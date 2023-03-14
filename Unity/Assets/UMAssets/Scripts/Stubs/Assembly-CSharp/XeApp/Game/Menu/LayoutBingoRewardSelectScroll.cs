using XeSys.Gfx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp.Game.Menu
{
	public class LayoutBingoRewardSelectScroll : LayoutUGUIScriptBase, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }

		public void OnBeginDrag(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

		public void OnDrag(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

		[SerializeField]
		private float m_offsetLength;
		[SerializeField]
		private int m_selectionFlipFrame;
		[SerializeField]
		private float m_flickTime;
		[SerializeField]
		private float m_flickLength;
		[SerializeField]
		private RectTransform m_hitRect;
	}
}
