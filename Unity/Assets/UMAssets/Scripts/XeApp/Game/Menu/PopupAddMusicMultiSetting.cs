using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupAddMusicMultiSetting : PopupSetting
	{
		public PopupUnlock.UnlockInfo UnlockInfo { get; set; } // 0x34
		public override string BundleName { get { return "ly/047.xab"; } } //0x1331624
		public override string AssetName { get { return "root_pop_music_ul_window_layout_root"; } } //0x1331680
		//public virtual string ListItemAssetName { get; } 0x13316DC
		public override string PrefabPath { get { return ""; } } //0x1331738
		public override bool IsAssetBundle { get { return true; } } //0x1331794
		public override bool IsPreload { get { return false; } } //0x133179C
		public override GameObject Content { get { return m_content; } } //0x13317A4

		//// RVA: 0x13317AC Offset: 0x13317AC VA: 0x13317AC
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70FE3C Offset: 0x70FE3C VA: 0x70FE3C
		//// RVA: 0x13317B4 Offset: 0x13317B4 VA: 0x13317B4 Slot: 4
		//public override IEnumerator LoadAssetBundlePrefab(Transform parent) { }

		//[DebuggerHiddenAttribute] // RVA: 0x70FEB4 Offset: 0x70FEB4 VA: 0x70FEB4
		//[CompilerGeneratedAttribute] // RVA: 0x70FEB4 Offset: 0x70FEB4 VA: 0x70FEB4
		//// RVA: 0x133187C Offset: 0x133187C VA: 0x133187C
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
