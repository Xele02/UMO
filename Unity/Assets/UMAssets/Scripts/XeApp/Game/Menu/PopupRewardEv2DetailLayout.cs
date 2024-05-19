using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupRewardEv2DetailLayout : LayoutUGUIScriptBase
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
		private InfoButton m_changeStatusButton; // 0x30
		[SerializeField]
		private ActionButton[] m_skillDetailsButtons; // 0x34
		[SerializeField]
		private ActionButton m_episodeButton; // 0x38
		[SerializeField]
		private RegulationButton m_regulationButton; // 0x3C
		[SerializeField]
		private RawImageEx m_sceneIconImage; // 0x40
		[SerializeField]
		private RawImageEx m_seriesIconImage; // 0x44
		[SerializeField]
		private RawImageEx m_liveSkillTypeImage; // 0x48
		[SerializeField]
		private RawImageEx[] m_compatibleDivaIconImages; // 0x4C
		[SerializeField]
		private RawImageEx[] m_compatibleMaskIconImages; // 0x50
		[SerializeField]
		private RawImageEx[] m_skillDetailIconImages; // 0x54
		[SerializeField]
		private RawImageEx[] m_skillRankIconImages; // 0x58
		[SerializeField]
		private ActionButton m_changePlateButton; // 0x5C
		private GCIJNCFDNON_SceneInfo  m_sceneData; // 0x60
		private AEKDNMPPOJN m_limitOverData = new AEKDNMPPOJN(); // 0x64
		private PIGBBNDPPJC m_episodeData = new PIGBBNDPPJC(); // 0x68
		private AbsoluteLayout[] m_nortsLayout; // 0x6C
		private AbsoluteLayout m_statusChangeLayout; // 0x70
		private AbsoluteLayout[] m_skillMisMatchLayout; // 0x74
		private AbsoluteLayout m_gachaInfoLayout; // 0x78
		private AbsoluteLayout m_plateTypeLayout; // 0x7C
		private AbsoluteLayout m_liveSkillTblLayout; // 0x80
		private SceneIconDecoration m_sceneIconDeccoration = new SceneIconDecoration(); // 0x84
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0x88
		private StringBuilder m_assetName = new StringBuilder(64); // 0x8C
		private PopupWindowControl m_windowControl; // 0x90
		private int m_statuDispIndex; // 0x94
		private int m_statusDispNum; // 0x98
		private TexUVListManager m_uvManager; // 0x9C
		private List<int> m_cimpatibleDivaIdList = new List<int>(); // 0xA0
		private SceneCardTextureCache m_sceneCardCache; // 0xA4
		private PopupRewardEv2Detail m_popupRewardEv2Detail; // 0xA8
		private GCIJNCFDNON_SceneInfo[] m_viewSceneData; // 0xAC
		private int m_selectSceneIndex; // 0xB0
		private LoadingFlag m_loadingFlag; // 0xB4
		private const string LevelFormat = "Lv{0}";
		private static readonly string[] m_statuChangeAnimeLabel = new string[4]
		{
			"01", "02", "03", "04"
		}; // 0x0

		// // RVA: 0x161DFCC Offset: 0x161DFCC VA: 0x161DFCC
		public bool IsLoading()
		{
			return m_loadingFlag != LoadingFlag.All;
		}

		// RVA: 0x161E144 Offset: 0x161E144 VA: 0x161E144 Slot: 5
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
			m_plateTypeLayout = layout.FindViewById("swtbl_reward_ev_switch_frame") as AbsoluteLayout;
			m_liveSkillTblLayout = layout.FindViewByExId("sw_scene_skill_swtbl_lskill") as AbsoluteLayout;
			m_changeStatusButton.OnClickButton = (int page) =>
			{
				//0x1621BA4
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				m_statuDispIndex++;
				if(m_statusDispNum <= m_statuDispIndex)
					m_statuDispIndex = 0;
				UpdateStatus();
			};
			m_uvManager = uvMan;
			m_changePlateButton.AddOnClickCallback(() =>
			{
				//0x1621C20
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				OnClickChangePlate();
			});
			m_episodeButton.AddOnClickCallback(OnShowEpisodePopup);
			m_popupRewardEv2Detail = transform.GetComponent<PopupRewardEv2Detail>();
			ClearLoadedCallback();
			return true;
		}

		// // RVA: 0x161E720 Offset: 0x161E720 VA: 0x161E720
		public void InitializeDecoration()
		{
			m_sceneIconDeccoration.Initialize(m_sceneIconImage.gameObject, SceneIconDecoration.Size.M, null, null);
		}

		// RVA: 0x161DECC Offset: 0x161DECC VA: 0x161DECC
		public void ReleaseDecoration()
		{
			m_sceneIconDeccoration.Release();
		}

		// // RVA: 0x161E78C Offset: 0x161E78C VA: 0x161E78C
		public void OnClickChangePlate()
		{
			m_selectSceneIndex = (m_selectSceneIndex + 1) % m_viewSceneData.Length;
			UpdateContent(m_viewSceneData[m_selectSceneIndex]);
		}

		// RVA: 0x161DDD8 Offset: 0x161DDD8 VA: 0x161DDD8
		public void Init(GCIJNCFDNON_SceneInfo[] sceneData)
		{
			InitializeDecoration();
			m_viewSceneData = sceneData;
			m_selectSceneIndex = 0;
			UpdateContent(sceneData[0]);
		}

		// // RVA: 0x161E868 Offset: 0x161E868 VA: 0x161E868
		public void UpdateContent(GCIJNCFDNON_SceneInfo sceneData)
		{
			m_windowControl = GetComponentInParent<PopupWindowControl>();
			if(!sceneData.JOKJBMJBLBB_Single)
			{
				if(sceneData.JPIPENJGGDD_NumBoard == 1)
				{
					m_windowControl.m_titleText.text = JpStringLiterals.StringLiteral_13959 + sceneData.OPFGFINHFCE_SceneName;
					m_plateTypeLayout.StartChildrenAnimGoStop("02");
				}
				else
				{
					m_windowControl.m_titleText.text = sceneData.OPFGFINHFCE_SceneName;
					m_plateTypeLayout.StartChildrenAnimGoStop("01");
				}
			}
			else
			{
				m_windowControl.m_titleText.text = JpStringLiterals.StringLiteral_13959 + sceneData.OPFGFINHFCE_SceneName;
				m_plateTypeLayout.StartChildrenAnimGoStop("03");
			}
			m_sceneIconDeccoration.Change(sceneData, DisplayType.Level);
			m_sceneData = sceneData;
			m_limitOverData.KHEKNNFCAOI(sceneData.JKGFBFPIMGA_Rarity, sceneData.MKHFCGPJPFI_LimitOverCount, sceneData.MJBODMOLOBC_Luck);
			m_sceneDetails.text = sceneData.BGJNIABLBDB_GetSceneDetail();
			m_loadingFlag = 0;
			GameManager.Instance.SceneIconCache.Load(sceneData.BCCHOBPJJKE_SceneId, sceneData.CGIELKDLHGE_GetEvolveId(), (IiconTexture texture) =>
			{
				//0x1621C84
				texture.Set(m_sceneIconImage);
				m_loadingFlag |= LoadingFlag.Scene;
			});
			GameManager.Instance.MenuResidentTextureCache.LoadLogo((int)sceneData.EMIKBGHIOMN_SerieLogo, (IiconTexture texture) =>
			{
				//0x1621D70
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
					m_nortsTexts[i].text = "";
					m_nortsLayout[i].StartChildrenAnimGoStop("02");
				}
				else
				{
					m_nortsTexts[i].text = sceneData.CMCKNKKCNDK_Status.spNoteExpected[i + 1].ToString();
					m_nortsLayout[i].StartChildrenAnimGoStop("01");
				}
			}
			m_skillDetailsButtons[0].ClearOnClickCallback();
			int centerId = sceneData.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
			if(centerId < 1)
			{
				UnitWindowConstant.SetInvalidText(m_skillNameTexts[0], TextAnchor.MiddleCenter);
				UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[0], TextAnchor.MiddleCenter);
				m_skillLevelTexts[0].text = string.Empty;
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[0], SkillRank.Type.None);
				m_skillDetailIconImages[0].enabled = false;
			}
			else
			{
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[0], (SkillRank.Type)sceneData.DHEFMEGKKDN_CenterSkillRank);
				m_skillNameTexts[0].text = sceneData.PFHJFIHGCKP_CenterSkillName1;
				m_skillNameTexts[0].alignment = TextAnchor.MiddleLeft;
				m_skillDescriptTexts[0].alignment = TextAnchor.MiddleLeft;
				m_skillLevelTexts[0].text = string.Format("Lv{0}", sceneData.DDEDANKHHPN_SkillLevel);
				if(UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[0], sceneData.IHLINMFMCDN_GetCenterSkillDesc(false), 1))
				{
					m_skillDetailsButtons[0].AddOnClickCallback(OnShowCenterSkillDetails);
					m_skillDetailIconImages[0].enabled = true;
				}
				else
					m_skillDetailIconImages[0].enabled = false;
			}
			m_skillDetailsButtons[1].ClearOnClickCallback();
			if(sceneData.HGONFBDIBPM_ActiveSkillId < 1)
			{
				UnitWindowConstant.SetInvalidText(m_skillNameTexts[1], TextAnchor.MiddleCenter);
				UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[1], TextAnchor.MiddleCenter);
				m_skillLevelTexts[1].text = string.Empty;
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[1], SkillRank.Type.None);
				m_skillDetailIconImages[1].enabled = false;
			}
			else
			{
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[1], (SkillRank.Type)sceneData.BEKGEAMJGEN_ActiveSkillRank);
				m_skillNameTexts[1].text = sceneData.ILCLGGPHHJO_ActiveSkillName;
				m_skillNameTexts[1].alignment = TextAnchor.MiddleLeft;
				m_skillDescriptTexts[1].alignment = TextAnchor.MiddleLeft;
				m_skillLevelTexts[1].text = string.Format("Lv{0}", sceneData.PNHJPCPFNFI_ActiveSkillLevel);
				if(UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[1], sceneData.PCMEMHPDABG_GetActiveSkillDesc(), 1))
				{
					m_skillDetailsButtons[1].AddOnClickCallback(OnShowActiveSkillDetails);
					m_skillDetailIconImages[1].enabled = true;
				}
				else
				{
					m_skillDetailIconImages[1].enabled = false;
				}
			}
			m_liveSkillTblLayout.StartChildrenAnimGoStop("01");
			m_skillDetailsButtons[2].ClearOnClickCallback();
			int liveId = sceneData.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0);
			if(liveId < 1)
			{
				UnitWindowConstant.SetInvalidText(m_skillNameTexts[2], TextAnchor.MiddleCenter);
				UnitWindowConstant.SetInvalidText(m_skillDescriptTexts[2], TextAnchor.MiddleCenter);
				m_skillLevelTexts[2].text = string.Empty;
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[2], SkillRank.Type.None);
				m_skillDetailIconImages[2].enabled = false;
			}
			else
			{
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankIconImages[2], (SkillRank.Type)sceneData.OAHMFMJIENM_LiveSkillRank);
				m_skillNameTexts[2].text = sceneData.NDPPEMCHKHA_LiveSkillName1;
				m_skillNameTexts[2].alignment = TextAnchor.MiddleLeft;
				m_skillDescriptTexts[2].alignment = TextAnchor.MiddleLeft;
				m_skillLevelTexts[2].text = string.Format("Lv{0}", sceneData.AADFFCIDJCB_LiveSkillLevel);
				if(UnitWindowConstant.SetSkillDetails(m_skillDescriptTexts[2], sceneData.KDGACEJPGFG_GetLiveSkillDesc(false), 1))
				{
					m_skillDetailsButtons[2].AddOnClickCallback(OnShowLiveSkillDetail);
					m_skillDetailIconImages[2].enabled = true;
				}
				else
				{
					m_skillDetailIconImages[2].enabled = false;
				}
				PPGHMBNIAEC p = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[liveId - 1];
				if(p.AOPELJFAMCL_LiveSkillType != 0)
				{
					m_liveSkillTblLayout.StartChildrenAnimGoStop("02");
					GameManager.Instance.UnionTextureManager.SetImageLiveSkillType(m_liveSkillTypeImage, (LiveSkillType.Type)p.AOPELJFAMCL_LiveSkillType);
				}
			}
			DFKGGBMFFGB_PlayerInfo playerInfo = new DFKGGBMFFGB_PlayerInfo();
			playerInfo.KHEKNNFCAOI_Init(null, false);
			int n = 0;
			for(int i = 0; i < playerInfo.NBIGLBMHEDC_Divas.Count; i++)
			{
				if(playerInfo.NBIGLBMHEDC_Divas[i].IPJMPBANBPP_Enabled)
				{
					m_strBuilder.Clear();
					m_strBuilder.AppendFormat("pop_reward_ev_icon_{0:D2}", playerInfo.NBIGLBMHEDC_Divas[i].AHHJLDLAPAN_DivaId);
					m_compatibleDivaIconImages[n].enabled = true;
					m_compatibleDivaIconImages[n].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(m_strBuilder.ToString()));
					m_compatibleMaskIconImages[n].enabled = !sceneData.DCLLIDMKNGO_IsDivaCompatible(playerInfo.NBIGLBMHEDC_Divas[i].AHHJLDLAPAN_DivaId);
					n++;
				}
			}
			for(int i = n; i < m_compatibleDivaIconImages.Length; i++)
			{
				m_compatibleDivaIconImages[i].enabled = false;
				m_compatibleMaskIconImages[i].enabled = false;
			}
			m_sceneIconDeccoration.SetActive(true);
			m_regulationButton.Setup(0, RegulationButton.Type.Live, m_sceneData);
			if(m_sceneData.KELFCMEOPPM_EpisodeId < 1)
			{
				m_episodeName.text = TextConstant.InvalidText;
				m_episodeButton.Hidden = true;
			}
			else
			{
				m_episodeData.KHEKNNFCAOI(m_sceneData.KELFCMEOPPM_EpisodeId);
				m_episodeName.text = m_episodeData.OPFGFINHFCE_Name;
				m_episodeButton.Hidden = false;
			}
			m_statusDispNum = m_statuChangeAnimeLabel.Length - 1;
			if(m_statusDispNum <= m_statuDispIndex)
				m_statuDispIndex = 0;
			m_changeStatusButton.SetPage(m_statuDispIndex + 1, m_statusDispNum);
			UpdateStatus();
		}

		// // RVA: 0x1621164 Offset: 0x1621164 VA: 0x1621164
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
				//0x1621ED8
				return;
			}, null, null, null);
		}

		// // RVA: 0x1621078 Offset: 0x1621078 VA: 0x1621078
		private void UpdateStatus()
		{
			m_statusChangeLayout.StartChildrenAnimGoStop(m_statuChangeAnimeLabel[m_statuDispIndex]);
		}

		// // RVA: 0x16214F4 Offset: 0x16214F4 VA: 0x16214F4
		private void OnShowCenterSkillDetails()
		{
			MenuScene.Instance.UnitSaveWindowControl.ShowSkillWindow(m_sceneData.PFHJFIHGCKP_CenterSkillName1, m_sceneData.IHLINMFMCDN_GetCenterSkillDesc(false));
		}

		// // RVA: 0x1621608 Offset: 0x1621608 VA: 0x1621608
		private void OnShowActiveSkillDetails()
		{
			MenuScene.Instance.UnitSaveWindowControl.ShowSkillWindow(m_sceneData.ILCLGGPHHJO_ActiveSkillName, m_sceneData.PCMEMHPDABG_GetActiveSkillDesc());
		}

		// // RVA: 0x1621718 Offset: 0x1621718 VA: 0x1621718
		private void OnShowLiveSkillDetail()
		{
			MenuScene.Instance.UnitSaveWindowControl.ShowSkillWindow(m_sceneData.NDPPEMCHKHA_LiveSkillName1, m_sceneData.KDGACEJPGFG_GetLiveSkillDesc(false));
		}
	}
}
