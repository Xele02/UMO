using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XeSys;
using System.Linq;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterGoDivaMusicExp : PopupFilterSortUGUIPartsBase
	{
		private enum Btn
		{
			All = 0,
			Soul = 1,
			Voice = 2,
			Charm = 3,
		}

		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x10
		[SerializeField]
		private Text[] m_btn_text; // 0x14
		private uint m_bit; // 0x18

		public override Type MyType { get { return Type.FilterGoDivaMusicExp; } } //0x1CA0D84

		// [IteratorStateMachineAttribute] // RVA: 0x708A84 Offset: 0x708A84 VA: 0x708A84
		// RVA: 0x1CA0D8C Offset: 0x1CA0D8C VA: 0x1CA0D8C Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1CA0F14
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
					//0x1CA0E50
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
					PushFilterButtonsWithAllButton(idx, m_btn);
					m_bit = GetFilterButtonsBitWithAllButton(m_btn);
				});
			}
			yield break;
		}

		// RVA: 0x1C994C8 Offset: 0x1C994C8 VA: 0x1C994C8
		public void SetBit(uint a_bit)
		{
			m_bit = a_bit;
			SetFilterButtonsWithAllButton(m_btn, a_bit);
		}

		// RVA: 0x1C99590 Offset: 0x1C99590 VA: 0x1C99590
		public uint GetBit()
		{
			return m_bit;
		}
	}
}
