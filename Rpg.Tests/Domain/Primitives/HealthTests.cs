using Rpg.Domain.Primitives;

namespace Rpg.Tests.Domain.Primitives
{
    public class HealthTests
    {
        [Fact]
        public void Ctor_InitializesToStartingValue()
        {
            var health = new Health();

            Assert.Equal(Health.StartingValue, health.Value);
        }

        [Fact]
        public void InflictDamage_LowersValueByDamageAmount()
        {
            var health = new Health();

            var result = health.InflictDamage(new Damage(100));

            Assert.Equal(900, result.Value);
        }

        [Fact]
        public void InflictDamage_ShouldNotGoBelowMinValue()
        {
            var health = new Health();

            var result = health.InflictDamage(new Damage(2000));

            Assert.Equal(Health.MinHealth, result.Value);
        }

        [Fact]
        public void Heal_IncreasesHealthByAmount()
        {
            var health = new Health(200);

            var result = health.Heal(new HealingAmount(200));

            Assert.Equal(400, result.Value);
        }

        [Fact]
        public void Heal_ShouldNotExceedMaxValue()
        {
            var health = new Health();

            var result = health.Heal(new HealingAmount(200));

            Assert.Equal(Health.MaxHealth, result.Value);
        }

    }
}
