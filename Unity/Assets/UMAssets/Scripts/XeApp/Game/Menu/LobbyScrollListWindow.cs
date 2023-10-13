using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections;

namespace XeApp.Game.Menu
{
	public enum CommentType
	{
		Chat = 0,
		BattleLog = 1,
		Stamp = 2,
		MoveThum = 3,
	}

	public class LobbyScrollListWindow : LayoutUGUIScriptBase
	{
		public enum ScrollItemType
		{
			MyComment = 1,
			OthersComment = 2,
		}

		public enum EnWindowType
		{
			None = 0,
			DecoChat = 1,
			Lobby = 2,
		}

		public class MessgeListItem : ChatMessgeListItemBase
		{
			public string Messge { get; set; } // 0x54
			public long Time { get; set; } // 0x58
		}

		public class StampListItem : ChatMessgeListItemBase
		{
			public int DivaStampId { get; set; } // 0x54
			public int MiniId { get; set; } // 0x58
			public int CommentId { get; set; } // 0x5C
			public long Time { get; set; } // 0x60
		}

		public class DefeatBossListItem : ChatMessgeListItemBase
		{
			public string Messge { get; set; } // 0x54
			public int Damage { get; set; } // 0x58
			public int BossType { get; set; } // 0x5C
			public long Time { get; set; } // 0x60
		}

		public class MacrossCannonListItem : ChatMessgeListItemBase
		{
			public int IconId { get; set; } // 0x54
			public int Damage { get; set; } // 0x58
			public long Time { get; set; } // 0x60
			public string Messge { get; set; } // 0x68
			public bool Defeat { get; set; } // 0x6C
			public SeriesAttr.Type BossSeries { get; set; } // 0x70
			public string BossName { get; set; } // 0x74
			public int BossRank { get; set; } // 0x78
			public int BossImageNum { get; set; } // 0x7C
			public int LogId { get; set; } // 0x80
			public int WavId { get; set; } // 0x84
		}

		public class FullComboListItem : ChatMessgeListItemBase
		{
			public long Time { get; set; } // 0x58
			public string Messge { get; set; } // 0x60
			public bool Defeat { get; set; } // 0x64
			public int FreeId { get; set; } // 0x68
		}

		public class ChatMessgeListItemBase : IFlexibleListItem
		{
			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public CommentType ChatType { get; set; } // 0x1C
			public int DiveId { get; set; } // 0x20
			public int DivaCosId { get; set; } // 0x24
			public int DivaCosColorId { get; set; } // 0x28
			public string UserName { get; set; } // 0x2C
			public bool IsPickUp { get; set; } // 0x30
			public int Index { get; set; } // 0x34
			public int EnmblemId { get; set; }  // 0x38
			public int EnmblemCount { get; set; } // 0x3C
			public bool IsIconChange { get; set; } // 0x40
			public int PlayerId { get; set; } // 0x44
			public bool IsMember { get; set; } // 0x48
			public int utarate_rank { get; set; } // 0x4C
			public int utarate { get; set; } // 0x50
		}

		private const int MAX_DISPLAY_COMMENT_NUM = 5;
		private readonly float MANUAL_UPDATA_WAIT_TIME = 3; // 0x14
		private const int FIRST_COMMENT_COUNT = 10;
		private AbsoluteLayout m_rootLayout; // 0x18
		[SerializeField]
		private RawImageEx m_decoIconImage01; // 0x1C
		[SerializeField]
		private RawImageEx m_decoIconImage02; // 0x20
		[SerializeField]
		private RawImageEx m_switchIcon; // 0x24
		[SerializeField]
		private ActionButton m_iconChangeButton; // 0x28
		[SerializeField]
		private ActionButton m_bbsUpdateButton; // 0x2C
		[SerializeField]
		private Transform m_tranCharaRoot; // 0x30
		[SerializeField]
		private ActionButton m_gotoListTopButton; // 0x34
		[SerializeField]
		private LayoutUGUIScrollSupport m_scrollSupport; // 0x38
		[SerializeField]
		private ButtonBase m_guideCharaBtn; // 0x3C
		private Text m_decoMessge; // 0x40
		private Coroutine guideTextAnim; // 0x44
		private SimpleVoicePlayer m_voicePlayer; // 0x48
		private AbsoluteLayout m_divacharaAnim; // 0x4C
		private AbsoluteLayout m_GuideTextAnim; // 0x50
		private bool m_isGuideTextAnim; // 0x54
		private int m_id; // 0x58
		private ScrollRect m_ScrollRect; // 0x5C
		private Transform m_ScrollContent; // 0x60
		private FlexibleItemScrollView m_fxScrollView; // 0x64
		private List<IFlexibleListItem> m_list = new List<IFlexibleListItem>(); // 0x68
		private TexUVList m_uvMan; // 0x6C
		private float m_scrollAllArea; // 0x70
		private int m_raidSelect; // 0x74
		private int m_lobbySelect; // 0x78
		private CommentType m_ChatType; // 0x7C
		private ANPBHCNJIDI.NOJONDLAMOC m_BbsChatType; // 0x80
		private AbsoluteLayout m_eff_anim; // 0x84
		private int m_commentCount; // 0x88
		private bool m_isBbsAutoUpdate = true; // 0x8C
		private int miniCharaId01; // 0x90
		private int miniCharamotionId01; // 0x94
		private int miniCharaId02; // 0x98
		private int miniCharamotionId02; // 0x9C
		public Action OnClickIconChangeButton; // 0xA0
		public Action OnClickBbsUpdateButton; // 0xA4
		public Action<int> ReprintButtonAction; // 0xA8
		public Action<int> OnClickPlayerIcon; // 0xAC
		public Action<LobbyLayoutItemR.CannonMovieInfo> OnClickMovieIcon; // 0xB0
		public Action OnClickGotoListTop; // 0xB4
		private bool IsChatButtonGrayOut; // 0xB9
		private LobbyScrollListWindow.EnWindowType m_window_type; // 0xBC
		private bool m_isIconChange; // 0xC0

		public bool IsLoadedTexture { get; protected set; } // 0xB8
		//public EnWindowType WindowType { get; set; } 0xD1A10C 0xD1A114
		//public int RaidSelectType { get; set; } 0xD0BB10 0xD1A11C
		//public bool IsIconChange { get; set; } 0xD1A124 0xD1A12C

		//// RVA: 0xD130A8 Offset: 0xD130A8 VA: 0xD130A8
		//public ButtonBase GetGuidCharaBtn() { }

		// RVA: 0xD1A134 Offset: 0xD1A134 VA: 0xD1A134 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_iconChangeButton.AddOnClickCallback(() =>
			{
				//0xD1EC94
				if (m_iconChangeButton != null)
					OnClickIconChangeButton();
			});
			m_bbsUpdateButton.AddOnClickCallback(() =>
			{
				//0xD1ED48
				if (m_bbsUpdateButton != null)
				{
					OnClickBbsUpdateButton();
					this.StartCoroutineWatched(Co_ManualUpdateWaitTime());
				}
			});
			m_gotoListTopButton.AddOnClickCallback(() =>
			{
				//0xD1EE14
				if (OnClickGotoListTop != null)
					OnClickGotoListTop();
			});
			m_rootLayout = layout.FindViewByExId("root_sel_lobby_scroll_01_sw_lb_scroll_anim_01") as AbsoluteLayout;
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_decoMessge = txts.Where((Text _) =>
			{
				//0xD1EEA4
				return _.name == "txt_01 (TextView)";
			}).First();
			m_divacharaAnim = layout.FindViewByExId("sw_lb_scroll_anim_01_swtbl_chara_01") as AbsoluteLayout;
			m_GuideTextAnim = layout.FindViewByExId("swtbl_chara_01_sw_lb_blln_02_01") as AbsoluteLayout;
			m_eff_anim = layout.FindViewByExId("sw_lb_scroll_anim_01_sw_lb_bg_eff_anim") as AbsoluteLayout;
			m_ScrollRect = GetComponentInChildren<ScrollRect>(true);
			m_ScrollContent = m_ScrollRect.transform.Find("Content");
			m_ScrollRect.horizontal = false;
			m_ScrollRect.vertical = true;
			m_ScrollRect.horizontalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
			m_ScrollRect.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
			m_ScrollRect.gameObject.GetComponentInChildren<VerticalLayoutGroup>(true).enabled = false;
			m_ScrollRect.gameObject.GetComponentInChildren<ContentSizeFitter>(true).enabled = false;
			m_ScrollRect.gameObject.GetComponentInChildren<LayoutElement>(true).enabled = false;
			m_uvMan = uvMan.GetTexUVList("sel_lobby_01_pack");
			m_isIconChange = true;
			m_switchIcon.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData("lb_btn_ch_01"));
			Loaded();
			return true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E99BC Offset: 0x6E99BC VA: 0x6E99BC
		//// RVA: 0xD0E404 Offset: 0xD0E404 VA: 0xD0E404
		//public IEnumerator Co_LoadAssetsLayoutListItemR(string bundleName, Font font) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E9A34 Offset: 0x6E9A34 VA: 0x6E9A34
		//// RVA: 0xD0E4C4 Offset: 0xD0E4C4 VA: 0xD0E4C4
		//public IEnumerator Co_LoadAssetsLayoutListItemL(string bundleName, Font font) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E9AAC Offset: 0x6E9AAC VA: 0x6E9AAC
		//// RVA: 0xD1301C Offset: 0xD1301C VA: 0xD1301C
		//public IEnumerator SettingCharaVoice() { }

		//// RVA: 0xD0C1CC Offset: 0xD0C1CC VA: 0xD0C1CC
		//public void EffectAnimLoop(bool _IsAnimStart) { }

		//// RVA: 0xD1A95C Offset: 0xD1A95C VA: 0xD1A95C
		//public void HideGotoTopButton(bool _isListBottom) { }

		//// RVA: 0xD1AA18 Offset: 0xD1AA18 VA: 0xD1AA18
		//public void Co_AddStampItemPost(CommentType _type) { }

		//// RVA: 0xD1AAB0 Offset: 0xD1AAB0 VA: 0xD1AAB0
		//public void ResetList() { }

		//// RVA: 0xD1AB28 Offset: 0xD1AB28 VA: 0xD1AB28
		//public void AddScrollItem() { }

		//// RVA: 0xD1B514 Offset: 0xD1B514 VA: 0xD1B514
		//public void AddBbsListItem(ANPBHCNJIDI.NNPGLGHDBKN _cm, ANPBHCNJIDI.NOJONDLAMOC m_bbsType, int _playerId, int _index, bool _isMember) { }

		//// RVA: 0xD1C818 Offset: 0xD1C818 VA: 0xD1C818
		//public void UpdateDivaIconThum(bool _change) { }

		//// RVA: 0xD1C96C Offset: 0xD1C96C VA: 0xD1C96C
		//private void OnUpdateScrollItem(IFlexibleListItem obj) { }

		//// RVA: 0xD0E280 Offset: 0xD0E280 VA: 0xD0E280
		//public void Co_SettingList() { }

		//// RVA: 0xD1DB78 Offset: 0xD1DB78 VA: 0xD1DB78
		//public void EnableUpdateButton(bool _enable) { }

		//// RVA: 0xD13240 Offset: 0xD13240 VA: 0xD13240
		//public void SetHiddengotoListTopButton(bool _isListBottom) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E9B24 Offset: 0x6E9B24 VA: 0x6E9B24
		//// RVA: 0xD1DBAC Offset: 0xD1DBAC VA: 0xD1DBAC
		private IEnumerator Co_ManualUpdateWaitTime()
		{
			//0xD1FB8C
			m_bbsUpdateButton.Disable = true;
			yield return new WaitForSecondsRealtime(MANUAL_UPDATA_WAIT_TIME);
			m_bbsUpdateButton.Disable = false;
		}

		//// RVA: 0xD1DC58 Offset: 0xD1DC58 VA: 0xD1DC58
		//public void ResetItem() { }

		//// RVA: 0xD1DD58 Offset: 0xD1DD58 VA: 0xD1DD58
		//public void UpdateScroll() { }

		//// RVA: 0xD1DE50 Offset: 0xD1DE50 VA: 0xD1DE50
		//public void NextCommentAddScrollLsit(int index) { }

		//// RVA: 0xD1DEA0 Offset: 0xD1DEA0 VA: 0xD1DEA0
		//public void UpdateDisplayOnly() { }

		//// RVA: 0xD1E004 Offset: 0xD1E004 VA: 0xD1E004
		//public void GotoListTop() { }

		//// RVA: 0xD1E098 Offset: 0xD1E098 VA: 0xD1E098
		//public void ScrollContentPostButtonGrayOut(bool isGrayOut) { }

		//// RVA: 0xD1E0C4 Offset: 0xD1E0C4 VA: 0xD1E0C4
		//public void StopScrollMove() { }

		//// RVA: 0xD0A4F4 Offset: 0xD0A4F4 VA: 0xD0A4F4
		public void LockScroll()
		{
			m_fxScrollView.LockScroll();
		}

		//// RVA: 0xD0A144 Offset: 0xD0A144 VA: 0xD0A144
		public void UnLockScroll()
		{
			m_fxScrollView.UnLockScroll();
		}

		//// RVA: 0xD1E0F0 Offset: 0xD1E0F0 VA: 0xD1E0F0
		//public bool IsUpdatePossible() { }

		//// RVA: 0xD1E360 Offset: 0xD1E360 VA: 0xD1E360
		//public bool IsNextUpdate() { }

		//// RVA: 0xD1122C Offset: 0xD1122C VA: 0xD1122C
		//public void Hide() { }

		//// RVA: 0xD0C274 Offset: 0xD0C274 VA: 0xD0C274
		//public void Show() { }

		//// RVA: 0xD1E4F8 Offset: 0xD1E4F8 VA: 0xD1E4F8
		//public bool IsPlayingChild() { }

		//// RVA: 0xD12F18 Offset: 0xD12F18 VA: 0xD12F18
		//public void GuideCharaInitialize(NKOBMDPHNGP _cont) { }

		//// RVA: 0xD1E524 Offset: 0xD1E524 VA: 0xD1E524
		//private void SetGuideCharaData(int _id, int _pic, string _messge) { }

		//// RVA: 0xD1E70C Offset: 0xD1E70C VA: 0xD1E70C
		//private void IsViewCharaSingle(bool _isSingle) { }

		//// RVA: 0xD1E7A0 Offset: 0xD1E7A0 VA: 0xD1E7A0
		//public void LoadIconTexture(int id, int emotion, bool isLeft = True) { }

		//// RVA: 0xD1E648 Offset: 0xD1E648 VA: 0xD1E648
		//public void HideMiniChara() { }

		//// RVA: 0xD09DBC Offset: 0xD09DBC VA: 0xD09DBC
		//public void OnClickGuideChara(NKOBMDPHNGP.FIPGKDJHKCH phase) { }

		//// RVA: 0xD100D8 Offset: 0xD100D8 VA: 0xD100D8
		//public void NaviCharaTextAnimStart() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E9B9C Offset: 0x6E9B9C VA: 0x6E9B9C
		//// RVA: 0xD1EB48 Offset: 0xD1EB48 VA: 0xD1EB48
		//private IEnumerator Co_NaviCharaTextAnimStart() { }

		//// RVA: 0xD1011C Offset: 0xD1011C VA: 0xD1011C
		//public void NaviCharaVoicePlay(NKOBMDPHNGP.FIPGKDJHKCH phase) { }
	}
}
