using Models.DTO;
using Models.Interfaces;

namespace Judge.Checkers
{
    public class CustomChecker : IChecker 
    {
        private IFileProvider FileProvider { get; }

        public CustomChecker(IFileProvider fileProvider)
        {
            FileProvider = fileProvider;
        }

        public Result Check(IRunnable runnable, string filename)
        {
            var startInfo = runnable.GetProcessStartInfo(FileProvider.Checkers, filename);
            return null;
        }
    }
}
