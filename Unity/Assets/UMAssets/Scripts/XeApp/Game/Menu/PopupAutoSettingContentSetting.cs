
using UnityEngine;
using UnityEngine.Events;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupAutoSettingContentSetting : PopupSetting
	{
		public PopupAutoSettingContent.Place Place { get; set; } // 0x34
		public DFKGGBMFFGB_PlayerInfo PlayerData { get; set; } // 0x38
		public UnityAction<PopupAutoSettingContent> OkCallBack { get; set; } // 0x3C
		public UnityAction ClearPlateCallBack { get; set; } // 0x40
		public UnityAction<PopupTabButton.ButtonLabel> TabCallBack { get; set; } // 0x44
		public bool IsGoDviva { get; set; } // 0x48
		public int MusicAttribute { get; set; } // 0x4C
		public int MusicSeries { get; set; } // 0x50
		public int MusicID { get; set; } // 0x54
		public KLBKPANJCPL_Score ScoreInfo { get; set; } // 0x58
		public override string PrefabPath { get { return ""; } } //0x1339DB8
		public override string BundleName { get { return "ly/013.xab"; } } //0x1339E1C
		public override string AssetName { get { return "AutoSetPanel"; } } //0x1339E78
		public override bool IsAssetBundle { get { return true; } } //0x1339ED4
		public override bool IsPreload { get { return true; } } //0x1339EDC
		public override GameObject Content { get { return m_content; } } //0x1339EE4
	}
}
