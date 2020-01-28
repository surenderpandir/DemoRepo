using NumberConverterAPI.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace NumberConverterAPI.Controllers
{
    [RoutePrefix("api/NumberConverter")]
    public class NumberConverterController : ApiController
    {
        #region MyRegion
        private INumberConverterService _numberConverterService;
        #endregion
        /// <summary>
        /// Constructor to inject the service
        /// </summary>
        /// <param name="numberConverterService"></param>
        public NumberConverterController(INumberConverterService numberConverterService)
        {
            _numberConverterService = numberConverterService;
        }
        /// <summary>
        /// Action method to get the word from number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetNumber")]
        public IHttpActionResult GetNumber(double number)
        {
            string Word = _numberConverterService.ConvertNumberToWords(number);
            if (!String.IsNullOrEmpty(Word))
            {
                return Ok(Word);
            }
            else
            {
                return InternalServerError();
            }
        }

    }
}
