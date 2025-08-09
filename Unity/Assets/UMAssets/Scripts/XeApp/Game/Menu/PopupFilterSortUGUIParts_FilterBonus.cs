using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XeSys;

namespace XeApp.Game.Menu
{
	//[AddComponentMenu("XeApp/Game/Menu/PopupFilterSortUGUIParts_FilterBonus")] // RVA: 0x6476C0 Offset: 0x6476C0 VA: 0x6476C0
	public class PopupFilterSortUGUIParts_FilterBonus : PopupFilterSortUGUIPartsBase
	{
		private enum Btn
		{
			All = 0,
			BonusOk = 1,
			BonusNotOk = 2,
		}

		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x10
		[SerializeField]
		private Text[] m_btn_text; // 0x14
		private uint m_bit; // 0x18

		public override Type MyType { get { return Type.FilterBonus; } } //0x1C9FE4C

		// [IteratorStateMachineAttribute] // RVA: 0x70882C Offset: 0x70882C VA: 0x70882C
		// RVA: 0x1C9FE54 Offset: 0x1C9FE54 VA: 0x1C9FE54 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1C9FFDC
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_btn_text[0].text = bk.GetMessageByLabel("popup_sort_filter_all");
			m_btn_text[1].text = bk.GetMessageByLabel("popup_filter_bonus_ok");
			m_btn_text[2].text = bk.GetMessageByLabel("popup_filter_bonus_not_ok");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1C9FF18
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
					PushFilterButtonsWithAllButton(index, m_btn);
					m_bit = GetFilterButtonsBitWithAllButton(m_btn);
				});
			}
			yield break;
		}

		// RVA: 0x1C99C14 Offset: 0x1C99C14 VA: 0x1C99C14
		public void SetBit(uint a_bit)
		{
			m_bit = a_bit;
			SetFilterButtonsWithAllButton(m_btn, a_bit);
		}

		// RVA: 0x1C99C2C Offset: 0x1C99C2C VA: 0x1C99C2C
		public uint GetBit()
		{
			return GetFilterButtonsBitWithAllButton(m_btn);
		}
	}
}
