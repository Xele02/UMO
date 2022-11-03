
using UnityEngine;

namespace XeApp.Game.Common
{
	public class TextPopupSetting : PopupSetting
	{
		public TextAnchor Alignment = TextAnchor.MiddleCenter; // 0x3C

		public bool Scrollable { get; set; } // 0x34
		public string Text { get; set; } // 0x38
		public override string PrefabPath { get { return "Menu/Prefab/PopupWindow/TextContent"; } } //0x1CCED30
	}
}
