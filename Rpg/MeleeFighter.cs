namespace Rpg;

public class MeleeFighter : Character
{
    public MeleeFighter(int level = StartingLevel) : base(level)
    {
        Range = 2;
    }
}