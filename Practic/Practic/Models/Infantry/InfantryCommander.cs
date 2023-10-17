using Practic.Interfaces;

namespace Practic.Models;

public class InfantryCommander : ICommander
{
    public event Action? OnOrderToAttack;
    public event Action? OnOrderToDefend;

    public void OrderToAttack()
    {
        Console.WriteLine("Infantry platoon attack!");
        OnOrderToAttack?.Invoke();
    }

    public void OrderToDefend()
    {
        Console.WriteLine("Infantry platoon defend!");
        OnOrderToDefend?.Invoke();
    }
}