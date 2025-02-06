using System;
using System.Collections.Generic;
using System.IO;

public interface ICollectionOperations<T>
{
    void Add(T item);
    void Remove(T item);
    IEnumerable<T> View(Func<T, bool> predicate);
}

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class CollectionType<T> : ICollectionOperations<T> where T : IComparable<T>
{
    private Node<T> head;

    public void Add(T item)
    {
        Node<T> newNode = new Node<T>(item);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void Remove(T item)
    {
        Node<T> current = head;
        Node<T> previous = null;

        while (current != null)
        {
            if (current.Data.Equals(item))
            {
                if (previous == null)
                {
                    head = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }
                return;
            }
            previous = current;
            current = current.Next;
        }
    }

    public IEnumerable<T> View(Func<T, bool> predicate)
    {
        var results = new List<T>();
        Node<T> current = head;
        while (current != null)
        {
            if (predicate(current.Data))
            {
                results.Add(current.Data);
            }
            current = current.Next;
        }
        return results;
    }

    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data is Developer developer)
                {
                    writer.WriteLine($"{developer.Id},{developer.Name}");
                }
                else if (current.Data is int number)
                {
                    writer.WriteLine(number);
                }
                current = current.Next;
            }
        }
    }

    public void LoadFromFile(string filePath)
    {
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (typeof(T) == typeof(Developer))
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            int id = int.Parse(parts[0]);
                            string name = parts[1];
                            Add((T)Convert.ChangeType(new Developer(id, name), typeof(T)));
                        }
                    }
                    else if (typeof(T) == typeof(int))
                    {
                        int number = int.Parse(line);
                        Add((T)Convert.ChangeType(number, typeof(T)));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
        }
    }
}

public class Developer : IComparable<Developer>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Developer(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString() => $"ID: {Id}, Name: {Name}";

    public int CompareTo(Developer other)
    {
        if (other == null) return 1;
        return Id.CompareTo(other.Id);
    }
}

class Program
{
    static void Main()
    {
        try
        {


            // Тестирование с целыми числами
            var intCollection = new CollectionType<int>();
            intCollection.Add(1);
            intCollection.Add(2);
            intCollection.Add(3);
            intCollection.Remove(2);

            Console.WriteLine("Integers in collection:");
            foreach (var item in intCollection.View(x => true))
            {
                Console.WriteLine(item);
            }

            // Тестирование с классом Developer
            var developerCollection = new CollectionType<Developer>();
            developerCollection.Add(new Developer(1, "Alice"));
            developerCollection.Add(new Developer(2, "Bob"));

            Console.WriteLine("\nDevelopers in collection:");
            foreach (var dev in developerCollection.View(d => true))
            {
                Console.WriteLine(dev);
            }

            // Сохранение и загрузка с использованием указанных вами путей
            string devFilePath = "C:\\Users\\kavop\\OneDrive\\Документы\\Belstu\\ОАиП\\Solutions\\OOP\\OOP_lab07\\developer.txt";
            string intFilePath = "C:\\Users\\kavop\\OneDrive\\Документы\\Belstu\\ОАиП\\Solutions\\OOP\\OOP_lab07\\int.txt";

            developerCollection.SaveToFile(devFilePath);
            intCollection.SaveToFile(intFilePath);

            var newDeveloperCollection = new CollectionType<Developer>();
            newDeveloperCollection.LoadFromFile(devFilePath);

            var newIntCollection = new CollectionType<int>();
            newIntCollection.LoadFromFile(intFilePath);

            Console.WriteLine("\nLoaded Developers from file:");
            foreach (var dev in newDeveloperCollection.View(d => true))
            {
                Console.WriteLine(dev);
            }

            Console.WriteLine("\nLoaded integers from file:");
            foreach (var item in newIntCollection.View(d => true))
            {
                Console.WriteLine(item);
            }
        }
        catch
        {
            Console.Write("Ошибка!");
        }
        finally { Console.WriteLine("конец"); }
    }

}