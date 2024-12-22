
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupLimitOverContentSetting : PopupSetting
    {
        public string ContentText { get; set; } // 0x34
        public AEKDNMPPOJN LimitOverData { get; set; } // 0x38
        public override string PrefabPath { get { return ""; } } //0x17AF690
        public override string BundleName { get { return "ly/099.xab"; } } //0x17AF6EC
        public override string AssetName { get { return "root_pop_luckyleaf_ability_layout_root"; } } //0x17AF748
        public override bool IsAssetBundle { get { return true; } } //0x17AF7A4
        public override bool IsPreload { get { return false; } } //0x17AF7AC
        public override GameObject Content { get { return m_content; } } //0x17AF7B4

        // // RVA: 0x17AF7BC Offset: 0x17AF7BC VA: 0x17AF7BC
        // public void SetContent(GameObject obj) { }
    }
}