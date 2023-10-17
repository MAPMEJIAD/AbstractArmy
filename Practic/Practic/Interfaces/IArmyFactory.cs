namespace Practic.Interfaces;

public interface IArmyFactory
{
    public IUnit CreateUnit();
    public ICommander CreateCommander();
}