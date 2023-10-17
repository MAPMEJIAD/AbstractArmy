using Practic.Interfaces;

namespace Practic.Models;

public class CavalryFactory : IArmyFactory
{
    public IUnit CreateUnit()
    {
        Random rand = new Random();
        IUnit cavalryUnit = new Cavalry();
        cavalryUnit.Health = rand.Next(80, 100);
        cavalryUnit.Damage = rand.Next(10, 30);
        cavalryUnit.Defence = rand.Next(30, 40);
        return cavalryUnit;
    }

    public ICommander CreateCommander()
    {
        return new CavalryCommander();
    }
}