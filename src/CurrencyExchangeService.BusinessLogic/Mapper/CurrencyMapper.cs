using CurrencyExchangeService.BusinessLogic.Models;

namespace CurrencyExchangeService.BusinessLogic.Mapper
{
    public class CurrencyMapper : ICurrencyMapper
    {
        public Currencies MapCurrency(string currencyName)
        {
            if (string.IsNullOrWhiteSpace(currencyName))
                return Currencies.Unknown;

            var name = currencyName.ToLower();
            switch (name)
            {
                case "usd":
                    return Currencies.UsDollar;
                case "gbp":
                    return Currencies.PoundSterling;
                case "eur":
                    return Currencies.Euro;
                default:
                    return Currencies.Unknown;
            }
        }

        public string MapCurrency(Currencies currency)
        {
            switch (currency)
            {
                case Currencies.Euro:
                    return "EUR";
                case Currencies.PoundSterling:
                    return "GBP";
                case Currencies.UsDollar:
                    return "USD";
                default:
                    return null;
            }
        }
    }
}