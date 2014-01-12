using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm.Sort
{
    class QuickSort<T>:ISort<T> where T:IComparable<T>
    {
        public T[] Sorting(T[] arr)
        {
            return Sorting(arr, 0, arr.Length - 1);
        }

        T[] Sorting(T[] arr, int start, int finish)
        {
            if (finish - start < 1) { return arr; }
            int pivot = finish;
            int i = start;
            int j = finish - 1;
            while (i < j)
            {
                while (arr[i].CompareTo(arr[pivot]) < 0) { i++; }
                while ((arr[j].CompareTo(arr[pivot]) >= 0) && (j > start)) { j--; }
                if (i < j)
                {
                    T temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++; j++;
                }
            }
            if ((i > j) || ((i == j) && (arr[j].CompareTo(arr[pivot]) < 0))) { j++; }
            if (pivot != j)
            {
                T temp = arr[pivot];
                arr[pivot] = arr[j];
                arr[j] = temp;
                pivot = j;
            }
            Sorting(arr, start, pivot - 1);
            Sorting(arr, pivot + 1, finish);
            return arr;
        }
    }
}
