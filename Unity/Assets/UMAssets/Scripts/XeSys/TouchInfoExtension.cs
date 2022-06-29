using UnityEngine;

namespace XeSys
{
	public static class TouchInfoExtension
	{
		// RVA: 0x2389B90 Offset: 0x2389B90 VA: 0x2389B90
		public static Vector2 GetSceneInnerPosition(this TouchInfo self)
		{
			return self.nativePosition;
		}
	}
}
