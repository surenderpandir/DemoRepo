using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberConverterAPI.Abstraction
{
    public interface INumberConverterService
    {
        string ConvertNumberToWords(double doubleNumber);
    }
}