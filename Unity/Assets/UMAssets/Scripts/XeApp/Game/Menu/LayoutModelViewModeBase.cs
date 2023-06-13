using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutModelViewModeBase : LayoutUGUIScriptBase
	{
		private Layout m_Layout; // 0x14
		protected AbsoluteLayout m_Anim; // 0x18
		protected ActionButton m_Button; // 0x1C
		private bool m_IsEntered; // 0x20

		// RVA: 0x1D69FEC Offset: 0x1D69FEC VA: 0x1D69FEC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_Layout = layout;
			OnInitializeFromLayout(layout, uvMan);
			Loaded();
			return true;
		}

		//// RVA: 0x1D6A024 Offset: 0x1D6A024 VA: 0x1D6A024 Slot: 6
		protected virtual void OnInitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			return;
		}

		//// RVA: 0x1D6A028 Offset: 0x1D6A028 VA: 0x1D6A028
		protected void Initialize(string anim_id)
		{
			m_Anim = m_Layout.FindViewByExId(anim_id) as AbsoluteLayout;
			m_Button = GetComponentInChildren<ActionButton>(true);
		}

		//// RVA: 0x1D6A108 Offset: 0x1D6A108 VA: 0x1D6A108 Slot: 7
		public virtual bool IsReady()
		{
			return IsLoaded() && GetComponent<LayoutUGUIRuntime>().IsReady;
		}

		//// RVA: 0x1D6A1A4 Offset: 0x1D6A1A4 VA: 0x1D6A1A4 Slot: 8
		public virtual bool IsPlaying()
		{
			return m_Anim.IsPlayingChildren();
		}

		//// RVA: 0x1D6A1D0 Offset: 0x1D6A1D0 VA: 0x1D6A1D0
		public bool IsEntered()
		{
			return m_IsEntered;
		}

		//// RVA: 0x1D6A1D8 Offset: 0x1D6A1D8 VA: 0x1D6A1D8 Slot: 9
		public virtual void Enter()
		{
			if (m_IsEntered)
				return;
			m_Anim.StartChildrenAnimGoStop("go_in", "st_in");
			m_IsEntered = true;
		}

		//// RVA: 0x1D6A278 Offset: 0x1D6A278 VA: 0x1D6A278 Slot: 10
		public virtual void Leave()
		{
			if (!m_IsEntered)
				return;
			m_Anim.StartChildrenAnimGoStop("go_out", "st_out");
			m_IsEntered = false;
		}

		//// RVA: 0x1D6A318 Offset: 0x1D6A318 VA: 0x1D6A318
		public ActionButton GetButton()
		{
			return m_Button;
		}

		//// RVA: 0x1D6A320 Offset: 0x1D6A320 VA: 0x1D6A320 Slot: 11
		public virtual void SetEnableHit(bool a_enable)
		{
			return;
		}
	}
}
