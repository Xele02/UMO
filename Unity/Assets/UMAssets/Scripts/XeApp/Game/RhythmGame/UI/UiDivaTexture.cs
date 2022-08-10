using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
    public class UiDivaTexture : UiReplaceTexture
    {
        private Texture2D mainTexture; // 0x10
        private Texture2D maskTexture; // 0x14
        private Texture2D bgTexture; // 0x18

        // [IteratorStateMachineAttribute] // RVA: 0x7477DC Offset: 0x7477DC VA: 0x7477DC
        // // RVA: 0x1567E34 Offset: 0x1567E34 VA: 0x1567E34
        // public IEnumerator Load(Texture2D liveCutBaseTexture, Texture2D liveCutMaskTexture) { }

        // [IteratorStateMachineAttribute] // RVA: 0x747854 Offset: 0x747854 VA: 0x747854
        // // RVA: 0x1567F14 Offset: 0x1567F14 VA: 0x1567F14
        // public IEnumerator Load(int divaId, int modelId, int colorId) { }

        // // RVA: 0x156800C Offset: 0x156800C VA: 0x156800C Slot: 4
        // public override void Set(Material material) { }

        // // RVA: 0x15680F8 Offset: 0x15680F8 VA: 0x15680F8 Slot: 5
        // public override void OnDestory() { }

        // // RVA: 0x156810C Offset: 0x156810C VA: 0x156810C
        public UiDivaTexture()
		{
			TodoLogger.Log(0, "TODO");
		}

        // [CompilerGeneratedAttribute] // RVA: 0x7478CC Offset: 0x7478CC VA: 0x7478CC
        // // RVA: 0x15681A4 Offset: 0x15681A4 VA: 0x15681A4
        // private void <Load>b__3_0(Texture2D tex) { }

        // [CompilerGeneratedAttribute] // RVA: 0x7478DC Offset: 0x7478DC VA: 0x7478DC
        // // RVA: 0x15681AC Offset: 0x15681AC VA: 0x15681AC
        // private void <Load>b__4_0(Texture2D tex) { }

        // [CompilerGeneratedAttribute] // RVA: 0x7478EC Offset: 0x7478EC VA: 0x7478EC
        // // RVA: 0x15681B4 Offset: 0x15681B4 VA: 0x15681B4
        // private void <Load>b__4_1(Texture2D tex) { }

        // [CompilerGeneratedAttribute] // RVA: 0x7478FC Offset: 0x7478FC VA: 0x7478FC
        // // RVA: 0x15681BC Offset: 0x15681BC VA: 0x15681BC
        // private void <Load>b__4_2(Texture2D tex) { }
    }
}