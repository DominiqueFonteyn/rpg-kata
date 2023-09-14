namespace Rpg;

public class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }
    public bool IsAlive => Health > 0;
}

