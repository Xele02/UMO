using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortParts_FilterRarity : PopupFilterSortPartsBase
	{
		private enum Btn
		{
			All = 0,
			One = 1,
			Two = 2,
			Three = 3,
			Four = 4,
			Five = 5,
			Six = 6,
			Seven = 7,
			Max = 8,
		}

		// Fields
		[SerializeField]
		private ToggleButton[] m_btn; // 0x1C
		[SerializeField]
		private RawImageEx[] m_btn_image; // 0x20
		[SerializeField]
		private Text[] m_btn_text; // 0x24
		private uint m_bit_btn; // 0x28

		// RVA: 0x1C8A114 Offset: 0x1C8A114 VA: 0x1C8A114 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			MessageBank bk =  MessageManager.Instance.GetBank("menu");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1C8A718
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					PushFilterButton(index, m_btn);
					m_bit_btn = GetFilterButtonBit(m_btn);
				});
			}
			m_btn_text[0].text = bk.GetMessageByLabel("popup_sort_filter_all");
			for(int i = 1; i < m_btn_text.Length; i++)
			{
				m_btn_text[i].text = bk.GetMessageByLabel(string.Format("popup_filter_rarity_{0:D2}", i));
			}
			Loaded();
			return true;
		}

		// // RVA: 0x1C8A474 Offset: 0x1C8A474 VA: 0x1C8A474
		public void SetBit(uint a_bit_rarity)
		{
			SetFilterButton(m_btn, a_bit_rarity);
			m_bit_btn = GetFilterButtonBit(m_btn);
		}

		// // RVA: 0x1C8A4A8 Offset: 0x1C8A4A8 VA: 0x1C8A4A8
		public uint GetBit()
		{
			return m_bit_btn;
		}

		// // RVA: 0x1C8A4B0 Offset: 0x1C8A4B0 VA: 0x1C8A4B0
		public void OnClickAllButton(int rarity)
		{
			m_btn[0].ClearOnClickCallback();
			m_btn[0].AddOnClickCallback(() =>
			{
				//0x1C8A814
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				RarityRestrictions(rarity);
				PushFilterButton(0, m_btn);
				m_bit_btn = GetFilterButtonBit(m_btn);
			});
		}

		// // RVA: 0x1C8A630 Offset: 0x1C8A630 VA: 0x1C8A630
		public void RarityRestrictions(int rarity)
		{
			if(rarity < 2)
				return;
			for(int i = 1; i < rarity; i++)
			{
				m_btn[i].SetOff();
				m_btn[i].Disable = true;
			}
		}
	}
}
