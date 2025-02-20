using GameStore.Client.Models;
using System.Net.Http.Json;

namespace GameStore.Client.Clients;

public class AuthenticatedClient
{
    private readonly HttpClient httpClient;

    public AuthenticatedClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task AddGameAsync(Game game)
    {
        // await httpClient.PostAsJsonAsync("games", game);
         await httpClient.PostAsJsonAsync("v1/games", game);
    }

    public async Task<Game> GetGameAsync(int id)
    {
        //return await httpClient.GetFromJsonAsync<Game>($"games/{id}") ?? throw new Exception("Could not find game!");
        return await httpClient.GetFromJsonAsync<Game>($"v1/games/{id}") ?? throw new Exception("Could not find game!");
    }

    public async Task UpdateGameAsync(Game updatedGame)
    {
        //await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);
        await httpClient.PutAsJsonAsync($"v1/games/{updatedGame.Id}", updatedGame);
    }

    public async Task DeleteGameAsync(int id)
    {
        //await httpClient.DeleteAsync($"games/{id}");
        await httpClient.DeleteAsync($"v1/games/{id}");
    }
}