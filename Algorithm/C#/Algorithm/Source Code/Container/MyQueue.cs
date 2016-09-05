using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Algorithm.Source_Code.Chapter1
{
    public class MyQueue<T>
    {
        private LinkedListNode head;
        private LinkedListNode tail;
        private int size;

        public MyQueue()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public void Enqueue(T item)
        {
            var node = new LinkedListNode(item);

            if (size == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.next = node;
                tail = node;
            }
            size++;
        }

        public T Dequeue()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }
            size--;
            var ret = head.val;
            head = head.next;
            return ret;
        }

        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        private class LinkedListNode
        {
            public T val;
            public LinkedListNode next;

            public LinkedListNode(T val)
            {
                this.val = val;
                next = null;
            }
        }
    }
}
