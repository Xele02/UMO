using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class BgSelectIconScrollContent : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_sceneIconImage; // 0x20
		[SerializeField]
		private ActionButton m_sceneIconButton; // 0x24
		[SerializeField]
		private Text m_limitText; // 0x28
		private NewMarkIcon m_newIcon = new NewMarkIcon(); // 0x2C
		private AbsoluteLayout m_frame; // 0x30
		private AbsoluteLayout m_setframe; // 0x34
		private AbsoluteLayout m_selectframe; // 0x38
		private AbsoluteLayout m_limitTextLayout; // 0x3C
		private AbsoluteLayout m_lockIconLayout; // 0x40
		private Outline m_outline; // 0x44
		private bool m_isCompatible; // 0x48
		private bool m_isInitializedNewMark; // 0x49
		private short m_sceneId; // 0x4A
		private short m_evolveId; // 0x4C
		private int m_episodeId; // 0x50
		private bool m_isLock; // 0x54
		private TexUVListManager m_uvManager; // 0x58
		[SerializeField]
		private RawImageEx[] m_selectFrameIcon; // 0x5C
		[SerializeField]
		private RawImageEx[] m_setFrameIcon; // 0x60

		public short SceneID { get { return m_sceneId; } } //0x10964F8
		public short EvolveID { get { return m_evolveId; } } //0x1096500
		public bool IsLock { get { return m_isLock; } } //0x1096508
		//public int EpisodeID { get; } 0x1096510
		//public RawImageEx SceneIconImage { get; } 0x1096518

		// RVA: 0x1096520 Offset: 0x1096520 VA: 0x1096520 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvManager = uvMan;
			m_isCompatible = false;
			m_frame = layout.FindViewByExId("sw_scene_anim_swtbl_sel_bg_frm") as AbsoluteLayout;
			m_limitTextLayout = layout.FindViewByExId("swtbl_sel_bg_frm_lim_sel_bg_frm_lim") as AbsoluteLayout;
			m_setframe = layout.FindViewByExId("swtbl_sel_bg_frm_sel_bg_frm_set") as AbsoluteLayout;
			m_selectframe = layout.FindViewByExId("swtbl_sel_bg_frm_sel_bg_frm_select") as AbsoluteLayout;
			m_lockIconLayout = layout.FindViewByExId("sw_scene_anim_sw_lock_onoff_anim") as AbsoluteLayout;
			m_outline = GetComponentsInChildren<RawImageEx>().Where((RawImageEx _) =>
			{
				//0x1097DD4
				return _.name == "swtexc_cmn_scene_m01 (ImageView)";
			}).First().gameObject.AddComponent<Outline>();
			Color col;
			ColorUtility.TryParseHtmlString("#024c5c", out col);
			m_outline.effectColor = col;
			m_outline.effectDistance = new Vector2(2, -2);
			m_outline.enabled = false;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}

		//// RVA: 0x1096A60 Offset: 0x1096A60 VA: 0x1096A60
		public void UpdateContent(CGFNKMNBNBN bgData, bool isSelect, bool isLock = false, int episodeId = 0)
		{
			m_outline.enabled = true;
			m_episodeId = episodeId;
			m_sceneId = (short)bgData.PPFNGGCBJKC_Id;
			m_evolveId = 0;
			m_isLock = isLock;
			MenuScene.Instance.SceneIconCache.SetLoadingTexture(m_sceneIconImage);
			MenuScene.Instance.HomeBgIconTextureCache.Load(bgData.KEFGPJBKAOD_BgId, (IiconTexture texture) =>
			{
				//0x1097BF8
				texture.Set(m_sceneIconImage);
			});
			m_lockIconLayout.StartAllAnimGoStop(m_isLock ? "01" : "02");
			m_sceneIconButton.ClearOnClickCallback();
			m_sceneIconButton.AddOnClickCallback(() =>
			{
				//0x1097CD8
				ClickButton.Invoke(0, this);
			});
			SetPlateState(m_sceneId, m_evolveId, isSelect);
			if (bgData.GJFPFFBAKGK_CloseAt == 0)
				m_limitTextLayout.StartAllAnimGoStop("02");
			else
			{
				m_limitTextLayout.StartAllAnimGoStop("01");
				DateTime date = Utility.GetLocalDateTime(bgData.GJFPFFBAKGK_CloseAt);
				m_limitText.text = string.Format(MessageManager.Instance.GetMessage("menu", "home_bg_limit_period"), new object[5]
					{
						date.Year, date.Month, date.Day, date.Hour, date.Minute
					});
			}
		}

		//// RVA: 0x10975AC Offset: 0x10975AC VA: 0x10975AC
		public void UpdateContent(GCIJNCFDNON_SceneInfo sceneData, short evolveId, bool isSelect)
		{
			m_isLock = false;
			m_outline.enabled = false;
			int sceneId = sceneData.BCCHOBPJJKE_SceneId;
			m_sceneId = (short)sceneData.BCCHOBPJJKE_SceneId;
			m_evolveId = evolveId;
			MenuScene.Instance.SceneIconCache.SetLoadingTexture(m_sceneIconImage);
			MenuScene.Instance.SceneIconCache.Load(m_sceneId, m_evolveId, (IiconTexture texture) =>
			{
				//0x1097E54
				if (m_sceneId != sceneId)
					return;
				if (m_evolveId != evolveId)
					return;
				texture.Set(m_sceneIconImage);
				SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImage, texture as IconTexture, false);
			});
			m_sceneIconButton.ClearOnClickCallback();
			m_sceneIconButton.AddOnClickCallback(() =>
			{
				//0x1098000
				ClickButton.Invoke(0, this);
			});
			SetPlateState(m_sceneId, m_evolveId, isSelect);
			m_limitTextLayout.StartAllAnimGoStop("02");
			m_lockIconLayout.StartAllAnimGoStop("02");
		}

		//// RVA: 0x109710C Offset: 0x109710C VA: 0x109710C
		private void SetPlateState(short sceneId, short evolveId, bool isSelect)
		{
			if(isSelect)
			{
				for(int i = 0; i < m_selectFrameIcon.Count(); i++)
				{
					m_selectFrameIcon[i].enabled = true;
				}
				for(int i = 0; i < m_setFrameIcon.Count(); i++)
				{
					m_setFrameIcon[i].enabled = false;
				}
			}
			else
			{
				if(JKHEOEEPBMJ.AGHGOOBIGDI_GetHomeSceneId() == sceneId)
				{
					if(JKHEOEEPBMJ.HDLMKFFMGEP_GetHomeSceneEvolveId() == evolveId)
					{
						for (int i = 0; i < m_selectFrameIcon.Count(); i++)
						{
							m_selectFrameIcon[i].enabled = false;
						}
						for (int i = 0; i < m_setFrameIcon.Count(); i++)
						{
							m_setFrameIcon[i].enabled = true;
						}
						return;
					}
				}

				for (int i = 0; i < m_selectFrameIcon.Count(); i++)
				{
					m_selectFrameIcon[i].enabled = false;
				}
				for (int i = 0; i < m_setFrameIcon.Count(); i++)
				{
					m_setFrameIcon[i].enabled = false;
				}
			}
		}

		//// RVA: 0x1097934 Offset: 0x1097934 VA: 0x1097934
		public void InitPlateState()
		{
			for(int i = 0; i < m_selectFrameIcon.Count(); i++)
			{
				m_selectFrameIcon[i].enabled = false;
			}
			for(int i = 0; i < m_setFrameIcon.Count(); i++)
			{
				m_setFrameIcon[i].enabled = false;
			}
			m_selectframe.StartAllAnimGoStop("02");
			m_setframe.StartAllAnimGoStop("01");
			m_limitTextLayout.StartAllAnimGoStop("02");
			m_sceneId = 0;
			m_evolveId = 0;
			m_outline.enabled = false;
		}
	}
}
