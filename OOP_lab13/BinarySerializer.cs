using System;
using System.IO;
using System.Text.Json;

public class BinaryDataSerializer : ISerializer
{
    public void Serialize<T>(T obj, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                // Сериализуем объект в строку JSON
                string jsonString = JsonSerializer.Serialize(obj);

                // Записываем JSON в бинарный файл
                writer.Write(jsonString);
            }
        }
    }

    public T Deserialize<T>(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            using (BinaryReader reader = new BinaryReader(fs))
            {
                // Читаем JSON-строку из файла
                string jsonString = reader.ReadString();

                // Десериализуем JSON в объект типа T
                return JsonSerializer.Deserialize<T>(jsonString);
            }
        }
    }
}
