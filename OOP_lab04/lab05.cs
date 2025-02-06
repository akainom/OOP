using ProductHierarchy;
using System;
using System;
using System.Diagnostics;
using System.IO;
using CustomExceptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            try
            {
                int a = 10;
                int b = 0;
                int result = a / b;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: деление на ноль. {ex.Message}");
                throw;
            }

            try
            {
                int[] array = { 1, 2, 3 };
                int value = array[5];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: неверный индекс массива. {ex.Message}");
            }

            try
            {
                string input = "abc";
                if (!int.TryParse(input, out int result))
                {
                    throw new CustomExceptions.InvalidDataException("Ошибка: введены неверные данные.");
                }
            }
            catch (CustomExceptions.InvalidDataException ex)
            {
                Console.WriteLine($"Пользовательское исключение: {ex.Message}");
            }

            try
            {
                string path = "/nonexistentfile.txt";
                using (var reader = new StreamReader(path))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Ошибка работы с файлами: {ex.Message}");
            }

            try
            {
                string input = "";
                if (string.IsNullOrEmpty(input))
                {
                    throw new UserInputException("Ошибка: ввод не может быть пустым.");
                }
            }
            catch (UserInputException ex)
            {
                Console.WriteLine($"Пользовательское исключение: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Общее исключение: {ex.GetType()} - {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Завершение программы.");
        }
    }
}

namespace CustomExceptions
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message) : base(message) { }
    }

    public class UserInputException : ArgumentException
    {
        public UserInputException(string message) : base(message) { }
    }

    public class FileSystemException : System.IO.IOException
    {
        public FileSystemException(string message) : base(message) { }
    }
}
namespace ProductHierarchy
{
    public abstract partial class Product
    {
        public int Weight { get; set; }
        public ProductCategory Category { get; set; }
    }

    public enum ProductCategory
    {
        Confectionery,
        Flower,
        Watch
    }
}
namespace Gift
{
    public struct CandyShop
    {
        public List<Confectionery> Items;
        public Dictionary<string, int> Inventory;

        public CandyShop(List<Confectionery> items, Dictionary<string, int> inventory)
        {
            Items = items;
            Inventory = inventory;
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Candy Shop Inventory:");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"Item: {item.Key}, Quantity: {item.Value}");
            }
        }
    }
    public class Container
    {
        private List<Product> products = new List<Product>();
        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Remove(Product product)
        {
            products.Remove(product);
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public void PrintAll()
        {
            Console.WriteLine("Container Contents:");
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        public void SortByWeight()
        {
            products.Sort((p1, p2) => p1.Weight.CompareTo(p2.Weight));
        }
    }
    public class ContainerController
    {
        private readonly Container container;

        public ContainerController(Container container)
        {
            this.container = container;
        }

        public decimal CalculateTotalPrice()
        {
            return container.GetAll().Sum(product => product.Price);
        }

        public Product FindLightestProduct()
        {
            return container.GetAll().OrderBy(product => product.Weight).FirstOrDefault();
        }

        public void SortProductsByWeight()
        {
            container.SortByWeight();
        }
    }
    class Program
    {
        static void Main1(string[] args)
        {
            var cake = new Cake { Name = "Chocolate Cake", Price = 25.99m, Flavor = "Chocolate", Layers = 3, Weight = 1500 };
            var flower = new Flower { Name = "Rose", Price = 5.99m, Color = "Red", Weight = 200 };
            var watch = new Watch { Name = "Smart Watch", Price = 199.99m, Brand = "BrandX", Weight = 300 };
            var candy = new Candy { Name = "Gummy Bears", Price = 2.99m, Flavor = "Mixed", IsSugarFree = false, Weight = 500 };

            var container = new Container();
            container.Add(cake);
            container.Add(flower);
            container.Add(watch);
            container.Add(candy);

            var controller = new ContainerController(container);

            container.PrintAll();

            decimal totalPrice = controller.CalculateTotalPrice();
            Console.WriteLine($"\nTotal Price of all products: {totalPrice:C}");

            Product lightestProduct = controller.FindLightestProduct();
            Console.WriteLine($"\nLightest Product: {lightestProduct}");

            controller.SortProductsByWeight();
            Console.WriteLine("\nProducts sorted by weight:");
            container.PrintAll();
        }
    }
}