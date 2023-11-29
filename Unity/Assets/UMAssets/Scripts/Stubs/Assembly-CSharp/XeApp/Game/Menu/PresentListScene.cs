using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PresentListScene : TransitionRoot
	{
		private enum PresentUpdateStep
		{
			Step_None = -1,
			Step_Item_check = 0,
			Step_Recept = 1,
			Step_Luck = 2,
			Step_Item = 3,
			Step_Lump_Check = 4,
			Step_Lump_Recept = 5,
			Step_Lump_Recept_Limit = 6,
		}

		private enum PresentListType
		{
			Present = 0,
			History = 1,
		}
 
		private enum PresentPopWindowType
		{
			NONE = -1,
			RECEIPT_CONF = 0,
			POSS_LIMIT = 1,
			RECEIPT = 2,
			SYNTHESIS_LUCK = 3,
			SYNTHESIS_ITEM = 4,
			LUMP_RECEIPT_CONF = 5,
			LUMP_POSS_LIMIT = 6,
			LUMP_RECEIPT = 7,
			LUMP_FAILURE = 8,
			MAX = 9,
		}

		private GeneralListWindow m_windowUi; // 0x48
		private List<PresentListElem> m_elems = new List<PresentListElem>(); // 0x4C
		private SwapScrollList m_scrollList; // 0x50
		private List<PresentListInfo> m_presentInfoList = new List<PresentListInfo>(); // 0x54
		private List<PresentListInfo> m_historyInfoList = new List<PresentListInfo>(); // 0x58
		private PresentUpdateStep Step = PresentUpdateStep.Step_None; // 0x5C
		private PresentListType ListType; // 0x60
		private int m_selectListIndex = -1; // 0x64
		private int m_connectingCount; // 0x68
		private AMOCLPHDGBP paidVCPurchase; // 0x6C
		private PresentPopWindowType windowType = PresentPopWindowType.NONE; // 0x70

		//private bool isConnecting { get; } 0x11661F8

		// RVA: 0x116620C Offset: 0x116620C VA: 0x116620C Slot: 4
		protected override void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_LoadResources());
		}

		// RVA: 0x11662C8 Offset: 0x11662C8 VA: 0x11662C8 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			m_windowUi.Hide();
			RequestVCRecover();
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.PNNHEOOJBFI_TutorialGeneralFlags.EDEDFDDIOKO_SetTrue(0);
		}

		// RVA: 0x1166584 Offset: 0x1166584 VA: 0x1166584 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_connectingCount < 1 && base.IsEndPreSetCanvas();
		}

		// RVA: 0x116659C Offset: 0x116659C VA: 0x116659C Slot: 18
		protected override void OnPostSetCanvas()
		{
			base.OnPostSetCanvas();
			Initialize();
		}

		// RVA: 0x1166958 Offset: 0x1166958 VA: 0x1166958 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return m_connectingCount < 1 && base.IsEndPostSetCanvas();
		}

		// RVA: 0x1166970 Offset: 0x1166970 VA: 0x1166970 Slot: 20
		protected override bool OnBgmStart()
		{
			int bgmId = BgmPlayer.MENU_BGM_ID_BASE;
			if(MenuScene.Instance.BgControl.limitedHomeBg.m_music_id == BgControl.LimitedHomeBg.INVALID_MUSIC_ID)
			{
				string home_bgm_id = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL("home_bgm_id", "0,0,0");
				string[] strs = home_bgm_id.Split(new char[] { ',' });
				if(strs.Length == 3)
				{
					int id;
					if (int.TryParse(strs[BgControl.GetHomeBgId(MenuScene.Instance.EnterToHomeTime) - 1], out id))
					{
						bgmId += id;
					}
				}
			}
			else
			{
				bgmId += MenuScene.Instance.BgControl.limitedHomeBg.m_music_id;
			}
			SoundManager.Instance.bgmPlayer.ContinuousPlay(bgmId, 1);
			return true;
		}

		// RVA: 0x1166E20 Offset: 0x1166E20 VA: 0x1166E20 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_windowUi.Enter();
		}

		// RVA: 0x1166E4C Offset: 0x1166E4C VA: 0x1166E4C Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_windowUi.IsPlaying();
		}

		// RVA: 0x1166E7C Offset: 0x1166E7C VA: 0x1166E7C Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_windowUi.Leave();
		}

		// RVA: 0x1166EA8 Offset: 0x1166EA8 VA: 0x1166EA8 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_windowUi.IsPlaying();
		}

		// RVA: 0x1166ED8 Offset: 0x1166ED8 VA: 0x1166ED8 Slot: 14
		protected override void OnDestoryScene()
		{
			return;
		}

		//// RVA: 0x1166408 Offset: 0x1166408 VA: 0x1166408
		//private void RequestVCRecover() { }

		//// RVA: 0x11665BC Offset: 0x11665BC VA: 0x11665BC
		private void Initialize()
		{
			m_windowUi.onClickHistoryButton = OnClickHistoryButton;
			m_windowUi.onClickPresentButton = OnClickHistoryButton;
			m_windowUi.onClickReceiveButton = OnClickAllReceiveButton;
			m_windowUi.ChangePreset(GeneralListWindow.Preset.PresentBox, false);
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
			m_scrollList.SetItemCount(0);
			m_scrollList.VisibleRegionUpdate();
			GetPresentList();
		}

		//// RVA: 0x11670E8 Offset: 0x11670E8 VA: 0x11670E8
		//private void OnSelectListItem(int value, SwapScrollListContent content) { }

		//// RVA: 0x1167C6C Offset: 0x1167C6C VA: 0x1167C6C
		//private void OnClickAllReceiveButton() { }

		//// RVA: 0x1167D18 Offset: 0x1167D18 VA: 0x1167D18
		//private void OnClickHistoryButton() { }

		//// RVA: 0x1167DDC Offset: 0x1167DDC VA: 0x1167DDC
		//private void SortPresentList(List<PresentListInfo> list) { }

		//// RVA: 0x116846C Offset: 0x116846C VA: 0x116846C
		//private void OnUpdateListItem(int index, GeneralListContent content, PresentListInfo info) { }

		//// RVA: 0x1168650 Offset: 0x1168650 VA: 0x1168650
		//private void OnGetPresentList() { }

		//// RVA: 0x1166EDC Offset: 0x1166EDC VA: 0x1166EDC
		//private void GetPresentList() { }

		//// RVA: 0x116867C Offset: 0x116867C VA: 0x116867C
		//private void GetHistoryList() { }

		//// RVA: 0x1168888 Offset: 0x1168888 VA: 0x1168888
		//private void NetErrorToTitle() { }

		//// RVA: 0x11671AC Offset: 0x11671AC VA: 0x11671AC
		//private void SetPrePopWindow(PresentListScene.PresentPopWindowType type) { }

		//// RVA: 0x1168994 Offset: 0x1168994 VA: 0x1168994
		//private void OnClickPopupButton(PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		//// RVA: 0x1168ED0 Offset: 0x1168ED0 VA: 0x1168ED0
		//private void UpdateItemReceipt() { }

		//// RVA: 0x1168FE0 Offset: 0x1168FE0 VA: 0x1168FE0
		//private void UpdateItemReceptLimit() { }

		//// RVA: 0x116908C Offset: 0x116908C VA: 0x116908C
		//private void UpdateItemReceptLimit2() { }

		//// RVA: 0x1169140 Offset: 0x1169140 VA: 0x1169140
		//private void UpdateItemReceptFailure() { }

		//// RVA: 0x1169154 Offset: 0x1169154 VA: 0x1169154
		//private void UpdateItemLuck() { }

		//// RVA: 0x1169174 Offset: 0x1169174 VA: 0x1169174
		//private void UpdateItemChange() { }

		//// RVA: 0x1169194 Offset: 0x1169194 VA: 0x1169194
		//private void UpdateLumpCheck() { }

		//// RVA: 0x11692A4 Offset: 0x11692A4 VA: 0x11692A4
		//private void UpdateError() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E10B4 Offset: 0x6E10B4 VA: 0x6E10B4
		//// RVA: 0x116623C Offset: 0x116623C VA: 0x116623C
		private IEnumerator Co_LoadResources()
		{
			//0x116AD50
			yield return Co.R(Co_LoadLayout());
			IsReady = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E112C Offset: 0x6E112C VA: 0x6E112C
		//// RVA: 0x11693B8 Offset: 0x11693B8 VA: 0x11693B8
		private IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x18
			Font systemFont; // 0x1C
			int bundleLoadCount; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24
			int poolSize; // 0x28
			int i; // 0x2C

			//0x116A394
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/039.xab");
			bundleLoadCount = 0;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_GeneralListWindow");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x116A090
				instance.transform.SetParent(transform, false);
				m_windowUi = instance.GetComponent<GeneralListWindow>();
				m_scrollList = instance.GetComponentInChildren<SwapScrollList>(true);
			}));
			bundleLoadCount++;
			poolSize = m_scrollList.ScrollObjectCount;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_PresentListElem");
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x116A1D4
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = string.Format("PresentListElem {0:D2}", 0);
				m_scrollList.AddScrollObject(instance.GetComponent<SwapScrollListContent>());
				m_elems.Add(instance.GetComponent<PresentListElem>());
			}));
			bundleLoadCount++;
			for(i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name = string.Format("PresentListElem {0:D2}", i);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				m_scrollList.AddScrollObject(r.GetComponent<SwapScrollListContent>());
				m_elems.Add(r.GetComponent<PresentListElem>());
			}
			for(i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			m_scrollList.Apply();
			m_scrollList.SetContentEscapeMode(true);
			while (!m_windowUi.IsLoaded())
				yield return null;
			for(i = 0; i < m_elems.Count; i++)
			{
				while (m_elems[i].IsLoaded())
					yield return null;
			}
		}

		//[CompilerGeneratedAttribute] // RVA: 0x6E11A4 Offset: 0x6E11A4 VA: 0x6E11A4
		//// RVA: 0x116954C Offset: 0x116954C VA: 0x116954C
		//private void <RequestVCRecover>b__25_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E11B4 Offset: 0x6E11B4 VA: 0x6E11B4
		//// RVA: 0x116955C Offset: 0x116955C VA: 0x116955C
		//private void <RequestVCRecover>b__25_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E11C4 Offset: 0x6E11C4 VA: 0x6E11C4
		//// RVA: 0x116956C Offset: 0x116956C VA: 0x116956C
		//private void <RequestVCRecover>b__25_2() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E11D4 Offset: 0x6E11D4 VA: 0x6E11D4
		//// RVA: 0x1169684 Offset: 0x1169684 VA: 0x1169684
		//private void <OnClickPopupButton>b__39_0() { }
	}
}
