
using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class PopupConfigBattleEventSetting : PopupSetting
    {
        public Action OnClickClassSelect; // 0x34
        public Action<bool> OnClickBattleInfo; // 0x38

        public override string PrefabPath { get { return ""; } } //0x133F5E4
        public override string BundleName { get { return "ly/063.xab"; } } //0x133F640
        public override string AssetName { get { return "root_sel_music_btl_eve_menu_layout_root"; } } //0x133F69C
        public override bool IsAssetBundle { get { return true; } } //0x133F6F8
        public override bool IsPreload { get { return false; } } //0x133F700
        public override GameObject Content { get { return m_content; } } //0x133F708

        // // RVA: 0x133F710 Offset: 0x133F710 VA: 0x133F710
        // public void SetContent(GameObject obj) { }
    }
}