using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INI.CustomExceptions
{
    public class INIPropertyNotFoundException : Exception
    {
        public INIPropertyNotFoundException()
            :base("INI Property not found"){}
        
        public INIPropertyNotFoundException(string exMsg)
            :base(exMsg){}

        public INIPropertyNotFoundException(string exMsg, Exception innerException)
            :base(exMsg, innerException){}
    }
}
