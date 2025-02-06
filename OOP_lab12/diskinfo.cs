using System;
using System.IO;

public static class PVRDiskInfo
{
    public static void PrintDiskInfo()
    {
        foreach (var drive in DriveInfo.GetDrives())
        {
            if (drive.IsReady)
            {
                Console.WriteLine($"Drive: {drive.Name}");
                Console.WriteLine($"File System: {drive.DriveFormat}");
                Console.WriteLine($"Total Size: {drive.TotalSize / (1024 * 1024 * 1024)} GB");
                Console.WriteLine($"Available Space: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} GB");
                Console.WriteLine($"Volume Label: {drive.VolumeLabel}");
                PVRLog.WriteLog("Disk Info", $"Drive {drive.Name} checked.");
            }
        }
    }
}
