using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiz.ViewModels
{
    public class ValidCorrectAnswer : ValidationAttribute
    {
        public override bool IsValid(object value)
        {



            return base.IsValid(value);
        }

    }
}