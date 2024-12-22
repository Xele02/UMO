
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupUnlockDivaContentSetting : PopupSetting
    {
        public PopupUnlock.UnlockInfo UnlockInfo { get; set; } // 0x34
        public override string PrefabPath { get { return ""; } } //0x115E388
        public override string BundleName { get { return "ly/048.xab"; } } //0x115E3E4
        public override string AssetName { get { return "root_pop_chara_ul_layout_root"; } } //0x115E440
        public override bool IsAssetBundle { get { return true; } } //0x115E49C
        public override bool IsPreload { get { return false; } } //0x115E4A4
        public override GameObject Content { get { return m_content; } } //0x115E4AC

        // // RVA: 0x115E4B4 Offset: 0x115E4B4 VA: 0x115E4B4
        // public void SetContent(GameObject obj) { }
    }
}