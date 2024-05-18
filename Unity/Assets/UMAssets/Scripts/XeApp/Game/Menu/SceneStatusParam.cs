using XeSys.Gfx;
using System;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System.Text;
using mcrs;
using XeSys;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class SceneStatusParam : LayoutUGUIScriptBase
	{
		private enum LoadingFlag
		{
			Scene = 1,
			Logo = 2,
			All = 3,
		}

		public enum PageSave
		{
			None = 0,
			Player = 1,
			Pickup = 2,
		}

		private enum SkillDispPartsType
		{
			Center = 0,
			Center2 = 1,
			Active = 2,
			Live = 3,
			Live_2 = 4,
			Num = 5,
		}

		private enum SkillDetailButtonsType
		{
			Center = 0,
			Center_2 = 1,
			Active = 2,
			Live = 3,
			Live_2 = 4,
			Num = 5,
		}

		private class LuckyLeafLayout
		{
			private AbsoluteLayout m_baseAbs; // 0x8
			private AbsoluteLayout m_leafAbs; // 0xC
			private AbsoluteLayout[] m_leaf = new AbsoluteLayout[5]; // 0x10

			// RVA: 0xA5A9D8 Offset: 0xA5A9D8 VA: 0xA5A9D8
			public LuckyLeafLayout(Layout lay)
			{
				m_baseAbs = lay.FindViewByExId("sw_add_leaf_btn_anim_sw_leaf_base_anim") as AbsoluteLayout;
				m_leafAbs = lay.FindViewByExId("sw_add_leaf_btn_anim_sw_add_leaf_anim") as AbsoluteLayout;
				for(int i = 0; i < m_leaf.Length; i++)
				{
					m_leaf[i] = lay.FindViewByExId(string.Format("sw_add_leaf_anim_swtbl_leaf_on_{0:D2}", i + 1)) as AbsoluteLayout;
				}
			}

			// // RVA: 0xA5F280 Offset: 0xA5F280 VA: 0xA5F280
			public void SetLeafNum(int num, int max)
			{
				m_baseAbs.StartChildrenAnimGoStop(max.ToString("00"));
				m_leafAbs.StartChildrenAnimGoStop(max.ToString("00"));
				for(int i = 0; i < num; i++)
				{
					m_leaf[i].StartChildrenAnimGoStop("02");
				}
				for(int i = num; i < m_leaf.Length; i++)
				{
					m_leaf[i].StartChildrenAnimGoStop("01");
				}
			}
		}

		private class LimitBreakStatusLayout
		{
			private enum AbsGroup
			{
				ExcelentProb = 0,
				SkillProb = 1,
			}

			private Dictionary<int, List<AbsoluteLayout>> m_abs = new Dictionary<int, List<AbsoluteLayout>>(); // 0x8
			private Dictionary<int, List<Text>> m_effectText = new Dictionary<int, List<Text>>(); // 0xC
			private static string[,] exIdTbl = new string[2, 3]
			{
				{"swtbl_scene_ex_sw_chk_scene_ex_01", "swtbl_scene_ex_sw_chk_scene_ex_05_01", "swtbl_scene_ex_sw_chk_scene_ex_04_01"},
				{"swtbl_scene_ex_sw_chk_scene_ex_03", "swtbl_scene_ex_sw_chk_scene_ex_05_02", "swtbl_scene_ex_sw_chk_scene_ex_04_02"}
			}; // 0x0
			private static string[,] textParentNameTbl = new string[2, 3]
			{
				{"sw_chk_scene_ex_01", "sw_chk_scene_ex_05_01", "sw_chk_scene_ex_04_01"},
				{"sw_chk_scene_ex_03", "sw_chk_scene_ex_05_02", "sw_chk_scene_ex_04_02"}
			}; // 0x4

			// RVA: 0xA5ACE4 Offset: 0xA5ACE4 VA: 0xA5ACE4
			public LimitBreakStatusLayout(Layout lay, GameObject go)
			{
				for(int i = 0; i < exIdTbl.GetLength(0); i++)
				{
					List<AbsoluteLayout> l = new List<AbsoluteLayout>();
					for(int j = 0; j < exIdTbl.GetLength(1); j++)
					{
						l.Add(lay.FindViewByExId(exIdTbl[i, j]) as AbsoluteLayout);
					}
					m_abs.Add(i, l);
				}
				Text[] texts = go.GetComponentsInChildren<Text>(true);
				for(int i = 0; i < textParentNameTbl.GetLength(0); i++)
				{
					List<Text> l = new List<Text>();
					for(int j = 0; j < textParentNameTbl.GetLength(1); j++)
					{
						l.Add(Array.Find(texts, (Text x) =>
						{
							//0xA64AAC
							return x.transform.parent.name.Contains(textParentNameTbl[i, j]);
						}));
					}
					m_effectText.Add(i, l);
				}
			}

			// // RVA: 0xA5F454 Offset: 0xA5F454 VA: 0xA5F454
			public void SetValue(LimitOverStatusData data)
			{
				foreach(var k in m_abs)
				{
					if(k.Key == 0)
					{
						k.Value[0].StartAnimGoStop("01");
						SetPanel(data.excellentRate, data.excellentRate_SameMusicAttr, data.excellentRate_SameSeriesAttr, k.Value, m_effectText[k.Key]);
					}
					else
					{
						k.Value[0].StartAnimGoStop(data.centerLiveSkillRate > 0 ? "01" : "05");
						SetPanel(data.centerLiveSkillRate, data.centerLiveSkillRate_SameMusicAttr, data.centerLiveSkillRate_SameSeriesAttr, k.Value, m_effectText[k.Key]);
					}
				}
			}

			// // RVA: 0xA63F90 Offset: 0xA63F90 VA: 0xA63F90
			private void SetPanel(int overLimitValue, int attrBonus, int seriesBonus, List<AbsoluteLayout> layoutList, List<Text> textList)
			{
				textList[0].text = string.Format("+<color={0}>{1}</color>%", overLimitValue < 1 ? SystemTextColor.NormalColor : SystemTextColor.ImportantColor, overLimitValue);
				textList[1].text = string.Format("+<color={0}>{1}</color>%", attrBonus < 1 ? SystemTextColor.NormalColor : SystemTextColor.ImportantColor, attrBonus);
				textList[2].text = string.Format("+<color={0}>{1}</color>%", seriesBonus < 1 ? SystemTextColor.NormalColor : SystemTextColor.ImportantColor, seriesBonus);
				if (attrBonus < 1 || seriesBonus < 1)
				{
					if (attrBonus < 1)
						layoutList[1].StartAnimGoStop("04");
					else
					{
						layoutList[1].StartAnimGoStop("02");
						layoutList[2].StartAnimGoStop("02");
					}
					if(seriesBonus < 1)
					{
						layoutList[2].StartAnimGoStop("04");
					}
					else
					{
						layoutList[1].StartAnimGoStop("03");
						layoutList[2].StartAnimGoStop("03");
					}
				}
				else
				{
					layoutList[1].StartAnimGoStop("01");
					layoutList[2].StartAnimGoStop("01");
				}
			}
		}

		[Serializable]
		public class SceneAbilityButtonEvent : UnityEvent<int>
		{
			//
		}

		[SerializeField]
		private Text[] m_paramTexts; // 0x14
		[SerializeField]
		private Text[] m_nortsTexts; // 0x18
		[SerializeField]
		private Text[] m_skillNameTexts; // 0x1C
		[SerializeField]
		private Text[] m_skillDescriptTexts; // 0x20
		[SerializeField]
		private Text[] m_skillLevelTexts; // 0x24
		[SerializeField]
		private Text m_sceneDetails; // 0x28
		[SerializeField]
		private Text m_episodeName; // 0x2C
		[SerializeField]
		private ActionButton m_sceneButton; // 0x30
		[SerializeField]
		private InfoButton m_changeStatusButton; // 0x34
		[SerializeField]
		private ActionButton[] m_skillDetailsButtons; // 0x38
		[SerializeField]
		private ActionButton m_luckLeafButton; // 0x3C
		[SerializeField]
		private ActionButton m_episodeButton; // 0x40
		[SerializeField]
		private ActionButton m_rareChangeButton; // 0x44
		[SerializeField]
		private RegulationButton[] m_regulationButtons; // 0x48
		[SerializeField]
		private RawImageEx m_sceneIconImage; // 0x4C
		[SerializeField]
		private RawImageEx m_seriesIconImage; // 0x50
		[SerializeField]
		private RawImageEx[] m_liveSkillTypeImages; // 0x54
		[SerializeField]
		private RawImageEx[] m_compatibleDivaIconImages; // 0x58
		[SerializeField]
		private RawImageEx[] m_compatibleMaskIconImages; // 0x5C
		[SerializeField]
		private RawImageEx[] m_skillDetailIconImages; // 0x60
		[SerializeField]
		private RawImageEx[] m_skillRankIconImages; // 0x64
		[SerializeField]
		private SceneAbilityButtonEvent m_onSceneAbilityEvent; // 0x68
		[SerializeField]
		private RawImage m_backImage; // 0x6C
		[SerializeField]
		private RawImageEx m_zoomSceneImage; // 0x70
		[SerializeField]
		private RawImageEx m_KiraImage; // 0x74
		[SerializeField]
		private RawImageEx m_KiraOverlayImage; // 0x78
		[SerializeField]
		private SceneImageViewer m_viewer; // 0x7C
		private GCIJNCFDNON_SceneInfo m_sceneData; // 0x80
		private AEKDNMPPOJN m_limitOverData = new AEKDNMPPOJN(); // 0x84
		private PIGBBNDPPJC m_episodeData = new PIGBBNDPPJC(); // 0x88
		private AbsoluteLayout[] m_nortsLayout; // 0x8C
		private AbsoluteLayout m_statusChangeLayout; // 0x90
		private AbsoluteLayout[] m_skillMisMatchLayout; // 0x94
		private AbsoluteLayout m_gachaInfoLayout; // 0x98
		private AbsoluteLayout m_centerSkillCrossFade; // 0x9C
		private AbsoluteLayout m_skillLayout; // 0xA0
		private AbsoluteLayout[] m_liveSkillTypeLayout; // 0xA4
		private SceneIconDecoration m_sceneIconDeccoration = new SceneIconDecoration(); // 0xA8
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0xAC
		private StringBuilder m_assetName = new StringBuilder(64); // 0xB0
		private PopupWindowControl m_windowControl; // 0xB4
		private int m_statusDispIndex; // 0xB8
		private int m_statusDispNum; // 0xBC
		private bool m_isEndView; // 0xC0
		private PageSave m_pageSave; // 0xC4
		private TexUVListManager m_uvManager; // 0xC8
		private List<int> m_cimpatibleDivaIdList = new List<int>(); // 0xCC
		private SceneCardTextureCache m_sceneCardCache; // 0xD0
		private LuckyLeafLayout m_luckyLeaf; // 0xD4
		private LimitBreakStatusLayout m_limitBreak; // 0xD8
		private PopupLuckyLeafSetting m_luckyLeafSetting = new PopupLuckyLeafSetting(); // 0xDC
		private PopupLuckyLeafTerminateSetting m_luckyLeafTerminateSetting = new PopupLuckyLeafTerminateSetting(); // 0xE0
		private LoadingFlag m_loadingFlag; // 0xE4
		private const string LevelFormat = "Lv{0}";
		private static readonly string[] m_statuChangeAnimeLabel = new string[4]
		{
			"01", "02", "03", "04"
		}; // 0x0

		// // RVA: 0xA59AF8 Offset: 0xA59AF8 VA: 0xA59AF8
		public bool IsLoading()
		{
			return m_loadingFlag != LoadingFlag.All;
		}

		// RVA: 0xA59B0C Offset: 0xA59B0C VA: 0xA59B0C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_nortsLayout = new AbsoluteLayout[m_nortsTexts.Length];
			for(int i = 0; i < m_nortsLayout.Length; i++)
			{
				m_strBuilder.Clear();
				m_strBuilder.AppendFormat("sw_chara_note_swtbl_st_note{0:D2}", i + 1);
				m_nortsLayout[i] = layout.FindViewByExId(m_strBuilder.ToString()) as AbsoluteLayout;
			}
			m_statusChangeLayout = layout.FindViewByExId("sw_chk_scene_all_swtbl_scene_status") as AbsoluteLayout;
			m_gachaInfoLayout = layout.FindViewByExId("swtbl_gacha_notes_cmn_chk_gacha_notes_fnt") as AbsoluteLayout;
			m_centerSkillCrossFade = layout.FindViewByExId("sw_scene_status_sw_c_skill_cf_anim") as AbsoluteLayout;
			m_skillLayout = layout.FindViewByExId("sw_scene_skill_sw_live_skill_cf_anim") as AbsoluteLayout;
			m_liveSkillTypeLayout = new AbsoluteLayout[2];
			m_liveSkillTypeLayout[0] = m_skillLayout.FindViewByExId("sw_live_skill_cf_anim_live_skill_01") as AbsoluteLayout;
			m_liveSkillTypeLayout[1] = m_skillLayout.FindViewByExId("sw_live_skill_cf_anim_live_skill_02") as AbsoluteLayout;
			m_changeStatusButton.OnClickButton = (int page) =>
			{
				//0xA611B4
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				m_statusDispIndex++;
				if(m_statusDispIndex >= m_statusDispNum)
					m_statusDispIndex = 0;
				UpdateStatus();
			};
			m_sceneButton.AddOnClickCallback(OnSceneZoom);
			m_skillMisMatchLayout = new AbsoluteLayout[3];
			string[] str = new string[3] { "sw_scene_status", "sw_scene_skill", "sw_scene_skill" };
			for(int i = 0; i < 3; i++)
			{
				m_strBuilder.Clear();
				m_strBuilder.AppendFormat("{0}_swtbl_skill_mismatch_{1:D2}", str[i], i + 1);
				m_skillMisMatchLayout[i] = layout.FindViewByExId(m_strBuilder.ToString()) as AbsoluteLayout;
				m_skillMisMatchLayout[i].StartChildrenAnimGoStop("05");
			}
			m_uvManager = uvMan;
			m_luckyLeaf = new LuckyLeafLayout(layout);
			m_limitBreak = new LimitBreakStatusLayout(layout, gameObject);
			m_luckLeafButton.AddOnClickCallback(OnShowLimitBreakPopup);
			m_episodeButton.AddOnClickCallback(OnShowEpisodePopup);
			m_viewer.onClose += () =>
			{
				//0xA61230
				m_isEndView = true;
			};
			m_viewer.onLeftArrow += (int page) =>
			{
				//0xA6123C
				ChangeEvolvImage(page);
			};
			m_viewer.onRightArrow += (int page) =>
			{
				//0xA61240
				ChangeEvolvImage(page);
			};
			ClearLoadedCallback();
			return true;
		}

		// // RVA: 0xA5B3B0 Offset: 0xA5B3B0 VA: 0xA5B3B0
		public void InitializeDecoration()
		{
			m_sceneIconDeccoration.Initialize(m_sceneIconImage.gameObject, SceneIconDecoration.Size.M, null, null);
		}

		// // RVA: 0xA5B41C Offset: 0xA5B41C VA: 0xA5B41C
		public void ReleaseDecoration()
		{
			m_sceneIconDeccoration.Release();
			GameManager.Instance.SceneIconCache.ReleaseKiraMaterial();
			if(m_pageSave == PageSave.Pickup)
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().LDNJHLLKEIG_StatusPopup.ILEFFJCOGOG_GachaStatusPage = m_statusDispIndex;
			}
			else if(m_pageSave == PageSave.Player)
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().LDNJHLLKEIG_StatusPopup.ICBNEOCAGKF_SceneStatusPage = m_statusDispIndex;
			}
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}

		// // RVA: 0xA5B624 Offset: 0xA5B624 VA: 0xA5B624
		public void UpdateContent(GCIJNCFDNON_SceneInfo sceneData, DFKGGBMFFGB_PlayerInfo playerData, bool isFriend, bool isDisableZoom, bool isDisableLuckyLeaf, PageSave pageSave = PageSave.Player)
		{
			if(m_rareChangeButton != null)
			{
				m_rareChangeButton.Hidden = true;
			}
			m_windowControl = GetComponentInParent<PopupWindowControl>();
			m_pageSave = pageSave;
			m_sceneData = sceneData;
			m_limitOverData.KHEKNNFCAOI(sceneData.JKGFBFPIMGA_Rarity, sceneData.MKHFCGPJPFI_LimitOverCount, sceneData.MJBODMOLOBC_Luck);
			m_sceneDetails.text = sceneData.BGJNIABLBDB_GetSceneDetail();
			m_gachaInfoLayout.StartAnimGoStop(sceneData.IJIKIPDKCPP == 0 ? "02" : "01");
			m_loadingFlag = 0;
			GameManager.Instance.SceneIconCache.Load(sceneData.BCCHOBPJJKE_SceneId, sceneData.CGIELKDLHGE_GetEvolveId(), (IiconTexture texture) =>
			{
				//0xA6180C
				texture.Set(m_sceneIconImage);
				SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImage, texture as IconTexture, sceneData.MBMFJILMOBP_IsKira());
				m_loadingFlag |= LoadingFlag.Scene;
			});
			GameManager.Instance.MenuResidentTextureCache.LoadLogo((int)sceneData.EMIKBGHIOMN_SerieLogo, (IiconTexture texture) =>
			{
				//0xA619C8
				texture.Set(m_seriesIconImage);
				m_loadingFlag |= LoadingFlag.Logo;
			});
			m_paramTexts[0].text = sceneData.CMCKNKKCNDK_Status.Total.ToString();
			m_paramTexts[1].text = sceneData.CMCKNKKCNDK_Status.soul.ToString();
			m_paramTexts[2].text = sceneData.CMCKNKKCNDK_Status.vocal.ToString();
			m_paramTexts[3].text = sceneData.CMCKNKKCNDK_Status.charm.ToString();
			m_paramTexts[4].text = sceneData.CMCKNKKCNDK_Status.life.ToString();
			UnitWindowConstant.SetLuckText(m_paramTexts[5], sceneData.MJBODMOLOBC_Luck);
			m_paramTexts[6].text = sceneData.CMCKNKKCNDK_Status.support.ToString();
			m_paramTexts[7].text = sceneData.CMCKNKKCNDK_Status.fold.ToString();
			for(int i = 0; i < sceneData.CMCKNKKCNDK_Status.spNoteExpected.Length - 1; i++)
			{
				if(sceneData.CMCKNKKCNDK_Status.spNoteExpected[i + 1] < 1)
				{
					m_nortsTexts[i].text = "0";
					m_nortsLayout[i].StartChildrenAnimGoStop("02");
				}
				else
				{
					m_nortsTexts[i].text = sceneData.CMCKNKKCNDK_Status.spNoteExpected[i + 1].ToString();
					m_nortsLayout[i].StartChildrenAnimGoStop("01");
				}
			}
			m_skillDetailsButtons[0].ClearOnClickCallback();
			m_skillDetailsButtons[1].ClearOnClickCallback();
			m_centerSkillCrossFade.StartAllAnimLoop("st_wait");
			int centerSkill1 = sceneData.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
			int centerSkill2 = sceneData.MEOOLHNNMHL_GetCenterSkillId(true, 0, 0);
			if(centerSkill1 < 1)
			{
				UnitWindowConstant.SetInvalidText(m_skillNameTexts[0], TextAnchor.MiddleCenter);
				UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[0], TextAnchor.MiddleCenter);
				m_skillLevelTexts[0].text = "";
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[0], 0);
				m_skillDetailIconImages[0].enabled = false;
			}
			else
			{
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[0], (SkillRank.Type)sceneData.DHEFMEGKKDN_CenterSkillRank);
				m_skillNameTexts[0].text = sceneData.PFHJFIHGCKP_CenterSkillName1;
				m_skillNameTexts[0].alignment = TextAnchor.MiddleLeft;
				m_skillDescriptTexts[0].alignment = TextAnchor.MiddleLeft;
				m_skillLevelTexts[0].text = string.Format("Lv{0}", sceneData.DDEDANKHHPN_SkillLevel);
				if (UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[0], sceneData.IHLINMFMCDN_GetCenterSkillDesc(false), 1))
				{
					m_skillDetailsButtons[0].AddOnClickCallback(OnShowCenterSkillDetails);
					m_skillDetailIconImages[0].enabled = true;
				}
				else
				{
					m_skillDetailIconImages[0].enabled = false;

				}
				if (centerSkill1 != centerSkill2 && centerSkill2 > 0)
				{
					GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[1], (SkillRank.Type)sceneData.FFDCGHDNDFJ_CenterSkillRank2);
					m_skillNameTexts[1].text = sceneData.EFELCLMJEOL_CenterSkillName2;
					m_skillNameTexts[1].alignment = TextAnchor.MiddleLeft;
					m_skillDescriptTexts[1].alignment = TextAnchor.MiddleLeft;
					m_skillLevelTexts[1].text = string.Format("Lv{0}", sceneData.DDEDANKHHPN_SkillLevel);
					if (UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[1], sceneData.IHLINMFMCDN_GetCenterSkillDesc(true), 1))
					{
						m_skillDetailsButtons[1].AddOnClickCallback(OnShowCenterSkillDetails2);
						m_skillDetailIconImages[1].enabled = true;
					}
					else
					{
						m_skillDetailIconImages[1].enabled = false;
					}
					m_centerSkillCrossFade.StartAllAnimLoop("logo_act");
				}
			}
			m_skillDetailsButtons[2].ClearOnClickCallback();
			if(sceneData.HGONFBDIBPM_ActiveSkillId < 1)
			{
				UnitWindowConstant.SetInvalidText(m_skillNameTexts[2], TextAnchor.MiddleCenter);
				UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[2], TextAnchor.MiddleCenter);
				m_skillLevelTexts[2].text = "";
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[2], 0);
				m_skillDetailIconImages[2].enabled = false;
			}
			else
			{
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[2], (SkillRank.Type)sceneData.BEKGEAMJGEN_ActiveSkillRank);
				m_skillNameTexts[2].text = sceneData.ILCLGGPHHJO_ActiveSkillName;
				m_skillNameTexts[2].alignment = TextAnchor.MiddleLeft;
				m_skillDescriptTexts[2].alignment = TextAnchor.MiddleLeft;
				m_skillLevelTexts[2].text = string.Format("Lv{0}", sceneData.PNHJPCPFNFI_ActiveSkillLevel);
				if (UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[2], sceneData.PCMEMHPDABG_GetActiveSkillDesc(), 1))
				{
					m_skillDetailsButtons[2].AddOnClickCallback(OnShowActiveSkillDetails);
					m_skillDetailIconImages[2].enabled = true;
				}
				else
				{
					m_skillDetailIconImages[2].enabled = false;
				}
			}
			m_skillDetailsButtons[3].ClearOnClickCallback();
			int liveSkill1 = sceneData.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0);
			int liveSkill2 = sceneData.FILPDDHMKEJ_GetLiveSkillId(true, 0, 0);
			m_skillLayout.StartAllAnimGoStop("st_wait");
			for(int i = 0; i < m_liveSkillTypeLayout.Length; i++)
			{
				m_liveSkillTypeLayout[i].StartChildrenAnimGoStop("01");
			}
			bool hasLiveSkill = false;
			if(liveSkill1 > 0)
			{
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[3], (SkillRank.Type)sceneData.OAHMFMJIENM_LiveSkillRank);
				m_skillNameTexts[3].text = sceneData.NDPPEMCHKHA_LiveSkillName1;
				m_skillNameTexts[3].alignment = TextAnchor.MiddleLeft;
				m_skillDescriptTexts[3].alignment = TextAnchor.MiddleLeft;
				m_skillLevelTexts[3].text = string.Format("Lv{0}", sceneData.AADFFCIDJCB_LiveSkillLevel);
				if (UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[3], sceneData.KDGACEJPGFG_GetLiveSkillDesc(false), 1))
				{
					m_skillDetailsButtons[3].AddOnClickCallback(OnShowLiveSkillDetail);
					m_skillDetailIconImages[3].enabled = true;
				}
				else
				{
					m_skillDetailIconImages[3].enabled = false;
				}
				hasLiveSkill = true;
				PPGHMBNIAEC liveSkill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[liveSkill1 - 1];
				if(liveSkill.AOPELJFAMCL_LiveSkillType != 0)
				{
					m_liveSkillTypeLayout[0].StartChildrenAnimGoStop("02");
					GameManager.Instance.UnionTextureManager.SetImageLiveSkillType(m_liveSkillTypeImages[0], (LiveSkillType.Type) liveSkill.AOPELJFAMCL_LiveSkillType);
				}
			}
			if(liveSkill2 > 0)
			{
				if(sceneData.BLPHPMBFIEI_LiveSkillHasSwitchPatternCond())
				{
					GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[4], (SkillRank.Type)sceneData.ELNJADBILOM_LiveSkillRank2);
					m_skillNameTexts[4].text = sceneData.LNLECENGMKK_LiveSkillName2;
					m_skillNameTexts[4].alignment = TextAnchor.MiddleLeft;
					m_skillDescriptTexts[4].alignment = TextAnchor.MiddleLeft;
					m_skillLevelTexts[4].text = string.Format("Lv{0}", sceneData.AADFFCIDJCB_LiveSkillLevel);
					if (UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[4], sceneData.KDGACEJPGFG_GetLiveSkillDesc(true), 1))
					{
						m_skillDetailsButtons[4].AddOnClickCallback(OnShowLiveSkillDetail2);
						m_skillDetailIconImages[4].enabled = true;
					}
					else
					{
						m_skillDetailIconImages[4].enabled = false;
					}
					m_skillLayout.StartAnimLoop("logo_act");
					PPGHMBNIAEC liveSkill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[liveSkill2 - 1];
					if (liveSkill.AOPELJFAMCL_LiveSkillType != 0)
					{
						m_liveSkillTypeLayout[1].StartChildrenAnimGoStop("02");
						GameManager.Instance.UnionTextureManager.SetImageLiveSkillType(m_liveSkillTypeImages[1], (LiveSkillType.Type)liveSkill.AOPELJFAMCL_LiveSkillType);
					}
				}
			}
			if(!hasLiveSkill)
			{
				UnitWindowConstant.SetInvalidText(m_skillNameTexts[3], TextAnchor.MiddleCenter);
				UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[3], TextAnchor.MiddleCenter);
				m_skillLevelTexts[3].text = "";
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[3], 0);
				m_skillDetailIconImages[3].enabled = false;
			}
			int j = 0;
			for (int i = 0; i < playerData.NBIGLBMHEDC_Divas.Count; i++)
			{
				if(playerData.NBIGLBMHEDC_Divas[i].IPJMPBANBPP_Enabled)
				{
					m_strBuilder.Clear();
					m_strBuilder.AppendFormat("cmn_chk_icon_{0:D2}", playerData.NBIGLBMHEDC_Divas[i].AHHJLDLAPAN_DivaId);
					m_compatibleDivaIconImages[j].enabled = true;
					m_compatibleDivaIconImages[j].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(m_strBuilder.ToString()));
					m_compatibleMaskIconImages[j].enabled = !sceneData.DCLLIDMKNGO_IsDivaCompatible(playerData.NBIGLBMHEDC_Divas[i].AHHJLDLAPAN_DivaId);
					j++;
				}
			}
			for(; j < m_compatibleDivaIconImages.Length; j++)
			{
				m_compatibleDivaIconImages[j].enabled = false;
				m_compatibleMaskIconImages[j].enabled = false;
			}
			m_sceneIconDeccoration.SetActive(true);
			m_sceneIconDeccoration.Change(sceneData, DisplayType.Level);
			m_regulationButtons[0].Setup(0, RegulationButton.Type.Live, m_sceneData);
			m_regulationButtons[1].Setup(0, RegulationButton.Type.Center, m_sceneData);
			if(m_sceneData.KELFCMEOPPM_EpisodeId < 1)
			{
				m_episodeName.text = TextConstant.InvalidText;
				m_episodeButton.Hidden = true;
			}
			else
			{
				m_episodeData.KHEKNNFCAOI(sceneData.KELFCMEOPPM_EpisodeId);
				m_episodeName.text = m_episodeData.OPFGFINHFCE_Name;
				m_episodeButton.Hidden = false;
			}
			m_sceneButton.Disable = isFriend || isDisableZoom;
			UpdateLimitBreak();
			m_luckLeafButton.Disable = isFriend;
			m_statusDispNum = GetStatusTableNum(sceneData, isDisableLuckyLeaf);
			int a = 0;
			if(pageSave == PageSave.Pickup)
			{
				a = GameManager.Instance.localSave.EPJOACOONAC_GetSave().LDNJHLLKEIG_StatusPopup.ILEFFJCOGOG_GachaStatusPage;
			}
			else if(pageSave == PageSave.Player)
			{
				a = GameManager.Instance.localSave.EPJOACOONAC_GetSave().LDNJHLLKEIG_StatusPopup.ICBNEOCAGKF_SceneStatusPage;
			}
			m_statusDispIndex = a;
			if (m_statusDispIndex >= m_statusDispNum)
				m_statusDispIndex = 0;
			m_changeStatusButton.SetPage(a < m_statusDispNum ? a + 1 : 1, m_statusDispNum);
			UpdateStatus();
			m_viewer.gameObject.SetActive(false);
		}

		// // RVA: 0xA5EF68 Offset: 0xA5EF68 VA: 0xA5EF68
		private int GetStatusTableNum(GCIJNCFDNON_SceneInfo sceneData, bool isDisableLuckyLeaf)
		{
			if(!isDisableLuckyLeaf)
			{
				m_limitOverData.KHEKNNFCAOI(sceneData.JKGFBFPIMGA_Rarity, sceneData.MKHFCGPJPFI_LimitOverCount, sceneData.MJBODMOLOBC_Luck);
				if (m_limitOverData.LJHOOPJACPI_LeafMax != 0)
				{
					if(sceneData.MJBODMOLOBC_Luck > 0)
					{
						return m_statuChangeAnimeLabel.Length;
					}
				}
			}
			return m_statuChangeAnimeLabel.Length - 1;
		}

		// // RVA: 0xA5F194 Offset: 0xA5F194 VA: 0xA5F194
		private void UpdateStatus()
		{
			m_statusChangeLayout.StartChildrenAnimGoStop(m_statuChangeAnimeLabel[m_statusDispIndex]);
		}

		// // RVA: 0xA5EEC4 Offset: 0xA5EEC4 VA: 0xA5EEC4
		public void UpdateLimitBreak()
		{
			m_luckyLeaf.SetLeafNum(m_limitOverData.DJEHLEJCPEL_LeafNum, m_limitOverData.LJHOOPJACPI_LeafMax);
			m_limitBreak.SetValue(m_limitOverData.CMCKNKKCNDK);
		}

		// // RVA: 0xA5F8CC Offset: 0xA5F8CC VA: 0xA5F8CC
		// private void OnPushAbilityButton() { }

		// // RVA: 0xA5F960 Offset: 0xA5F960 VA: 0xA5F960
		private void OnShowCenterSkillDetails()
		{
			ShowSkillWindow(m_sceneData.PFHJFIHGCKP_CenterSkillName1, m_sceneData.IHLINMFMCDN_GetCenterSkillDesc(false));
		}

		// // RVA: 0xA5FD4C Offset: 0xA5FD4C VA: 0xA5FD4C
		private void OnShowCenterSkillDetails2()
		{
			ShowSkillWindow(m_sceneData.EFELCLMJEOL_CenterSkillName2, m_sceneData.IHLINMFMCDN_GetCenterSkillDesc(true));
		}

		// // RVA: 0xA5FDB0 Offset: 0xA5FDB0 VA: 0xA5FDB0
		private void OnShowActiveSkillDetails()
		{
			ShowSkillWindow(m_sceneData.ILCLGGPHHJO_ActiveSkillName, m_sceneData.PCMEMHPDABG_GetActiveSkillDesc());
		}

		// // RVA: 0xA5FE10 Offset: 0xA5FE10 VA: 0xA5FE10
		private void OnShowLiveSkillDetail()
		{
			ShowSkillWindow(m_sceneData.NDPPEMCHKHA_LiveSkillName1, m_sceneData.KDGACEJPGFG_GetLiveSkillDesc(false));
		}

		// // RVA: 0xA5FE74 Offset: 0xA5FE74 VA: 0xA5FE74
		private void OnShowLiveSkillDetail2()
		{
			ShowSkillWindow(m_sceneData.LNLECENGMKK_LiveSkillName2, m_sceneData.KDGACEJPGFG_GetLiveSkillDesc(true));
		}

		// // RVA: 0xA5F9C4 Offset: 0xA5F9C4 VA: 0xA5F9C4
		private void ShowSkillWindow(string name, string descript)
		{
			if(MenuScene.Instance != null)
			{
				MenuScene.Instance.UnitSaveWindowControl.ShowSkillWindow(name, descript);
			}
			else
			{
				TextPopupSetting s = new TextPopupSetting();
				s.TitleText = MessageManager.Instance.GetMessage("menu", "popup_text_16");
				s.WindowSize = SizeType.Middle;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				s.Text = name + JpStringLiterals.StringLiteral_5812 + descript;
				PopupWindowManager.Show(s, null, null, null, null);
			}
		}

		// // RVA: 0xA5FED8 Offset: 0xA5FED8 VA: 0xA5FED8
		private void OnSceneZoom()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(SceneZoomCoroutine());
		}

		// // RVA: 0xA5FFD8 Offset: 0xA5FFD8 VA: 0xA5FFD8
		private void OnBackButton()
		{
			m_viewer.PerformClick();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70F9CC Offset: 0x70F9CC VA: 0x70F9CC
		// // RVA: 0xA5FF4C Offset: 0xA5FF4C VA: 0xA5FF4C
		private IEnumerator SceneZoomCoroutine()
		{
			int sceneId; // 0x14
			int evolveId; // 0x18
			sbyte attr; // 0x1C
			byte baseRare; // 0x1D
			float speed; // 0x20
			float t; // 0x24
			Vector2 startPosition; // 0x28
			Vector3 startScale; // 0x30
			Vector2 endPosition; // 0x3C
			Vector3 endScale; // 0x44
			bool isEvolve; // 0x50

			//0xA62760
			sceneId = m_sceneData.BCCHOBPJJKE_SceneId;
			evolveId = m_sceneData.CGIELKDLHGE_GetEvolveId();
			attr = m_sceneData.JGJFIJOCPAG_SceneAttr;
			baseRare = m_sceneData.JKGFBFPIMGA_Rarity;
			m_windowControl.InputDisable();
			if(m_sceneCardCache == null)
			{
				m_sceneCardCache = new SceneCardTextureCache();
				yield return Co.R(m_sceneCardCache.Initialize(false));
			}
			//LAB_00a62920
			if(m_sceneData.JKGFBFPIMGA_Rarity < 4)
			{
				evolveId = 1;
			}
			yield return this.StartCoroutineWatched(LoadTexture(sceneId, evolveId, null));
			yield return GameManager.Instance.SceneIconCache.LoadKiraMaterial(null);
			Transform t1 = m_backImage.canvas.GetComponent<RectTransform>().transform.Find("Root");
			if (t1 == null)
				yield break;
			m_backImage.enabled = true;
			m_backImage.rectTransform.sizeDelta = t1.GetComponent<RectTransform>().sizeDelta;
			m_backImage.rectTransform.anchoredPosition = PopupWindowControl.GetContentCenterOffset(SizeType.Large, true) * -1;
			m_zoomSceneImage.gameObject.SetActive(true);
			speed = 10;
			t = 0;
			startPosition = m_zoomSceneImage.rectTransform.anchoredPosition;
			startScale = SceneImageViewer.GetStartScale(m_sceneData.JKGFBFPIMGA_Rarity, t1.GetComponent<RectTransform>().sizeDelta.x);
			endPosition = Vector2.zero;
			endScale = Vector3.one;
			isEvolve = false;
			if (!m_sceneData.JOKJBMJBLBB_Single && evolveId > 1)
				isEvolve = true;
			m_zoomSceneImage.rectTransform.sizeDelta = SceneImageViewer.GetCardSize(t1.GetComponent<RectTransform>().sizeDelta.x);
			m_zoomSceneImage.uvRect = SceneImageViewer.GetCardUv(m_sceneData.JKGFBFPIMGA_Rarity);
			m_KiraImage.rectTransform.sizeDelta = m_zoomSceneImage.rectTransform.sizeDelta;
			m_KiraImage.uvRect = m_zoomSceneImage.uvRect;
			m_KiraOverlayImage.rectTransform.sizeDelta = m_zoomSceneImage.rectTransform.sizeDelta;
			m_KiraOverlayImage.uvRect = m_zoomSceneImage.uvRect;
			yield return Co.R(m_viewer.Co_LoadRareFrame(m_sceneData.JKGFBFPIMGA_Rarity));
			m_viewer.SetFrame(baseRare, attr, m_sceneData.JKGFBFPIMGA_Rarity != m_sceneData.EKLIPGELKCL_SceneRarity);
			m_viewer.IsZoomable = baseRare > 3;
			float s = SceneImageViewer.GetEndScale(m_sceneData.JKGFBFPIMGA_Rarity);
			endScale = new Vector3(s, s, 1);
			m_viewer.gameObject.SetActive(true);
			m_viewer.gameObject.transform.SetAsLastSibling();
			m_viewer.Initialize(isEvolve, m_sceneData.JKGFBFPIMGA_Rarity, m_sceneData.MCOMAOELHOG_IsKira == 1);
			m_viewer.Show();
			Vector2 pos = Vector2.Lerp(startPosition, endPosition, t);
			Vector3 scale = Vector3.Lerp(startScale, endScale, t);
			while(t <= 1)
			{
				t += Time.deltaTime * speed;
				pos = Vector2.Lerp(startPosition, endPosition, t);
				scale = Vector3.Lerp(startScale, endScale, t);
				m_zoomSceneImage.rectTransform.anchoredPosition = pos;
				m_zoomSceneImage.rectTransform.localScale = scale;
				m_KiraImage.rectTransform.anchoredPosition = pos;
				m_KiraImage.rectTransform.localScale = scale;
				m_KiraOverlayImage.rectTransform.anchoredPosition = pos;
				m_KiraOverlayImage.rectTransform.localScale = scale;
				yield return null;
			}
			m_isEndView = false;
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
			while (!m_isEndView)
				yield return null;
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			m_viewer.Close();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			t = 0;
			while(t <= 1)
			{
				t += Time.deltaTime * speed;
				pos = Vector2.Lerp(endPosition, startPosition, t);
				scale = Vector3.Lerp(endScale, startScale, t);
				m_zoomSceneImage.rectTransform.anchoredPosition = pos;
				m_zoomSceneImage.rectTransform.localScale = scale;
				m_KiraImage.rectTransform.anchoredPosition = pos;
				m_KiraImage.rectTransform.localScale = scale;
				m_KiraOverlayImage.rectTransform.anchoredPosition = pos;
				m_KiraOverlayImage.rectTransform.localScale = scale;
				yield return null;
			}
			Resources.UnloadAsset(m_zoomSceneImage.texture);
			m_viewer.gameObject.transform.SetAsFirstSibling();
			m_sceneCardCache.Clear();
			m_zoomSceneImage.texture = null;
			m_zoomSceneImage.gameObject.SetActive(false);
			m_backImage.enabled = false;
			m_windowControl.InputEnable();
			m_viewer.SetTexture(null);
			yield return null;
			yield return Co.R(m_viewer.Co_ReleaseRareFrame());
			m_viewer.gameObject.SetActive(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70FA44 Offset: 0x70FA44 VA: 0x70FA44
		// // RVA: 0xA60024 Offset: 0xA60024 VA: 0xA60024
		private IEnumerator LoadTexture(int sceneId, int evolvId, UnityAction endAction)
		{
			//0xA624F8
			bool isLoding = true;
			m_sceneCardCache.Load(sceneId, evolvId, (IiconTexture texture) =>
			{
				//0xA61AF8
				m_viewer.SetTexture(texture);
				isLoding = false;
			});
			while (isLoding)
				yield return null;
			if (endAction != null)
				endAction();
		}

		// // RVA: 0xA6011C Offset: 0xA6011C VA: 0xA6011C
		private void ChangeEvolvImage(int page)
		{
			int evolvId = 2;
			if (page < 2)
				evolvId = page + 1;
			m_viewer.InputDisable();
			this.StartCoroutineWatched(LoadTexture(m_sceneData.BCCHOBPJJKE_SceneId, evolvId, () =>
			{
				//0xA61B4C
				m_viewer.SetFrame(m_sceneData.JKGFBFPIMGA_Rarity, m_sceneData.JGJFIJOCPAG_SceneAttr, evolvId > 1);
				m_viewer.InputEnable();
			}));
		}

		// RVA: 0xA60298 Offset: 0xA60298 VA: 0xA60298
		private void Awake()
		{
			m_luckyLeafTerminateSetting.TitleText = MessageManager.Instance.GetMessage("menu", "limit_over_popup_title");
			m_luckyLeafTerminateSetting.m_parent = transform;
			m_luckyLeafTerminateSetting.WindowSize = SizeType.Middle;
			m_luckyLeafSetting.TitleText = MessageManager.Instance.GetMessage("menu", "limit_over_popup_title");
			m_luckyLeafSetting.m_parent = transform;
			m_luckyLeafSetting.WindowSize = SizeType.Large;
		}

		// RVA: 0xA60474 Offset: 0xA60474 VA: 0xA60474
		private void Update()
		{
			if(m_sceneCardCache != null)
				m_sceneCardCache.Update();
		}

		// // RVA: 0xA60488 Offset: 0xA60488 VA: 0xA60488
		private void OnShowLimitBreakPopup()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_limitOverData.KHEKNNFCAOI(m_sceneData.JKGFBFPIMGA_Rarity, m_sceneData.MKHFCGPJPFI_LimitOverCount, m_sceneData.MJBODMOLOBC_Luck);
			if(!m_limitOverData.EOBACDCDGOF)
			{
				m_luckyLeafSetting.Setup(m_sceneData);
				if(!m_limitOverData.JMHIDPKHELB)
				{
					m_luckyLeafSetting.Buttons = new ButtonInfo[2]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.SkillRelease, Type = PopupButton.ButtonType.Positive }
					};
				}
				else
				{
					m_luckyLeafSetting.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
					};
				}
				PopupWindowManager.Show(m_luckyLeafSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xA61244
					if(type == PopupButton.ButtonType.Positive)
					{
						MNDAMOGGJBJ m = new MNDAMOGGJBJ();
						m.KHEKNNFCAOI(null);
						m.MDHKGJJBLNL();
						m.INLBMFMOHCI_CostItems.Add(new MNDAMOGGJBJ.JFJJNPJNBPI() { PPFNGGCBJKC_Id = m_limitOverData.MJNOAMAFNHA, HMFFHLPNMPH_Cnt = m_limitOverData.IJEOIMGILCK });
						m.CMBGGPOFBOO_UcCost = m_limitOverData.GNKGDDMMJPF;
						this.StartCoroutineWatched(LimitOverMainCoroutine(m));
					}
				}, null, null, null);
			}
			else
			{
				m_luckyLeafTerminateSetting.Setup(m_sceneData);
				m_luckyLeafTerminateSetting.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				PopupWindowManager.Show(m_luckyLeafTerminateSetting, null, null, null, null);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70FABC Offset: 0x70FABC VA: 0x70FABC
		// // RVA: 0xA6099C Offset: 0xA6099C VA: 0xA6099C
		private IEnumerator LimitOverMainCoroutine(MNDAMOGGJBJ itemData)
		{
			//0xA61C74
			yield return Co.R(MenuScene.Instance.PopupUseItemWindow.Show(itemData, UseItemList.Unlock.Default));
			if(MenuScene.Instance.PopupUseItemWindow.Result != PopupUseItemWindow.UseItemResult.OK)
				yield break;
			m_windowControl.InputDisable();
			if(itemData.KMIFDLLCBEL() != 1)
				yield break;
			if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsShowKiraPlatePopUp2))
			{
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsShowKiraPlatePopUp2, true);
			}
			bool done = false;
			bool err = false;
			AEKDNMPPOJN.AHKFPJJKHFL(m_sceneData.BCCHOBPJJKE_SceneId, () =>
			{
				//0xA61C4C
				done = true;
			}, () =>
			{
				//0xA61C58
				done = true;
				err = true;
			});
			while(!done)
				yield return null;
			if(err)
			{
				MenuScene.Instance.GotoTitle();
			}
			else
			{
				MMPBPOIFDAF_Scene.PMKOFEIONEG scene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[m_sceneData.BCCHOBPJJKE_SceneId - 1];
				m_sceneData.MKHFCGPJPFI_LimitOverCount = scene.DMNIMMGGJJJ_Leaf;
				m_limitOverData.KHEKNNFCAOI(m_sceneData.JKGFBFPIMGA_Rarity, scene.DMNIMMGGJJJ_Leaf, m_sceneData.MJBODMOLOBC_Luck);
				done = false;
				MenuScene.Instance.LimitOverControl.ShowRelease(m_sceneData, m_limitOverData, () =>
				{
					//0xA61414
					UpdateLimitBreak();
					m_sceneIconDeccoration.Change(m_sceneData, DisplayType.Level);
					GameManager.Instance.SceneIconCache.Load(m_sceneData.BCCHOBPJJKE_SceneId, m_sceneData.CGIELKDLHGE_GetEvolveId(), (IiconTexture texture) =>
					{
						//0xA6162C
						texture.Set(m_sceneIconImage);
						SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImage, texture as IconTexture, m_sceneData.MBMFJILMOBP_IsKira());
					});
					m_windowControl.m_titleText.text = GameMessageManager.GetSceneCardName(m_sceneData);
				}, () =>
				{
					//0xA61C64
					done = true;
				});
				while(!done)
					yield return null;
				m_windowControl.InputEnable();
			}
		}

		// // RVA: 0xA60A64 Offset: 0xA60A64 VA: 0xA60A64
		private void OnShowEpisodePopup()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			PopupAddEpisodeContentSetting s = new PopupAddEpisodeContentSetting();
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			s.m_parent = transform;
			s.IsCaption = false;
			s.WindowSize = SizeType.Middle;
			s.EpisodeId = m_sceneData.KELFCMEOPPM_EpisodeId;
			s.Type = LayoutPopupAddEpisode.Type.ViewEpisode;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType buttonType, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0xA61808
				return;
			}, null, null, null);
		}
	}
}
