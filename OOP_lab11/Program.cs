using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

public static class Reflector
{
    public static void WriteAssemblyName(string className, string filePath)
    {
        Type type = Type.GetType(className);
        if (type == null) throw new ArgumentException($"Класс {className} не найден.");

        File.WriteAllText(filePath, $"Assembly: {type.Assembly.FullName}{Environment.NewLine}");
    }

    public static bool HasPublicConstructors(string className)
    {
        Type type = Type.GetType(className);
        if (type == null) throw new ArgumentException($"Класс {className} не найден.");

        return type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Any();
    }

    public static IEnumerable<string> GetPublicMethods(string className)
    {
        Type type = Type.GetType(className);
        if (type == null) throw new ArgumentException($"Класс {className} не найден.");

        return type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                   .Select(method => method.Name);
    }

    public static IEnumerable<string> GetFieldsAndProperties(string className)
    {
        Type type = Type.GetType(className);
        if (type == null) throw new ArgumentException($"Класс {className} не найден.");

        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                         .Select(field => $"Field: {field.Name}");

        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                             .Select(prop => $"Property: {prop.Name}");

        return fields.Concat(properties);
    }

    public static IEnumerable<string> GetImplementedInterfaces(string className)
    {
        Type type = Type.GetType(className);
        if (type == null) throw new ArgumentException($"Класс {className} не найден.");

        return type.GetInterfaces().Select(interfaceType => interfaceType.Name);
    }

    public static IEnumerable<string> GetMethodsByParameterType(string className, string parameterTypeName)
    {
        Type type = Type.GetType(className);
        if (type == null) throw new ArgumentException($"Класс {className} не найден.");

        Type parameterType = Type.GetType(parameterTypeName);
        if (parameterType == null) throw new ArgumentException($"Тип параметра {parameterTypeName} не найден.");

        return type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                   .Where(method => method.GetParameters()
                                          .Any(param => param.ParameterType == parameterType))
                   .Select(method => method.Name);
    }

    public static object Invoke(string className, string methodName, object[] parameters)
    {
        Type type = Type.GetType(className);
        if (type == null) throw new ArgumentException($"Класс {className} не найден.");

        MethodInfo method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        if (method == null) throw new ArgumentException($"Метод {methodName} не найден.");

        object instance = null;
        if (!method.IsStatic)
        {
            ConstructorInfo constructor = type.GetConstructors().FirstOrDefault();
            if (constructor == null) throw new ArgumentException($"Класс {className} не имеет публичных конструкторов.");
            instance = constructor.Invoke(null);
        }

        return method.Invoke(instance, parameters);
    }

    public static object Invoke(string className, string methodName, string parametersFilePath)
    {
        Type type = Type.GetType(className);
        if (type == null) throw new ArgumentException($"Класс {className} не найден.");

        MethodInfo method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        if (method == null) throw new ArgumentException($"Метод {methodName} не найден.");

        object instance = null;
        if (!method.IsStatic)
        {
            ConstructorInfo constructor = type.GetConstructors().FirstOrDefault();
            if (constructor == null) throw new ArgumentException($"Класс {className} не имеет публичных конструкторов.");
            instance = constructor.Invoke(null);
        }

        // Read parameters from a file
        var paramValues = File.ReadAllLines(parametersFilePath);
        var parameters = new object[paramValues.Length];
        ParameterInfo[] paramInfos = method.GetParameters();

        for (int i = 0; i < paramValues.Length; i++)
        {
            parameters[i] = Convert.ChangeType(paramValues[i], paramInfos[i].ParameterType);
        }

        return method.Invoke(instance, parameters);
    }

    public static T Create<T>() where T : new()
    {
        return new T();
    }
}

public class ExampleClass
{
    public int Value { get; set; }

    public ExampleClass() { }

    public ExampleClass(int value)
    {
        Value = value;
    }

    public void PrintValue(string prefix)
    {
        Console.WriteLine($"{prefix}: {Value}");
    }
}

public class Program
{
    public static void Main()
    {
        string className = "ExampleClass";

        // a. Определение имени сборки
        Reflector.WriteAssemblyName(className, "assembly_info.txt");

        // b. Проверка наличия публичных конструкторов
        Console.WriteLine($"Has public constructors: {Reflector.HasPublicConstructors(className)}");

        // c. Получение всех публичных методов
        foreach (var method in Reflector.GetPublicMethods(className))
        {
            Console.WriteLine($"Method: {method}");
        }

        // d. Информация о полях и свойствах
        foreach (var member in Reflector.GetFieldsAndProperties(className))
        {
            Console.WriteLine(member);
        }

        // e. Реализованные интерфейсы
        foreach (var interfaceName in Reflector.GetImplementedInterfaces(className))
        {
            Console.WriteLine($"Interface: {interfaceName}");
        }

        // f. Методы с параметрами определённого типа
        foreach (var methodName in Reflector.GetMethodsByParameterType(className, "System.String"))
        {
            Console.WriteLine($"Method with string parameter: {methodName}");
        }

        // g. Вызов метода через Invoke
        Reflector.Invoke(className, "PrintValue", new object[] { "Hello" });

        // Создание объекта через обобщённый метод
        var instance = Reflector.Create<ExampleClass>();
        instance.Value = 42;
        Console.WriteLine($"Created instance value: {instance.Value}");
    }
}
