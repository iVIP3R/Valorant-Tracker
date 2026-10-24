using System;
using System.Diagnostics;
using System.IO;

namespace Valorant_Tracker.Utils
{
    internal static class RegionStore
    {
        private static string FolderPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Valorant_Tracker");

        private static string FilePath => Path.Combine(FolderPath, "last-region.txt");

        public static bool TryLoad(out region value)
        {
            value = default;
            try
            {
                if (!File.Exists(FilePath)) return false;
                var content = File.ReadAllText(FilePath).Trim();
                return Enum.TryParse(content, ignoreCase: true, out value);
            }
            catch { return false; }
        }

        public static void Save(region value)
        {
            try
            {
                Directory.CreateDirectory(FolderPath);
                File.WriteAllText(FilePath, value.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[RegionStore] Save failed: {ex.Message}");
            }
        }
    }
}