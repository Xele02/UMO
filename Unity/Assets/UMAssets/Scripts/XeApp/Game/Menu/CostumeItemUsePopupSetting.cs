
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class CostumeItemUsePopupSetting : PopupSetting
    {
        public LFAFJCNKLML data { get; set; } // 0x34
        public int item_type { get; set; } // 0x38
        public int item_count { get; set; } // 0x3C
        public override string PrefabPath { get { return ""; } } //0x1631A74
        public override string BundleName { get { return "ly/128.xab"; } } //0x1631AD0
        public override string AssetName { get { return "PopupCostumeItemUse"; } } //0x1631B2C
        public override bool IsAssetBundle { get { return true; } } //0x1631B88
        public override bool IsPreload { get { return true; } } //0x1631B90
        public override GameObject Content { get { return m_content; } } //0x1631B98

        // RVA: 0x1631BA0 Offset: 0x1631BA0 VA: 0x1631BA0
        public void SetContent(GameObject obj)
        {
            m_content = obj;
        }
    }
}