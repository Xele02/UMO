
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupDecoSentGiftSetting : PopupSetting
    {
        public int itemId; // 0x34
        public int count; // 0x38
        public int sentCount; // 0x3C

        public override string PrefabPath { get { return ""; } } //0xF78634
        public override string BundleName { get { return "ly/201.xab"; } } //0xF78690
        public override string AssetName { get { return "root_deco_pop_gift_01_layout_root"; } } //0xF786EC
        public override bool IsAssetBundle { get { return true; } } //0xF78748
        public override bool IsPreload { get { return true; } } //0xF78750
        public override GameObject Content { get { return m_content; } } //0xF78758

        // // RVA: 0xF78760 Offset: 0xF78760 VA: 0xF78760
        // public void SetContent(GameObject content) { }
    }
}