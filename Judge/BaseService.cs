using System.Diagnostics;

namespace Judge
{
    public class BaseService
    {
        public string RunCmd(params string[] commands)
        {
            var info = new ProcessStartInfo("cmd")
            {
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using var process = Process.Start(info);
            var sw = process?.StandardInput;
            var sr = process?.StandardOutput;

            foreach (var command in commands)
            {
                sw?.WriteLine(command);
            }

            sw?.Close();
            var returnValue = sr?.ReadToEnd();

            return returnValue;
        }
    }
}
