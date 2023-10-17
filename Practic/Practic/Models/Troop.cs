using Practic.Interfaces;

namespace Practic.Models;

public class Troop
{
    public ICommander Commander { get; private set; }
    private List<IUnit> _units;
    public List<IUnit> Units => new(_units);
    public int Health = 0;
    public int Damage = 0;
    public int Defence = 0;
    public int Number;

    public Troop(int number)
    {
        Number = number;
        _units = new List<IUnit>();
    }

    public void SetCommander(ICommander commander)
    {
        Commander = commander;
        Commander.OnOrderToAttack += CommanderAttackOrderHandler;
        Commander.OnOrderToDefend += CommanderDefendOrderHandler;
    }

    public void AddUnit(IUnit unit)
    {
        _units.Add(unit);
        Health += unit.Health;
        Damage += unit.Damage;
        Defence += unit.Defence;
    }

    public bool Fight(Troop anotherTroop)
    {
        float thisTroopCapacity = Health * Defence / 100 / anotherTroop.Damage;
        float anotherTroopCapacity = anotherTroop.Health * anotherTroop.Defence / 100 / Damage;
        return thisTroopCapacity > anotherTroopCapacity;
    }

    private void CommanderAttackOrderHandler()
    {
        foreach (var unit in _units)
        {
            unit.Attack();
        }
    }

    private void CommanderDefendOrderHandler()
    {
        foreach (var unit in _units)
        {
            unit.Defend();
        }
    }
}