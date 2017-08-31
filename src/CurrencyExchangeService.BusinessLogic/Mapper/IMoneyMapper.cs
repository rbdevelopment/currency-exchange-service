using CurrencyExchangeService.BusinessLogic.Models;

namespace CurrencyExchangeService.BusinessLogic.Mapper
{
    public interface IMoneyMapper
    {
        MoneyModel MapValues(string currency, decimal amount);
    }
}