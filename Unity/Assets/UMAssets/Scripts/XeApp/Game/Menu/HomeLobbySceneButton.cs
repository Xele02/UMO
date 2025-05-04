using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using XeSys;

namespace XeApp.Game.Menu
{
	public class HomeLobbySceneButton : LayoutUGUIScriptBase
	{
		public enum eHeldType
		{
			eBefore = 0,
			eNow = 1,
			eAfter = 2,
			NUM = 3,
		}

		[SerializeField]
		private ActionButton m_sceneBtn; // 0x14
		[SerializeField]
		private Text m_raidText; // 0x18
		[SerializeField]
		private Button m_btnHide; // 0x1C
		private AbsoluteLayout m_sceneButtonsAnim; // 0x20
		private AbsoluteLayout m_baseButtonAnim; // 0x24
		private AbsoluteLayout m_tblButtonAnim; // 0x28
		private AbsoluteLayout m_typeButtonAnim; // 0x2C
		private NKOBMDPHNGP_EventRaidLobby m_evnetLobby; // 0x30
		private int m_dayNum; // 0x34
		private bool m_is_show; // 0x38

		public ActionButton sceneBtn { get { return m_sceneBtn; } } //0x96C220
		public Button hideBtn { get { return m_btnHide; } } //0x96C228
		public Action onSceneClickButton { private get; set; } // 0x3C
		public Action onHideClickButton { private get; set; } // 0x40

		// RVA: 0x96C240 Offset: 0x96C240 VA: 0x96C240
		private void Update()
		{
			return;
		}

		//// RVA: 0x96C244 Offset: 0x96C244 VA: 0x96C244
		public bool IsPlaying()
		{
			return m_baseButtonAnim.IsPlayingChildren();
		}

		//// RVA: 0x968FC8 Offset: 0x968FC8 VA: 0x968FC8
		public void Show(bool isEnd/* = False*/)
		{
			m_baseButtonAnim.StartChildrenAnimGoStop(isEnd ? "st_in" : "go_in", "st_in");
			m_is_show = true;
			m_btnHide.targetGraphic.raycastTarget = true;
		}

		//// RVA: 0x967130 Offset: 0x967130 VA: 0x967130
		public void Hide(bool isEnd = false)
		{
			if(!m_is_show)
				return;
			m_baseButtonAnim.StartChildrenAnimGoStop(isEnd ? "st_out" : "go_out", "st_out");
			m_is_show = false;
			m_btnHide.targetGraphic.raycastTarget = false;
		}

		//// RVA: 0x966AA4 Offset: 0x966AA4 VA: 0x966AA4
		public void Wait()
		{
			m_baseButtonAnim.StartChildrenAnimGoStop("st_wait");
			m_is_show = false;
			m_btnHide.targetGraphic.raycastTarget = false;
		}

		//// RVA: 0x9691F8 Offset: 0x9691F8 VA: 0x9691F8
		public bool IsShow()
		{
			return m_is_show;
		}

		//// RVA: 0x966E98 Offset: 0x966E98 VA: 0x966E98
		public void SetType(HomeLobbyButtonController.Type a_type)
		{
			m_typeButtonAnim.StartChildrenAnimGoStop(a_type == HomeLobbyButtonController.Type.UP ? "02" : "01");
		}

		//// RVA: 0x968AF0 Offset: 0x968AF0 VA: 0x968AF0
		public void SetRaidBattleHeld(eHeldType _type)
		{
			if(_type == eHeldType.eAfter)
			{
				m_tblButtonAnim.StartAllAnimGoStop("03");
			}
			else if(_type == eHeldType.eNow)
			{
				m_tblButtonAnim.StartAllAnimGoStop("02");
			}
			else if(_type == eHeldType.eBefore)
			{
				m_tblButtonAnim.StartAllAnimGoStop("01");
			}
		}

		//// RVA: 0x968BD0 Offset: 0x968BD0 VA: 0x968BD0
		public void SetRaidBattleText(eHeldType _type, int _day)
		{
			m_dayNum = _day;
			StringBuilder str = new StringBuilder();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(_type == eHeldType.eAfter)
			{
				if(_day < 1)
					str.AppendFormat(bk.GetMessageByLabel("home_lobby_button_after_today"), Array.Empty<object>());
				else
					str.AppendFormat(bk.GetMessageByLabel("home_lobby_button_after"), m_dayNum);
			}
			else if(_type == eHeldType.eNow)
			{
				if(_day < 1)
					str.AppendFormat(bk.GetMessageByLabel("home_lobby_button_enter_today"), Array.Empty<object>());
				else
					str.AppendFormat(bk.GetMessageByLabel("home_lobby_button_enter"), m_dayNum);
			}
			else if(_type == eHeldType.eBefore)
			{
				if(_day < 1)
					str.AppendFormat(bk.GetMessageByLabel("home_lobby_button_before_today"), Array.Empty<object>());
				else
					str.AppendFormat(bk.GetMessageByLabel("home_lobby_button_before"), m_dayNum);
			}
			else
				return;
			m_raidText.text = str.ToString();
		}

		// RVA: 0x96C270 Offset: 0x96C270 VA: 0x96C270 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			if(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB != null)
			{
				m_evnetLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as NKOBMDPHNGP_EventRaidLobby;
			}
			m_baseButtonAnim = layout.FindViewById("sw_btn_all_anim") as AbsoluteLayout;
			m_sceneButtonsAnim = layout.FindViewById("sw_cmn_lobby_btn_anim") as AbsoluteLayout;
			m_tblButtonAnim = layout.FindViewById("swtbl_lobby_btn") as AbsoluteLayout;
			m_typeButtonAnim = layout.FindViewById("sw_btn_all") as AbsoluteLayout;
			m_sceneBtn.ClearOnClickCallback();
			m_sceneBtn.AddOnClickCallback(() =>
			{
				//0x96C748
				if (onSceneClickButton != null)
					onSceneClickButton();
			});
			m_btnHide.onClick.RemoveAllListeners();
			m_btnHide.onClick.AddListener(() =>
			{
				//0x96C75C
				if (onHideClickButton != null)
					onHideClickButton();
			});
			m_btnHide.targetGraphic.raycastTarget = false;
			Loaded();
			return true;
		}
	}
}
