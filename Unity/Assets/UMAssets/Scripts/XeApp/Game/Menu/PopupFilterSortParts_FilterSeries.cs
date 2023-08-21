using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortParts_FilterSeries : PopupFilterSortPartsBase
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
		private ToggleButton[] m_btn; // 0x1C
		[SerializeField]
		private RawImageEx[] m_btn_image; // 0x20
		[SerializeField]
		private Text[] m_btn_text; // 0x24
		private uint m_bit_btn; // 0x28
		private Bind[] m_bind_tbl = new Bind[5]
		{
			new Bind() { m_series = 4, m_btn = 1 },
			new Bind() { m_series = 3, m_btn = 2 },
			new Bind() { m_series = 2, m_btn = 3 },
			new Bind() { m_series = 1, m_btn = 4 },
			new Bind() { m_series = 5, m_btn = 5 },
		}; // 0x2C

		// RVA: 0x1C8A930 Offset: 0x1C8A930 VA: 0x1C8A930 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_btn_text[0].text = bk.GetMessageByLabel("popup_sort_filter_all");
			for(int i = 0; i < m_btn.Length; i++)
			{
				int index = i;
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1C8B700
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					PushFilterButton(index, m_btn);
					m_bit_btn = GetFilterButtonBit(m_btn);
				});
			}
			for(int i = 1; i < m_btn_image.Length; i++)
			{
				m_btn_image[i].enabled = false;
				int index = i;
				GameManager.Instance.MenuResidentTextureCache.LoadLogo(5 - i > 0 ? 5 - i : 11, (IiconTexture texture) =>
				{
					//0x1C8B7FC
					if(m_btn_image[index] != null)
					{
						m_btn_image[index].enabled = true;
						texture.Set(m_btn_image[index]);
					}
				});
			}
			Loaded();
			return true;
		}

		// // RVA: 0x1C8AD90 Offset: 0x1C8AD90 VA: 0x1C8AD90
		public void SetBit(uint a_bit_series)
		{
			m_bit_btn = ConvertBit_SeriesToBtn(a_bit_series);
			SetFilterButton(m_btn, m_bit_btn);
		}

		// // RVA: 0x1C8AE70 Offset: 0x1C8AE70 VA: 0x1C8AE70
		public uint GetBit()
		{
			return ConvertBit_BtnToSeries(m_bit_btn);
		}

		// // RVA: 0x1C8AF2C Offset: 0x1C8AF2C VA: 0x1C8AF2C
		public static uint CreateBit(PIGBBNDPPJC a_view)
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(a_view.KIJAPOFAGPN_UnlockItemId);
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(a_view.KIJAPOFAGPN_UnlockItemId);
			int a = 0;
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg)
			{
				a = (int)IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.GCINIJEMHFK(id).AIHCEGFANAM_Sa;
			}
			else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
			{
				a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.GCINIJEMHFK(id).AIHCEGFANAM_Sa;
			}
			else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
			{
				a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.EEOADCECNOM_GetCostumeInfo(id).AHHJLDLAPAN_PrismDivaId).AIHCEGFANAM_Attr;
			}
			uint res = 16;
			if (a > 0 && a < 5)
				res = (uint)(1 << (a - 1));
			return res;
		}

		// // RVA: 0x1C8ADBC Offset: 0x1C8ADBC VA: 0x1C8ADBC
		private uint ConvertBit_SeriesToBtn(uint a_bit_series)
		{
			uint res = 0;
			for(int i = 0; i < m_bind_tbl.Length; i++)
			{
				if((a_bit_series & (1 << (m_bind_tbl[i].m_series - 1))) != 0)
				{
					res |= (uint)(1 << (m_bind_tbl[i].m_btn - 1));
				}
			}
			return res;
		}

		// // RVA: 0x1C8AE78 Offset: 0x1C8AE78 VA: 0x1C8AE78
		private uint ConvertBit_BtnToSeries(uint a_bit_btn)
		{
			uint res = 0;
			for(int i = 0; i < m_bind_tbl.Length; i++)
			{
				if((a_bit_btn & (1 << (m_bind_tbl[i].m_btn - 1))) != 0)
				{
					res |= (uint)(1 << (m_bind_tbl[i].m_series - 1));
				}
			}
			return res;
		}
	}
}
