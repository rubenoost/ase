namespace ase.lib;

internal interface IVar
{
    /// <summary>
    /// Reset the variable to all available values
    /// </summary>
    void Reset();
    
    /// <summary>
    /// Returns bool if selecting the next value was successful.
    /// </summary>
    /// <returns></returns>
    bool NextValue();
}