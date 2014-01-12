using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm.Sort
{
    class EvenOddSort<T>:ISort<T> where T:IComparable<T>
    {
        public T[] Sorting(T[] arr)
        {
            bool turn = true;
            while (turn)
            {
                turn = false;
                for (int i = 0; i < arr.Length - 1; i += 2)
                {
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        T temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        turn = true;
                    }
                }
                for (int i = 1; i < arr.Length - 1; i += 2)
                {
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        T temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        turn = true;
                    }
                }
            }
            return arr;
        }
    }
}
