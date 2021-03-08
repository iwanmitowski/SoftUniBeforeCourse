using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Skeleton;

namespace Tests
{
    [TestFixture]
    class HeroTests
    {
        [Test]
        public void PlayerXPShouldWorkCorectly()
        {
            Mock<ITarget> moqTarget = new Mock<ITarget>();
            Mock<IWeapon> moqWeapon = new Mock<IWeapon>();
            Mock<Hero> moqHero = new Mock<Hero>("Ivan", moqWeapon.Object);

            moqTarget.Setup(t => t.IsDead()).Returns(true);
            moqTarget.Setup(t => t.GiveExperience()).Returns(10);

            moqHero.Object.Attack(moqTarget.Object);
            int expected = 10;
            int actualHeroValue = moqHero.Object.Experience;

            Assert.That(actualHeroValue, Is.EqualTo(expected));
        }
    }
}
