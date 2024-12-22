
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.MusicSelect;

namespace XeApp.Game.Menu
{ 
	public class PopupMusicBookMarkMusicListSetting : PopupSettingUGUI
	{
		public override string PrefabPath { get { return ""; } } //0x1692E14
		public override string AssetName { get { return "PopupMusicBookMarkMusicListContent"; } } //0x1692E70
		public override string BundleName { get { return "ly/038.xab"; } } //0x1692ECC
		public override bool IsAssetBundle { get { return true; } } //0x1692F28
		public override bool IsPreload { get { return true; } } //0x1692F30
		public override GameObject Content { get { return m_content; } } //0x1692F38
		public PopupMusicBookMarkMusicListContentLayout Layout { get; set; } // 0x34
		public int BookMarkSelectIndex { get; set; } // 0x38
		public List<VerticalMusicDataList> VerticalMusicDataList { get; set; } // 0x3C

		//// RVA: 0x1692F40 Offset: 0x1692F40 VA: 0x1692F40
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6F56AC Offset: 0x6F56AC VA: 0x6F56AC
		// RVA: 0x1692F50 Offset: 0x1692F50 VA: 0x1692F50 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			AssetBundleLoadUGUIOperationBase uguiOp; // 0x1C

			//0x16930FC
			m_parent = parent;
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			Layout = m_content.GetComponent<PopupMusicBookMarkMusicListContentLayout>();
			GameObject obj = null;
			uguiOp = AssetBundleManager.LoadUGUIAsync(BundleName, "PopupMusicBookMarkMusicListContent_ScrollItem");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x1693028
				obj = instance;
				Layout.ScrollList.AddScrollObject(UnityEngine.Object.Instantiate(obj).GetComponent<SwapScrollListContent>());
			}));
			for(int i = Layout.ScrollList.ScrollObjectCount - 1; i > 0; i--)
			{
				Layout.ScrollList.AddScrollObject(UnityEngine.Object.Instantiate(obj).GetComponent<SwapScrollListContent>());
			}
			Layout.ScrollList.Apply();
			yield return null;
		}

		//[DebuggerHiddenAttribute] // RVA: 0x6F5724 Offset: 0x6F5724 VA: 0x6F5724
		//[CompilerGeneratedAttribute] // RVA: 0x6F5724 Offset: 0x6F5724 VA: 0x6F5724
		//// RVA: 0x1693018 Offset: 0x1693018 VA: 0x1693018
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
