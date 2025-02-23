
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
    public class PopupExBattleScheduleSetting : PopupSetting
    {
        public LayoutPopupExBattleScheduleListWindow layout; // 0x38

        public CDDODEHEKGB View { get; set; } // 0x34
        public override string PrefabPath { get { return ""; } } //0xF8D428
        public override string BundleName { get { return "ly/122.xab"; } } //0xF8D484
        public override string AssetName { get { return "root_pop_ex_btl_window_01_layout_root"; } } //0xF8D4E0
        public override bool IsAssetBundle { get { return true; } } //0xF8D53C
        public override bool IsPreload { get { return false; } } //0xF8D544
        public override GameObject Content { get { return m_content; } } //0xF8D54C

        // // RVA: 0xF8D554 Offset: 0xF8D554 VA: 0xF8D554
        // public void SetContent(GameObject obj) { }

        // [IteratorStateMachineAttribute] // RVA: 0x70303C Offset: 0x70303C VA: 0x70303C
        // RVA: 0xF8D55C Offset: 0xF8D55C VA: 0xF8D55C Slot: 4
        public override IEnumerator LoadAssetBundlePrefab(Transform parent)
        {
            FontInfo systemFont; // 0x1C
            int poolSize; // 0x20
            AssetBundleLoadLayoutOperationBase operation; // 0x24
            List<SwapScrollListContent> contentList; // 0x28
            int i; // 0x2C

            //0xF8D7C4
            yield return AssetBundleManager.LoadUnionAssetBundle(BundleName.ToString());
            yield return Co.R(base.LoadAssetBundlePrefab(parent));
            layout = m_content.GetComponent<LayoutPopupExBattleScheduleListWindow>();
            systemFont = GameManager.Instance.GetSystemFont();
            poolSize = layout.List.ScrollObjectCount;
            operation = AssetBundleManager.LoadLayoutAsync(BundleName.ToString(), "root_pop_ex_btl_list_01_layout_root");
            yield return operation;
            LayoutUGUIRuntime baseRuntime = null;
            yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
            {
                //0xF8D63C
                baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
                baseRuntime.name = baseRuntime.name.Replace("(Clone)", "_00");
                layout.List.AddScrollObject(instance.GetComponent<SwapScrollListContent>());
            }));
            AssetBundleManager.UnloadAssetBundle(BundleName.ToString(), false);
            contentList = new List<SwapScrollListContent>();
            for(i = 1; i < poolSize; i++)
            {
                LayoutUGUIRuntime runtime = Object.Instantiate(baseRuntime);
                runtime.name = baseRuntime.name.Replace("00", i.ToString("D2"));
                runtime.IsLayoutAutoLoad = false;
                runtime.Layout = baseRuntime.Layout.DeepClone();
                runtime.UvMan = baseRuntime.UvMan;
                runtime.LoadLayout();
                contentList.Add(runtime.GetComponent<SwapScrollListContent>());
            }
            AssetBundleManager.UnloadAssetBundle(BundleName.ToString(), false);
            while(!layout.IsLoaded())
                yield return null;
            for(i = 0; i < contentList.Count; i++)
            {
                while(!contentList[i].IsLoaded())
                    yield return null;
                layout.List.AddScrollObject(contentList[i]);
            }
            layout.List.Apply();
            layout.List.SetContentEscapeMode(true);
        }

        // [DebuggerHiddenAttribute] // RVA: 0x7030B4 Offset: 0x7030B4 VA: 0x7030B4
        // [CompilerGeneratedAttribute] // RVA: 0x7030B4 Offset: 0x7030B4 VA: 0x7030B4
        // // RVA: 0xF8D62C Offset: 0xF8D62C VA: 0xF8D62C
        // private IEnumerator <>n__0(Transform parent) { }
    }
}