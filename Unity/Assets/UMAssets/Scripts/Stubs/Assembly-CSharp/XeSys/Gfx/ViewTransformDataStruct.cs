using System;
using UnityEngine;

namespace XeSys.Gfx
{
	[Serializable]
	public struct ViewTransformDataStruct
	{
		public ViewTransformDataStruct(float f) : this()
		{
		}

		public Vector2 Pos;
		public Vector2 Move;
		public Vector2 Size;
		public Vector2 Scale;
		public float Rot;
		public Color Color;
		public Vector2 Center;
		public Vector2 BasePos;
	}
}
