using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.Gfx;
using static XeSys.Math;

namespace XeApp.Game.Menu
{
	public class SceneGrowthScene : TransitionRoot
	{
		private struct InfinityPanelUnlockInfo
		{
			public short index; // 0x0
			public short count; // 0x2

			//// RVA: 0x7FBE90 Offset: 0x7FBE90 VA: 0x7FBE90
			//public void Init() { }

			//// RVA: 0x7FBE9C Offset: 0x7FBE9C VA: 0x7FBE9C
			//public bool IsValid() { }
		}

		[SerializeField]
		private SceneGrowth3dEffect[] m_3dEffectPrefab; // 0x48
		[SerializeField]
		private GameObject[] m_panelLoopEffectPrefab; // 0x4C
		private SceneGrowthStatus m_statusWindow; // 0x50
		private SceneGrowthBoard m_mainBoard; // 0x54
		private SceneGrowthBoard m_subBoard; // 0x58
		private SceneGrowthBoard m_currentBoard; // 0x5C
		private SceneGrowthStart m_startPanel; // 0x60
		private SceneGrowthInfinityPanel m_infinityPanel; // 0x64
		private SceneGrowthPassButton m_itemPassButtonLayout; // 0x68
		private SceneGrowthUnlockButton m_itemUnlockButtonLayout; // 0x6C
		private List<SceneGrowthPanelBase> m_boardPanelCache = new List<SceneGrowthPanelBase>(); // 0x70
		private List<SceneGrowthPanelBase> m_raycasterChangeList = new List<SceneGrowthPanelBase>(); // 0x74
		private List<SceneGrowthPanel> m_panelObjectCache = new List<SceneGrowthPanel>(); // 0x78
		private List<SceneGrowthPanel> m_usePanelList = new List<SceneGrowthPanel>(); // 0x7C
		private List<SceneGrowthRoad> m_useRoadList = new List<SceneGrowthRoad>(); // 0x80
		private List<ISceneGrowthPanel> m_prodactPanelList = new List<ISceneGrowthPanel>(); // 0x84
		private List<SceneGrowthRoad> m_prodactRoadList = new List<SceneGrowthRoad>(); // 0x88
		private List<SceneGrowthRoad> m_roadObjectCache = new List<SceneGrowthRoad>(); // 0x8C
		private List<LayoutUGUIRuntime> m_panelOpenEffectCache = new List<LayoutUGUIRuntime>(); // 0x90
		private List<SceneGrowth3dEffect> m_panelOpen3dEffectCache = new List<SceneGrowth3dEffect>(); // 0x94
		private LayoutUGUIRuntime m_infinityPanelOpenEffect; // 0x98
		private SceneGrowth3dEffect m_infinityOpen3dEffect; // 0x9C
		private List<GameObject> m_validPanelEffectCache = new List<GameObject>(); // 0xA0
		private List<TweenBase> m_tweenList = new List<TweenBase>(); // 0xA4
		private GameObject m_infinityValidEffect; // 0xA8
		private List<LayoutUGUIRuntime> m_panelAddtiveEffectCache = new List<LayoutUGUIRuntime>(); // 0xAC
		private LayoutUGUIRuntime m_infinityPanelAddtiveEffect; // 0xB0
		private List<short> m_addtivePanelList = new List<short>(); // 0xB4
		private List<short> m_addtiveRoadList = new List<short>(); // 0xB8
		private List<LayoutUGUIScriptBase> m_expandPanelList = new List<LayoutUGUIScriptBase>(); // 0xBC
		private SceneGrowthPanel m_sourcePanel; // 0xC0
		private SceneGrowthRoad[] m_sourceRoad = new SceneGrowthRoad[3]; // 0xC4
		private PIGBBNDPPJC m_episodeData = new PIGBBNDPPJC(); // 0xC8
		private int[] m_addStatuList = new int[22]; // 0xCC
		private bool m_isLoaded; // 0xD0
		private SceneGrowthBoard.BoardType m_boardType = SceneGrowthBoard.BoardType.Main; // 0xD4
		private SceneGrowthBoard.BoardType m_lastBoardType; // 0xD8
		private GCIJNCFDNON_SceneInfo m_viewSceneData; // 0xDC
		private AEKDNMPPOJN m_limitOverData = new AEKDNMPPOJN(); // 0xE0
		private MNDAMOGGJBJ m_viewGrowItemData = new MNDAMOGGJBJ(); // 0xE4
		private CCAAJNJGNDO m_viewEventStoryData = new CCAAJNJGNDO(); // 0xE8
		private List<byte> m_unLockTargetPanelIndex = new List<byte>(100); // 0xEC
		private List<byte> m_unlockTargetRoadIndex = new List<byte>(100); // 0xF0
		private PopupSceneGrowthSetting m_popupSetting = new PopupSceneGrowthSetting(); // 0xF4
		private PopupSceneGrowthConfirmSetting m_popupGrowthConfirmSetting = new PopupSceneGrowthConfirmSetting(); // 0xF8
		private PopupSceneGrowthInfinityPanelSetting m_popupInfinityPanelSetting = new PopupSceneGrowthInfinityPanelSetting(); // 0xFC
		private PopupItemUseConfirmSetting m_popupItemUseConfirmSetting = new PopupItemUseConfirmSetting(); // 0x100
		private PopupItemRarityUpConfirmSetting m_popupItemRarityUpConfirmSetting = new PopupItemRarityUpConfirmSetting(); // 0x104
		private EventStoryOpenListPopupSetting m_popupEventStoryOpenListPopupSetting = new EventStoryOpenListPopupSetting(); // 0x108
		private EpisodeRewardGet m_episodeRewardWindow; // 0x10C
		private int m_lastRewardItemId; // 0x110
		private Canvas m_canvas; // 0x114
		private Material m_effectMaterial; // 0x118
		private bool m_isLoadingAppendAsset; // 0x11C
		private bool m_isShowing; // 0x11D
		private bool m_isBeginner; // 0x11E
		private bool m_isWaitSave; // 0x11F
		private bool m_isSaveError; // 0x120
		private const string BundleName = "ly/019.xab";
		private InfinityPanelUnlockInfo m_infinityPanelUnlockInfo; // 0x122
		private PopPassController m_pop_pass_ctrl; // 0x128
		private TransitionUniqueId m_transitionUniqueId; // 0x12C
		private PopupLuckyLeafSetting m_luckyLeafSetting = new PopupLuckyLeafSetting(); // 0x130
		private PopupLuckyLeafTerminateSetting m_luckyLeafTerminateSetting = new PopupLuckyLeafTerminateSetting(); // 0x134
		private StatusData m_prevStatus = new StatusData(); // 0x138
		private StatusData m_animeStatus = new StatusData(); // 0x13C
		private int m_prevLuck; // 0x140
		private int m_animeLuck; // 0x144
		private int m_prevCenterSkillLevel; // 0x148
		private int m_animeCenterSkillLevel; // 0x14C
		private int m_prevActiveSkillLevel; // 0x150
		private int m_animeActiveSkillLevel; // 0x154
		private int m_prevLiveSkillLevel; // 0x158
		private int m_animeLiveSkillLevel; // 0x15C
		private float m_animeTime; // 0x160
		private bool m_isAddtiveMainBoard; // 0x164
		private bool m_isAddtiveSubBoard; // 0x165
		private bool m_isAddtiveFirstSubBoard; // 0x166
		private bool m_isFirstInfinityPanelOpen; // 0x167
		private static readonly List<IDMPGHMNLHD.NPIEEGNKDEG>[] m_pageStatusTbl = new List<IDMPGHMNLHD.NPIEEGNKDEG>[3]
			{
				new List<IDMPGHMNLHD.NPIEEGNKDEG>()
				{
					IDMPGHMNLHD.NPIEEGNKDEG.KLJAMOGANCA_Life,
					IDMPGHMNLHD.NPIEEGNKDEG.IDFLLFIBKGK_Soul,
					IDMPGHMNLHD.NPIEEGNKDEG.JMLMELKOJND_Vocal,
					IDMPGHMNLHD.NPIEEGNKDEG.MJEJOPJKFNK_Charm,
					IDMPGHMNLHD.NPIEEGNKDEG.HLDDCDBLFGJ,
					IDMPGHMNLHD.NPIEEGNKDEG.NBAPLFKEJBL_Support,
					IDMPGHMNLHD.NPIEEGNKDEG.AFCFOLIHPDB_Fold
				},
				new List<IDMPGHMNLHD.NPIEEGNKDEG>()
				{
					IDMPGHMNLHD.NPIEEGNKDEG.GMKEEAPLKHC_SkillLevel,
					IDMPGHMNLHD.NPIEEGNKDEG.DEKFNLBLKEH_ActiveSkillLevel,
					IDMPGHMNLHD.NPIEEGNKDEG.AJKGPEGCJBH_LiveSkillLevel
				},
				new List<IDMPGHMNLHD.NPIEEGNKDEG>()
				{
					IDMPGHMNLHD.NPIEEGNKDEG.KDNCKIMIGOE
				}
			}; // 0x0
		private StringBuilder m_strBuilder = new StringBuilder(); // 0x168

		//// RVA: 0x10DE974 Offset: 0x10DE974 VA: 0x10DE974
		//private void ClearBoardOpenFlags() { }

		// RVA: 0x10DE980 Offset: 0x10DE980 VA: 0x10DE980
		private void Awake()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_popupSetting.TitleText = bk.GetMessageByLabel("popup_text_09");
			m_popupSetting.WindowSize = SizeType.Middle;
			m_popupGrowthConfirmSetting.TitleText = bk.GetMessageByLabel("popup_text_11");
			m_popupInfinityPanelSetting.TitleText = bk.GetMessageByLabel("growth_popup_title_text04");
			m_popupInfinityPanelSetting.WindowSize = SizeType.Middle;
			m_popupInfinityPanelSetting.m_parent = transform;
			m_luckyLeafTerminateSetting.TitleText = MessageManager.Instance.GetMessage("menu", "limit_over_popup_title");
			m_luckyLeafTerminateSetting.m_parent = transform;
			m_luckyLeafTerminateSetting.WindowSize = SizeType.Middle;
			m_luckyLeafSetting.TitleText = MessageManager.Instance.GetMessage("menu", "limit_over_popup_title");
			m_luckyLeafSetting.m_parent = transform;
			m_luckyLeafSetting.WindowSize = SizeType.Large;
			this.StartCoroutineWatched(LoadLayoutCoroutine());
			m_episodeRewardWindow = gameObject.AddComponent<EpisodeRewardGet>();
			if (m_pop_pass_ctrl == null)
				m_pop_pass_ctrl = gameObject.AddComponent<PopPassController>();
			m_popupEventStoryOpenListPopupSetting.IsCaption = false;
			m_popupEventStoryOpenListPopupSetting.WindowSize = SizeType.Middle;
			m_popupEventStoryOpenListPopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
		}

		// RVA: 0x10DEF80 Offset: 0x10DEF80 VA: 0x10DEF80
		private void Update()
		{
			for(int i = 0; i < m_tweenList.Count; i++)
			{
				m_tweenList[i].UpdateCurve();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x724FD4 Offset: 0x724FD4 VA: 0x724FD4
		//// RVA: 0x10DEEF4 Offset: 0x10DEEF4 VA: 0x10DEEF4
		private IEnumerator LoadLayoutCoroutine()
		{
			//0x10EE6EC
			yield return AssetBundleManager.LoadUnionAssetBundle("ly/tx/019.xab");
			while (!m_episodeRewardWindow.IsLoaded())
				yield return null;
			IsReady = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72504C Offset: 0x72504C VA: 0x72504C
		//// RVA: 0x10DF084 Offset: 0x10DF084 VA: 0x10DF084
		private IEnumerator LoadAppendLayoutCoroutine(bool isAddtiveBoard)
		{
			int loadCount; // 0x30
			AssetBundleLoadLayoutOperationBase layoutOperation; // 0x34
			int roadCount; // 0x38

			//0x10EB528
			loadCount = 0;
			m_isLoadingAppendAsset = true;
			bool isLodingTexture = false;
			if(m_episodeData.DKMLDEDKPBA_HasEpisode)
			{
				isLodingTexture = true;
				GameManager.Instance.EpisodeIconCache.Load(m_episodeData.KELFCMEOPPM_EpId, (IiconTexture texture) =>
				{
					//0x10E70EC
					isLodingTexture = false;
				});
			}
			#if UNITY_EDITOR || UNITY_STANDALONE
			BundleShaderInfo.Instance.FixMaterialShader(m_panelLoopEffectPrefab[1]);
			BundleShaderInfo.Instance.FixMaterialShader(m_panelLoopEffectPrefab[0]);
			#endif
			if (m_infinityValidEffect == null)
			{
				m_infinityValidEffect = Instantiate(m_panelLoopEffectPrefab[1]);
				m_infinityValidEffect.transform.SetParent(transform, false);
				m_infinityValidEffect.SetActive(false);
				m_tweenList.AddRange(m_infinityValidEffect.GetComponentsInChildren<TweenBase>(true));
			}
			if(m_validPanelEffectCache.Count == 0)
			{
				for(int i = 0; i < 20; i++)
				{
					GameObject g = Instantiate(m_panelLoopEffectPrefab[0]);
					g.transform.SetParent(transform, false);
					g.SetActive(false);
					m_validPanelEffectCache.Add(g);
					m_tweenList.AddRange(g.GetComponentsInChildren<TweenBase>(true));
				}
			}
			if(m_viewSceneData.JPIPENJGGDD_NumBoard > 1)
			{
				if(m_subBoard == null)
				{
					loadCount++;
					layoutOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_boards_layout_root");
					yield return layoutOperation;
					yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
					{
						//0x10E70F8
						m_subBoard = obj.GetComponent<SceneGrowthBoard>();
						m_subBoard.InitialAnime();
					}));
					yield return null;
					m_subBoard.transform.SetParent(transform, false);
					m_subBoard.transform.SetAsFirstSibling();
					loadCount++;
					layoutOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_sw_endicon_set_layout_root");
					yield return layoutOperation;
					yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
					{
						//0x10E71C0
						m_infinityPanel = obj.GetComponent<SceneGrowthInfinityPanel>();
						m_infinityPanel.transform.SetParent(transform, false);
						m_infinityPanel.SetActive(false);
					}));
					loadCount++;
					layoutOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_sw_endicon_add_ef_layout_root");
					yield return layoutOperation;
					yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
					{
						//0x10E7308
						m_infinityPanelAddtiveEffect = obj.GetComponent<LayoutUGUIRuntime>();
						m_infinityPanelAddtiveEffect.transform.SetParent(transform, false);
					}));
					layoutOperation = null;
				}
				m_subBoard.SetMultCount(m_viewSceneData.JPIPENJGGDD_NumBoard - 1);
			}
			if(isAddtiveBoard)
			{
				if(m_panelAddtiveEffectCache.Count == 0)
				{
					loadCount++;
					GameObject instance = null;
					layoutOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_sw_abicon_add_ef_layout_root");
					yield return layoutOperation;
					yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
					{
						//0x10E7D44
						instance = obj;
					}));
					LayoutUGUIRuntime r = instance.GetComponent<LayoutUGUIRuntime>();
					for(int i = 0; i < 23; i++)
					{
						LayoutUGUIRuntime r_ = Instantiate(r);
						r_.IsLayoutAutoLoad = false;
						r_.Layout = r.Layout.DeepClone();
						r_.UvMan = r.UvMan;
						r_.LoadLayout();
						m_panelAddtiveEffectCache.Add(r_);
					}
					m_panelAddtiveEffectCache.Add(r);
					yield return null;
					for(int i = 0; i < m_panelAddtiveEffectCache.Count; i++)
					{
						m_panelAddtiveEffectCache[i].transform.SetParent(transform, false);
						m_panelAddtiveEffectCache[i].gameObject.SetActive(false);
					}
					layoutOperation = null;
				}
			}
			//LAB_010ee064
			if (!m_isLoaded)
			{
				loadCount++;
				layoutOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_status_layout_root");
				yield return layoutOperation;
				yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
				{
					//0x10E741C
					m_statusWindow = obj.GetComponent<SceneGrowthStatus>();
					m_statusWindow.transform.SetParent(transform, false);
					m_statusWindow.PushStoryButtonListener += () =>
					{
						//0x10E76B8
						m_viewEventStoryData.MFMBGODNFGG_InitFromScene(m_viewSceneData.BCCHOBPJJKE_SceneId);
						EventStoryArgs arg = new EventStoryArgs(m_viewEventStoryData);
						MenuScene.Instance.Call(TransitionList.Type.EVENT_STORY, arg, true);
					};
				}));
				layoutOperation = null;
				loadCount++;
				layoutOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_boardm_layout_root");
				yield return layoutOperation;
				yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
				{
					//0x10E7818
					m_mainBoard = obj.GetComponent<SceneGrowthBoard>();
					m_mainBoard.InitialAnime();
					m_mainBoard.transform.SetParent(transform, false);
				}));
				layoutOperation = null;
				loadCount++;
				layoutOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_sw_start_icon_layout_root");
				yield return layoutOperation;
				yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
				{
					//0x10E7960
					m_startPanel = obj.GetComponent<SceneGrowthStart>();
					m_startPanel.transform.SetParent(transform, false);
					m_startPanel.SetActive(false);
				}));
				layoutOperation = null;
				loadCount++;
				layoutOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_ab_btn_pass_layout_root");
				yield return layoutOperation;
				yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
				{
					//0x10E7AA8
					m_itemPassButtonLayout = obj.GetComponent<SceneGrowthPassButton>();
					m_itemPassButtonLayout.OnClickButton = OnPushPassPurchaseButton;
					m_itemPassButtonLayout.transform.SetParent(transform, false);
				}));
				layoutOperation = null;
				loadCount++;
				layoutOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_ab_btn_free_layout_root");
				yield return layoutOperation;
				yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
				{
					//0x10E7C28
					m_itemUnlockButtonLayout = obj.GetComponent<SceneGrowthUnlockButton>();
					m_itemUnlockButtonLayout.transform.SetParent(transform, false);
				}));
				layoutOperation = null;
				roadCount = 22;
				loadCount++;
				GameObject instance = null;
				layoutOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_sw_abicon_set_layout_root");
				yield return layoutOperation;
				yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
				{
					//0x10E7D54
					instance = obj;
				}));
				LayoutUGUIRuntime r = instance.GetComponent<LayoutUGUIRuntime>();
				m_sourcePanel = r.GetComponent<SceneGrowthPanel>();
				for(int i = 0; i < roadCount - 1; i++)
				{
					LayoutUGUIRuntime r_ = Instantiate(r);
					r_.IsLayoutAutoLoad = false;
					r_.Layout = r.Layout.DeepClone();
					r_.UvMan = r.UvMan;
					r_.LoadLayout();
					m_panelObjectCache.Add(r_.GetComponent<SceneGrowthPanel>());
				}
				m_panelObjectCache.Add(r.GetComponent<SceneGrowthPanel>());
				yield return null;
				for(int i = 0; i < m_panelObjectCache.Count; i++)
				{
					m_panelObjectCache[i].transform.SetParent(transform, false);
					m_panelObjectCache[i].SetActive(false);
				}
				layoutOperation = null;
				roadCount = 22;
				loadCount++;
				instance = null;
				layoutOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_sw_way_lightup_layout_root");
				yield return layoutOperation;
				yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
				{
					//0x10E7D64
					instance = obj;
				}));
				r = instance.GetComponent<LayoutUGUIRuntime>();
				m_sourceRoad[0] = r.GetComponent<SceneGrowthRoad>();
				for(int i = 0; i < roadCount - 1; i++)
				{
					LayoutUGUIRuntime r_ = Instantiate(r);
					r_.IsLayoutAutoLoad = false;
					r_.Layout = r.Layout.DeepClone();
					r_.UvMan = r.UvMan;
					r_.LoadLayout();
					m_roadObjectCache.Add(r_.GetComponent<SceneGrowthRoad>());
				}
				m_roadObjectCache.Add(r.GetComponent<SceneGrowthRoad>());
				layoutOperation = null;
				roadCount = 16;
				loadCount++;
				instance = null;
				layoutOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_sw_way_lightup_down_layout_root");
				yield return layoutOperation;
				yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
				{
					//0x10E7D74
					instance = obj;
				}));
				r = instance.GetComponent<LayoutUGUIRuntime>();
				m_sourceRoad[1] = r.GetComponent<SceneGrowthRoad>();
				for(int i = 0; i < roadCount - 1; i++)
				{
					LayoutUGUIRuntime r_ = Instantiate(r);
					r_.IsLayoutAutoLoad = false;
					r_.Layout = r.Layout.DeepClone();
					r_.UvMan = r.UvMan;
					r_.LoadLayout();
					m_roadObjectCache.Add(r_.GetComponent<SceneGrowthRoad>());
				}
				m_roadObjectCache.Add(r.GetComponent<SceneGrowthRoad>());
				layoutOperation = null;
				roadCount = 16;
				loadCount++;
				instance = null;
				layoutOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_sw_way_lightup_up_layout_root");
				yield return layoutOperation;
				yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
				{
					//0x10E7D84
					instance = obj;
				}));
				r = instance.GetComponent<LayoutUGUIRuntime>();
				m_sourceRoad[2] = r.GetComponent<SceneGrowthRoad>();
				for (int i = 0; i < roadCount - 1; i++)
				{
					LayoutUGUIRuntime r_ = Instantiate(r);
					r_.IsLayoutAutoLoad = false;
					r_.Layout = r.Layout.DeepClone();
					r_.UvMan = r.UvMan;
					r_.LoadLayout();
					m_roadObjectCache.Add(r_.GetComponent<SceneGrowthRoad>());
				}
				m_roadObjectCache.Add(r.GetComponent<SceneGrowthRoad>());
				layoutOperation = null;
				yield return null;
				for(int i = 0; i < m_roadObjectCache.Count; i++)
				{
					m_roadObjectCache[i].transform.SetParent(transform, false);
					m_roadObjectCache[i].SetActive(false);
				}
				m_isLoaded = true;
			}
			//LAB_010ee070
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle("ly/019.xab", false);
			}
			//LAB_010ee0d0
			while (isLodingTexture)
				yield return null;
			m_boardPanelCache.Clear();
			m_raycasterChangeList.Clear();
			for(int i = 0; i < m_panelObjectCache.Count; i++)
			{
				m_boardPanelCache.Add(m_panelObjectCache[i]);
				m_raycasterChangeList.Add(m_panelObjectCache[i]);
			}
			for(int i = 0; i < m_roadObjectCache.Count; i++)
			{
				m_boardPanelCache.Add(m_roadObjectCache[i]);
			}
			if(m_infinityPanel != null)
			{
				m_boardPanelCache.Add(m_infinityPanel);
				m_raycasterChangeList.Add(m_infinityPanel);
			}
			if(m_startPanel != null)
			{
				m_boardPanelCache.Add(m_startPanel);
			}
			m_isLoadingAppendAsset = false;
		}

		//// RVA: 0x10DF14C Offset: 0x10DF14C VA: 0x10DF14C
		public SceneGrowthPanelBase StorePanelResource(ref BoardSquare square, SceneGrowthBoard board)
		{
			SceneGrowthPanelBase res;
			switch (square.type)
			{
				case SquareType.Panel:
				case SquareType.Lock:
					if(square.id == 20)
					{
						m_infinityPanel.ConnectEffect(m_infinityValidEffect);
						res = m_infinityPanel;
						m_infinityPanel = null;
					}
					else
					{
						res = null;
						if (m_panelObjectCache.Count != 0)
						{
							res = m_panelObjectCache[0];
							m_panelObjectCache.RemoveAt(0);
						}
						if(m_validPanelEffectCache.Count != 0)
						{
							GameObject g = m_validPanelEffectCache[0];
							m_validPanelEffectCache.RemoveAt(0);
							(res as SceneGrowthPanel).ConnectEffect(g);
						}
					}
					break;
				case SquareType.Start:
					res = m_startPanel;
					m_startPanel = null;
					break;
				case SquareType.Road:
					res = null;
					SceneGrowthRoad.Type id = (SceneGrowthRoad.Type)square.id;
					int idx = m_roadObjectCache.FindIndex((SceneGrowthRoad _) =>
					{
						//0x10E7D8C
						return _.RoadType == id;
					});
					if(idx > -1 && m_roadObjectCache.Count != 0)
					{
						res = m_roadObjectCache[idx];
						m_roadObjectCache.RemoveAt(idx);
					}
					break;
				default:
					res = null;
					break;
			}
			return res;
		}

		//// RVA: 0x10DF4DC Offset: 0x10DF4DC VA: 0x10DF4DC
		public void RestorePanelResource(SceneGrowthPanelBase panel, SceneGrowthBoard board)
		{
			if(panel is SceneGrowthStart)
			{
				m_startPanel = panel as SceneGrowthStart;
			}
			else if(panel is SceneGrowthRoad)
			{
				m_roadObjectCache.Add(panel as SceneGrowthRoad);
			}
			else if(panel is SceneGrowthPanel)
			{
				SceneGrowthPanel p = panel as SceneGrowthPanel;
				m_panelObjectCache.Add(p);
				GameObject g = p.DisConnectEffect(transform);
				if (g != null)
				{
					m_validPanelEffectCache.Add(g);
					g.transform.SetParent(transform, false);
					g.SetActive(false);
				}
			}
			else if(panel is SceneGrowthInfinityPanel)
			{
				SceneGrowthInfinityPanel p = panel as SceneGrowthInfinityPanel;
				m_infinityPanel = p;
				GameObject g = p.DisConnectEffect(transform);
				if (g != null)
				{
					g.transform.SetParent(transform, false);
					g.SetActive(false);
				}
			}
			panel.SetActive(false);
		}

		//// RVA: 0x10DF84C Offset: 0x10DF84C VA: 0x10DF84C
		public void OnEnablePassButton(SceneGrowthPanel panel)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			int cnt = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem, 1, null);
			int cnt2 = NHPDPKHMFEP.HHCJCDFCLOB.MENKMJPCELJ();
			if((cnt2 == 0 || cnt2 == -3) && cnt == 0)
			{
				panel.ConnectPassLayout(m_itemPassButtonLayout);
			}
		}

		//// RVA: 0x10DFAC8 Offset: 0x10DFAC8 VA: 0x10DFAC8
		public void OnDisablePassButton(SceneGrowthPanel panel)
		{
			panel.DisConnectPassLayout(transform);
		}

		//// RVA: 0x10DFB00 Offset: 0x10DFB00 VA: 0x10DFB00
		private void OnPushPassPurchaseButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(ShowPassPurchasePopupCoroutine());
		}

		//// RVA: 0x10DFC00 Offset: 0x10DFC00 VA: 0x10DFC00
		private int GetInfinityPanelIndex(SceneGrowthBoard board, List<byte> unlockIndexList)
		{
			for(int i = 0; i < unlockIndexList.Count; i++)
			{
				AFIFDLOAKGI a = board.GetPanelItem(unlockIndexList[i]);
				if(a.INDDJNMPONH_StatType == 20)
				{
					return unlockIndexList[i];
				}
			}
			return -1;
		}

		//// RVA: 0x10DFD40 Offset: 0x10DFD40 VA: 0x10DFD40
		private bool GetInfinityMinUnlockMaxCount(SceneGrowthBoard board, List<byte> unlockIndexList, MNDAMOGGJBJ exclusionItemData, out int max, out MNDAMOGGJBJ.MNDGNJLBANB reason)
		{
			max = 0;
			reason = MNDAMOGGJBJ.MNDGNJLBANB.HJNNKCMLGFL_None;
			AFIFDLOAKGI aa = null;
			int c = 0;
			for(int i = 0; i < unlockIndexList.Count; i++)
			{
				AFIFDLOAKGI a = board.GetPanelItem(unlockIndexList[i]);
				if(a.INDDJNMPONH_StatType == 20)
				{
					c = a.MKNDAOHGOAK;
					m_viewSceneData.KPCLNEADGEM(unlockIndexList[i]);
					aa = a;
				}
			}
			if(aa != null)
			{
				int v = m_episodeData.DMHDNKILKGI_MaxPoint / c;
				for(int i = 0; i < v; i++)
				{
					PCKLFFNPPLF p = new PCKLFFNPPLF();
					p.NCMOCCDGKBP(aa, exclusionItemData);
					if(exclusionItemData.EFFBJDMGIGO_GetBuyPossible() < 1)
					{
						reason = exclusionItemData.HDHNAIIAJCP();
						break;
					}
					max++;
				}
			}
			return aa != null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7250C4 Offset: 0x7250C4 VA: 0x7250C4
		//// RVA: 0x10DFFFC Offset: 0x10DFFFC VA: 0x10DFFFC
		//private IEnumerator ShowConfirmPopupCoroutine() { }

		//[IteratorStateMachineAttribute] // RVA: 0x72513C Offset: 0x72513C VA: 0x72513C
		//// RVA: 0x10E00A8 Offset: 0x10E00A8 VA: 0x10E00A8
		private IEnumerator ShowFinalConfirmPopupCoroutine()
		{
			//0x10F461C
			MenuScene.Instance.InputDisable();
			if (!m_popupGrowthConfirmSetting.ISLoaded())
			{
				yield return this.StartCoroutineWatched(m_popupGrowthConfirmSetting.LoadAssetBundlePrefab(transform));
			}
			PopupGrowthConfirm p = m_popupGrowthConfirmSetting.Content.GetComponent<PopupGrowthConfirm>();
			yield return this.StartCoroutineWatched(p.LoadAppendLayoutCoroutine(m_addStatuList, m_episodeData.DMHDNKILKGI_MaxPoint <= m_episodeData.ABLHIAEDJAI_CurrentPoint));
			MenuScene.Instance.InputEnable();
			m_popupGrowthConfirmSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Release, Type = PopupButton.ButtonType.Positive }
			};
			m_popupGrowthConfirmSetting.WindowSize = PopupGrowthConfirm.GetValidStatusValue(m_addStatuList) > 6 ? SizeType.Middle : SizeType.Small;
			PopupWindowManager.Show(m_popupGrowthConfirmSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x10E6224
				if(type == PopupButton.ButtonType.Positive)
				{
					ApplyConsume();
					MenuScene.Instance.InitAssitPlate();
				}
				else
				{
					Array.Clear(m_addStatuList, 0, m_addStatuList.Length);
				}
			}, null, null, null);
		}

		//// RVA: 0x10E0154 Offset: 0x10E0154 VA: 0x10E0154
		private void OpenPopupSubBoardReleaseConfirm()
		{
			this.StartCoroutineWatched(ShowSubBoardReleaseConfirmPopupCoroutine());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7251B4 Offset: 0x7251B4 VA: 0x7251B4
		//// RVA: 0x10E0178 Offset: 0x10E0178 VA: 0x10E0178
		private IEnumerator ShowSubBoardReleaseConfirmPopupCoroutine()
		{
			MessageBank bank; // 0x1C
			EKLNMHFCAOI.FKGCBLHOOCL_Category itemType; // 0x20
			int itemId; // 0x24

			//0x10F67C8
			MenuScene.Instance.InputDisable();
			if(!m_popupItemUseConfirmSetting.ISLoaded())
			{
				yield return this.StartCoroutineWatched(m_popupItemUseConfirmSetting.LoadAssetBundlePrefab(transform));
			}
			MenuScene.Instance.InputEnable();
			bank = MessageManager.Instance.GetBank("menu");
			int secret_board_item_id = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("secret_board_item_id", 70027);
			itemType = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(secret_board_item_id);
			itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(secret_board_item_id);
			m_popupItemUseConfirmSetting.TitleText = bank.GetMessageByLabel("secret_board_item_use_title");
			m_popupItemUseConfirmSetting.WindowSize = SizeType.Middle;
			m_popupItemUseConfirmSetting.TypeItemId = secret_board_item_id;
			m_popupItemUseConfirmSetting.Cost = 1;
			m_popupItemUseConfirmSetting.OwnCount = EKLNMHFCAOI.DLNFNHMPGLI_GetNumClamped(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, itemType, itemId, null);
			m_popupItemUseConfirmSetting.Period = 0;
			m_popupItemUseConfirmSetting.OverrideText = bank.GetMessageByLabel("secret_board_item_use_desc_2");
			if (m_popupItemUseConfirmSetting.OwnCount < 1)
			{
				m_popupItemUseConfirmSetting.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
			}
			else
			{
				m_popupItemUseConfirmSetting.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
			}
			bool isCancel = false;
			bool isClose = false;
			PopupWindowManager.Show(m_popupItemUseConfirmSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x10E7DCC
				if (type == PopupButton.ButtonType.Negative)
					isCancel = true;
				else
				{
					if (MenuScene.CheckDatelineAndAssetUpdate())
						return;
				}
				isClose = true;
			}, null, null, null);
			while(!isClose)
				yield return null;
			if(!isCancel)
			{
				if(m_viewSceneData.JKGFBFPIMGA_Rarity < 5)
				{
					TextPopupSetting s = PopupWindowManager.CrateTextContent("", SizeType.Small, string.Format(bank.GetMessageByLabel("secret_board_item_use_warning"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemType, itemId)), new ButtonInfo[2]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}, false, false);
					isCancel = false;
					isClose = false;
					PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0x10E7E7C
						if (type == PopupButton.ButtonType.Negative)
							isCancel = true;
						else
						{
							if (MenuScene.CheckDatelineAndAssetUpdate())
								return;
						}
						isClose = true;
					}, null, null, null);
					while (!isClose)
						yield return null;
				}
				if (!isCancel)
				{
					this.StartCoroutineWatched(ApplySubBoardReleaseCoroutine());
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72522C Offset: 0x72522C VA: 0x72522C
		//// RVA: 0x10E0224 Offset: 0x10E0224 VA: 0x10E0224
		private IEnumerator ApplySubBoardReleaseCoroutine()
		{
			bool isVisibleSubBoardRelease; // 0x18
			bool isEnableSubBoardRelease; // 0x19

			//0x10E8F10
			MenuScene.Instance.InputDisable();
			m_viewSceneData.JPIPENJGGDD_NumBoard++;
			JKNGJFOBADP d = new JKNGJFOBADP();
			d.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.MIDINHNHGNP_43, "");
			d.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, m_viewSceneData.BCCHOBPJJKE_SceneId, 1, null, 0);
			int typeItemId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("secret_board_item_id", 70027);
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(typeItemId);
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(typeItemId);
			int cnt = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, null);
			if(cnt > 0)
			{
				EKLNMHFCAOI.DPHGFMEPOCA_SetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, cnt - 1,  null);
			}
			bool isWaitSave = true;
			MenuScene.Save(() =>
			{
				//0x10E7F2C
				ILCCJNDFFOB.HHCJCDFCLOB.NNAPCDMAAJM(m_viewSceneData.BCCHOBPJJKE_SceneId, m_viewSceneData.JPIPENJGGDD_NumBoard, m_viewSceneData.CIEOBFIIPLD_SceneLevel, m_viewSceneData.CIEOBFIIPLD_SceneLevel, new List<int>() { typeItemId }, new List<int>(), 0, new List<int>());
				isWaitSave = false;
			}, null);
			while (isWaitSave)
				yield return null;
			SoundResource.AddCueSheet(SoundManager.Instance.sePlayerGacha.cueSheet);
			m_isAddtiveSubBoard = m_viewSceneData.NFILJJGGKNG_IsAdditiveSubBoard();
			m_isAddtiveFirstSubBoard = m_viewSceneData.IELENGDJPHF < 2;
			m_viewSceneData.JGNBHPJCICN();
			if(m_currentBoard != null)
			{
				m_itemUnlockButtonLayout.UpdateLayout(m_subBoard);
				yield return Co.R(HideBoardCoroutine(m_currentBoard));
				m_currentBoard = m_subBoard;
			}
			//LAB_010e95d4
			if (m_isAddtiveSubBoard)
			{
				yield return Co.R(LoadAppendLayoutCoroutine(true));
			}
			//LAB_010e9600
			isVisibleSubBoardRelease = m_viewSceneData.JHNNCPCBFDK();
			isEnableSubBoardRelease = m_viewSceneData.JFDLBEOGGID();
			m_statusWindow.UpdateContent(m_viewSceneData, m_transitionUniqueId);
			m_statusWindow.UpdateEpisode(m_episodeData);
			m_subBoard.SetBoardLayout(m_viewSceneData);
			m_subBoard.ClearUnlockAction();
			m_subBoard.OnUnlockAction += UnLockPanel;
			m_subBoard.BoardChangeAction = ChangeMainBoard;
			m_subBoard.SetEnableBoardChangeButton(true);
			m_subBoard.SetEnableSubBoardReleaseButton(isVisibleSubBoardRelease, isEnableSubBoardRelease);
			m_subBoard.SetLimitOverLayout(m_limitOverData);
			m_subBoard.LimitOverAction = OpenPopupLimitOver;
			m_subBoard.SubBoardReleaseAction = OpenPopupSubBoardReleaseConfirm;
			m_subBoard.SetMultCount(m_viewSceneData.JPIPENJGGDD_NumBoard - 1);
			(m_subBoard as SceneGrowthSubBoard).IsFirstInfinityPanelOpen = m_isFirstInfinityPanelOpen;
			yield return Co.R(StartAddtivePanelDirectionCoroutine());
			m_mainBoard.SetEnableBoardChangeButton(m_viewSceneData.JPIPENJGGDD_NumBoard > 1);
			m_mainBoard.SetEnableSubBoardReleaseButton(isVisibleSubBoardRelease, isEnableSubBoardRelease);
			SoundResource.RemoveCueSheet(SoundManager.Instance.sePlayerGacha.cueSheet);
			isWaitSave = true;
			MenuScene.Save(() =>
			{
				//0x10E81A4
				isWaitSave = false;
			}, null);
			while (isWaitSave)
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7252A4 Offset: 0x7252A4 VA: 0x7252A4
		//// RVA: 0x10E02D0 Offset: 0x10E02D0 VA: 0x10E02D0
		private IEnumerator ShowRarityUpConfirmPopupCoroutine()
		{
			MessageBank bank; // 0x1C
			EKLNMHFCAOI.FKGCBLHOOCL_Category itemType; // 0x20
			int itemId; // 0x24

			//0x10F5174
			MenuScene.Instance.InputDisable();
			if (!m_popupItemUseConfirmSetting.ISLoaded())
				yield return this.StartCoroutineWatched(m_popupItemUseConfirmSetting.LoadAssetBundlePrefab(transform));
			MenuScene.Instance.InputEnable();
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			bank = MessageManager.Instance.GetBank("menu");
			int rarityUpItemId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("rarity_up_item_id", 230001);
			itemType = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(rarityUpItemId);
			itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(rarityUpItemId);
			int num = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem, 1, null);
			int a = 0;
			List<NKFJNAANPNP.MOJLCADLMKH> n = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DPNKPPBEAGJ_RareUpItem.MCPIBDPKBBD(time);
			if (n.Count > 0)
			{
				a = n[0].HNKFMAJIFJD_ExpireAt;
			}
			m_popupItemUseConfirmSetting.TitleText = bank.GetMessageByLabel("rarityup_item_use_title");
			m_popupItemUseConfirmSetting.WindowSize = SizeType.Middle;
			m_popupItemUseConfirmSetting.TypeItemId = rarityUpItemId;
			m_popupItemUseConfirmSetting.Cost = 1;
			m_popupItemUseConfirmSetting.OwnCount = num;
			m_popupItemUseConfirmSetting.Period = a;
			int b = NHPDPKHMFEP.HHCJCDFCLOB.MENKMJPCELJ();
			if (num < 1)
			{
				if(b == 0 || b == -3)
				{
					m_popupItemUseConfirmSetting.OverrideText = bank.GetMessageByLabel("rarityup_item_use_desc_2");
					m_popupItemUseConfirmSetting.Buttons = new ButtonInfo[2]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.PassPurchase, Type = PopupButton.ButtonType.Positive }
					};
				}
				else
				{
					m_popupItemUseConfirmSetting.OverrideText = bank.GetMessageByLabel("rarityup_item_use_desc_2");
					m_popupItemUseConfirmSetting.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
					};
				}
			}
			else
			{
				m_popupItemUseConfirmSetting.OverrideText = bank.GetMessageByLabel("rarityup_item_use_desc_1");
				m_popupItemUseConfirmSetting.Buttons = new ButtonInfo[2]
				{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
			}
			bool isCancel = false;
			bool isPurchase = false;
			bool isClose = false;
			PopupWindowManager.Show(m_popupItemUseConfirmSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x10E81B8
				if (type == PopupButton.ButtonType.Negative)
					isCancel = true;
				if (label == PopupButton.ButtonLabel.PassPurchase)
					isPurchase = true;
				isClose = true;
			}, null, null, null);
			while (!isClose)
				yield return null;
			if(!isCancel)
			{
				if(!isPurchase)
				{
					if(m_viewSceneData.JKGFBFPIMGA_Rarity < 5)
					{
						TextPopupSetting scontent = PopupWindowManager.CrateTextContent("", SizeType.Small, 
							string.Format(bank.GetMessageByLabel("rarityup_item_use_warning"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemType, itemId)),
							new ButtonInfo[2]
							{
								new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
								new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
							}, false, false);
						isCancel = false;
						isClose = false;
						PopupWindowManager.Show(scontent, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
						{
							//0x10E81E4
							if (type == PopupButton.ButtonType.Negative)
								isCancel = true;
							isClose = true;
						}, null, null, null);
						while (!isClose)
							yield return null;
						if(isCancel)
						{
							yield break;
						}
					}
					this.StartCoroutineWatched(ShowRarityUpFinalConfirmPopupCoroutine());
				}
				else
				{
					this.StartCoroutineWatched(ShowPassPurchasePopupCoroutine());
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72531C Offset: 0x72531C VA: 0x72531C
		//// RVA: 0x10E037C Offset: 0x10E037C VA: 0x10E037C
		private IEnumerator ShowRarityUpFinalConfirmPopupCoroutine()
		{
			//0x10F6170
			MenuScene.Instance.InputDisable();
			if(!m_popupItemRarityUpConfirmSetting.ISLoaded())
			{
				yield return this.StartCoroutineWatched(m_popupItemRarityUpConfirmSetting.LoadAssetBundlePrefab(transform));
			}
			MenuScene.Instance.InputEnable();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_popupItemRarityUpConfirmSetting.TitleText = bk.GetMessageByLabel("rarityup_item_use_confirm_title");
			m_popupItemRarityUpConfirmSetting.WindowSize = SizeType.Middle;
			m_popupItemRarityUpConfirmSetting.SceneId = m_viewSceneData.BCCHOBPJJKE_SceneId;
			m_popupItemRarityUpConfirmSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.RarityUp, Type = PopupButton.ButtonType.Positive }
			};
			bool isCancel = false;
			bool isClose = false;
			PopupWindowManager.Show(m_popupItemRarityUpConfirmSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x10E6894
				if (type == PopupButton.ButtonType.Negative)
					isCancel = true;
				else
				{
					if (MenuScene.CheckDatelineAndAssetUpdate())
						return;
				}
				isClose = true;
			}, null, null, null);
			while (!isClose)
				yield return null;
			if (!isCancel)
				this.StartCoroutineWatched(ApplyRarityUpCoroutine());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x725394 Offset: 0x725394 VA: 0x725394
		//// RVA: 0x10E0428 Offset: 0x10E0428 VA: 0x10E0428
		private IEnumerator ApplyRarityUpCoroutine()
		{
			Color color;

			//0x10E8200
			MenuScene.Instance.InputDisable();
			m_viewSceneData.EKLIPGELKCL_SceneRarity = (byte)(m_viewSceneData.JKGFBFPIMGA_Rarity + 1);
			m_viewSceneData.JPIPENJGGDD_NumBoard = 1;
			m_viewSceneData.IELENGDJPHF = 0;
			JKNGJFOBADP d = new JKNGJFOBADP();
			d.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.CDJJNKKIBJN, "");
			d.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, m_viewSceneData.BCCHOBPJJKE_SceneId, 1, null, 0);
			int typeItemId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("rarity_up_item_id", 230001);
			int num = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(typeItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(typeItemId), null);
			if (num > 0)
				EKLNMHFCAOI.DPHGFMEPOCA_SetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(typeItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(typeItemId), num - 1, null);
			yield return Co.R(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.RarityUp, null, false));
			SoundResource.AddCueSheet(SoundManager.Instance.sePlayerGacha.cueSheet);
			GameManager.Instance.fullscreenFader.Fade(0.5f, Color.white);
			m_unLockTargetPanelIndex.RemoveRange(1, m_unLockTargetPanelIndex.Count - 1);
			m_unlockTargetRoadIndex.Clear();
			yield return Co.R(PlayUnlockPanelAnimationCoroutine(() =>
			{
				//0x10E661C
				SoundManager.Instance.sePlayerGacha.Play((int)cs_se_gacha.SE_GACHA_009);
			}));
			m_isAddtiveMainBoard = m_viewSceneData.ADMDGGOKPND_IsAdditiveMainBoard();
			yield return Co.R(LoadAppendLayoutCoroutine(m_isAddtiveMainBoard));
			m_mainBoard.DisConnectGameObject(m_boardPanelCache, transform);
			m_mainBoard.RemovePanel();
			m_mainBoard.ClearCallBack();
			m_mainBoard.SetBoardLayout(m_viewSceneData);
			m_mainBoard.SetEnableSubBoardReleaseButton(m_viewSceneData.JHNNCPCBFDK(), m_viewSceneData.JFDLBEOGGID());
			m_statusWindow.UpdateContent(m_viewSceneData, m_transitionUniqueId);
			m_statusWindow.UpdateEpisode(m_episodeData);
			color = Color.white;
			color.a = 0;
			GameManager.Instance.fullscreenFader.Fade(0.5f, color);
			yield return Co.R(StartAddtivePanelDirectionCoroutine());
			SoundResource.RemoveCueSheet(SoundManager.Instance.sePlayerGacha.cueSheet);
			m_viewSceneData.GHJOFLBDIOI();
			m_isWaitSave = true;
			MenuScene.Save(() =>
			{
				//0x10E6944
				ILCCJNDFFOB.HHCJCDFCLOB.NNAPCDMAAJM(m_viewSceneData.BCCHOBPJJKE_SceneId,
					m_viewSceneData.JPIPENJGGDD_NumBoard, m_viewSceneData.CIEOBFIIPLD_SceneLevel,
					m_viewSceneData.CIEOBFIIPLD_SceneLevel, new List<int>() { typeItemId }, new List<int>() { 1 }, 0, new List<int>());
				m_isWaitSave = false;
			}, () =>
			{
				//0x10E6BD0
				m_isWaitSave = false;
				m_isSaveError = true;
			});
			while (m_isWaitSave)
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72540C Offset: 0x72540C VA: 0x72540C
		//// RVA: 0x10DFB74 Offset: 0x10DFB74 VA: 0x10DFB74
		private IEnumerator ShowPassPurchasePopupCoroutine()
		{
			TodoLogger.LogError(TodoLogger.MonthlyPass, "ShowPassPurchasePopupCoroutine");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x725484 Offset: 0x725484 VA: 0x725484
		//// RVA: 0x10E04F4 Offset: 0x10E04F4 VA: 0x10E04F4
		private IEnumerator ShowEpisodeCompPopup(PIGBBNDPPJC episodeData, int addPoint, EpisodeRewardGet.CloseEpisodeCompWindowHandler onClose)
		{
			//0x10F4344
			bool isWait = true;
			PopupButton.ButtonLabel selectedLabel = PopupButton.ButtonLabel.None;
			m_episodeRewardWindow.Show(ref episodeData, addPoint, CIOECGOMILE.HHCJCDFCLOB.EBEGGFECPOE, (PopupButton.ButtonLabel label) =>
			{
				//0x10E6C20
				selectedLabel = label;
				isWait = false;
			}, true);
			while(isWait)
				yield return null;
			onClose(selectedLabel);
		}

		//// RVA: 0x10E05EC Offset: 0x10E05EC VA: 0x10E05EC
		private void ShowAddtiveBoardPopup(string titleLabel, string messageLabel, Action okCallBack)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel(titleLabel),
				SizeType.Small, bk.GetMessageByLabel(messageLabel), new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true), (PopupWindowControl control, PopupButton.ButtonType label, PopupButton.ButtonLabel type) =>
				{
					//0x10E6C30
					okCallBack();
				}, null, null, null);
		}

		// RVA: 0x10E0888 Offset: 0x10E0888 VA: 0x10E0888 Slot: 16
		protected override void OnPreSetCanvas()
		{
			m_isBeginner = false;
			m_isWaitSave = false;
			m_isSaveError = false;
			m_transitionUniqueId = (TransitionUniqueId)MenuScene.Instance.GetCurrentScene().uniqueId;
			SceneGrowthSceneArgs arg = Args as SceneGrowthSceneArgs;
			if (arg == null)
			{
				arg = ArgsReturn as SceneGrowthSceneArgs;
			}
			if(arg != null)
			{
				m_viewSceneData = arg.ViewSceneData;
				m_limitOverData.KHEKNNFCAOI(m_viewSceneData.JKGFBFPIMGA_Rarity, m_viewSceneData.MKHFCGPJPFI_LimitOverCount, m_viewSceneData.MJBODMOLOBC_Luck);
				m_lastBoardType = 0;
				m_isAddtiveMainBoard = m_viewSceneData.ADMDGGOKPND_IsAdditiveMainBoard();
				m_isAddtiveSubBoard = m_viewSceneData.NFILJJGGKNG_IsAdditiveSubBoard();
				if (m_isAddtiveMainBoard)
				{
					m_viewSceneData.GHJOFLBDIOI();
				}
				if (m_isAddtiveSubBoard)
				{
					//LAB_010e0ad0
					MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[m_viewSceneData.BCCHOBPJJKE_SceneId - 1];
					int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(scene.EKLIPGELKCL_Rarity, scene.MCCIFLKCNKO_Feed);
					m_isFirstInfinityPanelOpen = m_viewSceneData.IELENGDJPHF <= a;
					m_isAddtiveFirstSubBoard = m_viewSceneData.IELENGDJPHF < 2;
					m_viewSceneData.JGNBHPJCICN();
				}
				if(m_isAddtiveMainBoard || m_isAddtiveSubBoard)
				{
					m_isWaitSave = true;
					MenuScene.Save(() =>
					{
						//0x10E6304
						m_isWaitSave = false;
					}, () =>
					{
						//0x10E6310
						m_isWaitSave = false;
						m_isSaveError = true;
					});
				}
				m_isBeginner = arg.IsFromBiginner;
			}
			//LAB_010e0d64
			m_viewGrowItemData.KHEKNNFCAOI(null);
			m_episodeData.KHEKNNFCAOI(m_viewSceneData.KELFCMEOPPM_EpisodeId);
			m_currentBoard = null;
			LGMEPLIJLNB l = LGMEPLIJLNB.BMFKMFNPGPC(m_viewSceneData.KELFCMEOPPM_EpisodeId, true);
			m_lastRewardItemId = 0;
			if (l != null)
			{
				m_lastRewardItemId = l.GOOIIPFHOIG.JJBGOIMEIPF_ItemId;
			}
			this.StartCoroutine(LoadAppendLayoutCoroutine(m_isAddtiveMainBoard || m_isAddtiveSubBoard));
		}

		// RVA: 0x10E0EC8 Offset: 0x10E0EC8 VA: 0x10E0EC8 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			if(!m_isLoadingAppendAsset && !m_isWaitSave)
			{
				if(!m_isSaveError)
				{
					GetDefaultBoard();
					m_statusWindow.InitializeDecoration();
					m_statusWindow.UpdateContent(m_viewSceneData, m_transitionUniqueId);
					m_statusWindow.UpdateEpisode(m_episodeData);
					m_mainBoard.SetBoardLayout(m_viewSceneData);
					m_mainBoard.ClearUnlockAction();
					m_mainBoard.OnUnlockAction += UnLockPanel;
					m_mainBoard.BoardChangeAction = ChangeSubBoard;
					m_mainBoard.SetEnableBoardChangeButton(m_viewSceneData.JPIPENJGGDD_NumBoard > 1);
					m_mainBoard.SetEnableSubBoardReleaseButton(m_viewSceneData.JHNNCPCBFDK(), m_viewSceneData.JFDLBEOGGID());
					m_mainBoard.SetLimitOverLayout(m_limitOverData);
					m_mainBoard.LimitOverAction = OpenPopupLimitOver;
					m_mainBoard.SubBoardReleaseAction = OpenPopupSubBoardReleaseConfirm;
					if(m_subBoard != null)
					{
						m_subBoard.SetBoardLayout(m_viewSceneData);
						m_subBoard.ClearUnlockAction();
						m_subBoard.OnUnlockAction += UnLockPanel;
						m_subBoard.BoardChangeAction = ChangeMainBoard;
						m_subBoard.SetEnableBoardChangeButton(true);
						m_subBoard.SetEnableSubBoardReleaseButton(m_viewSceneData.JHNNCPCBFDK(), m_viewSceneData.JFDLBEOGGID());
						m_subBoard.SetLimitOverLayout(m_limitOverData);
						m_subBoard.LimitOverAction = OpenPopupLimitOver;
						m_subBoard.SubBoardReleaseAction = OpenPopupSubBoardReleaseConfirm;
						(m_subBoard as SceneGrowthSubBoard).IsFirstInfinityPanelOpen = m_isFirstInfinityPanelOpen;
					}
					m_statusWindow.SetPage(0);
					m_itemUnlockButtonLayout.OnClickStaButton = () =>
					{
						//0x10E6320
						UnLockStatusPanel(m_mainBoard);
					};
					m_itemUnlockButtonLayout.OnClickEpiButton = () =>
					{
						//0x10E6328
						UnLockEpisodePanel(m_mainBoard);
					};
					m_itemUnlockButtonLayout.OnClickAllButton = () =>
					{
						//0x10E6330
						UnLockAllPanel(m_mainBoard);
					};
				}
				return true;
			}
			return false;
		}

		// RVA: 0x10E245C Offset: 0x10E245C VA: 0x10E245C Slot: 18
		protected override void OnPostSetCanvas()
		{
			m_canvas = GetComponentInParent<Canvas>();
		}

		// RVA: 0x10E24C4 Offset: 0x10E24C4 VA: 0x10E24C4 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if (m_isSaveError)
				return;
			this.StartCoroutineWatched(ShowCoroutine());
		}

		// RVA: 0x10E2584 Offset: 0x10E2584 VA: 0x10E2584 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return m_isShowing;
		}

		// RVA: 0x10E2598 Offset: 0x10E2598 VA: 0x10E2598 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_statusWindow.Hide();
			m_currentBoard.Hide();
			m_itemUnlockButtonLayout.Hide();
		}

		// RVA: 0x10E2690 Offset: 0x10E2690 VA: 0x10E2690 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_statusWindow.IsAnimePlaying();
		}

		// RVA: 0x10E2718 Offset: 0x10E2718 VA: 0x10E2718 Slot: 23
		protected override void OnActivateScene()
		{
			m_episodeRewardWindow.ReStart(OnCallEpisodeDetails);
			if(m_isBeginner)
			{
				GameManager.PushBackButtonHandler dymmyBackHandler = () =>
				{
					//0x10E6674
					return;
				};
				GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
				BasicTutorialManager.Instance.ShowMessageWindow(BasicTutorialMessageId.Id_EpisodeMission3, () =>
				{
					//0x10E6C5C
					GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
				}, null);
			}
			for(int i = 0; i < m_raycasterChangeList.Count; i++)
			{
				m_raycasterChangeList[i].SetEnableRaycaster(true);
			}
		}

		//// RVA: 0x10E2A48 Offset: 0x10E2A48 VA: 0x10E2A48
		private void OnCallEpisodeDetails(PopupButton.ButtonLabel label)
		{
			if(label == PopupButton.ButtonLabel.Episode)
			{
				PIGBBNDPPJC data = new PIGBBNDPPJC();
				data.KHEKNNFCAOI(m_viewSceneData.KELFCMEOPPM_EpisodeId);
				MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_EPISODESELECT_EPISODEDETAIL, new EpisodeDetailArgs() { data = data }, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
		}

		// RVA: 0x10E2BA0 Offset: 0x10E2BA0 VA: 0x10E2BA0 Slot: 14
		protected override void OnDestoryScene()
		{
			m_statusWindow.ReleaseResource();
			m_mainBoard.RemovePanel();
			m_mainBoard.DisConnectGameObject(m_boardPanelCache, transform);
			m_mainBoard.ClearCallBack();
			if(m_subBoard != null)
			{
				m_subBoard.RemovePanel();
				m_subBoard.DisConnectGameObject(m_boardPanelCache, transform);
				m_subBoard.ClearCallBack();
			}
			base.OnDestoryScene();
		}

		// RVA: 0x10E2D80 Offset: 0x10E2D80 VA: 0x10E2D80 Slot: 15
		protected override void OnDeleteCache()
		{
			AssetBundleManager.UnloadAssetBundle("ly/tx/019.xab", false);
		}

		//// RVA: 0x10E16E4 Offset: 0x10E16E4 VA: 0x10E16E4
		private SceneGrowthBoard.BoardType GetDefaultBoard()
		{
			int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LAGGGIEIPEG(m_viewSceneData.JKGFBFPIMGA_Rarity, false, m_viewSceneData.MCCIFLKCNKO_Feed);
			for(int i = 0; i < a; i++)
			{
				if (m_viewSceneData.FAPMGGOMCOE(i) == GCIJNCFDNON_SceneInfo.HINAICIJJJC.BPMNCMICDAF/*1*/)
					return SceneGrowthBoard.BoardType.Main;
			}
			if(m_subBoard != null)
			{
				return m_viewSceneData.JPIPENJGGDD_NumBoard < 2 ? SceneGrowthBoard.BoardType.Main : SceneGrowthBoard.BoardType.Sub;
			}
			return SceneGrowthBoard.BoardType.Main;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7254FC Offset: 0x7254FC VA: 0x7254FC
		//// RVA: 0x10E24F8 Offset: 0x10E24F8 VA: 0x10E24F8
		private IEnumerator ShowCoroutine()
		{
			//0x10F3F34
			m_isShowing = true;
			m_statusWindow.Show();
			m_itemUnlockButtonLayout.Show();
			while (m_statusWindow.IsAnimePlaying())
				yield return null;
			if(!m_isAddtiveMainBoard && !m_isAddtiveSubBoard)
			{
				m_boardType = m_lastBoardType;
				if (m_lastBoardType == 0)
					m_boardType = GetDefaultBoard();
				m_currentBoard = m_subBoard;
				if (m_boardType == SceneGrowthBoard.BoardType.Main)
					m_currentBoard = m_mainBoard;
				m_currentBoard.PreConnectGameObject(m_boardPanelCache);
				m_currentBoard.InitializeBoard(m_lastRewardItemId);
				m_itemUnlockButtonLayout.UpdateLayout(m_currentBoard);
				yield return this.StartCoroutineWatched(ShowBoardCoroutine(m_currentBoard));
			}
			else
			{
				yield return this.StartCoroutineWatched(StartAddtivePanelDirectionCoroutine());
			}
			for(int i = 0; i < m_raycasterChangeList.Count; i++)
			{
				m_raycasterChangeList[i].SetEnableRaycaster(false);
			}
			m_isShowing = false;
		}

		//// RVA: 0x10E2E30 Offset: 0x10E2E30 VA: 0x10E2E30
		private void OpenPopupLimitOver()
		{
			if(!MenuScene.CheckDatelineAndAssetUpdate())
			{
				m_limitOverData.KHEKNNFCAOI(m_viewSceneData.JKGFBFPIMGA_Rarity, m_viewSceneData.MKHFCGPJPFI_LimitOverCount, m_viewSceneData.MJBODMOLOBC_Luck);
				if(!m_limitOverData.EOBACDCDGOF)
				{
					m_luckyLeafSetting.Setup(m_viewSceneData);
					if(!m_limitOverData.JMHIDPKHELB)
					{
						m_luckyLeafSetting.Buttons = new ButtonInfo[2]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
							new ButtonInfo() { Label = PopupButton.ButtonLabel.SkillRelease, Type = PopupButton.ButtonType.Positive }
						};
					}
					else
					{
						m_luckyLeafSetting.Buttons = new ButtonInfo[1]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
						};
					}
					PopupWindowManager.Show(m_luckyLeafSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0x10E6338
						if(type == PopupButton.ButtonType.Positive)
						{
							m_viewGrowItemData.MDHKGJJBLNL();
							MNDAMOGGJBJ.JFJJNPJNBPI d = new MNDAMOGGJBJ.JFJJNPJNBPI();
							d.MBFFGGFGPEN(m_limitOverData.MJNOAMAFNHA, m_limitOverData.IJEOIMGILCK);
							m_viewGrowItemData.INLBMFMOHCI_CostItems.Add(d);
							m_viewGrowItemData.CMBGGPOFBOO_UcCost = m_limitOverData.GNKGDDMMJPF;
							this.StartCoroutineWatched(LimitOverMainCoroutine(m_viewGrowItemData));
						}
					}, null, null, null);
				}
				else
				{
					m_luckyLeafTerminateSetting.Setup(m_viewSceneData);
					m_luckyLeafTerminateSetting.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
					};
					PopupWindowManager.Show(m_luckyLeafTerminateSetting, null, null, null, null);
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x725574 Offset: 0x725574 VA: 0x725574
		//// RVA: 0x10E3334 Offset: 0x10E3334 VA: 0x10E3334
		private IEnumerator LimitOverMainCoroutine(MNDAMOGGJBJ itemData)
		{
			//0x10EABD0
			yield return Co.R(MenuScene.Instance.PopupUseItemWindow.Show(itemData, UseItemList.Unlock.Default));
            PopupUseItemWindow.UseItemResult res = MenuScene.Instance.PopupUseItemWindow.Result;
			if(res != PopupUseItemWindow.UseItemResult.OK)
				yield break;
			if(itemData.KMIFDLLCBEL() != 1)
				yield break;
			if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsShowKiraPlatePopUp2))
			{
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsShowKiraPlatePopUp2, true);
			}
			bool done = false;
			bool err = false;
			MenuScene.Instance.InputDisable();
			AEKDNMPPOJN.AHKFPJJKHFL(m_viewSceneData.BCCHOBPJJKE_SceneId, () =>
			{
				//0x10E6D0C
				done = true;
			}, () => {
				//0x10E6D18
				done = true;
				err = true;
			});
			while(!done)
				yield return null;
			MenuScene.Instance.InputEnable();
			if(err)
			{
				MenuScene.Instance.GotoTitle();
				yield break;
			}
			MMPBPOIFDAF_Scene.PMKOFEIONEG scene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[m_viewSceneData.BCCHOBPJJKE_SceneId - 1];
			m_viewSceneData.MKHFCGPJPFI_LimitOverCount = scene.DMNIMMGGJJJ_Leaf;
			m_limitOverData.KHEKNNFCAOI(m_viewSceneData.JKGFBFPIMGA_Rarity, scene.DMNIMMGGJJJ_Leaf, m_viewSceneData.MJBODMOLOBC_Luck);
			done = false;
			MenuScene.Instance.InputDisable();
			MenuScene.Instance.LimitOverControl.ShowRelease(m_viewSceneData, m_limitOverData, () =>
			{
				//0x10E6514
				m_mainBoard.SetLimitOverLayout(m_limitOverData);
				m_subBoard.SetLimitOverLayout(m_limitOverData);
				m_statusWindow.UpdateContent(m_viewSceneData, m_transitionUniqueId);
			}, () =>
			{
				//0x10E6D24
				done = true;
			});
			while(!done)
				yield return null;
			MenuScene.Instance.InputEnable();
        }

		//// RVA: 0x10E33FC Offset: 0x10E33FC VA: 0x10E33FC
		private void ChangeMainBoard()
		{
			this.StartCoroutineWatched(ChangeMainBoardCoroutine());
		}

		//// RVA: 0x10E34AC Offset: 0x10E34AC VA: 0x10E34AC
		private void ChangeSubBoard()
		{
			this.StartCoroutineWatched(ChangeSubBoardCoroutine());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7255EC Offset: 0x7255EC VA: 0x7255EC
		//// RVA: 0x10E3420 Offset: 0x10E3420 VA: 0x10E3420
		private IEnumerator ChangeMainBoardCoroutine()
		{
			ContentSizeFitter contentSizefitter;

			//0x10E9FE8
			contentSizefitter = m_canvas.GetComponent<ContentSizeFitter>();
			contentSizefitter.enabled = false;
			m_boardType = SceneGrowthBoard.BoardType.Main;
			m_lastBoardType = SceneGrowthBoard.BoardType.Main;
			MenuScene.Instance.RaycastDisable();
			for (int i = 0; i < m_raycasterChangeList.Count; i++)
			{
				m_raycasterChangeList[i].SetEnableRaycaster(false);
			}
			m_itemUnlockButtonLayout.UpdateLayout(m_mainBoard);
			yield return this.StartCoroutineWatched(HideBoardCoroutine(m_subBoard));
			m_mainBoard.PreConnectGameObject(m_boardPanelCache);
			m_mainBoard.InitializeBoard(m_lastRewardItemId);
			yield return this.StartCoroutineWatched(ShowBoardCoroutine(m_mainBoard));
			m_currentBoard = m_mainBoard;
			yield return null;
			for (int i = 0; i < m_raycasterChangeList.Count; i++)
			{
				m_raycasterChangeList[i].SetEnableRaycaster(true);
			}
			MenuScene.Instance.RaycastEnable();
			contentSizefitter.enabled = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x725664 Offset: 0x725664 VA: 0x725664
		//// RVA: 0x10E34D0 Offset: 0x10E34D0 VA: 0x10E34D0
		private IEnumerator ChangeSubBoardCoroutine()
		{
			ContentSizeFitter contentSizefitter;

			//0x10EA4D8
			contentSizefitter = m_canvas.GetComponent<ContentSizeFitter>();
			contentSizefitter.enabled = false;
			m_boardType = SceneGrowthBoard.BoardType.Sub;
			m_lastBoardType = SceneGrowthBoard.BoardType.Sub;
			MenuScene.Instance.RaycastDisable();
			for(int i = 0; i < m_raycasterChangeList.Count; i++)
			{
				m_raycasterChangeList[i].SetEnableRaycaster(false);
			}
			m_itemUnlockButtonLayout.UpdateLayout(m_subBoard);
			yield return this.StartCoroutineWatched(HideBoardCoroutine(m_mainBoard));
			m_subBoard.PreConnectGameObject(m_boardPanelCache);
			m_subBoard.InitializeBoard(m_lastRewardItemId);
			yield return this.StartCoroutineWatched(ShowBoardCoroutine(m_subBoard));
			m_currentBoard = m_subBoard;
			yield return null;
			for (int i = 0; i < m_raycasterChangeList.Count; i++)
			{
				m_raycasterChangeList[i].SetEnableRaycaster(true);
			}
			MenuScene.Instance.RaycastEnable();
			contentSizefitter.enabled = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7256DC Offset: 0x7256DC VA: 0x7256DC
		//// RVA: 0x10E359C Offset: 0x10E359C VA: 0x10E359C
		private IEnumerator HideBoardCoroutine(SceneGrowthBoard board)
		{
			//0x10EA9C8
			board.Hide();
			while (board.IsAnimePlaying())
				yield return null;
			yield return null;
			board.DisConnectGameObject(m_boardPanelCache, transform);
			board.RemovePanel();
			board.ClearCallBack();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x725754 Offset: 0x725754 VA: 0x725754
		//// RVA: 0x10E3664 Offset: 0x10E3664 VA: 0x10E3664
		private IEnumerator ShowBoardCoroutine(SceneGrowthBoard board)
		{
			//0x10F39A0
			board.Show();
			while (board.IsAnimePlaying())
				yield return null;
		}

		//// RVA: 0x10E3710 Offset: 0x10E3710 VA: 0x10E3710
		//private void SetEffectClip() { }

		//// RVA: 0x10E0EC0 Offset: 0x10E0EC0 VA: 0x10E0EC0
		//private bool IsAddtiveSubBoard() { }

		//// RVA: 0x10E0EB8 Offset: 0x10E0EB8 VA: 0x10E0EB8
		//private bool IsAddtiveMainBoard() { }

		//[IteratorStateMachineAttribute] // RVA: 0x7257CC Offset: 0x7257CC VA: 0x7257CC
		//// RVA: 0x10E3714 Offset: 0x10E3714 VA: 0x10E3714
		private IEnumerator StartAddtivePanelDirectionCoroutine()
		{
			WaitWhile waitYielder; // 0x18
			SceneGrowthBoard lastBoard; // 0x1C
			SceneGrowthBoard.BoardType defaultBoard; // 0x20

			//0x10F81E4
			MenuScene.Instance.RaycastDisable();
			for (int i = 0; i < m_raycasterChangeList.Count; i++)
			{
				m_raycasterChangeList[i].SetEnableRaycaster(false);
			}
			bool isWait = false;
			waitYielder = new WaitWhile(() =>
			{
				//0x10E6D38
				return isWait;
			});
			lastBoard = null;
			if(m_isAddtiveMainBoard)
			{
				yield return this.StartCoroutineWatched(StartAddtiveBoardPanelCoroutine(m_mainBoard));
				isWait = true;
				ShowAddtiveBoardPopup("growth_popup_title_text01", "growth_popup_text10", () =>
				{
					//0x10E6D40
					isWait = false;
				});
				lastBoard = m_mainBoard;
			}
			//LAB_010f88d4
			if(isWait)
			{
				yield return waitYielder;
			}
			//LAB_010f8900
			if(m_isAddtiveSubBoard)
			{
				yield return this.StartCoroutineWatched(StartAddtiveBoardPanelCoroutine(m_subBoard));
				isWait = true;
				if(!m_isAddtiveFirstSubBoard)
				{
					ShowAddtiveBoardPopup("growth_popup_title_text03", "growth_popup_text12", () =>
					{
						//0x10E6D58
						isWait = false;
					});
				}
				else
				{
					ShowAddtiveBoardPopup("growth_popup_title_text02", "growth_popup_text11", () =>
					{
						//0x10E6D4C
						isWait = false;
					});
				}
				lastBoard = m_subBoard;
			}
			//LAB_010f8978
			yield return waitYielder;
			yield return TutorialManager.TryShowTutorialCoroutine(CheckTutorialCondition_25);
			yield return TutorialManager.TryShowTutorialCoroutine(CheckTutorialCondition_84);
			defaultBoard = GetDefaultBoard();
			if(defaultBoard == SceneGrowthBoard.BoardType.Sub)
			{
				bool canKeep = true;
				if(lastBoard != null)
				{
					canKeep = !(lastBoard is SceneGrowthMainBoard);
				}
				if(canKeep)
				{
					m_currentBoard = m_subBoard;
					m_itemUnlockButtonLayout.UpdateLayout(m_subBoard);
					yield return this.StartCoroutineWatched(BoardMoveCoroutine(m_subBoard, SceneGrowthBoard.BoardDispPosition.Current, (int)m_subBoard.GetDefaultScrollPosition()));
				}
				else
				{
					this.StartCoroutineWatched(ChangeSubBoardCoroutine());
				}
			}
			else
			{
				bool canKeep = true;
				if (lastBoard != null)
				{
					canKeep = !(lastBoard is SceneGrowthSubBoard);
				}
				if(canKeep)
				{
					m_currentBoard = m_mainBoard;
					m_itemUnlockButtonLayout.UpdateLayout(m_mainBoard);
					yield return this.StartCoroutineWatched(BoardMoveCoroutine(m_mainBoard, SceneGrowthBoard.BoardDispPosition.Current, (int)m_mainBoard.GetDefaultScrollPosition()));
				}
				else
				{
					this.StartCoroutineWatched(ChangeMainBoardCoroutine());
				}
			}
			m_boardType = defaultBoard;
			for (int i = 0; i < m_raycasterChangeList.Count; i++)
			{
				m_raycasterChangeList[i].SetEnableRaycaster(true);
			}
			MenuScene.Instance.RaycastEnable();
			m_isAddtiveMainBoard = false;
			m_isAddtiveSubBoard = false;
			m_isAddtiveFirstSubBoard = false;
			m_isFirstInfinityPanelOpen = false;
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x725844 Offset: 0x725844 VA: 0x725844
		//// RVA: 0x10E37C0 Offset: 0x10E37C0 VA: 0x10E37C0
		private IEnumerator StartAddtiveBoardPanelCoroutine(SceneGrowthBoard board)
		{
			int addEffectIndex; // 0x18
			WaitForSeconds waitSeccond; // 0x1C

			//0x10F746C
			if(m_currentBoard != null)
			{
				if(m_currentBoard != board)
				{
					yield return this.StartCoroutineWatched(HideBoardCoroutine(m_currentBoard));
				}
			}
			board.PreConnectGameObject(m_boardPanelCache);
			board.InitializeBoard(m_lastRewardItemId);
			board.InitializeExpandDirection(ref m_expandPanelList);
			for(int i = 0; i < m_expandPanelList.Count; i++)
			{
				if (m_expandPanelList[i] is ISceneGrowthPanel)
				{
					(m_expandPanelList[i] as ISceneGrowthPanel).StopLoopEffect();
				}
			}
			m_currentBoard = board;
			yield return this.StartCoroutineWatched(ShowBoardCoroutine(board));
			addEffectIndex = 0;
			for(int i = 0; i < m_expandPanelList.Count; i++)
			{
				LayoutUGUIRuntime r = null;
				if (m_expandPanelList[i] is ISceneGrowthPanel)
				{
					(m_expandPanelList[i] as ISceneGrowthPanel).PlayExpandAnime();
					r = m_infinityPanelAddtiveEffect;
					if ((m_expandPanelList[i] as ISceneGrowthPanel).PanelType == GrowthPanelType.Normal)
					{
						r = m_panelAddtiveEffectCache[addEffectIndex];
						addEffectIndex++;
					}
				}
				if(r != null)
				{
					r.transform.SetParent((m_expandPanelList[i] as ISceneGrowthPanel).transform, false);
					r.gameObject.SetActive(true);
					r.Layout.StartAllAnim();
				}
			}
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_004);
			waitSeccond = new WaitForSeconds(1);
			yield return waitSeccond;
			for(int i = 0; i < m_expandPanelList.Count; i++)
			{
				if (m_expandPanelList[i] != null)
				{
					if (m_expandPanelList[i] is SceneGrowthRoad)
					{
						SceneGrowthRoad p = m_expandPanelList[i] as SceneGrowthRoad;
						p.PlayExpandAnime();
						p.SetClose();
					}
					if (m_expandPanelList[i] is ISceneGrowthPanel)
					{
						(m_expandPanelList[i] as ISceneGrowthPanel).ShowLoopEffect();
					}
				}
			}
			yield return waitSeccond;
			for(int i = 0; i < addEffectIndex; i++)
			{
				m_panelAddtiveEffectCache[i].transform.SetParent(transform, false);
				m_panelAddtiveEffectCache[i].gameObject.SetActive(false);
			}
			if(m_infinityPanelAddtiveEffect != null)
			{
				m_infinityPanelAddtiveEffect.transform.SetParent(transform, false);
				m_infinityPanelAddtiveEffect.gameObject.SetActive(false);
			}
			m_expandPanelList.Clear();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7258BC Offset: 0x7258BC VA: 0x7258BC
		//// RVA: 0x10E3888 Offset: 0x10E3888 VA: 0x10E3888
		private IEnumerator BoardMoveCoroutine(SceneGrowthBoard board, SceneGrowthBoard.BoardDispPosition psotion, int defaultPosition)
		{
			float moveMs; // 0x1C
			float time; // 0x20
			float nowPosition; // 0x24
			float position; // 0x28

			//0x10E9D30
			moveMs = 0.25f;
			time = 0;
			nowPosition = board.GetScrollViewNormalizePosition();
			position = board.GetBoardNormalizePosition(psotion, defaultPosition);
			while(time < moveMs)
			{
				time += TimeWrapper.deltaTime;
				board.SetScrollNormalizePosition(Tween.EasingInOutCubic(nowPosition, position, Mathf.Clamp01(time / moveMs)));
				yield return null;
			}
			board.SetScrollNormalizePosition(position);
		}

		//// RVA: 0x10E3968 Offset: 0x10E3968 VA: 0x10E3968
		private void UnLockPanel(SceneGrowthBoard board, int x, int y)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if (MenuScene.CheckDatelineAndAssetUpdate())
				return;
			m_unLockTargetPanelIndex.Clear();
			m_unlockTargetRoadIndex.Clear();
			board.UnlockPanelListup(x, y, m_unLockTargetPanelIndex, m_unlockTargetRoadIndex);
			if(board.IsPanelRock(x, y))
			{
				this.StartCoroutineWatched(ShowRarityUpConfirmPopupCoroutine());
			}
			else
			{
				this.StartCoroutineWatched(UnlockPanelCoroutine(board, UseItemList.Unlock.Default));
			}
		}

		//// RVA: 0x10E3C18 Offset: 0x10E3C18 VA: 0x10E3C18
		private void UnLockAllPanel(SceneGrowthBoard board)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(MenuScene.CheckDatelineAndAssetUpdate())
				return;
			m_unLockTargetPanelIndex.Clear();
			m_unlockTargetRoadIndex.Clear();
			board.UnlockAllPanelListup(m_unLockTargetPanelIndex, m_unlockTargetRoadIndex);
			this.StartCoroutineWatched(UnlockPanelCoroutine(board, UseItemList.Unlock.All));
		}

		//// RVA: 0x10E3D94 Offset: 0x10E3D94 VA: 0x10E3D94
		private void UnLockEpisodePanel(SceneGrowthBoard board)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(MenuScene.CheckDatelineAndAssetUpdate())
				return;
			m_unLockTargetPanelIndex.Clear();
			m_unlockTargetRoadIndex.Clear();
			board.UnlockEpisodePanelListup(m_unLockTargetPanelIndex, m_unlockTargetRoadIndex);
			this.StartCoroutineWatched(UnlockPanelCoroutine(board, UseItemList.Unlock.Episode));
		}

		//// RVA: 0x10E3F10 Offset: 0x10E3F10 VA: 0x10E3F10
		private void UnLockStatusPanel(SceneGrowthBoard board)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(MenuScene.CheckDatelineAndAssetUpdate())
				return;
			m_unLockTargetPanelIndex.Clear();
			m_unlockTargetRoadIndex.Clear();
			board.UnlockStatusPanelListup(m_unLockTargetPanelIndex, m_unlockTargetRoadIndex);
			this.StartCoroutineWatched(UnlockPanelCoroutine(board, UseItemList.Unlock.Status));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x725934 Offset: 0x725934 VA: 0x725934
		//// RVA: 0x10E3B58 Offset: 0x10E3B58 VA: 0x10E3B58
		private IEnumerator UnlockPanelCoroutine(SceneGrowthBoard board, UseItemList.Unlock unlock)
		{
			//0x10F8D34
			m_viewGrowItemData.MDHKGJJBLNL();
			MakeGrowItemData(board, m_viewGrowItemData, m_unLockTargetPanelIndex, 1);
			MNDAMOGGJBJ.MNDGNJLBANB reason = m_viewGrowItemData.HDHNAIIAJCP();
			if (reason != MNDAMOGGJBJ.MNDGNJLBANB.HJNNKCMLGFL_None/*0*/)
			{
				yield return Co.R(MenuScene.Instance.PopupUseItemWindow.Show(m_viewGrowItemData, unlock));
			}
			else
			{
				int a = GetInfinityPanelIndex(board, m_unLockTargetPanelIndex);
				if (a < 0)
				{
					MakeAddStatus(m_addStatuList, board, m_unLockTargetPanelIndex, 0);
				}
				else
				{
					int count = 0;
					PopupButton.ButtonType button = PopupButton.ButtonType.Other;
					int stockCount = m_viewSceneData.KPCLNEADGEM(a);
					AFIFDLOAKGI afi = board.GetPanelItem(a);
					MakeGrowItemData(board, m_viewGrowItemData, m_unLockTargetPanelIndex, count);
					int unlockCount = 0;
					GetInfinityMinUnlockMaxCount(board, m_unLockTargetPanelIndex, m_viewGrowItemData, out unlockCount, out reason);
					m_infinityPanelUnlockInfo.index = (short)a;
					int e = Mathf.Min(unlockCount, stockCount);
					if(e < 2)
					{
						MakeGrowItemData(board, m_viewGrowItemData, m_unLockTargetPanelIndex, 1);
						MakeAddStatus(m_addStatuList, board, m_unLockTargetPanelIndex, 1);
					}
					else
					{
						yield return this.StartCoroutineWatched(ShowInfinityItemuPopupCoroutine((short)unlockCount, (short)stockCount, (short)afi.MKNDAOHGOAK, reason, (PopupButton.ButtonType type, int itemCount) =>
						{
							//0x10E6D6C
							count = itemCount;
							button = type;
						}));
						if (button == PopupButton.ButtonType.Negative)
							yield break;
						MakeGrowItemData(board, m_viewGrowItemData, m_unLockTargetPanelIndex, count);
						MakeAddStatus(m_addStatuList, board, m_unLockTargetPanelIndex, count);
					}
					//LAB_010f926c
					m_infinityPanelUnlockInfo.count = (short)count;
				}
				//LAB_010f927c
				m_popupSetting.ViewGrowItemData = m_viewGrowItemData;
				m_popupSetting.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
				};
				m_popupSetting.IsValidate = true;
				yield return Co.R(MenuScene.Instance.PopupUseItemWindow.Show(m_viewGrowItemData, unlock));
				if(MenuScene.Instance.PopupUseItemWindow.Result == PopupUseItemWindow.UseItemResult.OK)
				{
					this.StartCoroutineWatched(ShowFinalConfirmPopupCoroutine());
				}
				else
				{
					System.Array.Clear(m_addStatuList, 0, m_addStatuList.Length);
				}
			}
		}

		//// RVA: 0x10E40AC Offset: 0x10E40AC VA: 0x10E40AC
		private void MakeGrowItemData(SceneGrowthBoard board, MNDAMOGGJBJ itemData, List<byte> unLockIndexList, int infLoopCount)
		{
			itemData.MDHKGJJBLNL();
			for(int i = 0; i < unLockIndexList.Count; i++)
			{
				AFIFDLOAKGI a = board.GetPanelItem(unLockIndexList[i]);
				//a.ENNLMALGDKN();
				int count = 1;
				if (a.INDDJNMPONH_StatType == 20)
				{
					//a.PKLGGJPPBAN();
					count = infLoopCount;
				}
				//a.PKLGGJPPBAN();
				for (int j = count; j != 0; j--)
				{
					PCKLFFNPPLF p = new PCKLFFNPPLF();
					p.NCMOCCDGKBP(a, itemData);
				}
			}
		}

		//// RVA: 0x10E42D4 Offset: 0x10E42D4 VA: 0x10E42D4
		private void MakeAddStatus(int[] addStatus, SceneGrowthBoard board, List<byte> unlockIndexList, int infLoopCount)
		{
			Array.Clear(addStatus, 0, addStatus.Length);
			for(int i = 0; i < unlockIndexList.Count; i++)
			{
				int val = board.GetPanelValue(unlockIndexList[i]);
				AFIFDLOAKGI a = board.GetPanelItem(unlockIndexList[i]);
				int type = a.INDDJNMPONH_StatType;
				int cnt = 1;
				if (type == 20)
				{
					type = 18;
					cnt = infLoopCount;
				}
				for(int j = 0; j < cnt; j++)
				{
					addStatus[type] += val;
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7259AC Offset: 0x7259AC VA: 0x7259AC
		//// RVA: 0x10E44E4 Offset: 0x10E44E4 VA: 0x10E44E4
		private IEnumerator ShowInfinityItemuPopupCoroutine(short unlockCount, short stockCount, short episodeUnit, MNDAMOGGJBJ.MNDGNJLBANB reason, UnityAction<PopupButton.ButtonType, int> callBack)
		{
			//0x10F4B8C
			bool isWait = true;
			int count = 0;
			PopupButton.ButtonType button = PopupButton.ButtonType.Other;
			m_popupInfinityPanelSetting.UnlockCount = unlockCount;
			m_popupInfinityPanelSetting.EpisodeUnit = episodeUnit;
			m_popupInfinityPanelSetting.StockCount = stockCount;
			m_popupInfinityPanelSetting.Reason = reason;
			m_popupInfinityPanelSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(m_popupInfinityPanelSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x10E6D80
				button = type;
				count = (control.Content as PopupGrowthInfinityPanel).Value;
				isWait = false;
			}, null, null, null);
			while(isWait)
				yield return null;
			callBack(button, count);
		}

		//// RVA: 0x10E4610 Offset: 0x10E4610 VA: 0x10E4610
		private void ApplyConsume()
		{
			if(m_viewGrowItemData.KMIFDLLCBEL() > 0)
			{
				List<int> l = new List<int>();
				for (int i = 0; i < 22; i++)
					l.Add(0);
				MMPBPOIFDAF_Scene.PMKOFEIONEG scene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[m_viewSceneData.BCCHOBPJJKE_SceneId - 1];
				if(!m_viewSceneData.KEJMFDLFIEO())
				{
					JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() =>
					{
						//0x10E6714
						MenuScene.Instance.GotoTitle();
					}, "");
					return;
				}
				if(m_boardType == SceneGrowthBoard.BoardType.Main)
				{
					bool b = false;
					for(int i = 0; i < m_unLockTargetPanelIndex.Count; i++)
					{
						m_viewSceneData.EFLDHMMGALP(m_unLockTargetPanelIndex[i], GCIJNCFDNON_SceneInfo.HINAICIJJJC.JIKCABGFIEG_2);
						AFIFDLOAKGI af = m_viewSceneData.LDGCIDPEMPG(m_unLockTargetPanelIndex[i]);
						if(af != null)
						{
							l[af.INDDJNMPONH_StatType]++;
						}
						b |= !scene.IEPGLOIICLJ(m_unLockTargetPanelIndex[i]);
					}
					if(b)
					{
						//LAB_010e4f38
						JHHBAFKMBDL.HHCJCDFCLOB.OODNEKINHLO_ShowError(() =>
						{
							//0x10E6714
							MenuScene.Instance.GotoTitle();
						});
						return;
					}
				}
				else
				{
					bool b = false;
					for(int i = 0; i < m_unLockTargetPanelIndex.Count; i++)
					{
						m_viewSceneData.GIAPABMCNOC(m_unLockTargetPanelIndex[i], GCIJNCFDNON_SceneInfo.HINAICIJJJC.JIKCABGFIEG_2);
						AFIFDLOAKGI af = m_viewSceneData.CDDHNNLPOLG(m_unLockTargetPanelIndex[i], m_viewSceneData.ILABPFOMEAG_Va, m_viewSceneData.JGJFIJOCPAG_SceneAttr);
						if(af != null)
						{
							if(af.INDDJNMPONH_StatType == 20)
							{
								if(m_infinityPanelUnlockInfo.index > -1 && m_infinityPanelUnlockInfo.count > 0)
								{
									m_viewSceneData.OEIFKIPOHME(m_infinityPanelUnlockInfo.index, m_infinityPanelUnlockInfo.count);
									AFIFDLOAKGI af2 = m_viewSceneData.CDDHNNLPOLG(m_infinityPanelUnlockInfo.index, m_viewSceneData.ILABPFOMEAG_Va, m_viewSceneData.JGJFIJOCPAG_SceneAttr);
									if(af2 != null)
									{
										l[af2.INDDJNMPONH_StatType]++;
									}
								}
							}
							else
							{
								l[af.INDDJNMPONH_StatType]++;
								b |= !scene.PJLNENPKEDD(m_unLockTargetPanelIndex[i]);
							}
						}
					}
					if(b)
					{
						JHHBAFKMBDL.HHCJCDFCLOB.OODNEKINHLO_ShowError(() =>
						{
							//0x10E6678
							MenuScene.Instance.GotoTitle();
						});
						return;
					}
				}
				m_prevStatus.Copy(m_viewSceneData.CMCKNKKCNDK_Status);
				m_prevLuck = m_viewSceneData.MJBODMOLOBC_Luck;
				m_prevCenterSkillLevel = m_viewSceneData.DDEDANKHHPN_SkillLevel;
				m_prevActiveSkillLevel = m_viewSceneData.PNHJPCPFNFI_ActiveSkillLevel;
				m_prevLiveSkillLevel = m_viewSceneData.AADFFCIDJCB_LiveSkillLevel;
				m_viewSceneData.HCDGELDHFHB();
				GameManager.Instance.ViewPlayerData.DPLBHAIKPGL_GetTeam(false).HCDGELDHFHB();
				GameManager.Instance.ViewPlayerData.DPLBHAIKPGL_GetTeam(true).HCDGELDHFHB();
				m_viewSceneData.OHJIKMCAOLE();
				m_viewSceneData.EJLGAMEIMEG(m_viewGrowItemData, l);
				this.StartCoroutineWatched(PlayUnlockPanelAnimationCoroutine(null));
				m_mainBoard.UpdateBoardLayout();
				if (m_subBoard != null)
					m_subBoard.UpdateBoardLayout();
				m_itemUnlockButtonLayout.UpdateLayout(m_currentBoard);
				GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_IsBingoValid(null, -1);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x725A24 Offset: 0x725A24 VA: 0x725A24
		//// RVA: 0x10E5408 Offset: 0x10E5408 VA: 0x10E5408
		private IEnumerator PlayUnlockPanelAnimationCoroutine(Action playSeEvent)
		{
			int loadCount; // 0x28
			ISceneGrowthPanel inifityPanel; // 0x2C
			AssetBundleLoadLayoutOperationBase layoutOperation; // 0x30

			//0x10EE8BC
			loadCount = 0;
			MenuScene.Instance.InputDisable();
			bool isWaitSave = false;
			MenuScene.SaveWithAchievement(2, () =>
			{
				//0x10E6E6C
				isWaitSave = false;
			}, null);
			m_currentBoard.GetUnlockParts(m_prodactPanelList, m_prodactRoadList, m_unLockTargetPanelIndex, m_unlockTargetRoadIndex);
			inifityPanel = m_prodactPanelList.Find((ISceneGrowthPanel x) =>
			{
				//0x10E67B0
				return x.PanelType == GrowthPanelType.Infinity;
			});
			if(inifityPanel != null)
			{
				if(m_infinityPanelOpenEffect == null)
				{
					loadCount++;
					layoutOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_sw_endicon_get_ef_layout_root");
					yield return layoutOperation;
					yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
					{
						//0x10E6E78
						m_infinityPanelOpenEffect = obj.GetComponent<LayoutUGUIRuntime>();
						m_infinityPanelOpenEffect.transform.SetParent(transform, false);
						m_infinityPanelOpenEffect.gameObject.SetActive(false);
					}));
					layoutOperation = null;
				}
				//LAB_010ef798
				if(m_infinityOpen3dEffect == null)
				{
					m_infinityOpen3dEffect = Instantiate(m_3dEffectPrefab[1]);
#if UNITY_EDITOR || UNITY_STANDALONE
					BundleShaderInfo.Instance.FixMaterialShader(m_infinityOpen3dEffect.gameObject);
#endif
					m_infinityOpen3dEffect.transform.SetParent(transform, false);
					m_infinityOpen3dEffect.gameObject.SetActive(false);
				}
				m_prodactPanelList.Remove(inifityPanel);
			}
			//LAB_010ef91c
			if(m_panelOpenEffectCache.Count == 0)
			{
				loadCount++;
				GameObject instance = null;
				layoutOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_sw_abicon_get_ef_layout_root");
				yield return layoutOperation;
				yield return Co.R(layoutOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
				{
					//0x10E70B4
					instance = obj;
				}));
				LayoutUGUIRuntime runtime = instance.GetComponent<LayoutUGUIRuntime>();
				for(int i = 0; i < m_prodactPanelList.Count - 1; i++)
				{
					LayoutUGUIRuntime r = Instantiate(runtime);
					r.IsLayoutAutoLoad = false;
					r.Layout = runtime.Layout.DeepClone();
					r.UvMan = runtime.UvMan;
					r.LoadLayout();
					m_panelOpenEffectCache.Add(r);
				}
				m_panelOpenEffectCache.Add(runtime);
				yield return null;
				SceneGrowth3dEffect eff = Instantiate(m_3dEffectPrefab[0]);
#if UNITY_EDITOR || UNITY_STANDALONE
				BundleShaderInfo.Instance.FixMaterialShader(eff.gameObject);
#endif
				for(int i = 0; i < m_panelOpenEffectCache.Count; i++)
				{
					m_panelOpenEffectCache[i].transform.SetParent(transform, false);
					m_panelOpenEffectCache[i].gameObject.SetActive(false);
					SceneGrowth3dEffect eff2 = Instantiate(eff);
					eff2.transform.SetParent(transform, false);
					eff2.gameObject.SetActive(false);
					m_panelOpen3dEffectCache.Add(eff2);
				}
				Destroy(eff.gameObject);
				layoutOperation = null;
			}
			else if(m_panelOpenEffectCache.Count < m_prodactPanelList.Count)
			{
				int diff = m_prodactPanelList.Count - m_panelOpenEffectCache.Count;
				for(int i = 0; i < diff; i++)
				{
					LayoutUGUIRuntime r = Instantiate(m_panelOpenEffectCache[0]);
					r.IsLayoutAutoLoad = false;
					r.Layout = m_panelOpenEffectCache[0].Layout.DeepClone();
					r.UvMan = m_panelOpenEffectCache[0].UvMan;
					r.gameObject.SetActive(true);
					r.LoadLayout();
					m_panelOpenEffectCache.Add(r);
				}
				m_panelOpenEffectCache.Add(m_panelOpenEffectCache[0]);
				yield return null;
				for(int i = 0; i < m_panelOpenEffectCache.Count; i++)
				{
					m_panelOpenEffectCache[1].transform.SetParent(transform, false);
					m_panelOpenEffectCache[i].gameObject.SetActive(false);
					SceneGrowth3dEffect eff = Instantiate(m_panelOpen3dEffectCache[0]);
					eff.gameObject.SetActive(false);
					m_panelOpen3dEffectCache.Add(eff);
				}
			}
			//LAB_010efc5c
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle("ly/019.xab", false);
			}
			Canvas c = GetComponentInParent<Canvas>();
			for(int i = 0; i < m_prodactPanelList.Count; i++)
			{
				m_panelOpenEffectCache[i].transform.SetParent(m_prodactPanelList[i].transform, false);
				m_prodactPanelList[i].PlayUnLockAnime();
				m_panelOpenEffectCache[i].gameObject.SetActive(true);
				m_panelOpenEffectCache[i].Layout.StartAllAnimGoStop("go_in", "st_in");
				m_panelOpen3dEffectCache[i].gameObject.SetActive(true);
				m_panelOpen3dEffectCache[i].transform.SetParent(m_prodactPanelList[i].transform, false);
				m_panelOpen3dEffectCache[i].transform.localPosition = new Vector3(50, -50, -90);
			}
			for(int i = 0; i < m_prodactRoadList.Count; i++)
			{
				m_prodactRoadList[i].SetOpen();
			}
			if(inifityPanel != null)
			{
				(inifityPanel as SceneGrowthInfinityPanel).SetStock(m_viewSceneData.KPCLNEADGEM(m_infinityPanelUnlockInfo.index));
				m_infinityPanelOpenEffect.transform.SetParent(inifityPanel.transform, false);
				inifityPanel.PlayUnLockAnime();
				m_infinityPanelOpenEffect.gameObject.SetActive(true);
				m_infinityPanelOpenEffect.Layout.StartAllAnimGoStop("go_in", "st_in");
				m_infinityOpen3dEffect.transform.SetParent(inifityPanel.transform, false);
				m_infinityOpen3dEffect.gameObject.SetActive(true);
				m_infinityOpen3dEffect.transform.localPosition = new Vector3(90, -50, -90);
			}
			yield return null;
			int p = GetUpdatePageNumber(m_addStatuList);
			m_statusWindow.SetPage(p);
			for(int i = 0; i < m_pageStatusTbl[p].Count; i++)
			{
				if(m_addStatuList[(int)m_pageStatusTbl[p][i]] > 0)
				{
					m_statusWindow.PlayUpArrowAnimation(m_pageStatusTbl[p][i]);
				}
			}
			m_animeTime = 0;
			if(playSeEvent == null)
			{
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_003);
			}
			else
			{
				playSeEvent();
			}
			if(p == 1)
			{
				m_statusWindow.BeginUpdateCenterSkillAnime(m_viewSceneData, m_prevCenterSkillLevel, m_addStatuList[5] + m_prevCenterSkillLevel, 0.9f);
				m_statusWindow.BeginUpdateActiveSkillAnime(m_viewSceneData, m_prevActiveSkillLevel, m_addStatuList[6] + m_prevActiveSkillLevel, 0.9f);
				m_statusWindow.BeginUpdateLiveSkillAnime(m_viewSceneData, m_prevLiveSkillLevel, m_addStatuList[7] + m_prevLiveSkillLevel, 0.9f);
				//LAB_010f12e4
				while(m_animeTime <= 1)
				{
					m_animeTime += TimeWrapper.deltaTime;
					yield return null;
				}
			}
			else if(p != 0)
			{
				//LAB_010f115c;
				while(m_animeTime <= 1)
				{
					m_animeTime += TimeWrapper.deltaTime;
					yield return null;
				}
			}
			else
			{
				m_statusWindow.BeginUpdateStatusAnime(SceneGrowthStatus.TextLabel.Total, m_prevStatus.Total, m_addStatuList[3] + m_addStatuList[2] + m_addStatuList[4] + m_prevStatus.Total, 0.9f);
				m_statusWindow.BeginUpdateStatusAnime(SceneGrowthStatus.TextLabel.Life, m_prevStatus.life, m_addStatuList[1] + m_prevStatus.life, 0.9f);
				m_statusWindow.BeginUpdateStatusAnime(SceneGrowthStatus.TextLabel.Soul, m_prevStatus.soul, m_addStatuList[2] + m_prevStatus.soul, 0.9f);
				m_statusWindow.BeginUpdateStatusAnime(SceneGrowthStatus.TextLabel.Vocal, m_prevStatus.vocal, m_addStatuList[3] + m_prevStatus.vocal, 0.9f);
				m_statusWindow.BeginUpdateStatusAnime(SceneGrowthStatus.TextLabel.Charm, m_prevStatus.charm, m_addStatuList[4] + m_prevStatus.charm, 0.9f);
				m_statusWindow.BeginUpdateStatusAnime(SceneGrowthStatus.TextLabel.Support, m_prevStatus.support, m_addStatuList[8] + m_prevStatus.support, 0.9f);
				m_statusWindow.BeginUpdateStatusAnime(SceneGrowthStatus.TextLabel.Fold, m_prevStatus.fold, m_addStatuList[9] + m_prevStatus.fold, 0.9f);
				m_statusWindow.BeginUpdateStatusAnime(SceneGrowthStatus.TextLabel.Luck, m_prevLuck, m_addStatuList[19] + m_prevLuck, 0.9f);
				//LAB_010f112c
				while(m_animeTime <= 1)
				{
					m_animeTime += TimeWrapper.deltaTime;
					yield return null;
				}
			}
			while(m_panelOpenEffectCache[0].Layout.IsPlayingAll())
				yield return null;
			if(m_infinityPanelOpenEffect != null)
			{
				while(m_infinityPanelOpenEffect.Layout.IsPlayingAll())
					yield return null;
			}
			for(int i = 0; i < m_panelOpenEffectCache.Count; i++)
			{
				m_panelOpenEffectCache[i].transform.SetParent(transform, false);
				m_panelOpenEffectCache[i].gameObject.SetActive(false);
				m_panelOpen3dEffectCache[i].transform.SetParent(transform, false);
				m_panelOpen3dEffectCache[i].gameObject.SetActive(false);
			}
			if(m_infinityPanelOpenEffect != null)
			{
				m_infinityPanelOpenEffect.transform.SetParent(transform, false);
				m_infinityPanelOpenEffect.gameObject.SetActive(false);
			}
			if(m_infinityOpen3dEffect != null)
			{
				m_infinityOpen3dEffect.transform.SetParent(transform, false);
				m_infinityOpen3dEffect.gameObject.SetActive(false);
			}
			m_statusWindow.UpdateContent(m_viewSceneData, m_transitionUniqueId);
			m_currentBoard.UpdateBoardLayout();
			m_currentBoard.UpdateBoard();
			//LAB_010f18f4
			while(isWaitSave)
				yield return null;
			int prev = m_limitOverData.LJHOOPJACPI_LeafMax;
			m_limitOverData.KHEKNNFCAOI(m_viewSceneData.JKGFBFPIMGA_Rarity, m_viewSceneData.MKHFCGPJPFI_LimitOverCount, m_viewSceneData.MJBODMOLOBC_Luck);
			if(prev < m_limitOverData.LJHOOPJACPI_LeafMax)
			{
				bool done = false;
				MenuScene.Instance.LimitOverControl.ShowAddSlot(m_limitOverData, prev, () =>
				{
					//0x10E6FE4
					m_mainBoard.SetLimitOverLayout(m_limitOverData);
					m_subBoard.SetLimitOverLayout(m_limitOverData);
				}, () =>
				{
					//0x10E70C4
					done = true;
				});
				while(!done)
					yield return null;
			}
			int cnt = GetUnlockStoryCount(m_addStatuList);
			if(cnt > 0)
			{
				bool isWait = true;
				m_viewEventStoryData.MFMBGODNFGG_InitFromScene(m_viewSceneData.BCCHOBPJJKE_SceneId);
				m_popupEventStoryOpenListPopupSetting.Set(m_viewEventStoryData, cnt, m_transitionUniqueId == TransitionUniqueId.SETTINGMENU_SCENEABILITYRELEASELIST_SCENEGROWTH);
				PopupWindowManager.Show(m_popupEventStoryOpenListPopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x10E70D8
					isWait = false;
				}, null, null, null);
				while(isWait)
					yield return null;
			}
			bool isCallEpisode = false;
			int cnt2 = GetEpisodePoint(m_addStatuList);
			if(cnt2 > 0)
			{
				MenuScene.Instance.InputEnable();
				yield return this.StartCoroutineWatched(ShowEpisodeCompPopup(m_episodeData, cnt2, (PopupButton.ButtonLabel label) =>
				{
					//0x10E7098
					isCallEpisode = label == PopupButton.ButtonLabel.Episode;
				}));
			}
			else
			{
				MenuScene.Instance.InputEnable();
			}
			//LAB_010f1f14
			m_episodeData.KHEKNNFCAOI(m_viewSceneData.KELFCMEOPPM_EpisodeId);
			if(isCallEpisode)
			{
				m_episodeData = new PIGBBNDPPJC();
				m_episodeData.KHEKNNFCAOI(m_viewSceneData.KELFCMEOPPM_EpisodeId);
				MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_EPISODESELECT_EPISODEDETAIL, new EpisodeDetailArgs() { data = m_episodeData }, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
			m_statusWindow.UpdateEpisode(m_episodeData);
			Array.Clear(m_addStatuList, 0, m_addStatuList.Length);
		}

		//// RVA: 0x10E54D0 Offset: 0x10E54D0 VA: 0x10E54D0
		private int GetEpisodePoint(int[] addStatus)
		{
			return addStatus[20] + addStatus[18];
		}

		//// RVA: 0x10E5534 Offset: 0x10E5534 VA: 0x10E5534
		private int GetUnlockStoryCount(int[] addStatus)
		{
			return addStatus[21];
		}

		//// RVA: 0x10E5574 Offset: 0x10E5574 VA: 0x10E5574
		private int GetUpdatePageNumber(int[] addStatus)
		{
			int a1 = addStatus[2] + addStatus[1] + addStatus[3] + addStatus[4] + addStatus[8] + addStatus[19] + addStatus[9] > 0 ? 1 : 0;
			if(addStatus[5] + addStatus[6] + addStatus[7] > 0)
				a1 |= 2;
			if(addStatus[20] + addStatus[18] > 0)
				a1 |= 4;
			if((a1 & (1 << 0x1f)) == 0)
			{
				for(int i = 0; i < 3; i++)
				{
					if((a1 & (1 << i)) != 0)
						return i;
				}
				return 0;
			}
			return m_statusWindow.PageNum;
		}

		//// RVA: 0x10E57D4 Offset: 0x10E57D4 VA: 0x10E57D4
		private bool CheckTutorialCondition_25(TutorialConditionId conditionId)
		{
			if(conditionId != TutorialConditionId.Condition25)
				return false;
			return m_isAddtiveSubBoard;
		}

		//// RVA: 0x10E57F4 Offset: 0x10E57F4 VA: 0x10E57F4
		private bool CheckTutorialCondition_84(TutorialConditionId conditionId)
		{
			if (conditionId != TutorialConditionId.Condition84)
				return false;
			if (!m_isAddtiveSubBoard)
				return false;
			return m_viewSceneData.ILABPFOMEAG_Va > 0;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x725A9C Offset: 0x725A9C VA: 0x725A9C
		//// RVA: 0x10E61F4 Offset: 0x10E61F4 VA: 0x10E61F4
		//private void <ShowConfirmPopupCoroutine>b__94_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }
	}
}
