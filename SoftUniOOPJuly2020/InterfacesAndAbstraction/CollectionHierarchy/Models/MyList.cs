using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    class MyList: IAdd,IRemove
    {
        private List<string> myList;
        public MyList()
        {
            myList = new List<string>();
        }

        public int Used => myList.Count;
        public int Add(string text)
        {
            myList.Insert(0, text);
            return 0;
        }

        public string Remove()
        {
            string elementToRemove = myList[0];
            this.myList.RemoveAt(0);
            return elementToRemove;
        }
    }
}
