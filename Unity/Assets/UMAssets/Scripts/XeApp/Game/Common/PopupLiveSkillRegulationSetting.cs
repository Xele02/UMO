
using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Menu;

namespace XeApp.Game.Common
{
	public class PopupLiveSkillRegulationSetting : PopupSetting
	{
		public override string PrefabPath { get { return ""; } } //0x1BAE69C
		public override string AssetName { get { return "root_skip_pop_02_layout_root"; } } //0x1BAE6F8
		public override string BundleName { get { return "ly/216.xab"; } } //0x1BAE754
		public override bool IsAssetBundle { get { return true; } } //0x1BAE7B0
		public override bool IsPreload { get { return true; } } //0x1BAE7B8
		public override GameObject Content { get { return m_content; } } //0x1BAE7C0
		public LayoutSkillRegulationWindow LayoutSkillRegulationWindow { get; set; } // 0x34
		public GCIJNCFDNON_SceneInfo ViewSceneData { get; set; } // 0x38
		public RegulationButton.Type SkillType { get; set; } // 0x3C

		//// RVA: 0x1BAE7C8 Offset: 0x1BAE7C8 VA: 0x1BAE7C8
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x73F98C Offset: 0x73F98C VA: 0x73F98C
		// RVA: 0x1BAE7E8 Offset: 0x1BAE7E8 VA: 0x1BAE7E8 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			//0x1BAE964
			m_parent = parent;
			yield return AssetBundleManager.LoadUnionAssetBundle(BundleName);
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			LayoutSkillRegulationWindow = m_content.GetComponent<LayoutSkillRegulationWindow>();
			while (!ISLoaded())
				yield return null;
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
		}

		//[CompilerGeneratedAttribute] // RVA: 0x73FA04 Offset: 0x73FA04 VA: 0x73FA04
		//[DebuggerHiddenAttribute] // RVA: 0x73FA04 Offset: 0x73FA04 VA: 0x73FA04
		//// RVA: 0x1BAE8B4 Offset: 0x1BAE8B4 VA: 0x1BAE8B4
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
