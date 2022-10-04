using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class ValkyrieSoundOrderer : EventSoundOrdererBase
	{
		public enum ShootType
		{
			Machinegun = 0,
			Beam = 1,
			Sniper = 2,
			SoundWave = 3,
		}
		
		private static readonly string[] s_shootTypeSe = new string[4] { "se_valkyrie_001", "se_valkyrie_005", "se_valkyrie_005", "se_valkyrie_003" }; // 0x0
		[SerializeField]
		private ShootType m_fighterShootType; // 0x18
		[SerializeField]
		private ShootType m_gerwalkShootType; // 0x1C
		[SerializeField]
		private ShootType m_battroidShootType; // 0x20
		private ShootType m_currentShootType; // 0x24
		public Dictionary<string, string> m_list_change_sound = new Dictionary<string, string>(); // 0x28

		private string shootSoundName { get { return s_shootTypeSe[(int)m_currentShootType]; } } //0xD2F4E4

		//// RVA: 0xD2F5AC Offset: 0xD2F5AC VA: 0xD2F5AC Slot: 6
		public override void InitializeAtomSource()
		{
			atomSource = SoundManager.Instance.sePlayerGame;
		}

		//// RVA: 0xD2F5E8 Offset: 0xD2F5E8 VA: 0xD2F5E8 Slot: 8
		//public override void PlaySoundByName(string name) { }

		//// RVA: 0xD2F694 Offset: 0xD2F694 VA: 0xD2F694
		public void SwitchToFighter()
		{
			m_currentShootType = m_fighterShootType;
		}

		//// RVA: 0xD2F6A0 Offset: 0xD2F6A0 VA: 0xD2F6A0
		public void SwitchToGerwalk()
		{
			m_currentShootType = m_gerwalkShootType;
		}

		//// RVA: 0xD2F6AC Offset: 0xD2F6AC VA: 0xD2F6AC
		public void SwitchToBattroid()
		{
			m_currentShootType = m_battroidShootType;
		}

		//// RVA: 0xD2F6B8 Offset: 0xD2F6B8 VA: 0xD2F6B8
		public void PlayShootSound()
		{
			PlaySoundByName(shootSoundName, true);
		}

		//// RVA: 0xD2F6E8 Offset: 0xD2F6E8 VA: 0xD2F6E8
		public void StopShootSound()
		{
			StopSoundByName(shootSoundName);
		}

		//// RVA: 0xD2F70C Offset: 0xD2F70C VA: 0xD2F70C
		//public void PauseShootSound() { }

		//// RVA: 0xD2F750 Offset: 0xD2F750 VA: 0xD2F750
		//public void ResumeShootSound() { }

		//// RVA: 0xD2F794 Offset: 0xD2F794 VA: 0xD2F794
		public bool IsSingleShot()
		{
			if (m_currentShootType == ShootType.Machinegun)
				return false;
			return m_currentShootType != ShootType.SoundWave;
		}
	}
}
