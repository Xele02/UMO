using UnityEngine.EventSystems;

namespace XeApp.Core
{
	public class EventSystemControl
	{
		private int m_blockCount; // 0x8
		private EventSystem eventSystem; // 0xC

		public bool InputEnabled { get; set; }

		// // RVA: 0x1D6EC40 Offset: 0x1D6EC40 VA: 0x1D6EC40
		public void Init(EventSystem es)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1D6ECA4 Offset: 0x1D6ECA4 VA: 0x1D6ECA4
		// public bool get_InputEnabled() { }

		// // RVA: 0x1D6ECB8 Offset: 0x1D6ECB8 VA: 0x1D6ECB8
		// public void set_InputEnabled(bool value) { }

		// // RVA: 0x1D6ED14 Offset: 0x1D6ED14 VA: 0x1D6ED14
		// public bool SwitchDefaultInputModule() { }

		// // RVA: 0x1D6EE5C Offset: 0x1D6EE5C VA: 0x1D6EE5C
		// public void SwitchCustomInputModle() { }
	}
}
