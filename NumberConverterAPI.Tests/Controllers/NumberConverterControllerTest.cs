using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NumberConverterAPI.Abstraction;
using NumberConverterAPI.Controllers;
using NumberConverterAPI.Services;

namespace NumberConverterAPI.Tests.Controllers
{
    [TestClass]
    public class NumberConverterControllerTest
    {
        private Mock<INumberConverterService> _mockNumberConverterService = new Mock<INumberConverterService>();
        /// <summary>
        /// This test method will be passed if it returns an OK result
        /// </summary>
        [TestMethod]
        public void ConvertNumberToWords_ReturnsOK()
        {
            double number = 12.23;
            var numberConverterService = new NumberConverterService();
            var controller = new NumberConverterController(numberConverterService);
            // Act
            IHttpActionResult actionResult = controller.GetNumber(number);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);


        }
    }\
}
