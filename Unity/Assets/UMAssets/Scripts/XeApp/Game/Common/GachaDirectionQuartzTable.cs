using UnityEngine;
using System;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.Common
{
	public class GachaDirectionQuartzTable : ScriptableObject
	{
		public enum QuartzType
		{
			LV1_Blue = 0,
			LV2_Red = 1,
			LV3_Gold = 2,
			_Num = 3,
		}

		//[DefaultMemberAttribute] // RVA: 0x64E6F4 Offset: 0x64E6F4 VA: 0x64E6F4
		[Serializable]
		public class PhaseData
		{
			public const int Num = 3;
			[SerializeField]
			private List<QuartzType> m_quartzTypes; // 0x8

			public QuartzType this[int index] { get { return m_quartzTypes[index]; } internal set { m_quartzTypes[index] = value; } } //0x1C1E594 0x1C1E614

			// RVA: 0x1C1E69C Offset: 0x1C1E69C VA: 0x1C1E69C
			internal PhaseData()
			{
				m_quartzTypes = new List<QuartzType>(Num);
				for(int i = 0; i < Num; i++)
				{
					m_quartzTypes.Add(QuartzType.LV1_Blue);
				}
			}
		}

		[Serializable]
		public class RarityData
		{
			[SerializeField]
			private List<PhaseData> m_phases; // 0x8
			[SerializeField]
			private List<int> m_weights; // 0xC

			// internal List<PhaseData> phases { get; } 0x1C1E770
			// internal List<int> weights { get; } 0x1C1E778

			// // RVA: 0x1C1E500 Offset: 0x1C1E500 VA: 0x1C1E500
			public PhaseData RandomSelect()
			{
				return m_phases[RandomUtil.SelectByWeights(m_weights)];
			}

			// // RVA: 0x1C1E780 Offset: 0x1C1E780 VA: 0x1C1E780
			// internal void Add(GachaDirectionQuartzTable.PhaseData phase, int weight) { }

			// // RVA: 0x1C1E834 Offset: 0x1C1E834 VA: 0x1C1E834
			// internal void RemoveAt(int index) { }

			// RVA: 0x1C1E8E4 Offset: 0x1C1E8E4 VA: 0x1C1E8E4
			internal RarityData()
			{
				m_phases = new List<PhaseData>();
				m_weights = new List<int>();
			}
		}

		[SerializeField]
		private List<RarityData> m_rarityDatas; // 0xC

		// RVA: 0x1C1E460 Offset: 0x1C1E460 VA: 0x1C1E460
		public PhaseData RandomSelect(int starNum)
		{
			return m_rarityDatas[starNum - 1].RandomSelect();
		}
	}
}
