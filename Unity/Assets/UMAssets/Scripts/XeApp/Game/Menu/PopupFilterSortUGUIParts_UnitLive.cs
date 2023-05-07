using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_UnitLive : PopupFilterSortUGUIPartsBase
	{
		private enum Btn
		{
			All = 0,
			Soro = 1,
			Dio = 2,
			Trio = 3,
			Quintet = 4,
		}

		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x10
		[SerializeField]
		private Text[] m_btn_text; // 0x14
		[SerializeField]
		private Image[] m_btn_image; // 0x18
		private uint m_bit; // 0x1C

		public override PopupFilterSortUGUIPartsBase.Type MyType { get { return PopupFilterSortUGUIPartsBase.Type.FilterSeries; } } // 0x179B7D4

		// [IteratorStateMachineAttribute] // RVA: 0x709F2C Offset: 0x709F2C VA: 0x709F2C
		// // RVA: 0x179B7DC Offset: 0x179B7DC VA: 0x179B7DC Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x179B984
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_btn_text[0].text = bk.GetMessageByLabel("popup_sort_filter_all");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x179B8B4
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					PushFilterButtonsWithAllButton(index, m_btn);
					m_bit = GetFilterButtonsBitWithAllButton(m_btn);
				});
			}
			if(!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.OANJBOPLCKP_IsUnit5Enabled())
			{
				m_btn[4].gameObject.SetActive(false);
			}
			yield break;
		}

		// // RVA: 0x179B888 Offset: 0x179B888 VA: 0x179B888
		public void SetBit(uint a_bit)
		{
			m_bit = a_bit;
			SetFilterButtonsWithAllButton(m_btn, a_bit);
		}

		// // RVA: 0x179B898 Offset: 0x179B898 VA: 0x179B898
		public uint GetBit()
		{
			return GetFilterButtonsBitWithAllButton(m_btn);
		}
	}
}
