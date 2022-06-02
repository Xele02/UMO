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
			public int m_cosModelId;
			[SerializeField]
			public int m_personalityId;
		}

		public Color psylliumColor;
		[SerializeField]
		public List<DivaParam.ChangePersonalityInfo> m_changePersonlityInfo;
	}
}
