using System;
using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Common
{
	public class StageLightingResource : MonoBehaviour
	{
		public static readonly int MAX_CLIP_ADD = 5; // 0x0
		public bool isUnused = true; // 0xC
		public AnimationClip clip; // 0x10
		public AnimationClip[] clip_add = new AnimationClip[MAX_CLIP_ADD]; // 0x14
		public RuntimeAnimatorController animatorController; // 0x18
		private int targetDivaId; // 0x1C
		
		public bool isLoadedAnim { get; private set; } // 0x20
		public bool isAllLoaded { get { return isUnused || isLoadedAnim; } private set {} } //0x1CC7D9C 0x1CC7DC0

		// // RVA: 0x1CC79E0 Offset: 0x1CC79E0 VA: 0x1CC79E0
		public void OnDestroy()
		{
			clip = null;
			for(int i = 0; i < MAX_CLIP_ADD; i++)
			{
				clip_add[i] = null;
			}
		}

		// // RVA: 0x1CC7AD4 Offset: 0x1CC7AD4 VA: 0x1CC7AD4
		public void LoadResouces(int wavId, int assetId, int stageDivaNum)
		{
			this.StartCoroutineWatched(Co_LoadAllResouces(wavId, assetId, stageDivaNum));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73BAF0 Offset: 0x73BAF0 VA: 0x73BAF0
		// // RVA: 0x1CC7B00 Offset: 0x1CC7B00 VA: 0x1CC7B00
		private IEnumerator Co_LoadAllResouces(int wavId, int assetId, int stageDivaNum)
		{
			//0x1CC7EEC
			isLoadedAnim = false;
			isUnused = false;
			yield return this.StartCoroutineWatched(Co_LoadBasicResouces());
			yield return this.StartCoroutineWatched(Co_LoadMusicResouces(wavId, assetId, stageDivaNum));
			isLoadedAnim = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73BB68 Offset: 0x73BB68 VA: 0x73BB68
		// // RVA: 0x1CC7BF8 Offset: 0x1CC7BF8 VA: 0x1CC7BF8
		private IEnumerator Co_LoadBasicResouces()
		{
			StringBuilder bundleName; // 0x14
			StringBuilder assetName; // 0x18
			AssetBundleLoadAllAssetOperationBase operation; // 0x1C

			//0x1CC80F0
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			bundleName.SetFormat("mc/cmn/dr/li.xab", Array.Empty<object>());
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			assetName.SetFormat("dr_li_cmn_animator", Array.Empty<object>());
			animatorController = operation.GetAsset<RuntimeAnimatorController>(assetName.ToString());
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73BBE0 Offset: 0x73BBE0 VA: 0x73BBE0
		// // RVA: 0x1CC7CA4 Offset: 0x1CC7CA4 VA: 0x1CC7CA4
		private IEnumerator Co_LoadMusicResouces(int wavId, int assetId, int stageDivaNum)
		{
			StringBuilder bundleName; // 0x20
			StringBuilder assetName; // 0x24
			AssetBundleLoadAllAssetOperationBase operation; // 0x28

			//0x1CC8428
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			string wavName = GameManager.Instance.GetWavDirectoryName(wavId, "mc/{0}/dr/li/{1:D3}.xab", stageDivaNum, 1, assetId, false);
			bundleName.SetFormat("mc/{0}/dr/li/{1:D3}.xab", wavName, assetId);
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			assetName.SetFormat("dr_li_{0:D3}", assetId);
			clip = operation.GetAsset<AnimationClip>(assetName.ToString());
			for(int i = 0; i < MAX_CLIP_ADD; i++)
			{
				assetName.SetFormat("dr_li_{0:D3}_add_{1}", assetId, i+1);
				clip_add[i] = operation.GetAsset<AnimationClip>(assetName.ToString());
			}
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
		}
	}
}
