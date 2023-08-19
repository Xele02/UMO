
using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupUseItemSetting : PopupSetting
	{
		public MNDAMOGGJBJ ViewGrowItemData { get; set; } // 0x34
		public UseItemList.LackReason Reason { get; set; } // 0x38
		public UseItemList.Unlock Unlock { get; set; } // 0x3C
		public bool IsValidate { get; set; } // 0x40
		public override string PrefabPath { get { return ""; } } //0x1160320
		public override string BundleName { get { return "ly/097.xab"; } } //0x116037C
		public override string AssetName { get { return "root_pop_useitem_mask_layout_root"; } } //0x11603D8
		public override bool IsPreload { get { return true; } } //0x1160434
		public override bool IsAssetBundle { get { return true; } } //0x116043C
		public override GameObject Content { get { return m_content; } } //0x1160444

		//[IteratorStateMachineAttribute] // RVA: 0x73353C Offset: 0x73353C VA: 0x73353C
		//// RVA: 0x116044C Offset: 0x116044C VA: 0x116044C Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			//0x1160528
			yield return AssetBundleManager.LoadUnionAssetBundle(BundleName);
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			yield return Co.R(m_content.GetComponent<PopupUseItem>().LoadAppendLayoutCoroutine());
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
		}

		//[DebuggerHiddenAttribute] // RVA: 0x7335B4 Offset: 0x7335B4 VA: 0x7335B4
		//[CompilerGeneratedAttribute] // RVA: 0x7335B4 Offset: 0x7335B4 VA: 0x7335B4
		//// RVA: 0x116051C Offset: 0x116051C VA: 0x116051C
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
