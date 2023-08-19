using System;
using System.Collections;
using System.Text;
using CriWare;
using UnityEngine;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Common
{
	public class DivaModeResource : MonoBehaviour
	{
		private bool isLoadedMovie; // 0x10
		private bool isUnused = true; // 0x11
		public static bool prePlayMovie = true; // 0x0

		public CriManaMovieController moviePlayer { get; private set; } // 0xC 0x1BF162C 0x1BF1634
		public bool isAllLoaded { get {
			if(isUnused)
				return true;
			return isLoadedMovie;
		} } //0x1BF163C

		// // RVA: 0x1BF1660 Offset: 0x1BF1660 VA: 0x1BF1660
		public void OnDestroy()
		{
			moviePlayer = null;
		}

		// // RVA: 0x1BF166C Offset: 0x1BF166C VA: 0x1BF166C
		public void LoadResources(int musicId, int qualityId, Func<int> getSpecialMovieId)
		{
			isLoadedMovie = false;
			isUnused = false;
			this.StartCoroutineWatched(Co_LoadResources(musicId,qualityId,getSpecialMovieId));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x738198 Offset: 0x738198 VA: 0x738198
		// // RVA: 0x1BF16A4 Offset: 0x1BF16A4 VA: 0x1BF16A4
		private IEnumerator Co_LoadResources(int musicId, int qualityId, Func<int> getSpecialMovieId)
		{
			StringBuilder specialMovieExpansion; // 0x28
			StringBuilder assetName; // 0x2C
			string path; // 0x30

			//0x1BF18B0
			specialMovieExpansion = new StringBuilder();
			if(getSpecialMovieId != null)
			{
				yield return new WaitWhile(() => {
					//0x1BF181C
					return getSpecialMovieId() < 0;
				});
				int id = getSpecialMovieId();
				if(id > 0)
				{
					specialMovieExpansion.SetFormat("dr_{0:D3}_", id);
				}
			}
			assetName = new StringBuilder();
			assetName.SetFormat("mov/gm/dv/game_dv_{0:D4}_mv_{1}q{2:D1}.usm", musicId, specialMovieExpansion, qualityId);
			path = assetName.ToString();
			if(KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(path))
			{
				while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				{
					yield return null;
				}
			}
			assetName.Clear();
			assetName.Append(KEHOJEJMGLJ.CGAHFOBGHIM_PersistentPlatformDataPath);
			assetName.Append("/");
			assetName.Append(path);
			path = assetName.ToString();

			GameObject go = new GameObject("MoviePlayer");
			go.transform.SetParent(transform, false);

			MeshRenderer mr = go.AddComponent<MeshRenderer>();
			moviePlayer = go.AddComponent<CriManaMovieController>();

			moviePlayer.playOnStart = false;
			moviePlayer.target = mr;
			moviePlayer.moviePath = FileSystemProxy.ConvertPath(path);
			
			yield return null;

			moviePlayer.player.Prepare();
			//UMO, ensure video is ready
#if !UNITY_ANDROID
			while(moviePlayer.player.status != CriWare.CriMana.Player.Status.Ready)
			{
				yield return null;
			}
#endif
			if(prePlayMovie)
			{
				bool fin = false;
				WarmupTexturesGenerator.Instance.CreateMovie(moviePlayer, () => {
					//0x1BF18A0
					fin = true;
				});
				while(!fin)
					yield return null;
				prePlayMovie = false;
			}
			isLoadedMovie = true;
		}
	}
}
