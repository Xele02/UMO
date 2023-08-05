using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterMusicLock : PopupFilterSortUGUIPartsBase
	{
		private enum Btn
		{
			All = 0,
			MusicLock = 1,
			MusicUnLock = 2,
		}

		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x10
		[SerializeField]
		private Text[] m_btn_text; // 0x14
		private uint m_bit; // 0x18

		public override PopupFilterSortUGUIPartsBase.Type MyType { get { return PopupFilterSortUGUIPartsBase.Type.FilterMusicLock; } } // 0x1CA1D70

		// [IteratorStateMachineAttribute] // RVA: 0x708CDC Offset: 0x708CDC VA: 0x708CDC
		// // RVA: 0x1CA1D78 Offset: 0x1CA1D78 VA: 0x1CA1D78 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1CA1F00
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_btn_text[0].text = bk.GetMessageByLabel("popup_sort_filter_all");
			m_btn_text[1].text = bk.GetMessageByLabel("popup_sort_filter_musiclock");
			m_btn_text[2].text = bk.GetMessageByLabel("popup_sort_filter_musicunlock");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1CA1E3C
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					PushFilterButtonsWithAllButton(index, m_btn);
					m_bit = GetFilterButtonsBitWithAllButton(m_btn);
				});
			}
			yield break;
		}

		// // RVA: 0x1C9DD58 Offset: 0x1C9DD58 VA: 0x1C9DD58
		public void SetBit(uint a_bit)
		{
			m_bit = a_bit;
			SetFilterButtonsWithAllButton(m_btn, a_bit);
		}

		// // RVA: 0x1C9DD94 Offset: 0x1C9DD94 VA: 0x1C9DD94
		public uint GetBit()
		{
			return GetFilterButtonsBitWithAllButton(m_btn);
		}
	}
}
