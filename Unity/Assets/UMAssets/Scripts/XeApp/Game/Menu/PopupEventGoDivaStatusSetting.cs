
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupEventGoDivaStatusSetting : PopupSetting
    {
        public LayoutPopupEventGoDivaStatus.StatusParamSet m_statusParamSet; // 0x34

        public override string PrefabPath { get { return ""; } } //0xF8CF34
        public override string BundleName { get { return "ly/017.xab"; } } //0xF8CF90
        public override string AssetName { get { return "root_chk_diva_status_pop_layout_root"; } } //0xF8CFEC
        public override bool IsAssetBundle { get { return true; } } //0xF8D048
        public override bool IsPreload { get { return false; } } //0xF8D050
        public override GameObject Content { get { return m_content; } } //0xF8D058

        // // RVA: 0xF8D060 Offset: 0xF8D060 VA: 0xF8D060
        // public void SetContent(GameObject obj) { }
    }
}