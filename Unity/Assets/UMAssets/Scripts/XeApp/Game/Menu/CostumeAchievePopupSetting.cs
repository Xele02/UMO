
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class CostumeAchievePopupSetting : PopupSetting
    {
        public LFAFJCNKLML data; // 0x34
        public SimpleVoicePlayer voicePlayer; // 0x38

        public override string PrefabPath { get { return ""; } } //0x1B65C60
        public override string BundleName { get { return "ly/128.xab"; } } //0x1B65CBC
        public override string AssetName { get { return "PopupCostumeAchieve"; } } //0x1B65D18
        public override bool IsAssetBundle { get { return true; } } //0x1B65D74
        public override bool IsPreload { get { return true; } } //0x1B65D7C
        public override GameObject Content { get { return m_content; } } //0x1B65D84

        // RVA: 0x1B65D8C Offset: 0x1B65D8C VA: 0x1B65D8C
        public void SetContent(GameObject obj)
        {
            m_content = obj;
        }
    }
}