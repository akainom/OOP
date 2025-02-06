class Program
{
    static void Main()
    {
        PVRDiskInfo.PrintDiskInfo();

        string testFile = "test.txt";
        File.WriteAllText(testFile, "Hello, PVR!");

        PVRFileInfo.PrintFileInfo(testFile);

        string testDir = "TestDir";
        Directory.CreateDirectory(testDir);
        PVRDirInfo.PrintDirInfo(testDir);

        PVRFileManager.InspectDisk(Directory.GetCurrentDirectory());
        PVRFileManager.ManageFiles(Directory.GetCurrentDirectory(), ".txt");

        string archive = "test.zip";
        PVRFileManager.ArchiveFiles("PVRInspect", archive);
        PVRFileManager.ExtractArchive(archive, "Extracted");
    }
}
