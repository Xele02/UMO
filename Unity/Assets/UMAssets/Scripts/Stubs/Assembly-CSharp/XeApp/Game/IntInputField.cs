using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game
{
	public class IntInputField : MonoBehaviour
	{
		[SerializeField]
		private InputField m_input;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
