
namespace XeApp.Game.Common
{
    public class PopupLuckyLeafSetting : PopupSetting
    {
        private GCIJNCFDNON_SceneInfo sceneData; // 0x34

        public GCIJNCFDNON_SceneInfo SceneData { get { return sceneData;} } //0x1BAEE50
        public override string PrefabPath { get { return ""; } } //0x1BAF29C
        public override bool IsAssetBundle { get { return true; } } //0x1BAF2F8
        public override bool IsPreload { get { return true; } } //0x1BAF300
        public override string BundleName { get { return "ly/099.xab"; } } //0x1BAF308
        public override string AssetName { get { return "root_pop_luckyleaf_01_layout_root"; } } //0x1BAF364

        // // RVA: 0x1BAF294 Offset: 0x1BAF294 VA: 0x1BAF294
        // public void Setup(GCIJNCFDNON sceneData) { }
    }
}