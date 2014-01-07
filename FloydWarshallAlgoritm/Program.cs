using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace FloydWarshallAlgoritm
{
    class Program
    {
        static void Main(string[] args)
        {
            Sort<int> s = new Sort<int>();
            int[] arr = new int[10000];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
            }
            DateTime dt = DateTime.Now;
            arr = s.BubbleSort(arr);
            Console.WriteLine("Time for BubbleSort is {0}.", DateTime.Now - dt);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
            }
            dt = DateTime.Now;
            arr = s.CocktailSort(arr);
            Console.WriteLine("Time for CocktailSort is {0}.", DateTime.Now - dt);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
            }
            dt = DateTime.Now;
            arr = s.EvenOddSort(arr);
            Console.WriteLine("Time for EvenOddSort is {0}.", DateTime.Now - dt);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
            }
            dt = DateTime.Now;
            arr = s.CombSort(arr);
            Console.WriteLine("Time for CombSort is {0}.", DateTime.Now - dt);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
            }
            dt = DateTime.Now;
            arr = s.GnomeSort(arr);
            Console.WriteLine("Time for GnomeSort is {0}.", DateTime.Now - dt);

            arr = new int[100000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(100000);
            }
            dt = DateTime.Now;
            arr = s.InsertionSort(arr);
            Console.WriteLine("Time for InsertionSort is {0}.", DateTime.Now - dt);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(100000);
            }
            dt = DateTime.Now;
            arr = s.BinaryInsertionSort(arr);
            Console.WriteLine("Time for BinaryInsertionSort is {0}.", DateTime.Now - dt);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
            }
            dt = DateTime.Now;
            arr = s.ShellSort(arr);
            Console.WriteLine("Time for ShellSort is {0}.", DateTime.Now - dt);

            arr = new int[1000000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1000000);
            }
            dt = DateTime.Now;
            arr = s.MergeSort(arr);
            Console.WriteLine("Time for MergeSort is {0}.", DateTime.Now - dt);
            
            //StreamWriter sw = new StreamWriter("C:/Users/suvorovi/1.txt");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1000000);
                //sw.Write(arr[i] + " ");
            }
            //sw.WriteLine("");
            dt = DateTime.Now;
            arr = s.QuickSort(arr);
            Console.WriteLine("Time for QuickSort is {0}.", DateTime.Now - dt);
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1000000);
                //sw.Write(arr[i] + " ");
            }
            //sw.WriteLine("");
            dt = DateTime.Now;
            arr = s.QuickSort(arr, 0, arr.Length-1);
            Console.WriteLine("Time for QuickSort is {0}.", DateTime.Now - dt);
            arr = new int[10000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10000);
                //sw.Write(arr[i] + " ");
            }
            //sw.WriteLine("");
            dt = DateTime.Now;
            arr = s.TimSort(arr);
            Console.WriteLine("Time for TimSort is {0}.", DateTime.Now - dt);
            for (int i = 0; i < arr.Length-1; i++)
            {
                //sw.Write(arr[i] + " ");
                if (arr[i] > arr[i + 1]) Console.WriteLine("Fatal ERROR!!!");
            }
            Console.ReadLine();
            //sw.Close();
        }
    }
}
