using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy
{
    class AddRemoveCollection : IAdd, IRemove
    {
        private List<string> addRemoveCollection;
        public AddRemoveCollection()
        {
            this.addRemoveCollection = new List<string>();
        }
        public int Add(string text)
        {
            addRemoveCollection.Insert(0, text);
            return 0;
        }

        public string Remove()
        {
            string elementToRemove = addRemoveCollection.Last();
            this.addRemoveCollection.Remove(elementToRemove);
            return elementToRemove;
        }
    }
}
