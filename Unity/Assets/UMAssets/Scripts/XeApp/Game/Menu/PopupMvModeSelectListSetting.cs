
using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
    public class PopupMvModeSelectListSetting : PopupSetting // TypeDefIndex: 16406
    {
        public PopupMvModeSelectListContent.SelectTarget SelectTarget { get; set; } // 0x34
        public int SelectIndex { get; set; } // 0x38
        public int MusicId { get; set; } // 0x3C
        public override string PrefabPath { get { return ""; } } //0x169C3B4
        public override string BundleName { get { return "ly/104.xab"; } } //0x169C410
        public override string AssetName { get { return "MvModeSelectListContent"; } } //0x169C46C
        public override bool IsAssetBundle { get { return true; } } //0x169C4C8
        public override bool IsPreload { get { return true; } } //0x169C4D0
        public override GameObject Content { get { return m_content; } }// 0x169C4D8

        // // RVA: 0x169C4E0 Offset: 0x169C4E0 VA: 0x169C4E0
        // public void SetContent(GameObject content) { }

        // [IteratorStateMachineAttribute] // RVA: 0x730A64 Offset: 0x730A64 VA: 0x730A64
        // // RVA: 0x169C4E8 Offset: 0x169C4E8 VA: 0x169C4E8 Slot: 4
        public override IEnumerator LoadAssetBundlePrefab(Transform parent)
        {
            //0x169C648
            AssetBundleLoadLayoutOperationBase listItemOp;

            yield return AssetBundleManager.LoadUnionAssetBundle(BundleName);
            yield return base.LoadAssetBundlePrefab(parent);
            LayoutUGUIRuntime sourceRunTime = null;
            listItemOp = AssetBundleManager.LoadLayoutAsync(BundleName, "root_pop_simu_icon_layout_root");
            yield return listItemOp;
            yield return listItemOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject inst) => {
                //0x169C5C8
                sourceRunTime = inst.GetComponent<LayoutUGUIRuntime>();
            });
            m_content.gameObject.SetActive(true);
            m_content.GetComponent<PopupMvModeSelectListContent>().InitializeObject(sourceRunTime.GetComponent<LayoutUGUIRuntime>(), 10);
            yield return null;
            UnityEngine.Object.Destroy(sourceRunTime.gameObject);
            m_content.gameObject.SetActive(false);
            listItemOp = null;
            AssetBundleManager.UnloadAssetBundle(BundleName);
        }

        // [CompilerGeneratedAttribute] // RVA: 0x730ADC Offset: 0x730ADC VA: 0x730ADC
        // [DebuggerHiddenAttribute] // RVA: 0x730ADC Offset: 0x730ADC VA: 0x730ADC
        // // RVA: 0x169C5B8 Offset: 0x169C5B8 VA: 0x169C5B8
        // private IEnumerator <>n__0(Transform parent) { }
    }
}