using System;
using System.IO;

public static class PVRDirInfo
{
    public static void PrintDirInfo(string dirPath)
    {
        if (Directory.Exists(dirPath))
        {
            var dirInfo = new DirectoryInfo(dirPath);
            Console.WriteLine($"Directory: {dirInfo.FullName}");
            Console.WriteLine($"Files Count: {dirInfo.GetFiles().Length}");
            Console.WriteLine($"Subdirectories Count: {dirInfo.GetDirectories().Length}");
            Console.WriteLine($"Created: {dirInfo.CreationTime}");

            Console.WriteLine("Parent Directories:");
            var parent = dirInfo.Parent;
            while (parent != null)
            {
                Console.WriteLine(parent.FullName);
                parent = parent.Parent;
            }

            PVRLog.WriteLog("Directory Info", $"Info retrieved for {dirPath}");
        }
        else
        {
            Console.WriteLine("Directory does not exist.");
        }
    }
}
