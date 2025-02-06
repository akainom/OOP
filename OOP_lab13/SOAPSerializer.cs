using System.IO;
using System.Runtime.Serialization;

public class DataContractSerializerWrapper : ISerializer
{
    public void Serialize<T>(T obj, string filePath)
    {
        var serializer = new DataContractSerializer(typeof(T));
        using (var fs = new FileStream(filePath, FileMode.Create))
        {
            serializer.WriteObject(fs, obj);
        }
    }

    public T Deserialize<T>(string filePath)
    {
        var serializer = new DataContractSerializer(typeof(T));
        using (var fs = new FileStream(filePath, FileMode.Open))
        {
            return (T)serializer.ReadObject(fs);
        }
    }
}
