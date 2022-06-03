using UnityEngine;
using System;
using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class MenuDivaVoiceTable : ScriptableObject // TypeDefIndex: 10763
	{
		[Serializable]
		public class Data
		{
			[SerializeField]
			private int m_voiceId; // 0x8
			[SerializeField]
			private DivaMenuMotion.Type m_motionType; // 0xC

			public int VoiceId { get { return m_voiceId; } } // get_VoiceId 0xED0C00 
			public DivaMenuMotion.Type MotionType { get { return m_motionType; } } // get_MotionType 0xED0C08 
		}

		// Fields
		[SerializeField]
		[Header("- m_home_[Voice Id]")]
		private List<MenuDivaVoiceTable.Data> m_timeTalk; // 0xC
		[SerializeField]
		private List<MenuDivaVoiceTable.Data> m_loginTalk; // 0x10
		[SerializeField]
		private MenuDivaVoiceTable.Data m_comeback; // 0x14
		[SerializeField]
		private MenuDivaVoiceTable.Data m_birthdayTalk; // 0x18
		[Header("- diva_[Diva Id]_m_home_[Voice Id]")]
		[SerializeField]
		private List<MenuDivaVoiceTable.Data> m_eventTalk; // 0x1C
		[SerializeField]
		[Header("- touch [Voice Id] [Touch / Talk / Timezone / Present / SimpleTalk]")]
		private List<MenuDivaVoiceTable.Data> m_touchReaction; // 0x20
		[SerializeField]
		[Header("- present [Voice Id] [Touch / Talk / Timezone / Present / SimpleTalk]")]
		private List<MenuDivaVoiceTable.Data> m_presentReaction; // 0x24
		[Header("- intimacy [Voice Id] [Touch / Talk / Timezone / Present / SimpleTalk]")]
		[SerializeField]
		private List<MenuDivaVoiceTable.Data> m_intimacyReaction; // 0x28
		[SerializeField]
		[Header("")] // RVA: 0x669D34 Offset: 0x669D34 VA: 0x669D34
		private List<int> m_IntimacyLock_TimeTalk; // 0x2C
		[SerializeField]
		private List<int> m_IntimacyLock_TouchReaction; // 0x30

		// Methods

		// // RVA: 0xECE090 Offset: 0xECE090 VA: 0xECE090
		// public List<MenuDivaVoiceTable.Data> GetList_TimeTalk() { }

		// // RVA: 0xED0848 Offset: 0xED0848 VA: 0xED0848
		// public List<MenuDivaVoiceTable.Data> GetList_LoginTalk() { }

		// // RVA: 0xED0850 Offset: 0xED0850 VA: 0xED0850
		// public List<MenuDivaVoiceTable.Data> GetList_EventTalk() { }

		// // RVA: 0xED0858 Offset: 0xED0858 VA: 0xED0858
		// public List<MenuDivaVoiceTable.Data> GetList_TouchReaction() { }

		// // RVA: 0xED0860 Offset: 0xED0860 VA: 0xED0860
		// public List<MenuDivaVoiceTable.Data> GetList_PresentReaction() { }

		// // RVA: 0xED0868 Offset: 0xED0868 VA: 0xED0868
		// public List<MenuDivaVoiceTable.Data> GetList_IntimacyReaction() { }

		// // RVA: 0xED0870 Offset: 0xED0870 VA: 0xED0870
		// public MenuDivaVoiceTable.Data GetTimeTalk(int i) { }

		// // RVA: 0xED08F0 Offset: 0xED08F0 VA: 0xED08F0
		// public MenuDivaVoiceTable.Data GetLoginTalk(DivaTimezoneTalk.Type i) { }

		// // RVA: 0xED0970 Offset: 0xED0970 VA: 0xED0970
		// public MenuDivaVoiceTable.Data GetEventTalk(DivaSeasonTalk.Type i) { }

		// // RVA: 0xED09F0 Offset: 0xED09F0 VA: 0xED09F0
		// public MenuDivaVoiceTable.Data GetComeback() { }

		// // RVA: 0xED09F8 Offset: 0xED09F8 VA: 0xED09F8
		// public MenuDivaVoiceTable.Data GetBirthdayTalk() { }

		// // RVA: 0xED0A00 Offset: 0xED0A00 VA: 0xED0A00
		// public MenuDivaVoiceTable.Data GetTouchReaction(DivaTouchReaction.Type i) { }

		// // RVA: 0xED0A80 Offset: 0xED0A80 VA: 0xED0A80
		// public MenuDivaVoiceTable.Data GetPresent(int a_index) { }

		// // RVA: 0xED0B3C Offset: 0xED0B3C VA: 0xED0B3C
		// public MenuDivaVoiceTable.Data GetIntimacy(int a_index) { }

		// // RVA: 0xECFB7C Offset: 0xECFB7C VA: 0xECFB7C
		// public List<int> GetIntimacyLock_TimeTalk() { }

		// // RVA: 0xECF3BC Offset: 0xECF3BC VA: 0xECF3BC
		// public List<int> GetIntimacyLock_TouchReaction() { }
	}
}