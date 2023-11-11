
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class GachaRatePopupSetting : PopupSetting
	{
		public GCAHJLOGMCI.KNMMOMEHDON_GachaType Mode; // 0x48

		public List<GachaRateInfo> RarityInfoList { get; set; } // 0x34
		public List<GachaRateInfo> EpisodeInfoList { get; set; } // 0x38
		public Action<int> OnClickRewardButton { get; set; } // 0x3C
		public Action<int> OnClickStepButton { get; set; } // 0x40
		public LOBDIAABMKG Data { get; set; } // 0x44
		public override string PrefabPath { get { return ""; } } //0xEE5F48
		public override string BundleName { get { return "ly/068.xab"; } } //0xEE5FA4
		public override string AssetName { get { return "PopupGachaRate"; } } //0xEE6000
		public override bool IsAssetBundle { get { return true; } } //0xEE605C
		public override bool IsPreload { get { return true; } } //0xEE6064

		//// RVA: 0xEE606C Offset: 0xEE606C VA: 0xEE606C
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x7031F4 Offset: 0x7031F4 VA: 0x7031F4
		// RVA: 0xEE6074 Offset: 0xEE6074 VA: 0xEE6074 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			//0xEE6150
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			yield return Co.R(m_content.GetComponent<PopupGachaRate>().Co_LoadResources());
		}

		//[DebuggerHiddenAttribute] // RVA: 0x70326C Offset: 0x70326C VA: 0x70326C
		//[CompilerGeneratedAttribute] // RVA: 0x70326C Offset: 0x70326C VA: 0x70326C
		//// RVA: 0xEE6144 Offset: 0xEE6144 VA: 0xEE6144
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
