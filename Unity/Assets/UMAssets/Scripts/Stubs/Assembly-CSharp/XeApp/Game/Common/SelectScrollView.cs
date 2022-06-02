using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class SelectScrollView : ScrollRect
	{
		public bool isSingleTouch;
		public AnimationCurve curve;
		public int m_itemCount;
		public float selectVelocity;
		public Vector2 itemSize;
		public Vector2 spacing;
	}
}
