using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Numerics;
using System.Collections;


namespace HomeWork1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 9);

            int[] array = new int[1000];
            CreateArray(array);

            OutputDataArray(array, Algorithm.GnomeSort, "GnomeSort");
           // OutputDataArray(array, Algorithm.Sort, "HeapSort");
           // OutputDataArray(array, Algorithm.CombSort, "CombSort");
           // OutputDataFunction(num, Algorithm.Factorial, "Factorial");
        }
        public static void CreateArray(int[] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < 200; i++)
            {
                array[i] = rnd.Next(1, 9);
            }
        }
        static void OutputDataFunction(int num, Action<int,int> f, string nameAction)
        {
            List<int> time = new List<int>();

            using (StreamWriter file = new StreamWriter("Time.txt", true))
            {
                file.Write($"{nameAction};;");

                for (int j = 0; j < 200; j++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        FindTime(num, f, time, j);
                    }
                    int average = FindAverage(time);

                    file.Write($"{average};");
                    time.Clear();
                }

                file.WriteLine();
                file.Close();
            }
        }

        static void OutputDataArray(int[] arr, Action<int[], int> f, string nameAction)
        {
            List<int> time = new List<int>();

            using (StreamWriter file = new StreamWriter("Time.txt", true))
            {
                file.Write($"{nameAction};;");

                for (int j = 0; j < 1000; j++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        FindTimeArr(arr, f, time, j);
                    }
                    int average = FindAverage(time);

                    file.Write($"{average};");
                    time.Clear();
                }

                file.WriteLine();
                file.Close();
            }
        }

        public static void FindTime(int num, Action<int, int> f, List<int> time, int count)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            f(num,count);
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}", ts.Ticks);
            Console.WriteLine(elapsedTime);

            time.Add(Convert.ToInt32(elapsedTime));
        }

        public static void FindTimeArr(int[] arr, Action<int[], int> f, List<int> time, int count)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            f(arr, count);
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}", ts.Ticks);
            Console.WriteLine(elapsedTime);

            time.Add(Convert.ToInt32(elapsedTime));
        }
        static int FindAverage(List<int> time)
        {
            int sum = 0;
            for (int i = 0; i < time.Count; i++)
            {
                sum += time[i];
            }
            return sum / time.Count;
        }

        
    }
}
