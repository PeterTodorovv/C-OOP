namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {

        [Test]
        public void ConstructorMustSetCapacity()
        {
            RobotManager manager = new RobotManager(3);
            Assert.AreEqual(3, manager.Capacity);
        }

        [Test]
        public void CantCreateRobotManagerWithCapacityNegative()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-3));
        }

        [Test]
        public void ManagerStartsWithZeroElements()
        {
            var manager = new RobotManager(3);
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void CanAddRobotIfValid()
        {
            RobotManager manager = new RobotManager(3);
            manager.Add(new Robot("Gosho", 300));
            manager.Add(new Robot("Ivan", 300));

            Assert.AreEqual(2, manager.Count);

        }

        [Test]
        public void CantAddRobotIfItAlreadyExists()
        {
            RobotManager manager = new RobotManager(3);
            manager.Add(new Robot("Gosho", 300));

            Assert.Throws<InvalidOperationException>(() => manager.Add(new Robot("Gosho", 300)));
        }

        [Test]
        public void CantAddRobotIfCapacityIsFull()
        {
            RobotManager manager = new RobotManager(3);
            manager.Add(new Robot("Gosho", 300));
            manager.Add(new Robot("Ivan", 300));
            manager.Add(new Robot("Pesho", 300));

            Assert.Throws<InvalidOperationException>(() => manager.Add(new Robot("Dragan", 300)));
        }

        [Test]
        public void CanRemoveRobotThatExists()
        {
            RobotManager manager = new RobotManager(3);
            manager.Add(new Robot("Gosho", 300));
            manager.Add(new Robot("Ivan", 300));
            manager.Add(new Robot("Pesho", 300));

            manager.Remove("Gosho");
            Assert.AreEqual(2, manager.Count);

            manager.Remove("Ivan");
            Assert.AreEqual(1, manager.Count);

            manager.Remove("Pesho");
            Assert.AreEqual(0, manager.Count);

        }

        [Test]
        public void CantRemoveRobotThatDoesntExist()
        {
            RobotManager manager = new RobotManager(3);

            Assert.Throws<InvalidOperationException>(() => manager.Remove("Ivan"));
        }

        [Test]
        public void RobotThatExistCanWork()
        {
            RobotManager manager = new RobotManager(3);
            Robot Gosho = new Robot("Gosho", 100);
            manager.Add(Gosho);
            manager.Work("Gosho", "Coding", 20);
            Assert.AreEqual(80, Gosho.Battery);

        }

        [Test]
        public void RobotThatDoesntExistThrowsError()
        {
            RobotManager manager = new RobotManager(3);
            manager.Add(new Robot("Gosho", 300));
            Assert.Throws<InvalidOperationException>(() => manager.Work("Ivan", "Coding", 20));
        }

        [Test]
        public void RobotCantWorkWithoutEnoghBattery()
        {
            RobotManager manager = new RobotManager(3);
            manager.Add(new Robot("Gosho", 50));
            Assert.Throws<InvalidOperationException>(() => manager.Work("Gosho", "Coding", 60));
        }

        [Test]
        public void RobotCanBeCharged()
        {
            RobotManager manager = new RobotManager(3);
            Robot Gosho = new Robot("Gosho", 300);
            manager.Add(Gosho);
            manager.Work("Gosho", "Coding", 20);
            manager.Charge("Gosho");

            Assert.AreEqual(Gosho.MaximumBattery, Gosho.Battery);
        }

        [Test]
        public void RobotThatDoesntExistCantBeCharged()
        {
            RobotManager manager = new RobotManager(3);
            Robot Gosho = new Robot("Gosho", 300);
            manager.Add(Gosho);
            Assert.Throws<InvalidOperationException>(() => manager.Charge("Ivan"));
        }
    }
}
