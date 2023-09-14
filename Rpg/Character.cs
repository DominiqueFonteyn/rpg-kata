namespace Rpg;

public class Character
{
    public int Health { get; set; } = 1000;
    public int Level  => 1;
    public bool IsAlive => true;

    public void DoDamage(int damage)
    {
        Health -= damage;
    }
}