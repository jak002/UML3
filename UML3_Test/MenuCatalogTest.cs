using UML3___Jacob;

namespace UML3_Test
{
    [TestClass]
    public class MenuCatalogTest
    {
        MenuCatalog cat;
        Pizza p1;
        Pizza p2;
        Pizza p3;
        Pizza p4;
        Beverage b1;
        Beverage b2;
        Beverage b3;
        public void Setup()
        {
            cat = new MenuCatalog();
            p1 = new(12, "Garlic", "Tomato sauce, vegan cheese, garlic oil, basil", 75, MenuType.Pizza, true, true, false);
            p2 = new(7, "Kebab", "Tomato sauce, cheese, kebab, lettuce, onion, cucumber, tomato, dressing", 80, MenuType.Pizza, false, false, true);
            p3 = new(2, "Vesuvio", "Tomato sauce, cheese, ham", 69, MenuType.Pizza, false, true, false);
            p4 = new(17, "Chili", "Spicy tomato sauce, vegan cheese, paprika, beans", 90, MenuType.Pizza, true, false, true);
            b1 = new(87, "Ice tea", "Peach, 330ml", 15, MenuType.SoftDrink, true, false, false);
            b2 = new(88, "Juice", "Italian apple juice, 330ml", 20, MenuType.SoftDrink, true, true, false);
            b3 = new(89, "Soda", "Choose between pepsi, sprite, and other shit. 330ml", 15, MenuType.SoftDrink, false, false, false);
        }
        public void AddStandards()
        {
            cat.Add(p1);
            cat.Add(p2);
            cat.Add(p3);
            cat.Add(p4);
            cat.Add(b1);
            cat.Add(b2);
            cat.Add(b3);
        }

        [TestMethod]
        public void Add_1MenuItem()
        {
            //arrange
            Setup();
            //act
            int numbersBefore = cat.Count;
            cat.Add(new Pizza(12, "Test", "Test", 60, MenuType.Pizza, false, false, false));
            int numbersAfter = cat.Count;
            //assert
            Assert.AreEqual(numbersBefore+1, numbersAfter);
        }

        [TestMethod]
        [ExpectedException(typeof(MenuItemNumberExists))]
        public void Add_ExistingItem()
        {
            //arrange
            Setup();
            AddStandards();
            //act
            cat.Add(new Pizza(12, "Test", "Test", 60, MenuType.Pizza, false, false, false));
            //assert
        }

        [TestMethod]
        public void Search_ExistingItem()
        {
            //arrange
            Setup();
            Pizza ptest = new Pizza(12, "Test", "Test", 60, MenuType.Pizza, false, false, false);
            cat.Add(ptest);
            //act
            IMenuItem found = cat.Search(12);
            //assert
            Assert.AreSame(ptest, found);
        }

        [TestMethod]
        [ExpectedException(typeof(MenuItemNumberExists))]
        public void Search_NonexistantItem()
        {
            //arrange
            Setup();
            Pizza ptest = new Pizza(12, "Test", "Test", 60, MenuType.Pizza, false, false, false);
            cat.Add(ptest);
            //act
            IMenuItem found = cat.Search(5);
            //assert
        }

        [TestMethod]
        public void Update_ValidItem()
        {
            //arrange
            Setup();
            AddStandards();
            Pizza ptest = new Pizza(12, "Test", "Test", 60, MenuType.Pizza, false, false, false);
            //act
            cat.Update(12, ptest);
            //assert
            Assert.AreSame(ptest,cat.Search(12));
        }

        [TestMethod]
        [ExpectedException(typeof(MenuItemNumberExists))]
        public void Update_InvalidItem()
        {
            //arrange
            Setup();
            AddStandards();
            Pizza ptest = new Pizza(5, "Test", "Test", 60, MenuType.Pizza, false, false, false);
            //act
            cat.Update(12, ptest);
            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(MenuItemNumberExists))]
        public void Update_NonexistantItem()
        {
            //arrange
            Setup();
            AddStandards();
            Pizza ptest = new Pizza(5, "Test", "Test", 60, MenuType.Pizza, false, false, false);
            //act
            cat.Update(5, ptest);
            //assert
        }

        [TestMethod]
        public void Delete_1Item()
        {
            //arrange
            Setup();
            AddStandards();
            //act
            int numbersBefore = cat.Count;
            cat.Delete(12);
            int numbersAfter = cat.Count;
            //assert
            Assert.AreEqual(numbersBefore-1, numbersAfter);
        }

        [TestMethod]
        [ExpectedException(typeof(MenuItemNumberExists))]
        public void Delete_NonexistantItem()
        {
            //arrange
            Setup();
            AddStandards();
            //act
            cat.Delete(5);
            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(MenuItemNumberExists))]
        public void Delete_EmptyCatalog()
        {
            //arrange
            Setup();
            //act
            cat.Delete(12);
            //assert
        }

        [TestMethod]
        public void FindVegan()
        {
            //arrange
            Setup();
            AddStandards();
            //act
            List<IMenuItem> veganList = cat.FindAllVegan(MenuType.Pizza);
            //assert
            Assert.AreEqual(veganList.Count, 2);
        }

        [TestMethod]
        public void FindOrganic()
        {
            //arrange
            Setup();
            AddStandards();
            //act
            List<IMenuItem> veganList = cat.FindAllOrganic(MenuType.Pizza);
            //assert
            Assert.AreEqual(veganList.Count, 2);
        }

        [TestMethod]
        public void MostExpensive_Valid()
        {
            //arrange
            Setup();
            Salad ExpensiveItem = new Salad(5, "Money salad", "Just money. Seriously, it's a bowl of money", 99999, MenuType.Pasta, true, false, false, Dressing.Thousand_island);
            cat.Add(ExpensiveItem);
            AddStandards();
            //act
            IMenuItem found = cat.MostExpensiveMenuItem();
            //assert
            Assert.AreSame(ExpensiveItem, found);
        }

        [TestMethod]
        [ExpectedException(typeof(MenuItemNumberExists))]
        public void MostExpensive_Invalid()
        {
            //arrange
            Setup();
            //act
            IMenuItem found = cat.MostExpensiveMenuItem();
            //assert
        }
    }
}