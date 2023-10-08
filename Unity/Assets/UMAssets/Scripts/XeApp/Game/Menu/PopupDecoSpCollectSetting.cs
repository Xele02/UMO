
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupDecoSpCollectSetting : PopupSetting
    {
        public DecorationSpCollectInfo m_info; // 0x34

        public override string PrefabPath { get { return ""; } } //0xF79030
        public override string BundleName { get {  return DecorationConstants.BundleName;} } //0xF7908C
        public override string AssetName { get { return LayoutDecorationSpCollectPopup.AssetName; } } //0xF79118
        public override bool IsAssetBundle { get { return true; } } //0xF791A4
        public override bool IsPreload { get { return true; } } //0xF791AC
        public override GameObject Content { get { return m_content; } } //0xF791B4

        // // RVA: 0xF791BC Offset: 0xF791BC VA: 0xF791BC
        // public void SetContent(GameObject obj) { }
    }
}