using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using XeSys.Gfx;
using UnityEngine.EventSystems;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSelectItemBase : SwapScrollListContent, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IDragHandler, IEndDragHandler
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Vector2 m_size;
		[SerializeField]
		private ActionButton m_detailButton;
		[SerializeField]
		private NumberBase m_haveNumLayout;
		[SerializeField]
		private NumberBase m_restNumLayout;
		[SerializeField]
		private string m_grayoutId;
		[SerializeField]
		private List<RawImageEx> m_itemImage;
		[SerializeField]
		private ButtonBase m_button;
		[SerializeField]
		private float m_selectLength;
		[SerializeField]
		private GameObject m_draggingObject;
		[SerializeField]
		private GameObject m_hitObject;

		public void OnDrag(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}
	}
}
