using System.Collections;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class OfferTouchLead : LayoutUGUIScriptBase
	{
		private const float LEAD_HIDE_WAIT_TIME = 2;
		private AbsoluteLayout m_layoutRoot; // 0x14
		private bool IsEndAnimLoop; // 0x18
		private bool IsLeave; // 0x19

		// RVA: 0x1711A10 Offset: 0x1711A10 VA: 0x1711A10
		private void Start()
		{
			return;
		}

		// RVA: 0x1711A14 Offset: 0x1711A14 VA: 0x1711A14
		private void Update()
		{
			return;
		}

		//// RVA: 0x1711A18 Offset: 0x1711A18 VA: 0x1711A18
		//public void animStart() { }

		//// RVA: 0x1711AA4 Offset: 0x1711AA4 VA: 0x1711AA4
		public void AnimLoopStart()
		{
			IsEndAnimLoop = false;
			IsLeave = false;
			this.StartCoroutineWatched(Co_AnimLoop());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FC7FC Offset: 0x6FC7FC VA: 0x6FC7FC
		// RVA: 0x1711AD4 Offset: 0x1711AD4 VA: 0x1711AD4
		private IEnumerator Co_AnimLoop()
		{
			//0x1711E50
			while (true)
			{
				if (IsEndAnimLoop)
					yield break;
				m_layoutRoot.StartChildrenAnimGoStop("st_out", "go_out");
				IsLeave = false;
				yield return null;
				while (m_layoutRoot.IsPlayingChildren())
					yield return null;
				if (IsEndAnimLoop)
					yield break;
				yield return Co.R(KDHGBOOECKC.HHCJCDFCLOB.FMGMIKPJNKG_Co_wait(2, false, null));
				if (IsEndAnimLoop)
					yield break;
				m_layoutRoot.StartAllAnimGoStop("go_out", "st_out");
				IsLeave = true;
				yield return null;
				while (m_layoutRoot.IsPlayingChildren())
					yield return null;
				if (IsEndAnimLoop)
					yield break;
				yield return Co.R(KDHGBOOECKC.HHCJCDFCLOB.FMGMIKPJNKG_Co_wait(2, false, null));
			}
		}

		// RVA: 0x1711B80 Offset: 0x1711B80 VA: 0x1711B80
		public void Leave()
		{
			if(!IsEndAnimLoop && !IsLeave)
			{
				m_layoutRoot.StartAllAnimGoStop("go_out", "st_out");
				IsLeave = true;
			}
			IsEndAnimLoop = true;
		}

		//// RVA: 0x1711C34 Offset: 0x1711C34 VA: 0x1711C34
		//public void Hide() { }

		//// RVA: 0x1711CB0 Offset: 0x1711CB0 VA: 0x1711CB0
		//public void Show() { }

		//// RVA: 0x1711D2C Offset: 0x1711D2C VA: 0x1711D2C
		//public bool IsPlaying() { }

		// RVA: 0x1711D58 Offset: 0x1711D58 VA: 0x1711D58 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_sel_vfo_notice_sw_sel_val_notice_anim") as AbsoluteLayout;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
