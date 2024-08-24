using XeSys.Gfx;
using System;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System.Text;
using mcrs;

namespace XeApp.Game.Menu
{
	public class DivaStatusParam : LayoutUGUIScriptBase
	{
		private enum LoadingFlags
		{
			DivaIcon = 1,
			MainScene = 2,
			SubScene1 = 4,
			SbuScene2 = 8,
			Logo = 16,
			All = 31,
		}

		private enum SkillDispPartsType
		{
			Center = 0,
			Center2 = 1,
			Active = 2,
			Live1 = 3,
			Live1_2 = 4,
			Live2 = 5,
			Live2_2 = 6,
			Live3 = 7,
			Live3_3 = 8,
			Num = 9,
		}

		private enum SkillDetailButtonsType
		{
			Center = 0,
			Center_2 = 1,
			Active = 2,
			Live1 = 3,
			Live1_2 = 4,
			Live2 = 5,
			Live2_2 = 6,
			Live3 = 7,
			Live3_2 = 8,
			Num = 9,
		}

		// Namespace: 
		[Serializable]
		public class DivaStatusSelectScene : UnityEvent<int>
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
		private StayButton[] m_sceneButtons; // 0x28
		[SerializeField]
		private InfoButton m_changeStatusButton; // 0x2C
		[SerializeField]
		private RegulationButton[] m_regulationButtons; // 0x30
		[SerializeField]
		private ActionButton[] m_skillDetailsButtons; // 0x34
		[SerializeField]
		private RawImageEx m_divaIconImage; // 0x38
		[SerializeField]
		private RawImageEx m_logoIconImage; // 0x3C
		[SerializeField]
		private RawImageEx[] m_sceneIconImage; // 0x40
		[SerializeField]
		private RawImageEx[] m_skillRankIconImages; // 0x44
		[SerializeField]
		private RawImageEx[] m_skillDetailIconImages; // 0x48
		[SerializeField]
		private RawImageEx[] m_liveSkillTypeImages; // 0x4C
		[SerializeField]
		private DivaStatusSelectScene m_onSceneSelectEvent; // 0x50
		[SerializeField]
		private DivaStatusSelectScene m_onShowStatusEvent; // 0x54
		private DivaIconDecoration m_divaIconDecoration; // 0x58
		private SceneIconDecoration[] m_sceneIconDecoration = new SceneIconDecoration[3]; // 0x5C
		private AbsoluteLayout m_statusChangeLayout; // 0x60
		private AbsoluteLayout m_centerSkillCrossFade; // 0x64
		private AbsoluteLayout m_centerSkillMisMatch; // 0x68
		private AbsoluteLayout m_activeSkillMisMatch; // 0x6C
		private AbsoluteLayout[] m_liveSkillCrossFade; // 0x70
		private AbsoluteLayout[] m_liveSkillMisMatch; // 0x74
		private AbsoluteLayout[] m_liveSkillTypeTbl; // 0x78
		private AbsoluteLayout[] m_nortsIconLayout = new AbsoluteLayout[6]; // 0x7C
		private FFHPBEPOMAK_DivaInfo m_divaData; // 0x80
		private EEDKAACNBBG_MusicData m_musicData; // 0x84
		private List<GCIJNCFDNON_SceneInfo> m_sceneList = new List<GCIJNCFDNON_SceneInfo>(3); // 0x88
		private EDMIONMCICN m_calcStatusResult; // 0x8C
		private StatusData m_status = new StatusData(); // 0xB0
		private int m_statusDispIndex; // 0xB4
		private int m_divaSlotNumber; // 0xB8
		private bool m_isCenterDiva; // 0xBC
		private bool m_isFriend; // 0xBD
		private DivaStatusParam.LoadingFlags m_lodingFlags; // 0xBE
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0xC0
		private static readonly string[] m_statuChangeAnimeLabel = new string[3]
		{
			"01",
			"02",
			"03"
		}; // 0x0
		private const string LevelFormat = "Lv{0}";
		private readonly int[] LiveSkillDispPartsTypes = new int[3] {
			3, 5, 7
		}; // 0xC4
		private readonly int[] LiveSkillDetailButtonsTypes = new int[3] {
			3, 5, 7
		}; // 0xC8

		public DivaStatusParam.DivaStatusSelectScene OnSceneSelectEvent { get { return m_onSceneSelectEvent; } } //0x1267014
		public DivaStatusParam.DivaStatusSelectScene OnShowStatusEvent { get { return m_onShowStatusEvent; } } //0x126701C

		// // RVA: 0x1267024 Offset: 0x1267024 VA: 0x1267024
		public bool IsLoading()
		{
			return m_lodingFlags != LoadingFlags.All;
		}

		// RVA: 0x1267038 Offset: 0x1267038 VA: 0x1267038 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_statusChangeLayout = layout.FindViewByExId("sw_chk_chara_all_swtbl_chara_skill") as AbsoluteLayout;
			m_centerSkillCrossFade = layout.FindViewByExId("sw_chara_skill01_sw_c_skill_cf_anim") as AbsoluteLayout;
			for(int i = 0; i < m_nortsIconLayout.Length; i++)
			{
				m_strBuilder.Clear();
				m_strBuilder.AppendFormat("sw_chara_note_swtbl_st_note{0:D2}", i + 1);
				m_nortsIconLayout[i] = layout.FindViewByExId(m_strBuilder.ToString()) as AbsoluteLayout;
			}
			for(int i = 0; i < m_sceneButtons.Length; i++)
			{
				int sceneSlotIndex = i;
				m_sceneButtons[i].AddOnClickCallback(() =>
				{
					//0x127104C
					OnSelectScene(sceneSlotIndex);
				});
				m_sceneButtons[i].AddOnStayCallback(() =>
				{
					//0x127107C
					OnShowStatus(sceneSlotIndex);
				});
			}
			m_changeStatusButton.OnClickButton = (int page) =>
			{
				//0x1270B84
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				m_statusDispIndex++;
				if(m_statusDispIndex >= m_statuChangeAnimeLabel.Length)
					m_statusDispIndex = 0;
				UpdateStatus();
				UpdateSkillMisMatch(m_statusDispIndex);
			};
			for(int i = 0; i < m_sceneIconDecoration.Length; i++)
			{
				m_sceneIconDecoration[i] = new SceneIconDecoration();
			}
			m_centerSkillMisMatch = layout.FindViewByExId("sw_chara_skill01_swtbl_skill_mismatch_01") as AbsoluteLayout;
			m_activeSkillMisMatch = layout.FindViewByExId("sw_chara_skill01_swtbl_skill_mismatch_02") as AbsoluteLayout;
			m_liveSkillCrossFade = new AbsoluteLayout[3];
			for(int i = 0; i < m_liveSkillCrossFade.Length; i++)
			{
				m_strBuilder.Clear();
				m_strBuilder.AppendFormat("sw_chara_skill02_sw_live_skill_cf_anim_{0:D2}", i + 1);
				m_liveSkillCrossFade[i] = layout.FindViewByExId(m_strBuilder.ToString()) as AbsoluteLayout;
			}
			m_liveSkillMisMatch = new AbsoluteLayout[3];
			for(int i = 0; i < 3; i++)
			{
				m_strBuilder.Clear();
				m_strBuilder.AppendFormat("sw_chara_skill02_swtbl_skill_mismatch_{0:D2}", i + 1);
				m_liveSkillMisMatch[i] = layout.FindViewByExId(m_strBuilder.ToString()) as AbsoluteLayout;
			}
			m_liveSkillTypeTbl = new AbsoluteLayout[6];
			for(int i = 0; i < 3; i++)
			{
				AbsoluteLayout l = m_liveSkillCrossFade[i].FindViewByExId("sw_live_skill_cf_anim_live_skill_01") as AbsoluteLayout;
				m_liveSkillTypeTbl[i * 2] = l.FindViewByExId("live_skill_swtbl_lskill") as AbsoluteLayout;
				l = m_liveSkillCrossFade[i].FindViewByExId("sw_live_skill_cf_anim_live_skill_02") as AbsoluteLayout;
				m_liveSkillTypeTbl[i * 2 + 1] = l.FindViewByExId("live_skill_swtbl_lskill") as AbsoluteLayout;
			}
			m_divaIconDecoration = new DivaIconDecoration();
			m_calcStatusResult.OBKGEDCKHHE_Init();
			ClearLoadedCallback();
			return true;
		}

		// // RVA: 0x1267FE0 Offset: 0x1267FE0 VA: 0x1267FE0
		public void InitializeDecoration()
		{
			for(int i = 0; i < m_sceneIconDecoration.Length; i++)
			{
				m_sceneIconDecoration[i].Initialize(m_sceneIconImage[i].gameObject, SceneIconDecoration.Size.M, null, null);
			}
			m_divaIconDecoration.Initialize(m_divaIconImage.gameObject, DivaIconDecoration.Size.L, null, null);
		}

		// // RVA: 0x1268138 Offset: 0x1268138 VA: 0x1268138
		private void ReleaseDecoration()
		{
			for(int i = 0; i < m_sceneIconDecoration.Length; i++)
			{
				m_sceneIconDecoration[i].Release();
			}
			m_divaIconDecoration.Release();
		}

		// // RVA: 0x12681E8 Offset: 0x12681E8 VA: 0x12681E8
		public void Release()
		{
			ReleaseDecoration();
			m_sceneList.Clear();
			m_divaData = null;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().LDNJHLLKEIG_StatusPopup.EPJPNFIMODP_DivaStatusPage = m_statusDispIndex;
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}

		// // RVA: 0x126835C Offset: 0x126835C VA: 0x126835C
		public void UpdateContent(FFHPBEPOMAK_DivaInfo divaData, DFKGGBMFFGB_PlayerInfo playerData, int divaSlotNumber, EEDKAACNBBG_MusicData musicData)
		{
			m_sceneList.Clear();
			if(divaData.FGFIBOBAPIA_SceneId > 0)
			{
				m_sceneList.Add(playerData.OPIBAPEGCLA_Scenes[divaData.FGFIBOBAPIA_SceneId - 1]);
			}
			else
			{
				m_sceneList.Add(null);
			}
			for(int i = 0; i < divaData.DJICAKGOGFO_SubSceneIds.Count; i++)
			{
				if(divaData.DJICAKGOGFO_SubSceneIds[i] < 1)
				{
					m_sceneList.Add(null);
				}
				else
				{
					m_sceneList.Add(playerData.OPIBAPEGCLA_Scenes[divaData.DJICAKGOGFO_SubSceneIds[i] - 1]);
				}
			}
			CMMKCEPBIHI.AECDJDIJJKD_ApplySkills(ref m_calcStatusResult, divaData, null, playerData, null, null, null);
			m_status.Clear();
			m_calcStatusResult.IMLOCECFHGK(ref m_status);
			m_status.Add(divaData.CMCKNKKCNDK_EquippedStatus);
			UpdateContent(divaData, m_sceneList, divaSlotNumber, musicData);
			m_divaIconDecoration.Change(divaData, playerData, DisplayType.Level);
			m_isFriend = false;
		}

		// // RVA: 0x126EA00 Offset: 0x126EA00 VA: 0x126EA00
		public void UpdateContent(EAJCBFGKKFA_FriendInfo friendData, EEDKAACNBBG_MusicData musicData)
		{
			m_status.Clear();
			m_sceneList.Clear();
			m_sceneList.Add(friendData.KHGKPKDBMOH_GetAssistScene());
			for(int i = 0; i < friendData.HDJOHAJPGBA_SubScene.Count; i++)
			{
				m_sceneList.Add(friendData.HDJOHAJPGBA_SubScene[i]);
			}
			m_status.Add(friendData.JIGONEMPPNP_Diva.CMCKNKKCNDK_EquippedStatus);
			UpdateContent(friendData.JIGONEMPPNP_Diva, m_sceneList, -1, musicData);
			m_isFriend = true;
			m_divaIconDecoration.Change(friendData.JIGONEMPPNP_Diva, friendData, DisplayType.Level, friendData.KHGKPKDBMOH_GetAssistScene());
		}

		// // RVA: 0x1268764 Offset: 0x1268764 VA: 0x1268764
		private void UpdateContent(FFHPBEPOMAK_DivaInfo divaData, List<GCIJNCFDNON_SceneInfo> sceneList, int divaSlotNumber, EEDKAACNBBG_MusicData musicData)
		{
			m_divaSlotNumber = divaSlotNumber;
			m_divaData = divaData;
			m_musicData = musicData;
			m_lodingFlags = 0;
			for(int i = 0; i < m_liveSkillTypeTbl.Length; i++)
			{
				m_liveSkillTypeTbl[i].StartChildrenAnimGoStop("01");
			}
			MenuScene.Instance.DivaIconCache.LoadPortraitIcon(divaData.AHHJLDLAPAN_DivaId, divaData.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, divaData.EKFONBFDAAP_ColorId, (IiconTexture texture) =>
			{
				//0x1270CA0
				texture.Set(m_divaIconImage);
				m_lodingFlags |= LoadingFlags.DivaIcon;
			});
			MenuScene.Instance.MenuResidentTextureCache.LoadLogo(divaData.AIHCEGFANAM_Serie, (IiconTexture texture) =>
			{
				//0x1270D8C
				texture.Set(m_logoIconImage);
				m_lodingFlags |= LoadingFlags.Logo;
			});
			if(sceneList[0] == null)
			{
				MenuScene.Instance.SceneIconCache.Load(0, 0, (IiconTexture texture) =>
				{
					//0x1270E98
					texture.Set(m_sceneIconImage[0]);
					SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImage[0], texture as IconTexture, false);
					m_lodingFlags |= LoadingFlags.MainScene;
				});
				for(int i = 0; i < 9; i++)
				{
					UnitWindowConstant.SetInvalidText(m_skillNameTexts[i], TextAnchor.MiddleCenter);
					UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[i], TextAnchor.MiddleCenter);
					GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[i], 0);
					m_skillLevelTexts[i].text = "";
					m_skillDetailIconImages[i].enabled = false;
				}
				m_sceneIconDecoration[0].SetActive(false);
			}
			else
			{
				MenuScene.Instance.SceneIconCache.Load(sceneList[0].BCCHOBPJJKE_SceneId, sceneList[0].CGIELKDLHGE_GetEvolveId(), (IiconTexture texture) => {
					//0x12710AC
					texture.Set(m_sceneIconImage[0]);
					SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImage[0], texture as IconTexture, sceneList[0].MBMFJILMOBP_IsKira());
					m_lodingFlags |= LoadingFlags.MainScene;
				});
				m_skillDetailsButtons[0].ClearOnClickCallback();
				m_skillDetailsButtons[1].ClearOnClickCallback();
				m_centerSkillCrossFade.StartAllAnimLoop("st_wait");
				int centerSkill1 = sceneList[0].MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
				int centerSkill2 = sceneList[0].MEOOLHNNMHL_GetCenterSkillId(true, 0, 0);
				if(centerSkill1 == centerSkill2)
					centerSkill2 = 0;
				if(musicData == null)
				{
					if(centerSkill1 > 0)
					{
						GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[0], (SkillRank.Type)sceneList[0].DHEFMEGKKDN_CenterSkillRank);
						m_skillNameTexts[0].text = sceneList[0].PFHJFIHGCKP_CenterSkillName1;
						m_skillNameTexts[0].alignment = TextAnchor.MiddleLeft;
						m_skillDescriptTexts[0].alignment = TextAnchor.MiddleLeft;
						m_skillLevelTexts[0].text = string.Format("Lv{0}", sceneList[0].DDEDANKHHPN_SkillLevel);
						bool b = UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[0], sceneList[0].IHLINMFMCDN_GetCenterSkillDesc(false), 1);
						if(b)
						{
							m_skillDetailsButtons[0].AddOnClickCallback(OnShowCenterSkillDetails);
						}
						m_skillDetailIconImages[0].enabled = b;
						if(centerSkill2 > 0)
						{
							GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[1], (SkillRank.Type)sceneList[0].FFDCGHDNDFJ_CenterSkillRank2);
							m_skillNameTexts[1].text = sceneList[0].EFELCLMJEOL_CenterSkillName2;
							m_skillNameTexts[1].alignment = TextAnchor.MiddleLeft;
							m_skillDescriptTexts[1].alignment = TextAnchor.MiddleLeft;
							m_skillLevelTexts[1].text = string.Format("Lv{0}", sceneList[0].DDEDANKHHPN_SkillLevel);
							b = UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[1], sceneList[0].IHLINMFMCDN_GetCenterSkillDesc(true), 1);
							if(b)
							{
								m_skillDetailsButtons[1].AddOnClickCallback(OnShowCenterSkillDetails2);
							}
							m_skillDetailIconImages[1].enabled = b;
							m_centerSkillCrossFade.StartAllAnimLoop("logo_act");
						}
					}
					else
					{
						//LAB_01269df8;
						UnitWindowConstant.SetInvalidText(m_skillNameTexts[0], TextAnchor.MiddleLeft);
						UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[0], TextAnchor.MiddleLeft);
						m_skillLevelTexts[0].text = "";
						GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[0], 0);
						m_skillDetailIconImages[0].enabled = false;
					}
				}
				else
				{
					centerSkill1 = sceneList[0].MEOOLHNNMHL_GetCenterSkillId(false, musicData.FKDCCLPGKDK_JacketAttr, musicData.AIHCEGFANAM_Serie);
					if(centerSkill1 < 1)
					{
						//LAB_01269df8
						UnitWindowConstant.SetInvalidText(m_skillNameTexts[0], TextAnchor.MiddleLeft);
						UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[0], TextAnchor.MiddleLeft);
						m_skillLevelTexts[0].text = "";
						GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[0], 0);
						m_skillDetailIconImages[0].enabled = false;
					}
					else
					{
						if(centerSkill1 == centerSkill2)
						{
							GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[0], (SkillRank.Type)sceneList[0].FFDCGHDNDFJ_CenterSkillRank2);
							m_skillNameTexts[0].text = sceneList[0].EFELCLMJEOL_CenterSkillName2;
						}
						else
						{
							GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[0], (SkillRank.Type)sceneList[0].DHEFMEGKKDN_CenterSkillRank);
							m_skillNameTexts[0].text = sceneList[0].PFHJFIHGCKP_CenterSkillName1;
						}
						m_skillNameTexts[0].alignment = TextAnchor.MiddleLeft;
						m_skillDescriptTexts[0].alignment = TextAnchor.MiddleLeft;
						m_skillLevelTexts[0].text = string.Format("Lv{0}", sceneList[0].DDEDANKHHPN_SkillLevel);
						bool b = UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[0], sceneList[0].IHLINMFMCDN_GetCenterSkillDesc(centerSkill1 == centerSkill2), 1);
						if(b)
						{
							m_skillDetailsButtons[0].AddOnClickCallback(OnShowCenterSkillDetails2);
						}
						m_skillDetailIconImages[0].enabled = b;
					}
				}
				m_skillDetailsButtons[2].ClearOnClickCallback();
				if(sceneList[0].HGONFBDIBPM_ActiveSkillId < 1)
				{
					UnitWindowConstant.SetInvalidText(m_skillNameTexts[2], TextAnchor.MiddleLeft);
					UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[2], TextAnchor.MiddleLeft);
					m_skillLevelTexts[2].text = "";
					GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[2], 0);
					m_skillDetailIconImages[2].enabled = false;
				}
				else
				{
					GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[2], (SkillRank.Type)sceneList[0].BEKGEAMJGEN_ActiveSkillRank);
					m_skillNameTexts[2].text = sceneList[0].ILCLGGPHHJO_ActiveSkillName;
					m_skillNameTexts[2].alignment = TextAnchor.MiddleLeft;
					m_skillDescriptTexts[2].alignment = TextAnchor.MiddleLeft;
					m_skillLevelTexts[2].text = string.Format("Lv{0}", sceneList[0].PNHJPCPFNFI_ActiveSkillLevel);
					bool b = UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[2], sceneList[0].PCMEMHPDABG_GetActiveSkillDesc(), 1);
					if(b)
					{
						m_skillDetailsButtons[2].AddOnClickCallback(OnShowActiveSkillDetails);
					}
					m_skillDetailIconImages[2].enabled = b;
				}
				m_skillDetailsButtons[LiveSkillDetailButtonsTypes[0]].ClearOnClickCallback();
				m_liveSkillCrossFade[0].StartAllAnimGoStop("st_wait");
				if(sceneList[0] == null)
				{
					//LAB_0126bd90
					UnitWindowConstant.SetInvalidText(m_skillNameTexts[LiveSkillDispPartsTypes[0]], TextAnchor.MiddleLeft);
					UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[LiveSkillDispPartsTypes[0]], TextAnchor.MiddleLeft);
					GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[LiveSkillDispPartsTypes[0]], 0);
					m_skillLevelTexts[LiveSkillDispPartsTypes[0]].text = "";
					m_skillDetailIconImages[LiveSkillDispPartsTypes[0]].enabled = false;
				}
				else
				{
					if(musicData != null)
					{
						int liveSkill1 = sceneList[0].FILPDDHMKEJ_GetLiveSkillId(false, musicData.FKDCCLPGKDK_JacketAttr, musicData.AIHCEGFANAM_Serie);
						int liveSkill2 = sceneList[0].FILPDDHMKEJ_GetLiveSkillId(true, musicData.FKDCCLPGKDK_JacketAttr, musicData.AIHCEGFANAM_Serie);
						if(liveSkill1 < 1)
						{
							UnitWindowConstant.SetInvalidText(m_skillNameTexts[LiveSkillDispPartsTypes[0]], TextAnchor.MiddleLeft);
							UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[LiveSkillDispPartsTypes[0]], TextAnchor.MiddleLeft);
							GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[LiveSkillDispPartsTypes[0]], 0);
							m_skillLevelTexts[LiveSkillDispPartsTypes[0]].text = "";
							m_skillDetailIconImages[LiveSkillDispPartsTypes[0]].enabled = false;
						}
						else
						{
							int skillRank = sceneList[0].OAHMFMJIENM_LiveSkillRank;
							string skillName = sceneList[0].NDPPEMCHKHA_LiveSkillName1;
							string skillDesc = sceneList[0].KDGACEJPGFG_GetLiveSkillDesc(false);
							if(liveSkill1 == liveSkill2 && sceneList[0].BLPHPMBFIEI_LiveSkillHasSwitchPatternCond())
							{
								skillRank = sceneList[0].ELNJADBILOM_LiveSkillRank2;
								skillName = sceneList[0].LNLECENGMKK_LiveSkillName2;
								skillDesc = sceneList[0].KDGACEJPGFG_GetLiveSkillDesc(true);
								PPGHMBNIAEC p = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[liveSkill1 - 1];
								if(p.AOPELJFAMCL_LiveSkillType != 0)
								{
									m_liveSkillTypeTbl[0].StartChildrenAnimGoStop("02");
									GameManager.Instance.UnionTextureManager.SetImageLiveSkillType(m_liveSkillTypeImages[0], (LiveSkillType.Type)p.AOPELJFAMCL_LiveSkillType);
								}
							}
							else
							{
								//LAB_0126b0f8
								PPGHMBNIAEC p = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[liveSkill1 - 1];
								if(p.AOPELJFAMCL_LiveSkillType != 0)
								{
									m_liveSkillTypeTbl[0].StartChildrenAnimGoStop("02");
									GameManager.Instance.UnionTextureManager.SetImageLiveSkillType(m_liveSkillTypeImages[0], (LiveSkillType.Type)p.AOPELJFAMCL_LiveSkillType);
								}
							}
							GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[LiveSkillDispPartsTypes[0]], (SkillRank.Type) skillRank);
							m_skillNameTexts[LiveSkillDispPartsTypes[0]].text = skillName;
							m_skillNameTexts[LiveSkillDispPartsTypes[0]].alignment = TextAnchor.MiddleLeft;
							m_skillDescriptTexts[LiveSkillDispPartsTypes[0]].alignment = TextAnchor.MiddleLeft;
							m_skillLevelTexts[LiveSkillDispPartsTypes[0]].text = string.Format("Lv{0}", sceneList[0].AADFFCIDJCB_LiveSkillLevel);
							bool b = UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[LiveSkillDispPartsTypes[0]], skillDesc, 1);
							if(b)
							{
								m_skillDetailsButtons[LiveSkillDetailButtonsTypes[0]].AddOnClickCallback(() =>
								{
									//0x1270E78
									OnShowLiveSkillDetail2(0);
								});
							}
							m_skillDetailIconImages[LiveSkillDispPartsTypes[0]].enabled = b;
						}
					}
					else
					{
						int liveSkill1 = sceneList[0].FILPDDHMKEJ_GetLiveSkillId(false, 0, 0);
						int liveSkill2 = sceneList[0].FILPDDHMKEJ_GetLiveSkillId(true, 0, 0);
						bool hasSkill = false;
						if(liveSkill1 > 0)
						{
							GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[LiveSkillDispPartsTypes[0]], (SkillRank.Type) sceneList[0].OAHMFMJIENM_LiveSkillRank);
							m_skillNameTexts[LiveSkillDispPartsTypes[0]].text = sceneList[0].NDPPEMCHKHA_LiveSkillName1;
							m_skillNameTexts[LiveSkillDispPartsTypes[0]].alignment = TextAnchor.MiddleLeft;
							m_skillDescriptTexts[LiveSkillDispPartsTypes[0]].alignment = TextAnchor.MiddleLeft;
							m_skillLevelTexts[LiveSkillDispPartsTypes[0]].text = string.Format("Lv{0}", sceneList[0].AADFFCIDJCB_LiveSkillLevel);
							bool b = UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[LiveSkillDispPartsTypes[0]], sceneList[0].KDGACEJPGFG_GetLiveSkillDesc(false), 1);
							if(b)
							{
								m_skillDetailsButtons[LiveSkillDetailButtonsTypes[0]].AddOnClickCallback(() =>
								{
									//0x1270E88
									OnShowLiveSkillDetail(0);
								});
							}
							m_skillDetailIconImages[LiveSkillDispPartsTypes[0]].enabled = b;
							PPGHMBNIAEC p = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[liveSkill1 - 1];
							if(p.AOPELJFAMCL_LiveSkillType != 0)
							{
								m_liveSkillTypeTbl[0].StartChildrenAnimGoStop("02");
								GameManager.Instance.UnionTextureManager.SetImageLiveSkillType(m_liveSkillTypeImages[0], (LiveSkillType.Type)p.AOPELJFAMCL_LiveSkillType);
							}
							hasSkill = true;
						}
						if(liveSkill2 > 0)
						{
							if(sceneList[0].BLPHPMBFIEI_LiveSkillHasSwitchPatternCond())
							{
								GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[LiveSkillDispPartsTypes[0] + 1], (SkillRank.Type) sceneList[0].ELNJADBILOM_LiveSkillRank2);
								m_skillNameTexts[LiveSkillDispPartsTypes[0] + 1].text = sceneList[0].LNLECENGMKK_LiveSkillName2;
								m_skillNameTexts[LiveSkillDispPartsTypes[0] + 1].alignment = TextAnchor.MiddleLeft;
								m_skillDescriptTexts[LiveSkillDispPartsTypes[0] + 1].alignment = TextAnchor.MiddleLeft;
								m_skillLevelTexts[LiveSkillDispPartsTypes[0] + 1].text = string.Format("Lv{0}", sceneList[0].AADFFCIDJCB_LiveSkillLevel);
								bool b = UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[LiveSkillDispPartsTypes[0] + 1], sceneList[0].KDGACEJPGFG_GetLiveSkillDesc(true), 1);
								if(b)
								{
									m_skillDetailsButtons[LiveSkillDetailButtonsTypes[0] + 1].AddOnClickCallback(() =>
									{
										//0x1270E90
										OnShowLiveSkillDetail2(0);
									});
								}
								m_skillDetailIconImages[LiveSkillDispPartsTypes[0] + 1].enabled = b;
								m_liveSkillCrossFade[0].StartAllAnimLoop("logo_act");
								PPGHMBNIAEC p = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[liveSkill1 - 1];
								if(p.AOPELJFAMCL_LiveSkillType != 0)
								{
									m_liveSkillTypeTbl[1].StartChildrenAnimGoStop("02");
									GameManager.Instance.UnionTextureManager.SetImageLiveSkillType(m_liveSkillTypeImages[1], (LiveSkillType.Type)p.AOPELJFAMCL_LiveSkillType);
								}
							}
						}
						if(!hasSkill)
						{
							//LAB_0126bd90;
							UnitWindowConstant.SetInvalidText(m_skillNameTexts[LiveSkillDispPartsTypes[0]], TextAnchor.MiddleLeft);
							UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[LiveSkillDispPartsTypes[0]], TextAnchor.MiddleLeft);
							GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[LiveSkillDispPartsTypes[0]], 0);
							m_skillLevelTexts[LiveSkillDispPartsTypes[0]].text = "";
							m_skillDetailIconImages[LiveSkillDispPartsTypes[0]].enabled = false;
						}
					}
				}
				m_sceneIconDecoration[0].SetActive(true);
				m_sceneIconDecoration[0].Change(sceneList[0], DisplayType.Level);
			}
			//LAB_0126c0a8
			for(int i = 0; i < divaData.DJICAKGOGFO_SubSceneIds.Count; i++)
			{
				int index = i;
				int slot = LiveSkillDispPartsTypes[i + 1];
				int btn = LiveSkillDetailButtonsTypes[i + 1];
				m_liveSkillCrossFade[i + 1].StartAllAnimGoStop("st_wait");
                GCIJNCFDNON_SceneInfo sceneData = sceneList[i + 1];
				if(sceneData == null)
				{
					MenuScene.Instance.SceneIconCache.Load(0, 0, (IiconTexture texture) =>
					{
						//0x1271328
						texture.Set(m_sceneIconImage[index + 1]);
						SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImage[index + 1], texture as IconTexture, false);
						m_lodingFlags |= (LoadingFlags)(4 << index);
					});
					UnitWindowConstant.SetInvalidText(m_skillNameTexts[slot], TextAnchor.MiddleLeft);
					UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[slot], TextAnchor.MiddleLeft);
					GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[slot], 0);
					m_skillDetailIconImages[slot].enabled = false;
					m_skillLevelTexts[slot].text = "";
					m_sceneIconDecoration[i + 1].SetActive(false);
				}
				else
				{
					MenuScene.Instance.SceneIconCache.Load(sceneData.BCCHOBPJJKE_SceneId, sceneData.CGIELKDLHGE_GetEvolveId(), (IiconTexture texture) =>
					{
						//0x1271544
						texture.Set(m_sceneIconImage[index + 1]);
						SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImage[index + 1], texture as IconTexture, sceneList[index + 1].MBMFJILMOBP_IsKira());
						m_lodingFlags |= (LoadingFlags)(4 << index);
					});
					m_skillDetailsButtons[btn].ClearOnClickCallback();
					m_skillDetailsButtons[btn + 1].ClearOnClickCallback();
					if(musicData == null)
					{
						int liveSkill1 = sceneData.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0);
						int liveSkill2 = sceneData.FILPDDHMKEJ_GetLiveSkillId(true, 0, 0);
						bool hasSkill = false;
						if(liveSkill1 > 0)
						{
							GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[slot], (SkillRank.Type) sceneData.OAHMFMJIENM_LiveSkillRank);
							m_skillNameTexts[slot].text = sceneData.NDPPEMCHKHA_LiveSkillName1;
							m_skillNameTexts[slot].alignment = TextAnchor.MiddleLeft;
							m_skillDescriptTexts[slot].alignment = TextAnchor.MiddleLeft;
							m_skillLevelTexts[slot].text = string.Format("Lv{0}", sceneData.AADFFCIDJCB_LiveSkillLevel);
							bool b = UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[slot], sceneData.KDGACEJPGFG_GetLiveSkillDesc(false), 1);
							if(b)
							{
								m_skillDetailsButtons[btn].AddOnClickCallback(() =>
								{
									//0x12712C8
									OnShowLiveSkillDetail(index + 1);
								});
							}
							m_skillDetailIconImages[slot].enabled = b;
							PPGHMBNIAEC p = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[liveSkill1 - 1];
							if(p.AOPELJFAMCL_LiveSkillType != 0)
							{
								m_liveSkillTypeTbl[i * 2 + 2].StartChildrenAnimGoStop("02");
								GameManager.Instance.UnionTextureManager.SetImageLiveSkillType(m_liveSkillTypeImages[i * 2 + 2], (LiveSkillType.Type)p.AOPELJFAMCL_LiveSkillType);
							}
							hasSkill = true;
						}
						if(liveSkill2 > 0)
						{
							if(sceneData.BLPHPMBFIEI_LiveSkillHasSwitchPatternCond())
							{
								GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[slot + 1], (SkillRank.Type) sceneData.ELNJADBILOM_LiveSkillRank2);
								m_skillNameTexts[slot + 1].text = sceneData.LNLECENGMKK_LiveSkillName2;
								m_skillNameTexts[slot + 1].alignment = TextAnchor.MiddleLeft;
								m_skillDescriptTexts[slot + 1].alignment = TextAnchor.MiddleLeft;
								m_skillLevelTexts[slot + 1].text = string.Format("Lv{0}", sceneData.AADFFCIDJCB_LiveSkillLevel);
								bool b = UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[slot + 1], sceneData.KDGACEJPGFG_GetLiveSkillDesc(true), 1);
								if(b)
								{
									m_skillDetailsButtons[btn + 1].AddOnClickCallback(() =>
									{
										//0x12712F8
										OnShowLiveSkillDetail2(index + 1);
									});
								}
								m_skillDetailIconImages[slot + 1].enabled = b;
								m_liveSkillCrossFade[i + 1].StartAllAnimLoop("logo_act");
								PPGHMBNIAEC p = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[liveSkill2 - 1];
								if(p.AOPELJFAMCL_LiveSkillType != 0)
								{
									m_liveSkillTypeTbl[i * 2 + 3].StartChildrenAnimGoStop("02");
									GameManager.Instance.UnionTextureManager.SetImageLiveSkillType(m_liveSkillTypeImages[i * 2 + 3], (LiveSkillType.Type)p.AOPELJFAMCL_LiveSkillType);
								}
							}
						}
						if(!hasSkill)
						{
							//LAB_0126dc34
							UnitWindowConstant.SetInvalidText(m_skillNameTexts[slot], TextAnchor.MiddleLeft);
							UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[slot], TextAnchor.MiddleLeft);
							GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[slot], 0);
							m_skillLevelTexts[slot].text = "";
							m_skillDetailIconImages[slot].enabled = false;
						}
					}
					else
					{
						int liveSkill1 = sceneData.FILPDDHMKEJ_GetLiveSkillId(false, musicData.FKDCCLPGKDK_JacketAttr, musicData.AIHCEGFANAM_Serie);
						int liveSkill2 = sceneData.FILPDDHMKEJ_GetLiveSkillId(true, musicData.FKDCCLPGKDK_JacketAttr, musicData.AIHCEGFANAM_Serie);
						if(liveSkill1 < 1)
						{
							//LAB_0126dc34
							UnitWindowConstant.SetInvalidText(m_skillNameTexts[slot], TextAnchor.MiddleLeft);
							UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[slot], TextAnchor.MiddleLeft);
							GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[slot], 0);
							m_skillLevelTexts[slot].text = "";
							m_skillDetailIconImages[slot].enabled = false;
						}
						else
						{
							int skillRank = sceneData.OAHMFMJIENM_LiveSkillRank;
							string skillName = sceneData.NDPPEMCHKHA_LiveSkillName1;
							string skillDesc = sceneData.KDGACEJPGFG_GetLiveSkillDesc(false);
							if(liveSkill1 == liveSkill2 && sceneData.BLPHPMBFIEI_LiveSkillHasSwitchPatternCond())
							{
								skillRank = sceneData.ELNJADBILOM_LiveSkillRank2;
								skillName = sceneData.LNLECENGMKK_LiveSkillName2;
								skillDesc = sceneData.KDGACEJPGFG_GetLiveSkillDesc(true);
								PPGHMBNIAEC p = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[liveSkill1 - 1];
								if(p.AOPELJFAMCL_LiveSkillType != 0)
								{
									m_liveSkillTypeTbl[i * 2 + 3].StartChildrenAnimGoStop("02");
									GameManager.Instance.UnionTextureManager.SetImageLiveSkillType(m_liveSkillTypeImages[i * 2 + 3], (LiveSkillType.Type)p.AOPELJFAMCL_LiveSkillType);
								}
							}
							else
							{
								//LAB_0126d360
								PPGHMBNIAEC p = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[liveSkill1 - 1];
								if(p.AOPELJFAMCL_LiveSkillType != 0)
								{
									m_liveSkillTypeTbl[i * 2 + 2].StartChildrenAnimGoStop("02");
									GameManager.Instance.UnionTextureManager.SetImageLiveSkillType(m_liveSkillTypeImages[i * 2 + 2], (LiveSkillType.Type)p.AOPELJFAMCL_LiveSkillType);
								}
							}
							GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[slot], (SkillRank.Type) skillRank);
							m_skillNameTexts[slot].text = skillName;
							m_skillNameTexts[slot].alignment = TextAnchor.MiddleLeft;
							m_skillDescriptTexts[slot].alignment = TextAnchor.MiddleLeft;
							m_skillLevelTexts[slot].text = string.Format("Lv{0}", sceneData.AADFFCIDJCB_LiveSkillLevel);
							bool b = UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[slot], skillDesc, 1);
							if(b)
							{
								m_skillDetailsButtons[btn].AddOnClickCallback(() =>
								{
									//0x127103C
									OnShowLiveSkillDetail2(0);
								});
							}
							m_skillDetailIconImages[slot].enabled = b;
						}
						m_sceneIconDecoration[i + 1].SetActive(true);
						m_sceneIconDecoration[i + 1].Change(sceneData, DisplayType.Level);
					}
				}
            }
			SetStatus(divaData, DivaIconDecoration.GetEquipmentLuck(m_sceneList));
			m_isCenterDiva = divaSlotNumber == 0;
			m_statusDispIndex = GameManager.Instance.localSave.EPJOACOONAC_GetSave().LDNJHLLKEIG_StatusPopup.EPJPNFIMODP_DivaStatusPage;
			m_changeStatusButton.SetPage(m_statusDispIndex + 1, m_statuChangeAnimeLabel.Length);
			UpdateStatus();
			UpdateSkillMisMatch(m_statusDispIndex);
		}

		// // RVA: 0x126EC80 Offset: 0x126EC80 VA: 0x126EC80
		private void SetStatus(FFHPBEPOMAK_DivaInfo divaData, int luck)
		{
			m_paramTexts[0].text = m_status.Total.ToString();
			m_paramTexts[1].text = m_status.soul.ToString();
			m_paramTexts[2].text = m_status.vocal.ToString();
			m_paramTexts[3].text = m_status.charm.ToString();
			m_paramTexts[4].text = m_status.life.ToString();
			UnitWindowConstant.SetLuckText(m_paramTexts[5], luck);
			m_paramTexts[6].text = m_status.support.ToString();
			m_paramTexts[7].text = m_status.fold.ToString();
			for(int i = 0; i < m_status.spNoteExpected.Length - 1; i++)
			{
				if(m_status.spNoteExpected[i + 1] < 1)
				{
					m_nortsTexts[i].text = "0";
					if(m_nortsIconLayout[i] != null)
					{
						m_nortsIconLayout[i].StartChildrenAnimGoStop("02");
					}
				}
				else
				{
					m_nortsTexts[i].text = m_status.spNoteExpected[i + 1].ToString();
					if(m_nortsIconLayout[i] != null)
					{
						m_nortsIconLayout[i].StartChildrenAnimGoStop("01");
					}
				}
			}
		}

		// // RVA: 0x126F3BC Offset: 0x126F3BC VA: 0x126F3BC
		private void UpdateStatus()
		{
			m_statusChangeLayout.StartChildrenAnimGoStop(m_statuChangeAnimeLabel[m_statusDispIndex]);
		}

		// // RVA: 0x126F4A8 Offset: 0x126F4A8 VA: 0x126F4A8
		private void UpdateSkillMisMatch(int dispIndex)
		{
			if(m_isFriend)
			{
				m_centerSkillMisMatch.StartChildrenAnimGoStop("05");
				m_activeSkillMisMatch.StartChildrenAnimGoStop("05");
				for(int i = 0; i < m_liveSkillMisMatch.Length; i++)
				{
					m_liveSkillMisMatch[i].StartChildrenAnimGoStop("05");
				}
			}
			int musicId = m_musicData != null ? m_musicData.DLAEJOBELBH_MusicId : 0;
			if(dispIndex == 0)
			{
				string lbl = "05";
				string lbl2 = "05";
				if(m_sceneList[0] == null)
				{
					m_regulationButtons[0].Setup(0, 0, null);
					lbl = "05";
					lbl2 = "05";
				}
				else
				{
					m_regulationButtons[0].Setup(musicId, 0, m_sceneList[0]);
					EEDKAACNBBG_MusicData e = new EEDKAACNBBG_MusicData();
					int skillId;
					if(musicId < 1)
					{
						skillId = m_sceneList[0].MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
					}
					else
					{
						e.KHEKNNFCAOI(musicId);
						skillId = m_sceneList[0].MEOOLHNNMHL_GetCenterSkillId(false, e.FKDCCLPGKDK_JacketAttr, e.AIHCEGFANAM_Serie);
					}
					if(!m_isCenterDiva)
					{
						lbl = "04";
						if(skillId < 1)
							lbl = "05";
						lbl2 = "04";
						if(m_sceneList[0].HGONFBDIBPM_ActiveSkillId < 1)
							lbl2 = "05";
					}
					else
					{
						lbl = "08";
						if(!m_regulationButtons[0].IsMisMatchAttr)
							lbl = "05";
						if(m_regulationButtons[0].IsMisMatchSeries)
							lbl = "07";
					}
				}
				m_centerSkillMisMatch.StartChildrenAnimGoStop(lbl);
				m_activeSkillMisMatch.StartChildrenAnimGoStop(lbl2);
			}
			else if(dispIndex == 1)
			{
				string lbl = "05";
				if(m_sceneList[0] == null)
				{
					m_regulationButtons[0].Setup(0, RegulationButton.Type.Live, null);
				}
				else
				{
					m_regulationButtons[0].Setup(musicId, RegulationButton.Type.Live, m_sceneList[0]);

					int skillId;
					if(musicId < 1)
					{
						skillId = m_sceneList[0].FILPDDHMKEJ_GetLiveSkillId(false, 0, 0);
					}
					else
					{
						skillId = m_sceneList[0].FILPDDHMKEJ_GetLiveSkillId(false, m_musicData.FKDCCLPGKDK_JacketAttr, m_musicData.AIHCEGFANAM_Serie);
					}
					if(skillId > 0)
					{
						if(!m_isCenterDiva)
						{
							if(m_sceneList[0].DCLLIDMKNGO_IsDivaCompatible(m_divaData.AHHJLDLAPAN_DivaId))
							{
								if(m_regulationButtons[0].IsMisMatchAttr)
									lbl = "08";
								if(m_regulationButtons[0].IsMisMatchMusic)
									lbl = "06";
							}
							else
							{
								lbl = "01";
							}
						}
						else
						{
							lbl = "02";
						}
					}
				}
				m_liveSkillMisMatch[0].StartChildrenAnimGoStop(lbl);
				for(int i = 1; i < m_sceneList.Count; i++)
				{
					lbl = "05";
					if(m_sceneList[i] == null)
					{
						m_regulationButtons[i].Setup(0, RegulationButton.Type.Live, null);
					}
					else
					{
						m_regulationButtons[i].Setup(musicId, RegulationButton.Type.Live, m_sceneList[i]);

						int skillId;
						if(m_musicData == null)
						{
							skillId = m_sceneList[i].FILPDDHMKEJ_GetLiveSkillId(false, 0, 0);
						}
						else
						{
							skillId = m_sceneList[i].FILPDDHMKEJ_GetLiveSkillId(false, m_musicData.FKDCCLPGKDK_JacketAttr, m_musicData.AIHCEGFANAM_Serie);
						}
						if(skillId > 0)
						{
							if(m_sceneList[i].DCLLIDMKNGO_IsDivaCompatible(m_divaData.AHHJLDLAPAN_DivaId))
							{
								if(m_regulationButtons[i].IsMisMatchAttr)
									lbl = "08";
								if(m_regulationButtons[i].IsMisMatchMusic)
									lbl = "06";
							}
							else
							{
								lbl = "01";
							}
						}
					}
					m_liveSkillMisMatch[i].StartChildrenAnimGoStop(lbl);
				}
			}
		}

		// // RVA: 0x1270128 Offset: 0x1270128 VA: 0x1270128
		private void OnSelectScene(int sceneSlotIndex)
		{
			m_onSceneSelectEvent.Invoke(sceneSlotIndex);
		}

		// // RVA: 0x12701A8 Offset: 0x12701A8 VA: 0x12701A8
		private void OnShowStatus(int sceneSlotIndex)
		{
			m_onShowStatusEvent.Invoke(sceneSlotIndex);
		}

		// // RVA: 0x1270228 Offset: 0x1270228 VA: 0x1270228
		private void OnShowCenterSkillDetails()
		{
			MenuScene.Instance.UnitSaveWindowControl.ShowSkillWindow(m_sceneList[0].PFHJFIHGCKP_CenterSkillName1, m_sceneList[0].IHLINMFMCDN_GetCenterSkillDesc(false));
		}

		// // RVA: 0x1270360 Offset: 0x1270360 VA: 0x1270360
		private void OnShowCenterSkillDetails2()
		{
			MenuScene.Instance.UnitSaveWindowControl.ShowSkillWindow(m_sceneList[0].EFELCLMJEOL_CenterSkillName2, m_sceneList[0].IHLINMFMCDN_GetCenterSkillDesc(true));
		}

		// // RVA: 0x1270498 Offset: 0x1270498 VA: 0x1270498
		private void OnShowActiveSkillDetails()
		{
			MenuScene.Instance.UnitSaveWindowControl.ShowSkillWindow(m_sceneList[0].ILCLGGPHHJO_ActiveSkillName, m_sceneList[0].PCMEMHPDABG_GetActiveSkillDesc());
		}

		// // RVA: 0x12705CC Offset: 0x12705CC VA: 0x12705CC
		private void OnShowLiveSkillDetail(int skillIndex)
		{
			MenuScene.Instance.UnitSaveWindowControl.ShowSkillWindow(m_sceneList[0].NDPPEMCHKHA_LiveSkillName1, m_sceneList[skillIndex].KDGACEJPGFG_GetLiveSkillDesc(false));
		}

		// // RVA: 0x1270708 Offset: 0x1270708 VA: 0x1270708
		private void OnShowLiveSkillDetail2(int skillIndex)
		{
			MenuScene.Instance.UnitSaveWindowControl.ShowSkillWindow(m_sceneList[0].LNLECENGMKK_LiveSkillName2, m_sceneList[skillIndex].KDGACEJPGFG_GetLiveSkillDesc(true));
		}

		// [CompilerGeneratedAttribute] // RVA: 0x70F5AC Offset: 0x70F5AC VA: 0x70F5AC
		// // RVA: 0x1270E80 Offset: 0x1270E80 VA: 0x1270E80
		// private void <UpdateContent>b__56_5() { }

		// [CompilerGeneratedAttribute] // RVA: 0x70F5FC Offset: 0x70F5FC VA: 0x70F5FC
		// // RVA: 0x1271044 Offset: 0x1271044 VA: 0x1271044
		// private void <UpdateContent>b__56_11() { }
	}
}
