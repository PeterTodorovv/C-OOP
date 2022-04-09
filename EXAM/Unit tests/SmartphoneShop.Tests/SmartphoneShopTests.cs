using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
       [Test]
       public void ConstructorSetsCapacityAndPhones()
        {
            int capacity = 3;
            Shop shop = new Shop(capacity);

            Assert.AreEqual(capacity, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void CapacityCantBeLessThenZero()
        {
            Assert.Throws<ArgumentException>(() => new Shop(-1));
        }

        [Test]
        public void PhonesCanBeAdded()
        {
            Shop shop = new Shop(10);
            shop.Add(new Smartphone("Samsung", 5000));
            Assert.AreEqual(1, shop.Count);

            shop.Add(new Smartphone("Apple", 3000));
            Assert.AreEqual(2, shop.Count);
        }

        [Test]
        public void CantAddSmartphoneThatAlreadyExists()
        {
            Shop shop = new Shop(10);
            shop.Add(new Smartphone("Samsung", 5000));
            shop.Add(new Smartphone("Apple", 3000));

            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("Samsung", 2000)));
        }

        [Test]
        public void CantAddPhoneToFullShop()
        {
            Shop shop = new Shop(2);
            shop.Add(new Smartphone("Samsung", 5000));
            shop.Add(new Smartphone("Apple", 3000));

            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("Xiaomi", 2000)));
        }

        [Test]
        public void PhoneCanBeRemoved()
        {
            Shop shop = new Shop(22);
            shop.Add(new Smartphone("Samsung", 5000));
            shop.Add(new Smartphone("Apple", 3000));

            shop.Remove("Samsung");
            Assert.AreEqual(1, shop.Count);

            shop.Remove("Apple");
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void CantRemovePhoneThatDoesntExist()
        {
            Shop shop = new Shop(22);
            shop.Add(new Smartphone("Samsung", 5000));
            shop.Add(new Smartphone("Apple", 3000));

            Assert.Throws<InvalidOperationException>(() => shop.Remove("Xiaomi"));
        }

        [Test]
        public void PhoneCanBeTested()
        {
            Shop shop = new Shop(22);
            Smartphone Samsung = new Smartphone("Samsung", 5000);
            Smartphone Apple = new Smartphone("Apple", 3000);

            shop.Add(Samsung);
            shop.Add(Apple);

            shop.TestPhone("Apple", 2000);
            shop.TestPhone("Samsung", 4000);

            Assert.AreEqual(1000, Samsung.CurrentBateryCharge);
            Assert.AreEqual(1000, Apple.CurrentBateryCharge);
        }

        [Test]
        public void CantTestPhoneThatDoesntExist()
        {
            Shop shop = new Shop(22);
            shop.Add(new Smartphone("Samsung", 5000));
            shop.Add(new Smartphone("Apple", 3000));

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Xiaomi", 2000));
        }

        [Test]
        public void CantTestPhoneThatIsLowOnBattery()
        {
            Shop shop = new Shop(22);
            shop.Add(new Smartphone("Samsung", 5000));
            shop.Add(new Smartphone("Apple", 3000));

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Apple", 3500));
        }

        [Test]
        public void PhoneCanBeCharged()
        {
            Shop shop = new Shop(22);
            Smartphone Samsung = new Smartphone("Samsung", 5000);
            Smartphone Apple = new Smartphone("Apple", 3000);

            shop.Add(Samsung);
            shop.Add(Apple);

            shop.TestPhone("Apple", 2000);
            shop.TestPhone("Samsung", 4000);

            shop.ChargePhone("Apple");
            shop.ChargePhone("Samsung");

            Assert.AreEqual(Apple.CurrentBateryCharge, 3000);
            Assert.AreEqual(Samsung.CurrentBateryCharge, 5000);
        }

        [Test]
        public void CantChargePhoneThatDoesntExist()
        {
            Shop shop = new Shop(22);
            shop.Add(new Smartphone("Samsung", 5000));
            shop.Add(new Smartphone("Apple", 3000));

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Xiaomi"));
        }
    }
}