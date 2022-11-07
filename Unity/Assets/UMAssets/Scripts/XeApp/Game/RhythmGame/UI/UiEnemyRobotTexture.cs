using System.Collections;
using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
    public class UiEnemyRobotTexture : UiReplaceTexture
    {
        private Texture2D mainTexture; // 0x10

        // [IteratorStateMachineAttribute] // RVA: 0x747A84 Offset: 0x747A84 VA: 0x747A84
        // // RVA: 0x1568DFC Offset: 0x1568DFC VA: 0x1568DFC
        public IEnumerator Load(int robotNo)
		{
			//0x1568F64
			yield return Load(string.Format("ct/em/mh/{0:D3}.xab", robotNo), robotNo.ToString("000"), (Texture2D tex) =>
			{
				//0x1568F58
				mainTexture = tex;
			});
		}

		// // RVA: 0x1568EC4 Offset: 0x1568EC4 VA: 0x1568EC4 Slot: 4
		public override void Set(Material material)
		{
			material.SetTexture("_MainTex", mainTexture);
		}

		// // RVA: 0x1568F48 Offset: 0x1568F48 VA: 0x1568F48 Slot: 5
		public override void OnDestory()
		{
			mainTexture = null;
		}
    }
}
