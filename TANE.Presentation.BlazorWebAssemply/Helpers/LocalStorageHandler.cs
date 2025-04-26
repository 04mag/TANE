using Blazored.LocalStorage;

namespace TANE.Presentation.BlazorWebAssemply.Helpers
{
    public class LocalStorageHandler
    {
        private readonly ILocalStorageService _localStorage;
        public LocalStorageHandler(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }
        
        public async Task SetJwtAsync(string token, string refreshToken, string tokenExpiriation)
        {
            await SetTokenAsync(token);
            await SetRefreshTokenAsync(refreshToken);
            await SetTokenExpirationAsync(tokenExpiriation);
        }

        public async Task SetTokenAsync(string value)
        {
            await _localStorage.SetItemAsync("token", value);
        }

        public async Task<string?> GetTokenAsync()
        {
            return await _localStorage.GetItemAsync<string>("token");
        }

        public async Task RemoveTokenAsync()
        {
            await _localStorage.RemoveItemAsync("token");
        }

        public async Task SetRefreshTokenAsync(string value)
        {
            await _localStorage.SetItemAsync("refreshToken", value);
        }

        public async Task<string?> GetRefreshTokenAsync()
        {
            return await _localStorage.GetItemAsync<string>("refreshToken");
        }

        public async Task RemoveRefreshTokenAsync()
        {
            await _localStorage.RemoveItemAsync("refreshToken");
        }

        public async Task SetTokenExpirationAsync(string value)
        {
            await _localStorage.SetItemAsync("tokenexpiration", value);
        }

        public async Task<string?> GetTokenExpirationAsync()
        {
            return await _localStorage.GetItemAsync<string>("tokenexpiration");
        }

        public async Task RemoveTokenExpirationAsync()
        {
            await _localStorage.RemoveItemAsync("tokenexpiration");
        }
    }
}
