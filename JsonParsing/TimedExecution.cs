using System;
using System.Diagnostics;

namespace JsonParsing;

public class TimedExecution : IDisposable
{
    private readonly string _name;
    private readonly Stopwatch _watch = new();
    public TimedExecution(string name = "")
    {
        _name = name;
        _watch.Start();
    }

    public void Dispose()
    {
        _watch.Stop();
        Console.WriteLine($"Finished {_name} in {_watch.ElapsedMilliseconds}ms or {_watch.Elapsed.TotalSeconds}s");
    }
}