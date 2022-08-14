using UnityEngine;

namespace XeApp.Core
{
	public class MayaCameraConverter : MonoBehaviour
	{
		private new Camera camera; // 0xC

		// RVA: 0x1D7410C Offset: 0x1D7410C VA: 0x1D7410C
		private void Awake()
		{
			camera = GetComponentInChildren<Camera>(true);
		}

		// RVA: 0x1D74178 Offset: 0x1D74178 VA: 0x1D74178
		private void LateUpdate()
		{
			if(camera != null)
			{
				camera.fieldOfView = transform.localScale.z;
			}
		}
	}
}
