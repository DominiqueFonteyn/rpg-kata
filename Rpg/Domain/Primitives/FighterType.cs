using Rpg.Domain.Enums;

namespace Rpg.Domain.Primitives
{
    public class FighterType
    {
        public const int MaxMeleeRange = 2;
        public const int MaxRangedRange = 20;

        public FighterType(FightingType fightingType = FightingType.Melee)
        {
            FightingType = fightingType;
        }

        public FightingType FightingType { get; }
        public int Range => FightingType == FightingType.Melee ? MaxMeleeRange : MaxRangedRange;
    }
}
