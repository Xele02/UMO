using UnityEngine;
using XeApp.Game;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using XeApp.Core;
using XeSys;
using System;

namespace XeApp.Game.Common
{
	public class DivaExtensionResource : MonoBehaviour
	{
		public bool isUnused = true; // 0xC
		public MusicExtensionPrefabParam param; // 0x10
		public List<GameObject> prefabList; // 0x14
		public int divaId; // 0x18
		public AnimationClip clip; // 0x1C
		public RuntimeAnimatorController animatorController; // 0x20

		public bool isLoaded { get; private set; } // 0x24
		public bool isAllLoaded { get { return isUnused || isLoaded; } private set { } } //0x1BEF430 0x1BEF454

		// // RVA: 0x1BEF140 Offset: 0x1BEF140 VA: 0x1BEF140
		public void OnDestroy()
		{
			clip = null;
		}

		// // RVA: 0x1BEF15C Offset: 0x1BEF15C VA: 0x1BEF15C
		public void LoadResouces(int wavId, int assetId, int divaId, int stageDivaNum)
		{
			this.divaId = divaId;
			StartCoroutine(Co_LoadAllResouces(wavId, assetId, stageDivaNum));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x737D38 Offset: 0x737D38 VA: 0x737D38
		// // RVA: 0x1BEF194 Offset: 0x1BEF194 VA: 0x1BEF194
		private IEnumerator Co_LoadAllResouces(int wavId, int assetId, int stageDivaNum)
		{
			//0x1BEF46C
			isLoaded = false;
			isUnused = false;
			yield return StartCoroutine(Co_LoadBasicResouces());
			yield return StartCoroutine(Co_LoadMusicResouces(wavId, assetId, stageDivaNum));
			isLoaded = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x737DB0 Offset: 0x737DB0 VA: 0x737DB0
		// // RVA: 0x1BEF28C Offset: 0x1BEF28C VA: 0x1BEF28C
		private IEnumerator Co_LoadBasicResouces()
		{
			StringBuilder bundleName;
			StringBuilder assetName;
			AssetBundleLoadAllAssetOperationBase operation;
			//0x1BEF670
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			bundleName.SetFormat("mc/cmn/dr/dv.xab", Array.Empty<object>());
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			assetName.SetFormat("dr_dv_cmn_animator", Array.Empty<object>());
			animatorController = operation.GetAsset<RuntimeAnimatorController>(assetName.ToString());
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x737E28 Offset: 0x737E28 VA: 0x737E28
		// // RVA: 0x1BEF338 Offset: 0x1BEF338 VA: 0x1BEF338
		private IEnumerator Co_LoadMusicResouces(int wavId, int assetId, int stageDivaNum)
		{
			StringBuilder bundleName;
			StringBuilder assetName;
			AssetBundleLoadAllAssetOperationBase operation;
			//0x1BEF9A8
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			string wavName = GameManager.Instance.GetWavDirectoryName(wavId, "mc/{0}/dr/dv/{1:D3}.xab", stageDivaNum, 1, assetId, false);
			bundleName.SetFormat("mc/{0}/dr/dv/{1:D3}.xab", wavName, assetId);
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			assetName.SetFormat("dr_dv_{0:D3}_param", assetId);
			param = operation.GetAsset<MusicExtensionPrefabParam>(assetName.ToString());
			assetName.SetFormat("dr_dv_{0:D3}_anim", assetId);
			clip = operation.GetAsset<AnimationClip>(assetName.ToString());
			prefabList = new List<GameObject>(param.attachDataList.Count);
			for(int i = 0; i < param.attachDataList.Count; i++)
			{
				assetName.SetFormat("dr_dv_{0:D3}_prefab_{1:D2}", assetId, i + 1);
				prefabList.Add(operation.GetAsset<GameObject>(assetName.ToString()));
			}
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
		}
	}
}
