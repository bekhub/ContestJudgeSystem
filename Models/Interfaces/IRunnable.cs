using System.Diagnostics;

namespace Models.Interfaces
{
    public interface IRunnable
    {
        ProcessStartInfo GetProcessStartInfo(string path, string filename);
    }
}
