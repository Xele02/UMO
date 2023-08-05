using System.Collections;
using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
    public class UiEnemyPilotTexture : UiReplaceTexture
    {
        private Texture2D mainTexture; // 0x10

        // [IteratorStateMachineAttribute] // RVA: 0x7479AC Offset: 0x7479AC VA: 0x7479AC
        // // RVA: 0x1568AA0 Offset: 0x1568AA0 VA: 0x1568AA0
        public IEnumerator Load(int pilotNo)
		{
			//0x1568C08
			yield return Co.R(Load(string.Format("ct/em/pl/{0:D3}.xab", pilotNo), pilotNo.ToString("000"), (Texture2D tex) =>
			{
				//0x1568BFC
				mainTexture = tex;
			}));
		}

		// // RVA: 0x1568B68 Offset: 0x1568B68 VA: 0x1568B68 Slot: 4
		public override void Set(Material material)
		{
			material.SetTexture("_MainTex", mainTexture);
		}

		// // RVA: 0x1568BEC Offset: 0x1568BEC VA: 0x1568BEC Slot: 5
		public override void OnDestory()
		{
			mainTexture = null;
		}
    }
}
