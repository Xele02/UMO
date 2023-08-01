using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class VirtualPad : MonoBehaviour
	{
		[SerializeField]
		private VirtualPadStick stick;
		[SerializeField]
		private VirtualPadButton[] buttons;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
