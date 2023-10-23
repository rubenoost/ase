using ase.lib;
using BenchmarkDotNet.Attributes;

namespace ase.benchmark;

public class ASEBenchmark
{
    [Benchmark]
    public bool Test()
    {
        var m = new Model();

        var a1 = m.Int(1, 9);
        var a2 = m.Int(1, 9);
        var a3 = m.Int(1, 9);

        m.Assert(() => a1 > 2);
        m.Assert(() => a2 > 2);
        m.Assert(() => a3 > 2);
        m.Assert(() => a1 > a2);
        m.Assert(() => a2 > a3);
        m.Assert(() => a1 * a2 * a3 == 105);

        var success = m.Solve();
        return success;
    }
}