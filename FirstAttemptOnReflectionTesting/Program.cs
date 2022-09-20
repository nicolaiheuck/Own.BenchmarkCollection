using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace FirstAttemptOnReflectionTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            ManualConfig config = DefaultConfig.Instance.WithArtifactsPath("../../../Artifacts");
            BenchmarkRunner.Run<GetClassesImplementingAnInterfaceTests>(config);
        }
    }
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class GetClassesImplementingAnInterfaceTests
    {
        [Benchmark(Baseline = true)]
        public void Default()
        {
            List<Type> services = typeof(Program).Assembly
                                                 .GetTypes()
                                                 .Where(p => !p.IsInterface)
                                                 .Where(p => p.IsAssignableTo(typeof(IService)))
                                                 .ToList();
        }
        [Benchmark]
        public void Default_DifferentOrder()
        {
            List<Type> services = typeof(Program).Assembly
                                                 .GetTypes()
                                                 .Where(p => p.IsAssignableTo(typeof(IService)))
                                                 .Where(p => !p.IsInterface)
                                                 .ToList();
        }
        [Benchmark]
        public void Default_CombinedWhere()
        {
            List<Type> services = typeof(Program).Assembly
                                                 .GetTypes()
                                                 .Where(p => !p.IsInterface && p.IsAssignableTo(typeof(IService)))
                                                 .ToList();
        }
    }
    public interface IService
    {
    }
    public class AService : IService
    {
    }
    public class BService : IService
    {
    }
    public class CService : IService
    {
    }
    public class DService : IService
    {
    }
    public class EService : IService
    {
    }
    public class FService : IService
    {
    }
    public class GService : IService
    {
    }
    public class HService : IService
    {
    }
    public class IIService : IService
    {
    }
    public class JService : IService
    {
    }
    public class KService : IService
    {
    }
    public class LService : IService
    {
    }
    public class MService : IService
    {
    }
    public class NService : IService
    {
    }
    public class OService : IService
    {
    }
    public class PService : IService
    {
    }
    public class QService : IService
    {
    }
}