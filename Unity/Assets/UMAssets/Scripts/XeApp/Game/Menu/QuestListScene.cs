using System.Collections;
using System.Collections.Generic;
using System.Text;
using mcrs;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class QuestListScene : TransitionRoot
	{
		private const int ITEM_NUM = 4;
		private const string BUNDLE_NAME = "ly/059.xab";
		private LayoutQuestList m_layoutScrollList; // 0x48
		private QuestTopFormQuestListArgs m_args; // 0x4C
		private List<FKMOKDCJFEN> m_questViewList; // 0x50
		private List<string> achievementsKeys = new List<string>(); // 0x54
		private List<int> clearQuestIds = new List<int>(); // 0x58
		private bool isSyncMissionStatus; // 0x5C
		private StringBuilder sBuilder = new StringBuilder(); // 0x60

		// RVA: 0x9D5BEC Offset: 0x9D5BEC VA: 0x9D5BEC Slot: 4
		protected override void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_LoadLayout());
		}

		// // RVA: 0x9D5CA8 Offset: 0x9D5CA8 VA: 0x9D5CA8
		private void SetupLayout()
		{
			m_layoutScrollList.OnClickReceiveAll = OnClickReceiveAll;
			m_layoutScrollList.Setup(m_questViewList, m_args.viewData);
			m_layoutScrollList.SetStatus();
			for(int i = 0; i < m_layoutScrollList.List.ScrollObjects.Count; i++)
			{
				(m_layoutScrollList.List.ScrollObjects[i] as LayoutQuestVerticalItem).OnReceiveCallback = UpdateList;
			}
		}

		// // RVA: 0x9D5F70 Offset: 0x9D5F70 VA: 0x9D5F70
		private void ConnectEventQuest()
		{
			m_questViewList = FKMOKDCJFEN.KJHKBBBDBAL(m_args.viewData.JOPOPMLFINI_QuastName, false, m_args.viewData.BCOKKAALGHC_Group);
			m_layoutScrollList.Setup(m_questViewList, m_args.viewData);
			m_layoutScrollList.SetStatus();
			QuestUtility.UpdateQuestData();
			QuestUtility.FooterMenuBadge();
		}

		// // RVA: 0x9D61EC Offset: 0x9D61EC VA: 0x9D61EC
		private void UpdateList()
		{
			ConnectEventQuest();
			m_layoutScrollList.UpdateList();
		}

		// // RVA: 0x9D6220 Offset: 0x9D6220 VA: 0x9D6220
		private void OnClickReceiveAll()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			List<FKMOKDCJFEN> list = new List<FKMOKDCJFEN>();
			for(int i = 0; i < m_questViewList.Count; i++)
			{
				if(m_questViewList[i].CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved)
				{
					list.Add(m_questViewList[i]);
				}
			}
			QuestUtility.ReceiveAll(list, () =>
			{
				//0x9D6E70
				UpdateList();
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7103C4 Offset: 0x7103C4 VA: 0x7103C4
		// // RVA: 0x9D5C1C Offset: 0x9D5C1C VA: 0x9D5C1C
		private IEnumerator Co_LoadLayout()
		{
			//0x9D7C64
			yield return this.StartCoroutineWatched(Co_LoadLayoutList());
			yield return this.StartCoroutineWatched(Co_LoadLayoutListVerticalItem());
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71043C Offset: 0x71043C VA: 0x71043C
		// // RVA: 0x9D655C Offset: 0x9D655C VA: 0x9D655C
		private IEnumerator Co_LoadLayoutList()
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x9D7DC4
			operation = AssetBundleManager.LoadLayoutAsync("ly/059.xab", "root_sel_que_ev_list_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x9D6E74
				m_layoutScrollList = instance.GetComponent<LayoutQuestList>();
			}));
			AssetBundleManager.UnloadAssetBundle("ly/059.xab", false);
			while(!m_layoutScrollList.IsReady())
				yield return null;
			m_layoutScrollList.transform.SetParent(transform, false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7104B4 Offset: 0x7104B4 VA: 0x7104B4
		// // RVA: 0x9D6608 Offset: 0x9D6608 VA: 0x9D6608
		private IEnumerator Co_LoadLayoutListVerticalItem()
		{
			int poolSize;
			AssetBundleLoadLayoutOperationBase operation;

			//0x9D8148
			poolSize = m_layoutScrollList.List.ScrollObjectCount;
			operation = AssetBundleManager.LoadLayoutAsync("ly/059.xab", "root_sel_que_items_list_layout_root");
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x9D6F78
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name += string.Format("_{0:D2}", 0);
				m_layoutScrollList.List.AddScrollObject(baseRuntime.GetComponent<SwapScrollListContent>());
			}));
			AssetBundleManager.UnloadAssetBundle("ly/059.xab", false);
			for(int i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name += string.Format("_{0:D2}", i);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				m_layoutScrollList.List.AddScrollObject(r.GetComponent<SwapScrollListContent>());
			}
			m_layoutScrollList.List.Apply();
			m_layoutScrollList.List.SetContentEscapeMode(true);
			while(!m_layoutScrollList.IsLoaded())
				yield return null;
		}

		// RVA: 0x9D66B4 Offset: 0x9D66B4 VA: 0x9D66B4 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_layoutScrollList.Enter();
		}

		// RVA: 0x9D66E0 Offset: 0x9D66E0 VA: 0x9D66E0 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_layoutScrollList.Leave();
		}

		// RVA: 0x9D670C Offset: 0x9D670C VA: 0x9D670C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_layoutScrollList.IsPlaying();
		}

		// RVA: 0x9D673C Offset: 0x9D673C VA: 0x9D673C Slot: 16
		protected override void OnPreSetCanvas()
		{
			if(Args != null && Args is QuestTopFormQuestListArgs)
			{
				m_args = Args as QuestTopFormQuestListArgs;
				KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(string.Format("ct/qu/qf/{0:d5}.xab", m_args.viewData.LFCOJABLOEN_EventId));
				m_questViewList = FKMOKDCJFEN.KJHKBBBDBAL(m_args.viewData.JOPOPMLFINI_QuastName, false, m_args.viewData.BCOKKAALGHC_Group);
			}
			SetupLayout();
			isSyncMissionStatus = false;
			this.StartCoroutineWatched(Co_SyncMissionStatus(m_args.viewData));
		}

		// RVA: 0x9D6A0C Offset: 0x9D6A0C VA: 0x9D6A0C Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && !isSyncMissionStatus;
		}

		// RVA: 0x9D6AD0 Offset: 0x9D6AD0 VA: 0x9D6AD0 Slot: 23
		protected override void OnActivateScene()
		{
			this.StartCoroutineWatched(Co_Intrduce());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71052C Offset: 0x71052C VA: 0x71052C
		// // RVA: 0x9D6AF4 Offset: 0x9D6AF4 VA: 0x9D6AF4
		private IEnumerator Co_Intrduce()
		{
			//0x9D714C
			if(QuestUtility.m_selectedItemInfo != null)
			{
				MFDJIFIIPJD info = QuestUtility.m_selectedItemInfo;
				QuestUtility.m_selectedItemInfo = null;
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				PopupQuestRewardSetting s = new PopupQuestRewardSetting();
				s.ItemInfo = info;
				s.TitleText = bk.GetMessageByLabel("popup_quest_reward_title");
				s.WindowSize = SizeType.Small;
				s.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } };
				bool popupWait = true;
				PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x9D6F6C
					return;
				}, null, null, null, closeWaitCallBack: () =>
				{
					//0x9D7118
					popupWait = false;
					return true;
				});
				while(popupWait)
					yield return null;
				m_layoutScrollList.UpdateList();
			}
			if(m_args == null)
				yield break;
			if(!m_args.CanShowHelp())
				yield break;
			MenuScene.Instance.InputDisable();
			bool isWait = true;
			yield return this.StartCoroutineWatched(TutorialManager.ShowTutorial(m_args.GetHelpId(), () =>
			{
				//0x9D7130
				isWait = false;
			}));
			while(isWait)
				yield return null;
			if(m_args != null)
			{
				if(m_args.viewData != null)
				{
					KNKDBNFMAKF_EventSp ev = m_args.viewData.COAMJFMEIBF as KNKDBNFMAKF_EventSp;
					if(ev != null)
					{
						ev.ALIBGNACAEA(true, m_args.viewData.BCOKKAALGHC_Group);
						isWait = true;
						MenuScene.Save(() =>
						{
							//0x9D713C
							isWait = false;
						}, null);
						while(isWait)
							yield return null;
					}
				}
			}
			//LAB_009d7440
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7105A4 Offset: 0x7105A4 VA: 0x7105A4
		// // RVA: 0x9D6964 Offset: 0x9D6964 VA: 0x9D6964
		private IEnumerator Co_SyncMissionStatus(CGJKNOCAPII viewData)
		{
			IKDICBBFBMI_EventBase controller;

			//0x9D9948
			if(viewData == null)
				yield break;
			isSyncMissionStatus = true;
			controller = m_args.viewData.COAMJFMEIBF;
			if(controller != null)
			{
				if(controller.OEGAJJANHGL() != 0)
				{
					yield return Co.R(Co_SyncAchievement(controller, false));
					yield return Co.R(Co_SyncAchievement(controller, false));
					UpdateList();
				}
			}
			isSyncMissionStatus = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71061C Offset: 0x71061C VA: 0x71061C
		// // RVA: 0x9D6BC0 Offset: 0x9D6BC0 VA: 0x9D6BC0
		private IEnumerator Co_SyncAchievement(IKDICBBFBMI_EventBase controller, bool isRepeated)
		{
			List<AKIIJBEJOEP> quest; // 0x1C
			JGMEFHJCNHP_GetAchievementRecords req; // 0x20

			//0x9D8884
			achievementsKeys.Clear();
			clearQuestIds.Clear();
			quest = controller.AGLILDLEFDK_Missions;
			for(int i = 0; i < quest.Count; i++)
			{
				if(controller.GBADILEHLGC_GetStatus(quest[i].PPFNGGCBJKC_Id) == 2)
				{
					if(!isRepeated)
					{
						if(quest[i].HPAOAKMKCMA_Slt2 > 0)
						{
							string str = controller.DCODGEOEDPG();
							if(str == null)
								str = "";
							sBuilder.Clear();
							sBuilder.Append(str);
							sBuilder.Append(quest[i].HPAOAKMKCMA_Slt2.ToString("D4"));
							achievementsKeys.Add(sBuilder.ToString());
						}
					}
					else
					{
						if(quest[i].IKJAAKEINHC_Slt > 0)
						{
							string str = controller.IFKKBHPMALH();
							if(str == null)
								str = "";
							sBuilder.Clear();
							sBuilder.Append(str);
							sBuilder.Append(quest[i].IKJAAKEINHC_Slt.ToString());
							achievementsKeys.Add(sBuilder.ToString());
						}
					}
				}
			}
			if(achievementsKeys.Count == 0)
				yield break;
			req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new JGMEFHJCNHP_GetAchievementRecords());
			req.MIDAMHNABAJ_Keys = achievementsKeys;
			req.KMOBDLBKAAA_Repeatable = isRepeated;
			while(!req.PLOOEECNHFB_IsDone)
				yield return null;
			if(req.NPNNPNAIONN_IsError)
			{
				GotoTitle();
			}
			else
			{
				int cnt = req.NFEAMMJIMPG.CEDLLCCONJP.Count;
				for(int i = 0; i < quest.Count; i++)
				{
					if(controller.GBADILEHLGC_GetStatus(quest[i].PPFNGGCBJKC_Id) == 2)
					{
						if(!isRepeated)
						{
							if(quest[i].HPAOAKMKCMA_Slt2 > 0)
							{
								for(int j = 0; j < cnt; j++)
								{
									if(req.NFEAMMJIMPG.CEDLLCCONJP[j].OOIJCMLEAJP_IsReceived)
									{
										string str = controller.DCODGEOEDPG();
										if(str == null)
											str = "";
										sBuilder.Clear();
										sBuilder.Append(str);
										sBuilder.Append(quest[i].HPAOAKMKCMA_Slt2.ToString("D4"));
										if(req.NFEAMMJIMPG.CEDLLCCONJP[j].LJNAKDMILMC_Key == sBuilder.ToString())
										{
											clearQuestIds.Add(quest[i].PPFNGGCBJKC_Id);
										}
									}
								}
							}
						}
						else
						{
							if(quest[i].IKJAAKEINHC_Slt > 0)
							{
								for(int j = 0; j < cnt; j++)
								{
									if(req.NFEAMMJIMPG.CEDLLCCONJP[j].OOIJCMLEAJP_IsReceived)
									{
										string str = controller.IFKKBHPMALH();
										if(str == null)
											str = "";
										sBuilder.Clear();
										sBuilder.Append(str);
										sBuilder.Append(quest[i].IKJAAKEINHC_Slt.ToString());
										if(req.NFEAMMJIMPG.CEDLLCCONJP[j].LJNAKDMILMC_Key == sBuilder.ToString())
										{
											clearQuestIds.Add(quest[i].PPFNGGCBJKC_Id);
										}
									}
								}
							}
						}
					}
				}
				if(clearQuestIds.Count > 0)
				{
					controller.FHGEJBKNBLP(clearQuestIds);
					for(int i = 0; i < clearQuestIds.Count; i++)
					{
						controller.OLDFFDMPEBM_Quests[clearQuestIds[i] - 1].EALOBDHOCHP_Stat = 3;
					}
				}
			}
		}

		// RVA: 0x9D6CA0 Offset: 0x9D6CA0 VA: 0x9D6CA0 Slot: 15
		protected override void OnDeleteCache()
		{
			return;
		}

		// RVA: 0x9D6CA4 Offset: 0x9D6CA4 VA: 0x9D6CA4 Slot: 28
		protected override TransitionArgs GetCallArgsReturn()
		{
			if(PrevTransition < TransitionList.Type.NO_USE__HOME_DIVA_SELECT)
			{
				if(PrevTransition != TransitionList.Type.EVENT_MUSIC_SELECT && PrevTransition != TransitionList.Type.EVENT_QUEST)
					return null;
			}
			else if(PrevTransition != TransitionList.Type.NEW_YEAR_EVENT && PrevTransition != TransitionList.Type.EVENT_BATTLE)
				return null;
			if(TransitionName == TransitionList.Type.QUEST_SELECT)
			{
				return new QuestTopArgs(4);
			}
			return null;
		}
	}
}
