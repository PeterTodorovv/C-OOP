using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void ConstructorSetsNameAndCapacity()
        {
            Gym gym = new Gym("Fitness", 12);
            Assert.AreEqual("Fitness", gym.Name);
            Assert.AreEqual(12, gym.Capacity);
        }

        [Test]
        public void GymStartsWithZeroAthletes()
        {
            Gym gym = new Gym("Fitness", 12);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void GymNameCantBeNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(name, 12));
        }

        [Test]
        public void CapacityCantBeNegative()
        {
            Assert.Throws<ArgumentException>(() => new Gym("gym", -1));
        }

        [Test]
        public void CanAddAthletes()
        {
            Gym gym = new Gym("Fitness", 12);
            gym.AddAthlete(new Athlete("Ivan"));
            Assert.AreEqual(1, gym.Count);

            gym.AddAthlete(new Athlete("Gosho"));
            Assert.AreEqual(2, gym.Count);

            gym.AddAthlete(new Athlete("Pesho"));
            Assert.AreEqual(3, gym.Count);
        }

        [Test]
        public void CantAddAthletesToFullGym()
        {
            Gym gym = new Gym("Fitness", 2);
            gym.AddAthlete(new Athlete("Ivan"));
            gym.AddAthlete(new Athlete("Gosho"));

            Athlete athlete = new Athlete("Pesho");
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete));
        }

        [Test]
        public void CanRemoveAthlete()
        {
            Gym gym = new Gym("Fitness", 22);
            gym.AddAthlete(new Athlete("Ivan"));
            gym.AddAthlete(new Athlete("Gosho"));

            gym.RemoveAthlete("Ivan");
            Assert.AreEqual(1, gym.Count);

            gym.RemoveAthlete("Gosho");
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void CantRemoveAthleteThatDoesntExist()
        {
            Gym gym = new Gym("Fitness", 22);
            gym.AddAthlete(new Athlete("Ivan"));
            gym.AddAthlete(new Athlete("Gosho"));

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("asdsa"));
        }

        [Test]
        public void AthleteCanBeInjured()
        {
            Gym gym = new Gym("Fitness", 22);
            Athlete Ivan = new Athlete("Ivan");
            Athlete Gosho = new Athlete("Gosho");
            gym.AddAthlete(Ivan);
            gym.AddAthlete(Gosho);
            gym.InjureAthlete("Ivan");

            Assert.IsTrue(Ivan.IsInjured);
            Assert.IsFalse(Gosho.IsInjured);
        }

        [Test]
        public void CantInjureathleteThatDoesntExist()
        {
            Gym gym = new Gym("Fitness", 22);
            Athlete Ivan = new Athlete("Ivan");
            gym.AddAthlete(Ivan);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("sdf"));
        }

        [Test]
        public void ReportReturnsValidInfo()
        {
            Gym gym = new Gym("Fitness", 22);
            gym.AddAthlete(new Athlete("Ivan"));
            gym.AddAthlete(new Athlete("Gosho"));

            string report = gym.Report();
            string expected = $"Active athletes at {gym.Name}: Ivan, Gosho";

            Assert.AreEqual(expected, report);

        }

        [Test]
        public void ReportDoesntCountInjuredAthelets()
        {
            Gym gym = new Gym("Fitness", 22);
            gym.AddAthlete(new Athlete("Ivan"));
            gym.AddAthlete(new Athlete("Gosho"));

            gym.InjureAthlete("Gosho");
            string expected = $"Active athletes at {gym.Name}: Ivan";

        }
    }
}
