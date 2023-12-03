using System;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class UnlockValkyrieScene : TransitionRoot
	{
		[Serializable]
		public class CameraInfo
		{
			public Vector3 CameraPos = Vector3.zero; // 0x8
			public Vector3 TargetPos = Vector3.zero; // 0x14

			// RVA: 0x1653568 Offset: 0x1653568 VA: 0x1653568
			public CameraInfo()
			{
				return;
			}

			// RVA: 0x164E248 Offset: 0x164E248 VA: 0x164E248
			public CameraInfo(Vector3 position, Vector3 target)
			{
				CameraPos = position;
				TargetPos = target;
			}

			//// RVA: 0x1650CA4 Offset: 0x1650CA4 VA: 0x1650CA4
			public Vector3 GetTargetPos()
			{
				return new Vector3(TargetPos.x * Mathf.Clamp01((Screen.width * 1.0f / Screen.height) / 1.494949f), TargetPos.y, TargetPos.z);
			}
		}

		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
	}
}
