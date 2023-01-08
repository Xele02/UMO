
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
    public enum SceneSelectType
    {
        SceneSelect = 0,
        SceneList = 1,
    }
    public class TeamSelectSceneListArgs : TransitionArgs
    {
        public int divaSlotIndex; // 0x8
        public int defaultSelectScene; // 0xC
        public SceneSelectType scelectType; // 0x10
        public FFHPBEPOMAK divaData; // 0x14
        public bool isGoDiva; // 0x18
        public EAJCBFGKKFA friendPlayerData; // 0x1C
        public EEDKAACNBBG musicBaseData; // 0x20
        public EJKBKMBJMGL_EnemyData enemyData; // 0x24
        public Difficulty.Type difficulty; // 0x28
    }
}