
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupUnlockStageContentSetting : PopupSetting
    {
        public PopupUnlock.UnlockInfo UnlockInfo { get; set; } // 0x34
        public override string PrefabPath { get { return ""; } } //0x115F8B4
        public override string BundleName { get { return "ly/049.xab"; } } //0x115F910
        public override string AssetName { get { return "root_pop_story_ul_layout_root"; } } //0x115F96C
        public override bool IsAssetBundle { get { return true; } } //0x115F9C8
        public override bool IsPreload { get { return false; } } //0x115F9D0
        public override GameObject Content { get { return m_content; } } //0x115F9D8

        // // RVA: 0x115F9E0 Offset: 0x115F9E0 VA: 0x115F9E0
        // public void SetContent(GameObject obj) { }
    }
}