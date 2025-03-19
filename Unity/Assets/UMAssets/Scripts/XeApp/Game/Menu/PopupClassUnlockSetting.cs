
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupClassUnlockSetting : PopupSetting
    {
        public IHGLIHBAOII View { get; set; } // 0x34
        public override string PrefabPath { get { return ""; } } //0x133EB00
        public override string BundleName { get { return "ly/063.xab"; } } //0x133EB5C
        public override string AssetName { get { return "root_sel_music_btl_cl_unlock_layout_root"; } } //0x133EBB8
        public override bool IsAssetBundle { get { return true; } } //0x133EC14
        public override bool IsPreload { get { return false; } } //0x133EC1C
        public override GameObject Content { get { return m_content; } } //0x133EC24

        // // RVA: 0x133EC2C Offset: 0x133EC2C VA: 0x133EC2C
        // public void SetContent(GameObject obj) { }
    }
}