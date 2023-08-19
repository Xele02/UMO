using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class EpisodeIcon : SwapScrollListContent
	{
		private AbsoluteLayout m_icon_mask_anim; // 0x20
		private AbsoluteLayout m_bar_anim; // 0x24
		private AbsoluteLayout m_comp_anim; // 0x28
		private AbsoluteLayout m_available_episode_point; // 0x2C
		private AbsoluteLayout m_available_episode_point_blink; // 0x30
		private AbsoluteLayout m_episodeFeedPlateAttention; // 0x34
		private AbsoluteLayout m_episodeFeedPlateLoopAnime; // 0x38
		private ActionButton m_btn; // 0x3C
		private Text m_next; // 0x40
		private Text m_episode_name; // 0x44
		private RawImageEx m_next_item; // 0x48
		private RawImageEx m_episode_image; // 0x4C
		private RawImageEx m_comp_icon; // 0x50
		private Action mUpdater; // 0x54
		private int m_frame; // 0x58
		private const int MaskFrameMax = 107;
		private Transform m_new_obj; // 0x5C
		private NewMarkIcon m_new_icon; // 0x60
		private RawImageEx m_mask_obj0; // 0x64
		private RawImageEx m_mask_obj1; // 0x68
		private Rect m_image_uv; // 0x6C
		private int GaugeMaxFrame = 265; // 0x7C
		private int AvailablePointMaxFrame = 264; // 0x80
		private bool m_isNewIconInitialized; // 0x84
		private int m_episode_image_index; // 0x88
		private int m_next_item_index; // 0x8C

		// RVA: 0xEF51C8 Offset: 0xEF51C8 VA: 0xEF51C8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_icon_mask_anim = layout.FindViewById("sw_cnm_ep_icon_03_anim") as AbsoluteLayout;
			m_bar_anim = layout.FindViewById("sw_sel_ep_mask_eff_anim") as AbsoluteLayout;
			m_comp_anim = layout.FindViewById("sw_sel_ep_light_anim") as AbsoluteLayout;
			m_bar_anim.StartChildrenAnimLoop("go_out");
			Transform t = transform.Find("sw_sel_ep_episode_all (AbsoluteLayout)/sw_sel_ep_episode (AbsoluteLayout)");
			m_btn = t.Find("sw_sel_ep_btn_detail_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			m_next = t.Find("point_count_01 (TextView)").GetComponent<Text>();
			m_episode_name = t.Find("episode_name_01 (TextView)").GetComponent<Text>();
			m_next_item = t.Find("cnm_ep_item_icon_01 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
			m_episode_image = t.Find("sw_cnm_ep_icon_03_anim (AbsoluteLayout)/cnm_ep_icon_01 (AbsoluteLayout)/swtexc_cmn_diva_m04 (ImageView)").GetComponent<RawImageEx>();
			m_comp_icon = t.Find("swtbl_cmp_icon (AbsoluteLayout)/cmn_cmp_icon (AbsoluteLayout)/cmn_cmp_icon (ImageView)").GetComponent<RawImageEx>();
			m_new_obj = t.Find("root_icon_new01 (AbsoluteLayout)");
			m_mask_obj0 = t.Find("sw_cnm_ep_icon_03_anim (AbsoluteLayout)/sel_ep_mask_01_01 (MaskView)/MaskInverse/sel_ep_g_mono (AbsoluteLayout)/sel_ep_g_mono (ImageView)").GetComponent<RawImageEx>();
			m_mask_obj1 = t.Find("sw_cnm_ep_icon_03_anim (AbsoluteLayout)/sel_ep_mask_01_01 (MaskView)/MaskInverse/cnm_ep_icon_01_sepia (AbsoluteLayout)/swtexc_cmn_diva_m04 (ImageView)").GetComponent<RawImageEx>();
			m_image_uv = new Rect(0.1171875f, 0, 0.765625f, 1);
			m_episode_image.uvRect = m_image_uv;
			m_mask_obj1.uvRect = m_image_uv;
			RectTransform rt = (GetComponentInChildren<Mask>(true).transform.GetChild(0) as RectTransform);
			rt.pivot = new Vector2(0, 1);
			rt.anchorMin = new Vector2(0, 1);
			rt.anchorMax = new Vector2(0, 1);
			m_available_episode_point = layout.FindViewByExId("sw_cnm_ep_icon_03_anim_sw_sel_ep_meter_eff_01_anim") as AbsoluteLayout;
			m_available_episode_point_blink = layout.FindViewByExId("sw_sel_ep_meter_eff_01_anim_sel_ep_meter_eff") as AbsoluteLayout;
			m_episodeFeedPlateAttention = layout.FindViewByExId("sw_sel_ep_episode_sw_sw_sel_ep_icon_ep_onoff_anim") as AbsoluteLayout;
			m_episodeFeedPlateLoopAnime = layout.FindViewByExId("sw_sw_sel_ep_icon_ep_onoff_anim_sw_sel_ep_icon_ep_anim") as AbsoluteLayout;
			m_new_icon = new NewMarkIcon();
			m_btn.AddOnClickCallback(OnPushDetail);
			return true;
		}

		//// RVA: 0xEF5B90 Offset: 0xEF5B90 VA: 0xEF5B90
		public void SetViewData(PIGBBNDPPJC data)
		{
			m_episode_name.text = data.OPFGFINHFCE_Name;
			if(!data.CCBKMCLDGAD_HasReward)
			{
				int a = EpisodeUtility.CalcEpisodeGaugeFrame(data.ABLHIAEDJAI_CurrentPoint, data.DMHDNKILKGI_MaxPoint, GaugeMaxFrame);
				m_icon_mask_anim.StartChildrenAnimGoStop(a, a);
				m_comp_icon.enabled = false;
				m_comp_anim.StartChildrenAnimGoStop("st_wait");
				m_new_icon.SetActive(data.CADENLBDAEB_IsNew);
				a = EpisodeUtility.CalcEpisodeGaugeFrame(data.LEGAKDFPPHA_AvaiablePoint, data.DMHDNKILKGI_MaxPoint, GaugeMaxFrame);
				a = Mathf.Clamp(a, 0, AvailablePointMaxFrame);
				m_available_episode_point.StartChildrenAnimGoStop(a, a);
			}
			else
			{
				m_icon_mask_anim.StartChildrenAnimGoStop("st_out", "st_out");
				m_comp_icon.enabled = true;
				m_comp_anim.StartChildrenAnimLoop("logo_up", "loen_up");
				m_new_icon.SetActive(false);
				m_available_episode_point.StartChildrenAnimGoStop("st_out");
			}
			StringBuilder str = new StringBuilder(32);
			str.SetFormat(JpStringLiterals.StringLiteral_15794, data.JBFLCHFEIGL.OJELCGDDAOM_MissingPoint, RichTextUtility.MakeSizeTagString("EP", 16));
			m_next.text = str.ToString();
			m_episodeFeedPlateAttention.StartChildrenAnimGoStop(data.JBCIDDKDJMM ? "01" : "02");
			SetEpisodeImage(data.KELFCMEOPPM_EpId);
			SetItemImage(data.JBFLCHFEIGL.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId);
		}

		//// RVA: 0xEF6320 Offset: 0xEF6320 VA: 0xEF6320
		public void InitializeNewIcon()
		{
			m_new_icon.Initialize(m_new_obj.gameObject);
			m_isNewIconInitialized = true;
		}

		//// RVA: 0xEF6380 Offset: 0xEF6380 VA: 0xEF6380
		public void ReleaseNew()
		{
			m_new_icon.Release();
			m_isNewIconInitialized = false;
		}

		//// RVA: 0xEF63B8 Offset: 0xEF63B8 VA: 0xEF63B8
		public void SetNewIconFrame(int frame)
		{
			if (m_isNewIconInitialized && m_new_icon != null)
			{
				m_new_icon.OverridePlayTime(frame);
			}
		}

		//// RVA: 0xEF63D8 Offset: 0xEF63D8 VA: 0xEF63D8
		public void SetBlinkFrame(int frame)
		{
			if (m_available_episode_point_blink != null)
				m_available_episode_point_blink.StartChildrenAnimGoStop(frame, frame);
		}

		//// RVA: 0xEF63F0 Offset: 0xEF63F0 VA: 0xEF63F0
		public void SetFeedEpisodeFrame(int frame)
		{
			if (m_episodeFeedPlateLoopAnime != null)
				m_episodeFeedPlateLoopAnime.StartChildrenAnimGoStop(frame, frame);
		}

		//// RVA: 0xEF6408 Offset: 0xEF6408 VA: 0xEF6408
		private void OnPushDetail()
		{
			ClickButton.Invoke(0, this);
		}

		//// RVA: 0xEF600C Offset: 0xEF600C VA: 0xEF600C
		private void SetEpisodeImage(int index)
		{
			m_episode_image_index = index;
			MenuScene.Instance.EpisodeIconCache.Load(index, (IiconTexture icon) =>
			{
				//0xEF64B0
				if (m_episode_image_index != index)
					return;
				icon.Set(m_episode_image);
				icon.Set(m_mask_obj1);
			});
		}

		//// RVA: 0xEF6194 Offset: 0xEF6194 VA: 0xEF6194
		private void SetItemImage(int index)
		{
			m_next_item_index = index;
			MenuScene.Instance.ItemTextureCache.Load(index, (IiconTexture icon) =>
			{
				//0xEF666C
				if (m_next_item_index != index)
					return;
				icon.Set(m_next_item);
			});
		}
	}
}
