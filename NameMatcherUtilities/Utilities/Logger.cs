using GGLMatchesAssessment.Interfaces;
using System.Diagnostics;

namespace GGLMatchesAssessment.Utilities;

public class Logger : ILogger
{
    public void Log(string message, Stopwatch stopwatch)
    {
        string folderPath = @"C:\Users\Vidur\source\repos\GGLMatchesAssessment\Logs";

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string filePath = Path.Combine(folderPath, "log.txt");
        string logMessage = $"{DateTime.Now.ToString()} - {message} - Execution Time: {stopwatch.Elapsed}";

        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(logMessage);
        }
    }
}