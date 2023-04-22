
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public class SceneComparisonPopupSetting : PopupSetting
    {
        public override string PrefabPath { get { return ""; } } //0x15A6140
        public override string BundleName { get { return "ly/014.xab"; } } //0x15A619C
        public override string AssetName { get { return "SceneComparisonPopup"; } } //0x15A61F8
        public override bool IsAssetBundle { get { return true; } } //0x15A6254
        public override bool IsPreload { get { return false; } } //0x15A625C
        public override GameObject Content { get { return m_content; } } //0x15A6264
        public DFKGGBMFFGB_PlayerInfo PlayerData { get; set; } // 0x34
        public GCIJNCFDNON_SceneInfo AfterScene { get; set; } // 0x38
        public GCIJNCFDNON_SceneInfo BeforeScene { get; set; } // 0x3C
        public FFHPBEPOMAK_DivaInfo DivaData { get; set; } // 0x40
        public int SceneSlotIndex { get; set; } // 0x44
        public int DivaSlot { get; set; } // 0x48
        public DisplayType DisplayType { get; set; } // 0x4C
        public EAJCBFGKKFA_FriendInfo FriendPlayerData { get; set; } // 0x50
        public EEDKAACNBBG_MusicData MusicBaseData { get; set; } // 0x54
        public EJKBKMBJMGL_EnemyData EnemyData { get; set; } // 0x58
        public Difficulty.Type Difficulty { get; set; } // 0x5C
        public bool IsGoDiva { get; set; } // 0x60

        // // RVA: 0x15A62D4 Offset: 0x15A62D4 VA: 0x15A62D4
        // public void SetContent(GameObject content) { }
    }
}
