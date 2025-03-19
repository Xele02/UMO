using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class EpisodeDetailWindow : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_abs; // 0x14
		private AbsoluteLayout m_next_gauge; // 0x18
		private AbsoluteLayout m_mask; // 0x1C
		private AbsoluteLayout m_bar_anim; // 0x20
		private AbsoluteLayout m_available_episode_point; // 0x24
		private AbsoluteLayout m_episodeFeedPlateAttention; // 0x28
		private Action m_updater; // 0x2C
		private NumberBase m_point_den; // 0x30
		private NumberBase m_point_mol; // 0x34
		private NumberBase m_point_item_num; // 0x38
		private ActionButton m_scene_btn; // 0x3C
		private ActionButton m_use_item_btn; // 0x40
		private ActionButton m_reward_btn; // 0x44
		private Text m_episode_name; // 0x48
		private Text m_episode_info; // 0x4C
		private Text m_item_name; // 0x50
		private Text m_next; // 0x54
		private RawImageEx m_episode_image; // 0x58
		private RawImageEx m_item_image; // 0x5C
		private RawImageEx m_episode_bg_image; // 0x60
		private EpisodeRewardPopupSetting m_reward_window = new EpisodeRewardPopupSetting(); // 0x64
		private const int MaskFrameMax = 107;
		private PIGBBNDPPJC m_data; // 0x68
		private EpisodeSceneListArgs m_sceneListArgs = new EpisodeSceneListArgs(); // 0x6C
		private RawImageEx m_mask_obj0; // 0x70
		private RawImageEx m_mask_obj1; // 0x74
		private Rect m_image_uv; // 0x78
		private Transform m_start_point; // 0x88
		private Transform m_end_point; // 0x8C
		private RectTransform m_line; // 0x90
		private RectTransform m_lineStartTarget; // 0x94
		private RectTransform m_lineEndTarget; // 0x98
		private const int LINE_Y_ADJUST = 4;
		private const int LINE_X_ADJUST = -10;
		private RawImageEx m_line_image; // 0x9C
		private RawImageEx m_next_image; // 0xA0
		private AbsoluteLayout m_next_abs; // 0xA4
		private AbsoluteLayout m_line_abs; // 0xA8
		private AbsoluteLayout m_gauge_table; // 0xAC
		private int GaugeMaxFrame = 265; // 0xB0
		private int AvailableEpisodePointMaxFrame = 264; // 0xB4
		private StringBuilder m_work_sb = new StringBuilder(32); // 0xB8
		private bool is_load_episode_image; // 0xBC
		private bool is_load_episode_bg_image; // 0xBD
		private bool is_load_episode_item_image; // 0xBE
		//[CompilerGeneratedAttribute] // RVA: 0x66CD5C Offset: 0x66CD5C VA: 0x66CD5C
		public Action<EpisodeSceneListArgs> PushSceneListHandler; // 0xC0

		// RVA: 0xEF143C Offset: 0xEF143C VA: 0xEF143C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.FindViewById("sw_sel_ep_detail_anim") as AbsoluteLayout;
			m_next_gauge = layout.FindViewById("sw_sel_ep_progress_anim") as AbsoluteLayout;
			m_mask = layout.FindViewById("sw_cnm_ep_icon_01_anim") as AbsoluteLayout;
			m_bar_anim = layout.FindViewById("sw_sel_ep_mask_eff_anim") as AbsoluteLayout;
			m_bar_anim.StartChildrenAnimLoop("go_out");
			Transform t1 = transform.Find("sw_sel_ep_detail_all (AbsoluteLayout)/sw_sel_ep_detail_anim (AbsoluteLayout)/sw_sel_ep_detail (AbsoluteLayout)");
			m_scene_btn = t1.Find("sw_sel_ep_btn_scene_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			m_use_item_btn = t1.Find("sw_sel_ep_btn_item_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			m_reward_btn = t1.Find("sw_sel_ep_btn_reward_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			m_episode_name = t1.Find("episode_name_01 (TextView)").GetComponent<Text>();
			m_episode_info = t1.Find("episode_detail_01 (TextView)").GetComponent<Text>();
			m_item_name = t1.Find("swtbl_detail_switch (AbsoluteLayout)/sel_ep_app_text (AbsoluteLayout)/app_text_01 (TextView)").GetComponent<Text>();
			m_next = t1.Find("swtbl_detail_switch (AbsoluteLayout)/sel_ep_point_count (AbsoluteLayout)/point_count_01 (TextView)").GetComponent<Text>();
			m_point_den = t1.Find("swtbl_detail_switch (AbsoluteLayout)/sw_state_num01 (AbsoluteLayout)/swnum_state_num01_l (AbsoluteLayout)").GetComponent<NumberBase>();
			m_point_mol = t1.Find("swtbl_detail_switch (AbsoluteLayout)/sw_state_num01 (AbsoluteLayout)").GetComponent<NumberBase>();
			m_point_item_num = t1.Find("swnum_item_num01 (AbsoluteLayout)").GetComponent<NumberBase>();
			m_episode_image = t1.Find("sw_cnm_ep_icon_01_anim (AbsoluteLayout)/cnm_ep_icon_01 (AbsoluteLayout)/swtexc_cmn_diva_m04 (ImageView)").GetComponent<RawImageEx>();
			m_item_image = t1.Find("cnm_ep_item_icon_02 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
			m_episode_bg_image = t1.Find("cnm_ep_bg_01 (AbsoluteLayout)/swtexc_cmn_episode_bg (ImageView)").GetComponent<RawImageEx>();
			m_episode_bg_image.raycastTarget = false;
			m_mask_obj0 = t1.Find("sw_cnm_ep_icon_01_anim (AbsoluteLayout)/sel_ep_mask_01_01 (MaskView)/MaskInverse/sel_ep_g_mono (AbsoluteLayout)/sel_ep_g_mono (ImageView)").GetComponent<RawImageEx>();
			m_mask_obj1 = t1.Find("sw_cnm_ep_icon_01_anim (AbsoluteLayout)/sel_ep_mask_01_01 (MaskView)/MaskInverse/cnm_ep_icon_01_sepia (AbsoluteLayout)/swtexc_cmn_diva_m04 (ImageView)").GetComponent<RawImageEx>();
			m_line_abs = layout.FindViewByExId("sw_cnm_ep_icon_01_anim_sel_ep_next_line") as AbsoluteLayout;
			m_next_abs = layout.FindViewByExId("sw_sel_ep_detail_sel_ep_next_fnt") as AbsoluteLayout;
			m_gauge_table = layout.FindViewById("swtbl_detail_switch") as AbsoluteLayout;
			m_start_point = t1.Find("sw_cnm_ep_icon_01_anim (AbsoluteLayout)/sel_ep_next_line (AbsoluteLayout)/sel_ep_next_line (ImageView)");
			m_end_point = t1.Find("item_arrival_pos (AbsoluteLayout)");
			GameObject g = new GameObject("lineObject");
			m_line = g.AddComponent<RectTransform>();
			m_line.SetParent(m_end_point, false);
			m_line.anchoredPosition = Vector2.zero;
			g.AddComponent<RawImage>().color = new Color(0.9921569f, 0.2666667f, 1, 1);
			g = new GameObject("LineStartTarget");
			m_lineStartTarget = g.AddComponent<RectTransform>();
			m_lineStartTarget.transform.SetParent(m_start_point, false);
			m_lineStartTarget.anchorMax = new Vector2(1, 1);
			m_lineStartTarget.anchorMin = new Vector2(1, 1);
			m_lineStartTarget.sizeDelta = new Vector2(10, 10);
			m_lineStartTarget.anchoredPosition = Vector2.zero;
			g = new GameObject("LineEndTarget");
			m_lineEndTarget = g.AddComponent<RectTransform>();
			m_lineEndTarget.SetParent(m_end_point, false);
			m_lineEndTarget.anchorMax = new Vector2(1, 1);
			m_lineEndTarget.anchorMin = new Vector2(1, 1);
			m_lineEndTarget.pivot = new Vector2(1, 1);
			m_lineEndTarget.sizeDelta = new Vector2(10, 10);
			m_line_image = t1.Find("sw_cnm_ep_icon_01_anim (AbsoluteLayout)/sel_ep_next_line (AbsoluteLayout)/sel_ep_next_line (ImageView)").GetComponent<RawImageEx>();
			m_next_image = t1.Find("sel_ep_next_fnt (AbsoluteLayout)/sel_ep_next_fnt (ImageView)").GetComponent<RawImageEx>();
			m_use_item_btn.AddOnClickCallback(() =>
			{
				//0xEF4258
				OnClickUseItem();
			});
			m_reward_btn.AddOnClickCallback(() =>
			{
				//0xEF425C
				OnClickReward();
			});
			m_scene_btn.AddOnClickCallback(() =>
			{
				//0xEF4260
				OnClickScene();
			});
			m_image_uv = new Rect(0.1171875f, 0, 0.765625f, 1);
			m_episode_image.uvRect = m_image_uv;
			m_mask_obj1.uvRect = m_image_uv;
			RectTransform rt = GetComponentInChildren<Mask>(true).transform.GetChild(0) as RectTransform;
			rt.pivot = new Vector2(0, 1);
			rt.anchorMin = new Vector2(0, 1);
			rt.anchorMax = new Vector2(0, 1);
			GaugeMaxFrame = (int)(m_line_abs.FrameAnimation.SearchLabelFrame("st_out"));
			m_available_episode_point = layout.FindViewByExId("sw_cnm_ep_icon_01_anim_sw_sel_ep_meter_eff_01_anim") as AbsoluteLayout;
			m_episodeFeedPlateAttention = layout.FindViewByExId("sw_sel_ep_detail_sw_sw_sel_ep_icon_ep_onoff_anim") as AbsoluteLayout;
			m_updater = UpdateLoad;
			return true;
		}

		// RVA: 0xEF28B8 Offset: 0xEF28B8 VA: 0xEF28B8
		private void Update()
		{
			MenuScene.Instance.ItemTextureCache.Update();
			MenuScene.Instance.EpisodeIconCache.Update();
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0xEF29D4 Offset: 0xEF29D4 VA: 0xEF29D4
		private void UpdateLoad()
		{
			if(m_point_den.IsLoaded() && m_point_mol.IsLoaded() && m_point_item_num.IsLoaded())
			{
				Loaded();
				m_updater = UpdateIdle;
			}
		}

		//// RVA: 0xEF2AE0 Offset: 0xEF2AE0 VA: 0xEF2AE0
		private void UpdateIdle()
		{
			return;
		}

		//// RVA: 0xEF2AE4 Offset: 0xEF2AE4 VA: 0xEF2AE4
		public void Enter()
		{
			this.StartCoroutineWatched(EnterWait());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DAB8C Offset: 0x6DAB8C VA: 0x6DAB8C
		//// RVA: 0xEF2B08 Offset: 0xEF2B08 VA: 0xEF2B08
		private IEnumerator EnterWait()
		{
			//0xEF45B0
			while (!is_load_episode_image)
				yield return null;
			while (!is_load_episode_bg_image)
				yield return null;
			while (!is_load_episode_item_image)
				yield return null;
			m_abs.StartChildrenAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0xEF2BB4 Offset: 0xEF2BB4 VA: 0xEF2BB4
		public bool IsLodingImage()
		{
			return !is_load_episode_image || !is_load_episode_bg_image || !is_load_episode_item_image;
		}

		//// RVA: 0xEF2BF0 Offset: 0xEF2BF0 VA: 0xEF2BF0
		public void Leave()
		{
			m_abs.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0xEF2C7C Offset: 0xEF2C7C VA: 0xEF2C7C
		public bool IsPlaying()
		{
			return m_abs.IsPlayingChildren();
		}

		//// RVA: 0xEF2CA8 Offset: 0xEF2CA8 VA: 0xEF2CA8
		public void Init(PIGBBNDPPJC data)
		{
			m_data = data;
			m_episode_name.text = data.OPFGFINHFCE_Name;
			if(!data.CCBKMCLDGAD_HasReward)
			{
				m_gauge_table.StartChildrenAnimGoStop(0, 0);
				m_line_image.enabled = true;
				m_next_image.enabled = true;
				int a = EpisodeUtility.CalcEpisodeGaugeFrame(data.ABLHIAEDJAI_CurrentPoint, data.DMHDNKILKGI_MaxPoint, GaugeMaxFrame);
				m_mask.StartChildrenAnimGoStop(a, a);
				m_point_den.SetNumber(data.JBFLCHFEIGL.DNBFMLBNAEE_TotalPoint - data.JBFLCHFEIGL.OJELCGDDAOM_MissingPoint, 0);
				SetGauge((int)(((m_data.JBFLCHFEIGL.DNBFMLBNAEE_TotalPoint - m_data.JBFLCHFEIGL.OJELCGDDAOM_MissingPoint) / m_data.JBFLCHFEIGL.DNBFMLBNAEE_TotalPoint - GetPoint0(data.KELFCMEOPPM_EpId)) * 100.0f));
				this.StartCoroutineWatched(SetItemGaugeLine(EpisodeUtility.CalcEpisodeGaugeFrame(data.JBFLCHFEIGL.DNBFMLBNAEE_TotalPoint, data.DMHDNKILKGI_MaxPoint, GaugeMaxFrame)));
				SetHasEpisodeGauge(EpisodeUtility.CalcEpisodeGaugeFrame(data.LEGAKDFPPHA_AvaiablePoint, data.DMHDNKILKGI_MaxPoint, AvailableEpisodePointMaxFrame));
			}
			else
			{
				m_gauge_table.StartChildrenAnimGoStop(1, 1);
				m_line_image.enabled = false;
				m_next_image.enabled = false;
				m_line.gameObject.SetActive(false);
				m_mask.StartChildrenAnimGoStop("st_out", "st_out");
				m_point_den.SetNumber(data.DMHDNKILKGI_MaxPoint, 0);
				SetGauge((int)(((m_data.JBFLCHFEIGL.DNBFMLBNAEE_TotalPoint - GetPoint0(data.KELFCMEOPPM_EpId) - data.JBFLCHFEIGL.OJELCGDDAOM_MissingPoint) / m_data.JBFLCHFEIGL.DNBFMLBNAEE_TotalPoint - GetPoint0(data.KELFCMEOPPM_EpId)) * 100.0f));
				SetHasEpisodeGauge(0);
			}
			m_point_mol.SetNumber(data.DMHDNKILKGI_MaxPoint, 0);
			m_point_item_num.SetNumber(data.JBFLCHFEIGL.GOOIIPFHOIG.MBJIFDBEDAC_Cnt, 0);
			m_work_sb.SetFormat(JpStringLiterals.StringLiteral_15750, data.JBFLCHFEIGL.OJELCGDDAOM_MissingPoint, RichTextUtility.MakeSizeTagString("EP", 22));
			m_next.text = m_work_sb.ToString();
			m_item_name.text = JpStringLiterals.StringLiteral_15778;
			m_episode_info.text = data.KLMPFGOCBHC_Description;
			SetEpisodeImage(m_data.KELFCMEOPPM_EpId);
			SetItemImage(m_data.JBFLCHFEIGL.GOOIIPFHOIG.JJBGOIMEIPF_ItemId);
			m_sceneListArgs.episodeId = data.KELFCMEOPPM_EpId;
			m_episodeFeedPlateAttention.StartChildrenAnimGoStop(data.JBCIDDKDJMM ? "01" : "02");
		}

		//// RVA: 0xEF3414 Offset: 0xEF3414 VA: 0xEF3414
		private int GetPoint0(int id)
		{
			List<LGMEPLIJLNB> rewards = LGMEPLIJLNB.FKDIMODKKJD_GetEpisodeRewards(id);
			int a = -1;
			for(int i = 0; i < rewards.Count; i++)
			{
				a = i;
				if (rewards[i].DNBFMLBNAEE_TotalPoint > m_data.ABLHIAEDJAI_CurrentPoint)
					break;
			}
			if (a < 1)
				return 0;
			else
			{
				return rewards[a - 1].DNBFMLBNAEE_TotalPoint;
			}
		}

		//// RVA: 0xEF37B0 Offset: 0xEF37B0 VA: 0xEF37B0
		private void SetEpisodeImage(int index)
		{
			is_load_episode_image = false;
			is_load_episode_bg_image = false;
			MenuScene.Instance.EpisodeIconCache.Load(index, (IiconTexture icon) =>
			{
				//0xEF4264
				icon.Set(m_episode_image);
				icon.Set(m_mask_obj1);
				is_load_episode_image = true;
			});
			MenuScene.Instance.EpisodeIconCache.LoadBg(index, (IiconTexture bg) =>
			{
				//0xEF43DC
				bg.Set(m_episode_bg_image);
				is_load_episode_bg_image = true;
			});
		}

		//// RVA: 0xEF3954 Offset: 0xEF3954 VA: 0xEF3954
		private void SetItemImage(int index)
		{
			is_load_episode_item_image = false;
			MenuScene.Instance.ItemTextureCache.Load(index, (IiconTexture icon) =>
			{
				//0xEF44C4
				icon.Set(m_item_image);
				is_load_episode_item_image = true;
			});
		}

		//// RVA: 0xEF3578 Offset: 0xEF3578 VA: 0xEF3578
		private void SetGauge(int gauge)
		{
			m_next_gauge.StartChildrenAnimGoStop(gauge + 1, gauge + 1);
		}

		//// RVA: 0xEF35B0 Offset: 0xEF35B0 VA: 0xEF35B0
		private void SetHasEpisodeGauge(int gauge)
		{
			if(gauge != 0)
			{
				m_available_episode_point.StartChildrenAnimGoStop(gauge, gauge);
			}
			else
			{
				m_available_episode_point.StartChildrenAnimGoStop("st_out");
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DAC04 Offset: 0x6DAC04 VA: 0x6DAC04
		//// RVA: 0xEF3708 Offset: 0xEF3708 VA: 0xEF3708
		private IEnumerator SetItemGaugeLine(int frame)
		{
			//0xEF47A4
			if (frame >= GaugeMaxFrame)
				frame = GaugeMaxFrame - 1;
			m_next_abs.StartAllAnimGoStop(frame, frame);
			m_line_abs.StartAllAnimGoStop(frame, frame);
			m_line.gameObject.SetActive(true);
			while (!GetComponentInParent<Canvas>())
				yield return null;
			Canvas c = GetComponentInParent<Canvas>();
			Vector2 v1 = c.worldCamera.WorldToScreenPoint(m_lineEndTarget.position);
			Vector2 v2 = c.worldCamera.WorldToScreenPoint(m_lineStartTarget.position);
			RectTransform rt = c.transform.Find("Root").GetComponent<RectTransform>();
			Vector2 s = rt.sizeDelta;
			float a = Mathf.Atan2(v2.y * (s.y / Screen.height) - v1.y * (s.y / Screen.height),
				v2.x * (s.x / Screen.width) - v1.x * (s.x / Screen.width));
			m_line.pivot = new Vector2(0, 1);
			m_line.anchorMax = new Vector2(1, 1);
			m_line.anchorMin = new Vector2(1, 1);
			m_line.anchoredPosition = Vector2.zero;
			if(a * 57.29578f >= 0)
			{
				m_line.localScale = new Vector3(1, -1, 1);
				m_lineStartTarget.anchoredPosition = new Vector2(0, 0);
			}
			else
			{
				m_line.localScale = new Vector3(1, 1, 1);
				m_lineStartTarget.anchoredPosition = new Vector2(0, -5);
			}
			v1 = c.worldCamera.WorldToScreenPoint(m_lineEndTarget.position);
			v2 = c.worldCamera.WorldToScreenPoint(m_lineStartTarget.position);
			a = Mathf.Atan2(v2.y - v1.y, v2.x - v1.x);
			m_line.transform.SetLocalEulerAngleZ(a * 57.29578f);
			RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, v1, c.worldCamera, out v1);
			RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, v2, c.worldCamera, out v2);
			m_line.sizeDelta = new Vector2(Vector3.Distance(v2, v1), 5);
		}

		//// RVA: 0xEF3C5C Offset: 0xEF3C5C VA: 0xEF3C5C
		private void OnClickUseItem()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			EpisodeItemSelectArgs arg = new EpisodeItemSelectArgs();
			arg.data = m_data;
			MenuScene.Instance.Call(TransitionList.Type.EPISODE_ITEM_SELECT, arg, true);
		}

		//// RVA: 0xEF3DA0 Offset: 0xEF3DA0 VA: 0xEF3DA0
		private void OnClickReward()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_reward_window.TitleText = bk.GetMessageByLabel("popup_title_episode_01");
			m_reward_window.SetParent(transform);
			m_reward_window.episodeId = m_data.KELFCMEOPPM_EpId;
			m_reward_window.WindowSize = SizeType.Large;
			m_reward_window.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(m_reward_window, null, null, null, null);
		}

		//// RVA: 0xEF4098 Offset: 0xEF4098 VA: 0xEF4098
		private void OnClickScene()
		{
			if (PushSceneListHandler == null)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			PushSceneListHandler(m_sceneListArgs);
		}
	}
}
