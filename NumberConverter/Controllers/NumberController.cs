using NumberConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace NumberConverter.Controllers
{
    public class NumberController : Controller
    {
       /// <summary>
       /// This method returns the result from WebApi
       /// </summary>
       /// <param name="id"></param>
       /// <param name="name"></param>
       /// <returns></returns>
        public ActionResult Index(ConvertedNumber convertedNumber)
        {
           // convertedNumber = (ConvertedNumber)TempData["ConvertedNumber"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60410/api/");
                //HTTP GET to get the word from double value
                var responseTask = client.GetAsync("NumberConverter/GetNumber?number=" + convertedNumber.Number);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    convertedNumber.Number = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    convertedNumber.Number = string.Empty;
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(convertedNumber);
        }
        /// <summary>
        /// This method returns the ViewResult
        /// </summary>
        /// <returns></returns>
        public ActionResult Input(ConvertedNumber convertedNumber)
        {
            if (ModelState.IsValid)
            {
                TempData["ConvertedNumber"] = convertedNumber;
               return RedirectToAction("Index", "Number",convertedNumber);
            }
            return View(convertedNumber);
        }
    }
}