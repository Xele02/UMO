using UnityEngine;

namespace XeApp.Game
{
	public class AnchorPositionTween : TweenBase
	{
		[SerializeField]
		private Vector2 m_from;
		[SerializeField]
		private Vector2 m_to;
		[SerializeField]
		private RectTransform m_rectTransform;
	}
}
