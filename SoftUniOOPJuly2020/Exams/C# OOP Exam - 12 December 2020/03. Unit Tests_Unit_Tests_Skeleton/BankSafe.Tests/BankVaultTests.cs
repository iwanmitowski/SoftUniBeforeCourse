using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        BankVault bankVault;
        Item item;
        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("Ivan", "ID12");
        }

        [Test]
        public void ConstructorShouldBeSetCorectly()
        {
            Assert.IsNotNull(bankVault);
        }

        [Test]
        public void AddingItemAddsCorectly()
        {
            string cell = "C4";
            bankVault.AddItem(cell, item);

            Assert.IsNotNull(bankVault.VaultCells[cell]);
        }

        [Test]
        public void AddingItemThrowsExceptionIfCellDoesntExist()
        {
            string cell = "C5";

            Assert.Throws<ArgumentException>(() => bankVault.AddItem(cell, item));
        }

        [Test]
        public void AddingItemThrowsExceptionIfCellIsTaken()
        {
            string cell = "C4";
            Item item2 = new Item("Gosho", "Pesho");
            bankVault.AddItem(cell, item2);

            Assert.Throws<ArgumentException>(() => bankVault.AddItem(cell, item));
        }

        [Test]
        public void AddingItemThrowsExceptionIfItemExistInThis()
        {
            string cell = "C4";
            string cell2 = "C3";
            Item item2 = new Item("Gosho", "Pesho");
            bankVault.AddItem(cell2, item2);

            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem(cell, item2));
        }

        [Test]
        public void RemovingWorksCorectly()
        {
            string cell = "C4";
            bankVault.AddItem(cell, item);
            bankVault.RemoveItem(cell, item);

            Assert.IsNull(this.bankVault.VaultCells[cell]);
        }

        [Test]
        public void RemovingThrowsExceptionIfCellDoesntExist()
        {
            string cell = "C5";
            
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem(cell, item));

        }

        [Test]
        public void RemovingThrowsExceptionIfItemDoesntExist()
        {
            string cell = "C5";
            Item item2 = new Item("Gosho", "Pesho");

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem(cell, item2));

        }
    }
}