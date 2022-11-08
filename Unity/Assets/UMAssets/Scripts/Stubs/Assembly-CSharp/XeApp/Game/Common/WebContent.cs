using UnityEngine.EventSystems;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class WebContent : UIBehaviour
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private RectTransform m_webArea;
	}
}
