using UnityEngine;
using System;
using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class MenuDivaVoiceTable : ScriptableObject
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

		[SerializeField]
		[Header("- m_home_[Voice Id]")]
		private List<Data> m_timeTalk; // 0xC
		[SerializeField]
		private List<Data> m_loginTalk; // 0x10
		[SerializeField]
		private Data m_comeback; // 0x14
		[SerializeField]
		private Data m_birthdayTalk; // 0x18
		[Header("- diva_[Diva Id]_m_home_[Voice Id]")]
		[SerializeField]
		private List<Data> m_eventTalk; // 0x1C
		[SerializeField]
		[Header("- touch [Voice Id] [Touch / Talk / Timezone / Present / SimpleTalk]")]
		private List<Data> m_touchReaction; // 0x20
		[SerializeField]
		[Header("- present [Voice Id] [Touch / Talk / Timezone / Present / SimpleTalk]")]
		private List<Data> m_presentReaction; // 0x24
		[Header("- intimacy [Voice Id] [Touch / Talk / Timezone / Present / SimpleTalk]")]
		[SerializeField]
		private List<Data> m_intimacyReaction; // 0x28
		[SerializeField]
		[Header("")] // RVA: 0x669D34 Offset: 0x669D34 VA: 0x669D34
		private List<int> m_IntimacyLock_TimeTalk; // 0x2C
		[SerializeField]
		private List<int> m_IntimacyLock_TouchReaction; // 0x30

		// // RVA: 0xECE090 Offset: 0xECE090 VA: 0xECE090
		public List<Data> GetList_TimeTalk()
		{
			return m_timeTalk;
		}

		// // RVA: 0xED0848 Offset: 0xED0848 VA: 0xED0848
		// public List<MenuDivaVoiceTable.Data> GetList_LoginTalk() { }

		// // RVA: 0xED0850 Offset: 0xED0850 VA: 0xED0850
		// public List<MenuDivaVoiceTable.Data> GetList_EventTalk() { }

		// // RVA: 0xED0858 Offset: 0xED0858 VA: 0xED0858
		// public List<MenuDivaVoiceTable.Data> GetList_TouchReaction() { }

		// // RVA: 0xED0860 Offset: 0xED0860 VA: 0xED0860
		// public List<MenuDivaVoiceTable.Data> GetList_PresentReaction() { }

		// // RVA: 0xED0868 Offset: 0xED0868 VA: 0xED0868
		public List<Data> GetList_IntimacyReaction()
		{
			return m_intimacyReaction;
		}

		// // RVA: 0xED0870 Offset: 0xED0870 VA: 0xED0870
		public Data GetTimeTalk(int i)
		{
			return m_timeTalk[i];
		}

		// // RVA: 0xED08F0 Offset: 0xED08F0 VA: 0xED08F0
		public Data GetLoginTalk(DivaTimezoneTalk.Type i)
		{
			return m_loginTalk[(int)i];
		}

		// // RVA: 0xED0970 Offset: 0xED0970 VA: 0xED0970
		public Data GetEventTalk(DivaSeasonTalk.Type i)
		{
			return m_eventTalk[(int)i];
		}

		// // RVA: 0xED09F0 Offset: 0xED09F0 VA: 0xED09F0
		// public MenuDivaVoiceTable.Data GetComeback() { }

		// // RVA: 0xED09F8 Offset: 0xED09F8 VA: 0xED09F8
		public Data GetBirthdayTalk()
		{
			return m_birthdayTalk;
		}

		// // RVA: 0xED0A00 Offset: 0xED0A00 VA: 0xED0A00
		public Data GetTouchReaction(DivaTouchReaction.Type i)
		{
			return m_touchReaction[(int)i];
		}

		// // RVA: 0xED0A80 Offset: 0xED0A80 VA: 0xED0A80
		public Data GetPresent(int a_index)
		{
			if (m_presentReaction.Count <= a_index)
				return null;
			return m_presentReaction[a_index];
		}

		// // RVA: 0xED0B3C Offset: 0xED0B3C VA: 0xED0B3C
		public Data GetIntimacy(int a_index)
		{
			if (m_intimacyReaction.Count <= a_index)
				return null;
			return m_intimacyReaction[a_index];
		}

		// // RVA: 0xECFB7C Offset: 0xECFB7C VA: 0xECFB7C
		public List<int> GetIntimacyLock_TimeTalk()
		{
			return m_IntimacyLock_TimeTalk;
		}

		// // RVA: 0xECF3BC Offset: 0xECF3BC VA: 0xECF3BC
		public List<int> GetIntimacyLock_TouchReaction()
		{
			return m_IntimacyLock_TouchReaction;
		}
	}
}
