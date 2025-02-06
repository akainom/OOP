using System;
using System.IO;

public static class PVRFileInfo
{
    public static void PrintFileInfo(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileInfo = new FileInfo(filePath);
            Console.WriteLine($"Full Path: {fileInfo.FullName}");
            Console.WriteLine($"Size: {fileInfo.Length} bytes");
            Console.WriteLine($"Extension: {fileInfo.Extension}");
            Console.WriteLine($"Name: {fileInfo.Name}");
            Console.WriteLine($"Created: {fileInfo.CreationTime}");
            Console.WriteLine($"Modified: {fileInfo.LastWriteTime}");
            PVRLog.WriteLog("File Info", $"Info retrieved for {filePath}");
        }
        else
        {
            Console.WriteLine("File does not exist.");
        }
    }
}
