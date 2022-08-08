using UnityEngine;
using XeApp.Game.Common;
using TMPro;
using System;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectMusicFilterButton : MonoBehaviour
	{
		public enum ButtonStatusType
		{
			FilterOff = 0,
			FilterOn = 1,
			Max = 2,
		}

		[SerializeField]
		private InOutAnime m_inOut; // 0xC
		[SerializeField]
		private UGUIButton m_button; // 0x10
		[SerializeField]
		private GameObject[] m_filterObj = new GameObject[2]; // 0x14
		[SerializeField]
		private TextMeshProUGUI[] m_sortText = new TextMeshProUGUI[2]; // 0x18
		private bool m_isEntered; // 0x1C

		public Action OnClickButtonListener { private get; set; } // 0x20

		// // RVA: 0xBE159C Offset: 0xBE159C VA: 0xBE159C
		private void Awake()
		{
			m_button.AddOnClickCallback(() =>
			{
				//0xBE1AA8
				if (OnClickButtonListener != null)
					OnClickButtonListener();
			});
		}

		// // RVA: 0xBE1644 Offset: 0xBE1644 VA: 0xBE1644
		// public void TryEnter() { }

		// // RVA: 0xBE168C Offset: 0xBE168C VA: 0xBE168C
		// public void TryLeave() { }

		// // RVA: 0xBE1654 Offset: 0xBE1654 VA: 0xBE1654
		public void Enter()
		{
			m_isEntered = true;
			m_inOut.ForceEnter(null);
		}

		// // RVA: 0xBE169C Offset: 0xBE169C VA: 0xBE169C
		// public void Leave() { }

		// // RVA: 0xBE16D4 Offset: 0xBE16D4 VA: 0xBE16D4
		// public void Show() { }

		// // RVA: 0xBE1720 Offset: 0xBE1720 VA: 0xBE1720
		// public void Hide() { }

		// // RVA: 0xBE1768 Offset: 0xBE1768 VA: 0xBE1768
		public bool IsPlaying()
		{
			return m_inOut.IsPlaying();
		}

		// // RVA: 0xBE1794 Offset: 0xBE1794 VA: 0xBE1794
		public void SetButtonStatus(VerticalMusicSelectMusicFilterButton.ButtonStatusType status)
		{
			for(int i = 0; i < m_filterObj.Length; i++)
			{
				m_filterObj[i].SetActive(false);
			}
			m_filterObj[(int)status].SetActive(true);
		}

		// // RVA: 0xBE1890 Offset: 0xBE1890 VA: 0xBE1890
		// public void SetButtonSortItem(SortItem sortIem) { }

		// // RVA: 0xBE19E4 Offset: 0xBE19E4 VA: 0xBE19E4
		public void SetButtonEnable(bool isEnable)
		{
			m_button.Disable = !isEnable;
		}
	}
}
