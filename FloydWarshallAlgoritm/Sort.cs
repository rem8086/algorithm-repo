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

        public T[] CombSort(T[] arr)
        {
            const float REDUCTIONFACTOR = 1.247330950103979F;
            int interval = Convert.ToInt32(Math.Round(arr.Length / REDUCTIONFACTOR, 0));
            while (interval >= 1)
            {
                    for (int i = 0; i < arr.Length - interval; i++)
                    {
                        if (arr[i].CompareTo(arr[i + interval]) > 0)
                        {
                            T temp = arr[i];
                            arr[i] = arr[i + interval];
                            arr[i + interval] = temp;
                        }
                    }
                interval--;
            }
            return arr;
        }

        public T[] GnomeSort(T[] arr)
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

        public T[] InsertionSort(T[] arr)
        {
            T key;
            for (int i = 1; i < arr.Length; i++)
            {
                key = arr[i];
                int j = i-1;
                while ((j >= 0) && (arr[j]).CompareTo(key) > 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j+1] = key;
            }
            return arr;
        }

        public T[] ShellSort(T[] arr)
        {
            if (arr.Length == 1) { return arr; }
            int[] delta = { 1, 4, 10, 23, 57, 132, 301, 701 };
            int deltaElement = delta.Length - 1;
            while (delta[deltaElement] >= arr.Length) { deltaElement--; }
            for (int i = deltaElement; i >= 0; i--)
            {
                for (int j = 1; j <= delta[i]; j++)
                {
                    for (int k = delta[i] + j - 1; k < arr.Length; k += delta[i])
                    {
                        T key = arr[k];
                        int l = k - delta[i];
                        while ((l >= 0) && (arr[l].CompareTo(key) > 0))
                        {
                            arr[l + delta[i]] = arr[l];
                            l -= delta[i];
                        }
                        arr[l + delta[i]] = key;
                    }
                }
            }
            return arr;
        }

        public T[] MergeSort(T[] arr)
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
            partOneArr = MergeSort(partOneArr);
            partTwoArr = MergeSort(partTwoArr);
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

        public T[] QuickSort(T[] arr)
        {
            if (arr.Length < 2) return arr;
            if (arr.Length == 2)
            {
                if (arr[0].CompareTo(arr[1]) <= 0)
                { 
                    return arr; 
                }
                else
                {
                    return new T[] { arr[1], arr[0] };
                }
            }
            int pivot = arr.Length - 1;
            int lowborder = 0;
            int highborder = arr.Length - 2;
            while (lowborder < highborder)
            {
                while (arr[lowborder].CompareTo(arr[pivot]) < 0) { lowborder++; }
                while ((arr[highborder].CompareTo(arr[pivot]) >= 0) && (highborder > 0)) { highborder--; }
                if (highborder > lowborder)
                {
                    T temp = arr[lowborder];
                    arr[lowborder] = arr[highborder];
                    arr[highborder] = temp;
                    lowborder++; highborder--;
                }
            }
            if ((lowborder > highborder) ||
                ((lowborder == highborder) && (arr[highborder].CompareTo(arr[pivot]) < 0)))
            { highborder++; }
            if (pivot!= highborder)
            {
                T temp = arr[highborder];
                arr[highborder] = arr[pivot];
                arr[pivot] = temp;
                pivot = highborder;
            }

            T[] partonearr = new T[pivot];
            T[] parttwoarr = new T[arr.Length - pivot - 1];
            Array.Copy(arr, 0, partonearr, 0, pivot);
            Array.Copy(arr, pivot + 1, parttwoarr, 0, arr.Length - pivot - 1);
            partonearr = QuickSort(partonearr);
            parttwoarr = QuickSort(parttwoarr);
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < pivot) { arr[i] = partonearr[i]; }
                if (i > pivot) { arr[i] = parttwoarr[i - pivot - 1]; }
            }
            return arr;
        }

        public T[] QuickSort(T[] arr, int start, int finish)
        {
            if (finish - start < 1) { return arr; }
            /* if (finish - start == 1)
             {
                 if (arr[finish].CompareTo(arr[start]) < 0)
                 {
                     T temp = arr[finish];
                     arr[finish] = arr[start];
                     arr[start] = temp;
                 }
                 return arr;
             }*/
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
            QuickSort(arr, start, pivot - 1);
            QuickSort(arr, pivot + 1, finish);
            return arr;
        }

    }
}
