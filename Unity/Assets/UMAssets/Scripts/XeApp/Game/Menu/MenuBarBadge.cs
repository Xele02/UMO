using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class MenuBarBadge : LayoutUGUIScriptBase
	{
		[SerializeField] // RVA: 0x66AFF8 Offset: 0x66AFF8 VA: 0x66AFF8
		private Text m_text; // 0x14
		[SerializeField] // RVA: 0x66B008 Offset: 0x66B008 VA: 0x66B008
		private LayoutUGUIRuntime m_runtime; // 0x18

		public LayoutUGUIRuntime runtime { get { return m_runtime; } } //0xEC3518

		// // RVA: 0xEC3520 Offset: 0xEC3520 VA: 0xEC3520
		// public void Set(BadgeConstant.ID id, string text) { }

		// // RVA: 0xEC379C Offset: 0xEC379C VA: 0xEC379C
		public void Initialize(GameObject parent, AbsoluteLayout parentLayout)
		{
			transform.SetParent(parent.transform, false);
			transform.SetAsLastSibling();
			if(parentLayout == null)
				return;
			parentLayout.AddView(m_runtime.Layout.Root);
		}

		// // RVA: 0xEC3890 Offset: 0xEC3890 VA: 0xEC3890 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			Loaded();
			return true;
		}
	}
}
