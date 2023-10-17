namespace Practic.Interfaces;

public interface ICommander
{
    public event Action OnOrderToAttack;
    public event Action OnOrderToDefend;
    public void OrderToAttack();
    public void OrderToDefend();
}