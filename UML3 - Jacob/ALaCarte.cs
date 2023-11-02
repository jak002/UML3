using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML3___Jacob
{
	public class ALaCarte : MenuItem
	{

		public bool BigSize
		{
            get; set;
		}

        public ALaCarte(int number, string name, string description, double price, MenuType type, bool isVegan, bool isOrganic, bool bigSize):base(number,name,description,price,type,isVegan,isOrganic)
        {
            BigSize = bigSize;
        }

        public override string ToString()
        {
            string aLaCarteString =  base.ToString();
            if (!BigSize) aLaCarteString += "\n\t- Small";
            else aLaCarteString += "\n\t- Big";
            return aLaCarteString;
        }
    }
}
