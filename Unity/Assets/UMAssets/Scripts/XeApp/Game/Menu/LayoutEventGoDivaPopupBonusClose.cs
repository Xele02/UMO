using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaPopupBonusClose : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textMain; // 0x14
		[SerializeField]
		private CheckboxButton m_checkHidden; // 0x18
		[SerializeField]
		private Text m_textHidden; // 0x1C
		public Action<bool> OnClickCheckButtonHiddenListener; // 0x20

		// RVA: 0x199363C Offset: 0x199363C VA: 0x199363C
		public void Setup()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textMain.text = bk.GetMessageByLabel("pop_godiva_bonus_close_text");
			m_textHidden.text = bk.GetMessageByLabel("pop_godiva_bonus_close_next_hidden");
			m_checkHidden.AddOnClickCallback(() =>
			{
				//0x1993810
				if(OnClickCheckButtonHiddenListener != null)
					OnClickCheckButtonHiddenListener(m_checkHidden.IsChecked);
			});
		}

		// RVA: 0x19937E4 Offset: 0x19937E4 VA: 0x19937E4
		public void Reset()
		{
			return;
		}

		// RVA: 0x19937E8 Offset: 0x19937E8 VA: 0x19937E8
		public void Show()
		{
			return;
		}

		// RVA: 0x19937EC Offset: 0x19937EC VA: 0x19937EC
		public void Hide()
		{
			return;
		}

		// RVA: 0x19937F0 Offset: 0x19937F0 VA: 0x19937F0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
