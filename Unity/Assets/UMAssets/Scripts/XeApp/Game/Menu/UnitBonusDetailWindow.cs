using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.Menu
{
	internal class UnitBonusDetailWindow : LayoutUGUIScriptBase
	{
		private enum CellType
		{
			Costume = 1,
			Valkyrie = 2,
			None = 3,
		}

		[SerializeField]
		private Text m_descText; // 0x14
		[SerializeField]
		private List<Text> m_nameTextList; // 0x18
		[SerializeField]
		private List<Text> m_bonusTextList; // 0x1C
		[SerializeField]
		private List<RawImageEx> m_iconImageList; // 0x20
		[SerializeField]
		private List<RawImageEx> m_mainImageList; // 0x24
		private List<AbsoluteLayout> m_cellLayout; // 0x28
		private List<AbsoluteLayout> m_bonusLayout; // 0x2C
		private List<AbsoluteLayout> m_bonusValue; // 0x30
		private const int MaxCellNum = 3;
		private bool m_isInitialize; // 0x34

		// public bool IsInitialize { get; } 0xA4A734

		// RVA: 0xA4A73C Offset: 0xA4A73C VA: 0xA4A73C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_isInitialize = false;
			m_cellLayout = new List<AbsoluteLayout>();
			m_cellLayout.Add(layout.FindViewByExId("sw_pop_bo_detail_swtbl_pop_bo_detail_01") as AbsoluteLayout);
			m_cellLayout.Add(layout.FindViewByExId("sw_pop_bo_detail_swtbl_pop_bo_detail_02") as AbsoluteLayout);
			m_cellLayout.Add(layout.FindViewByExId("sw_pop_bo_detail_swtbl_pop_bo_detail_03") as AbsoluteLayout);
			m_bonusLayout = new List<AbsoluteLayout>();
			m_bonusLayout.Add(m_cellLayout[0].FindViewByExId("swtbl_pop_bo_detail_cmn_win_05_01") as AbsoluteLayout);
			m_bonusLayout.Add(m_cellLayout[1].FindViewByExId("swtbl_pop_bo_detail_cmn_win_05_01") as AbsoluteLayout);
			m_bonusLayout.Add(m_cellLayout[2].FindViewByExId("swtbl_pop_bo_detail_cmn_win_05_01") as AbsoluteLayout);
			m_bonusValue = new List<AbsoluteLayout>();
			m_bonusValue.Add(m_cellLayout[0].FindViewByExId("swtbl_cmn_win_pop_ep_eve_bonus_s") as AbsoluteLayout);
			m_bonusValue.Add(m_cellLayout[1].FindViewByExId("swtbl_cmn_win_pop_ep_eve_bonus_s") as AbsoluteLayout);
			m_bonusValue.Add(m_cellLayout[2].FindViewByExId("swtbl_cmn_win_pop_ep_eve_bonus_s") as AbsoluteLayout);
			return true;
		}

		// RVA: 0xA4AF60 Offset: 0xA4AF60 VA: 0xA4AF60
		public void Initialize(List<PKNOKJNLPOE_EventRaid.MOAICCAOMCP.AAALCKPHGNG> data)
		{
			m_descText.text = MessageManager.Instance.GetMessage("menu", "popup_raid_formation_bonus_costume_desc");
			for(int i = 0; i < data.Count; i++)
			{
				SwitchCell(m_cellLayout[i], CellType.Costume);
				m_nameTextList[i].text = data[i].IFGEJDMMAHE_CostumeInfo.OPFGFINHFCE_Name;
				m_bonusTextList[i].text = string.Format(JpStringLiterals.StringLiteral_20803, data[i].DJJGNDCMNHF_UnitBonusCostume);
				SwitchCell(m_bonusValue[i], CellType.Costume);
				SetBounus(m_bonusLayout[i], data[i].NFAPNIKALBK_Active, data[i].IFGEJDMMAHE_CostumeInfo.FJODMPGPDDD_Possessed);
				int idx = i;
				GameManager.Instance.CostumeIconCache.Load(data[i].IFGEJDMMAHE_CostumeInfo.AHHJLDLAPAN_DivaId, data[i].IFGEJDMMAHE_CostumeInfo.DAJGPBLEEOB_PrismCostumeId, 0, (IiconTexture texture) =>
				{
					//0xA4C044
					texture.Set(m_mainImageList[idx]);
				});
				GameManager.Instance.DivaIconCache.Load(data[i].IFGEJDMMAHE_CostumeInfo.AHHJLDLAPAN_DivaId, data[i].IFGEJDMMAHE_CostumeInfo.DAJGPBLEEOB_PrismCostumeId, 0, (IiconTexture texture) =>
				{
					//0xA4C16C
					texture.Set(m_iconImageList[idx]);
				});
			}
			for(int i = data.Count; i < 3; i++)
			{
				SwitchCell(m_cellLayout[i], CellType.None);
			}
			m_isInitialize = true;
		}

		// RVA: 0xA4B978 Offset: 0xA4B978 VA: 0xA4B978
		public void Initialize(List<PKNOKJNLPOE_EventRaid.MOAICCAOMCP.LNKNJHEFBCE> data)
		{
			m_descText.text = "";
			for(int i = 0; i < data.Count; i++)
			{
				SwitchCell(m_cellLayout[i], CellType.Valkyrie);
				m_nameTextList[i].text = data[i].IFGEJDMMAHE_ValkInfo.IJBLEJOKEFH_ValkyrieName;
				m_bonusTextList[i].text = string.Format(JpStringLiterals.StringLiteral_20803, data[i].DJJGNDCMNHF_UnitBonusValk);
				SwitchCell(m_bonusValue[i], CellType.Costume);
				SetBounus(m_bonusLayout[i], data[i].NFAPNIKALBK_Active, data[i].IFGEJDMMAHE_ValkInfo.FJODMPGPDDD_Unlocked);
				int idx = i;
				GameManager.Instance.ValkyrieIconCache.LoadPortraitIcon(data[i].IFGEJDMMAHE_ValkInfo.GPPEFLKGGGJ_ValkyrieId, data[i].IFGEJDMMAHE_ValkInfo.GCCNMFHELCB_Form, (IiconTexture texture) =>
				{
					//0xA4C294
					texture.Set(m_mainImageList[idx]);
				});
			}
			for(int i = data.Count; i < 3; i++)
			{
				SwitchCell(m_cellLayout[i], CellType.None);
			}
			m_isInitialize = true;
		}

		// // RVA: 0xA4B81C Offset: 0xA4B81C VA: 0xA4B81C
		private void SwitchCell(AbsoluteLayout cell, UnitBonusDetailWindow.CellType type)
		{
			string lbl = string.Format("{0:D2}", (int)type);
			cell.StartChildrenAnimGoStop(lbl, lbl);
		}

		// // RVA: 0xA4B8D4 Offset: 0xA4B8D4 VA: 0xA4B8D4
		private void SetBounus(AbsoluteLayout layout, bool isUse, bool isHave)
		{
			if(isUse)
			{
				layout.StartChildrenAnimGoStop("01");
			}
			else if(isHave)
			{
				layout.StartChildrenAnimGoStop("02");
			}
			else 
			{
				layout.StartChildrenAnimGoStop("03");
			}
		}
	}
}
