
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class DocorationSpItemRemovePopupSetting : PopupSetting
    {
        public List<int> itemList = new List<int>(); // 0x34
        public bool isReplaceRoom; // 0x38

        public override string PrefabPath { get { return ""; } } //0x1273D10
        public override string BundleName { get { return "ly/201.xab"; } } //0x1273D6C
        public override string AssetName { get { return "root_deco_pop_m_03_layout_root"; } } //0x1273DC8
        public override bool IsAssetBundle { get { return true; } } //0x1273E24
        public override bool IsPreload { get { return true; } } //0x1273E2C
        public override GameObject Content { get { return m_content; } } //0x1273E34

        // // RVA: 0x1273E3C Offset: 0x1273E3C VA: 0x1273E3C
        // public void SetContent(GameObject content) { }
    }
}