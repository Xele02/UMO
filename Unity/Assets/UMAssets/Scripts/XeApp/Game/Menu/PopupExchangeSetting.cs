
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupExchangeSetting : PopupSetting
    {
        public FJGOKILCBJA View { get; set; } // 0x34
        public override string PrefabPath { get { return ""; } } //0xF8E720
        public override string BundleName { get { return "ly/213.xab"; } } //0xF8E77C
        public override string AssetName { get { return "root_pop_exchange_layout_root"; } } //0xF8E7D8
        public override bool IsAssetBundle { get { return true; } } //0xF8E834
        public override bool IsPreload { get { return false; } } //0xF8E83C
        public override GameObject Content { get { return m_content; } } //0xF8E844

        // // RVA: 0xF8E84C Offset: 0xF8E84C VA: 0xF8E84C
        // public void SetContent(GameObject obj) { }
    }
}