using BenchmarkDotNet.Running;

namespace ObjectMemoryUtilization;

public class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run<ObjectInitialization>();
    }
}