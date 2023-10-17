using Practic.Interfaces;

namespace Practic.Models;

public class Artillery : IUnit
{
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Defence { get; set; }

    public void Attack()
    {
        Console.WriteLine("Artillery attacks");
    }

    public void Defend()
    {
        Console.WriteLine("Artillery defends");
    }
}