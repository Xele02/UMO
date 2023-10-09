
using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PlayerSearchPopupSetting : PopupSetting
	{
		public string myId { get; set; } // 0x34
		public string friendId { get; set; } // 0x38
		public string friendIdPlaceholder { get; set; } // 0x3C
		public Action<string> onClickCopyButton { get; set; } // 0x40
		public Action<string> onClickSearchButton { get; set; } // 0x44
		public override string PrefabPath { get { return ""; } } //0xDE6EC4
		public override string BundleName { get { return "ly/039.xab"; } } //0xDE6F20
		public override string AssetName { get { return "PopupPlayerSearch"; } } //0xDE6F7C
		public override bool IsAssetBundle { get { return true; } } //0xDE6FD8
		public override bool IsPreload { get { return true; } } //0xDE6FE0

		//// RVA: 0xDE6FE8 Offset: 0xDE6FE8 VA: 0xDE6FE8
		public void SetContent(GameObject obj)
		{
			m_content = obj;
		}
	}
}
