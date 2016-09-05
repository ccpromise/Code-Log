using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter2
{
    /// <summary>
    /// A class has different sort standard.
    /// you can declare inner class which implement IComparer<T>, create a object of it.
    /// Or you can declare inner function which is Comparision<T>, create a delegate variable.
    /// the usage of Array.Sort(T[] arr, Icomparer<T> compare)
    /// the member should be static since it does not belong to any instance.
    /// </summary>
    public class Student
    {
        private string name;
        private int id;

        public string Name { get { return name; } }
        public int Id { get { return id; } }
        public static IComparer<Student> byName = new ByName();  // interface: any class implement this interface can be assigned
        public static IComparer<Student> byId = new ById();
        public static Comparison<Student> _byName = _ByName; // delegate: a static function
        public static Comparison<Student> _byId = _ById;

        private class ByName : IComparer<Student>
        {
            public int Compare(Student a, Student b)
            {
                return string.Compare(a.Name, b.Name);
            }
        }
        private class ById : IComparer<Student>
        {
            public int Compare(Student a, Student b)
            {
                return a.Id - b.Id;
            }
        }

        private static int _ByName(Student a, Student b)
        {
            return string.Compare(a.Name, b.Name);
        }
        private static int _ById(Student a, Student b)
        {
            return a.Id - b.Id;
        }
    }

    class ClientTest
    {
        public static void Test()
        {
            var students = new Student[10];
            Array.Sort(students, Student.byId);
            Array.Sort(students, Student.byName);
            Array.Sort(students, Student._byId);
            Array.Sort(students, Student._byName);
        }
    }
}
