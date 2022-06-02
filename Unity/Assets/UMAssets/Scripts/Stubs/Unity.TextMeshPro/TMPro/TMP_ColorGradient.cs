using System;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	public class TMP_ColorGradient : ScriptableObject
	{
		public ColorMode colorMode;
		public Color topLeft;
		public Color topRight;
		public Color bottomLeft;
		public Color bottomRight;
	}
}
