
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupStopAccountSetting : PopupSetting
    {
        public LayoutPopupStopAccount.Type type { get; set; } // 0x34
        public override string PrefabPath { get { return "Layout/contract/root_contract_pop_02_layout_root"; } } //0x1152040
        public override string BundleName { get { return ""; } } //0x115209C
        public override string AssetName { get { return "root_contract_pop_02_layout_root"; } } //0x11520F8
        public override bool IsAssetBundle { get { return false; } } //0x1152154
        public override bool IsPreload { get { return false; } } //0x115215C
        public override GameObject Content { get { return m_content; } } //0x1152164

        // // RVA: 0x115216C Offset: 0x115216C VA: 0x115216C
        // public void SetContent(GameObject obj) { }
    }
}