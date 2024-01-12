using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministore.business.CustomException
{
    public class InvalidNullRefererenceException:Exception
    {
        public string PropertyName { get; set; }
        public InvalidNullRefererenceException(string? message) : base(message)
        {

        }
        public InvalidNullRefererenceException(string? message, string? propertyname) : base(message)
        {
            PropertyName = PropertyName;
        }
    }
}
