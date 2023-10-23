namespace ase.lib;

public sealed class Var<T> : IVar
{
    internal SearchSpace<T> ss;
    internal Action callback;

    public T Value
    {
        get
        {
            callback();
            return ss.Value;
        }
    }
    
    public static implicit operator T(Var<T> x) => x.Value;

    // Searchspace proxy
    void IVar.Reset() => ss.Reset();
    bool IVar.NextValue() => ss.NextValue();
}