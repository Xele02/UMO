using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class LayoutPopupRecordPlateController : IDisposable
	{
		private const int LIST_ITEM_NUM = 3;
		private const int LIST_INFO_ITEM_NUM = 7;
		//private PopupRecordPlateOverlapSetting m_overlapSetting; // 0x18
		private LayoutOverlapPlateLvup m_overlapLvup; // 0x1C
		//private PopupOverlapListSetting m_overlapListSetting; // 0x20
		private RecordPlateUtility.eSceneType m_sceneType; // 0x24
		private SceneCardTextureCache m_sceneCard; // 0x28
		private SceneFrameTextureCache m_sceneFrame; // 0x2C
		//private PopupAddEpisodeContentSetting m_newEpisodeSetting; // 0x30
		//private PopupGachaSkillUpSetting m_gachaSkillUpSetting; // 0x34
		private KiraProductController m_kiraProduct; // 0x38
		//private PopupAddEpisodeScrollSetting m_newEpisodeScrollSetting; // 0x3C
		private string[] m_bundleNames = new string[3] { "ly/073.xab", "ly/074.xab", "ly/057.xab" }; // 0x40
		private Dictionary<string, int> m_bundleCounter = new Dictionary<string, int>(8); // 0x44

		public GameObject Parent { get; set; } // 0x8
		public GameObject CanvasParent { get; set; } // 0xC
		public MonoBehaviour mb { get; set; } // 0x10
		public bool IsShowRarityUp { get; private set; } // 0x14
		public bool IsShowKiraUp { get; private set; } // 0x15
		public bool IsLoadBundle { get; private set; } // 0x48

		// RVA: 0x177A218 Offset: 0x177A218 VA: 0x177A218
		public void Update()
		{
			if (m_sceneCard != null)
				m_sceneCard.Update();
			if (m_sceneFrame != null)
				m_sceneFrame.Update();
		}

		//// RVA: 0x177A254 Offset: 0x177A254 VA: 0x177A254
		public void Setup(RecordPlateUtility.eSceneType sceneType)
		{
			TodoLogger.Log(0, "Setup");
		}

		//// RVA: 0x177A420 Offset: 0x177A420 VA: 0x177A420
		//private void PopupShowNewGet(GONMPHKGKHI.LCMJJMNMIKG info, Action callback) { }

		//// RVA: 0x177A664 Offset: 0x177A664 VA: 0x177A664
		//private void PopupShowEpisode(int episodeId, LayoutPopupAddEpisode.Type type, Action callback) { }

		//// RVA: 0x177A910 Offset: 0x177A910 VA: 0x177A910
		//private void PopupShowAddScrollEpisode(List<int> episodeIds, LayoutPopupAddEpisode.Type type, Action callback) { }

		//// RVA: 0x177ABBC Offset: 0x177ABBC VA: 0x177ABBC
		//private void PopupShowList(List<GONMPHKGKHI.LCMJJMNMIKG> list, Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70BD2C Offset: 0x70BD2C VA: 0x70BD2C
		//// RVA: 0x177B0D0 Offset: 0x177B0D0 VA: 0x177B0D0
		public IEnumerator ListPhase(List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> highList, List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> infoList, Action callback)
		{
			TodoLogger.Log(0, "ListPhase");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70BDA4 Offset: 0x70BDA4 VA: 0x70BDA4
		//// RVA: 0x177B1B0 Offset: 0x177B1B0 VA: 0x177B1B0
		public IEnumerator RarityUpPhase(List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> highList, Action callback)
		{
			TodoLogger.Log(0, "RarityUpPhase");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70BE1C Offset: 0x70BE1C VA: 0x70BE1C
		//// RVA: 0x177B290 Offset: 0x177B290 VA: 0x177B290
		public IEnumerator SkillEvolutionPhase(List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> highList, Action callback)
		{
			TodoLogger.Log(0, "SkillEvolutionPhase");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70BE94 Offset: 0x70BE94 VA: 0x70BE94
		//// RVA: 0x177B370 Offset: 0x177B370 VA: 0x177B370
		//private IEnumerator PopupActiveSkillUP(GCIJNCFDNON view1, GCIJNCFDNON view2) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70BF0C Offset: 0x70BF0C VA: 0x70BF0C
		//// RVA: 0x177B450 Offset: 0x177B450 VA: 0x177B450
		//private IEnumerator PopupCenterSkillUP(GCIJNCFDNON view1, GCIJNCFDNON view2) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70BF84 Offset: 0x70BF84 VA: 0x70BF84
		//// RVA: 0x177B530 Offset: 0x177B530 VA: 0x177B530
		//private IEnumerator PopupLiveSkillUP(GCIJNCFDNON view1, GCIJNCFDNON view2) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70BFFC Offset: 0x70BFFC VA: 0x70BFFC
		//// RVA: 0x177B610 Offset: 0x177B610 VA: 0x177B610
		//public IEnumerator KiraUpPhase(int sceneId, int baseRare, Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70C074 Offset: 0x70C074 VA: 0x70C074
		//// RVA: 0x177B708 Offset: 0x177B708 VA: 0x177B708
		public IEnumerator NewGetPhase(List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> infoList, Action callback)
		{
			TodoLogger.Log(0, "NewGetPhase");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C0EC Offset: 0x70C0EC VA: 0x70C0EC
		//// RVA: 0x177B7E8 Offset: 0x177B7E8 VA: 0x177B7E8
		public IEnumerator EpisodePhase(GONMPHKGKHI_RewardView.CECMLGBLHHG type, List<int> episodeList, Action callback)
		{
			TodoLogger.Log(0, "EpisodePhase");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C164 Offset: 0x70C164 VA: 0x70C164
		//// RVA: 0x177B8E0 Offset: 0x177B8E0 VA: 0x177B8E0
		public IEnumerator GetPosterPhase(List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> posterList, Action callback)
		{
			TodoLogger.Log(0, "GetPosterPhase");
			yield return null;
		}

		// RVA: 0x177B9C0 Offset: 0x177B9C0 VA: 0x177B9C0 Slot: 4
		public void Dispose()
		{
			foreach(var k in m_bundleCounter)
			{
				for(int i = 0; i < k.Value; i++)
				{
					AssetBundleManager.UnloadAssetBundle(k.Key, false);
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C1DC Offset: 0x70C1DC VA: 0x70C1DC
		//// RVA: 0x177BC20 Offset: 0x177BC20 VA: 0x177BC20
		//private IEnumerator LoadLayoutNewEpisodeSetup(GONMPHKGKHI.CECMLGBLHHG type, Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70C254 Offset: 0x70C254 VA: 0x70C254
		//// RVA: 0x177BD00 Offset: 0x177BD00 VA: 0x177BD00
		//private IEnumerator LoadLayoutNewEpisodeListSetup(GONMPHKGKHI.CECMLGBLHHG type, Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70C2CC Offset: 0x70C2CC VA: 0x70C2CC
		//// RVA: 0x177BDE0 Offset: 0x177BDE0 VA: 0x177BDE0
		//private IEnumerator LoadLayoutPlate(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70C344 Offset: 0x70C344 VA: 0x70C344
		//// RVA: 0x177BEA8 Offset: 0x177BEA8 VA: 0x177BEA8
		//private IEnumerator LoadLayoutPlateLvup(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70C3BC Offset: 0x70C3BC VA: 0x70C3BC
		//// RVA: 0x177BF70 Offset: 0x177BF70 VA: 0x177BF70
		//private IEnumerator LoadLayoutNewEpisode(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70C434 Offset: 0x70C434 VA: 0x70C434
		//// RVA: 0x177C038 Offset: 0x177C038 VA: 0x177C038
		//private IEnumerator LoadLayoutNewEpisodeList(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70C4AC Offset: 0x70C4AC VA: 0x70C4AC
		//// RVA: 0x177C100 Offset: 0x177C100 VA: 0x177C100
		//private IEnumerator InitializeSceneCard(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70C524 Offset: 0x70C524 VA: 0x70C524
		//// RVA: 0x177C1C8 Offset: 0x177C1C8 VA: 0x177C1C8
		//private IEnumerator IsReadyLayoutRuntime(List<LayoutUGUIScriptBase> scriptBase) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70C59C Offset: 0x70C59C VA: 0x70C59C
		//// RVA: 0x177C274 Offset: 0x177C274 VA: 0x177C274
		//private IEnumerator LoadLayout(string bundleName, string assetName, Action<GameObject> callback) { }

		//// RVA: 0x177C37C Offset: 0x177C37C VA: 0x177C37C
		private void AddBundleCounter(string bundleName)
		{
			if(m_bundleCounter.ContainsKey(bundleName))
			{
				m_bundleCounter[bundleName]++;
			}
			else
			{
				m_bundleCounter.Add(bundleName, 1);
			}
		}

		//// RVA: 0x177C490 Offset: 0x177C490 VA: 0x177C490
		public void LoadAssetBundle()
		{
			IsLoadBundle = false;
			GameManager.Instance.StartCoroutine(UnionBundle());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C634 Offset: 0x70C634 VA: 0x70C634
		//// RVA: 0x177C548 Offset: 0x177C548 VA: 0x177C548
		private IEnumerator UnionBundle()
		{
			int i;

			//0x1782228
			for(i = 0; i < m_bundleNames.Length; i++)
			{
				UnionAssetBundleLoadOperation operation = AssetBundleManager.LoadUnionAssetBundle(m_bundleNames[i]);
				AddBundleCounter(m_bundleNames[i]);
				yield return operation;
			}
			IsLoadBundle = true;
		}

		//// RVA: 0x177B9C4 Offset: 0x177B9C4 VA: 0x177B9C4
		//public void UnloadAssetBundle() { }

		//// RVA: 0x177A388 Offset: 0x177A388 VA: 0x177A388
		//private void SetupSceneCard() { }

		//// RVA: 0x177A21C Offset: 0x177A21C VA: 0x177A21C
		//private void SceneCardUpdete() { }

		//// RVA: 0x177C5F4 Offset: 0x177C5F4 VA: 0x177C5F4
		//private bool IsLoadingSceneCard() { }

		//// RVA: 0x177C650 Offset: 0x177C650 VA: 0x177C650
		//private void TerminatedSceneCard(List<GONMPHKGKHI.LCMJJMNMIKG> highList) { }

		//// RVA: 0x177C72C Offset: 0x177C72C VA: 0x177C72C
		//private void ShowTutorial_21() { }

		//// RVA: 0x177C850 Offset: 0x177C850 VA: 0x177C850
		//private bool CheckTutorialFunc_21(TutorialConditionId conditionId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70C6AC Offset: 0x70C6AC VA: 0x70C6AC
		//// RVA: 0x177C888 Offset: 0x177C888 VA: 0x177C888
		//private IEnumerator Co_ShowTutorial_39(PopupWindowControl control) { }

		//// RVA: 0x177C950 Offset: 0x177C950 VA: 0x177C950
		//private bool CheckTutorialFunc_39(TutorialConditionId conditionId) { }

		//[CompilerGeneratedAttribute] // RVA: 0x70C724 Offset: 0x70C724 VA: 0x70C724
		//// RVA: 0x177CB64 Offset: 0x177CB64 VA: 0x177CB64
		//private void <LoadLayoutPlate>b__51_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x70C734 Offset: 0x70C734 VA: 0x70C734
		//// RVA: 0x177CD18 Offset: 0x177CD18 VA: 0x177CD18
		//private void <LoadLayoutPlateLvup>b__52_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x70C744 Offset: 0x70C744 VA: 0x70C744
		//// RVA: 0x177CE44 Offset: 0x177CE44 VA: 0x177CE44
		//private void <LoadLayoutNewEpisode>b__53_0(GameObject instance) { }
	}
}
