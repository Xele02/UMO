using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    internal class PopupDetailCostumeSetting : PopupSetting
    {
        // public CKFGMNAIBNG ViewCostumeData { get; set; } // 0x34
        public int ColorId { get; set; } // 0x38
        // public override bool IsPreload { get; } 0xF80BC8
        // public override bool IsAssetBundle { get; } 0xF80BD0
        // public override string PrefabPath { get; } 0xF80BD8
        // public override string BundleName { get; } 0xF80C34
        // public override string AssetName { get; } 0xF80C90
        // public override GameObject Content { get; } 0xF80CEC
    }
}