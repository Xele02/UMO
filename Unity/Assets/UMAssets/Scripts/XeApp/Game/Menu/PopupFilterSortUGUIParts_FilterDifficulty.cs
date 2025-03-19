using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterDifficulty : PopupFilterSortUGUIPartsBase
	{
		private enum Btn
		{
			All = 0,
			Easy = 1,
			Normal = 2,
			Hard = 3,
			VeryHard = 4,
			Extreme = 5,
		}

		[SerializeField]
		private UGUIToggleButtonGroup m_btnGroup; // 0x10
		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x14
		[SerializeField]
		private Text[] m_btn_text; // 0x18
		private uint m_bit; // 0x1C

		public override Type MyType { get { return Type.FilterComb; } } //0x1CA098C

		// [IteratorStateMachineAttribute] // RVA: 0x7089BC Offset: 0x7089BC VA: 0x7089BC
		// RVA: 0x1CA0994 Offset: 0x1CA0994 VA: 0x1CA0994 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1CA0B1C
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int idx = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1CA0A58
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
					PushFilterButtonsWithAllButton(idx, m_btn);
					m_bit = GetFilterButtonsBitWithAllButton(m_btn);
				});
			}
			yield break;
		}

		// RVA: 0x1C98E78 Offset: 0x1C98E78 VA: 0x1C98E78
		public void SetItem(bool is6Line)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(!is6Line)
			{
				m_btn_text[0].text = bk.GetMessageByLabel("popup_filter_difficulty_easy");
				m_btn_text[1].text = bk.GetMessageByLabel("popup_filter_difficulty_normal");
				m_btn_text[2].text = bk.GetMessageByLabel("popup_filter_difficulty_hard");
				m_btn_text[3].text = bk.GetMessageByLabel("popup_filter_difficulty_veryhard");
				m_btn_text[4].text = bk.GetMessageByLabel("popup_filter_difficulty_extreme");
			}
			else
			{
				m_btn_text[2].text = bk.GetMessageByLabel("popup_filter_difficulty_6line_hard");
				m_btn_text[3].text = bk.GetMessageByLabel("popup_filter_difficulty_6line_veryhard");
				m_btn_text[4].text = bk.GetMessageByLabel("popup_filter_difficulty_6line_extreme");
			}
			for(int i = 0; i < m_btn.Length; i++)
			{
				m_btn[i].Hidden = i < (is6Line ? 2 : 0);
			}
		}

		// RVA: 0x1C99400 Offset: 0x1C99400 VA: 0x1C99400
		public void SetDifficulty(Difficulty.Type diff)
		{
			for(int i = 0; i < m_btn.Length; i++)
			{
				if((int)diff == i)
				{
					m_btn[i].SetOn();
				}
				else
				{
					m_btn[i].SetOff();
				}
			}
		}

		// // RVA: 0x1C994D8 Offset: 0x1C994D8 VA: 0x1C994D8
		public int GetDifficulty()
		{
			int res = 0;
			for(int i = 0; i < m_btn.Length; i++)
			{
				if(m_btn[i].IsOn)
					res = i;
			}
			return res;
		}
	}
}
