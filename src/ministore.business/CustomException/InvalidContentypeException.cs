using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministore.business.CustomException
{
    public  class InvalidContentypeException:Exception
    {
        public string Propertyname { get; set; }
     
        public InvalidContentypeException(string? message):base(message)
        {

        }
        public InvalidContentypeException(string? message,string? propertyname):base(message)
        {
            propertyname = Propertyname;
        }
        public InvalidContentypeException()
        {

        }

    }
}
