using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm.Sort
{
    class BubbleSort<T>: ISort<T> where T:IComparable<T>
    {
        public T[] Sorting(T[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 1; j < arr.Length - i; j++)
                {
                    if (arr[j].CompareTo(arr[j - 1]) < 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
            return arr;
        }
    }
}
