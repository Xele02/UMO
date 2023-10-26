using mcrs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopPassController : MonoBehaviour
	{
		public enum Result
		{
			None = 0,
			Buy = 1,
			Close = 2,
			Error = 3,
		}
		
		public Result m_result; // 0xC
		public bool m_open_window; // 0x10
		public NHPDPKHMFEP.GGNEBJEIFCP m_plan; // 0x14
		public PopPassListWin m_layout_window; // 0x18
		public PopPassPurchaseConfirmationPopup m_layout_popup; // 0x1C
		private List<ActionButton> m_list_btn = new List<ActionButton>(); // 0x20
		private List<ScrollRect> m_list_scroll = new List<ScrollRect>(); // 0x24

		// RVA: 0xDE6FF8 Offset: 0xDE6FF8 VA: 0xDE6FF8
		public void OnDestroy()
		{
			DestroyLayout();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FFA2C Offset: 0x6FFA2C VA: 0x6FFA2C
		//// RVA: 0xDE71A0 Offset: 0xDE71A0 VA: 0xDE71A0
		public IEnumerator CoroutineOpen()
		{
			//0xDEA12C
			MenuScene.Instance.InputDisable();
			MenuScene.Instance.RaycastDisable();
			GameManager.Instance.CloseSnsNotice();
			bool t_done = false;
			bool t_err = false;
			bool t_jump_home = false;
			bool t_goto_title = false;
			NHPDPKHMFEP.HHCJCDFCLOB.FADCFLIHEPB_PreparePurchase(() =>
			{
				//0xDE8730
				t_done = true;
			}, () =>
			{
				//0xDE873C
				t_done = true;
				t_err = true;
			}, () =>
			{
				//0xDE8748
				t_jump_home = true;
				t_done = true;
			}, () =>
			{
				//0xDE8758
				t_goto_title = true;
				t_done = true;
			});
			while(!t_done)
				yield return null;
			MenuScene.Instance.InputEnable();
			MenuScene.Instance.RaycastEnable();
			if(t_jump_home)
			{
				MenuScene.Instance.Mount(TransitionUniqueId.LOGINBONUS, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				yield break;
			}
			if (t_err)
				yield break;
			if(t_goto_title)
			{
				MenuScene.Instance.GotoTitle();
				yield break;
			}
			int a = NHPDPKHMFEP.HHCJCDFCLOB.MENKMJPCELJ();
			if (a < 0)
				yield break;
			if (a == 0 || (!NHPDPKHMFEP.HHCJCDFCLOB.ENAAHAPDMCO() && NHPDPKHMFEP.HHCJCDFCLOB.DCDDAAONHHC() && NHPDPKHMFEP.HHCJCDFCLOB.NGHHJMJPEHN()))
			{
				//LAB_00deb294
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				bool t_wait = true;
				bool t_cancel = false;
				PopPassSelectSetting t_setting = new PopPassSelectSetting();
				t_setting.TitleText = bk.GetMessageByLabel("pop_pass_select_title");
				t_setting.IsCaption = true;
				t_setting.WindowSize = SizeType.Large;
				t_setting.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative } };
				t_setting.EnableNormalPlan = 0 < a;
				PopupWindowControl t_cont = PopupWindowManager.Show(t_setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
				{
					//0xDE8770
					t_wait = false;
					t_cancel = true;
				}, null, null, null);
				t_setting.OnClickLoginBonus = () =>
				{
					//0xDE877C
					t_cont.InputDisable();
					this.StartCoroutineWatched(PopupLoginBonusMonthlyPass.Show(PopupLoginBonusMonthlyPass.Type.TitleMonthlyPass, false, t_setting.Content.transform, (bool received) =>
					{
						//0xDE8914
						t_cont.InputEnable();
					}));
				};
				t_setting.OnClickNormal = () =>
				{
					//0xDE8940
					m_plan = NHPDPKHMFEP.GGNEBJEIFCP.CCAPCGPIIPF_0;
					t_cont.Close(() =>
					{
						//0xDE8A2C
						t_wait = false;
					}, null);
				};
				t_setting.OnClickSpecial = () =>
				{
					//0xDE8A38
					m_plan = NHPDPKHMFEP.GGNEBJEIFCP.AJAHGGBMOJE_1;
					t_cont.Close(() =>
					{
						//0xDE8B24
						t_wait = false;
					}, null);
				};
				while (t_wait)
					yield return null;
				if (t_cancel)
					yield break;
				MenuScene.Instance.RaycastDisable();
				DestroyLayout();
				GameObject gl = GameObject.Find("Canvas-Popup");
				m_result = Result.None;
				m_open_window = true;
				MenuScene.Instance.InputDisable();
				yield return Co.R(Co_LoadLayout(gl.transform.GetChild(0)));
				m_layout_window.Initialize(NHPDPKHMFEP.HHCJCDFCLOB.BAFEDCMCONG_GetMonthlyPassRareGetCount() < 1, m_plan);
				m_layout_window.m_cb_law_1 += CB_Law1;
				m_layout_window.m_cb_law_2 += CB_Law2;
				m_layout_window.m_cb_cancel += CB_Close;
				m_layout_window.m_cb_buy += CB_CheckBuy;
				m_layout_window.m_cb_agre += CB_Agre;
				m_layout_window.m_cb_bonus += CB_Bonus;
				m_layout_window.m_cb_detail += CB_Detail;
				m_layout_window.m_cb_contract += CB_Contract;
				m_layout_window.m_cb_privacy += CB_Privacy;
				m_layout_popup.Initialize(m_plan);
				m_list_btn.Clear();
				m_list_btn.AddRange(m_layout_window.GetComponentsInChildren<ActionButton>(true));
				m_list_scroll.Clear();
				m_list_scroll.AddRange(m_layout_window.GetComponentsInChildren<ScrollRect>(true));
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_000);
				m_layout_window.Enter();
				while (m_layout_window.IsPlayingAnim())
					yield return null;
				MenuScene.Instance.InputEnable();
				//LAB_00deae18
				while (m_result == Result.None)
					yield return null;
				MenuScene.Instance.InputDisable();
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_001);
				m_layout_window.Leave();
				while (m_layout_window.IsPlayingAnim())
					yield return null;
				if(m_result != Result.Buy)
				{
					if(m_result == Result.Error)
					{
						MenuScene.Instance.GotoTitle();
					}
				}
				else
				{
					yield return Co.R(Co_GotoHomePopupOpen());
					MenuScene.Instance.Mount(TransitionUniqueId.LOGINBONUS, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				}
				//LAB_00deaf74
				DestroyLayout();
				MenuScene.Instance.InputEnable();
				MenuScene.Instance.RaycastEnable();
				m_open_window = false;
			}
			else
			{
				yield return Co.R(PopupLoginBonusMonthlyPass.Show(PopupLoginBonusMonthlyPass.Type.TitleMonthlyPass, false, null, null));
			}
		}

		// RVA: 0xDE6FFC Offset: 0xDE6FFC VA: 0xDE6FFC
		public void DestroyLayout()
		{
			if(m_layout_popup != null)
			{
				Destroy(m_layout_popup.gameObject);
				m_layout_popup = null;
			}
			if(m_layout_window != null)
			{
				Destroy(m_layout_window.gameObject);
				m_layout_window = null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FFAA4 Offset: 0x6FFAA4 VA: 0x6FFAA4
		//// RVA: 0xDE724C Offset: 0xDE724C VA: 0xDE724C
		private IEnumerator Co_LoadLayout(Transform a_transform)
		{
			Font font; // 0x1C
			string bundleName; // 0x20
			int bundleLoadCount; // 0x24
			AssetBundleLoadLayoutOperationBase lytOp; // 0x28

			//0xDE96A4
			font = GameManager.Instance.GetSystemFont();
			bundleName = "ly/150.xab";
			bundleLoadCount = 0;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName, "root_pop_pass_window_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xDE84BC
				instance.transform.SetParent(a_transform, false);
				m_layout_window = instance.GetComponent<PopPassListWin>();
				m_layout_window.transform.SetSiblingIndex(0);
			}));
			bundleLoadCount++;
			yield return Co.R(m_layout_window.Co_LoadListContent());
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName, "root_pop_pass_agre_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xDE85F0
				instance.transform.SetParent(m_layout_window.transform, false);
				m_layout_popup = instance.GetComponent<PopPassPurchaseConfirmationPopup>();
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
			}
			while (!m_layout_window.IsReady())
				yield return null;
			while (!m_layout_popup.IsReady())
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FFB1C Offset: 0x6FFB1C VA: 0x6FFB1C
		//// RVA: 0xDE7314 Offset: 0xDE7314 VA: 0xDE7314
		//private IEnumerator Co_CheckBuyPopupOpen(Action a_buy, Action a_error, Action a_close, Action a_cancelClose) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FFB94 Offset: 0x6FFB94 VA: 0x6FFB94
		//// RVA: 0xDE7428 Offset: 0xDE7428 VA: 0xDE7428
		private IEnumerator Co_GotoHomePopupOpen()
		{
			//0xDE9288
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			bool t_wait = true;
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = "";
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			s.Text = bk.GetMessageByLabel("pop_pass_goto_home");
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0xDE8708
				t_wait = true;
			}, null, null, null);
			while (t_wait)
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FFC0C Offset: 0x6FFC0C VA: 0x6FFC0C
		//// RVA: 0xDE74BC Offset: 0xDE74BC VA: 0xDE74BC
		//private IEnumerator Co_StoreErrorPopupOpen() { }

		//// RVA: 0xDE7550 Offset: 0xDE7550 VA: 0xDE7550
		//private void EnableButton(bool a_enable) { }

		//// RVA: 0xDE76D4 Offset: 0xDE76D4 VA: 0xDE76D4
		private void CB_Law1()
		{
			TodoLogger.LogNotImplemented("CB_Law1");
		}

		//// RVA: 0xDE7848 Offset: 0xDE7848 VA: 0xDE7848
		private void CB_Law2()
		{
			TodoLogger.LogNotImplemented("CB_Law2");
		}

		//// RVA: 0xDE79BC Offset: 0xDE79BC VA: 0xDE79BC
		private void CB_Close()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_002);
			m_result = Result.Close;
		}

		//// RVA: 0xDE7A20 Offset: 0xDE7A20 VA: 0xDE7A20
		private void CB_CheckBuy()
		{
			TodoLogger.LogNotImplemented("CB_CheckBuy");
		}

		//// RVA: 0xDE7BB0 Offset: 0xDE7BB0 VA: 0xDE7BB0
		private void CB_Agre()
		{
			TodoLogger.LogNotImplemented("CB_Agre");
		}

		//// RVA: 0xDE7D3C Offset: 0xDE7D3C VA: 0xDE7D3C
		private void CB_Bonus(bool forceAvailableTopplan)
		{
			TodoLogger.LogNotImplemented("CB_Bonus");
		}

		//// RVA: 0xDE7EAC Offset: 0xDE7EAC VA: 0xDE7EAC
		private void CB_Detail()
		{
			TodoLogger.LogNotImplemented("CB_Detail");
		}

		//// RVA: 0xDE806C Offset: 0xDE806C VA: 0xDE806C
		private void CB_Contract()
		{
			TodoLogger.LogNotImplemented("CB_Contract");
		}

		//// RVA: 0xDE81E0 Offset: 0xDE81E0 VA: 0xDE81E0
		private void CB_Privacy()
		{
			TodoLogger.LogNotImplemented("CB_Privacy");
		}

		//[CompilerGeneratedAttribute] // RVA: 0x6FFC84 Offset: 0x6FFC84 VA: 0x6FFC84
		//// RVA: 0xDE8414 Offset: 0xDE8414 VA: 0xDE8414
		//private void <CB_Law1>b__16_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FFC94 Offset: 0x6FFC94 VA: 0x6FFC94
		//// RVA: 0xDE841C Offset: 0xDE841C VA: 0xDE841C
		//private void <CB_Law1>b__16_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FFCA4 Offset: 0x6FFCA4 VA: 0x6FFCA4
		//// RVA: 0xDE8428 Offset: 0xDE8428 VA: 0xDE8428
		//private void <CB_Law2>b__17_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FFCB4 Offset: 0x6FFCB4 VA: 0x6FFCB4
		//// RVA: 0xDE8430 Offset: 0xDE8430 VA: 0xDE8430
		//private void <CB_Law2>b__17_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FFCC4 Offset: 0x6FFCC4 VA: 0x6FFCC4
		//// RVA: 0xDE843C Offset: 0xDE843C VA: 0xDE843C
		//private void <CB_CheckBuy>b__19_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FFCD4 Offset: 0x6FFCD4 VA: 0x6FFCD4
		//// RVA: 0xDE8448 Offset: 0xDE8448 VA: 0xDE8448
		//private void <CB_CheckBuy>b__19_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FFCE4 Offset: 0x6FFCE4 VA: 0x6FFCE4
		//// RVA: 0xDE8454 Offset: 0xDE8454 VA: 0xDE8454
		//private void <CB_CheckBuy>b__19_2() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FFCF4 Offset: 0x6FFCF4 VA: 0x6FFCF4
		//// RVA: 0xDE845C Offset: 0xDE845C VA: 0xDE845C
		//private void <CB_CheckBuy>b__19_3() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FFD04 Offset: 0x6FFD04 VA: 0x6FFD04
		//// RVA: 0xDE8468 Offset: 0xDE8468 VA: 0xDE8468
		//private void <CB_Agre>b__20_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FFD14 Offset: 0x6FFD14 VA: 0x6FFD14
		//// RVA: 0xDE8470 Offset: 0xDE8470 VA: 0xDE8470
		//private void <CB_Agre>b__20_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FFD24 Offset: 0x6FFD24 VA: 0x6FFD24
		//// RVA: 0xDE847C Offset: 0xDE847C VA: 0xDE847C
		//private void <CB_Bonus>b__21_0(bool received) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FFD34 Offset: 0x6FFD34 VA: 0x6FFD34
		//// RVA: 0xDE8484 Offset: 0xDE8484 VA: 0xDE8484
		//private void <CB_Detail>b__22_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FFD44 Offset: 0x6FFD44 VA: 0x6FFD44
		//// RVA: 0xDE848C Offset: 0xDE848C VA: 0xDE848C
		//private void <CB_Contract>b__23_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FFD54 Offset: 0x6FFD54 VA: 0x6FFD54
		//// RVA: 0xDE8494 Offset: 0xDE8494 VA: 0xDE8494
		//private void <CB_Contract>b__23_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FFD64 Offset: 0x6FFD64 VA: 0x6FFD64
		//// RVA: 0xDE84A0 Offset: 0xDE84A0 VA: 0xDE84A0
		//private void <CB_Privacy>b__24_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FFD74 Offset: 0x6FFD74 VA: 0x6FFD74
		//// RVA: 0xDE84A8 Offset: 0xDE84A8 VA: 0xDE84A8
		//private void <CB_Privacy>b__24_1() { }
	}
}
