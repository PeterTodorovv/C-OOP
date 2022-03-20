using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DifferentWarriorsCanBeEnroled()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Ivan", 30, 100);
            Warrior warrior2 = new Warrior("Gosho", 301, 90);
            Warrior warrior3 = new Warrior("Pesho", 69, 420);

            arena.Enroll(warrior);
            arena.Enroll(warrior2);
            arena.Enroll(warrior3);

            Assert.AreEqual(3, arena.Count);

        }

        [Test]
        public void CantEnrollTheSameWarriorTwise()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Ivan", 30, 100);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void IfTheTwoWarriorsAreOnTheArenaTheyCanFight()
        {
            Warrior warrior = new Warrior("Ivan", 30, 100);
            Warrior warrior2 = new Warrior("Gosho", 301, 90);

            Arena arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(warrior2);

            Assert.DoesNotThrow(() => arena.Fight("Gosho", "Ivan"));
        }

        [Test]
        public void ThereCanNotBeAfightIfBothWarriorsArentEnrolled()
        {
            Warrior warrior = new Warrior("Ivan", 30, 100);
            Arena arena = new Arena();
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Gosho", "Ivan"));
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Ivan", "Gosho"));

        }
    }
}
