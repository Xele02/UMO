using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class MusicCameraCutinObject : MonoBehaviour
	{
		private Animator animator; // 0xC
		private AnimatorOverrideController overrideController; // 0x10
		private MusicCameraCutinResource resource; // 0x14
		private MusicCameraObject cameraObject; // 0x18
		private Dictionary<int, float> changeCutinFireTimes = new Dictionary<int, float>(4); // 0x1C
		private int resourceId; // 0x20

		// RVA: 0x1119694 Offset: 0x1119694 VA: 0x1119694
		//public void ResetAnimationPreview() { }

		// RVA: 0x1119698 Offset: 0x1119698 VA: 0x1119698
		public void Initialize(MusicCameraCutinResource resource, MusicCameraObject cameraObject, int resourceId = 0)
		{
			UnityEngine.Debug.LogError("TODO MusicCameraCutinObject Initialize");
		}

		// RVA: 0x11199A4 Offset: 0x11199A4 VA: 0x11199A4
		//private void SetupEventFireTime(AnimationEvent[] events) { }

		//// RVA: 0x1119B60 Offset: 0x1119B60 VA: 0x1119B60
		//public void ChangeCutin(int id) { }

		//// RVA: 0x1119D80 Offset: 0x1119D80 VA: 0x1119D80
		//public void PlayMusicAnimation() { }

		//// RVA: 0x111A014 Offset: 0x111A014 VA: 0x111A014
		//public void Stop() { }

		//// RVA: 0x111A0C0 Offset: 0x111A0C0 VA: 0x111A0C0
		//public void Pause() { }

		//// RVA: 0x111A178 Offset: 0x111A178 VA: 0x111A178
		//public void Resume() { }

		//// RVA: 0x1119E64 Offset: 0x1119E64 VA: 0x1119E64
		//public void ChangeAnimationTime(double time) { }
	}
}
