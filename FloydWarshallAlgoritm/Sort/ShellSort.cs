using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm.Sort
{
    class ShellSort<T>:ISort<T> where T:IComparable<T>
    {
        public T[] Sorting(T[] arr)
        {
            if (arr.Length == 1) { return arr; }
            int[] delta = { 1, 4, 10, 23, 57, 132, 301, 701 };
            int deltaElement = delta.Length - 1;
            while (delta[deltaElement] >= arr.Length) { deltaElement--; }
            for (int i = deltaElement; i >= 0; i--)
            {
                for (int j = 1; j <= delta[i]; j++)
                {
                    for (int k = delta[i] + j - 1; k < arr.Length; k += delta[i])
                    {
                        T key = arr[k];
                        int l = k - delta[i];
                        while ((l >= 0) && (arr[l].CompareTo(key) > 0))
                        {
                            arr[l + delta[i]] = arr[l];
                            l -= delta[i];
                        }
                        arr[l + delta[i]] = key;
                    }
                }
            }
            return arr;
        }
    }
}
