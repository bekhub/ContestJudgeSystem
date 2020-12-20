using System.Diagnostics;
using System.IO;
using Models.Interfaces;

namespace Judge.Runnables
{
    public class CppRunner : IRunnable
    {
        private Process Compile(string path, string filename)
        {
            var filepath = Path.Combine(path, filename);
            return Process.Start("g++", $"{filepath}.cpp -std=c++14 -o {filepath}");
        }

        public ProcessStartInfo GetProcessStartInfo(string path, string filename)
        {
            Compile(path, filename).WaitForExit();

            return new ProcessStartInfo
            {
                FileName = Path.Combine(path, filename),
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
            };
        }
    }
}
