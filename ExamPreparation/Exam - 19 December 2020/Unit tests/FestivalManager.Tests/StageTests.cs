// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void PerformersAreSetByTheConstructor()
	    {
			Stage stage = new Stage();
			Assert.AreEqual(0, stage.Performers.Count);
		}

		[Test]
		public void PerformerCanBeAdded()
        {
			Stage stage = new Stage();

			stage.AddPerformer(new Performer("Ivan", "Goshev", 33));
			Assert.AreEqual(1, stage.Performers.Count);

			stage.AddPerformer(new Performer("Gosho", "Ivanov", 29));
			Assert.AreEqual(2, stage.Performers.Count);

			stage.AddPerformer(new Performer("Pesho", "Todorov", 22));
			Assert.AreEqual(3, stage.Performers.Count);
		}
		
		[Test]
		public void PerformerAgeCantBeZero()
        {
			Stage stage = new Stage();
			stage.AddPerformer(new Performer("Ivan", "Goshev", 33));

			Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("Gosho", "Ivanov", 17)));
		}

		[Test]
		public void PerformerCantBeNull()
        {
			Stage stage = new Stage();
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));

		}

		

		[Test]
		public void SongCantBeNull()
        {
			Stage stage = new Stage();
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
		}

		[Test]
		public void SongCantBeShorterThenMinute()
        {
			Stage stage = new Stage();
			Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("song", TimeSpan.FromSeconds(30))));
		}

		[Test]
		public void SongCanBeAddedToArtist()
        {
			Stage stage = new Stage();
			Performer performer = new Performer("Ivan", "Goshev", 33);
			stage.AddPerformer(performer);
			stage.AddSong(new Song("Kuchek", TimeSpan.FromMinutes(2)));
			stage.AddSongToPerformer("Kuchek", "Ivan Goshev");

			Assert.AreEqual(1, performer.SongList.Count);
		}

		[Test]
		public void StageCanBePlayed()
        {
			Stage stage = new Stage();
			Performer performer = new Performer("Ivan", "Goshev", 33);
			stage.AddPerformer(performer);
			stage.AddSong(new Song("Kuchek", TimeSpan.FromMinutes(2)));
			stage.AddSongToPerformer("Kuchek", "Ivan Goshev");
			stage.AddPerformer(new Performer("Ivan", "Geshev", 22));
			stage.AddSong(new Song("Kuchek2.0", TimeSpan.FromMinutes(2)));
			stage.AddSongToPerformer("Kuchek2.0", "Ivan Geshev");

			Assert.AreEqual($"2 performers played 2 songs", stage.Play());
		}

		[Test]
		public void PerformerMayNotExist()
        {
			Stage stage = new Stage();
			stage.AddSong(new Song("Kuchek", TimeSpan.FromMinutes(2)));
			stage.AddPerformer(new Performer("Ivan", "Geshev", 22));

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("nqma pesen", "Ivan Geshev"));

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Kuchek", "Nikoi"));

		}
	}
}