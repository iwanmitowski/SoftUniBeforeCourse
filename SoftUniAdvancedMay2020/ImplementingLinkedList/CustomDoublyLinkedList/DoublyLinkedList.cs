using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    class DoublyLinkedList
    {
        private ListNode head;
        private ListNode tail;
        public int Count { get; set; }

        public void AddFirst(int value)
        {
            if (this.Count==0)
            {
                this.head = this.tail = new ListNode(value);
            }
            else
            {
                var newHead = new ListNode(value);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }
            this.Count++;
        }

        public void AddLast(int value)
        {
            if (this.Count==0)
            {
                this.head = this.tail = new ListNode(value);
            }
            else
            {
                var newTail = new ListNode(value);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
                
            }
            this.Count++;
        }
        public int RemoveFirst()
        {
            if (this.Count==0)
            {
                throw new InvalidOperationException("The list is empty");

            }

            var firstElement = this.head.Value;
            this.head = this.head.NextNode;
            if (this.head!=null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }
            this.Count--;
            return firstElement;
        }

        public int RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");

            }
            var lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;
            if (this.tail==null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.head = null;
            }
            this.Count--;
            return lastElement;
        }

        public void ForEach(Action<int> action)
        {
            var currNode = this.head;
            while (currNode != null)
            {
                action(currNode.Value);
                currNode = currNode.NextNode;
            }
        }

        
    }
}
