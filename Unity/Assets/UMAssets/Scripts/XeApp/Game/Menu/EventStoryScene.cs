using mcrs;
using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;

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
				if(m_eventStoryData.IMAGLAKEMIE == CCAAJNJGNDO.HGIFGFEJLAB.EKJGOMKEJLK/*2*/)
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
				if (m_eventStoryData.IMAGLAKEMIE == CCAAJNJGNDO.HGIFGFEJLAB.EKJGOMKEJLK/*2*/)
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
			if(!data.GOBAMBLBCOM && !data.CMEKNACNMCE && !data.DHJFHNFFDMG)
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
			if (m_eventStoryData.IMAGLAKEMIE == 0)
			{
				switch(OHCAABOMEOF.BPJMGICFPBJ(m_eventStoryData.PPMNNKKFJNM))
				{
					case OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection:
						uniqueId = TransitionUniqueId.EVENTMUSICSELECT_EVENTSTORY;
						break;
					case OHCAABOMEOF.KGOGMKMBCPP_EventType.MKKOHBGHADL/*2*/:
					case OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN/*4*/:
					case OHCAABOMEOF.KGOGMKMBCPP_EventType.ENMHPBGOOII/*5*/:
					default:
						break;
					case OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle:
						uniqueId = TransitionUniqueId.EVENTBATTLE_EVENTSTORY;
						break;
					case OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest:
						uniqueId = TransitionUniqueId.EVENTQUEST_EVENTSTORY;
						break;
					case OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB/*7*/:
						IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB(m_eventStoryData.PPMNNKKFJNM);
						KNKDBNFMAKF_EventSp k = null;
						if (ev != null)
						{
							TodoLogger.LogError(0, "Event");
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
				if(m_eventStoryData.IMAGLAKEMIE == CCAAJNJGNDO.HGIFGFEJLAB.EKJGOMKEJLK/*2*/)
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
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA(data.PBPOLELIPJI_AdventureId);
			GPMHOAKFALE_Adventure.NGDBKCKMDHE dbAdv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK(data.PBPOLELIPJI_AdventureId);
			OAGBCBBHMPF.DKAMMIHBINF a = 0;
			if (m_eventStoryData.IPCPFJJPIII - 1 < 4)
				a = new OAGBCBBHMPF.DKAMMIHBINF[4] {
					OAGBCBBHMPF.DKAMMIHBINF.BPCPDNGLNGO/*3*/,
					OAGBCBBHMPF.DKAMMIHBINF.HEFPAOLDHCK/*4*/,
					OAGBCBBHMPF.DKAMMIHBINF.DECFIFJACCL/*1*/,
					OAGBCBBHMPF.DKAMMIHBINF.EKJGOMKEJLK/*10*/
				}[m_eventStoryData.IPCPFJJPIII - 1];
			ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(data.PBPOLELIPJI_AdventureId, a);
			Database.Instance.advSetup.Setup(dbAdv.KKPPFAHFOJI);
			MenuScene.Instance.GotoAdventure(true);
		}

		//// RVA: 0xB9608C Offset: 0xB9608C VA: 0xB9608C
		private void UnlockSns(int index)
		{
			TodoLogger.LogNotImplemented("UnlockSns");
		}

		//// RVA: 0xB960B0 Offset: 0xB960B0 VA: 0xB960B0
		private void UnReadPrevStory(int index)
		{
			TodoLogger.LogNotImplemented("UnReadPrevStory");
		}

		//// RVA: 0xB9632C Offset: 0xB9632C VA: 0xB9632C
		private void UnlockStory(int index)
		{
			TodoLogger.LogNotImplemented("UnlockStory");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DBFE4 Offset: 0x6DBFE4 VA: 0x6DBFE4
		//// RVA: 0xB96884 Offset: 0xB96884 VA: 0xB96884
		//private IEnumerator Co_ShowUnlockSnsPopup(int index) { }

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
				bool b = false;
				if(!d.OKKNPGJAPAO_IsUnlockTextEmpty)
				{
					b = !d.OEDKEGEPFKE;
				}
				c.EnableLockMessage(b);
				c.EnableSnsIcon(true);
				c.EnableThumbnail(false);
				c.EnableArrow(false);
				c.EnableNoise(false);
				c.EnableNewIcon(false);
			}
			else if(d.CMEKNACNMCE)
			{
				c.SetLock(!d.CDOCOLOKCJK_Unlocked);
				c.EnableLockMessage(!d.OKKNPGJAPAO_IsUnlockTextEmpty);
				c.EnableSnsIcon(false);
				c.EnableThumbnail(true);
				c.EnableArrow(true);
				bool b = false;
				if (!d.CDOCOLOKCJK_Unlocked)
					b = !d.GELLHOIEABC;
				c.EnableNoise(b);
				c.SetThumbnail(d.HIGLGJBBPAP_ThumbId, d.DEAKHOJCBDM_Index);
				c.EnableNewIcon(d.IFNIEPPAMBE);
			}
			else if(d.DHJFHNFFDMG)
			{
				c.SetLock(false);
				c.EnableLockMessage(!d.OKKNPGJAPAO_IsUnlockTextEmpty);
				c.EnableSnsIcon(false);
				c.EnableThumbnail(true);
				c.EnableArrow(true);
				c.EnableNoise(false);
				c.SetThumbnail(d.HIGLGJBBPAP_ThumbId, d.DEAKHOJCBDM_Index);
				c.EnableNewIcon(d.IFNIEPPAMBE);
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
				c.SetThumbnail(d.HIGLGJBBPAP_ThumbId == 2 ? 1 : 0, d.BMCJDCOEJFH == CCAAJNJGNDO.NIPDOAIGCIB.OEDCONLFLHD/*2*/);
				c.EnableNewIcon(false);
			}
			c.SetButtonLabel(d.FICACPOCAPG ? EventStoryListContent.ButtonLabel.Release : EventStoryListContent.ButtonLabel.Look);
			c.SetButtonFunc(d.FICACPOCAPG ? EventStoryListContent.ButtonFunc.Release : EventStoryListContent.ButtonFunc.Look);
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
				if(m_eventStoryData.IMAGLAKEMIE == 0)
				{
					m_eventStoryData.KHEKNNFCAOI(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB(m_eventStoryData.PPMNNKKFJNM));
				}
				else
				{
					m_eventStoryData.KHEKNNFCAOI(m_eventStoryData.PPMNNKKFJNM);
				}
				m_eventStoryList.ListUpdate();
			};
			MenuScene.Instance.InputEnable();
			if (MenuScene.CheckDatelineAndAssetUpdate())
				yield break;
			MenuScene.Instance.InputDisable();
			m_snsScreen.InRoom(SnsScreen.eSceneType.Menu, roomId, SNSController.eObjectOrderType.Last, snsId, true, m_eventStoryData.IMAGLAKEMIE == CCAAJNJGNDO.HGIFGFEJLAB.BJOHLHKGNHM/*1*/);
			while (m_snsScreen != null && m_snsScreen.IsPlaying)
				yield return null;
			MenuScene.Instance.InputEnable();
		}
		
		//[CompilerGeneratedAttribute] // RVA: 0x6DC16C Offset: 0x6DC16C VA: 0x6DC16C
		//// RVA: 0xB97318 Offset: 0xB97318 VA: 0xB97318
		//private void <UnlockStory>b__24_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }
	}
}
