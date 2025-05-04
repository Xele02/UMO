using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LobbyFooterTransButtonLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6713C8 Offset: 0x6713C8 VA: 0x6713C8
		private ActionButton m_preRaidButton; // 0x14
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x67142C Offset: 0x67142C VA: 0x67142C
		private ActionButton m_RaidButton; // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x671488 Offset: 0x671488 VA: 0x671488
		private ActionButton m_missionButton; // 0x1C
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6714E4 Offset: 0x6714E4 VA: 0x6714E4
		private ActionButton m_cannonGaugeButton; // 0x20
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x671548 Offset: 0x671548 VA: 0x671548
		private NumberBase m_foldRadarNum; // 0x24
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6715B0 Offset: 0x6715B0 VA: 0x6715B0
		private Text m_dayText; // 0x28
		//[HeaderAttribute] // RVA: 0x671614 Offset: 0x671614 VA: 0x671614
		[SerializeField]
		private Text m_BossContText; // 0x2C
		private AbsoluteLayout m_footerRaidBtnAnim; // 0x40
		private AbsoluteLayout m_root; // 0x44
		private AbsoluteLayout m_missionBadge; // 0x48
		private AbsoluteLayout m_raidBadge; // 0x4C
		private AbsoluteLayout m_foldRadarAnim; // 0x50
		private AbsoluteLayout m_cannonStockNumAnim; // 0x54
		private AbsoluteLayout m_raidBtnLoopAnim; // 0x58
		private AbsoluteLayout m_raidBassNumAnim; // 0x5C

		public Action onPreRaidClickButton { get; set; } // 0x30
		public Action onMissionClickButton { get; set; } // 0x34
		public Action onRaideClickButton { get; set; } // 0x38
		public Action onMcGaugeClickButton { get; set; } // 0x3C

		// RVA: 0x1285DC0 Offset: 0x1285DC0 VA: 0x1285DC0
		private void Start()
		{
			return;
		}

		// RVA: 0x1285DC4 Offset: 0x1285DC4 VA: 0x1285DC4
		private void Update()
		{
			return;
		}

		// // RVA: 0x1285DC8 Offset: 0x1285DC8 VA: 0x1285DC8
		// public void SetRaidButtonEnable() { }

		// // RVA: 0x1285E7C Offset: 0x1285E7C VA: 0x1285E7C
		public void FooterPhaseInit(NKOBMDPHNGP_EventRaidLobby evCont)
		{
			SetRaidBossSwitchButtonAnimation(evCont.CHDNDNMHJHI_GetPhase());
		}

		// // RVA: 0x1286098 Offset: 0x1286098 VA: 0x1286098
		public void SetFoldRadar(int num)
		{
			m_foldRadarNum.SetNumber(num, 0);
		}

		// // RVA: 0x12860D8 Offset: 0x12860D8 VA: 0x12860D8
		public void SetDayText(int day)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(day < 1)
				m_dayText.text = bk.GetMessageByLabel("lobby_raid_befor_today_text");
			else
				m_dayText.text = string.Format(bk.GetMessageByLabel("lobby_raid_befor_today_text"), day);
		}

		// // RVA: 0x128622C Offset: 0x128622C VA: 0x128622C
		public void SetFotterMisionNewIcon(bool _isEnable)
		{
			m_missionBadge.StartChildrenAnimGoStop(_isEnable ? "01" : "02");
		}

		// // RVA: 0x12862C0 Offset: 0x12862C0 VA: 0x12862C0
		public void SetFotterRaidNewIcon(bool _isEnable)
		{
			m_raidBadge.StartChildrenAnimGoStop(_isEnable ? "01" : "02");
		}

		// // RVA: 0x1286354 Offset: 0x1286354 VA: 0x1286354
		public void SetEableBossNumText(int _bossNum)
		{
			if(_bossNum < 1)
			{
				m_raidBassNumAnim.StartChildrenAnimGoStop("02");
			}
			else
			{
				m_BossContText.text = string.Format(MessageManager.Instance.GetMessage("menu", "lobby_raidboss_enable_count"), _bossNum);
				m_raidBassNumAnim.StartChildrenAnimGoStop("01");
			}
		}

		// // RVA: 0x1285EB8 Offset: 0x1285EB8 VA: 0x1285EB8
		public void SetRaidBossSwitchButtonAnimation(NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase _type)
		{
			if(_type == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End)
			{
				m_preRaidButton.Hidden = true;
				m_RaidButton.Hidden = true;
				m_missionButton.Hidden = true;
				m_cannonGaugeButton.Hidden = true;
				m_footerRaidBtnAnim.StartChildrenAnimGoStop("02");
				m_foldRadarAnim.StartChildrenAnimGoStop("02");
			}
			else if(_type == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now)
			{
				m_footerRaidBtnAnim.StartChildrenAnimGoStop("02");
				m_raidBtnLoopAnim.StartChildrenAnimLoop("lo_");
			}
			else if(_type == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.KJNKFFJBPIH_1_Before)
			{
				m_footerRaidBtnAnim.StartChildrenAnimGoStop("01");
			}
		}

		// // RVA: 0x12864D0 Offset: 0x12864D0 VA: 0x12864D0
		public void Enter()
		{
			m_root.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x1286550 Offset: 0x1286550 VA: 0x1286550
		public void Leave()
		{
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x12865D0 Offset: 0x12865D0 VA: 0x12865D0
		public void Hide()
		{
			m_root.StartChildrenAnimGoStop("st_wait");
		}

		// // RVA: 0x1286640 Offset: 0x1286640 VA: 0x1286640
		public void SetCannonStock(int num)
		{
			m_cannonStockNumAnim.StartChildrenAnimGoStop(string.Format("{0:D2}", num + 1));
		}

		// // RVA: 0x12866FC Offset: 0x12866FC VA: 0x12866FC
		public bool IsPlayingChild()
		{
			return m_root.IsPlayingChildren();
		}

		// RVA: 0x1286728 Offset: 0x1286728 VA: 0x1286728 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.FindViewByExId("root_sel_lobby_btn_01_sw_lb_btn_anim_01") as AbsoluteLayout;
			m_root.StartChildrenAnimGoStop("st_wait");
			m_footerRaidBtnAnim = layout.FindViewByExId("sw_lb_btn_anim_01_swtbl_lb_raid_btn") as AbsoluteLayout;
			m_missionBadge = layout.FindViewByExId("sw_lb_mi_btn_01_cmn_head_icon_new") as AbsoluteLayout;
			m_raidBadge = layout.FindViewByExId("sw_lb_raid_btn_01_cmn_head_icon_new") as AbsoluteLayout;
			m_foldRadarAnim = layout.FindViewByExId("swtbl_lb_raid_btn_lb_frm_fr_01") as AbsoluteLayout;
			m_cannonStockNumAnim = layout.FindViewByExId("sw_lb_btn_mcc_01_swtbl_lb_mcc_01") as AbsoluteLayout;
			m_raidBtnLoopAnim = layout.FindViewByExId("sw_lb_raid_btn_01_sw_lb_btn_raid_ef_01") as AbsoluteLayout;
			m_raidBassNumAnim = layout.FindViewByExId("sw_lb_raid_btn_01_lb_raid_frm_01") as AbsoluteLayout;
			m_raidBassNumAnim.StartChildrenAnimGoStop("02");
			m_preRaidButton.ClearOnClickCallback();
			m_preRaidButton.AddOnClickCallback(() =>
			{
				//0x1286D98
				if(m_preRaidButton != null)
					onPreRaidClickButton();
			});
			m_missionButton.ClearOnClickCallback();
			m_missionButton.AddOnClickCallback(() =>
			{
				//0x1286E4C
				if(m_missionButton != null)
					onMissionClickButton();
			});
			m_RaidButton.ClearOnClickCallback();
			m_RaidButton.AddOnClickCallback(() =>
			{
				//0x1286F00
				if(m_RaidButton != null)
					onRaideClickButton();
			});
			m_cannonGaugeButton.ClearOnClickCallback();
			m_cannonGaugeButton.AddOnClickCallback(() =>
			{
				//0x1286FB4
				if(m_cannonGaugeButton != null)
					onMcGaugeClickButton();
			});
			Loaded();
			return true;
		}
	}
}
