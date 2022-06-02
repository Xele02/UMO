using UnityEngine.EventSystems;
using UnityEngine;

namespace TMPro
{
	public class TextContainer : UIBehaviour
	{
		[SerializeField]
		private Vector2 m_pivot;
		[SerializeField]
		private TextContainerAnchors m_anchorPosition;
		[SerializeField]
		private Rect m_rect;
		[SerializeField]
		private Vector4 m_margins;
	}
}
