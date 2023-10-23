namespace ase.lib;

public sealed class Model
{
    private int _nextID = 0;

    private readonly Dictionary<int, IVar> _vars = new();

    private readonly List<Func<bool>> _assertions = new();

    private readonly Action<int> _callback;
    private readonly Stack<int> _requestedValuesInOrder = new();
    private bool[]? _requestedValues;

    public Model()
    {
        // Callback for registering what happened
        _callback = i =>
        {
            if (!_requestedValues[i])
            {
                _requestedValues[i] = true;
                _requestedValuesInOrder.Push(i);
            }
        };
    }

    public Var<int> Int(int minInclusive, int maxInclusive)
    {
        var values = Enumerable.Range(minInclusive, maxInclusive - minInclusive + 1).ToList();
        var ss = new SearchSpace<int>(values);

        var id = _nextID++;

        var result = new Var<int>
        {
            ss = ss,
            callback = () => _callback(id)
        };

        _vars.Add(id, result);
        return result;
    }

    public void Assert(Func<bool> assertion)
    {
        _assertions.Add(assertion);
    }

    public bool Solve()
    {
        _requestedValues = new bool[_nextID];
        var run = 0;

        while (true)
        {
            // Check all assertions
            for (var i = 0; i < _assertions.Count; i++)
            {
                var assertion = _assertions[i];
                if (!assertion())
                {
                    goto failure;
                }
            }

            // Success
            return true;

            // Failure
            failure:

            foreach (var id in _requestedValuesInOrder.Reverse())
            {
                var v = _vars[id];
                if (v.NextValue())
                {
                    // Selecting the next value is succeeded, so let's run this again
                    goto next;
                }
                else
                {
                    v.Reset();
                }
            }
            
            // This failed
            return false;
            
            next: ;
        }
    }
}