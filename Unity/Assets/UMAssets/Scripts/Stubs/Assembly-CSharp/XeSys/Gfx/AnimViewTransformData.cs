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
			public Vector2 MoveBezierNext;
			public Vector2 MoveBezierPrev;
		}

		[SerializeField]
		public ViewTransformDataStruct m;
		[SerializeField]
		private AnimViewTransformDataStruct s;
	}
}
