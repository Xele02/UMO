
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupUnlockNotifyDivaSetting : PopupSetting
    {
        public PopupUnlock.UnlockInfo UnlockInfo { get; set; } // 0x34
        public override string PrefabPath { get { return ""; } } //0x115F1B4
        public override string BundleName { get { return "ly/088.xab"; } } //0x115F210
        public override string AssetName { get { return "root_sw_pop_diva_join_layout_root"; } } //0x115F26C
        public override bool IsAssetBundle { get { return true; } } //0x115F2C8
        public override bool IsPreload { get { return false; } } //0x115F2D0
        public override GameObject Content { get { return m_content; } } //0x115F2D8

        // // RVA: 0x115F2E0 Offset: 0x115F2E0 VA: 0x115F2E0
        // public void SetContent(GameObject obj) { }
    }
}