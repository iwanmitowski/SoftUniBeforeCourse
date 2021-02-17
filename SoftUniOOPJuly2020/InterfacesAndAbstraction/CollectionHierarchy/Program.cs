using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] input = Console.ReadLine().Split();

            List<int> addCollectionIndexes = new List<int>(input.Length);
            List<int> addRemoveCollectionIndexes = new List<int>(input.Length);
            List<int> myListIndexes = new List<int>(input.Length);

            List<string> addRemoveCollectionWords = new List<string>();
            List<string> myListWords = new List<string>();

            foreach (string word in input)
            {
                addCollectionIndexes.Add(addCollection.Add(word));
                addRemoveCollectionIndexes.Add(addRemoveCollection.Add(word));
                myListIndexes.Add(myList.Add(word));
            }

            int removeCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < removeCount; i++)
            {
                addRemoveCollectionWords.Add(addRemoveCollection.Remove());
                myListWords.Add(myList.Remove());
            }
            PrintResult(addCollectionIndexes);
            PrintResult(addRemoveCollectionIndexes);
            PrintResult(myListIndexes);
            PrintResult(addRemoveCollectionWords);
            PrintResult(myListWords);
            
        }
        static void PrintResult<T>(List<T> list)
        {
            Console.WriteLine(string.Join(" ",list));
        }
    }
}
