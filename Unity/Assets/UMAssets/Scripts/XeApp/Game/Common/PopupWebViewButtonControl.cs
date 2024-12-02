using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using mcrs;

namespace XeApp.Game.Common
{
	public class PopupWebViewButtonControl : LayoutUGUIScriptBase
	{
		private enum ButtonType
		{
			Return = 0,
			Close = 1,
		}

		[SerializeField]
		private ActionButton m_returnButton; // 0x14
		[SerializeField]
		private ActionButton m_closeButton; // 0x18
		[SerializeField]
		private List<RawImageEx> m_labels; // 0x1C
		[SerializeField]
		private CheckboxButton m_rejectCheckbox; // 0x20
		[SerializeField]
		private Text m_rejectText; // 0x24
		//[CompilerGeneratedAttribute] // RVA: 0x68BE6C Offset: 0x68BE6C VA: 0x68BE6C
		public UnityAction PushReturnButtonHandler; // 0x28
		//[CompilerGeneratedAttribute] // RVA: 0x68BE7C Offset: 0x68BE7C VA: 0x68BE7C
		public UnityAction PushCloseButtonHandler; // 0x2C
		private AbsoluteLayout m_rootLayout; // 0x30
		private bool m_showReturnButton; // 0x34
		private bool m_showRejectCheckbox; // 0x35
		private static readonly string[] uvNameTbl = new string[2]
		{
			"cmn_pop01_fnt_01_15", "cmn_pop01_fnt_01_09"
		}; // 0x0

		// RVA: 0x1BB5CA8 Offset: 0x1BB5CA8 VA: 0x1BB5CA8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			for(int i = 0; i < m_labels.Count; i++)
			{
				m_labels[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(uvNameTbl[i]));
			}
			m_returnButton.AddOnClickCallback(OnReturn);
			m_closeButton.AddOnClickCallback(OnClose);
			m_rejectCheckbox.AddOnClickCallback(OnClickCheck);
			m_rootLayout = layout.FindViewByExId("root_btn_webview_btn_webview_arrange") as AbsoluteLayout;
			GameManager.Instance.GetSystemFont().Apply(m_rejectText);
			m_rejectText.text = JpStringLiterals.StringLiteral_14355;
			ClearLoadedCallback();
			Loaded();
			return true;
		}

		// RVA: 0x1BB6108 Offset: 0x1BB6108 VA: 0x1BB6108
		public void SetDisableReturnButton(bool isDisable)
		{
			if(m_returnButton.IsLoaded())
				m_returnButton.Disable = isDisable;
		}

		// // RVA: 0x1BB6168 Offset: 0x1BB6168 VA: 0x1BB6168
		public void ShowReturnButton(bool isShow)
		{
			m_showReturnButton = isShow;
			UpdateButtonTable();
		}

		// // RVA: 0x1BB6230 Offset: 0x1BB6230 VA: 0x1BB6230
		public void ShowRejectCheckbox(bool isShow)
		{
			m_showRejectCheckbox = isShow;
			UpdateButtonTable();
		}

		// // RVA: 0x1BB6238 Offset: 0x1BB6238 VA: 0x1BB6238
		public void ResetRejectCheckbox(bool on = false)
		{
			if(on)
				m_rejectCheckbox.SetOn();
			else
				m_rejectCheckbox.SetOff();
		}

		// // RVA: 0x1BB6284 Offset: 0x1BB6284 VA: 0x1BB6284
		// public bool IsRejectChecked() { }

		// // RVA: 0x1BB62B0 Offset: 0x1BB62B0 VA: 0x1BB62B0
		private void OnReturn()
		{
			if(PushReturnButtonHandler != null)
				PushReturnButtonHandler();
		}

		// // RVA: 0x1BB62C4 Offset: 0x1BB62C4 VA: 0x1BB62C4
		private void OnClose()
		{
			if(PushCloseButtonHandler != null)
				PushCloseButtonHandler();
		}

		// // RVA: 0x1BB62D8 Offset: 0x1BB62D8 VA: 0x1BB62D8
		private void OnClickCheck()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		// // RVA: 0x1BB6170 Offset: 0x1BB6170 VA: 0x1BB6170
		private void UpdateButtonTable()
		{
			if(!m_showRejectCheckbox)
			{
				if(m_showReturnButton)
					m_rootLayout.StartChildrenAnimGoStop("01");
				else
					m_rootLayout.StartChildrenAnimGoStop("02");
			}
			else
			{
				if(m_showReturnButton)
					m_rootLayout.StartChildrenAnimGoStop("03");
				else
					m_rootLayout.StartChildrenAnimGoStop("04");
			}
		}
	}
}
