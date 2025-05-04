using System;
using System.Collections;
using CriWare;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class MacrossCannonObject : MonoBehaviour
	{
		private class ReleaseData
		{
			public LayerMask cullingMask; // 0x8
			public CameraClearFlags clearFlags; // 0xC
		}

		private const float s_movieWidth = 1280;
		private const float s_movieHeight = 720;
		private const float s_movieAspect = 1.777778f;
		[SerializeField]
		private Renderer m_movieRenderer; // 0xC
		[SerializeField]
		private Camera m_billboardCamera; // 0x10
		[SerializeField]
		private float m_billboardDist = 100; // 0x14
		[SerializeField]
		private LayerMask m_overrideCullingMask; // 0x18
		[SerializeField]
		private CameraClearFlags m_overrideClearFlags; // 0x1C
		private CameraStretchBillboard m_stretchBillboard; // 0x20
		private ReleaseData m_releaseData; // 0x24
		private bool isInitialized; // 0x28
		private Coroutine m_coWaitForMovieEnd; // 0x30

		public bool IsInitialize { get { return isInitialized; } private set { isInitialized = value; } } //0x110D680 0x110D688
		private CriManaMovieController moviePlayer { get; set; } // 0x2C
		private long playedMicroSec { get; set; } // 0x38
		private long endMicroSec { get; set; } // 0x40
		private Action onPreEndMovieCallback { get; set; } // 0x48
		private long preEndCallbackMicroSec { get; set; } // 0x50
		public Action onEndMovieCallback { private get; set; } // 0x58
		public bool isRunning { get; private set; } // 0x5C
		public bool isPause { get; private set; } // 0x5D
		public bool isPlayingMovie { get { return moviePlayer != null && moviePlayer.player.status == CriWare.CriMana.Player.Status.Playing; } } //0x110D728

		// RVA: 0x110D810 Offset: 0x110D810 VA: 0x110D810
		private void LateUpdate()
		{
			if(!isRunning)
				return;
            CriWare.CriMana.FrameInfo info = moviePlayer.player.frameInfo;
			if(onPreEndMovieCallback != null)
			{
				if(playedMicroSec < preEndCallbackMicroSec && preEndCallbackMicroSec <= (long)info.time)
				{
					onPreEndMovieCallback();
				}
			}
			playedMicroSec = (long)info.time;
        }

		// // RVA: 0x110D8F0 Offset: 0x110D8F0 VA: 0x110D8F0
		public void Initialize(CriManaMovieController movieController)
		{
			m_billboardCamera = Camera.main;
			moviePlayer = movieController;
			movieController.target = m_movieRenderer;
			#if UNITY_EDITOR_LINUX || UNITY_EDITOR_OSX
			moviePlayer.material.mainTextureScale = new Vector2(1, -1);
			moviePlayer.material.mainTextureOffset = new Vector2(0, 1);
			#else
			moviePlayer.material.mainTextureScale = new Vector2(-1, -1);
			moviePlayer.material.mainTextureOffset = new Vector2(1, 1);
			#endif
			m_releaseData = new ReleaseData();
			m_releaseData.cullingMask = m_billboardCamera.cullingMask;
			m_releaseData.clearFlags = m_billboardCamera.clearFlags;
			m_stretchBillboard = gameObject.AddComponent<CameraStretchBillboard>();
			m_stretchBillboard.Setup(m_billboardCamera, m_billboardDist, () =>{
				//0x110E548
				return 1.777778f;
			});
			m_stretchBillboard.enabled = false;
			gameObject.SetActive(false);
			isInitialized = true;
		}

		// // RVA: 0x110DCA0 Offset: 0x110DCA0 VA: 0x110DCA0
		// public void Prepare() { }

		// // RVA: 0x110DDBC Offset: 0x110DDBC VA: 0x110DDBC
		public void Begin()
		{
			if(m_coWaitForMovieEnd != null)
				this.StopCoroutineWatched(m_coWaitForMovieEnd);
			gameObject.SetActive(true);
			moviePlayer.player.SetVolume(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.MIFIAMNHKOF());
			m_billboardCamera.cullingMask = m_overrideCullingMask;
			m_billboardCamera.clearFlags = m_overrideClearFlags;
			m_stretchBillboard.enabled = true;
			moviePlayer.Pause(isPause);
			moviePlayer.Play();
			isRunning = true;
			m_coWaitForMovieEnd = this.StartCoroutineWatched(Co_WaitForMovieEnd());
			isInitialized = true;
		}

		// // RVA: 0x110E0C4 Offset: 0x110E0C4 VA: 0x110E0C4
		public void End()
		{
			if(isInitialized)
			{
				m_stretchBillboard.enabled = false;
				m_billboardCamera.cullingMask = m_releaseData.cullingMask;
				m_billboardCamera.clearFlags = m_releaseData.clearFlags;
				moviePlayer.Stop();
				playedMicroSec = -1;
				isRunning = false;
			}
		}

		// // RVA: 0x110E1BC Offset: 0x110E1BC VA: 0x110E1BC
		public void Pause()
		{
			if(isInitialized)
			{
				moviePlayer.Pause(true);
				isPause = true;
			}
		}

		// // RVA: 0x110E204 Offset: 0x110E204 VA: 0x110E204
		public void Resume()
		{
			if(isInitialized)
			{
				moviePlayer.Pause(false);
				isPause = false;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73FE5C Offset: 0x73FE5C VA: 0x73FE5C
		// // RVA: 0x110E24C Offset: 0x110E24C VA: 0x110E24C
		public IEnumerator SetPreEndMovieCallback(Action method, float sec)
		{
			//0x110E738
			while(moviePlayer.player.status < CriWare.CriMana.Player.Status.WaitPrep)
				yield return null;
			SetupMovieTimes();
			preEndCallbackMicroSec = Mathf.FloorToInt((endMicroSec / 1000.0f - sec * 1000.0f) * 1000.0f);
			onPreEndMovieCallback = method;
		}

		// // RVA: 0x110E338 Offset: 0x110E338 VA: 0x110E338
		private void SetupMovieTimes()
		{
            CriWare.CriMana.MovieInfo info = moviePlayer.player.movieInfo;
			playedMicroSec = 0;
			endMicroSec = Mathf.FloorToInt((info.totalFrames * 1.0f / (info.framerateN * 1.0f / info.framerateD)) * 1000.0f * 1000.0f );
        }

		// [IteratorStateMachineAttribute] // RVA: 0x73FED4 Offset: 0x73FED4 VA: 0x73FED4
		// // RVA: 0x110E038 Offset: 0x110E038 VA: 0x110E038
		private IEnumerator Co_WaitForMovieEnd()
		{
			//0x110E558
			yield return new WaitForSeconds(1);
			while(isPlayingMovie)
				yield return null;
			End();
			yield return null;
			if(onEndMovieCallback != null)
				onEndMovieCallback();
		}
	}
}
