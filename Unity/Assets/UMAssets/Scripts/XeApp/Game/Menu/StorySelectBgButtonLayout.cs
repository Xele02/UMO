using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using mcrs;

namespace XeApp.Game.Menu
{
	public class StorySelectBgButtonLayout : LayoutUGUIScriptBase
	{
		private enum eLabel
		{
			Off = 0,
			On = 1,
		}

		[SerializeField]
		private ActionButton m_button; // 0x14
		[SerializeField]
		private RawImageEx m_label; // 0x18
		private const float TAPWAIT_DISTANCE = 5;
		private Vector3 m_startTapPos; // 0x28
		private AbsoluteLayout m_root; // 0x34
		private List<IEnumerator> m_animationList = new List<IEnumerator>(8); // 0x38
		private TexUVListManager m_uvList; // 0x3C
		private LayoutUGUIHitOnly m_hitOnly; // 0x40
		private readonly string[] m_viewLabel = new string[2] { "sel_sns_view_fnt_off", "sel_sns_view_fnt_on" }; // 0x44

		public Action CallbackButton { get; set; } // 0x1C
		public Action CallbackScreenTap { get; set; } // 0x20
		public bool IsShowBg { get; private set; } // 0x24

		//// RVA: 0x12E3840 Offset: 0x12E3840 VA: 0x12E3840
		//public void SetStatus() { }

		//// RVA: 0x12E3844 Offset: 0x12E3844 VA: 0x12E3844
		private void SetButtonLabel(eLabel label)
		{
			if((int)label > -1)
			{
				if((int)label < m_viewLabel.Length)
				{
					if(m_label != null)
					{
						m_label.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvList.GetUVData(m_viewLabel[(int)label]));
					}
				}
			}
		}

		// RVA: 0x12E39D8 Offset: 0x12E39D8 VA: 0x12E39D8
		public void Update()
		{
			if (m_animationList.Count < 1)
				return;
			if (!m_animationList[0].MoveNext())
				m_animationList.RemoveAt(0);
		}

		// RVA: 0x12E3B50 Offset: 0x12E3B50 VA: 0x12E3B50
		public void Reset()
		{
			return;
		}

		//// RVA: 0x12E3B54 Offset: 0x12E3B54 VA: 0x12E3B54
		public void Show()
		{
			if (m_root != null)
				m_root.StartChildrenAnimGoStop("go_in", "st_in");
			m_animationList.Clear();
			m_animationList.Add(WaitAnimShow());
		}

		//// RVA: 0x12E3CC8 Offset: 0x12E3CC8 VA: 0x12E3CC8
		private void OutInner()
		{
			if (m_root == null)
				return;
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
			if (m_hitOnly != null)
				m_hitOnly.enabled = false;
			m_animationList.Clear();
			m_animationList.Add(WaitAnimOut());
		}

		//// RVA: 0x12E3EA8 Offset: 0x12E3EA8 VA: 0x12E3EA8
		public void Out()
		{
			if (m_root == null)
				return;
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
			if (m_hitOnly != null)
				m_hitOnly.enabled = false;
			m_animationList.Clear();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72B54C Offset: 0x72B54C VA: 0x72B54C
		//// RVA: 0x12E3E1C Offset: 0x12E3E1C VA: 0x12E3E1C
		private IEnumerator WaitAnimOut()
		{
			//0x12E46F8
			while(m_root.IsPlayingChildren())
				yield return null;
			if (!IsShowBg)
				SetCallbackViewIn();
			else
				SetCallbackViewOut();
			Show();
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72B5C4 Offset: 0x72B5C4 VA: 0x72B5C4
		//// RVA: 0x12E3C3C Offset: 0x12E3C3C VA: 0x12E3C3C
		private IEnumerator WaitAnimShow()
		{
			//0x12E4848
			while (m_root.IsPlayingChildren())
				yield return null;
			if (m_hitOnly != null)
				m_hitOnly.enabled = true;
		}

		//// RVA: 0x12E4000 Offset: 0x12E4000 VA: 0x12E4000
		private void SetCallbackViewIn()
		{
			if(m_button != null)
			{
				m_button.ClearOnClickCallback();
				m_button.AddOnClickCallback(() =>
				{
					//0x12E45F4
					if (CallbackButton != null)
						CallbackButton();
					IsShowBg = true;
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					OutInner();
				});
				SetButtonLabel(eLabel.On);
			}
		}

		//// RVA: 0x12E411C Offset: 0x12E411C VA: 0x12E411C
		private void SetCallbackViewOut()
		{
			if (m_button == null)
				return;
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0x12E4674
				if (CallbackScreenTap != null)
					CallbackScreenTap();
				IsShowBg = false;
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				OutInner();
			});
			SetButtonLabel(eLabel.Off);
		}

		//// RVA: 0x12E4238 Offset: 0x12E4238 VA: 0x12E4238
		public void PerformClick()
		{
			if (m_button.IsInputOff)
				return;
			if (m_button.Disable)
				return;
			m_button.PerformClick();
		}

		//// RVA: 0x12E42BC Offset: 0x12E42BC VA: 0x12E42BC
		public bool IsExecuteAnimationList()
		{
			return m_animationList.Count > 0;
		}

		// RVA: 0x12E4344 Offset: 0x12E4344 VA: 0x12E4344 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvList = uvMan;
			m_root = layout.Root[0] as AbsoluteLayout;
			m_hitOnly = GetComponentInChildren<LayoutUGUIHitOnly>();
			SetCallbackViewIn();
			Loaded();
			return true;
		}
	}
}
