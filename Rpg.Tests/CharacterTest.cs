using System.Reflection;

namespace Rpg.Tests
{
    public class CharacterTest
    {
        [Fact]
        public void Health_StartsAt1000()
        {
            var character = new Character();

            Assert.Equal(1000, character.Health);
        }

        [Fact]
        public void LevelStart1()
        {
            var character = new Character();

            Assert.Equal(1, character.Level);
        }

        [Fact]
        public void StartingAlive()
        {
            var character = new Character();

            Assert.True(character.IsAlive);
        }

        [Fact]
        public void Damage_10_Health990()
        {
            var ole = new Character();
            var simon = new Character();

            ole.Damage(simon, 10);

            Assert.Equal(990, simon.Health);
        }
        [Fact]
        public void TestKill()
        {
            var simon = new Character();
            var ole = new Character();
            simon.Damage(ole, ole.Health + 10);
            Assert.False(ole.IsAlive);
        }

        [Fact]
        public void CannotDealDamageToSelf()
        {
            var simon = new Character();

            var Act = () => simon.Damage(simon, 50);

            Assert.Throws<Exception>(Act);
        }

        [Fact]
        public void TestACharacterCanOnlySelfHeal()
        {
            var simon = new Character();
            var ole = new Character();

            var Act = () => simon.Heal(ole);

            Assert.Throws<Exception>(Act);
        }

        [Fact]
        public void Damage_OtherIs5LevelsBelowSelf_ReducedBy50Percent()
        {
            var simon = new Character();
            var ole = new Character();

            ole.LevelUp(5);
            ole.Damage(simon, 100);

            Assert.Equal(950, simon.Health);
        }
        [Fact]
        public void Level5higherIncreaseDammage()
        {
            var simon = new Character();
            var ole = new Character();

            simon.LevelUp(5);
            ole.Damage(simon, 100);
            Assert.Equal(850, simon.Health);


        }

        [Fact]
        public void MeleeFighterHasRangeOf2Meters()
        {
            var fighter = new MeleeFighter();

            Assert.Equal(2, fighter.Range);
        }
        [Fact]
        public void RangedFighterHasRangeOf20Meters()
        {
            var fighter = new RangedFighter();

            Assert.Equal(20, fighter.Range);
        }
    }

    internal class MeleeFighter
    {
        public MeleeFighter()
        {
        }

        public int Range { get; } = 2;
    }
    internal class RangedFighter
    {
        public RangedFighter()
        {
        }

        public int Range { get; } = 20;
    }
    public class Character
    {
        public int Health { get; protected set; } = 1000;
        public int Level { get; protected set; } = 1;
        public bool IsAlive
        {
            get
            {
                if (Health <= 0) return false;
                return true;
            }
        }

        public void Damage(Character target, int damage)
        {
            if (this == target)
                throw new Exception();

            int damageDealt = damage;
            if (HasDecreasedDamage(target))
                damageDealt = damage / 2;
            if (HasIncreasedDamage(target))
                damageDealt = (int)Math.Round(damage * 1.5);

            target.Health = target.Health - damageDealt;
        }

        private bool HasIncreasedDamage(Character target)
        => target.Level - Level >= 5;

        private bool HasDecreasedDamage(Character target)
        => Level - target.Level >= 5;

        public void Heal(Character self)
        {
            if (this != self)
                throw new Exception();

        }

        public void LevelUp(int levelAmount)
        {
            Level += levelAmount;
        }
    }
}
