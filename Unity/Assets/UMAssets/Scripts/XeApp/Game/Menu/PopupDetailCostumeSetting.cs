using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    internal class PopupDetailCostumeSetting : PopupSetting
    {
        public CKFGMNAIBNG ViewCostumeData { get; set; } // 0x34
        public int ColorId { get; set; } // 0x38
        public override bool IsPreload { get { return true; } } //0xF80BC8
        public override bool IsAssetBundle { get { return true; } }// 0xF80BD0
        public override string PrefabPath { get { return ""; } } //0xF80BD8
        public override string BundleName { get { return "ly/103.xab"; } } //0xF80C34
        public override string AssetName { get { return "root_pop_detail_cos_layout_root"; } } //0xF80C90
        public override GameObject Content { get { return m_content; } }// 0xF80CEC
    }
}
