using UnityEngine;
using XeApp.Game.Common;
using System;
using CriWare;
using System.Collections;

namespace XeApp.Core
{
	public class WarmupMovieTexture : MonoBehaviour
	{
		private const float s_movieWidth = 1280;
		private const float s_movieHeight = 720;
		private const float s_movieAspect = 1.777778f;
		[SerializeField] // RVA: 0x68F70C Offset: 0x68F70C VA: 0x68F70C
		private Renderer m_movieRenderer; // 0xC
		private Camera m_billboardCamera; // 0x10
		private float m_billboardDist = 100.0f; // 0x14
		private CameraStretchBillboard m_stretchBillboard; // 0x18
		private Action onFinish; // 0x1C
		private CriManaMovieController moviePlayer; // 0x20
		private bool isMoveMode; // 0x24

		// RVA: 0x1D783CC Offset: 0x1D783CC VA: 0x1D783CC
		public void InitializeMovie(CriManaMovieController movieController, Action onFinish)
		{
			moviePlayer = movieController;
			movieController.target = m_movieRenderer;
			moviePlayer.material.mainTextureScale = new Vector2(-1, -1);
			moviePlayer.material.mainTextureOffset = new Vector2(1, 1);
			m_billboardCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
			m_stretchBillboard = gameObject.AddComponent<CameraStretchBillboard>();
			m_stretchBillboard.Setup(m_billboardCamera, m_billboardDist, () => {
				//0x1D78810
				return 1.777778f;
			});
			this.onFinish = onFinish;
			this.StartCoroutineWatched(Co_PreRender());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x748820 Offset: 0x748820 VA: 0x748820
		// RVA: 0x1D786D4 Offset: 0x1D786D4 VA: 0x1D786D4
		private IEnumerator Co_PreRender()
		{
			//0x1D78820
			while(moviePlayer.player.status != CriWare.CriMana.Player.Status.Ready)
				yield return null;
			moviePlayer.player.Start();
			yield return new WaitForSeconds(0.5f);
			moviePlayer.player.Stop();
			while(moviePlayer.player.status != CriWare.CriMana.Player.Status.Stop)
				yield return null;
			moviePlayer.player.SetSeekPosition(0);
			moviePlayer.target = null;
			moviePlayer.player.Prepare();
			onFinish();
			Destroy(gameObject);
		}
	}
}
