using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm.Sort
{
    class GnomeSort<T>:ISort<T> where T:IComparable<T>
    {
        public T[] Sorting(T[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(arr[i - 1]) < 0)
                {
                    T temp = arr[i - 1];
                    arr[i - 1] = arr[i];
                    arr[i] = temp;
                    int j = i-1;
                    while ((j > 0) && (arr[j].CompareTo(arr[j - 1]) < 0))
                    {
                        T anothertemp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = anothertemp;
                        j--;
                    }

                }
            }
            return arr;
        }
    }
}
