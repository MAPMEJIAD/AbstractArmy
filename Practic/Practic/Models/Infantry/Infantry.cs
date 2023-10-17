using Practic.Interfaces;

namespace Practic.Models;

public class Infantry : IUnit
{
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Defence { get; set; }

    public void Attack()
    {
        Console.WriteLine("Infantry attacks");
    }

    public void Defend()
    {
        Console.WriteLine("Infantry defends");
    }
}