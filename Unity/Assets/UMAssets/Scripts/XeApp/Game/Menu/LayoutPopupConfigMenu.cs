using System;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigMenu : MonoBehaviour
	{
		private LayoutPopupConfigBase[] m_layouts; // 0xC
		private ConfigMenu.eType m_type; // 0x10

		public ConfigMenu.eType ConfigType { get { return m_type; } set
			{
				m_type = value;
				float pos = 0;
				for(int i = 0; i < m_layouts.Length; i++)
				{
					m_layouts[i].ConfigType = m_type;
					if(m_layouts[i].IsShow())
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
		} //0x1EC3BDC 0x1EC3BE4
		public Transform Parent { set {
				for(int i = 0; i < m_layouts.Length; i++)
				{
					m_layouts[i].Parent = value;
				}
			} } //0x1EC3DE8

		// RVA: 0x1EC3B68 Offset: 0x1EC3B68 VA: 0x1EC3B68
		private void Awake()
		{
			m_layouts = GetComponentsInChildren<LayoutPopupConfigBase>(true);
			Array.Reverse(m_layouts);
		}

		//// RVA: 0x1EC3E74 Offset: 0x1EC3E74 VA: 0x1EC3E74
		public int GetContentsHeight()
		{
			int res = 0;
			for (int i = 0; i < m_layouts.Length; i++)
			{
				res += m_layouts[i].GetContentsHeight();
			}
			return res + 10;
		}

		//// RVA: 0x1EC3F18 Offset: 0x1EC3F18 VA: 0x1EC3F18
		public bool IsLoaded()
		{
			for(int i = 0; i < m_layouts.Length; i++)
			{
				if(!m_layouts[i].IsLoaded())
					return false;
			}
			return true;
		}

		//// RVA: 0x1EC3FB4 Offset: 0x1EC3FB4 VA: 0x1EC3FB4
		public void SetStatus(ScrollRect scroll)
		{
			TodoLogger.LogError(0, "SetStatus");
		}

		// RVA: 0x1EC4054 Offset: 0x1EC4054 VA: 0x1EC4054
		public void Reset()
		{
			for(int i = 0; i < m_layouts.Length; i++)
			{
				;// m_layouts[i]
			}
		}

		//// RVA: 0x1EC40D8 Offset: 0x1EC40D8 VA: 0x1EC40D8
		//public void Show() { }

		//// RVA: 0x1EC4110 Offset: 0x1EC4110 VA: 0x1EC4110
		//public void Hide() { }
	}
}
