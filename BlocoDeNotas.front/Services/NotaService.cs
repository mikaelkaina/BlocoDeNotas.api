using System.Net.Http.Headers;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using BlocoDeNotas.front.Models;

namespace BlocoDeNotas.front.Services
{
    public class NotaService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;

        public NotaService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }

        private async Task SetAuthHeaderAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            if (!string.IsNullOrEmpty(token))
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<List<NotaModel>> GetNotasAsync()
        {
            await SetAuthHeaderAsync();
            return await _http.GetFromJsonAsync<List<NotaModel>>("api/notas") ?? new();
        }

        public async Task<bool> CriarNotaAsync(NotaModel nota)
        {
            await SetAuthHeaderAsync();
            var response = await _http.PostAsJsonAsync("api/notas", nota);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AtualizarNotaAsync(NotaModel nota)
        {
            await SetAuthHeaderAsync();
            var response = await _http.PutAsJsonAsync($"api/notas/{nota.Id}", nota);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletarNotaAsync(int id)
        {
            await SetAuthHeaderAsync();
            var response = await _http.DeleteAsync($"api/notas/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}