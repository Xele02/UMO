using System;
using System.Collections;
using System.Collections.Generic;
using mcrs;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupDenomination : UIBehaviour, IPopupContent
	{
		private class PopupDenominationSetting : PopupSetting
		{
			public class ScrollObject
			{
				// Fields
				public GameObject obj; // 0x8
				public bool is_disp; // 0xC
			}

			private List<ScrollObject> m_ScrollObjList = new List<ScrollObject>(); // 0x4C
			private Vector2 m_ItemSize = Vector2.zero; // 0x50
			private List<LGDNAJACFHI> m_paidVcProductDataList = new List<LGDNAJACFHI>(); // 0x58

			public AMOCLPHDGBP NetPaidVCPurchase { get; set; } // 0x34
			public ELBOJBBIBFM OnPurchase { get; set; } // 0x38
			public JFDNPFFOACP OnCancel { get; set; } // 0x3C
			public OnDenomChangeDate OnChangeDate { get; set; } // 0x40
			public ProductListFilter Filter { get; set; } // 0x44
			public int HavePaidVC { get; set; } // 0x48
			public List<ScrollObject> GetScrollObjList { get { return m_ScrollObjList; } } //0xF7C728
			public Vector2 GetItemSize { get { return m_ItemSize; } } //0xF7C96C
			public override string PrefabPath { get { return ""; } } //0xF7FBB0
			public override string BundleName { get { return "ly/078.xab"; } } //0xF7FC0C
			public override string AssetName { get { return "PopupDenomination"; } } //0xF7FC68
			public override bool IsAssetBundle { get { return true; } } //0xF7FCC4
			public override bool IsPreload { get { return true; } } //0xF7FCCC
			public override GameObject Content { get { return m_content; } } //0xF7FCD4

			//// RVA: 0xF7FCDC Offset: 0xF7FCDC VA: 0xF7FCDC
			//public void SetContent(GameObject obj) { }

			//// RVA: 0xF7CAA4 Offset: 0xF7CAA4 VA: 0xF7CAA4
			public void ReleaseScrollObj()
			{
				for(int i = 0; i < m_ScrollObjList.Count; i++)
				{
					Destroy(m_ScrollObjList[i].obj);
				}
				m_ScrollObjList.Clear();
			}

			//[IteratorStateMachineAttribute] // RVA: 0x6D82EC Offset: 0x6D82EC VA: 0x6D82EC
			//// RVA: 0xF7F86C Offset: 0xF7F86C VA: 0xF7F86C
			public IEnumerator Co_LoadPopupResource()
			{
				int loadcount; // 0x18
				AssetBundleLoadLayoutOperationBase operation; // 0x1C
				
				//0xF7FEA0
				loadcount = 0;
				if(m_content == null)
				{
					operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PopupDenomination");
					yield return operation;
					yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
					{
						//0xF7FE84
						m_content = instance;
					}));
					yield return null;
					loadcount++;
					operation = null;
				}
				//LAB_00f800f8
				GameObject inst = null;
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "StoneItem");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0xF7FE94
					inst = instance;
				}));
				m_ItemSize = inst.GetComponent<RectTransform>().sizeDelta;
				yield return null;
				ReleaseScrollObj();
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				LayoutUGUIRuntime runtime = inst.GetComponent<LayoutUGUIRuntime>();
				ApplyProductFilter(m_paidVcProductDataList, NetPaidVCPurchase);
				for(int i = 0; i < m_paidVcProductDataList.Count; i++)
				{
					LayoutUGUIRuntime r = CopyInstance(runtime);
					r.GetComponent<LayoutStoneItem>().Setup(m_paidVcProductDataList[i]);
					ScrollObject sObject = new ScrollObject();
					sObject.obj = r.gameObject;
					sObject.is_disp = m_paidVcProductDataList[i].EMEKFFHCHMH_CloseAt == 0 || t < m_paidVcProductDataList[i].EMEKFFHCHMH_CloseAt;
					m_ScrollObjList.Add(sObject);
				}
				Destroy(inst);
				yield return null;
				loadcount++;
				operation = null;
				for(int i = 0; i < loadcount; i++)
				{
					AssetBundleManager.UnloadAssetBundle(BundleName, false);
				}
			}

			//// RVA: 0xF7FD04 Offset: 0xF7FD04 VA: 0xF7FD04
			private LayoutUGUIRuntime CopyInstance(LayoutUGUIRuntime runtime)
			{
				LayoutUGUIRuntime r = Instantiate(runtime);
				r.IsLayoutAutoLoad = false;
				r.UvMan = runtime.UvMan;
				r.Layout = runtime.Layout.DeepClone();
				r.LoadLayout();
				return r;
			}
		}

		private static PopupDenominationSetting sm_Setting; // 0x0
		private static PopupWindowControl sm_Control; // 0x4
		private static DJBHIFLHJLK errorHandler; // 0x8
		private const int ScrollItemCount = 3;
		private LayoutPopupDenomination m_MainLayout; // 0x10
		private PopupWindowControl m_control; // 0x14
		//[CompilerGeneratedAttribute] // RVA: 0x66C808 Offset: 0x66C808 VA: 0x66C808
		public Action SupportSiteManagerErrorHandler; // 0x18
		private bool m_IsBuying; // 0x1C
		private List<LGDNAJACFHI> m_paidVcProductDataList = new List<LGDNAJACFHI>(); // 0x20

		public Transform Parent { get; private set; } // 0xC

		//[IteratorStateMachineAttribute] // RVA: 0x6D7FB4 Offset: 0x6D7FB4 VA: 0x6D7FB4
		//// RVA: 0xF7B788 Offset: 0xF7B788 VA: 0xF7B788
		public static IEnumerator Co_ShowPopup(Transform parent, AMOCLPHDGBP p, ELBOJBBIBFM onPurchase, JFDNPFFOACP onCancel, DJBHIFLHJLK onError, OnDenomChangeDate onChangeDate, ProductListFilter filter)
		{
			//0xF7F110
			if(sm_Setting == null)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				PopupDenominationSetting s = new PopupDenominationSetting();
				s.WindowSize = SizeType.Large;
				s.TitleText = bk.GetMessageByLabel("popup_denom_title");
				s.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative } };
				sm_Setting = s;
			}
			errorHandler = onError;
			sm_Setting.NetPaidVCPurchase = p;
			sm_Setting.OnPurchase = onPurchase;
			sm_Setting.OnCancel = onCancel;
			sm_Setting.OnChangeDate = onChangeDate;
			sm_Setting.Filter = filter;
			sm_Setting.HavePaidVC = CIOECGOMILE.HHCJCDFCLOB.DEAPMEIDCGC_GetTotalPaidCurrency();
			sm_Setting.SetParent(parent);
			yield return Co.R(sm_Setting.Co_LoadPopupResource());
			sm_Control = PopupWindowManager.Show(sm_Setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xF7E2F4
				sm_Control = null;
				if(onCancel != null)
					onCancel();
				errorHandler = null;
			}, null, null, null);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D802C Offset: 0x6D802C VA: 0x6D802C
		//// RVA: 0xF7B8D4 Offset: 0xF7B8D4 VA: 0xF7B8D4
		public static IEnumerator Co_ClosePopup(Action onClosed)
		{
			//0xF7E8D0
			if(sm_Control != null)
			{
				bool is_close = false;
				sm_Control.Close(() =>
				{
					//0xF7E3F0
					sm_Control = null;
					is_close = true;
				}, null);
				yield return new WaitWhile(() =>
				{
					//0xF7E48C
					return !is_close;
				});
			}
			if(onClosed != null)
				onClosed();
		}

		//// RVA: 0xF7B980 Offset: 0xF7B980 VA: 0xF7B980
		public static void OnProcessingEnd()
		{
			if(sm_Setting != null)
			{
				if(sm_Setting.Content != null)
				{
					PopupDenomination p = sm_Setting.Content.GetComponent<PopupDenomination>();
					if(p != null)
						p.FinishBuying();
				}
			}
		}

		//// RVA: 0xF7BBB0 Offset: 0xF7BBB0 VA: 0xF7BBB0
		private void FinishBuying()
		{
			if(sm_Control == null)
				return;
			if(!m_IsBuying)
				return;
			m_IsBuying = false;
			sm_Control.InputEnable();
		}

		// RVA: 0xF7BCFC Offset: 0xF7BCFC VA: 0xF7BCFC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupDenominationSetting s = setting as PopupDenominationSetting;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_control = control;
			Parent = setting.m_parent;
			gameObject.SetActive(true);
		}

		// RVA: 0xF7BF00 Offset: 0xF7BF00 VA: 0xF7BF00
		public void OnDestroy()
		{
			sm_Setting = null;
			sm_Control = null;
			m_control = null;
		}

		//// RVA: 0xF7BFB0 Offset: 0xF7BFB0 VA: 0xF7BFB0
		private void Setup()
		{
			m_MainLayout = GetComponent<LayoutPopupDenomination>();
			m_MainLayout.SetUp(sm_Setting.HavePaidVC);
			m_MainLayout.OnClickSCTL = OnClickSCTL;
			m_MainLayout.OnClickPSA = OnClickPSA;
			SetupScrollContent();
		}

		//// RVA: 0xF7C15C Offset: 0xF7C15C VA: 0xF7C15C
		private void SetupScrollContent()
		{
			RectTransform rt = m_MainLayout.GetScrollContent.Find("Range").GetComponent<RectTransform>();
			float y = 10;
			for(int i = 0; i < sm_Setting.GetScrollObjList.Count; i++)
			{
				int idx = i;
				if(!sm_Setting.GetScrollObjList[i].is_disp)
					sm_Setting.GetScrollObjList[i].obj.SetActive(false);
				else
				{
					SetupObject(sm_Setting.GetScrollObjList[i].obj, rt, -y);
					y += sm_Setting.GetItemSize.y;
					LayoutStoneItem ls = sm_Setting.GetScrollObjList[i].obj.GetComponent<LayoutStoneItem>();
					ls.OnClickBuyButton = () =>
					{
						//0xF7E4A0
						if(m_IsBuying)
							return;
						this.StartCoroutineWatched(Co_OnClickBuyButton(idx));
					};
					ls.OnClickInfoButton = () =>
					{
						//0xF7E524
						OnClickInfoButton(idx);
					};
				}
			}
			m_MainLayout.GetScrollRect.verticalNormalizedPosition = 1;
			rt = m_MainLayout.GetScrollContent.GetComponent<RectTransform>();
			rt.sizeDelta = new Vector2(0, y + 10);
			rt.anchoredPosition = Vector2.zero;
			m_MainLayout.GetScrollRect.vertical = sm_Setting.GetScrollObjList.Count > 3;
		}

		//// RVA: 0xF7C738 Offset: 0xF7C738 VA: 0xF7C738
		private void SetupObject(GameObject obj, RectTransform parent, float pos)
		{
			Vector2 size = parent.sizeDelta;
			obj.transform.SetParent(parent, false);
			obj.SetActive(true);
			RectTransform rt = obj.GetComponent<RectTransform>();
			rt.anchoredPosition = new Vector2(-size.x, size.y) * 0.5f;
			rt.anchoredPosition += new Vector2(0, pos);
		}

		// RVA: 0xF7C980 Offset: 0xF7C980 VA: 0xF7C980 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF7C988 Offset: 0xF7C988 VA: 0xF7C988 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			Setup();
		}

		// RVA: 0xF7C9CC Offset: 0xF7C9CC VA: 0xF7C9CC Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
			sm_Setting.ReleaseScrollObj();
		}

		// RVA: 0xF7CBD4 Offset: 0xF7CBD4 VA: 0xF7CBD4 Slot: 21
		public bool IsReady()
		{
			return GetComponent<LayoutPopupDenomination>().IsLoaded();
		}

		// RVA: 0xF7CC58 Offset: 0xF7CC58 VA: 0xF7CC58 Slot: 22
		public void CallOpenEnd()
		{
			this.StartCoroutineWatched(Co_ShowTutorial());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D80A4 Offset: 0x6D80A4 VA: 0x6D80A4
		//// RVA: 0xF7CC7C Offset: 0xF7CC7C VA: 0xF7CC7C
		private IEnumerator Co_ShowTutorial()
		{
			//0xF7F994
			m_control.InputDisable();
			yield return this.StartCoroutineWatched(TutorialManager.TryShowTutorialCoroutine(CheckGameResultTutorialCondition));
			m_control.InputEnable();
		}

		//// RVA: 0xF7CD28 Offset: 0xF7CD28 VA: 0xF7CD28
		private bool CheckGameResultTutorialCondition(TutorialConditionId conditionId)
		{
			return conditionId == TutorialConditionId.Condition54;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D811C Offset: 0x6D811C VA: 0x6D811C
		//// RVA: 0xF7CD38 Offset: 0xF7CD38 VA: 0xF7CD38
		private IEnumerator Co_OnClickBuyButton(int index)
		{
			ELBOJBBIBFM onPurchase;

			//0xF7EBD4
			onPurchase = sm_Setting.OnPurchase;
			m_IsBuying = true;
			sm_Control.InputDisable();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			TransitionList.Type gotoSceneType = TransitionList.Type.UNDEFINED;
			if(sm_Setting.OnChangeDate != null)
			{
				bool isFinished = false;
				yield return Co.R(Co_CheckChangeDate((TransitionList.Type result) =>
				{
					//0xF7E564
					gotoSceneType = result;
					isFinished = true;
				}));
				yield return new WaitWhile(() =>
				{
					//0xF7E598
					return !isFinished;
				});
			}
			if(gotoSceneType == TransitionList.Type.UNDEFINED)
			{
				ApplyProductFilter(m_paidVcProductDataList, sm_Setting.NetPaidVCPurchase);
				onPurchase(m_paidVcProductDataList[index]);
			}
			else
			{
				m_IsBuying = false;
				OnChangeDate(gotoSceneType);
			}
		}

		//// RVA: 0xF7CE00 Offset: 0xF7CE00 VA: 0xF7CE00
		private static void ApplyProductFilter(List<LGDNAJACFHI> list, AMOCLPHDGBP paidVcPurchase)
		{
			list.Clear();
			for(int i = 0; i < paidVcPurchase.HFCNOINEPLB.MHKCPJDNJKI.Count; i++)
			{
				if(sm_Setting.Filter == null || sm_Setting.Filter(paidVcPurchase.HFCNOINEPLB.MHKCPJDNJKI[i]))
				{
					list.Add(paidVcPurchase.HFCNOINEPLB.MHKCPJDNJKI[i]);
				}
			}
		}

		//// RVA: 0xF7D120 Offset: 0xF7D120 VA: 0xF7D120
		private void OnClickInfoButton(int index)
		{
			sm_Control.InputDisable();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			ApplyProductFilter(m_paidVcProductDataList, sm_Setting.NetPaidVCPurchase);
			MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(m_paidVcProductDataList[index].JKKNIEHJBAP, () =>
			{
				//0xF7E070
				sm_Control.InputEnable();
			}, () =>
			{
				//0xF7E118
				return;
			});

		}

		//// RVA: 0xF7D4A0 Offset: 0xF7D4A0 VA: 0xF7D4A0
		public static void ChangeDate(TransitionList.Type type)
		{
			if(sm_Setting == null)
				return;
			if(sm_Setting.Content == null)
				return;
			sm_Setting.Content.GetComponent<PopupDenomination>().OnChangeDate(type);
		}

		//// RVA: 0xF7D694 Offset: 0xF7D694 VA: 0xF7D694
		private void OnChangeDate(TransitionList.Type type)
		{
			if(sm_Setting.OnChangeDate != null)
			{
				sm_Setting.OnChangeDate(type);
			}
			this.StartCoroutineWatched(Co_ClosePopup(null));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D8194 Offset: 0x6D8194 VA: 0x6D8194
		//// RVA: 0xF7D808 Offset: 0xF7D808 VA: 0xF7D808
		private IEnumerator Co_CheckChangeDate(Action<TransitionList.Type> onFinished)
		{
			bool isChangeDate;

			//0xF7E5E4
			TransitionList.Type result = TransitionList.Type.UNDEFINED;
			isChangeDate = PGIGNJDPCAH.MNANNMDBHMP(() =>
			{
				//0xF7E5B4
				result = TransitionList.Type.LOGIN_BONUS;
			}, () =>
			{
				//0xF7E5C0
				result = TransitionList.Type.TITLE;
			});
			yield return null;
			if(isChangeDate)
			{
				yield return new WaitWhile(() =>
				{
					//0xF7E5CC
					return result == TransitionList.Type.UNDEFINED;
				});
			}
			if(onFinished != null)
				onFinished(result);
		}

		//// RVA: 0xF7D8B4 Offset: 0xF7D8B4 VA: 0xF7D8B4
		private void OnClickSCTL()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			sm_Control.InputDisable();
			m_MainLayout.ScrollDisable();
			MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.LCCLAEBKMLD_Legals, () =>
			{
				//0xF7DE5C
				sm_Control.InputEnable();
				m_MainLayout.ScrollEnable();
			}, () =>
			{
				//0xF7E11C
				if(errorHandler != null)
					errorHandler();
			});
		}

		//// RVA: 0xF7DB40 Offset: 0xF7DB40 VA: 0xF7DB40
		private void OnClickPSA()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			sm_Control.InputEnable();
			m_MainLayout.ScrollDisable();
			MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.BFKFPEDCFCL_Settlement, () =>
			{
				//0xF7DF28
				sm_Control.InputEnable();
				m_MainLayout.ScrollEnable();
			}, () =>
			{
				//0xF7E204
				if(errorHandler != null)
					errorHandler();
			});
		}
	}
}
