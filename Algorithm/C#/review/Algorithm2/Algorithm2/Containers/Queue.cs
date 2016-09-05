using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm2.Containers
{
    /// <summary>
    /// Design template class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T>
    {
        private ListNode head, tail;
        private int size;
        public Queue()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public void Push(T item)
        {
            var node = new ListNode(item);

            if(size == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.next = node;
            }
            size++;
        }

        public void Pop()
        {
            if(size == 0)
            {
                throw new InvalidOperationException();
            }
            head = head.next;
            size--;
        }

        public T Front()
        {
            if(size == 0)
            {
                throw new InvalidOperationException();
            }
            return head.val;
        }

        public int Size()
        {
            return size;
        }

        private class ListNode
        {
            public T val;
            public ListNode next;
            public ListNode(T val)
            {
                this.val = val;
                this.next = null;
            }
        }
    }
}
