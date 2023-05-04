
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupMvModeLackDivaSetting : PopupSettingUGUI
	{
		public override string PrefabPath { get { return ""; } } //0x16986F0
		public override string AssetName { get { return "UGUI_MvModeLackDivaContent"; } } //0x169874C
		public override string BundleName { get { return "ly/104.xab"; } } //0x16987A8
		public override bool IsAssetBundle { get { return true; } } //0x1698804
		public override bool IsPreload { get { return true; } } //0x169880C
		public override GameObject Content { get { return m_content; } } //0x1698814
		public PopupMvModeLackDivaLayout Layout { get; set; } // 0x34
		public List<int> DivaIds { get; set; } // 0x38

		// RVA: 0x169881C Offset: 0x169881C VA: 0x169881C
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x7307BC Offset: 0x7307BC VA: 0x7307BC
		// RVA: 0x1698834 Offset: 0x1698834 VA: 0x1698834 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			TodoLogger.Log(0, "LoadAssetBundlePrefab");
			yield return null;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x730834 Offset: 0x730834 VA: 0x730834
		//[DebuggerHiddenAttribute] // RVA: 0x730834 Offset: 0x730834 VA: 0x730834
		//// RVA: 0x1698904 Offset: 0x1698904 VA: 0x1698904
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
