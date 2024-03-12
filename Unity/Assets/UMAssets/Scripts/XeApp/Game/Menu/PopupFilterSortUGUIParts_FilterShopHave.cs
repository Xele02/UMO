using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XeSys;
using System.Text;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterShopHave : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x10
		[SerializeField]
		private Image[] m_image; // 0x14
		[SerializeField]
		private Text[] m_text; // 0x18

		public override Type MyType { get { return Type.FilterRarity; } } //0x1797BEC

		// [IteratorStateMachineAttribute] // RVA: 0x7096CC Offset: 0x7096CC VA: 0x7096CC
		// RVA: 0x1797BF4 Offset: 0x1797BF4 VA: 0x1797BF4 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1797D50
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1797CC8
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
					PushFilterButtonsWithAllButton(index, m_btn);
				});
			}
			m_text[0].text = bk.GetMessageByLabel("popup_sort_filter_all");
			StringBuilder str = new StringBuilder();
			for(int i = 1; i < m_btn.Length; i++)
			{
				str.SetFormat("popup_filter_have_{0:D2}", i);
				m_text[i].text = bk.GetMessageByLabel(str.ToString());
			}
			yield break;
		}

		// // RVA: 0x1797CA0 Offset: 0x1797CA0 VA: 0x1797CA0
		public void SetBit(uint bitFlag)
		{
			SetFilterButtonsWithAllButton(m_btn, bitFlag);
		}

		// // RVA: 0x1797CAC Offset: 0x1797CAC VA: 0x1797CAC
		public uint GetBit()
		{
			return GetFilterButtonsBitWithAllButton(m_btn);
		}
	}
}
