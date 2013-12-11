using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm;

class Sort<T> where T:IComporable<T>
{
	public T[] CombSort(T[] arr)
	{
		const float REDUCTIONFACTOR = 1.247330950103979;
		int interval = Math.Round(arr.Length/REDUCTIONFACTOR,0);
		while (interval >= 1)
		{
			bool turn = false;
			while (turn)
			{
				for (int i = 0; i < arr.Length - interval; i++)
				{
					if(arr[i].CompareTo(arr[i+interval]) > 0)
					{
						T temp = arr[i];
						arr[i] = arr[i+interval];
						arr[i+interval] = a[i];
						turn = true;
					}
				}
				if (interval > 1) {turn = false;}
			}
			interval--;
		}
		return arr;
	}
}