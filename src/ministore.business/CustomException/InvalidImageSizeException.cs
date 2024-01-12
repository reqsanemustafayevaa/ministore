using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministore.business.CustomException
{
    public  class InvalidImageSizeException:Exception
    {
        public string Propertyname { get; set; }
       
        public InvalidImageSizeException(string? message) : base(message)
        {

        }
        public InvalidImageSizeException(string? message, string? propertyname) : base(message)
        {
            propertyname = Propertyname;
        }
        public InvalidImageSizeException()
        {

        }
    }
}
