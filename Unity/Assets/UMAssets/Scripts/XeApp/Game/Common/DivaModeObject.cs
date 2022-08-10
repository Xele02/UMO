using System;
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
		//public bool isPlayingMovie { get; } 0x1BF06C0

		// RVA: 0x1BF07A8 Offset: 0x1BF07A8 VA: 0x1BF07A8
		private void LateUpdate()
		{
			if (!isRunning)
				return;
			TodoLogger.Log(0, "DivaModeObject LateUpdate");
		}

		// RVA: 0x1BF0888 Offset: 0x1BF0888 VA: 0x1BF0888
		public void Initialize(CriManaMovieController movieController)
		{
			TodoLogger.Log(0, "DivaModeObject Initialize");
		}

		//// RVA: 0x1BF0CDC Offset: 0x1BF0CDC VA: 0x1BF0CDC
		//public void Prepare() { }

		//// RVA: 0x1BF0DF8 Offset: 0x1BF0DF8 VA: 0x1BF0DF8
		//public void Begin() { }

		//// RVA: 0x1BF1124 Offset: 0x1BF1124 VA: 0x1BF1124
		//public void End() { }

		//// RVA: 0x1BF1228 Offset: 0x1BF1228 VA: 0x1BF1228
		//public void Pause() { }

		//// RVA: 0x1BF1270 Offset: 0x1BF1270 VA: 0x1BF1270
		//public void Resume() { }

		//// RVA: 0x1BF12B8 Offset: 0x1BF12B8 VA: 0x1BF12B8
		//public void SetPreEndMovieCallback(Action method, float sec) { }

		//// RVA: 0x1BF0F38 Offset: 0x1BF0F38 VA: 0x1BF0F38
		//private void SetupMovieTimes() { }

		//[IteratorStateMachineAttribute] // RVA: 0x7380B0 Offset: 0x7380B0 VA: 0x7380B0
		//// RVA: 0x1BF1098 Offset: 0x1BF1098 VA: 0x1BF1098
		//private IEnumerator Co_WaitForMovieEnd() { }
	}
}
