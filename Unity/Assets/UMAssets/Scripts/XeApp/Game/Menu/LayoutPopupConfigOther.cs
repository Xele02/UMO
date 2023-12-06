using System;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigOther : MonoBehaviour
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
		} // 0x1EC6F28 0x1EC6F30
		public Transform Parent
		{
			set
			{
				for (int i = 0; i < m_layouts.Length; i++)
				{
					m_layouts[i].Parent = value;
				}
			}
		} //0x1EC7134

		// RVA: 0x1EC6EB4 Offset: 0x1EC6EB4 VA: 0x1EC6EB4
		private void Awake()
		{
			m_layouts = GetComponentsInChildren<LayoutPopupConfigBase>(true);
			Array.Reverse(m_layouts);
		}

		//// RVA: 0x1EC71C0 Offset: 0x1EC71C0 VA: 0x1EC71C0
		public int GetContentsHeight()
		{
			int res = 0;
			for (int i = 0; i < m_layouts.Length; i++)
			{
				res += m_layouts[i].GetContentsHeight();
			}
			return res + 10;
		}

		//// RVA: 0x1EC72C4 Offset: 0x1EC72C4 VA: 0x1EC72C4
		public bool IsLoaded()
		{
			for(int i = 0; i < m_layouts.Length; i++)
			{
				if (!m_layouts[i].IsLoaded())
					return false;
			}
			return true;
		}

		//// RVA: 0x1EC7360 Offset: 0x1EC7360 VA: 0x1EC7360
		public void SetStatus(ScrollRect scroll)
		{
			for(int i = 0; i < m_layouts.Length; i++)
			{
				m_layouts[i].SetStatus(scroll);
			}
		}

		// RVA: 0x1EC7400 Offset: 0x1EC7400 VA: 0x1EC7400
		public void Reset()
		{
			return;
		}

		//// RVA: 0x1EC7484 Offset: 0x1EC7484 VA: 0x1EC7484
		//public void Show() { }

		//// RVA: 0x1EC74BC Offset: 0x1EC74BC VA: 0x1EC74BC
		//public void Hide() { }
	}
}
