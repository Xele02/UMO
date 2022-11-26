using UnityEngine;
using UnityEngine.UI;

public class DebugCheatIntInputField : MonoBehaviour
{
	[SerializeField]
	private InputField m_input;
	private void Awake()
	{
		UnityEngine.Debug.LogError("Implement Monobehaviour");
	}
}
