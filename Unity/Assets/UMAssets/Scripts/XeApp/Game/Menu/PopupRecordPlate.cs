using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class PopupRecordPlate : MonoBehaviour, IDisposable
	{
		private LayoutPopupRecordPlateController m_prpController = new LayoutPopupRecordPlateController(); // 0xC

		//// RVA: 0x1619DA0 Offset: 0x1619DA0 VA: 0x1619DA0
		public static IEnumerator Show(RecordPlateUtility.eSceneType sceneType, Action callbackClose, bool allReceive = false)
		{
			RecordPlateUtility.IsResultConfirm = false;
			return Coroutine_Show(sceneType, callbackClose, allReceive);
		}

		//// RVA: 0x1619EFC Offset: 0x1619EFC VA: 0x1619EFC
		//public static IEnumerator Show(RecordPlateUtility.eSceneType sceneType, JKNGJFOBADP inventoryUtil, Action callbackClose, bool allReceive = False) { }

		//// RVA: 0x1619FA8 Offset: 0x1619FA8 VA: 0x1619FA8
		//public static IEnumerator ResultShow(RecordPlateUtility.eSceneType sceneType, Action callbackClose, bool allReceive = False) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70D414 Offset: 0x70D414 VA: 0x70D414
		//// RVA: 0x1619E3C Offset: 0x1619E3C VA: 0x1619E3C
		private static IEnumerator Coroutine_Show(RecordPlateUtility.eSceneType sceneType, Action callbackClose, bool allReceive)
		{
			PopupRecordPlate prp;

			//0x161AC9C
			GameManager.Instance.AddPushBackButtonHandler(BackButtonEmpty);
			if (MenuScene.Instance != null)
			{
				MenuScene.Instance.RaycastDisable();
			}
			yield return null;

			prp = Create(null);
			yield return prp.Co_MainPhase(sceneType, allReceive);
			if (callbackClose != null)
				callbackClose();
			prp.Dispose();
			if (MenuScene.Instance != null)
				MenuScene.Instance.RaycastEnable();
			GameManager.Instance.RemovePushBackButtonHandler(BackButtonEmpty);
		}

		//// RVA: 0x161A064 Offset: 0x161A064 VA: 0x161A064
		public static PopupRecordPlate Create(Transform parent)
		{
			return new GameObject("PopupRecordPlate").AddComponent<PopupRecordPlate>();
		}

		// RVA: 0x161A108 Offset: 0x161A108 VA: 0x161A108 Slot: 4
		public void Dispose()
		{
			RecordPlateUtility.Clear();
			m_prpController.Dispose();
			m_prpController = null;
			Destroy(gameObject);
		}

		//// RVA: 0x161A1F8 Offset: 0x161A1F8 VA: 0x161A1F8
		private static void BackButtonEmpty()
		{
			return;
		}

		// RVA: 0x161A1FC Offset: 0x161A1FC VA: 0x161A1FC
		public void Awake()
		{
			return;
		}

		// RVA: 0x161A200 Offset: 0x161A200 VA: 0x161A200
		public void Start()
		{
			return;
		}

		// RVA: 0x161A204 Offset: 0x161A204 VA: 0x161A204
		private void Update()
		{
			if (m_prpController != null)
				m_prpController.Update();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70D48C Offset: 0x70D48C VA: 0x70D48C
		//// RVA: 0x161A218 Offset: 0x161A218 VA: 0x161A218
		private IEnumerator Co_MainPhase(RecordPlateUtility.eSceneType sceneType, bool allReceive)
		{
			GONMPHKGKHI_RewardView viewData; // 0x1C
			List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> highList; // 0x20
			List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> infoList; // 0x24
			List<int> episodeList; // 0x28

			//0x161A3F0
			m_prpController.mb = this;
			m_prpController.LoadAssetBundle();
			while(!m_prpController.IsLoadBundle)
				yield return null;
			m_prpController.Parent = gameObject;
			m_prpController.CanvasParent = GameObject.Find("Canvas-Popup");
			viewData = RecordPlateUtility.ViewInitialize(sceneType, allReceive);
			if (GameManager.Instance.IsTutorial)
				yield break;
			m_prpController.Setup(sceneType);
			highList = new List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo>();
			infoList = new List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo>();
			episodeList = new List<int>();
			if(RecordPlateUtility.IsResultConfirm)
			{
				if (!viewData.JDKOAKDLHMG(/*4*/GONMPHKGKHI_RewardView.CECMLGBLHHG.INJNLJHGGKB, ref highList, ref infoList, ref episodeList))
					yield break;
				yield return m_prpController.ListPhase(highList, infoList, null);
			}
			else
			{
				if(sceneType != RecordPlateUtility.eSceneType.Gacha && viewData.JDKOAKDLHMG(/*1*/GONMPHKGKHI_RewardView.CECMLGBLHHG.GBIDBHKEPGL, ref highList, ref infoList, ref episodeList))
				{
					yield return m_prpController.NewGetPhase(infoList, null);
				}
				if(viewData.JDKOAKDLHMG(/*2*/GONMPHKGKHI_RewardView.CECMLGBLHHG.AGLFBCCGHJM, ref highList, ref infoList, ref episodeList))
				{
					yield return m_prpController.EpisodePhase(GONMPHKGKHI_RewardView.CECMLGBLHHG.AGLFBCCGHJM/*2*/, episodeList, null);
				}
				if (viewData.JDKOAKDLHMG(GONMPHKGKHI_RewardView.CECMLGBLHHG.NNEOHGFGLKM/*3*/, ref highList, ref infoList, ref episodeList))
				{
					yield return m_prpController.RarityUpPhase(highList, null);
					yield return m_prpController.SkillEvolutionPhase(highList, null);
				}
				if(sceneType != RecordPlateUtility.eSceneType.RarityUp)
				{
					if (viewData.JDKOAKDLHMG(/*4*/GONMPHKGKHI_RewardView.CECMLGBLHHG.INJNLJHGGKB, ref highList, ref infoList, ref episodeList))
					{
						yield return m_prpController.ListPhase(highList, infoList, null);
					}
				}
				if (viewData.JDKOAKDLHMG(/*7*/GONMPHKGKHI_RewardView.CECMLGBLHHG.BKHAAGAAIHJ, ref highList, ref infoList, ref episodeList))
				{
					yield return m_prpController.EpisodePhase(/*7*/GONMPHKGKHI_RewardView.CECMLGBLHHG.BKHAAGAAIHJ, episodeList, null);
				}
				if(HNDLICBDEMI.AFGKIJMPNNN())
				{
					if (viewData.JDKOAKDLHMG(/*8*/GONMPHKGKHI_RewardView.CECMLGBLHHG.JCGKGFLCKCP, ref highList, ref infoList, ref episodeList))
					{
						yield return m_prpController.GetPosterPhase(infoList, null);
					}
				}
				highList = null;
				infoList = null;
				episodeList = null;
			}
		}

		//// RVA: 0x161A2F8 Offset: 0x161A2F8 VA: 0x161A2F8
		//private bool CheckTutorialCondition(TutorialConditionId conditionId) { }
	}
}
