
using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupDecoOptionSetting : PopupSetting
	{
		private LayoutPopupConfigDeco m_layoutPopupConfigDeco; // 0x34

		public override string PrefabPath { get { return ""; } } //0x1346E64
		public override string BundleName { get { return "ly/211.xab"; } } //0x1346EC0
		public override string AssetName { get { return "UI_DecoConfig"; } } //0x1346F1C
		public override bool IsAssetBundle { get { return true; } } //0x1346F78
		public override bool IsPreload { get { return true; } } //0x1346F80
		public override GameObject Content { get { return m_content; } } //0x1346F88
		public LayoutPopupConfigDeco LayoutPopupConfigDeco { get { return m_layoutPopupConfigDeco; } } //0x1346D28
		public MDDBFCFOKFC DecorationLocalSaveData { get; set; } // 0x38

		//// RVA: 0x1346F90 Offset: 0x1346F90 VA: 0x1346F90
		//public void SetContent(GameObject content) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D14A4 Offset: 0x6D14A4 VA: 0x6D14A4
		// RVA: 0x1346FA0 Offset: 0x1346FA0 VA: 0x1346FA0 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			//0xF7801C
			m_parent = parent;
			AssetBundleManager.LoadUnionAssetBundle(BundleName);
			yield return null;
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			m_layoutPopupConfigDeco = m_content.GetComponent<LayoutPopupConfigDeco>();
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			while (!m_layoutPopupConfigDeco.IsLoad())
				yield return null;
			yield return null;
		}

		//[DebuggerHiddenAttribute] // RVA: 0x6D151C Offset: 0x6D151C VA: 0x6D151C
		//[CompilerGeneratedAttribute] // RVA: 0x6D151C Offset: 0x6D151C VA: 0x6D151C
		//// RVA: 0x134704C Offset: 0x134704C VA: 0x134704C
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
