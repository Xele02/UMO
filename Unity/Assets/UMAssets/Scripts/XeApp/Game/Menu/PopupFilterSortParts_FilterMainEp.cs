using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortParts_FilterMainEp : PopupFilterSortPartsBase
	{
		private enum Btn
		{
			All = 0,
			Lock = 1,
			Unlock = 2,
			Plate = 3,
		}

		[SerializeField]
		private ToggleButton[] m_btn; // 0x1C
		[SerializeField]
		private Text[] m_btn_text; // 0x20
		private uint m_bit; // 0x24

		// RVA: 0x1C89B90 Offset: 0x1C89B90 VA: 0x1C89B90 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_btn_text[0].text = bk.GetMessageByLabel("popup_sort_filter_all");
			m_btn_text[1].text = bk.GetMessageByLabel("popup_filter_mainep_item_lock");
			m_btn_text[2].text = bk.GetMessageByLabel("popup_filter_mainep_item_unlock");
			m_btn_text[3].text = bk.GetMessageByLabel("popup_filter_mainep_item_enable_unlock");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1C8A018
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					PushFilterButton(index, m_btn);
					m_bit = GetFilterButtonBit(m_btn);
				});
			}
			Loaded();
			return true;
		}

		// // RVA: 0x1C89FA8 Offset: 0x1C89FA8 VA: 0x1C89FA8
		public void SetBit(uint a_bit)
		{
			m_bit = a_bit;
			SetFilterButton(m_btn, a_bit);
		}

		// // RVA: 0x1C89FBC Offset: 0x1C89FBC VA: 0x1C89FBC
		public uint GetBit()
		{
			return m_bit;
		}

		// // RVA: 0x1C89FC4 Offset: 0x1C89FC4 VA: 0x1C89FC4
		// public static uint CreateBit(PIGBBNDPPJC a_view) { }
	}
}
