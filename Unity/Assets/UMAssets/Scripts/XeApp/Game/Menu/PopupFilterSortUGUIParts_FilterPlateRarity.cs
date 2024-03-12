using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections;
using XeSys;
using System.Text;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterPlateRarity : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private GameObject[] m_btnRoot; // 0x10
		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x14
		[SerializeField]
		private Image[] m_image; // 0x18
		[SerializeField]
		private Text[] m_text; // 0x1C

		public override Type MyType { get { return Type.FilterRarity; } } //0x1CA45A4

		// [IteratorStateMachineAttribute] // RVA: 0x7090D4 Offset: 0x7090D4 VA: 0x7090D4
		// RVA: 0x1CA45AC Offset: 0x1CA45AC VA: 0x1CA45AC Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1CA46F4
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1CA4670
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					PushFilterButtonsWithAllButton(index, m_btn);
				});
			}
			m_text[0].text = bk.GetMessageByLabel("popup_sort_filter_all");
			StringBuilder str = new StringBuilder();
			for(int i = 1; i < m_btn.Length; i++)
			{
				str.SetFormat("popup_filter_rarity_{0:D2}", i);
				m_text[i].text = bk.GetMessageByLabel(str.ToString());
			}
			yield break;
		}

		// // RVA: 0x1C9AC60 Offset: 0x1C9AC60 VA: 0x1C9AC60
		public void SetBit(uint bitFlag)
		{
			SetFilterButtonsWithAllButton(m_btn, bitFlag);
		}

		// // RVA: 0x1C9C51C Offset: 0x1C9C51C VA: 0x1C9C51C
		public uint GetBit()
		{
			return GetFilterButtonsBitWithAllButton(m_btn);
		}

		// // RVA: 0x1C9D680 Offset: 0x1C9D680 VA: 0x1C9D680
		public void SetRarity(uint bitFlag)
		{
			for(int i = 0; i < m_btnRoot.Length; i++)
			{
				m_btnRoot[i].gameObject.SetActive((bitFlag & (1 << i)) != 0);
			}
		}
	}
}
