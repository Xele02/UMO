using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using System;

namespace XeApp.Game.Menu
{
	public class FriendMenuRuntime : LayoutLabelScriptBase
	{
		[SerializeField]
		private FriendMenuListButton m_friendListButton; // 0x18
		[SerializeField]
		private FriendMenuListButton m_requestListButton; // 0x1C
		[SerializeField]
		private FriendMenuListButton m_acceptListButton; // 0x20
		[SerializeField]
		private ActionButton m_friendSearchButton; // 0x24
		private LayoutSymbolData m_symbolMain; // 0x28
		private LayoutSymbolData m_symbolFriendButtonStyle; // 0x2C
		private LayoutSymbolData m_symbolRequestButtonStyle; // 0x30
		private LayoutSymbolData m_symbolAcceptButtonStyle; // 0x34

		public Action onClickFriendListButton { private get; set; } // 0x38
		public Action onClickRequestListButton { private get; set; } // 0x3C
		public Action onClickAcceptListButton { private get; set; } // 0x40
		public Action onClickFriendSearchButton { private get; set; } // 0x44

		// RVA: 0xED51D4 Offset: 0xED51D4 VA: 0xED51D4
		public void Enter()
		{
			m_symbolMain.StartAnim("enter");
		}

		// RVA: 0xED5250 Offset: 0xED5250 VA: 0xED5250
		public void Leave()
		{
			m_symbolMain.StartAnim("leave");
		}

		// RVA: 0xED52CC Offset: 0xED52CC VA: 0xED52CC
		public void Show()
		{
			m_symbolMain.StartAnim("active");
		}

		// RVA: 0xED5348 Offset: 0xED5348 VA: 0xED5348
		public void Hide()
		{
			m_symbolMain.StartAnim("wait");
		}

		// RVA: 0xED53C4 Offset: 0xED53C4 VA: 0xED53C4
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		// RVA: 0xED53F0 Offset: 0xED53F0 VA: 0xED53F0
		public void SetupFriendList(string count, string max, bool isNew, string newCount)
		{
			m_friendListButton.SetListCount(count);
			m_friendListButton.SetListMax(max);
			m_friendListButton.SetNewMark(isNew);
			m_friendListButton.SetNewCount(newCount);
		}

		// RVA: 0xED54D0 Offset: 0xED54D0 VA: 0xED54D0
		public void SetupRequestList(string count)
		{
			m_requestListButton.SetListCount(count);
		}

		// RVA: 0xED5500 Offset: 0xED5500 VA: 0xED5500
		public void SetupAcceptlList(string count, bool isNew, string newCount)
		{
			m_acceptListButton.SetListCount(count);
			m_acceptListButton.SetNewMark(isNew);
			m_acceptListButton.SetNewCount(newCount);
		}

		// RVA: 0xED559C Offset: 0xED559C VA: 0xED559C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_friendListButton.AddOnClickCallback(() =>
			{
				//0xED58AC
				if(onClickFriendListButton != null)
					onClickFriendListButton();
			});
			m_requestListButton.AddOnClickCallback(() =>
			{
				//0xED58C0
				if(onClickRequestListButton != null)
					onClickRequestListButton();
			});
			m_acceptListButton.AddOnClickCallback(() =>
			{
				//0xED58D4
				if(onClickAcceptListButton != null)
					onClickAcceptListButton();
			});
			m_friendSearchButton.AddOnClickCallback(() =>
			{
				//0xED58E8
				if(onClickFriendSearchButton != null)
					onClickFriendSearchButton();
			});
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolFriendButtonStyle = CreateSymbol("friend_btn_style", layout);
			m_symbolRequestButtonStyle = CreateSymbol("request_btn_style", layout);
			m_symbolAcceptButtonStyle = CreateSymbol("accept_btn_style", layout);
			m_symbolFriendButtonStyle.StartAnim("n_c_m");
			m_symbolRequestButtonStyle.StartAnim("c");
			m_symbolAcceptButtonStyle.StartAnim("n_c");
			Loaded();
			return true;
		}
	}
}
