using System.IO;
using System.Xml.Serialization;

public class XmlSerializerWrapper : ISerializer
{
    public void Serialize<T>(T obj, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(fs, obj);
        }
    }

    public T Deserialize<T>(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            return (T)serializer.Deserialize(fs);
        }
    }
}
