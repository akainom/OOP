using System;
using System.IO;

public static class PVRLog
{
    private static readonly string LogFilePath = "pvrlogfile.txt";

    public static void WriteLog(string action, string details)
    {
        string logEntry = $"[{DateTime.Now}] ACTION: {action} | DETAILS: {details}";
        File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
    }

    public static string[] ReadLog()
    {
        return File.Exists(LogFilePath) ? File.ReadAllLines(LogFilePath) : Array.Empty<string>();
    }

    public static string[] SearchLog(string keyword)
    {
        var logs = ReadLog();
        return Array.FindAll(logs, log => log.Contains(keyword, StringComparison.OrdinalIgnoreCase));
    }

    public static void ClearLogExceptCurrentHour()
    {
        var logs = ReadLog();
        var currentHour = DateTime.Now.Hour;
        var filteredLogs = Array.FindAll(logs, log =>
        {
            if (DateTime.TryParse(log.Split(']')[0].Trim('[', ']'), out var logTime))
            {
                return logTime.Hour == currentHour;
            }
            return false;
        });
        File.WriteAllLines(LogFilePath, filteredLogs);
    }
}
