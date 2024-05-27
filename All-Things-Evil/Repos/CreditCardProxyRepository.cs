using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UBB_SE_2024_Evil.Models;

namespace All_Things_Evil.Repos
{
    public class CreditCardProxyRepository : ICreditCardProxyRepository
    {
        private const string SERVER_URL = "https://localhost:7224";

        public CreditCardProxyRepository()
        {
        }
        public async void SaveCreditCard(CreditCard card)
        {
            var json = JsonSerializer.Serialize(card);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(SERVER_URL + "/api/CreditCards", data);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error: " + response.ReasonPhrase);
                }
            }
        }
    }
}
