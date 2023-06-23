using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Text;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class SceneGrowthStatus : LayoutUGUIScriptBase
	{
		public enum SkillUIType
		{
			Active = 0,
			Live2 = 1,
			Live = 2,
			Center2 = 3,
			Center = 4,
			Num = 5,
		}

		public enum GrowthStatus
		{
			Soul = 0,
			Voice = 1,
			Charm = 2,
			Life = 3,
			Luck = 4,
			Support = 5,
			Fold = 6,
			CenterSkill = 7,
			ActiveSkill = 8,
			LiveSkill = 9,
			Max = 10,
			None = 11,
		}
 
		public enum TextLabel
		{
			Total = 0,
			Soul = 1,
			Vocal = 2,
			Charm = 3,
			Life = 4,
			Luck = 5,
			Support = 6,
			Fold = 7,
		}

		[SerializeField]
		private RawImageEx m_sceneIconImage; // 0x14
		[SerializeField]
		private RawImageEx m_titleIconImage; // 0x18
		[SerializeField]
		private Text[] m_statusText; // 0x1C
		[SerializeField]
		private Text[] m_skillLevel; // 0x20
		[SerializeField]
		private Text[] m_skillDescript; // 0x24
		[SerializeField]
		private RawImageEx[] m_skillRankImages; // 0x28
		[SerializeField]
		private RawImageEx[] m_skillInfoImages; // 0x2C
		[SerializeField]
		private Text[] m_commonText; // 0x30
		[SerializeField]
		private ActionButton[] m_pageChangeButton; // 0x34
		[SerializeField]
		private ActionButton[] m_skillInfoButtons; // 0x38
		[SerializeField]
		private SceneGrowthEpisodeGauge m_episodeGauge; // 0x3C
		[SerializeField]
		private SceneGrowthEpisodeStatus m_episodeStatus; // 0x40
		[SerializeField]
		private ActionButton m_storyButton; // 0x44
		private AbsoluteLayout[] m_statusUpAnimationlayout; // 0x48
		private SceneIconDecoration m_decoration; // 0x4C
		private AbsoluteLayout m_windowLayout; // 0x50
		private AbsoluteLayout m_storyNewLayout; // 0x54
		private AbsoluteLayout m_centerSkillCrossFade; // 0x58
		private AbsoluteLayout m_liveSkillCrossFade; // 0x5C
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0x60
		private StringBuilder m_modifyTagCenterSkillComment = new StringBuilder(64); // 0x64
		private StringBuilder m_modifyTagActiveSkillComment = new StringBuilder(64); // 0x68
		private StringBuilder m_modifyTagLiveSkillComment = new StringBuilder(64); // 0x6C
		private CCAAJNJGNDO m_eventStoryData = new CCAAJNJGNDO(); // 0x70
		//[CompilerGeneratedAttribute] // RVA: 0x67D87C Offset: 0x67D87C VA: 0x67D87C
		public UnityAction PushStoryButtonListener; // 0x74
		private int m_pageNum; // 0x78
		private int m_pageMax; // 0x7C
		private const int PageMax = 3;
		private const string LevelFormat = "Lv{0}";
		private readonly string[] PageChangeLabel = new string[3] {
			"p1", "p2", "p3"
		}; // 0x80
		private static readonly GrowthStatus[] m_growStatusTbl = new GrowthStatus[22]
			{
				GrowthStatus.None,
				GrowthStatus.Life,
				GrowthStatus.Soul,
				GrowthStatus.Voice,
				GrowthStatus.Charm,
				GrowthStatus.CenterSkill,
				GrowthStatus.ActiveSkill,
				GrowthStatus.LiveSkill,
				GrowthStatus.Support,
				GrowthStatus.Fold,
				GrowthStatus.None,
				GrowthStatus.None,
				GrowthStatus.None,
				GrowthStatus.None,
				GrowthStatus.None,
				GrowthStatus.None,
				GrowthStatus.None,
				GrowthStatus.None,
				GrowthStatus.None,
				GrowthStatus.Luck,
				GrowthStatus.None,
				GrowthStatus.None
			}; // 0x0
		private readonly string[] m_statusUpAnimeLayerNames = new string[10]
			{
				"sw_ab_fr_set_p1_sw_cmn_status_icon_up_so",
				"sw_ab_fr_set_p1_sw_cmn_status_icon_up_vo",
				"sw_ab_fr_set_p1_sw_cmn_status_icon_up_ch",
				"sw_ab_fr_set_p1_sw_cmn_status_icon_up_li",
				"sw_ab_fr_set_p1_sw_cmn_status_icon_up_lu",
				"sw_ab_fr_set_p1_sw_cmn_status_icon_up_su",
				"sw_ab_fr_set_p1_sw_cmn_status_icon_up_fo",
				"sw_ab_fr_set_p2_sw_cmn_status_icon_up_c",
				"sw_ab_fr_set_p2_sw_cmn_status_icon_up_a",
				"sw_ab_fr_set_p2_sw_cmn_status_icon_up_l"
			}; // 0x84

		//public int PageNum { get; } 0x10E57CC

		// RVA: 0x10F9774 Offset: 0x10F9774 VA: 0x10F9774 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_pageChangeButton[0].AddOnClickCallback(OnPushRightButton);
			m_pageChangeButton[1].AddOnClickCallback(OnPushLeftButton);
			m_storyButton.AddOnClickCallback(OnPushStoryButton);
			m_windowLayout = layout.FindViewByExId("sw_ab_fr_set_anim_swtbl_ab_fr_set") as AbsoluteLayout;
			m_storyNewLayout = layout.FindViewByExId("sw_ab_btn_story_anim_sw_icon_new_onoff_anim") as AbsoluteLayout;
			m_decoration = new SceneIconDecoration();
			m_centerSkillCrossFade = layout.FindViewByExId("sw_ab_fr_set_p2_sw_c_skill_cf_anim") as AbsoluteLayout;
			m_liveSkillCrossFade = layout.FindViewByExId("sw_ab_fr_set_p2_sw_live_skill_cf_anim") as AbsoluteLayout;
			m_statusUpAnimationlayout = new AbsoluteLayout[10];
			for(int i = 0; i < 10; i++)
			{
				m_statusUpAnimationlayout[i] = layout.FindViewByExId(m_statusUpAnimeLayerNames[i]) as AbsoluteLayout;
			}
			(layout.FindViewByExId("sw_cnm_ep_icon_03_anim_sw_sel_ep_mask_eff_anim") as AbsoluteLayout).StartChildrenAnimLoop("go_out");
			m_windowLayout.StartAnimGoStop("st_out");
			ClearLoadedCallback();
			return true;
		}

		//// RVA: 0x10E18D4 Offset: 0x10E18D4 VA: 0x10E18D4
		public void InitializeDecoration()
		{
			m_decoration.Initialize(m_sceneIconImage.gameObject, SceneIconDecoration.Size.M, m_windowLayout, null);
		}

		//// RVA: 0x10E1948 Offset: 0x10E1948 VA: 0x10E1948
		public void UpdateContent(GCIJNCFDNON_SceneInfo sceneData, TransitionUniqueId transitionUniqueId)
		{
			bool isKira = sceneData.MBMFJILMOBP_IsKira();
			MenuScene.Instance.SceneIconCache.Load(sceneData.BCCHOBPJJKE_SceneId, sceneData.CGIELKDLHGE_GetEvolveId(), (IiconTexture texture) =>
			{
				//0x1363640
				texture.Set(m_sceneIconImage);
				SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImage, texture as IconTexture, isKira);
			});
			MenuScene.Instance.MenuResidentTextureCache.LoadLogo(sceneData.EMIKBGHIOMN_SerieLogo == SeriesLogoId.Type.FrontiaItsuwari ? 10 : (int)sceneData.EMIKBGHIOMN_SerieLogo, (IiconTexture texture) =>
			{
				//0x136391C
				texture.Set(m_titleIconImage);
			});
			m_commonText[0].text = "";
			m_commonText[2].text = GameMessageManager.GetSceneCardName(sceneData);
			UpdateStatus(sceneData.CMCKNKKCNDK_Status, sceneData.MJBODMOLOBC_Luck);
			for(int i = 0; i < 5; i++)
			{
				m_skillLevel[i].alignment = TextAnchor.MiddleCenter;
				m_skillDescript[i].alignment = TextAnchor.MiddleCenter;
				m_skillLevel[i].text = "";
				UnitWindowConstant.SetInvalidText(m_skillDescript[i], TextAnchor.MiddleCenter);
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankImages[i], SkillRank.Type.None);
				m_skillInfoImages[i].enabled = false;
				m_skillInfoButtons[i].ClearOnClickCallback();
			}
			UpdateSkill(sceneData);
			m_pageMax = 3;
			if (sceneData.KELFCMEOPPM_EpisodeId == 0)
				m_pageMax = 2;
			UpdatePage();
			m_decoration.Change(sceneData, DisplayType.Level);
			if(transitionUniqueId != TransitionUniqueId.SETTINGMENU_SCENEABILITYRELEASELIST_SCENEGROWTH || sceneData.JKGFBFPIMGA_Rarity < 6)
			{
				m_storyButton.Hidden = true;
			}
			else
			{
				m_storyButton.Hidden = false;
				m_eventStoryData.KHEKNNFCAOI(CCAAJNJGNDO.NNDBMLNMDJM(sceneData.BCCHOBPJJKE_SceneId));
				m_storyNewLayout.StartChildrenAnimGoStop("02");
				bool b = true;
				for(int i = 0; i < m_eventStoryData.FFPCLEONGHE.Count; i++)
				{
					if(m_eventStoryData.FFPCLEONGHE[i].CDOCOLOKCJK)
					{
						if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.FABEJIHKFGN(m_eventStoryData.FFPCLEONGHE[i].PBPOLELIPJI))
						{
							b = false;
							m_storyNewLayout.StartChildrenAnimGoStop("01");
						}
					}
				}
				m_storyButton.Disable = b;
			}
		}

		//// RVA: 0x10FA3D8 Offset: 0x10FA3D8 VA: 0x10FA3D8
		//private string ModifyColorTagSkillComment(string comment) { }

		//// RVA: 0x10E23CC Offset: 0x10E23CC VA: 0x10E23CC
		public void UpdateEpisode(PIGBBNDPPJC episodeData)
		{
			m_episodeGauge.UpdateContent(episodeData);
			m_episodeStatus.UpdateContent(episodeData);
		}

		//// RVA: 0x10E2428 Offset: 0x10E2428 VA: 0x10E2428
		public void SetPage(int page)
		{
			if (m_pageNum == page)
				return;
			m_pageNum = page;
			ChangeStatus(0);
			UpdatePage();
		}

		//// RVA: 0x10FA2C8 Offset: 0x10FA2C8 VA: 0x10FA2C8
		private void UpdatePage()
		{
			m_commonText[1].text = string.Format("{0}/{1}", m_pageNum + 1, m_pageMax);
		}

		//// RVA: 0x10FA68C Offset: 0x10FA68C VA: 0x10FA68C
		private void OnPushLeftButton()
		{
			TodoLogger.LogNotImplemented("OnPushLeftButton");
		}

		//// RVA: 0x10FA6F4 Offset: 0x10FA6F4 VA: 0x10FA6F4
		private void OnPushRightButton()
		{
			TodoLogger.LogNotImplemented("OnPushRightButton");
		}

		//// RVA: 0x10FA75C Offset: 0x10FA75C VA: 0x10FA75C
		private void OnPushStoryButton()
		{
			TodoLogger.LogNotImplemented("OnPushStoryButton");
		}

		//// RVA: 0x10FA5E4 Offset: 0x10FA5E4 VA: 0x10FA5E4
		private void ChangeStatus(int dir)
		{
			m_pageNum += dir;
			if (m_pageNum < 0)
				m_pageNum = m_pageMax - 1;
			else if (m_pageNum >= m_pageMax)
				m_pageNum = 0;
			m_windowLayout.StartChildrenAnimGoStop(PageChangeLabel[m_pageNum]);
			UpdatePage();
		}

		//// RVA: 0x10E2D54 Offset: 0x10E2D54 VA: 0x10E2D54
		public void ReleaseResource()
		{
			m_decoration.Release();
		}

		//// RVA: 0x10F9DF0 Offset: 0x10F9DF0 VA: 0x10F9DF0
		public void UpdateStatus(StatusData status, int luck)
		{
			m_statusText[0].text = status.Total.ToString();
			m_statusText[1].text = status.soul.ToString();
			m_statusText[2].text = status.vocal.ToString();
			m_statusText[3].text = status.charm.ToString();
			m_statusText[4].text = status.life.ToString();
			UnitWindowConstant.SetLuckText(m_statusText[5], luck);
			m_statusText[6].text = status.support.ToString();
			m_statusText[7].text = status.fold.ToString();
		}

		//// RVA: 0x10F2308 Offset: 0x10F2308 VA: 0x10F2308
		//public void BeginUpdateStatusAnime(SceneGrowthStatus.TextLabel type, int before, int after, float waitTime) { }

		//// RVA: 0x10F240C Offset: 0x10F240C VA: 0x10F240C
		//public void BeginUpdateCenterSkillAnime(GCIJNCFDNON sceneData, int before, int after, float waitTime) { }

		//// RVA: 0x10F2A1C Offset: 0x10F2A1C VA: 0x10F2A1C
		//public void BeginUpdateActiveSkillAnime(GCIJNCFDNON sceneData, int before, int after, float waitTime) { }

		//// RVA: 0x10F3074 Offset: 0x10F3074 VA: 0x10F3074
		//public void BeginUpdateLiveSkillAnime(GCIJNCFDNON sceneData, int before, int after, float waitTime) { }

		//// RVA: 0x10FA96C Offset: 0x10FA96C VA: 0x10FA96C
		//private void ReplaceSkillText(StringBuilder str, List<string> replaceWords) { }

		//// RVA: 0x10FA424 Offset: 0x10FA424 VA: 0x10FA424
		//private void InsertColorTag(StringBuilder strBuilder) { }

		//[IteratorStateMachineAttribute] // RVA: 0x7262BC Offset: 0x7262BC VA: 0x7262BC
		//// RVA: 0x10FA7CC Offset: 0x10FA7CC VA: 0x10FA7CC
		//private IEnumerator Co_BeginUpdateStatusAnime(Text text, int before, int after, float waitTime, string format, UnityAction<int> updateAction) { }

		//// RVA: 0x10FAB30 Offset: 0x10FAB30 VA: 0x10FAB30
		public void UpdateCenterSkill(GCIJNCFDNON_SceneInfo sceneData, int level)
		{
			int id1 = sceneData.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
			int id2 = sceneData.MEOOLHNNMHL_GetCenterSkillId(true, 0, 0);
			if (m_centerSkillCrossFade != null)
				m_centerSkillCrossFade.StartAllAnimLoop("st_wait");
			if(id1 > 0)
			{
				UpdateSkill(m_skillLevel[4], m_skillDescript[4], m_skillRankImages[4], m_skillInfoImages[4], m_skillInfoButtons[4], sceneData.PFHJFIHGCKP_CenterSkillName1, sceneData.IHLINMFMCDN_GetCenterSkillDesc(level, false), level, (SkillRank.Type)sceneData.DHEFMEGKKDN_CenterSkillRank);
			}
			if(id1 != id2 && id2 > 0)
			{
				UpdateSkill(m_skillLevel[3], m_skillDescript[3], m_skillRankImages[3], m_skillInfoImages[3], m_skillInfoButtons[3], sceneData.EFELCLMJEOL_CenterSkillName2, sceneData.IHLINMFMCDN_GetCenterSkillDesc(level, true), level, (SkillRank.Type)sceneData.FFDCGHDNDFJ_CenterSkillRank2);
				if(m_centerSkillCrossFade != null)
				{
					m_centerSkillCrossFade.StartAllAnimLoop("logo_act");
				}
			}
		}

		//// RVA: 0x10FB290 Offset: 0x10FB290 VA: 0x10FB290
		public void UpdateActiveSkill(GCIJNCFDNON_SceneInfo sceneData, int level)
		{
			if(sceneData.HGONFBDIBPM_ActiveSkillId > 0)
			{
				UpdateSkill(m_skillLevel[0], m_skillDescript[0], m_skillRankImages[0], m_skillInfoImages[0], m_skillInfoButtons[0], sceneData.ILCLGGPHHJO_ActiveSkillName, sceneData.PCMEMHPDABG_GetActiveSkillDesc(level), level, (SkillRank.Type)sceneData.BEKGEAMJGEN_ActiveSkillRank);
			}
		}

		//// RVA: 0x10FB414 Offset: 0x10FB414 VA: 0x10FB414
		public void UpdateLiveSkill(GCIJNCFDNON_SceneInfo sceneData, int level)
		{
			int id1 = sceneData.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0);
			int id2 = sceneData.FILPDDHMKEJ_GetLiveSkillId(true, 0, 0);
			if (m_liveSkillCrossFade != null)
				m_liveSkillCrossFade.StartAllAnimLoop("st_wait");
			if(id1 > 0)
			{
				UpdateSkill(m_skillLevel[2], m_skillDescript[2], m_skillRankImages[2], m_skillInfoImages[2], m_skillInfoButtons[2], sceneData.NDPPEMCHKHA_LiveSkillName1, sceneData.KDGACEJPGFG_GetLiveSkillDesc(level, false), level, (SkillRank.Type)sceneData.OAHMFMJIENM_LiveSkillRank);
			}
			if(id2 > 0)
			{
				UpdateSkill(m_skillLevel[1], m_skillDescript[1], m_skillRankImages[1], m_skillInfoImages[1], m_skillInfoButtons[1], sceneData.LNLECENGMKK_LiveSkillName2, sceneData.KDGACEJPGFG_GetLiveSkillDesc(level, true), level, (SkillRank.Type)sceneData.ELNJADBILOM_LiveSkillRank2);
				if (m_liveSkillCrossFade != null)
					m_liveSkillCrossFade.StartAllAnimLoop("logo_act");
			}
		}

		//// RVA: 0x10FA238 Offset: 0x10FA238 VA: 0x10FA238
		private void UpdateSkill(GCIJNCFDNON_SceneInfo sceneData)
		{
			UpdateCenterSkill(sceneData, sceneData.DDEDANKHHPN_SkillLevel);
			UpdateActiveSkill(sceneData, sceneData.PNHJPCPFNFI_ActiveSkillLevel);
			UpdateLiveSkill(sceneData, sceneData.AADFFCIDJCB_LiveSkillLevel);
		}

		//// RVA: 0x10FAFCC Offset: 0x10FAFCC VA: 0x10FAFCC
		private void UpdateSkill(Text levelText, Text descText, RawImageEx rankImage, RawImageEx infoImage, ActionButton button, string name, string desc, int level, SkillRank.Type rank)
		{
			levelText.text = string.Format("Lv{0}", level);
			levelText.alignment = TextAnchor.UpperLeft;
			descText.alignment = TextAnchor.UpperLeft;
			descText.horizontalOverflow = HorizontalWrapMode.Wrap;
			infoImage.enabled = UnitWindowConstant.SetSkillDetails(descText, desc, 2);
			if(infoImage.enabled)
			{
				button.AddOnClickCallback(() =>
				{
					//0x1363D68
					MenuScene.Instance.UnitSaveWindowControl.ShowSkillWindow(name, desc);
				});
			}
			GameManager.Instance.UnionTextureManager.SetImageSkillRank(rankImage, rank);
		}

		//// RVA: 0x10FA8D8 Offset: 0x10FA8D8 VA: 0x10FA8D8
		//private void DisableSkillCrossFade() { }

		//// RVA: 0x10F21C4 Offset: 0x10F21C4 VA: 0x10F21C4
		//public void PlayUpArrowAnimation(IDMPGHMNLHD.NPIEEGNKDEG kind) { }

		//// RVA: 0x10F421C Offset: 0x10F421C VA: 0x10F421C
		public void Show()
		{
			m_windowLayout.StartAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0x10E2604 Offset: 0x10E2604 VA: 0x10E2604
		public void Hide()
		{
			m_windowLayout.StartAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x10E26BC Offset: 0x10E26BC VA: 0x10E26BC
		public bool IsAnimePlaying()
		{
			return m_windowLayout.IsPlayingChildren() || m_windowLayout.IsPlaying();
		}
	}
}
