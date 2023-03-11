using System;
using System.Diagnostics;


namespace Algorithms_BinarySearchTree
{
    public class timeTest
    {
        public void Test(func f,  string funcName, bool Ordered,int maxN)
        {
            Console.WriteLine($" ");
            Console.WriteLine($" ");

            Stopwatch clock = new Stopwatch();

            int count = 0;


            clock.Start();

            Random r = new Random();
            for (int i = 0; i < maxN; i++)
            {
                // our action
                if (Ordered==false)
                    f(r.Next(0, maxN));
                else
                    f(i);
            }


            Console.Write($" до {maxN}  {funcName}: {count}");
            clock.Stop();



            TimeSpan ts = clock.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine($"{elapsedTime} ");

        }

        public delegate void func(int n);


    }
}
