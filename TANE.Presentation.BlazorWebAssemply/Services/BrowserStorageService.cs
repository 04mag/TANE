using Microsoft.JSInterop;
using System.Text.Json;

namespace TANE.Presentation.BlazorWebAssemply.Services
{
    public class BrowserStorageService
    {
        private readonly IJSRuntime _jsRuntime;

        public BrowserStorageService(IJSRuntime jSRuntime)
        {
            _jsRuntime = jSRuntime;
        }

        public async Task SaveToLocalStorage<Type>(string key, Type value)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, SerializeToJson(value));
        }

        public async Task<Type?> GetFromLocalStorage<Type>(string key)
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            return DeserializeFromJson<Type?>(json);
        }

        public async Task RemoveFromLocalStorage(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        private static string SerializeToJson<Type>(Type value)
        {
            return JsonSerializer.Serialize(value);
        }

        private static Type? DeserializeFromJson<Type>(string? json)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                return JsonSerializer.Deserialize<Type>(json);
            }
            return default;
        }
    }
}
