using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using mcrs;
using XeSys;
using System.Text;
using XeApp.Game.Common.View;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterMusicBookMark : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private UGUIToggleButtonGroup m_btnGroup; // 0x10
		[SerializeField]
		private UGUIToggleButton[] m_btn; // 0x14
		[SerializeField]
		private Text[] m_text; // 0x18
		[SerializeField]
		private Text[] m_text_wide; // 0x1C

		public override PopupFilterSortUGUIPartsBase.Type MyType { get { return PopupFilterSortUGUIPartsBase.Type.FilterMusicBookMark; } } // 0x1CA1940

		// [IteratorStateMachineAttribute] // RVA: 0x708C14 Offset: 0x708C14 VA: 0x708C14
		// RVA: 0x1CA1948 Offset: 0x1CA1948 VA: 0x1CA1948 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1CA1ADC
			for(int i = 0; i < m_btn.Length; i++)
			{
				m_btn[i].AddOnClickCallback(() =>
				{
					//0x1CA1A80
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
			}
			SetBookMarkText();
			yield break;
		}

		// // RVA: 0x1C9DB78 Offset: 0x1C9DB78 VA: 0x1C9DB78
		public void SetBookMarkText()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_text[0].text = bk.GetMessageByLabel("popup_sort_filter_bookmark_00");
			StringBuilder str = new StringBuilder();
			for(int i = 1; i < m_btn.Length; i++)
			{
				m_text[i].text = ViewBookMarkMusicData.BDCDCCJHOCD_GetBookmarkName(i - 1);
			}
		}

		// // RVA: 0x1C9DB44 Offset: 0x1C9DB44 VA: 0x1C9DB44
		public void SetIndex(int index)
		{
			m_btnGroup.SelectGroupButton(index);
		}

		// // RVA: 0x1C9DD68 Offset: 0x1C9DD68 VA: 0x1C9DD68
		public int GetIndex()
		{
			return m_btnGroup.GetSelectIndex();
		}
	}
}
