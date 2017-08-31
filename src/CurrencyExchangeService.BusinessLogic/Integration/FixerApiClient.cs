using System;
using System.Net.Http;
using System.Threading.Tasks;
using CurrencyExchangeService.BusinessLogic.Integration.Models;
using Newtonsoft.Json;

namespace CurrencyExchangeService.BusinessLogic.Integration
{
    public class FixerApiClient : IFixerApiClient
    {
        private readonly HttpClient _client;

        public FixerApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<CurrencyModel> GetCurrencyDataAsync(
            string baseCurrency, string targetCurrency)
        {
            var address = $"http://api.fixer.io/latest?base={baseCurrency}&symbols={targetCurrency}";

            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(address));
            var response = await _client.SendAsync(request).ConfigureAwait(false);

            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<CurrencyModel>(await response.Content.ReadAsStringAsync()) : null;
        }
    }
}