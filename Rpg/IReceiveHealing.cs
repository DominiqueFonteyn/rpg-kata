namespace Rpg;

public interface IReceiveHealing
{
    void ReceiveHealing(int health);
    bool IsDead { get; }
}
