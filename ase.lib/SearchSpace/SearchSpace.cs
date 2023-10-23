namespace ase.lib;

internal class SearchSpace<T> : ISearchSpace
{
    /// <summary>
    /// All possible values
    /// </summary>
    private readonly List<T> _values;

    private int _idx = 0;

    public T Value => _values[_idx];

    public SearchSpace(List<T> values)
    {
        _values = values;
    }
    
    public void Reset()
    {
        _idx = 0;
    }

    public bool NextValue()
    {
        return ++_idx < _values.Count;
    }
}