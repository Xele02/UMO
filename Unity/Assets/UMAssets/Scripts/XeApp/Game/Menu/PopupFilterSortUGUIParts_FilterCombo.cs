using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterCombo : PopupFilterSortUGUIPartsBase
	{
		private enum Btn
		{
			All = 0,
			FullCombo = 1,
			PrefectFullCombo = 2,
		}

		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x10
		[SerializeField]
		private Text[] m_btn_text; // 0x14
		private uint m_bit; // 0x18

		public override PopupFilterSortUGUIPartsBase.Type MyType { get { return PopupFilterSortUGUIPartsBase.Type.FilterComb; } } // 0x1CA03EC

		// [IteratorStateMachineAttribute] // RVA: 0x7088F4 Offset: 0x7088F4 VA: 0x7088F4
		// RVA: 0x1CA03F4 Offset: 0x1CA03F4 VA: 0x1CA03F4 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1CA057C
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_btn_text[0].text = bk.GetMessageByLabel("popup_filter_unspecified");
			m_btn_text[1].text = bk.GetMessageByLabel("popup_filter_fullcombo");
			m_btn_text[2].text = bk.GetMessageByLabel("popup_filter_prefect_fullcombo");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1CA04B8
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					PushFilterButtonsWithAllButton(index, m_btn);
					m_bit = GetFilterButtonsBitWithAllButton(m_btn);
				});
			}
			yield break;
		}

		// // RVA: 0x1C994B8 Offset: 0x1C994B8 VA: 0x1C994B8
		public void SetBit(uint a_bit)
		{
			m_bit = a_bit;
			SetFilterButtonsWithAllButton(m_btn, a_bit);
		}

		// // RVA: 0x1C99588 Offset: 0x1C99588 VA: 0x1C99588
		public uint GetBit()
		{
			return GetFilterButtonsBitWithAllButton(m_btn);
		}
	}
}
