namespace Tests
{
    using System;

    using ExtendedDatabase;

    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private ExtendedDatabase database;
        private Person person;
        [SetUp]
        public void Setup()
        {
            Person[] people = new Person[]
            {
                person = new Person(1,"Ivan"),
                person = new Person(2,"Gosho"),
                person = new Person(3,"Pesho1"),
                person = new Person(4,"Pesho2"),
                person = new Person(5,"Pesho3"),
                person = new Person(6,"Pesho4"),
                person = new Person(7,"Pesho5"),
                person = new Person(8,"Pesho6"),
                person = new Person(9,"Pesho7"),
                person = new Person(10,"Pesho8"),
                person = new Person(11,"Pesho9"),

            };

            this.database = new ExtendedDatabase(people);
        }
        [Test]
        public void TestArrayCapacity()
        {
            int result = this.database.Count;
            int expected = 11;

            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void ThrowingExceptionAfter16Element()
        {

            this.database.Add(new Person(12, "Jivko1"));
            this.database.Add(new Person(13, "Jivko2"));
            this.database.Add(new Person(14, "Jivko3"));
            this.database.Add(new Person(15, "Jivko4"));
            this.database.Add(new Person(16, "Jivko5"));

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(17, "Greshka")));
            Assert.That(ex.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void CorectlyAddingElements()
        {
            Person person = new Person(12, "Jivk0");
            this.database.Add(person);

            int expected = 12;
            int result = this.database.Count;

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldThrowExceptionIfRemovingFromEmpty()
        {
            ExtendedDatabase newDb = new ExtendedDatabase();


            Assert.Throws<InvalidOperationException>(() => newDb.Remove());

        }

        [Test]
        public void RemovingShouldWorkCorectly()
        {
            this.database.Remove();
            int expected = 10;

            Assert.That(this.database.Count, Is.EqualTo(expected));

        }
        [Test]
        public void AddExistingUserName()
        {
            Person person = new Person(12, "Ivan");
            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));

        }
        [Test]
        public void AddExistingId()
        {
            Person person = new Person(1, "Ivan123");
            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));

        }

        [TestCase("")]
        [TestCase(null)]
        public void IfUserNameIsNullArgumentExceptionThrown(string userName)
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(userName));
        }


        [TestCase("Ivan123")]
        [TestCase("Ivan1234")]
        public void NoPresentUsernameInvalidOperationThrownIfUserNameIsNull(string userName)
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(userName));
        }

        [Test]
        public void CaseSensitivityTest()
        {
            string notExpected ="ivAN";
            string name = this.database.FindByUsername("Ivan").UserName;

            Assert.That(notExpected, Is.Not.EqualTo(name));
        }

        
       
        [TestCase(-1)]
        public void IfIdIsNegativeArgumentExceptionThrown(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(id));
        }

        [Test]
        public void IfNoValidPersonInvalidOperationExceptionThrown()
        {
            long id = 123;

            Assert.Throws<InvalidOperationException>(() => this.database.FindById(id));
        }
    }
}