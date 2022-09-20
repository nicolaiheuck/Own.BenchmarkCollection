using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using ExceptionHandling;

ManualConfig config = DefaultConfig.Instance.WithArtifactsPath("../../../Artifacts");
BenchmarkRunner.Run<TryCatchThrowOrNothing>(config);