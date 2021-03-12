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
        Stage stage;
        Performer performer;
        Song song;
        TimeSpan ts = new TimeSpan(0, 3, 50);
        [SetUp]
        public void SetUp()
        {
            stage = new Stage();
            performer = new Performer("Ivan", "Ivanov", 20);
            song = new Song("Hop", ts);
        }
        [Test]
        public void ConstructorShouldWorksCorectly()
        {
            Assert.IsNotNull(stage);
        }
        [Test]
        public void AddingPerformerShouldWorkCorectly()
        {
            stage.AddPerformer(performer);

            int expectedCount = 1;

            Assert.That(expectedCount, Is.EqualTo(this.stage.Performers.Count));
        }
        [Test]
        public void AddingUnderAgePerformerThrowsException()
        {
            performer = new Performer("asd", "asd", 17);
            Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(performer));
        }
        [Test]
        public void AddingNullPerformerShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(null));

        }
        [Test]
        public void AddingNullSongShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(null));

        }

        [Test]
        public void AddingShortSongShouldThrowException()
        {
            TimeSpan ts1 = new TimeSpan(0, 0, 0);
            Assert.Throws<ArgumentException>(() => this.stage.AddSong(new Song("asd", ts1)));

        }

        [Test]
        public void AddingSongToPerformerShouldReturnCorectAnswer()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            string expected = "Hop (03:50) will be performed by Ivan Ivanov";

            Assert.AreEqual(expected, stage.AddSongToPerformer("Hop", "Ivan Ivanov"));

        }
        [Test]
        public void PlayWillReturnCorrectOutput()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer(song.Name, performer.FullName);

            string expected = "1 performers played 1 songs";

            Assert.AreEqual(expected, stage.Play());
        }

    }
}