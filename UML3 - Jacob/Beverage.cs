using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML3___Jacob
{
    public class Beverage : MenuItem
    {
        public bool Alcohol { get; set; }

        public Beverage(int number, string name, string description, double price, MenuType type, bool isVegan, bool isOrganic, bool alcohol):base(number,name,description,price,type,isVegan,isOrganic)
        {
            Alcohol = alcohol;
        }

        public override string ToString()
        {
            string drinkString = base.ToString();
            if (Alcohol) drinkString += "\n\tContains alcohol";
            return drinkString;
        }
    }
}
