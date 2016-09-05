using System;
using System.Collections;
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
    public class Stack<T>: IEnumerable
    {
        IList<T> arr;
        public Stack()
        {
            arr = new List<T>();
        }

        public void Push(T item)
        {
            arr.Add(item);
        }

        public void Pop()
        {
            var N = arr.Count();
            if(N == 0)
            {
                throw new InvalidOperationException();
            }
            arr.RemoveAt(N - 1);
        }

        public T Top()
        {
            return arr.Last();
        }

        public int Size()
        {
            return arr.Count();
        }

        public IEnumerator GetEnumerator()
        {
            for(var i = 0; i < arr.Count(); i++)
            {
                yield return arr[i];
            }
        }
    }
}
