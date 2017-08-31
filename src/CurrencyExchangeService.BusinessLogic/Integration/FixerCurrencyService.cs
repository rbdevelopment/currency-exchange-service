using System.Threading.Tasks;
using CurrencyExchangeService.BusinessLogic.Mapper;
using CurrencyExchangeService.BusinessLogic.Models;

namespace CurrencyExchangeService.BusinessLogic.Integration
{
    public class FixerCurrencyService : IFixerCurrencyService
    {
        private readonly IFixerApiClient _apiClient;
        private readonly ICurrencyMapper _mapper;

        public FixerCurrencyService(IFixerApiClient apiClient, ICurrencyMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }

        public async Task<MoneyModel> Convert(MoneyModel source, Currencies currency)
        {
            var sourceCurrency = _mapper.MapCurrency(source.Currency);
            var targetCurrency = _mapper.MapCurrency(currency);
            if (string.IsNullOrWhiteSpace(sourceCurrency) || string.IsNullOrEmpty(targetCurrency))
                return null;

            if (sourceCurrency == targetCurrency)
                return source;

            var result = await _apiClient.GetCurrencyDataAsync(sourceCurrency, targetCurrency);
            if (result != null)
                if (result.Rates.ContainsKey(targetCurrency))
                {
                    var exchangeRate = result.Rates[targetCurrency];
                    return new MoneyModel {Amount = source.Amount * exchangeRate, Currency = currency};
                }

            return null;
        }
    }
}