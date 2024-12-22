using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public abstract class RankingSceneBase : TransitionRoot
	{
		public class WaitForFrame : CustomYieldInstruction
		{
			private int waitFrame; // 0x8
			private int startFrame; // 0xC

			public override bool keepWaiting { get { return Time.frameCount <= waitFrame + startFrame; } } // 0xCF7CD8

			// RVA: 0xCF4614 Offset: 0xCF4614 VA: 0xCF4614
			public WaitForFrame(int waitFrame)
			{
				this.waitFrame = waitFrame;
				this.startFrame = Time.frameCount;
			}

			//// RVA: 0xCF7C1C Offset: 0xCF7C1C VA: 0xCF7C1C
			public void Reset(int waitFrame)
			{
				this.waitFrame = waitFrame;
				startFrame = Time.frameCount;
			}
		}
		
		protected GeneralListWindow m_windowUi; // 0x48
		protected List<RankingListElemBase> m_elems = new List<RankingListElemBase>(); // 0x4C
		protected SwapScrollList m_scrollList; // 0x50
		protected List<DivaIconDecoration> m_divaDecos = new List<DivaIconDecoration>(); // 0x54
		protected List<SceneIconDecoration> m_sceneDecos = new List<SceneIconDecoration>(); // 0x58
		private bool m_isFriendList; // 0x5C
		private int m_listAddBorderPosition = -1; // 0x60
		private List<RankingListInfo> m_totalInfoList = new List<RankingListInfo>(); // 0x64
		private List<RankingListInfo> m_friendInfoList = new List<RankingListInfo>(); // 0x68
		private bool m_receivedTotalInfo; // 0x6C
		private bool m_receivedFriendInfo; // 0x6D
		private WaitForFrame waitForFrame; // 0x74
		private const int VisibleListItemCount = 2;

		private List<RankingListInfo> currentInfoList { get; set; } // 0x70
		protected bool isFriendList { get { return m_isFriendList; } } //0xCF4564

		// RVA: 0xCF456C Offset: 0xCF456C VA: 0xCF456C Slot: 4
		protected override void Awake()
		{
			base.Awake();
			waitForFrame = new WaitForFrame(3);
			this.StartCoroutineWatched(Co_LoadResources());
		}

		// RVA: 0xCF46CC Offset: 0xCF46CC VA: 0xCF46CC Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			m_windowUi.Hide();
			m_windowUi.SetMessage("");
			m_windowUi.SetMessageVisible(false);
			Initialize();
		}

		// RVA: 0xCF47B8 Offset: 0xCF47B8 VA: 0xCF47B8 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			m_windowUi.transform.SetAsLastSibling();
			return true;
		}

		// RVA: 0xCF4808 Offset: 0xCF4808 VA: 0xCF4808 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_windowUi.Enter();
		}

		// RVA: 0xCF4834 Offset: 0xCF4834 VA: 0xCF4834 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_windowUi.IsPlaying();
		}

		// RVA: 0xCF4864 Offset: 0xCF4864 VA: 0xCF4864 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_windowUi.Leave();
		}

		// RVA: 0xCF4890 Offset: 0xCF4890 VA: 0xCF4890 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_windowUi.IsPlaying();
		}

		// RVA: 0xCF48C0 Offset: 0xCF48C0 VA: 0xCF48C0 Slot: 14
		protected override void OnDestoryScene()
		{
			Release();
		}

		// RVA: 0xCF48D0 Offset: 0xCF48D0 VA: 0xCF48D0
		private void Update()
		{
			if (m_listAddBorderPosition < 0)
				return;
			if (m_scrollList.ListTopPosition < m_listAddBorderPosition)
				return;
			m_listAddBorderPosition = -1;
			MenuScene.Instance.RaycastDisable();
			m_scrollList.SetEnableScrollBar(false);
			GetRankingListAdditive(false);
		}

		//// RVA: -1 Offset: -1 Slot: 31
		protected abstract void Initialize();

		//// RVA: -1 Offset: -1 Slot: 32
		protected abstract void Release();

		//// RVA: -1 Offset: -1 Slot: 33
		protected abstract int GetCurrentBaseRank();

		//// RVA: -1 Offset: -1 Slot: 34
		protected abstract void GetRankingList(int baseRank, int rankingIdx);

		//// RVA: -1 Offset: -1 Slot: 35
		protected abstract void GetRankingListAdditive(bool isUpper);

		//// RVA: -1 Offset: -1 Slot: 36
		protected abstract string GetRankingNotFoundMessage();

		//// RVA: 0xCF49EC Offset: 0xCF49EC VA: 0xCF49EC Slot: 37
		protected virtual void OnSetupTotalRanking()
		{
			return;
		}

		//// RVA: 0xCF49F0 Offset: 0xCF49F0 VA: 0xCF49F0 Slot: 38
		protected virtual void OnSetupFriendRanking()
		{
			return;
		}

		//// RVA: 0xCF49F4 Offset: 0xCF49F4 VA: 0xCF49F4
		protected bool CheckTransitByReturn()
		{
			return PrevTransition == TransitionList.Type.PROFIL;
		}

		//// RVA: 0xCF4A18 Offset: 0xCF4A18 VA: 0xCF4A18
		protected int GetListEdgeRank(bool isUpper)
		{
			if(isUpper)
			{
				return currentInfoList[0].rankingOrder;
			}
			else
			{
				return currentInfoList[currentInfoList.Count - 1].rankingOrder;
			}
		}

		//// RVA: 0xCF4B24 Offset: 0xCF4B24 VA: 0xCF4B24
		protected void InitializeDecos()
		{
			m_divaDecos.Capacity = m_elems.Count;
			m_sceneDecos.Capacity = m_elems.Count;
			for(int i = 0; i < m_elems.Count; i++)
			{
				if(m_elems[i].GetDivaIconObject() != null)
				{
					m_divaDecos.Add(new DivaIconDecoration(m_elems[i].GetDivaIconObject(), DivaIconDecoration.Size.S, true, true, null, null));
				}
				if(m_elems[i].GetSceneIconObject() != null)
				{
					m_sceneDecos.Add(new SceneIconDecoration(m_elems[i].GetSceneIconObject(), SceneIconDecoration.Size.M, null, null));
				}
			}
		}

		//// RVA: 0xCF4EAC Offset: 0xCF4EAC VA: 0xCF4EAC
		protected void ReleaseDecos()
		{
			for(int i = 0; i < m_divaDecos.Count; i++)
			{
				m_divaDecos[i].Release();
			}
			m_divaDecos.Clear();
			for(int i = 0; i < m_sceneDecos.Count; i++)
			{
				m_sceneDecos[i].Release();
			}
			m_sceneDecos.Clear();
		}

		//// RVA: 0xCF5050 Offset: 0xCF5050 VA: 0xCF5050
		protected void OnSelectListItem(int value, SwapScrollListContent content)
		{
			RankingListInfo info = currentInfoList[content.Index];
			if(value == 0)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				ProfilDateArgs arg = new ProfilDateArgs();
				arg.data = info.friend;
				arg.infoType = ProfilMenuLayout.InfoType.STATS;
				if(ParentTransition == TransitionList.Type.RAID)
				{
					arg.infoType = ProfilMenuLayout.InfoType.PLAYER;
					arg.isFavorite = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GAAOPEGIPKA_FavoritePlayer.FFKIDMKHIOE(info.friend.MLPEHNBNOGD_Id);
					arg.btnType = NKGJPJPHLIF.HHCJCDFCLOB.CAFHLEFMMGD_GetPlayerId() == info.friend.MLPEHNBNOGD_Id ? ProfilMenuLayout.ButtonType.None : ProfilMenuLayout.ButtonType.Raid;
				}
				MenuScene.Instance.Call(TransitionList.Type.PROFIL, arg, true);
			}
		}

		//// RVA: 0xCF5370 Offset: 0xCF5370 VA: 0xCF5370
		protected void ResetReceivedFlag()
		{
			m_receivedTotalInfo = false;
			m_receivedFriendInfo = false;
		}

		//// RVA: 0xCF537C Offset: 0xCF537C VA: 0xCF537C
		protected void SetupTotalRanking()
		{
			ResetReceivedFlag();
			m_windowUi.SelectTotalRankingTab();
			m_listAddBorderPosition = -1;
			m_isFriendList = false;
			currentInfoList = m_totalInfoList;
			OnSetupTotalRanking();
			if(!m_receivedTotalInfo)
			{
				m_scrollList.SetItemCount(0);
				m_scrollList.SetPosition(0, 0, 0, false);
				m_scrollList.VisibleRegionUpdate();
				MenuScene.Instance.RaycastDisable();
				m_scrollList.SetEnableScrollBar(false);
				GetRankingList(GetCurrentBaseRank(), 0);
			}
			else
			{
				m_scrollList.SetItemCount(currentInfoList.Count);
				m_scrollList.SetPosition(0, 0, 0, false);
				m_scrollList.VisibleRegionUpdate();
			}
		}

		//// RVA: 0xCF55F8 Offset: 0xCF55F8 VA: 0xCF55F8
		protected void SetupFriendRanking()
		{
			ResetReceivedFlag();
			m_windowUi.SelectFriendRankingTab();
			m_listAddBorderPosition = -1;
			m_isFriendList = true;
			currentInfoList = m_friendInfoList;
			OnSetupFriendRanking();
			if(!m_receivedFriendInfo)
			{
				m_scrollList.SetItemCount(0);
				m_scrollList.SetPosition(0, 0, 0, false);
				m_scrollList.VisibleRegionUpdate();
				MenuScene.Instance.RaycastDisable();
				m_scrollList.SetEnableScrollBar(false);
				GetRankingList(GetCurrentBaseRank(), 0);
			}
			else
			{
				m_scrollList.SetItemCount(currentInfoList.Count);
				m_scrollList.SetPosition(0, 0, 0, false);
				m_scrollList.VisibleRegionUpdate();
				m_windowUi.SetMessageVisible(currentInfoList.Count < 1);
				if (currentInfoList.Count > 0)
					return;
				m_windowUi.SetMessage(GetRankingNotFoundMessage());
			}
		}

		//// RVA: 0xCF5920 Offset: 0xCF5920 VA: 0xCF5920
		protected void OnReceivedRankingList(int dir, List<IBIGBMDANNM> list)
		{
			currentInfoList.Clear();
			if(list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					EAJCBFGKKFA_FriendInfo data = new EAJCBFGKKFA_FriendInfo();
					data.KHEKNNFCAOI(list[i]);
					RankingListInfo info = new RankingListInfo(i, true, data);
					currentInfoList.Add(info);
					info.TryInstall();
				}
			}
			m_windowUi.SetMessageVisible(currentInfoList.Count < 1);
			if(currentInfoList.Count < 1)
			{
				m_windowUi.SetMessage(GetRankingNotFoundMessage());
			}
			OnChangedRankingList(0);
			if (!m_isFriendList)
				m_receivedTotalInfo = true;
			else
				m_receivedFriendInfo = true;
			this.StartCoroutineWatched(Co_WaitDownLoadAsset());
		}

		//// RVA: 0xCF6048 Offset: 0xCF6048 VA: 0xCF6048
		protected void OnReceivedRankingList(List<RankingListInfo> a_list)
		{
			currentInfoList.Clear();
			if(a_list != null)
			{
				for(int i = 0; i < a_list.Count; i++)
				{
					a_list[i].TryInstall();
				}
				currentInfoList.AddRange(a_list);
			}
			m_windowUi.SetMessageVisible(currentInfoList.Count < 1);
			if(currentInfoList.Count < 1)
			{
				m_windowUi.SetMessage(GetRankingNotFoundMessage());
			}
			OnChangedRankingList(0);
			if (!m_isFriendList)
				m_receivedTotalInfo = true;
			else
				m_receivedFriendInfo = true;
			this.StartCoroutineWatched(Co_WaitDownLoadAsset());
		}

		//// RVA: 0xCF6284 Offset: 0xCF6284 VA: 0xCF6284
		protected void OnReceivedRankingListAdditive(int dir, List<IBIGBMDANNM> list)
		{
			if(list != null && list.Count > 0)
			{
				for(int i = 0; i < list.Count; i++)
				{
					EAJCBFGKKFA_FriendInfo data = new EAJCBFGKKFA_FriendInfo();
					data.KHEKNNFCAOI(list[i]);
					RankingListInfo info = new RankingListInfo(i, true, data);
					if(dir < 0)
						currentInfoList.Insert(i, info);
					else
						currentInfoList.Add(info);
					info.TryInstall();
				}
				OnChangedRankingList(list.Count * (dir < 0 ? -1 : 1));
			}
			this.StartCoroutineWatched(Co_WaitDownLoadAsset());
		}

		//// RVA: 0xCF64C4 Offset: 0xCF64C4 VA: 0xCF64C4
		protected void OnReceivedRankingListAdditive(int dir, List<RankingListInfo> a_list)
		{
			if(a_list != null && a_list.Count > 0)
			{
				for(int i = 0; i < a_list.Count; i++)
				{
					if(dir < 0)
						currentInfoList.Insert(i, a_list[i]);
					else
						currentInfoList.Add(a_list[i]);
					a_list[i].TryInstall();
				}
				OnChangedRankingList(a_list.Count * (dir < 0 ? -1 : 1));
			}
			this.StartCoroutineWatched(Co_WaitDownLoadAsset());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E15E4 Offset: 0x6E15E4 VA: 0x6E15E4
		//// RVA: 0xCF5FBC Offset: 0xCF5FBC VA: 0xCF5FBC
		private IEnumerator Co_WaitDownLoadAsset()
		{
			//0xCF7A50
			waitForFrame.Reset(3);
			yield return waitForFrame;
			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			MenuScene.Instance.RaycastEnable();
			m_scrollList.SetEnableScrollBar(true);
		}

		//// RVA: 0xCF66D4 Offset: 0xCF66D4 VA: 0xCF66D4
		protected void OnRankingError()
		{
			Debug.LogWarning("Ranking Error.");
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xCF67B4 Offset: 0xCF67B4 VA: 0xCF67B4
		protected void OnNetError()
		{
			UnityEngine.Debug.LogWarning("Net Error");
			if(MenuScene.Instance.IsTransition())
				GotoTitle();
			else
				MenuScene.Instance.GotoTitle();
		}

		//// RVA: 0xCF6904 Offset: 0xCF6904 VA: 0xCF6904
		protected void OnClickTotalButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			SetupTotalRanking();
		}

		//// RVA: 0xCF6968 Offset: 0xCF6968 VA: 0xCF6968
		protected void OnClickFriendButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			SetupFriendRanking();
		}

		//// RVA: 0xCF5BE8 Offset: 0xCF5BE8 VA: 0xCF5BE8
		protected void OnChangedRankingList(int changeDirection)
		{
			m_scrollList.SetItemCount(currentInfoList.Count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
			{
				//0xCF71E0
				GeneralListContent c = content as GeneralListContent;
				OnUpdateListItem(index, c, currentInfoList[index]);
			});
			if(changeDirection == 0)
			{
				int s = GetCurrentBaseRank();
				if(s == 0)
				{
					for(int i = 0; i < currentInfoList.Count; i++)
					{
						if (currentInfoList[i].isOwner)
							s = i;
					}
				}
				int c = 0;
				if(currentInfoList.Count > 1)
				{
					c = s;
					if(currentInfoList.Count - 2 < s)
					{
						c = currentInfoList.Count - 2;
					}
				}
				m_scrollList.SetPosition(c, 0, 0, false);
			}
			m_scrollList.VisibleRegionUpdate();
			m_listAddBorderPosition = -1;
			if(currentInfoList.Count > 0)
			{
				m_listAddBorderPosition = Mathf.Max(0, currentInfoList.Count - 4);
			}
		}

		//// RVA: 0xCF69CC Offset: 0xCF69CC VA: 0xCF69CC
		protected void OnUpdateListItem(int index, GeneralListContent content, RankingListInfo info)
		{
			RankingListElemBase elem = content.GetElemUI<RankingListElemBase>();
			elem.SetName(info.name);
			elem.SetLevel(info.playerLevel.ToString());
			elem.SetScore(info.score.ToString());
			elem.SetDamage(info.score.ToString());
			elem.SetRankOrder(info.rankingOrder);
			elem.SetMusicRatio(info.musicRatio.ToString());
			elem.SetMusicRank(info.scoreRatingRank);
			elem.SetKira(info.isKira);
			elem.SetDivaIconDelegate(info.GetDivaIconTex, GameManager.Instance.DivaIconCache.SetLoadingIcon);
			elem.SetSceneIconDelegate(info.GetSceneIconTex, GameManager.Instance.SceneIconCache.SetLoadingTexture);
			int idx = m_elems.IndexOf(elem);
			if(m_divaDecos.Count > 0)
			{
				m_divaDecos[idx].SetActive(true);
				m_divaDecos[idx].Change(info.friend.JIGONEMPPNP_Diva, info.friend, DisplayType.Level, info.friend.AFBMEMCHJCL_MainScene);
			}
			if(m_sceneDecos.Count > 0)
			{
				m_sceneDecos[idx].SetActive(true);
				m_sceneDecos[idx].Change(info.friend.AFBMEMCHJCL_MainScene, DisplayType.Level);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E165C Offset: 0x6E165C VA: 0x6E165C
		//// RVA: 0xCF4640 Offset: 0xCF4640 VA: 0xCF4640
		private IEnumerator Co_LoadResources()
		{
			//0xCF791C
			yield return Co.R(Co_LoadLayout());
			IsReady = true;
		}

		//// RVA: -1 Offset: -1 Slot: 39
		protected abstract IEnumerator Co_LoadLayout();

		//[IteratorStateMachineAttribute] // RVA: 0x6E16D4 Offset: 0x6E16D4 VA: 0x6E16D4
		//// RVA: 0xCF6F60 Offset: 0xCF6F60 VA: 0xCF6F60
		protected static IEnumerator Co_LoadListElem(string bundleName, string assetName, XeSys.FontInfo font, int elemCount, string elemNameFormat, Action<LayoutUGUIRuntime> onLoadedElem)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xCF7438
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, assetName);
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xCF7320
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = string.Format(elemNameFormat, 0);
				onLoadedElem(baseRuntime);
			}));
			for(int i = 1; i < elemCount; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name = string.Format(elemNameFormat, i);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				onLoadedElem(r);
			}
		}
	}
}
