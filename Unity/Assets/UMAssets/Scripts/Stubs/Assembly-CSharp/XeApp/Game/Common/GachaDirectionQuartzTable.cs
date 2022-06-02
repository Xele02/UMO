using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class GachaDirectionQuartzTable : ScriptableObject
	{
		[Serializable]
		public class PhaseData
		{
			[SerializeField]
			private List<GachaDirectionQuartzTable.QuartzType> m_quartzTypes;
		}

		[Serializable]
		public class RarityData
		{
			[SerializeField]
			private List<GachaDirectionQuartzTable.PhaseData> m_phases;
			[SerializeField]
			private List<int> m_weights;
		}

		public enum QuartzType
		{
			LV1_Blue = 0,
			LV2_Red = 1,
			LV3_Gold = 2,
			_Num = 3,
		}

		[SerializeField]
		private List<GachaDirectionQuartzTable.RarityData> m_rarityDatas;
	}
}
