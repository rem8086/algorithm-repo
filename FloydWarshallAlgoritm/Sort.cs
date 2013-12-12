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
	
	public T[] ShellSort(T[] arr)
	{
		int[] delta = {1, 4, 10, 23, 57, 132, 301, 701};
		int deltaElement = delta.Length - 1;
		while (delta[deltaElement] >= arr.Length) { deltaElement--; }
		for (int i = deltaElement; i < 0; i--)
		{
			for (int j = 1; j <= delta[i]; j++)
			{
				for (int k = delta[i] + j - 1; k < arr[Length]; k += delta[i])
				{
					T key = arr[k];
					int l = k - delta[i];
					while ((l >= 0) && (arr[l].CompareTo(key) > 0))
					{
						arr[l+delta[i]] = arr[l];
						l -= delta[i];
					}
					arr[l+delta[i]] = key;
				}
			}
		}
	}
	
}