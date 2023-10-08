
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupDecoEnergyChargeSetting : PopupSetting
    {
        public int currentStock; // 0x34
        public int currentGauge; // 0x38
        public bool isCurrentMax; // 0x3C
        public int nextGauge; // 0x40
        public bool isDeco; // 0x44

        public override string PrefabPath { get { return ""; } } //0x13469A0
        public override string BundleName { get { return "ly/214.xab"; } } //0x13469FC
        public override string AssetName { get { return "root_deco_bar_pop_01_layout_root"; } } //0x1346A58
        public override bool IsAssetBundle { get { return true; } } //0x1346AB4
        public override bool IsPreload { get { return true; } } //0x1346ABC
        public override GameObject Content { get { return m_content; } } //0x1346AC4

        // // RVA: 0x1346ACC Offset: 0x1346ACC VA: 0x1346ACC
        // public void SetContent(GameObject obj) { }
    }
}