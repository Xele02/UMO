
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class ReplaceValkyriePopupSetting : PopupSetting
    {
        public PNGOLKLFFLH before_data { get; set; } // 0x34
        public NHDJHOPLMDE before_data_ab { get; set; } // 0x38
        public PNGOLKLFFLH after_data { get; set; } // 0x3C
        public NHDJHOPLMDE after_data_ab { get; set; } // 0x40
        public override string PrefabPath { get { return ""; } } //0xCFC864
        public override string BundleName { get { return "ly/045.xab"; } } //0xCFC8C0
        public override string AssetName { get { return "PopupReplaceValkyrie"; } } //0xCFC91C
        public override bool IsAssetBundle { get { return true; } } //0xCFC978
        public override bool IsPreload { get { return true; } } //0xCFC980
        public override GameObject Content { get { return m_content; } } //0xCFC988

        // // RVA: 0xCFC990 Offset: 0xCFC990 VA: 0xCFC990
        // public void SetContent(GameObject obj) { }
    }
}