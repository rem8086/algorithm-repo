using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm.Sort
{
    class HeapSort<T>:ISort<T> where T: IComparable<T>
    {
        T[] heap;
        int heapLength;

        public T[] Sorting(T[] arr)
	{
		MakeHeap(arr);
		T[] resultArray = new T[heapLength];
		int len = heapLength;
		for (int i = 0; i < len; i++)
		{
            resultArray[i] = RemoveMin();
		}
		return resultArray;
	}

        void MakeHeap(T[] arr)
        {
            //heap = new T[arr.Length];
            //Array.Copy(arr, heap, arr.Length);
            heap = arr;
            heapLength = arr.Length;
            int halfLength = Convert.ToInt32(Math.Floor(heapLength / 2.0));
            for (int i = halfLength - 1; i >= 0; i--)
            {
                SiftDown(i);
            }
        }

        void Insert(T element)
        {
            if (heap.Length == heapLength)
            {
                Array.Resize(ref heap, Convert.ToInt32(Math.Truncate(heapLength * 2.0 / 3.0)));
                // array resize with 2/3 and 4/9 
            }
            heap[heapLength++] = element;
            SiftUp(heapLength - 1);
        }

        T GetMin()
        {
            return heap[0];
        }

        T RemoveMin()
        {
            //no array full size recalc, just cuz  insert doesn't need in heapsort
            if (heapLength == 0) return default(T);
            T returnedMin = heap[0];
            heap[0] = heap[--heapLength];
            SiftDown(0);
            return returnedMin;
        }

        void SiftDown(int elementIndex)
        {
            if (heapLength > elementIndex * 2 + 2)
            {
                int minSonIndex = (heap[elementIndex * 2 + 2].CompareTo(heap[elementIndex * 2 + 1]) < 0)
                    ? elementIndex * 2 + 2 : elementIndex * 2 + 1;
                if (heap[minSonIndex].CompareTo(heap[elementIndex]) < 0)
                {
                    Swap(elementIndex, minSonIndex);
                    SiftDown(minSonIndex);
                }
            }
            else if (heapLength > elementIndex * 2 + 1)
            {
                if (heap[elementIndex * 2 + 1].CompareTo(heap[elementIndex]) < 0)
                {
                    Swap(elementIndex, elementIndex * 2 + 1);
                    //SiftDown(elementIndex * 2 + 1);
                }
            }
            else
            {
                return;
            }
        }

        void SiftUp(int elementIndex)
        {
            int parentIndex = Convert.ToInt32(Math.Ceiling(elementIndex / 2.0 - 1.0));
            if (parentIndex >= 0)
            {
                if (heap[elementIndex].CompareTo(heap[parentIndex]) < 0)
                {
                    Swap(elementIndex, parentIndex);
                    SiftUp(parentIndex);
                }
            }
        }

        void Swap(int firstIndex, int secondIndex)
        {
            T tempElement = heap[firstIndex];
            heap[firstIndex] = heap[secondIndex];
            heap[secondIndex] = tempElement;
        }
    }
}
