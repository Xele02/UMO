
using System.Collections;
using UnityEngine;

namespace XeApp.Game.Common
{
	public abstract class PopupSettingUGUI : PopupSetting
	{

		//[IteratorStateMachineAttribute] // RVA: 0x73F23C Offset: 0x73F23C VA: 0x73F23C
		//								// RVA: 0x1BB295C Offset: 0x1BB295C VA: 0x1BB295C Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			TodoLogger.Log(0, "LoadAssetBundlePrefab");
			yield return null;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x73F2B4 Offset: 0x73F2B4 VA: 0x73F2B4
		//							 // RVA: 0x1BB2A28 Offset: 0x1BB2A28 VA: 0x1BB2A28
		//private void <LoadAssetBundlePrefab>b__0_0(GameObject instance) { }
	}
}
