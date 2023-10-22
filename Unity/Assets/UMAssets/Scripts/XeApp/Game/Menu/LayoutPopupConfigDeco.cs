using System;
using UnityEngine;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigDeco : MonoBehaviour
	{
		private LayoutPopupDecoOptionBase[] m_layouts; // 0xC

		public MDDBFCFOKFC SaveData { set
		{
			for(int i = 0; i < m_layouts.Length; i++)
			{
				m_layouts[i].SaveData = value;
			}
		} } //0x1EC0F5C
		//public Transform Parent { set; } 0x1EC1068

		// RVA: 0x1EC0FF4 Offset: 0x1EC0FF4 VA: 0x1EC0FF4
		private void Awake()
		{
			m_layouts = GetComponentsInChildren<LayoutPopupDecoOptionBase>(true);
			Array.Reverse(m_layouts);
		}

		//// RVA: 0x1EC10F4 Offset: 0x1EC10F4 VA: 0x1EC10F4
		public void SetLayoutHeight()
		{
			int y = 10;
			for(int i = 0; i < m_layouts.Length; i++)
			{
				if(m_layouts[i].IsShow())
				{
					m_layouts[i].Show();
					m_layouts[i].SetPosY(-y);
					y += m_layouts[i].GetContentsHeight();
				}
				else
				{
					m_layouts[i].Hide();
				}
			}
		}

		//// RVA: 0x1EC12A8 Offset: 0x1EC12A8 VA: 0x1EC12A8
		public void SetSizeDelta(Vector2 sizeDelta)
		{
			for(int i = 0; i < m_layouts.Length; i++)
			{
				m_layouts[i].GetComponent<RectTransform>().sizeDelta = sizeDelta;
			}
		}

		//// RVA: 0x1EC13B0 Offset: 0x1EC13B0 VA: 0x1EC13B0
		//public int GetContentsHeight() { }

		//// RVA: 0x1EC1454 Offset: 0x1EC1454 VA: 0x1EC1454
		public void SetStatus(ScrollRect scroll)
		{
			for(int i = 0; i < m_layouts.Length; i++)
			{
				m_layouts[i].SetStatus(scroll);
			}
		}

		//// RVA: 0x1EC14F4 Offset: 0x1EC14F4 VA: 0x1EC14F4
		public void SetDecoOption(MDDBFCFOKFC saveData)
		{
			for(int i = 0; i < m_layouts.Length; i++)
			{
				m_layouts[i].SetDecoOption(saveData);
			}
		}

		// RVA: 0x1EC1594 Offset: 0x1EC1594 VA: 0x1EC1594
		public bool IsLoad()
		{
			for(int i = 0; i < m_layouts.Length; i++)
			{
				if (!m_layouts[i].IsLoaded())
					return false;
			}
			return true;
		}

		// RVA: 0x1EC1630 Offset: 0x1EC1630 VA: 0x1EC1630
		public void Reset()
		{
			for(int i = 0; i < m_layouts.Length; i++)
			{
				//m_layouts[i].??
			}
		}

		//// RVA: 0x1EC16B4 Offset: 0x1EC16B4 VA: 0x1EC16B4
		//public void Show() { }

		//// RVA: 0x1EC16EC Offset: 0x1EC16EC VA: 0x1EC16EC
		//public void Hide() { }
	}
}
