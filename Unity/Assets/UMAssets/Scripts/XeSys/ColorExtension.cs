using UnityEngine;

namespace XeSys
{
	public static class ColorExtension
	{
		public const float TranspEpsilon = 0.0009765625f;

		// RVA: 0x19315A0 Offset: 0x19315A0 VA: 0x19315A0
		public static string HexStringRGBA(this Color self)
		{
			return ((int)(self.r * 255)).ToString("X2") +
				((int)(self.g * 255)).ToString("X2") +
				((int)(self.b * 255)).ToString("X2") +
				((int)(self.a * 255)).ToString("X2");
		}

		// RVA: 0x19316BC Offset: 0x19316BC VA: 0x19316BC
		public static bool IsTransp(this Color self)
		{
			return self.a < TranspEpsilon;
		}
	}
}
