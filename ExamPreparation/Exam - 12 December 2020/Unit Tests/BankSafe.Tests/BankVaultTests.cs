using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorWorks()
        {
            BankVault bankVault = new BankVault();

            Assert.AreEqual(12, bankVault.VaultCells.Count);
        }

        [Test]
        [TestCase("69", "11", "22")]
        public void CanAddValidCell(string id1, string id2, string id3)
        {
            BankVault bankVault = new BankVault();
            Assert.AreEqual($"Item:{id1} saved successfully!" ,bankVault.AddItem("A1", new Item("Ivan", id1)));
            Assert.AreEqual($"Item:{id2} saved successfully!", bankVault.AddItem("A2", new Item("Gosho", id2)));
            Assert.AreEqual($"Item:{id3} saved successfully!", bankVault.AddItem("B2", new Item("Pesho", id3)));

        }

        [Test]
        [TestCase("C8")]
        [TestCase("p8")]
        [TestCase("AA")]
        public void CantAddItemToNonExistingCell(string cell)
        {
            BankVault bankVault = new BankVault();

            Assert.Throws<ArgumentException>(() => bankVault.AddItem(cell, new Item("Ivan", "69")));
        }

        [Test]
        public void CantAddItemToTakenCell()
        {
            BankVault bankVault = new BankVault();
            bankVault.AddItem("A1", new Item("Ivan", "90"));

            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", new Item("gosho", "69")));
        }

        [Test]
        public void CantAddItemThatExists()
        {
            BankVault bankVault = new BankVault();
            bankVault.AddItem("A1", new Item("Ivan", "90"));

            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("B2", new Item("Ivan", "90")));
        }

        [Test]
        [TestCase("11", "22", "33")]
        public void CanRemoveItem(string id1, string id2, string id3)
        {
            BankVault bankVault = new BankVault();
            Item item1 = new Item("Pesho", id1);
            Item item2 = new Item("Ivan", id2);
            Item item3 = new Item("Stamat", id3);
            bankVault.AddItem("A1", item1);
            bankVault.AddItem("A2", item2);
            bankVault.AddItem("B2", item3);

            Assert.AreEqual($"Remove item:{id1} successfully!", bankVault.RemoveItem("A1", item1));
            Assert.AreEqual($"Remove item:{id2} successfully!", bankVault.RemoveItem("A2", item2));
            Assert.AreEqual($"Remove item:{id3} successfully!", bankVault.RemoveItem("B2", item3));
        }

        [Test]
        public void CantAddItemToNonExistingCell()
        {
            BankVault bankVault = new BankVault();

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("gosho", new Item("adsa", "909")));
        }

        [Test]
        public void CantRemoveItemThatDoesntExist()
        {
            BankVault bankVault = new BankVault();
            Item item1 = new Item("Pesho", "33");
            Item item2 = new Item("Ivan", "22");
            Item item3 = new Item("Stamat", "90");
            bankVault.AddItem("A1", item1);
            bankVault.AddItem("A2", item2);
            bankVault.AddItem("B2", item3);
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", new Item("Ivan", "22")));
        }
    }
}