using System;
using UnityEngine;

namespace XeSys.Gfx
{
	[Serializable]
	public class ViewTransformData
	{
		[SerializeField]
		public ViewTransformDataStruct m = new ViewTransformDataStruct(); // 0x8

		// public Vector2 Pos { get; set; } 0x1EE5AE4 0x1EE5AF8
		// public Vector2 Move { get; set; } 0x1EEC79C 0x1EEC790
		public Vector2 Size { get { return m.Size; } set { m.Size = value; } } //0x1EE5B04 0x1EE5B18
		// public Vector2 Scale { get; set; } 0x1EE5B24 0x1EE5B38
		// public Vector2 Center { get; set; } 0x1EE5B74 0x1EE5B88
		// public float X { get; set; } 0x1EE6010 0x1EE6048
		// public float Y { get; set; } 0x1EE6074 0x1EE60AC
		// public float MoveX { get; set; } 0x1EE6228 0x1EE6260
		// public float MoveY { get; set; } 0x1EE628C 0x1EE62C4
		public float Width { get { return m.Size.x; } set { m.Size.x = value; } } //0x1EE62CC 0x1EE6304
		public float Height { get { return m.Size.y; } set { m.Size.y = value; } } //0x1EE6418 0x1EE6450
		// public float ScaleX { get; set; } 0x1EE647C 0x1EE64B4
		// public float ScaleY { get; set; } 0x1EE64E0 0x1EE6518
		// public float Rot { get; set; } 0x1EE5B44 0x1EE5B4C
		// public Color Col { get; set; } 0x1EE5B54 0x1EE5B64
		// public float CenterX { get; set; } 0x1EE6608 0x1EE6640
		// public float CenterY { get; set; } 0x1EE666C 0x1EE66A4
		// public float BaseX { get; set; } 0x1EE60D8 0x1EE6110
		// public float BaseY { get; set; } 0x1EE613C 0x1EE6174
		// public float Left { get; } 0x1EE61AC
		// public float Top { get; } 0x1EE61F0

		// RVA: 0x1EE5468 Offset: 0x1EE5468 VA: 0x1EE5468
		public void CopyTo(ViewTransformData data)
		{
			data.m = m;
		}
	}
}
