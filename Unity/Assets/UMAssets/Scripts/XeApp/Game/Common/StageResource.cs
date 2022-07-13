using System;
using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game;
using XeSys;

namespace XeApp.Game.Common
{
	public class StageResource : MonoBehaviour
	{
		public GameObject prefab; // 0xC
		public StageParam param; // 0x10

		public bool isLoadedPrefab { get; private set; } // 0x14
		public bool isAllLoaded { get { return isLoadedPrefab; } private set {} } //0x1CC95FC 0x1CC9604


		// // RVA: 0x1CC94D0 Offset: 0x1CC94D0 VA: 0x1CC94D0
		// public void OnDestroy() { }

		// // RVA: 0x1CC94EC Offset: 0x1CC94EC VA: 0x1CC94EC
		public void LoadResouces(int stageId, Func<int> getSpecialStageId)
		{
			isLoadedPrefab = false;
			StartCoroutine(Co_LoadResouces(stageId, getSpecialStageId));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73B5C0 Offset: 0x73B5C0 VA: 0x73B5C0
		// // RVA: 0x1CC951C Offset: 0x1CC951C VA: 0x1CC951C
		private IEnumerator Co_LoadResouces(int stageId, Func<int> getSpecialStageId)
		{
			StringBuilder bundleName; // 0x20
			StringBuilder assetName; // 0x24
			AssetBundleLoadAllAssetOperationBase operation; // 0x28
			GameObject tmpRoot; // 0x2C

			//0x1CC96A4
			if(getSpecialStageId != null)
			{
				yield return new WaitWhile(() =>
				{
					//0x1CC9618
					return getSpecialStageId() == -1;
				});
				if (getSpecialStageId() > 0)
				{
					stageId = getSpecialStageId();
				}
			}
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			bundleName.SetFormat("st/{0:D4}.xab", stageId);
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			assetName.SetFormat("stg_{0:D4}_prefab", stageId);
			prefab = operation.GetAsset<GameObject>(assetName.ToString());
			assetName.SetFormat("stg_{0:D4}_param", stageId);
			param = operation.GetAsset<StageParam>(assetName.ToString());
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
			bool fin = false;
			tmpRoot = UnityEngine.Object.Instantiate<GameObject>(prefab);
			WarmupTexturesGenerator.Instance.Create(tmpRoot, () =>
			{
				//0x1CC9694
				fin = true;
			});
			while (!fin)
				yield return null;
			Destroy(tmpRoot);
			isLoadedPrefab = true;
		}
	}
}
