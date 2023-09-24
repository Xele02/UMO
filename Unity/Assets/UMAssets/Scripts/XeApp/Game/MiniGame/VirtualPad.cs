using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class VirtualPad : MonoBehaviour
	{
		[SerializeField]
		private VirtualPadStick stick; // 0xC
		[SerializeField]
		private VirtualPadButton[] buttons; // 0x10

		public VirtualPadStick Stick { get { return stick; } } //0xC8E6B4
		public VirtualPadButton[] Buttons { get { return buttons; } } //0xC8E6D0

		// RVA: 0xC92CEC Offset: 0xC92CEC VA: 0xC92CEC
		private void Awake()
		{
			return;
		}

		//// RVA: 0xC92CF0 Offset: 0xC92CF0 VA: 0xC92CF0
		//public void OnUpdate() { }

		// RVA: 0xC92D04 Offset: 0xC92D04 VA: 0xC92D04
		private void OnApplicationPause(bool pause)
		{
			if(pause)
			{
				stick.ResetAxis();
				for(int i = 0; i < buttons.Length; i++)
				{
					buttons[i].IsPress = false;
				}
			}
		}
	}
}
