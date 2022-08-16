using UnityEngine;
using XeApp.Game.Common;
using TMPro;
using System;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelctSimulationButton : MonoBehaviour
	{
		public enum ButtonState // TypeDefIndex: 13284
		{
			Open = 0,
			Lock = 1,
			Disable = 2,
			Hidden = 3,
		}

		// [HeaderAttribute] // RVA: 0x6741E4 Offset: 0x6741E4 VA: 0x6741E4
		[SerializeField]
		private UGUIButton m_button; // 0xC
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x67422C Offset: 0x67422C VA: 0x67422C
		private InOutAnime m_inOut; // 0x10
		[SerializeField]
		private TextMeshProUGUI m_tokenText; // 0x14
		[SerializeField]
		private GameObject m_lockObj; // 0x18

		public Action<bool> OnClickButtonListener { private get; set; } // 0x1C

		// // RVA: 0xBDB08C Offset: 0xBDB08C VA: 0xBDB08C
		private void Awake()
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() => {
				//0xBDB3E4
				if(OnClickButtonListener != null)
					OnClickButtonListener(true);
			});
		}

		// // RVA: 0xBDB154 Offset: 0xBDB154 VA: 0xBDB154
		public void SetTicketNum(int num)
		{
			m_tokenText.text = "" + num;
		}

		// // RVA: 0xBDB1A0 Offset: 0xBDB1A0 VA: 0xBDB1A0
		public void SetButtonState(VerticalMusicSelctSimulationButton.ButtonState state)
		{
			if(state == ButtonState.Disable)
			{
				m_button.Disable = true;
				m_lockObj.SetActive(false);
			}
			else if(state == ButtonState.Lock)
			{
				m_button.Disable = false;
				m_lockObj.SetActive(true);
			}
			else if(state == ButtonState.Open)
			{
				m_button.Disable = false;
				m_lockObj.SetActive(false);
			}
		}

		// // RVA: 0xBDB274 Offset: 0xBDB274 VA: 0xBDB274
		public void SetEnable(bool isEneble)
		{
			if(!isEneble)
			{
				m_inOut.ForceEnter(0, null);
			}
			gameObject.SetActive(isEneble);
		}

		// // RVA: 0xBDB2E8 Offset: 0xBDB2E8 VA: 0xBDB2E8
		public void SetInputEnable(bool isEnable)
		{
			m_button.IsInputOff = !isEnable;
		}

		// // RVA: 0xBDB31C Offset: 0xBDB31C VA: 0xBDB31C
		public void Enter()
		{
			m_inOut.ForceEnter(null);
		}

		// // RVA: 0xBDB34C Offset: 0xBDB34C VA: 0xBDB34C
		// public void Leave() { }

		// // RVA: 0xBDB3B0 Offset: 0xBDB3B0 VA: 0xBDB3B0
		public bool IsPlaying()
		{
			return m_inOut.IsPlaying();
		}
	}
}
