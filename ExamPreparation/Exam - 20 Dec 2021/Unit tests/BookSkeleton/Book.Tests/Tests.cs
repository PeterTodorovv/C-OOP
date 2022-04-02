namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConstructorSetsBookNameAndAuthor()
        {
            string name = "GoT";
            string author = "Gosho";
            Book book = new Book(name, author);

            Assert.AreEqual(name, book.BookName);
            Assert.AreEqual(author, book.Author);
        }

        [Test]
        public void BookStartsWithZeroFootnotes()
        {
            Book book = new Book("GoT", "Gosho");

            Assert.AreEqual(0, book.FootnoteCount);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void BookNameCantBeNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() => new Book(name, "Gosho"));

        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void AuthorNameCantBeNullOrEmpty(string author)
        {
            Assert.Throws<ArgumentException>(() => new Book("CodeComplete", author));

        }

        [Test]
        public void UniqueFootnotesCanBeAdded()
        {
            Book book = new Book("GoT", "Gosho");
            book.AddFootnote(11, "note1");
            Assert.AreEqual(1, book.FootnoteCount);

            book.AddFootnote(1, "note2");
            Assert.AreEqual(2, book.FootnoteCount);

            book.AddFootnote(22, "note3");
            Assert.AreEqual(3, book.FootnoteCount);
        }

        [Test]
        public void TwoNotesCantHaveTheSameNumber()
        {
            Book book = new Book("GoT", "Gosho");
            book.AddFootnote(11, "note1");
            book.AddFootnote(1, "note2");
            book.AddFootnote(22, "note3");

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(11, "note1"));
        }

        [Test]
        public void CanFindNoteThatExists()
        {
            Book book = new Book("GoT", "Gosho");
            int noteNumber = 11;
            string noteText = "note1";
            book.AddFootnote(noteNumber, noteText);


            Assert.AreEqual($"Footnote #{noteNumber}: {noteText}", book.FindFootnote(noteNumber));
        }

        [Test]
        public void CantFindNoteThatDoesntExist()
        {
            Book book = new Book("GoT", "Gosho");
            book.AddFootnote(11, "note1");
            book.AddFootnote(1, "note2");
            book.AddFootnote(22, "note3");

            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(69));
        }

        [Test]
        public void FootnotesTextCanBeChanged()
        {
            Book book = new Book("GoT", "Gosho");
            book.AddFootnote(11, "note1");
            book.AddFootnote(1, "note2");
            book.AddFootnote(22, "note3");
            int noteNumber = 1;
            string newTxt = "AlteredNote";
            book.AlterFootnote(noteNumber, newTxt);
            Assert.AreEqual($"Footnote #{noteNumber}: {newTxt}", book.FindFootnote(1));
        }

        [Test]
        public void CantAlterFootnoteThatDoesntExist()
        {
            Book book = new Book("GoT", "Gosho");
            book.AddFootnote(11, "note1");
            book.AddFootnote(1, "note2");
            book.AddFootnote(22, "note3");

            int noteNumber = 69;
            string newTxt = "AlteredNote";
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(noteNumber, newTxt));
        }
    }
}