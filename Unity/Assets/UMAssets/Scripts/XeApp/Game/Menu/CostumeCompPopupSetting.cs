
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class CostumeCompPopupSetting : PopupSetting
    {
        public LFAFJCNKLML data; // 0x34
        public int add_point; // 0x38
        public bool is_restart; // 0x3C
        public int prev_offer_difficult; // 0x40
        public SimpleVoicePlayer voicePlayer; // 0x44
        public bool is_reshow; // 0x48

        public override string PrefabPath { get { return ""; } } //0x1B664A0
        public override string BundleName { get { return "ly/128.xab"; } } //0x1B664FC
        public override string AssetName { get { return "PopupCostumeComp"; } } //0x1B66558
        public override bool IsAssetBundle { get { return true; } } //0x1B665B4
        public override bool IsPreload { get { return true; } } //0x1B665BC
        public override GameObject Content { get { return m_content; } } //0x1B665C4

        // RVA: 0x1B665CC Offset: 0x1B665CC VA: 0x1B665CC
        public void SetContent(GameObject obj)
        {
            m_content = obj;
        }
    }
}