using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IRunner
    {
        Task RunAsync(IRunnable runnable, string filename);
    }
}
