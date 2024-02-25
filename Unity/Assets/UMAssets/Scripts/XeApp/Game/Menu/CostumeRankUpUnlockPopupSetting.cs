
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class CostumeRankUpUnlockPopupSetting : PopupSetting
    {
        public LFAFJCNKLML m_data; // 0x34
        public MOEALEGLGCH m_upgrade; // 0x38

        public override string PrefabPath { get { return ""; } } //0x16347D8
        public override string BundleName { get { return "ly/128.xab"; } } //0x1634834
        public override string AssetName { get { return "PopupCostumeRankUpUnlock"; } } //0x1634890
        public override bool IsAssetBundle { get { return true; } } //0x16348EC
        public override bool IsPreload { get { return true; } } //0x16348F4
        public override GameObject Content { get { return m_content; } } //0x16348FC

        // // RVA: 0x1634904 Offset: 0x1634904 VA: 0x1634904
        // public void SetContent(GameObject obj) { }

        // // RVA: 0x163490C Offset: 0x163490C VA: 0x163490C
        public void StartRankUnlockAnimation()
        {
            m_content.GetComponent<CostumeRankUpUnlockWindow>().StartRankUnlockAnimation();
        }

        // // RVA: 0x16349DC Offset: 0x16349DC VA: 0x16349DC
        public bool IsPlayingAnimation()
        {
            return m_content.GetComponent<CostumeRankUpUnlockWindow>().m_isPlayingRankUnlockAnimation;
        }
    }
}