using UnityEngine;

namespace XeApp.Game.Common
{
	public class DPIConvert : MonoBehaviour
	{
		[SerializeField]
		public RectTransform m_root;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
