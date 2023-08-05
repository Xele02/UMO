using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortParts_Sort2 : PopupFilterSortPartsBase
	{
		[SerializeField]
		private ToggleButton[] m_btn; // 0x1C
		[SerializeField]
		private Text[] m_text; // 0x20
		[SerializeField]
		private Text[] m_text_wide; // 0x24
		private SortItem[] m_item; // 0x28

		// // RVA: 0x1C8C2FC Offset: 0x1C8C2FC VA: 0x1C8C2FC
		public void Initialize(SortItem[] a_item)
		{
			m_item = a_item;
			for(int i = 0; i < m_btn.Length; i++)
			{
				if(i < a_item.Length)
				{
					int sitem = (int)a_item[i] - 23;
					if(sitem >= 0 && sitem < 17 && (0x10021 & (1 << (sitem))) != 0)
					{
						m_text_wide[i].text = PopupSortMenu.GetMsg_SortItem(a_item[i]);
						m_text_wide[i].enabled = true;
						if(m_text[i] != null)
							m_text[i].enabled = false;
					}
					else
					{
						m_text[i].text = PopupSortMenu.GetMsg_SortItem(a_item[i]);
						m_text[i].enabled = true;
						if(m_text_wide[i] != null)
						m_text_wide[i].enabled = false;
					}
					m_btn[i].Hidden = false;
					int t_index = i;
					m_btn[i].AddOnClickCallback(() =>
					{
						//0x1C8CC3C
						OnChangeSort(t_index);
					});
				}
				else
				{
					m_btn[i].Hidden = true;
					m_btn[i].ClearOnClickCallback();
				}
			}
		}

		// // RVA: 0x1C8C954 Offset: 0x1C8C954 VA: 0x1C8C954
		public void SetSortItem(SortItem a_item)
		{
			for(int i = 0; i < m_item.Length; i++)
			{
				if(m_item[i] == a_item)
					OnChangeSort(i);
			}
		}

		// // RVA: 0x1C8CB48 Offset: 0x1C8CB48 VA: 0x1C8CB48
		public SortItem GetSortItem()
		{
			for(int i = 0; i < m_btn.Length; i++)
			{
				if(m_btn[i].IsOn)
					return m_item[i];
			}
			return SortItem.None;
		}

		// // RVA: 0x1C8C9E4 Offset: 0x1C8C9E4 VA: 0x1C8C9E4
		private void OnChangeSort(int a_index)
		{
			for(int i = 0; i < m_btn.Length; i++)
			{
				if(!m_btn[i].Disable && !m_btn[i].Hidden)
				{
					if(i == a_index)
						m_btn[i].SetOn();
					else
						m_btn[i].SetOff();
				}
			}
		}

		// // RVA: 0x1C8C930 Offset: 0x1C8C930 VA: 0x1C8C930
		// private bool IsTextWide(SortItem a_sort) { }

		// RVA: 0x1C8CC1C Offset: 0x1C8CC1C VA: 0x1C8CC1C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			return true;
		}
	}
}
