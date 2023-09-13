namespace Rpg;

public class Character
{
    public int Health { get; }
    public int Level { get; }
    public CharacterStatus Status { get; }

    public Character()
    {
        Health = 1000;
        Level = 1;
    }
}