using System.Collections;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutOfferBoot : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_root; // 0x14
		private AbsoluteLayout m_logoAnim; // 0x18
		private bool IsStartLeave; // 0x1D
		public bool IsStartEnd; // 0x1E

		public bool IsOpen { get; private set; } // 0x1C

		// RVA: 0x15D036C Offset: 0x15D036C VA: 0x15D036C
		public void Update()
		{
			return;
		}

		// RVA: 0x15D0370 Offset: 0x15D0370 VA: 0x15D0370
		public void In()
		{
			if(m_root != null && m_logoAnim != null && !IsOpen)
			{
				IsOpen = false;
				gameObject.SetActive(true);
				m_root.StartChildrenAnimGoStop("go_in", "st_in");
				m_logoAnim.StartChildrenAnimGoStop("go_in", "st_in");
				IsStartLeave = false;
				IsStartEnd = false;
				this.StartCoroutineWatched(StartEnd());
			}
		}

		//// RVA: 0x15D0544 Offset: 0x15D0544 VA: 0x15D0544
		public void Loop()
		{
			m_root.StartChildrenAnimLoop("logo_act");
			m_logoAnim.StartChildrenAnimLoop("logo_act");
		}

		// RVA: 0x15D05F0 Offset: 0x15D05F0 VA: 0x15D05F0
		public void Out()
		{
			if(m_root != null && m_logoAnim != null && IsOpen)
			{
				IsOpen = false;
				m_root.StartChildrenAnimGoStop("st_wait");
				m_logoAnim.StartChildrenAnimGoStop("st_wait");
				IsStartLeave = true;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F7BA4 Offset: 0x6F7BA4 VA: 0x6F7BA4
		//// RVA: 0x15D04B8 Offset: 0x15D04B8 VA: 0x15D04B8
		private IEnumerator StartEnd()
		{
			//0x15D08F8
			yield return null;
			while (true)
			{
				if (!IsPlaying())
				{
					IsStartEnd = true;
					Loop();
					break;
				}
				else if (!IsStartLeave)
					yield return null;
			}
		}

		// RVA: 0x15D06D4 Offset: 0x15D06D4 VA: 0x15D06D4
		public bool IsPlaying()
		{
			return m_root != null && m_logoAnim != null && (m_root.IsPlayingChildren() || m_logoAnim.IsPlaying());
		}

		// RVA: 0x15D0730 Offset: 0x15D0730 VA: 0x15D0730 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root as AbsoluteLayout;
			m_root.StartChildrenAnimGoStop("st_wait");
			m_logoAnim = layout.FindViewByExId("sw_start_vfo_anim_sw_start_sns_logo_anim") as AbsoluteLayout;
			m_logoAnim.StartChildrenAnimGoStop("st_wait");
			Loaded();
			return true;
		}
	}
}
