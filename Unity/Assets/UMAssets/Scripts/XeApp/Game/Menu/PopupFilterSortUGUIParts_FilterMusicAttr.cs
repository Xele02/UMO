using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XeSys;
using System.Text;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterMusicAttr : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x10
		[SerializeField]
		private Image[] m_image; // 0x14
		[SerializeField]
		private Text[] m_text; // 0x18

		public override PopupFilterSortUGUIPartsBase.Type MyType { get { return PopupFilterSortUGUIPartsBase.Type.FilterMusicAttr; } }

		// [IteratorStateMachineAttribute] // RVA: 0x708B4C Offset: 0x708B4C VA: 0x708B4C
		// RVA: 0x1CA13C4 Offset: 0x1CA13C4 VA: 0x1CA13C4 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1CA150C
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1CA1488
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					PushFilterButtonsWithAllButton(index, m_btn);
				});
			}
			m_text[0].text = bk.GetMessageByLabel("popup_sort_filter_all");
			StringBuilder str = new StringBuilder();
			for(int i = 1; i < m_btn.Length; i++)
			{
				str.SetFormat("popup_filter_music_attribute_{0:D3}", i);
				m_text[i].text = bk.GetMessageByLabel(str.ToString());
			}
			yield break;
		}

		// // RVA: 0x1C994B0 Offset: 0x1C994B0 VA: 0x1C994B0
		public void SetBit(uint bitFlag)
		{
			SetFilterButtonsWithAllButton(m_btn, bitFlag);
		}

		// // RVA: 0x1C99580 Offset: 0x1C99580 VA: 0x1C99580
		public uint GetBit()
		{
			return GetFilterButtonsBitWithAllButton(m_btn);
		}
	}
}
