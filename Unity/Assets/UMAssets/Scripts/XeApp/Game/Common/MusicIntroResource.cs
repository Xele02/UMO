using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Common
{
	public class MusicIntroResource : MonoBehaviour
	{
		
		public class OverrideAnimationClip
		{
			public AnimationClip m_idle; // 0x8
			public AnimationClip m_takeoff; // 0xC
		}

		public OverrideAnimationClip m_override_anim = new OverrideAnimationClip(); // 0x1C

		public GameObject runwayPrefab { get; private set; } // 0xC
		public GameObject enviromentPrefab { get; private set; } // 0x10
		public ValkyrieColorParam paramColor { get; private set; } // 0x14
		public ValkyrieIntroParam paramIntro { get; private set; } // 0x18
		public bool isLoadedRunway { get; private set; } // 0x20
		public bool isLoadedEnviroment { get; private set; } // 0x21
		public bool isLoadedAnimator { get; private set; } // 0x22
		public bool isAllLoaded { get {
			return isLoadedRunway && isLoadedEnviroment && isLoadedAnimator;
		} } //0xAEA888

		// // RVA: 0xAEA8B4 Offset: 0xAEA8B4 VA: 0xAEA8B4
		public void OnDestroy()
		{
			TodoLogger.Log(0, "MusicIntroResource OnDestroy");
		}

		// // RVA: 0xAEA8CC Offset: 0xAEA8CC VA: 0xAEA8CC
		public void LoadResources(int runwayId, int enviromentId, int valkyrieId)
		{
			isLoadedRunway = false;
			isLoadedEnviroment = false;
			StartCoroutine(Co_LoadResources(runwayId, enviromentId, valkyrieId));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7395B4 Offset: 0x7395B4 VA: 0x7395B4
		// // RVA: 0xAEA904 Offset: 0xAEA904 VA: 0xAEA904
		private IEnumerator Co_LoadResources(int runwayId, int enviromentId, int valkyrieId)
		{
			StringBuilder bundleName; // 0x20
			StringBuilder assetName; // 0x24
			AssetBundleLoadAllAssetOperationBase operation; // 0x28

			//0xAEAC44
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			bundleName.SetFormat("gm/it/{0:D4}.xab", runwayId);
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;

			assetName.SetFormat("game_it_{0:D4}_prefab", runwayId);
			runwayPrefab = operation.GetAsset<GameObject>(assetName.ToString());
			isLoadedRunway = true;
			isLoadedAnimator = true;
			assetName.SetFormat("game_it_{0:D4}_color", runwayId);
			paramColor = operation.GetAsset<ValkyrieColorParam>(assetName.ToString());
			assetName.SetFormat("game_it_{0:D4}_param", runwayId);
			paramIntro = operation.GetAsset<ValkyrieIntroParam>(assetName.ToString());
			assetName.SetFormat("it{0:D4}_vl{1:D4}_idle", runwayId, valkyrieId);
			m_override_anim.m_idle = operation.GetAsset<AnimationClip>(assetName.ToString());
			assetName.SetFormat("it{0:D4}_vl{1:D4}_takeoff", runwayId, valkyrieId);
			m_override_anim.m_takeoff = operation.GetAsset<AnimationClip>(assetName.ToString());

			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);

			bundleName.SetFormat("ev/it/{0:D4}.xab", enviromentId);
			assetName.SetFormat("env_it_{0:D4}_prefab", enviromentId);

			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;

			enviromentPrefab = operation.GetAsset<GameObject>(assetName.ToString());

			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);

			isLoadedEnviroment = true;
		}

		// // RVA: 0xAEA9FC Offset: 0xAEA9FC VA: 0xAEA9FC
		public void OverrideMusicStartTime(ref float a_sec)
		{
			if(paramIntro != null)
			{
				if (paramIntro.secMusicStart < 0)
					return;
				a_sec = paramIntro.secMusicStart;
			}
		}

		// // RVA: 0xAEAAD4 Offset: 0xAEAAD4 VA: 0xAEAAD4
		public void OverrideIntroEndTime(ref int a_msec)
		{
			if (paramIntro != null)
			{
				if (paramIntro.secIntroEnd < 0)
					return;
				a_msec = (int)(paramIntro.secIntroEnd * 1000.0f);
			}
		}
	}
}
