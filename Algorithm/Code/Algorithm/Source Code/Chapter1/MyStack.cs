using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Algorithm.Source_Code.Chapter1
{
    //public class MyStack<T>: IEnumerable
    //{
    //    private LinkedListNode head = null;
    
    //    public void Push(T item)
    //    {
    //        var node = new LinkedListNode(item);
    //        node.next = head;
    //        head = node;
    //    }

    //    public T Pop()
    //    {
    //        if (IsEmpty())
    //        {
    //            throw new InvalidOperationException();
    //        }
    //        var ret = head.val;
    //        head = head.next;
    //        return ret;
    //    }

    //    public bool IsEmpty()
    //    {
    //        return head == null;
    //    }

    //    public int Size()
    //    {
    //        var node = head;
    //        var count = 0;

    //        while (node != null)
    //        {
    //            node = node.next;
    //            count++;
    //        }
    //        return count;
    //    }

    //    public IEnumerator GetEnumerator()
    //    {
    //        var node = head;

    //        while (node != null)
    //        {
    //            yield return node.val;
    //            node = node.next;
    //        }
    //    }

    //    private class LinkedListNode
    //    {
    //        public T val;
    //        public LinkedListNode next;

    //        public LinkedListNode(T val)
    //        {
    //            this.val = val;
    //            next = null;
    //        }
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        try
    //        {
    //            var file = new StreamReader("../../Data/Chapter1/test_stack.txt");
    //            var str = file.ReadLine();
    //            var stack = new MyStack<string>();

    //            while (str != "")
    //            {
    //                if (str == "-")
    //                {
    //                    Console.WriteLine(stack.Pop());
    //                }
    //                else
    //                {
    //                    stack.Push(str);
    //                }
    //                str = file.ReadLine();
    //            }
    //            foreach (var item in stack)
    //            {
    //                Console.WriteLine(item);
    //            }
    //            Console.ReadKey();
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine("This file could not be read.");
    //            Console.WriteLine(e.Message);
    //        }
    //    }
    //}

    /// <summary>
    /// stack implemented using linked list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyStack<T>: IEnumerable
    {
        private LinkedListNode head;
        private int count;

        public MyStack()
        {
            head = null;
            count = 0;
        }

        public void Push(T item)
        {
            var node = new LinkedListNode(item);

            node.next = head;
            head = node;
            count++;
        }

        public T Pop()
        {
            // use IsEmpty() instead of private field count for isolation between interface and implementation.
            if (this.IsEmpty())
            {
                throw new InvalidOperationException();
            }
            var ret = head.value;

            head = head.next;
            count--;
            return ret;
        }

        public int Size()
        {
            return count;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public IEnumerator GetEnumerator()
        {
            var node = head;

            while (node != null)
            {
                yield return node.value;
                node = node.next;
            }
        }

        private class LinkedListNode
        {
            public T value;
            public LinkedListNode next;

            public LinkedListNode(T value)
            {
                this.value = value;
                next = null;
            }
        }
    }
}
