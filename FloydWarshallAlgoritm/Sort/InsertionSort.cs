using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm.Sort
{
    class InsertionSort<T>:ISort<T> where T:IComparable<T>
    {
        public T[] Sorting(T[] arr)
        {
            T key;
            for (int i = 1; i < arr.Length; i++)
            {
                key = arr[i];
                int j = i - 1;
                while ((j >= 0) && (arr[j]).CompareTo(key) > 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
            return arr;
        }
    }
}
