using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CurrencyExchangeService.BusinessLogic.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Currencies
    {
        [EnumMember(Value = null)] Unknown,
        [EnumMember(Value = "EUR")] Euro,
        [EnumMember(Value = "GBP")] PoundSterling,
        [EnumMember(Value = "USD")] UsDollar
    }
}