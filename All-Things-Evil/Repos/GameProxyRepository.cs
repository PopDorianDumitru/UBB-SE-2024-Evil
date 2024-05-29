using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using All_Things_Evil.Services;
using UBB_SE_2024_Evil.Models.Spartacus;

namespace All_Things_Evil.Repos
{
    public class GameProxyRepository : IGameProxyRepository
    {
        private const string SERVER_URL = "http://localhost:5002";
        public GameProxyRepository()
        {
        }

        public async Task<List<GameSave>> GetGameSaves(int userId)
        {
            var json = JsonSerializer.Serialize(userId);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(SERVER_URL + "/api/GameSaves");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error: " + response.ReasonPhrase);
                }
                var responseString = await response.Content.ReadAsStringAsync();
                List<GameSave> gameSaves = JsonSerializer.Deserialize<List<GameSave>>(responseString);
                return gameSaves;
            }
        }

        public async void SaveGame(GameSave gameSave)
        {
            var json = JsonSerializer.Serialize(gameSave);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsync(SERVER_URL + "/api/GameSaves/" + gameSave.Id.ToString(), data);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error: " + response.ReasonPhrase);
                }
            }
        }

        public async Task<GameSave> LoadSave(int id)
        {
            var json = JsonSerializer.Serialize(id);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(SERVER_URL + "/api/GameSaves/" + id.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error: " + response.ReasonPhrase);
                }
                var responseString = await response.Content.ReadAsStringAsync();
                GameSave gameSave = JsonSerializer.Deserialize<GameSave>(responseString);
                return gameSave;
            }
        }

        public async Task<GameSave> NewSave(GameSave runName)
        {
            var json = JsonSerializer.Serialize(runName);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(SERVER_URL + "/api/GameSaves", data);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error: " + response.ReasonPhrase);
                }
                var responseString = await response.Content.ReadAsStringAsync();
                GameSave gameSave = JsonSerializer.Deserialize<GameSave>(responseString);
                return gameSave;
            }
        }
    }
}
