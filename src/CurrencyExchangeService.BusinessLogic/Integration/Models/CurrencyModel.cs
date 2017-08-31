using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CurrencyExchangeService.BusinessLogic.Integration.Models
{
    [DataContract]
    public class CurrencyModel
    {
        [DataMember(Name = "base")]
        public string BaseCurrency { get; set; }

        [DataMember(Name = "rates")]
        public Dictionary<string, decimal> Rates { get; set; }
    }
}