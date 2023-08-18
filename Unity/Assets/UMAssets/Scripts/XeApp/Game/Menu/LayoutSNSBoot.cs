using mcrs;
using System.Collections;
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutSNSBoot : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_root; // 0x14
		private AbsoluteLayout m_logoAnim; // 0x18
		private List<IEnumerator> m_animList = new List<IEnumerator>(4); // 0x1C

		public bool IsOpen { get; private set; } // 0x20

		// RVA: 0x1D1CC24 Offset: 0x1D1CC24 VA: 0x1D1CC24
		public void Update()
		{
			for(int i = 0; i < m_animList.Count; i++)
			{
				if(m_animList[i] != null)
				{
					if (!m_animList[i].MoveNext())
						m_animList[i] = null;
				}
			}
		}

		//// RVA: 0x1D1CDC0 Offset: 0x1D1CDC0 VA: 0x1D1CDC0
		public void In()
		{
			if (m_root == null || m_logoAnim == null)
				return;
			if (IsOpen)
				return;
			IsOpen = true;
			gameObject.SetActive(true);
			m_root.StartChildrenAnimGoStop("go_in", "st_in");
			m_logoAnim.StartChildrenAnimGoStop("go_in", "st_in");
			m_animList.Clear();
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SNS_001);
		}

		//// RVA: 0x1D1CF60 Offset: 0x1D1CF60 VA: 0x1D1CF60
		//public void Out() { }

		//[IteratorStateMachineAttribute] // RVA: 0x72797C Offset: 0x72797C VA: 0x72797C
		//// RVA: 0x1D1D088 Offset: 0x1D1D088 VA: 0x1D1D088
		//private IEnumerator WaitAnimOut() { }

		//// RVA: 0x1D1D134 Offset: 0x1D1D134 VA: 0x1D1D134
		public bool IsPlaying()
		{
			if(m_root != null && m_logoAnim != null)
			{
				return m_root.IsPlayingChildren() || m_logoAnim.IsPlayingChildren();
			}
			return false;
		}

		// RVA: 0x1D1D190 Offset: 0x1D1D190 VA: 0x1D1D190 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_root.StartChildrenAnimGoStop("st_wait");
			m_logoAnim = layout.FindViewByExId("sw_start_sns_anim_sw_start_sns_logo_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
