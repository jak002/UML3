using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML3___Jacob
{
    public class MenuItemNumberExists : Exception
    {
        public MenuItemNumberExists():base()
        {
            
        }
        public MenuItemNumberExists(string message):base(message)
        {
            
        }
    }
}
