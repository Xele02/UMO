using XeSys.Gfx;
using XeApp.Game;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Menu
{
	public class GeneralListButtonRuntime : LayoutLabelScriptBase
	{
		public enum Preset
		{
			GuestSelect = 0,
			FriendList = 1,
			FriendSearch = 2,
			BlockList = 3,
			None = 4,
		}

		private enum Style
		{
			Guest = 0,
			Friend = 1,
			Search = 2,
			None = 3,
		}

		private class ButtonSet
		{
			public ActionButton button { get; private set; } // 0x8
			public LayoutSymbolData symbol { get; private set; } // 0xC

			// RVA: 0xB87594 Offset: 0xB87594 VA: 0xB87594
			public void Reset(ActionButton b, LayoutSymbolData s)
			{
				button = b;
				symbol = s;
			}
		}

		[SerializeField]
		private TextureListSupport m_texListSupport; // 0x18
		[SerializeField]
		private ActionButton m_friendButtonLeft; // 0x1C
		[SerializeField]
		private ActionButton m_friendButtonRight; // 0x20
		[SerializeField]
		private ActionButton m_reloadButton; // 0x24
		[SerializeField]
		private RawImageEx m_sortTypeImage; // 0x28
		[SerializeField]
		private RawImageEx m_sortOrderImage; // 0x2C
		private TexUVListManager m_uvMan; // 0x30
		private LayoutSymbolData m_symbolMain; // 0x34
		private LayoutSymbolData m_symbolStyle; // 0x38
		private ButtonSet m_leftSide = new ButtonSet(); // 0x3C
		private ButtonSet m_rightSide = new ButtonSet(); // 0x40
		private List<Rect> m_sortOrderUvRects = new List<Rect>(2); // 0x44
		private Rect m_idSearchUvRect; // 0x48

		public Action onClickHistoryButton { private get; set; } // 0x58
		public Action onClickSearchButton { private get; set; } // 0x5C
		public Action onClickSortButton { private get; set; } // 0x60
		public Action onClickOrderButton { private get; set; } // 0x64
		public Action onClickReloadButton { private get; set; } // 0x68

		//// RVA: 0xB86AE8 Offset: 0xB86AE8 VA: 0xB86AE8
		public void Enter()
		{
			m_symbolMain.StartAnim("enter");
		}

		//// RVA: 0xB86B64 Offset: 0xB86B64 VA: 0xB86B64
		public void Leave()
		{
			m_symbolMain.StartAnim("leave");
		}

		//// RVA: 0xB86BE0 Offset: 0xB86BE0 VA: 0xB86BE0
		//public void Show() { }

		//// RVA: 0xB86C5C Offset: 0xB86C5C VA: 0xB86C5C
		public void Hide()
		{
			m_symbolMain.StartAnim("wait");
		}

		//// RVA: 0xB86CD8 Offset: 0xB86CD8 VA: 0xB86CD8
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		//// RVA: 0xB86D04 Offset: 0xB86D04 VA: 0xB86D04
		public void ChangePreset(Preset preset)
		{
			ClearButtonCallback();
			switch(preset)
			{
				case Preset.GuestSelect:
					ChangeStyle(Style.Guest);
					m_leftSide.button.AddOnClickCallback(() =>
					{
						//0xB878F8
						if (onClickSortButton != null)
							onClickSortButton();
					});
					m_rightSide.button.AddOnClickCallback(() =>
					{
						//0xB8790C
						if (onClickOrderButton != null)
							onClickOrderButton();
					});
					m_reloadButton.Hidden = false;
					m_reloadButton.AddOnClickCallback(() =>
					{
						//0xB87920
						if (onClickReloadButton != null)
							onClickReloadButton();
					});
					break;
				case Preset.FriendList:
					ChangeStyle(Style.Friend);
					m_leftSide.button.AddOnClickCallback(() =>
					{
						//0xB87934
						if (onClickSortButton != null)
							onClickSortButton();
					});
					m_rightSide.button.AddOnClickCallback(() =>
					{
						//0xB87948
						if (onClickOrderButton != null)
							onClickOrderButton();
					});
					m_reloadButton.Hidden = true;
					break;
				case Preset.FriendSearch:
					ChangeStyle(Style.Search);
					m_texListSupport.SetImage(m_sortOrderImage, "sel_list_cont_btn01_fnt_14");
					m_rightSide.button.AddOnClickCallback(() =>
					{
						//0xB8795C
						if (onClickSearchButton != null)
							onClickSearchButton();
					});
					break;
				case Preset.BlockList:
				case Preset.None:
					ChangeStyle(Style.None);
					break;
			}
		}

		//// RVA: 0xB872C0 Offset: 0xB872C0 VA: 0xB872C0
		public void SetSortType(SortItem sortType)
		{
			m_texListSupport.SetImage(m_sortTypeImage, SortMenuWindow.GetSortLabelUv(sortType));
		}

		//// RVA: 0xB87378 Offset: 0xB87378 VA: 0xB87378
		//public void SetSortOrder(bool isDesc) { }

		//// RVA: 0xB87388 Offset: 0xB87388 VA: 0xB87388
		public void SetSortOrder(GeneralList.SortOrder order)
		{
			m_texListSupport.SetImage(m_sortOrderImage, GeneralList.SortOrderUvNames[(int)order]);
		}

		//// RVA: 0xB8747C Offset: 0xB8747C VA: 0xB8747C
		public void SetReloadButtonLock(bool isLock)
		{
			if (m_reloadButton.Disable == isLock)
				return;
			m_reloadButton.Disable = isLock;
		}

		//// RVA: 0xB874E0 Offset: 0xB874E0 VA: 0xB874E0
		public void SetFriendButtonLock(bool isLock)
		{
			if(m_friendButtonLeft.Disable != isLock)
			{
				m_friendButtonLeft.Disable = isLock;
			}
			if(m_friendButtonRight.Disable != isLock)
			{
				m_friendButtonRight.Disable = isLock;
			}
		}

		//// RVA: 0xB870A0 Offset: 0xB870A0 VA: 0xB870A0
		private void ClearButtonCallback()
		{
			m_friendButtonLeft.ClearOnClickCallback();
			m_friendButtonRight.ClearOnClickCallback();
			m_reloadButton.ClearOnClickCallback();
		}

		//// RVA: 0xB87110 Offset: 0xB87110 VA: 0xB87110
		private void ChangeStyle(Style style)
		{
			string preset = "none";
			switch(style)
			{
				case Style.Guest:
					preset = "guest";
					m_leftSide.Reset(m_friendButtonLeft, null);
					m_rightSide.Reset(m_friendButtonRight, null);
					break;
				case Style.Friend:
					preset = "friend";
					m_leftSide.Reset(m_friendButtonLeft, null);
					m_rightSide.Reset(m_friendButtonRight, null);
					break;
				case Style.Search:
					m_leftSide.Reset(null, null);
					m_rightSide.Reset(m_friendButtonRight, null);
					preset = "search";
					break;
				case Style.None:
					m_leftSide.Reset(null, null);
					m_rightSide.Reset(null, null);
					break;
				default:
					preset = "";
					break;
			}
			m_symbolStyle.StartAnim(preset);
		}

		// RVA: 0xB875A0 Offset: 0xB875A0 VA: 0xB875A0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_uvMan = uvMan;
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolStyle = CreateSymbol("style", layout);
			m_idSearchUvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("sel_list_cont_btn01_fnt_14"));
			for(int i = 0; i < GeneralList.SortOrderUvNames.Length; i++)
			{
				m_sortOrderUvRects.Add(LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(GeneralList.SortOrderUvNames[i])));
			}
			Loaded();
			return true;
		}
	}
}
