namespace XeApp.Game.Common
{
    public class PopupLuckyLeafTerminateSetting : PopupSetting
    {
        private GCIJNCFDNON_SceneInfo sceneData; // 0x34

        public GCIJNCFDNON_SceneInfo SceneData { get { return sceneData; } } //0x1BAF5C8
        public override string PrefabPath { get { return ""; } } //0x1BAFA14
        public override bool IsAssetBundle { get { return true; } } //0x1BAFA70
        public override bool IsPreload { get { return true; } } //0x1BAFA78
        public override string BundleName { get { return "ly/099.xab"; } } //0x1BAFA80
        public override string AssetName { get { return "root_pop_luckyleaf_02_layout_root"; } } //0x1BAFADC

        // // RVA: 0x1BAFA0C Offset: 0x1BAFA0C VA: 0x1BAFA0C
        // public void Setup(GCIJNCFDNON sceneData) { }
    }
}