using System.Threading.Tasks;
using CurrencyExchangeService.BusinessLogic.Models;

namespace CurrencyExchangeService.BusinessLogic.Integration
{
    public interface IFixerCurrencyService
    {
        Task<MoneyModel> Convert(MoneyModel source, Currencies currency);
    }
}