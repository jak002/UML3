using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML3___Jacob
{
    public class ExtraTopping : MenuItem
    {
        public ExtraTopping(int number, string name, string description, double price, MenuType type, bool isVegan, bool isOrganic) : base(number, name, description, price, type, isVegan, isOrganic)
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
