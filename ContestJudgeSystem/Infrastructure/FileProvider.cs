using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Models.Interfaces;

namespace ContestJudgeSystem.Infrastructure
{
    public class FileProvider : IFileProvider
    {
        private readonly IWebHostEnvironment _environment;

        private readonly IConfiguration _configuration;

        private static FileProvider _instance;

        private static readonly object Padlock = new();

        public string RootPath => _environment.WebRootPath;

        public string Checkers => Path.Combine(RootPath, _configuration.GetPath("Checkers"));
        
        public string Inputs => Path.Combine(RootPath, _configuration.GetPath("Inputs"));
        
        public string Outputs => Path.Combine(RootPath, _configuration.GetPath("Outputs"));
        
        public string RealOutputs => Path.Combine(RootPath, _configuration.GetPath("RealOutputs"));
        
        public string Sources => Path.Combine(RootPath, _configuration.GetPath("Sources"));

        private FileProvider(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        public static FileProvider GetInstance(IWebHostEnvironment environment, IConfiguration configuration)
        {
            if (_instance != null) return _instance;
            
            lock (Padlock) _instance ??= new FileProvider(environment, configuration);

            return _instance;
        }
    }
}
