using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterReward : PopupFilterSortUGUIPartsBase
	{
		private enum Btn
		{
			All = 0,
			Score = 1,
			Combo = 2,
			Clear = 3,
		}

		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x10
		[SerializeField]
		private Text[] m_btn_text; // 0x14
		private uint m_bit; // 0x18

		public override PopupFilterSortUGUIPartsBase.Type MyType { get { return PopupFilterSortUGUIPartsBase.Type.FilterReward; } } // 0x179645C

		// [IteratorStateMachineAttribute] // RVA: 0x70953C Offset: 0x70953C VA: 0x70953C
		// RVA: 0x1796464 Offset: 0x1796464 VA: 0x1796464 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x179660C
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_btn_text[0].text = bk.GetMessageByLabel("popup_filter_unspecified");
			m_btn_text[1].text = bk.GetMessageByLabel("popup_filter_reward_score");
			m_btn_text[2].text = bk.GetMessageByLabel("popup_filter_reward_combo");
			m_btn_text[3].text = bk.GetMessageByLabel("popup_filter_reward_clear");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x179653C
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					PushFilterButtonsWithAllButton(index, m_btn);
					m_bit = GetFilterButtonsBitWithAllButton(m_btn);
				});
			}
			yield break;
		}

		// // RVA: 0x1796510 Offset: 0x1796510 VA: 0x1796510
		public void SetBit(uint a_bit)
		{
			m_bit = a_bit;
			SetFilterButtonsWithAllButton(m_btn, a_bit);
		}

		// // RVA: 0x1796520 Offset: 0x1796520 VA: 0x1796520
		public uint GetBit()
		{
			return GetFilterButtonsBitWithAllButton(m_btn);
		}
	}
}
