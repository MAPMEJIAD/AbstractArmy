using Practic.Interfaces;

namespace Practic.Models;

public class InfantryFactory : IArmyFactory
{
    public IUnit CreateUnit()
    {
        Random rand = new Random();
        IUnit infantryUnit = new Infantry();
        infantryUnit.Health = rand.Next(80, 100);
        infantryUnit.Damage = rand.Next(10, 30);
        infantryUnit.Defence = rand.Next(30, 40);
        return infantryUnit;
    }

    public ICommander CreateCommander()
    {
        return new InfantryCommander();
    }
}