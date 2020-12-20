using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ContestJudgeSystem.Infrastructure
{
    public static class Extensions
    {
        public static string GetPath(this IConfiguration configuration, string name)
        {
            return configuration?.GetSection("Paths")?[name];
        }

        public static async Task SaveFile(this IFormFile file, string path)
        {
            await using Stream fileStream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(fileStream);
        }
    }
}
