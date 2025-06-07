using System.Collections;
using System.Text;
using CriWare;
using UnityEngine;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Common
{
	public class MacrossCannonResouce : MonoBehaviour
	{
		private bool isLoadedMovie; // 0x10
		private bool isUnused = true; // 0x11
		public static bool prePlayMovie = true; // 0x0

		public CriManaMovieController moviePlayer { get; private set; } // 0xC
		public bool IsLoadedMovie { get { return isLoadedMovie; } } //0x110E93C
		//public bool isAllLoaded { get; } 0x110E944

		// RVA: 0x110E968 Offset: 0x110E968 VA: 0x110E968
		public void OnDestroy()
		{
			moviePlayer = null;
		}

		// RVA: 0x110E974 Offset: 0x110E974 VA: 0x110E974
		public void LoadResources(SeriesAttr.Type series, int pattern, int qualityId)
		{
			isLoadedMovie = false;
			isUnused = false;
			this.StartCoroutineWatched(Co_LoadResources(series, pattern, qualityId));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x74000C Offset: 0x74000C VA: 0x74000C
		// // RVA: 0x110E9AC Offset: 0x110E9AC VA: 0x110E9AC
		private IEnumerator Co_LoadResources(SeriesAttr.Type series, int pattern, int qualityId)
		{
			StringBuilder assetName; // 0x24
			string path; // 0x28

			//0x110EB34
			assetName = new StringBuilder();
			string id = "d";
			if((int)series - 2 >= 0 && (int)series - 2 < 3)
				id = new string[3] { "f", "7", "1" }[(int)series - 2];
			assetName.SetFormat("mov/mc/mac_canon_" + id + "_{0:D3}_q{1:D1}.usm", pattern, qualityId);
			path = assetName.ToString();
			if(KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(path))
			{
				while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
					yield return null;
			}
			assetName.Clear();
			assetName.Append(KEHOJEJMGLJ.CGAHFOBGHIM_PersistentPlatformDataPath);
			assetName.Append("/");
			assetName.Append(path);
			path = assetName.ToString();
			GameObject g = new GameObject("MoviePlayer");
			g.transform.SetParent(transform, false);
			MeshRenderer r = g.AddComponent<MeshRenderer>();
			moviePlayer = g.AddComponent<CriManaMovieController>();
			moviePlayer.playOnStart = false;
			moviePlayer.target = r;
			moviePlayer.moviePath = path;
			yield return null;
			moviePlayer.player.Prepare();
			if(prePlayMovie)
			{
				moviePlayer.player.SetVolume(0);
				bool fin = false;
				WarmupTexturesGenerator.Instance.CreateMovie(moviePlayer, () =>
				{
					//0x110EB24
					fin = true;
				});
				while(!fin)
					yield return null;
				prePlayMovie = false;
				moviePlayer.player.SetVolume(1);
			}
			//LAB_0110ee7c
			isLoadedMovie = true;
		}
	}
}
