using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML3___Jacob
{
    public enum Dressing { Creme_fraiche, Garlic, Thousand_island, Ceasar, Balsamic }
    public class Salad : ALaCarte
    {
        public Dressing ChosenDressing { get; set; }

        public Salad(int number, string name, string description, double price, MenuType type, bool isVegan, bool isOrganic, bool bigSize, Dressing chosenDressing) : base(number, name, description, price, type, isVegan, isOrganic, bigSize)
        {
            ChosenDressing = chosenDressing;
        }

        public override string ToString()
        {
            string saladString = base.ToString();
            saladString += $"\n\tComes with {ChosenDressing} as default";
            return saladString;
        }
    }
}
