using UnityEngine;

namespace XeApp.Game.Menu
{
	public class ScrollContentControl : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_Content;
		[SerializeField]
		private GameObject m_ItemObject;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
