using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class UGUILoopSelectScroll : MonoBehaviour, IEndDragHandler, IEventSystemHandler
	{
		[SerializeField]
		private ScrollRect m_scrollRect;
		[SerializeField]
		private UGUILoopSelectScrollContent m_itemObj;
		[SerializeField]
		private Vector2 m_leftTopPosition;
		[SerializeField]
		private Vector2 m_spacing;
		[SerializeField]
		private int m_startIndex;
		[SerializeField]
		private int m_rowCount;
		[SerializeField]
		private int m_columnCount;
		[SerializeField]
		private bool m_isVertical;

		public void OnEndDrag(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
