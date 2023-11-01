using UnityEngine;
using System;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.Common
{
	public class GachaDirectionOrbTable : ScriptableObject
	{
		public enum ExpectType
		{
			LV0 = 0,
			LV1 = 1,
			LV2 = 2,
			LV3 = 3,
			_Num = 4,
		}

		[Serializable]
		public class RegionData
		{
			[SerializeField]
			private List<int> m_weights; // 0x8

			internal List<int> weights { get { return m_weights; } } //0x1C1DF28

			// // RVA: 0x1C1DE18 Offset: 0x1C1DE18 VA: 0x1C1DE18
			public ExpectType RandomSelect()
			{
				return (ExpectType)RandomUtil.SelectByWeights(m_weights);
			}
		}

		[SerializeField]
		private RegionData m_missRegionData; // 0xC
		[SerializeField]
		private RegionData m_rare4RegionData; // 0x10
		[SerializeField]
		private RegionData m_rare5RegionData; // 0x14
		[SerializeField]
		private List<int> m_expantionRatios; // 0x18

		// RVA: 0x1C1DDEC Offset: 0x1C1DDEC VA: 0x1C1DDEC
		public ExpectType SelectForMiss()
		{
			return m_missRegionData.RandomSelect();
		}

		// RVA: 0x1C1DE24 Offset: 0x1C1DE24 VA: 0x1C1DE24
		public ExpectType SelectForRare5()
		{
			return m_rare5RegionData.RandomSelect();
		}

		// RVA: 0x1C1DE50 Offset: 0x1C1DE50 VA: 0x1C1DE50
		public ExpectType SelectForRare4()
		{
			return m_rare4RegionData.RandomSelect();
		}

		// RVA: 0x1C1DE7C Offset: 0x1C1DE7C VA: 0x1C1DE7C
		public bool SelectForHitExpansion(ExpectType expect)
		{
			return UnityEngine.Random.Range(0, 100) < m_expantionRatios[(int)expect];
		}
	}
}
