using System;
using System.Collections.Generic;

namespace XeSys
{
	public static class Algorithms
	{
		// RVA: -1 Offset: -1
		// public static void InsertSort<T>(T[] ary, Comparison<T> comp) { }
		/* GenericInstMethod :
		|
		|-RVA: 0x1AB5100 Offset: 0x1AB5100 VA: 0x1AB5100
		|-Algorithms.InsertSort<object>
		*/

		// RVA: -1 Offset: -1
		public static void InsertSort<T>(List<T> ary, Comparison<T> comp)
		{
			for(int i = 1, j = 2; i < ary.Count; i++, j++)
			{
				T item1 = ary[i];
				int k = j;
				for(; k > 1; k--)
				{
					T item = ary[k - 2];
					if(comp(item, item1) < 1)
						break;
					ary[k - 1] = item;
				}
				ary[k - 1] = item1;
			}
		}
		/* GenericInstMethod :
		|
		|-RVA: 0x1AB4F60 Offset: 0x1AB4F60 VA: 0x1AB4F60
		|-Algorithms.InsertSort<JBCAHMMCOKK>
		|-Algorithms.InsertSort<PKNOKJNLPOE.MJFMOPMOFDJ>
		|-Algorithms.InsertSort<object>
		*/
	}

}
