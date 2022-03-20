using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("James", 20, 50)]
        [TestCase("Ivan", 1, 501)]
        [TestCase("Gosho", 100, 3)]
        public void ConstructorShouldWorkIfDataIsValid(string name, int dmg, int hp)
        {
            Warrior warrior = new Warrior(name, dmg, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(dmg, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);

        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void NameCannotBeNullEmptyOrWhitespace(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 20 , 30));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-123)]
        public void DamageCantBeZeroOrNegavite(int dmg)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Jake", dmg, 30));

        }

        [TestCase(-123)]
        [TestCase(-23)]
        public void HpCantBeNegative(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Jake", 13, hp));

        }

        [Test]
        [TestCase(10)]
        [TestCase(1)]
        [TestCase(29)]
        public void WarriorCantAttackIfHeIsUnder30Hp(int hp)
        {
            Warrior attackWarrior = new Warrior("Jake", 20, hp);
            Warrior defenceWarrior = new Warrior("Ivan", 10, 50);
            Assert.Throws<InvalidOperationException>(() => attackWarrior.Attack(defenceWarrior));
        }

        [Test]
        [TestCase(10)]
        [TestCase(1)]
        [TestCase(29)]
        public void WarriorCantAttackEnemiesUnder30Hp(int hp)
        {
            Warrior attackWarrior = new Warrior("Jake", 20, 40);
            Warrior defenceWarrior = new Warrior("Ivan", 10, hp);
            Assert.Throws<InvalidOperationException>(() => attackWarrior.Attack(defenceWarrior));
        }

        [Test]
        [TestCase(50)]
        [TestCase(41)]

        public void WarriorCantAttackStrongerEnemy(int dmg)
        {
            Warrior attackWarrior = new Warrior("Jake", 20, 40);
            Warrior defenceWarrior = new Warrior("Ivan", dmg, 100);
            Assert.Throws<InvalidOperationException>(() => attackWarrior.Attack(defenceWarrior));
        }

        [TestCase(110, 10)]
        public void DamageIsCalculatedProperly(int atackerDmg, int defenceDmg)
        {
            Warrior attackWarrior = new Warrior("Jake", atackerDmg, 40);
            Warrior defenceWarrior = new Warrior("Ivan", defenceDmg, 100);

            attackWarrior.Attack(defenceWarrior);
            Assert.AreEqual(0, defenceWarrior.HP);
            Assert.AreEqual(30, attackWarrior.HP);
        }
    }
}