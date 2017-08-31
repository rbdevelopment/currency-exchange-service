using System.Runtime.Serialization;

namespace CurrencyExchangeService.BusinessLogic.Models
{
    [DataContract(Name = "money")]
    public class MoneyModel
    {
        [DataMember(Name = "currency")]
        public Currencies Currency { get; set; }

        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }
    }
}