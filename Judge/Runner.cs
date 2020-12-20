using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Common.Extensions;
using Models.Interfaces;

namespace Judge
{
    public class Runner
    {
        private IFileProvider FileProvider { get; }

        private static Runner _instance;
        
        private static readonly object Padlock = new();

        private const string Txt = "txt";

        private Runner(IFileProvider fileProvider)
        {
            FileProvider = fileProvider;
        }

        public void Run(IRunnable runnable, string filename)
        {
            var inputs = FileProvider.Inputs.GetFiles(filename, Txt);

            var startInfo = runnable.GetProcessStartInfo(FileProvider.Sources, filename);

            Parallel.ForEach(inputs, async input =>
            {
                using var runner = new Process { StartInfo = startInfo };
                runner.Start();
                                    
                var writer = runner.StandardInput;
                var (name, text) = input;
                await writer.WriteLineAsync(text);
                writer.Close();
    
                runner.WaitForExit(3000);
                await File.WriteAllTextAsync(Path.Combine(FileProvider.RealOutputs, name), 
                    await runner.StandardOutput.ReadToEndAsync());
            });
        }

        public static Runner GetInstance(IFileProvider fileProvider)
        {
            if (_instance != null) return _instance;
            
            lock (Padlock) _instance ??= new Runner(fileProvider);

            return _instance;
        }
    }
}
