using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm.Sort
{
    class SelectionSort<T>:ISort<T> where T:IComparable<T>
    {
        public T[] Sorting(T[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[min].CompareTo(arr[j]) < 0) { min = j; }
                }
                if (min != i)
                {
                    T temp = arr[min];
                    arr[min] = arr[i];
                    arr[i] = temp;
                }
            }
            return arr;
        }
    }
}
