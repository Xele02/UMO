using XeSys.Gfx;

namespace XeApp.Game.Common
{
	public class TabButtonControl : LayoutUGUIScriptBase
	{
		private ActionButton[] m_buttons; // 0x14

		// RVA: 0x1CCE3D4 Offset: 0x1CCE3D4 VA: 0x1CCE3D4
		private void Start()
		{
			m_buttons = GetComponentsInChildren<ActionButton>(true);
			for(int i = 0; i < m_buttons.Length; i++)
			{
				int index = i;
				m_buttons[i].AddOnClickCallback(() => {
					//0x1CCE56C
					for(int j = 0; j < m_buttons.Length; j++)
					{
						if(j != index)
						{
							m_buttons[j].SetOff();
						}
					}
				});
			}
		}

		// RVA: 0x1CCE560 Offset: 0x1CCE560 VA: 0x1CCE560
		private void Update()
		{
			return;
		}
	}
}
