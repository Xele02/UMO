using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_Sort : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private int m_columnCount = 4; // 0x10
		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x14
		[SerializeField]
		private Text[] m_text; // 0x18
		[SerializeField]
		private Text[] m_text_wide; // 0x1C
		private SortItem[] m_item; // 0x20
		private float m_originalHeight; // 0x24
		public override PopupFilterSortUGUIPartsBase.Type MyType { get { return PopupFilterSortUGUIPartsBase.Type.Sort; } } // 0x1799CA4

		// [IteratorStateMachineAttribute] // RVA: 0x709BFC Offset: 0x709BFC VA: 0x709BFC
		// // RVA: 0x1799CAC Offset: 0x1799CAC VA: 0x1799CAC Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x179A7A4
			RectTransform rt = GetGuidSize();
			m_originalHeight = rt.rect.height;
			for(int i = 0; i < m_btn.Length; i++)
			{
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x179A718
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
			}
			yield break;
		}

		// // RVA: 0x1799D58 Offset: 0x1799D58 VA: 0x1799D58
		public void SetupItem(SortItem[] a_item)
		{
			Vector2 s;
			int cnt = 0;
			m_item = a_item;
			for(int i = 0; i < m_btn.Length; i++)
			{
				if(i < m_item.Length)
				{
					if(m_item[i] == SortItem.EpisodePoint || m_item[i] == SortItem.SecretBoard)
					{
						m_text_wide[i].text = PopupSortMenu.GetMsg_SortItem(a_item[i]);
						m_text_wide[i].enabled = true;
						m_text[i].enabled = false;
					}
					else
					{
						m_text[i].text = PopupSortMenu.GetMsg_SortItem(a_item[i]);
						m_text[i].enabled = true;
						m_text_wide[i].enabled = false;
					}
					m_btn[i].Hidden = false;
					int index = i;
					m_btn[i].AddOnClickCallback(() =>
					{
						//0x179A770
						OnChangeSort(index);
					});
					cnt++;
				}
				else
				{
					m_btn[i].Hidden = true;
					m_btn[i].ClearOnClickCallback();
				}
			}
			int d = (cnt - 1) / m_columnCount;
			s = GetGuidSize().sizeDelta;
			GetGuidSize().sizeDelta = new Vector2(s.x, m_originalHeight * (d + 1));
		}

		// // RVA: 0x179A3C4 Offset: 0x179A3C4 VA: 0x179A3C4
		public void SetSortItem(SortItem a_item)
		{
			for(int i = 0; i < m_item.Length; i++)
			{
				if(m_item[i] == a_item)
				{
					OnChangeSort(i);
					return;
				}
			}
		}

		// // RVA: 0x179A5B8 Offset: 0x179A5B8 VA: 0x179A5B8
		public SortItem GetSortItem()
		{
			for(int i = 0; i < m_btn.Length; i++)
			{
				if(m_btn[i].IsOn)
				{
					return m_item[i];
				}
			}
			return SortItem.None;
		}

		// // RVA: 0x179A454 Offset: 0x179A454 VA: 0x179A454
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

		// // RVA: 0x179A3A8 Offset: 0x179A3A8 VA: 0x179A3A8
		// private bool IsTextWide(SortItem a_sort) { }
	}
}
