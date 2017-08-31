using System.Web.Mvc;

namespace CurrencyExchangeService.FrontEnd.Controllers
{
    public class DefaultController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}