using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReTek_CarMechanical.Helpers
{
    public class StringValidationRule : ValidationRule
    {
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value.ToString();
            bool rt = Regex.IsMatch(input, "^[0-9.,\\s]*$");
            if (!rt)
            {
                return new ValidationResult(false, this.ErrorMessage);
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
