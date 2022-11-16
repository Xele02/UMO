using System;
using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game;
using XeSys;

namespace XeApp.Game.Common
{
	public class MusicCameraResource : MonoBehaviour
	{
		public RuntimeAnimatorController animator; // 0xC
		public AnimationClip clip; // 0x10
		public MusicCameraParam m_param; // 0x14

		public bool isAllLoaded { get { return isLoadedAnimator && isLoadedMusicClip && isLoadedParam; } private set {} } //0xAE547C 0xAE54C0
		private bool isLoadedAnimator { get; set; } // 0x18
		private bool isLoadedMusicClip { get; set; } // 0x19
		private bool isLoadedParam { get; set; } // 0x1A

		// // RVA: 0xAE534C Offset: 0xAE534C VA: 0xAE534C
		public void OnDestroy()
		{
			animator = null;
			clip = null;
		}

		// // RVA: 0xAE535C Offset: 0xAE535C VA: 0xAE535C
		public void LoadResource(int wavId, int primeId, int stageDivaNum)
		{
			isLoadedParam = false;
			StartCoroutine(Co_LoadParam(wavId, stageDivaNum));
			isLoadedAnimator = false;
			StartCoroutine(Co_LoadAnimator());
			isLoadedMusicClip = false;
			StartCoroutine(Co_LoadMusicClipResouces(wavId, primeId, stageDivaNum));

		}

		// // RVA: 0xAE5414 Offset: 0xAE5414 VA: 0xAE5414
		// private void LoadAnimatorResouces() { }

		// [IteratorStateMachineAttribute] // RVA: 0x739E64 Offset: 0x739E64 VA: 0x739E64
		// // RVA: 0xAE54CC Offset: 0xAE54CC VA: 0xAE54CC
		private IEnumerator Co_LoadAnimator()
		{
			StringBuilder bundleName;
			AssetBundleLoadAllAssetOperationBase operation;

			//0xAE576C
			bundleName = new StringBuilder();
			bundleName.SetFormat("mc/cmn/ca.xab", Array.Empty<object>());
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			animator = operation.GetAsset<RuntimeAnimatorController>("game_cmn_cam_animator");
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
			isLoadedAnimator = true;
		}

		// // RVA: 0xAE5444 Offset: 0xAE5444 VA: 0xAE5444
		// private void LoadMusicClipResouces(int wavId, int primeId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x739EFC Offset: 0x739EFC VA: 0x739EFC
		// // RVA: 0xAE5580 Offset: 0xAE5580 VA: 0xAE5580
		private IEnumerator Co_LoadMusicClipResouces(int wavId, int primeId, int stageDivaNum)
		{
			StringBuilder bundleName; // 0x20
			StringBuilder assetName; // 0x24
			AssetBundleLoadAllAssetOperationBase operation; // 0x28
			string wavIdString; // 0x2C

			//0xAE5A58
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			wavIdString = GameManager.Instance.GetWavDirectoryName(wavId, "mc/{0}/bt{1:D3}.xab", stageDivaNum, primeId, -1, true);
			bundleName.SetFormat("mc/{0}/bt{1:D3}.xab", wavIdString, primeId);
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			assetName.SetFormat("music_{0}_prime_{1:D3}_cam", wavIdString, primeId);
			clip = operation.GetAsset<AnimationClip>(assetName.ToString());
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
			isLoadedMusicClip = true;
		}

		// // RVA: 0xAE53E4 Offset: 0xAE53E4 VA: 0xAE53E4
		// private void LoadParam(int wavId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x739F94 Offset: 0x739F94 VA: 0x739F94
		// // RVA: 0xAE5680 Offset: 0xAE5680 VA: 0xAE5680
		private IEnumerator Co_LoadParam(int waveId, int stageDivaNum)
		{
			StringBuilder strBuilder; // 0x1C
			AssetBundleLoadAllAssetOperationBase operation; // 0x20
			//0xAE5E60
			strBuilder = new StringBuilder();
			string wavIdString = GameManager.Instance.GetWavDirectoryName(waveId, "mc/{0}/sc.xab", stageDivaNum, 1, -1, true);
			strBuilder.SetFormat("mc/{0}/sc.xab", wavIdString);
			operation = AssetBundleManager.LoadAllAssetAsync(strBuilder.ToString());
			yield return operation;
			StringBuilder strBuilder2 = new StringBuilder(); // fix original game bug where they release wrong bundle name;
			strBuilder2.SetFormat("mcp_{0:D4}", waveId);
			m_param = operation.GetAsset<MusicCameraParam>(strBuilder2.ToString());
			AssetBundleManager.UnloadAssetBundle(strBuilder.ToString());
			isLoadedParam = true;
		}
	}
}
