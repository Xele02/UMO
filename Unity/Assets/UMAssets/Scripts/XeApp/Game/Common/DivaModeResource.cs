using System;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class DivaModeResource : MonoBehaviour
	{
		private bool isLoadedMovie; // 0x10
		private bool isUnused = true; // 0x11
		public static bool prePlayMovie = true; // 0x0

		public CriManaMovieController moviePlayer { get; set; } // 0xC
		public bool isAllLoaded { get {
			if(isUnused)
				return true;
			return isLoadedMovie;
		} } //0x1BF163C


		// [CompilerGeneratedAttribute] // RVA: 0x738178 Offset: 0x738178 VA: 0x738178
		// // RVA: 0x1BF162C Offset: 0x1BF162C VA: 0x1BF162C
		// public CriManaMovieController get_moviePlayer() { }

		// [CompilerGeneratedAttribute] // RVA: 0x738188 Offset: 0x738188 VA: 0x738188
		// // RVA: 0x1BF1634 Offset: 0x1BF1634 VA: 0x1BF1634
		// private void set_moviePlayer(CriManaMovieController value) { }

		// // RVA: 0x1BF1660 Offset: 0x1BF1660 VA: 0x1BF1660
		// public void OnDestroy() { }

		// // RVA: 0x1BF166C Offset: 0x1BF166C VA: 0x1BF166C
		public void LoadResources(int musicId, int qualityId, Func<int> getSpecialMovieId)
		{
			UnityEngine.Debug.LogError("TodO LoadResources");
			isLoadedMovie = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x738198 Offset: 0x738198 VA: 0x738198
		// // RVA: 0x1BF16A4 Offset: 0x1BF16A4 VA: 0x1BF16A4
		// private IEnumerator Co_LoadResources(int musicId, int qualityId, Func<int> getSpecialMovieId) { }
	}
}
