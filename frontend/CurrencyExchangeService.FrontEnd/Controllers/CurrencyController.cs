using System.Threading.Tasks;
using System.Web.Http;
using CurrencyExchangeService.BusinessLogic.Models;
using CurrencyExchangeService.BusinessLogic.Services;

namespace CurrencyExchangeService.FrontEnd.Controllers
{
    [RoutePrefix("api")]
    public class CurrencyController : ApiController
    {
        private readonly IExchangeService _exchangeService;

        public CurrencyController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        [Route("exchange/{sourceCurrency}/{targetCurrency}/{amount}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetEquivalentAsync(string sourceCurrency, string targetCurrency, decimal amount)
        {
            var result = await _exchangeService.Convert(sourceCurrency, targetCurrency, amount);
            if (result == null || result.Currency == Currencies.Unknown)
                return BadRequest("Incorrect set of currencies");

            return Json(result);
        }
    }
}