using System;

[Serializable]
public abstract class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public abstract void PrintDetails();

    public override string ToString()
    {
        return $"{GetType().Name}: {Name}, Price: {Price:C}";
    }
}

[Serializable]
public class Cake : Product
{
    [NonSerialized]
    public string Flavor;

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
