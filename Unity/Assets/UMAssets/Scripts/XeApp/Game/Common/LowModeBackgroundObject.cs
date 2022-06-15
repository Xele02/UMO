using UnityEngine;

namespace XeApp.Game.Common
{
	public class LowModeBackgroundObject : MonoBehaviour
	{
		// private LowModeBackgroundResource resource; // 0xC
		[HideInInspector] // RVA: 0x68C12C Offset: 0x68C12C VA: 0x68C12C
		public GameObject intro; // 0x10
		[HideInInspector] // RVA: 0x68C13C Offset: 0x68C13C VA: 0x68C13C
		public GameObject card; // 0x14
		[HideInInspector] // RVA: 0x68C14C Offset: 0x68C14C VA: 0x68C14C
		public GameObject battle; // 0x18
		private bool isInitialized; // 0x1C
		private Material mipmapBiasMaterialInstance; // 0x20
		private readonly byte[,] DimmerTbl = new byte[2, 11] { { 0x6e, 0x78, 0x82, 0x8c, 0x99, 0xaa, 0xb4, 0xbe, 0xc8, 0xd2, 0xdc}, 
			{0x28, 0x32, 0x3c, 0x46, 0x50, 0x64, 0x6e, 0x78, 0x82, 0x8c, 0x96 } }; // 0x24

		// // RVA: 0x1109E08 Offset: 0x1109E08 VA: 0x1109E08
		// public void Initialize(LowModeBackgroundResource resource) { }

		// // RVA: 0x110A574 Offset: 0x110A574 VA: 0x110A574
		// private void ApplyDimmer() { }

		// // RVA: 0x110A728 Offset: 0x110A728 VA: 0x110A728
		// private void ApplyDimmer(RawImage image, int value, LowModeBackgroundObject.DimmerTblIndex index) { }

		// // RVA: 0x110A27C Offset: 0x110A27C VA: 0x110A27C
		// private void ApplyBackGroundPanelSize(RawImage target, Canvas canvas, int baseRare) { }

		// // RVA: 0x110A814 Offset: 0x110A814 VA: 0x110A814
		public void ChangeIntroBg()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x110A89C Offset: 0x110A89C VA: 0x110A89C
		// public void ChangeCardBg() { }

		// // RVA: 0x110A924 Offset: 0x110A924 VA: 0x110A924
		// public void ChangeBattleBg() { }
	}
}
