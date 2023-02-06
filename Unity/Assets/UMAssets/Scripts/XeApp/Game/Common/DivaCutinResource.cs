using System;
using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Common
{
	public class DivaCutinResource : MonoBehaviour
	{
		public static readonly int CutinLimit = 3; // 0x0
		public bool isUnused = true; // 0xC
		public AnimationClip clip; // 0x10
		public AnimationClip clipBoneSpring; // 0x14
		public RuntimeAnimatorController animatorController; // 0x18
		public AnimationClip[] cutinBodyClips; // 0x1C
		public AnimationClip[] cutinFaceClips; // 0x20
		public AnimationClip[] cutinMouthClips; // 0x24
		public AnimationClip[] cutinMikeClips; // 0x28
		public AnimationClip[] cutinBoneSpringClips; // 0x2C
		public int divaId; // 0x30

		public bool isLoaded { get; private set; } // 0x34
		public bool isAllLoaded { get { return isUnused || isLoaded; } private set {} } //0x1BE79DC 0x1BE7A00

		// RVA: 0x1BE76EC Offset: 0x1BE76EC VA: 0x1BE76EC
		public void OnDestroy()
		{
			clip = null;
		}

		// // RVA: 0x1BE7708 Offset: 0x1BE7708 VA: 0x1BE7708
		public void LoadResouces(int wavId, int assetId, int divaId, int stageDivaNum)
		{
			this.divaId = divaId;
			this.StartCoroutineWatched(Co_LoadAllResouces(wavId, assetId, stageDivaNum));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7379F8 Offset: 0x7379F8 VA: 0x7379F8
		// // RVA: 0x1BE7740 Offset: 0x1BE7740 VA: 0x1BE7740
		private IEnumerator Co_LoadAllResouces(int wavId, int assetId, int stageDivaNum)
		{
			//0x1BE7A80
			isLoaded = false;
			isUnused = false;
			yield return this.StartCoroutineWatched(Co_LoadBasicResouces());
			yield return this.StartCoroutineWatched(Co_LoadMusicResouces(wavId, assetId, stageDivaNum));
			isLoaded = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x737A70 Offset: 0x737A70 VA: 0x737A70
		// // RVA: 0x1BE7838 Offset: 0x1BE7838 VA: 0x1BE7838
		private IEnumerator Co_LoadBasicResouces()
		{
			StringBuilder bundleName;
			StringBuilder assetName;
			AssetBundleLoadAllAssetOperationBase operation;
			//0x1BE7C84
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			bundleName.SetFormat("mc/cmn/dr/dc.xab", Array.Empty<object>());
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return Co.R(operation);
			assetName.SetFormat("dr_dc_cmn_animator", Array.Empty<object>());
			animatorController = operation.GetAsset<RuntimeAnimatorController>(assetName.ToString());
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x737AE8 Offset: 0x737AE8 VA: 0x737AE8
		// // RVA: 0x1BE78E4 Offset: 0x1BE78E4 VA: 0x1BE78E4
		private IEnumerator Co_LoadMusicResouces(int wavId, int assetId, int stageDivaNum)
		{
			StringBuilder bundleName;
			StringBuilder assetName;
			AssetBundleLoadAllAssetOperationBase operation;
			//0x1BE7FBC
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			string wavName = GameManager.Instance.GetWavDirectoryName(wavId, "mc/{0}/dr/dc/{1:D3}.xab", stageDivaNum, 1, assetId, false);
			bundleName.SetFormat("mc/{0}/dr/dc/{1:D3}.xab", wavName, assetId);
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return Co.R(operation);
			assetName.SetFormat("dr_dc_{0:D3}_anim", assetId);
			clip = operation.GetAsset<AnimationClip>(assetName.ToString());
			assetName.SetFormat("dr_dc_{0:D3}_spring_off", assetId);
			clipBoneSpring = operation.GetAsset<AnimationClip>(assetName.ToString());
			cutinBodyClips = new AnimationClip[CutinLimit];
			cutinFaceClips = new AnimationClip[CutinLimit];
			cutinMouthClips = new AnimationClip[CutinLimit];
			cutinMikeClips = new AnimationClip[CutinLimit];
			cutinBoneSpringClips = new AnimationClip[CutinLimit];
			for(int i = 0; i < CutinLimit; i++)
			{
				assetName.SetFormat("dr_dc_{0:D3}_cut_{1:D2}_body", assetId, i + 1);
				cutinBodyClips[i] = operation.GetAsset<AnimationClip>(assetName.ToString());
				assetName.SetFormat("dr_dc_{0:D3}_cut_{1:D2}_face", assetId, i + 1);
				cutinFaceClips[i] = operation.GetAsset<AnimationClip>(assetName.ToString());
				assetName.SetFormat("dr_dc_{0:D3}_cut_{1:D2}_mouth", assetId, i + 1);
				cutinMouthClips[i] = operation.GetAsset<AnimationClip>(assetName.ToString());
				assetName.SetFormat("dr_dc_{0:D3}_cut_{1:D2}_mike", assetId, i + 1);
				cutinMikeClips[i] = operation.GetAsset<AnimationClip>(assetName.ToString());
				assetName.SetFormat("dr_dc_{0:D3}_cut_{1:D2}_spring_off", assetId, i + 1);
				cutinBoneSpringClips[i] = operation.GetAsset<AnimationClip>(assetName.ToString());
			}
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
		}
	}
}
