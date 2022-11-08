using UnityEngine.EventSystems;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class NotificationContent : UIBehaviour, IPopupContent
	{
		[SerializeField]
		private GameObject m_sourcePrefab;
		[SerializeField]
		private RectTransform m_listRoot;
		[SerializeField]
		private NotificationDetail m_detailRoot;

		public Transform Parent => throw new System.NotImplementedException();

		public void CallOpenEnd()
		{
			throw new System.NotImplementedException();
		}

		public void Hide()
		{
			throw new System.NotImplementedException();
		}

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			throw new System.NotImplementedException();
		}

		public bool IsReady()
		{
			throw new System.NotImplementedException();
		}

		public bool IsScrollable()
		{
			throw new System.NotImplementedException();
		}

		public void Show()
		{
			throw new System.NotImplementedException();
		}
	}
}
