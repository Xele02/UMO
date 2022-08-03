using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelecChoiceMusicListTab : MonoBehaviour
	{
		public enum MusicTab
		{
			Normal = 0,
			Event = 1,
			Max = 2,
		}

		// [HeaderAttribute] // RVA: 0x6742A4 Offset: 0x6742A4 VA: 0x6742A4
		[SerializeField]
		private InOutAnime m_inOut; // 0xC
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x6742EC Offset: 0x6742EC VA: 0x6742EC
		private UGUIToggleObjectSwapButton m_toggle; // 0x10
		private bool m_isNormal; // 0x14

		public bool isNormal { get { return m_isNormal; } } //0xBDB454
		public Action<bool> OnButtonClickListener { private get; set; } // 0x18

		// // RVA: 0xBDB46C Offset: 0xBDB46C VA: 0xBDB46C
		public void Awake()
		{
			m_toggle.AddOnClickCallback(() =>
			{
				//0xBDB64C
				bool wasNormal = m_isNormal;
				m_isNormal = !m_isNormal;
				OnButtonClickListener(wasNormal == false);
			});
		}

		// // RVA: 0xBDB514 Offset: 0xBDB514 VA: 0xBDB514
		// public void SetToggleEnable(bool isEnable) { }

		// // RVA: 0xBDB548 Offset: 0xBDB548 VA: 0xBDB548
		// public void SetMusicListTab(VerticalMusicSelecChoiceMusicListTab.MusicTab musicTab) { }

		// // RVA: 0xBDB5B8 Offset: 0xBDB5B8 VA: 0xBDB5B8
		public void Enter()
		{
			m_inOut.ForceEnter(null);
		}

		// // RVA: 0xBDB5E8 Offset: 0xBDB5E8 VA: 0xBDB5E8
		// public void Leave() { }

		// // RVA: 0xBDB618 Offset: 0xBDB618 VA: 0xBDB618
		public bool IsPlaying()
		{
			return m_inOut.IsPlaying();
		}
	}
}
