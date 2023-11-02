using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML3___Jacob
{
    public class MenuCatalog : IMenuCatalog
    {

        private Dictionary<int, IMenuItem> catalog;
        public MenuCatalog() 
        {
            //initialize collection
            catalog = new Dictionary<int, IMenuItem>();
        }
        public int Count { get { return catalog.Count; } }

        public void Add(IMenuItem aMenuItem)
        {
            if (catalog.ContainsKey(aMenuItem.Number))
            {
                throw new MenuItemNumberExists($"Item already exists with the number {aMenuItem.Number}");
            } else
            {
                catalog.Add(aMenuItem.Number, aMenuItem);
            }
        }

        public void Delete(int number)
        {
            if (!catalog.ContainsKey(number))
            {
                throw new MenuItemNumberExists($"No item found with the number {number}");
            } else
            {
                catalog.Remove(number);
            }
        }

        public List<IMenuItem> FindAllOrganic(MenuType type)
        {
            List<IMenuItem> organicItems = new List<IMenuItem>();
            foreach (IMenuItem item in catalog.Values)
            {
                if (item.IsOrganic & item.Type == type)
                {
                    organicItems.Add(item);
                }
            }
            return organicItems;
        }

        public List<IMenuItem> FindAllVegan(MenuType type)
        {
            List<IMenuItem> veganList = new List<IMenuItem>();
            foreach (IMenuItem item in catalog.Values) 
            { 
                if (item.IsVegan & item.Type == type) 
                { 
                    veganList.Add(item); 
                } 
            }
            return veganList;
        }

        public IMenuItem MostExpensiveMenuItem()
        {
            if (catalog.Count != 0)
            {
                IMenuItem returnedItem = null;
                double compare = 0.0;
                foreach (IMenuItem item in catalog.Values)
                {
                    if (item.Price > compare)
                    {
                        returnedItem = item;
                        compare = item.Price;
                    }
                }
                return returnedItem;
            }
            else throw new MenuItemNumberExists("No items found in list");
        }

        public void PrintBeveragesMenu()
        {
            foreach (IMenuItem item in catalog.Values)
            {
                if (item.Type == MenuType.SoftDrink || item.Type == MenuType.AlcoholicDrink) 
                {
                    Console.WriteLine($"{item}\n");
                }
            }
        }

        public void PrintPizzasMenu()
        {
            foreach (IMenuItem item in catalog.Values)
            {
                if (item.Type == MenuType.Pizza)
                {
                    Console.WriteLine($"{item}\n");
                }
            }
        }

        public void PrintToppingsMenu()
        {
            //optional
            foreach (IMenuItem item in catalog.Values)
            {
                if (item == typeof(ExtraTopping))
                {
                    Console.WriteLine($"{item}\n");
                }
            }
        }

        public IMenuItem Search(int number)
        {
            if (catalog.ContainsKey(number))
            {
                return catalog[number];
            }
            else
            {
                throw new MenuItemNumberExists($"No item found with the number {number}");
            }
        }

        public void Update(int number, IMenuItem theMenuItem)
        {
            if (catalog.ContainsKey(number))
            { if (catalog[number].Number == theMenuItem.Number)
                {
                    catalog[number] = theMenuItem;
                }
                else
                {
                    throw new MenuItemNumberExists($"Input number({number}) and item number{theMenuItem.Number} are inconsistent .");
                }
            } else
            {
                throw new MenuItemNumberExists($"No item found with the number {number}");
            }
        }
    }
}
