namespace Rpg;

public class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }
    public FighterType FighterType { get; set; }
    public int Postion { set; get; }
    public bool IsAlive => Health > 0;
}

public enum FighterType
{
    Melee,
    Ranged,
}

