using System;
using System.Collections;
using CriWare;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class DivaModeObject : MonoBehaviour
	{
		private class ReleaseData
		{
			public LayerMask cullingMask; // 0x8
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
		private LayerMask m_overrideCullingMask1; // 0x18
		[SerializeField]
		private LayerMask m_overrideCullingMask2; // 0x1C
		private CameraStretchBillboard m_stretchBillboard; // 0x20
		private bool isInitialized; // 0x24
		private DivaModeObject.ReleaseData m_releaseData; // 0x28
		private Coroutine m_coWaitForMovieEnd; // 0x30

		public bool VisibleDiva { get; set; } // 0x25
		private CriManaMovieController moviePlayer { get; set; } // 0x2C
		private long playedMicroSec { get; set; } // 0x38
		private long endMicroSec { get; set; } // 0x40
		private Action onPreEndMovieCallback { get; set; } // 0x48
		private long preEndCallbackMicroSec { get; set; } // 0x50
		public Action onEndMovieCallback { private get; set; } // 0x58
		public bool isRunning { get; private set; } // 0x5C
		public bool isPause { get; private set; } // 0x5D
		public bool isPlayingMovie { get { return moviePlayer != null && moviePlayer.player.status == CriWare.CriMana.Player.Status.Playing; } } //0x1BF06C0

		// RVA: 0x1BF07A8 Offset: 0x1BF07A8 VA: 0x1BF07A8
		private void LateUpdate()
		{
			if (!isRunning)
				return;
			long time = 0;
			if(moviePlayer.player.frameInfo != null)
			{
				time = (long)((moviePlayer.player.frameInfo.time * 1000000) / moviePlayer.player.frameInfo.tunit);
			}
			if(onPreEndMovieCallback != null)
			{
				if(time >= preEndCallbackMicroSec && playedMicroSec < preEndCallbackMicroSec)
				{
					onPreEndMovieCallback();
				}
			}
			playedMicroSec = time;
		}

		// RVA: 0x1BF0888 Offset: 0x1BF0888 VA: 0x1BF0888
		public void Initialize(CriManaMovieController movieController)
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.OOCKIFIHJJN_Is2DMode)
			{
				gameObject.SetActive(false);
			}
			moviePlayer = movieController;
			movieController.target = m_movieRenderer;
			moviePlayer.material.mainTextureScale = new Vector2(-1, -1);
			moviePlayer.material.mainTextureOffset = new Vector2(1, 1);
			m_releaseData = new ReleaseData();
			m_releaseData.cullingMask = m_billboardCamera.cullingMask;
			m_stretchBillboard = gameObject.AddComponent<CameraStretchBillboard>();
			m_stretchBillboard.Setup(m_billboardCamera, m_billboardDist, () => {
				//0x1BF142C
				return 1.777778f;
			});
			m_stretchBillboard.enabled = false;
			gameObject.SetActive(false);
			isInitialized = true;
		}

		//// RVA: 0x1BF0CDC Offset: 0x1BF0CDC VA: 0x1BF0CDC
		//public void Prepare() { }

		//// RVA: 0x1BF0DF8 Offset: 0x1BF0DF8 VA: 0x1BF0DF8
		public void Begin()
		{
			if (m_coWaitForMovieEnd != null)
				StopCoroutine(m_coWaitForMovieEnd);
			gameObject.SetActive(true);
			m_billboardCamera.cullingMask = VisibleDiva ? m_overrideCullingMask1 : m_overrideCullingMask2;
			m_stretchBillboard.enabled = true;
			moviePlayer.Pause(isPause);
			moviePlayer.Play();
			SetupMovieTimes();
			isRunning = true;
			m_coWaitForMovieEnd = StartCoroutine(Co_WaitForMovieEnd());
			isInitialized = true;
		}

		//// RVA: 0x1BF1124 Offset: 0x1BF1124 VA: 0x1BF1124
		public void End()
		{
			if (!isInitialized)
				return;
			if (m_coWaitForMovieEnd != null)
				StopCoroutine(m_coWaitForMovieEnd);
			gameObject.SetActive(false);
			m_billboardCamera.cullingMask = m_releaseData.cullingMask;
			m_stretchBillboard.enabled = false;
			moviePlayer.Stop();
			playedMicroSec = -1;
			isRunning = false;
		}

		//// RVA: 0x1BF1228 Offset: 0x1BF1228 VA: 0x1BF1228
		public void Pause()
		{
			if(isInitialized)
			{
				moviePlayer.Pause(true);
				isPause = true;
			}
		}

		//// RVA: 0x1BF1270 Offset: 0x1BF1270 VA: 0x1BF1270
		public void Resume()
		{
			if(isInitialized)
			{
				moviePlayer.Pause(false);
				isPause = false;
			}
		}

		//// RVA: 0x1BF12B8 Offset: 0x1BF12B8 VA: 0x1BF12B8
		public void SetPreEndMovieCallback(Action method, float sec)
		{
			onPreEndMovieCallback = method;
			preEndCallbackMicroSec = Mathf.FloorToInt((endMicroSec / 1000.0f - sec * 1000.0f) * 1000.0f);
		}

		//// RVA: 0x1BF0F38 Offset: 0x1BF0F38 VA: 0x1BF0F38
		private void SetupMovieTimes()
		{
			playedMicroSec = 0;
			endMicroSec = Mathf.FloorToInt((moviePlayer.player.movieInfo.totalFrames * 1.0f / (moviePlayer.player.movieInfo.framerateN * 1.0f / moviePlayer.player.movieInfo.framerateD)) * 1000.0f * 1000.0f);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7380B0 Offset: 0x7380B0 VA: 0x7380B0
		//// RVA: 0x1BF1098 Offset: 0x1BF1098 VA: 0x1BF1098
		private IEnumerator Co_WaitForMovieEnd()
		{
			//0x1BF143C
			yield return new WaitForSeconds(0.5f);
			while (isPlayingMovie && playedMicroSec < endMicroSec)
				yield return null;
			if (onEndMovieCallback != null)
				onEndMovieCallback();
		}
	}
}
