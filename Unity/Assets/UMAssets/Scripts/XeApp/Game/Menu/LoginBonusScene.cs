using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LoginBonusScene : TransitionRoot
	{
		private enum eConnectStatus
		{
			None = 0,
			Success = 1,
			SuccessNo = 2,
			Error = 3,
		}

		private DivaSerifWindow m_layoutDivaSerifWindow; // 0x48
		private LayoutLoginBonusStanding m_layoutLoginbonusStanding; // 0x4C
		private LayoutLoginBonusConditions m_layoutLoginbonusConditions; // 0x50
		private ItemPackImageTextureCache m_itemPackTextureCache; // 0x54
		private List<EPLAAEHPCDM> m_loginBonusMasters; // 0x58
		private bool m_isLoading; // 0x5C
		private LoginBonusScene.eConnectStatus m_connectStatus; // 0x60
		private bool m_isOpenScene; // 0x64
		private bool m_isConnect = true; // 0x65
		private LoginBonusDivaControl m_divaControl; // 0x68
		private List<IEnumerator> m_updater = new List<IEnumerator>(8); // 0x6C

		private IKIIAFKHDFP loginBonusManager { get { return NKGJPJPHLIF.HHCJCDFCLOB.DHEFMDMGPMG_LoginBonusManager; } set { NKGJPJPHLIF.HHCJCDFCLOB.DHEFMDMGPMG_LoginBonusManager = value; } } //0xEB2DEC 0xEB2E80

		// // RVA: 0xEB2F18 Offset: 0xEB2F18 VA: 0xEB2F18 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			IsReady = true;
			m_itemPackTextureCache = new ItemPackImageTextureCache();
		}

		// // RVA: 0xEB2FA4 Offset: 0xEB2FA4 VA: 0xEB2FA4 Slot: 20
		protected override bool OnBgmStart()
		{
			if (m_connectStatus != eConnectStatus.SuccessNo && m_connectStatus != eConnectStatus.Error)
			{
				int id = MenuScene.Instance.BgControl.limitedHomeBg.m_music_id;
				if(id == BgControl.LimitedHomeBg.INVALID_MUSIC_ID)
				{
					string strid = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL("home_bgm_id", "0,0,0");
					string[] strs = strid.Split(new char[] { ',' });
					if(strs.Length == 3)
					{
						long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
						int idx = BgControl.GetHomeBgId(time);
						int id2;
						if(int.TryParse(strs[idx - 1], out id2))
						{
							id = id2 + BgmPlayer.MENU_BGM_ID_BASE;
						}
					}
				}
				else
				{
					id = id + BgmPlayer.MENU_BGM_ID_BASE;
				}
				SoundManager.Instance.bgmPlayer.ContinuousPlay(id, 1);
			}
			return true;
		}

		// // RVA: 0xEB34A8 Offset: 0xEB34A8 VA: 0xEB34A8 Slot: 21
		protected override void OnOpenScene()
		{
			BasicTutorialManager.TutorialAfterFirstLoginBonus();
			base.OnOpenScene();
		}

		// // RVA: 0xEB34CC Offset: 0xEB34CC VA: 0xEB34CC
		private void Update()
		{
			if(m_updater.Count > 0)
			{
				if(!m_updater[0].MoveNext())
				{
					m_updater.RemoveAt(0);
				}
			}
			m_itemPackTextureCache.Update();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EC5E4 Offset: 0x6EC5E4 VA: 0x6EC5E4
		// // RVA: 0xEB3658 Offset: 0xEB3658 VA: 0xEB3658
		private IEnumerator DefaultLoginBonus()
		{
			IEnumerator fadeIn; // 0x18
			bool isEnd; // 0x1C
			IEnumerator fade; // 0x20

			//0xEB70FC
			if(m_loginBonusMasters.Count < 1)
				yield break;
			while(!m_isOpenScene)
				yield return null;
			fadeIn = FadeIn();
			while(fadeIn.MoveNext())
				yield return null;
			isEnd = false;
			while(!isEnd)
			{
				if(m_loginBonusMasters.Count < 1)
					break;
				EPLAAEHPCDM data = m_loginBonusMasters[0];
				if(data.CKHOBDIKJFN_Type < ANPGILOLNFK.CDOGFBNLIPG.PHABJLGFJNI_1 || data.CKHOBDIKJFN_Type > ANPGILOLNFK.CDOGFBNLIPG.CEIJKIOOIPE_4)
				{
					isEnd = true;
					break;
				}
				m_loginBonusMasters.RemoveAt(0);
				//LAB_00eb7424
				while(m_divaControl.IsBreakReactionPlaying)
					yield return null;
				m_layoutLoginbonusStanding.SetButtonCallbackOk(() =>
				{
					//0xEB583C
					if(m_loginBonusMasters.Count > 0)
					{
						if(data.CKHOBDIKJFN_Type >= ANPGILOLNFK.CDOGFBNLIPG.PHABJLGFJNI_1 || data.CKHOBDIKJFN_Type <= ANPGILOLNFK.CDOGFBNLIPG.CEIJKIOOIPE_4)
						{
							m_divaControl.RequestLoginAnimLoopBreak();
						}
					}
					m_layoutLoginbonusStanding.Hide();
				});
				m_layoutLoginbonusStanding.SetPreStampPlayCallback(() =>
				{
					//0xEB5CA8
					DivaPlay(data.CKHOBDIKJFN_Type);
				});
				m_layoutLoginbonusStanding.SetStatus(data, loginBonusManager, m_itemPackTextureCache);
				m_layoutLoginbonusStanding.OnWaitDivaVoice = () =>
				{
					//0xEB5950
					return m_divaControl.IsVoicePlaying;
				};
				//LAB_00eb75b8
				while(m_layoutLoginbonusStanding.IsLoading())
					yield return null;
				m_layoutLoginbonusStanding.Show();
				//LAB_00eb760c
				while(!m_layoutLoginbonusStanding.IsClosed())
					yield return null;
				m_layoutLoginbonusStanding.Reset();
			}
			//LAB_00eb76d8
			fade = FadeOut();
			while(fade.MoveNext())
				yield return null;
			DivaHide();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EC65C Offset: 0x6EC65C VA: 0x6EC65C
		// // RVA: 0xEB3704 Offset: 0xEB3704 VA: 0xEB3704
		private IEnumerator ConditionsLoginBonus()
		{
			IEnumerator fade; // 0x18
			bool isEnd; // 0x1C
			EPLAAEHPCDM data; // 0x20

			//0xEB6230
			if(m_loginBonusMasters.Count < 1)
				yield break;
			while(!m_isOpenScene)
				yield return null;
			isEnd = false;
			while(!isEnd)
			{
				if(m_loginBonusMasters.Count < 1)
					break;
				data = m_loginBonusMasters[0];
				if(data.CKHOBDIKJFN_Type < ANPGILOLNFK.CDOGFBNLIPG.LAOEGNLOJHC_5 || data.CKHOBDIKJFN_Type >= ANPGILOLNFK.CDOGFBNLIPG.MKADAMIGMPO_7)
				{
					isEnd = true;
					break;
				}
				m_loginBonusMasters.RemoveAt(0);
				if(data.OENPCNBFPDA_BgId > 0)
				{
					bool isWait = true;
					this.StartCoroutineWatched(Co_LoadBg(data.OENPCNBFPDA_BgId, () =>
					{
						//0xEB5CF4
						isWait = false;
					}));
					//LAB_00eb633c
					while(isWait)
						yield return null;
				}
				m_layoutLoginbonusConditions.SetButtonCallbackOk(() =>
				{
					//0xEB597C
					m_layoutLoginbonusConditions.Hide();
				});
				m_layoutLoginbonusConditions.SetStatus(data, loginBonusManager, m_itemPackTextureCache);
				//LAB_00eb65d0
				while(m_layoutLoginbonusConditions.IsLoading())
					yield return null;
				m_layoutLoginbonusConditions.Show();
				fade = FadeIn();
				while(fade.MoveNext())
					yield return null;
				while(!m_layoutLoginbonusConditions.IsClosed())
					yield return null;
				fade = FadeOut();
				while(fade.MoveNext())
					yield return null;
				m_layoutLoginbonusConditions.Reset();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EC6D4 Offset: 0x6EC6D4 VA: 0x6EC6D4
		// // RVA: 0xEB37B0 Offset: 0xEB37B0 VA: 0xEB37B0
		private IEnumerator NextScene()
		{
			//0xEB8E58
			while (!m_isOpenScene)
			{
				yield return null;
			}
			BasicTutorialManager.TutorialAfterFirstHome();
			GameManager.Instance.SetFPS(30);
			foreach(var e in JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN)
			{
				if(e.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool)
				{
					if(e is AMLGMLNGMFB_EventAprilFool)
					{
						bool done = false;
						bool err = false;
						(e as AMLGMLNGMFB_EventAprilFool).LEGMNFOCKGE(() =>
						{
							//0xEB5D08
							done = true;
						}, () =>
						{
							//0xEB5D14
							done = true;
							err = true;
						});
						while (!done)
							yield return null;
						if(err)
						{
							MenuScene.Instance.GotoTitle();
							yield break;
						}
					}
				}
			}
			IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_PresentCampaign/*9*/, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/);
			if(ev != null)
			{
				TodoLogger.LogError(TodoLogger.EventPresentCampaign_9, "LoginBonusScene.NextScene event");
			}
			//LAB_00eb9458
			MenuScene.Instance.Mount(TransitionUniqueId.EPISODEAPPEAL, null, true, 0);
		}

		// // RVA: 0xEB385C Offset: 0xEB385C VA: 0xEB385C
		private void ResetData()
		{
			loginBonusManager = null;
			m_isLoading = false;
			m_loginBonusMasters = null;
			m_connectStatus = 0;
			m_isOpenScene = false;
			m_isConnect = true;
			m_divaControl = new LoginBonusDivaControl();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EC74C Offset: 0x6EC74C VA: 0x6EC74C
		// // RVA: 0xEB38F0 Offset: 0xEB38F0 VA: 0xEB38F0
		private IEnumerator FadeIn()
		{
			//0xEB787C
			while(TipsControl.Instance.isPlayingAnime())
				yield return null;
			TipsControl.Instance.Close();
			GameManager.Instance.NowLoading.Hide();
			GameManager.Instance.fullscreenFader.Fade(0.1f, 0);
			while(GameManager.Instance.fullscreenFader.isFading)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EC7C4 Offset: 0x6EC7C4 VA: 0x6EC7C4
		// // RVA: 0xEB3984 Offset: 0xEB3984 VA: 0xEB3984
		private IEnumerator FadeOut()
		{
			//0xEB7BC8
			GameManager.Instance.fullscreenFader.Fade(0.1f, Color.black);
			while(GameManager.Instance.fullscreenFader.isFading)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EC83C Offset: 0x6EC83C VA: 0x6EC83C
		// // RVA: 0xEB3A18 Offset: 0xEB3A18 VA: 0xEB3A18
		private IEnumerator Co_LoadBg(int bgId, UnityAction endCallBack)
		{
			//0xEB606C
			yield return this.StartCoroutineWatched(MenuScene.Instance.ChangeBgTexture(BgTextureType.LoginBonus, bgId));
			if (endCallBack != null)
				endCallBack();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EC8B4 Offset: 0x6EC8B4 VA: 0x6EC8B4
		// // RVA: 0xEB3AF8 Offset: 0xEB3AF8 VA: 0xEB3AF8
		private IEnumerator SetupDiva(Action finish)
		{
			//0xEB9820
			MenuScene.Instance.divaManager.Release(true);
			MenuScene.Instance.divaManager.Load(GameManager.Instance.ViewPlayerData, DivaResource.MenuFacialType.Home, true);
			while(MenuScene.Instance.divaManager.IsLoading)
				yield return null;
			yield return null;
			MenuScene.Instance.divaManager.OnIdle("");
			DivaShow();
			yield return null;
			DivaIdle();
			yield return new WaitForSeconds(0.1f);
			if(finish != null)
				finish();
		}

		// // RVA: 0xEB3BC0 Offset: 0xEB3BC0 VA: 0xEB3BC0
		private void DivaShow()
		{
			GameManager.Instance.SetFPS(60);
			MenuScene.Instance.divaManager.SetActive(true, true);
		}

		// // RVA: 0xEB3DC0 Offset: 0xEB3DC0 VA: 0xEB3DC0
		private void DivaHide()
		{
			GameManager.Instance.SetFPS(30);
			MenuScene.Instance.divaManager.SetActive(false, true);
			m_layoutDivaSerifWindow.Leave();
			m_divaControl.CallbackChangeDivaSerif = null;
			m_divaControl.Stop();
		}

		// // RVA: 0xEB3F40 Offset: 0xEB3F40 VA: 0xEB3F40
		private void DivaIdle()
		{
			m_divaControl.OnLoginIdle();
		}

		// // RVA: 0xEB3F6C Offset: 0xEB3F6C VA: 0xEB3F6C
		private void DivaPlay(ANPGILOLNFK.CDOGFBNLIPG type)
		{
			m_layoutDivaSerifWindow.SetTitle(MenuScene.Instance.divaManager.GetFullName());
			m_layoutDivaSerifWindow.Enter();
			if(type >= ANPGILOLNFK.CDOGFBNLIPG.DHGCJEOPEIE_3 && type < ANPGILOLNFK.CDOGFBNLIPG.LAOEGNLOJHC_5)
			{
				if (CheckComebackTalk(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), CIOECGOMILE.HHCJCDFCLOB.PKBOFLOJNIJ_LastLoginTime))
				{
					m_layoutDivaSerifWindow.SetText(MenuScene.Instance.divaManager.GetMessageByLabel("talk_comeback_01"));
					m_divaControl.RequestLoginBonus(LoginBonusDivaControl.Type.Comeback_001);
				}
				else
				{
					m_layoutDivaSerifWindow.SetText(MenuScene.Instance.divaManager.GetMessageByLabel("talk_comeback_02"));
					m_divaControl.RequestLoginBonus(LoginBonusDivaControl.Type.Comeback_002);
				}
				m_divaControl.CallbackChangeDivaSerif = null;
			}
			else
			{
				m_layoutDivaSerifWindow.SetText(MenuScene.Instance.divaManager.GetMessageByLabel("login_reaction_01"));
				m_divaControl.RequestLoginBonus(LoginBonusDivaControl.Type.Regular);
				m_divaControl.CallbackChangeDivaSerif = () =>
				{
					//0xEB59A8
					ChangeDivaSerif("login_reaction_02");
				};
			}
		}

		// // RVA: 0xEB4740 Offset: 0xEB4740 VA: 0xEB4740
		private void ChangeDivaSerif(string label)
		{
			if(m_layoutDivaSerifWindow != null)
			{
				m_layoutDivaSerifWindow.SetText(MenuScene.Instance.divaManager.GetMessageByLabel(label));
			}
		}

		// // RVA: 0xEB445C Offset: 0xEB445C VA: 0xEB445C
		private bool CheckComebackTalk(long loginTime, long lastLoginTime)
		{
			long prev = GameManager.Instance.localSave.EPJOACOONAC_GetSave().NDOKECOAPML_Login.CCIMAHFKOGO_LastLoginDate;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().NDOKECOAPML_Login.CCIMAHFKOGO_LastLoginDate = loginTime;
			if (lastLoginTime < prev)
				lastLoginTime = prev;
			TimeSpan s = Utility.GetLocalDateTime(loginTime) - Utility.GetLocalDateTime(lastLoginTime);
			return s.Days >= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("comeback_login_bonus_talk", 7);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EC92C Offset: 0x6EC92C VA: 0x6EC92C
		// // RVA: 0xEB4874 Offset: 0xEB4874 VA: 0xEB4874
		private IEnumerator ConnectLoginBonus()
		{
			IEnumerator loginBonus;

			//0xEB6920
			PGIGNJDPCAH.HIHIEBACIHJ(PGIGNJDPCAH.FELLIEJEPIJ.JBAIEADLAGH_0/*0*/);
			loginBonus = /*Co.R(*/CheckLoginBonus()/*)*/;
			while (loginBonus.MoveNext())
				yield return null;
			if(m_connectStatus == eConnectStatus.Success)
			{
				m_loginBonusMasters = new List<EPLAAEHPCDM>(loginBonusManager.FMAMKPJMFHJ);
				m_loginBonusMasters.RemoveAll((EPLAAEHPCDM master) =>
				{
					//0xEB5C08
					return master.PJHKECDOALD == 0;
				});
				if(IsDefaultLoginBonus())
				{
					m_updater.Add(LoadingLayout());
					m_updater.Add(DefaultLoginBonus());
				}
				if (IsExistConditionsLoginBonus())
				{
					m_updater.Add(LoadingLayoutConditions());
					m_updater.Add(ConditionsLoginBonus());
				}
				m_updater.Add(NextScene());
				yield return null;
				//4
				AutoFadeFlag = false;
				m_isConnect = false;
			}
			else if(m_connectStatus == eConnectStatus.Error)
			{
				loginBonusManager = null;
				AutoFadeFlag = false;
				m_isConnect = false;
				yield return null;
				//2
				MenuScene.Instance.GotoTitle();
			}
			else
			{
				loginBonusManager = null;
				m_connectStatus = eConnectStatus.None;
				AutoFadeFlag = false;
				m_isConnect = false;
				yield return null;
				//3
				m_updater.Add(NextScene());
			}
		}

		// // RVA: 0xEB4920 Offset: 0xEB4920 VA: 0xEB4920
		// private void ConnectEnd() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EC9A4 Offset: 0x6EC9A4 VA: 0x6EC9A4
		// // RVA: 0xEB4944 Offset: 0xEB4944 VA: 0xEB4944
		private IEnumerator CheckLoginBonus()
		{
			//0xEB5D54
			if (loginBonusManager != null)
			{
				m_connectStatus = eConnectStatus.Success;
				yield break;
			}
			m_connectStatus = eConnectStatus.None;
			loginBonusManager = new IKIIAFKHDFP();
			loginBonusManager.HBOKJNECOPA_GetMaster(onSuccessWithBonus, onSuccessNoBonus, onErrorBonus, false);
			while (m_connectStatus == eConnectStatus.None)
				yield return null;
			BIFNGFAIEIL.HHCJCDFCLOB.DNKCCHCEPBH(false);
		}

		// // RVA: 0xEB49F0 Offset: 0xEB49F0 VA: 0xEB49F0
		private void onSuccessWithBonus()
		{
			m_connectStatus = eConnectStatus.Success;
		}

		// // RVA: 0xEB49FC Offset: 0xEB49FC VA: 0xEB49FC
		private void onSuccessNoBonus()
		{
			m_connectStatus = eConnectStatus.SuccessNo;
		}

		// // RVA: 0xEB4A08 Offset: 0xEB4A08 VA: 0xEB4A08
		private void onErrorBonus()
		{
			m_connectStatus = eConnectStatus.Error;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ECA1C Offset: 0x6ECA1C VA: 0x6ECA1C
		// // RVA: 0xEB4A14 Offset: 0xEB4A14 VA: 0xEB4A14
		private IEnumerator LoadingLayout()
		{
			//0xEB8A98
			m_isLoading = false;
			this.StartCoroutineWatched(LayoutLoadDivaSerifWindow());
			while (!m_isLoading)
				yield return null;
			m_isLoading = false;
			this.StartCoroutineWatched(LayoutLoadDefaultLoginBonus());
			while (!m_isLoading)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ECA94 Offset: 0x6ECA94 VA: 0x6ECA94
		// // RVA: 0xEB4AC0 Offset: 0xEB4AC0 VA: 0xEB4AC0
		private IEnumerator LoadingLayoutConditions()
		{
			//0xEB8C6C
			m_isLoading = false;
			this.StartCoroutineWatched(LayoutLoadConditionsLoginBonus());
			while(!m_isLoading)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ECB0C Offset: 0x6ECB0C VA: 0x6ECB0C
		// // RVA: 0xEB4B6C Offset: 0xEB4B6C VA: 0xEB4B6C
		private IEnumerator LayoutLoadDefaultLoginBonus()
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xEB8240
			if(m_layoutLoginbonusStanding == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync("ly/001.xab", "root_login_01_layout_root");
				yield return operation;
				yield return operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0xEB5A0C
					m_layoutLoginbonusStanding = instance.GetComponent<LayoutLoginBonusStanding>();
				});
				AssetBundleManager.UnloadAssetBundle("ly/001.xab", false);
				while(!m_layoutLoginbonusStanding.IsReady())
				{
					yield return null;
				}
				m_layoutLoginbonusStanding.transform.SetParent(transform, false);
				m_layoutLoginbonusStanding.gameObject.SetActive(false);
			}
			m_isLoading = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ECB84 Offset: 0x6ECB84 VA: 0x6ECB84
		// // RVA: 0xEB4C18 Offset: 0xEB4C18 VA: 0xEB4C18
		private IEnumerator LayoutLoadConditionsLoginBonus()
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xEB7E14
			if(m_layoutLoginbonusConditions == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync("ly/001.xab", "root_login_02_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0xEB5A88
					m_layoutLoginbonusConditions = instance.GetComponent<LayoutLoginBonusConditions>();
				}));
				AssetBundleManager.UnloadAssetBundle("ly/001.xab", false);
				while(!m_layoutLoginbonusConditions.IsReady())
					yield return null;
				m_layoutLoginbonusConditions.transform.SetParent(transform, false);
				m_layoutLoginbonusConditions.gameObject.SetActive(false);
			}
			//LAB_00eb814c
			m_isLoading = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ECBFC Offset: 0x6ECBFC VA: 0x6ECBFC
		// // RVA: 0xEB4CC4 Offset: 0xEB4CC4 VA: 0xEB4CC4
		private IEnumerator LayoutLoadDivaSerifWindow()
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xEB866C
			if(m_layoutDivaSerifWindow == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync("ly/032.xab", "root_cmn_balloon_layout_root");
				yield return operation;
				yield return operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0xEB5B04
					m_layoutDivaSerifWindow = instance.GetComponent<DivaSerifWindow>();
				});
				AssetBundleManager.UnloadAssetBundle("ly/032.xab", false);
				while (!m_layoutDivaSerifWindow.IsLoaded())
					yield return null;
				m_layoutDivaSerifWindow.transform.SetParent(transform, false);
				m_layoutDivaSerifWindow.gameObject.SetActive(false);
			}
			m_isLoading = true;
		}

		// // RVA: 0xEB4D70 Offset: 0xEB4D70 VA: 0xEB4D70
		private bool IsDefaultLoginBonus()
		{ 
			if(m_loginBonusMasters != null)
			{
				EPLAAEHPCDM data = m_loginBonusMasters.Find((EPLAAEHPCDM _) =>
				{
					//0xEB5C38
					return _.CKHOBDIKJFN_Type >= ANPGILOLNFK.CDOGFBNLIPG.PHABJLGFJNI_1 && _.CKHOBDIKJFN_Type < ANPGILOLNFK.CDOGFBNLIPG.LAOEGNLOJHC_5;
				});
				return data != null;
			}
			return false;
		}

		// // RVA: 0xEB4ED0 Offset: 0xEB4ED0 VA: 0xEB4ED0
		private bool IsExistConditionsLoginBonus()
		{
			if(m_loginBonusMasters != null)
			{
				EPLAAEHPCDM data = m_loginBonusMasters.Find((EPLAAEHPCDM _) =>
				{
					//0xEB5C6C
					return _.CKHOBDIKJFN_Type >= ANPGILOLNFK.CDOGFBNLIPG.LAOEGNLOJHC_5 && _.CKHOBDIKJFN_Type < ANPGILOLNFK.CDOGFBNLIPG.MKADAMIGMPO_7;
				});
				return data != null;
			}
			return false;
		}

		// RVA: 0xEB5030 Offset: 0xEB5030 VA: 0xEB5030 Slot: 12
		protected override void OnStartExitAnimation()
		{
			MenuScene.Instance.divaManager.EndControl(m_divaControl);
		}

		// RVA: 0xEB51D4 Offset: 0xEB51D4 VA: 0xEB51D4 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return true;
		}

		// RVA: 0xEB51DC Offset: 0xEB51DC VA: 0xEB51DC Slot: 16
		protected override void OnPreSetCanvas()
		{
			ResetData();
			MenuScene.Instance.divaManager.BeginControl(m_divaControl);
			PGIGNJDPCAH.MLPMNKKNFCJ();
			m_updater.Add(ConnectLoginBonus());
			GameManager.Instance.ResetViewPlayerData();
		}

		// RVA: 0xEB5454 Offset: 0xEB5454 VA: 0xEB5454 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_isConnect == false;
		}

		// RVA: 0xEB5468 Offset: 0xEB5468 VA: 0xEB5468 Slot: 18
		protected override void OnPostSetCanvas()
		{
			if(m_connectStatus == eConnectStatus.Error)
				return;
			if(IsDefaultLoginBonus())
			{
				this.StartCoroutineWatched(SetupDiva(() =>
				{
					//0xEB5B80
					m_isOpenScene = true;
				}));
				return;
			}
			m_isOpenScene = true;
		}

		// RVA: 0xEB5530 Offset: 0xEB5530 VA: 0xEB5530 Slot: 15
		protected override void OnDeleteCache()
		{
			if(m_layoutDivaSerifWindow != null)
			{
				Destroy(m_layoutDivaSerifWindow.gameObject);
				m_layoutDivaSerifWindow = null;
			}
			if(m_layoutLoginbonusStanding != null)
			{
				Destroy(m_layoutLoginbonusStanding.gameObject);
				m_layoutLoginbonusStanding = null;
			}
			if(m_layoutLoginbonusConditions != null)
			{
				Destroy(m_layoutLoginbonusConditions.gameObject);
				m_layoutLoginbonusConditions = null;
			}
			m_itemPackTextureCache.Terminated();
			m_itemPackTextureCache = null;
		}
	}
}
