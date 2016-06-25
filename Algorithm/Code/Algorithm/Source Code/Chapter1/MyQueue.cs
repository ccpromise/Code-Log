using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Algorithm.Source_Code.Chapter1
{
    //public class MyQueue<T>
    //{
    //    private LinkedListNode head = null;
    //    private LinkedListNode tail = null;
    //    private int size = 0;

    //    public MyQueue()
    //    { }

    //    public void Enqueue(T item)
    //    {
    //        var node = new LinkedListNode(item);

    //        if (tail == null)
    //        {
    //            head = node;
    //            tail = node;
    //        }
    //        else
    //        {
    //            tail.next = node;
    //            tail = node;
    //        }
    //        size++;
    //    }

    //    public T Dequeue()
    //    {
    //        if (head == null)
    //        {
    //            throw new InvalidOperationException();
    //        }
    //        size--;
    //        var ret = head.val;
    //        head = head.next;
    //        return ret;
    //    }

    //    public int Size()
    //    {
    //        return size;
    //    }

    //    public bool IsEmpty()
    //    {
    //        return size == 0;
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
    //            var file = new StreamReader("../../Data/Chapter1/test_queue.txt");
    //            var str = file.ReadLine();
    //            var queue = new MyQueue<string>();

    //            while (str != "")
    //            {
    //                if (str == "-")
    //                {
    //                    Console.WriteLine(queue.Dequeue());
    //                }
    //                else
    //                {
    //                    queue.Enqueue(str);
    //                }
    //                str = file.ReadLine();
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
    /// implement using linked list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyQueue<T>
    {
        private LinkedListNode head;
        private LinkedListNode tail;
        private int count;

        public MyQueue()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Enqueue(T item)
        {
            var node = new LinkedListNode(item);

            if (head == null)
            {
                head = node;
                tail = node;
                tail.next = null;
            }
            else
            { 
                
            }
        }

        public T Dequeue()
        { }

        public int Size()
        { }

        public bool IsEmpty
        { }

        private class LinkedListNode
        {
            public T val;
            public LinkedListNode next;

            public LinkedListNode(T value)
            {
                val = value;
                next = null;
            }
        }
    }
}
