using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm.Sort
{
    class TimSort<T>:ISort<T> where T:IComparable<T>
    {
        struct SubArray
        {
            public int Index, Length;

            public SubArray(int ind, int len)
            {
                Index = ind;
                Length = len;
            }
        }

        T[] inputArray;
        Stack<SubArray> runarraystack;

        public T[]  Sorting(T[] arr)
        {
            inputArray = arr;
            runarraystack = new Stack<SubArray>();
            int minrun = TimSort_FindMinRun(inputArray.Length);
            int current = 0;
            while (current < inputArray.Length - 1)
            {
                int currentlength = 2;
                bool reverse = (inputArray[current].CompareTo(inputArray[current + 1]) > 0) ? true : false;
                while (((reverse && (inputArray[current + currentlength - 2].CompareTo(inputArray[current + currentlength - 1]) > 0)) ||
                (!reverse && (inputArray[current + currentlength - 2].CompareTo(inputArray[current + currentlength - 1]) <= 0))) &&
                (current + currentlength < inputArray.Length))
                {
                    currentlength++;
                }
                if (reverse)
                {
                    for (int i = current; i < Convert.ToInt32(Math.Truncate(currentlength / 2.0)); i++)
                    {
                        T temp = inputArray[i];
                        inputArray[i] = inputArray[currentlength - i];
                        inputArray[currentlength - i] = temp;
                    }
                }
                if (current + currentlength == inputArray.Length - 1) currentlength++;
                if (currentlength < minrun) currentlength = minrun;
                if (current + currentlength > inputArray.Length) currentlength = inputArray.Length - current;
                InsertionSort(current, current + currentlength - 1);
                runarraystack.Push(new SubArray(current, currentlength));
                TimSort_MergeSubArray();
                current += currentlength;
            }
            while (runarraystack.Count > 1)
            {
                SubArray second = runarraystack.Pop();
                SubArray first = runarraystack.Pop();
                runarraystack.Push(TimSort_Merge(first, second));
            }
            return inputArray;

        }

        void InsertionSort(int start, int finish)
        {
            T key;
            for (int i = start + 1; i <= finish; i++)
            {
                key = inputArray[i];
                int j = i - 1;
                while ((j >= start) && (inputArray[j]).CompareTo(key) > 0)
                {
                    inputArray[j + 1] = inputArray[j];
                    j--;
                }
                inputArray[j + 1] = key;
            }
        }

        int TimSort_FindMinRun(int length)
        {
            int minrun = length;
            int rightcount = 0;
            while (minrun >= 64)
            {
                minrun = Convert.ToInt32((Math.Truncate(minrun / 2.0)));
                rightcount++;
            }
            if (length % Math.Pow(2, rightcount) != 0) minrun++;
            return minrun;
        }

        /* timsort merge without galoping
        SubArray TimSort_Merge(SubArray firstSA, SubArray secondSA) //возвращать SubArray результата, заполнять этот результат одновременно
        {
            T[] temparr = new T[firstSA.Length];
            Array.Copy(inputArray, firstSA.Index, temparr, 0, firstSA.Length);
            int mainIndex = firstSA.Index;
            int firstIndex = 0;
            int secondIndex = secondSA.Index;
            while ((firstIndex < firstSA.Length)&&(secondIndex < secondSA.Index + secondSA.Length))
            {
                inputArray[mainIndex++] = (temparr[firstIndex].CompareTo(inputArray[secondIndex]) < 0)
                    ? temparr[firstIndex++] : inputArray[secondIndex++];
            }
            while (firstIndex < firstSA.Length) inputArray[mainIndex++] = temparr[firstIndex++];
            while (secondIndex < secondSA.Index + secondSA.Length) inputArray[mainIndex++] = inputArray[secondIndex++];
            return new SubArray(firstSA.Index, firstSA.Length + secondSA.Length);
        }
        */

        SubArray TimSort_Merge(SubArray firstSA, SubArray secondSA) 
        {
            T[] temparr = new T[firstSA.Length];
            Array.Copy(inputArray, firstSA.Index, temparr, 0, firstSA.Length);
            int mainIndex = firstSA.Index;
            int firstIndex = 0;
            int secondIndex = secondSA.Index;
            int firstCounter = 0;
            int secondCounter = 0;
            while ((firstIndex < firstSA.Length) && (secondIndex < secondSA.Index + secondSA.Length))
            {
                if (temparr[firstIndex].CompareTo(inputArray[secondIndex]) < 0)
                {
                    inputArray[mainIndex++] = temparr[firstIndex++];
                    firstCounter++; secondCounter = 0;
                }
                else
                {
                    inputArray[mainIndex++] = inputArray[secondIndex++];
                    secondCounter++; firstCounter = 0;
                }
                if (firstCounter == 7)
                {
                    firstCounter = 0;
                    int count = TimSort_Galop(temparr, firstIndex, temparr.Length, inputArray[secondIndex]);
                    for (int i = 0; i < count; i++) inputArray[mainIndex++] = temparr[firstIndex++];
                }
                if (secondCounter == 7)
                {
                    secondCounter = 0;
                    int count = TimSort_Galop(inputArray, secondIndex, secondSA.Index + secondSA.Length, temparr[firstIndex]);
                    for (int i = 0; i < count; i++) inputArray[mainIndex++] = inputArray[secondIndex++];
                }
            }
            while (firstIndex < firstSA.Length) inputArray[mainIndex++] = temparr[firstIndex++];
            while (secondIndex < secondSA.Index + secondSA.Length) inputArray[mainIndex++] = inputArray[secondIndex++];
            return new SubArray(firstSA.Index, firstSA.Length + secondSA.Length);
        }

        // guy from blogspot var merge sub arrays
        void TimSort_MergeSubArray() 
        {
            if (runarraystack.Count < 2) return;
            SubArray X = runarraystack.Pop();
            SubArray Y = runarraystack.Pop();
            SubArray Z = (runarraystack.Count == 0) ? new SubArray(0, 0) : runarraystack.Pop();
            if (((Z.Length > Y.Length + X.Length) || ((Z.Length == 0))) && (Y.Length > X.Length))
            {
                if ((Z.Length != 0)) runarraystack.Push(Z);
                runarraystack.Push(Y);
                runarraystack.Push(X);
                return;
            }
            if ((Z.Length != 0) && (Z.Length <= X.Length + Y.Length))
            {
                if (X.Length >= Z.Length)
                {
                    runarraystack.Push(TimSort_Merge(Z, Y));
                    runarraystack.Push(X);
                }
                else
                {
                    runarraystack.Push(Z);
                    runarraystack.Push(TimSort_Merge(Y, X));
                }
                TimSort_MergeSubArray();
            }
            else if (Y.Length <= X.Length)
            {
                if ((Z.Length != 0)) runarraystack.Push(Z);
                runarraystack.Push(TimSort_Merge(Y, X));
                TimSort_MergeSubArray();
            }
            return;
        }

        /* wiki var merge sub arrays
         void TimSort_MergeSubArray() // проверить индексацию List
		{
            if (runarraystack.Count < 3) return;
            SubArray X = runarraystack.Pop();
            SubArray Y = runarraystack.Pop();
            SubArray Z = runarraystack.Pop();
            Console.WriteLine("Try merge arrays with lenghts {0}, {1}, {2}", Z.Length, Y.Length, X.Length);
			if ((X.Length > Y.Length + Z.Length)&&(Y.Length > Z.Length))
			{
                runarraystack.Push(Z);
                runarraystack.Push(Y);
                runarraystack.Push(X);
				return;
			}
			if (X.Length >= Z.Length)
			{
                runarraystack.Push(TimSort_Merge(Z, Y));
                runarraystack.Push(X);
			} else 
			{
                runarraystack.Push(Z);
                runarraystack.Push(TimSort_Merge(Y, X));
			}
            TimSort_MergeSubArray();
			return;
		}
        */

        int TimSort_Galop(T[] arr, int arrindex, int length, T maxel) //возвращает количество элементов из подмассива для переноса
        {
            int i = -1;
            while (true)
            {
                if (Math.Pow(2, i + 1) >= length - arrindex)
                {
                    if (arr[length - 1].CompareTo(maxel) > 0)
                        return (i < 0) ? 0 : Convert.ToInt32(Math.Pow(2, i));
                    else
                        return length - arrindex - 1;
                }
                if (arr[Convert.ToInt32(Math.Pow(2, i + 1)) + arrindex].CompareTo(maxel) > 0)
                    return (i < 0) ? 0 : Convert.ToInt32(Math.Pow(2, i));
                i++;
            }
        }
    }
}
