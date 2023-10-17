using Practic.Interfaces;

namespace Practic.Models;

public class CavalryCommander : ICommander
{
    public event Action? OnOrderToAttack;
    public event Action? OnOrderToDefend;

    public void OrderToAttack()
    {
        Console.WriteLine("Cavalry platoon attack!");
        OnOrderToAttack?.Invoke();
    }

    public void OrderToDefend()
    {
        Console.WriteLine("Cavalry platoon defend!");
        OnOrderToDefend?.Invoke();
    }
}