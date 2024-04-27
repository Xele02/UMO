using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutPopupStopAccount : LayoutUGUIScriptBase
	{
		public enum Type
		{
			ACCOUNT = 0,
			EVENT = 1,
		}

		[SerializeField]
		private Text m_text00; // 0x14
		[SerializeField]
		private ActionButton m_button; // 0x18

		public Action CallbackButtonContract { get; set; } // 0x1C

		// // RVA: 0x1789EB8 Offset: 0x1789EB8 VA: 0x1789EB8
		public void SetStatus(Type type)
		{
			SetDesc(type);
			SetButtonCallback();
		}

		// // RVA: 0x1789ED4 Offset: 0x1789ED4 VA: 0x1789ED4
		private void SetDesc(Type type)
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			if(m_text00 != null)
			{
				if(type == Type.EVENT)
				{
					m_text00.text = bk.GetMessageByLabel("popup_ranking_ban_01");
				}
				else if(type == Type.ACCOUNT)
				{
					m_text00.text = bk.GetMessageByLabel("saka_error0059");
				}
				m_text00.lineSpacing = 0.7f;
			}
		}

		// // RVA: 0x178A068 Offset: 0x178A068 VA: 0x178A068
		private void SetButtonCallback()
		{
			if(m_button != null)
			{
				m_button.ClearOnClickCallback();
				m_button.AddOnClickCallback(() =>
				{
					//0x178A20C
					if(CallbackButtonContract != null)
						CallbackButtonContract();
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
			}
		}

		// RVA: 0x178A178 Offset: 0x178A178 VA: 0x178A178
		public void Reset()
		{
			return;
		}

		// // RVA: 0x178A17C Offset: 0x178A17C VA: 0x178A17C
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// // RVA: 0x178A1B4 Offset: 0x178A1B4 VA: 0x178A1B4
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x178A1EC Offset: 0x178A1EC VA: 0x178A1EC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
