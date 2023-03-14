
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public enum ConfirmType
	{
		Save = 0,
		Load = 1,
	}
	public class PopupUnitSaveConfirmContentSetting : PopupSetting
	{
		public ConfirmType ConfirmType { get; set; } // 0x34
		public DFKGGBMFFGB_PlayerInfo PlayerData { get; set; } // 0x38
		public int TargetUnitId { get; set; } // 0x3C
		public EEDKAACNBBG_MusicData MusicData { get; set; } // 0x40
		public EJKBKMBJMGL_EnemyData EnemyData { get; set; } // 0x44
		public EAJCBFGKKFA_FriendInfo FriendData { get; set; } // 0x48
		public bool IsGoDiva { get; set; } // 0x4C
		public override string PrefabPath { get { return ""; } } //0x1156958
		public override string BundleName { get { return "ly/013.xab"; } } //0x11569BC
		public override string AssetName { get { return "PopupUnitSaveConfirmContent"; } } //0x1156A18
		public override bool IsAssetBundle { get { return true; } } //0x1156A74
		public override bool IsPreload { get { return true; } } //0x1156A7C
		public override GameObject Content { get { return m_content; } } //0x1156A84
	}
}
