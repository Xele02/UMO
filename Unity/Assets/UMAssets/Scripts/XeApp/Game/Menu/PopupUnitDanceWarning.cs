using UnityEngine;

namespace XeApp.Game.Menu
{
	public class PopupUnitDanceWarning
	{
		private GameObject m_instance; // 0xC
		private const string AssetBundleName = "ly/126.xab";
		private const string PrefabName = "root_pop_unit_select_layout_root";

		public UnitDanceWarningWindow WarningWindow { get; private set; } // 0x8
		//public bool IsLoaded { get; } 0x1155E3C

		//[IteratorStateMachineAttribute] // RVA: 0x6F57E4 Offset: 0x6F57E4 VA: 0x6F57E4
		// RVA: 0x1155EC8 Offset: 0x1155EC8 VA: 0x1155EC8
		//public IEnumerator Co_Load(Transform parent) { }

		// RVA: 0x1155F90 Offset: 0x1155F90 VA: 0x1155F90
		public void Release()
		{
			Object.Destroy(m_instance);
			WarningWindow = null;
			m_instance = null;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x6F585C Offset: 0x6F585C VA: 0x6F585C
		// RVA: 0x115602C Offset: 0x115602C VA: 0x115602C
		//private void <Co_Load>b__9_0(GameObject instance) { }
	}
}
