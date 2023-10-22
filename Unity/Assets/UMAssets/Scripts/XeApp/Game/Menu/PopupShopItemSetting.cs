
using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupShopItemSetting : PopupSetting
    {
        public FJGOKILCBJA View { get; set; } // 0x34
        public bool IsBuy { get; set; } // 0x38
        public Action<int> OnChangeCallback { get; set; } // 0x3C
        public override string PrefabPath { get { return ""; } } //0x114865C
        public override string BundleName { get { return "ly/106.xab"; } } //0x11486B8
        public override string AssetName { get { return "root_sel_shop_pop_01_layout_root"; } } //0x1148714
        public override bool IsAssetBundle { get { return true; } } //0x1148770
        public override bool IsPreload { get { return false; } } //0x1148778
        public override GameObject Content { get { return m_content; } } //0x1148780

        // // RVA: 0x1148788 Offset: 0x1148788 VA: 0x1148788
        // public void SetContent(GameObject obj) { }

        // [IteratorStateMachineAttribute] // RVA: 0x70F454 Offset: 0x70F454 VA: 0x70F454
        // RVA: 0x1148790 Offset: 0x1148790 VA: 0x1148790 Slot: 4
        public override IEnumerator LoadAssetBundlePrefab(Transform parent)
        {
            //0x114886C
            yield return Co.R(base.LoadAssetBundlePrefab(parent));
            if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(View.KIJAPOFAGPN_ItemFullId) != EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem)
                yield break;
            yield return Co.R(m_content.GetComponent<LayoutPopupShop>().Co_LoadScrollItemContent());
        }

        // [CompilerGeneratedAttribute] // RVA: 0x70F4CC Offset: 0x70F4CC VA: 0x70F4CC
        // [DebuggerHiddenAttribute] // RVA: 0x70F4CC Offset: 0x70F4CC VA: 0x70F4CC
        // // RVA: 0x1148860 Offset: 0x1148860 VA: 0x1148860
        // private IEnumerator <>n__0(Transform parent) { }
    }
}