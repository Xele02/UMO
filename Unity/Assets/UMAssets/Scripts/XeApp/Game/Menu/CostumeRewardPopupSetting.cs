
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class CostumeRewardPopupSetting : PopupSetting
	{
		public LFAFJCNKLML CostumeData { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } //0x163A390
		public override string BundleName { get { return "ly/128.xab"; } } //0x163A3EC
		public override string AssetName { get { return "PopupCostumeReward"; } } //0x163A448
		public override bool IsAssetBundle { get { return true; } } //0x163A4A4
		public override bool IsPreload { get { return true; } } //0x163A4AC
		public override GameObject Content { get { return m_content; } } //0x163A4B4

		//// RVA: 0x163A4BC Offset: 0x163A4BC VA: 0x163A4BC
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CF724 Offset: 0x6CF724 VA: 0x6CF724
		//// RVA: 0x163A4C4 Offset: 0x163A4C4 VA: 0x163A4C4 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			//0x163A5A0
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			yield return Co.R(m_content.GetComponent<CostumeRewardWindow>().CreateItemIcon(CostumeData.LLLCMHENKKN_LevelMax));
		}

		//[CompilerGeneratedAttribute] // RVA: 0x6CF79C Offset: 0x6CF79C VA: 0x6CF79C
		//[DebuggerHiddenAttribute] // RVA: 0x6CF79C Offset: 0x6CF79C VA: 0x6CF79C
		//// RVA: 0x163A594 Offset: 0x163A594 VA: 0x163A594
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
