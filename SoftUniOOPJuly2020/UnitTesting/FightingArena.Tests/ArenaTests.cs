using NUnit.Framework;
using FightingArena;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void ArenaCtorShouldWorksProperly()
        {
            Assert.IsNotNull(this.arena);
        }

        [Test]
        public void ArenaEnrollShouldWorksProperly()
        {
            Warrior warrior = new Warrior("Ivan", 30, 30);
            arena.Enroll(warrior);

            Assert.That(this.arena.Warriors, Has.Member(warrior));

        }

        [Test]
        public void IfEqualWarriorsEnrolledShouldThrowException()
        {
            Warrior warrior = new Warrior("Ivan", 30, 30);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void ArenaCountWorkingProperly()
        {
            Warrior warrior = new Warrior("Ivan", 30, 30);
            arena.Enroll(warrior);
            int expectedArenaCount = 1;

            Assert.That(this.arena.Count, Is.EqualTo(expectedArenaCount));
        }

        [TestCase(null, "Ivan")]
        [TestCase("Ivan", null)]
        [TestCase("Ivan","Gosho")]
        public void IfMissingFighterThrowException(string f1, string f2)
        {

            Assert.Throws<InvalidOperationException>(() => arena.Fight(f1, f2));

        }
        
        [Test]
        public void FightShouldWorkCorectly()
        {
            Warrior attacker = new Warrior("Ivan", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 50);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight("Ivan", "Gosho");

            int expectedAttackerHP = 95;
            int expectedDefenderHP = 40;

            Assert.That(attacker.HP, Is.EqualTo(expectedAttackerHP));
            Assert.That(defender.HP, Is.EqualTo(expectedDefenderHP));
        }


    }
}

