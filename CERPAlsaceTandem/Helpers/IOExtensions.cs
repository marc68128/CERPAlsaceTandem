using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CERPAlsaceTandem.Helpers
{
    public static class IOExtensions
    {
        public static string[] PhotoExtensions = new[] { "*.jpg" };
        public static string[] VideoExtensions = new[] { "*.avi", "*.mkv" };
        public static List<string> GetFilesRecursiv(string path, string searchPattern)
        {
            var files = Directory.GetFiles(path, searchPattern).ToList();
            var folders = Directory.GetDirectories(path);
            foreach (var folder in folders)
            {
                files.AddRange(GetFilesRecursiv(folder, searchPattern));
            }
            return files;
        }

        public static List<string> GetDirectoriesRecursiv(string path, string searchPattern)
        {
            var folders = Directory.GetDirectories(path, searchPattern).ToList();
            var allFolders = Directory.GetDirectories(path);
            foreach (var folder in allFolders)
            {
                folders.AddRange(GetDirectoriesRecursiv(folder, searchPattern));
            }
            return folders;
        }
    }
}
