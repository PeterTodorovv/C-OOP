using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        Axe axe = new Axe(1, 10);
        [Test]
        public void DummyLoosesHealthIfAttacked()
        {
            Dummy dummy = new Dummy(10, 20);
            axe.Attack(dummy);
            Assert.That(dummy.Health == 9);
        }

        [Test]
        public void DummyCantBeAttackedIfDead()
        {
            Dummy dummy = new Dummy(0, 20);

            Assert.That(() => axe.Attack(dummy), Throws.Exception);
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 20);
            Assert.DoesNotThrow(() => dummy.GiveExperience());

        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(10, 20);
            Assert.That(() => dummy.GiveExperience(), Throws.Exception);

        }
    }
}