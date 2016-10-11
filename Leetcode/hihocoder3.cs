using System.Collections.Generic;
using System;
using System.Linq;

public class Program
{
    static int Main()
    {
        var tokens = Console.ReadLine().Split();
        var N = Convert.ToInt32(tokens[0]); // N students
        var M = Convert.ToInt32(tokens[1]); // M offices
        var K = Convert.ToInt32(tokens[2]); // K unit time
        //var students = new Student[N];
        //var offices = new Office[M];
        var offices = new int[M];// offices[i]: the available time of office i.
        var pq = new PriorityQueue<Student>();
        var ret = new int[N];
        var n = 0;
        while (n < N)
        {
            tokens = Console.ReadLine().Split();
            var stu = new Student(Convert.ToInt32(tokens[0]), n, Convert.ToInt32(tokens[1]) + K);
            var m = Convert.ToInt32(tokens[2]);
            stu.office_to_visit = new int[m];
            stu.duration_in_office = new int[m];
            for (var i = 0; i < m; i++)
            {
                stu.office_to_visit[i] = Convert.ToInt32(tokens[3 + 2 * i]) - 1;
                stu.duration_in_office[i] = Convert.ToInt32(tokens[4 + 2 * i]);
            }
            pq.Push(stu);
            n++;
        }
        while (pq.Count() != 0)
        {
            var stu = pq.DelMin();
            var off = stu.office_to_visit[stu.next_office_idx];
            var dur = stu.duration_in_office[stu.next_office_idx];
            stu.total_time = Math.Max(offices[off], stu.total_time) + dur;
            offices[off] = stu.total_time;
            stu.next_office_idx++;
            if (stu.next_office_idx < stu.office_to_visit.Count())
            {
                stu.total_time += K;
                pq.Push(stu);
            }
            else {
                ret[stu.idx] = stu.total_time;
            }
        }
        foreach (var time in ret)
            Console.WriteLine(time);
        return 0;
    }
}

public class Student : IComparable<Student>
{
    public int id;
    public int idx;
    public int[] office_to_visit;
    public int[] duration_in_office;
    public int next_office_idx;
    public int total_time;

    public Student(int id, int idx, int arrive_time)
    {
        this.id = id;
        this.idx = idx;
        this.total_time = arrive_time;
    }
    public int CompareTo(Student other)
    {
        if (this.total_time == other.total_time) return this.id - other.id;
        return this.total_time - other.total_time;
    }
}
public class PriorityQueue<T> where T : IComparable<T>
{
    private IList<T> data;

    public PriorityQueue()
    {
        data = new List<T>();
    }
    public void Push(T item)
    {
        data.Add(item);
        Swim(data.Count() - 1);
    }
    public T DelMin()
    {
        var ret = data[0];
        data[0] = data.Last();
        data.RemoveAt(data.Count() - 1);
        if (data.Count() != 0)
            Sink(0);
        return ret;
    }

    public int Count()
    {
        return data.Count();
    }
    private void Swim(int i)
    {
        int parent = (i - 1) / 2;
        while (parent >= 0 && data[i].CompareTo(data[parent]) < 0)
        {
            Swap(i, parent);
            i = parent;
            parent = (i - 1) / 2;
        }
    }
    private void Sink(int i)
    {
        int child = i * 2 + 1;
        while (child < data.Count())
        {
            var min_child = child;
            if (i * 2 + 2 < data.Count() && data[i * 2 + 2].CompareTo(data[i * 2 + 1]) < 0)
                min_child = i * 2 + 2;
            if (data[i].CompareTo(data[min_child]) < 0)
                break;
            Swap(i, min_child);
            i = min_child;
            child = i * 2 + 1;
        }
    }

    private void Swap(int i, int j)
    {
        var tmp = data[i];
        data[i] = data[j];
        data[j] = tmp;
    }
}