using UnityEngine;

namespace XeApp.Game.Menu
{
	public class UnlockValkyrieManager : MonoBehaviour
	{
		[SerializeField]
		private ScriptableObject m_CameraParam;
		public bool IsAnimEnd;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
