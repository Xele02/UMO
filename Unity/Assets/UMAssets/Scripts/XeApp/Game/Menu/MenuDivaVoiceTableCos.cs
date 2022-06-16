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
			private int m_voiceId; // 0x8
			[SerializeField]
			private DivaMenuMotion.Type m_motionType; // 0xC
			[SerializeField]
			private int m_weight; // 0x10

			public int VoiceId { get { return m_voiceId; } } // get_VoiceId 0xED0CF0
			public DivaMenuMotion.Type MotionType { get { return m_motionType; } } // get_MotionType 0xED0CF8 
			public int Weight { get { return m_weight; } } // get_Weight 0xED0CE0
		}
		
		[SerializeField]
		[Header("- touch [Voice Id] [Touch / Talk / Timezone / Present / SimpleTalk]")]
		private List<MenuDivaVoiceTableCos.Data> m_touchReaction; // 0xC

		public List<MenuDivaVoiceTableCos.Data> TouchReaction { get { return m_touchReaction; } set { return; } } // get_TouchReaction 0xED0C18  set_TouchReaction 0xED0C20 

		// // RVA: 0xED0C24 Offset: 0xED0C24 VA: 0xED0C24
		// public MenuDivaVoiceTableCos.Data GetTouchReactionData(int a_index) { }

		// // RVA: 0xECF280 Offset: 0xECF280 VA: 0xECF280
		// public List<int> CreateTouchReactionWeightTable() { }
	}
}