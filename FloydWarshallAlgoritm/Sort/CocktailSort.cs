using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm.Sort
{
    class CocktailSort<T>:ISort<T> where T:IComparable<T>
    {
        public T[] Sorting(T[] arr)
        {
            for (int i = 0; i < Convert.ToInt32(arr.Length / 2); i++)
            {
                for (int j = i + 1; j < arr.Length - i; j++)
                {
                    if (arr[j - 1].CompareTo(arr[j]) > 0)
                    {
                        T temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
                for (int j = arr.Length - 2 - i; j > i; j--)
                {
                    if (arr[j - 1].CompareTo(arr[j]) > 0)
                    {
                        T temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }
    }
}
