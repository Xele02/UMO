using System;
using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Common
{
	public class MusicBoneSpringResource : MonoBehaviour
	{
		private static readonly int CutinLimit = 3; // 0x0
		public bool isUnused = true; // 0xC
		public RuntimeAnimatorController animatorController; // 0x10
		public AnimationClip clip; // 0x14

		public bool isLoaded { get; private set; } // 0x18
		public bool isAllLoaded { get {
			if(isUnused) return true;
			return isLoaded;
		} private set {} } //0x1118AB4 0x1118AD8

		// // RVA: 0x111878C Offset: 0x111878C VA: 0x111878C
		// public void OnDestroy() { }

		// // RVA: 0x11187A8 Offset: 0x11187A8 VA: 0x11187A8
		public void LoadMusicResouces(int wavId, int primeId, int stageDivaNum, int positionId = 0)
		{
			StartCoroutine(Co_LoadAllResouces(wavId, primeId, stageDivaNum, positionId));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x739BEC Offset: 0x739BEC VA: 0x739BEC
		// // RVA: 0x11187E0 Offset: 0x11187E0 VA: 0x11187E0
		private IEnumerator Co_LoadAllResouces(int wavId, int primeId, int stageDivaNum, int positionId)
		{
			//0x1118B58
			isLoaded = false;
			isUnused = false;
			yield return StartCoroutine(Co_LoadAnimatorResouces());
			yield return StartCoroutine(Co_LoadMusicResouces(wavId, primeId, stageDivaNum, positionId));
			isLoaded = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x739C64 Offset: 0x739C64 VA: 0x739C64
		// // RVA: 0x11188F4 Offset: 0x11188F4 VA: 0x11188F4
		private IEnumerator Co_LoadAnimatorResouces()
		{
			StringBuilder bundleName; // 0x14
			StringBuilder assetName; // 0x18
			AssetBundleLoadAllAssetOperationBase operation; // 0x1C

			//0x1118D6C
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			bundleName.SetFormat("mc/cmn/bs.xab", Array.Empty<object>());

			if(KEHOJEJMGLJ.HHCJCDFCLOB.IDJBKGBMDAJ.PPCCFNAPHCH(bundleName.ToString()))
			{
				operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
				yield return operation;
				if(!operation.IsError())
				{
					assetName.SetFormat("game_cmn_bs_animator", Array.Empty<object>());
					animatorController = operation.GetAsset<RuntimeAnimatorController>(assetName.ToString());
					AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
				}
			}

		}

		// [IteratorStateMachineAttribute] // RVA: 0x739CDC Offset: 0x739CDC VA: 0x739CDC
		// // RVA: 0x11189A0 Offset: 0x11189A0 VA: 0x11189A0
		private IEnumerator Co_LoadMusicResouces(int wavId, int primeId, int stageDivaNum, int positionId)
		{
			StringBuilder bundleName; // 0x24
			StringBuilder assetName; // 0x28
			AssetBundleLoadAllAssetOperationBase operation; // 0x2C

			//0x1119178
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			string wavName = GameManager.Instance.GetWavDirectoryName(wavId, "mc/{0}/bs/{1:D3}.xab", stageDivaNum, primeId, -1, false);
			bundleName.SetFormat("mc/{0}/bs/{1:D3}.xab", wavName, primeId);
			if(KEHOJEJMGLJ.HHCJCDFCLOB.IDJBKGBMDAJ.PPCCFNAPHCH(bundleName.ToString()))
			{
				operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
				yield return operation;
				if(!operation.IsError())
				{
					if(positionId == 0)
					{
						assetName.SetFormat("music_{0:D4}_spring_off", wavId);
					}
					else
					{
						assetName.SetFormat("music_{0:D4}_{1}_spring_off", wavId, positionId);
					}
					clip = operation.GetAsset<AnimationClip>(assetName.ToString());
					AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
				}
			}
		}
	}
}
