using System;
using System.IO;
using System.IO.Compression;

public static class PVRFileManager
{
    public static void InspectDisk(string diskPath)
    {
        if (!Directory.Exists(diskPath))
        {
            Console.WriteLine("Disk path does not exist.");
            return;
        }

        string inspectDir = "PVRInspect";
        Directory.CreateDirectory(inspectDir);

        string dirInfoFile = Path.Combine(inspectDir, "pvrdirinfo.txt");
        using (var writer = new StreamWriter(dirInfoFile))
        {
            foreach (var dir in Directory.GetDirectories(diskPath))
            {
                writer.WriteLine($"Directory: {dir}");
            }
            foreach (var file in Directory.GetFiles(diskPath))
            {
                writer.WriteLine($"File: {file}");
            }
        }

        string copyFile = dirInfoFile.Replace(".txt", "_copy.txt");
        File.Copy(dirInfoFile, copyFile);
        File.Delete(dirInfoFile);

        PVRLog.WriteLog("Inspect Disk", $"Inspected {diskPath}, info saved in {copyFile}");
    }

    public static void ManageFiles(string dirPath, string extension)
    {
        if (!Directory.Exists(dirPath))
        {
            Console.WriteLine("Directory does not exist.");
            return;
        }

        string filesDir = "PVRFiles";
        Directory.CreateDirectory(filesDir);

        foreach (var file in Directory.GetFiles(dirPath, $"*{extension}"))
        {
            string destFile = Path.Combine(filesDir, Path.GetFileName(file));
            File.Copy(file, destFile);
        }

        string inspectDir = "PVRInspect";
        Directory.CreateDirectory(inspectDir);

        Directory.Move(filesDir, Path.Combine(inspectDir, filesDir));
        PVRLog.WriteLog("Manage Files", $"Moved files with {extension} to {inspectDir}");
    }

    public static void ArchiveFiles(string sourceDir, string archivePath)
    {
        if (Directory.Exists(sourceDir))
        {
            ZipFile.CreateFromDirectory(sourceDir, archivePath);
            PVRLog.WriteLog("Archive Files", $"Archived {sourceDir} to {archivePath}");
        }
    }

    public static void ExtractArchive(string archivePath, string extractPath)
    {
        if (File.Exists(archivePath))
        {
            ZipFile.ExtractToDirectory(archivePath, extractPath);
            PVRLog.WriteLog("Extract Archive", $"Extracted {archivePath} to {extractPath}");
        }
    }
}
