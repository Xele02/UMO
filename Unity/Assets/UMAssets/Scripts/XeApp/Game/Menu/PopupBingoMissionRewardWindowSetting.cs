
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
    public class PopupBingoMissionRewardWindowSetting : PopupSetting
    {
        public List<GNGMCIAIKMA.JCIFAFBDALP> ItemInfoList = new List<GNGMCIAIKMA.JCIFAFBDALP>(); // 0x34
        public List<string> MissionTextList = new List<string>(); // 0x38
        private LayoutBingoMissionRewardWindow layout; // 0x3C

        public override string PrefabPath { get { return ""; } } //0x133A29C
        public override string BundleName { get { return "ly/153.xab"; } } //0x133A2F8
        public override string AssetName { get { return "root_pop_reward_item_list_layout_root"; } } //0x133A354
        public override bool IsAssetBundle { get { return true; } } //0x133A3B0
        public override bool IsPreload { get { return false; } } //0x133A3B8
        public override GameObject Content { get { return m_content; } } //0x133A3C0

        // // RVA: 0x133A3C8 Offset: 0x133A3C8 VA: 0x133A3C8
        // public void SetContent(GameObject obj) { }

        // [IteratorStateMachineAttribute] // RVA: 0x700374 Offset: 0x700374 VA: 0x700374
        // // RVA: 0x133A3D0 Offset: 0x133A3D0 VA: 0x133A3D0 Slot: 4
        public override IEnumerator LoadAssetBundlePrefab(Transform parent)
        {
            XeSys.FontInfo systemFont; // 0x1C
            int poolSize; // 0x20
            AssetBundleLoadLayoutOperationBase operation; // 0x24
            int i; // 0x28

            //0x133A7C8
            yield return AssetBundleManager.LoadUnionAssetBundle(BundleName);
            yield return Co.R(base.LoadAssetBundlePrefab(parent));
            layout = m_content.GetComponent<LayoutBingoMissionRewardWindow>();
            systemFont = GameManager.Instance.GetSystemFont();
            poolSize = layout.List.ScrollObjectCount;
            operation = AssetBundleManager.LoadLayoutAsync(BundleName, "root_pop_reward_item_list_inf_layout_root");
            yield return operation;
            bool _isLoaded = false;
            LayoutUGUIRuntime baseRuntime = null;
            List<LayoutBingoMissionRewardContents> contentList = new List<LayoutBingoMissionRewardContents>();
            yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
            {
                //0x133A568
                baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
                baseRuntime.name = baseRuntime.name.Replace("(Clone)", "_00");
                baseRuntime.IsLayoutAutoLoad = false;
                baseRuntime.Layout = baseRuntime.Layout.DeepClone();
                baseRuntime.UvMan = baseRuntime.UvMan;
                baseRuntime.LoadLayout();
                contentList.Add(instance.GetComponent<LayoutBingoMissionRewardContents>());
                _isLoaded = true;
            }));
            while(!_isLoaded)
                yield return null;
            AssetBundleManager.UnloadAssetBundle(BundleName, false);
            for(i = 1; i < poolSize; i++)
            {
                LayoutUGUIRuntime r = UnityEngine.Object.Instantiate(baseRuntime);
                r.name.Replace("00", i.ToString("D2"));
                r.IsLayoutAutoLoad = false;
                r.Layout = baseRuntime.Layout.DeepClone();
                r.UvMan = baseRuntime.UvMan;
                r.LoadLayout();
                contentList.Add(r.GetComponent<LayoutBingoMissionRewardContents>());
            }
            AssetBundleManager.UnloadAssetBundle(BundleName, false);
            for(i = 0; i < contentList.Count; i++)
            {
                while(!contentList[i].IsLoaded())
                    yield return null;
                layout.List.AddScrollObject(contentList[i]);
            }
            layout.List.Apply();
            layout.List.SetContentEscapeMode(true);
        }

        // [DebuggerHiddenAttribute] // RVA: 0x7003EC Offset: 0x7003EC VA: 0x7003EC
        // [CompilerGeneratedAttribute] // RVA: 0x7003EC Offset: 0x7003EC VA: 0x7003EC
        // // RVA: 0x133A558 Offset: 0x133A558 VA: 0x133A558
        // private IEnumerator <>n__0(Transform parent) { }
    }
}