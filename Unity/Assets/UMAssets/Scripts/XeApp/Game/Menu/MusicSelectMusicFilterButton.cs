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
		private bool m_isEntered; // 0x20

		public Action OnClickButtonListener { private get; set; } // 0x24

		// // RVA: 0x1678FD0 Offset: 0x1678FD0 VA: 0x1678FD0
		private void Awake()
		{
			m_button.AddOnClickCallback(() => {
				//0x16792BC
				if(OnClickButtonListener != null)
					OnClickButtonListener();
			});
		}

		// // RVA: 0x167915C Offset: 0x167915C VA: 0x167915C
		public void TryEnter()
		{
			if(!m_isEntered)
				Enter();
		}

		// // RVA: 0x16791A8 Offset: 0x16791A8 VA: 0x16791A8
		public void TryLeave()
		{
			if(m_isEntered)
				Leave();
		}

		// // RVA: 0x167916C Offset: 0x167916C VA: 0x167916C
		public void Enter()
		{
			m_isEntered = true;
			m_inOut.Enter(false, null);
		}

		// // RVA: 0x16791B8 Offset: 0x16791B8 VA: 0x16791B8
		public void Leave()
		{
			m_isEntered = false;
			m_inOut.Leave(false, null);
		}

		// // RVA: 0x16791F4 Offset: 0x16791F4 VA: 0x16791F4
		// public void Show() { }

		// // RVA: 0x1679240 Offset: 0x1679240 VA: 0x1679240
		public void Hide()
		{
			m_isEntered = false;
			m_inOut.Leave(0, false);
		}

		// // RVA: 0x1679288 Offset: 0x1679288 VA: 0x1679288
		public bool IsPlaying()
		{
			return m_inOut.IsPlaying();
		}

		// // RVA: 0x1679084 Offset: 0x1679084 VA: 0x1679084
		public void SetButtonStatus(ButtonStatusType status)
		{
			if(status == ButtonStatusType.FilterOn)
			{
				m_buttonImage.sprite = m_spriteFilterOn;
			}
			else if(status == ButtonStatusType.FilterOff)
			{
				m_buttonImage.sprite = m_spriteFilterOff;
			}
		}
	}
}
