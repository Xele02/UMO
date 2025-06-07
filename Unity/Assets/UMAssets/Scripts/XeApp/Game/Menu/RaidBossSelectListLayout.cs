using XeSys.Gfx;
using System;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class RaidBossSelectListLayout : LayoutUGUIScriptBase
	{
		[Serializable]
		public class BossPanel
		{
			public int panelIndex; // 0x8
			public bool isSp; // 0xC
			public Text nameText1; // 0x10
			public Text nameText2; // 0x14
			public Text timeText1; // 0x18
			public Text timeText2; // 0x1C
			public Text joinMemberText; // 0x20
			public RawImageEx playerIcon; // 0x24
			public RawImageEx musicRateImage1; // 0x28
			public RawImageEx musicRateImage2; // 0x2C
			public ActionButton attackButton; // 0x30
			public NumberBase hpNum1; // 0x34
			public NumberBase hpNum2; // 0x38
			public ButtonBase iconButton; // 0x3C
			public DivaIconDecoration divaDecoration = new DivaIconDecoration(); // 0x40
			private Func<long> remainTimeAct; // 0x44
			public List<RawImageEx> panelImageList; // 0x48
			public AbsoluteLayout winSwitchAnim1; // 0x4C
			public AbsoluteLayout winSwitchAnim2; // 0x50
			public AbsoluteLayout winSwitchAnim3; // 0x54
			public AbsoluteLayout spSwitchAnim1; // 0x58
			public AbsoluteLayout spSwitchAnim2; // 0x5C
			public AbsoluteLayout entryLampAnim1; // 0x60
			public AbsoluteLayout entryLampAnim2; // 0x64
			public AbsoluteLayout hpGaugeAnim1; // 0x68
			public AbsoluteLayout hpGaugeAnim2; // 0x6C
			public AbsoluteLayout rankAnim1; // 0x70
			public AbsoluteLayout rankAnim2; // 0x74
			public AbsoluteLayout spHpAnim1; // 0x78
			public AbsoluteLayout spHpAnim2; // 0x7C

			// // RVA: 0x1462A88 Offset: 0x1462A88 VA: 0x1462A88
			public void Hide()
			{
				for(int i = 0; i < panelImageList.Count; i++)
				{
					panelImageList[i].enabled = false;
				}
				attackButton.enabled = false;
				iconButton.enabled = false;
				SetPlayerName("");
				SetTime("");
				SetJoinMember("");
			}

			// // RVA: 0x1462C04 Offset: 0x1462C04 VA: 0x1462C04
			public void Show()
			{
				for(int i = 0; i < panelImageList.Count; i++)
				{
					panelImageList[i].enabled = true;
				}
				attackButton.enabled = true;
				iconButton.enabled = true;
			}

			// // RVA: 0x1463288 Offset: 0x1463288 VA: 0x1463288
			public void SetPlayerName(string name)
			{
				nameText1.text = name;
				nameText2.text = name;
			}

			// // RVA: 0x146339C Offset: 0x146339C VA: 0x146339C
			public void SetTime(long time)
			{
				if(time < 0)
					time = 0;
				int h = (int)time / 3600;
				time %= 3600;
				int m = (int)time / 60;
				time %= 60;
				int s = (int)time;
				timeText1.text = string.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
				timeText2.text = string.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
			}

			// // RVA: 0x14632F4 Offset: 0x14632F4 VA: 0x14632F4
			public void SetTime(string time)
			{
				timeText1.text = time;
				timeText2.text = time;
			}

			// // RVA: 0x14635D4 Offset: 0x14635D4 VA: 0x14635D4
			public void SetJoinMember(int num)
			{
				joinMemberText.text = string.Format(JpStringLiterals.StringLiteral_19851, num);
			}

			// // RVA: 0x1463360 Offset: 0x1463360 VA: 0x1463360
			public void SetJoinMember(string num)
			{
				joinMemberText.text = num;
			}

			// // RVA: 0x1463694 Offset: 0x1463694 VA: 0x1463694
			public void SetPlayerIcon(IBIGBMDANNM friendPlayerData)
			{
				EAJCBFGKKFA_FriendInfo f = new EAJCBFGKKFA_FriendInfo();
				f.KHEKNNFCAOI(friendPlayerData);
				GameManager.Instance.DivaIconCache.SetLoadingIcon(playerIcon);
				GameManager.Instance.DivaIconCache.Load(f.JIGONEMPPNP_Diva.AHHJLDLAPAN_DivaId, f.JIGONEMPPNP_Diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId,
					f.JIGONEMPPNP_Diva.EKFONBFDAAP_ColorId, (IiconTexture icon) =>
					{
						//0x1464208
						icon.Set(playerIcon);
					});
			}

			// // RVA: 0x14638D0 Offset: 0x14638D0 VA: 0x14638D0
			public void SetPlayerIconDeco(IBIGBMDANNM playerData)
			{
				EAJCBFGKKFA_FriendInfo f = new EAJCBFGKKFA_FriendInfo();
				f.KHEKNNFCAOI(playerData);
				divaDecoration.Change(f.JIGONEMPPNP_Diva, f, DisplayType.Level, f.AFBMEMCHJCL_MainScene);
			}

			// // RVA: 0x14639D4 Offset: 0x14639D4 VA: 0x14639D4
			public void SetRate(int grade)
			{
				if(grade == 0)
				{
					Debug.LogError("StringLiteral_19852");
					return;
				}
				HighScoreRatingRank.Type rank = (HighScoreRatingRank.Type)grade;
				GameManager.Instance.MusicRatioTextureCache.Load(rank, (IiconTexture texture) =>
				{
					//0x14642E8
					MusicRatioTextureCache.MusicRatioTexture t = texture as MusicRatioTextureCache.MusicRatioTexture;
					if(t != null)
					{
						t.Set(musicRateImage1, rank);
						t.Set(musicRateImage2, rank);
					}
				});
			}

			// // RVA: 0x1463BB4 Offset: 0x1463BB4 VA: 0x1463BB4
			public void SetSp(bool isSp)
			{
				this.isSp = isSp;
				if(isSp)
				{
					spSwitchAnim1.StartChildrenAnimGoStop("01", "01");
					spSwitchAnim2.StartChildrenAnimGoStop("01", "01");
					winSwitchAnim1.StartChildrenAnimGoStop("02", "02");
					winSwitchAnim2.StartChildrenAnimGoStop("02", "02");
					winSwitchAnim3.StartChildrenAnimGoStop("02", "02");
					spHpAnim1.StartChildrenAnimGoStop("02", "02");
					spHpAnim2.StartChildrenAnimGoStop("02", "02");
				}
				else
				{
					spSwitchAnim1.StartChildrenAnimGoStop("02", "02");
					spSwitchAnim2.StartChildrenAnimGoStop("02", "02");
					winSwitchAnim1.StartChildrenAnimGoStop("01", "01");
					winSwitchAnim2.StartChildrenAnimGoStop("01", "01");
					winSwitchAnim3.StartChildrenAnimGoStop("01", "01");
					spHpAnim1.StartChildrenAnimGoStop("01", "01");
					spHpAnim2.StartChildrenAnimGoStop("01", "01");
				}
			}

			// // RVA: 0x1463EC4 Offset: 0x1463EC4 VA: 0x1463EC4
			public void SetEntry(bool isEntry)
			{
				if(isEntry)
				{
					entryLampAnim1.StartChildrenAnimGoStop("02", "02");
					entryLampAnim2.StartChildrenAnimGoStop("02", "02");
				}
				else
				{
					entryLampAnim1.StartChildrenAnimGoStop("01", "01");
					entryLampAnim2.StartChildrenAnimGoStop("01", "01");
				}
			}

			// // RVA: 0x1463FC8 Offset: 0x1463FC8 VA: 0x1463FC8
			public void SetGauge(int val)
			{
				hpGaugeAnim1.StartAllAnimGoStop(val, val);
				hpGaugeAnim2.StartAllAnimGoStop(val, val);
			}

			// // RVA: 0x146402C Offset: 0x146402C VA: 0x146402C
			public void SetRank(int rank)
			{
				string label = string.Format("{0:D2}", rank);
				rankAnim1.StartChildrenAnimGoStop(label, label);
				rankAnim2.StartChildrenAnimGoStop(label, label);
			}

			// // RVA: 0x1464110 Offset: 0x1464110 VA: 0x1464110
			public void SetHp(int hp)
			{
				hpNum1.SetNumber(hp, 0);
				hpNum2.SetNumber(hp, 0);
			}

			// // RVA: 0x1464184 Offset: 0x1464184 VA: 0x1464184
			public void SetRemainTimeAct(Func<long> func)
			{
				remainTimeAct = func;
			}

			// // RVA: 0x1461478 Offset: 0x1461478 VA: 0x1461478
			public void UpdateRemainTime()
			{
				if(attackButton.enabled && remainTimeAct != null)
				{
					SetTime(remainTimeAct());
				}
			}
		}

		public class BossPanelController
		{
			private BossPanel panel; // 0x8

			// RVA: 0x1462A68 Offset: 0x1462A68 VA: 0x1462A68
			public BossPanelController(BossPanel _)
			{
				panel = _;
			}

			// // RVA: 0x1464400 Offset: 0x1464400 VA: 0x1464400
			public void SetPlayerName(string name)
			{
				panel.SetPlayerName(name);
			}

			// // RVA: 0x1464430 Offset: 0x1464430 VA: 0x1464430
			public void SetTime(long time)
			{
				panel.SetTime(time);
			}

			// // RVA: 0x1464470 Offset: 0x1464470 VA: 0x1464470
			public void SetJoinMember(int num)
			{
				panel.SetJoinMember(num);
			}

			// // RVA: 0x14644A0 Offset: 0x14644A0 VA: 0x14644A0
			public void SetPlayerIcon(IBIGBMDANNM friendPlayerData)
			{
				panel.SetPlayerIcon(friendPlayerData);
			}

			// // RVA: 0x14644D0 Offset: 0x14644D0 VA: 0x14644D0
			public void SetPlayerIconDeco(IBIGBMDANNM playerData)
			{
				panel.SetPlayerIconDeco(playerData);
			}

			// // RVA: 0x1464500 Offset: 0x1464500 VA: 0x1464500
			public void SetRate(int grade)
			{
				panel.SetRate(grade);
			}

			// // RVA: 0x1464530 Offset: 0x1464530 VA: 0x1464530
			public void SetSp(bool isSp)
			{
				panel.SetSp(isSp);
			}

			// // RVA: 0x1464560 Offset: 0x1464560 VA: 0x1464560
			public void SetEntry(bool isEntry)
			{
				panel.SetEntry(isEntry);
			}

			// // RVA: 0x1464590 Offset: 0x1464590 VA: 0x1464590
			public void SetGauge(int val)
			{
				panel.SetGauge(val);
			}

			// // RVA: 0x14645C0 Offset: 0x14645C0 VA: 0x14645C0
			public void SetRank(int rank)
			{
				panel.SetRank(rank);
			}

			// // RVA: 0x14645F0 Offset: 0x14645F0 VA: 0x14645F0
			public void SetHp(int hp)
			{
				panel.SetHp(hp);
			}

			// // RVA: 0x1464620 Offset: 0x1464620 VA: 0x1464620
			public void SetRemainTimeAct(Func<long> func)
			{
				panel.SetRemainTimeAct(func);
			}
		}

		public UnityAction<int, BossPanelController> UpdatePanelListner; // 0x14
		public UnityAction ScrollStartListner; // 0x18
		public UnityAction<int> ScrollEndListner; // 0x1C
		public UnityAction<int> PushAttackButtonListner; // 0x20
		public UnityAction<int> PushProfileButtonListner; // 0x24
		public UnityAction<int> OnClickFlowButton; // 0x28
		[SerializeField]
		private List<BossPanel> m_bossPanelList; // 0x2C
		[SerializeField]
		private RaidBossSelectReelScroller m_scroller; // 0x30
		[SerializeField]
		private RawImageEx topArrow; // 0x34
		[SerializeField]
		private RawImageEx bottonArrow; // 0x38
		private static readonly int[] m_orderdActionIndex = new int[6]
		{
			3, 4, 5, 0, 1, 2
		}; // 0x0
		private bool m_isShow; // 0x3C
		private bool m_isShowCannon; // 0x3D
		private AbsoluteLayout m_centerPanel1; // 0x40
		private AbsoluteLayout m_centerPanel2; // 0x44
		private AbsoluteLayout m_bossSelectAnim; // 0x48
		private int m_currentIndex; // 0x4C
		private int m_currentBossNum; // 0x50
		private bool m_isShowEffect; // 0x54
		private float m_elapsedTime; // 0x58

		// private bool scrollIsClamp { get; } 0x1460624
		public int CurrentIndex { get { return m_currentIndex; } } //0x146066C
		// public bool CheckTopLimit { get; } 0x1460674
		// public bool CheckBottomLimit { get; } 0x1460688

		// // RVA: 0x146064C Offset: 0x146064C VA: 0x146064C
		// protected bool IsRangeOver(int index) { }

		// RVA: 0x14606A4 Offset: 0x14606A4 VA: 0x14606A4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_isShowEffect = false;
			m_isShow = true;
			m_isShowCannon = true;
			m_bossSelectAnim = layout.FindViewByExId("sw_sel_music_raid_boss_select_cr_anim_sw_raid_list_swipe_anim") as AbsoluteLayout;
			m_centerPanel1 = layout.FindViewByExId("sw_raid_list_swipe_anim_front") as AbsoluteLayout;
			m_centerPanel2 = layout.FindViewByExId("sw_raid_list_swipe_anim_back") as AbsoluteLayout;
			SetAbsoluteLayouts(0, m_bossPanelList[0], "sw_raid_list_swipe_anim_front", layout);
			SetAbsoluteLayouts(0, m_bossPanelList[1], "sw_raid_list_swipe_anim_back", layout);
			SetAbsoluteLayouts(1, m_bossPanelList[2], "sw_raid_list_swipe_anim_05", layout);
			SetAbsoluteLayouts(2, m_bossPanelList[3], "sw_raid_list_swipe_anim_08", layout);
			SetAbsoluteLayouts(3, m_bossPanelList[4], "sw_raid_list_swipe_anim_00", layout);
			SetAbsoluteLayouts(4, m_bossPanelList[5], "sw_raid_list_swipe_anim_02", layout);
			SetAbsoluteLayouts(5, m_bossPanelList[6], "sw_raid_list_swipe_anim_03", layout);
			m_bossPanelList[0].attackButton.AddOnClickCallback(() =>
			{
				//0x1463158
				OnPushAttackButton(m_currentIndex);
			});
			m_bossPanelList[0].iconButton.AddOnClickCallback(() =>
			{
				//0x1463160
				OnPushProfileButton(m_currentIndex);
			});
			m_elapsedTime = 0;
			return true;
		}

		// RVA: 0x14612E4 Offset: 0x14612E4 VA: 0x14612E4
		private void Update()
		{
			if(m_currentIndex < 1 || m_currentBossNum - 1 <= m_currentIndex)
				UpdateScrollArrow();
			m_elapsedTime += Time.deltaTime;
			if(m_elapsedTime >= 1)
			{
				m_elapsedTime = m_elapsedTime % 1;
				if(m_currentBossNum != 0)
				{
					for(int i = 0; i < m_bossPanelList.Count; i++)
					{
						m_bossPanelList[i].UpdateRemainTime();
					}
				}
			}
		}

		// // RVA: 0x1460BEC Offset: 0x1460BEC VA: 0x1460BEC
		private void SetAbsoluteLayouts(int panelIndex, BossPanel panel, string parentExId, Layout layout)
		{
			panel.panelIndex = panelIndex;
			AbsoluteLayout l = layout.FindViewByExId(parentExId) as AbsoluteLayout;
			panel.winSwitchAnim1 = l.FindViewByExId("sw_raid_list_cont_list_win_set_b") as AbsoluteLayout;
			panel.winSwitchAnim2 = l.FindViewByExId("sw_raid_list_cont_list_win_set_c") as AbsoluteLayout;
			panel.winSwitchAnim3 = l.FindViewByExId("sw_raid_list_cont_list_win_set_t") as AbsoluteLayout;
			panel.spSwitchAnim1 = l.FindViewByExId("sw_raid_list_close_sw_raid_boss_sp") as AbsoluteLayout;
			panel.spSwitchAnim2 = l.FindViewByExId("sw_raid_list_open_sw_raid_boss_sp") as AbsoluteLayout;
			panel.entryLampAnim1 = l.FindViewByExId("sw_raid_list_close_sw_list_join") as AbsoluteLayout;
			panel.entryLampAnim2 = l.FindViewByExId("sw_raid_list_open_sw_list_join") as AbsoluteLayout;
			panel.spHpAnim1 = l.FindViewByExId("sw_raid_list_close_sw_raid_boss_bar_set") as AbsoluteLayout;
			panel.spHpAnim2 = l.FindViewByExId("sw_raid_list_open_sw_raid_boss_bar_set") as AbsoluteLayout;
			panel.rankAnim1 = l.FindViewByExId("sw_raid_b_r_icon_min_sw_raid_boss_rank") as AbsoluteLayout;
			panel.rankAnim2 = l.FindViewByExId("sw_raid_b_r_icon_sw_raid_boss_rank") as AbsoluteLayout;
			panel.hpGaugeAnim1 = panel.spHpAnim1.FindViewByExId("sw_raid_boss_bar_set_sw_boss_bar_anim") as AbsoluteLayout;
			panel.hpGaugeAnim2 = panel.spHpAnim2.FindViewByExId("sw_raid_boss_bar_set_sw_boss_bar_anim") as AbsoluteLayout;
		}

		// // RVA: 0x1461524 Offset: 0x1461524 VA: 0x1461524
		public void Initialize()
		{
			m_scroller.onSelectionChanged = OnSelectionChanged;
			m_scroller.onScrollRepeated = OnScrollRepeated;
			m_scroller.onScrollStarted = OnScrollStarted;
			m_scroller.onScrollUpdated = OnScrollUpdated;
			m_scroller.onScrollEnded = OnScrollEnded;
			m_currentIndex = 0;
			InitPanel(0, -1);
		}

		// // RVA: 0x146180C Offset: 0x146180C VA: 0x146180C
		public void InitializeDecoration()
		{
			for(int i = 0; i < m_bossPanelList.Count; i++)
			{
				m_bossPanelList[i].divaDecoration.Initialize(m_bossPanelList[i].playerIcon.gameObject, DivaIconDecoration.Size.S, true, true, null, null);
			}
		}

		// // RVA: 0x1461990 Offset: 0x1461990 VA: 0x1461990
		// public void Show() { }

		// // RVA: 0x1461A18 Offset: 0x1461A18 VA: 0x1461A18
		public void Hide()
		{
			m_isShow = false;
			m_bossSelectAnim.StartSiblingAnimGoStop("st_out", "st_out");
		}

		// // RVA: 0x1461AA0 Offset: 0x1461AA0 VA: 0x1461AA0
		public void Enter()
		{
			if(!m_isShow)
			{
				OpenPanel(true);
				m_bossSelectAnim.StartSiblingAnimGoStop("go_in", "st_in");
			}
			m_isShow = true;
		}

		// // RVA: 0x1461D28 Offset: 0x1461D28 VA: 0x1461D28
		public void Leave()
		{
			if(m_isShow)
			{
				m_bossSelectAnim.StartSiblingAnimGoStop("go_out", "st_out");
			}
			m_isShow = false;
		}

		// // RVA: 0x1461DC8 Offset: 0x1461DC8 VA: 0x1461DC8
		public bool IsPlaying()
		{
			return m_bossSelectAnim.IsPlayingSibling();
		}

		// // RVA: 0x1461DF4 Offset: 0x1461DF4 VA: 0x1461DF4
		// public void RequestLeftFlow(int pageOffset, float flowSec, Action onEnd) { }

		// // RVA: 0x1461F18 Offset: 0x1461F18 VA: 0x1461F18
		// public void RequestRightFlow(int pageOffset, float flowSec, Action onEnd) { }

		// // RVA: 0x1461F60 Offset: 0x1461F60 VA: 0x1461F60
		public void InputEnable()
		{
			m_scroller.InputEnable();
		}

		// // RVA: 0x1461F94 Offset: 0x1461F94 VA: 0x1461F94
		public void InputDisable()
		{
			m_scroller.InputDisable();
		}

		// // RVA: 0x1461FC8 Offset: 0x1461FC8 VA: 0x1461FC8
		private void OnSelectionChanged(int offset)
		{
			if(m_currentBossNum == 0)
				return;
			m_currentIndex += offset;
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_SNS_002);
			UpdateScrollArrow();
		}

		// // RVA: 0x1462044 Offset: 0x1462044 VA: 0x1462044
		public void OnScrollRepeated(int repeatDelta, bool isSelectionFlipped)
		{
			int end = 2;
			int start = -3;
			if(isSelectionFlipped)
			{
				end = 3;
				start = -2;
			}
			for(int i = 0; start + i <= end; i++)
			{
				int off = start + i;
				int val = off + m_currentIndex;
				if(val < 0 || val >= m_currentBossNum)
					HidePanel(i);
				else
				{
					int v = XeSys.Math.Repeat(val, 0, m_currentBossNum - 1);
					UpdatePanel(m_orderdActionIndex[i], v);
					ShowPanel(i);
				}
			}
		}

		// // RVA: 0x1462608 Offset: 0x1462608 VA: 0x1462608
		public void OnScrollStarted(bool isAuto)
		{
			if(m_currentBossNum > 1)
				ClosePanel();
			if(ScrollStartListner != null)
				ScrollStartListner();
		}

		// // RVA: 0x14626F0 Offset: 0x14626F0 VA: 0x14626F0
		public void OnScrollUpdated(bool isAuto)
		{
			return;
		}

		// // RVA: 0x14626F4 Offset: 0x14626F4 VA: 0x14626F4
		public void OnScrollEnded(bool isAuto)
		{
			OpenPanel(false);
			SetScrollLimit(-m_currentIndex, m_currentBossNum + ~m_currentIndex);
			if(ScrollEndListner != null)
				ScrollEndListner(m_currentIndex);
		}

		// // RVA: 0x14627A4 Offset: 0x14627A4 VA: 0x14627A4
		// private void PlayFocusAnim(int offset = 1) { }

		// // RVA: 0x14627A8 Offset: 0x14627A8 VA: 0x14627A8
		// private void UpdateFocusAnim(bool isSelectionFlipped) { }

		// // RVA: 0x14627AC Offset: 0x14627AC VA: 0x14627AC
		public void SetScrollLimit(int leftLimitPage, int rightLimitPage)
		{
			m_scroller.SetLimit(rightLimitPage, leftLimitPage);
		}

		// // RVA: 0x1462850 Offset: 0x1462850 VA: 0x1462850
		// public void ClearScrollLimit() { }

		// // RVA: 0x146289C Offset: 0x146289C VA: 0x146289C
		public void SetTopArrowVisible(bool isVisible)
		{
			topArrow.enabled = isVisible;
		}

		// // RVA: 0x14628D0 Offset: 0x14628D0 VA: 0x14628D0
		public void SetBottomArrowVisible(bool isVisible)
		{
			bottonArrow.enabled = isVisible;
		}

		// // RVA: 0x1461764 Offset: 0x1461764 VA: 0x1461764
		public void InitPanel(int bossNum, int myBossIndex)
		{
			if(myBossIndex < 0)
				myBossIndex = 0;
			m_currentIndex = myBossIndex;
			m_currentBossNum = bossNum;
			UpdatePanels();
			SetScrollLimit(-m_currentIndex, m_currentBossNum + ~m_currentIndex);
			if(m_currentIndex < 1 || m_currentBossNum - 1 <= m_currentIndex)
				UpdateScrollArrow();
			else
			{
				SetTopArrowVisible(true);
				SetBottomArrowVisible(true);
			}
			m_scroller.SetLock(m_currentBossNum < 2);
		}

		// // RVA: 0x1462904 Offset: 0x1462904 VA: 0x1462904
		private void UpdatePanels()
		{
			if(m_currentBossNum != 0)
			{
				for(int i = 0; i < 6; i++)
				{
					int val = i + m_currentIndex - 3;
					if(val < 0 || val >= m_currentBossNum)
						HidePanel(i);
					else
					{
						int v = XeSys.Math.Repeat(val, 0, m_currentBossNum - 1);
						UpdatePanel(m_orderdActionIndex[i], v);
						ShowPanel(i);
					}
				}
			}
		}

		// // RVA: 0x1462308 Offset: 0x1462308 VA: 0x1462308
		private void UpdatePanel(int panelIndex, int bossIndex)
		{
			if(UpdatePanelListner != null)
			{
				for(int i = 0; i < m_bossPanelList.Count; i++)
				{
					if(m_bossPanelList[i].panelIndex == panelIndex)
					{
						UpdatePanelListner(bossIndex, new BossPanelController(m_bossPanelList[i]));
					}
				}
			}
		}

		// // RVA: 0x14621AC Offset: 0x14621AC VA: 0x14621AC
		public void HidePanel(int order)
		{
			for(int i = 0; i < m_bossPanelList.Count; i++)
			{
				if(m_bossPanelList[i].panelIndex == m_orderdActionIndex[order])
				{
					m_bossPanelList[i].Hide();
				}
			}
		}

		// // RVA: 0x14624AC Offset: 0x14624AC VA: 0x14624AC
		public void ShowPanel(int order)
		{
			for(int i = 0; i < m_bossPanelList.Count; i++)
			{
				if(m_bossPanelList[i].panelIndex == m_orderdActionIndex[order])
				{
					m_bossPanelList[i].Show();
				}
			}
		}

		// // RVA: 0x1462D2C Offset: 0x1462D2C VA: 0x1462D2C
		public void SetPanelEffect(bool isShow)
		{
			m_isShowEffect = isShow;
			if(isShow)
			{
				m_centerPanel1.StartChildrenAnimGoStop("st_stop", "st_stop");
				m_centerPanel2.StartChildrenAnimGoStop("st_stop", "st_stop");
			}
			else
			{
				m_centerPanel1.StartChildrenAnimGoStop("st_in", "st_in");
				m_centerPanel2.StartChildrenAnimGoStop("st_in", "st_in");
			}
		}

		// // RVA: 0x1461B4C Offset: 0x1461B4C VA: 0x1461B4C
		private void OpenPanel(bool isSkipAnim/* = False*/)
		{
			if(!m_isShowEffect)
			{
				if(!isSkipAnim)
				{
					m_centerPanel1.StartChildrenAnimGoStop("go_in", "st_in");
					m_centerPanel2.StartChildrenAnimGoStop("go_in", "st_in");
				}
				else
				{
					m_centerPanel1.StartChildrenAnimGoStop("st_in", "st_in");
					m_centerPanel2.StartChildrenAnimGoStop("st_in", "st_in");
				}
			}
			else
			{
				if(!isSkipAnim)
				{
					m_centerPanel1.StartChildrenAnimGoStop("go_in", "st_stop");
					m_centerPanel2.StartChildrenAnimGoStop("go_in", "st_stop");
				}
				else
				{
					m_centerPanel1.StartChildrenAnimGoStop("st_stop", "st_stop");
					m_centerPanel2.StartChildrenAnimGoStop("st_stop", "st_stop");
				}
			}
		}

		// // RVA: 0x146263C Offset: 0x146263C VA: 0x146263C
		private void ClosePanel()
		{
			m_centerPanel1.StartChildrenAnimGoStop("st_out", "st_out");
			m_centerPanel2.StartChildrenAnimGoStop("st_out", "st_out");
		}

		// // RVA: 0x146278C Offset: 0x146278C VA: 0x146278C
		// public void UpdateScrollLimit() { }

		// // RVA: 0x1462A3C Offset: 0x1462A3C VA: 0x1462A3C
		// public void ShowScrollArrow() { }

		// // RVA: 0x146142C Offset: 0x146142C VA: 0x146142C
		public void UpdateScrollArrow()
		{
			SetTopArrowVisible(m_currentIndex > 0);
			SetBottomArrowVisible(m_currentIndex < m_currentBossNum - 1);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x711FF4 Offset: 0x711FF4 VA: 0x711FF4
		// // RVA: 0x1462E34 Offset: 0x1462E34 VA: 0x1462E34
		// private IEnumerator AfterOpenPanel() { }

		// // RVA: 0x1462EE0 Offset: 0x1462EE0 VA: 0x1462EE0
		private void OnPushAttackButton(int index)
		{
			if(PushAttackButtonListner != null)
				PushAttackButtonListner(index);
		}

		// // RVA: 0x1462F54 Offset: 0x1462F54 VA: 0x1462F54
		private void OnPushProfileButton(int index)
		{
			if(PushProfileButtonListner != null)
				PushProfileButtonListner(index);
		}

		// // RVA: 0x1462FC8 Offset: 0x1462FC8 VA: 0x1462FC8
		public void Release()
		{
			for(int i = 0; i < m_bossPanelList.Count; i++)
			{
				m_bossPanelList[i].divaDecoration.Release();
			}
		}
	}
}
