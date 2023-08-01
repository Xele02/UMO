using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game;
using XeSys;

namespace XeApp.Game.Common
{
	public class MusicStageChangerResource : MonoBehaviour
	{
		public bool isUnused = true; // 0xC
		public MusicStageChangerParam param; // 0x10

		public bool isLoaded { get; private set; } // 0x14
		public bool isAllLoaded { get { return isUnused || isLoaded; } private set { } } //0xAEB69C 0xAEB6C0

		// RVA: 0xAEB564 Offset: 0xAEB564 VA: 0xAEB564
		public void OnDestroy()
		{
			TodoLogger.LogError(0, "MusicStageChangerResource OnDestroy");
		}

		// RVA: 0xAEB578 Offset: 0xAEB578 VA: 0xAEB578
		public void LoadResouces(int wavId, int assetId, int stageDivaNum)
		{
			this.StartCoroutineWatched(Co_LoadAllResouces(wavId, assetId, stageDivaNum));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x73B6A8 Offset: 0x73B6A8 VA: 0x73B6A8
		// RVA: 0xAEB5A4 Offset: 0xAEB5A4 VA: 0xAEB5A4
		private IEnumerator Co_LoadAllResouces(int wavId, int assetId, int stageDivaNum)
		{
			StringBuilder bundleName;
			StringBuilder assetName;
			AssetBundleLoadAllAssetOperationBase operation;
			//0xAEB6D8
			isUnused = false;
			isLoaded = false;
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			string wavName = GameManager.Instance.GetWavDirectoryName(wavId, "mc/{0}/dr/sc/{1:D3}.xab", stageDivaNum, 1, assetId, false);
			bundleName.SetFormat("mc/{0}/dr/sc/{1:D3}.xab", wavName, assetId);
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return Co.R(operation);
			assetName.SetFormat("dr_sc_{0:D3}_param", assetId);
			param = operation.GetAsset<MusicStageChangerParam>(assetName.ToString());
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
			isLoaded = true;
		}
	}
}
