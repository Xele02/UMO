using mcrs;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class HomeBgSelectScene : TransitionRoot
	{
		public struct SceneInfo
		{
			public int index; // 0x0
			public short evolveId; // 0x4
		}

		private UGUIEnterLeave m_ButtonGroup; // 0x48
		private UGUIEnterLeave m_ListGroup; // 0x4C
		private HomeBgSelectWindow m_homeBgSelectWindow; // 0x50
		private HomeBgSelectList m_homeBgSelectList; // 0x54
		private ListSortButtonGroup m_sortButtonGroup; // 0x58
		private List<SceneInfo> m_sceneIndexList = new List<SceneInfo>(); // 0x5C
		private List<CGFNKMNBNBN> m_bgDataList = new List<CGFNKMNBNBN>(); // 0x60
		private bool isPreview; // 0x64
		
		private DFKGGBMFFGB_PlayerInfo PlayerData { get { return GameManager.Instance.ViewPlayerData; } } //0x95CA9C
		
		// RVA: 0x95CB38 Offset: 0x95CB38 VA: 0x95CB38
		private void Start()
		{
			this.StartCoroutineWatched(InitializeCoroutine());
		}

		// RVA: 0x95CBE8 Offset: 0x95CBE8 VA: 0x95CBE8
		private void Update()
		{
			if (!isPreview)
				return;
			if (!InputManager.Instance.IsScreenTouch())
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			isPreview = false;
			m_ButtonGroup.Show();
			m_ListGroup.Show();
		}

		//// RVA: 0x95CD50 Offset: 0x95CD50 VA: 0x95CD50
		private void OnBackButton()
		{
			if (!isPreview)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			isPreview = false;
			m_ButtonGroup.Show();
			m_ListGroup.Show();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E5544 Offset: 0x6E5544 VA: 0x6E5544
		//// RVA: 0x95CB5C Offset: 0x95CB5C VA: 0x95CB5C
		private IEnumerator InitializeCoroutine()
		{
			XeSys.FontInfo systemFont; // 0x14
			StringBuilder bundleName; // 0x18
			int bundleLoadCount; // 0x1C
			AssetBundleLoadUGUIOperationBase uguiOp; // 0x20

			//0x95EF68
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName = new StringBuilder();
			bundleName.Set("ly/226.xab");
			bundleLoadCount = 0;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "SelectBgButtons");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0x95E610
				instance.transform.SetParent(transform, false);
				m_ButtonGroup = instance.GetComponentInChildren<UGUIEnterLeave>();
				m_homeBgSelectWindow = instance.GetComponentInChildren<HomeBgSelectWindow>();
				m_homeBgSelectWindow.OnClickOkEvent = () =>
				{
					//0x95E8AC
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					m_homeBgSelectList.SelectBgSave();
					MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				};
				m_homeBgSelectWindow.OnClickCancelEvent = () =>
				{
					//0x95EC80
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_002);
					MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				};
				m_homeBgSelectWindow.OnClickPreviewEvent = () =>
				{
					//0x95E9D0
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					this.StartCoroutineWatched(DelayPreviewMode());
				};
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "SelectBgList");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0x95EA44
				instance.transform.SetParent(transform, false);
				m_ListGroup = instance.GetComponentInChildren<UGUIEnterLeave>();
				m_homeBgSelectList = instance.GetComponentInChildren<HomeBgSelectList>();
				m_homeBgSelectList.OnClickSortEvent = OnClickFilter;
				m_homeBgSelectList.sceneToggleEvent = SceneToggleChange;
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			yield return Co.R(m_homeBgSelectList.LoadScrollObjectCoroutine());
			IsReady = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E55BC Offset: 0x6E55BC VA: 0x6E55BC
		//// RVA: 0x95CE20 Offset: 0x95CE20 VA: 0x95CE20
		private IEnumerator DelayPreviewMode()
		{
			//0x95EE28
			yield return null;
			m_ButtonGroup.Hide();
			m_ListGroup.Hide();
			isPreview = true;
		}

		//// RVA: 0x95CECC Offset: 0x95CECC VA: 0x95CECC
		private void Sort()
		{
			Listup((uint)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.GIDCHFBCBML_SelectHomeBG.PLNMMHPILLO_FilterRarity, (uint)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.GIDCHFBCBML_SelectHomeBG.HBEFGKLLMEC_FilterSeries);
		}

		//// RVA: 0x95CFF4 Offset: 0x95CFF4 VA: 0x95CFF4
		private void Listup(uint rarityFilterBit = 4294967295, uint seriaseFilterBit = 4294967295)
		{
			m_sceneIndexList.Clear();
			List<int> l = new List<int>();
			for(int i = 0; i < PlayerData.OPIBAPEGCLA_Scenes.Count; i++)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.FGNJBMPDBLO_IsSceneValid(PlayerData.OPIBAPEGCLA_Scenes[i].BCCHOBPJJKE_SceneId))
				{
					if(PlayerData.OPIBAPEGCLA_Scenes[i].CGKAEMGLHNK_IsUnlocked() && !PlayerData.OPIBAPEGCLA_Scenes[i].MCCIFLKCNKO_Feed)
					{
						if(PopupSortMenu.IsSerializeFilterOn((int)PlayerData.OPIBAPEGCLA_Scenes[i].AIHCEGFANAM_SceneSeries, seriaseFilterBit))
						{
							if(JKHEOEEPBMJ.DGGEAHIKPBB <= PlayerData.OPIBAPEGCLA_Scenes[i].JKGFBFPIMGA_Rarity)
							{
								l.Add(i);
							}
						}
					}
				}
			}
			l.Sort(DefaultSortCb);
			for(int i = 0; i < l.Count; i++)
			{
				GCIJNCFDNON_SceneInfo scene = PlayerData.OPIBAPEGCLA_Scenes[l[i]];
				if(scene.EKLIPGELKCL_SceneRarity == scene.JKGFBFPIMGA_Rarity)
				{
					if(PopupSortMenu.IsRarityFilterOn(scene.EKLIPGELKCL_SceneRarity, rarityFilterBit))
					{
						m_sceneIndexList.Add(new SceneInfo() { index = l[i], evolveId = (short)scene.CGIELKDLHGE_GetEvolveId() });
					}
				}
				else
				{
					if (PopupSortMenu.IsRarityFilterOn(scene.JKGFBFPIMGA_Rarity, rarityFilterBit) || PopupSortMenu.IsRarityFilterOn(scene.EKLIPGELKCL_SceneRarity, rarityFilterBit))
					{
						if(PopupSortMenu.IsRarityFilterOn(scene.EKLIPGELKCL_SceneRarity, rarityFilterBit))
						{
							m_sceneIndexList.Add(new SceneInfo() { index = l[i], evolveId = 2 });
						}
						if(PopupSortMenu.IsRarityFilterOn(scene.JKGFBFPIMGA_Rarity, rarityFilterBit))
						{
							if(!scene.JOKJBMJBLBB_Single)
								m_sceneIndexList.Add(new SceneInfo() { index = l[i], evolveId = 1 });
						}
					}
				}
			}
		}

		//// RVA: 0x95D740 Offset: 0x95D740 VA: 0x95D740
		private void OnClickFilter()
		{
			Sort();
			int setBgId = JKHEOEEPBMJ.AGHGOOBIGDI_GetHomeSceneId();
			int setEvolveId = JKHEOEEPBMJ.HDLMKFFMGEP_GetHomeSceneEvolveId();
			if(setEvolveId != 0)
			{
				m_sceneIndexList.RemoveAll((HomeBgSelectScene.SceneInfo x) =>
				{
					//0x95ED84
					if (x.index != setBgId - 1)
						return false;
					return setEvolveId == x.evolveId;
				});
				m_sceneIndexList.Insert(0, new SceneInfo() { index = setBgId - 1, evolveId = (short)setEvolveId });
			}
			m_homeBgSelectList.UpdateContent(PlayerData, PlayerData.OPIBAPEGCLA_Scenes, m_sceneIndexList, 0);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E5634 Offset: 0x6E5634 VA: 0x6E5634
		//// RVA: 0x95D98C Offset: 0x95D98C VA: 0x95D98C
		//private IEnumerator UpdateContentCoroutine() { }

		//// RVA: 0x95DA38 Offset: 0x95DA38 VA: 0x95DA38
		private void SceneToggleChange(bool value)
		{
			int setBgId = JKHEOEEPBMJ.AGHGOOBIGDI_GetHomeSceneId();
			int setEvolveId = JKHEOEEPBMJ.HDLMKFFMGEP_GetHomeSceneEvolveId();
			if (!value)
			{
				m_bgDataList = CGFNKMNBNBN.ABOLOPHFADL();
				if (setEvolveId == 0)
				{
					CGFNKMNBNBN item = CGFNKMNBNBN.ELKDCEEPLKB(setBgId);
					m_bgDataList.RemoveAll((CGFNKMNBNBN x) =>
					{
						//0x95EDE4
						return x.PPFNGGCBJKC_Id == setBgId;
					});
					m_bgDataList.Insert(0, item);
				}
				m_homeBgSelectList.UpdateContent(PlayerData, m_bgDataList, 0);
				return;
			}
			if(setEvolveId != 0)
			{
				m_sceneIndexList.RemoveAll((SceneInfo x) =>
				{
					//0x95EDB4
					if (x.index != setBgId - 1)
						return false;
					return setEvolveId == x.evolveId;
				});
				m_sceneIndexList.Insert(0, new SceneInfo() { index = setBgId - 1, evolveId = (short)setEvolveId });
			}
			m_homeBgSelectList.UpdateContent(PlayerData, PlayerData.OPIBAPEGCLA_Scenes, m_sceneIndexList, 0);
		}

		//// RVA: 0x95DD4C Offset: 0x95DD4C VA: 0x95DD4C
		private int DefaultSortCb(int left, int right)
		{
			if (left < 0)
				return -1;
			if (right < 0)
				return 1;
			int res = GetSameEvaluationValue2(PlayerData.OPIBAPEGCLA_Scenes[left], PlayerData.OPIBAPEGCLA_Scenes[right]);
			if(res == 0)
			{
				res = GetSameEvaluationValue3(PlayerData.OPIBAPEGCLA_Scenes[left], PlayerData.OPIBAPEGCLA_Scenes[right]);
			}
			return res;
		}

		//// RVA: 0x95DFB4 Offset: 0x95DFB4 VA: 0x95DFB4
		//private int GetSameEvaluationValue(GCIJNCFDNON left, GCIJNCFDNON right) { }

		//// RVA: 0x95DEE8 Offset: 0x95DEE8 VA: 0x95DEE8
		private int GetSameEvaluationValue2(GCIJNCFDNON_SceneInfo left, GCIJNCFDNON_SceneInfo right)
		{
			return right.JKGFBFPIMGA_Rarity - left.JKGFBFPIMGA_Rarity;
		}

		//// RVA: 0x95DF28 Offset: 0x95DF28 VA: 0x95DF28
		private int GetSameEvaluationValue3(GCIJNCFDNON_SceneInfo left, GCIJNCFDNON_SceneInfo right)
		{
			return SortMenuWindow.SortThirdPriority(left, right);
		}

		// RVA: 0x95E040 Offset: 0x95E040 VA: 0x95E040 Slot: 16
		protected override void OnPreSetCanvas()
		{
			Sort();
			m_homeBgSelectList.UpdateView();
			SceneToggleChange(JKHEOEEPBMJ.HDOOGKNLOGI_IsHomeSceneEvolve());
			GameManager.Instance.SceneIconCache.TryInstall(PlayerData);
		}

		// RVA: 0x95E170 Offset: 0x95E170 VA: 0x95E170 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			if (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				return false;
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
			m_homeBgSelectList.Setup();
			return base.IsEndPreSetCanvas();
		}

		// RVA: 0x95E2D8 Offset: 0x95E2D8 VA: 0x95E2D8 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			MenuScene.Instance.SetActiveDivaModel(JKHEOEEPBMJ.NMKPJJLAONP_GetShowHomeDiva(), true);
			m_ButtonGroup.Enter();
			m_ListGroup.Enter();
			return base.IsEndPostSetCanvas();
		}

		// RVA: 0x95E404 Offset: 0x95E404 VA: 0x95E404 Slot: 12
		protected override void OnStartExitAnimation()
		{
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			m_ButtonGroup.Leave();
			m_ListGroup.Leave();
		}

		// RVA: 0x95E520 Offset: 0x95E520 VA: 0x95E520 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_ListGroup.IsPlaying();
		}
	}
}
