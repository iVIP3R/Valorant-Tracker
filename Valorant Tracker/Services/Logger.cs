using System;
using System.Diagnostics;
using System.IO;

namespace Valorant_Tracker.Services
{
    public static class Logger
    {
        public static void Log(Exception ex, string context = "Global")
        {
            try
            {
                string logFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Valorant_Tracker", "logs");

                Directory.CreateDirectory(logFolder);

                string fileName = $"log_{DateTime.Now:yyyy-MM-dd}.txt";
                string filePath = Path.Combine(logFolder, fileName);

                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{context}]\n" +
                                  $"Exception: {ex.GetType().Name}\n" +
                                  $"Message: {ex.Message}\n" +
                                  $"StackTrace:\n{ex.StackTrace}\n" +
                                  "--------------------------------------------------\n";

                File.AppendAllText(filePath, logEntry);
                Debug.WriteLine($"[Logger] Successfully wrote to {filePath}");
            }
            catch (Exception logEx)
            {
                Debug.WriteLine($"[Logger] FAILED to write to disk: {logEx.Message}");
            }
        }

        public static void Log(string message, string context = "Info")
        {
            try
            {
                string logFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Valorant_Tracker", "logs");

                Directory.CreateDirectory(logFolder);

                string fileName = $"log_{DateTime.Now:yyyy-MM-dd}.txt";
                string filePath = Path.Combine(logFolder, fileName);

                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{context}] {message}\n";
                File.AppendAllText(filePath, logEntry);
                Debug.WriteLine($"[Logger] {message}");
            }
            catch (Exception logEx)
            {
                Debug.WriteLine($"[Logger] FAILED to write to disk: {logEx.Message}");
            }
        }
    }
}