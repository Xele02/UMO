
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
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
			AssetBundleLoadUGUIOperationBase uguiOp; // 0x1C

			//0x16989F4
			m_parent = parent;
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			Layout = m_content.GetComponent<PopupMvModeLackDivaLayout>();
			GameObject obj = null;
			uguiOp = AssetBundleManager.LoadUGUIAsync(BundleName, "UGUI_LackDivaIconContent");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x1698914
				obj = instance;
				Layout.ScrollList.AddScrollObject(obj.GetComponent<SwapScrollListContent>());
			}));
			for(int i = 1; i < Layout.ScrollList.ScrollObjectCount; i++)
			{
				GameObject g = UnityEngine.Object.Instantiate(obj);
				Layout.ScrollList.AddScrollObject(g.GetComponent<SwapScrollListContent>());
			}
			Layout.ScrollList.Apply();
			yield return null;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x730834 Offset: 0x730834 VA: 0x730834
		//[DebuggerHiddenAttribute] // RVA: 0x730834 Offset: 0x730834 VA: 0x730834
		//// RVA: 0x1698904 Offset: 0x1698904 VA: 0x1698904
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
