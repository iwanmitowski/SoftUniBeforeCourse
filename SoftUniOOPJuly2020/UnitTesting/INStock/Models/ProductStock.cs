using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products = new List<IProduct>();
        public IProduct this[int index] { get => this.products[index]; set => this.products[index] = value; }

        public int Count => this.products.Count;

        public void Add(IProduct product)
        {
            this.products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            foreach (var item in products)
            {
                if (item.CompareTo(product) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.products.Count)
            {
                throw new IndexOutOfRangeException("Invalid Index!");
            }

            return this.products[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            decimal decPrice = Convert.ToDecimal(price);
            IEnumerable<IProduct> sorted = this.products.Where(x => x.Price == decPrice);

            return sorted;


        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {

            IEnumerable<IProduct> sorted = this.products.Where(x => x.Quantity == quantity);

            return sorted;
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            decimal loM = Convert.ToDecimal(lo);
            decimal hiM = Convert.ToDecimal(hi);
            IEnumerable<IProduct> sorted = this.products.Where(x => x.Price >= loM && x.Price <= hiM).OrderByDescending(x => x.Price);

            return sorted;
        }

        public IProduct FindByLabel(string label)
        {
            IProduct searched = this.products.FirstOrDefault(p => p.Label == label);
            if (searched == null)
            {
                throw new ArgumentException("There is no such product!");
            }
            return searched;
        }

        public IProduct FindMostExpensiveProduct()
        {
            IProduct theMostExpensiveProduct = this.products.OrderByDescending(x => x.Price).FirstOrDefault();

            return theMostExpensiveProduct;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var item in this.products)
            {
                yield return item;
            }
        }

        public bool Remove(IProduct product)
        {
            bool res = this.products.Contains(product);
            if (res)
            {
                this.products.Remove(product);
                return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
