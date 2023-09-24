using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortParts_FilterDiva : PopupFilterSortPartsBase
	{
		public enum ButtonType
		{
			Multi = 0,
			Single = 1,
		}

		public enum WindowType
		{
			Large = 0,
			Middle = 1,
		}

		private enum Btn
		{
			All = 0,
			Diva01 = 1,
			Diva02 = 2,
			Diva03 = 3,
			Diva04 = 4,
			Diva05 = 5,
			Diva06 = 6,
			Diva07 = 7,
			Diva08 = 8,
			Diva09 = 9,
			Diva10 = 10,
			Val = 11,
			Max = 12,
		}

		private class Bind
		{
			public int m_diva_id; // 0x8
			public int m_btn; // 0xC
		}

		[SerializeField]
		private ToggleButton[] m_btn; // 0x1C
		[SerializeField]
		private RawImageEx[] m_btn_image; // 0x20
		[SerializeField]
		private Text[] m_btn_text; // 0x24
		private List<int> m_list_diva_id = new List<int>(); // 0x28
		private uint m_bit_btn; // 0x2C
		private ButtonType m_btn_type; // 0x30
		private WindowType m_wind_type; // 0x34
		private AbsoluteLayout m_anim; // 0x38
		public Action OnChangeFilter; // 0x3C
		private Bind[] m_bind_tbl = new Bind[11]
			{
				new Bind() { m_btn = 1, m_diva_id  = 1 },
				new Bind() { m_btn = 2, m_diva_id  = 2 },
				new Bind() { m_btn = 3, m_diva_id  = 3 },
				new Bind() { m_btn = 4, m_diva_id  = 4 },
				new Bind() { m_btn = 5, m_diva_id  = 5 },
				new Bind() { m_btn = 6, m_diva_id  = 6 },
				new Bind() { m_btn = 7, m_diva_id  = 7 },
				new Bind() { m_btn = 8, m_diva_id  = 8 },
				new Bind() { m_btn = 9, m_diva_id  = 9 },
				new Bind() { m_btn = 10, m_diva_id  = 10 },
				new Bind() { m_btn = 11, m_diva_id  = 11 }
			}; // 0x40

		// RVA: 0xF956C0 Offset: 0xF956C0 VA: 0xF956C0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_anim = layout.FindViewByExId("root_cmn_sort_filter_diva_filter_compatibility") as AbsoluteLayout;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_btn_text[0].text = bk.GetMessageByLabel("popup_sort_filter_all");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int t_index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1C87470
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					if(m_btn_type == ButtonType.Single)
					{
						PushFilterButtonSingle(t_index, m_btn);
					}
					else
					{
						PushFilterButton(t_index, m_btn);
					}
					m_bit_btn = GetFilterButtonBit(m_btn);
					if (OnChangeFilter != null)
						OnChangeFilter();
				});
			}
			Loaded();
			return true;
		}

		//// RVA: 0xF93858 Offset: 0xF93858 VA: 0xF93858
		public void Initialize(List<FFHPBEPOMAK_DivaInfo> a_view_diva, bool a_is_val, ButtonType a_btn_type = 0, WindowType a_wind_type = 0, bool a_is_has_only = false)
		{
			m_btn_type = a_btn_type;
			m_btn[0].Hidden = a_btn_type == ButtonType.Single;
			m_wind_type = a_wind_type;
			m_anim.StartAllAnimGoStop(a_wind_type == WindowType.Middle ? "02" : "01");
			m_list_diva_id.Clear();
			for(int i = 0; i < a_view_diva.Count; i++)
			{
				if(!a_is_has_only || a_view_diva[i].FJODMPGPDDD)
				{
					m_bind_tbl[m_list_diva_id.Count].m_diva_id = a_view_diva[i].AHHJLDLAPAN_DivaId;
					m_list_diva_id.Add(a_view_diva[i].AHHJLDLAPAN_DivaId);
				}
			}
			for(int i = 1; i < m_btn_image.Length; i++)
			{
				int t_index_img = i;
				if(i - 1 < m_list_diva_id.Count)
				{
					GameManager.Instance.DivaIconCache.SetLoadingIcon(m_btn_image[t_index_img]);
					int divaId = m_list_diva_id[i - 1];
					int cos = 1;
					int col = 0;
					if (a_is_has_only)
					{
						FFHPBEPOMAK_DivaInfo d = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas.Find((FFHPBEPOMAK_DivaInfo _) =>
						{
							//0x1C877E4
							return _.AHHJLDLAPAN_DivaId == divaId;
						});
						if(d != null)
						{
							cos = d.EGAFMGDFFCH_HomeDivaCostume.DAJGPBLEEOB_PrismCostumeId;
							col = d.JFFLFIMIMOI_HomeColorId;
						}
					}
					GameManager.Instance.DivaIconCache.Load(divaId, cos, col, (IiconTexture texture) =>
					{
						//0x1C8761C
						if(m_btn_image[t_index_img] != null)
						{
							texture.Set(m_btn_image[t_index_img]);
						}
					});
					m_btn[i].Hidden = false;
				}
				else
				{
					m_btn[i].Hidden = true;
				}
			}
			if (a_is_val)
			{
				m_list_diva_id.Add(a_view_diva.Count + 1);
				m_btn[m_btn.Length - 1].Hidden = false;
			}
			else
			{
				m_btn[m_btn.Length - 1].Hidden = true;
			}
		}

		//// RVA: 0xF941D8 Offset: 0xF941D8 VA: 0xF941D8
		public void SetBit(uint a_bit_diva)
		{
			m_bit_btn = ConvertBit_DivaToBtn(a_bit_diva);
			if (m_btn_type == ButtonType.Single)
				SetFilterButtonSingle(m_btn, m_bit_btn);
			else
				SetFilterButton(m_btn, m_bit_btn);
		}

		//// RVA: 0xF9421C Offset: 0xF9421C VA: 0xF9421C
		public uint GetBit()
		{
			return ConvertBit_BtnToDiva(m_bit_btn);
		}

		//// RVA: 0xF95AE8 Offset: 0xF95AE8 VA: 0xF95AE8
		//public static uint CreateBit(PIGBBNDPPJC a_view) { }

		//// RVA: 0xF95988 Offset: 0xF95988 VA: 0xF95988
		private uint ConvertBit_DivaToBtn(uint a_bit_diva)
		{
			uint res = 0;
			for(int i = 0; i < m_bind_tbl.Length; i++)
			{
				if ((a_bit_diva & (1 << m_bind_tbl[i].m_diva_id)) != 0)
					res |= (uint)(1 << (m_bind_tbl[i].m_btn - 1));
			}
			return res;
		}

		//// RVA: 0xF95A38 Offset: 0xF95A38 VA: 0xF95A38
		private uint ConvertBit_BtnToDiva(uint a_bit_btn)
		{
			uint res = 0;
			for (int i = 0; i < m_bind_tbl.Length; i++)
			{
				if ((a_bit_btn & (1 << m_bind_tbl[i].m_btn - 1)) != 0)
					res |= (uint)(1 << (m_bind_tbl[i].m_diva_id));
			}
			return res;
		}
	}
}
