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
	public class StageExtensionResource : MonoBehaviour
	{
		public bool isUnused = true; // 0xC
		public MusicExtensionPrefabParam param; // 0x10
		public MusicExtensionPrefabMovieParam paramMovie; // 0x14
		public List<GameObject> prefabList; // 0x18
		public AnimationClip clip; // 0x1C
		public RuntimeAnimatorController animatorController; // 0x20
		public CriManaMovieController moviePlayer; // 0x24
		public Material movieMaterial; // 0x28
		private bool isMovieMaterialAdd; // 0x2C

		public bool isLoaded { get; private set; } // 0x2D
		public bool isAllLoaded { get { return isUnused || isLoaded; } private set {} } //0x13A3864 0x13A3888

		// // RVA: 0x13A3454 Offset: 0x13A3454 VA: 0x13A3454
		// public void OnDestroy() { }

		// // RVA: 0x13A3474 Offset: 0x13A3474 VA: 0x13A3474
		public void LoadResouces(int wavId, int divaId, int assetId, int stageDivaNum)
		{
			StartCoroutine(Co_LoadAllResouces(wavId, divaId, assetId, stageDivaNum));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73B7B0 Offset: 0x73B7B0 VA: 0x73B7B0
		// // RVA: 0x13A34AC Offset: 0x13A34AC VA: 0x13A34AC
		private IEnumerator Co_LoadAllResouces(int wavId, int divaId, int assetId, int stageDivaNum)
		{
			//0x13A38A0
			isLoaded = false;
			isUnused = false;
			yield return StartCoroutine(Co_LoadBasicResouces());
			yield return StartCoroutine(Co_LoadMusicResouces(wavId, divaId, assetId, stageDivaNum));
			isLoaded = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73B828 Offset: 0x73B828 VA: 0x73B828
		// // RVA: 0x13A35C0 Offset: 0x13A35C0 VA: 0x13A35C0
		private IEnumerator Co_LoadBasicResouces()
		{
			StringBuilder bundleName; // 0x14
			StringBuilder assetName; // 0x18
			AssetBundleLoadAllAssetOperationBase operation; // 0x1C

			//0x13A3AB4
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			bundleName.SetFormat("mc/cmn/dr/st.xab", Array.Empty<object>());
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			assetName.SetFormat("dr_st_cmn_animator", Array.Empty<object>());
			animatorController = operation.GetAsset<RuntimeAnimatorController>(assetName.ToString());
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73B8A0 Offset: 0x73B8A0 VA: 0x73B8A0
		// // RVA: 0x13A366C Offset: 0x13A366C VA: 0x13A366C
		private IEnumerator Co_LoadMusicResouces(int wavId, int divaId, int assetId, int stageDivaNum)
		{
			StringBuilder bundleName; // 0x24
			StringBuilder assetName; // 0x28
			AssetBundleLoadAllAssetOperationBase operation; // 0x2C

			//0x13A44F8
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			string wavName = GameManager.Instance.GetWavDirectoryName(wavId, "mc/{0}/dr/st/{1:D3}.xab", stageDivaNum, 1, assetId, false);
			bundleName.SetFormat("mc/{0}/dr/st/{1:D3}.xab", wavName, assetId);
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			assetName.SetFormat("dr_st_{0:D3}_param", assetId);
			param = operation.GetAsset<MusicExtensionPrefabParam>(assetName.ToString());
			assetName.SetFormat("dr_st_{0:D3}_movie_param", assetId);
			paramMovie = operation.GetAsset<MusicExtensionPrefabMovieParam>(assetName.ToString());
			assetName.SetFormat("dr_st_{0:D3}_anim", assetId);
			clip = operation.GetAsset<AnimationClip>(assetName.ToString());
			prefabList = new List<GameObject>(param.attachDataList.Count);
			for(int i = 0; i < param.attachDataList.Count; i++)
			{
				assetName.SetFormat("dr_st_{0:D3}_prefab_{1:D2}", assetId, i+1);
				prefabList.Add(operation.GetAsset<GameObject>(assetName.ToString()));
			}
			assetName.SetFormat("cri_movie", Array.Empty<object>());
			isMovieMaterialAdd = false;
			Material mat = operation.GetAsset<Material>(assetName.ToString());
			if(mat == null)
			{
				assetName.SetFormat("cri_movie_add", Array.Empty<object>());
				mat = operation.GetAsset<Material>(assetName.ToString());
				isMovieMaterialAdd = true;
			}
			if(mat != null)
			{
				movieMaterial = new Material(mat);
			}
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
			if(mat != null)
			{
				yield return StartCoroutine(Co_LoadMovieResource(wavId, divaId));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73B918 Offset: 0x73B918 VA: 0x73B918
		// // RVA: 0x13A3784 Offset: 0x13A3784 VA: 0x13A3784
		private IEnumerator Co_LoadMovieResource(int wavId, int divaId)
		{
			StringBuilder assetName; // 0x1C
			string t_path; // 0x20

			//0x13A3DEC
			assetName = new StringBuilder();
			if(paramMovie != null && !string.IsNullOrEmpty(paramMovie.pathMovie))
			{
				assetName.SetFormat("mov/gm/st/{0}", paramMovie.pathMovie);
			}
			else
			{
				assetName.SetFormat("mov/gm/st/game_st_{0:D4}_{1:D3}.usm", wavId, divaId);
			}
			t_path = assetName.ToString();
			if(KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC(t_path))
			{
				while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB)
					yield return null;
			}
			assetName.Clear();
			assetName.Append(KEHOJEJMGLJ.CGAHFOBGHIM);
			assetName.Append("/");
			assetName.Append(t_path);
			t_path = assetName.ToString();
			GameObject go = new GameObject("StageMoviePlayer");
			go.transform.SetParent(transform, false);
			MeshRenderer renderer = go.AddComponent<MeshRenderer>();
			moviePlayer = go.AddComponent<CriManaMovieController>();
			moviePlayer.playOnStart = false;
			moviePlayer.additiveMode = isMovieMaterialAdd;
			moviePlayer.moviePath = t_path;
			moviePlayer.loop = true;
			moviePlayer.material = movieMaterial;
			yield return null;
			moviePlayer.player.Prepare();
		}
	}
}
