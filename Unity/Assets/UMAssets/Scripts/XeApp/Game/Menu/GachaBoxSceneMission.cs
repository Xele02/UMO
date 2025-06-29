using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class GachaBoxSceneMission : GachaBoxScene
	{
		private HGFPAFPGIKG.FHOKKDKGGJI m_reactionTiming; // 0x6C
		private List<HGFPAFPGIKG.LBEPCOMCHNE> m_reactionList = new List<HGFPAFPGIKG.LBEPCOMCHNE>(); // 0x70
		private bool m_isBoxFull; // 0x74
		private int m_prevBoxId; // 0x78
		private int m_crntBoxId; // 0x7C
		private HGFPAFPGIKG.CMEDMHFOFAH m_prevPickup; // 0x80
		private HGFPAFPGIKG.CMEDMHFOFAH m_crntPickup; // 0x84

		protected override string BundleName { get { return "ly/118.xab"; } } //0xEE0890
		protected override string PopupText_BoxEmpty { get { return "popup_event_gacha_box_text_13"; } } //0xEE08EC

		// RVA: 0xEE0948 Offset: 0xEE0948 VA: 0xEE0948 Slot: 16
		protected override void OnPreSetCanvas()
		{
			GachaBoxArgs arg = Args as GachaBoxArgs;
			(m_layoutMain as LayoutGachaBoxMission).OnClickButtonNext = () =>
			{
				//0xEE1CA0
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
				this.StartCoroutineWatched(Co_ConfirmNextBox());
			};
			m_reactionTiming = HGFPAFPGIKG.FHOKKDKGGJI.KENKGHLELHP_1;
			UpdateLayout(null);
			UpdateReaction();
		}

		// RVA: 0xEE0BCC Offset: 0xEE0BCC VA: 0xEE0BCC Slot: 18
		protected override void OnPostSetCanvas()
		{
			base.OnPostSetCanvas();
		}

		// RVA: 0xEE0BD0 Offset: 0xEE0BD0 VA: 0xEE0BD0 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0xEE0C70 Offset: 0xEE0C70 VA: 0xEE0C70 Slot: 20
		protected override bool OnBgmStart()
		{
			SoundManager.Instance.bgmPlayer.Play(BgmPlayer.MENU_BGM_ID_BASE, 1);
			return true;
		}

		// RVA: 0xEE0D50 Offset: 0xEE0D50 VA: 0xEE0D50 Slot: 33
		protected override void StartQualitySettings()
		{
			return;
		}

		// RVA: 0xEE0D54 Offset: 0xEE0D54 VA: 0xEE0D54 Slot: 34
		protected override void EndQualitySettings()
		{
			return;
		}

		// RVA: 0xEE0D58 Offset: 0xEE0D58 VA: 0xEE0D58 Slot: 35
		protected override void OnBoxDetailPopup()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			PopupGachaBox2DetailSetting s = new PopupGachaBox2DetailSetting();
			s.View = m_view;
			s.OnSelectCallback = OnSelectItem;
			s.TitleText = "";
			s.WindowSize = SizeType.Large;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			bool done = false;
			PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xEE1F30
				return;
			}, null, null, null, true, true, false, null, () =>
			{
				//0xEE1F90
				done = true;
			});
		}

		// RVA: 0xEE118C Offset: 0xEE118C VA: 0xEE118C Slot: 36
		protected override void OnDrawBoxSingle()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(!CloseTimeCheck("popup_event_end_text_1"))
			{
				this.StartCoroutineWatched(Co_ConfirmDrawBox(1));
			}
		}

		// RVA: 0xEE1308 Offset: 0xEE1308 VA: 0xEE1308 Slot: 37
		protected override void OnDrawBoxMulti(int num)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(!CloseTimeCheck("popup_event_end_text_1"))
			{
				this.StartCoroutineWatched(Co_ConfirmDrawBox(num));
			}
		}

		// RVA: 0xEE13E0 Offset: 0xEE13E0 VA: 0xEE13E0 Slot: 39
		protected override void UpdateLayout(HGFPAFPGIKG view)
		{
			if(view == null)
			{
				view = new HGFPAFPGIKG(m_eventId);
			}
			m_view = view;
			m_layoutMain.Setup(m_eventId, view);
			m_prevBoxId = m_crntBoxId;
			m_crntBoxId = m_view.IMMDGJAOPCD;
			m_prevPickup = m_crntPickup;
			m_crntPickup = FindPickup(m_view);
			if(m_crntPickup != null)
			{
				m_reactionList = m_view.MHCOADJDLLF(m_reactionTiming, HGFPAFPGIKG.FBGKMBHEOBC.HJNNKCMLGFL_0, HGFPAFPGIKG.GDEJHABHLFH.HJNNKCMLGFL_0).FindAll(CheckReaction);
				m_isBoxFull = m_view.JALHJAPAFLK_BoxCurrent == m_view.DMPELKEMCCJ_BoxTotal;
			}
		}

		// // RVA: 0xEE0AC4 Offset: 0xEE0AC4 VA: 0xEE0AC4
		private void UpdateReaction()
		{
			if(m_reactionTiming == 0)
				return;
			(m_layoutMain as LayoutGachaBoxMission).SetupSerif(m_reactionList);
		}

		// // RVA: 0xEE1754 Offset: 0xEE1754 VA: 0xEE1754
		private bool CheckReaction(HGFPAFPGIKG.LBEPCOMCHNE reaction)
		{
			if(reaction.FKDOMKHHOCD == HGFPAFPGIKG.GDEJHABHLFH.HJNNKCMLGFL_0 || reaction.FKDOMKHHOCD > HGFPAFPGIKG.GDEJHABHLFH.EOAFEBEENLI_5)
				return false;
			switch(reaction.FKDOMKHHOCD)
			{
				case HGFPAFPGIKG.GDEJHABHLFH.HPFFBANMJOD_1:
					break;
				case HGFPAFPGIKG.GDEJHABHLFH.CPLKGJJFJKA_2:
					return (m_crntPickup.NNCCGILOOIE - m_crntPickup.BFGKGMOLAFL_MaxPlate) < 0;
				default:
					if(m_prevBoxId != m_crntBoxId)
						return false;
					if(m_prevPickup == null)
						return false;
					if(m_prevPickup.NNCCGILOOIE <= m_crntPickup.NNCCGILOOIE)
						return false;
					if(reaction.FKDOMKHHOCD == HGFPAFPGIKG.GDEJHABHLFH.DAFJKGJDAND_3)
					{
						if(!m_isBoxFull)
							return false;
						return true;
					}
					if(reaction.FKDOMKHHOCD != HGFPAFPGIKG.GDEJHABHLFH.BEJJEGKLGMP_4)
						return false;
					return !m_isBoxFull;
				case HGFPAFPGIKG.GDEJHABHLFH.EOAFEBEENLI_5:
					return m_view.JALHJAPAFLK_BoxCurrent - 1 < 0;
			}
			return true;
		}

		// // RVA: 0xEE15D8 Offset: 0xEE15D8 VA: 0xEE15D8
		private HGFPAFPGIKG.CMEDMHFOFAH FindPickup(HGFPAFPGIKG view)
		{
			return view.GMENOMFADOH().Find((HGFPAFPGIKG.CMEDMHFOFAH x) =>
			{
				//0xEE1F34
				return x.JOPPFEHKNFO_IsPickup;
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DE72C Offset: 0x6DE72C VA: 0x6DE72C
		// // RVA: 0xEE18AC Offset: 0xEE18AC VA: 0xEE18AC Slot: 40
		protected override IEnumerator Co_InitializeLayout()
		{
			//0xEE33A4
			yield return AssetBundleManager.LoadUnionAssetBundle(BundleName);
			yield return Co.R(Co_LoadLayout());
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DE7A4 Offset: 0x6DE7A4 VA: 0x6DE7A4
		// // RVA: 0xEE1958 Offset: 0xEE1958 VA: 0xEE1958
		private IEnumerator Co_LoadLayout()
		{
			FontInfo systemFont;
			AssetBundleLoadLayoutOperationBase operation;

			//0xEE35DC
			systemFont = GameManager.Instance.GetSystemFont();
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, "root_gacha_box2_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xEE1D14
				instance.transform.SetParent(transform, false);
				m_layoutMain = instance.GetComponent<LayoutGachaBoxMission>();
			}));
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			m_layoutMain.OnClickButtonPickup = OnSelectItem;
			m_layoutMain.OnClickButtonDetail = OnBoxDetailPopup;
			m_layoutMain.OnClickButtonSingle = OnDrawBoxSingle;
			m_layoutMain.OnClickButtonMulti = OnDrawBoxMulti;
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, "root_gacha_box2_pop_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xEE1DE4
				instance.transform.SetParent(transform, false);
				m_layoutResult = instance.GetComponent<LayoutGachaBoxResult>();
			}));
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			m_layoutResult.OnClickButtonOK = OnResultClose;
			m_layoutResult.OnClickButtonResult = OnResultItemDetail;
			while(!m_layoutMain.IsLoaded())
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DE81C Offset: 0x6DE81C VA: 0x6DE81C
		// // RVA: 0xEE1260 Offset: 0xEE1260 VA: 0xEE1260
		private IEnumerator Co_ConfirmDrawBox(int num/* = 1*/)
		{
			MessageBank bank;

			//0xEE2078
			bool done = false;
			bool cancel = false;
			bank = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent("", SizeType.Small, string.Format(bank.GetMessageByLabel("popup_event_gacha_box_text_07"), num * m_view.AAIKGPGDHIB_Cost, num), new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, false), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xEE1FA4
				if(type == PopupButton.ButtonType.Negative)
					cancel = true;
			}, null, null, null, true, true, false, null, () =>
			{
				//0xEE1FB4
				done = true;
			});
			yield return new WaitWhile(() =>
			{
				//0xEE1FC0
				return !done;
			});
			if(!cancel)
			{
				m_reactionTiming = HGFPAFPGIKG.FHOKKDKGGJI.PDEGHEGBDBE_2;
				yield return Co.R(Co_DrawBox(num));
				HGFPAFPGIKG.LBEPCOMCHNE d = m_reactionList.Find((HGFPAFPGIKG.LBEPCOMCHNE x) =>
				{
					//0xEE1F58
					return x.FKDOMKHHOCD >= HGFPAFPGIKG.GDEJHABHLFH.DAFJKGJDAND_3 && x.FKDOMKHHOCD < HGFPAFPGIKG.GDEJHABHLFH.EOAFEBEENLI_5;
				});
				if(d != null)
				{
					PopupWindowManager.Show(PopupWindowManager.CrateTextContent("", SizeType.Small, bank.GetMessageByLabel("popup_event_gacha_box_text_12"), new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}, false, false), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0xEE1FD4
						if(type == PopupButton.ButtonType.Negative)
							cancel = true;
					}, null, null, null, true, true, false, null, () =>
					{
						//0xEE1FE4
						done = true;
					});
					yield return new WaitWhile(() =>
					{
						//0xEE1FF0
						return !done;
					});
					UpdateReaction();
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DE894 Offset: 0x6DE894 VA: 0x6DE894
		// // RVA: 0xEE1A24 Offset: 0xEE1A24 VA: 0xEE1A24
		private IEnumerator Co_ConfirmNextBox()
		{
			MessageBank bank;

			//0xEE29C4
			bool cancel = false;
			bool done = false;
			bank = MessageManager.Instance.GetBank("menu");
			string str = bank.GetMessageByLabel("popup_event_gacha_box_text_09");
			int nextCost = m_view.EPLMGDEGLKG(m_view.FBJLOOFBHAP());
			if(m_view.AAIKGPGDHIB_Cost < nextCost)
			{
				str += Environment.NewLine;
				str += Environment.NewLine;
				str += string.Format(bank.GetMessageByLabel("popup_event_gacha_box_text_10"), m_view.AAIKGPGDHIB_Cost, nextCost);
			}
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent("", SizeType.Small, str, new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, false), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xEE200C
				if(type == PopupButton.ButtonType.Negative)
					cancel = true;
			}, null, null, null, true, true, false, null, () =>
			{
				//0xEE201C
				done = true;
			});
			yield return new WaitWhile(() =>
			{
				//0xEE2028
				return !done;
			});
			if(!cancel)
			{
				m_view.OEGDCBLNNFF().OGMDPOJNBHK();
				bool err = false;
				yield return Co.R(Co_Save(() =>
				{
					//0xEE203C
					err = true;
				}));
				if(!err)
				{
					UpdateLayout(null);
					PopupWindowManager.Show(PopupWindowManager.CrateTextContent("", SizeType.Small, bank.GetMessageByLabel("popup_event_gacha_box_text_11"), new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}, false, false), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0xEE1F8C
						return;
					}, null, null, null, true, true, false, null, () =>
					{
						//0xEE2048
						done = true;
					});
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DE90C Offset: 0x6DE90C VA: 0x6DE90C
		// // RVA: 0xEE1AD0 Offset: 0xEE1AD0 VA: 0xEE1AD0
		private IEnumerator Co_Save(Action errorCallback)
		{
			//0xEE3C60
			MenuScene.Instance.InputDisable();
			bool done = false;
			bool err = false;
			MenuScene.Save(() =>
			{
				//0xEE205C
				done = true;
			}, () =>
			{
				//0xEE2068
				done = true;
				err = true;
			});
			while(!done)
				yield return null;
			if(err && errorCallback != null)
				errorCallback();
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DE984 Offset: 0x6DE984 VA: 0x6DE984
		// RVA: 0xEE1B7C Offset: 0xEE1B7C VA: 0xEE1B7C Slot: 41
		protected override IEnumerator StartDrawObject()
		{
			//0xEE3F74
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_004);
			yield return null;
		}

		// RVA: 0xEE1C10 Offset: 0xEE1C10 VA: 0xEE1C10 Slot: 42
		protected override void ResetDrawObject()
		{
			return;
		}
	}
}
