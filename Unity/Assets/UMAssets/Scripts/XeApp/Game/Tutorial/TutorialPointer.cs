using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Tutorial
{
	public class TutorialPointer : LayoutUGUIScriptBase
	{
		public enum Direction
		{
			Normal = 1,
			UP = 2,
			Down = 3,
		}

		private AbsoluteLayout m_cursorLayer; // 0x14
		private AbsoluteLayout m_rootLayer; // 0x18
		private RectTransform m_rectTransform; // 0x1C

		//public RectTransform RectTransform { get; } 0xE41178

		// RVA: 0xE499C4 Offset: 0xE499C4 VA: 0xE499C4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_cursorLayer = layout.FindViewByExId("sw_cmn_tuto_icon01_anim_cmn_tuto_icon_01") as AbsoluteLayout;
			m_rootLayer = layout.FindViewByExId("root_cmn_tuto_finger_cmn_tuto_icon01") as AbsoluteLayout;
			ClearLoadedCallback();
			return true;
		}

		//// RVA: 0xE41540 Offset: 0xE41540 VA: 0xE41540
		//public void Show(Vector3 localPosition, TutorialPointer.Direction dir) { }

		//// RVA: 0xE4122C Offset: 0xE4122C VA: 0xE4122C
		//public void ShowAnchorPosition(Vector3 localPosition, TutorialPointer.Direction dir) { }

		//// RVA: 0xE49B14 Offset: 0xE49B14 VA: 0xE49B14
		//public void Hide() { }
	}
}
