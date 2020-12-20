using Models.DTO;

namespace Models.Interfaces
{
    public interface IChecker
    {
        Result Check(IRunnable runnable, string filename);
    }
}
