using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupDataOption : LayoutUGUIScriptBase
	{
		private enum eItemPos
		{
			BunchInstall = 0,
			CacheClear = 1,
			Count = 2,
		}

		[SerializeField]
		private ActionButton[] m_buttons; // 0x14
		[SerializeField]
		private RawImageEx[] m_buttonImages; // 0x18
		[SerializeField]
		private Text[] m_titleTexts; // 0x1C
		[SerializeField]
		private Text[] m_desc1Texts; // 0x20
		[SerializeField]
		private Text[] m_desc2Texts; // 0x24
		private TexUVList m_texUvList; // 0x30

		public Action CallbackCacheClear { get; set; } // 0x28
		public Action CallbackBunchInstall { get; set; } // 0x2C

		// RVA: 0x171C70C Offset: 0x171C70C VA: 0x171C70C
		public void SetStatus()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_titleTexts[1].text = bk.GetMessageByLabel("popup_option_cacheclear_title");
			m_desc1Texts[1].text = bk.GetMessageByLabel("popup_option_cacheclear_desc1");
			m_desc2Texts[1].text = bk.GetMessageByLabel("popup_option_cacheclear_desc2");
			SetupButton(m_buttons[1], m_buttonImages[1], "sel_opt_btn_fnt_01", CallbackCacheClear);
			m_titleTexts[0].text = bk.GetMessageByLabel("popup_option_bunchinstall_title");
			m_desc1Texts[0].text = bk.GetMessageByLabel("popup_option_bunchinstall_desc1");
			m_desc2Texts[0].text = bk.GetMessageByLabel("popup_option_bunchinstall_desc2");
			SetupButton(m_buttons[0], m_buttonImages[0], "sel_opt_btn_fnt_02", CallbackBunchInstall);
			m_buttons[0].Disable = true; // Disable on UMO, all files are here
		}

		// RVA: 0x171CE2C Offset: 0x171CE2C VA: 0x171CE2C
		public void Reset()
		{
			return;
		}

		// RVA: 0x171CE30 Offset: 0x171CE30 VA: 0x171CE30
		public void Show()
		{
			return;
		}

		// RVA: 0x171CE34 Offset: 0x171CE34 VA: 0x171CE34
		public void Hide()
		{
			return;
		}

		//// RVA: 0x171CC08 Offset: 0x171CC08 VA: 0x171CC08
		private void SetupButton(ActionButton button, RawImageEx image, string uvFontName, Action callback)
		{
			if(button != null)
			{
				button.ClearOnClickCallback();
				button.AddOnClickCallback(() =>
				{
					//0x171CED8
					if (callback != null)
						callback();
				});
				if(image != null)
				{
					image.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUvList.GetUVData(uvFontName));
				}
			}
		}

		// RVA: 0x171CE40 Offset: 0x171CE40 VA: 0x171CE40 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_texUvList = uvMan.GetTexUVList("sel_option_pack");
			Loaded();
			return true;
		}
	}
}
