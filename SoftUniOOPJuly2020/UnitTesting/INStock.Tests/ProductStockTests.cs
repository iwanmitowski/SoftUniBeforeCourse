namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        IProductStock stock;
        IProduct product;
        IProduct otherProduct;
        IProductStock emptyStock;
        [SetUp]
        public void SetUp()
        {
            product = new Product("label", 1.5M, 2);
            otherProduct = new Product("asd", 4.5M, 2);
            stock = new ProductStock() { product, otherProduct };
            emptyStock = new ProductStock();

        }
        [Test]
        public void CountReturningMustWorkCorectly()
        {
            int expectedCount = 2;

            Assert.That(stock.Count, Is.EqualTo(expectedCount));
        }
        [Test]
        public void AddMustWorkCorectly()
        {
            IProduct product = new Product("label4", 2.5M, 2);
            int expectedCount = 3;

            this.stock.Add(product);

            Assert.That(this.stock.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void ContainsMustReturnTrueIfContainingProdcut()
        {
            Assert.IsTrue(stock.Contains(product));
        }

        [Test]
        public void ContainsMustReturnFalseIfNotContainingProdcut()
        {
            stock = new ProductStock() { product };

            Assert.IsFalse(stock.Contains(otherProduct));
        }

        [Test]
        public void FindMustReturnExpectedProduct()
        {

            Assert.That(stock.Find(0), Is.EqualTo(product));
        }

        [Test]
        public void FindMustThrowExceptionIfInvalidIndex()
        {

            Assert.Throws<IndexOutOfRangeException>(() => stock.Find(3));
        }

        [Test]
        public void ReturningByLabelWorksAsExpected()
        {
            string expectedLabel = "label";

            Assert.That(stock.FindByLabel("label").Label, Is.EqualTo(expectedLabel));
        }

        [Test]
        public void ReturningByLabelThrowsExceptionIfNotExistingLabel()
        {
            Assert.Throws<ArgumentException>(() => stock.FindByLabel("qwerty"));

        }

        [Test]
        public void FindAllInPriceRangeMustReturnCollection()
        {
            Assert.AreEqual(stock.FindAllInRange(1.5, 4.5), stock.OrderByDescending(p => p.Price));
        }

        [Test]
        public void FindAllInPriceRangeMustReturnEmptyCollection()
        {

            Assert.AreEqual(stock.FindAllInRange(2.5, 3.5), emptyStock);
        }

        [Test]
        public void FindAllByPriceShouldReturnCorectly()
        {
            double price = 2.5;
            Assert.AreEqual(stock.FindAllByPrice(price), stock.Where(p => p.Price == Convert.ToDecimal(price)));

        }

        [Test]
        public void FindAllByPriceShouldReturnEmptyCollection()
        {
            double price = 5.5;

            Assert.AreEqual(stock.FindAllByPrice(price), emptyStock);

        }

        [Test]
        public void FindMostExpensiveShouldWorkCorectly()
        {
            IProduct theMostExpensiveProduct = stock.OrderByDescending(x => x.Price).FirstOrDefault();

            Assert.AreEqual(stock.FindMostExpensiveProduct(), theMostExpensiveProduct);
        }

        [Test]
        public void FindAllByQuantityShouldReturnCorectly()
        {
            int quantity = 2;
            Assert.AreEqual(stock.FindAllByQuantity(quantity), stock.Where(p => p.Quantity == quantity));

        }

        [Test]
        public void FindAllByQuantityShouldReturnEmptyCollection()
        {
            int quantity = 3;
           
            Assert.AreEqual(stock.FindAllByQuantity(quantity), emptyStock);

        }

        [Test]
        public void RemoveShouldReturnTrueIfItemIsRemovedCorectly()
        {
            IProduct productToRemove = product = new Product("asd", 4.5M, 2);

            Assert.IsTrue(stock.Remove(productToRemove));
        }
        [Test]
        public void RemoveShouldReturnFalseIfItemIsMissingCorectly()
        {
            IProduct productToRemove = product = new Product("label", 1.70M, 2);

            Assert.IsFalse(stock.Remove(productToRemove));
        }
    }
}
