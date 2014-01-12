using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm.Sort
{
    class BinaryInsertionSort<T>:ISort<T> where T:IComparable<T>
    {
        public T[] Sorting(T[] arr)
        {
            T key;
            for (int i = 1; i < arr.Length; i++)
            {
                int left = 0;
                int right = i;
                key = arr[i];
                while (left < right)
                {
                    int middle = Convert.ToInt32(Math.Truncate((right + left) / 2.0));
                    if (key.CompareTo(arr[middle]) < 0)
                        right = middle;
                    else
                        left = middle + 1;
                }
                for (int j = i; j > left; j--)
                {
                    T temp = arr[j - 1];
                    arr[j - 1] = arr[j];
                    arr[j] = temp;
                }
            }
            return arr;
        }
    }
}
