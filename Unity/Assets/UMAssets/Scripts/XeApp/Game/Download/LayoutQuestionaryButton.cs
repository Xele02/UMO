using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace XeApp.Game.DownLoad
{
	public class LayoutQuestionaryButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ToggleButton m_toggleButton; // 0x14
		[SerializeField]
		private Text m_buttonLabel; // 0x18
		[SerializeField]
		private string m_rootExId; // 0x1C
		public UnityAction PushButtonHandler; // 0x20 0x9812BC 0x9813C8
		private AbsoluteLayout m_rootAnim; // 0x24
		private AbsoluteLayout m_buttonChangeAnim; // 0x28
		private bool m_isOpen; // 0x2C

		// RVA: 0x9814D4 Offset: 0x9814D4 VA: 0x9814D4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_toggleButton.AddOnClickCallback(OnPushButton);
			m_rootAnim = layout.FindViewByExId(m_rootExId) as AbsoluteLayout;
			Loaded();
			ClearLoadedCallback();
			return true;
		}

		//// RVA: 0x98160C Offset: 0x98160C VA: 0x98160C
		public void SetLabel(string label)
		{
			m_buttonLabel.text = label;
		}

		//// RVA: 0x981648 Offset: 0x981648 VA: 0x981648
		public void Open()
		{
			if(!m_isOpen)
			{
				m_rootAnim.StartChildrenAnimGoStop("go_in", "st_in");
			}
			m_isOpen = true;
			m_toggleButton.IsInputOff = false;
		}

		//// RVA: 0x98170C Offset: 0x98170C VA: 0x98170C
		public void Close()
		{
			if(m_isOpen)
			{
				m_rootAnim.StartChildrenAnimGoStop("go_out", "st_out");
			}
			m_isOpen = false;
			m_toggleButton.IsInputOff = true;
		}

		//// RVA: 0x9817D0 Offset: 0x9817D0 VA: 0x9817D0
		public bool IsPlaying()
		{
			if(m_rootAnim.IsVisible)
			{
				return m_rootAnim.IsPlayingChildren();
			}
			return false;
		}

		//// RVA: 0x981834 Offset: 0x981834 VA: 0x981834
		public void Hide()
		{
			m_rootAnim.StartChildrenAnimGoStop("st_out");
			m_toggleButton.IsInputOff = true;
		}

		//// RVA: 0x9818D4 Offset: 0x9818D4 VA: 0x9818D4
		public void Clear()
		{
			m_toggleButton.SetOff();
		}

		//// RVA: 0x981908 Offset: 0x981908 VA: 0x981908
		public bool IsOn()
		{
			return m_toggleButton.IsOn;
		}

		//// RVA: 0x981934 Offset: 0x981934 VA: 0x981934
		public bool IsDisable()
		{
			return m_toggleButton.Disable;
		}

		//// RVA: 0x981960 Offset: 0x981960 VA: 0x981960
		public void SetEnable()
		{
			m_toggleButton.Disable = false;
		}

		//// RVA: 0x981990 Offset: 0x981990 VA: 0x981990
		public void SetDisable()
		{
			m_toggleButton.Disable = true;
		}

		//// RVA: 0x9819C0 Offset: 0x9819C0 VA: 0x9819C0
		private void OnPushButton()
		{
			if (PushButtonHandler != null)
				PushButtonHandler();
		}
	}
}
