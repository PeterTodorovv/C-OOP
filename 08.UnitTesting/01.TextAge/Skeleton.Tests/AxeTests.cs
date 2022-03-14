using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeShouldLooseDurabilityAfterAtack()
        {
            Axe axe = new Axe(1, 10);
            Dummy dummy = new Dummy(100, 10);
            axe.Attack(dummy);
            Assert.AreEqual(axe.DurabilityPoints, 9);
        }

        [Test]
        public void AxeCantAttackIfBroken()
        {
            Axe axe = new Axe(1, 0);
            Dummy dummy = new Dummy(100, 10);

            Assert.That(() => axe.Attack(dummy), Throws.Exception);
        }

        
    }
}