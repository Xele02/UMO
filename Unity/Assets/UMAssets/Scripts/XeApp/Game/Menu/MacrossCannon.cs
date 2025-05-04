using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class MacrossCannon : MonoBehaviour
	{
		[SerializeField]
		private MacrossCannonObject mcrsCannonObject; // 0xC
		private MacrossCannonResouce mcCannonResouce; // 0x10
		private Action OnPreEndMovieCallback; // 0x14
		private float PreEndMovieSec; // 0x18

		// RVA: 0xEBA72C Offset: 0xEBA72C VA: 0xEBA72C
		private void Awake()
		{
			mcCannonResouce = gameObject.AddComponent<MacrossCannonResouce>();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7136E4 Offset: 0x7136E4 VA: 0x7136E4
		// // RVA: 0xEBA7B4 Offset: 0xEBA7B4 VA: 0xEBA7B4
		public IEnumerator Initialize(SeriesAttr.Type series, int pattern, int qualityId, Action onMoviePreEndCallBack, float preEndMovieSec = 0.1f)
		{
			//0xEBAD0C
			if(onMoviePreEndCallBack != null)
			{
				OnPreEndMovieCallback = onMoviePreEndCallBack;
				PreEndMovieSec = preEndMovieSec;
			}
			yield return Co.R(Co_LoadMovie(series, pattern, qualityId));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71375C Offset: 0x71375C VA: 0x71375C
		// // RVA: 0xEBA8EC Offset: 0xEBA8EC VA: 0xEBA8EC
		private IEnumerator Co_LoadMovie(SeriesAttr.Type series, int pattern, int qualityId)
		{
			//0xEBAAA0
			mcCannonResouce.LoadResources(series, pattern, qualityId);
			while(!mcCannonResouce.IsLoadedMovie)
				yield return null;
			mcrsCannonObject.Initialize(mcCannonResouce.moviePlayer);
			while(!mcrsCannonObject.IsInitialize)
				yield return null;
			yield return Co.R(mcrsCannonObject.SetPreEndMovieCallback(OnPreEndMovieCallback, PreEndMovieSec));
		}

		// // RVA: 0xEBA9E4 Offset: 0xEBA9E4 VA: 0xEBA9E4
		public void Play()
		{
			mcrsCannonObject.Begin();
		}

		// // RVA: 0xEBAA10 Offset: 0xEBAA10 VA: 0xEBAA10
		public void End()
		{
			mcrsCannonObject.End();
		}

		// RVA: 0xEBAA3C Offset: 0xEBAA3C VA: 0xEBAA3C
		public void Pause()
		{
			mcrsCannonObject.Pause();
		}

		// RVA: 0xEBAA68 Offset: 0xEBAA68 VA: 0xEBAA68
		public void Resume()
		{
			mcrsCannonObject.Resume();
		}
	}
}
