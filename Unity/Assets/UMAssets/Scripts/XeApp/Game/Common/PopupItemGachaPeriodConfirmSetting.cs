
using UnityEngine;

namespace XeApp.Game.Common
{
    public class PopupItemGachaPeriodConfirmSetting : PopupSetting
    {
        public int TypeItemId { get; set; } // 0x34
        public int Cost { get; set; } // 0x38
        public int OwnCount { get; set; } // 0x3C
        public long Period { get; set; } // 0x40
        public string OverrideText { get; set; } // 0x48
        public string OverrideCaution { get; set; } // 0x4C
        public bool HideUseNum { get; set; } // 0x50
        public override bool IsPreload { get { return true; } } //0xAFCC6C
        public override bool IsAssetBundle { get { return true; } } //0xAFCC74
        public override string PrefabPath { get { return ""; } } //0xAFCC7C
        public override string BundleName { get { return "ly/216.xab"; } } //0xAFCCD8
        public override string AssetName { get { return "root_pop_rerity2_layout_root"; } } //0xAFCD34
        public override GameObject Content { get { return m_content; } } //0xAFCD90
    }
}