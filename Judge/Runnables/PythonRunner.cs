using System.Diagnostics;
using System.IO;
using Models.Interfaces;

namespace Judge.Runnables
{
    public class PythonRunner : IRunnable
    {
        public ProcessStartInfo GetProcessStartInfo(string path, string filename) => new()
        {
            FileName = "py",
            Arguments = Path.Combine(path, $"{filename}.py"),
            UseShellExecute = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
        };
    }
}
