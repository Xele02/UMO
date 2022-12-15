
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupTabSetting : PopupSetting
	{
		public override string PrefabPath { get { return "Menu/Prefab/PopupWindow/PopupTabContents"; } } //0x1154408
		public override string BundleName { get { return ""; } } //0x1154464
		public override string AssetName { get { return "PopupTabContents"; } } //0x11544C0
		public override bool IsAssetBundle { get { return false; } } //0x115451C
		public override bool IsPreload { get { return true; } } //0x1154524
		public override GameObject Content { get { return m_content; } } //0x115452C

		// RVA: 0x1154534 Offset: 0x1154534 VA: 0x1154534
		public void SetContent(GameObject obj)
		{
			m_content = obj;
		}
	}
}
