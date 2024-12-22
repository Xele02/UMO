
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupPlayerRankupSetting : PopupSetting
    {
        public class SettingParam
        {
            public int prevPlayerLevel; // 0x8
            public int currentPlayerLevel; // 0xC
            public int prevStaminaMax; // 0x10
            public int currentStaminaMax; // 0x14
            public int currentStamina; // 0x18
            public int prevFriendMax; // 0x1C
            public int currentFriendMax; // 0x20
            public int jacketId; // 0x24
            public int currentStep; // 0x28
            public int nextStep; // 0x2C
            public string musicName; // 0x30
            public string missionDesc; // 0x34
        }

        public SettingParam param; // 0x34

        public override string PrefabPath { get { return ""; } } //0x160AD30
        public override string BundleName { get { return "ly/021.xab"; } } //0x160AD8C
        public override string AssetName { get { return "root_rankup_layout_root"; } } //0x160ADE8
        public override bool IsAssetBundle { get { return true; } } //0x160AE44
        public override bool IsPreload { get { return false; } } //0x160AE4C
        public override GameObject Content { get { return m_content; } } //0x160AE54

        // // RVA: 0x160AE5C Offset: 0x160AE5C VA: 0x160AE5C
        // public void SetContent(GameObject obj) { }
    }
}