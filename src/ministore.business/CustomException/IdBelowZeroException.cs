using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministore.business.CustomException
{
    public class IdBelowZeroException:Exception
    {
        public string PropertyName { get; set; }
        public IdBelowZeroException(string? message):base(message)
        {

        }
        public IdBelowZeroException(string? message,string? propertyname):base(message)
        {
            PropertyName = PropertyName;
        }
    }
}
