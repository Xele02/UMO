using System;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	public struct VertexGradient
	{
		public VertexGradient(Color color) : this()
		{
		}

		public Color topLeft;
		public Color topRight;
		public Color bottomLeft;
		public Color bottomRight;
	}
}
