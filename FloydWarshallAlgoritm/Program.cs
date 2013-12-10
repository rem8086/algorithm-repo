using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm
{
    class Program
    {
        static void Main(string[] args)
        {
            Sort<int> s = new Sort<int>();
            int[] a = { 5, 2, 1, 3, 9, 0, 4, 6, 8, 7 };
            int[] res = s.EvenOddSort(a);
            for (int i = 0; i < res.Length; i++)
            {
                Console.Write(res[i] + " ");
            }
            AdjacencyMatrix matr = new AdjacencyMatrix(6);
            matr.SetElement(0, 1, 2);
            matr.SetElement(0, 3, 5);
            matr.SetElement(1, 2, 4);
            matr.SetElement(2, 3, 1);
            matr.SetElement(2, 5, 7);
            matr.SetElement(3, 0, -3);
            matr.SetElement(3, 1, 4);
            matr.SetElement(3, 2, 6);
            matr.SetElement(3, 4, 5);
            matr.SetElement(4, 2, 8);
            matr.SetElement(4, 5, -1);
            FlWaAlgoritm alg = new FlWaAlgoritm(matr);
            Console.WriteLine(alg.ShowResult());
            alg.AlgoritmStep();
            Console.WriteLine(alg.ShowResult());
            Console.ReadLine();
        }
    }
}
