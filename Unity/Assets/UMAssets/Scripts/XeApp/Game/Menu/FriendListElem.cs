using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System;

namespace XeApp.Game.Menu
{
	public class FriendListElem : GeneralListElemBase
	{
		public enum ButtonStyle
		{
			FriendList = 0,
			AcceptList = 1,
			RequestList = 2,
			PlayerSearch = 3,
			BlockList = 4,
			PlayerSearchDecoVisit = 5,
		}

		private enum PosiButtonType
		{
			Select = 0,
			Accept = 1,
			Request = 2,
			Receive = 3,
			Use = 4,
			_Num = 5,
		}

		private enum NegaButtonType
		{
			Reject = 0,
			Release = 1,
			Cancel = 2,
			_Num = 3,
		}

		public const int InvokeId_Posi = 0;
		public const int InvokeId_Nega = 1;
		public const int InvokeId_Other = 2;
		public const int InvokeId_Profile = 3;
		private static readonly string[] s_posiButtonTypes = new string[5]
		{
			"select", "accept", "request", "receive", "use"
		}; // 0x0
		private static readonly string[] s_negaButtonTypes = new string[3]
		{
			"reject", "release", "cancel"
		}; // 0x4
		private static readonly string[] s_starNums = new string[8]
		{
			"none", "n1", "n2", "n3", "n4", "n5", "n6", "n6"
		}; // 0x8
		[SerializeField]
		private RawImageEx m_divaIconImage; // 0x18
		[SerializeField]
		private RawImageEx m_sceneIconImage; // 0x1C
		[SerializeField]
		private RawImageEx m_skillRankImage; // 0x20
		[SerializeField]
		private RawImageEx m_musicRatioIconImage; // 0x24
		[SerializeField]
		private Text m_nameText; // 0x28
		[SerializeField]
		private Text m_levelText; // 0x2C
		[SerializeField]
		private Text m_loginDateText; // 0x30
		[SerializeField]
		private Text m_totalText; // 0x34
		[SerializeField]
		private Text m_soulText; // 0x38
		[SerializeField]
		private Text m_voiceText; // 0x3C
		[SerializeField]
		private Text m_charmText; // 0x40
		[SerializeField]
		private Text m_lifeText; // 0x44
		[SerializeField]
		private Text m_supportText; // 0x48
		[SerializeField]
		private Text m_foldText; // 0x4C
		[SerializeField]
		private Text m_luckText; // 0x50
		[SerializeField]
		private Text m_skillText; // 0x54
		[SerializeField]
		private Text m_skillLevelText; // 0x58
		[SerializeField]
		private Text m_commentText; // 0x5C
		[SerializeField]
		private Text m_musicRatioText; // 0x60
		[SerializeField]
		private Text m_musicRateRankText; // 0x64
		[SerializeField]
		private ScrollListButton[] m_posiButton; // 0x68
		[SerializeField]
		private ScrollListButton[] m_negaButton; // 0x6C
		[SerializeField]
		private ScrollListButton m_otherButton; // 0x70
		[SerializeField]
		private ButtonBase m_profileButton; // 0x74
		private LayoutSymbolData m_symbolButtonStyle; // 0x78
		private LayoutSymbolData m_symbolPosiButtonType; // 0x7C
		private LayoutSymbolData m_symbolSmallPosiButtonType; // 0x80
		private LayoutSymbolData m_symbolNegaButtonType; // 0x84
		private LayoutSymbolData m_symbolSmallNegaButtonType; // 0x88
		private LayoutSymbolData m_symbolStatus; // 0x8C
		private LayoutSymbolData m_symbolParamTable; // 0x90
		private LayoutSymbolData m_symbolStarNum; // 0x94
		private LayoutSymbolData m_symbolPlayerRank; // 0x98
		private bool m_statusIsComment; // 0x9C
		private bool m_isKira; // 0x9D
		private string m_loginDateString; // 0xA0
		private string m_requestDateString; // 0xA4
		private bool m_useRequestDate; // 0xA8

		private Func<IiconTexture> divaIconDelegate { get; set; } // 0xAC
		private Func<IiconTexture> sceneIconDelegate { get; set; } // 0xB0

		// RVA: 0xBA86C4 Offset: 0xBA86C4 VA: 0xBA86C4
		private void Update()
		{
			if(divaIconDelegate != null)
			{
				SetDivaIcon(divaIconDelegate());
				divaIconDelegate = null;
			}
			if(sceneIconDelegate != null)
			{
				SetSceneIcon(sceneIconDelegate(), m_isKira);
				sceneIconDelegate = null;
			}
		}

		//// RVA: 0xBA89B0 Offset: 0xBA89B0 VA: 0xBA89B0
		public void SwapStatus(bool immediate = false)
		{
			ChangeStatus(!m_statusIsComment, immediate);
		}

		//// RVA: 0xBA5870 Offset: 0xBA5870 VA: 0xBA5870
		public void ChangeStatus(bool toComment, bool immediate = false)
		{
			m_symbolStatus.StartAnim(immediate ? (toComment ? "wait_1" : "wait_2") : (toComment ? "goto_1" : "goto_2"));
			m_statusIsComment = toComment;
		}

		//// RVA: 0xBA89C8 Offset: 0xBA89C8 VA: 0xBA89C8
		//public bool IsPlayingStatus() { }

		//// RVA: 0xBA89F4 Offset: 0xBA89F4 VA: 0xBA89F4
		public GameObject GetDivaIconObject()
		{
			return m_divaIconImage.gameObject;
		}

		//// RVA: 0xBA8A20 Offset: 0xBA8A20 VA: 0xBA8A20
		public GameObject GetSceneIconObject()
		{
			return m_sceneIconImage.gameObject;
		}

		//// RVA: 0xBA26A0 Offset: 0xBA26A0 VA: 0xBA26A0
		public void SetButtonStyle(ButtonStyle style)
		{
			switch(style)
			{
				case ButtonStyle.FriendList:
					m_symbolButtonStyle.StartAnim("n");
					SetNegaButtonType(NegaButtonType.Release);
					break;
				case ButtonStyle.AcceptList:
					m_symbolButtonStyle.StartAnim("np");
					SetNegaButtonType(NegaButtonType.Reject);
					SetPosiButtonType(PosiButtonType.Accept);
					break;
				case ButtonStyle.RequestList:
					m_symbolButtonStyle.StartAnim("n");
					SetNegaButtonType(NegaButtonType.Cancel);
					break;
				case ButtonStyle.PlayerSearch:
					m_symbolButtonStyle.StartAnim("p");
					SetPosiButtonType(PosiButtonType.Request);
					break;
				case ButtonStyle.BlockList:
					m_symbolButtonStyle.StartAnim("n");
					SetNegaButtonType(NegaButtonType.Release);
					break;
				case ButtonStyle.PlayerSearchDecoVisit:
					m_symbolButtonStyle.StartAnim("v");
					break;
			}
		}

		//// RVA: 0xBA8C6C Offset: 0xBA8C6C VA: 0xBA8C6C
		//public void SetDivaIconDelegate(Func<IiconTexture> iconDelegate) { }

		//// RVA: 0xBA8C74 Offset: 0xBA8C74 VA: 0xBA8C74
		//public void SetSceneIconDelegate(Func<IiconTexture> iconDelegate) { }

		//// RVA: 0xBA878C Offset: 0xBA878C VA: 0xBA878C
		public void SetDivaIcon(IiconTexture iconTex)
		{
			iconTex.Set(m_divaIconImage);
		}

		//// RVA: 0xBA886C Offset: 0xBA886C VA: 0xBA886C
		public void SetSceneIcon(IiconTexture iconTex, bool isKira)
		{
			iconTex.Set(m_sceneIconImage);
			SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImage, iconTex as IconTexture, isKira);
		}

		//// RVA: 0xBA8C7C Offset: 0xBA8C7C VA: 0xBA8C7C
		//public void SetSceneStarNum(int starNum) { }

		//// RVA: 0xBA592C Offset: 0xBA592C VA: 0xBA592C
		//public void SetParamTable(SortItem sortBy) { }

		//// RVA: 0xBA8DB0 Offset: 0xBA8DB0 VA: 0xBA8DB0
		//public void SetName(string name) { }

		//// RVA: 0xBA8DEC Offset: 0xBA8DEC VA: 0xBA8DEC
		//public void SetLevel(string level) { }

		//// RVA: 0xBA8E28 Offset: 0xBA8E28 VA: 0xBA8E28
		//public void SetLoginDate(string date) { }

		//// RVA: 0xBA8E30 Offset: 0xBA8E30 VA: 0xBA8E30
		//public void SetRequestDate(string date) { }

		//// RVA: 0xBA8E38 Offset: 0xBA8E38 VA: 0xBA8E38
		//public void SetTotal(string total) { }

		//// RVA: 0xBA8E74 Offset: 0xBA8E74 VA: 0xBA8E74
		//public void SetSoul(string soul) { }

		//// RVA: 0xBA8EB0 Offset: 0xBA8EB0 VA: 0xBA8EB0
		//public void SetVoice(string voice) { }

		//// RVA: 0xBA8EEC Offset: 0xBA8EEC VA: 0xBA8EEC
		//public void SetCharm(string charm) { }

		//// RVA: 0xBA8F28 Offset: 0xBA8F28 VA: 0xBA8F28
		//public void SetLife(string life) { }

		//// RVA: 0xBA8F64 Offset: 0xBA8F64 VA: 0xBA8F64
		//public void SetSupport(string support) { }

		//// RVA: 0xBA8FA0 Offset: 0xBA8FA0 VA: 0xBA8FA0
		//public void SetFold(string fold) { }

		//// RVA: 0xBA8FDC Offset: 0xBA8FDC VA: 0xBA8FDC
		//public void SetLuck(string luck) { }

		//// RVA: 0xBA9018 Offset: 0xBA9018 VA: 0xBA9018
		//public void SetComment(string comment) { }

		//// RVA: 0xBA9054 Offset: 0xBA9054 VA: 0xBA9054
		//public void SetMusicRatio(string ratio) { }

		//// RVA: 0xBA9090 Offset: 0xBA9090 VA: 0xBA9090
		//public void SetSkill(string skill) { }

		//// RVA: 0xBA9184 Offset: 0xBA9184 VA: 0xBA9184
		//public void SetSkillLevel(int level) { }

		//// RVA: 0xBA9288 Offset: 0xBA9288 VA: 0xBA9288
		//public void SetSkillRank(SkillRank.Type rank) { }

		//// RVA: 0xBA9358 Offset: 0xBA9358 VA: 0xBA9358
		//public void SetMusicRank(HighScoreRatingRank.Type rank) { }

		//// RVA: 0xBA94C0 Offset: 0xBA94C0 VA: 0xBA94C0
		//public void SetMusicRateRank(IBIGBMDANNM a_friend_data) { }

		//// RVA: 0xBA959C Offset: 0xBA959C VA: 0xBA959C
		//public void SetKira(bool isKira) { }

		//// RVA: 0xBA8B5C Offset: 0xBA8B5C VA: 0xBA8B5C
		private void SetPosiButtonType(PosiButtonType type)
		{
			m_symbolPosiButtonType.StartAnim(s_posiButtonTypes[(int)type]);
			m_symbolSmallPosiButtonType.StartAnim(s_posiButtonTypes[(int)type]);
		}

		//// RVA: 0xBA8A4C Offset: 0xBA8A4C VA: 0xBA8A4C
		private void SetNegaButtonType(NegaButtonType type)
		{
			m_symbolNegaButtonType.StartAnim(s_negaButtonTypes[(int)type]);
			m_symbolSmallNegaButtonType.StartAnim(s_negaButtonTypes[(int)type]);
		}

		//// RVA: 0xBA95A4 Offset: 0xBA95A4 VA: 0xBA95A4
		private void OnClickPosiCallback()
		{
			InvokeSelectItem(0);
		}

		//// RVA: 0xBA95B0 Offset: 0xBA95B0 VA: 0xBA95B0
		private void OnClickNegaCallback()
		{
			InvokeSelectItem(1);
		}

		//// RVA: 0xBA95BC Offset: 0xBA95BC VA: 0xBA95BC
		private void OnClickOtherCallback()
		{
			InvokeSelectItem(2);
		}

		//// RVA: 0xBA95C8 Offset: 0xBA95C8 VA: 0xBA95C8
		private void OnClickProfileCallback()
		{
			InvokeSelectItem(3);
		}

		//// RVA: 0xBA8D68 Offset: 0xBA8D68 VA: 0xBA8D68
		//private void ApplyDateString() { }

		// RVA: 0xBA95D4 Offset: 0xBA95D4 VA: 0xBA95D4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			for(int i = 0; i < m_posiButton.Length; i++)
			{
				m_posiButton[i].ClearOnClickCallback();
				m_posiButton[i].AddOnClickCallback(OnClickPosiCallback);
			}
			for(int i = 0; i < m_negaButton.Length; i++)
			{
				m_negaButton[i].ClearOnClickCallback();
				m_negaButton[i].AddOnClickCallback(OnClickNegaCallback);
			}
			m_otherButton.ClearOnClickCallback();
			m_otherButton.AddOnClickCallback(OnClickOtherCallback);
			m_profileButton.ClearOnClickCallback();
			m_profileButton.AddOnClickCallback(OnClickProfileCallback);
			m_symbolButtonStyle = CreateSymbol("btn_style", layout);
			m_symbolPosiButtonType = CreateSymbol("btn_posi_type", layout);
			m_symbolSmallPosiButtonType = CreateSymbol("btn_posi_s_type", layout);
			m_symbolNegaButtonType = CreateSymbol("btn_nega_type", layout);
			m_symbolSmallNegaButtonType = CreateSymbol("btn_nega_s_type", layout);
			m_symbolStatus = CreateSymbol("status", layout);
			m_symbolParamTable = CreateSymbol("param_tbl", layout);
			m_symbolStarNum = CreateSymbol("star_num", layout);
			m_symbolPlayerRank = CreateSymbol("rank", layout);
			Loaded();
			return true;
		}
	}
}
