using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using FloydWarshallAlgoritm.Sort;

namespace FloydWarshallAlgoritm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10000];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
            }
            ISort<int> s = new BubbleSort<int>();
            DateTime dt = DateTime.Now;
            arr = s.Sorting(arr);
            Console.WriteLine("Time for BubbleSort is {0}.", DateTime.Now - dt);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
            }
            dt = DateTime.Now;
            s = new CocktailSort<int>();
            arr = s.Sorting(arr);
            Console.WriteLine("Time for CocktailSort is {0}.", DateTime.Now - dt);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
            }
            dt = DateTime.Now;
            s = new EvenOddSort<int>();
            arr = s.Sorting(arr);
            Console.WriteLine("Time for EvenOddSort is {0}.", DateTime.Now - dt);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
            }
            dt = DateTime.Now;
            s = new CombSort<int>();
            arr = s.Sorting(arr);
            Console.WriteLine("Time for CombSort is {0}.", DateTime.Now - dt);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
            }
            dt = DateTime.Now;
            s = new GnomeSort<int>();
            arr = s.Sorting(arr);
            Console.WriteLine("Time for GnomeSort is {0}.", DateTime.Now - dt);

            arr = new int[10000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
            }
            dt = DateTime.Now;
            s = new InsertionSort<int>();
            arr = s.Sorting(arr);
            Console.WriteLine("Time for InsertionSort is {0}.", DateTime.Now - dt);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
            }
            dt = DateTime.Now;
            s = new BinaryInsertionSort<int>();
            arr = s.Sorting(arr);
            Console.WriteLine("Time for BinaryInsertionSort is {0}.", DateTime.Now - dt);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
            }
            dt = DateTime.Now;
            s = new ShellSort<int>();
            arr = s.Sorting(arr);
            Console.WriteLine("Time for ShellSort is {0}.", DateTime.Now - dt);

            arr = new int[1000000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1000000);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
            }
            dt = DateTime.Now;
            s = new HeapSort<int>();
            arr = s.Sorting(arr);
            Console.WriteLine("Time for HeapSort is {0}.", DateTime.Now - dt);
            int ddd = 0;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                //Console.Write(arr[i] + " ");
                if (arr[i] > arr[i + 1]) //Console.WriteLine("Fatal ERROR!!!");
                    ddd++;
            }
            Console.WriteLine("Error count: {0}", ddd);

            dt = DateTime.Now;
            s = new MergeSort<int>();
            arr = s.Sorting(arr);
            Console.WriteLine("Time for MergeSort is {0}.", DateTime.Now - dt);
            
            //StreamWriter sw = new StreamWriter("C:/Users/suvorovi/1.txt");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1000000);
                //sw.Write(arr[i] + " ");
            }
            //sw.WriteLine("");
            dt = DateTime.Now;
            s = new QuickSort<int>();
            arr = s.Sorting(arr);
            Console.WriteLine("Time for QuickSort is {0}.", DateTime.Now - dt);
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1000000);
                //sw.Write(arr[i] + " ");
            }
            //sw.WriteLine("");
            dt = DateTime.Now;
            s = new TimSort<int>();
            arr = s.Sorting(arr);
            Console.WriteLine("Time for TimSort is {0}.", DateTime.Now - dt);
            ddd = 0;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                //Console.Write(arr[i] + " ");
                if (arr[i] > arr[i + 1]) //Console.WriteLine("Fatal ERROR!!!");
                    ddd++;
            }
            Console.WriteLine("Error count: {0}", ddd);
            Console.ReadLine();
            //sw.Close();
        }
    }
}
