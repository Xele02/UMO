using UnityEngine;

namespace XeApp.Game.Menu
{
	public class IntimacyController : MonoBehaviour
	{
		[SerializeField]
		private float m_SerifPlayTime;
		public bool IsPupUpWindow;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
