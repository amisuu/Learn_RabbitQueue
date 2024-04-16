using MVC.Models.Dto;
using MVC.Services.Interfaces;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _httpClient;

        public TransferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Transfer(TransferDto transferDto)
        {
            var url = "https://localhost:7008/api/Banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDto),
                                                    System.Text.Encoding.UTF8,
                                                    "application/json");
            var response = await _httpClient.PostAsync(url, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
