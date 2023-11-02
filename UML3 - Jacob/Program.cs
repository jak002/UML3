// See https://aka.ms/new-console-template for more information
using UML3___Jacob;

Console.WriteLine("Hello, World!");


IMenuCatalog catalog = new MenuCatalog();
Pizza p1 = new(12, "Garlic", "Tomato sauce, vegan cheese, garlic oil, basil", 75, MenuType.Pizza, true, true, false);
Pizza p2 = new(7, "Kebab", "Tomato sauce, cheese, kebab, lettuce, onion, cucumber, tomato, dressing", 80, MenuType.Pizza, false, false, true);
Pizza p3 = new(2, "Vesuvio", "Tomato sauce, cheese, ham", 69, MenuType.Pizza, false, true, false);
Beverage b1 = new(87, "Ice tea", "Peach, 330ml", 15, MenuType.SoftDrink, true, false, false);
Beverage b2 = new(88, "Juice", "Italian apple juice, 330ml", 20, MenuType.SoftDrink, true, true, false);
Beverage b3 = new(89,"Soda","Choose between pepsi, sprite, and other shit. 330ml",15,MenuType.SoftDrink,false,false, false);

Console.WriteLine($"Amount of pizzas in menu before adding: {catalog.Count}");
catalog.Add(p1);
catalog.Add(p2);
catalog.Add(p3);
try
{
    catalog.Add(p1);
}
catch (MenuItemNumberExists mex)
{
    Console.WriteLine($"Succesfully stopped from adding twice. {mex.Message}");
}
Console.WriteLine($"Amount of pizzas in menu before adding: {catalog.Count}");

catalog.Add(b1);
catalog.Add(b2);
catalog.Add(b3);
//testing search
IMenuItem foundItem = catalog.Search(12);
if (foundItem != null)
{
    Console.WriteLine($"Found: {foundItem}");
}

//testing FindAllVegan
List<IMenuItem> VeganPizzas = catalog.FindAllVegan(MenuType.Pizza);
foreach(IMenuItem item in VeganPizzas) Console.WriteLine(item);

Console.WriteLine("Finding vegan beverages");
List<IMenuItem> VeganBeverages = catalog.FindAllVegan(MenuType.SoftDrink);
foreach(IMenuItem item in VeganBeverages) Console.WriteLine(item);