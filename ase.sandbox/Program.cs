using ase.lib;

var m = new Model();

// Variables
var a1 = m.Int(1, 9);
var a2 = m.Int(1, 9);
var a3 = m.Int(1, 9);

// Conditions
m.Assert(() => a1 > 2);
m.Assert(() => a2 > 2);
m.Assert(() => a3 > 2);
m.Assert(() => a1 > a2);
m.Assert(() => a2 > a3);
m.Assert(() => a1 * a2 * a3 == 105);

// Solution
var success = m.Solve();

if (success)
{
    Console.WriteLine("Solution found: {0} / {1} / {2}" , a1.Value, a2.Value, a3.Value);
}
else
{
    Console.WriteLine("Could not find solution");
}