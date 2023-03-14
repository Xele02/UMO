using UnityEngine;
using UnityEngine.UI;

public class DebugCheatIntInputField : MonoBehaviour
{
	[SerializeField]
	private InputField m_input;
	private void Awake()
	{
		TodoLogger.Log(0, "Implement Monobehaviour");
	}
}
