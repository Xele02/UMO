
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class SceneSelectHomeBgSetting : PopupSetting // TypeDefIndex: 16168
    {
        public SceneSelectHomeBgLayout.SetBgType BgType { get; set; } // 0x34
        public GCIJNCFDNON_SceneInfo SceneData { get; set; } // 0x38
        public GCIJNCFDNON_SceneInfo HomeBgSceneData { get; set; } // 0x3C
        public int SceneBgRare { get; set; } // 0x40
        public SceneSelectHomeBgLayout SceneSelectHomeBgLayout { get; set; } // 0x44
        public override string PrefabPath { get { return ""; } } //0x137A870
        public override string BundleName { get { return "ly/014.xab"; } } //0x137A8CC
        public override string AssetName { get { return "root_sel_card_bg_select_layout_root"; } } //0x137A928
        public override bool IsAssetBundle { get { return true; } } //0x137A984
        public override bool IsPreload { get { return true; } } //0x137A98C
        public override GameObject Content { get { return m_content; } } //0x137A994

        // // RVA: 0x137A99C Offset: 0x137A99C VA: 0x137A99C
        // public void SetContent(GameObject obj) { }

        // [IteratorStateMachineAttribute] // RVA: 0x72DD8C Offset: 0x72DD8C VA: 0x72DD8C
        // // RVA: 0x137A9A4 Offset: 0x137A9A4 VA: 0x137A9A4 Slot: 4
        public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			TodoLogger.LogError(0, "LoadAssetBundlePrefab");
			yield return base.LoadAssetBundlePrefab(parent);
		}

        // [CompilerGeneratedAttribute] // RVA: 0x72DE04 Offset: 0x72DE04 VA: 0x72DE04
        // [DebuggerHiddenAttribute] // RVA: 0x72DE04 Offset: 0x72DE04 VA: 0x72DE04
        // // RVA: 0x137AA74 Offset: 0x137AA74 VA: 0x137AA74
        // private IEnumerator <>n__0(Transform parent) { }
    }
}
