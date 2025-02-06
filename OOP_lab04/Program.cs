using System;
using System.Reflection.Metadata.Ecma335;

namespace ProductHierarchy
{
    public interface IPrintable
    {
        public void PrintDetails();
        public void IsPrinter();
    }

    public abstract partial class Product
    {
        public bool printer;
        public virtual void IsPrinter()
        {
            printer = false;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public abstract void PrintDetails();

        public override string ToString()
        {
            return $"{GetType().Name}: {Name}, Price: {Price:C}";
        }
    }

    public class Confectionery : Product
    {
        public string Flavor { get; set; }

        public override void PrintDetails()
        {
            Console.WriteLine($"Confectionery: {Name}, Flavor: {Flavor}, Price: {Price:C}");
        }

        public override string ToString()
        {
            return base.ToString() + $", Flavor: {Flavor}";
        }
    }

    public class Flower : Product
    {
        public string Color { get; set; }

        public override void PrintDetails()
        {
            Console.WriteLine($"Flower: {Name}, Color: {Color}, Price: {Price:C}");
        }

        public override string ToString()
        {
            return base.ToString() + $", Color: {Color}";
        }
    }

    public sealed class Cake : Confectionery
    {
        public int Layers { get; set; }

        public override void PrintDetails()
        {
            Console.WriteLine($"Cake: {Name}, Layers: {Layers}, Flavor: {Flavor}, Price: {Price:C}");
        }

        public override string ToString()
        {
            return base.ToString() + $", Layers: {Layers}";
        }
    }

    public class Watch : Product
    {
        public string Brand { get; set; }

        public override void PrintDetails()
        {
            Console.WriteLine($"Watch: {Name}, Brand: {Brand}, Price: {Price:C}");
        }

        public override string ToString()
        {
            return base.ToString() + $", Brand: {Brand}";
        }
    }

    public class Candy : Confectionery
    {
        public bool IsSugarFree { get; set; }

        public override void PrintDetails()
        {
            Console.WriteLine($"Candy: {Name}, Sugar-Free: {IsSugarFree}, Flavor: {Flavor}, Price: {Price:C}");
        }

        public override string ToString()
        {
            return base.ToString() + $", Sugar-Free: {IsSugarFree}";
        }
    }

    public class Printer : Product, IPrintable
    {
        public void IAmPrinting(Product product)
        {
            if (product is IPrintable printable)
            {
                printable.PrintDetails();
            }
            else Console.WriteLine("Cannot print details.");
        }

        public override void PrintDetails()
        {
            Console.WriteLine("I am Printer!");
        }

        void IPrintable.PrintDetails()
        {
            Console.WriteLine("Playboy Carti");
        }
        public override void IsPrinter()
        {
            base.printer = true;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Printer))
            {
                return false;
            }
            else return true;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(Math.Acosh(Convert.ToDouble(base.GetHashCode())));
        }

        public override string ToString()
        {
            string str = "";
            return str;
        }
    }


    class Program
    {
        static void iain(string[] args)
        {
            Product[] products = new Product[]
            {
                new Cake { Name = "Chocolate Cake", Price = 25.99m, Flavor = "Chocolate", Layers = 3 },
                new Flower { Name = "Rose", Price = 5.99m, Color = "Red" },
                new Watch { Name = "Smart Watch", Price = 199.99m, Brand = "BrandX" },
                new Candy { Name = "Gummy Bears", Price = 2.99m, Flavor = "Mixed", IsSugarFree = false }
            };

            Printer printer = new Printer();

            foreach (var product in products)
            {
                printer.IAmPrinting(product);
                Console.WriteLine(product.ToString());
                Console.WriteLine();
                printer.IsPrinter();
                Console.WriteLine(printer.printer);
            }
        }
    }
}