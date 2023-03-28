using UnityEngine;

namespace XeApp.Game.Menu
{
	public class HomeDivaViewCamera : MonoBehaviour
	{
		private GameObject m_viewObj; // 0xC
		public ViewScreenCostume m_camera; // 0x10
		private bool m_isEntered; // 0x14

		public static HomeDivaViewCamera Instance { get; private set; } // 0x0

		// RVA: 0x9638A0 Offset: 0x9638A0 VA: 0x9638A0
		private void Start()
		{
			Instance = this;
		}

		// RVA: 0x963904 Offset: 0x963904 VA: 0x963904
		private void Update()
		{
			return;
		}

		//// RVA: 0x963908 Offset: 0x963908 VA: 0x963908
		//public void Create() { }

		//// RVA: 0x9639F8 Offset: 0x9639F8 VA: 0x9639F8
		//public void Enter() { }

		//// RVA: 0x963AEC Offset: 0x963AEC VA: 0x963AEC
		//public void Leave() { }

		//// RVA: 0x963BCC Offset: 0x963BCC VA: 0x963BCC
		//public void OnDeleteCache() { }

		//// RVA: 0x963CB8 Offset: 0x963CB8 VA: 0x963CB8
		//public void Reinstate() { }

		//// RVA: 0x963D18 Offset: 0x963D18 VA: 0x963D18
		//public void InputOn() { }

		//// RVA: 0x963D4C Offset: 0x963D4C VA: 0x963D4C
		//public void InputOff() { }

		//// RVA: 0x963CEC Offset: 0x963CEC VA: 0x963CEC
		//public void SetDivaTargetObject() { }

		//// RVA: 0x963D78 Offset: 0x963D78 VA: 0x963D78
		//public void InitChangeDiva() { }

		//// RVA: 0x963DA4 Offset: 0x963DA4 VA: 0x963DA4
		//public void InitCameraRot() { }

		//// RVA: 0x963DD0 Offset: 0x963DD0 VA: 0x963DD0
		//private void OnEntered() { }

		//// RVA: 0x963AE4 Offset: 0x963AE4 VA: 0x963AE4
		//public bool IsEntered() { }

		//// RVA: 0x963CA8 Offset: 0x963CA8 VA: 0x963CA8
		//private void OnFinished() { }

		//// RVA: 0x963DDC Offset: 0x963DDC VA: 0x963DDC
		//public bool IsFinished() { }

		//// RVA: 0x963E68 Offset: 0x963E68 VA: 0x963E68
		//public int GetState() { }
	}
}
