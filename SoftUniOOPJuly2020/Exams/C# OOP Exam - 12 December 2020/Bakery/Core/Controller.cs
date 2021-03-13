using Bakery.Core.Factories;
using Bakery.Core.Factory;
using Bakery.Core.Factory.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core.Contracts
{
    class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods = new List<IBakedFood>();
        private readonly List<IDrink> drinks = new List<IDrink>();
        private readonly List<ITable> tables = new List<ITable>();

        private readonly IDrinkFactory drinkFactory;
        private readonly IFoodFactory foodFactory;
        private readonly ITableFactory tableFactory;

        private decimal totalIncome;
        public Controller()
        {
            drinkFactory = new DrinkFactory();
            foodFactory = new FoodFactory();
            tableFactory = new TableFactory();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink currentDrink = drinkFactory.CreateDrink(type, name, portion, brand);

            drinks.Add(currentDrink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood currentFood = foodFactory.CreateFood(type, name, price);

            bakedFoods.Add(currentFood);

            return string.Format(OutputMessages.FoodAdded, name, type);

        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = tableFactory.CreateTable(type, tableNumber, capacity);

            tables.Add(table);

            return string.Format(OutputMessages.TableAdded, tableNumber);

        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in tables.Where(x => x.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable currentTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (currentTable == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            decimal tableBill = currentTable.GetBill();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {tableBill:f2}");

            this.totalIncome += tableBill;

            currentTable.Clear();

            return sb.ToString().Trim();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable currentTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IDrink currentDrink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (currentTable == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (currentDrink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            currentTable.OrderDrink(currentDrink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable currentTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IBakedFood currentFood = bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (currentTable == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (currentFood == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            currentTable.OrderFood(currentFood);

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);

        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable freeTable = tables.FirstOrDefault(x => x.IsReserved == false);

            if (freeTable == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            freeTable.Reserve(numberOfPeople);

            return string.Format(OutputMessages.TableReserved, freeTable.TableNumber, numberOfPeople);
        }
    }
}
