using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Source_Code.Chapter2
{
    class Application
    {   
        private class Point
        {
            public double x;
            public double y;
            public static Comparison<Point> _byY = SortByY;
            public Comparison<Point> _byAngle()
            {
                return SortByAngle;
            }

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public double Angle(Point other)
            {
                return Math.Atan2(other.y - this.y, other.x - this.x);
            }

            /// <summary>
            /// The usage of Array.Sort(T[] arr, Comparison<T> compare)
            /// You can define the Comparison<T> inside the Point class and make it a static memeber.
            /// </summary>
            /// <param name="points"></param>
            /// <returns></returns>
            public static IList<Point> ConvexHull(Point[] points)
            {
                Array.Sort(points, Point._byY);
                Array.Sort(points, points[0]._byAngle());

                var s = new Stack<Point>();
                s.Push(points[0]);
                s.Push(points[1]);

                for(var i = 2; i<points.Length;i++)
                {
                    var top = s.Pop();

                    while(!CCW(top, s.Peek(), points[i]))
                    {
                        top = s.Pop();
                    }
                    s.Push(top);
                    s.Push(points[i]);
                }
                var ret = new List<Point>();
                while(s.Count!=0)
                {
                    ret.Add(s.Pop());
                }
                return ret;
            }

            private static bool CCW(Point a, Point b, Point c)
            {
                return (c.y - b.y) * (c.x - b.x) - (c.x - b.x) * (c.y - a.y) > 0;
            }
            private static int SortByY(Point a, Point b)
            {
                var ret = a.y - b.y;
                if (ret > 0)
                {
                    return 1;
                }
                if (ret < 0)
                {
                    return -1;
                }
                return 0;
            }      

            private int SortByAngle(Point a, Point b)
            {
                var ret = this.Angle(a) - this.Angle(b);

                if(ret>0)
                {
                    return 1;
                }
                if(ret<0)
                {
                    return -1;
                }
                return 0;
            }

            private static void Swap(IComparable[] arr, int i, int j)
            {
                var tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
            }
        }
        
    }
}
