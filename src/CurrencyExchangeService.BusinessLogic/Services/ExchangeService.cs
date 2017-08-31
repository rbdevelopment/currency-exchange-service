using System.Threading.Tasks;
using CurrencyExchangeService.BusinessLogic.Integration;
using CurrencyExchangeService.BusinessLogic.Mapper;
using CurrencyExchangeService.BusinessLogic.Models;

namespace CurrencyExchangeService.BusinessLogic.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IFixerCurrencyService _currencyService;
        private readonly IMoneyMapper _moneyMapper;
        private readonly ICurrencyMapper _currencyMapper;

        public ExchangeService(
            IFixerCurrencyService currencyService,
            IMoneyMapper moneyMapper,
            ICurrencyMapper currencyMapper)
        {
            _currencyService = currencyService;
            _moneyMapper = moneyMapper;
            _currencyMapper = currencyMapper;
        }

        public Task<MoneyModel> Convert(string source, string target, decimal amount)
        {
            var targetCurrency = _currencyMapper.MapCurrency(target);
            if (targetCurrency == Currencies.Unknown)
                return null;

            var model = _moneyMapper.MapValues(source, amount);
            return _currencyService.Convert(model, targetCurrency);
        }
    }
}