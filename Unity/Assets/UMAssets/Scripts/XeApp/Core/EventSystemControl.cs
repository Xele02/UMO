using UnityEngine.EventSystems;

namespace XeApp.Core
{
	public class EventSystemControl
	{
		private int m_blockCount; // 0x8
		private EventSystem eventSystem; // 0xC

		// public bool InputEnabled { get; set; } 0x1D6ECA4 0x1D6ECB8

		// // RVA: 0x1D6EC40 Offset: 0x1D6EC40 VA: 0x1D6EC40
		public void Init(EventSystem es)
		{
			m_blockCount = 0;
			eventSystem = es;
			es.enabled = true;
			eventSystem.pixelDragThreshold = 16;
		}

		// // RVA: 0x1D6ED14 Offset: 0x1D6ED14 VA: 0x1D6ED14
		// public bool SwitchDefaultInputModule() { }

		// // RVA: 0x1D6EE5C Offset: 0x1D6EE5C VA: 0x1D6EE5C
		// public void SwitchCustomInputModle() { }
	}
}
