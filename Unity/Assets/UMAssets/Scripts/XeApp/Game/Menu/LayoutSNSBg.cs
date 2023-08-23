using System.Collections;
using System.Collections.Generic;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutSNSBg : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_root; // 0x14
		private AbsoluteLayout m_patternTbl; // 0x18
		private List<IEnumerator> m_animList = new List<IEnumerator>(); // 0x1C

		public bool IsOpen { get; private set; } // 0x20

		// RVA: 0x1D1C26C Offset: 0x1D1C26C VA: 0x1D1C26C
		public void SetStatus(int divaId)
		{
			m_patternTbl.StartChildrenAnimGoStop(divaId.ToString("D2"));
		}

		//// RVA: 0x1D1C270 Offset: 0x1D1C270 VA: 0x1D1C270
		//public void SetPatternTbl(int index) { }

		//// RVA: 0x1D1C300 Offset: 0x1D1C300 VA: 0x1D1C300
		public void In()
		{
			if (m_root == null)
				return;
			if (IsOpen)
				return;
			IsOpen = true;
			gameObject.SetActive(true);
			m_root.StartChildrenAnimGoStop("go_in", "st_in");
			m_animList.Clear();
		}

		//// RVA: 0x1D1C40C Offset: 0x1D1C40C VA: 0x1D1C40C
		//public void Update() { }

		//// RVA: 0x1D1C5A8 Offset: 0x1D1C5A8 VA: 0x1D1C5A8
		public void Out()
		{
			if (m_root == null || !IsOpen)
				return;
			IsOpen = false;
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
			m_animList.Clear();
			m_animList.Add(WaitAnimOut());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x727894 Offset: 0x727894 VA: 0x727894
		//// RVA: 0x1D1C6A4 Offset: 0x1D1C6A4 VA: 0x1D1C6A4
		private IEnumerator WaitAnimOut()
		{
			//0x1D1CAD8
			while (m_root != null && m_root.IsPlayingChildren())
				yield return null;
			gameObject.SetActive(false);
		}

		//// RVA: 0x1D1C750 Offset: 0x1D1C750 VA: 0x1D1C750
		//public void Show() { }

		//// RVA: 0x1D1C7F8 Offset: 0x1D1C7F8 VA: 0x1D1C7F8
		//public void Hide() { }

		//// RVA: 0x1D1C8A0 Offset: 0x1D1C8A0 VA: 0x1D1C8A0
		public bool IsPlaying()
		{
			if (m_root != null)
				return m_root.IsPlayingChildren();
			return false;
		}

		// RVA: 0x1D1C8B8 Offset: 0x1D1C8B8 VA: 0x1D1C8B8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_root.StartChildrenAnimGoStop("st_wait");
			m_patternTbl = layout.FindViewByExId("bg_dot_swtbl_sns_bg") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
