namespace ase.lib;

internal interface ISearchSpace
{
    /// <summary>
    /// Reset the variable to all available values
    /// </summary>
    public void Reset();
    
    /// <summary>
    /// Returns bool if selecting the next value was successful.
    /// </summary>
    /// <returns></returns>
    public bool NextValue();
}