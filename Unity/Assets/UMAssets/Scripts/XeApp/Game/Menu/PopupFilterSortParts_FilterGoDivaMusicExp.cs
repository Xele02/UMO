using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortParts_FilterGoDivaMusicExp : PopupFilterSortPartsBase
	{
		private enum Btn
		{
			All = 0,
			Soul = 1,
			Voice = 2,
			Charm = 3,
		}

		[SerializeField]
		private ToggleButton[] m_btn; // 0x1C
		[SerializeField]
		private Text[] m_btn_text; // 0x20
		private uint m_bit; // 0x24

		// RVA: 0x1C89658 Offset: 0x1C89658 VA: 0x1C89658 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_btn_text[0].text = bk.GetMessageByLabel("popup_sort_filter_all");
			m_btn_text[1].text = bk.GetMessageByLabel("popup_filter_godiva_music_exp_item_soul");
			m_btn_text[2].text = bk.GetMessageByLabel("popup_filter_godiva_music_exp_item_voice");
			m_btn_text[3].text = bk.GetMessageByLabel("popup_filter_godiva_music_exp_item_charm");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int idx = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1C89A94
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
					PushFilterButton(idx, m_btn);
					m_bit = GetFilterButtonBit(m_btn);
				});
			}
			Loaded();
			return true;
		}

		// RVA: 0x1C89A70 Offset: 0x1C89A70 VA: 0x1C89A70
		public void SetBit(uint a_bit)
		{
			m_bit = a_bit;
			SetFilterButton(m_btn, a_bit);
		}

		// RVA: 0x1C89A84 Offset: 0x1C89A84 VA: 0x1C89A84
		public uint GetBit()
		{
			return m_bit;
		}
	}
}
