using NUnit.Framework;
using Database;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        

        public void ElementCanBeAddedIfTheArrayIsntFull()
        {
            Database.Database database = new Database.Database();
            database.Add(1);
            database.Add(2);
            database.Add(3);

            Assert.AreEqual(database.Count, 3);
        }

        [Test]
        public void CantAdd17thElement()
        {
            Database.Database database = new Database.Database();

            for(int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.That(() => database.Add(17), Throws.InvalidOperationException);
        }

        [Test]
        public void CantRemoveElementFromEmptyDatabase()
        {
            Database.Database database = new Database.Database();

            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void CanRemoveElemntFromNonEmptyDatabase()
        {
            Database.Database database = new Database.Database(1, 2, 3);
            database.Remove();

            Assert.AreEqual(database.Count, 2);
        }

        [Test]
        [TestCase(1, 5, 5)]
        [TestCase(1, 7, 7)]
        [TestCase(1, 16, 16)]
        [TestCase(1, 1, 1)]
        public void ConstructorCanTakeUpTo16Elements(int start, int count, int reslut)
        {
            int[] numbers = Enumerable.Range(start, count).ToArray();
            Database.Database database = new Database.Database(numbers);

            Assert.AreEqual(database.Count, reslut);
        }
    }
}