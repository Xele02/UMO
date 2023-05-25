using System;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigSimulation : MonoBehaviour
	{
		private LayoutPopupConfigBase[] m_layouts; // 0xC
		private ConfigMenu.eType m_type; // 0x10

		public ConfigMenu.eType ConfigType
		{
			get { return m_type; }
			set
			{
				m_type = value;
				float pos = 0;
				for (int i = 0; i < m_layouts.Length; i++)
				{
					m_layouts[i].ConfigType = m_type;
					if (m_layouts[i].IsShow())
					{
						m_layouts[i].Show();
						m_layouts[i].SetPosY(-pos);
						pos += m_layouts[i].GetContentsHeight();
					}
					else
					{
						m_layouts[i].Hide();
					}
				}
			}
		} //0x1ED7EAC 0x1ED75E4
		public Transform Parent {
			set
			{
				for (int i = 0; i < m_layouts.Length; i++)
				{
					m_layouts[i].Parent = value;
				}
			}
		} //0x1ED77E8

		// RVA: 0x1ED7E38 Offset: 0x1ED7E38 VA: 0x1ED7E38
		private void Awake()
		{
			m_layouts = GetComponentsInChildren<LayoutPopupConfigBase>(true);
			Array.Reverse(m_layouts);
		}

		// RVA: 0x1ED7874 Offset: 0x1ED7874 VA: 0x1ED7874
		public int GetContentsHeight()
		{
			int res = 0;
			for (int i = 0; i < m_layouts.Length; i++)
			{
				res += m_layouts[i].GetContentsHeight();
			}
			return res + 10;
		}

		//// RVA: 0x1ED7EB4 Offset: 0x1ED7EB4 VA: 0x1ED7EB4
		public bool IsLoaded()
		{
			TodoLogger.Log(0, "IsLoaded");
			return true;
		}

		//// RVA: 0x1ED70FC Offset: 0x1ED70FC VA: 0x1ED70FC
		public void SetStatus(ScrollRect scroll)
		{
			TodoLogger.Log(0, "SetStatus");
		}

		// RVA: 0x1ED7F50 Offset: 0x1ED7F50 VA: 0x1ED7F50
		public void Reset()
		{
			return;
		}

		//// RVA: 0x1ED7FD4 Offset: 0x1ED7FD4 VA: 0x1ED7FD4
		//public void Show() { }

		//// RVA: 0x1ED800C Offset: 0x1ED800C VA: 0x1ED800C
		//public void Hide() { }
	}
}
