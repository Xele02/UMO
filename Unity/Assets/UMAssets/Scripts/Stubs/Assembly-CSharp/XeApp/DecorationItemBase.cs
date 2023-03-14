using UnityEngine;

namespace XeApp
{
	public class DecorationItemBase : MonoBehaviour
	{
		public int m_statusFlag;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
