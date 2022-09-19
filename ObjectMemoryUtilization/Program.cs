using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace ObjectMemoryUtilization;

public class Program
{
    public static void Main()
    {
        ManualConfig config = DefaultConfig.Instance.WithArtifactsPath("../../../Artifacts");
        BenchmarkRunner.Run<ObjectInitialization>(config);
    }
}