using XeSys.Gfx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp.Game.Menu
{
	public class RaidBossSelectReelScroller : LayoutLabelScriptBase, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private RectTransform m_hitRect;
		[SerializeField]
		private int m_scrollMaxFrame;
		[SerializeField]
		private float m_offsetLength;
		[SerializeField]
		private int m_selectionFlipFrame;
		[SerializeField]
		private float m_flickTime;
		[SerializeField]
		private float m_flickLength;

		public void OnBeginDrag(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

		public void OnDrag(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}
	}
}
