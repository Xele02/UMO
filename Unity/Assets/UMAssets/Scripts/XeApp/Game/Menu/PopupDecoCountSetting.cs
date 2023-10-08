
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupDecoCountSetting : PopupSetting
    {
        public int decoCount; // 0x34

        public override string PrefabPath { get { return ""; } } //0x1345E40
        public override string BundleName { get { return "ly/201.xab"; } } //0x1345E9C
        public override string AssetName { get { return "root_deco_pop_s_01_layout_root"; } } //0x1345EF8
        public override bool IsAssetBundle { get { return true; } } //0x1345F54
        public override bool IsPreload { get { return true; } } //0x1345F5C
        public override GameObject Content { get { return m_content; } } //0x1345F64

        // // RVA: 0x1345F6C Offset: 0x1345F6C VA: 0x1345F6C
        // public void SetContent(GameObject content) { }
    }
}