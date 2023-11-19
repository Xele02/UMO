
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupGetBingoRewaedSetting : PopupSetting
    {
        public int ItemId; // 0x34
        public int GetItemCount; // 0x38
        public int BingoCount; // 0x3C

        public override string PrefabPath { get { return ""; } } //0x17A8278
        public override string BundleName { get { return "ly/153.xab"; } } //0x17A82D4
        public override string AssetName { get { return "root_pop_bingo_rwd_get_layout_root"; } } //0x17A8330
        public override bool IsAssetBundle { get { return true; } } //0x17A838C
        public override bool IsPreload { get { return false; } } //0x17A8394
        public override GameObject Content { get { return m_content; } } //0x17A839C

        // // RVA: 0x17A83A4 Offset: 0x17A83A4 VA: 0x17A83A4
        // public void SetContent(GameObject obj) { }
    }
}