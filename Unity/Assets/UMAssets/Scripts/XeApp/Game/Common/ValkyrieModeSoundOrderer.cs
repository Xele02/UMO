using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class ValkyrieModeSoundOrderer : EventSoundOrdererBase
	{
		private List<string> m_playedNameList = new List<string>(8); // 0x18

		// RVA: 0xD27AC8 Offset: 0xD27AC8 VA: 0xD27AC8 Slot: 6
		public override void InitializeAtomSource()
		{
			atomSource = SoundManager.Instance.sePlayerGame;
		}

		// RVA: 0xD27B04 Offset: 0xD27B04 VA: 0xD27B04 Slot: 8
		public override void PlaySoundByName(string name)
		{
			if(m_playedNameList.Contains(name))
				return;
			base.PlaySoundByName(name);
			m_playedNameList.Add(name);
		}

		// RVA: 0xD27BCC Offset: 0xD27BCC VA: 0xD27BCC
		//public void ClearPlayedList() { }
	}
}
