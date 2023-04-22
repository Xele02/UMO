using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game
{
	public class DivaParam : ScriptableObject
	{
		[Serializable]
		public class ChangePersonalityInfo
		{
			[SerializeField]
			public int m_cosModelId; // 0x8
			[SerializeField]
			public int m_personalityId; // 0xC
		}
		
		public Color psylliumColor; // 0xC
		[SerializeField]
		public List<ChangePersonalityInfo> m_changePersonlityInfo; // 0x1C

		// // RVA: 0x11B94CC Offset: 0x11B94CC VA: 0x11B94CC
		public int ChangePersonalityId(int a_cos_model_id, int a_personality_id)
		{
			foreach(var c in m_changePersonlityInfo)
			{
				if(c.m_cosModelId == a_cos_model_id && c.m_personalityId > 0)
					return c.m_personalityId;
			}
			return a_personality_id;
		}

	}
}