using System;
using Judge.Checkers;
using Judge.Runnables;
using Models.Enums;
using Models.Interfaces;

namespace Judge.Infrastructure
{
    public static class Configuration
    {
        public static IRunnable GetRunnable(this RunnableEnum runnableEnum) => runnableEnum switch
        {
            RunnableEnum.Cpp => new CppRunner(),
            RunnableEnum.Python => new PythonRunner(),
            _ => throw new ArgumentOutOfRangeException(nameof(runnableEnum), runnableEnum, null),
        };

        public static IChecker GetChecker(this CheckerEnum checkerEnum, IFileProvider fileProvider) => checkerEnum switch
        {
            CheckerEnum.Default => new DefaultChecker(fileProvider),
            CheckerEnum.Custom => new CustomChecker(fileProvider),
            _ => throw new ArgumentOutOfRangeException(nameof(checkerEnum), checkerEnum, null)
        };
    }
}
