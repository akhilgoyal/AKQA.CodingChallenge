using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Customer = AKQA.CodingChallenge.Web.Models.Customer;

namespace AKQA.CodingChallenge.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IResultClient _resultClient;

        public HomeController(IResultClient resultClient)
        {
            _resultClient = resultClient ?? throw new ArgumentNullException(nameof(resultClient));
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConvertToWord(Customer customer)
        {
            var results = _resultClient.GetAmountInWords(customer.Amount);
            customer.WordAmount = results;
            return View("~/Views/Home/Index.cshtml", customer);
        }
    }
}