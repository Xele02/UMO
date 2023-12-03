using System;
using System.Collections;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class OfferReturnLayout : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_layoutRoot; // 0x14
		private bool IsLeave; // 0x18
		public bool IsEntryEnd; // 0x19

		// RVA: 0x185EA00 Offset: 0x185EA00 VA: 0x185EA00
		private void Start()
		{
			return;
		}

		// RVA: 0x185EA04 Offset: 0x185EA04 VA: 0x185EA04
		private void Update()
		{
			return;
		}

		// RVA: 0x18585A4 Offset: 0x18585A4 VA: 0x18585A4
		public void AnimStart()
		{
			IsLeave = false;
			IsEntryEnd = false;
			m_layoutRoot.StartChildrenAnimGoStop("go_act", "st_act");
			this.StartCoroutineWatched(StartAnimEnd(() =>
			{
				//0x185ECB8
				AnimLoop();
			}));
		}

		// RVA: 0x1858700 Offset: 0x1858700 VA: 0x1858700
		public void AnimLeave()
		{
			IsLeave = true;
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x185EAB0 Offset: 0x185EAB0 VA: 0x185EAB0
		public void AnimLoop()
		{
			IsEntryEnd = true;
			m_layoutRoot.StartChildrenAnimGoStop("logo_act");
		}

		//// RVA: 0x185EB34 Offset: 0x185EB34 VA: 0x185EB34
		public void Hide()
		{
			m_layoutRoot.StartChildrenAnimGoStop("st_wait");
		}

		//// RVA: 0x185A2F0 Offset: 0x185A2F0 VA: 0x185A2F0
		//public bool IsPlaying() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FA6DC Offset: 0x6FA6DC VA: 0x6FA6DC
		//// RVA: 0x185EA08 Offset: 0x185EA08 VA: 0x185EA08
		private IEnumerator StartAnimEnd(Action act)
		{
			//0x185ECC0
			yield return null;
			while (m_layoutRoot.IsPlayingChildren())
			{
				if (IsLeave)
					yield break;
				yield return null;
			}
			act();
		}

		// RVA: 0x185EBD0 Offset: 0x185EBD0 VA: 0x185EBD0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_sortie_vfo_return_sw_sortie_vfo_return_anim") as AbsoluteLayout;
			Hide();
			Loaded();
			return true;
		}
	}
}
