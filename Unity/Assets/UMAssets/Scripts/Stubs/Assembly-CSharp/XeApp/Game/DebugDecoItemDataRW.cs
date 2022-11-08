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
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
