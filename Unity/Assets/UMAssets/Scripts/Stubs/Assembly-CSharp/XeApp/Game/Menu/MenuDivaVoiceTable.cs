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
			private int m_voiceId;
			[SerializeField]
			private DivaMenuMotion.Type m_motionType;
		}

		[SerializeField]
		private List<MenuDivaVoiceTable.Data> m_timeTalk;
		[SerializeField]
		private List<MenuDivaVoiceTable.Data> m_loginTalk;
		[SerializeField]
		private Data m_comeback;
		[SerializeField]
		private Data m_birthdayTalk;
		[SerializeField]
		private List<MenuDivaVoiceTable.Data> m_eventTalk;
		[SerializeField]
		private List<MenuDivaVoiceTable.Data> m_touchReaction;
		[SerializeField]
		private List<MenuDivaVoiceTable.Data> m_presentReaction;
		[SerializeField]
		private List<MenuDivaVoiceTable.Data> m_intimacyReaction;
		[SerializeField]
		private List<int> m_IntimacyLock_TimeTalk;
		[SerializeField]
		private List<int> m_IntimacyLock_TouchReaction;
	}
}
