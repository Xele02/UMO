using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;
using System.Collections;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterPlateNotes : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x10
		[SerializeField]
		private RawImageEx[] m_image; // 0x14
		[SerializeField]
		private Text[] m_text; // 0x18

		public override Type MyType { get { return Type.FilterSkill; } } //0x1CA4128

		// [IteratorStateMachineAttribute] // RVA: 0x70900C Offset: 0x70900C VA: 0x70900C
		// RVA: 0x1CA4130 Offset: 0x1CA4130 VA: 0x1CA4130 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1CA4278
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1CA41F4
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					PushFilterButtonsWithAllButton(index, m_btn);
				});
			}
			m_text[0].text = bk.GetMessageByLabel("popup_sort_filter_all");
			yield return null;
		}

		// // RVA: 0x1C9AC8C Offset: 0x1C9AC8C VA: 0x1C9AC8C
		public void SetBit(uint bitFlag)
		{
			SetFilterButtonsWithAllButton(m_btn, bitFlag);
		}

		// // RVA: 0x1C9C52C Offset: 0x1C9C52C VA: 0x1C9C52C
		public uint GetBit()
		{
			return GetFilterButtonsBitWithAllButton(m_btn);
		}
	}
}
