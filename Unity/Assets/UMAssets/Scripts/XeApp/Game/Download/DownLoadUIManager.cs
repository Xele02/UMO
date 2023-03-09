using UnityEngine;
using XeApp.Game.Menu;

namespace XeApp.Game.DownLoad
{
	public class DownLoadUIManager : MonoBehaviour
	{
		private static DownLoadUIManager sm_Instance; // 0x0
		[SerializeField]
		private GameObject m_BgRoot; // 0xC
		[SerializeField]
		private GameObject m_UIRoot; // 0x10
		private BgControl m_BgControl; // 0x14
		private LayoutDownLoad m_Layout; // 0x18
		private bool m_IsLoadLayout; // 0x1C
		private bool m_IsLoadedLayout; // 0x1D
		private bool m_IsFade; // 0x1E

		//public static DownLoadUIManager Instance { get; } 0x11B9770
		//public GameObject UIRoot { get; } 0x11BC594
		//public LayoutDownLoad Layout { get; } 0x11BC59C
		//public bool IsLoadLayout { get; } 0x11BF010
		//public bool IsLoadedLayout { get; } 0x11BC558
		//public bool IsFade { get; set; } 0x11C126C 0x11C1274

		// RVA: 0x11C127C Offset: 0x11C127C VA: 0x11C127C
		public void Awake()
		{
			return;
		}

		// RVA: 0x11C1280 Offset: 0x11C1280 VA: 0x11C1280
		public void OnDestroy()
		{
			sm_Instance = null;
		}

		//// RVA: 0x11BC560 Offset: 0x11BC560 VA: 0x11BC560
		//public void LoadResouce(List<int> diva_list) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6B53F8 Offset: 0x6B53F8 VA: 0x6B53F8
		//// RVA: 0x11C1310 Offset: 0x11C1310 VA: 0x11C1310
		//private IEnumerator Co_LoadResource(List<int> diva_list) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6B5470 Offset: 0x6B5470 VA: 0x6B5470
		//// RVA: 0x11C13D8 Offset: 0x11C13D8 VA: 0x11C13D8
		//public IEnumerator ChangeValkieriBg() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6B54E8 Offset: 0x6B54E8 VA: 0x6B54E8
		//// RVA: 0x11C1490 Offset: 0x11C1490 VA: 0x11C1490
		//private void <Co_LoadResource>b__24_0(LayoutDownLoad layout) { }
	}
}
