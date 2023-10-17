namespace Practic.Interfaces;

public interface IUnit
{
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Defence { get; set; }
    public void Attack();
    public void Defend();
}