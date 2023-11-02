using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML3___Jacob
{
    public interface IMenuCatalog
    {
        int Count { get; }
        void Add(IMenuItem aMenuItem);
        IMenuItem Search(int number);
        void Delete(int number);
        void PrintPizzasMenu();
        void PrintBeveragesMenu();
        void PrintToppingsMenu();
        void Update(int number, IMenuItem theMenuItem);
        List<IMenuItem> FindAllVegan(MenuType type);
        List<IMenuItem> FindAllOrganic(MenuType type);
        IMenuItem MostExpensiveMenuItem();
    }
}
