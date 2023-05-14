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
			// public void SetLeafNum(int num, int max) { }
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
							return textParentNameTbl[i, j].Contains(x.transform.parent.name);
						}));
					}
					m_effectText.Add(i, l);
				}
			}

			// // RVA: 0xA5F454 Offset: 0xA5F454 VA: 0xA5F454
			// public void SetValue(LimitOverStatusData data) { }

			// // RVA: 0xA63F90 Offset: 0xA63F90 VA: 0xA63F90
			// private void SetPanel(int overLimitValue, int attrBonus, int seriesBonus, List<AbsoluteLayout> layoutList, List<Text> textList) { }
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
			TodoLogger.Log(0, "IsLoading");
			return false;
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
			TodoLogger.Log(0, "InitializeDecoration");
		}

		// // RVA: 0xA5B41C Offset: 0xA5B41C VA: 0xA5B41C
		public void ReleaseDecoration()
		{
			TodoLogger.Log(0, "ReleaseDecoration");
		}

		// // RVA: 0xA5B624 Offset: 0xA5B624 VA: 0xA5B624
		public void UpdateContent(GCIJNCFDNON_SceneInfo sceneData, DFKGGBMFFGB_PlayerInfo playerData, bool isFriend, bool isDisableZoom, bool isDisableLuckyLeaf, PageSave pageSave = PageSave.Player)
		{
			TodoLogger.Log(0, "UpdateContent");
		}

		// // RVA: 0xA5EF68 Offset: 0xA5EF68 VA: 0xA5EF68
		// private int GetStatusTableNum(GCIJNCFDNON sceneData, bool isDisableLuckyLeaf) { }

		// // RVA: 0xA5F194 Offset: 0xA5F194 VA: 0xA5F194
		private void UpdateStatus()
		{
			TodoLogger.Log(0, "UpdateStatus");
		}

		// // RVA: 0xA5EEC4 Offset: 0xA5EEC4 VA: 0xA5EEC4
		// public void UpdateLimitBreak() { }

		// // RVA: 0xA5F8CC Offset: 0xA5F8CC VA: 0xA5F8CC
		// private void OnPushAbilityButton() { }

		// // RVA: 0xA5F960 Offset: 0xA5F960 VA: 0xA5F960
		// private void OnShowCenterSkillDetails() { }

		// // RVA: 0xA5FD4C Offset: 0xA5FD4C VA: 0xA5FD4C
		// private void OnShowCenterSkillDetails2() { }

		// // RVA: 0xA5FDB0 Offset: 0xA5FDB0 VA: 0xA5FDB0
		// private void OnShowActiveSkillDetails() { }

		// // RVA: 0xA5FE10 Offset: 0xA5FE10 VA: 0xA5FE10
		// private void OnShowLiveSkillDetail() { }

		// // RVA: 0xA5FE74 Offset: 0xA5FE74 VA: 0xA5FE74
		// private void OnShowLiveSkillDetail2() { }

		// // RVA: 0xA5F9C4 Offset: 0xA5F9C4 VA: 0xA5F9C4
		// private void ShowSkillWindow(string name, string descript) { }

		// // RVA: 0xA5FED8 Offset: 0xA5FED8 VA: 0xA5FED8
		private void OnSceneZoom()
		{
			TodoLogger.LogNotImplemented("OnSceneZoom");
		}

		// // RVA: 0xA5FFD8 Offset: 0xA5FFD8 VA: 0xA5FFD8
		// private void OnBackButton() { }

		// [IteratorStateMachineAttribute] // RVA: 0x70F9CC Offset: 0x70F9CC VA: 0x70F9CC
		// // RVA: 0xA5FF4C Offset: 0xA5FF4C VA: 0xA5FF4C
		// private IEnumerator SceneZoomCoroutine() { }

		// [IteratorStateMachineAttribute] // RVA: 0x70FA44 Offset: 0x70FA44 VA: 0x70FA44
		// // RVA: 0xA60024 Offset: 0xA60024 VA: 0xA60024
		// private IEnumerator LoadTexture(int sceneId, int evolvId, UnityAction endAction) { }

		// // RVA: 0xA6011C Offset: 0xA6011C VA: 0xA6011C
		private void ChangeEvolvImage(int page)
		{
			TodoLogger.Log(0, "ChangeEvolvImage");
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
			TodoLogger.LogNotImplemented("OnShowLimitBreakPopup");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70FABC Offset: 0x70FABC VA: 0x70FABC
		// // RVA: 0xA6099C Offset: 0xA6099C VA: 0xA6099C
		// private IEnumerator LimitOverMainCoroutine(MNDAMOGGJBJ itemData) { }

		// // RVA: 0xA60A64 Offset: 0xA60A64 VA: 0xA60A64
		private void OnShowEpisodePopup()
		{
			TodoLogger.LogNotImplemented("OnShowEpisodePopup");
		}

		// [CompilerGeneratedAttribute] // RVA: 0x70FB74 Offset: 0x70FB74 VA: 0x70FB74
		// // RVA: 0xA61244 Offset: 0xA61244 VA: 0xA61244
		// private void <OnShowLimitBreakPopup>b__81_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// [CompilerGeneratedAttribute] // RVA: 0x70FB84 Offset: 0x70FB84 VA: 0x70FB84
		// // RVA: 0xA61414 Offset: 0xA61414 VA: 0xA61414
		// private void <LimitOverMainCoroutine>b__82_2() { }

		// [CompilerGeneratedAttribute] // RVA: 0x70FB94 Offset: 0x70FB94 VA: 0x70FB94
		// // RVA: 0xA6162C Offset: 0xA6162C VA: 0xA6162C
		// private void <LimitOverMainCoroutine>b__82_4(IiconTexture texture) { }
	}
}
