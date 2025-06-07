using XeApp.Game.Common;
using System;
using UnityEngine.UI;
using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	internal class UnitBonusContent : SwapScrollListContent
	{
		public enum CellType
		{
			Episode = 1,
			Costume = 2,
			Valkyrie = 3,
			None = 4,
		}

		[Serializable]
		public class BonusCell
		{
			public CellType cellType; // 0x8
			public ActionButton button1; // 0xC
			public ActionButton button2; // 0x10
			public ActionButton button3; // 0x14
			public Text nameText1; // 0x18
			public Text nameText2; // 0x1C
			public Text nameText3; // 0x20
			public Text bonusText1; // 0x24
			public Text bonusText2; // 0x28
			public Text bonusText3; // 0x2C
			public Text bonusMaxText1; // 0x30
			public Text bonusMaxText2; // 0x34
			public Text bonusMaxText3; // 0x38
			public Text bonusAssist1; // 0x3C
			public int episodeId; // 0x40
			public RawImageEx sceneImage; // 0x44
			public RawImageEx cosImage1; // 0x48
			public RawImageEx cosImage2; // 0x4C
			public RawImageEx cosImage3; // 0x50
			public RawImageEx valImage1; // 0x54
			public RawImageEx valImage2; // 0x58
			public RawImageEx valImage3; // 0x5C
			public AbsoluteLayout cellSwitchLayout; // 0x60
			public AbsoluteLayout cellCursor1; // 0x64
			public AbsoluteLayout cellCursor2; // 0x68
			public AbsoluteLayout cellCursor3; // 0x6C
			public AbsoluteLayout cellAssist1; // 0x70

			// // RVA: 0xA471B8 Offset: 0xA471B8 VA: 0xA471B8
			public void Initialize(AbsoluteLayout rootLayout)
			{
				cellSwitchLayout = rootLayout.FindViewByExId("swtbl_episode_sw_episode") as AbsoluteLayout;
				cellCursor1 = rootLayout.FindViewByExId("sw_episode_swtbl_ep_eve_cursor_01") as AbsoluteLayout;
				cellCursor2 = rootLayout.FindViewByExId("sw_episode_02_swtbl_ep_eve_cursor_01") as AbsoluteLayout;
				cellCursor3 = rootLayout.FindViewByExId("sw_episode_03_swtbl_ep_eve_cursor_01") as AbsoluteLayout;
				cellAssist1 = rootLayout.FindViewByExId("sw_episode_sw_assist_onoff_anim") as AbsoluteLayout;
			}

			// // RVA: 0xA4946C Offset: 0xA4946C VA: 0xA4946C
			public void SetCellType(CellType cellType)
			{
				string lbl = string.Format("{0:D2}", (int)cellType);
				cellSwitchLayout.StartSiblingAnimGoStop(lbl, lbl);
			}

			// // RVA: 0xA49528 Offset: 0xA49528 VA: 0xA49528
			public void SetBouns(Text bonusText, int bonusPoint, bool isUse, bool isHave)
			{
				if(isUse)
				{
					bonusText.text = string.Format(JpStringLiterals.StringLiteral_20803, bonusPoint);
					SetIsUse("01");
				}
				else
				{
					if(isHave)
					{
						bonusText.text = MessageManager.Instance.GetMessage("menu", "unorganized");
						SetIsUse("02");
					}
					else
					{
						bonusText.text = MessageManager.Instance.GetMessage("menu", "not_possessed");
						if(RuntimeSettings.CurrentSettings.Language == "fr")
							bonusText.fontSize = 12;
						SetIsUse("03");
					}
				}
			}

			// // RVA: 0xA4A6A0 Offset: 0xA4A6A0 VA: 0xA4A6A0
			public void SetIsUse(string label)
			{
				cellCursor1.StartChildrenAnimGoStop(label, label);
				cellCursor2.StartChildrenAnimGoStop(label, label);
				cellCursor3.StartChildrenAnimGoStop(label, label);
			}

			// // RVA: 0xA496E8 Offset: 0xA496E8 VA: 0xA496E8
			public void SetIsAssistUse(bool isUse)
			{
				cellAssist1.StartChildrenAnimGoStop(isUse ? "01" : "02", isUse ? "01" : "02");
				bonusAssist1.text = MessageManager.Instance.GetMessage("menu", "episode_assist");
			}
		}

		[SerializeField]
		private List<BonusCell> m_bonusCellList = new List<BonusCell>(8); // 0x20
		private PopupEpisodeBonusPlateSortList m_plateEpisodeList = new PopupEpisodeBonusPlateSortList(); // 0x24
		private PopupUnitBonusDetailContentSetting m_bonusDetailPopup = new PopupUnitBonusDetailContentSetting(); // 0x28
		private PKNOKJNLPOE_EventRaid.MOAICCAOMCP m_unitBonusInfo; // 0x2C
		private HomeBannerTextureCache m_homeBannerTextureCache; // 0x30
		private const int MaxCellCount = 8;
		private bool m_isInitialize; // 0x34
		private int m_loadCount; // 0x38
		private int m_loadedCount; // 0x3C

		public PopupEpisodeBonusPlateSortList popupEpisodeBonusPlateSortList { get { return m_plateEpisodeList; } } //0xA46728
		// public bool IsInitialize { get; } 0xA46730

		// // RVA: 0xA46738 Offset: 0xA46738 VA: 0xA46738
		public bool IsLoadImage()
		{
			return m_loadCount == m_loadedCount;
		}

		// RVA: 0xA46750 Offset: 0xA46750 VA: 0xA46750 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_isInitialize = false;
			m_bonusDetailPopup.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			m_bonusDetailPopup.WindowSize = SizeType.Middle;
			m_bonusCellList[0].Initialize(layout.FindViewByExId("sw_pop_ep_eve_8_swtbl_episode_01") as AbsoluteLayout);
			m_bonusCellList[1].Initialize(layout.FindViewByExId("sw_pop_ep_eve_8_swtbl_episode_02") as AbsoluteLayout);
			m_bonusCellList[2].Initialize(layout.FindViewByExId("sw_pop_ep_eve_8_swtbl_episode_04") as AbsoluteLayout);
			m_bonusCellList[3].Initialize(layout.FindViewByExId("sw_pop_ep_eve_8_swtbl_episode_05") as AbsoluteLayout);
			m_bonusCellList[4].Initialize(layout.FindViewByExId("sw_pop_ep_eve_8_swtbl_episode_06") as AbsoluteLayout);
			m_bonusCellList[5].Initialize(layout.FindViewByExId("sw_pop_ep_eve_8_swtbl_episode_07") as AbsoluteLayout);
			m_bonusCellList[6].Initialize(layout.FindViewByExId("sw_pop_ep_eve_8_swtbl_episode_08") as AbsoluteLayout);
			m_bonusCellList[7].Initialize(layout.FindViewByExId("sw_pop_ep_eve_8_swtbl_episode_09") as AbsoluteLayout);
			for(int i = 0; i < m_bonusCellList.Count; i++)
			{
				int index = i;
				m_bonusCellList[i].button1.AddOnClickCallback(() =>
				{
					//0xA49DF8
					OnTapCell(index);
				});
				m_bonusCellList[i].button2.AddOnClickCallback(() =>
				{
					//0xA49E28
					OnTapCell(index);
				});
				m_bonusCellList[i].button3.AddOnClickCallback(() =>
				{
					//0xA49E58
					OnTapCell(index);
				});
			}
			m_homeBannerTextureCache = new HomeBannerTextureCache();
			Loaded();
			return true;
		}

		// RVA: 0xA47468 Offset: 0xA47468 VA: 0xA47468
		public void Initialize(PopupUnitBonusContent content)
		{
			m_plateEpisodeList.bannerTexCache = m_homeBannerTextureCache;
			m_plateEpisodeList.Initialize(content.Parent, this);
			m_bonusDetailPopup.m_parent = content.Parent;
			PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			m_unitBonusInfo = ev.ANMBIEIFKFF_UnitBonusInfo;
			m_loadCount = 0;
			m_loadedCount = 0;
			int idx = 0;
			if(ev.ANMBIEIFKFF_UnitBonusInfo.FABAGMLEKIB_CostumeBonuses.Count != 0)
			{
				CellSettingCostume(m_bonusCellList[0], m_unitBonusInfo.FABAGMLEKIB_CostumeBonuses);
				idx++;
			}
			if(ev.ANMBIEIFKFF_UnitBonusInfo.CNGNBKNBKGI_ValkyrieBonuses.Count != 0)
			{
				CellSettingValkyrie(m_bonusCellList[idx], m_unitBonusInfo.CNGNBKNBKGI_ValkyrieBonuses);
				idx++;
			}
			for(int i = 0; i < m_unitBonusInfo.BBAJKJPKOHD_EpisodeBonuses.Count; i++)
			{
				CellSettingEpisode(m_bonusCellList[idx], m_unitBonusInfo.BBAJKJPKOHD_EpisodeBonuses[i], m_unitBonusInfo.BBAJKJPKOHD_EpisodeBonuses[i].DJJGNDCMNHF_BonusValue);
				idx++;
			}
			for(int i = idx; i < 8; i++)
			{
				HideCell(m_bonusCellList[i]);
			}
			m_isInitialize = true;
		}

		// // RVA: 0xA48430 Offset: 0xA48430 VA: 0xA48430
		public void CellSettingValkyrie(BonusCell cell, List<PKNOKJNLPOE_EventRaid.MOAICCAOMCP.LNKNJHEFBCE> valkyrieList)
		{
			cell.cellType = CellType.Valkyrie;
			cell.SetCellType(CellType.Valkyrie);
			cell.nameText3.text = MessageManager.Instance.GetMessage("menu", "popup_raid_formation_bonus_valkyrie");
			int t = 0;
			for(int i = 0; i < valkyrieList.Count; i++)
			{
				if(valkyrieList[i].NFAPNIKALBK_Active)
				{
					//m_unitBonusInfo.KMEDEGMLEBF_UnitBonusValkyrie
				}
				t = Mathf.Max(t, valkyrieList[i].DJJGNDCMNHF_UnitBonusValk);
			}
			m_loadCount++;
			GameManager.Instance.ValkyrieIconCache.LoadPortraitIcon(valkyrieList[0].IFGEJDMMAHE_ValkInfo.GPPEFLKGGGJ_ValkyrieId, valkyrieList[0].IFGEJDMMAHE_ValkInfo.GCCNMFHELCB_Form, (IiconTexture texture) =>
			{
				//0xA49E88
				texture.Set(cell.valImage1);
				m_loadedCount++;
			});
			m_loadCount++;
			GameManager.Instance.ValkyrieIconCache.LoadPortraitIcon(valkyrieList[1].IFGEJDMMAHE_ValkInfo.GPPEFLKGGGJ_ValkyrieId, valkyrieList[1].IFGEJDMMAHE_ValkInfo.GCCNMFHELCB_Form, (IiconTexture texture) =>
			{
				//0xA49FB0
				texture.Set(cell.valImage2);
				m_loadedCount++;
			});
			m_loadCount++;
			GameManager.Instance.ValkyrieIconCache.LoadPortraitIcon(valkyrieList[2].IFGEJDMMAHE_ValkInfo.GPPEFLKGGGJ_ValkyrieId, valkyrieList[2].IFGEJDMMAHE_ValkInfo.GCCNMFHELCB_Form, (IiconTexture texture) =>
			{
				//0xA4A0D8
				texture.Set(cell.valImage3);
				m_loadedCount++;
			});
			bool b = false;
			for(int i = 0; i < valkyrieList.Count; i++)
			{
				b |= valkyrieList[i].NFAPNIKALBK_Active;
			}
			bool b2 = false;
			for(int i = 0; i < valkyrieList.Count; i++)
			{
				b2 |= valkyrieList[i].IFGEJDMMAHE_ValkInfo.FJODMPGPDDD_Unlocked;
			}
			cell.bonusMaxText3.text = string.Format(MessageManager.Instance.GetMessage("menu", "popup_episodebonus_max"), t);
			cell.SetBouns(cell.bonusText3, m_unitBonusInfo.KMEDEGMLEBF_UnitBonusValkyrie, b, b2);
		}

		// // RVA: 0xA47988 Offset: 0xA47988 VA: 0xA47988
		public void CellSettingCostume(BonusCell cell, List<PKNOKJNLPOE_EventRaid.MOAICCAOMCP.AAALCKPHGNG> costumeList)
		{
			cell.cellType = CellType.Costume;
			cell.SetCellType(CellType.Costume);
			cell.nameText2.text = MessageManager.Instance.GetMessage("menu", "popup_raid_formation_bonus_costume");
			int t = 0;
			int t2 = 0;
			for(int i = 0; i < costumeList.Count; i++)
			{
				if(costumeList[i].NFAPNIKALBK_Active)
				{
					t = Mathf.Max(t, costumeList[i].DJJGNDCMNHF_UnitBonusCostume);
				}
				t2 = Mathf.Max(t2, costumeList[i].DJJGNDCMNHF_UnitBonusCostume);
			}
			m_loadCount++;
			GameManager.Instance.CostumeIconCache.Load(costumeList[0].IFGEJDMMAHE_CostumeInfo.AHHJLDLAPAN_DivaId, costumeList[0].IFGEJDMMAHE_CostumeInfo.DAJGPBLEEOB_PrismCostumeId, 0, (IiconTexture texture) =>
			{
				//0xA4A200
				texture.Set(cell.cosImage1);
				m_loadedCount++;
			});
			m_loadCount++;
			GameManager.Instance.CostumeIconCache.Load(costumeList[1].IFGEJDMMAHE_CostumeInfo.AHHJLDLAPAN_DivaId, costumeList[1].IFGEJDMMAHE_CostumeInfo.DAJGPBLEEOB_PrismCostumeId, 0, (IiconTexture texture) =>
			{
				//0xA4A328
				texture.Set(cell.cosImage2);
				m_loadedCount++;
			});
			m_loadCount++;
			GameManager.Instance.CostumeIconCache.Load(costumeList[2].IFGEJDMMAHE_CostumeInfo.AHHJLDLAPAN_DivaId, costumeList[2].IFGEJDMMAHE_CostumeInfo.DAJGPBLEEOB_PrismCostumeId, 0, (IiconTexture texture) =>
			{
				//0xA4A450
				texture.Set(cell.cosImage3);
				m_loadedCount++;
			});
			bool b = false;
			for(int i = 0; i < costumeList.Count; i++)
			{
				b |= costumeList[i].NFAPNIKALBK_Active;
			}
			bool b2 = false;
			for(int i = 0; i < costumeList.Count; i++)
			{
				b2 |= costumeList[i].IFGEJDMMAHE_CostumeInfo.FJODMPGPDDD_Possessed;
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			cell.bonusMaxText2.text = string.Format(bk.GetMessageByLabel("popup_episodebonus_max"), t2);
			cell.SetBouns(cell.bonusText2, t, b, b2);
		}

		// // RVA: 0xA48E40 Offset: 0xA48E40 VA: 0xA48E40
		public void CellSettingEpisode(BonusCell cell, PKNOKJNLPOE_EventRaid.MOAICCAOMCP.ELAIDDICLCD episodeData, int bonusPoint)
		{
			cell.cellType = CellType.Episode;
			cell.SetCellType(CellType.Episode);
			cell.nameText1.text = episodeData.OPFGFINHFCE_Name;
			CIKHPBBNEIM.ODGCADPPIFA c = new CIKHPBBNEIM.ODGCADPPIFA();
			List<CIKHPBBNEIM.ODGCADPPIFA> l = m_unitBonusInfo.MBPCEBPHOBB.GGHMLFOFELH(episodeData.PPFNGGCBJKC_Id).FLJNOOPOAGI;
			bool isUse = false;
			bool b = false;
			bool b2 = false;
			int t = 0;
			for(int i = 0; i < l.Count; i++)
			{
				t = Mathf.Max(t, l[i].ALDAOOLPHCH_BonusAfter);
				if(l[i].ILOKENBBBAE_Available)
				{
					b |= l[i].GKBNFLFEIOF_IsAssist;
					isUse = true;
				}
				b2 |= l[i].IADCHIFJHOJ_Unlocked;
			}
			cell.bonusMaxText1.text = string.Format(MessageManager.Instance.GetMessage("menu", "popup_episodebonus_max"), t);
			cell.episodeId = episodeData.PPFNGGCBJKC_Id;
			m_loadCount++;
			GameManager.Instance.EpisodeIconCache.LoadBg(episodeData.PPFNGGCBJKC_Id, (IiconTexture texture) =>
			{
				//0xA4A578
				texture.Set(cell.sceneImage);
				m_loadedCount++;
			});
			cell.SetIsAssistUse(b);
			cell.SetBouns(cell.bonusText1, bonusPoint, isUse, b2);
		}

		// // RVA: 0xA49418 Offset: 0xA49418 VA: 0xA49418
		public void HideCell(BonusCell cell)
		{
			cell.cellType = CellType.None;
			cell.SetCellType(CellType.None);
		}

		// // RVA: 0xA49804 Offset: 0xA49804 VA: 0xA49804
		public void OnTapCell(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			if(m_bonusCellList[index].cellType == CellType.Valkyrie)
			{
				m_bonusDetailPopup.SetValkyrieData(m_unitBonusInfo.CNGNBKNBKGI_ValkyrieBonuses);
				PopupWindowManager.Show(m_bonusDetailPopup, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel btnlabel) =>
				{
					//0xA49DF4
					return;
				}, null, null, null, true, true, false);
			}
			else if(m_bonusCellList[index].cellType == CellType.Episode)
			{
				m_plateEpisodeList.Setup(m_bonusCellList[index].episodeId, m_unitBonusInfo.MBPCEBPHOBB);
				m_plateEpisodeList.Show();
			}
			else if(m_bonusCellList[index].cellType == CellType.Costume)
			{
				m_bonusDetailPopup.SetCostumeData(m_unitBonusInfo.FABAGMLEKIB_CostumeBonuses);
				PopupWindowManager.Show(m_bonusDetailPopup, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel btnlabel) =>
				{
					//0xA49DF0
					return;
				}, null, null, null, true, true, false);
			}
		}

		// RVA: 0xA49C6C Offset: 0xA49C6C VA: 0xA49C6C
		private void Update()
		{
			if(m_homeBannerTextureCache != null)
				m_homeBannerTextureCache.Update();
		}

		// RVA: 0xA49C80 Offset: 0xA49C80 VA: 0xA49C80
		private void OnDestroy()
		{
			if(m_homeBannerTextureCache != null)
				m_homeBannerTextureCache.Terminated();
		}
	}
}
