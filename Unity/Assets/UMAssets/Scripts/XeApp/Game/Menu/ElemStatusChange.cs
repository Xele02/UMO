using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class ElemStatusChange
	{
		private float m_changeSec; // 0x8
		private bool m_isActive; // 0xC
		private float m_timer; // 0x10
		public Action onChangeEvent { private get; set; }

		//// RVA: 0x12740F0 Offset: 0x12740F0 VA: 0x12740F0
		public void Setup(float changeSec)
		{
			m_changeSec = changeSec;
		}

		//// RVA: 0x12740F8 Offset: 0x12740F8 VA: 0x12740F8
		public void Activate(bool immediate = false)
		{
			m_isActive = true;
			m_timer = immediate ? 0 : m_changeSec;
		}

		//// RVA: 0x1274118 Offset: 0x1274118 VA: 0x1274118
		public void Deactivate()
		{
			m_isActive = false;
		}

		//// RVA: 0x1274124 Offset: 0x1274124 VA: 0x1274124
		public void Update()
		{
			if(m_isActive)
			{
				if(m_timer <= 0)
				{
					if (onChangeEvent != null)
						onChangeEvent();
					m_timer = m_changeSec;
				}
				else
				{
					m_timer -= TimeWrapper.deltaTime;
				}
			}
		}
	}
}
