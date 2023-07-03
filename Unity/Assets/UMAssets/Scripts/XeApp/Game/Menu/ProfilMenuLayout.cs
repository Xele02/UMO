using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System;
using XeSys;
using mcrs;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class ProfilMenuLayout : LayoutUGUIScriptBase
	{
		public enum InfoType
		{
			PLAYER = 0,
			SCENE = 1,
			STATS = 2,
			ASSIST = 3,
		}

		private enum ImageLoadFlags
		{
			None = 0,
			Diva = 1,
			Scene = 2,
			Degree = 4,
			Assist = 8,
			All = 15,
		}

		public enum ButtonType
		{
			None = 0,
			Fan = 1,
			Fan_NoLobby = 2,
			Raid = 3,
			Raid_Result = 4,
		}

		private class CostumeData
		{
			public CKFGMNAIBNG data; // 0x8
			public int color; // 0xC
		}

		private class AssistImageData
		{
			public int index; // 0x8
			public IiconTexture sceneTex; // 0xC
			public bool isKira; // 0x10
		}

		private const int MAIN_GUN_POWER_MAX = 999999;
		private const int FAN_COUNT_MAX = 99999;
		private const int StatsPageNum = 6;
		private const int AssistPageStatusNum = 3;
		private const int AssistPageSelectNum = 5;
		private const int AssistAttributeMax = 4;
		private const int AssistLoadImagePlayer = 20;
		private const int AssistLoadImageFriend = 4;
		private static readonly string[] DifficultUvTable = new string[5] {
			"cmn_music_diff_01", "cmn_music_diff_02", "cmn_music_diff_03",
			"cmn_music_diff_04", "cmn_music_diff_05"
		}; // 0x0
		private static readonly string[] DifficultUvTable_6Line = new string[3]
			{
				"cmn_music_diff_06", "cmn_music_diff_07", "cmn_music_diff_08"
			}; // 0x4
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x67693C Offset: 0x67693C VA: 0x67693C
		private Text m_player_name; // 0x14
		[SerializeField]
		private Text m_player_name_time; // 0x18
		[SerializeField]
		private RawImageEx m_diva_image; // 0x1C
		[SerializeField]
		private Transform m_diva_level; // 0x20
		[SerializeField]
		private ActionButton m_scene_info_tab_btn; // 0x24
		[SerializeField]
		private ActionButton m_player_info_tab_btn; // 0x28
		[SerializeField]
		private ActionButton m_stats_info_tab_btn; // 0x2C
		[SerializeField]
		private ActionButton m_assist_info_tab_btn; // 0x30
		[SerializeField]
		private ActionButton m_lobbyBrowsing_btn; // 0x34
		[SerializeField]
		private ActionButton m_fanRelease_btn; // 0x38
		[SerializeField]
		private ActionButton m_fanEntry_btn; // 0x3C
		[SerializeField]
		private ActionButton m_visit_btn; // 0x40
		[SerializeField]
		private ActionButton m_block_btn; // 0x44
		//[HeaderAttribute] // RVA: 0x676A48 Offset: 0x676A48 VA: 0x676A48
		[SerializeField]
		private Text m_degree; // 0x48
		[SerializeField]
		private Text m_comment; // 0x4C
		[SerializeField]
		private Text m_player_id; // 0x50
		[SerializeField]
		private Text m_player_level; // 0x54
		[SerializeField]
		private RawImageEx m_degree_image; // 0x58
		[SerializeField]
		private RawImageEx m_musicrate_image; // 0x5C
		[SerializeField]
		private Text m_musicrate00_text; // 0x60
		[SerializeField]
		private Text m_musicrate01_text; // 0x64
		[SerializeField]
		private ActionButton m_musicrate_popup_button; // 0x68
		[SerializeField]
		private ActionButton m_name_btn; // 0x6C
		[SerializeField]
		private ActionButton m_comment_btn; // 0x70
		[SerializeField]
		private ActionButton m_degree_btn; // 0x74
		[SerializeField]
		private ActionButton m_player_id_btn; // 0x78
		[SerializeField]
		private StayButton m_degree_info; // 0x7C
		[SerializeField]
		private NumberBase m_degree_num; // 0x80
		[SerializeField]
		private NumberBase m_fanCount_num; // 0x84
		[SerializeField]
		private Text m_mainGunPower_text; // 0x88
		//[HeaderAttribute] // RVA: 0x676B9C Offset: 0x676B9C VA: 0x676B9C
		[SerializeField]
		private Text[] m_center_skill_name; // 0x8C
		[SerializeField]
		private Text[] m_center_skill_desc; // 0x90
		[SerializeField]
		private Text[] m_center_skill_level; // 0x94
		[SerializeField]
		private RawImageEx[] m_center_skill_rank; // 0x98
		[SerializeField]
		private RawImageEx[] m_center_skill_foldout; // 0x9C
		[SerializeField]
		private ButtonBase[] m_center_skill_btn; // 0xA0
		[SerializeField]
		private RegulationButton m_center_skill_regu_btn; // 0xA4
		[SerializeField]
		private Text m_scene_name; // 0xA8
		[SerializeField]
		private RawImageEx m_scene_image; // 0xAC
		[SerializeField]
		private StayButton m_scene_info; // 0xB0
		[SerializeField]
		private LayoutUGUIHitOnly m_scene_hit_only; // 0xB4
		[SerializeField]
		private RectTransform m_scene_info_rect; // 0xB8
		[SerializeField]
		private Text m_scene_total; // 0xBC
		[SerializeField]
		private Text m_scene_soul; // 0xC0
		[SerializeField]
		private Text m_scene_voice; // 0xC4
		[SerializeField]
		private Text m_scene_charm; // 0xC8
		[SerializeField]
		private Text m_scene_life; // 0xCC
		[SerializeField]
		private Text m_scene_support; // 0xD0
		[SerializeField]
		private Text m_scene_fold; // 0xD4
		[SerializeField]
		private Text m_scene_luck; // 0xD8
		[SerializeField]
		private TextAnchor m_center_skill_name_align; // 0xDC
		[SerializeField]
		private TextAnchor m_center_skill_desc_align; // 0xE0
		[SerializeField]
		private TextAnchor m_center_skill_level_align; // 0xE4
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x676D58 Offset: 0x676D58 VA: 0x676D58
		private ActionButton m_page_left_btn; // 0xE8
		[SerializeField]
		private ActionButton m_page_right_btn; // 0xEC
		[SerializeField]
		private Text m_stats_page_num; // 0xF0
		[SerializeField]
		private Text m_stats_plate_count; // 0xF4
		[SerializeField]
		private Text m_stats_valkyrie_count; // 0xF8
		[SerializeField]
		private Text m_stats_lvmax_plate_count; // 0xFC
		[SerializeField]
		private Text m_stats_costume_count; // 0x100
		[SerializeField]
		private Text m_stats_mission_clear_count; // 0x104
		[SerializeField]
		private Text m_stats_clear_count; // 0x108
		[SerializeField]
		private Text m_stats_perfect_notes_count; // 0x10C
		[SerializeField]
		private Text m_stats_highscore_value; // 0x110
		[SerializeField]
		private Text m_stats_highscore_music; // 0x114
		[SerializeField]
		private RawImageEx m_stats_highscore_diff; // 0x118
		[SerializeField]
		private List<Text> m_stats_clear_music_count; // 0x11C
		[SerializeField]
		private List<Text> m_stats_fullcombo_music_count; // 0x120
		[SerializeField]
		private List<RawImageEx> m_stats_extreme_image; // 0x124
		[SerializeField]
		private Text m_emblem_scroll_text; // 0x128
		[SerializeField]
		private SwapScrollList m_swap_scroll; // 0x12C
		//[HeaderAttribute] // RVA: 0x676EB4 Offset: 0x676EB4 VA: 0x676EB4
		[SerializeField]
		private Text[] m_assist_attribute_title; // 0x130
		[SerializeField]
		private RawImageEx[] m_assist_scene_image; // 0x134
		[SerializeField]
		private Text m_assist_name; // 0x138
		[SerializeField]
		private Text m_assist_caution; // 0x13C
		[SerializeField]
		private Text m_assist_status_page_now; // 0x140
		[SerializeField]
		private Text m_assist_status_page_max; // 0x144
		[SerializeField]
		private Text[] m_assist_total; // 0x148
		[SerializeField]
		private Text[] m_assist_life; // 0x14C
		[SerializeField]
		private Text[] m_assist_center_skill_name; // 0x150
		[SerializeField]
		private Text[] m_assist_center_skill_level; // 0x154
		[SerializeField]
		private RawImageEx[] m_assist_certer_skill_rank; // 0x158
		[SerializeField]
		private Text[] m_assist_soul; // 0x15C
		[SerializeField]
		private Text[] m_assist_voice; // 0x160
		[SerializeField]
		private Text[] m_assist_charm; // 0x164
		[SerializeField]
		private Text[] m_assist_support; // 0x168
		[SerializeField]
		private Text[] m_assist_fold; // 0x16C
		[SerializeField]
		private Text[] m_assist_luck; // 0x170
		[SerializeField]
		private ActionButton m_assist_name_btn; // 0x174
		[SerializeField]
		private ActionButton m_assist_status_btn; // 0x178
		[SerializeField]
		private ActionButton[] m_assist_page_btn; // 0x17C
		[SerializeField]
		private StayButton[] m_assist_plate_btn; // 0x180
		[SerializeField]
		private SwaipTouch m_swaip_touch; // 0x184
		private AbsoluteLayout m_abs; // 0x188
		private AbsoluteLayout m_info_table; // 0x18C
		private AbsoluteLayout m_scene_info_btn; // 0x190
		private AbsoluteLayout m_player_info_btn; // 0x194
		private AbsoluteLayout m_stats_info_btn; // 0x198
		private AbsoluteLayout m_assist_info_btn; // 0x19C
		private AbsoluteLayout m_player_id_switch; // 0x1A0
		private AbsoluteLayout m_text_switch; // 0x1A4
		private AbsoluteLayout m_stats_page; // 0x1A8
		private AbsoluteLayout m_player_info_win; // 0x1AC
		private AbsoluteLayout m_center_skill_mask; // 0x1B0
		private AbsoluteLayout m_center_skill_cross_fade; // 0x1B4
		private AbsoluteLayout[] m_assist_status_layout; // 0x1B8
		private AbsoluteLayout m_assist_selectnum_layout; // 0x1BC
		private AbsoluteLayout[] m_assist_select_layout; // 0x1C0
		private AbsoluteLayout[] m_assist_skill_layout; // 0x1C4
		private AbsoluteLayout[] m_assist_skill_cross_fade_layout; // 0x1C8
		private AbsoluteLayout m_assist_name_btn_layout; // 0x1CC
		private AbsoluteLayout m_assist_arrow_layout; // 0x1D0
		private bool m_is_friend; // 0x1D4
		private IAPDFOPPGND m_degree_data; // 0x1D8
		private GCIJNCFDNON_SceneInfo m_scene_data; // 0x1DC
		private DivaIconDecoration m_level_icon; // 0x1E0
		private SceneIconDecoration m_scene_deco; // 0x1E4
		private SceneIconDecoration[] m_assist_scene_deco = new SceneIconDecoration[4]; // 0x1E8
		private DegreeSetPopupSetting m_degree_setting = new DegreeSetPopupSetting(); // 0x1EC
		private TextPopupSetting m_notChangedPlayerNamePopupSetting = new TextPopupSetting(); // 0x1F0
		private TextPopupSetting m_notChangedCommentPopupSetting = new TextPopupSetting(); // 0x1F4
		private Action m_updater; // 0x1F8
		private ImageLoadFlags m_imageLoadFlags; // 0x1FC
		private int m_stats_page_idx; // 0x200
		private string[] m_center_skill_full_desc = new string[2]
			{
				"", ""
			}; // 0x204
		private float m_copyButtonPrevPushSec; // 0x208
		private const float m_copyButtonIntervalSec = 3;
		private bool m_swap_scroll_loaded; // 0x20C
		private TransitionUniqueId m_transitionUniquId; // 0x210
		private List<CKFGMNAIBNG> m_costume_list; // 0x214
		private List<PNGOLKLFFLH> m_valkyrie_list; // 0x218
		private List<IAPDFOPPGND> m_emblem_list = new List<IAPDFOPPGND>(); // 0x21C
		private GHLGEECLCMH m_viewHSRatingData = new GHLGEECLCMH(); // 0x220
		private PopupDetailValkyrieSetting m_popup_setting_val = new PopupDetailValkyrieSetting(); // 0x224
		private TexUVListManager m_uvMan; // 0x228
		private EAJCBFGKKFA_FriendInfo m_friend_player_data; // 0x22C
		private bool m_enable_lobby_btn; // 0x230
		private ButtonType m_btnType; // 0x234
		private List<CostumeData> m_inner_costume_list; // 0x238
		private EEMGHIINEHN m_view_assist_data = new EEMGHIINEHN(); // 0x23C
		private int m_assist_status_page; // 0x240
		private int m_assist_select_page; // 0x244
		private int m_assist_load_image_count; // 0x248
		private int m_assist_load_image_max; // 0x24C
		private GCIJNCFDNON_SceneInfo[] m_assist_scene_data = new GCIJNCFDNON_SceneInfo[4]; // 0x250
		private List<AssistImageData> m_assist_imagedata_list = new List<AssistImageData>(); // 0x254
		private bool m_is_lock_scene; // 0x258
		private bool m_is_lock_swaip; // 0x259
		private bool m_is_stop_swaip; // 0x25A
		private bool m_is_enable_swaip; // 0x25B
		private const string LevelFormat = "Lv{0}";

		public bool IsFriend { get { return m_is_friend; } } //0x116B76C
		public List<CKFGMNAIBNG> CostumeList { get { return m_costume_list; } set { m_costume_list = value; } } //0x116B774 0x116B77C
		public List<PNGOLKLFFLH> ValkyrieList { get { return m_valkyrie_list; } set { m_valkyrie_list = value; } } //0x116B784 0x116B78C
		public List<IAPDFOPPGND> EmblemList { get { return m_emblem_list; } set { m_emblem_list = value; } } //0x116B794 0x116B79C

		// RVA: 0x116B7A4 Offset: 0x116B7A4 VA: 0x116B7A4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			m_abs = layout.FindViewByExId("root_sw_cmn_profile_sw_cmn_profile_anim") as AbsoluteLayout;
			m_info_table = layout.FindViewByExId("sw_cmn_profile_all_swtbl_cmn_pro") as AbsoluteLayout;
			m_scene_info_btn = layout.FindViewByExId("sw_cmn_pro_tab_all_swtbl_cmn_pro_tab_01") as AbsoluteLayout;
			m_player_info_btn = layout.FindViewByExId("sw_cmn_pro_tab_all_swtbl_cmn_pro_tab_02") as AbsoluteLayout;
			m_stats_info_btn = layout.FindViewByExId("sw_cmn_pro_tab_all_swtbl_cmn_pro_tab_03") as AbsoluteLayout;
			m_assist_info_btn = layout.FindViewByExId("sw_cmn_pro_tab_all_swtbl_cmn_pro_tab_04") as AbsoluteLayout;
			m_player_id_switch = layout.FindViewByExId("sw_cmn_pro_me_swtbl_cmn_pro_id") as AbsoluteLayout;
			m_text_switch = layout.FindViewByExId("sw_cmn_pro_degree_swtbl_cmn_pro_text") as AbsoluteLayout;
			m_stats_page = layout.FindViewByExId("sw_cmn_pro_grade_sw_cmn_grade_page_switch") as AbsoluteLayout;
			m_player_info_win = layout.FindViewByExId("swtbl_cmn_pro_sw_cmn_pro_me") as AbsoluteLayout;
			m_center_skill_mask = layout.FindViewByExId("sw_cmn_pro_diva_swtbl_black_onoff") as AbsoluteLayout;
			m_center_skill_cross_fade = layout.FindViewByExId("sw_cmn_pro_diva_sw_c_skill_cf_anim") as AbsoluteLayout;
			m_assist_selectnum_layout = layout.FindViewByExId("sw_assist_swtbl_bg_change_mark") as AbsoluteLayout;
			m_assist_select_layout = new AbsoluteLayout[5];
			for(int i = 0; i < m_assist_select_layout.Length; i++)
			{
				m_assist_select_layout[i] = layout.FindViewByExId(string.Format("swtbl_bg_change_mark_0{0}a", i + 1)) as AbsoluteLayout;
			}
			m_assist_status_layout = new AbsoluteLayout[4];
			m_assist_skill_layout = new AbsoluteLayout[4];
			m_assist_skill_cross_fade_layout = new AbsoluteLayout[4];
			for(int i = 0; i < m_assist_skill_layout.Length; i++)
			{
				m_assist_status_layout[i] = layout.FindViewByExId(string.Format("sw_assist_swtbl_assist_0{0}", i + 1)) as AbsoluteLayout;
				m_assist_skill_layout[i] = m_assist_status_layout[i].FindViewByExId("swtbl_assist_swtbl_note") as AbsoluteLayout;
				m_assist_skill_cross_fade_layout[i] = m_assist_status_layout[i].FindViewByExId("assist_01_sw_c_skill_cf_anim2") as AbsoluteLayout;
			}
			m_assist_name_btn_layout = layout.FindViewByExId("sw_assist_sw_asst_name_onoff_anim") as AbsoluteLayout;
			m_assist_arrow_layout = layout.FindViewByExId("sw_assist_sw_arrow_onoff") as AbsoluteLayout;
			m_scene_info_tab_btn.AddOnClickCallback(() =>
			{
				//0x117AC58
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				SetInfoTable(InfoType.SCENE);
			});
			m_player_info_tab_btn.AddOnClickCallback(() =>
			{
				//0x117ACC0
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				SetInfoTable(InfoType.PLAYER);
			});
			m_stats_info_tab_btn.AddOnClickCallback(() =>
			{
				//0x117AD28
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				SetInfoTable(InfoType.STATS);
			});
			m_assist_info_tab_btn.AddOnClickCallback(() =>
			{
				//0x117AD90
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				SetInfoTable(InfoType.ASSIST);
			});
			m_lobbyBrowsing_btn.AddOnClickCallback(OnClickLobbyBrowsing);
			m_fanRelease_btn.AddOnClickCallback(OnClickFanRelease);
			m_fanEntry_btn.AddOnClickCallback(OnClickFanEntry);
			m_visit_btn.AddOnClickCallback(OnClickVisit);
			m_block_btn.AddOnClickCallback(OnClickBlock);
			Transform t = m_player_id_btn.transform.Find("cmn_pro_font (AbsoluteLayout)/swtexf_cmn_pro_btn_font_01 (ImageView)");
			t.GetComponent<RawImageEx>().uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("cmn_pro_btn_font_03"));
			m_name_btn.AddOnClickCallback(() =>
			{
				//0x117ADF8
				OnChangePlayerName(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName);
			});
			m_comment_btn.AddOnClickCallback(() =>
			{
				//0x117AEE4
				OnChangeComment(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.CMKKFCGBILD_Prof);
			});
			m_degree_btn.AddOnClickCallback(() =>
			{
				//0x117BD90
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				//MenuScene.Instance.Call(TransitionList.Type.DEGREE_SELECT, null, true);
				TodoLogger.LogNotImplemented("SetDegree");
			});
			m_degree_info.AddOnClickCallback(() =>
			{
				//0x117AFD0
				TodoLogger.LogNotImplemented("DegreeInfo");
			});
			m_degree_info.AddOnStayCallback(() =>
			{
				//0x117AFD4
				TodoLogger.LogNotImplemented("DegreeInfo 2");
			});
			m_player_id_btn.AddOnClickCallback(() =>
			{
				//0x117AFD8
				TodoLogger.LogNotImplemented("PlayerId Copy");
			});
			m_musicrate_popup_button.AddOnClickCallback(() =>
			{
				//0x117B060
				TodoLogger.LogNotImplemented("MusicRatePopup");
			});
			m_scene_info.AddOnClickCallback(() =>
			{
				//0x117B064
				OnClickSceneInfo();
			});
			m_scene_info.AddOnStayCallback(() =>
			{
				//0x117B068
				OnClickSceneInfo();
			});
			m_page_left_btn.AddOnClickCallback(() =>
			{
				//0x117B06C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				UpdateStatsPage(m_stats_page_idx - 1);
			});
			m_page_right_btn.AddOnClickCallback(() =>
			{
				//0x117B070
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				UpdateStatsPage(m_stats_page_idx + 1);
			});
			this.StartCoroutineWatched(Load_ScrollItemIcon());
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_popup_setting_val.TitleText = bk.GetMessageByLabel("popup_title_04");
			m_popup_setting_val.SetParent(transform);
			m_assist_status_btn.AddOnClickCallback(OnClickAssistStatusPage);
			m_assist_page_btn[0].AddOnClickCallback(() =>
			{
				//0x117B074
				ChangeAssistSelectPage(m_assist_select_page - 1);
				m_is_lock_swaip = true;
				SwaipReset();
			});
			m_assist_page_btn[1].AddOnClickCallback(() =>
			{
				//0x117B0A4
				ChangeAssistSelectPage(m_assist_select_page + 1);
				m_is_lock_swaip = true;
				SwaipReset();
			});
			for(int i = 0; i < 4; i++)
			{
				int attribute = i;
				m_assist_plate_btn[i].AddOnStayCallback(() =>
				{
					//0x117C67C
					OnStayAssistScene(attribute);
				});
			}
			m_assist_name_btn.AddOnClickCallback(() =>
			{
				//0x117B0D4
				OnChangeAssitName(m_assist_select_page);
			});
			m_notChangedPlayerNamePopupSetting = PopupWindowManager.CrateTextContent(
				MessageManager.Instance.GetMessage("common", "popup_ngword_error_title"),
				0,
				MessageManager.Instance.GetMessage("menu", "popup_text_notchangedplayername"),
				new ButtonInfo[1]{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true);
			m_notChangedCommentPopupSetting = PopupWindowManager.CrateTextContent(
				MessageManager.Instance.GetMessage("common", "popup_ngword_error_title"),
				0,
				MessageManager.Instance.GetMessage("menu", "popup_text_notchangedcomment"),
				new ButtonInfo[1]{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true);
			this.StartCoroutineWatched(LoadDegreeInfoWindow());
			m_updater = UpdateLoad;
			return true;
		}

		// RVA: 0x116D6E8 Offset: 0x116D6E8 VA: 0x116D6E8
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0x116D6FC Offset: 0x116D6FC VA: 0x116D6FC
		private void UpdateLoad()
		{
			if(m_degree_setting.Content != null)
			{
				if(m_degree_num.IsLoaded())
				{
					if(m_swap_scroll_loaded)
					{
						Loaded();
						m_updater = UpdateIdle;
					}
				}
			}
		}

		//// RVA: 0x116D834 Offset: 0x116D834 VA: 0x116D834
		private void UpdateIdle()
		{
			if (!m_swaip_touch.IsReady() || m_is_stop_swaip)
				return;
			if (!m_is_enable_swaip)
				return;
			if(m_is_lock_scene)
			{
				if (!m_swaip_touch.IsSwaiping())
					m_is_lock_scene = false;
			}
			if(m_swaip_touch.IsSwaip(SwaipTouch.Direction.RIGHT) || m_swaip_touch.IsFlickNoSwaip(SwaipTouch.Direction.RIGHT))
			{
				if(!m_is_lock_swaip)
				{
					ChangeAssistSelectPage(m_assist_select_page - 1);
					m_is_lock_scene = true;
					m_is_lock_swaip = true;
				}
			}
			if (m_swaip_touch.IsSwaip(SwaipTouch.Direction.LEFT) || m_swaip_touch.IsFlickNoSwaip(SwaipTouch.Direction.LEFT))
			{
				if (!m_is_lock_swaip)
				{
					ChangeAssistSelectPage(m_assist_select_page + 1);
					m_is_lock_scene = true;
					m_is_lock_swaip = true;
				}
			}
			if(!m_assist_status_btn.IsPlaying())
			{
				if (m_is_lock_swaip)
					m_is_lock_swaip = false;
			}
		}

		//// RVA: 0x116DA00 Offset: 0x116DA00 VA: 0x116DA00
		private void WaitEnterLeave()
		{
			if (m_abs.IsPlayingChildren())
				return;
			m_updater = UpdateIdle;
		}

		//// RVA: 0x116DAB0 Offset: 0x116DAB0 VA: 0x116DAB0
		public void Out()
		{
			m_abs.StartChildrenAnimGoStop("st_out", "st_out");
		}

		//// RVA: 0x116DB30 Offset: 0x116DB30 VA: 0x116DB30
		public void Enter()
		{
			m_abs.StartChildrenAnimGoStop("go_in", "st_in");
			m_updater = WaitEnterLeave;
		}

		//// RVA: 0x116DBF8 Offset: 0x116DBF8 VA: 0x116DBF8
		public void Leave()
		{
			m_abs.StartChildrenAnimGoStop("go_out", "st_out");
			m_updater = WaitEnterLeave;
		}

		//// RVA: 0x116DCC0 Offset: 0x116DCC0 VA: 0x116DCC0
		public void OtherRelease()
		{
			if (m_level_icon != null)
				m_level_icon.Release();
			if (m_scene_deco != null)
				m_scene_deco.Release();
			for(int i = 0; i < 4; i++)
			{
				if(m_assist_scene_deco[i] != null)
				{
					m_assist_scene_deco[i].Release();
				}
			}
		}

		//// RVA: 0x116DD98 Offset: 0x116DD98 VA: 0x116DD98
		public bool IsLoadingImage()
		{
			return m_imageLoadFlags == ImageLoadFlags.All;
		}

		//// RVA: 0x116DDAC Offset: 0x116DDAC VA: 0x116DDAC
		public void Init()
		{
			TodoLogger.Log(0, "Init");
		}

		//// RVA: 0x1171608 Offset: 0x1171608 VA: 0x1171608
		public void Init(EAJCBFGKKFA_FriendInfo data, bool a_enable_lobby_btn)
		{
			TodoLogger.Log(0, "Init 2");
		}

		//// RVA: 0x1171E90 Offset: 0x1171E90 VA: 0x1171E90
		public void SetInfoTable(InfoType type)
		{
			m_info_table.StartChildrenAnimGoStop((int)type, (int)type);
			switch(type)
			{
				case InfoType.PLAYER:
					m_scene_info_btn.StartChildrenAnimGoStop(0, 0);
					m_player_info_btn.StartChildrenAnimGoStop(1, 1);
					m_stats_info_btn.StartChildrenAnimGoStop(0, 0);
					m_assist_info_btn.StartChildrenAnimGoStop(0, 0);
					m_is_stop_swaip = true;
					break;
				case InfoType.SCENE:
					m_scene_info_btn.StartChildrenAnimGoStop(1, 1);
					m_player_info_btn.StartChildrenAnimGoStop(0, 0);
					m_stats_info_btn.StartChildrenAnimGoStop(0, 0);
					m_assist_info_btn.StartChildrenAnimGoStop(0, 0);
					m_is_stop_swaip = true;
					break;
				case InfoType.STATS:
					m_scene_info_btn.StartChildrenAnimGoStop(0, 0);
					m_player_info_btn.StartChildrenAnimGoStop(0, 0);
					m_stats_info_btn.StartChildrenAnimGoStop(1, 1);
					m_assist_info_btn.StartChildrenAnimGoStop(0, 0);
					UpdateStatsPage(m_stats_page_idx);
					m_is_stop_swaip = true;
					break;
				case InfoType.ASSIST:
					m_scene_info_btn.StartChildrenAnimGoStop(0, 0);
					m_player_info_btn.StartChildrenAnimGoStop(0, 0);
					m_stats_info_btn.StartChildrenAnimGoStop(0, 0);
					m_assist_info_btn.StartChildrenAnimGoStop(1, 1);
					m_is_stop_swaip = false;
					break;
			}
			SwaipReset();
		}

		//// RVA: 0x11722DC Offset: 0x11722DC VA: 0x11722DC
		public void SetPlayerInfoWindow(bool IsEnableCannon, bool IsEnableFan)
		{
			string s = "";
			if (IsEnableCannon && IsEnableFan)
				s = "04";
			else
			{
				s = "01";
				if (IsEnableCannon)
					s = "03";
				if (IsEnableFan)
					s = "02";
			}
			m_player_info_win.StartChildrenAnimGoStop(s);
		}

		//// RVA: 0x11723A0 Offset: 0x11723A0 VA: 0x11723A0
		public void SetTransitionUniqueId(TransitionUniqueId uniqueId)
		{
			m_transitionUniquId = uniqueId;
		}

		//// RVA: 0x11723A8 Offset: 0x11723A8 VA: 0x11723A8
		//private int CountHaveScene() { }

		//// RVA: 0x1172564 Offset: 0x1172564 VA: 0x1172564
		public bool IsPlaying()
		{
			return m_abs.IsPlayingChildren();
		}

		//// RVA: 0x116E4F0 Offset: 0x116E4F0 VA: 0x116E4F0
		//public void SetDivaImage(int diva_no, int cos_no, int color_no) { }

		//// RVA: 0x116E618 Offset: 0x116E618 VA: 0x116E618
		//public void SetMusicRate(HighScoreRatingRank.Type a_icon_type) { }

		//// RVA: 0x1172598 Offset: 0x1172598 VA: 0x1172598
		public void SetMusicRanking(int a_rank)
		{
			m_musicrate01_text.text = OEGIPPCADNA.GEEFFAEGHAH(a_rank, true);
		}

		//// RVA: 0x11725E4 Offset: 0x11725E4 VA: 0x11725E4
		//public void SetDegreeImage(int degree_no) { }

		//// RVA: 0x117273C Offset: 0x117273C VA: 0x117273C
		//public void SetSceneImage(int id, int rank, bool isKira) { }

		//// RVA: 0x11728B8 Offset: 0x11728B8 VA: 0x11728B8
		//private void SetAssistSceneImage(int id, int rank, bool isKira, int num) { }

		//// RVA: 0x1172A4C Offset: 0x1172A4C VA: 0x1172A4C
		//private void SetAssistSceneImage() { }

		//// RVA: 0x1170374 Offset: 0x1170374 VA: 0x1170374
		//private void SetChangePlayerNameTime(int mon, int day) { }

		//// RVA: 0x1172D10 Offset: 0x1172D10 VA: 0x1172D10
		private void OnChangePlayerName(string playerName)
		{
			TodoLogger.LogNotImplemented("OnChangePlayerName");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FE994 Offset: 0x6FE994 VA: 0x6FE994
		//// RVA: 0x1172DFC Offset: 0x1172DFC VA: 0x1172DFC
		//private IEnumerator OnChangePlayerNameCoroutine(string playerName) { }

		//// RVA: 0x11732FC Offset: 0x11732FC VA: 0x11732FC
		//private void ConfirmPlayerName(string playerName) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FEA0C Offset: 0x6FEA0C VA: 0x6FEA0C
		//// RVA: 0x11737A4 Offset: 0x11737A4 VA: 0x11737A4
		//private IEnumerator ChangePlayerNameCoroutine(string playerName) { }

		//// RVA: 0x117386C Offset: 0x117386C VA: 0x117386C
		//private bool IsChangePlayerName(string changedName) { }

		//// RVA: 0x1173958 Offset: 0x1173958 VA: 0x1173958
		//private bool IsChangeComment(string changedComment) { }

		//// RVA: 0x1173A44 Offset: 0x1173A44 VA: 0x1173A44
		//private void ChangePlayerName() { }

		//// RVA: 0x1172EA0 Offset: 0x1172EA0 VA: 0x1172EA0
		//private void FailurePlayerName() { }

		//// RVA: 0x1173E54 Offset: 0x1173E54 VA: 0x1173E54
		//private void ShowNotChangedPlayerNamePopup() { }

		//// RVA: 0x1173F18 Offset: 0x1173F18 VA: 0x1173F18
		//private void ShowNotChangedCommentPopup() { }

		//// RVA: 0x1173FDC Offset: 0x1173FDC VA: 0x1173FDC
		private void OnChangeComment(string comment)
		{
			TodoLogger.LogNotImplemented("OnChangeComment");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FEA84 Offset: 0x6FEA84 VA: 0x6FEA84
		//// RVA: 0x1174058 Offset: 0x1174058 VA: 0x1174058
		//private IEnumerator OnChangeCommentCoroutine(string comment) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FEAFC Offset: 0x6FEAFC VA: 0x6FEAFC
		//// RVA: 0x11740FC Offset: 0x11740FC VA: 0x11740FC
		//private IEnumerator OnChangeCommentCoroutine2(string inputComment) { }

		//// RVA: 0x11741A0 Offset: 0x11741A0 VA: 0x11741A0
		//private void ChangeComment() { }

		//// RVA: 0x11745B0 Offset: 0x11745B0 VA: 0x11745B0
		//private void OnClickPlayerIdCopy() { }

		//// RVA: 0x1174674 Offset: 0x1174674 VA: 0x1174674
		//private void OnClickMusicRateDetail() { }

		//// RVA: 0x1174BC8 Offset: 0x1174BC8 VA: 0x1174BC8
		//private void OnClickCenterSkill() { }

		//// RVA: 0x1174D6C Offset: 0x1174D6C VA: 0x1174D6C
		//private void OnClickCenterSkill2() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FEB74 Offset: 0x6FEB74 VA: 0x6FEB74
		//// RVA: 0x116D660 Offset: 0x116D660 VA: 0x116D660
		private IEnumerator LoadDegreeInfoWindow()
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x9CCEE4
			operation = AssetBundleManager.LoadLayoutAsync(m_degree_setting.BundleName, m_degree_setting.AssetName);
			yield return operation;
			if(!operation.IsError())
			{
				yield return Co.R(operation.InitializeLayoutCoroutine(MenuScene.Instance.m_font, (GameObject instance) =>
				{
					//0x117B2B4
					m_degree_setting.SetContent(instance);
				}));
				m_degree_setting.SetParent(transform);
				AssetBundleManager.UnloadAssetBundle(m_degree_setting.BundleName);
			}
		}

		//// RVA: 0x1174F10 Offset: 0x1174F10 VA: 0x1174F10
		//private void OnClickDegreeInfo() { }

		//// RVA: 0x117025C Offset: 0x117025C VA: 0x117025C
		//private IAPDFOPPGND GetDegreeData(int id) { }

		//// RVA: 0x11753B4 Offset: 0x11753B4 VA: 0x11753B4
		//private void SetDegreeNum(int num, bool active = True) { }

		//// RVA: 0x117555C Offset: 0x117555C VA: 0x117555C
		//private IAPDFOPPGND GetDegreeListIndex(int id) { }

		//// RVA: 0x116E818 Offset: 0x116E818 VA: 0x116E818
		private void SetMainSceneInfo(GCIJNCFDNON_SceneInfo sceneData)
		{
			TodoLogger.Log(0, "SetMainSceneInfo");
		}

		//// RVA: 0x116EF30 Offset: 0x116EF30 VA: 0x116EF30
		//private void SetCenterSkillInfo(FFHPBEPOMAK divaData, GCIJNCFDNON sceneData) { }

		//// RVA: 0x117008C Offset: 0x117008C VA: 0x117008C
		//private void SetDegreeInfo(IAPDFOPPGND emblem) { }

		//// RVA: 0x11704A8 Offset: 0x11704A8 VA: 0x11704A8
		//private void SetStatsInfo(JNMFKOHFAFB status) { }

		//// RVA: 0x1175690 Offset: 0x1175690 VA: 0x1175690
		private void OnClickSceneInfo()
		{
			if (m_scene_data != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				ShowSceneStatusPopup(m_scene_data, GameManager.Instance.ViewPlayerData, () =>
				{
					//0x117B2E8
					SetMainSceneInfo(m_scene_data);
				});
			}
		}

		//// RVA: 0x11758CC Offset: 0x11758CC VA: 0x11758CC
		//private void OnClickPageLeft() { }

		//// RVA: 0x1175938 Offset: 0x1175938 VA: 0x1175938
		//private void OnClickPageRight() { }

		//// RVA: 0x117214C Offset: 0x117214C VA: 0x117214C
		private void UpdateStatsPage(int newPage)
		{
			TodoLogger.Log(0, "UpdateStatsPage");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FEBEC Offset: 0x6FEBEC VA: 0x6FEBEC
		//// RVA: 0x11759A4 Offset: 0x11759A4 VA: 0x11759A4
		//private IEnumerator Coroutine_ChangeMcrosReportPage(int a_page) { }

		//// RVA: 0x11757E4 Offset: 0x11757E4 VA: 0x11757E4
		private void ShowSceneStatusPopup(GCIJNCFDNON_SceneInfo sceneData, DFKGGBMFFGB_PlayerInfo playerData, Action onClose)
		{
			MenuScene.Instance.ShowSceneStatusPopupWindow(sceneData, playerData, false, TransitionList.Type.UNDEFINED, onClose, m_is_friend, true, SceneStatusParam.PageSave.Player, true);
		}

		//// RVA: 0x1175674 Offset: 0x1175674 VA: 0x1175674
		//private static TextAnchor ToCenter(TextAnchor baseAnchor) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FEC64 Offset: 0x6FEC64 VA: 0x6FEC64
		//// RVA: 0x116D5D0 Offset: 0x116D5D0 VA: 0x116D5D0
		private IEnumerator Load_ScrollItemIcon()
		{
			AssetBundleLoadLayoutOperationBase layOp;

			//0x9CD2C0
			LayoutUGUIRuntime runtime = null;
			m_swap_scroll.RemoveScrollObject();
			m_swap_scroll.SetEnableScrollBar(true);
			layOp = AssetBundleManager.LoadLayoutAsync("ly/071.xab", "UI_ProfilScrollItemIcon");
			yield return layOp;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x117CF9C
				runtime = instance.GetComponent<LayoutUGUIRuntime>();
				ProfilScrollIcon p = instance.GetComponent<ProfilScrollIcon>();
				p.SetCallbackClickIconCos(CB_ClickIcon_Costume);
				p.SetCallbackClickIconVal(CB_ClickIcon_Valkyrie);
				p.SetCallbackClickIconEmblem(CB_ClickIcon_Emblem);
				m_swap_scroll.AddScrollObject(p);
			}));
			for(int i = 1; i < m_swap_scroll.ScrollObjectCount; i++)
			{
				LayoutUGUIRuntime r = Instantiate(runtime);
				r.IsLayoutAutoLoad = false;
				r.Layout = runtime.Layout.DeepClone();
				r.UvMan = runtime.UvMan;
				r.LoadLayout();
				ProfilScrollIcon p = r.GetComponent<ProfilScrollIcon>();
				p.SetCallbackClickIconCos(CB_ClickIcon_Costume);
				p.SetCallbackClickIconVal(CB_ClickIcon_Valkyrie);
				p.SetCallbackClickIconEmblem(CB_ClickIcon_Emblem);
				m_swap_scroll.AddScrollObject(p);
			}
			m_swap_scroll.Apply();
			m_swap_scroll.SetContentEscapeMode(false);
			yield return null;
			AssetBundleManager.UnloadAssetBundle("ly/071.xab", false);
			m_swap_scroll_loaded = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FECDC Offset: 0x6FECDC VA: 0x6FECDC
		//// RVA: 0x1175A6C Offset: 0x1175A6C VA: 0x1175A6C
		//private IEnumerator Coroutine_SetupCostumeScrollList() { }

		//// RVA: 0x1175B18 Offset: 0x1175B18 VA: 0x1175B18
		//private void OnUpdateCostumeScrollItem(int a_index, ProfilScrollIcon a_icon, ProfilMenuLayout.CostumeData a_costume_info) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FED54 Offset: 0x6FED54 VA: 0x6FED54
		//// RVA: 0x1175B7C Offset: 0x1175B7C VA: 0x1175B7C
		//private IEnumerator Coroutine_SetupVarkiryScrollList() { }

		//// RVA: 0x1175C04 Offset: 0x1175C04 VA: 0x1175C04
		//private void OnUpdateVarkiryScrollItem(int a_index, ProfilScrollIcon a_icon, PNGOLKLFFLH a_data) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FEDCC Offset: 0x6FEDCC VA: 0x6FEDCC
		//// RVA: 0x1175C38 Offset: 0x1175C38 VA: 0x1175C38
		//private IEnumerator Coroutine_SetupEmblemScrollList() { }

		//// RVA: 0x1175CE4 Offset: 0x1175CE4 VA: 0x1175CE4
		//private void OnUpdateEmblemScrollItem(int a_index, ProfilScrollIcon a_icon, IAPDFOPPGND a_emblem_info) { }

		//// RVA: 0x1175D18 Offset: 0x1175D18 VA: 0x1175D18
		private void CB_ClickIcon_Valkyrie(PNGOLKLFFLH a_data)
		{
			TodoLogger.LogNotImplemented("CB_ClickIcon_Valkyrie");
		}

		//// RVA: 0x1175F14 Offset: 0x1175F14 VA: 0x1175F14
		private void CB_ClickIcon_Costume(CKFGMNAIBNG a_data, int a_color)
		{
			TodoLogger.LogNotImplemented("CB_ClickIcon_Costume");
		}

		//// RVA: 0x1176014 Offset: 0x1176014 VA: 0x1176014
		private void CB_ClickIcon_Emblem(IAPDFOPPGND a_data)
		{
			TodoLogger.LogNotImplemented("CB_ClickIcon_Emblem");
		}

		//// RVA: 0x11764A8 Offset: 0x11764A8 VA: 0x11764A8
		public void SetFanCount(int _fanCount)
		{
			if (_fanCount >= 99999)
				_fanCount = 99999;
			m_fanCount_num.SetNumber(_fanCount, 0);
		}

		//// RVA: 0x11764F4 Offset: 0x11764F4 VA: 0x11764F4
		public void SetMainGunPower(int _power)
		{
			m_mainGunPower_text.text = _power < 1 ? "---" : (_power < 1000000 ? _power : 999999).ToString();
		}

		//// RVA: 0x11765C0 Offset: 0x11765C0 VA: 0x11765C0
		public void HiddenVisitButton(bool isHidden)
		{
			m_visit_btn.Hidden = isHidden;
		}

		//// RVA: 0x11765F4 Offset: 0x11765F4 VA: 0x11765F4
		//public void HiddenLobbyBrows(bool isHidden) { }

		//// RVA: 0x1176628 Offset: 0x1176628 VA: 0x1176628
		//public bool GetHiddenLobbyBrows() { }

		//// RVA: 0x1176654 Offset: 0x1176654 VA: 0x1176654
		//public void DecoButtonHidden(bool a_hidden) { }

		//// RVA: 0x117671C Offset: 0x117671C VA: 0x117671C
		public void SetButtonType(ButtonType a_type)
		{
			TodoLogger.Log(0, "SetButtonType");
		}

		//// RVA: 0x1176B94 Offset: 0x1176B94 VA: 0x1176B94
		public void OnClickFanRelease()
		{
			TodoLogger.LogNotImplemented("OnClickFanRelease");
		}

		//// RVA: 0x1176DFC Offset: 0x1176DFC VA: 0x1176DFC
		public void OnClickFanEntry()
		{
			TodoLogger.LogNotImplemented("OnClickFanEntry");
		}

		//// RVA: 0x117725C Offset: 0x117725C VA: 0x117725C
		public void OnClickVisit()
		{
			TodoLogger.LogNotImplemented("OnClickVisit");
		}

		//// RVA: 0x1177650 Offset: 0x1177650 VA: 0x1177650
		public void OnClickBlock()
		{
			TodoLogger.LogNotImplemented("OnClickBlock");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FEE44 Offset: 0x6FEE44 VA: 0x6FEE44
		//// RVA: 0x11776C4 Offset: 0x11776C4 VA: 0x11776C4
		//private IEnumerator Co_AddBlockList() { }

		//// RVA: 0x1177770 Offset: 0x1177770 VA: 0x1177770
		public void OnClickLobbyBrowsing()
		{
			TodoLogger.LogNotImplemented("OnClickLobbyBrowsing");
		}

		//// RVA: 0x11770B8 Offset: 0x11770B8 VA: 0x11770B8
		//private void PopupFanLimit() { }

		//// RVA: 0x11778DC Offset: 0x11778DC VA: 0x11778DC
		//private void UpdateFavoritePlayer(List<int> a_list_add, List<int> a_list_remove, Action a_func) { }

		//// RVA: 0x1177BD0 Offset: 0x1177BD0 VA: 0x1177BD0
		//private void SetAssistAttributeText() { }

		//// RVA: 0x1177E94 Offset: 0x1177E94 VA: 0x1177E94
		//private void SetAssistName(int page) { }

		//// RVA: 0x1177F10 Offset: 0x1177F10 VA: 0x1177F10
		//private void ChangeAssistName(string assistName) { }

		//// RVA: 0x1171110 Offset: 0x1171110 VA: 0x1171110
		//private void AssistSelectInit() { }

		//// RVA: 0x1171B00 Offset: 0x1171B00 VA: 0x1171B00
		//private void AssistSelectInit(EAJCBFGKKFA data) { }

		//// RVA: 0x1178DB8 Offset: 0x1178DB8 VA: 0x1178DB8
		//private void MyAssistInformation() { }

		//// RVA: 0x1179038 Offset: 0x1179038 VA: 0x1179038
		//private void FriendAssistInformation() { }

		//// RVA: 0x1177F9C Offset: 0x1177F9C VA: 0x1177F9C
		//private void SetAssistSceneInfo(int assistNum, GCIJNCFDNON sceneData) { }

		//// RVA: 0x117924C Offset: 0x117924C VA: 0x117924C
		//private void SetAssistCenterSkill(GCIJNCFDNON sceneData, int assistNum) { }

		//// RVA: 0x1178AA8 Offset: 0x1178AA8 VA: 0x1178AA8
		//private void UpdateAssistStatusPage(int newPage) { }

		//// RVA: 0x11798EC Offset: 0x11798EC VA: 0x11798EC
		private void OnClickAssistStatusPage()
		{
			TodoLogger.LogNotImplemented("OnClickAssistStatusPage");
		}

		//// RVA: 0x1178C7C Offset: 0x1178C7C VA: 0x1178C7C
		//private void UpdateAssistSelectPage(int newPage) { }

		//// RVA: 0x1179968 Offset: 0x1179968 VA: 0x1179968
		private void ChangeAssistSelectPage(int newPage)
		{
			TodoLogger.LogNotImplemented("ChangeAssistSelectPage");
		}

		//// RVA: 0x1179BB4 Offset: 0x1179BB4 VA: 0x1179BB4
		//private void OnClickAssistSelectPage(int newPage) { }

		//// RVA: 0x1179BD8 Offset: 0x1179BD8 VA: 0x1179BD8
		//private void OnFlickOrSwaipAssistSelectPage(int newPage) { }

		//// RVA: 0x1179BF4 Offset: 0x1179BF4 VA: 0x1179BF4
		private void OnChangeAssitName(int page)
		{
			TodoLogger.LogNotImplemented("OnChangeAssitName");
		}

		//// RVA: 0x117A120 Offset: 0x117A120 VA: 0x117A120
		private void OnStayAssistScene(int attribute)
		{
			TodoLogger.LogNotImplemented("OnStayAssistScene");
		}

		//// RVA: 0x117A3D8 Offset: 0x117A3D8 VA: 0x117A3D8
		//private void OnClickAssistScene(int type) { }

		//// RVA: 0x117A388 Offset: 0x117A388 VA: 0x117A388
		//private bool IsDoSwaip() { }

		//// RVA: 0x116D838 Offset: 0x116D838 VA: 0x116D838
		//private void UpdateSwaip() { }

		//// RVA: 0x117226C Offset: 0x117226C VA: 0x117226C
		private void SwaipReset()
		{
			TodoLogger.Log(0, "SwaipReset");
		}
		
		//[CompilerGeneratedAttribute] // RVA: 0x6FEFCC Offset: 0x6FEFCC VA: 0x6FEFCC
		//// RVA: 0x117B0DC Offset: 0x117B0DC VA: 0x117B0DC
		//private void <SetDivaImage>b__194_0(IiconTexture icon) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FEFDC Offset: 0x6FEFDC VA: 0x6FEFDC
		//// RVA: 0x117B1C8 Offset: 0x117B1C8 VA: 0x117B1C8
		//private void <SetDegreeImage>b__197_0(IiconTexture icon) { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x6FEFFC Offset: 0x6FEFFC VA: 0x6FEFFC
		//// RVA: 0x117B2E8 Offset: 0x117B2E8 VA: 0x117B2E8
		//private void <OnClickSceneInfo>b__229_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FF00C Offset: 0x6FF00C VA: 0x6FF00C
		//// RVA: 0x117B2F0 Offset: 0x117B2F0 VA: 0x117B2F0
		//private void <Coroutine_SetupCostumeScrollList>b__237_0(int index, SwapScrollListContent content) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FF01C Offset: 0x6FF01C VA: 0x6FF01C
		//// RVA: 0x117B424 Offset: 0x117B424 VA: 0x117B424
		//private void <Coroutine_SetupVarkiryScrollList>b__239_0(int index, SwapScrollListContent content) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FF02C Offset: 0x6FF02C VA: 0x6FF02C
		//// RVA: 0x117B55C Offset: 0x117B55C VA: 0x117B55C
		//private void <Coroutine_SetupEmblemScrollList>b__241_0(int index, SwapScrollListContent content) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FF03C Offset: 0x6FF03C VA: 0x6FF03C
		//// RVA: 0x117B694 Offset: 0x117B694 VA: 0x117B694
		//private void <OnClickFanRelease>b__253_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FF04C Offset: 0x6FF04C VA: 0x6FF04C
		//// RVA: 0x117B780 Offset: 0x117B780 VA: 0x117B780
		//private void <OnClickFanEntry>b__254_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FF05C Offset: 0x6FF05C VA: 0x6FF05C
		//// RVA: 0x117B86C Offset: 0x117B86C VA: 0x117B86C
		//private void <OnClickVisit>b__255_0(PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FF06C Offset: 0x6FF06C VA: 0x6FF06C
		//// RVA: 0x117BB54 Offset: 0x117BB54 VA: 0x117BB54
		//private void <OnChangeAssitName>b__276_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }
	}
}
