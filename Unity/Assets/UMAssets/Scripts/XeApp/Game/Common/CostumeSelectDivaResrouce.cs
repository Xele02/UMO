
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class CostumeSelectDivaResrouce : DivaResource
	{
		private StringBuilder bundleName = new StringBuilder(64); // 0x15C
		private StringBuilder assetName = new StringBuilder(64); // 0x160
		private StringBuilder strBuilder = new StringBuilder(64); // 0x164
		public List<List<Material>> materialList = new List<List<Material>>(); // 0x168
		public List<MotionOverrideSingleResource> overrideClipList = new List<MotionOverrideSingleResource>(); // 0x16C

		//// RVA: 0xE6898C Offset: 0xE6898C VA: 0xE6898C
		//public void Initialize(int divaId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x73617C Offset: 0x73617C VA: 0x73617C
		//								// RVA: 0xE68994 Offset: 0xE68994 VA: 0xE68994
		//public IEnumerator Co_LoadBasicResource() { }

		//// RVA: 0xE68A40 Offset: 0xE68A40 VA: 0xE68A40
		//private void ReleaseBasic() { }

		//[IteratorStateMachineAttribute] // RVA: 0x7361F4 Offset: 0x7361F4 VA: 0x7361F4
		//								// RVA: 0xE68ACC Offset: 0xE68ACC VA: 0xE68ACC
		//public IEnumerator Co_LoadFacialClip(DivaResource.MenuFacialType type) { }

		//// RVA: 0xE68B94 Offset: 0xE68B94 VA: 0xE68B94
		//private void ReleaseFacial() { }

		//[IteratorStateMachineAttribute] // RVA: 0x73626C Offset: 0x73626C VA: 0x73626C
		//								// RVA: 0xE68D60 Offset: 0xE68D60 VA: 0xE68D60
		//public IEnumerator Co_LoadMotion() { }

		//[IteratorStateMachineAttribute] // RVA: 0x7362E4 Offset: 0x7362E4 VA: 0x7362E4
		//								// RVA: 0xE68E0C Offset: 0xE68E0C VA: 0xE68E0C
		//public IEnumerator Co_LoadCostume(int modelId, UnityAction coroutineEnd) { }

		//// RVA: 0xE68EEC Offset: 0xE68EEC VA: 0xE68EEC
		//public void ReleaseCostume() { }

		//// RVA: 0xE690CC Offset: 0xE690CC VA: 0xE690CC
		//public void Release() { }
	}
}
