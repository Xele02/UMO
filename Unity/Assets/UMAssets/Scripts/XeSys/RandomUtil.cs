using System.Collections.Generic;

namespace XeSys
{
	public class RandomUtil
	{
		// // RVA: 0x239AB64 Offset: 0x239AB64 VA: 0x239AB64
		// public static bool RandomBool() { }

		// // RVA: 0x239AB90 Offset: 0x239AB90 VA: 0x239AB90
		// public static float RandomSign() { }

		// RVA: 0x239AC30 Offset: 0x239AC30 VA: 0x239AC30
		public static int SelectByWeights(IList<int> weights)
		{
			int total = 0;
			for(int i = 0; i < weights.Count; i++)
			{
				total += weights[i];
			}
			float f = total * UnityEngine.Random.value;
			for(int i = 0; i < weights.Count; i++)
			{
				if(f <= weights[i])
					return i;
				f -= weights[i];
			}
			return -1;
		}
	}
}
