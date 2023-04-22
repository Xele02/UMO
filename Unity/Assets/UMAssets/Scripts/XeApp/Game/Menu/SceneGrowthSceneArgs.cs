
namespace XeApp.Game.Menu
{
    public class SceneGrowthSceneArgs : TransitionArgs
    {
        public GCIJNCFDNON_SceneInfo ViewSceneData { get; private set; } // 0x8
        public bool IsFromBiginner { get; private set; } // 0xC

        // RVA: 0x10F95F8 Offset: 0x10F95F8 VA: 0x10F95F8
        public SceneGrowthSceneArgs(GCIJNCFDNON_SceneInfo viewSceneData, bool isFromBiginner = false)
        {
            IsFromBiginner = isFromBiginner;
            ViewSceneData = viewSceneData;
        }
    }
}
