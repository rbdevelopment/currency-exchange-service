using System.Threading.Tasks;
using CurrencyExchangeService.BusinessLogic.Integration.Models;

namespace CurrencyExchangeService.BusinessLogic.Integration
{
    public interface IFixerApiClient
    {
        Task<CurrencyModel> GetCurrencyDataAsync(string baseCurrency, string targetCurrency);
    }
}