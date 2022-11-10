using System;
using UnityEngine;

namespace XeSys.Gfx
{
	[Serializable]
	public struct ViewTransformDataStruct
	{
		public Vector2 Pos; // 0x0
		public Vector2 Move; // 0x8
		public Vector2 Size; // 0x10
		public Vector2 Scale; // 0x18
		public float Rot; // 0x20
		public Color Color; // 0x24
		public Vector2 Center; // 0x34
		public Vector2 BasePos; // 0x3C

		// RVA: 0x8025E8 Offset: 0x8025E8 VA: 0x8025E8
		public ViewTransformDataStruct(float f)
		{
			Pos = new Vector2(0, 0);
			Move = new Vector2(0, 0);
			Scale = new Vector2(1, 1);
			Color = new Color(1, 1, 1, 1);
			Size = new Vector2(0, 0);
			Rot = 0;
			Center = new Vector2(0, 0);
			BasePos = new Vector2(0, 0);
		}
	}
}
