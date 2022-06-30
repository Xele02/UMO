
namespace XeApp.Game.Menu
{
    public class SceneStackInfo // TypeDefIndex: 10886
    {
        public TransitionList.Type name; // 0x8
        public SceneCacheCategory cacheCategory; // 0xC
        public SceneGroupCategory groupCategory; // 0x10
        public TransitionArgs args; // 0x14
        public int fadeId; // 0x18 // Init 0x20 0xff ?
        public CommonMenuStackLabel.LabelType titleLabel; // 0x1C
        public int descId; // 0x20
        public int bgmId; // 0x24
        public BgType bgType; // 0x28
        public int bgId; // 0x2C
        public int bgAttr; // 0x30
        public int uniqueId; // 0x34
        public StoryBgParam storyBgParam; // 0x38

        // RVA: 0xA59734 Offset: 0xA59734 VA: 0xA59734
        // public void Copy(SceneStackInfo o) { }
    }
}