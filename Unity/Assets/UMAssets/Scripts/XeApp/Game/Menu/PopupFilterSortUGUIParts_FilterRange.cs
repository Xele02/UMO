using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterRange : PopupFilterSortUGUIPartsBase
	{
		private enum Btn
		{
			All = 0,
			Long = 1,
			Short = 2,
		}

		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x10
		[SerializeField]
		private Text[] m_btn_text; // 0x14
		private uint m_bit; // 0x18

		public override PopupFilterSortUGUIPartsBase.Type MyType { get; } // 0x1795E9C

		// [IteratorStateMachineAttribute] // RVA: 0x709474 Offset: 0x709474 VA: 0x709474
		// // RVA: 0x1795EA4 Offset: 0x1795EA4 VA: 0x1795EA4 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x179604C
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_btn_text[0].text = bk.GetMessageByLabel("popup_sort_filter_all");
			m_btn_text[1].text = bk.GetMessageByLabel("popup_sort_filter_range_long");
			m_btn_text[2].text = bk.GetMessageByLabel("popup_sort_filter_range_short");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1795F7C
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					PushFilterButtonsWithAllButton(index, m_btn);
					m_bit = GetFilterButtonsBitWithAllButton(m_btn);
				});
			}
			yield break;
		}

		// // RVA: 0x1795F50 Offset: 0x1795F50 VA: 0x1795F50
		public void SetBit(uint a_bit)
		{
			m_bit = a_bit;
			SetFilterButtonsWithAllButton(m_btn, a_bit);
		}

		// // RVA: 0x1795F60 Offset: 0x1795F60 VA: 0x1795F60
		public uint GetBit()
		{
			return GetFilterButtonsBitWithAllButton(m_btn);
		}
	}
}
