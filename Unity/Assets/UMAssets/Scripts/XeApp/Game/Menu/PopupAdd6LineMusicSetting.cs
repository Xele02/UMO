
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupAdd6LineMusicSetting : PopupSetting
    {
        public PopupUnlock.UnlockInfo UnlockInfo { get; set; } // 0x34
        public override string PrefabPath { get { return ""; } } //0x132E5FC
        public override string BundleName { get { return "ly/127.xab"; } } //0x132E658
        public override string AssetName { get { return "root_pop_music_ul_line_layout_root"; } } //0x132E6B4
        public override bool IsAssetBundle { get { return true; } } //0x132E710
        public override bool IsPreload { get { return false; } } //0x132E718
        public override GameObject Content { get { return m_content; } } //0x132E720

        // // RVA: 0x132E728 Offset: 0x132E728 VA: 0x132E728
        // public void SetContent(GameObject obj) { }
    }
}