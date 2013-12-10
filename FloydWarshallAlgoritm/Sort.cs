using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm
{
    class Sort<T> where T:IComparable<T>
    {
        public T[] BubbleSort(T[] arr) 
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

        public T[] CocktailSort(T[] arr)
        {
            for (int i = 0; i < Convert.ToInt32(arr.Length/2); i++)
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
                for (int j = arr.Length-2 - i; j > i; j--)
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

        public T[] EvenOddSort(T[] arr)
        {
            bool turn = true;
            while (turn)
            {
                turn = false;
                for (int i = 0; i < arr.Length-1; i += 2)
                {
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        T temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        turn = true;
                    }
                }
                for (int i = 1; i < arr.Length-1; i += 2)
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
