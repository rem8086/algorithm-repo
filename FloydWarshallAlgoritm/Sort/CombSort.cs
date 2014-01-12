using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm.Sort
{
    class CombSort<T>:ISort<T> where T:IComparable<T>
    {
        public T[] Sorting(T[] arr)
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
    }
}
