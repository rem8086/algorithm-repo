using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm.Sort
{
    interface ISort<T> where T : IComparable<T>
    {
        T[] Sorting(T[] arr);
    }
}
