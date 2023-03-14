using UnityEngine;

namespace XeSys
{
	public class GUITextBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float fontSize;
		[SerializeField]
		private float fontImportSize;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
