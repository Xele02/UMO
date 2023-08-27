using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class EpisodeUtility
	{

		// RVA: 0xEF3650 Offset: 0xEF3650 VA: 0xEF3650
		public static int CalcEpisodeGaugeFrame(int currentPoint, int maxPoint, int flashFrame = 100)
		{
			return (int)(Mathf.Clamp01(currentPoint * 1.0f / maxPoint) * flashFrame);
		}

		// RVA: 0xF0A990 Offset: 0xF0A990 VA: 0xF0A990
		public static int GetAcquiredRewardLastIndex(List<LGMEPLIJLNB> list, int point)
		{
			for(int i = 0; i < list.Count - 1; i++)
			{
				if (point < list[i].DNBFMLBNAEE_TotalPoint)
					return i;
			}
			return list.Count - 1;
		}
	}
}
