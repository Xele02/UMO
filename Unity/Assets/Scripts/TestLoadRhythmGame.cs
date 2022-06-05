using XeApp.Core;
using XeApp.Game;

public class TestLoadRhythmGame : MainSceneBase
{
    // // RVA: 0xE5CA64 Offset: 0xE5CA64 VA: 0xE5CA64 Slot: 10
    // protected override void DoStart() { }

    // // RVA: 0xE5CAE0 Offset: 0xE5CAE0 VA: 0xE5CAE0 Slot: 12
    protected override bool DoUpdateEnter()
    {
        if(GameManager.Instance != null)
        {
            if(GameManager.Instance.IsInitializedSystemLayout())
            {
                NextScene("RhythmGame");
                return true;
            }
        }
        return false;
    }

    // // RVA: 0xE5CD14 Offset: 0xE5CD14 VA: 0xE5CD14
    // private void OnGUI() { }

    // // RVA: 0xE5CD24 Offset: 0xE5CD24 VA: 0xE5CD24 Slot: 11
    // protected override void DoOnGUI() { }

    // // RVA: 0xE5CD28 Offset: 0xE5CD28 VA: 0xE5CD28 Slot: 13
    // protected override void DoUpdateMain() { }
}
