using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class BoneSpringSuppressParam : ScriptableObject
	{
		[Serializable]
		public class TargetData
		{
			[SerializeField]
			private string m_pointPath; // 0x8
			[SerializeField]
			private float m_influenceRate; // 0xC

			public string pointPath { get { return m_pointPath; } } //0xE635C8
			public float influenceRate { get { return m_influenceRate; } } //0xE635D0
		}

		[SerializeField]
		private List<BoneSpringSuppressParam.TargetData> m_targets; // 0xC

		public int targetCount { get { return m_targets.Count; } }//0xE634C8

		// RVA: 0xE63540 Offset: 0xE63540 VA: 0xE63540
		public BoneSpringSuppressParam.TargetData GetTargetData(int index)
		{
			return m_targets[index];
		}
	}
}
