namespace Tests
{
    using System;

    using Database;

    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(1, 2, 3);
        }
        [Test]
        public void TestArrayCapacity()
        {
            int result = this.database.Count;
            int expected = 3;

            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void ThrowingExceptionAfter16Element()
        {
            for (int i = this.database.Count; i < 16; i++)
            {
                this.database.Add(1);
            }
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.database.Add(1));
            Assert.That(ex.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void CorectlyAddingElements(int num)
        {
            this.database.Add(num);

            Assert.That(this.database.Count, Is.EqualTo(4));
        }

        [Test]
        public void ShouldThrowExceptionIfRemovingFromEmpty()
        {
            this.database.Remove();
            this.database.Remove();
            this.database.Remove();
            

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.database.Remove());
            Assert.That(ex.Message, Is.EqualTo("The collection is empty!"));
        }

        [Test]
        public void RemovingShouldWorkCorectly()
        {
            this.database.Remove();
            int expected = 2;

            Assert.That(this.database.Count, Is.EqualTo(expected));

        }

        [Test]
        public void FetchShouldReturnArray()
        {
            int[] arr = this.database.Fetch();


            Assert.That(arr.Length, Is.EqualTo(this.database.Count));
            Assert.That(arr, Is.InstanceOf(typeof(int[])));
        }
    }
}