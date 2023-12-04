using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;
using System;
using mcrs;
using XeApp.Game.Common.uGUI;

namespace XeApp.Game.Menu
{
	public class GeneralListWindow : LayoutLabelScriptBase
	{
		public enum Preset
		{
			PresentBox = 0,
			PresentHistory = 1,
			ScoreRanking = 2,
			CollectEventRanking = 3,
			ScoreEventRanking = 4,
			BattleEventRanking = 5,
			CollectEventRankingFriend = 6,
			ScoreEventRankingFriend = 7,
			BattleEventRankingFriend = 8,
			GoDivaTotalRanking = 9,
			GoDivaTotalRankingFriend = 10,
			GoDivaEventRanking = 11,
			GoDivaEventRankingFriend = 12,
			None = 13,
		}

		private enum HeaderStyle
		{
			Items = 0,
			Music = 1,
			Event = 2,
			MusicEvent = 3,
			GoDivaTotalRanking = 4,
			GoDivaEventRanking = 5,
			None = 6,
		}

		private enum ButtonStyle
		{
			Inner2 = 0,
			Inner1 = 1,
			Frame = 2,
			None = 3,
		}

		public enum EventSubHeaderStyle
		{
			DefaultRanking = 0,
			TotalRanking = 1,
			MusicRanking = 2,
			ExBattleTotalRanking = 3,
			ExBattleScoreRanking = 4,
			DivaRanking = 5,
		}

		private const float s_elemOffsetY = -128;
		[SerializeField]
		private Text m_windowMessage; // 0x18
		[SerializeField]
		private Text m_warningMessage; // 0x1C
		[SerializeField]
		private List<Text> m_musicTitle; // 0x20
		[SerializeField]
		private Text m_rankingMessage; // 0x24
		[SerializeField]
		private Text m_rankButtonLabel; // 0x28
		[SerializeField]
		private List<RawImageEx> m_musicAttrImage; // 0x2C
		[SerializeField]
		private RawImageEx m_musicDiffImage; // 0x30
		[SerializeField]
		private List<RawImageEx> m_musicJacketImage; // 0x34
		[SerializeField]
		private RawImageEx m_eventBannerImage; // 0x38
		[SerializeField]
		private List<RawImageEx> m_rankingMessageImage; // 0x3C
		[SerializeField]
		private ActionButton m_innerButton1; // 0x40
		[SerializeField]
		private ActionButton m_innerButton2; // 0x44
		[SerializeField]
		private ActionButton m_frameButton; // 0x48
		[SerializeField]
		private ButtonBase m_totalRankTab; // 0x4C
		[SerializeField]
		private ButtonBase m_friendRankTab; // 0x50
		[SerializeField]
		private NumberBase m_itemCount; // 0x54
		[SerializeField]
		private NumberBase m_itemMax; // 0x58
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x5C
		[SerializeField]
		private List<RawImageEx> m_eventRankingMusicJacketImage; // 0x60
		[SerializeField]
		private ActionButton m_eventRankingChangeButton; // 0x64
		[SerializeField]
		private RawImageEx m_eventRankingChangeButtonImage; // 0x68
		[SerializeField]
		private Text m_txtDivaName; // 0x6C
		private LayoutSymbolData m_symbolMain; // 0x70
		private LayoutSymbolData m_symbolMessage; // 0x74
		private LayoutSymbolData m_symbolHeaderStyle; // 0x78
		private LayoutSymbolData m_symbolButtonStyle; // 0x7C
		private LayoutSymbolData m_symbolInnerButtonType; // 0x80
		private LayoutSymbolData m_symbolTotalTabType; // 0x84
		private LayoutSymbolData m_symbolFriendTabType; // 0x88
		private AbsoluteLayout[] m_AnimEventRankingMusicJacket; // 0x8C
		private AbsoluteLayout m_AnimEventRankingChangeBtn; // 0x90
		private AbsoluteLayout m_AnimEventRankingTitle; // 0x94
		private LayoutUGUIHitOnly m_HitEventRankingChangeBtn; // 0x98
		private TexUVListManager m_uvMan; // 0x9C
		private int m_elemCount; // 0xA0
		private Func<IiconTexture> m_musicJacketDelegate; // 0xA4

		public Action onClickFriendRankButton { private get; set; } // 0xA8
		public Action onClickTotalRankButton { private get; set; } // 0xAC
		public Action onClickReceiveButton { private get; set; } // 0xB0
		public Action onClickHistoryButton { private get; set; } // 0xB4
		public Action onClickPresentButton { private get; set; } // 0xB8
		public Action onClickSearchButton { private get; set; } // 0xBC
		public Action onClickRankRangeButton { private get; set; } // 0xC0
		public Action onClickCornerButton { private get; set; } // 0xC4
		public Action onClickChangeRankingButton { private get; set; } // 0xC8

		// RVA: 0xB87A48 Offset: 0xB87A48 VA: 0xB87A48
		private void Update()
		{
			if(m_musicJacketDelegate != null)
			{
				IiconTexture t = m_musicJacketDelegate();
				if (t == null)
					return;
				SetMusicJacket(t);
				m_musicJacketDelegate = null;
			}
		}

		//// RVA: 0xB87CD0 Offset: 0xB87CD0 VA: 0xB87CD0
		public void Enter()
		{
			m_symbolMain.StartAnim("enter");
		}

		//// RVA: 0xB87D4C Offset: 0xB87D4C VA: 0xB87D4C
		public void Leave()
		{
			m_symbolMain.StartAnim("leave");
		}

		//// RVA: 0xB87DC8 Offset: 0xB87DC8 VA: 0xB87DC8
		//public void Show() { }

		//// RVA: 0xB87E44 Offset: 0xB87E44 VA: 0xB87E44
		public void Hide()
		{
			m_symbolMain.StartAnim("wait");
		}

		//// RVA: 0xB87EC0 Offset: 0xB87EC0 VA: 0xB87EC0
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		//// RVA: 0xB87EEC Offset: 0xB87EEC VA: 0xB87EEC
		public void ChangePreset(Preset preset, bool enableChangeRanking = false)
		{
			ClearButtonCallback();
			m_AnimEventRankingChangeBtn.StartChildrenAnimGoStop("st_non", "st_non");
			m_HitEventRankingChangeBtn.enabled = false;
			switch(preset)
			{
				case Preset.PresentBox:
					ChangeHeaderStyle(HeaderStyle.Items);
					ChangeButtonStyle(ButtonStyle.Inner2);
					m_symbolInnerButtonType.StartAnim("history");
					HideRankingTab();
					m_innerButton1.AddOnClickCallback(() =>
					{
						//0xB8A8AC
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						if (onClickHistoryButton != null)
							onClickHistoryButton();
					});
					m_innerButton2.AddOnClickCallback(() =>
					{
						//0xB8A91C
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						if (onClickReceiveButton != null)
							onClickReceiveButton();
					});
					break;
				case Preset.PresentHistory:
					ChangeHeaderStyle(HeaderStyle.Items);
					ChangeButtonStyle(ButtonStyle.Inner1);
					m_symbolInnerButtonType.StartAnim("present");
					HideRankingTab();
					m_innerButton1.AddOnClickCallback(() =>
					{
						//0xB8A98C
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						if (onClickPresentButton != null)
							onClickPresentButton();
					});
					break;
				case Preset.ScoreRanking:
					ChangeHeaderStyle(HeaderStyle.Music);
					ChangeButtonStyle(ButtonStyle.None);
					m_totalRankTab.AddOnClickCallback(() =>
					{
						//0xB8A9FC
						if (onClickTotalRankButton != null)
							onClickTotalRankButton();
					});
					m_symbolInnerButtonType.StartAnim("history");
					m_friendRankTab.AddOnClickCallback(() =>
					{
						//0xB8AA10
						if (onClickFriendRankButton != null)
							onClickFriendRankButton();
					});
					break;
				case Preset.CollectEventRanking:
				case Preset.BattleEventRanking:
				case Preset.GoDivaEventRanking:
					ChangeHeaderStyle(HeaderStyle.Event);
					ChangeButtonStyle(ButtonStyle.Inner1);
					m_symbolInnerButtonType.StartAnim("text");
					m_totalRankTab.AddOnClickCallback(() =>
					{
						//0xB8AA24
						if (onClickTotalRankButton != null)
							onClickTotalRankButton();
					});
					m_friendRankTab.AddOnClickCallback(() =>
					{
						//0xB8AA38
						if (onClickFriendRankButton != null)
							onClickFriendRankButton();
					});
					m_innerButton1.AddOnClickCallback(() =>
					{
						//0xB8AA4C
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						if (onClickRankRangeButton != null)
							onClickRankRangeButton();
					});
					if (!enableChangeRanking)
						return;
					m_AnimEventRankingChangeBtn.StartChildrenAnimGoStop("st_wait", "st_wait");
					m_HitEventRankingChangeBtn.enabled = true;
					m_eventRankingChangeButton.AddOnClickCallback(() =>
					{
						//0xB8AABC
						if (onClickChangeRankingButton != null)
							onClickChangeRankingButton();
					});
					break;
				case Preset.ScoreEventRanking:
					ChangeHeaderStyle(HeaderStyle.MusicEvent);
					ChangeButtonStyle(ButtonStyle.Inner1);
					m_symbolInnerButtonType.StartAnim("text");
					m_totalRankTab.AddOnClickCallback(() =>
					{
						//0xB8AB0C
						if (onClickTotalRankButton != null)
							onClickTotalRankButton();
					});
					m_friendRankTab.AddOnClickCallback(() =>
					{
						//0xB8AB20
						if (onClickFriendRankButton != null)
							onClickFriendRankButton();
					});
					m_innerButton1.AddOnClickCallback(() =>
					{
						//0xB8AB34
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						if (onClickRankRangeButton != null)
							onClickRankRangeButton();
					});
					break;
				case Preset.CollectEventRankingFriend:
				case Preset.BattleEventRankingFriend:
				case Preset.GoDivaEventRankingFriend:
					ChangeHeaderStyle(HeaderStyle.Event);
					ChangeButtonStyle(ButtonStyle.None);
					m_totalRankTab.AddOnClickCallback(() =>
					{
						//0xB8AAD0
						if (onClickTotalRankButton != null)
							onClickTotalRankButton();
					});
					m_friendRankTab.AddOnClickCallback(() =>
					{
						//0xB8AAE4
						if (onClickFriendRankButton != null)
							onClickFriendRankButton();
					});
					if (!enableChangeRanking)
						return;
					m_AnimEventRankingChangeBtn.StartChildrenAnimGoStop("st_wait", "st_wait");
					m_HitEventRankingChangeBtn.enabled = true;
					m_eventRankingChangeButton.AddOnClickCallback(() =>
					{
						//0xB8AAF8
						if (onClickChangeRankingButton != null)
							onClickChangeRankingButton();
					});
					break;
				case Preset.ScoreEventRankingFriend:
					ChangeHeaderStyle(HeaderStyle.MusicEvent);
					ChangeButtonStyle(ButtonStyle.None);
					m_totalRankTab.AddOnClickCallback(() =>
					{
						//0xB8ABA4
						if (onClickTotalRankButton != null)
							onClickTotalRankButton();
					});
					m_friendRankTab.AddOnClickCallback(() =>
					{
						//0xB8ABB8
						if (onClickFriendRankButton != null)
							onClickFriendRankButton();
					});
					break;
				case Preset.GoDivaTotalRanking:
				case Preset.GoDivaTotalRankingFriend:
					ChangeHeaderStyle(HeaderStyle.GoDivaTotalRanking);
					ChangeButtonStyle(preset == Preset.GoDivaTotalRankingFriend ? ButtonStyle.None : ButtonStyle.Inner1);
					for(int i = 0; i < m_musicJacketImage.Count; i++)
					{
						m_musicJacketImage[i].enabled = false;
					}
					m_eventBannerImage.enabled = false;
					SetRankingMessage("");
					m_totalRankTab.AddOnClickCallback(() =>
					{
						//0xB8ABCC
						if (onClickTotalRankButton != null)
							onClickTotalRankButton();
					});
					m_friendRankTab.AddOnClickCallback(() =>
					{
						//0xB8ABE0
						if (onClickFriendRankButton != null)
							onClickFriendRankButton();
					});
					if (preset != Preset.GoDivaTotalRanking)
						return;
					m_symbolInnerButtonType.StartAnim("text");
					m_innerButton1.AddOnClickCallback(() =>
					{
						//0xB8ABF4
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						if (onClickRankRangeButton != null)
							onClickRankRangeButton();
					});
					break;
				case Preset.None:
					ChangeHeaderStyle(HeaderStyle.None);
					ChangeButtonStyle(ButtonStyle.None);
					HideRankingTab();
					break;
				default:
					break;
			}
		}

		//// RVA: 0xB88D58 Offset: 0xB88D58 VA: 0xB88D58
		public void SetLockInnerButton2(bool isLock)
		{
			m_innerButton2.Disable = isLock;
		}

		//// RVA: 0xB88D8C Offset: 0xB88D8C VA: 0xB88D8C
		public void SelectTotalRankingTab()
		{
			m_symbolTotalTabType.StartAnim("red");
			m_symbolFriendTabType.StartAnim("blue");
		}

		//// RVA: 0xB88E38 Offset: 0xB88E38 VA: 0xB88E38
		public void SelectFriendRankingTab()
		{
			m_symbolTotalTabType.StartAnim("blue");
			m_symbolFriendTabType.StartAnim("red");
		}

		//// RVA: 0xB88EE4 Offset: 0xB88EE4 VA: 0xB88EE4
		public void SetMessage(string message)
		{
			m_windowMessage.text = message;
		}

		//// RVA: 0xB88F20 Offset: 0xB88F20 VA: 0xB88F20
		public void SetMessageVisible(bool isVisible)
		{
			m_symbolMessage.StartAnim(isVisible ? "on" : "off");
		}

		//// RVA: 0xB88FB8 Offset: 0xB88FB8 VA: 0xB88FB8
		public void SetWarningMessage(string warning)
		{
			m_warningMessage.text = warning;
		}

		//// RVA: 0xB88FF4 Offset: 0xB88FF4 VA: 0xB88FF4
		public void SetMusicTitle(string title, string colorCode)
		{
			string s = RichTextUtility.MakeColorTagString(title, colorCode);
			for(int i = 0; i < m_musicTitle.Count; i++)
			{
				m_musicTitle[i].text = s;
			}
		}

		//// RVA: 0xB88C38 Offset: 0xB88C38 VA: 0xB88C38
		public void SetRankingMessage(string message)
		{
			m_rankingMessage.text = message;
			for(int i = 0; i < m_rankingMessageImage.Count; i++)
			{
				m_rankingMessageImage[i].enabled = !string.IsNullOrEmpty(message);
			}
		}

		//// RVA: 0xB89124 Offset: 0xB89124 VA: 0xB89124
		public void SetRankButtonLabel(string label)
		{
			m_rankButtonLabel.text = label;
		}

		//// RVA: 0xB89160 Offset: 0xB89160 VA: 0xB89160
		public void SetMusicAttr(GameAttribute.Type attr)
		{
			Rect r = GameManager.Instance.UnionTextureManager.GetGameAttributeUvRect(attr);
			for(int i = 0; i < m_musicAttrImage.Count; i++)
			{
				m_musicAttrImage[i].uvRect = r;
			}
		}

		//// RVA: 0xB892F0 Offset: 0xB892F0 VA: 0xB892F0
		public void SetMusicDiffVisible(bool isVisible)
		{
			m_musicDiffImage.enabled = isVisible;
		}

		//// RVA: 0xB89324 Offset: 0xB89324 VA: 0xB89324
		//public void SetMusicDiff(Difficulty.Type difficulty) { }

		//// RVA: 0xB89434 Offset: 0xB89434 VA: 0xB89434
		//public void SetMusicJacketDelegate(Func<IiconTexture> iconDelegate) { }

		//// RVA: 0xB87AD0 Offset: 0xB87AD0 VA: 0xB87AD0
		public void SetMusicJacket(IiconTexture iconTex)
		{
			for(int i = 0; i < m_musicJacketImage.Count; i++)
			{
				iconTex.Set(m_musicJacketImage[i]);
			}
		}

		//// RVA: 0xB8943C Offset: 0xB8943C VA: 0xB8943C
		public void SetEventMusicRankingJacket(IiconTexture iconTex, int index = 0)
		{
			if(iconTex == null)
			{
				m_eventRankingMusicJacketImage[index].enabled = false;
			}
			else
			{
				iconTex.Set(m_eventRankingMusicJacketImage[index]);
				m_eventRankingMusicJacketImage[index].enabled = true;
			}
		}

		//// RVA: 0xB89584 Offset: 0xB89584 VA: 0xB89584
		//public void SetEventBanner(IiconTexture iconTex) { }

		//// RVA: 0xB89664 Offset: 0xB89664 VA: 0xB89664
		public void SetItemCount(int count)
		{
			m_itemCount.SetNumber(count, 0);
		}

		//// RVA: 0xB896A4 Offset: 0xB896A4 VA: 0xB896A4
		public void SetItemMax(int max)
		{
			m_itemMax.SetNumber(max, 0);
		}

		//// RVA: 0xB88960 Offset: 0xB88960 VA: 0xB88960
		private void ClearButtonCallback()
		{
			m_innerButton1.ClearOnClickCallback();
			m_innerButton2.ClearOnClickCallback();
			m_frameButton.ClearOnClickCallback();
			m_totalRankTab.ClearOnClickCallback();
			m_friendRankTab.ClearOnClickCallback();
			m_eventRankingChangeButton.ClearOnClickCallback();
		}

		//// RVA: 0xB88A30 Offset: 0xB88A30 VA: 0xB88A30
		private void ChangeHeaderStyle(HeaderStyle style)
		{
			m_symbolHeaderStyle.StartAnim(new string[7] { "items", "music", "event", "evscore", "drank", "items", "none" }[(int)style]);
		}

		//// RVA: 0xB88AE4 Offset: 0xB88AE4 VA: 0xB88AE4
		private void ChangeButtonStyle(ButtonStyle style)
		{
			m_symbolButtonStyle.StartAnim(new string[4] { "inner2", "inner1", "frame", "none" } [(int)style]);
		}

		//// RVA: 0xB88B8C Offset: 0xB88B8C VA: 0xB88B8C
		private void HideRankingTab()
		{
			m_symbolTotalTabType.StartAnim("none");
			m_symbolFriendTabType.StartAnim("none");
		}

		//// RVA: 0xB896E4 Offset: 0xB896E4 VA: 0xB896E4
		//public void ChangeEventSubHeaderStyle(GeneralListWindow.EventSubHeaderStyle style, int a_diva_id = 0) { }

		// RVA: 0xB8A270 Offset: 0xB8A270 VA: 0xB8A270 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_uvMan = uvMan;
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolMessage = CreateSymbol("message", layout);
			m_symbolHeaderStyle = CreateSymbol("head_style", layout);
			m_symbolButtonStyle = CreateSymbol("btn_style", layout);
			m_symbolInnerButtonType = CreateSymbol("btn_inner1_type", layout);
			m_symbolTotalTabType = CreateSymbol("tab_total_type", layout);
			m_symbolFriendTabType = CreateSymbol("tab_friend_type", layout);
			m_AnimEventRankingMusicJacket = new AbsoluteLayout[3];
			m_AnimEventRankingMusicJacket[0] = layout.FindViewById("swtbl_jacket") as AbsoluteLayout;
			m_AnimEventRankingMusicJacket[1] = layout.FindViewById("swtbl_jacket_2") as AbsoluteLayout;
			m_AnimEventRankingMusicJacket[2] = layout.FindViewById("swtbl_jacket_3") as AbsoluteLayout;
			m_AnimEventRankingChangeBtn = layout.FindViewById("sw_p_r_e_toggle_btn") as AbsoluteLayout;
			m_AnimEventRankingTitle = layout.FindViewById("swtbl_title") as AbsoluteLayout;
			m_HitEventRankingChangeBtn = m_eventRankingChangeButton.gameObject.GetComponentInChildren<LayoutUGUIHitOnly>();
			SetMessageVisible(false);
			SetEventMusicRankingJacket(null, 0);
			SetEventMusicRankingJacket(null, 1);
			SetEventMusicRankingJacket(null, 2);
			Loaded();
			return true;
		}
	}
}
