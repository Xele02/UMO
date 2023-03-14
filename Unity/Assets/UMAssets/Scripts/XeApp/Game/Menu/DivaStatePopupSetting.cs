
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class DivaStatePopupSetting : PopupSetting
	{
		public FFHPBEPOMAK_DivaInfo Diva { get; set; } // 0x34
		public int DivaSlotIndex { get; set; } // 0x38
		public DFKGGBMFFGB_PlayerInfo PlayerData { get; set; } // 0x3C
		public EAJCBFGKKFA_FriendInfo FriendData { get; set; } // 0x40
		public EEDKAACNBBG_MusicData MusicData { get; set; } // 0x44
		public bool IsFriend { get; set; } // 0x48
		public bool IsChangeScene { get; set; } // 0x49
		public bool IsGoDiva { get; set; } // 0x4A
		public override string PrefabPath { get { return "Menu/Prefab/PopupWindow/PopupDivaState"; } } //0x1266ED8
		public override string BundleName { get { return "ly/016.xab"; } } //0x1266F34
		public override string AssetName { get { return "PopupDivaState"; } } //0x1266F90
		public override bool IsAssetBundle { get { return true; } } //0x1266FEC
		public override bool IsPreload { get { return true; } } //0x1266FF4
		public override GameObject Content { get { return m_content; } } //0x1266FFC

		//// RVA: 0x1267004 Offset: 0x1267004 VA: 0x1267004
		//public void SetContent(GameObject obj) { }
	}
}
