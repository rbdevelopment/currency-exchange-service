using CurrencyExchangeService.BusinessLogic.Models;

namespace CurrencyExchangeService.BusinessLogic.Mapper
{
    public interface ICurrencyMapper
    {
        Currencies MapCurrency(string currencyName);
        string MapCurrency(Currencies currency);
    }
}