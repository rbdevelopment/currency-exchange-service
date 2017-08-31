using System.Threading.Tasks;
using CurrencyExchangeService.BusinessLogic.Models;

namespace CurrencyExchangeService.BusinessLogic.Services
{
    public interface IExchangeService
    {
        Task<MoneyModel> Convert(string source, string target, decimal amount);
    }
}