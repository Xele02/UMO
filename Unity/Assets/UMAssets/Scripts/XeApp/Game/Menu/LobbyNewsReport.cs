using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LobbyNewsReport : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_newsButton; // 0x14
		private AbsoluteLayout m_windowBase; // 0x18
		private readonly float WaitTime = 3.0f; // 0x1C
		public Action onNewsClickButton; // 0x20
		private bool isLeave = true; // 0x24
		public bool IsShow; // 0x25

		// RVA: 0xD19AFC Offset: 0xD19AFC VA: 0xD19AFC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_windowBase = layout.FindViewById("sw_lb_btn_news_anim_01") as AbsoluteLayout;
			m_newsButton.ClearOnClickCallback();
			m_newsButton.AddOnClickCallback(() =>
			{
				//0xD19E1C
				if(m_newsButton != null)
					onNewsClickButton();
			});
			IsShow = false;
			return true;
		}

		// // RVA: 0xD19C4C Offset: 0xD19C4C VA: 0xD19C4C
		public void Enter()
		{
			isLeave = false;
			IsShow = true;
			this.StartCoroutineWatched(AutoLeave());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E98C4 Offset: 0x6E98C4 VA: 0x6E98C4
		// // RVA: 0xD19C7C Offset: 0xD19C7C VA: 0xD19C7C
		private IEnumerator AutoLeave()
		{
			//0xD19ED4
			m_windowBase.StartAllAnimGoStop("go_in", "st_in");
			while(m_windowBase.IsPlayingAll())
				yield return null;
			yield return new WaitForSecondsRealtime(WaitTime);
			if(!isLeave)
				Leave();
		}

		// // RVA: 0xD19D28 Offset: 0xD19D28 VA: 0xD19D28
		public void Leave()
		{
			IsShow = false;
			if(isLeave)
				return;
			isLeave = true;
			m_windowBase.StartAllAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0xD19DD0 Offset: 0xD19DD0 VA: 0xD19DD0
		// public void Show() { }

		// RVA: 0xD112A8 Offset: 0xD112A8 VA: 0xD112A8
		public void Hide()
		{
			IsShow = false;
			m_windowBase.StartAllAnimGoStop("st_wait", "st_wait");
		}

		// // RVA: 0xD19DD4 Offset: 0xD19DD4 VA: 0xD19DD4
		public bool IsPlayingChild()
		{
			return m_windowBase.IsPlayingChildren();
		}
	}
}
