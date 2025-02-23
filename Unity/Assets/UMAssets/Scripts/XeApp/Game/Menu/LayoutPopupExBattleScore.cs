using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupExBattleScore : LayoutUGUIScriptBase
	{
		public Action onClickButton; // 0x14
		private EMGOCNMMPHC m_view; // 0x18
		private Transform m_parent; // 0x1C
		private AbsoluteLayout m_layoutRoot; // 0x20
		private AbsoluteLayout m_layoutWinLose; // 0x24
		private AbsoluteLayout m_layoutNewRecord; // 0x28
		private AbsoluteLayout m_layoutNewRecordIcon; // 0x2C
		private RawImageEx m_imageJacket; // 0x30
		private NumberBase m_numScore; // 0x34
		private NumberBase m_numWinBonus; // 0x38
		private NumberBase m_numExBattleScore; // 0x3C
		private NumberBase m_numExBattleHiScore; // 0x40
		private Text m_textClassRank; // 0x44
		private Text m_textWinResult; // 0x48
		private Text m_textLoseResult; // 0x4C
		private ActionButton m_button; // 0x50
		private bool m_isShow; // 0x54

		public bool IsShow { get { return m_isShow; } } //0x1724340

		// RVA: 0x1723D5C Offset: 0x1723D5C VA: 0x1723D5C
		private void Start()
		{
			return;
		}

		// RVA: 0x1723D60 Offset: 0x1723D60 VA: 0x1723D60
		private void Update()
		{
			return;
		}

		// // RVA: 0x1723D64 Offset: 0x1723D64 VA: 0x1723D64
		public void Setup(EMGOCNMMPHC view)
		{
			m_view = view;
			m_parent = transform.parent;
			m_imageJacket.enabled = false;
			MenuScene.Instance.MusicJacketTextureCache.Load(m_view.JNCPEGJGHOG_JackedId, (IiconTexture texture) =>
			{
				//0x1725644
				m_imageJacket.enabled = true;
				texture.Set(m_imageJacket);
			});
			m_numScore.SetNumber(m_view.KNIFCANOHOC_Sc, 0);
			m_numExBattleScore.SetNumber(m_view.KDNCMJBDCLE_ExBattleScore, 0);
			m_numExBattleHiScore.SetNumber(m_view.LDIODNEADGG_Hs, 0);
			if(m_view.FFHMPNGJCLK_IsHighScore)
			{
				m_layoutNewRecord.StartChildrenAnimGoStop("01");
				m_layoutNewRecordIcon.StartChildrenAnimGoStop("01");
			}
			else
			{
				m_layoutNewRecord.StartChildrenAnimGoStop("02");
				m_layoutNewRecordIcon.StartChildrenAnimGoStop("02");
			}

            MessageBank bk = MessageManager.Instance.GetBank("menu");
            m_textClassRank.text = string.Format(bk.GetMessageByLabel("music_event_battle_class"), m_view.BGJDHCEOIDB_ClassRank);
			m_numWinBonus.SetNumber(m_view.IOOBNLAHLEJ_WinBonus, 0);
			if(m_view.DPCFADCFMOA_Wl)
			{
				m_textWinResult.text = bk.GetMessageByLabel("event_reward_result_win");
				m_layoutWinLose.StartChildrenAnimGoStop("01");
			}
			else
			{
				m_textLoseResult.text = bk.GetMessageByLabel("event_reward_result_lose");
				m_layoutWinLose.StartChildrenAnimGoStop("02");
			}
		}

		// // RVA: 0x1724348 Offset: 0x1724348 VA: 0x1724348
		public void TryEnter(bool isSeChange/* = False*/)
		{
			if(m_isShow)
				return;
			Enter(isSeChange);
		}

		// // RVA: 0x17245CC Offset: 0x17245CC VA: 0x17245CC
		// public void TryLeave() { }

		// // RVA: 0x1724358 Offset: 0x1724358 VA: 0x1724358
		public void Enter(bool isSeChange/* = False*/)
		{
			transform.SetParent(GameManager.Instance.PopupCanvas.transform.GetChild(0), false);
			transform.SetAsLastSibling();
			SoundManager.Instance.sePlayerBoot.Play(isSeChange ? (int)mcrs.cs_se_boot.SE_WND_004 : (int)mcrs.cs_se_boot.SE_WND_000);
			m_isShow = true;
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			GameManager.Instance.AddPushBackButtonHandler(OnClickOkButton);
		}

		// // RVA: 0x17245DC Offset: 0x17245DC VA: 0x17245DC
		public void Leave()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_001);
			m_isShow = false;
			this.StartCoroutineWatched(Co_Leave());
			GameManager.Instance.RemovePushBackButtonHandler(OnClickOkButton);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x702B2C Offset: 0x702B2C VA: 0x702B2C
		// // RVA: 0x1724724 Offset: 0x1724724 VA: 0x1724724
		private IEnumerator Co_Leave()
		{
			//0x1725C74
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
			yield return new WaitWhile(() =>
			{
				//0x1725748
				return m_layoutRoot.IsPlayingChildren();
			});
			transform.SetParent(m_parent);
		}

		// // RVA: 0x17247D0 Offset: 0x17247D0 VA: 0x17247D0
		// public void Show() { }

		// // RVA: 0x1724854 Offset: 0x1724854 VA: 0x1724854
		public void Hide()
		{
			m_isShow = false;
			m_layoutRoot.StartChildrenAnimGoStop("st_out");
		}

		// // RVA: 0x17248D8 Offset: 0x17248D8 VA: 0x17248D8
		// public bool IsPlaying() { }

		// // RVA: 0x1724904 Offset: 0x1724904 VA: 0x1724904
		private void OnClickOkButton()
		{
			if(!m_isShow)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(onClickButton != null)
				onClickButton();
			Leave();
		}

		// RVA: 0x1724988 Offset: 0x1724988 VA: 0x1724988 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("sw_pop_ex_btl_win_scr_01_inout_anim") as AbsoluteLayout;
			m_layoutWinLose = layout.FindViewById("swtbl_win_lose") as AbsoluteLayout;
			m_layoutNewRecord = layout.FindViewById("swtbl_g_r_e_newrec") as AbsoluteLayout;
			m_layoutNewRecordIcon = layout.FindViewById("swtbl_g_r_e_newrec_icn") as AbsoluteLayout;
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			m_imageJacket = imgs.Where((RawImageEx _) =>
			{
				//0x17257F0
				return _.name == "swtexc_cmn_cd (ImageView)";
			}).First();
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_textClassRank = txts.Where((Text _) =>
			{
				//0x1725870
				return _.name == "class (TextView)";
			}).First();
			m_textWinResult = txts.Where((Text _) =>
			{
				//0x17258F0
				return _.name == "win (TextView)";
			}).First();
			m_textLoseResult = txts.Where((Text _) =>
			{
				//0x1725970
				return _.name == "lose (TextView)";
			}).First();
			NumberBase[] numbers = GetComponentsInChildren<NumberBase>(true);
			m_numScore = numbers.Where((NumberBase _) =>
			{
				//0x17259F0
				return _.name == "swnum_event_score_1 (AbsoluteLayout)";
			}).First();
			m_numWinBonus = numbers.Where((NumberBase _) =>
			{
				//0x1725A70
				return _.name == "swnum_event_score_4 (AbsoluteLayout)";
			}).First();
			m_numExBattleScore = numbers.Where((NumberBase _) =>
			{
				//0x1725AF0
				return _.name == "swnum_event_score_2 (AbsoluteLayout)";
			}).First();
			m_numExBattleHiScore = numbers.Where((NumberBase _) =>
			{
				//0x1725B70
				return _.name == "swnum_event_score_3 (AbsoluteLayout)";
			}).First();
			ActionButton[] btns = GetComponentsInChildren<ActionButton>(true);
			m_button = btns.Where((ActionButton _) =>
			{
				//0x1725BF0
				return _.name == "sw_btn_anim (AbsoluteLayout)";
			}).First();
			m_button.AddOnClickCallback(OnClickOkButton);
			Hide();
			Loaded();
			return true;
		}
	}
}
