using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FoodOrderApp_Test.Validations
{
    internal class EmailValidation : ValidationRule
    {
        public string ErrorMessage { get; set; }
        public string ErrorMessageNull { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);
            if (value == null)
                return result;
            if (value.ToString() == "")
            {
                return new ValidationResult(false, this.ErrorMessageNull);
            }
            //Regex regex = new Regex(@"^[a-zA-Z0-9_]+$");
            if (!value.ToString().Contains("@gmail.com"))
                return new ValidationResult(value.ToString().Contains("@gmail.com"), this.ErrorMessage);
            return result;
        }
    }
}