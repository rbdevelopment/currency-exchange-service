using CurrencyExchangeService.BusinessLogic.Models;

namespace CurrencyExchangeService.BusinessLogic.Mapper
{
    public class MoneyMapper : IMoneyMapper
    {
        private readonly ICurrencyMapper _currencyMapper;

        public MoneyMapper(ICurrencyMapper currencyMapper)
        {
            _currencyMapper = currencyMapper;
        }

        public MoneyModel MapValues(string currency, decimal amount)
        {
            return new MoneyModel {Amount = amount, Currency = _currencyMapper.MapCurrency(currency)};
        }
    }
}