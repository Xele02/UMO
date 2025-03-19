
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class TicketGainedPopupSetting : PopupSetting
    {
        public int itemId { get; set; } // 0x34
        public string title { get; set; } // 0x38
        public string label01 { get; set; } // 0x3C
        public string label02 { get; set; } // 0x40
        public int layoutType { get; set; } // 0x44
        public override string PrefabPath { get { return ""; } } //0xA96C90
        public override string BundleName { get { return "ly/079.xab"; } } //0xA96CEC
        public override string AssetName { get { return "PopupTicketGained"; } } //0xA96D48
        public override bool IsAssetBundle { get { return true; } } //0xA96DA4
        public override bool IsPreload { get { return true; } } //0xA96DAC

        // // RVA: 0xA96DB4 Offset: 0xA96DB4 VA: 0xA96DB4
        public void SetContent(GameObject obj)
        {
            m_content = obj;
        }
    }
}