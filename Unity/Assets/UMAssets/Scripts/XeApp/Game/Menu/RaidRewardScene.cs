using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidRewardArgs : TransitionArgs
	{
		public List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ> bossInfoList; // 0x8
		public TransitionUniqueId returnUniqueId; // 0xC

		// RVA: 0x1816168 Offset: 0x1816168 VA: 0x1816168
		public RaidRewardArgs(TransitionUniqueId uniqueId, List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ> _bossInfoList)
		{
			bossInfoList = _bossInfoList;
			returnUniqueId = uniqueId;
		}
	}

	public class RaidRewardScene : TransitionRoot
	{
		private RaidResultBossFilterLayout raidResultBossFilter; // 0x48
		private RaidResultCannonLayoutController raidResultCannonLayoutController; // 0x4C
		private RaidResultRewardLayoutController raidResultRewardLayoutController; // 0x50
		private List<RaidResultRewardLayoutController.InitParam> initParamList; // 0x54
		private int currentParamIndex; // 0x58
		private bool m_initialize; // 0x5C
		private TransitionUniqueId m_returnUniqueId; // 0x60
		private List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ> m_bossInfoList; // 0x64

		// RVA: 0x1816190 Offset: 0x1816190 VA: 0x1816190 Slot: 5
		protected override void Start()
		{
			this.StartCoroutineWatched(Co_LoadLayout());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7151B4 Offset: 0x7151B4 VA: 0x7151B4
		// // RVA: 0x18161B4 Offset: 0x18161B4 VA: 0x18161B4
		private IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x14
			FontInfo fontInfo; // 0x18
			AssetBundleLoadLayoutOperationBase lytAssetOp; // 0x1C

			//0x18196C8
			bundleName = new StringBuilder();
			fontInfo = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/204.xab");
			lytAssetOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_RaidResultCannonDamage");
			yield return lytAssetOp;
			yield return Co.R(lytAssetOp.InitializeLayoutCoroutine(fontInfo, (GameObject instance) =>
			{
				//0x1816F88
				instance.transform.SetParent(transform, false);
				raidResultCannonLayoutController = instance.GetComponent<RaidResultCannonLayoutController>();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			lytAssetOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_RaidResultReward");
			yield return lytAssetOp;
			yield return Co.R(lytAssetOp.InitializeLayoutCoroutine(fontInfo, (GameObject instance) =>
			{
				//0x1817058
				instance.transform.SetParent(transform, false);
				raidResultRewardLayoutController = instance.GetComponent<RaidResultRewardLayoutController>();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71522C Offset: 0x71522C VA: 0x71522C
		// // RVA: 0x1816260 Offset: 0x1816260 VA: 0x1816260
		private IEnumerator Co_LoadFilterLayout()
		{
			StringBuilder bundleName; // 0x14
			FontInfo fontInfo; // 0x18
			AssetBundleLoadLayoutOperationBase lytAssetOp; // 0x1C

			//0x1819350
			bundleName = new StringBuilder();
			fontInfo = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/204.xab");
			lytAssetOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_g_r_d_filter_layout_root");
			yield return lytAssetOp;
			yield return Co.R(lytAssetOp.InitializeLayoutCoroutine(fontInfo, (GameObject instance) =>
			{
				//0x1817128
				instance.transform.SetParent(transform, false);
				raidResultBossFilter = instance.GetComponent<RaidResultBossFilterLayout>();
				raidResultBossFilter.gameObject.transform.SetAsFirstSibling();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7152A4 Offset: 0x7152A4 VA: 0x7152A4
		// // RVA: 0x181630C Offset: 0x181630C VA: 0x181630C
		private IEnumerator Co_SetBossBg(int imageType)
		{
			//0x181A6D8
			yield return Co.R(MenuScene.Instance.BgControl.ChangeBgCoroutine(BgType.Raid, imageType, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71531C Offset: 0x71531C VA: 0x71531C
		// // RVA: 0x18163B8 Offset: 0x18163B8 VA: 0x18163B8
		private IEnumerator Co_Initialize()
		{
			RaidRewardArgs args; // 0x18

			//0x1818740
			args = Args as RaidRewardArgs;
			if(args == null)
			{
				m_returnUniqueId = TransitionUniqueId.HOME_RAID;
				m_bossInfoList = null;
			}
			else
			{
				m_returnUniqueId = args.returnUniqueId;
				m_bossInfoList = args.bossInfoList;
			}
			if(args != null && m_bossInfoList != null)
			{
				yield return this.StartCoroutineWatched(Co_LoadFilterLayout());
				raidResultBossFilter.SetFilter(RaidResultBossFilterLayout.FilterType.Red);
				raidResultCannonLayoutController.gameObject.SetActive(false);
				this.StartCoroutineWatched(InitRaidRewardResult(args.bossInfoList));
				yield return this.StartCoroutineWatched(Co_SetBossBg(args.bossInfoList[0].HPPDFBKEJCG_BgId));
			}
			else
			{
				raidResultRewardLayoutController.gameObject.SetActive(false);
				GJMCHHCPFDL g = new GJMCHHCPFDL();
				DAFGPCEKAJB d = new DAFGPCEKAJB();
				g.KHEKNNFCAOI(true);
				d.KHEKNNFCAOI();
				RaidResultCannonLayoutController.InitParam p = new RaidResultCannonLayoutController.InitParam();
				p.viewEventRaidDamageData = g;
				p.viewEventRaidRankingData = d;
				raidResultCannonLayoutController.gameObject.SetActive(true);
				raidResultCannonLayoutController.onClickOkayButton = OnClickRaidDamageResultEnd;
				raidResultCannonLayoutController.Setup(p);
				yield return this.StartCoroutineWatched(Co_SetBossBg(g.HPPDFBKEJCG_BgId));
				PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
				bool done = false;
				McrsCannonViewer.Initiarize(transform, ev.KFBDBBCCPBB(ev.JIBMOEHKMGB_SelectedBoss.INDDJNMPONH_Type), ev.NNDFMCHDJOH_GetBossSerie(ev.JIBMOEHKMGB_SelectedBoss.INDDJNMPONH_Type), 
					ev.JIBMOEHKMGB_SelectedBoss.HPPDFBKEJCG_BgId, ev.JIBMOEHKMGB_SelectedBoss.FJOLNJLLJEJ_Rank, ev.AGEJGHGEGFF_GetBossName(ev.JIBMOEHKMGB_SelectedBoss.INDDJNMPONH_Type), 
					ev.GGDBEANLCPC.HALIDDHLNEG_MCannonDamage, () =>
					{
						//0x1817314
						done = true;
					});
				while(!done)
					yield return null;
				raidResultBossFilter = McrsCannonViewer.BossFilterLayout;
				raidResultBossFilter.transform.SetParent(transform, false);
				raidResultBossFilter.transform.SetAsFirstSibling();
				McrsCannonViewer.Play(() =>
				{
					//0x1817300
					return;
				}, () =>
				{
					//0x1817258
					raidResultCannonLayoutController.StartAnim();
				}, () =>
				{
					//0x1817304
					McrsCannonViewer.Skip();
				});
				yield return new WaitForSeconds(0.5f);
			}
			m_initialize = true;
		}

		// // RVA: 0x1816464 Offset: 0x1816464 VA: 0x1816464
		private void OnClickRaidDamageResultEnd()
		{
			PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			if(ev.KONJMFICNJJ == null)
			{
				this.StartCoroutineWatched(Co_RaidBossHelp());
			}
			else
			{
				raidResultCannonLayoutController.gameObject.SetActive(false);
				this.StartCoroutineWatched(InitRaidRewardResult(null));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x715394 Offset: 0x715394 VA: 0x715394
		// // RVA: 0x1816714 Offset: 0x1816714 VA: 0x1816714
		private IEnumerator Co_RaidBossHelp()
		{
			PKNOKJNLPOE_EventRaid cont;

			//0x1819BD4
			MessageBank bank = MessageManager.Instance.GetBank("menu");
			cont = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			if(cont.LMIFOCDCNAI())
			{
				if(cont.JIBMOEHKMGB_SelectedBoss.PPFNGGCBJKC_Id == cont.PMIIMELDPAJ_GetMyBoss().PPFNGGCBJKC_Id)
				{
					PopupRaidBossHelpContentSetting s = new PopupRaidBossHelpContentSetting();
					s.TitleText = bank.GetMessageByLabel("pop_raid_helprequest_title");
					s.WindowSize = Common.SizeType.Middle;
					s.Buttons = new ButtonInfo[2]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					bool isHelp = false;
					bool isClose = false;
					RaidBossHelpWindow.SelectType selectType = RaidBossHelpWindow.SelectType.All;
					s.OnSelectType = (RaidBossHelpWindow.SelectType type) =>
					{
						//0x1817330
						selectType = type;
					};
					PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0x1817338
						isClose = true;
						isHelp = type == PopupButton.ButtonType.Positive;
					}, null, null, null, true, true, false);
					while(!isClose)
						yield return null;
					if(isHelp)
					{
						MenuScene.Instance.InputDisable();
						bool done = false;
						bool err = false;
						cont.MCKDAPPELKJ_RequestBossHelp(selectType == RaidBossHelpWindow.SelectType.Loby || selectType == RaidBossHelpWindow.SelectType.LobyPrioFriend, selectType == RaidBossHelpWindow.SelectType.LobyPrioFriend, (List<PKNOKJNLPOE_EventRaid.ECICDAPCMJG> helper) =>
						{
							//0x1817358
							if(helper.Count < 1)
							{
								TextPopupSetting s_ = new TextPopupSetting();
								s_.TitleText = bank.GetMessageByLabel("pop_raid_helprequest_confirmed_title");
								s_.Buttons = new ButtonInfo[1]
								{
									new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
								};
								s_.Text = bank.GetMessageByLabel("pop_raid_helprequest_failed_text02");
								PopupWindowManager.Show(s_, (PopupWindowControl content2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
								{
									//0x1817874
									done = true;
								}, null, null, null, true, true, false);
							}
							else
							{
								PopupRaidHelpCompletionListContentSetting s_ = new PopupRaidHelpCompletionListContentSetting();
								s_.TitleText = bank.GetMessageByLabel("pop_raid_helprequest_completion_title");
								s_.WindowSize = SizeType.Middle;
								s_.Buttons = new ButtonInfo[1]
								{
									new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
								};
								s_.helperList = helper;
								PopupWindowManager.Show(s_, (PopupWindowControl control2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
								{
									//0x1817868
									done = true;
								}, null, null, null, true, true, false);

							}
						}, () =>
						{
							//0x1817880
							done = true;
							err = true;
						}, () =>
						{
							//0x181788C
							TextPopupSetting s_ = new TextPopupSetting();
							s_.TitleText = bank.GetMessageByLabel("pop_raid_helprequest_confirmed_title");
							s_.Buttons = new ButtonInfo[1]
							{
								new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
							};
							s_.Text = bank.GetMessageByLabel("pop_raid_helprequest_failed_text01");
							PopupWindowManager.Show(s_, (PopupWindowControl content2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
							{
								//0x1817B6C
								done = true;
							}, null, null, null, true, true, false);
						}, () =>
						{
							//0x1817B78
							TextPopupSetting s_ = new TextPopupSetting();
							s_.TitleText = bank.GetMessageByLabel("pop_raid_enemy_escape_title");
							s_.Buttons = new ButtonInfo[1]
							{
								new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
							};
							s_.Text = bank.GetMessageByLabel("pop_raid_enemy_escape_result_text");
							PopupWindowManager.Show(s_, (PopupWindowControl content2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
							{
								//0x1817E58
								done = true;
							}, null, null, null, true, true, false);
						}, () =>
						{
							//0x1817E64
							TextPopupSetting s_ = new TextPopupSetting();
							s_.TitleText = bank.GetMessageByLabel("pop_raid_enemy_requested_title");
							s_.Buttons = new ButtonInfo[1]
							{
								new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
							};
							s_.Text = bank.GetMessageByLabel("pop_raid_enemy_requested_text");
							PopupWindowManager.Show(s_, (PopupWindowControl content2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
							{
								//0x1818144
								done = true;
							}, null, null, null, true, true, false);
						}, () =>
						{
							//0x1818150
							TextPopupSetting s_ = new TextPopupSetting();
							s_.TitleText = bank.GetMessageByLabel("pop_raid_enemy_requested_title");
							s_.Buttons = new ButtonInfo[1]
							{
								new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
							};
							s_.Text = bank.GetMessageByLabel("pop_raid_help_result_defeated_text");
							PopupWindowManager.Show(s_, (PopupWindowControl content2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
							{
								//0x1818430
								done = true;
							}, null, null, null, true, true, false);
						}, () =>
						{
							//0x181843C
							TextPopupSetting s_ = new TextPopupSetting();
							s_.TitleText = bank.GetMessageByLabel("pop_raid_enemy_requested_title");
							s_.Buttons = new ButtonInfo[1]
							{
								new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
							};
							s_.Text = bank.GetMessageByLabel("pop_raid_help_player_count_limit_over_text");
							PopupWindowManager.Show(s_, (PopupWindowControl content2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
							{
								//0x181871C
								done = true;
							}, null, null, null, true, true, false);
						});
						//LAB_0181a1f0
						while(!done)
							yield return null;
						MenuScene.Instance.InputEnable();
						if(err)
						{
							MenuScene.Instance.GotoTitle();
							yield break;
						}
					}
				}
			}
			//LAB_0181a308
			EndRaidResult();
		}

		// // RVA: 0x18167C0 Offset: 0x18167C0 VA: 0x18167C0
		private void EndRaidResult()
		{
			MenuScene.Instance.Mount(m_returnUniqueId, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71540C Offset: 0x71540C VA: 0x71540C
		// // RVA: 0x181666C Offset: 0x181666C VA: 0x181666C
		private IEnumerator InitRaidRewardResult(List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ> bossInfoList)
		{
			int i; // 0x1C
			RaidResultRewardLayoutController.InitParam initParam; // 0x20
			PLFJMDBBAJD viewRaidReward; // 0x24

			//0x181AEBC
			initParamList = new List<RaidResultRewardLayoutController.InitParam>();
			currentParamIndex = 0;
			if(bossInfoList != null)
			{
				for(i = 0; i < bossInfoList.Count; i++)
				{
					bool done = false;
					initParam = new RaidResultRewardLayoutController.InitParam();
					initParam.viewEventRaidRewardData = new PLFJMDBBAJD();
					viewRaidReward = new PLFJMDBBAJD();
					viewRaidReward.KHEKNNFCAOI(bossInfoList[i], () =>
					{
						//0x1818730
						done = true;
					});
					while(!done)
						yield return null;
					initParam.viewEventRaidRewardData = viewRaidReward;
					initParamList.Add(initParam);
					initParam = null;
					viewRaidReward = null;
				}
			}
			else
			{
				RaidResultRewardLayoutController.InitParam p = new RaidResultRewardLayoutController.InitParam();
				p.viewEventRaidRewardData = new PLFJMDBBAJD();
				p.viewEventRaidRewardData.KHEKNNFCAOI();
				initParamList.Add(p);
			}
			raidResultRewardLayoutController.gameObject.SetActive(false);
			raidResultRewardLayoutController.onClickOkayButton = OnClickRaidRewardResultEnd;
			raidResultRewardLayoutController.onClickMemberListButton = OnClickMemberListButton;
			yield return this.StartCoroutineWatched(raidResultRewardLayoutController.Co_SetupFromRaid(initParamList[0], raidResultBossFilter));
			yield return this.StartCoroutineWatched(Co_SetBossBg(initParamList[0].viewEventRaidRewardData.HPPDFBKEJCG_BgId));
			StartRaidRewardResultAnim();
		}

		// // RVA: 0x18168A0 Offset: 0x18168A0 VA: 0x18168A0
		private void StartRaidRewardResultAnim()
		{
			raidResultRewardLayoutController.gameObject.SetActive(true);
			raidResultRewardLayoutController.ChangeViewForReward();
			raidResultRewardLayoutController.StartAnim();
		}

		// // RVA: 0x1816934 Offset: 0x1816934 VA: 0x1816934
		private void OnClickRaidRewardResultEnd()
		{
			currentParamIndex++;
			if(currentParamIndex < initParamList.Count)
			{
				this.StartCoroutineWatched(Co_StartNextRaidResult());
			}
			else
			{
				MenuScene.Instance.Mount(m_returnUniqueId, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x715484 Offset: 0x715484 VA: 0x715484
		// // RVA: 0x1816A58 Offset: 0x1816A58 VA: 0x1816A58
		private IEnumerator Co_StartNextRaidResult()
		{
			//0x181A8F0
			MenuScene.Instance.InputDisable();
			GameManager.Instance.fullscreenFader.Fade(0.1f, Color.black);
			while(GameManager.Instance.fullscreenFader.isFading)
				yield return null;
			yield return this.StartCoroutineWatched(raidResultRewardLayoutController.Co_SetupFromRaid(initParamList[currentParamIndex], raidResultBossFilter));
			yield return this.StartCoroutineWatched(Co_SetBossBg(initParamList[currentParamIndex].viewEventRaidRewardData.HPPDFBKEJCG_BgId));
			GameManager.Instance.fullscreenFader.Fade(0.1f, 0);
			while(GameManager.Instance.fullscreenFader.isFading)
				yield return null;
			StartRaidRewardResultAnim();
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x1816B04 Offset: 0x1816B04 VA: 0x1816B04
		private void OnClickMemberListButton()
		{
			RaidMvpCandidatesArgs arg = null;
			if(m_bossInfoList != null)
			{
				arg = new RaidMvpCandidatesArgs(m_bossInfoList[currentParamIndex]);
			}
			MenuScene.Instance.Call(TransitionList.Type.RAID_MVP, arg, true);
		}

		// RVA: 0x1816C10 Offset: 0x1816C10 VA: 0x1816C10 Slot: 16
		protected override void OnPreSetCanvas()
		{
			if(TransitionType == MenuTransitionControl.TransitionType.Return)
				return;
			raidResultCannonLayoutController.gameObject.SetActive(false);
			raidResultRewardLayoutController.gameObject.SetActive(false);
			this.StartCoroutineWatched(Co_Initialize());
		}

		// RVA: 0x1816CD0 Offset: 0x1816CD0 VA: 0x1816CD0 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_initialize;
		}

		// RVA: 0x1816CD8 Offset: 0x1816CD8 VA: 0x1816CD8 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			if(raidResultCannonLayoutController != null && raidResultCannonLayoutController.IsReady() && 
				raidResultRewardLayoutController != null && raidResultRewardLayoutController.IsReady())
			{
				raidResultCannonLayoutController.transform.SetAsLastSibling();
				raidResultRewardLayoutController.transform.SetAsLastSibling();
				return true;
			}
			return false;
		}

		// RVA: 0x1816E9C Offset: 0x1816E9C VA: 0x1816E9C Slot: 9
		protected override void OnStartEnterAnimation()
		{
			return;
		}

		// RVA: 0x1816EA0 Offset: 0x1816EA0 VA: 0x1816EA0 Slot: 23
		protected override void OnActivateScene()
		{
			if(TransitionType != MenuTransitionControl.TransitionType.Return)
				return;
			MenuScene.Instance.HelpButton.ShowRaidResultHelpButton();
		}

		// RVA: 0x1816F74 Offset: 0x1816F74 VA: 0x1816F74 Slot: 12
		protected override void OnStartExitAnimation()
		{
			return;
		}

		// RVA: 0x1816F78 Offset: 0x1816F78 VA: 0x1816F78 Slot: 14
		protected override void OnDestoryScene()
		{
			McrsCannonViewer.DeleteCache();
		}
	}
}
