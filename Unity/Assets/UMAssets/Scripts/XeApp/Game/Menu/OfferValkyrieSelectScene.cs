using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class OfferValkyrieSelectScene : TransitionRoot
	{
		[SerializeField]
		private ValkyrieSelectController m_valkyrieSelectController; // 0x48
		private List<HEFCLPGPMLK.ANKPCIEKPAH>[] m_SeriesValkyrieList = new List<HEFCLPGPMLK.ANKPCIEKPAH>[5]; // 0x4C
		private List<HEFCLPGPMLK.ANKPCIEKPAH> m_viewList; // 0x50
		private HEFCLPGPMLK m_view; // 0x54
		private HEFCLPGPMLK.AAOPGOGGMID OfferInfo; // 0x58
		private int m_SelectSeries; // 0x5C
		private int m_Select; // 0x60
		private int selectformationIndex; // 0x64
		private int formationId; // 0x68
		private Action m_updater; // 0x6C
		private bool IsInitialize; // 0x70
		private bool IsEnter; // 0x71
		private bool IsLeaving; // 0x72
		private bool IsReturn = true; // 0x73

		// RVA: 0x1719ED8 Offset: 0x1719ED8 VA: 0x1719ED8
		private void Awake()
		{
			IsReady = true;
		}

		// RVA: 0x1719EE4 Offset: 0x1719EE4 VA: 0x1719EE4
		private void Start()
		{
			ILCCJNDFFOB.HHCJCDFCLOB.BKLNHBHDDEJ(JpStringLiterals.StringLiteral_18949);
		}

		// RVA: 0x1719F90 Offset: 0x1719F90 VA: 0x1719F90
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0x1719FA4 Offset: 0x1719FA4 VA: 0x1719FA4
		private void UpdateInit()
		{
			if(m_valkyrieSelectController != null && m_valkyrieSelectController.IsAssetLoad)
			{
				m_valkyrieSelectController.Initialize();
				m_valkyrieSelectController.renewalSeriesTab();
				m_valkyrieSelectController.SetLayoutButton(() =>
				{
					//0x171B094
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					platoonChengePopup();
				}, () =>
				{
					//0x171B0F8
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					ValkyrieSelectDetach();
				});
				m_updater = UpdateIdel;
			}
		}

		//// RVA: 0x171A160 Offset: 0x171A160 VA: 0x171A160
		private void UpdateIdel()
		{
			m_valkyrieSelectController.ValkyrieSelectUpdate();
		}

		// RVA: 0x171A18C Offset: 0x171A18C VA: 0x171A18C Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			OfferValkyrieSelectArgs args = Args as OfferValkyrieSelectArgs;
			if(args != null)
			{
				m_SeriesValkyrieList = args.SeriesValkyrieList;
				m_SelectSeries = args.SelectSeries;
				m_viewList = args.Formation;
				formationId = args.platoonId + 1;
				m_Select = args.Select;
				selectformationIndex = args.selectIndex;
				OfferInfo = args.OfferInfo;
			}
			IsReturn = true;
			m_view = new HEFCLPGPMLK();
			m_valkyrieSelectController.SetView(m_view);
			m_valkyrieSelectController.SetOfferSeries((int)OfferInfo.DFMOGBOPLEF_Series);
			m_valkyrieSelectController.StartAssetLoad();
			m_valkyrieSelectController.SetValKyrieList(m_SeriesValkyrieList);
			m_valkyrieSelectController.SetSelectSeries(m_SelectSeries, m_Select);
			m_valkyrieSelectController.IsLeader = selectformationIndex == 0;
			IsInitialize = false;
			m_updater = UpdateInit;
			this.StartCoroutineWatched(Co_IsInitialize());
		}

		// RVA: 0x171A488 Offset: 0x171A488 VA: 0x171A488 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return IsInitialize;
		}

		// RVA: 0x171A490 Offset: 0x171A490 VA: 0x171A490 Slot: 18
		protected override void OnPostSetCanvas()
		{
			base.OnPostSetCanvas();
		}

		// RVA: 0x171A498 Offset: 0x171A498 VA: 0x171A498 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return base.IsEndPostSetCanvas();
		}

		// RVA: 0x171A4A0 Offset: 0x171A4A0 VA: 0x171A4A0 Slot: 23
		protected override void OnActivateScene()
		{
			base.OnActivateScene();
		}

		// RVA: 0x171A4A8 Offset: 0x171A4A8 VA: 0x171A4A8 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			base.OnStartEnterAnimation();
			this.StartCoroutineWatched(Co_StartLayout());
		}

		// RVA: 0x171A564 Offset: 0x171A564 VA: 0x171A564 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !IsEnter;
		}

		// RVA: 0x171A578 Offset: 0x171A578 VA: 0x171A578 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			if (!IsReturn)
				return;
			this.StartCoroutineWatched(Co_LeaveLayout());
		}

		// RVA: 0x171A640 Offset: 0x171A640 VA: 0x171A640 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !IsLeaving;
		}

		// RVA: 0x171A654 Offset: 0x171A654 VA: 0x171A654 Slot: 14
		protected override void OnDestoryScene()
		{
			base.OnDestoryScene();
			m_valkyrieSelectController.LayoutDestroy();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F8EEC Offset: 0x6F8EEC VA: 0x6F8EEC
		//// RVA: 0x171A3FC Offset: 0x171A3FC VA: 0x171A3FC
		private IEnumerator Co_IsInitialize()
		{
			//0x171B274
			while (!m_valkyrieSelectController.IsAssetLoad)
				yield return null;
			HEFCLPGPMLK.ANKPCIEKPAH cur = m_viewList[selectformationIndex];
			for (int i = 0; i < m_viewList.Count; i++)
			{
				if(m_viewList[i].JMHKMDFNAIN == selectformationIndex)
				{
					cur = m_viewList[i];
				}
			}
			m_valkyrieSelectController.DisableDetachBtn(cur.LLOBHDMHJIG_Id < 1);
			m_valkyrieSelectController.ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.NONE);
			m_valkyrieSelectController.renewalSeriesTab();
			yield return null;
			IsInitialize = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F8F64 Offset: 0x6F8F64 VA: 0x6F8F64
		//// RVA: 0x171A4D8 Offset: 0x171A4D8 VA: 0x171A4D8
		private IEnumerator Co_StartLayout()
		{
			//0x171B73C
			bool IsEnter = true;
			m_valkyrieSelectController.EnterLayout();
			while (m_valkyrieSelectController.IsPlayingLayout())
				yield return null;
			IsEnter = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F8FDC Offset: 0x6F8FDC VA: 0x6F8FDC
		//// RVA: 0x171A5B4 Offset: 0x171A5B4 VA: 0x171A5B4
		private IEnumerator Co_LeaveLayout()
		{
			//0x171B590
			IsLeaving = true;
			m_valkyrieSelectController.LeaveLayout();
			m_view.FFGHIOAOABE(formationId);
			while(m_valkyrieSelectController.IsPlayingLayout())
				yield return null;
			IsLeaving = false;
		}

		//// RVA: 0x171A6EC Offset: 0x171A6EC VA: 0x171A6EC
		private void platoonChengePopup()
		{
			m_valkyrieSelectController.GetSelectSeries(out m_SelectSeries, out m_Select);
			if (SelectionAnotherPlatoon())
				ValkyrieSelectDone();
			else
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("offer_chenge_popup_title"), SizeType.Small, bk.GetMessageByLabel("offer_plantoon_chenge_popup_text_01"), new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x171B15C
					if (type != PopupButton.ButtonType.Positive)
						return;
					MenuScene.SaveRequest();
					ValkyrieSelectDone();
				}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
				{
					//0x171B26C
					return;
				}, null, null);
			}
		}

		//// RVA: 0x171AC00 Offset: 0x171AC00 VA: 0x171AC00
		private void ValkyrieSelectDone()
		{
			IsReturn = false;
			m_view.JBHBEKJHLFE(formationId, selectformationIndex, m_SeriesValkyrieList[m_SelectSeries][m_Select].LLOBHDMHJIG_Id);
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.AHMOGDDPIFL_LastVfId = m_SeriesValkyrieList[m_SelectSeries][m_Select].LLOBHDMHJIG_Id;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.CPKMLLNADLJ_Series = m_SelectSeries + 1;
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			MenuScene.Instance.Mount(TransitionUniqueId.OFFERSELECT_OFFERFORMATION, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			this.StartCoroutineWatched(Co_LeaveLayout());
		}

		//// RVA: 0x171AF04 Offset: 0x171AF04 VA: 0x171AF04
		private void ValkyrieSelectDetach()
		{
			IsReturn = false;
			m_view.JBHBEKJHLFE(formationId, selectformationIndex, 0);
			MenuScene.Instance.Mount(TransitionUniqueId.OFFERSELECT_OFFERFORMATION, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			this.StartCoroutineWatched(Co_LeaveLayout());
		}

		//// RVA: 0x171AB20 Offset: 0x171AB20 VA: 0x171AB20
		private bool SelectionAnotherPlatoon()
		{
			if (m_SeriesValkyrieList[m_SelectSeries][m_Select] != null && m_SeriesValkyrieList[m_SelectSeries][m_Select].LABKKJAGDFN_FormationId != formationId)
				return m_SeriesValkyrieList[m_SelectSeries][m_Select].LABKKJAGDFN_FormationId < 1;
			return true;
		}
	}
}
