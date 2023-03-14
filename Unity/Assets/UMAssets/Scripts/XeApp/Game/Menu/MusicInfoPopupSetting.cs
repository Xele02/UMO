
using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class MusicInfoPopupSetting : PopupSetting
	{
		public int musicId { get; set; } // 0x34
		public bool flameDisplay { get; set; } // 0x38
		public bool isValidMusicUrl { get; set; } // 0x39
		public Action onClickMusicButton { get; set; } // 0x3C
		public override string PrefabPath { get { return ""; } } //0x104A368
		public override string BundleName { get { return "ly/041.xab"; } } //0x104A3C4
		public override string AssetName { get { return "PopupMusicInfo"; } } //0x104A420
		public override bool IsAssetBundle { get { return true; } } //0x104A47C
		public override bool IsPreload { get { return true; } } //0x104A484
		public override GameObject Content { get { return m_content; } } //0x104A48C

		//// RVA: 0x104A494 Offset: 0x104A494 VA: 0x104A494
		//public void SetContent(GameObject obj) { }
	}
}
