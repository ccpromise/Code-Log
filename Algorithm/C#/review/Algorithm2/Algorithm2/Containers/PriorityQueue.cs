using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// How to design class:
/// 1\ Design API first.
/// 2\ Decide the data structure you use to represent data.
/// 3\ Method as member of class.
/// </summary>
namespace Algorithm2.Containers
{
    /// <summary>
    /// 1\ Design template class
    /// 2\ General usage by passing a comparator.
    /// 3\ Outline your whole process first and add details after. Abstract your method by private function.
    /// 
    /// complexity:
    /// push/pop: O(lgN)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T>
    {
        IList<T> arr;
        Comparison<T> comparator;
        public PriorityQueue(Comparison<T> comparator)
        {
            arr = new List<T>();
            this.comparator = comparator;
        }

        public void Push(T item)
        {
            arr.Add(item);
            Swim(arr.Count() - 1);
        }

        public T Front()
        {
            if(arr.Count() == 0)
            {
                throw new InvalidOperationException();
            }
            return arr[0];
        }

        public void Pop()
        {
            var N = arr.Count();
            if (N == 0)
            {
                throw new InvalidOperationException();
            }
            Swap(0, N - 1);
            arr.RemoveAt(N - 1);
            Sink(0);
        }

        public int Size()
        {
            return arr.Count();
        }
    }
}
