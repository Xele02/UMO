
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupDecoSpItemLevelupePopupSetting : PopupSetting
    {
        public int currentLevel; // 0x34
        public int itemId; // 0x38

        public override string PrefabPath { get { return ""; } } //0xF794E0
        public override string BundleName { get { return "ly/201.xab"; } } //0xF7953C
        public override string AssetName { get { return "root_deco_pop_m_02_01_layout_root"; } } //0xF79598
        public override bool IsAssetBundle { get { return true; } } //0xF795F4
        public override bool IsPreload { get { return true; } } //0xF795FC
        public override GameObject Content { get { return m_content; } } //0xF79604

        // // RVA: 0xF7960C Offset: 0xF7960C VA: 0xF7960C
        // public void SetContent(GameObject content) { }
    }
}