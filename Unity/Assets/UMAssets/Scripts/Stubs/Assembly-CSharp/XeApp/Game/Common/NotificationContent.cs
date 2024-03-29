using UnityEngine.EventSystems;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class NotificationContent : UIBehaviour, IPopupContent
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private GameObject m_sourcePrefab;
		[SerializeField]
		private RectTransform m_listRoot;
		[SerializeField]
		private NotificationDetail m_detailRoot;

		public Transform Parent => null; //throw new System.NotImplementedException();

		public void CallOpenEnd()
		{
			//throw new System.NotImplementedException();
		}

		public void Hide()
		{
			//throw new System.NotImplementedException();
		}

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			//throw new System.NotImplementedException();
		}

		public bool IsReady()
		{
			//throw new System.NotImplementedException();
			return true;
		}

		public bool IsScrollable()
		{
			//throw new System.NotImplementedException();
			return true;
		}

		public void Show()
		{
			//throw new System.NotImplementedException();
		}
	}
}
