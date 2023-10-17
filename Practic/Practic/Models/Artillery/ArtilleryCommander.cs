using Practic.Interfaces;

namespace Practic.Models;

public class ArtilleryCommander : ICommander
{
    public event Action? OnOrderToAttack;
    public event Action? OnOrderToDefend;

    public void OrderToAttack()
    {
        Console.WriteLine("Artillery platoon attack!");
        OnOrderToAttack?.Invoke();
    }

    public void OrderToDefend()
    {
        Console.WriteLine("Artillery platoon defend!");
        OnOrderToDefend?.Invoke();
    }
}