using UnityEngine;
using System;
using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class MenuDivaVoiceTableCos : ScriptableObject
	{
		[Serializable]
		public class Data
		{
			[SerializeField]
			private int m_voiceId;
			[SerializeField]
			private DivaMenuMotion.Type m_motionType;
			[SerializeField]
			private int m_weight;
		}

		[SerializeField]
		private List<MenuDivaVoiceTableCos.Data> m_touchReaction;
	}
}
