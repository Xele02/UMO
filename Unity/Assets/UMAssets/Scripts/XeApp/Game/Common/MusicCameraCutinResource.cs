using System;
using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Common
{
	public class MusicCameraCutinResource : MonoBehaviour
	{
		private static readonly int CutinLimit = 3; // 0x0
		public bool isUnused = true; // 0xC
		public AnimationClip clip; // 0x10
		public RuntimeAnimatorController animatorController; // 0x14
		public AnimationClip[] cutinClips; // 0x18
		
		public bool isLoaded { get; private set; } // 0x1C
		public bool isAllLoaded { get { return isUnused || isLoaded; } private set {} } //0x111A5A4 0x111A5C8

		// // RVA: 0x111A2C0 Offset: 0x111A2C0 VA: 0x111A2C0
		// public void OnDestroy() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73A10C Offset: 0x73A10C VA: 0x73A10C
		// // RVA: 0x111A2CC Offset: 0x111A2CC VA: 0x111A2CC
		// public bool get_isLoaded() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73A11C Offset: 0x73A11C VA: 0x73A11C
		// // RVA: 0x111A2D4 Offset: 0x111A2D4 VA: 0x111A2D4
		// private void set_isLoaded(bool value) { }

		// // RVA: 0x111A2DC Offset: 0x111A2DC VA: 0x111A2DC
		public void LoadResouces(int wavId, int assetId, int stageDivaNum)
		{
			StartCoroutine(Co_LoadAllResouces(wavId, assetId, stageDivaNum));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73A12C Offset: 0x73A12C VA: 0x73A12C
		// // RVA: 0x111A308 Offset: 0x111A308 VA: 0x111A308
		private IEnumerator Co_LoadAllResouces(int wavId, int assetId, int stageDivaNum)
		{
			//0x111A648
			isLoaded = false;
			isUnused = false;
			yield return StartCoroutine(Co_LoadBasicResouces());
			yield return StartCoroutine(Co_LoadMusicResouces(wavId, assetId, stageDivaNum));
			isLoaded = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73A1A4 Offset: 0x73A1A4 VA: 0x73A1A4
		// // RVA: 0x111A400 Offset: 0x111A400 VA: 0x111A400
		private IEnumerator Co_LoadBasicResouces()
		{
			StringBuilder bundleName;
			StringBuilder assetName;
			AssetBundleLoadAllAssetOperationBase operation;
			//0x111A84C
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			bundleName.SetFormat("mc/cmn/dr/cc.xab", Array.Empty<object>());
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			assetName.SetFormat("dr_cc_cmn_animator", Array.Empty<object>());
			animatorController = operation.GetAsset<RuntimeAnimatorController>(assetName.ToString());
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73A21C Offset: 0x73A21C VA: 0x73A21C
		// // RVA: 0x111A4AC Offset: 0x111A4AC VA: 0x111A4AC
		private IEnumerator Co_LoadMusicResouces(int wavId, int assetId, int stageDivaNum)
		{
			StringBuilder bundleName;
			StringBuilder assetName;
			AssetBundleLoadAllAssetOperationBase operation;
			//0x111AB84
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			string wavName = GameManager.Instance.GetWavDirectoryName(wavId, "mc/{0}/dr/cc/{1:D3}.xab", stageDivaNum, 1, assetId, false);
			bundleName.SetFormat("mc/{0}/dr/cc/{1:D3}.xab", wavName, assetId);
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			assetName.SetFormat("dr_cc_{0:D3}_anim", assetId);
			clip = operation.GetAsset<AnimationClip>(assetName.ToString());
			cutinClips = new AnimationClip[CutinLimit];
			for(int i = 0; i < 3; i++)
			{
				assetName.SetFormat("dr_cc_{0:D3}_cut_{1:D2}", assetId, i + 1);
				cutinClips[i] = operation.GetAsset<AnimationClip>(assetName.ToString());
			}
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
		}
	}
}
