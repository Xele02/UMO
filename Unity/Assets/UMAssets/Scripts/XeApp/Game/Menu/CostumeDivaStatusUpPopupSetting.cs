
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    internal class CostumeDivaStatusUpPopupSetting : PopupSetting
    {
        public LFAFJCNKLML m_data; // 0x34

        public override string PrefabPath { get { return ""; } } //0x162A8B8
        public override string BundleName { get { return "ly/128.xab"; } } //0x162A914
        public override string AssetName { get { return "PopupCostumeDivaStatusUp"; } } //0x162A970
        public override bool IsAssetBundle { get { return true; } } //0x162A9CC
        public override bool IsPreload { get { return true; } } //0x162A9D4
        public override GameObject Content { get { return m_content; } } //0x162A9DC

        // // RVA: 0x162A9E4 Offset: 0x162A9E4 VA: 0x162A9E4
        // public void SetContent(GameObject obj) { }
    }
}