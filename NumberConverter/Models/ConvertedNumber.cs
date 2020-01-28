using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NumberConverter.Models
{
    public class ConvertedNumber
    {
        [Required(ErrorMessage = "Name is Requird")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Number is Requird")]
        public string Number { get; set; }
    }
}