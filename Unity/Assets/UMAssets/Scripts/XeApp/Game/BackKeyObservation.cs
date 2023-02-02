using UnityEngine;

namespace XeApp.Game
{
	public class BackKeyObservation : MonoBehaviour
	{
		// RVA: 0xE5C9A0 Offset: 0xE5C9A0 VA: 0xE5C9A0
		private void Update()
		{
			if (!Input.GetKeyUp(KeyCode.Escape))
				return;
			GameManager.Instance.OnPushBackButton();
		}
	}
}
