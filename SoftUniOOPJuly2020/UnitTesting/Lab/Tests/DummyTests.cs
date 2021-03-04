using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Tests
{
    [TestFixture]
    class DummyTests
    {
        private const int AxeAttack = 2;
        private const int AxeDurability = 2;
        private const int DummyHealth = 10;
        private const int DummyXp = 10;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyXp);
        }

        [Test]
        public void DummyLosesHpIfAttacked()
        {

            axe.Attack(dummy);

            Assert.That(dummy.Health, Is.EqualTo(8));
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            dummy.TakeAttack(20);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(20));

            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));


        }
        [Test]
        public void DeadDummyCanGiveExp()
        {
            dummy.TakeAttack(21);

            int exp = dummy.GiveExperience();

            Assert.That(exp, Is.Not.EqualTo(0));
        }

        [Test]
        public void AliveDummyCantGiveExp()
        {
            dummy.TakeAttack(2);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());

            Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
        }
    }
}
