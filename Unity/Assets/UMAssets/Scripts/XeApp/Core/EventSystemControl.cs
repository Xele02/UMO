using UnityEngine.EventSystems;

namespace XeApp.Core
{
	public class EventSystemControl
	{
		private int m_blockCount; // 0x8
		private EventSystem eventSystem; // 0xC

		public bool InputEnabled { get { return m_blockCount < 1; } set
			{
				if(value)
				{
					if (m_blockCount > 0)
						m_blockCount--;
				}
				else
				{
					m_blockCount++;
				}
				eventSystem.enabled = m_blockCount < 1;
			}
		} //0x1D6ECA4 0x1D6ECB8

		// // RVA: 0x1D6EC40 Offset: 0x1D6EC40 VA: 0x1D6EC40
		public void Init(EventSystem es)
		{
			m_blockCount = 0;
			eventSystem = es;
			es.enabled = true;
			eventSystem.pixelDragThreshold = 16;
		}

		// // RVA: 0x1D6ED14 Offset: 0x1D6ED14 VA: 0x1D6ED14
		public bool SwitchDefaultInputModule()
		{
			BaseInputModule m = eventSystem.gameObject.GetComponent<BaseInputModule>();
			if (m != null)
			{
				if (m is CustomInputModule)
				{
					UnityEngine.Object.Destroy(m);
					eventSystem.gameObject.AddComponent<StandaloneInputModule>();
					return true;
				}
			}
			return false;
		}

		// // RVA: 0x1D6EE5C Offset: 0x1D6EE5C VA: 0x1D6EE5C
		public void SwitchCustomInputModle()
		{
			UnityEngine.Object.Destroy(eventSystem.gameObject.GetComponent<BaseInputModule>());
			eventSystem.gameObject.AddComponent<CustomInputModule>();
		}
	}
}
