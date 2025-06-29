using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class GachaBoxScene : TransitionRoot
	{
		public class GachaBoxArgs : TransitionArgs
		{
			public int gachaBoxEventId { get; private set; } // 0x8
			public HGFPAFPGIKG.KAFHMMOGLKO seasonType { get; set; } // 0xC
			public int halfTimeId { get; set; } // 0x10

			// RVA: 0xEE0870 Offset: 0xEE0870 VA: 0xEE0870
			public GachaBoxArgs(int eventId)
			{
				gachaBoxEventId = eventId;
			}
		}

		protected LayoutGachaBox m_layoutMain; // 0x48
		protected LayoutGachaBoxResult m_layoutResult; // 0x4C
		private ModelGachaBox m_boxObject; // 0x50
		private HGFPAFPGIKG.KAFHMMOGLKO m_seasonType; // 0x54
		private int m_halfTimeId; // 0x58
		protected int m_eventId; // 0x5C
		protected HGFPAFPGIKG m_view; // 0x60
		protected bool m_isInitialize; // 0x64
		protected int m_antiAliasing; // 0x68

		protected virtual string BundleName { get { return "ly/113.xab"; } } //0xEDB7F8
		protected virtual string PopupText_BoxEmpty { get { return "popup_event_gacha_box_text_03"; } } //0xEDB854

		// RVA: 0xEDB8B0 Offset: 0xEDB8B0 VA: 0xEDB8B0 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			InitializeLayout();
		}

		// RVA: 0xEDB8DC Offset: 0xEDB8DC VA: 0xEDB8DC Slot: 16
		protected override void OnPreSetCanvas()
		{
			m_isInitialize = false;
			this.StartCoroutineWatched(Co_Initialize(() =>
			{
				//0xEDE398
				m_isInitialize = true;
			}));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DDF4C Offset: 0x6DDF4C VA: 0x6DDF4C
		// // RVA: 0xEDB984 Offset: 0xEDB984 VA: 0xEDB984
		private IEnumerator Co_Initialize(Action callback)
		{
			//0xEDF57C
			base.OnPreSetCanvas();
			if(NKGJPJPHLIF.HHCJCDFCLOB.DPJBHHIHJJK)
			{
				bool isDone_UpdateServerTime = false;
				NKGJPJPHLIF.HHCJCDFCLOB.CADNBFCHAKM_GetToken(() =>
				{
					//0xEDE730
					isDone_UpdateServerTime = true;
				}, () =>
				{
					//0xEDE73C
					isDone_UpdateServerTime = true;
					GoToTitle();
				});
				while(!isDone_UpdateServerTime)
					yield return null;
			}
			GachaBoxArgs arg = Args as GachaBoxArgs;
			if(arg != null)
			{
				m_eventId = arg.gachaBoxEventId;
				m_seasonType = arg.seasonType;
				m_halfTimeId = arg.halfTimeId;
			}
			yield return Co.R(MenuScene.Instance.BgControl.ChangeBgCoroutine(BgType.GachaBox, m_eventId, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			if(m_boxObject != null)
				m_boxObject.Reset();
			StartQualitySettings();
			UpdateLayout(null);
			if(callback != null)
				callback();
		}

		// RVA: 0xEDBA4C Offset: 0xEDBA4C VA: 0xEDBA4C Slot: 18
		protected override void OnPostSetCanvas()
		{
			base.OnPostSetCanvas();
			if(m_boxObject != null)
				m_boxObject.AdjustCamera();
		}

		// RVA: 0xEDBB0C Offset: 0xEDBB0C VA: 0xEDBB0C Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && m_isInitialize;
		}

		// RVA: 0xEDBBB8 Offset: 0xEDBBB8 VA: 0xEDBBB8 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_layoutMain.Enter();
		}

		// RVA: 0xEDBBE4 Offset: 0xEDBBE4 VA: 0xEDBBE4 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_layoutMain.IsPlaying();
		}

		// RVA: 0xEDBC14 Offset: 0xEDBC14 VA: 0xEDBC14 Slot: 12
		protected override void OnStartExitAnimation()
		{
			EndQualitySettings();
			m_layoutMain.Leave();
		}

		// RVA: 0xEDBC58 Offset: 0xEDBC58 VA: 0xEDBC58 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_layoutMain.IsPlaying();
		}

		// RVA: 0xEDBC88 Offset: 0xEDBC88 VA: 0xEDBC88 Slot: 14
		protected override void OnDestoryScene()
		{
			if(m_boxObject != null)
				m_boxObject.Hide();
		}

		// RVA: 0xEDBD3C Offset: 0xEDBD3C VA: 0xEDBD3C Slot: 15
		protected override void OnDeleteCache()
		{
			if(m_layoutResult != null)
			{
				Destroy(m_layoutResult.gameObject);
				m_layoutResult = null;
			}
			if(m_boxObject != null)
			{
				Destroy(m_boxObject.gameObject);
				m_boxObject = null;
			}
		}

		// // RVA: 0xEDBEE0 Offset: 0xEDBEE0 VA: 0xEDBEE0 Slot: 33
		protected virtual void StartQualitySettings()
		{
			m_antiAliasing = QualitySettings.antiAliasing;
			QualitySettings.antiAliasing = 8;
		}

		// // RVA: 0xEDBF08 Offset: 0xEDBF08 VA: 0xEDBF08 Slot: 34
		protected virtual void EndQualitySettings()
		{
			QualitySettings.antiAliasing = m_antiAliasing;
		}

		// // RVA: 0xEDBF14 Offset: 0xEDBF14 VA: 0xEDBF14
		protected void OnResultClose()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			GameManager.Instance.InputEnabled = false;
			m_layoutResult.Leave(() =>
			{
				//0xEDE5CC
				GameManager.Instance.InputEnabled = true;
			});
		}

		// // RVA: 0xEDC0F8 Offset: 0xEDC0F8 VA: 0xEDC0F8
		protected void OnResultItemDetail(int itemId)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				//EKLNMHFCAOI.ALHCGDMEMID_GetNumItems();
				MenuScene.Instance.ShowSceneStatusPopupWindow(GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId) - 1], GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, false, true, SceneStatusParam.PageSave.None, false);
			}
			else
			{
				MenuScene.Instance.ShowItemDetail(itemId, 1, null);
			}
		}

		// // RVA: 0xEDC478 Offset: 0xEDC478 VA: 0xEDC478
		protected void OnItemSecret(Transform parent, long openTime)
		{
			DateTime date = Utility.GetLocalDateTime(openTime);
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent("", SizeType.Small, string.Format(MessageManager.Instance.GetMessage("menu", "popup_event_gacha_box_text_05"), new object[5]
			{
				date.Year, date.Month, date.Day, date.Hour, date.Minute
			}), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			}, false, false), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xEDE66C
				return;
			}, null, null, null, true, true, false);
		}

		// // RVA: 0xEDCAA0 Offset: 0xEDCAA0 VA: 0xEDCAA0
		protected void OnItemDetail(Transform parent, int itemId)
		{
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				GCIJNCFDNON_SceneInfo[] scenes = new GCIJNCFDNON_SceneInfo[2];
				scenes[0] = new GCIJNCFDNON_SceneInfo();
				scenes[1] = new GCIJNCFDNON_SceneInfo();
				scenes[0].KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId), null, null, 0, 0, 0, false, 0, 0);
				scenes[1].KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId), null, null, 1, 0, 0, false, 0, 0);
				PopupRewardEv2DetailSetting s = new PopupRewardEv2DetailSetting();
				s.TitleText = scenes[0].OPFGFINHFCE_SceneName;
				s.Scene = scenes;
				s.WindowSize = SizeType.Large;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				s.SetParent(parent);
				bool done = false;
				PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xEDE670
					return;
				}, null, null, null, true, true, false, null, () =>
				{
					//0xEDE76C
					done = true;
				});
			}
			else
			{
				MenuScene.Instance.ShowItemDetail(itemId, 1, null);
			}
		}

		// // RVA: 0xEDD1B0 Offset: 0xEDD1B0 VA: 0xEDD1B0
		protected void OnSelectItem(Transform parent, HGFPAFPGIKG.CMEDMHFOFAH item)
		{
			if(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime() < m_view.JOFAGCFNKIO_Start && 
				EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(item.GLCLFMGPMAN_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene && item.JOPPFEHKNFO_IsPickup)
			{
				OnItemSecret(parent, m_view.JOFAGCFNKIO_Start);
			}
			else
			{
				OnItemDetail(parent, item.GLCLFMGPMAN_ItemId);
			}
		}

		// // RVA: 0xEDD350 Offset: 0xEDD350 VA: 0xEDD350 Slot: 35
		protected virtual void OnBoxDetailPopup()
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
				//0xEDE674
				return;
			}, null, null, null, true, true, false, null, () =>
			{
				//0xEDE778
				done = true;
			});
		}

		// // RVA: 0xEDD784 Offset: 0xEDD784 VA: 0xEDD784 Slot: 36
		protected virtual void OnDrawBoxSingle()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(CloseTimeCheck("popup_event_gacha_box_text_04"))
				return;
			this.StartCoroutineWatched(Co_DrawBox(1));
		}

		// // RVA: 0xEDDD00 Offset: 0xEDDD00 VA: 0xEDDD00 Slot: 37
		protected virtual void OnDrawBoxMulti(int num)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(CloseTimeCheck("popup_event_gacha_box_text_04"))
				return;
			this.StartCoroutineWatched(Co_DrawBox(num));
		}

		// // RVA: 0xEDD858 Offset: 0xEDD858 VA: 0xEDD858
		protected bool CloseTimeCheck(string endLabel)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(m_view.EBCHFBIINDP_End < time)
			{
				PopupWindowManager.Show(PopupWindowManager.CrateTextContent("", SizeType.Small, MessageManager.Instance.GetMessage("menu", endLabel), new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, false), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xEDE678
					return;
				}, null, null, null, true, true, false, null, () =>
				{
					//0xEDE3AC
					GoToTitle();
				});
				return true;
			}
			return false;
		}

		// // RVA: 0xEDDDD8 Offset: 0xEDDDD8 VA: 0xEDDDD8 Slot: 38
		protected virtual void InitializeLayout()
		{
			this.StartCoroutineWatched(Co_InitializeLayout());
		}

		// // RVA: 0xEDDE0C Offset: 0xEDDE0C VA: 0xEDDE0C Slot: 39
		protected virtual void UpdateLayout(HGFPAFPGIKG view)
		{
			if(view == null)
				view = new HGFPAFPGIKG(m_eventId);
			m_view = view;
			if(m_boxObject != null)
				m_boxObject.Setup(m_seasonType, m_halfTimeId);
			m_layoutMain.Setup(m_eventId, m_view);
			m_layoutMain.SetCostIcon(m_seasonType, m_halfTimeId);
		}

		// // RVA: 0xEDDF6C Offset: 0xEDDF6C VA: 0xEDDF6C
		protected void GoToTitle()
		{
			if(MenuScene.Instance.IsTransition())
				GotoTitle();
			else
				MenuScene.Instance.GotoTitle();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DDFC4 Offset: 0x6DDFC4 VA: 0x6DDFC4
		// // RVA: 0xEDE078 Offset: 0xEDE078 VA: 0xEDE078 Slot: 40
		protected virtual IEnumerator Co_InitializeLayout()
		{
			//0xEDFAD0
			yield return AssetBundleManager.LoadUnionAssetBundle(BundleName);
			yield return Co.R(Co_LoadLayout());
			yield return Co.R(Co_LoadBoxModel(null));
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DE03C Offset: 0x6DE03C VA: 0x6DE03C
		// // RVA: 0xEDE124 Offset: 0xEDE124 VA: 0xEDE124
		private IEnumerator Co_LoadLayout()
		{
			FontInfo systemFont; // 0x14
			AssetBundleLoadLayoutOperationBase operation; // 0x18

			//0xEE00C0
			systemFont = GameManager.Instance.GetSystemFont();
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, "root_gacha_box_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xEDE3B0
				instance.transform.SetParent(transform, false);
				m_layoutMain = instance.GetComponent<LayoutGachaBox>();
			}));
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			m_layoutMain.OnClickButtonPickup = OnSelectItem;
			m_layoutMain.OnClickButtonDetail = OnBoxDetailPopup;
			m_layoutMain.OnClickButtonSingle = OnDrawBoxSingle;
			m_layoutMain.OnClickButtonMulti = OnDrawBoxMulti;
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, "root_gacha_box_pop_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xEDE480
				instance.transform.SetParent(transform, false);
				m_layoutResult = instance.GetComponent<LayoutGachaBoxResult>();
			}));
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			m_layoutResult.OnClickButtonOK = OnResultClose;
			m_layoutResult.OnClickButtonResult = OnResultItemDetail;
			while(!m_layoutMain.IsLoaded())
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DE0B4 Offset: 0x6DE0B4 VA: 0x6DE0B4
		// // RVA: 0xEDE1D0 Offset: 0xEDE1D0 VA: 0xEDE1D0
		private IEnumerator Co_LoadBoxModel(Action callback)
		{
			AssetBundleLoadAssetOperation operation;
			//0xEDFD4C
			operation = AssetBundleManager.LoadAssetAsync(BundleName, "box", typeof(GameObject));
			yield return operation;
			GameObject g = Instantiate(operation.GetAsset<GameObject>());
			m_boxObject = g.GetComponentInChildren<ModelGachaBox>();
			m_boxObject.Hide();
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			if(callback != null)
				callback();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DE12C Offset: 0x6DE12C VA: 0x6DE12C
		// // RVA: 0xEDDC58 Offset: 0xEDDC58 VA: 0xEDDC58
		protected IEnumerator Co_DrawBox(int num = 1)
		{
			bool isEnpty; // 0x1C
			JKNGJFOBADP inventoryUtil; // 0x20

			//0xEDE860
			MenuScene.Instance.InputDisable();
			List<HGFPAFPGIKG.JAKMCKNADCE> drawList = null;
			bool done = false;
			bool cancel = false;
			m_view.EAFPKOMBKGB(num, (List<HGFPAFPGIKG.JAKMCKNADCE> list) =>
			{
				//0xEDE78C
				done = true;
				drawList = list;
			}, () =>
			{
				//0xEDE79C
				done = true;
				cancel = true;
			}, () =>
			{
				//0xEDE7A8
				GoToTitle();
			});
			yield return new WaitWhile(() =>
			{
				//0xEDE7D0
				return !done;
			});
			if(!cancel)
			{
				yield return Co.R(StartDrawObject());
				if(drawList != null)
				{
					if(drawList.Count > 0)
					{
						GameManager.Instance.ResetViewPlayerData();
						ResetDrawObject();
						isEnpty = m_view.HCPAAGBDCAO_IsEmpty;
						inventoryUtil = m_view.JANMJPOKLFL_InventoryUtil;
						m_layoutResult.Setup(drawList);
						yield return Co.R(m_layoutResult.Enter(null));
						HGFPAFPGIKG.JAKMCKNADCE it = drawList.Find((HGFPAFPGIKG.JAKMCKNADCE x) =>
						{
							//0xEDE67C
							return EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(x.GLCLFMGPMAN_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene;
						});
						if(it != null)
						{
							done = false;
							this.StartCoroutineWatched(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.GachaBox, inventoryUtil, () =>
							{
								//0xEDE7E4
								done = true;
							}, false));
							m_layoutResult.InputDisable();
							yield return new WaitWhile(() =>
							{
								//0xEDE7F0
								return !done;
							});
						}
						m_layoutResult.InputEnable();
						yield return new WaitWhile(() =>
						{
							//0xEDE804
							return m_layoutResult.IsOpen;
						});
						if(isEnpty)
						{
							done = false;
							PopupWindowManager.Show(PopupWindowManager.CrateTextContent("", SizeType.Small, MessageManager.Instance.GetMessage("menu", PopupText_BoxEmpty), new ButtonInfo[1]
							{
								new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
							}, false, false), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
							{
								//0xEDE724
								return;
							}, null, null, null, true, true, false, null, () =>
							{
								//0xEDE83C
								done = true;
							});
							yield return new WaitWhile(() =>
							{
								//0xEDE848
								return !done;
							});
						}
						//LAB_00edf270
						UpdateLayout(null);
					}
				}
			}
			//LAB_00edf2ac
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DE1A4 Offset: 0x6DE1A4 VA: 0x6DE1A4
		// // RVA: 0xEDE2B8 Offset: 0xEDE2B8 VA: 0xEDE2B8 Slot: 41
		protected virtual IEnumerator StartDrawObject()
		{
			//0xEE0744
			yield return Co.R(m_boxObject.Enter());
		}

		// // RVA: 0xEDE364 Offset: 0xEDE364 VA: 0xEDE364 Slot: 42
		protected virtual void ResetDrawObject()
		{
			m_boxObject.Reset();
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6DE22C Offset: 0x6DE22C VA: 0x6DE22C
		// [DebuggerHiddenAttribute] // RVA: 0x6DE22C Offset: 0x6DE22C VA: 0x6DE22C
		// // RVA: 0xEDE3A4 Offset: 0xEDE3A4 VA: 0xEDE3A4
		// private void <>n__0() { }
	}
}
