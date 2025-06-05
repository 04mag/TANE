using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using System.Security.Claims;
using System.Threading.Tasks;
using TANE.Application.Common.Exceptions;
using TANE.Application.Groups.JwtTokens.Commands.Interfaces;
using TANE.Domain.Entities;
using TANE.Presentation.BlazorWebAssemply.Services;

namespace TANE.Presentation.BlazorWebAssemply.Authentication
{
    public class CustomStateProvider : AuthenticationStateProvider
    {
        private const string authenticationType = "apiauth_type";
        private const string userStorageKey = "user";
        private readonly BrowserStorageService _browserStorageService;
        private readonly IUserLogin _userLogin;
        private readonly IRefreshToken _refreshToken;

        public CustomStateProvider(BrowserStorageService browserStorageService, IUserLogin userLogin, IRefreshToken refreshToken)
        {
            _browserStorageService = browserStorageService;
            _userLogin = userLogin;
            _refreshToken = refreshToken;
            AuthenticationStateChanged += CustomStateProvider_AuthenticationStateChanged;
        }

        private async void CustomStateProvider_AuthenticationStateChanged(Task<AuthenticationState> task)
        {
            var authState = await task;

            if (authState is not null)
            {
                if (authState.User.Identity != null)
                {
                    CurrentUser = new User
                    {
                        Email = authState.User.Identity?.Name!,
                        Roles = authState.User.FindFirst(ClaimTypes.Role)?.Value.Split(",").ToList()!,
                        Token = authState.User.FindFirst("Token")?.Value!,
                        RefreshToken = authState.User.FindFirst("RefreshToken")?.Value!,
                        Expiration = DateTime.Parse(authState.User.FindFirst("Expiration")?.Value!)
                    };
                }
                return;
            }
            CurrentUser = new User();
        }

        public User CurrentUser { get; set; } = new User();

        //Gets called when app first starts to get the authentication state
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = await _browserStorageService.GetFromLocalStorage<User>(userStorageKey);

            if (user is null)
            {
                //User is not logged in
                CurrentUser = new User();
                return new AuthenticationState(new ClaimsPrincipal());
            }
            else
            {
                //User is logged in
                CurrentUser = user;

                var authState = GenerateAuthState(user);

                return authState;
            }
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            try
            {
                var result = await _userLogin.LoginAsync(username, password);

                await _browserStorageService.SaveToLocalStorage(userStorageKey, result);

                var authState = GenerateAuthState(result);

                NotifyAuthenticationStateChanged(Task.FromResult(authState));
                return result.Token;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task LogoutAsync()
        {
            await _browserStorageService.RemoveFromLocalStorage(userStorageKey);
            var authState = new AuthenticationState(new ClaimsPrincipal());
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task RefreshTokenAsync(NavigationManager navigationManager, NotificationService notificationService)
        {
            var user = await _browserStorageService.GetFromLocalStorage<User>(userStorageKey);
            
            if (user is null)
            {
                return;
            }

            try
            {
                var result = await _refreshToken.RefreshTokenAsync(user.Token, user.RefreshToken);

                user.Token = result.Token;
                user.RefreshToken = result.RefreshToken;
                user.Expiration = result.Expiration;
            }
            catch (RefreshTokenExpiredException)
            {
                await LogoutAsync();

                notificationService.Notify(new NotificationMessage()
                {
                    Severity = NotificationSeverity.Error,
                    Summary = "Session expired",
                    Detail = "Din session er udløbet. Log venligt ind igen.",
                    Duration = 5000
                });

                navigationManager.NavigateTo("/login");
                return;
            }
            catch (Exception)
            {

                //await LogoutAsync();


                //notificationService.Notify(new NotificationMessage()
                //{
                //    Severity = NotificationSeverity.Error,
                //    Summary = "Session expired",
                //    Detail = "Your session has expired. Please log in again.",
                //    Duration = 5000
                //});


                //navigationManager.NavigateTo("/login");
                //return;
            }

            await _browserStorageService.SaveToLocalStorage(userStorageKey, user);

            var authState = GenerateAuthState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        private static AuthenticationState GenerateAuthState(User user)
        {
            Claim[] claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, string.Join(",", user.Roles)),
                    new Claim("Token", user.Token),
                    new Claim("RefreshToken", user.RefreshToken),
                    new Claim("Expiration", user.Expiration.ToString())
                };

            var identity = new ClaimsIdentity(claims, authenticationType);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(claimsPrincipal);

            return authState;
        }
    }
}
