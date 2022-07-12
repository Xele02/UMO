using UnityEngine;
using XeApp.Game;

namespace XeApp.Game.Common
{
	public class MusicVoiceChangerResource : MonoBehaviour
	{
		public bool isUnused = true; // 0xC
		public MusicVoiceChangerParam param; // 0x10
		public int wavId; // 0x14
		public int assetId; // 0x18

		public bool isLoaded { get; private set; } // 0x1C
		public bool isAllLoaded { get { return isUnused || isLoaded; } private set {} } //0xAED078 0xAED09C

		// // RVA: 0xAECF40 Offset: 0xAECF40 VA: 0xAECF40
		// public void OnDestroy() { }

		// // RVA: 0xAECF54 Offset: 0xAECF54 VA: 0xAECF54
		// public void LoadResouces(int wavId, int assetId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73CBE8 Offset: 0x73CBE8 VA: 0x73CBE8
		// // RVA: 0xAECF80 Offset: 0xAECF80 VA: 0xAECF80
		// private IEnumerator Co_LoadAllResouces(int wavId, int assetId, int stageDivaNum) { }
	}
}
