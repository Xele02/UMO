using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutPopupContract : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_text00; // 0x14
		[SerializeField]
		private Text m_text01; // 0x18
		[SerializeField]
		private ActionButton m_button; // 0x1C

		public Action CallbackButtonContract { get; set; } // 0x20

		// // RVA: 0x1EDB920 Offset: 0x1EDB920 VA: 0x1EDB920
		public void SetStatus()
		{
			SetDesc();
			SetButtonCallback();
		}

		// // RVA: 0x1EDB93C Offset: 0x1EDB93C VA: 0x1EDB93C
		private void SetDesc()
		{
			if(m_text00 != null)
				m_text00.text = MessageManager.Instance.GetBank("common").GetMessageByLabel("popup_kiyaku_001");
			if(m_text01 != null)
			{
				m_text01.horizontalOverflow = HorizontalWrapMode.Overflow;
				m_text01.text = MessageManager.Instance.GetBank("common").GetMessageByLabel("popup_kiyaku_002");
			}
		}

		// // RVA: 0x1EDBB34 Offset: 0x1EDBB34 VA: 0x1EDBB34
		private void SetButtonCallback()
		{
			if(m_button != null)
			{
				m_button.ClearOnClickCallback();
				m_button.AddOnClickCallback(() => {
					//0x1EDBCD8
					if(CallbackButtonContract != null)
						CallbackButtonContract();
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
			}
		}

		// // RVA: 0x1EDBC44 Offset: 0x1EDBC44 VA: 0x1EDBC44
		// public void Reset() { }

		// // RVA: 0x1EDBC48 Offset: 0x1EDBC48 VA: 0x1EDBC48
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// // RVA: 0x1EDBC80 Offset: 0x1EDBC80 VA: 0x1EDBC80
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1EDBCB8 Offset: 0x1EDBCB8 VA: 0x1EDBCB8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
