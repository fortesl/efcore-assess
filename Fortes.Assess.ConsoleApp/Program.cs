
using System;
using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fortes.Assess.ConsoleApp
{
    class Program
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static string users;

        static void Main(string[] args)
        {
            GetUsers();

        }

        private static async void GetUsers()
        {
            object p = await RetrieveUsers();
            users = p.ToString();
            Console.WriteLine(users);

        }
        private static async Task<string> RetrieveUsers()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/api/users");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("user-agent", "TestApp");

            var response = await _httpClient.SendAsync(request);


            return await response.Content.ReadAsStringAsync();
        }
    }
}
