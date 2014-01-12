using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm.Sort
{
    class MergeSort<T>:ISort<T> where T:IComparable<T>
    {
        public T[] Sorting(T[] arr)
        {
            if (arr.Length == 1) return arr;
            int partOneLength = Convert.ToInt32(Math.Truncate(arr.Length / 2.0));
            T[] partOneArr = new T[partOneLength];
            for (int i = 0; i < partOneLength; i++)
            {
                partOneArr[i] = arr[i];
            }
            T[] partTwoArr = new T[arr.Length - partOneLength];
            for (int i = 0; i < arr.Length - partOneLength; i++)
            {
                partTwoArr[i] = arr[partOneLength + i];
            }
            partOneArr = Sorting(partOneArr);
            partTwoArr = Sorting(partTwoArr);
            int partOneIndex = 0, partTwoIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (partOneIndex == partOneArr.Length) { arr[i] = partTwoArr[partTwoIndex++]; }
                else if (partTwoIndex == partTwoArr.Length) { arr[i] = partOneArr[partOneIndex++]; }
                else if (partOneArr[partOneIndex].CompareTo(partTwoArr[partTwoIndex]) < 0) { arr[i] = partOneArr[partOneIndex++]; }
                else { arr[i] = partTwoArr[partTwoIndex++]; }
            }
            return arr;
        }
    }
}
