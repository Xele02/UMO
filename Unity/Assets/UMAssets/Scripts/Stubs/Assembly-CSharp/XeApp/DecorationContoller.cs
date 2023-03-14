using UnityEngine;

namespace XeApp
{
	public class DecorationContoller : MonoBehaviour
	{
		[SerializeField]
		public float m_zoomMax;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
