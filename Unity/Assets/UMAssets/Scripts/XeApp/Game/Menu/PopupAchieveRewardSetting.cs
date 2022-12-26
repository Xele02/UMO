
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupAchieveRewardSetting : PopupSetting
    {
        // public int selectMusicId { get; set; } // 0x34
        // public int selectFreeMusicId { get; set; } // 0x38
        // public int gameEventType { get; set; } // 0x3C
        // public Difficulty.Type diff { get; set; } // 0x40
        // public LayoutPopupAchieveReward.eMode mode { get; set; } // 0x44
        // public FPGEMAIAMBF viewFreeReward { get; set; } // 0x48
        // public bool isLine6Mode { get; set; } // 0x4C
        public override string PrefabPath { get { return "Menu/Prefab/PopupWindow/root_pop_reward_layout_root"; } } //0x132DE08
        public override string BundleName { get { return "ly/043.xab"; } } //0x132DE64
        public override string AssetName { get { return "root_pop_reward_layout_root"; } } //0x132DEC0
        public override bool IsAssetBundle { get { return true; } } //0x132DF1C
        public override bool IsPreload { get { return true; } } //0x132DF24
        public override GameObject Content { get { return m_content; } } //0x132DF2C

        // // RVA: 0x132DF34 Offset: 0x132DF34 VA: 0x132DF34
        public void SetContent(GameObject obj)
        {
            m_content = obj;
        }
    }
}