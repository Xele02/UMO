
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
    //[DefaultMember("Item")] // RVA: 0x640480 Offset: 0x640480 VA: 0x640480
    public class PopupDecoSpItemListSetting : PopupSetting
    {
        public struct ItemParam
        {
            public int id; // 0x0
            public int count; // 0x4
        }

        private List<ItemParam> itemList = new List<ItemParam>(); // 0x34
        public int m_itemId; // 0x38
        public int m_itemNum; // 0x3C

        public ItemParam this[int index] { get { return itemList[index]; } } //0xF79B74
        public override string PrefabPath { get { return ""; } } //0xF7A378
        public override string BundleName { get { return DecorationConstants.BundleName; } } //0xF7A3D4
        public override string AssetName { get { return LayoutDecorationSpItemListPopup.AssetName; } } //0xF7A460
        public override bool IsAssetBundle { get { return true; } } //0xF7A4EC
        public override bool IsPreload { get { return true; } } //0xF7A4F4
        public override GameObject Content { get { return m_content; } } //0xF7A4FC

        // // RVA: 0xF7A504 Offset: 0xF7A504 VA: 0xF7A504
        // public void SetContent(GameObject obj) { }

        // [IteratorStateMachineAttribute] // RVA: 0x6D72A4 Offset: 0x6D72A4 VA: 0x6D72A4
        // // RVA: 0xF7A50C Offset: 0xF7A50C VA: 0xF7A50C Slot: 4
        public override IEnumerator LoadAssetBundlePrefab(Transform parent)
        {
            AssetBundleLoadLayoutOperationBase listItemOp;

            //0xF7A95C
            yield return AssetBundleManager.LoadUnionAssetBundle(BundleName);
            yield return Co.R(base.LoadAssetBundlePrefab(parent));
            LayoutUGUIRuntime sourceRuntime = null;
            listItemOp = AssetBundleManager.LoadLayoutAsync(BundleName, "root_deco_pop_m_01_layout_root");
            yield return listItemOp;
            yield return Co.R(listItemOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject inst) =>
            {
                //0xF7A8C8
                sourceRuntime = inst.GetComponent<LayoutUGUIRuntime>();
            }));
            PopupDecoSpItemList p = m_content.GetComponent<PopupDecoSpItemList>();
            m_content.gameObject.SetActive(true);
            p.InitializeObject(sourceRuntime, 5);
            yield return null;
            Object.Destroy(sourceRuntime.gameObject);
            m_content.gameObject.SetActive(false);
            listItemOp = null;
            AssetBundleManager.UnloadAssetBundle(BundleName, false);
        }

        // RVA: 0xF7A5D4 Offset: 0xF7A5D4 VA: 0xF7A5D4
        public void Clear()
        {
            itemList.Clear();
        }

        // RVA: 0xF7A64C Offset: 0xF7A64C VA: 0xF7A64C
        public void Add(ItemParam item)
        {
            int idx = itemList.FindIndex((ItemParam x) =>
            {
                //0xF7A944
                return x.id == item.id;
            });
            if(idx > -1)
            {
                ItemParam p = itemList[idx];
                p.count += item.count;
                itemList[idx] = p;
            }
            else
            {
                itemList.Add(item);
            }
        }

        // RVA: 0xF79C40 Offset: 0xF79C40 VA: 0xF79C40
        public int Count()
        {
            return itemList.Count;
        }

        // [DebuggerHiddenAttribute] // RVA: 0x6D731C Offset: 0x6D731C VA: 0x6D731C
        // [CompilerGeneratedAttribute] // RVA: 0x6D731C Offset: 0x6D731C VA: 0x6D731C
        // // RVA: 0xF7A8B8 Offset: 0xF7A8B8 VA: 0xF7A8B8
        // private IEnumerator <>n__0(Transform parent) { }
    }
}