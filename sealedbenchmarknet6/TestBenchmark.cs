using BenchmarkDotNet.Attributes;
using sealedbenchmarknet6.models;

namespace sealedbenchmarknet6;

public class TestBenchmark
{
    private readonly SomeObjetctNoSealed _objetctNoSealed = new();
    private readonly SomeObjetctSealed _objetctSealed = new();
    private readonly SomeObjetctNoSealed[] _objetctsNoSealed = new SomeObjetctNoSealed[100];
    private readonly SomeObjetctSealed[] _objetctsSealed = new SomeObjetctSealed[100];

    [Benchmark]
    public void CallNotSealed()
    {
        _objetctNoSealed.SomeMethod();
    }

    [Benchmark]
    public void CallSealed()
    {
        _objetctSealed.SomeMethod();
    }

    [Benchmark]
    public void CallArrayNotSealed()
    {
        for (var i = 0; i < _objetctsNoSealed.Length; i++)
        {
            _objetctsNoSealed[i] = new SomeObjetctNoSealed();
        }
    }

    [Benchmark]
    public void CallArraySealed()
    {
        for (var i = 0; i < _objetctsSealed.Length; i++)
        {
            _objetctsSealed[i] = new SomeObjetctSealed();
        }
    }
}