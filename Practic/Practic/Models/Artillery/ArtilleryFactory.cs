using Practic.Interfaces;

namespace Practic.Models;

public class ArtilleryFactory : IArmyFactory
{
    public IUnit CreateUnit()
    {
        Random rand = new Random();
        IUnit artilleryUnit = new Artillery();
        artilleryUnit.Health = rand.Next(80, 100);
        artilleryUnit.Damage = rand.Next(10, 30);
        artilleryUnit.Defence = rand.Next(30, 40);
        return artilleryUnit;
    }

    public ICommander CreateCommander()
    {
        return new ArtilleryCommander();
    }
}