using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML3___Jacob
{
    public class MenuItem : IMenuItem
    {
        public int Number { get; }

        public string Name { get ; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public MenuType Type { get; set; }
        public bool IsVegan { get; set; }
        public bool IsOrganic { get; set; }

        public MenuItem(int number, string name, string description, double price, MenuType type, bool isVegan, bool isOrganic)
        {
            Number = number;
            Name = name;
            Description = description;
            Price = price;
            Type = type;
            IsVegan = isVegan;
            IsOrganic = isOrganic;
        }
        public override string ToString()
        {
            string itemString = $"{Number}.\t{Name}\t\t{Price}kr.";
            itemString += $"\n\t-{Description}";
            if (IsVegan || IsOrganic)
            {
                itemString += "\n\t";
                if (IsVegan) itemString += "V";
                if (IsVegan && IsOrganic) itemString += ", ";
                if (IsOrganic) itemString += "O";
            }
            return itemString;
        }
    }
}
