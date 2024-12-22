using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class SceneIconScrollContent : SwapScrollListContent
	{
		public enum IconFlagBitIndex
		{
			New = 0,
			Unit = 1,
			Set = 2,
			Episode = 3,
			HomeBg = 4,
		}

		public enum SkillIconType
		{
			None = 0,
			Active = 1,
			Live = 2,
		}

		[SerializeField]
		private RawImageEx m_sceneIconImage; // 0x20
		[SerializeField]
		private StayButton m_sceneIconButton; // 0x24
		[SerializeField]
		private RawImageEx[] m_unitSetImages; // 0x28
		[SerializeField]
		private GameObject m_newParentObject; // 0x2C
		[SerializeField]
		private RawImageEx[] m_skillIconImages; // 0x30
		private NewMarkIcon m_newIcon = new NewMarkIcon(); // 0x34
		private AbsoluteLayout m_cursorLayout; // 0x38
		private AbsoluteLayout m_skillIconLayout; // 0x3C
		private AbsoluteLayout m_episodeNameLayout; // 0x40
		private AbsoluteLayout m_episodeMarkLayout; // 0x44
		private AbsoluteLayout m_homeSelectLayout; // 0x48
		private bool m_isCompatible; // 0x4C
		private bool m_isInitializedNewMark; // 0x4D
		private short m_sceneId; // 0x4E
		private short m_evolveId; // 0x50
		private TexUVListManager m_uvManager; // 0x54
		private Matrix23 m_identity; // 0x58

		// public short SceneID { get; } 0x136DF00
		// public short EvolveID { get; } 0x136DF08
		public RawImageEx SceneIconImage { get { return m_sceneIconImage; } } //0x136DF10

		// RVA: 0x136DF18 Offset: 0x136DF18 VA: 0x136DF18 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_skillIconLayout = layout.FindViewByExId("sw_scene02_anim_sw_sel_card_skill_ef_anim") as AbsoluteLayout;
			m_cursorLayout = layout.FindViewByExId("swtbl_sel_card_skill_sw_sel_card_skill_ef_anim") as AbsoluteLayout;
			m_episodeNameLayout = layout.FindViewByExId("sw_scene02_anim_swtbl_sel_card_epi_frm") as AbsoluteLayout;
			m_episodeMarkLayout = layout.FindViewByExId("sw_scene02_anim_sw_sw_sel_card_ep_onoff_anim") as AbsoluteLayout;
			m_isCompatible = false;
			m_homeSelectLayout = layout.FindViewByExId("sw_sel_card_bg_cursor_onoff_anim_sw_sel_card_bg_cursor_anim") as AbsoluteLayout;
			m_uvManager = uvMan;
			m_cursorLayout.StartChildrenAnimGoStop("st_non");
			m_episodeMarkLayout.StartChildrenAnimGoStop("02");
			m_skillIconLayout.StartChildrenAnimGoStop("01");
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}

		// // RVA: 0x136E284 Offset: 0x136E284 VA: 0x136E284
		public void InitializeCompatibleAnimeParam(ref CompatibleLayoutAnimeParam animeParam)
		{
			animeParam.Initialize(m_cursorLayout.FrameAnimation.SearchLabelFrame("loen_act"), m_cursorLayout.FrameAnimation.SearchLabelFrame("logo_act"));
		}

		// // RVA: 0x136E3D4 Offset: 0x136E3D4 VA: 0x136E3D4
		public void InitializeDecoration()
		{
			m_newIcon.Initialize(m_newParentObject);
			m_isInitializedNewMark = true;
		}

		// // RVA: 0x136E414 Offset: 0x136E414 VA: 0x136E414
		public void ReleaseDecoration()
		{
			m_newIcon.Release();
			m_isInitializedNewMark = false;
		}

		// // RVA: 0x136E44C Offset: 0x136E44C VA: 0x136E44C
		public void UpdateContent(GCIJNCFDNON_SceneInfo sceneData, uint iconFlagBit, bool isCompatible, SkillIconType iconType, TransitionList.Type transitionType, bool isActivate)
		{
			m_sceneId = (short)sceneData.BCCHOBPJJKE_SceneId;
			int sceneId = m_sceneId;
			m_evolveId = (short)sceneData.CGIELKDLHGE_GetEvolveId();
			int evolveId = m_evolveId;
			KMOGDEOKHPG_Episode epDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode;
			GameManager.Instance.SceneIconCache.SetLoadingTexture(m_sceneIconImage);
			GameManager.Instance.SceneIconCache.Load(m_sceneId, m_evolveId, (IiconTexture texture) => {
				//0x136F358
				if(m_sceneId != sceneId)
					return;
				if(m_evolveId != evolveId)
					return;
				texture.Set(m_sceneIconImage);
				SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImage, texture as IconTexture, sceneData.MBMFJILMOBP_IsKira());
			});
			m_sceneIconButton.ClearOnClickCallback();
			m_sceneIconButton.ClearOnStayCallback();
			m_sceneIconButton.AddOnClickCallback(() => {
				//0x136F528
				ClickButton.Invoke(0, this);
			});
			m_sceneIconButton.AddOnStayCallback(() => {
				//0x136F5C4
				ClickButton.Invoke(1, this);
			});
			SetVisibleUnitMark(false);
			m_skillIconLayout.StartChildrenAnimGoStop("01");
			if((iconFlagBit & 1) == 0)
				m_newIcon.SetActive(false);
			else if(!m_newIcon.IsActive())
			{
				m_newIcon.SetActive(true);
			}
			if(transitionType == TransitionList.Type.HOME_BG_SELECT)
			{
				SetVisibleSelectHomeMark(((iconFlagBit << 0x1b) >> 0x1f) != 0);
			}
			else
			{
				if((iconFlagBit & 2) != 0)
					SetVisibleUnitMark(true);
				if((iconFlagBit & 4) != 0)
					SetVisibleUnitMark(true);
				SetVisibleSelectHomeMark(false);
			}
			SetVisibleEpisodeMark(((iconFlagBit << 0x1c) >> 0x1f) != 0);
			m_isCompatible = isCompatible;
			m_cursorLayout.StartChildrenAnimGoStop(isCompatible ? "st_wait" : "st_non");
			m_cursorLayout.UpdateAllAnimation(2 * TimeWrapper.deltaTime, false);
			m_cursorLayout.UpdateAll(m_identity, Color.white);
			if(m_isCompatible)
			{
				for(int i = 0; i < m_skillIconImages.Length; i++)
				{
					m_skillIconImages[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(iconType == SkillIconType.Live ? "sel_card_icon_skill_02" : "sel_card_icon_skill_01"));
				}
				if(!isActivate)
				{
					if(sceneData.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0) > 0)
					{
						m_skillIconLayout.StartChildrenAnimGoStop("02");
					}
				}
			}
		}

		// // RVA: 0x136F228 Offset: 0x136F228 VA: 0x136F228
		public void UpdateCursorAnime(int time)
		{
			if(!m_isCompatible)
				return;
			m_cursorLayout.StartChildrenAnimGoStop(time, time);
		}

		// // RVA: 0x136F26C Offset: 0x136F26C VA: 0x136F26C
		public void UpdateNewAnime(int time)
		{
			if(!m_isInitializedNewMark)
				return;
			if(!m_newIcon.IsActive())
				return;
			m_newIcon.OverridePlayTime(time);
		}

		// // RVA: 0x136EF9C Offset: 0x136EF9C VA: 0x136EF9C
		private void SetVisibleUnitMark(bool isVisible)
		{
			for(int i = 0; i < m_unitSetImages.Length; i++)
			{
				m_unitSetImages[i].enabled = isVisible;
			}
		}

		// // RVA: 0x136F194 Offset: 0x136F194 VA: 0x136F194
		private void SetVisibleEpisodeMark(bool isVisible)
		{
			m_episodeMarkLayout.StartChildrenAnimGoStop(isVisible ? "01" : "02");
		}

		// // RVA: 0x136F034 Offset: 0x136F034 VA: 0x136F034
		private void SetVisibleSelectHomeMark(bool isVisible)
		{
			m_homeSelectLayout.StartAllAnimGoStop(isVisible ? "01" : "02");
			m_homeSelectLayout.UpdateAllAnimation(2 * TimeWrapper.deltaTime, false);
			m_homeSelectLayout.UpdateAll(m_identity, Color.white);
		}
	}
}
