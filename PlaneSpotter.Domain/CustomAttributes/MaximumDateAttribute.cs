using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.Domain.CustomAttributes
{
    public class MaximumDateAttribute : ValidationAttribute
    {
        public MaximumDateAttribute()
        {

        }

        public override bool IsValid(object value)
        {
            var maxdate = (DateTime)value;
            bool result = true;

            if (maxdate > DateTime.Now)
            {
                result = false;
            }
            return result;
        }
    }
}
