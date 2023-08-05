using System.Collections;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class PopupUnitDanceWarning
	{
		private GameObject m_instance; // 0xC
		private const string AssetBundleName = "ly/126.xab";
		private const string PrefabName = "root_pop_unit_select_layout_root";

		public UnitDanceWarningWindow WarningWindow { get; private set; } // 0x8
		public bool IsLoaded { get { return m_instance != null; } } //0x1155E3C

		//[IteratorStateMachineAttribute] // RVA: 0x6F57E4 Offset: 0x6F57E4 VA: 0x6F57E4
		// RVA: 0x1155EC8 Offset: 0x1155EC8 VA: 0x1155EC8
		public IEnumerator Co_Load(Transform parent)
		{
			AssetBundleLoadLayoutOperationBase layOp;

			//0x11560B0
			if (m_instance != null)
				yield break;
			layOp = AssetBundleManager.LoadLayoutAsync("ly/126.xab", "root_pop_unit_select_layout_root");
			yield return layOp;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x115602C
				m_instance = instance;
				WarningWindow = instance.GetComponent<UnitDanceWarningWindow>();
			}));
			m_instance.transform.SetParent(parent, false);
		}

		// RVA: 0x1155F90 Offset: 0x1155F90 VA: 0x1155F90
		public void Release()
		{
			Object.Destroy(m_instance);
			WarningWindow = null;
			m_instance = null;
		}
	}
}
