using Practic.Interfaces;

namespace Practic.Models;

public class Cavalry : IUnit
{
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Defence { get; set; }

    public void Attack()
    {
        Console.WriteLine("Cavalry attacks");
    }

    public void Defend()
    {
        Console.WriteLine("Cavalry defends");
    }
}