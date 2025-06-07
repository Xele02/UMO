using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class SelectLobbyInfo : TransitionArgs
	{
		public int selectIndex; // 0x8
		public bool isSearchPlayer; // 0xC
		public NKOBMDPHNGP_EventRaidLobby.ELKMKCNPDFO data; // 0x10
	}

	public class LobbyGroupSelctScene : TransitionRoot
	{
		public static readonly int GROUP_MAX_NUM = 4; // 0x0
		private static readonly int BGM_ID = 1026; // 0x4
		private LobbyGroupSelectWindow m_groupSelectWindow; // 0x48
		private LobbyGroupSelctCheckWindow m_checkWindow; // 0x4C
		private LobbySignalWindow m_signalWindow; // 0x50
		private NKOBMDPHNGP_EventRaidLobby m_RaidLobbyController; // 0x54
		private bool m_isInitialized; // 0x58
		private bool IsEndPreset; // 0x59
		private int m_lobbySelect; // 0x5C
		private int m_lobbyGroupNum; // 0x60
		private SelectLobbyInfo m_groupInfo; // 0x64
		private int AddBackKeyCount; // 0x68

		// RVA: 0x1287964 Offset: 0x1287964 VA: 0x1287964 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			IsReady = true;
		}

		// RVA: 0x128798C Offset: 0x128798C VA: 0x128798C Slot: 16
		protected override void OnPreSetCanvas()
		{
			SelectLobbyInfo arg = Args as SelectLobbyInfo;
			SelectLobbyInfo argR = ArgsReturn as SelectLobbyInfo;
			m_groupInfo = arg;
			if(m_groupInfo == null)
				m_groupInfo = argR;
			base.OnPreSetCanvas();
			NCPPAHHCCAO.MGHDHIJIGLD();
			IsEndPreset = false;
			this.StartCoroutineWatched(Co_Initialize());
		}

		// RVA: 0x1287B48 Offset: 0x1287B48 VA: 0x1287B48 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return IsEndPreset;
		}

		// RVA: 0x1287B50 Offset: 0x1287B50 VA: 0x1287B50 Slot: 20
		protected override bool OnBgmStart()
		{
			SoundManager.Instance.bgmPlayer.ContinuousPlay(MenuScene.Instance.GetDefaultBgmId(SceneGroupCategory.LOBBY), 1);
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EAEE4 Offset: 0x6EAEE4 VA: 0x6EAEE4
		// // RVA: 0x1287ABC Offset: 0x1287ABC VA: 0x1287ABC
		private IEnumerator Co_Initialize()
		{
			//0x1289ECC
			yield return Co.R(Co_LoadLayOutData());
			m_groupSelectWindow.Hide();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_checkWindow.SetUpCheckMessge(bk.GetMessageByLabel("lobby_corps_belongs_conf_text"));
			m_checkWindow.SetDownCheckMessge(bk.GetMessageByLabel("lobby_corps_belongs_note_text"));
			m_checkWindow.Hide();
			m_RaidLobbyController = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			if(m_RaidLobbyController == null)
			{
				Debug.LogError("StringLiteral_18336");
			}
			if(m_groupInfo != null)
			{
				LeaveBackButton();
				m_checkWindow.SetBannerImage(m_RaidLobbyController.EPPBAFDEDCD_GetGroupImageId(m_groupInfo.selectIndex - 1));
				while(!m_checkWindow.IsLoadedBanner())
					yield return null;
			}
			yield return Co.R(MenuScene.Instance.BgControl.ChangeBgCoroutine(BgType.LobbyMain, 3, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			yield return Co.R(InitEventController());
			IsEndPreset = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EAF5C Offset: 0x6EAF5C VA: 0x6EAF5C
		// // RVA: 0x1287C68 Offset: 0x1287C68 VA: 0x1287C68
		private IEnumerator InitEventController()
		{
			NKOBMDPHNGP_EventRaidLobby evntCtr; // 0x14
			int i; // 0x18

			//0x128C420
			evntCtr = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			if(evntCtr != null)
			{
				m_lobbyGroupNum = evntCtr.EDILJHGLMNG_GetNumLobbies();
				if(m_groupSelectWindow != null)
				{
					m_groupSelectWindow.BannerLayoutDataAnimation(m_lobbyGroupNum);
				}
				for(i = 0; i < m_lobbyGroupNum; i++)
				{
					m_groupSelectWindow.SetBannerImage(i, evntCtr.EPPBAFDEDCD_GetGroupImageId(i));
					while(!m_groupSelectWindow.IsSetTexture(i))
						yield return null;
				}
			}
			yield return null;
		}

		// RVA: 0x1287D14 Offset: 0x1287D14 VA: 0x1287D14 Slot: 18
		protected override void OnPostSetCanvas()
		{
			this.StartCoroutineWatched(Initialize());
		}

		// RVA: 0x1287DC4 Offset: 0x1287DC4 VA: 0x1287DC4 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return m_isInitialized;
		}

		// RVA: 0x1287DCC Offset: 0x1287DCC VA: 0x1287DCC Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if(m_groupInfo == null)
			{
				m_groupSelectWindow.Enter();
			}
			else
			{
				m_checkWindow.Enter();
			}
		}

		// RVA: 0x1287F2C Offset: 0x1287F2C VA: 0x1287F2C Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return base.IsEndEnterAnimation();
		}

		// RVA: 0x1287F34 Offset: 0x1287F34 VA: 0x1287F34 Slot: 23
		protected override void OnActivateScene()
		{
			this.StartCoroutineWatched(Co_OnActivateScene());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EAFD4 Offset: 0x6EAFD4 VA: 0x6EAFD4
		// // RVA: 0x1287F58 Offset: 0x1287F58 VA: 0x1287F58
		private IEnumerator Co_OnActivateScene()
		{
			GameManager.PushBackButtonHandler backButtonDummy;

			//0x128ABA0
			if(m_groupInfo == null)
				EnterBackButton();
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsMcrsLobbyHelp))
				yield break;
			MenuScene.Instance.InputDisable();
			backButtonDummy = () =>
			{
				//0x12895D0
				return;
			};
			yield return Co.R(TutorialManager.ShowTutorial(118, null));
			bool done = false;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsMcrsLobby, true);
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsMcrsLobbyHelp, true);
			MenuScene.Save(() =>
			{
				//0x12895DC
				done = true;
			}, null);
			while(!done)
				yield return null;
			GameManager.Instance.RemovePushBackButtonHandler(backButtonDummy);
			MenuScene.Instance.InputEnable();
			backButtonDummy = null;
		}

		// RVA: 0x1288004 Offset: 0x1288004 VA: 0x1288004 Slot: 12
		protected override void OnStartExitAnimation()
		{
			if(m_groupSelectWindow.IsShow)
				m_groupSelectWindow.Leave();
			if(m_signalWindow.IsShow)
				m_signalWindow.Leave();
			for(int i = 0; i < AddBackKeyCount; i++)
			{
				GameManager.Instance.RemovePushBackButtonHandler(NotBackKey);
			}
			AddBackKeyCount = 0;
		}

		// RVA: 0x1288290 Offset: 0x1288290 VA: 0x1288290 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_groupSelectWindow.IsPlaying() && !m_signalWindow.IsPlaying();
		}

		// RVA: 0x1288314 Offset: 0x1288314 VA: 0x1288314 Slot: 14
		protected override void OnDestoryScene()
		{
			base.OnDestoryScene();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EB04C Offset: 0x6EB04C VA: 0x6EB04C
		// // RVA: 0x1287D38 Offset: 0x1287D38 VA: 0x1287D38
		private IEnumerator Initialize()
		{
			//0x128CAD8
			m_isInitialized = true;
			yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EB0C4 Offset: 0x6EB0C4 VA: 0x6EB0C4
		// // RVA: 0x128833C Offset: 0x128833C VA: 0x128833C
		private IEnumerator Co_LoadLayOutData()
		{
			StringBuilder bundleName;
			FontInfo systemFont; // 0x18
			AssetBundleLoadLayoutOperationBase operation; // 0x1C

			//0x128A4EC
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/203.xab");
			if(m_groupSelectWindow == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_group_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x1288F80
					instance.transform.SetParent(transform, false);
					m_groupSelectWindow = instance.GetComponent<LobbyGroupSelectWindow>();
					m_groupSelectWindow.onGroupSearchButton = OnClickGroupSearchButton;
					m_groupSelectWindow.OnButtonCallBack((int i) =>
					{
						//0x12892C8
						OnBannerButton(i);
					});
				}));
			}
			//LAB_0128a774
			if(m_checkWindow == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_belong_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x12892CC
					instance.transform.SetParent(transform, false);
					m_checkWindow = instance.GetComponent<LobbyGroupSelctCheckWindow>();
					if(m_checkWindow != null)
					{
						m_checkWindow.onOkClickButton = OnClickOKButton;
						m_checkWindow.onCancelClickButton = OnClickCancelButton;
					}
				}));
			}
			//LAB_0128a8c4
			if(m_signalWindow == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_signal_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x1289484
					instance.transform.SetParent(transform, false);
					m_signalWindow = instance.GetComponent<LobbySignalWindow>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
				yield return null;
			}
		}

		// // RVA: 0x12883E8 Offset: 0x12883E8 VA: 0x12883E8
		private void OnBannerButton(int _index)
		{
			Debug.Log("StringLiteral_18326 "+_index);
			if(GROUP_MAX_NUM < _index)
			{
				OnClickGroupSearchButton();
			}
			else
			{
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
				m_groupInfo = new SelectLobbyInfo();
				m_groupInfo.selectIndex = _index;
				this.StartCoroutineWatched(GotoGroupSelectCheck());
			}
		}

		// // RVA: 0x12885A4 Offset: 0x12885A4 VA: 0x12885A4
		private void OnClickGroupSearchButton()
		{
			Debug.Log("StringLiteral_18327");
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			MenuScene.Instance.Call(TransitionList.Type.LOBBY_GROUP_SEARCH, null, true);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EB13C Offset: 0x6EB13C VA: 0x6EB13C
		// // RVA: 0x1288774 Offset: 0x1288774 VA: 0x1288774
		// private IEnumerator Co_ErrorPopupOpen() { }

		// // RVA: 0x1288808 Offset: 0x1288808 VA: 0x1288808
		private void OnClickOKButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(GotoGroupSelectSignal());
		}

		// // RVA: 0x1288908 Offset: 0x1288908 VA: 0x1288908
		private void OnClickCancelButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(ReturnGroupSelect());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EB1B4 Offset: 0x6EB1B4 VA: 0x6EB1B4
		// // RVA: 0x128897C Offset: 0x128897C VA: 0x128897C
		private IEnumerator ReturnGroupSelect()
		{
			//0x128CBD8
			MenuScene.Instance.InputDisable();
			m_checkWindow.Leave();
			yield return null;
			while(m_checkWindow.IsPlaying())
				yield return null;
			yield return null;
			EnterBackButton();
			m_groupSelectWindow.Enter();
			yield return null;
			while(m_groupSelectWindow.IsPlaying())
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EB22C Offset: 0x6EB22C VA: 0x6EB22C
		// // RVA: 0x1288A28 Offset: 0x1288A28 VA: 0x1288A28
		private IEnumerator SignalToReturnGroupSelect()
		{
			//0x128CF18
			MenuScene.Instance.InputDisable();
			m_signalWindow.Leave();
			yield return null;
			while(m_signalWindow.IsPlaying())
				yield return null;
			yield return null;
			yield return null;
			EnterBackButton();
			m_groupSelectWindow.Enter();
			yield return null;
			while(m_groupSelectWindow.IsPlaying())
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EB2A4 Offset: 0x6EB2A4 VA: 0x6EB2A4
		// // RVA: 0x128887C Offset: 0x128887C VA: 0x128887C
		private IEnumerator GotoGroupSelectSignal()
		{
			//0x128C12C
			MenuScene.Instance.InputDisable();
			m_checkWindow.Leave();
			yield return null;
			while(m_checkWindow.IsPlaying())
				yield return null;
			yield return null;
			yield return null;
			yield return Co.R(Co_SelectLobby(m_groupInfo));
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EB31C Offset: 0x6EB31C VA: 0x6EB31C
		// // RVA: 0x12886E8 Offset: 0x12886E8 VA: 0x12886E8
		private IEnumerator GotoGroupSelectCheck()
		{
			//0x128BCEC
			MenuScene.Instance.InputDisable();
			m_groupSelectWindow.Leave();
			yield return null;
			m_checkWindow.SetBannerImage(m_RaidLobbyController.EPPBAFDEDCD_GetGroupImageId(m_groupInfo.selectIndex));
			while(m_groupSelectWindow.IsPlaying())
				yield return null;
			while(!m_checkWindow.IsLoadedBanner())
				yield return null;
			LeaveBackButton();
			m_checkWindow.Enter();
			yield return null;
			while(m_checkWindow.IsPlaying())
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x1288B14 Offset: 0x1288B14 VA: 0x1288B14
		private void LeaveBackButton()
		{
			MenuScene.Instance.HeaderMenu.MenuStack.LeaveBackButton(false);
			GameManager.Instance.AddPushBackButtonHandler(NotBackKey);
			AddBackKeyCount++;
		}

		// // RVA: 0x1288C94 Offset: 0x1288C94 VA: 0x1288C94
		private void EnterBackButton()
		{
			for(int i = 0; i < AddBackKeyCount; i++)
			{
				GameManager.Instance.RemovePushBackButtonHandler(NotBackKey);
			}
			AddBackKeyCount = 0;
			MenuScene.Instance.HeaderMenu.MenuStack.EnterBackButton(false);
		}

		// // RVA: 0x1288E34 Offset: 0x1288E34 VA: 0x1288E34
		private void NotBackKey()
		{
			return;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EB394 Offset: 0x6EB394 VA: 0x6EB394
		// // RVA: 0x1288E38 Offset: 0x1288E38 VA: 0x1288E38
		private IEnumerator Co_SelectLobby(SelectLobbyInfo data)
		{
			NKOBMDPHNGP_EventRaidLobby cont; // 0x1C

			//0x128B1C4
			cont = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
            LGGPBMPINDL_EventRaidPlayer savePl = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer;
			bool wait = false;
			bool error = false;
			bool isCapacityOver = false;
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_LOBBY_001);
			m_signalWindow.Enter();
			while(m_signalWindow.IsPlaying())
				yield return null;
			m_signalWindow.LoopAnim();
			if(!data.isSearchPlayer)
			{
				cont.DEJFFGKLNHP(data.selectIndex, cont.DKNNNOIMMFN_GetClusterId(), () =>
				{
					//0x12896AC
					wait = true;
					Debug.Log("StringLiteral_18328 "+savePl.MEBHCFJCKFE_LobbyId);
				}, () =>
				{
					//0x1289794
					error = true;
					wait = true;
					Debug.LogError("StringLiteral_18329");
				});
			}
			else
			{
				cont.EJEIHOOOBLM_JoinLobbyByPlayer(cont.DKNNNOIMMFN_GetClusterId(), data.data, () =>
				{
					//0x1289830
					Debug.Log("StringLiteral_18330 "+savePl.MEBHCFJCKFE_LobbyId);
					wait = true;
				}, () =>
				{
					//0x1289918
					Debug.LogError("StringLiteral_18331");
					wait = true;
					isCapacityOver = true;
				}, () =>
				{
					//0x12899B4
					Debug.LogError("StringLiteral_18332");
					error = true;
					wait = true;
				});
			}
			while(!wait)
				yield return null;
			SoundManager.Instance.sePlayerMenu.Stop();
			if(!isCapacityOver)
			{
				if(!error)
				{
					EventLobbyArgs arg = new EventLobbyArgs();
					arg.IsMyLobby = true;
					arg.playerId = NKGJPJPHLIF.HHCJCDFCLOB.CAFHLEFMMGD_GetPlayerId();
					ILCCJNDFFOB.HHCJCDFCLOB.LHCHBHPHLCP(1);
					MenuScene.Instance.Mount(TransitionUniqueId.HOME_LOBBYMAIN, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				}
				else
				{
					Debug.LogError("StringLiteral_18341");
					MenuScene.Instance.GotoTitle();
				}
			}
			else
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				TextPopupSetting s = new TextPopupSetting();
				s.Text = bk.GetMessageByLabel("pop_lobby_group_capacityover_desc");
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				s.IsCaption = false;
				PopupWindowManager.Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
				{
					if(t != PopupButton.ButtonType.Positive)
						return;
					//0x1289A50
					this.StartCoroutineWatched(SignalToReturnGroupSelect());
				}, null, null, null, true, true, false);
			}
        }
	}
}
