using mcrs;
using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class EventStoryScene : TransitionRoot
	{
		private CCAAJNJGNDO m_eventStoryData; // 0x48
		private EventStoryList m_eventStoryList; // 0x4C
		private bool m_isRestor; // 0x50
		private bool m_isChangeBg; // 0x51
		private SnsScreen m_snsScreen; // 0x54
		private StringBuilder m_strBuilder = new StringBuilder(); // 0x58
		private GCIJNCFDNON_SceneInfo m_viewSceneData = new GCIJNCFDNON_SceneInfo(); // 0x5C

		// RVA: 0xB949D4 Offset: 0xB949D4 VA: 0xB949D4
		private void Start()
		{
			this.StartCoroutineWatched(Co_LoadLayout());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DBF6C Offset: 0x6DBF6C VA: 0x6DBF6C
		//// RVA: 0xB949F8 Offset: 0xB949F8 VA: 0xB949F8
		private IEnumerator Co_LoadLayout()
		{
			AssetBundleLoadLayoutOperationBase lytOp;

			//0xB97954
			lytOp = AssetBundleManager.LoadLayoutAsync("ly/117.xab", "root_sel_event_data_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xB971E8
				instance.transform.SetParent(transform, false);
				m_eventStoryList = instance.GetComponent<EventStoryList>();
			}));
			yield return Co.R(m_eventStoryList.Co_LoadListContent());
			AssetBundleManager.UnloadAssetBundle("ly/117.xab", false);
			m_eventStoryList.UpdateListListner += UpdateList;
			m_eventStoryList.PushButtonListner += PushListButton;
			IsReady = true;
		}

		//// RVA: 0xB94AA4 Offset: 0xB94AA4 VA: 0xB94AA4
		private void InitializeList(float listPosition)
		{
			m_eventStoryList.InitializeList(m_eventStoryData, listPosition);
		}

		// RVA: 0xB94ADC Offset: 0xB94ADC VA: 0xB94ADC Slot: 16
		protected override void OnPreSetCanvas()
		{
			EventStoryArgs arg = Args as EventStoryArgs;
			float pos = 0;
			if(arg !=  null)
			{
				m_isRestor = false;
				m_eventStoryData = arg.EventStoryData;
			}
			else
			{
				m_eventStoryData = Database.Instance.advResult.EventStoryData;
				pos = Database.Instance.advResult.RestorListPosition;
				m_isRestor = true;
				if(m_eventStoryData.IMAGLAKEMIE_StoryType == CCAAJNJGNDO.HGIFGFEJLAB.EKJGOMKEJLK_Scene/*2*/)
				{
					m_eventStoryData.HFLNCEOIBJI();
				}
			}
			m_eventStoryList.Hide();
			InitializeList(pos);
			this.StartCoroutineWatched(Co_LoadBg());
			base.OnPreSetCanvas();
		}

		// RVA: 0xB94D5C Offset: 0xB94D5C VA: 0xB94D5C Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			if(!m_isChangeBg)
			{
				if(!KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				{
					return base.IsEndPreSetCanvas();
				}
			}
			return false;
		}

		// RVA: 0xB94E24 Offset: 0xB94E24 VA: 0xB94E24 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_eventStoryList.Enter();
			if (TransitionName != TransitionList.Type.NEW_YEAR_EVENT_STORY)
				return;
			m_eventStoryList.TitleEnter();
		}

		// RVA: 0xB94E80 Offset: 0xB94E80 VA: 0xB94E80 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			if(!m_eventStoryList.IsPlaying())
			{
				return base.IsEndEnterAnimation();
			}
			return false;
		}

		// RVA: 0xB94EC4 Offset: 0xB94EC4 VA: 0xB94EC4 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_eventStoryList.Leave();
		}

		// RVA: 0xB94EEC Offset: 0xB94EEC VA: 0xB94EEC Slot: 13
		protected override bool IsEndExitAnimation()
		{
			if (!m_eventStoryList.IsPlaying())
			{
				return base.IsEndExitAnimation();
			}
			return false;
		}

		// RVA: 0xB94F30 Offset: 0xB94F30 VA: 0xB94F30 Slot: 20
		protected override bool OnBgmStart()
		{
			if(!m_isRestor)
			{
				return base.OnBgmStart();
			}
			else
			{
				if (Database.Instance.advResult.RestorBgmId < 0)
					SoundManager.Instance.bgmPlayer.Stop();
				else
					SoundManager.Instance.bgmPlayer.Play(Database.Instance.advResult.RestorBgmId, 1);
				return true;
			}
		}

		// RVA: 0xB9504C Offset: 0xB9504C VA: 0xB9504C Slot: 14
		protected override void OnDestoryScene()
		{
			m_eventStoryList.ReleaseList();
		}

		// RVA: 0xB95074 Offset: 0xB95074 VA: 0xB95074 Slot: 28
		protected override TransitionArgs GetCallArgsReturn()
		{
			if (!m_isRestor)
			{
				return base.GetCallArgsReturn();
			}
			else
			{
				if (m_eventStoryData.IMAGLAKEMIE_StoryType == CCAAJNJGNDO.HGIFGFEJLAB.EKJGOMKEJLK_Scene/*2*/)
				{
					return new SceneGrowthSceneArgs(GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes.Find((GCIJNCFDNON_SceneInfo x) =>
					{
						//0xB972B8
						return CCAAJNJGNDO.FCMFPPALLOM(m_eventStoryData.PPMNNKKFJNM) == x.BCCHOBPJJKE_SceneId;
					}), false);
				}
				else
				{
					return new EventMusicSelectSceneArgs(m_eventStoryData.PPMNNKKFJNM, false, false);
				}
			}
		}

		// RVA: 0xB95274 Offset: 0xB95274 VA: 0xB95274 Slot: 15
		protected override void OnDeleteCache()
		{
			if (m_snsScreen != null)
			{
				m_snsScreen.Dispose();
				m_snsScreen = null;
			}
			base.OnDeleteCache();
		}

		//// RVA: 0xB9533C Offset: 0xB9533C VA: 0xB9533C
		private void PushListButton(EventStoryListContent.ButtonLabel label, int index, EventStoryListContent.ButtonFunc func)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			if(func > EventStoryListContent.ButtonFunc.None && func <= EventStoryListContent.ButtonFunc.UnRelease)
			{
				switch(func)
				{
					case EventStoryListContent.ButtonFunc.Look:
						LookEvent(index);
						break;
					case EventStoryListContent.ButtonFunc.Release:
						UnlockSns(index);
						break;
					case EventStoryListContent.ButtonFunc.UnReadPrevStory:
						UnReadPrevStory(index);
						break;
					case EventStoryListContent.ButtonFunc.UnRelease:
						UnlockStory(index);
						break;
				}
			}
		}

		//// RVA: 0xB95414 Offset: 0xB95414 VA: 0xB95414
		private void LookEvent(int index)
		{
			CCAAJNJGNDO.GALFFONBIJG data = m_eventStoryData.FFPCLEONGHE[index];
			if(!data.GOBAMBLBCOM_IsPrologueOrEpilogue && !data.CMEKNACNMCE_IsUnknown3 && !data.DHJFHNFFDMG_IsUnknown4)
			{
				this.StartCoroutineWatched(Co_OpenSnsTalk(data.CLIHPOEBELF_RoomId, data.PBPOLELIPJI_AdventureId));
				return;
			}
			int eventUniqueId = m_eventStoryData.PPMNNKKFJNM;
			int restorBgmId = SoundManager.Instance.bgmPlayer.currentBgmId;
			int bgId = MenuScene.Instance.BgControl.GetCurrentId();
			BgType bgType = MenuScene.Instance.BgControl.GetCurrentType();
			BgTextureType bgTexType = MenuScene.Instance.BgControl.GetCurrentTextureType();
			GameAttribute.Type bgAttr = MenuScene.Instance.BgControl.GetCurrentAttr();
			float pos = m_eventStoryList.GetListPosition();
			TransitionUniqueId uniqueId = 0;
			if (m_eventStoryData.IMAGLAKEMIE_StoryType == CCAAJNJGNDO.HGIFGFEJLAB.CCDOBDNDPIL_0)
			{
				switch(OHCAABOMEOF.BPJMGICFPBJ(m_eventStoryData.PPMNNKKFJNM))
				{
					case OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection:
						uniqueId = TransitionUniqueId.EVENTMUSICSELECT_EVENTSTORY;
						break;
					case OHCAABOMEOF.KGOGMKMBCPP_EventType.MKKOHBGHADL_2/*2*/:
					case OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore/*4*/:
					case OHCAABOMEOF.KGOGMKMBCPP_EventType.ENMHPBGOOII_Week/*5*/:
					default:
						break;
					case OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle:
						uniqueId = TransitionUniqueId.EVENTBATTLE_EVENTSTORY;
						break;
					case OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest:
						uniqueId = TransitionUniqueId.EVENTQUEST_EVENTSTORY;
						break;
					case OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp/*7*/:
						IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(m_eventStoryData.PPMNNKKFJNM);
						KNKDBNFMAKF_EventSp k = null;
						if (ev != null)
						{
							TodoLogger.LogError(TodoLogger.EventSp_7, "Event");
						}
						m_eventStoryData.MFCPHGNMMFA(k);
						m_eventStoryList.ListUpdate();
						uniqueId = TransitionUniqueId.HOME_NEWYEAREVENT_NEWYEAREVENTSTORY;
						break;
					case OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva:
						uniqueId = TransitionUniqueId.EVENTGODIVA_EVENTSTORY;
						break;
				}
			}
			else
			{
				if(m_eventStoryData.IMAGLAKEMIE_StoryType == CCAAJNJGNDO.HGIFGFEJLAB.EKJGOMKEJLK_Scene/*2*/)
				{
					uniqueId = (TransitionUniqueId)MenuScene.Instance.GetCurrentScene().uniqueId;
				}
				else
				{
					uniqueId = TransitionUniqueId.OPTIONMENU_EVENTSTORY;
				}
			}
			if(uniqueId != 0)
			{
				Database.Instance.advResult.Setup("Menu", uniqueId, new AdvSetupParam() { eventUniqueId = eventUniqueId, restorBgmId = restorBgmId, restorListPosition = pos, bgParam = new AdvReturnBgParam() { bgId = bgId, textureType = bgTexType, bgType = bgType, attr = bgAttr }, eventStoryData = m_eventStoryData });
			}
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(data.PBPOLELIPJI_AdventureId);
			GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData dbAdv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(data.PBPOLELIPJI_AdventureId);
			OAGBCBBHMPF.DKAMMIHBINF a = 0;
			if (m_eventStoryData.IPCPFJJPIII - 1 < 4)
				a = new OAGBCBBHMPF.DKAMMIHBINF[4] {
					OAGBCBBHMPF.DKAMMIHBINF.BPCPDNGLNGO/*3*/,
					OAGBCBBHMPF.DKAMMIHBINF.HEFPAOLDHCK/*4*/,
					OAGBCBBHMPF.DKAMMIHBINF.DECFIFJACCL/*1*/,
					OAGBCBBHMPF.DKAMMIHBINF.EKJGOMKEJLK/*10*/
				}[m_eventStoryData.IPCPFJJPIII - 1];
			ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(data.PBPOLELIPJI_AdventureId, a);
			Database.Instance.advSetup.Setup(dbAdv.KKPPFAHFOJI_FileId);
			MenuScene.Instance.GotoAdventure(true);
		}

		//// RVA: 0xB9608C Offset: 0xB9608C VA: 0xB9608C
		private void UnlockSns(int index)
		{
			this.StartCoroutineWatched(Co_ShowUnlockSnsPopup(index));
		}

		//// RVA: 0xB960B0 Offset: 0xB960B0 VA: 0xB960B0
		private void UnReadPrevStory(int index)
		{
			TextPopupSetting s = new TextPopupSetting();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			s.TitleText = bk.GetMessageByLabel("event_story_text_016");
			s.Text = bk.GetMessageByLabel("event_story_text_017");
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(s, null, null, null, null);
		}

		//// RVA: 0xB9632C Offset: 0xB9632C VA: 0xB9632C
		private void UnlockStory(int index)
		{
			TextPopupSetting s = new TextPopupSetting();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			CCAAJNJGNDO.GALFFONBIJG c = m_eventStoryData.FFPCLEONGHE[index];
			m_viewSceneData = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[CCAAJNJGNDO.FCMFPPALLOM(c.DEIJDMPOPJF) - 1];
			m_strBuilder.SetFormat(bk.GetMessageByLabel("event_story_text_018"), m_viewSceneData.OPFGFINHFCE_SceneName);
			s.TitleText = bk.GetMessageByLabel("event_story_text_016");
			s.Text = m_strBuilder.ToString();
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Release, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xB97318
				if(type == PopupButton.ButtonType.Positive)
				{
					MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_SCENEABILITYRELEASELIST_SCENEGROWTH, new SceneGrowthSceneArgs(m_viewSceneData, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				}
			}, null, null, null);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DBFE4 Offset: 0x6DBFE4 VA: 0x6DBFE4
		//// RVA: 0xB96884 Offset: 0xB96884 VA: 0xB96884
		private IEnumerator Co_ShowUnlockSnsPopup(int index)
		{
			MessageBank bank; // 0x1C
			TextPopupSetting textPopup; // 0x20

			//0xB98274
			bank = MessageManager.Instance.GetBank("menu");
			textPopup = new TextPopupSetting();
			bool isWait = true;
			CCAAJNJGNDO.GALFFONBIJG d = m_eventStoryData.FFPCLEONGHE[index];
			int a1 = 0;
			int a2 = 0;
			string str = "";
			string str2 = "";
			if(d.LIPNNILKOLH == 2)
			{
				str2 = EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 1));
				a1 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.JJKEDPHDEDO_GetSpItemCount(1);
				a2 = d.GAGNJGMKPME_UnlockCost;
				str = EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 1);
			}
			if(d.NHKNPHLNHHD_UnlockError != 0)
			{
				textPopup.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				if(d.NHKNPHLNHHD_UnlockError == CCAAJNJGNDO.JLFOIPMADEP.EPIBHNAAJGL_1_UnlockNotEnoughItems)
				{
					textPopup.TitleText = bank.GetMessageByLabel("event_story_text_014");
					textPopup.Text = string.Format(bank.GetMessageByLabel("event_story_text_013"), str2, a2, str);
				}
				else if(d.NHKNPHLNHHD_UnlockError == CCAAJNJGNDO.JLFOIPMADEP.IAHDGAGKBGJ_2_PreviousNotViewed)
				{
					textPopup.TitleText = bank.GetMessageByLabel("event_story_text_008");
					textPopup.Text = bank.GetMessageByLabel(d.FICACPOCAPG_NeedRelease ? "event_story_text_012" : "event_story_text_011");
				}
				isWait = true;
				PopupWindowManager.Show(textPopup, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xB975A0
					isWait = false;
				}, null, null, null);
				while(isWait)
					yield return null;
			}
			else
			{
				textPopup.TitleText = bank.GetMessageByLabel("event_story_text_014");
				textPopup.Text = string.Format(bank.GetMessageByLabel("event_story_text_009"), new object[5]
				{
					str2, a2, a1, a1 - a2, str
				});
				textPopup.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.UsedItem, Type = PopupButton.ButtonType.Positive }
				};
				isWait = true;
				bool isPositive = false;
				PopupWindowManager.Show(textPopup, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xB975AC
					if(type == PopupButton.ButtonType.Positive)
						isPositive = true;
					isWait = false;
				}, null, null, null);
				while(isWait)
					yield return null;
				if(!isPositive)
					yield break;
				m_eventStoryData.IIOBBJFCHGH(index);
				CIOECGOMILE.HHCJCDFCLOB.PFAKPFKJJKA();
				isWait = true;
				MenuScene.Instance.InputDisable();
				MenuScene.Save(() =>
				{
					//0xB975C4
					isWait = false;
				}, null);
				while(isWait)
					yield return null;
				MenuScene.Instance.InputEnable();
				d = m_eventStoryData.FFPCLEONGHE[index];
				BOKMNHAFJHF_Sns.KEIGMAOCJHK_Talk sns = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA_Talks[d.PBPOLELIPJI_AdventureId];
				ILCCJNDFFOB.HHCJCDFCLOB.JOLBIMMKGIP(sns.MALFHCHNEFN_RoomId, sns.AIPLIEMLHGC_SnsId, sns.AJIDLAGFPGM_TalkId, EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 1));
				textPopup.TitleText = bank.GetMessageByLabel("event_story_text_008");
				textPopup.Text = bank.GetMessageByLabel("event_story_text_010");
				textPopup.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				PopupWindowManager.Show(textPopup, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xB975D0
					isWait = false;
				}, null, null, null);
				while(isWait)
					yield return null;
				m_eventStoryList.ListUpdate();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DC05C Offset: 0x6DC05C VA: 0x6DC05C
		//// RVA: 0xB94CD0 Offset: 0xB94CD0 VA: 0xB94CD0
		private IEnumerator Co_LoadBg()
		{
			AdvResultData advResult; // 0x14
			BgControl bgControl; // 0x18

			//0xB975E0
			if(m_isRestor)
			{
				advResult = Database.Instance.advResult;
				bgControl = MenuScene.Instance.BgControl;
				if(!bgControl.Comparer(advResult.RestorBgParam.bgId, advResult.RestorBgParam.bgType))
				{
					m_isChangeBg = true;
					yield return Co.R(bgControl.ChangeBgCoroutine(advResult.RestorBgParam.bgType, advResult.RestorBgParam.bgId, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
					bgControl.ChangeAttribute(advResult.RestorBgParam.attr);
					bgControl.ChangeTilingType(BgBehaviour.TilingType.Dot);
					m_isChangeBg = false;
				}
			}
		}

		//// RVA: 0xB9696C Offset: 0xB9696C VA: 0xB9696C
		private void UpdateList(int index, SwapScrollListContent content)
		{
			EventStoryListContent c = content as EventStoryListContent;
			if (c == null)
				return;
			CCAAJNJGNDO.GALFFONBIJG d = m_eventStoryData.FFPCLEONGHE[index];
			c.SetTitleText(d.FFPANKMKAPD_Title);
			c.SetUnlockText(d.OJAKFNNKADK_UnlockText);
			if(d.KKLDIKMOACO_IsSNS)
			{
				c.SetLock(!d.CDOCOLOKCJK_Unlocked);
				bool b = false;
				if(!d.OKKNPGJAPAO_IsUnlockTextEmpty)
				{
					b = !d.OEDKEGEPFKE_NeedUnlock;
				}
				c.EnableLockMessage(b);
				c.EnableSnsIcon(true);
				c.EnableThumbnail(false);
				c.EnableArrow(false);
				c.EnableNoise(false);
				c.EnableNewIcon(false);
			}
			else if(d.CMEKNACNMCE_IsUnknown3)
			{
				c.SetLock(!d.CDOCOLOKCJK_Unlocked);
				c.EnableLockMessage(!d.OKKNPGJAPAO_IsUnlockTextEmpty);
				c.EnableSnsIcon(false);
				c.EnableThumbnail(true);
				c.EnableArrow(true);
				bool b = false;
				if (!d.CDOCOLOKCJK_Unlocked)
					b = !d.GELLHOIEABC_PreviousViewed;
				c.EnableNoise(b);
				c.SetThumbnail(d.HIGLGJBBPAP_ThumbId, d.DEAKHOJCBDM_Index);
				c.EnableNewIcon(d.IFNIEPPAMBE_IsNew);
			}
			else if(d.DHJFHNFFDMG_IsUnknown4)
			{
				c.SetLock(false);
				c.EnableLockMessage(!d.OKKNPGJAPAO_IsUnlockTextEmpty);
				c.EnableSnsIcon(false);
				c.EnableThumbnail(true);
				c.EnableArrow(true);
				c.EnableNoise(false);
				c.SetThumbnail(d.HIGLGJBBPAP_ThumbId, d.DEAKHOJCBDM_Index);
				c.EnableNewIcon(d.IFNIEPPAMBE_IsNew);
				if(!d.CDOCOLOKCJK_Unlocked)
				{
					c.SetButtonLabel(EventStoryListContent.ButtonLabel.Release);
					c.ChangeReleaseFont(EventStoryListContent.ReleaseFont.UnRelease);
					c.SetButtonFunc(EventStoryListContent.ButtonFunc.UnRelease);
				}
				else
				{
					c.SetButtonLabel(EventStoryListContent.ButtonLabel.Look);
					c.SetButtonFunc(EventStoryListContent.ButtonFunc.Look);
				}
				return;
			}
			else
			{
				c.SetLock(!d.CDOCOLOKCJK_Unlocked);
				c.EnableLockMessage(!d.OKKNPGJAPAO_IsUnlockTextEmpty);
				c.EnableSnsIcon(false);
				c.EnableThumbnail(true);
				c.EnableArrow(true);
				c.EnableNoise(!d.CDOCOLOKCJK_Unlocked);
				c.SetThumbnail(d.HIGLGJBBPAP_ThumbId, d.BMCJDCOEJFH == CCAAJNJGNDO.NIPDOAIGCIB.OEDCONLFLHD_2_Epilogue/*2*/);
				c.EnableNewIcon(false);
			}
			c.SetButtonLabel(d.FICACPOCAPG_NeedRelease ? EventStoryListContent.ButtonLabel.Release : EventStoryListContent.ButtonLabel.Look);
			c.SetButtonFunc(d.FICACPOCAPG_NeedRelease ? EventStoryListContent.ButtonFunc.Release : EventStoryListContent.ButtonFunc.Look);
			c.ChangeReleaseFont(EventStoryListContent.ReleaseFont.DoRelease);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DC0D4 Offset: 0x6DC0D4 VA: 0x6DC0D4
		//// RVA: 0xB967C4 Offset: 0xB967C4 VA: 0xB967C4
		public IEnumerator Co_OpenSnsTalk(int roomId, int snsId)
		{
			//0xB97D48
			GameManager.Instance.CloseSnsNotice();
			MenuScene.Instance.InputDisable();
			if(m_snsScreen == null)
			{
				m_snsScreen = SnsScreen.Create(transform.parent);
				yield return null;
			}
			m_snsScreen.Initialize(0, false);
			m_snsScreen.OutStartCallback = () =>
			{
				//0xB97410
				if(m_eventStoryData.IMAGLAKEMIE_StoryType == 0)
				{
					m_eventStoryData.KHEKNNFCAOI_InitFromCurrentEvent(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(m_eventStoryData.PPMNNKKFJNM));
				}
				else
				{
					m_eventStoryData.KHEKNNFCAOI_InitFromEventId(m_eventStoryData.PPMNNKKFJNM);
				}
				m_eventStoryList.ListUpdate();
			};
			MenuScene.Instance.InputEnable();
			if (MenuScene.CheckDatelineAndAssetUpdate())
				yield break;
			MenuScene.Instance.InputDisable();
			m_snsScreen.InRoom(SnsScreen.eSceneType.Menu, roomId, SNSController.eObjectOrderType.Last, snsId, true, m_eventStoryData.IMAGLAKEMIE_StoryType == CCAAJNJGNDO.HGIFGFEJLAB.BJOHLHKGNHM_Event/*1*/);
			while (m_snsScreen != null && m_snsScreen.IsPlaying)
				yield return null;
			MenuScene.Instance.InputEnable();
		}
	}
}
