using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game
{
	public class DebugDecoItemDataRW : MonoBehaviour
	{
		[SerializeField]
		private Button button_data;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
