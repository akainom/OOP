public interface ISerializer
{
    void Serialize<T>(T obj, string filePath);
    T Deserialize<T>(string filePath);
}
