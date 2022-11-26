using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game;
using XeSys;

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
		public void OnDestroy()
		{
			return;
		}

		// // RVA: 0xAECF54 Offset: 0xAECF54 VA: 0xAECF54
		public void LoadResouces(int wavId, int assetId, int stageDivaNum)
		{
			StartCoroutine(Co_LoadAllResouces(wavId, assetId, stageDivaNum));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73CBE8 Offset: 0x73CBE8 VA: 0x73CBE8
		// // RVA: 0xAECF80 Offset: 0xAECF80 VA: 0xAECF80
		private IEnumerator Co_LoadAllResouces(int wavId, int assetId, int stageDivaNum)
		{
			StringBuilder bundleName; // 0x20
			StringBuilder assetName; // 0x24
			AssetBundleLoadAllAssetOperationBase operation; // 0x28

			//0xAED0B4
			isLoaded = false;
			isUnused = false;
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			string wavName = GameManager.Instance.GetWavDirectoryName(wavId, "mc/{0}/dr/vo/{1:D3}.xab", stageDivaNum, 1, assetId, false);
			bundleName.SetFormat("mc/{0}/dr/vo/{1:D3}.xab", wavName, assetId);

			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;

			assetName.SetFormat("dr_vo_{0:D3}", assetId);
			param = operation.GetAsset<MusicVoiceChangerParam>(assetName.ToString());

			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
			isLoaded = true;
		}
	}
}
