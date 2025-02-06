using System.IO;
using System.Text.Json;

public class JsonSerializerWrapper : ISerializer
{
    public void Serialize<T>(T obj, string filePath)
    {
        string json = JsonSerializer.Serialize(obj);
        File.WriteAllText(filePath, json);
    }

    public T Deserialize<T>(string filePath)
    {
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }
}
