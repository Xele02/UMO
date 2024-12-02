using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Text;
using XeSys;
using mcrs;
using System.Collections;
using XeApp.Core;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class HomeBgSelectList : MonoBehaviour
	{
		[SerializeField]
		private SwapScrollList m_scrollList; // 0xC
		[SerializeField]
		private UGUIButton m_filterButton; // 0x10
		[SerializeField]
		private UGUIToggleButtonGroup m_sceneToggleGroup; // 0x14
		[SerializeField]
		private UGUIToggleButtonGroup m_divaToggleGroup; // 0x18
		[SerializeField]
		private UGUIToggleButtonGroup m_bgDarkToggleGroup; // 0x1C
		[SerializeField]
		private Text m_invalidText; // 0x20
		public UnityAction OnClickSortEvent; // 0x24
		public UnityAction<int, int> OnClickItemEvent; // 0x28
		public UnityAction<bool> sceneToggleEvent; // 0x2C
		private List<int> m_sceneIndexList = new List<int>(); // 0x38
		private List<BgSelectIconScrollContent> m_iconContent = new List<BgSelectIconScrollContent>(); // 0x3C
		private Dictionary<int, PIGBBNDPPJC> m_homeBgEpisodeList = new Dictionary<int, PIGBBNDPPJC>(); // 0x40
		private StringBuilder m_builder = new StringBuilder(); // 0x44
		private bool m_isSceneMode; // 0x48
		private bool m_showDiva; // 0x49
		private bool m_isBgDark; // 0x4A
		private bool m_isSelect; // 0x4B

		public int SelectSceneId { get; private set; } // 0x30
		public int SelectEvolveId { get; private set; } // 0x34

		//// RVA: 0x958360 Offset: 0x958360 VA: 0x958360
		public void Setup()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_invalidText.text = bk.GetMessageByLabel("scenelist_not_listed_up");
			m_invalidText.enabled = false;
			m_divaToggleGroup.OnSelectToggleButtonEvent.RemoveAllListeners();
			m_divaToggleGroup.OnSelectToggleButtonEvent.AddListener((int index) =>
			{
				//0x95A094
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				m_showDiva = index == 0;
				MenuScene.Instance.SetActiveDivaModel(m_showDiva);
			});
			m_sceneToggleGroup.OnSelectToggleButtonEvent.RemoveAllListeners();
			m_sceneToggleGroup.OnSelectToggleButtonEvent.AddListener((int index) =>
			{
				//0x95A1B8
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				m_isSceneMode = index == 1;
				if (sceneToggleEvent != null)
					sceneToggleEvent(m_isSceneMode);
			});
			m_bgDarkToggleGroup.OnSelectToggleButtonEvent.RemoveAllListeners();
			m_bgDarkToggleGroup.OnSelectToggleButtonEvent.AddListener((int index) =>
			{
				//0x95A2A0
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				m_isBgDark = index == 1;
				if(m_isBgDark)
				{
					MenuScene.Instance.BgControl.ShowBgDark();
				}
				else
				{
					MenuScene.Instance.BgControl.HideBgDark();
				}
			});
		}

		//// RVA: 0x9586F0 Offset: 0x9586F0 VA: 0x9586F0
		public void SelectBgSave()
		{
			JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = true;
			JDDGPJDKHNE.HHCJCDFCLOB.NFNLGGHMEAM();
			ILCCJNDFFOB.HHCJCDFCLOB.BBIBBNHCPPJ(JKHEOEEPBMJ.NMKPJJLAONP_GetShowHomeDiva() ? 1 : 0, m_showDiva ? 1 : 0, JKHEOEEPBMJ.HDLMKFFMGEP_GetHomeSceneEvolveId() != 0 ? 1 : 0, SelectEvolveId != 0 ? 1 : 0, CGFNKMNBNBN.MHJBBLBFHIB_IsHomeBgDark() ? 0 : 1, m_isBgDark ? 0 : 1, SelectEvolveId == 0 ? SelectSceneId : 0, SelectEvolveId != 0 ? SelectSceneId : 0, SelectEvolveId == 2 ? 1 : 0);
			JKHEOEEPBMJ.NDFFOBHACPE_SetHomeSceneId(SelectSceneId, SelectEvolveId);
			JKHEOEEPBMJ.MLPMCLHGDFG_SetShowHomeDiva(m_showDiva);
			CGFNKMNBNBN.LLAMCBGJNOG_SetHomeBgDark(m_isBgDark);
			MenuScene.SaveRequest();
		}

		//// RVA: 0x958970 Offset: 0x958970 VA: 0x958970
		//public void InitContentView() { }

		//// RVA: 0x958A4C Offset: 0x958A4C VA: 0x958A4C
		public void UpdateContent(DFKGGBMFFGB_PlayerInfo playerData, List<GCIJNCFDNON_SceneInfo> sceneList, List<HomeBgSelectScene.SceneInfo> sortListIndexList, int dispRow)
		{
			m_homeBgEpisodeList.Clear();
			m_filterButton.Disable = false;
			m_scrollList.SetItemCount(sortListIndexList.Count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
			{
				//0x95A440
				BgSelectIconScrollContent c = content as BgSelectIconScrollContent;
				if (sortListIndexList[index].index < 0)
				{
					content.RectTransform.localPosition = new Vector3(-320, content.RectTransform.localPosition.y, 0);
				}
				else
				{
					int row = index % m_scrollList.ColumnCount;
					content.RectTransform.localPosition = new Vector3(m_scrollList.ContentSize.x * row + m_scrollList.LeftTopPosition.x, content.RectTransform.localPosition.y, 0);
					if(m_isSelect && sortListIndexList[index].index == SelectSceneId - 1 && sortListIndexList[index].evolveId == SelectEvolveId)
					{
						c.UpdateContent(sceneList[sortListIndexList[index].index], sortListIndexList[index].evolveId, true);
					}
					else
					{
						c.UpdateContent(sceneList[sortListIndexList[index].index], sortListIndexList[index].evolveId, false);
					}
				}
			});
			int idx = sortListIndexList.FindIndex((HomeBgSelectScene.SceneInfo x) =>
			{
				//0x95A948
				if(x.index > -1)
				{
					if(sceneList[x.index].BCCHOBPJJKE_SceneId == SelectSceneId)
					{
						if (SelectEvolveId == x.evolveId)
							return true;
					}
				}
				return false;
			});
			int a = 0;
			float y = 0;
			if(idx >= 0)
			{
				int row = idx / m_scrollList.ColumnCount;
				if (row > 0)
					a = row;
				y = 5;
				if (a < 1)
					y = 0;
			}
			m_scrollList.ResetScrollVelocity();
			m_scrollList.SetPosition(a, 0, y, false);
			m_scrollList.VisibleRegionUpdate();
			m_invalidText.enabled = sortListIndexList.Count == 0;
		}

		//// RVA: 0x958ED8 Offset: 0x958ED8 VA: 0x958ED8
		public void UpdateContent(DFKGGBMFFGB_PlayerInfo playerData, List<CGFNKMNBNBN> bgList, int dispRow)
		{
			List<CGFNKMNBNBN> homeBgList = new List<CGFNKMNBNBN>(bgList);
			List<int> unlockBgIdList = new List<int>();
			m_homeBgEpisodeList.Clear();
			List<PIGBBNDPPJC> eps = PIGBBNDPPJC.FKDIMODKKJD_GetAvaiableEpisodes(false);
			for(int i = 0; i < eps.Count; i++)
			{
				if(!eps[i].CCBKMCLDGAD_HasReward)
				{
					if (EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(eps[i].KIJAPOFAGPN_UnlockItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg)
					{
						int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(eps[i].KIJAPOFAGPN_UnlockItemId);
						homeBgList.Add(CGFNKMNBNBN.ELKDCEEPLKB(itemId));
						unlockBgIdList.Add(itemId);
						m_homeBgEpisodeList.Add(itemId, eps[i]);
					}
				}
			}
			m_filterButton.Disable = true;
			m_scrollList.SetItemCount(homeBgList.Count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
			{
				//0x95AA3C
				BgSelectIconScrollContent c = content as BgSelectIconScrollContent;
				if (index < 0)
				{
					content.RectTransform.localPosition = new Vector3(-320, content.RectTransform.localPosition.y, 0);
					return;
				}
				int row = index % m_scrollList.ColumnCount;
				content.RectTransform.localPosition = new Vector3(m_scrollList.ContentSize.x * row + m_scrollList.LeftTopPosition.x, content.RectTransform.localPosition.y, 0);
				bool isSelect = false;
				bool isLock = false;
				if (m_isSelect && SelectSceneId == homeBgList[index].PPFNGGCBJKC_Id && SelectEvolveId == 0)
				{
					isSelect = true;
					isLock = false;
				}
				else
				{
					isLock = unlockBgIdList.Contains((int)homeBgList[index].PPFNGGCBJKC_Id);
					isSelect = false;
				}
				c.UpdateContent(homeBgList[index], isSelect, isLock, 0);
			});
			int idx = homeBgList.FindIndex((CGFNKMNBNBN x) =>
			{
				//0x95AE94
				if(x.KEFGPJBKAOD_BgId > -1)
				{
					return x.KEFGPJBKAOD_BgId == SelectSceneId;
				}
				return false;
			});
			int a = 0;
			float y = 0;
			if(idx >= 0)
			{
				int row = idx / m_scrollList.ColumnCount;
				if (row > 0)
					a = row;
				y = 5;
				if (a < 1)
					y = 0;
			}
			m_scrollList.ResetScrollVelocity();
			m_scrollList.SetPosition(a, 0, y, false);
			m_scrollList.VisibleRegionUpdate();
			m_invalidText.enabled = homeBgList.Count == 0;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E524C Offset: 0x6E524C VA: 0x6E524C
		//// RVA: 0x959680 Offset: 0x959680 VA: 0x959680
		public IEnumerator LoadScrollObjectCoroutine()
		{
			string assetBundleName; // 0x18
			AssetBundleLoadLayoutOperationBase operation; // 0x1C
			int i; // 0x20

			//0x95B920
			m_iconContent.Clear();
			int poolSize = m_scrollList.ScrollObjectCount;
			assetBundleName = "ly/014.xab";
			operation = AssetBundleManager.LoadLayoutAsync(assetBundleName, "root_sel_bg_layout_root");
			yield return operation;
			GameObject prefab = operation.GetAsset<GameObject>();
			LayoutUGUIRuntime runtime = prefab.GetComponent<LayoutUGUIRuntime>();
			yield return Co.R(operation.CreateLayoutCoroutine(runtime, GameManager.Instance.GetSystemFont(), (Layout loadLayout, TexUVListManager loadUvMan) =>
			{
				//0x95AEF8
				for(i = 0; i < poolSize; i++)
				{
					GameObject g = Instantiate(prefab);
					LayoutUGUIRuntime r = g.GetComponent<LayoutUGUIRuntime>();
					r.IsLayoutAutoLoad = false;
					r.Layout = loadLayout.DeepClone();
					r.UvMan = loadUvMan;
					r.LoadLayout();
					Text[] txts = g.GetComponentsInChildren<Text>(true);
					for(int j = 0; j < txts.Length; j++)
					{
						GameManager.Instance.GetSystemFont().Apply(txts[j]);
					}
					m_scrollList.AddScrollObject(g.GetComponent<BgSelectIconScrollContent>());
					m_iconContent.Add(g.GetComponent<BgSelectIconScrollContent>());
				}
			}));
			yield return null;
			m_scrollList.Apply();
			AssetBundleManager.UnloadAssetBundle(assetBundleName, false);
			for(i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				while (!m_scrollList.ScrollObjects[i].IsLoaded())
					yield return null;
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
			for(i = 0; i < m_iconContent.Count; i++)
			{
				m_iconContent[i].InitPlateState();
			}
			m_filterButton.AddOnClickCallback(() =>
			{
				//0x95B27C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				MenuScene.Instance.ShowSortWindow(PopupFilterSort.Scene.SelectHomeBg, (PopupFilterSort content) =>
				{
					//0x95B3DC
					OnClickSortEvent();
				}, null, true);
			});
			m_scrollList.SetContentEscapeMode(true);
		}

		//// RVA: 0x95972C Offset: 0x95972C VA: 0x95972C
		public void UpdateView()
		{
			SelectSceneId = JKHEOEEPBMJ.AGHGOOBIGDI_GetHomeSceneId();
			SelectEvolveId = JKHEOEEPBMJ.HDLMKFFMGEP_GetHomeSceneEvolveId();
			m_showDiva = JKHEOEEPBMJ.NMKPJJLAONP_GetShowHomeDiva();
			m_isSceneMode = SelectEvolveId != 0;
			m_isBgDark = CGFNKMNBNBN.MHJBBLBFHIB_IsHomeBgDark();
			m_isSelect = false;
			m_sceneToggleGroup.SelectGroupButton(m_isSceneMode ? 1 : 0);
			m_divaToggleGroup.SelectGroupButton(m_showDiva ? 0 : 1);
			m_bgDarkToggleGroup.SelectGroupButton(m_isBgDark ? 1 : 0);
		}

		//// RVA: 0x959868 Offset: 0x959868 VA: 0x959868
		//private void SetFilterButtonAction(UnityAction act) { }

		//// RVA: 0x959970 Offset: 0x959970 VA: 0x959970
		private void OnSelectListItem(int value, SwapScrollListContent content)
		{
			BgSelectIconScrollContent c = content as BgSelectIconScrollContent;
			if(!c.IsLock)
			{
				this.StartCoroutineWatched(ChangeBgCoroutine(c));
			}
			else
			{
				if (!m_homeBgEpisodeList.ContainsKey(c.SceneID))
					return;
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				HomeBgSelectListTermsPopup.Setting s = new HomeBgSelectListTermsPopup.Setting();
				s.TitleText = bk.GetMessageByLabel("popup_sel_cos_terms_title");
				s.m_bg_id = c.SceneID;
				s.WindowSize = SizeType.Middle;
				s.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Episode, Type = PopupButton.ButtonType.Episode }
				};
				m_builder.SetFormat(bk.GetMessageByLabel("popup_sel_cos_terms_text_base"), m_homeBgEpisodeList[c.SceneID].OPFGFINHFCE_Name);
				s.m_text = m_builder.ToString();
				this.StartCoroutineWatched(ShowLockPopup(s));
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E52C4 Offset: 0x6E52C4 VA: 0x6E52C4
		//// RVA: 0x959E94 Offset: 0x959E94 VA: 0x959E94
		private IEnumerator ShowLockPopup(HomeBgSelectListTermsPopup.Setting setting)
		{
			//0x95C0B4
			bool t_next_episode = false;
			bool t_end_popup = false;
			PopupWindowManager.Show(setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x95B450
				t_next_episode = label == PopupButton.ButtonLabel.Episode;
			}, null, null, null, true, true, false, null, () =>
			{
				//0x95B464
				t_end_popup = true;
			});
			while (!t_end_popup)
				yield return null;
			if (t_next_episode)
			{
				MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_EPISODESELECT_EPISODEDETAIL, new EpisodeDetailArgs() { data = m_homeBgEpisodeList[setting.m_bg_id] }, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E533C Offset: 0x6E533C VA: 0x6E533C
		//// RVA: 0x959DD4 Offset: 0x959DD4 VA: 0x959DD4
		private IEnumerator ChangeBgCoroutine(BgSelectIconScrollContent sceneContent)
		{
			//0x95B474
			MenuScene.Instance.RaycastDisable();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(SelectSceneId != sceneContent.SceneID || SelectEvolveId != sceneContent.EvolveID)
			{
				m_isSelect = true;
				MenuScene.Instance.BgControl.ReserveFade(0.1f, Color.black);
				SelectEvolveId = 0;
				if(m_isSceneMode)
				{
					SelectEvolveId = sceneContent.EvolveID;
				}
				SelectSceneId = sceneContent.SceneID;
				yield return Co.R(MenuScene.Instance.BgControl.ChangeHomeBgCoroutine(BgType.Home, sceneContent.SceneID, sceneContent.EvolveID, m_isBgDark, SceneGroupCategory.HOME, TransitionList.Type.HOME, -1));
				m_scrollList.VisibleRegionUpdate();
			}
			MenuScene.Instance.RaycastEnable();
		}
	}
}
