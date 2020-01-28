using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NumberConverterAPI.Abstraction;
using NumberConverterAPI.Common;

namespace NumberConverterAPI.Services
{
    public class NumberConverterService : INumberConverterService
    {
        public string ConvertNumberToWords(double doubleNumber)
        {
            var beforeFloatingPoint = (int)Math.Floor(doubleNumber);
            var beforeFloatingPointWord = $"{NumberConverterHelper.NumberToWords(beforeFloatingPoint)} dollars";
            var afterFloatingPointWord =
                $"{NumberConverterHelper.SmallNumberToWord((int)Math.Round((((doubleNumber - beforeFloatingPoint)) * 100),2), "")} cents";
            return $"{beforeFloatingPointWord} and {afterFloatingPointWord}";
        }

       
    }
}