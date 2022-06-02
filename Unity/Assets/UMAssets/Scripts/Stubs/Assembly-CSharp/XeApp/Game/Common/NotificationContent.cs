using UnityEngine.EventSystems;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class NotificationContent : UIBehaviour
	{
		[SerializeField]
		private GameObject m_sourcePrefab;
		[SerializeField]
		private RectTransform m_listRoot;
		[SerializeField]
		private NotificationDetail m_detailRoot;
	}
}
