using System;
using System.Xml;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Объект для теста
        Cake cake = new Cake { Name = "Vanilla Cake", Price = 15.99m, Layers = 3, Flavor = "Vanilla" };

        // JSON
        ISerializer jsonSerializer = new JsonSerializerWrapper();
        jsonSerializer.Serialize(cake, "cake.json");
        Cake cakeFromJson = jsonSerializer.Deserialize<Cake>("cake.json");
        Console.WriteLine($"Deserialized JSON: {cakeFromJson}");

        // XML
        ISerializer xmlSerializer = new XmlSerializerWrapper();
        xmlSerializer.Serialize(cake, "cake.xml");
        Cake cakeFromXml = xmlSerializer.Deserialize<Cake>("cake.xml");
        Console.WriteLine($"Deserialized XML: {cakeFromXml}");

        // Binary
        ISerializer binarySerializer = new BinaryDataSerializer();
        binarySerializer.Serialize(cake, "cake.bin");
        Cake cakeFromBinary = binarySerializer.Deserialize<Cake>("cake.bin");
        Console.WriteLine($"Deserialized Binary: {cakeFromBinary}");

        // XPath
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("cake.xml");
        XmlNode nameNode = xmlDoc.SelectSingleNode("//Name");
        Console.WriteLine($"Name from XPath: {nameNode?.InnerText}");

        XmlNode priceNode = xmlDoc.SelectSingleNode("//Price");
        Console.WriteLine($"Price from XPath: {priceNode?.InnerText}");

        // SOAP??
        ISerializer dataContractSerializer = new DataContractSerializerWrapper();
        dataContractSerializer.Serialize(cake, "cake.soap");
        Cake cakeFromDataContract = dataContractSerializer.Deserialize<Cake>("cake.soap");
        Console.WriteLine($"Deserialized DataContract (SOAP-like): {cakeFromDataContract}");


        // LINQ to XML
        XDocument doc = new XDocument(
            new XElement("Products",
                new XElement("Cake",
                    new XElement("Name", "Vanilla Cake"),
                    new XElement("Price", "15.99"),
                    new XElement("Layers", "3")
                )
            )
        );
        doc.Save("products_linq.xml");

        XDocument loadedDoc = XDocument.Load("products_linq.xml");
        var cakePrice = loadedDoc.Descendants("Price").FirstOrDefault()?.Value;
        Console.WriteLine($"Cake Price from LINQ: {cakePrice}");
    }
}
