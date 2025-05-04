using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class RaidBossSelectAnnounce : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_announceText; // 0x14
		private AbsoluteLayout m_layoutMain; // 0x18
		private AbsoluteLayout m_layoutTextAnim; // 0x1C
		private bool m_isShow; // 0x20
		private Action endCallback; // 0x24

		// RVA: 0x145E640 Offset: 0x145E640 VA: 0x145E640 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutMain = layout.FindViewByExId("sw_raid_announce_bc_anim_raid_announce_bc_set") as AbsoluteLayout;
			m_layoutTextAnim = layout.FindViewByExId("raid_announce_bc_set_raid_announce_b_fnt") as AbsoluteLayout;
			m_isShow = false;
			endCallback = null;
			Loaded();
			return true;
		}

		// RVA: 0x145E7A0 Offset: 0x145E7A0 VA: 0x145E7A0
		public void SetText(string str)
		{
			m_announceText.text = str;
		}

		// RVA: 0x145E7DC Offset: 0x145E7DC VA: 0x145E7DC
		public void TextScrollIn(Action callback)
		{
			if(endCallback != null)
				return;
			endCallback = callback;
			m_layoutTextAnim.StartChildrenAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(Co_EndWatch());
		}

		// RVA: 0x145E920 Offset: 0x145E920 VA: 0x145E920
		public void TextScrollOut()
		{
			m_layoutTextAnim.StartChildrenAnimGoStop("go_out", "st_out");
			this.StartCoroutineWatched(Co_EndWatch());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x711D74 Offset: 0x711D74 VA: 0x711D74
		// // RVA: 0x145E894 Offset: 0x145E894 VA: 0x145E894
		private IEnumerator Co_EndWatch()
		{
			//0x145ED98
			while(IsPlayingScroll())
				yield return null;
			if(endCallback != null)
				endCallback();
			endCallback = null;
		}

		// // RVA: 0x145E9E4 Offset: 0x145E9E4 VA: 0x145E9E4
		private bool IsPlayingScroll()
		{
			return m_layoutTextAnim.IsPlayingChildren();
		}

		// RVA: 0x145EA10 Offset: 0x145EA10 VA: 0x145EA10
		public void TextShow()
		{
			m_layoutMain.StartChildrenAnimGoStop("02", "02");
		}

		// // RVA: 0x145EA90 Offset: 0x145EA90 VA: 0x145EA90
		public void TextHide()
		{
			m_layoutMain.StartChildrenAnimGoStop("01", "01");
		}

		// // RVA: 0x145EB10 Offset: 0x145EB10 VA: 0x145EB10
		// public void Show() { }

		// // RVA: 0x145EB98 Offset: 0x145EB98 VA: 0x145EB98
		public void Hide()
		{
			m_isShow = false;
			m_layoutMain.StartSiblingAnimGoStop("st_out", "st_out");
		}

		// // RVA: 0x145EC20 Offset: 0x145EC20 VA: 0x145EC20
		public void Enter()
		{
			if(!m_isShow)
			{
				m_layoutMain.StartSiblingAnimGoStop("go_in", "st_in");
			}
			m_isShow = true;
		}

		// // RVA: 0x145ECC0 Offset: 0x145ECC0 VA: 0x145ECC0
		public void Leave()
		{
			if(m_isShow)
			{
				m_layoutMain.StartSiblingAnimGoStop("go_out", "st_out");
			}
			m_isShow = false;
		}

		// // RVA: 0x145ED60 Offset: 0x145ED60 VA: 0x145ED60
		public bool IsPlaying()
		{
			return m_layoutMain.IsPlayingSibling();
		}
	}
}
