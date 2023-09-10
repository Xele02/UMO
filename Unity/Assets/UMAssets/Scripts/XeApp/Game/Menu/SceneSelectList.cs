using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;
using XeSys;
using System.Collections;
using XeApp.Core;
using mcrs;

namespace XeApp.Game.Menu
{
	public class SceneSelectList : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x14
		[SerializeField]
		private SceneListSelectEvent m_onSelectSceneEvent; // 0x18
		[SerializeField]
		private UnityEvent m_onRemoveSceneEvent; // 0x1C
		[SerializeField]
		private SceneListSelectEvent m_onShowSceneStatusEvent; // 0x20
		[SerializeField]
		private string m_windowExId; // 0x24
		[SerializeField]
		private NumberBase[] m_episodeNumber; // 0x28
		[SerializeField]
		private Text m_invalidText; // 0x2C
		[SerializeField]
		private Text m_gaugeRateText; // 0x30
		[SerializeField]
		private UnitExpectedScore m_scoreGauge; // 0x34
		[SerializeField]
		private List<Text> m_gaugeNameTexts; // 0x38
		[SerializeField]
		private RawImageEx m_jacketImage; // 0x3C
		[SerializeField]
		private RawImageEx m_musicAttributeImage; // 0x40
		[SerializeField]
		private RawImageEx m_difficultImage; // 0x44
		[SerializeField]
		private RawImageEx m_scorePlusImage; // 0x48
		[SerializeField]
		private RepeatButton m_scorePlusButton; // 0x4C
		[SerializeField]
		private RepeatButton m_scoreMinusButton; // 0x50
		private TexUVListManager m_uvManager; // 0x54
		private AbsoluteLayout m_windowAnimation; // 0x58
		private AbsoluteLayout m_episodeLayout; // 0x5C
		private AbsoluteLayout m_invalidTextLayout; // 0x60
		private AbsoluteLayout m_scoreGaugeLayout; // 0x64
		private ActionButton m_removeButton; // 0x68
		private SceneIconDecoration[] m_sceneIconDecoration; // 0x6C
		private DisplayType m_dispType; // 0x70
		private sbyte m_selectedSlotNumber; // 0x74
		private bool m_initialized; // 0x75
		private Dictionary<SwapScrollListContent, SceneIconDecoration> m_decrationMap; // 0x78
		private CompatibleLayoutAnimeParam m_comAnimeParam; // 0x7C
		private CompatibleLayoutAnimeParam m_newAnimeParam; // 0x88
		private static readonly string[] DifficultUvTable = new string[5] {
			"cmn_music_diff_01", "cmn_music_diff_02", "cmn_music_diff_03", 
			"cmn_music_diff_04", "cmn_music_diff_05"
		}; // 0x0
		private static readonly string[] DifficultUvTable_6Line = new string[3] {
			"cmn_music_diff_06", "cmn_music_diff_07", "cmn_music_diff_08"
		}; // 0x4
		private static readonly string[] MusicAttributeUvTable = new string[4] {
			"cmn_zok_01", "cmn_zok_02", "cmn_zok_03", "cmn_zok_04"
		}; // 0x8

		public SceneListSelectEvent OnSelectSceneEvent { get { return m_onSelectSceneEvent; } } //0x137ACFC
		public UnityEvent OnRemoveSceneEvent { get { return m_onRemoveSceneEvent; } } //0x137AD04
		public SceneListSelectEvent OnShowSceneStatusEvent { get { return m_onShowSceneStatusEvent; } } //0x137AD0C
		public SwapScrollList Scroll { get { return m_scrollList; } } //0x137AD14
		public int DivaSlot { get; set; } // 0x94

		// RVA: 0x137AD2C Offset: 0x137AD2C VA: 0x137AD2C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvManager = uvMan;
			m_windowAnimation = layout.FindViewByExId(m_windowExId) as AbsoluteLayout;
			m_episodeLayout = layout.FindViewByExId("swtbl_sel_card_release_sw_sel_card_release_anim") as AbsoluteLayout;
			m_invalidTextLayout = layout.FindViewByExId("swtbl_wintext_01_sw_wintext_01") as AbsoluteLayout;
			m_scoreGaugeLayout = layout.FindViewByExId("sw_sel_card_wind01_anim_swtbl_gauge2_onoff_anim") as AbsoluteLayout;
			m_invalidText.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("scenelist_not_listed_up");
			for(int i = 0; i < m_gaugeNameTexts.Count; i++)
			{
				m_gaugeNameTexts[i].text = MessageManager.Instance.GetBank("menu").GetMessageByLabel(string.Format("pop_score_detail_item_name_{0:00}", i + 1));
			}
			if(m_scorePlusButton != null && m_scoreMinusButton != null)
			{
				m_scorePlusButton.AddOnClickCallback(() => {
					//0x137E290
					OnPushScoreRate(UnitExpectedScore.defaultAddGaugeRatio);
				});
				m_scorePlusButton.AddOnRepeatCallback(() => {
					//0x137E2B4
					OnPushScoreRate(UnitExpectedScore.defaultAddGaugeRatio);
				});
				m_scoreMinusButton.AddOnClickCallback(() => {
					//0x137E2D8
					OnPushScoreRate(-UnitExpectedScore.defaultAddGaugeRatio);
				});
				m_scoreMinusButton.AddOnRepeatCallback(() => {
					//0x137E2FC
					OnPushScoreRate(-UnitExpectedScore.defaultAddGaugeRatio);
				});
				m_scorePlusImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("cmn_con_plus_symbol"));
			}
			m_newAnimeParam.Initialize(1, 60);
			m_initialized = false;
			Loaded();
			ClearLoadedCallback();
			return true;
		}

		// RVA: 0x137B438 Offset: 0x137B438 VA: 0x137B438
		private void Update()
		{
			if(m_initialized)
			{
				int a = m_newAnimeParam.UpdateFrame(TimeWrapper.deltaTime);
				int b = m_comAnimeParam.UpdateFrame(TimeWrapper.deltaTime);
				for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
				{
					SceneIconScrollContent content = m_scrollList.ScrollObjects[i] as SceneIconScrollContent;
					content.UpdateCursorAnime(b);
					content.UpdateNewAnime(a);
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E7D7C Offset: 0x6E7D7C VA: 0x6E7D7C
		// // RVA: 0x137B658 Offset: 0x137B658 VA: 0x137B658
		public IEnumerator LoadScrollObjectCoroutine(TransitionList.Type transitionName)
		{
			string assetBundleName; // 0x1C
			AssetBundleLoadLayoutOperationBase operation; // 0x20
			SceneIconScrollContent scrObject; // 0x24
			int i; // 0x28

			//0x137F494
			int poolSize = m_scrollList.ScrollObjectCount;
			m_decrationMap = new Dictionary<SwapScrollListContent, SceneIconDecoration>(poolSize);
			m_sceneIconDecoration = new SceneIconDecoration[poolSize];
			for(i = 0; i < m_sceneIconDecoration.Length; i++)
			{
				m_sceneIconDecoration[i] = new SceneIconDecoration();
			}
			assetBundleName = "ly/014.xab";
			operation = AssetBundleManager.LoadLayoutAsync(assetBundleName, "SceneIconButton");
			yield return Co.R(operation);
			GameObject prefab = operation.GetAsset<GameObject>();
			yield return Co.R(operation.CreateLayoutCoroutine(prefab.GetComponent<LayoutUGUIRuntime>(), GameManager.Instance.GetSystemFont(), (Layout loadLayout, TexUVListManager loadUvMan) => {
				//0x137E408
				for(i = 0; i < poolSize; i++)
				{
					GameObject g = Instantiate(prefab);
					LayoutUGUIRuntime runtime = g.GetComponent<LayoutUGUIRuntime>();
					runtime.IsLayoutAutoLoad = false;
					runtime.Layout = loadLayout.DeepClone();
					runtime.UvMan = loadUvMan;
					runtime.LoadLayout();
					Text[] ts = g.GetComponentsInChildren<Text>(true);
					for(int j = 0; j < ts.Length; j++)
					{
						ts[j].font = GameManager.Instance.GetSystemFont();
					}
					m_scrollList.AddScrollObject(g.GetComponent<SceneIconScrollContent>());
				}
			}));
			yield return null;
			m_scrollList.Apply();
			if(transitionName == TransitionList.Type.HOME_BG_SELECT)
			{
				operation = AssetBundleManager.LoadLayoutAsync(assetBundleName, "root_sel_card03_layout_root");
				yield return Co.R(operation);
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) => {
					//0x137EAB0
					m_removeButton = instance.GetComponentInChildren<ActionButton>();
					m_removeButton.Hidden = true;
					instance.transform.SetParent(m_scrollList.ScrollContent, false);
					instance.GetComponent<RectTransform>().anchoredPosition = new Vector2(m_scrollList.LeftTopPosition.x, -m_scrollList.LeftTopPosition.y);
				}));
				yield return null;
			}
			if(transitionName == TransitionList.Type.SCENE_SELECT || transitionName == TransitionList.Type.ASSIST_SELECT)
			{
				operation = AssetBundleManager.LoadLayoutAsync(assetBundleName, "RemoveButton");
				yield return Co.R(operation);
				prefab = operation.GetAsset<GameObject>();
				yield return Co.R(operation.CreateLayoutCoroutine(prefab.GetComponent<LayoutUGUIRuntime>(), GameManager.Instance.GetSystemFont(), (Layout loadLayout, TexUVListManager loadUvMan) => {
					//0x137E740
					GameObject g = Instantiate(prefab);
					LayoutUGUIRuntime runtime = g.GetComponent<LayoutUGUIRuntime>();
					runtime.IsLayoutAutoLoad = false;
					runtime.Layout = loadLayout;
					runtime.UvMan = loadUvMan;
					runtime.LoadLayout();
					m_removeButton = g.GetComponentInChildren<ActionButton>(true);
					g.transform.SetParent(m_scrollList.ScrollContent, false);
					g.GetComponent<RectTransform>().anchoredPosition = new Vector2(m_scrollList.LeftTopPosition.x, -m_scrollList.LeftTopPosition.y);
				}));
				yield return null;
			}
			AssetBundleManager.UnloadAssetBundle(assetBundleName);
			if(transitionName == TransitionList.Type.SCENE_SELECT)
				AssetBundleManager.UnloadAssetBundle(assetBundleName);
			for(i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				while(!m_scrollList.ScrollObjects[i].IsLoaded())
					yield return null;
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
			if(m_removeButton != null)
			{
				m_removeButton.AddOnClickCallback(OnRemoveScene);
			}
			SceneIconScrollContent srcObj = m_scrollList.ScrollObjects[0] as SceneIconScrollContent;
			while(!srcObj.IsLoaded())
				yield return null;
			srcObj.InitializeCompatibleAnimeParam(ref m_comAnimeParam);
			m_scrollList.SetContentEscapeMode(true);
			m_initialized = true;
		}

		// // RVA: 0x137B720 Offset: 0x137B720 VA: 0x137B720
		public void InitializeDecoration()
		{
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				SceneIconScrollContent content = m_scrollList.ScrollObjects[i] as SceneIconScrollContent;
				m_sceneIconDecoration[i].Initialize(content.SceneIconImage.gameObject, SceneIconDecoration.Size.M, null, null);
				m_decrationMap.Add(content, m_sceneIconDecoration[i]);
				content.InitializeDecoration();
			}
		}

		// // RVA: 0x137BB7C Offset: 0x137BB7C VA: 0x137BB7C
		public void ReleaseDecoration()
		{
			for(int i = 0; i < m_sceneIconDecoration.Length; i++)
			{
				m_sceneIconDecoration[i].Release();
			}
			m_decrationMap.Clear();
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				(m_scrollList.ScrollObjects[i] as SceneIconScrollContent).ReleaseDecoration();
			}
		}

		// // RVA: 0x137BE58 Offset: 0x137BE58 VA: 0x137BE58
		public void UpdateRemoveButton(FFHPBEPOMAK_DivaInfo divaData, int sceneSlotIndex)
		{
			if(divaData == null)
				return;
			if(m_removeButton == null)
				return;
			m_removeButton.Disable = sceneSlotIndex == 0 ? divaData.FGFIBOBAPIA_SceneId < 1 : divaData.DJICAKGOGFO_SubSceneIds[sceneSlotIndex - 1] < 1;
		}

		// // RVA: 0x137BF7C Offset: 0x137BF7C VA: 0x137BF7C
		public void UpdateRemoveButton(GCIJNCFDNON_SceneInfo sceneData)
		{
			m_removeButton.Disable = sceneData == null ? true : sceneData.BCCHOBPJJKE_SceneId < 1;
		}

		// // RVA: 0x137BFCC Offset: 0x137BFCC VA: 0x137BFCC
		// public void UpdateDefaultButton(GCIJNCFDNON sceneData) { }

		// // RVA: 0x137BFD0 Offset: 0x137BFD0 VA: 0x137BFD0
		public void SetSelectedSlot(int selectedSlotNumber)
		{
			m_selectedSlotNumber = (sbyte)selectedSlotNumber;
			m_scrollList.VisibleRegionUpdate();
		}

		// // RVA: 0x137C000 Offset: 0x137C000 VA: 0x137C000
		public void UpdateContent(DFKGGBMFFGB_PlayerInfo playerData, FFHPBEPOMAK_DivaInfo divaData, int musicId, List<GCIJNCFDNON_SceneInfo> sceneList, List<int> sortListIndexList, int selectedSceneId, DisplayType type, int dispRow, TransitionList.Type transitionType, bool isGoDiva)
		{
			m_dispType = type;
			m_scrollList.SetItemCount(sortListIndexList.Count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener((int index, SwapScrollListContent content) => {
				//0x137ED38
				SceneIconScrollContent scontent = content as SceneIconScrollContent;
				int idx_ = sortListIndexList[index];
				SceneIconDecoration decoration = m_decrationMap[content];
				if(idx_ < 0)
				{
					content.RectTransform.localPosition = new Vector3(-320, content.RectTransform.localPosition.y, 0);
					decoration.SetActive(false);
				}
				else
				{
					int idxLine = index / m_scrollList.ColumnCount;
					int idxCol = index % m_scrollList.ColumnCount;
					content.RectTransform.localPosition = new Vector3(
						m_scrollList.ContentSize.x * idxCol + m_scrollList.LeftTopPosition.x,
						content.RectTransform.localPosition.y, content.RectTransform.localPosition.z
					);
					decoration.SetActive(true);
					bool isActivate = true;
                    SceneIconScrollContent.SkillIconType iconType = SceneIconScrollContent.SkillIconType.None;
					bool isCompatible = false;
					GCIJNCFDNON_SceneInfo sceneInfo = sceneList[idx_];
					if(divaData != null)
					{
						if(((isGoDiva && IsCenterDiva(playerData.DPLBHAIKPGL_GetTeam(false), divaData)) || DivaSlot == 0) && m_selectedSlotNumber == 0)
						{
							isCompatible = sceneInfo.HGONFBDIBPM_ActiveSkillId > 0;
							isActivate = SetDeckSkillIconControl.CheckMatchActiveSkill(sceneInfo);
							iconType = SceneIconScrollContent.SkillIconType.Active;
						}
						else
						{
							if(sceneInfo.DCLLIDMKNGO_IsDivaCompatible(divaData.AHHJLDLAPAN_DivaId))
							{
								if(sceneInfo.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0) > 0)
									isCompatible = true;
							}
							isActivate = SetDeckSkillIconControl.CheckMatchLiveSkill(sceneInfo, divaData.AHHJLDLAPAN_DivaId, musicId);
							iconType = SceneIconScrollContent.SkillIconType.Live;
						}
					}
					scontent.UpdateContent(sceneInfo, GetSceneIconBitFlag(playerData, sceneInfo, isGoDiva), isCompatible, iconType, transitionType, isActivate);
					decoration.Change(sceneInfo, m_dispType);
				}
			});
			int idx = sortListIndexList.FindIndex((int x) => {
				//0x137F3D8
				if(x < 0)
					return false;
				return sceneList[x].BCCHOBPJJKE_SceneId == selectedSceneId;
			});
			int position = 0;
			float yOffset = 0;
			if(idx >= 0)
			{
				position = sortListIndexList.Count / m_scrollList.ColumnCount;
				position -= dispRow;
				int rest = sortListIndexList.Count % m_scrollList.ColumnCount;
				if(rest != 0)
					position++;
				if(idx / m_scrollList.ColumnCount < position)
					position = idx / m_scrollList.ColumnCount;
				if(position < 1)
					position = 0;
				yOffset = 16;
				if(position < 1)
					yOffset = 0;
			}
			m_scrollList.ResetScrollVelocity();
			m_scrollList.SetPosition(position, 0, yOffset, false);
			m_scrollList.VisibleRegionUpdate();
			m_invalidTextLayout.StartAnimGoStop(GetListCount(sortListIndexList) == 0 ? "01" : "02");
		}

		// // RVA: 0x137C66C Offset: 0x137C66C VA: 0x137C66C
		public void UpdateScore(EEDKAACNBBG_MusicData musicBaseData)
		{
			if(m_scoreGaugeLayout != null)
			{
				if(musicBaseData == null)
				{
					m_scoreGaugeLayout.StartChildrenAnimGoStop("02");
					return;
				}
				GameManager.Instance.MusicJacketTextureCache.Load(musicBaseData.JNCPEGJGHOG_JacketId, (IiconTexture texture) => {
					//0x137E320
					texture.Set(m_jacketImage);
				});
				m_musicAttributeImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(MusicAttributeUvTable[musicBaseData.FKDCCLPGKDK_JacketAttr - 1]));
				string key = "";
				string pack = "";
				if(!Database.Instance.gameSetup.musicInfo.IsLine6Mode)
				{
					key = DifficultUvTable[(int)Database.Instance.gameSetup.musicInfo.difficultyType];
					pack = "cmn_tex_pack";
				}
				else
				{
					key = DifficultUvTable_6Line[(int)Database.Instance.gameSetup.musicInfo.difficultyType - 2];
					pack = "cmn_tex_02_pack";
				}
				GameManager.Instance.UnionTextureManager.GetTexture(pack).Set(m_difficultImage);
				m_difficultImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(key));
				int[] scoreParams = new int[10];
				float[] rankPosition = new float[5];
				for(int i = 0; i < 10; i++)
				{
					scoreParams[i] = CMMKCEPBIHI.NDNOLJACLLC_GetScore((CMMKCEPBIHI.NOJENDEDECD_ScoreType)i);
				}
				for(int i = 0; i < 5; i++)
				{
					rankPosition[i] = CMMKCEPBIHI.GPCKPNJGANO_GetRank((ResultScoreRank.Type)i);
				}
				m_scoreGaugeLayout.StartChildrenAnimGoStop("01");
				float viewratio = m_scoreGauge.UpdateScoreGaugeRatio(m_gaugeRateText, m_scorePlusButton, m_scoreMinusButton);
				m_scoreGauge.SetScore(CMMKCEPBIHI.KHCOOPDAGOE_ScoreRank, CMMKCEPBIHI.FDLECNKJCGG_GaugeRatio, rankPosition, scoreParams, viewratio);
			}
		}

		// // RVA: 0x137CE80 Offset: 0x137CE80 VA: 0x137CE80
		public void UpdateScore()
		{
			m_scoreGauge.UpdateScore(m_scoreGauge.UpdateScoreGaugeRatio(m_gaugeRateText, m_scorePlusButton, m_scoreMinusButton));
		}

		// // RVA: 0x137C5A4 Offset: 0x137C5A4 VA: 0x137C5A4
		private int GetListCount(List<int> list)
		{
			int res = 0;
			for(int i = 0; i < list.Count; i++)
			{
				res += (list[i] >> 0x1f) ^ 1;
			}
			return res;
		}

		// // RVA: 0x137CEFC Offset: 0x137CEFC VA: 0x137CEFC
		private bool IsCenterDiva(JLKEOGLJNOD_TeamInfo unitData, FFHPBEPOMAK_DivaInfo divaData)
		{
			if(unitData != null && divaData != null)
			{
				if(unitData.BCJEAJPLGMB_MainDivas[0] != null)
				{
					return unitData.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId == divaData.AHHJLDLAPAN_DivaId;
				}
			}
			return false;
		}

		// // RVA: 0x137D00C Offset: 0x137D00C VA: 0x137D00C
		public void UpdateRegion()
		{
			m_scrollList.VisibleRegionUpdate();
		}

		// // RVA: 0x137D038 Offset: 0x137D038 VA: 0x137D038
		public static uint GetSceneIconBitFlag(DFKGGBMFFGB_PlayerInfo playerData, GCIJNCFDNON_SceneInfo sceneData, bool isGoDiva)
		{
			int res = sceneData.CADENLBDAEB ? 1 : 0;
			if(IsUnitScene(playerData, sceneData, isGoDiva))
				res |= 2;
			if(sceneData.MCCIFLKCNKO_Feed)
				res |= 8;
			if(sceneData.BCCHOBPJJKE_SceneId == JKHEOEEPBMJ.AGHGOOBIGDI_GetHomeSceneId())
				res |= 16;
			return (uint)res;
		}

		// // RVA: 0x137D138 Offset: 0x137D138 VA: 0x137D138
		public static bool IsUnitScene(DFKGGBMFFGB_PlayerInfo playerData, GCIJNCFDNON_SceneInfo sceneData, bool isGoDiva)
		{
			List<FFHPBEPOMAK_DivaInfo> l = playerData.DPLBHAIKPGL_GetTeam(isGoDiva).BCJEAJPLGMB_MainDivas;
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i] != null)
				{
					if(IsDivaEquipScene(l[i], playerData.OPIBAPEGCLA_Scenes, sceneData))
						return true;
				}
			}
			return false;
		}

		// // RVA: 0x137D4EC Offset: 0x137D4EC VA: 0x137D4EC
		// public static bool IsSetScene(DFKGGBMFFGB playerData, GCIJNCFDNON sceneData) { }

		// // RVA: 0x137D32C Offset: 0x137D32C VA: 0x137D32C
		public static bool IsDivaEquipScene(FFHPBEPOMAK_DivaInfo divaData, List<GCIJNCFDNON_SceneInfo> sceneList, GCIJNCFDNON_SceneInfo sceneData)
		{
			for(int i = 0; i < 3; i++)
			{
				int id = 0;
				if(i == 0)
				{
					id = divaData.FGFIBOBAPIA_SceneId;
				}
				else
				{
					id = divaData.DJICAKGOGFO_SubSceneIds[i - 1];
				}
				if(id > 0 && sceneList[id - 1] != null && sceneList[id - 1].BCCHOBPJJKE_SceneId == sceneData.BCCHOBPJJKE_SceneId)
					return true;
			}
			return false;
		}

		// // RVA: 0x137D614 Offset: 0x137D614 VA: 0x137D614
		private void OnSelectListItem(int value, SwapScrollListContent content)
		{
			if(value != 0)
				OnShowSceneStatus(content.Index);
			else
				OnSelectScene(content.Index);
		}

		// // RVA: 0x137D664 Offset: 0x137D664 VA: 0x137D664
		private void OnSelectScene(int listIndex)
		{
			m_onSelectSceneEvent.Invoke(listIndex);
		}

		// // RVA: 0x137D6E4 Offset: 0x137D6E4 VA: 0x137D6E4
		private void OnShowSceneStatus(int listIndex)
		{
			m_onShowSceneStatusEvent.Invoke(listIndex);
		}

		// // RVA: 0x137D764 Offset: 0x137D764 VA: 0x137D764
		private void OnPushScoreRate(float addRatio)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			UnitExpectedScore.baseGaugeScale += addRatio;
			float viewRatio = m_scoreGauge.UpdateScoreGaugeRatio(m_gaugeRateText, m_scorePlusButton, m_scoreMinusButton);
			m_scoreGauge.UpdateScore(viewRatio);
		}

		// // RVA: 0x137D858 Offset: 0x137D858 VA: 0x137D858
		private void OnRemoveScene()
		{
			m_onRemoveSceneEvent.Invoke();
		}

		// // RVA: 0x137D884 Offset: 0x137D884 VA: 0x137D884
		public void SetWait()
		{
			m_windowAnimation.StartChildrenAnimGoStop("st_wait");
		}

		// // RVA: 0x137D900 Offset: 0x137D900 VA: 0x137D900
		public void Show()
		{
			m_windowAnimation.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x137D98C Offset: 0x137D98C VA: 0x137D98C
		public void Hide()
		{
			m_windowAnimation.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x137DA18 Offset: 0x137DA18 VA: 0x137DA18
		public bool IsPlaying()
		{
			return m_windowAnimation.IsPlayingChildren();
		}

		// // RVA: 0x137DA44 Offset: 0x137DA44 VA: 0x137DA44
		public void SetEpisodePoint(int now, int max)
		{
			int a = now;
			if(m_episodeNumber != null)
				a = m_episodeNumber.Length;
			if(m_episodeNumber == null || a == 0)
				return;
			m_episodeNumber[0].SetNumber(max, 0);
			m_episodeNumber[1].SetNumber(now, 0);
			m_episodeLayout.StartChildrenAnimGoStop(now < max ? "st_stop_01" : "st_stop_02");
		}

		// // RVA: 0x137DB84 Offset: 0x137DB84 VA: 0x137DB84
		public void ShowEpisodePoint()
		{
			if(m_episodeLayout != null)
				m_episodeLayout.StartAnimGoStop("01");
		}

		// // RVA: 0x137DBF4 Offset: 0x137DBF4 VA: 0x137DBF4
		public void HideEpisodePoint()
		{
			if(m_episodeLayout != null)
				m_episodeLayout.StartAnimGoStop("02");
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6E7E34 Offset: 0x6E7E34 VA: 0x6E7E34
		// // RVA: 0x137E320 Offset: 0x137E320 VA: 0x137E320
		// private void <UpdateScore>b__54_0(IiconTexture texture) { }
	}
}
