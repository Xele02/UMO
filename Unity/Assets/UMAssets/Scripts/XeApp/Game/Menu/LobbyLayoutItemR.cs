using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System;

namespace XeApp.Game.Menu
{
	public class LobbyLayoutItemR : FlexibleListItemLayout
	{
		public class CannonMovieInfo
		{
			public string userName; // 0x8
			public string bossName; // 0xC
			public SeriesAttr.Type series; // 0x10
			public int damage; // 0x14
			public int bossRank; // 0x18
			public int bossImageNum; // 0x1C
			public int logId; // 0x20
			public int wavId; // 0x24
		}

		private const int UPDATE_TIMING = 1;
		private const int MAX_NEW_LINE_NUM = 2;
		[SerializeField]
		private RawImageEx m_divaIconImage; // 0x18
		[SerializeField]
		private RawImageEx m_divaStampIconImage; // 0x1C
		[SerializeField]
		private RawImageEx m_stampBallonImage; // 0x20
		[SerializeField]
		private Text[] m_textMessge; // 0x24
		[SerializeField]
		private Text[] m_textUserName; // 0x28
		[SerializeField]
		private Text[] m_textTime; // 0x2C
		[SerializeField]
		private ActionButton m_chatButton; // 0x30
		[SerializeField]
		private ActionButton m_movieThumButton; // 0x34
		[SerializeField]
		private ActionButton m_playerIconButton; // 0x38
		[SerializeField]
		private NumberBase m_emblemNum; // 0x3C
		[SerializeField]
		private RawImageEx m_musicrate_image; // 0x40
		[SerializeField]
		private Text m_musicrate_rank_text; // 0x44
		private AbsoluteLayout m_postChangeAnim; // 0x48
		private AbsoluteLayout m_videoThumAnim; // 0x4C
		private AbsoluteLayout m_pickUpAnim; // 0x50
		private AbsoluteLayout m_textSizeChange; // 0x54
		private AbsoluteLayout m_textTypeChange; // 0x58
		private AbsoluteLayout m_numberEnable; // 0x5C
		private AbsoluteLayout m_moveThumAnim; // 0x60
		private int m_subId; // 0x64
		private int m_id; // 0x68
		private int m_index; // 0x6C
		private bool m_isIconchage; // 0x70
		private int m_emblemId; // 0x74
		private bool m_isDisplayDiva; // 0x78
		private int m_playerId; // 0x7C
		private bool IsPickUp; // 0x80
		private bool IsMember; // 0x81
		private bool IsShowEmblem; // 0x82
		private string userName; // 0x84
		private string bossName; // 0x88
		private int bossRank; // 0x8C
		private int bossImageNum; // 0x90
		private int commentImageId; // 0x94
		private int StampMotionId; // 0x98
		private int iconImageId; // 0x9C
		private int stampBallonImageId; // 0xA0
		public Action<int> OnClickChatButton; // 0xA4
		public Action<int> OnClickPlayerIcon; // 0xA8
		public Action<CannonMovieInfo> OnClickMovieIcon; // 0xAC
		private bool m_endInitLayout; // 0xB0
		private MusicRatioTextureCache.MusicRatioTexture m_musicRatioTexture; // 0xB4
		private HighScoreRatingRank.Type m_musicRatioRankType; // 0xB8
		private int m_musicRate; // 0xBC
		private int m_musicRank; // 0xC0
		private bool m_disp_musicraterank = true; // 0xC4

		public bool IsLoadedTexture { get; protected set; } // 0x71
		//public int Id { get; } 0x12931A0

		// RVA: 0x12931A8 Offset: 0x12931A8 VA: 0x12931A8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_postChangeAnim = layout.FindViewById("swtbl_log_r") as AbsoluteLayout;
			if(m_postChangeAnim == null)
			{
				m_postChangeAnim = layout.FindViewById("swtbl_log_l") as AbsoluteLayout;
			}
			m_videoThumAnim = layout.FindViewById("swtbl_lb_mv_thumb") as AbsoluteLayout;
			m_pickUpAnim = layout.FindViewById("swtbl_diva_icon") as AbsoluteLayout;
			m_textSizeChange = layout.FindViewByExId("swtbl_log_l_lb_bllnl_p_02") as AbsoluteLayout;
			if(m_textSizeChange == null)
			{
				m_textSizeChange = layout.FindViewByExId("swtbl_log_r_lb_bllnr_p_02") as AbsoluteLayout;
			}
			m_textTypeChange = layout.FindViewByExId("swtex_dc_blln_01_swtbl_fuki_txt") as AbsoluteLayout;
			m_numberEnable = layout.FindViewByExId("swtbl_diva_icon_swtbl_pro_num_01") as AbsoluteLayout;
			m_moveThumAnim = layout.FindViewByExId("lb_bllnl_p_04_swtbl_lb_mv_thumb") as AbsoluteLayout;
			if(m_moveThumAnim == null)
				m_moveThumAnim = layout.FindViewByExId("lb_bllnr_p_04_swtbl_lb_mv_thumb") as AbsoluteLayout;
			m_chatButton.ClearOnClickCallback();
			m_chatButton.AddOnClickCallback(() =>
			{
				//0x12961E8
				if(m_chatButton != null)
				{
					if (OnClickChatButton != null)
						OnClickChatButton(m_index);
				}
			});
			m_playerIconButton.ClearOnClickCallback();
			m_playerIconButton.AddOnClickCallback(() =>
			{
				//0x12962E8
				if(!IsPickUp && m_playerId > 0)
				{
					if (OnClickPlayerIcon != null)
						OnClickPlayerIcon(m_playerId);
				}
			});
			m_endInitLayout = true;
			Loaded();
			return true;
		}

		//// RVA: 0x12937C4 Offset: 0x12937C4 VA: 0x12937C4
		//public void UpdateAbsLayout() { }

		//// RVA: 0x1293C34 Offset: 0x1293C34 VA: 0x1293C34
		//public void SetPostItemAnimation(CommentType _type) { }

		//// RVA: 0x1293D48 Offset: 0x1293D48 VA: 0x1293D48
		//public void SetVideoThumAnimation(int _type) { }

		//// RVA: 0x1293E5C Offset: 0x1293E5C VA: 0x1293E5C
		//public void SetPickUpIconAnimation(bool _isPickUp) { }

		//// RVA: 0x1293F10 Offset: 0x1293F10 VA: 0x1293F10
		//public void EnableEmblemCount() { }

		//// RVA: 0x1293FA8 Offset: 0x1293FA8 VA: 0x1293FA8
		//public void SetMember(bool _isMember) { }

		//// RVA: 0x1293FB0 Offset: 0x1293FB0 VA: 0x1293FB0
		//public void SetEnablePostButton(bool _enable) { }

		//// RVA: 0x1294098 Offset: 0x1294098 VA: 0x1294098
		//public void SetPostButtonDisable(bool _isDisable) { }

		//// RVA: 0x1294154 Offset: 0x1294154 VA: 0x1294154
		//public void ResetStateThumButton() { }

		//// RVA: 0x1294188 Offset: 0x1294188 VA: 0x1294188
		//public void SetChatPostInfo(int index, string name, ANPBHCNJIDI.NOJONDLAMOC _type, string mes, long updateAt) { }

		//// RVA: 0x1294688 Offset: 0x1294688 VA: 0x1294688
		//public void SetStampPostInfo(int index, string name, ANPBHCNJIDI.NOJONDLAMOC _type, int _divaId, int _miniId, int _commentId, long _time) { }

		//// RVA: 0x1294928 Offset: 0x1294928 VA: 0x1294928
		//private void LoadIconTexture(int sudId = 0) { }

		//// RVA: 0x1294BBC Offset: 0x1294BBC VA: 0x1294BBC
		//private void LoadtBallonTexture(int sudId = 0) { }

		//// RVA: 0x1294E68 Offset: 0x1294E68 VA: 0x1294E68
		//public void SetDefeatBossInfo(int index, string name, ANPBHCNJIDI.NOJONDLAMOC _type, long _time, string _messge) { }

		//// RVA: 0x1295018 Offset: 0x1295018 VA: 0x1295018
		//public void SetMacrossCannonPostInfo(int index, string name, ANPBHCNJIDI.NOJONDLAMOC _type, long _time, string _messge) { }

		//// RVA: 0x12951D4 Offset: 0x12951D4 VA: 0x12951D4
		//public void SetFullComboPostInfo(int index, string name, ANPBHCNJIDI.NOJONDLAMOC _type, long _time, string _messge) { }

		//// RVA: 0x1295384 Offset: 0x1295384 VA: 0x1295384
		//public void SetDivaIcon(int _divaCosId, int _divaCosClolrId, int emblemId, int emblemCount, bool IsDisplayDiva) { }

		//// RVA: 0x1294344 Offset: 0x1294344 VA: 0x1294344
		//private void SetMessgeText(ANPBHCNJIDI.NOJONDLAMOC _type, string _messge) { }

		//// RVA: 0x12956EC Offset: 0x12956EC VA: 0x12956EC
		//private int targetCount(string _text, char target) { }

		//// RVA: 0x1294338 Offset: 0x1294338 VA: 0x1294338
		//private void SetPalyerName(string _name) { }

		//// RVA: 0x129454C Offset: 0x129454C VA: 0x129454C
		//private void SetUpdateAtTime(long updateAt) { }

		//// RVA: 0x12958E8 Offset: 0x12958E8 VA: 0x12958E8
		//public void SetPlayerId(int _playerId) { }

		//// RVA: 0x12958F0 Offset: 0x12958F0 VA: 0x12958F0
		//public void SetMusicRateRank(int _musicRateRank, int _musicRate) { }

		//// RVA: 0x1295AB0 Offset: 0x1295AB0 VA: 0x1295AB0
		//public void SetMovieThumUV(SeriesAttr.Type series) { }

		//// RVA: 0x1295B5C Offset: 0x1295B5C VA: 0x1295B5C
		//public void SetMovieBossInfo(string name, int damage, int rank, int imageNum, SeriesAttr.Type series, int logId, int wavId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E8144 Offset: 0x6E8144 VA: 0x6E8144
		//// RVA: 0x1295E30 Offset: 0x1295E30 VA: 0x1295E30
		//private IEnumerator Co_MovieClickEndAnim() { }

		//// RVA: 0x1295EDC Offset: 0x1295EDC VA: 0x1295EDC
		//public void SetDiveIconChange(bool _isChange) { }

		//// RVA: 0x12957D8 Offset: 0x12957D8 VA: 0x12957D8
		//private void SetUserNameAndMusicRate(string a_name, int a_ranking) { }

		//// RVA: 0x12961D0 Offset: 0x12961D0 VA: 0x12961D0
		//public void DispMusicRateRank(bool a_disp) { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x6E81DC Offset: 0x6E81DC VA: 0x6E81DC
		//// RVA: 0x1296370 Offset: 0x1296370 VA: 0x1296370
		//private void <SetDiveIconChange>b__82_0(IiconTexture icon) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E81EC Offset: 0x6E81EC VA: 0x6E81EC
		//// RVA: 0x1296498 Offset: 0x1296498 VA: 0x1296498
		//private void <SetDiveIconChange>b__82_1(IiconTexture texture) { }
	}
}
