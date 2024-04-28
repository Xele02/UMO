using mcrs;
using System;
using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class DecoChatScene : TransitionRoot
	{
		private LobbyScrollListWindow m_windowUi; // 0x48
		private LobbyFooter m_lobbyFooter; // 0x4C
		private LobbyStampMakerButton m_stampMakerButton; // 0x50
		private LobbyStampWindow m_stampWindow; // 0x54
		private Action m_updater; // 0x58
		private OKLFOAPMJAA m_chatContller; // 0x5C
		private int m_ChatPlayerId; // 0x60
		private int m_myPlayerId; // 0x64
		private bool IsInitilaized; // 0x68
		private bool m_isChange; // 0x69
		private int m_commentCount; // 0x6C
		private string m_messgeText = ""; // 0x70
		private bool m_IsSendBtnPossible; // 0x74
		private bool IsRequestNextList; // 0x75
		private long preTime; // 0x78
		private bool m_IsUpdateError; // 0x80
		private bool IsTryProfile; // 0x81
		private bool IsRequestGotoTitle; // 0x82
		private bool IsAfterAutoUpdateAct; // 0x83
		private bool IsTapGuardON; // 0x84
		private bool IsTapGuardOFF; // 0x85

		// RVA: 0xC5254C Offset: 0xC5254C VA: 0xC5254C
		private void Awake()
		{
			IsReady = true;
		}

		// RVA: 0xC52558 Offset: 0xC52558 VA: 0xC52558
		public void Update()
		{
			if (m_updater != null && !IsRequestGotoTitle)
				m_updater();
			if(IsTapGuardON)
			{
				IsTapGuardON = false;
				MenuScene.Instance.InputDisable();
				if (m_windowUi != null)
					m_windowUi.LockScroll();
			}
			if (IsTapGuardOFF)
			{
				IsTapGuardOFF = false;
				MenuScene.Instance.InputEnable();
				if (m_windowUi != null)
					m_windowUi.UnLockScroll();
			}

		}

		//// RVA: 0xC52768 Offset: 0xC52768 VA: 0xC52768
		//private void initialize() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CFF7C Offset: 0x6CFF7C VA: 0x6CFF7C
		//// RVA: 0xC5279C Offset: 0xC5279C VA: 0xC5279C
		private IEnumerator Co_Initialize()
		{
			//0xC57A08
			yield return Co.R(AllAssetsLoad());
			SettingLayout();
			yield return Co.R(Co_NetBbsUpdate());
			if (m_IsUpdateError)
			{
				IsRequestGotoTitle = true;
			}
			else
			{
				yield return Co.R(Co_ReloadComment());
			}
			m_windowUi.HideGotoTopButton(true);
			m_stampWindow.HaveStampListUpdate();
			if (IsRequestGotoTitle)
				GotoTitle();
			IsInitilaized = true;
		}

		//// RVA: 0xC52848 Offset: 0xC52848 VA: 0xC52848
		private void SettingLayout()
		{
			m_stampWindow.onHideClickButton = () =>
			{
				//0xC553BC
				m_stampWindow.Leave();
			};
			m_stampWindow.OnClickStamp = (int stamp, int serif) =>
			{
				//0xC553E8
				OnClickStamp(stamp, serif);
				m_stampWindow.Leave();
			};
			m_stampWindow.OnClickStampEditButton = ClickStampEditButton;
			m_stampMakerButton.OnClickStampButton = ClickStampEditButton;
			m_windowUi.ReprintButtonAction = null;
			m_windowUi.OnClickPlayerIcon = OnClickPlayerIcon;
			m_windowUi.OnClickGotoListTop = OnClickGotoListTop;
			m_windowUi.OnClickIconChangeButton = OnClickIconChangeButton;
			m_windowUi.OnClickBbsUpdateButton = OnClickBbsUpdateButton;
			m_lobbyFooter.SetFooterSwitchButtonAnimation(LobbyFooter.FooterButtonAnimType.DecoChat);
			m_lobbyFooter.onMessgeSend = (string value, bool butEnable) =>
			{
				//0xC5541C
				m_messgeText = value;
				m_IsSendBtnPossible = butEnable;
			};
			m_lobbyFooter.Setting();
			m_lobbyFooter.onSendClickButton = OnClickSendButton;
			m_lobbyFooter.onStampClickButton = OnClickStampButton;
			m_lobbyFooter.onMemberClickButton = null;
			m_lobbyFooter.SetEnableMemberButton(false);
			m_windowUi.HideMiniChara();
		}

		// RVA: 0xC52D44 Offset: 0xC52D44 VA: 0xC52D44 Slot: 16
		protected override void OnPreSetCanvas()
		{
			if(Args != null && Args is DecoChatArgs)
			{
				m_ChatPlayerId = (Args as DecoChatArgs).playerId;
			}
			m_myPlayerId = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
			m_chatContller = EBNNKJCEEFN.LIFAAGMJFEB(m_ChatPlayerId);
			IsInitilaized = false;
			IsRequestGotoTitle = false;
			this.StartCoroutineWatched(Co_Initialize());
			IsTryProfile = false;
			base.OnPreSetCanvas();
		}

		// RVA: 0xC52E80 Offset: 0xC52E80 VA: 0xC52E80 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return IsInitilaized;
		}

		// RVA: 0xC52E88 Offset: 0xC52E88 VA: 0xC52E88 Slot: 18
		protected override void OnPostSetCanvas()
		{
			base.OnPostSetCanvas();
		}

		// RVA: 0xC52E90 Offset: 0xC52E90 VA: 0xC52E90 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return base.IsEndPostSetCanvas();
		}

		// RVA: 0xC52E98 Offset: 0xC52E98 VA: 0xC52E98 Slot: 21
		protected override void OnOpenScene()
		{
			base.OnOpenScene();
			m_updater = UpdateCommentObservation;
			if (m_lobbyFooter != null)
				m_lobbyFooter.Enter(true);
			if (m_stampMakerButton != null)
				m_stampMakerButton.Enter();
		}

		// RVA: 0xC53000 Offset: 0xC53000 VA: 0xC53000 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			m_updater = null;
			if (m_lobbyFooter != null)
				m_lobbyFooter.Leave(true);
			if (m_stampMakerButton != null)
				m_stampMakerButton.Leave();
			if (m_stampWindow != null)
				if(m_stampWindow.IsShow)
					m_stampWindow.Leave();
		}

		// RVA: 0xC531C0 Offset: 0xC531C0 VA: 0xC531C0 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			bool res = true;
			if (m_lobbyFooter != null)
				res &= !m_lobbyFooter.IsPlayingChild();
			if (m_stampMakerButton != null)
				res &= !m_stampMakerButton.IsPlaying();
			if (m_stampWindow != null && m_stampWindow.IsShow)
				res &= !m_stampWindow.IsPlayingChild();
			return res;
		}

		// RVA: 0xC53380 Offset: 0xC53380 VA: 0xC53380 Slot: 20
		protected override bool OnBgmStart()
		{
			MenuScene.Instance.GetDefaultBgmId(SceneGroupCategory.LOBBY);
			return true;
		}

		// RVA: 0xC53424 Offset: 0xC53424 VA: 0xC53424 Slot: 14
		protected override void OnDestoryScene()
		{
			base.OnDestoryScene();
			DestroyImmediate(m_windowUi.gameObject);
			m_windowUi = null;
			DestroyImmediate(m_lobbyFooter.gameObject);
			m_lobbyFooter = null;
			DestroyImmediate(m_stampMakerButton.gameObject);
			m_stampMakerButton = null;
			DestroyImmediate(m_stampWindow.gameObject);
			m_stampWindow = null;
		}

		// RVA: 0xC5356C Offset: 0xC5356C VA: 0xC5356C Slot: 15
		protected override void OnDeleteCache()
		{
			base.OnDeleteCache();
		}

		// RVA: 0xC53574 Offset: 0xC53574 VA: 0xC53574 Slot: 29
		protected override void InputEnable()
		{
			base.InputEnable();
			if (InputStateCount > 0)
				return;
			m_lobbyFooter.InputEnable();
		}

		// RVA: 0xC535C0 Offset: 0xC535C0 VA: 0xC535C0 Slot: 30
		protected override void InputDisable()
		{
			base.InputDisable();
			if (InputStateCount < 1)
				return;
			m_lobbyFooter.InputDisable();
		}

		//// RVA: 0xC5360C Offset: 0xC5360C VA: 0xC5360C
		private void ClickStampEditButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.Call(TransitionList.Type.DECO_STAMP, null, true);
		}

		//// RVA: 0xC5370C Offset: 0xC5370C VA: 0xC5370C
		private void OnClickStamp(int stampId, int serifId)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_AddStampItem(stampId, serifId));
		}

		//// RVA: 0xC53850 Offset: 0xC53850 VA: 0xC53850
		private void OnClickStampButton()
		{
			if (m_stampWindow != null)
			{
				if (m_lobbyFooter.IsKeyBoardOpen)
					return;
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				m_stampWindow.SetParent(transform, transform.parent);
				m_stampWindow.Show();
			}
		}

		//// RVA: 0xC539E4 Offset: 0xC539E4 VA: 0xC539E4
		private void OnClickSendButton()
		{
			if(m_IsSendBtnPossible)
			{
				this.StartCoroutineWatched(Co_AddMessgeItem());
			}
			else
			{
				if (m_lobbyFooter != null)
				{
					m_lobbyFooter.SetMessgeInputOut();
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CFFF4 Offset: 0x6CFFF4 VA: 0x6CFFF4
		//// RVA: 0xC53AC0 Offset: 0xC53AC0 VA: 0xC53AC0
		private IEnumerator Co_AddMessgeItem()
		{
			//0xC5678C
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			IsTapGuardON = true;
			m_chatContller.OBKGEDCKHHE();
			bool success = false;
			bool isDone = false;
			bool inList = false;
			bool error = false;
			CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.LJLKGPDFEAD_IsBlacklisted(m_ChatPlayerId, () =>
			{
				//0xC55980
				success = true;
				isDone = true;
			}, () =>
			{
				//0xC5598C
				isDone = true;
				inList = true;
			}, (CACGCMBKHDI_Request act) =>
			{
				//0xC55998
				isDone = true;
				error = true;
			}, (CACGCMBKHDI_Request act) =>
			{
				//0xC559A8
				isDone = true;
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			});
			while (!isDone)
				yield return null;
			if(inList)
			{
				ShowBlackListPopup();
			}
			if(!success)
			{
				//LAB_00c56bbc
				if (m_lobbyFooter != null)
					m_lobbyFooter.SetMessgeInputOut();
				yield return null;
				IsTapGuardOFF = true;
				yield break;
			}
			yield return Co.R(Co_NetBbsUpdate());
			if(m_IsUpdateError)
			{
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
				if (m_lobbyFooter != null)
					m_lobbyFooter.SetMessgeInputOut();
				yield return null;
				IsTapGuardOFF = true;
				yield break;
			}
			yield return Co.R(Co_NetBbsCreate());
			if (m_lobbyFooter != null)
				m_lobbyFooter.SetMessgeInputOut();
			yield return null;
			IsTapGuardOFF = true;
			yield break;
		}

		//// RVA: 0xC53B6C Offset: 0xC53B6C VA: 0xC53B6C
		private void OnClickIconChangeButton()
		{
			if (m_chatContller.OKNCPELPJJO)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if (!m_isChange)
			{
				m_windowUi.UpdateDivaIconThum(false);
				m_windowUi.IsIconChange = false;
				m_isChange = true;
			}
			else
			{
				m_windowUi.UpdateDivaIconThum(true);
				m_windowUi.IsIconChange = true;
				m_isChange = false;
			}
			CommentDisplayUpdate();
		}

		//// RVA: 0xC53DB8 Offset: 0xC53DB8 VA: 0xC53DB8
		private void OnClickBbsUpdateButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			if (IsAfterAutoUpdateAct)
				return;
			this.StartCoroutineWatched(Co_AfterAutoUpdateAct(() =>
			{
				//0xC558E8
				return;
			}));
		}

		//// RVA: 0xC53FF0 Offset: 0xC53FF0 VA: 0xC53FF0
		private void OnClickGotoListTop()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_windowUi.StopScrollMove();
			m_windowUi.GotoListTop();
		}

		//// RVA: 0xC5408C Offset: 0xC5408C VA: 0xC5408C
		private void OnClickPlayerIcon(int _playerId)
		{
			if (IsTryProfile)
				return;
			IsTryProfile = true;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(Co_OnClickPlayerIcon(_playerId));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D006C Offset: 0x6D006C VA: 0x6D006C
		//// RVA: 0xC5411C Offset: 0xC5411C VA: 0xC5411C
		private IEnumerator Co_OnClickPlayerIcon(int _playerId)
		{
			bool IsMyData;

			//0xC595D4
			IsTapGuardON = true;
			IsMyData = m_myPlayerId == _playerId;
			bool isDone = false;
			bool IsError = false;
			EAJCBFGKKFA_FriendInfo friends = new EAJCBFGKKFA_FriendInfo();
			PIGBKEIAMPE_FriendManager fm = CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager;
			fm.LJMOBJNEHPM(_playerId, () =>
			{
				//0xC55A74
				for(int i = 0; i < fm.BFDEHIANFOG.Count; i++)
				{
					EAJCBFGKKFA_FriendInfo data = new EAJCBFGKKFA_FriendInfo();
					data.KHEKNNFCAOI(fm.BFDEHIANFOG[i]);
					if (data.MLPEHNBNOGD_Id == _playerId)
						friends = data;

				}
				isDone = true;
			}, (CACGCMBKHDI_Request err) =>
			{
				//0xC55BD4
				IsError = true;
				IsTryProfile = false;
			}, (CACGCMBKHDI_Request err) =>
			{
				//0xC55C04
				IsTryProfile = false;
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			});
			while(!isDone)
				yield return null;
			if(!IsError)
			{
				ProfilDateArgs arg = new ProfilDateArgs();
				arg.isFavorite = friends.PCEGKKLKFNO.NEILEPPJKIN_IsFavorite != 0;
				arg.data = friends;
				arg.infoType = ProfilMenuLayout.InfoType.PLAYER;
				arg.btnType = IsMyData ? ProfilMenuLayout.ButtonType.None : ProfilMenuLayout.ButtonType.Fan;
				MenuScene.Instance.Call(TransitionList.Type.PROFIL, arg, true);
				IsTapGuardOFF = true;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D00E4 Offset: 0x6D00E4 VA: 0x6D00E4
		//// RVA: 0xC53790 Offset: 0xC53790 VA: 0xC53790
		private IEnumerator Co_AddStampItem(int stampId, int serifId)
		{
			//0xC56D80
			IsTapGuardON = true;
			m_chatContller.OBKGEDCKHHE();
			bool success = false;
			bool isDone = false;
			bool error = false;
			bool inList = false;
			CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.LJLKGPDFEAD_IsBlacklisted(m_ChatPlayerId, () =>
			{
				//0xC55CE4
				success = true;
				isDone = true;
			}, () =>
			{
				//0xC55CF0
				isDone = true;
				inList = true;
			}, (CACGCMBKHDI_Request act) =>
			{
				//0xC55CFC
				isDone = true;
				error = true;
			}, (CACGCMBKHDI_Request act) =>
			{
				//0xC55D0C
				isDone = true;
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			});
			while (!isDone)
				yield return null;
			if(inList)
			{
				ShowBlackListPopup();
			}
			if(!success)
			{
				yield return null;
				IsTapGuardOFF = true;
				yield break;
			}
			yield return Co.R(Co_NetBbsUpdate());
			if(m_IsUpdateError)
			{
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
				yield return null;
				IsTapGuardOFF = true;
				yield break;
			}
			yield return Co.R(Co_NetBbsStampCreate(stampId, serifId));
			yield return null;
			IsTapGuardOFF = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D015C Offset: 0x6D015C VA: 0x6D015C
		//// RVA: 0xC54204 Offset: 0xC54204 VA: 0xC54204
		private IEnumerator Co_NetBbsStampCreate(int stampId, int serifId)
		{
			//0xC58D34
			bool wait = false;
			bool error = false;
			bool success = false;
			m_chatContller.MFFPEIEMGGM();
			ANPBHCNJIDI.BNEIDPGIAFM data = new ANPBHCNJIDI.BNEIDPGIAFM();
			FFHPBEPOMAK_DivaInfo diva = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0];
			data.AHHJLDLAPAN_DivaId = diva.AHHJLDLAPAN_DivaId;
			data.NNOHKLNKGAD_CostumeId = diva.JPIDIENBGKH_CostumeId;
			data.LIBPMIHHEJD_StampDiva = diva.AHHJLDLAPAN_DivaId;
			data.DJHMGDKKKFO_ColorId = diva.EKFONBFDAAP_ColorId;
			data.HEKIEDEBAEO_StampId = stampId;
			data.EKAMPLIAENM_SerifId = serifId;
			data.PCEHLFNFIDA(GameManager.Instance.ViewPlayerData.AHEFHIMGIBI_ServerSave);
			m_chatContller.NPIBJOGODKG(0, data, () =>
			{
				//0xC55DD8
				wait = true;
				success = true;
			}, () =>
			{
				//0xC55E70
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			}, () =>
			{
				//0xC55F2C
				error = true;
				wait = true;
			});
			while (!wait)
				yield return null;
			if(success)
			{
				yield return Co.R(Co_NetBbsUpdate());
				if(!m_IsUpdateError)
				{
					UpdateChatComment();
				}
				else
				{
					MenuScene.Instance.GotoTitle();
					IsRequestGotoTitle = true;
				}
			}
		}

		//// RVA: 0xC542E4 Offset: 0xC542E4 VA: 0xC542E4
		private void UpdateCommentObservation()
		{
			if(m_windowUi != null && m_chatContller != null)
			{
				m_lobbyFooter.IsButtonDisable(!m_chatContller.ONOLJCIOKOC());
				if(InputManager.Instance.touchCount < 1)
				{
					if(m_windowUi.IsNextUpdate())
					{
						GetNextCommentList();
						return;
					}
				}
				else
				{
					m_chatContller.MFFPEIEMGGM();
				}
				StringBuilder str = new StringBuilder(1024);
				if(m_windowUi.IsUpdatePossible())
				{
					int bbs_auto_update_op = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("bbs_auto_update_op", 1);
					m_chatContller.FBANBDCOEJL(bbs_auto_update_op, () =>
					{
						//0xC55428
						CommentDisplayUpdate();
					}, () =>
					{
						//0xC558EC
						return;
					});
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D01D4 Offset: 0x6D01D4 VA: 0x6D01D4
		//// RVA: 0xC54704 Offset: 0xC54704 VA: 0xC54704
		private IEnumerator Co_ReloadComment()
		{
			//0xC59B3C
			IsTapGuardON = true;
			yield return Co.R(Co_NetBbsUpdate());
			if (!m_IsUpdateError)
				UpdateChatComment();
			else
			{
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			}
			IsTapGuardOFF = true;
		}

		//// RVA: 0xC547B0 Offset: 0xC547B0 VA: 0xC547B0
		private void UpdateChatComment()
		{
			m_commentCount = m_chatContller.NJMOALFKKIK();
			m_windowUi.ResetItem();
			for (int i = m_commentCount - 1; i >= 0; i--)
			{
				ANPBHCNJIDI.NNPGLGHDBKN data = m_chatContller.NOEMAKFEICB(i);
				m_windowUi.AddBbsListItem(data, data.INDDJNMPONH, m_myPlayerId, i, true);
			}
			m_windowUi.AddScrollItem();
			m_windowUi.UpdateScroll();
		}

		//// RVA: 0xC53C88 Offset: 0xC53C88 VA: 0xC53C88
		private void CommentDisplayUpdate()
		{
			m_commentCount = m_chatContller.NJMOALFKKIK();
			m_windowUi.ResetItem();
			for(int i = m_commentCount - 1; i >= 0; i--)
			{
				ANPBHCNJIDI.NNPGLGHDBKN data = m_chatContller.NOEMAKFEICB(i);
				m_windowUi.AddBbsListItem(data, data.INDDJNMPONH, m_myPlayerId, i, true);
			}
			m_windowUi.AddScrollItem();
			m_windowUi.UpdateDisplayOnly();
		}

		//// RVA: 0xC548E0 Offset: 0xC548E0 VA: 0xC548E0
		private void NextAddComment(int index)
		{
			m_commentCount = m_chatContller.NJMOALFKKIK();
			m_windowUi.ResetItem();
			for(int i = m_commentCount - 1; i > -1; i--)
			{
                ANPBHCNJIDI.NNPGLGHDBKN cm = m_chatContller.NOEMAKFEICB(i);
                m_windowUi.AddBbsListItem(cm, cm.INDDJNMPONH, m_myPlayerId, i, true);
			}
			m_windowUi.AddScrollItem();
			m_windowUi.NextCommentAddScrollLsit(index);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D024C Offset: 0x6D024C VA: 0x6D024C
		//// RVA: 0xC54A18 Offset: 0xC54A18 VA: 0xC54A18
		private IEnumerator Co_NetBbsUpdate()
		{
			//0xC59328
			bool wait = false;
			m_IsUpdateError = false;
			if (m_chatContller == null)
				yield break;
			IsTapGuardON = true;
			m_chatContller.JLEFHIOELGH(0, () =>
			{
				//0xC55FD0
				wait = true;
			}, () =>
			{
				//0xC56068
				m_IsUpdateError = true;
				wait = true;
			});
			while (!wait)
				yield return null;
			IsTapGuardOFF = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D02C4 Offset: 0x6D02C4 VA: 0x6D02C4
		//// RVA: 0xC54AC4 Offset: 0xC54AC4 VA: 0xC54AC4
		private IEnumerator Co_NetBbsCreate()
		{
			//0xC587E8
			bool success = false;
			bool wait = false;
			if (m_chatContller == null)
				yield break;
			m_chatContller.MFFPEIEMGGM();
			ANPBHCNJIDI.AIFBLOAGFOP data = new ANPBHCNJIDI.AIFBLOAGFOP();
			data.AHHJLDLAPAN_DivaId = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId;
			data.EBBJPBGHJOL_Content = m_messgeText;
			data.PCEHLFNFIDA(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
			m_chatContller.NPIBJOGODKG(0, data, () =>
			{
				//0xC56120
				success = true;
				wait = true;
			}, () =>
			{
				//0xC561B8
				wait = true;
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			}, () =>
			{
				//0xC5627C
				wait = true;
			});
			while (!wait)
				yield return null;
			if (success)
			{
				yield return Co.R(Co_ReloadComment());
			}
			if (m_lobbyFooter != null)
				m_lobbyFooter.SetMessgeInputOut();
		}

		//// RVA: 0xC546A0 Offset: 0xC546A0 VA: 0xC546A0
		private void GetNextCommentList()
		{
			if(m_chatContller.JFLNJEIOFDE() && !IsRequestNextList)
			{
				IsRequestNextList = true;
				this.StartCoroutineWatched(Co_GetNextCommentList());
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D033C Offset: 0x6D033C VA: 0x6D033C
		//// RVA: 0xC54B70 Offset: 0xC54B70 VA: 0xC54B70
		private IEnumerator Co_GetNextCommentList()
		{
			int optionBits; // 0x18
			int preCommentCount; // 0x1C

			//0xC57598
			bool IsDone = false;
			bool IsError = false;
			bool success = false;
			optionBits = 0;
			IsTapGuardON = true;
			yield return null;
			while(m_chatContller.OKNCPELPJJO)
				yield return null;
			preCommentCount = m_chatContller.NJMOALFKKIK();
			m_chatContller.HDHACKFJKGM(optionBits, () =>
			{
				//0xC5631C
				IsDone = true;
				success = true;
			}, () =>
			{
				//0xC56328
				IsDone = true;
				IsError = true;
			});
			while(!IsDone)
				yield return null;
			if(success)
			{
				yield return null;
				NextAddComment(m_chatContller.NJMOALFKKIK() - preCommentCount);
			}
			//LAB_00c57864
			if(IsError)
			{
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			}
			IsTapGuardOFF = true;
			IsRequestNextList = false;
			yield break;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D03B4 Offset: 0x6D03B4 VA: 0x6D03B4
		//// RVA: 0xC54C1C Offset: 0xC54C1C VA: 0xC54C1C
		private IEnumerator AllAssetsLoad()
		{
			string bundleName; // 0x14
			Font systemFont; // 0x18

			//0xC56338
			bundleName = "ly/203.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			yield return Co.R(Co_LoadAssetsLayoutScrollWindow(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsLayoutFooter(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsLayoutStampWindow(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsLayoutStampMakerButton(bundleName, systemFont));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			while (!m_lobbyFooter.IsLoaded())
				yield return null;
			while (!m_windowUi.IsLoaded())
				yield return null;
			while (!m_stampWindow.IsLoaded())
				yield return null;
			while (!m_stampMakerButton.IsLoaded())
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D042C Offset: 0x6D042C VA: 0x6D042C
		//// RVA: 0xC54CC8 Offset: 0xC54CC8 VA: 0xC54CC8
		private IEnumerator Co_LoadAssetsLayoutScrollWindow(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xC57EE0
			if(m_windowUi == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_lobby_scroll_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0xC554C0
					instance.transform.SetParent(transform, false);
					m_windowUi = instance.GetComponent<LobbyScrollListWindow>();
					if (m_windowUi != null)
						m_windowUi.WindowType = LobbyScrollListWindow.EnWindowType.DecoChat;
				}));
				m_windowUi.Co_SettingList();
				yield return m_windowUi.Co_LoadAssetsLayoutListItemR(bundleName, font);
				yield return m_windowUi.Co_LoadAssetsLayoutListItemL(bundleName, font);
				operation = null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D04A4 Offset: 0x6D04A4 VA: 0x6D04A4
		//// RVA: 0xC54DA8 Offset: 0xC54DA8 VA: 0xC54DA8
		private IEnumerator Co_LoadAssetsLayoutFooter(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xC57C44
			if(m_lobbyFooter == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_lobby_footer_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0xC555FC
					instance.transform.SetParent(transform, false);
					m_lobbyFooter = instance.GetComponent<LobbyFooter>();
				}));
				operation = null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D051C Offset: 0x6D051C VA: 0x6D051C
		//// RVA: 0xC54E88 Offset: 0xC54E88 VA: 0xC54E88
		private IEnumerator Co_LoadAssetsLayoutStampWindow(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xC584F4
			if(m_stampWindow == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_lobby_stmp_win_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0xC556CC
					instance.transform.SetParent(transform, false);
					m_stampWindow = instance.GetComponent<LobbyStampWindow>();
				}));
				yield return Co.R(m_stampWindow.Co_LoadStampItemContent());
				operation = null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D0594 Offset: 0x6D0594 VA: 0x6D0594
		//// RVA: 0xC54F68 Offset: 0xC54F68 VA: 0xC54F68
		private IEnumerator Co_LoadAssetsLayoutStampMakerButton(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xC58258
			if(m_stampMakerButton == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_lobby_btn_stmp_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0xC5579C
					instance.transform.SetParent(transform, false);
					m_stampMakerButton = instance.GetComponent<LobbyStampMakerButton>();
				}));
				operation = null;
			}
		}

		//// RVA: 0xC55048 Offset: 0xC55048 VA: 0xC55048
		//private void TapGuardOn() { }

		//// RVA: 0xC55054 Offset: 0xC55054 VA: 0xC55054
		//private void TapGuardOff() { }

		//// RVA: 0xC55060 Offset: 0xC55060 VA: 0xC55060
		private void ShowBlackListPopup()
		{
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = MessageManager.Instance.GetMessage("menu", "pop_blocked_title");
			s.Text = MessageManager.Instance.GetMessage("menu", "pop_blocked_text");
			s.WindowSize = SizeType.Small;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, null, null, null, null);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D060C Offset: 0x6D060C VA: 0x6D060C
		//// RVA: 0xC53F48 Offset: 0xC53F48 VA: 0xC53F48
		private IEnumerator Co_AfterAutoUpdateAct(Action act)
		{
			//0xC572D8
			IsAfterAutoUpdateAct = true;
			MenuScene.Instance.InputDisable();
			m_windowUi.LockScroll();
			while(m_chatContller.OKNCPELPJJO)
				yield return null;
			act();
			yield return Co.R(Co_ReloadComment());
			MenuScene.Instance.InputEnable();
			m_windowUi.UnLockScroll();
			IsAfterAutoUpdateAct = false;
		}
	}
}
