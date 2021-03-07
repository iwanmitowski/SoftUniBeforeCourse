namespace INStock.Tests
{
    using System;
    using INStock.Contracts;
    using NUnit.Framework;

    [TestFixture]
    public class ProductTests
    {
        IProduct product;

        [SetUp]
        public void SetUp()
        {
            product = new Product("label", 2.50M, 3);
        }

        [Test]
        public void ConstructorSetsLabelCorectly()
        {
            string expected = "label";

            Assert.That(product.Label, Is.EqualTo(expected));
        }

        [Test]
        public void ConstructorSetsPriceCorectly()
        {
            decimal expected = 2.50M;

            Assert.That(product.Price, Is.EqualTo(expected));
        }

        [Test]
        public void ConstructorSetsQuantityCorectly()
        {
            int expected = 3;

            Assert.That(product.Quantity, Is.EqualTo(expected));
        }
       
        [Test]
        public void ComparisonIfEqualObjectsReturnTrue()
        {
           IProduct other = new Product("label", 2.50M, 3);
            int expected = 0;

            Assert.That(product.CompareTo(other),Is.EqualTo(expected));
        }
        [Test]
        public void ComparisonIfNotEqualObjectsReturnFalse()
        {
            IProduct other = new Product("Other label", 2.50M, 3);
            int notExpected = 0;

            Assert.That(product.CompareTo(other), Is.Not.EqualTo(notExpected));
        }
    }
}