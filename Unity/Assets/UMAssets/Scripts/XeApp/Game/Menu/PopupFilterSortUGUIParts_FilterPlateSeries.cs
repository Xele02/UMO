using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;
using System.Collections;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterPlateSeries : PopupFilterSortUGUIPartsBase
	{
		private enum Btn
		{
			All = 0,
			First = 1,
			Seven = 2,
			Frontia = 3,
			Delta = 4,
			Other = 5,
			Max = 6,
		}

		private class Bind
		{
			public int m_series; // 0x8
			public int m_btn; // 0xC
		}

		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x10
		[SerializeField]
		private RawImageEx[] m_image; // 0x14
		[SerializeField]
		private Text[] m_text; // 0x18
		private uint m_bit_btn; // 0x1C
		private Bind[] m_bind_tbl = new Bind[5]
		{
			new Bind() { m_series = 4, m_btn = 1 },
			new Bind() { m_series = 3, m_btn = 2 },
			new Bind() { m_series = 2, m_btn = 3 },
			new Bind() { m_series = 1, m_btn = 4 },
			new Bind() { m_series = 5, m_btn = 5 }
		}; // 0x20

		public override Type MyType { get { return Type.FilterSeries; } } //0x1CA4B28

		// [IteratorStateMachineAttribute] // RVA: 0x70919C Offset: 0x70919C VA: 0x70919C
		// RVA: 0x1CA4B30 Offset: 0x1CA4B30 VA: 0x1CA4B30 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1CA5428
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1CA512C
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					PushFilterButtonsWithAllButton(index, m_btn);
					m_bit_btn = GetFilterButtonsBitWithAllButton(m_btn);
				});
			}
			m_text[0].text = bk.GetMessageByLabel("popup_sort_filter_all");
			for(int i = 1; i < m_image.Length; i++)
			{
				int t_btn_index = i;
				m_image[i].enabled = false;
				GameManager.Instance.MenuResidentTextureCache.LoadLogo((4 - (i - 1)) > 0 ? (4 - (i - 1)) : 11, (IiconTexture texture) =>
				{
					//0x1CA51F4
					if(m_image[t_btn_index] != null)
					{
						m_image[t_btn_index].enabled = true;
						texture.Set(m_image[t_btn_index]);
					}
				});
			}
			yield break;
		}

		// // RVA: 0x1C9AC68 Offset: 0x1C9AC68 VA: 0x1C9AC68
		public void SetBit(uint bitFlag)
		{
			m_bit_btn = ConvertBit_SeriesToBtn(bitFlag);
			SetFilterButtonsWithAllButton(m_btn, m_bit_btn);
		}

		// // RVA: 0x1C9C524 Offset: 0x1C9C524 VA: 0x1C9C524
		public uint GetBit()
		{
			return ConvertBit_BtnToSeries(m_bit_btn);
		}

		// // RVA: 0x1CA4BDC Offset: 0x1CA4BDC VA: 0x1CA4BDC
		private uint ConvertBit_SeriesToBtn(uint a_bit_series)
		{
			uint res = 0;
			for(int i = 0; i < m_bind_tbl.Length; i++)
			{
				if((a_bit_series & (1 << m_bind_tbl[i].m_series - 1)) != 0)
					res |= (uint)(1 << (m_bind_tbl[i].m_btn - 1));
			}
			return res;
		}

		// // RVA: 0x1CA4C90 Offset: 0x1CA4C90 VA: 0x1CA4C90
		private uint ConvertBit_BtnToSeries(uint a_bit_btn)
		{
			uint res = 0;
			for(int i = 0; i < m_bind_tbl.Length; i++)
			{
				if((a_bit_btn & (1 << m_bind_tbl[i].m_btn - 1)) != 0)
					res |= (uint)(1 << (m_bind_tbl[i].m_series - 1));
			}
			return res;
		}
	}
}
