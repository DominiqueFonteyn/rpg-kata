namespace Rpg.Faults
{
    public class CharacterAlreadyDeadException
        : Exception
    {
        public CharacterAlreadyDeadException() 
            : base("Character cannot be healed when dead")
        {
            
        }
    }
}
