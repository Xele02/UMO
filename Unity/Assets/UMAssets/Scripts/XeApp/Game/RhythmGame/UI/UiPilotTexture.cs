using System.Collections;
using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
    public class UiPilotTexture : UiReplaceTexture
    {
        private Texture2D mainTexture; // 0x10

        // [IteratorStateMachineAttribute] // RVA: 0x747704 Offset: 0x747704 VA: 0x747704
        // // RVA: 0x1569158 Offset: 0x1569158 VA: 0x1569158
        public IEnumerator Load(int pilotNo)
		{
			//0x1569338
			yield return Load(string.Format("ct/pl/{0:D3}.xab", pilotNo), pilotNo.ToString("000"), (Texture2D tex) =>
			{
				//0x156932C
				mainTexture = tex;
			});
		}

		// // RVA: 0x1569220 Offset: 0x1569220 VA: 0x1569220 Slot: 4
		// public override void Set(Material material) { }

		// // RVA: 0x156931C Offset: 0x156931C VA: 0x156931C Slot: 5
		public override void OnDestory()
		{
			mainTexture = null;
		}
    }
}
