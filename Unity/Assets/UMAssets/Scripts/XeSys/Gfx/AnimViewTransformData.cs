using System;
using UnityEngine;

namespace XeSys.Gfx
{
	[Serializable]
	public struct AnimViewTransformData
	{
		[Serializable]
		private struct AnimViewTransformDataStruct
		{
			public Vector2 MoveBezierNext; // 0x0
			public Vector2 MoveBezierPrev; // 0x8
		}

		[SerializeField]
		public ViewTransformDataStruct m; // 0x0
		[SerializeField]
		private AnimViewTransformDataStruct s; // 0x44

		//public Vector2 Pos { get; set; } 0x806070 0x806084
		//public Vector2 Move { get; set; } 0x806090 0x8060A4
		//public Vector2 Size { get; set; } 0x8060B0 0x8060C4
		//public Vector2 Scale { get; set; } 0x8060D0 0x8060E4
		//public Vector2 Center { get; set; } 0x8060F0 0x806104
		//public float X { get; set; } 0x806110 0x806118
		//public float Y { get; set; } 0x806120 0x806128
		//public float MoveX { get; set; } 0x806130 0x806138
		//public float MoveY { get; set; } 0x806140 0x806148
		//public float Width { get; set; } 0x806150 0x806158
		//public float Height { get; set; } 0x806160 0x806168
		//public float ScaleX { get; set; } 0x806170 0x806178
		//public float ScaleY { get; set; } 0x806180 0x806188
		//public float Rot { get; set; } 0x806190 0x806198
		//public Color Col { get; set; } 0x8061A0 0x8061B0
		//public float ColR { get; set; } 0x8061C0 0x8061C8
		//public float ColG { get; set; } 0x8061D0 0x8061D8
		//public float ColB { get; set; } 0x8061E0 0x8061E8
		//public float Alpha { get; set; } 0x8061F0 0x8061F8
		//public float CenterX { get; set; } 0x806200 0x806208
		//public float CenterY { get; set; } 0x806210 0x806218
		//public float BaseX { get; set; } 0x806220 0x806228
		//public float BaseY { get; set; } 0x806230 0x806238
		//public float Left { get; } 0x806240 
		//public float Top { get; } 0x806254
		public Vector2 MoveBezierNext { get { return s.MoveBezierNext; } set { s.MoveBezierNext = value; } } //0x806268 0x80627C
		public Vector2 MoveBezierPrev { get { return s.MoveBezierPrev; } set { s.MoveBezierPrev = value; } } //0x806288 0x80629C
		public float MoveBezierNextX { get { return s.MoveBezierNext.x; } set { s.MoveBezierNext.x = value; } } //0x8062A8 0x8062B0
		public float MoveBezierPrevX { get { return s.MoveBezierPrev.x; } set { s.MoveBezierPrev.x = value; } } //0x8062B8 0x8062C0
		public float MoveBezierNextY { get { return s.MoveBezierNext.y; } set { s.MoveBezierNext.y = value; } } //0x8062C8 0x8062D0
		public float MoveBezierPrevY { get { return s.MoveBezierPrev.y; } set { s.MoveBezierPrev.y = value; } } //0x8062D8 0x8062E0
	}
}
