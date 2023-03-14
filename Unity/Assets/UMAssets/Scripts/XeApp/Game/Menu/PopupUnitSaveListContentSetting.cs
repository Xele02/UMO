
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupUnitSaveListContentSetting : PopupSetting
	{
		public DFKGGBMFFGB_PlayerInfo ViewPlayerData { get; set; } // 0x34
		public bool ResetScrollPosition { get; set; } // 0x38
		public EEDKAACNBBG_MusicData MusicData { get; set; } // 0x3C
		public EJKBKMBJMGL_EnemyData EnemyData { get; set; } // 0x40
		public EAJCBFGKKFA_FriendInfo FriendData { get; set; } // 0x44
		public bool IsGoDiva { get; set; } // 0x48
		public override string PrefabPath { get { return ""; } } //0x11587BC
		public override string BundleName { get { return "ly/013.xab"; } } //0x1158820
		public override string AssetName { get { return "PopupUnitSaveListContent"; } } //0x115887C
		public override bool IsAssetBundle { get { return true; } } //0x11588D8
		public override bool IsPreload { get { return true; } } //0x11588E0
		public override GameObject Content { get { return m_content; } } //0x11588E8
	}
}
