using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigsApplication.Core.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime datetime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                 "dd MMM yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out datetime);
            return (isValid && DateTime.Parse(datetime.ToShortDateString()) >= DateTime.Parse(DateTime.Now.ToShortDateString()) || value == null);

        }
    }
}