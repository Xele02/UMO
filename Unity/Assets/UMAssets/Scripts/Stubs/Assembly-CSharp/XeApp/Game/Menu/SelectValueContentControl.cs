using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SelectValueContentControl : MonoBehaviour
	{
		[SerializeField]
		private ScrollContentControl m_ScrollContentControl;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
