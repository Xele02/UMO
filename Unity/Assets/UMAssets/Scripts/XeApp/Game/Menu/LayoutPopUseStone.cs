using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutPopUseStone : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_text00; // 0x14
		[SerializeField]
		private Text m_text01; // 0x18
		[SerializeField]
		private ActionButton m_button; // 0x1C
		private AbsoluteLayout m_limitTextLayout; // 0x20
		private bool IsLegal = true; // 0x24

		public Action CallbackButtonContract { get; set; } // 0x28

		//// RVA: 0x15DD4D0 Offset: 0x15DD4D0 VA: 0x15DD4D0
		public void SetStatus(string str, string str2, bool IsLegalButton)
		{
			m_text00.text = str;
			m_text01.text = str2;
			SetButtonCallback();
			IsLegal = !IsLegalButton;
		}

		// RVA: 0x15DD554 Offset: 0x15DD554 VA: 0x15DD554
		public void SetMainText(string str)
		{
			m_text00.text = str;
		}

		//// RVA: 0x15DD590 Offset: 0x15DD590 VA: 0x15DD590
		//public void SetLimitText(string str) { }

		//// RVA: 0x15DD5CC Offset: 0x15DD5CC VA: 0x15DD5CC
		private void SetButtonCallback()
		{
			if(m_button != null)
			{
				m_button.ClearOnClickCallback();
				m_button.AddOnClickCallback(() =>
				{
					//0x15DDA64
					if(CallbackButtonContract != null)
						CallbackButtonContract();
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
			}
		}

		// RVA: 0x15DD6DC Offset: 0x15DD6DC VA: 0x15DD6DC
		public void Reset()
		{
			return;
		}

		//// RVA: 0x15DD6E0 Offset: 0x15DD6E0 VA: 0x15DD6E0
		public void Show()
		{
			SetButtonHidden();
			checkLimitTextDisable();
			gameObject.SetActive(true);
		}

		//// RVA: 0x15DD8A0 Offset: 0x15DD8A0 VA: 0x15DD8A0
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		//// RVA: 0x15DD768 Offset: 0x15DD768 VA: 0x15DD768
		public bool checkLimitTextDisable()
		{
			if(m_limitTextLayout != null)
			{
				if(m_text01 != null)
				{
					string txt = m_text01.text;
					m_limitTextLayout.StartChildrenAnimGoStop(txt == "" ? "02" : "01");
					return txt == "";
				}
			}
			return true;
		}

		//// RVA: 0x15DD8D8 Offset: 0x15DD8D8 VA: 0x15DD8D8
		//public bool IsButtonHidden() { }

		//// RVA: 0x15DD72C Offset: 0x15DD72C VA: 0x15DD72C
		public void SetButtonHidden()
		{
			m_button.Hidden = IsLegal;
		}

		//// RVA: 0x15DD904 Offset: 0x15DD904 VA: 0x15DD904
		public bool IsReady()
		{
			return m_button.IsLoaded() && IsLoaded();
		}

		// RVA: 0x15DD948 Offset: 0x15DD948 VA: 0x15DD948 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_limitTextLayout = layout.FindViewByExId("sw_use_stone_btn_all_swtbl_u_s_count") as AbsoluteLayout;
			m_limitTextLayout.StartChildrenAnimGoStop("02");
			checkLimitTextDisable();
			Loaded();
			return true;
		}
	}
}
