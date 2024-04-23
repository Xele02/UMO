using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class MusicSelectMusicFilterButton : MonoBehaviour
	{
		public enum ButtonStatusType
		{
			FilterOff = 0,
			FilterOn = 1,
		}

		[SerializeField]
		private InOutAnime m_inOut; // 0xC
		[SerializeField]
		private UGUIButton m_button; // 0x10
		[SerializeField]
		private Image m_buttonImage; // 0x14
		[SerializeField]
		private Sprite m_spriteFilterOff; // 0x18
		[SerializeField]
		private Sprite m_spriteFilterOn; // 0x1C
		// private bool m_isEntered; // 0x20

		public Action OnClickButtonListener { private get; set; } // 0x24

		// // RVA: 0x1678FD0 Offset: 0x1678FD0 VA: 0x1678FD0
		private void Awake()
		{
			m_button.AddOnClickCallback(() => {
				//0x16792BC
				TodoLogger.LogNotImplemented("MusicSelectMusicFilterButton Click");
			});
		}

		// // RVA: 0x167915C Offset: 0x167915C VA: 0x167915C
		// public void TryEnter() { }

		// // RVA: 0x16791A8 Offset: 0x16791A8 VA: 0x16791A8
		public void TryLeave()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "MusicSelectMusicFilterButton TryLeave");
		}

		// // RVA: 0x167916C Offset: 0x167916C VA: 0x167916C
		public void Enter()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "MusicSelectMusicFilterButton Enter");
		}

		// // RVA: 0x16791B8 Offset: 0x16791B8 VA: 0x16791B8
		// public void Leave() { }

		// // RVA: 0x16791F4 Offset: 0x16791F4 VA: 0x16791F4
		// public void Show() { }

		// // RVA: 0x1679240 Offset: 0x1679240 VA: 0x1679240
		public void Hide()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "MusicSelectMusicFilterButton Hide");
		}

		// // RVA: 0x1679288 Offset: 0x1679288 VA: 0x1679288
		public bool IsPlaying()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "MusicSelectMusicFilterButton IsPlaying");
			return false;
		}

		// // RVA: 0x1679084 Offset: 0x1679084 VA: 0x1679084
		public void SetButtonStatus(MusicSelectMusicFilterButton.ButtonStatusType status)
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "MusicSelectMusicFilterButton SetButtonStatus");
		}
	}
}
