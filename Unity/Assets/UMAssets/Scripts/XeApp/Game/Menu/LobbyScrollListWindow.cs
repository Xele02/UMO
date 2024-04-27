using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections;
using XeApp.Core;

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
		private EnWindowType m_window_type; // 0xBC
		private bool m_isIconChange; // 0xC0

		public bool IsLoadedTexture { get; protected set; } // 0xB8
		public EnWindowType WindowType { get { return m_window_type; } set { m_window_type = value; } } //0xD1A10C 0xD1A114
		//public int RaidSelectType { get; set; } 0xD0BB10 0xD1A11C
		public bool IsIconChange { get { return m_isIconChange; } set { m_isIconChange = value; } } //0xD1A124 0xD1A12C

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
		public IEnumerator Co_LoadAssetsLayoutListItemR(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xD1F80C
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_lobby_win_l_01_layout_root");
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xD1F274
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				instance.transform.SetParent(transform, false);
			}));
			m_fxScrollView.AddLayoutCache(2, baseRuntime, 5);
			Destroy(baseRuntime.gameObject);
			baseRuntime = null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E9A34 Offset: 0x6E9A34 VA: 0x6E9A34
		//// RVA: 0xD0E4C4 Offset: 0xD0E4C4 VA: 0xD0E4C4
		public IEnumerator Co_LoadAssetsLayoutListItemL(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xD1F48C
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_lobby_win_r_01_layout_root");
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xD1F378
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				instance.transform.SetParent(transform, false);
			}));
			m_fxScrollView.AddLayoutCache(1, baseRuntime, 5);
			Destroy(baseRuntime.gameObject);
			baseRuntime = null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E9AAC Offset: 0x6E9AAC VA: 0x6E9AAC
		//// RVA: 0xD1301C Offset: 0xD1301C VA: 0xD1301C
		//public IEnumerator SettingCharaVoice() { }

		//// RVA: 0xD0C1CC Offset: 0xD0C1CC VA: 0xD0C1CC
		//public void EffectAnimLoop(bool _IsAnimStart) { }

		//// RVA: 0xD1A95C Offset: 0xD1A95C VA: 0xD1A95C
		public void HideGotoTopButton(bool _isListBottom)
		{
			if (m_gotoListTopButton != null)
				m_gotoListTopButton.Hidden = _isListBottom;
		}

		//// RVA: 0xD1AA18 Offset: 0xD1AA18 VA: 0xD1AA18
		//public void Co_AddStampItemPost(CommentType _type) { }

		//// RVA: 0xD1AAB0 Offset: 0xD1AAB0 VA: 0xD1AAB0
		//public void ResetList() { }

		//// RVA: 0xD1AB28 Offset: 0xD1AB28 VA: 0xD1AB28
		public void AddScrollItem()
		{
			float f = 0;
			int f2 = 30;
			m_scrollAllArea = 0;
			for(int i = 0; i < m_list.Count; i++)
			{
				//LAB_00d1b464
				ChatMessgeListItemBase l = m_list[i] as ChatMessgeListItemBase;
				f += f2;
				switch(l.ChatType)
				{
					case CommentType.Chat:
						l.Top = new Vector2(6, -f);
						l.Height = 150;
						f += 150;
						f2 = 30;
						m_scrollAllArea += l.Height;
						break;
					case CommentType.BattleLog:
						l.Top = new Vector2(6, -f);
						l.Height = 150;
						f += 120;
						f2 = 30;
						m_scrollAllArea += l.Height;
						break;
					case CommentType.Stamp:
						l.Top = new Vector2(6, -f);
						l.Height = 250;
						f += 200;
						f2 = 50;
						m_scrollAllArea += l.Height;
						break;
					case CommentType.MoveThum:
						l.Top = new Vector2(6, -f);
						l.Height = 310;
						f += 250;
						f2 = 60;
						m_scrollAllArea += l.Height;
						break;
				}
			}
		}

		//// RVA: 0xD1B514 Offset: 0xD1B514 VA: 0xD1B514
		public void AddBbsListItem(ANPBHCNJIDI.NNPGLGHDBKN _cm, ANPBHCNJIDI.NOJONDLAMOC m_bbsType, int _playerId, int _index, bool _isMember)
		{
			if(m_bbsType <= ANPBHCNJIDI.NOJONDLAMOC.HJNNKCMLGFL_0 || m_bbsType > ANPBHCNJIDI.NOJONDLAMOC.JPOGBMJKPIJ_5_FullCombo)
			{
				Debug.LogError("StringLiteral_18442");
				return;
			}
			switch(m_bbsType)
			{
				case ANPBHCNJIDI.NOJONDLAMOC.CCAPCGPIIPF_1_Chat:
				{
					Debug.Log("StringLiteral_18437");
					ANPBHCNJIDI.AIFBLOAGFOP data = _cm as ANPBHCNJIDI.AIFBLOAGFOP;
					MessgeListItem it = new MessgeListItem();
					it.ChatType = CommentType.Chat;
					it.IsMember = _isMember;
					it.IsPickUp = false;
					it.DiveId = data.AHHJLDLAPAN_DivaId;
					it.DivaCosId = data.NNOHKLNKGAD_CostumeId;
					it.DivaCosColorId = data.DJHMGDKKKFO_ColorId;
					it.UserName = data.OPFGFINHFCE_PlayerName;
					it.PlayerId = data.MLPEHNBNOGD_WritterId;
					it.Index = _index;
					it.EnmblemId = data.MDPKLNFFDBO_EmblemId;
					it.EnmblemCount = data.KDHCKDHIHIP_EmblemCount;
					it.utarate_rank = data.AILEOFKIELL_UtaRateRank;
					it.utarate = data.KIFEGLJLEDC_TotalUtaRate;
					it.Messge = data.EBBJPBGHJOL_Content;
					it.Time = data.EKEGHNPNCEH_UpdateAt;
					it.ResourceType = _playerId == _cm.MLPEHNBNOGD_WritterId ? 1 : 2;
					m_list.Add(it);
				}
				break;
				case ANPBHCNJIDI.NOJONDLAMOC.DDPLFFAOAEB_2_Stamp:
				{
					Debug.Log("StringLiteral_18438");
					ANPBHCNJIDI.BNEIDPGIAFM data = _cm as ANPBHCNJIDI.BNEIDPGIAFM;
					StampListItem it = new StampListItem();
					it.DivaStampId = data.LIBPMIHHEJD_StampDiva;
					it.MiniId = data.HEKIEDEBAEO_StampId;
					it.CommentId = data.EKAMPLIAENM_SerifId;
					it.IsPickUp = false;
					it.ChatType = CommentType.Stamp;
					it.DiveId = data.AHHJLDLAPAN_DivaId;
					it.DivaCosId = data.NNOHKLNKGAD_CostumeId;
					it.DivaCosColorId = data.DJHMGDKKKFO_ColorId;
					it.UserName = data.OPFGFINHFCE_PlayerName;
					it.Time = data.EKEGHNPNCEH_UpdateAt;
					it.PlayerId = data.MLPEHNBNOGD_WritterId;
					it.Index = _index;
					it.EnmblemId = data.MDPKLNFFDBO_EmblemId;
					it.EnmblemCount = data.KDHCKDHIHIP_EmblemCount;
					it.utarate_rank = data.AILEOFKIELL_UtaRateRank;
					it.IsMember = _isMember;
					it.ResourceType = _playerId == _cm.MLPEHNBNOGD_WritterId ? 1 : 2;
					it.utarate = data.KIFEGLJLEDC_TotalUtaRate;
					m_list.Add(it);
				}
				break;
				case ANPBHCNJIDI.NOJONDLAMOC.CGEPNIOPFHF_3_DefeatBoss:
				{
					Debug.Log("StringLiteral_18439");
					ANPBHCNJIDI.KNGOGLLMKDL data = _cm as ANPBHCNJIDI.KNGOGLLMKDL;
					DefeatBossListItem it = new DefeatBossListItem();
					it.Messge = data.EBBJPBGHJOL_Content;
					it.Damage = data.HALIDDHLNEG_Damage;
					it.BossType = data.MFMPCHIJINJ_BossType;
					it.ChatType = CommentType.BattleLog;
					it.DiveId = data.AHHJLDLAPAN_DivaId;
					it.DivaCosId = data.NNOHKLNKGAD_CostumeId;
					it.DivaCosColorId = data.DJHMGDKKKFO_ColorId;
					it.UserName = data.OPFGFINHFCE_PlayerName;
					it.Time = data.EKEGHNPNCEH_UpdateAt;
					it.PlayerId = data.MLPEHNBNOGD_WritterId;
					it.Index = _index;
					it.EnmblemId = data.MDPKLNFFDBO_EmblemId;
					it.EnmblemCount = data.KDHCKDHIHIP_EmblemCount;
					it.utarate_rank = data.AILEOFKIELL_UtaRateRank;
					it.IsMember = _isMember;
					it.ResourceType = _playerId == _cm.MLPEHNBNOGD_WritterId ? 1 : 2;
					it.IsPickUp = m_raidSelect == 0;
					it.utarate = data.KIFEGLJLEDC_TotalUtaRate;
					m_list.Add(it);
				}
				break;
				case ANPBHCNJIDI.NOJONDLAMOC.JDGLJOFPHLK_4_MaccrossCannon:
				{
					Debug.Log("StringLiteral_18440");
					ANPBHCNJIDI.NBHIMCACDHM data = _cm as ANPBHCNJIDI.NBHIMCACDHM;
					MacrossCannonListItem it = new MacrossCannonListItem();
					it.Messge = data.EBBJPBGHJOL_Content;
					it.Damage = data.HALIDDHLNEG_Damage;
					it.Defeat = data.IGNJCGMLBDA_Defeat;
					it.Time = data.EKEGHNPNCEH_UpdateAt;
					it.ChatType = CommentType.MoveThum;
					it.DiveId = data.AHHJLDLAPAN_DivaId;
					it.DivaCosId = data.NNOHKLNKGAD_CostumeId;
					it.DivaCosColorId = data.DJHMGDKKKFO_ColorId;
					it.UserName = data.OPFGFINHFCE_PlayerName;
					it.PlayerId = data.MLPEHNBNOGD_WritterId;
					it.Index = _index;
					it.EnmblemId = data.MDPKLNFFDBO_EmblemId;
					it.EnmblemCount = data.KDHCKDHIHIP_EmblemCount;
					it.IsMember = _isMember;
					it.BossName = data.GJAOLNLFEBD_BossName;
					it.BossSeries = (SeriesAttr.Type)data.PCPODOMOFDH_BossSeriesAttr;
					it.ResourceType = _playerId == _cm.MLPEHNBNOGD_WritterId ? 1 : 2;
					it.IsPickUp = m_raidSelect == 0;
					it.BossImageNum = data.JNBDLNBKDCO_BossImage;
					it.BossRank = data.EJGDHAENIDC_BossRank;
					it.LogId = data.CNOHJPEHHCH;
					it.utarate_rank = data.AILEOFKIELL_UtaRateRank;
					it.WavId = data.KKPAHLMJKIH;
					it.utarate = data.KIFEGLJLEDC_TotalUtaRate;
					m_list.Add(it);
				}
				break;
				case ANPBHCNJIDI.NOJONDLAMOC.JPOGBMJKPIJ_5_FullCombo:
				{
					Debug.Log("StringLiteral_18440");
					ANPBHCNJIDI.JLHGKKIEALB data = _cm as ANPBHCNJIDI.JLHGKKIEALB;
					FullComboListItem it = new FullComboListItem();
					it.Messge = data.EBBJPBGHJOL_Content;
					it.FreeId = data.ADHMMMEOJMK_FreeSongId;
					it.ChatType = CommentType.BattleLog;
					it.DiveId = data.AHHJLDLAPAN_DivaId;
					it.DivaCosId = data.NNOHKLNKGAD_CostumeId;
					it.DivaCosColorId = data.DJHMGDKKKFO_ColorId;
					it.UserName = data.OPFGFINHFCE_PlayerName;
					it.Time = data.EKEGHNPNCEH_UpdateAt;
					it.PlayerId = data.MLPEHNBNOGD_WritterId;
					it.Index = _index;
					it.EnmblemId = data.MDPKLNFFDBO_EmblemId;
					it.EnmblemCount = data.KDHCKDHIHIP_EmblemCount;
					it.utarate_rank = data.AILEOFKIELL_UtaRateRank;
					it.IsMember = _isMember;
					it.ResourceType = _playerId == _cm.MLPEHNBNOGD_WritterId ? 1 : 2;
					it.IsPickUp = m_raidSelect == 0;
					it.utarate = data.KIFEGLJLEDC_TotalUtaRate;
					m_list.Add(it);
				}
				break;
			}
		}

		//// RVA: 0xD1C818 Offset: 0xD1C818 VA: 0xD1C818
		public void UpdateDivaIconThum(bool _change)
		{
			m_isIconChange = _change;
			m_switchIcon.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(_change ? "lb_btn_ch_01" : "lb_btn_ch_02"));
		}

		//// RVA: 0xD1C96C Offset: 0xD1C96C VA: 0xD1C96C
		private void OnUpdateScrollItem(IFlexibleListItem obj)
		{
			LobbyLayoutItemR l = obj.Layout.GetComponent<LobbyLayoutItemR>();
			if(l != null)
			{
				l.DispMusicRateRank(m_window_type != EnWindowType.Lobby);
			}
			if(obj != null)
			{
				if(obj is MessgeListItem)
				{
					MessgeListItem m = obj as MessgeListItem;
					if (l != null)
					{
						l.SetPostItemAnimation(m.ChatType);
						l.SetDivaIcon(m.DivaCosId, m.DivaCosColorId, m.EnmblemId, m.EnmblemCount, m_isIconChange);
						l.SetChatPostInfo(m.Index, m.UserName, ANPBHCNJIDI.NOJONDLAMOC.CCAPCGPIIPF_1_Chat, m.Messge, m.Time);
						l.SetPickUpIconAnimation(m.IsPickUp);
						l.SetPostButtonDisable(IsChatButtonGrayOut);
						l.SetEnablePostButton(m_raidSelect == 1 && m.IsMember);
						l.SetMember(m.IsMember);
						l.EnableEmblemCount();
						l.OnClickChatButton = ReprintButtonAction;
						l.SetPlayerId(m.PlayerId);
						l.SetMusicRateRank(m.utarate_rank, m.utarate);
						l.ResetStateThumButton();
						l.OnClickPlayerIcon = OnClickPlayerIcon;
					}
				}
				else if(obj is StampListItem)
				{
					StampListItem m = obj as StampListItem;
					if(l != null)
					{
						l.SetPostItemAnimation(m.ChatType);
						l.SetDivaIcon(m.DivaCosId, m.DivaCosColorId, m.EnmblemId, m.EnmblemCount, m_isIconChange);
						l.SetStampPostInfo(m.Index, m.UserName, ANPBHCNJIDI.NOJONDLAMOC.DDPLFFAOAEB_2_Stamp, m.DivaStampId, m.MiniId, m.CommentId, m.Time);
						l.SetPickUpIconAnimation(m.IsPickUp);
						l.SetPostButtonDisable(IsChatButtonGrayOut);
						l.SetEnablePostButton(m_raidSelect == 1 && m.IsMember);
						l.SetMember(m.IsMember);
						l.EnableEmblemCount();
						l.OnClickChatButton = ReprintButtonAction;
						l.SetPlayerId(m.PlayerId);
						l.SetMusicRateRank(m.utarate_rank, m.utarate);
						l.ResetStateThumButton();
						l.OnClickPlayerIcon = OnClickPlayerIcon;
					}
				}
				else if(obj is DefeatBossListItem)
				{
					DefeatBossListItem m = obj as DefeatBossListItem;
					if(l != null)
					{
						l.SetPostItemAnimation(m.ChatType);
						l.SetDivaIcon(m.DivaCosId, m.DivaCosColorId, m.EnmblemId, m.EnmblemCount, m_isIconChange);
						l.SetDefeatBossInfo(m.Index, m.UserName, ANPBHCNJIDI.NOJONDLAMOC.CGEPNIOPFHF_3_DefeatBoss, m.Time, m.Messge);
						l.SetPickUpIconAnimation(m.IsPickUp);
						l.SetPostButtonDisable(IsChatButtonGrayOut);
						l.SetEnablePostButton(m_raidSelect == 1 && m.IsMember);
						l.SetMember(m.IsMember);
						l.EnableEmblemCount();
						l.OnClickChatButton = ReprintButtonAction;
						l.SetPlayerId(m.PlayerId);
						l.SetMusicRateRank(m.utarate_rank, m.utarate);
						l.ResetStateThumButton();
						l.OnClickPlayerIcon = OnClickPlayerIcon;
					}
				}
				else if(obj is MacrossCannonListItem)
				{
					MacrossCannonListItem m = obj as MacrossCannonListItem;
					if(l != null)
					{
						l.SetPostItemAnimation(m.ChatType);
						l.SetDivaIcon(m.DivaCosId, m.DivaCosColorId, m.EnmblemId, m.EnmblemCount, m_isIconChange);
						l.SetMacrossCannonPostInfo(m.Index, m.UserName, ANPBHCNJIDI.NOJONDLAMOC.JDGLJOFPHLK_4_MaccrossCannon, m.Time, m.Messge);
						l.SetPickUpIconAnimation(m.IsPickUp);
						l.SetPostButtonDisable(IsChatButtonGrayOut);
						l.SetEnablePostButton(m_raidSelect == 1 && m.IsMember);
						l.SetMember(m.IsMember);
						l.EnableEmblemCount();
						l.SetMovieThumUV(m.BossSeries);
						l.SetMovieBossInfo(m.BossName, m.Damage, m.BossRank, m.BossImageNum, m.BossSeries, m.LogId, m.WavId);
						l.OnClickChatButton = ReprintButtonAction;
						l.SetPlayerId(m.PlayerId);
						l.SetMusicRateRank(m.utarate_rank, m.utarate);
						l.ResetStateThumButton();
						l.OnClickPlayerIcon = OnClickPlayerIcon;
						l.OnClickMovieIcon = OnClickMovieIcon;
					}
				}
				else if(obj is FullComboListItem)
				{
					FullComboListItem m = obj as FullComboListItem;
					if(l != null)
					{
						l.SetPostItemAnimation(m.ChatType);
						l.SetDivaIcon(m.DivaCosId, m.DivaCosColorId, m.EnmblemId, m.EnmblemCount, m_isIconChange);
						l.SetFullComboPostInfo(m.Index, m.UserName, ANPBHCNJIDI.NOJONDLAMOC.JPOGBMJKPIJ_5_FullCombo, m.Time, m.Messge);
						l.SetPickUpIconAnimation(m.IsPickUp);
						l.SetPostButtonDisable(IsChatButtonGrayOut);
						l.SetEnablePostButton(m_raidSelect == 1 && m.IsMember);
						l.SetMember(m.IsMember);
						l.EnableEmblemCount();
						l.OnClickChatButton = ReprintButtonAction;
						l.SetPlayerId(m.PlayerId);
						l.SetMusicRateRank(m.utarate_rank, m.utarate);
						l.ResetStateThumButton();
						l.OnClickPlayerIcon = OnClickPlayerIcon;
					}
				}
			}
			l.UpdateAbsLayout();
		}

		//// RVA: 0xD0E280 Offset: 0xD0E280 VA: 0xD0E280
		public void Co_SettingList()
		{
			m_fxScrollView = new FlexibleItemScrollView();
			m_fxScrollView.Initialize(m_ScrollRect);
			m_fxScrollView.UpdateItemListener += OnUpdateScrollItem;
			m_fxScrollView.SetupListItem(m_list);
			m_fxScrollView.SetlistTop(0);
			m_fxScrollView.SetZeroVelocity();
			m_fxScrollView.VisibleRangeUpdate();
		}

		//// RVA: 0xD1DB78 Offset: 0xD1DB78 VA: 0xD1DB78
		//public void EnableUpdateButton(bool _enable) { }

		//// RVA: 0xD13240 Offset: 0xD13240 VA: 0xD13240
		public void SetHiddengotoListTopButton(bool _isListBottom)
		{
			if (m_gotoListTopButton != null)
				m_gotoListTopButton.Hidden = _isListBottom;
		}

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
		public void ResetItem()
		{
			if (m_list.Count < 1)
				return;
			if (m_fxScrollView != null)
			{
				m_fxScrollView.AllFree();
				m_fxScrollView.SetZeroVelocity();
				m_fxScrollView.VisibleRangeUpdate();
			}
			m_list.Clear();
		}

		//// RVA: 0xD1DD58 Offset: 0xD1DD58 VA: 0xD1DD58
		public void UpdateScroll()
		{
			m_fxScrollView.SetupListItem(m_list);
			m_fxScrollView.SetlistBottom(m_list.Count - 1);
			m_fxScrollView.SetZeroVelocity();
			m_fxScrollView.VisibleRangeUpdate();
		}

		//// RVA: 0xD1DE50 Offset: 0xD1DE50 VA: 0xD1DE50
		public void NextCommentAddScrollLsit(int index)
		{
			m_fxScrollView.SetupListItem(m_list);
			m_fxScrollView.SetlistTop(index);
		}

		//// RVA: 0xD1DEA0 Offset: 0xD1DEA0 VA: 0xD1DEA0
		public void UpdateDisplayOnly()
		{
			if (m_fxScrollView == null)
				return;
			m_fxScrollView.SetupListItem(m_list);
			m_fxScrollView.SetlistUpdateOnly();
			float f = m_fxScrollView.CurrentVerticalScrollPositon();
			if(f <= 0)
			{
				m_fxScrollView.SetlistBottom(m_list.Count - 1);
			}
			else if(f >= 1)
			{
				m_fxScrollView.SetlistTop(0);
			}
		}

		//// RVA: 0xD1E004 Offset: 0xD1E004 VA: 0xD1E004
		public void GotoListTop()
		{
			if (m_fxScrollView == null)
				return;
			m_fxScrollView.SetlistTop(m_list.Count - 1);
		}

		//// RVA: 0xD1E098 Offset: 0xD1E098 VA: 0xD1E098
		//public void ScrollContentPostButtonGrayOut(bool isGrayOut) { }

		//// RVA: 0xD1E0C4 Offset: 0xD1E0C4 VA: 0xD1E0C4
		public void StopScrollMove()
		{
			m_fxScrollView.StopScrollMove();
		}

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
		public bool IsUpdatePossible()
		{
			bool res = true;
			if(m_list.Count > 9)
			{
				float f = 0;
				for(int i = m_list.Count - 1; i <= m_list.Count - 6; i++)
				{
					f += m_list[i].Height;
				}
				res = m_scrollAllArea - f <= m_fxScrollView.CurrentContentAnchorBottomPos().y;
			}
			SetHiddengotoListTopButton(res);
			return res;
		}

		//// RVA: 0xD1E360 Offset: 0xD1E360 VA: 0xD1E360
		public bool IsNextUpdate()
		{
			if(m_list.Count > 4)
			{
				return 120.0f / m_scrollAllArea + 1 <= m_fxScrollView.CurrentVerticalScrollPositon();// m_list[0].Height;
			}
			return false;
		}

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
		public void HideMiniChara()
		{
			m_decoIconImage01.enabled = false;
			m_decoIconImage02.enabled = false;
			m_GuideTextAnim.StartChildrenAnimGoStop("st_out");
		}

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
