using UnityEngine;
using XeApp.Game;

public class IntimacyTouchEffect : MonoBehaviour
{
		[SerializeField]
		private ParticleSystem m_effectBeggin; // 0xC
		[SerializeField]
		private ParticleSystem m_effectEnd; // 0x10
		[SerializeField]
		private Camera m_systemCanvasCamera; // 0x14

		// RVA: 0x1412BD4 Offset: 0x1412BD4 VA: 0x1412BD4
		private void Awake()
		{
			if(m_systemCanvasCamera != null)
				return;
			m_systemCanvasCamera = GameManager.Instance.GetSystemCanvasCamera();
		}

		// // RVA: 0x1412CC0 Offset: 0x1412CC0 VA: 0x1412CC0
		// public void TouchPlay(Vector2 position) { }

		// // RVA: 0x1412E1C Offset: 0x1412E1C VA: 0x1412E1C
		// public void TouchEnd() { }

		// // RVA: 0x1412F58 Offset: 0x1412F58 VA: 0x1412F58
		// public void TouchCancel() { }

		// // RVA: 0x1412FA8 Offset: 0x1412FA8 VA: 0x1412FA8
		// public void Drop(Vector2 position) { }

		// [IteratorStateMachineAttribute] // RVA: 0x68FDE4 Offset: 0x68FDE4 VA: 0x68FDE4
		// // RVA: 0x1412ECC Offset: 0x1412ECC VA: 0x1412ECC
		// private IEnumerator Co_WaitAnime(ParticleSystem particle) { }
}
