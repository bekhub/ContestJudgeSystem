using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace Common.Extensions
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class FileExtensions
    {
        public static IEnumerable<(string Name, string Text)> GetFiles(this string path, string filename, string extension)
        {
            var files = Directory.GetFiles(path, $"{filename}_*.{extension}");
            return files.AsParallel().Select(x => (x.GetName(), File.ReadAllText(x)));
        }
        
        public static string GetName(this string path)
        {
            return path.Split('\\')[^1];
        }
        
        public static string GetWithoutExt(this string path)
        {
            return path.Substring(0, path.LastIndexOf('.'));
        }

        public static int GetFileOrder(this string path)
        {
            return int.Parse(path.GetName().GetWithoutExt().Split('_')[^1]);
        }
    }
}
