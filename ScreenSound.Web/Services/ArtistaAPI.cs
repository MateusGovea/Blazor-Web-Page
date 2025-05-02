using ScreenSound.Web.Requests;
using ScreenSound.Web.Response;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services;

public class ArtistaAPI
{
    private readonly HttpClient _httpClient;

    public ArtistaAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    // GET
    public async Task<ICollection<ArtistaResponse>?> GetArtistasAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<ArtistaResponse>>("artistas");
    }

    // GET by Nome
    public async Task<ArtistaResponse?> GetArtistaPorNomeAsync(string nome)
    {
        return await _httpClient.GetFromJsonAsync<ArtistaResponse>($"artistas/{nome}");
    } 

    // POST
    public async Task AddArtistaAsync(ArtistaRequest artista)
    {
        await _httpClient.PostAsJsonAsync("artistas", artista);
    }

    // DELETE
    public async Task DeleteArtistaAsync(int id)
    {
        await _httpClient.DeleteAsync($"artistas/{id}");
    }

    // PUT
    public async Task EditarArtistaAsync(ArtistaRequestEdit artista)
    {
        await _httpClient.PutAsJsonAsync("artistas", artista);
    }
}
