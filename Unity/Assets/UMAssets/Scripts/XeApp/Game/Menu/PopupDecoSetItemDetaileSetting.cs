
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupDecoSetItemDetaileSetting : PopupSetting
    {
        public FJGOKILCBJA View { get; set; } // 0x34
        public override string PrefabPath { get { return ""; } } //0xF78780
        public override string BundleName { get { return "ly/106.xab"; } } //0xF787DC
        public override string AssetName { get { return "root_sel_shop_pop_02_layout_root"; } } //0xF78838
        public override bool IsAssetBundle { get { return true; } } //0xF78894
        public override bool IsPreload { get { return false; } } //0xF7889C
        public override GameObject Content { get { return m_content; } } //0xF788A4

        // // RVA: 0xF788AC Offset: 0xF788AC VA: 0xF788AC
        // public void SetContent(GameObject obj) { }

        // [IteratorStateMachineAttribute] // RVA: 0x70F2DC Offset: 0x70F2DC VA: 0x70F2DC
        // RVA: 0xF788B4 Offset: 0xF788B4 VA: 0xF788B4 Slot: 4
        public override IEnumerator LoadAssetBundlePrefab(Transform parent)
        {
            //0xF78990
            yield return Co.R(base.LoadAssetBundlePrefab(parent));
            yield return Co.R(m_content.GetComponent<LayoutPopupDecpSetDataile>().Co_LoadScrollItemContent());
        }

        // [DebuggerHiddenAttribute] // RVA: 0x70F354 Offset: 0x70F354 VA: 0x70F354
        // [CompilerGeneratedAttribute] // RVA: 0x70F354 Offset: 0x70F354 VA: 0x70F354
        // // RVA: 0xF78984 Offset: 0xF78984 VA: 0xF78984
        // private IEnumerator <>n__0(Transform parent) { }
    }
}