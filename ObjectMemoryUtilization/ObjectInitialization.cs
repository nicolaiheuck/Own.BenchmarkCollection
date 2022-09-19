using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace ObjectMemoryUtilization;

[MemoryDiagnoser]
[MarkdownExporterAttribute.GitHub]
public class ObjectInitialization
{
    public string Result { get; set; }
    
    [Benchmark]
    [BenchmarkCategory("MultipleMethods")]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public void InitializationOfOneObject()
    {
        TestClass test = new TestClass();
        for (int i = 0; i < 5; i++)
        {
            Result = test.Test1();
        }
    }
    
    // [Benchmark]
    // [BenchmarkCategory("MultipleMethods")]
    // [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    // public void InitializationOfFiveObjects()
    // {
    //     TestClass test = new TestClass();
    //     TestClass test2 = new TestClass();
    //     TestClass test3 = new TestClass();
    //     TestClass test4 = new TestClass();
    //     TestClass test5 = new TestClass();
    //     
    //     Result = test.Test1();
    //     Result = test2.Test1();
    //     Result = test3.Test1();
    //     Result = test4.Test1();
    //     Result = test5.Test1();
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("SingleMethod")]
    // [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    // public void InitializationOfOneObjectSingleMethod()
    // {
    //     TestClass test = new TestClass();
    //     for (int i = 0; i < 5; i++)
    //     {
    //         Result = test.Test1();
    //     }
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("SingleMethod")]
    // [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    // public void InitializationOfFiveObjectsSingleMethod()
    // {
    //     TestClass test = new TestClass();
    //     TestClass test2 = new TestClass();
    //     TestClass test3 = new TestClass();
    //     TestClass test4 = new TestClass();
    //     TestClass test5 = new TestClass();
    //     
    //     Result = test.Test1();
    //     Result = test2.Test1();
    //     Result = test3.Test1();
    //     Result = test4.Test1();
    //     Result = test5.Test1();
    // }
    
}
public class TestClass
{
    public string Test1() => "Test";
    public void Test2() {}
    public void Test3() {}
    public void Test4() {}
    public void Test5() {}
}
public class TestClass2
{
    public string Test1() => "Test";
}