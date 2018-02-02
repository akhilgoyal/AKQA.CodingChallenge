﻿using System.Web.Http;
using AKQA.CodingChallenge.Service;

namespace AKQA.CodingChallenge.Service.Controllers
{
    [RoutePrefix("api/converter")]
    public class AmountConverterController : ApiController
    {
        [Route("Currency/{amount:decimal}/")]
        [HttpGet]
        public string ConvertCurrencyIntoWord(decimal amount)
        {
            return AmountHandler.ConvertToWord(amount);
        }
    }
}
