
using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupDashContentSetting : PopupSetting
    {
        public class InitParam
        {
            public int Rate { get; set; } // 0x8
            public int Cost { get; set; } // 0xC
        }

        public int EventId { get; set; } // 0x34
        public LayoutPopupDash.CostType CostType { get; set; } // 0x38
        public int OwnValue { get; set; } // 0x3C
        public InitParam[] Param { get; set; } // 0x40
        public Action<int> OnSelectCallback { get; set; } // 0x44
        public override string PrefabPath { get { return ""; } } //0x1344E9C
        public override string BundleName { get { return "ly/101.xab"; } } //0x1344EF8
        public override string AssetName { get { return "root_pop_dash_layout_root"; } } //0x1344F54
        public override bool IsAssetBundle { get { return true; } } //0x1344FB0
        public override bool IsPreload { get { return false; } } //0x1344FB8
        public override GameObject Content { get { return m_content; } } //0x1344FC0

        // // RVA: 0x1344FC8 Offset: 0x1344FC8 VA: 0x1344FC8
        // public void SetContent(GameObject obj) { }
    }
}