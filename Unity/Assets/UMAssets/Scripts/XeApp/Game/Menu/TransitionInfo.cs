
namespace XeApp.Game.Menu
{
    public class TransitionInfo // TypeDefIndex: 10885
    {
        public TransitionList.Type name; // 0x8
        public SceneCacheCategory cacheCategory; // 0xC
        public SceneGroupCategory groupCategory; // 0x10
        public int uniqueId = 0xff0020; // 0x14
        public int fadeId; // 0x18
        public CommonMenuStackLabel.LabelType titleLabel; // 0x1C
        public int descId; // 0x20
        public int bgmId; // 0x24
        public BgType bgType; // 0x28
        public int bgId; // 0x2C
        public int bgAttr; // 0x30
        public TransitionArgs args; // 0x34
        public TransitionArgs args_return; // 0x38
        public TransitionList.Type parentTransition; // 0x3C
        public MenuScene.MenuSceneCamebackInfo.CamBackUnityScene camBackUnityScene; // 0x40
        public bool isForceFading; // 0x44

        // RVA: 0xA9D570 Offset: 0xA9D570 VA: 0xA9D570
        public TransitionInfo()
        {
            groupCategory = SceneGroupCategory.UNDEFINED;
            name = TransitionList.Type.UNDEFINED;
            parentTransition = TransitionList.Type.UNDEFINED;
            camBackUnityScene = 0;
            titleLabel = CommonMenuStackLabel.LabelType._Undefined;
            isForceFading = false;
        }
    }
}