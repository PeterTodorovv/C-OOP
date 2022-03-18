using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanAddUniqueUsers()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new ExtendedDatabase.Person(22, "Peter"));
            database.Add(new ExtendedDatabase.Person(13, "Gosho"));
            database.Add(new ExtendedDatabase.Person(10, "Ivan"));

            Assert.AreEqual(3, database.Count);
        }

        [Test]
        public void TwoUsersCantHaveTheSameUsername()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new ExtendedDatabase.Person(22, "Peter"));
            Assert.Throws<InvalidOperationException>(() => database.Add(new ExtendedDatabase.Person(33, "Peter")));

        }

        [Test]
        public void TwoUsersCantHaveTheSameID()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new ExtendedDatabase.Person(22, "George"));
            Assert.Throws<InvalidOperationException>(() => database.Add(new ExtendedDatabase.Person(22, "Peter")));

        }

        [Test]
        public void CantAdd17thPerson()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();

            for(int i = 0; i < 16; i++)
            {
                database.Add(new ExtendedDatabase.Person(i, "gosho" + i));
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(new ExtendedDatabase.Person(17, "Ivan")));
        }

        [Test]
        public void CanRemoveElemntIfTheCountIsntZero()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new ExtendedDatabase.Person(22, "Peter"));
            database.Add(new ExtendedDatabase.Person(13, "Gosho"));
            database.Add(new ExtendedDatabase.Person(10, "Ivan"));

            database.Remove();
            database.Remove();

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void CantReamoveElementIfCountIsZero()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => database.Remove());

        }

        [Test]
        public void CantFindUsernameThatDoesntExist()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Gosho"));
        }

        [Test]
        public void UserNameParameterCantBeNull()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));

        }

        [Test]
        public void ArgumentsMustBeCaseSensitive()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new ExtendedDatabase.Person(11, "Gosho"));

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("gosho"));
        }

        [Test]
        public void CantFindIdThatDoesntExist()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => database.FindById(11));
        }

        [Test]
        public void IdCantBeNegative()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-11));

        }

    }
}