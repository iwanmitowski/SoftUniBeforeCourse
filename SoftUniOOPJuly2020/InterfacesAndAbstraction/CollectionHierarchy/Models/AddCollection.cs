using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    class AddCollection : IAdd
    {
        private List<string> addCollection;
        
        public AddCollection()
        {
            this.addCollection = new List<string>();
        }
        public int Add(string text)
        {
            addCollection.Add(text);
            return addCollection.Count - 1;
        }
    }
}
