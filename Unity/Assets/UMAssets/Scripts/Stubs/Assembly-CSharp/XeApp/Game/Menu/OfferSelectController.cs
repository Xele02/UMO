using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class OfferSelectController : MonoBehaviour
	{
		private OfferMessageLayout m_msgLayout; // 0xC
		private OfferOrderNumLayout m_orderNumLayout; // 0x10
		private OfferSelectList m_orderListLayout; // 0x14
		private OfferSelectContent m_listContent; // 0x18
		public OfferHaveItemCheck ItemCheck; // 0x1C
		private OfferSelectDivaController m_divaController; // 0x20
		private HEFCLPGPMLK viewOfferData; // 0x24
		private List<HEFCLPGPMLK.AAOPGOGGMID> viewList; // 0x28
		private LimitTimeWatcher m_timeWatcherFirstCompOffer = new LimitTimeWatcher(); // 0x2C
		public float MOTION_WAIT_TIME = 1.1f; // 0x30
		public bool IsLayoutAssetLoad; // 0x34
		public bool IsGoToHome = true; // 0x35
		private bool IsBeginner; // 0x36
		private bool GetValkyrieFlg; // 0x37
		public bool IsOrderInduction; // 0x38
		private bool IsSaveSuccess; // 0x39
		public IEnumerator OnEndAllDoneAction; // 0x3C

		// RVA: 0x1864F6C Offset: 0x1864F6C VA: 0x1864F6C
		private void Start()
		{
			return;
		}

		// RVA: 0x1864F70 Offset: 0x1864F70 VA: 0x1864F70
		private void Update()
		{
			m_timeWatcherFirstCompOffer.Update();
		}

		// RVA: 0x1864F9C Offset: 0x1864F9C VA: 0x1864F9C
		public void DestroyScene()
		{
			m_orderListLayout.ReleaseBadge();
			m_orderListLayout.SetSelectTab();
			m_orderListLayout.DestroyScene();
		}

		// RVA: 0x186500C Offset: 0x186500C VA: 0x186500C
		public void DestroyLayout()
		{
			if(m_msgLayout != null)
			{
				DestroyImmediate(m_msgLayout.gameObject);
			}
			if (m_orderNumLayout != null)
			{
				DestroyImmediate(m_orderNumLayout.gameObject);
			}
			if(m_orderListLayout != null)
			{
				DestroyImmediate(m_orderListLayout.gameObject);
			}
			if(m_listContent != null)
			{
				DestroyImmediate(m_listContent.gameObject);
			}
			m_msgLayout = null;
			m_orderNumLayout = null;
			m_orderListLayout = null;
			m_listContent = null;
		}

		// RVA: 0x18652F4 Offset: 0x18652F4 VA: 0x18652F4
		public void EixtScene()
		{
			m_orderListLayout.IsExitBefore = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FA8DC Offset: 0x6FA8DC VA: 0x6FA8DC
		// RVA: 0x186531C Offset: 0x186531C VA: 0x186531C
		public IEnumerator Co_GoToGetValkyrie(Action ConfirmTransisiton)
		{
			//0x186F694
			int VfId = 0;
			GetValkyrieFlg = KDHGBOOECKC.HHCJCDFCLOB.AHKAIKMNKJL();
			if (viewOfferData.OHILPCDFKCH() || GetValkyrieFlg)
				yield break;
			VfId = KDHGBOOECKC.HHCJCDFCLOB.JMGECJKIJJF();
			if (VfId == 0)
				yield break;
			if (ConfirmTransisiton != null)
				ConfirmTransisiton();
			GameManager.Instance.CloseSnsNotice();
			MenuScene.Instance.RaycastDisable();
			yield return null;
			bool IsSaveDone = false;
			this.StartCoroutineWatched(Co_Save(() =>
			{
				//0x186B6CC
				IsSaveDone = true;
			}, () =>
			{
				//0x186B088
				return;
			}));
			while (!IsSaveDone)
				yield return null;
			yield return Co.R(KDHGBOOECKC.HHCJCDFCLOB.FMGMIKPJNKG_Co_wait(1, false, null));
			IsGoToHome = false;
			JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList.Where((JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo _) =>
			{
				//0x186B6D8
				return _.GPPEFLKGGGJ_Id == VfId;
			}).First();
			int attr = 1;
			if (valk != null)
				attr = valk.AIHCEGFANAM_Sa;
			UnlockFadeManager.Create();
			yield return Co.R(UnlockFadeManager.Instance.Co_LoadFadeEffect(attr));
			UnlockFadeManager.Instance.GetEffect().Enter();
			MenuScene.Instance.RaycastEnable();
			UnlockValkyrieArgs arg = new UnlockValkyrieArgs();
			arg.valkyrie_id = VfId;
			MenuScene.Instance.Mount(TransitionUniqueId.OFFERSELECT_UNLOCKVALKYRIE, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// RVA: 0x18653E4 Offset: 0x18653E4 VA: 0x18653E4
		public void initialize()
		{
			ItemCheck.transform.SetParent(transform.parent);
			viewOfferData = new HEFCLPGPMLK();
			viewOfferData.EMAEAEAKDLJ();
			IsBeginner = viewOfferData.OHILPCDFKCH();
			GetValkyrieFlg = false;
			if(!IsBeginner)
			{
				GetValkyrieFlg = !KDHGBOOECKC.HHCJCDFCLOB.AHKAIKMNKJL();
				IsBeginner = GetValkyrieFlg;
			}
			CheckAllRecvButtonState();
			m_orderListLayout.settingTab();
			if(!IsBeginner)
			{
				if(m_orderListLayout.SelectTab == OfferSelectList.OfferSelectTab.DebutTab)
				{
					m_orderListLayout.SelectTab = OfferSelectList.OfferSelectTab.DaylyTab;
				}
				SetViewList(m_orderListLayout.SelectTab, false);
			}
			else
			{
				SetViewList(OfferSelectList.OfferSelectTab.DebutTab, false);
			}
			m_orderNumLayout.NuberSetting(viewOfferData.JGFHJPGJJHP(), viewOfferData.NCAPNMMJCLF());
			m_orderNumLayout.UpDownButtonAction(() =>
			{
				//0x186AAD0
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				bool b = KDHGBOOECKC.HHCJCDFCLOB.LBKNBKPBAPJ_IsSortDesc();
				KDHGBOOECKC.HHCJCDFCLOB.NCGGBBELDFI(!b);
				m_orderNumLayout.m_sortOrder = !b;
				m_orderNumLayout.UpdateOrderFont();
				SetViewList(m_orderListLayout.SelectTab, false);
				m_orderListLayout.SetupList(viewList.Count, true);
			});
			m_orderNumLayout.UpDown_ButtonHide(IsBeginner);
			m_orderNumLayout.AllGetButtonAction(() =>
			{
				//0x186AAD4
				this.StartCoroutineWatched(Co_OnAllDoneActionButton(null));
			});
			m_orderNumLayout.AllGet_ButtonHide(IsBeginner);
			if (!IsBeginner)
				m_orderNumLayout.m_orderLayout.enabled = true;
			else
				m_orderNumLayout.m_orderLayout.enabled = false;
			m_orderListLayout.Initialize();
			m_orderListLayout.List.Apply();
			m_orderListLayout.List.SetContentEscapeMode(true);
			m_msgLayout.SettingText(viewOfferData.BEGJBMHBGPL());
			m_orderListLayout.SetupList(viewList.Count, true);
			m_orderListLayout.SetOperationTabClickCallback((int index) =>
			{
				//0x186AAFC
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				SetViewList(index, false);
				m_orderListLayout.SetupList(viewList.Count, true);
			});
			m_orderListLayout.SetStartListUpdateAct(CheckAllRecvButtonState);
			m_timeWatcherFirstCompOffer.onEndCallback = (long time) =>
			{
				//0x186AB00
				if (IsBeginner)
					return;
				m_orderNumLayout.AllGet_ButtonDisable(false);
			};
		}

		// RVA: 0x1865DE0 Offset: 0x1865DE0 VA: 0x1865DE0
		public void SetOrderButton(Action order, Action progress, Action complete)
		{
			m_orderListLayout.SetContentButtonCallback((int index) =>
			{
				//0x186B71C
				OnOrdersActionButton(index, order);
			}, (int index) =>
			{
				//0x186B754
				OnProgressActionButton(index, progress);
			}, (int index) =>
			{
				//0x186B78C
				OnDoneActionButton(index, complete);
			}, () =>
			{
				//0x186B7C4
				ItemCheck.ButtonDisable();
			}, () =>
			{
				//0x186B800
				ItemCheck.ButtonEnable();
			});
		}

		//// RVA: 0x1865FF0 Offset: 0x1865FF0 VA: 0x1865FF0
		//private void UpDownButtonAction() { }

		//// RVA: 0x1865A28 Offset: 0x1865A28 VA: 0x1865A28
		private void CheckAllRecvButtonState()
		{
			if (IsBeginner)
				return;
			m_orderNumLayout.AllGet_ButtonDisable(GetAchivedOfferList().Count == 0);
		}

		//// RVA: 0x18665EC Offset: 0x18665EC VA: 0x18665EC
		//public void layoutAllEnter() { }

		// RVA: 0x1866670 Offset: 0x1866670 VA: 0x1866670
		public void layoutAllLeave()
		{
			m_orderNumLayout.Leave();
			m_orderListLayout.Leave();
			m_msgLayout.Leave();
			ItemCheck.Leave();
		}

		// RVA: 0x18666F4 Offset: 0x18666F4 VA: 0x18666F4
		public bool IsAllLayoutIsPlaying()
		{
			return m_orderNumLayout.IsPlaying() || m_orderListLayout.IsPlaying();
		}

		//// RVA: 0x186617C Offset: 0x186617C VA: 0x186617C
		private List<HEFCLPGPMLK.AAOPGOGGMID> GetAchivedOfferList()
		{
			List<HEFCLPGPMLK.AAOPGOGGMID> res = new List<HEFCLPGPMLK.AAOPGOGGMID>();
			res.AddRange(viewOfferData.CAGIOJAAGGP.FindAll((HEFCLPGPMLK.AAOPGOGGMID x) =>
			{
				//0x186B08C
				return x.CMCKNKKCNDK_Status == BOPFPIHGJMD.IGHPDAGKIKO.FJGFAPKLLCL_3_Achieved;
			}));
			res.AddRange(viewOfferData.KPMDLOBOEEM.FindAll((HEFCLPGPMLK.AAOPGOGGMID x) =>
			{
				//0x186B0BC
				return x.CMCKNKKCNDK_Status == BOPFPIHGJMD.IGHPDAGKIKO.FJGFAPKLLCL_3_Achieved;
			}));
			res.AddRange(viewOfferData.NLKBPLNCPGG.FindAll((HEFCLPGPMLK.AAOPGOGGMID x) =>
			{
				//0x186B0EC
				return x.CMCKNKKCNDK_Status == BOPFPIHGJMD.IGHPDAGKIKO.FJGFAPKLLCL_3_Achieved;
			}));
			return res;
		}

		//// RVA: 0x1866748 Offset: 0x1866748 VA: 0x1866748
		public void OnOrdersActionButton(int index, Action act)
		{
			GameManager.Instance.CloseSnsNotice();
			MenuScene.Instance.RaycastDisable();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			if(!CheckChengeDate())
			{
				if (act != null)
					act();
				ItemCheck.ButtonDisable();
				this.StartCoroutineWatched(Co_serverTimeUpdateWait(() =>
				{
					//0x186B83C
					ItemCheck.ButtonEnable();
					if(OnClickOperationTimeCheck(index))
					{
						if(OnClickSortieValkyrieCheck())
						{
							m_orderListLayout.IsExitBefore = true;
							m_divaController.CrossChangeLeaveMotion(() =>
							{
								//0x186BA2C
								this.StartCoroutineWatched(Co_GotoSelectFormation(index));
							});
							IsGoToHome = false;
							return;
						}
					}
					MenuScene.Instance.RaycastEnable();
				}));
			}
			else
			{
				MenuScene.Instance.RaycastEnable();
			}
		}

		//// RVA: 0x1866C00 Offset: 0x1866C00 VA: 0x1866C00
		private bool OnClickSortieValkyrieCheck()
		{
			int a1 = viewOfferData.JGFHJPGJJHP();
			int a2 = viewOfferData.NCAPNMMJCLF();
			if (a1 - a2 < 1)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				TextPopupSetting s = new TextPopupSetting();
				s.TitleText = bk.GetMessageByLabel("");
				s.Text = bk.GetMessageByLabel("offer_all_platoon_sortie_pop_text");
				s.IsCaption = false;
				s.WindowSize = SizeType.Small;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				PopupWindowManager.Show(s, null, null, null, null);
			}
			return a1 != a2 && a1 - a2 > -1;
		}

		//// RVA: 0x1866F2C Offset: 0x1866F2C VA: 0x1866F2C
		private bool OnClickOperationTimeCheck(int index)
		{
			HEFCLPGPMLK.AAOPGOGGMID data = viewList[index];
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string k;
			if (data.FGHGMHPNEMG_Category == BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva)
			{
				if (data.LOAEGNGKFNF_Expr != NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime())
				{
					return true;
				}
				KDHGBOOECKC.HHCJCDFCLOB.EGNCJPMPMDC_ClearFlag(BOPFPIHGJMD.GNGGLPCONLM.MGPHIBLKNMO_8 | BOPFPIHGJMD.GNGGLPCONLM.BCMLFJPLKAM_4); // 12
				k = "offer_select_operation_ended_pop_text";
			}
			else if (data.FGHGMHPNEMG_Category == BOPFPIHGJMD.MLBMHDCCGHI.HEFPAOLDHCK_1_Day)
			{
				if (!KDHGBOOECKC.HHCJCDFCLOB.DJMICICGLLG())
					return true;
				KDHGBOOECKC.HHCJCDFCLOB.JLKENFELMPM_SetFlag(BOPFPIHGJMD.GNGGLPCONLM.OCKIDPJNNBP_1);
				k = "popup_update_operation_text";
			}
			else return true;
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = "";
			s.Text = bk.GetMessageByLabel(k);
			s.IsCaption = false;
			s.WindowSize = SizeType.Small;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x186AB38
				if (label != PopupButton.ButtonLabel.Ok)
					return;
				if(m_msgLayout != null)
				{
					m_msgLayout.SettingText(viewOfferData.BEGJBMHBGPL());
				}
				SetViewList(m_orderListLayout.SelectTab, true);
				if (m_orderListLayout != null)
				{
					m_orderListLayout.InitializeBadge();
					m_orderListLayout.StartListUpdate();
				}
			}, null, null, null);
			return false;
		}

		//// RVA: 0x1867418 Offset: 0x1867418 VA: 0x1867418
		//public void OnProgressActionButton(int index, Action act) { }

		//// RVA: 0x18677E4 Offset: 0x18677E4 VA: 0x18677E4
		//private ButtonInfo[] buttonInfo(int index) { }

		//// RVA: 0x1867AA8 Offset: 0x1867AA8 VA: 0x1867AA8
		//private void OnClickofferCancel(int index) { }

		//// RVA: 0x1867E98 Offset: 0x1867E98 VA: 0x1867E98
		//private void OnClockFastComp(int index) { }

		//// RVA: 0x18689C0 Offset: 0x18689C0 VA: 0x18689C0
		//private bool FastDoneLimitOverCheck() { }

		//// RVA: 0x1868CC4 Offset: 0x1868CC4 VA: 0x1868CC4
		//private bool FastDoneTimeCheck(int index) { }

		//// RVA: 0x1868E10 Offset: 0x1868E10 VA: 0x1868E10
		//private void NoFastPopup() { }

		//// RVA: 0x18690D8 Offset: 0x18690D8 VA: 0x18690D8
		//private void NoCancelPopup() { }

		//// RVA: 0x18693A0 Offset: 0x18693A0 VA: 0x18693A0
		//public void OnDoneActionButton(int index, Action act) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FA954 Offset: 0x6FA954 VA: 0x6FA954
		//// RVA: 0x18695E0 Offset: 0x18695E0 VA: 0x18695E0
		//public IEnumerator Co_OnAllDoneActionButton(Action act) { }

		//// RVA: 0x1866BDC Offset: 0x1866BDC VA: 0x1866BDC
		//public void serverTimeUpdateWait(Action SuccessAction) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FA9CC Offset: 0x6FA9CC VA: 0x6FA9CC
		//// RVA: 0x1869684 Offset: 0x1869684 VA: 0x1869684
		private IEnumerator Co_serverTimeUpdateWait(Action SuccessAction)
		{
			//0x1702AB0
			MenuScene.Instance.RaycastDisable();
			bool IsDone = false;
			bool IsError = false;
			NKGJPJPHLIF.HHCJCDFCLOB.CADNBFCHAKM_GetToken(() =>
			{
				//0x186D98C
				IsDone = true;
			}, () =>
			{
				//0x186D998
				IsDone = true;
				IsError = true;
			});
			while (!IsDone)
				yield return null;
			if(!IsError)
			{
				MenuScene.Instance.RaycastEnable();
				SuccessAction();
			}
			else
			{
				MenuScene.Instance.GotoTitle();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FAA44 Offset: 0x6FAA44 VA: 0x6FAA44
		//// RVA: 0x186970C Offset: 0x186970C VA: 0x186970C
		private IEnumerator Co_Save(Action saveEndCallback, Action saveErrorCallback)
		{
			//0x1701DBC
			bool IsSaveing = true;
			if (m_divaController != null)
				m_divaController.IsAloneMotion = false;
			MenuScene.Instance.InputDisable();
			ItemCheck.ButtonDisable();
			m_orderNumLayout.AllGetButtonActDisable();
			Debug.Log("<color=cyan>Co_Save request</color>");
			if(!CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0x186D9AC
				Debug.Log("<color=cyan>Co_Save done</color>");
				saveEndCallback();
				IsSaveing = false;
				if (m_divaController != null)
					m_divaController.IsAloneMotion = true;
				ItemCheck.ButtonEnable();
				m_orderNumLayout.AllGetButtonActEnable();
			}, () =>
			{
				//0x186DB50
				saveErrorCallback();
				if(m_divaController != null)
				{
					m_divaController.DivaStopVoice();
				}
				m_divaController.IsAloneMotion = false;
				ItemCheck.ButtonEnable();
				m_orderNumLayout.AllGetButtonActEnable();
				MenuScene.Instance.GotoTitle();
			}, null))
			{
				Debug.Log("<color=red>Co_Save skipped</color>");
			}
			while (IsSaveing)
				yield return null;
			m_divaController.IsAloneMotion = true;
			MenuScene.Instance.InputEnable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FAABC Offset: 0x6FAABC VA: 0x6FAABC
		//// RVA: 0x18697C8 Offset: 0x18697C8 VA: 0x18697C8
		//private IEnumerator Co_WaitSave(Action SaveEnd) { }

		//// RVA: 0x18669C8 Offset: 0x18669C8 VA: 0x18669C8
		private bool CheckChengeDate()
		{
			return PGIGNJDPCAH.MNANNMDBHMP(() =>
			{
				//0x186B588
				MenuScene.Instance.GotoLoginBonus();
			}, () =>
			{
				//0x186B624
				MenuScene.Instance.GotoTitle();
			});
		}

		//// RVA: 0x186986C Offset: 0x186986C VA: 0x186986C
		//private void TabClickCallBack(int tabstate) { }

		// RVA: 0x1869970 Offset: 0x1869970 VA: 0x1869970
		public void StartTutorial()
		{
			this.StartCoroutineWatched(Co_tuto());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FAB34 Offset: 0x6FAB34 VA: 0x6FAB34
		//// RVA: 0x1869994 Offset: 0x1869994 VA: 0x1869994
		public IEnumerator Co_tuto()
		{
			//0x1702E8C
			IsOrderInduction = true;
			//CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer
			ButtonBase[] btns = m_orderListLayout.m_scrollList.ScrollObjects[0].GetComponentsInChildren<ButtonBase>();
			ButtonBase b = null;
			for (int i = 0; i < btns.Length; i++)
			{
				if (btns[i].name == "sw_s_v_btn_03_anim (AbsoluteLayout)")
					b = btns[i];
			}
			if(b != null)
			{
				yield return this.StartCoroutineWatched(TutorialProc.Co_OffeReleaseTutorial(InputLimitButton.Delegate, b, () =>
				{
					//0x186B6C0
					return;
				}, BasicTutorialMessageId.Id_OfferOrder, true, null));
			}
			IsOrderInduction = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FABAC Offset: 0x6FABAC VA: 0x6FABAC
		//// RVA: 0x1869A1C Offset: 0x1869A1C VA: 0x1869A1C
		//private IEnumerator Co_GotoSelectFormation(int index) { }

		//// RVA: 0x1865AE0 Offset: 0x1865AE0 VA: 0x1865AE0
		public void SetViewList(OfferSelectList.OfferSelectTab tab, bool IsListUpdata = false)
		{
			HEFCLPGPMLK.AAOPGOGGMID d = viewOfferData.HHPEMLOLJIH();
			m_timeWatcherFirstCompOffer.WatchStop();
			switch(tab)
			{
				case OfferSelectList.OfferSelectTab.DivaTab:
					viewList = viewOfferData.PDFOBMKIKKJ(BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva, IsListUpdata, KDHGBOOECKC.HHCJCDFCLOB.LBKNBKPBAPJ_IsSortDesc());
					if (KDHGBOOECKC.HHCJCDFCLOB != null)
						KDHGBOOECKC.HHCJCDFCLOB.BFJFAIIAMMO(BOPFPIHGJMD.FDDGIANLNAD.BCMLFJPLKAM_1, true);
					if (d == null || d.FGHGMHPNEMG_Category == BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva)
						break;
					m_timeWatcherFirstCompOffer.WatchStart(d.PCCFAKEOBIC_EndDate, false);
					break;
				case OfferSelectList.OfferSelectTab.WeeklyTab:
					viewList = viewOfferData.PDFOBMKIKKJ(BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week, IsListUpdata, KDHGBOOECKC.HHCJCDFCLOB.LBKNBKPBAPJ_IsSortDesc());
					if (d == null || d.FGHGMHPNEMG_Category == BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week)
						break;
					m_timeWatcherFirstCompOffer.WatchStart(d.PCCFAKEOBIC_EndDate, false);
					break;
				case OfferSelectList.OfferSelectTab.DaylyTab:
					viewList = viewOfferData.PDFOBMKIKKJ(BOPFPIHGJMD.MLBMHDCCGHI.HEFPAOLDHCK_1_Day, IsListUpdata, KDHGBOOECKC.HHCJCDFCLOB.LBKNBKPBAPJ_IsSortDesc());
					if (d == null || d.FGHGMHPNEMG_Category == BOPFPIHGJMD.MLBMHDCCGHI.HEFPAOLDHCK_1_Day)
						break;
					m_timeWatcherFirstCompOffer.WatchStart(d.PCCFAKEOBIC_EndDate, false);
					break;
				case OfferSelectList.OfferSelectTab.DebutTab:
					viewList = viewOfferData.PDFOBMKIKKJ(BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut, IsListUpdata, KDHGBOOECKC.HHCJCDFCLOB.LBKNBKPBAPJ_IsSortDesc());
					m_timeWatcherFirstCompOffer.WatchStart(d.PCCFAKEOBIC_EndDate, false);
					break;
			}
			m_orderListLayout.SetView(viewList, viewOfferData);
			m_orderListLayout.NonListTextSetting(viewList.Count < 1);
		}

		// RVA: 0x1869AE4 Offset: 0x1869AE4 VA: 0x1869AE4
		public void ShowRelesePlatoonPopup(Action OnClick)
		{
			PopupOfferUnclokPlattonSetting s = new PopupOfferUnclokPlattonSetting();
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			s.WindowSize = 0;
			s.IsCaption = false;
			s.nextPlatoonNum = KDHGBOOECKC.HHCJCDFCLOB.JGFHJPGJJHP();
			s.ReleasePlatoonNum = viewOfferData.JGFHJPGJJHP() - 1;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x186DD30
				OnClick();
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.MKFNKOLCBOP_UpdateVFpUnlock(s.nextPlatoonNum);
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			}, null, null, null);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FAC24 Offset: 0x6FAC24 VA: 0x6FAC24
		// RVA: 0x1869DC8 Offset: 0x1869DC8 VA: 0x1869DC8
		public IEnumerator Co_dailyOperationDiff()
		{
			//0x17026C8
			int maxDiff = KDHGBOOECKC.HHCJCDFCLOB.BCACCAGCPCO();
			bool closePopup = false;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.CHFMCFNEFEO_LastVOP_DailyLv < maxDiff)
			{
				ShowDiffPopup(GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.CHFMCFNEFEO_LastVOP_DailyLv, maxDiff, bk.GetMessageByLabel("offer_daily_offer_levelup_text"), () =>
				{
					//0x186DEB0
					closePopup = true;
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.AHAECLAKMIB_UpdateDailyLv(maxDiff);
					GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				});
			}
			else
			{
				closePopup = true;
			}
			while (!closePopup)
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FAC9C Offset: 0x6FAC9C VA: 0x6FAC9C
		// RVA: 0x1869E50 Offset: 0x1869E50 VA: 0x1869E50
		public IEnumerator Co_DivaOperationDiff()
		{
			ILDKBCLAFPB.ABEMIFANBMF_Offer saveData; // 0x1C
			BBHNACPENDM_ServerSaveData pd; // 0x20
			string text; // 0x24
			int i; // 0x28

			//0x186EFE0
			bool closePopup = false;
			saveData = GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer;
			pd = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
			int LvMax = 0;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			text = bk.GetMessageByLabel("offer_diva_offer_levelup_text");
			for(i = 0; i < pd.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
			{
				int Id = i + 1;
				LvMax = KDHGBOOECKC.HHCJCDFCLOB.HFLNFKFGEJH(Id);
				closePopup = false;
				if(saveData.LDIBGNOLFAB_GetDivaLv(Id) < LvMax)
				{
					ShowDiffPopup(saveData.LDIBGNOLFAB_GetDivaLv(Id), LvMax, string.Format(text, MessageManager.Instance.GetMessage("master", string.Format("diva_s_{0:D2}", Id))), () =>
					{
						//0x186E00C
						closePopup = true;
						GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.AHOBDLOOLHD(Id, LvMax);
						GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
					});
					while (!closePopup)
						yield return null;
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FAD14 Offset: 0x6FAD14 VA: 0x6FAD14
		// RVA: 0x1869EFC Offset: 0x1869EFC VA: 0x1869EFC
		public IEnumerator Co_PlatoonRelease()
		{
			//0x1701A9C
			int prePlatoon = KDHGBOOECKC.HHCJCDFCLOB.JGFHJPGJJHP();
			int diff = prePlatoon - GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.GHKKEFGDIBC_LastVFP_Unlock;
			bool closePopup = false;
			if (diff < 1)
				closePopup = true;
			else
			{
				ShowPlatoonPopup(prePlatoon, diff, () =>
				{
					//0x186E190
					closePopup = true;
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.MKFNKOLCBOP_UpdateVFpUnlock(KDHGBOOECKC.HHCJCDFCLOB.JGFHJPGJJHP());
					GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				});
			}
			while (!closePopup)
				yield return null;
		}

		//// RVA: 0x1869F84 Offset: 0x1869F84 VA: 0x1869F84
		private void ShowDiffPopup(int preLv, int nextLv, string label, Action act)
		{
			PopupOfferUnclokDiffSetting s = new PopupOfferUnclokDiffSetting();
			s.TitleText = "";
			s.IsCaption = false;
			s.popupMsg = label;
			s.preDiff = preLv;
			s.nextDiff = nextLv;
			s.WindowSize = 0;
			s.ButtonInfo = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType typ, PopupButton.ButtonLabel lbl) =>
			{
				//0x186E304
				act();
			}, null, null, null);
		}

		//// RVA: 0x186A27C Offset: 0x186A27C VA: 0x186A27C
		private void ShowPlatoonPopup(int prePlatoon, int nextPlatoon, Action act)
		{
			PopupOfferUnclokPlattonSetting s = new PopupOfferUnclokPlattonSetting();
			s.IsCaption = false;
			s.nextPlatoonNum = prePlatoon;
			s.ReleasePlatoonNum = nextPlatoon;
			s.WindowSize = 0;
			s.ButtonInfo = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType typ, PopupButton.ButtonLabel lbl) =>
			{
				//0x186E330
				act();
			}, null, null, null);
		}

		// RVA: 0x186A4D0 Offset: 0x186A4D0 VA: 0x186A4D0
		public void AssetLoadStart()
		{
			this.StartCoroutineWatched(AllAssetLoad());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FAD8C Offset: 0x6FAD8C VA: 0x6FAD8C
		//// RVA: 0x186A4F4 Offset: 0x186A4F4 VA: 0x186A4F4
		private IEnumerator AllAssetLoad()
		{
			string bundleName; // 0x14
			Font systemFont; // 0x18

			//0x186EB08
			IsLayoutAssetLoad = false;
			bundleName = "ly/143.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co.R(Co_LoadAssetsMessageLayout(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsOrderNumLayout(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsOrderListLayout(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsLayoutOrderListItem(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsItemButtonLayout(bundleName, systemFont));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			while (!m_msgLayout.IsLoaded())
				yield return null;
			while (!m_orderNumLayout.IsLoaded())
				yield return null;
			while (!m_orderListLayout.IsLoaded())
				yield return null;
			while(!ItemCheck.IsLoaded())
				yield return null;
			IsLayoutAssetLoad = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FAE04 Offset: 0x6FAE04 VA: 0x6FAE04
		//// RVA: 0x186A5A0 Offset: 0x186A5A0 VA: 0x186A5A0
		private IEnumerator Co_LoadAssetsItemButtonLayout(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x16FE19C
			if(ItemCheck == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_vfo_item_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x186ACCC
					instance.transform.SetParent(transform, false);
					ItemCheck = instance.GetComponent<OfferHaveItemCheck>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FAE7C Offset: 0x6FAE7C VA: 0x6FAE7C
		//// RVA: 0x186A65C Offset: 0x186A65C VA: 0x186A65C
		private IEnumerator Co_LoadAssetsOrderNumLayout(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x16FF364
			if(m_orderNumLayout == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_vfo_order_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x186AD9C
					instance.transform.SetParent(transform, false);
					m_orderNumLayout = instance.GetComponent<OfferOrderNumLayout>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
			}
			else
			{
				m_orderNumLayout.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FAEF4 Offset: 0x6FAEF4 VA: 0x6FAEF4
		//// RVA: 0x186A718 Offset: 0x186A718 VA: 0x186A718
		private IEnumerator Co_LoadAssetsMessageLayout(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;
			//0x16FECFC
			if(m_msgLayout == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_vfo_mes_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x186AE6C
					instance.transform.SetParent(transform, false);
					m_msgLayout = instance.GetComponent<OfferMessageLayout>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_msgLayout.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FAF6C Offset: 0x6FAF6C VA: 0x6FAF6C
		//// RVA: 0x186A7D4 Offset: 0x186A7D4 VA: 0x186A7D4
		private IEnumerator Co_LoadAssetsOrderListLayout(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x16FF030
			if(m_orderListLayout == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_vfo_window_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x186AF3C
					instance.transform.SetParent(transform, false);
					m_orderListLayout = instance.GetComponent<OfferSelectList>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_orderListLayout.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FAFE4 Offset: 0x6FAFE4 VA: 0x6FAFE4
		//// RVA: 0x186A890 Offset: 0x186A890 VA: 0x186A890
		private IEnumerator Co_LoadAssetsLayoutOrderListItem(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation; // 0x20
			int poolSize; // 0x24
			int i; // 0x28

			//0x16FE470
			if(m_orderListLayout.m_scrollList.ScrollObjects.Count < 1)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_vfo_list_layout_root");
				yield return operation;
				List<SwapScrollListContent> contentList = new List<SwapScrollListContent>();
				LayoutUGUIRuntime baseRuntime = null;
				poolSize = m_orderListLayout.m_scrollList.ScrollObjectCount;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x186E364
					baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
					baseRuntime.name = baseRuntime.name.Replace("(Clone)", "_00");
					instance.transform.SetParent(transform, false);
					contentList.Add(instance.GetComponent<OfferSelectContent>());
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				for(i = 1; i < poolSize; i++)
				{
					LayoutUGUIRuntime r = Instantiate(baseRuntime);
					r.name = baseRuntime.name.Replace("00", i.ToString("D2"));
					r.IsLayoutAutoLoad = false;
					r.Layout = baseRuntime.Layout.DeepClone();
					r.UvMan = baseRuntime.UvMan;
					r.LoadLayout();
					contentList.Add(r.GetComponent<OfferSelectContent>());
				}
				for(i = 0; i < contentList.Count; i++)
				{
					while (!contentList[i].IsLoaded())
						yield return null;
					m_orderListLayout.m_scrollList.AddScrollObject(contentList[i]);
				}
				operation = null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FB05C Offset: 0x6FB05C VA: 0x6FB05C
		//// RVA: 0x186A94C Offset: 0x186A94C VA: 0x186A94C
		//private IEnumerator Co_LoadAssetsAllDoneLayout(string bundleName, Font font, List<HEFCLPGPMLK.AAOPGOGGMID> compOfferInfo, Action<OfferAllRecvBgLayout, OfferAllRecvBgButton, OfferAllRecvConnectLayout, List<OfferAllRecvContentLayout>> loadSuccess) { }

		// RVA: 0x186AA38 Offset: 0x186AA38 VA: 0x186AA38
		public void SetDivaController(OfferSelectDivaController controller)
		{
			m_divaController = controller;
		}
	}
}
