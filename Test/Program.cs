using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"C:\Users\bekam\source\MyFolder\Univer\bil-303\ContestJudgeSystem\ContestJudgeSystem\Files\Sources";
            Directory.GetFiles(path, "1_*.txt").ToList().ForEach(Console.WriteLine);
            var process = new Process
            {
                StartInfo = new()
                {
                    FileName = "py",
                    Arguments = Path.Combine(path, "12"),
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                },
            };
        }
    }
}