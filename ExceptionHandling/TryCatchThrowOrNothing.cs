using BenchmarkDotNet.Attributes;

namespace ExceptionHandling;

[MemoryDiagnoser]
[MarkdownExporterAttribute.GitHub]
public class TryCatchThrowOrNothing
{
    // SharpLab: https://sharplab.io/#v2:D4AQTAjAsAUCDMACciDCiDetE+z5SIALIgHID2ALgBYCWAdgOYAUAlHjljPj4g5YgDOAVwC2iALyIADAG4OvAGbkATomb8+kmbK0AeRBGly+AalPtuvTgus4R401Nryr1gL6wFntwWQkAFRUAT1QAQ0oAY2oA6hVyAHc2BS47REoQ23xUtPxNB205LOtlNQ16AVpC3SqDIxNac0tc7OLcgqc+VxacHzafNMiI6PUAUQAPSIBTAAdKWnJ6RCnmuxyWmniE7rsB/B93IA=
    public int Result { get; set; }
    
    [Benchmark]
    public void Nothing()
    {
        int sum = 0;
        for (int i = 0; i < 100; i++)
        {
            sum += i;
        }

        Result = sum;
    }
    [Benchmark]
    public void TryCatchThrow()
    {
        try
        {
            int sum = 0;
            for (int i = 0; i < 100; i++)
            {
                sum += i;
            }

            Result = sum;
        }
        catch (Exception e)
        {
            throw;
        }
    }
}