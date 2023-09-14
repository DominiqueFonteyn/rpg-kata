using Rpg.Domain.Primitives;

namespace Rpg.Tests.Domain.Primitives
{
    public class HealthTests
    {
        [Fact]
        public void InflictDamage_LowersValueByDamageAmount()
        {
            var health = new Health(1000);

            var result = health.InflictDamage(new Damage(100));

            Assert.Equal(900, result.Value);
        }

        [Fact]
        public void InflictDamage_ShouldNotGoBelowZero()
        {
            var health = new Health(1000);

            var result = health.InflictDamage(new Damage(2000));

            Assert.Equal(0, result.Value);
        }

        [Fact]
        public void Heal_IncreasesHealthByAmount()
        {
            var health = new Health(200);

            var result = health.Heal(new HealthAmount(200));

            Assert.Equal(400, result.Value);
        }

        [Fact]
        public void Heal_ShouldNotExceed1000()
        {
            var health = new Health(1000);

            var result = health.Heal(new HealthAmount(200));

            Assert.Equal(1000, result.Value);
        }

    }
}
