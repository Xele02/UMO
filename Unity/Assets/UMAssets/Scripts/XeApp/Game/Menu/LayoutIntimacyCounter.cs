using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutIntimacyCounter : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textTime; // 0x14
		[SerializeField]
		private NumberBase m_numCount; // 0x18
		private AbsoluteLayout m_layoutRoot; // 0x1C
		private AbsoluteLayout m_layoutSwitch; // 0x20
		private Coroutine m_coroutine; // 0x24

		public bool IsOpen { get; private set; } // 0x28

		// RVA: 0x1D515A8 Offset: 0x1D515A8 VA: 0x1D515A8
		private void OnDisable()
		{
			if (m_coroutine == null)
				return;
			this.StopCoroutineWatched(m_coroutine);
			m_coroutine = null;
			Hide();
		}

		// RVA: 0x1D516A0 Offset: 0x1D516A0 VA: 0x1D516A0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("sw_fs_to_anim") as AbsoluteLayout;
			m_layoutSwitch = layout.FindViewById("swtbl_fs_to") as AbsoluteLayout;
			m_layoutSwitch.StartChildrenAnimGoStop("01");
			Loaded();
			return true;
		}

		//// RVA: 0x1D5181C Offset: 0x1D5181C VA: 0x1D5181C
		public void Enter()
		{
			if (IsOpen)
				return;
			gameObject.SetActive(true);
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			IsOpen = true;
		}

		//// RVA: 0x1D518EC Offset: 0x1D518EC VA: 0x1D518EC
		//public void Leave() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CC5FC Offset: 0x6CC5FC VA: 0x6CC5FC
		//// RVA: 0x1D51954 Offset: 0x1D51954 VA: 0x1D51954
		//private IEnumerator Co_Leave() { }

		//// RVA: 0x1D51A00 Offset: 0x1D51A00 VA: 0x1D51A00
		public void Show()
		{
			if (IsOpen)
				return;
			gameObject.SetActive(true);
			m_layoutRoot.StartChildrenAnimGoStop("st_in");
			IsOpen = true;
		}

		//// RVA: 0x1D515E0 Offset: 0x1D515E0 VA: 0x1D515E0
		public void Hide()
		{
			if (!IsOpen)
				return;
			gameObject.SetActive(false);
			m_layoutRoot.StartChildrenAnimGoStop("st_wait");
			IsOpen = false;
		}

		//// RVA: 0x1D51AC0 Offset: 0x1D51AC0 VA: 0x1D51AC0
		public void SetEnable(bool enable)
		{
			m_layoutSwitch.StartChildrenAnimGoStop(enable ? "01" : "02");
		}

		//// RVA: 0x1D51B58 Offset: 0x1D51B58 VA: 0x1D51B58
		public void SetCount(int count)
		{
			m_numCount.SetNumber(count, 0);
		}

		//// RVA: 0x1D51B98 Offset: 0x1D51B98 VA: 0x1D51B98
		public void SetTime(long time)
		{
			if(time < 0)
			{
				m_textTime.text = "MAX";
			}
			else
			{
				TimeSpan t = new TimeSpan(0, 0, (int)time);
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				if(t.Hours < 1)
					m_textTime.text = string.Format(bk.GetMessageByLabel("diva_intimacy_time_count"), t.Minutes, t.Seconds);
				else
					m_textTime.text = string.Format(bk.GetMessageByLabel("diva_intimacy_time_count_2"), t.Hours, t.Minutes, t.Seconds);
			}
		}
	}
}
