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

        public T[] InsertionSort(T[] arr, int start, int finish)
        {
            T key;
            for (int i = start + 1; i <= finish; i++)
            {
                key = arr[i];
                int j = i - 1;
                while ((j >= start) && (arr[j]).CompareTo(key) > 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
            return arr;
        }
        
        public T[] BinaryInsertionSort(T[] arr)
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
		
		public T[] SelectionSort(T[] arr)
		{
			for (int i = 0; i < arr.Length-1; i++)
			{
				int min = i;
				for (int j = i+1; j < arr.Length; j++)
				{
					if (arr[min].CompareTo(arr[j])<0) {min = j;}
				}
				if (min != i)
				{
					T temp = arr[min];
					arr[min] = arr[i];
					arr[i] = temp;
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

		public T[] TimSort(T[] arr)
		{
			int minrun = TimSort_FindMinRun(arr.Length);
			int current = 0;
			List<T[]> runarraylist = new List<T[]>();
			while (current < arr.Length-1)
			{ 
				int currentlength = 2;
				bool reverse = (arr[current].CompareTo(arr[current+1]) > 0) ? true : false;
				while (((reverse && (arr[current + currentlength - 2].CompareTo(arr[current + currentlength - 1]) > 0))||
				(!reverse && (arr[current + currentlength - 2].CompareTo(arr[current + currentlength - 1]) <= 0))) &&
				(current + currentlength < arr.Length))
				{ 
					currentlength++; 
				}
                if (reverse)
                {
                    for (int i = current; i < Convert.ToInt32(Math.Truncate(currentlength / 2.0)); i++)
                    {
                        T temp = arr[i];
                        arr[i] = arr[currentlength - i];
                        arr[currentlength - i] = temp;
                    }
                }
				//int originalcurrentlength = currentlength;
				if (current + currentlength == arr.Length - 1) currentlength++;
				if (currentlength < minrun) currentlength = minrun; 
				if (current + currentlength < arr.Length) currentlength = arr.Length - current;
                /*T[] currentarray = new T[currentlength];
                for (int i = 0; i < currentlength; i++)
                {
                    if ((reverse)&&(i < originalcurrentlength))
                    {
                        currentarray[originalcurrentlength - 1 - i] = arr[current + i];
                    } else
                    {
                        currentarray[i] = arr[current + i];
                    }
                }*/
                arr = InsertionSort(arr, current, current + currentlength-1);
				//runarraylist.Add(InsertionSort(currentarray));
				runarraylist = TimSort_MergeSubArray(runarraylist);
				current += currentlength;
                                                    //здесь добавление подмассива в стек (можно лист чтобы меньше переписывать)
                                                    //работа с существующим стеком
			}
			//runarraylist.Reverse(); // проверить как работает reverse
			T[] resultarray = runarraylist[runarraylist.Count-1];
            for (int i = runarraylist.Count-2; i >= 0; i--)
            {
                resultarray = TimSort_Merge(resultarray, runarraylist[i]);
            }
			return resultarray;
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
			if (length % Math.Pow(2,rightcount) != 0) minrun++;
			return minrun;
		}
	
		T[] TimSort_Merge(T[] arr1, T[] arr2) //проверить как будет работать с одним пустым массивом
		{
			T[] resultarr = new T[arr1.Length + arr2.Length];
			int counter = 0;
			int arr1index = 0, arr2index = 0;
			for (int i = 0; i < resultarr.Length; i++)
			{
				if (arr1index == arr1.Length)
				{
					resultarr[i] = arr2[arr2index++];
					counter = (counter < 8) ? 8 : counter + 1;
				}
				else if (arr2index == arr2.Length) 
				{
					resultarr[i] = arr1[arr1index++];
					counter = (counter > 7) ? 1 : counter + 1;
				}
				else if (arr1[arr1index].CompareTo(arr2[arr2index]) < 0) 
				{
					resultarr[i] = arr1[arr1index++];
					counter = (counter > 7) ? 1 : counter + 1;
				} else 
				{
					resultarr[i] = arr2[arr2index++];
					counter = (counter < 8) ? 8 : counter + 1;
				}
				if (counter == 7)
				{
					int addel = TimSort_Galop(arr1, arr1index-1, arr2[arr2index]);
					for (int j = 1; j <= addel; j++)
					{
						resultarr[i+j] = arr1[arr1index+j-1];
					}
					arr1index = arr1index+addel;
					i=i+addel;
					counter = 0;
				}
				if (counter == 14)
				{
					int addel = TimSort_Galop(arr2, arr2index-1, arr1[arr1index]);
					for (int j = 1; j <= addel; j++)
					{
						resultarr[i+j] = arr2[arr2index+j-1];
					}
					arr2index = arr2index+addel;
					i=i+addel;
					counter = 0;
				}
			}
			return resultarr;
		}
		
		List<T[]> TimSort_MergeSubArray(List<T[]> arraylist) // проверить индексацию List
		{
			int count = arraylist.Count;
			if (count < 3) return arraylist;
			if ((arraylist[count-1].Length > arraylist[count-2].Length + arraylist[count-3].Length)&&
                (arraylist[count-2].Length > arraylist[count-3].Length))
			{
				return arraylist;
			}
			if (arraylist[count-1].Length > arraylist[count-3].Length)
			{
				arraylist[count-3] = TimSort_Merge(arraylist[count-3], arraylist[count-2]);
			} else
			{
                arraylist[count - 1] = TimSort_Merge(arraylist[count - 1], arraylist[count - 2]);
			}
			arraylist.RemoveAt(count-2);
			return TimSort_MergeSubArray(arraylist);
		}
		
		int TimSort_Galop(T[] arr, int arrindex, T maxel) //возвращает количество элементов из подмассива для переноса
		{
			int i = -1;
			/*int count = (Math.Pow(2,i+1) < arr.Length-arrindex-1) ? Math.Pow(2,i+1) : arr.Length-arrindex-1;
			while ((Math.Pow(2,i+1) + arrindex < arr.Length)&&(arr[arrindex+Math.Pow(2,i+1)] <= maxel))
			{
				i++;
			}
			if (i == -1) return 0;
			return Math.Pow(2,i);*/
			while (true)
			{
				if (Math.Pow(2,i+1) >= arr.Length - arrindex)
				{
					if (arr[arr.Length-1].CompareTo(maxel) > 0) return Convert.ToInt32(Math.Pow(2,i)); 
                        else return arr.Length-arrindex-1;
				}
				if (arr[Convert.ToInt32(Math.Pow(2,i+1))].CompareTo(maxel) > 0) return (i < 0) ? 0 : Convert.ToInt32(Math.Pow(2,i));
				i++;
			}
		}
	
	}
}

