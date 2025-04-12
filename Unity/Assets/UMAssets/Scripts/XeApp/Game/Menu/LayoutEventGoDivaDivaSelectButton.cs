using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaDivaSelectButton : LayoutUGUIScriptBase
	{
		public enum ModeType
		{
			WithExplain = 0,
			IconOnly = 1,
		}

		private static int DIVA_COUNT = 10; // 0x0
		[SerializeField]
		private RawImageEx[] m_imageDivaIconTbl; // 0x14
		[SerializeField]
		private Text[] m_textDivaLockTbl; // 0x18
		[SerializeField]
		private ActionButton[] m_buttonDivaTbl; // 0x1C
		[SerializeField]
		private Text m_textExplain; // 0x20
		private bool m_isShown; // 0x24
		private AbsoluteLayout m_layoutMain; // 0x28
		private AbsoluteLayout m_layoutIconPos; // 0x2C
		private AbsoluteLayout m_layoutExplainOnOff; // 0x30
		private AbsoluteLayout[] m_layoutButtonDivaTbl = new AbsoluteLayout[DIVA_COUNT]; // 0x34
		private AbsoluteLayout[] m_layoutSelectAnimTbl = new AbsoluteLayout[DIVA_COUNT]; // 0x38
		private bool[] m_isLockDivaTbl = new bool[DIVA_COUNT]; // 0x3C
		private int m_divaIconLoadingCount; // 0x40
		public Action<int> OnClickDivaIconListener; // 0x44

		public bool IsLoadingDivaIcon { get { return m_divaIconLoadingCount > 0; } } //0x18CA50C

		// // RVA: 0x18CA520 Offset: 0x18CA520 VA: 0x18CA520
		public void Enter()
		{
			m_isShown = true;
			m_layoutMain.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x18CA5B4 Offset: 0x18CA5B4 VA: 0x18CA5B4
		public void Leave()
		{
			m_isShown = false;
			m_layoutMain.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x18CA648 Offset: 0x18CA648 VA: 0x18CA648
		public void TryEnter()
		{
			if(!m_isShown)
				Enter();
		}

		// // RVA: 0x18CA658 Offset: 0x18CA658 VA: 0x18CA658
		public void TryLeave()
		{
			if(m_isShown)
				Leave();
		}

		// // RVA: 0x18CA668 Offset: 0x18CA668 VA: 0x18CA668
		// public void Show() { }

		// // RVA: 0x18CA6EC Offset: 0x18CA6EC VA: 0x18CA6EC
		public void Hide()
		{
			m_isShown = false;
			m_layoutMain.StartChildrenAnimGoStop("st_wait");
		}

		// RVA: 0x18CA770 Offset: 0x18CA770 VA: 0x18CA770
		public bool IsPlaying()
		{
			return m_layoutMain.IsPlayingChildren();
		}

		// // RVA: 0x18CA79C Offset: 0x18CA79C VA: 0x18CA79C
		public void SetDivaIcon(int index, int diva_id, int model_id, int color_id, bool isLock)
		{
			if(index > -1)
			{
				if(index < DIVA_COUNT)
				{
					m_divaIconLoadingCount++;
					GameManager.Instance.DivaIconCache.Load(diva_id, model_id, color_id, (IiconTexture icon) =>
					{
						//0x18CB9C8
						icon.Set(m_imageDivaIconTbl[index]);
						m_divaIconLoadingCount--;
					});
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					m_textDivaLockTbl[index].text = isLock ? bk.GetMessageByLabel("godiva_diva_select_not_have") : "";
					m_isLockDivaTbl[index] = isLock;
					m_buttonDivaTbl[index].enabled = !isLock;
					m_layoutButtonDivaTbl[index].StartChildrenAnimGoStop(isLock ? "st_bot_imp" : "st_wait");
				}
			}
		}

		// // RVA: 0x18CAC14 Offset: 0x18CAC14 VA: 0x18CAC14
		public void SetSelecting(int index)
		{
			for(int i = 0; i < DIVA_COUNT; i++)
			{
				if(!m_isLockDivaTbl[i])
				{
					if(index == i)
					{
						m_buttonDivaTbl[i].enabled = false;
						m_layoutButtonDivaTbl[i].StartChildrenAnimGoStop("go_bot_decide");
						m_layoutSelectAnimTbl[i].StartChildrenAnimLoop("logo_act_01", "loen_act_01");
					}
					else
					{
						m_buttonDivaTbl[i].enabled = true;
						m_layoutButtonDivaTbl[i].StartChildrenAnimGoStop("st_wait");
						m_layoutSelectAnimTbl[i].StartChildrenAnimLoop("st_non");
					}
				}
			}
		}

		// // RVA: 0x18CAF34 Offset: 0x18CAF34 VA: 0x18CAF34
		public void SetMode(ModeType mode)
		{
			if(mode == ModeType.IconOnly)
			{
				m_layoutIconPos.StartChildrenAnimGoStop("02");
				m_layoutExplainOnOff.StartChildrenAnimGoStop("02");
			}
			else if(mode == ModeType.WithExplain)
			{
				m_layoutIconPos.StartChildrenAnimGoStop("01");
				m_layoutExplainOnOff.StartChildrenAnimGoStop("01");
			}
		}

		// // RVA: 0x18CB048 Offset: 0x18CB048 VA: 0x18CB048
		public void InputEnable()
		{
			for(int i = 0; i < m_buttonDivaTbl.Length; i++)
			{
				m_buttonDivaTbl[i].IsInputOff = false;
			}
		}

		// // RVA: 0x18CB0C0 Offset: 0x18CB0C0 VA: 0x18CB0C0
		// public void InputDisable() { }

		// // RVA: 0x18CB138 Offset: 0x18CB138 VA: 0x18CB138
		private void OnClickDivaIcon(int index)
		{
			SetSelecting(index);
			if(OnClickDivaIconListener != null)
				OnClickDivaIconListener(index);
		}

		// RVA: 0x18CB1B8 Offset: 0x18CB1B8 VA: 0x18CB1B8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_layoutMain = layout.FindViewById("sw_s_m_diva_inout_anim") as AbsoluteLayout;
			m_layoutIconPos = layout.FindViewById("sw_cmn_sel_diva_all") as AbsoluteLayout;
			m_layoutExplainOnOff = layout.FindViewById("sw_sel_chara_frm") as AbsoluteLayout;
			for(int i = 0; i < DIVA_COUNT; i++)
			{
				m_layoutButtonDivaTbl[i] = layout.FindViewById(string.Format("sw_cmn_sel_diva_anim_{0:D2}", i + 1)) as AbsoluteLayout;
				m_layoutSelectAnimTbl[i] = m_layoutButtonDivaTbl[i].FindViewById("sw_cursor_anim") as AbsoluteLayout;
			}
			for(int i = 0; i < DIVA_COUNT; i++)
			{
				int index = i;
				m_buttonDivaTbl[i].AddOnClickCallback(() =>
				{
					//0x18CBB28
					OnClickDivaIcon(index);
				});
			}
			m_textExplain.text = MessageManager.Instance.GetMessage("menu", "godiva_diva_select_explain");
			Loaded();
			return true;
		}
	}
}
