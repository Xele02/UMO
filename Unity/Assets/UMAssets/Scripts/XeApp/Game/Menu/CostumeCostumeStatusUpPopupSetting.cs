
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class CostumeCostumeStatusUpPopupSetting : PopupSetting
    {
        public LFAFJCNKLML m_data; // 0x34

        public override string PrefabPath { get { return ""; } } //0x1627C84
        public override string BundleName { get { return "ly/128.xab"; } } //0x1627CE0
        public override string AssetName { get { return "PopupCostumeCostumeStatusUp"; } } //0x1627D3C
        public override bool IsAssetBundle { get { return true; } } //0x1627D98
        public override bool IsPreload { get { return false; } } //0x1627DA0
        public override GameObject Content { get { return m_content; } } //0x1627DA8

        // // RVA: 0x1627DB0 Offset: 0x1627DB0 VA: 0x1627DB0
        // public void SetContent(GameObject obj) { }
    }
}