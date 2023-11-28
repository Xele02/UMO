using System.Collections;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class OfferResultTitleLayout : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_layoutRoot; // 0x14

		// RVA: 0x185E59C Offset: 0x185E59C VA: 0x185E59C
		private void Start()
		{
			return;
		}

		// RVA: 0x185E5A0 Offset: 0x185E5A0 VA: 0x185E5A0
		private void Update()
		{
			return;
		}

		// RVA: 0x185DEFC Offset: 0x185DEFC VA: 0x185DEFC
		public void Enter()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(Co_LoopAnimation());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FA614 Offset: 0x6FA614 VA: 0x6FA614
		//// RVA: 0x185E5A4 Offset: 0x185E5A4 VA: 0x185E5A4
		private IEnumerator Co_LoopAnimation()
		{
			//0x185E8BC
			yield return null;
			while(m_layoutRoot.IsPlaying())
				yield return null;
			loopStart();
		}

		// RVA: 0x185A6D4 Offset: 0x185A6D4 VA: 0x185A6D4
		public void Leave()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x185E650 Offset: 0x185E650 VA: 0x185E650
		public void loopStart()
		{
			m_layoutRoot.StartChildrenAnimLoop("logo_act");
		}

		//// RVA: 0x185E6CC Offset: 0x185E6CC VA: 0x185E6CC
		//public void Hide() { }

		//// RVA: 0x185E748 Offset: 0x185E748 VA: 0x185E748
		//public void Show() { }

		// RVA: 0x185A760 Offset: 0x185A760 VA: 0x185A760
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlayingAll();
		}

		// RVA: 0x185E7C4 Offset: 0x185E7C4 VA: 0x185E7C4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			m_layoutRoot = layout.FindViewByExId("root_midasi_sw_midasi_in_anim") as AbsoluteLayout;
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
