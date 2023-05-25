using System;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigRhythm : MonoBehaviour
	{
		private LayoutPopupConfigBase[] m_layouts; // 0xC
		private ConfigMenu.eType m_type; // 0x10

		public ConfigMenu.eType ConfigType { get { return m_type; }
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
		} //0x1ECAC08 0x1ECAC10
		public Action CallbackButtonTiming { set
			{
				for (int i = 0; i < m_layouts.Length; i++)
				{
					if (m_layouts[i] is LayoutPopupConfigRhythm_05)
					{
						(m_layouts[i] as LayoutPopupConfigRhythm_05).CallbackButtonTiming = value;
					}
				}
			}
		} //0x1ECAE14
		public Transform Parent {
			set
			{
				for (int i = 0; i < m_layouts.Length; i++)
				{
					m_layouts[i].Parent = value;
				}
			}
		} //0x1ECAF78

		// RVA: 0x1ECAB94 Offset: 0x1ECAB94 VA: 0x1ECAB94
		private void Awake()
		{
			m_layouts = GetComponentsInChildren<LayoutPopupConfigBase>(true);
			Array.Reverse(m_layouts);
		}

		//// RVA: 0x1ECB004 Offset: 0x1ECB004 VA: 0x1ECB004
		public int GetContentsHeight()
		{
			int res = 0;
			for (int i = 0; i < m_layouts.Length; i++)
			{
				res += m_layouts[i].GetContentsHeight();
			}
			return res + 10;
		}

		//// RVA: 0x1ECB0A8 Offset: 0x1ECB0A8 VA: 0x1ECB0A8
		public bool IsLoaded()
		{
			for(int i = 0; i < m_layouts.Length; i++)
			{
				if (!m_layouts[i].IsLoaded())
					return false;
			}
			return true;
		}

		//// RVA: 0x1ECB144 Offset: 0x1ECB144 VA: 0x1ECB144
		public void SetStatus(ScrollRect scroll)
		{
			for(int i = 0; i < m_layouts.Length; i++)
			{
				m_layouts[i].SetStatus(scroll);
			}
		}

		// RVA: 0x1ECB1E4 Offset: 0x1ECB1E4 VA: 0x1ECB1E4
		public void Reset()
		{
			return;
		}

		//// RVA: 0x1ECB268 Offset: 0x1ECB268 VA: 0x1ECB268
		//public void Show() { }

		//// RVA: 0x1ECB2A0 Offset: 0x1ECB2A0 VA: 0x1ECB2A0
		//public void Hide() { }
	}
}
