using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class DivaSelectList : LayoutUGUIScriptBase
	{
		private enum RemoveDivaState
		{
			CenterDiva = 0,
			EmptySlot = 1,
			Ok = 2,
		}

		[SerializeField]
		private ActionButton m_removeButton; // 0x14
		[SerializeField]
		private StayButton m_selectDivaButton; // 0x18
		[SerializeField]
		private RawImageEx m_selectDivaIconImage; // 0x1C
		[SerializeField]
		private RawImageEx m_selectDivaCenterIconImage; // 0x20
		[SerializeField]
		private RawImageEx[] m_selectDivaSceneImages; // 0x24
		[SerializeField]
		private RawImageEx[] m_skillIconImages; // 0x28
		[SerializeField]
		private UnityEvent m_onRemoveEvent; // 0x2C
		[SerializeField]
		private SelectDivaEvent m_onSelectDivaEvent; // 0x30
		[SerializeField]
		private SelectDivaEvent m_onShowDivaStatusEvent; // 0x34
		[SerializeField]
		private SelecteDivaSceneSelectEvent m_onShowSelectedDivaSceneStatus; // 0x38
		[SerializeField]
		private string m_animeLayoutExId; // 0x3C
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x40
		private DivaIconDecoration m_divaIconDecoration = new DivaIconDecoration(); // 0x44
		private SceneIconDecoration[] m_sceneIconDecraitons; // 0x48
		private AbsoluteLayout m_animationLayout; // 0x4C
		private AbsoluteLayout[] m_compatibleAnimeLayout; // 0x50
		private AbsoluteLayout[] m_skillIconLayout; // 0x54
		private EEDKAACNBBG m_musicData; // 0x58
		private sbyte m_compatibleFlags; // 0x5C
		private bool m_isSelectedCenterDiva; // 0x5D
		private CompatibleLayoutAnimeParam m_comAnimeParam; // 0x60
		private List<int> m_sortDivaList; // 0x6C
		private List<DivaSelectListIcon> m_divaListIcon = new List<DivaSelectListIcon>(); // 0x70
		private TexUVListManager m_uvManager; // 0x74
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0x78
		private DisplayType m_displayType; // 0x7C

		public UnityEvent OnRemoveEvent { get { return m_onRemoveEvent; } } //0x17E7C24
		public SelectDivaEvent OnSelectDivaEvent { get { return m_onSelectDivaEvent; } } //0x17E7C2C
		public SelectDivaEvent OnShowDivaStatusEvent { get { return m_onShowDivaStatusEvent; } } //0x17E7C34
		public SelecteDivaSceneSelectEvent OnShowSelectedDivaSceneStatus { get { return m_onShowSelectedDivaSceneStatus; } } //0x17E7C3C

		// RVA: 0x17E7C44 Offset: 0x17E7C44 VA: 0x17E7C44 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_sceneIconDecraitons = new SceneIconDecoration[3];
			if(m_scrollList != null)
			{
				m_scrollList.OnUpdateItem.AddListener(UpdateScrollContent);
			}
			m_animationLayout = layout.FindViewByExId(m_animeLayoutExId) as AbsoluteLayout;
			m_selectDivaButton.AddOnClickCallback(OnShowSelectedDivaStatus);
			StringBuilder str = new StringBuilder(64);
			m_skillIconLayout = new AbsoluteLayout[3];
			m_compatibleAnimeLayout = new AbsoluteLayout[3];
			for (int i = 0; i < 3; i++)
			{
				str.Clear();
				if (i == 0)
					str.Append("sw_sel_card_window03_cmn_scene_icon_main");
				else
					str.AppendFormat("sw_sel_card_window03_cmn_scene_icon_sab{0:D2}", i);
				AbsoluteLayout abs = (layout.FindViewByExId(str.ToString()) as AbsoluteLayout);
				m_skillIconLayout[i] = abs.FindViewByExId("sw_cmn_scene_icon_anim_sw_sel_card_skill_ef_anim") as AbsoluteLayout;
				m_compatibleAnimeLayout[i] = abs.FindViewByExId("swtbl_sel_card_skill_sw_sel_card_skill_ef_anim") as AbsoluteLayout;
			}
			m_comAnimeParam.Initialize(m_compatibleAnimeLayout[0].FrameAnimation.SearchLabelFrame("loen_act"), m_compatibleAnimeLayout[0].FrameAnimation.SearchLabelFrame("logo_act"));
			m_uvManager = uvMan;
			return true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E7BD4 Offset: 0x6E7BD4 VA: 0x6E7BD4
		//// RVA: 0x17E845C Offset: 0x17E845C VA: 0x17E845C
		public IEnumerator LoadDivaIconPanelCoroutine()
		{
			AssetBundleLoadLayoutOperationBase lytOperation; // 0x18

			//0x17ECA98
			if(m_scrollList != null)
			{
				LayoutUGUIRuntime runtime = null;
				lytOperation = AssetBundleManager.LoadLayoutAsync("ly/014.xab", "root_sel_chara_icon_layout_root");
				yield return lytOperation;

				yield return lytOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x17EC610
					runtime = instance.GetComponent<LayoutUGUIRuntime>();
				});
				for(int i = 0; i < m_scrollList.ScrollObjectCount - 1; i++)
				{
					LayoutUGUIRuntime inst = Instantiate(runtime);
					inst.IsLayoutAutoLoad = false;
					inst.Layout = runtime.Layout.DeepClone();
					inst.UvMan = runtime.UvMan;
					inst.LoadLayout();
					m_scrollList.AddScrollObject(inst.GetComponent<SwapScrollListContent>());
					m_divaListIcon.Add(inst.GetComponent<DivaSelectListIcon>());
				}
				m_scrollList.AddScrollObject(runtime.GetComponent<SwapScrollListContent>());
				m_divaListIcon.Add(runtime.GetComponent<DivaSelectListIcon>());
				yield return null;
				m_scrollList.Apply();
			}
		}

		//// RVA: 0x17E8508 Offset: 0x17E8508 VA: 0x17E8508
		public void Initialize()
		{
			m_divaIconDecoration.Initialize(m_selectDivaIconImage.gameObject, DivaIconDecoration.Size.S, true, false, null, null);
			for(int i = 0; i < m_divaListIcon.Count; i++)
			{
				m_divaListIcon[i].InitializeDecoration();
			}
			for(int i = 0; i < m_sceneIconDecraitons.Length; i++)
			{
				m_sceneIconDecraitons[i] = new SceneIconDecoration();
				m_sceneIconDecraitons[i].Initialize(m_selectDivaSceneImages[i].gameObject, SceneIconDecoration.Size.M, null,null);
			}
		}

		//// RVA: 0x17E8908 Offset: 0x17E8908 VA: 0x17E8908
		public void Release()
		{
			m_divaIconDecoration.Release();
			for(int i = 0; i < m_divaListIcon.Count; i++)
			{
				m_divaListIcon[i].ReleaseDecoration();
			}
			for(int i = 0; i < m_sceneIconDecraitons.Length; i++)
			{
				m_sceneIconDecraitons[i].Release();
			}
		}

		// RVA: 0x17E8B28 Offset: 0x17E8B28 VA: 0x17E8B28
		private void Update()
		{
			for(int i = 0; i < m_divaListIcon.Count; i++)
			{
				m_divaListIcon[i].UpdateCompatibleAnime(Time.deltaTime);
			}
			UpdateCompatibleAnime(Time.deltaTime);
		}

		//// RVA: 0x17E8DB4 Offset: 0x17E8DB4 VA: 0x17E8DB4
		public void UpdateContent(FFHPBEPOMAK selectedDiva, List<int> sortDivaIndexList, int slotNo, EEDKAACNBBG musicData)
		{
			m_sortDivaList = sortDivaIndexList;
			m_musicData = musicData;
			m_isSelectedCenterDiva = slotNo == 0;
			if(selectedDiva == null)
			{
				MenuScene.Instance.DivaIconCache.Load(0, 0, 0, (IiconTexture texture) => {
					//0x17EC528
					texture.Set(m_selectDivaIconImage);
				});
				m_divaIconDecoration.SetActive(false);
				m_selectDivaCenterIconImage.enabled = false;
				for(int i = 0; i < m_selectDivaSceneImages.Length; i++)
				{
					int index = i;
					GameManager.Instance.SceneIconCache.Load(0, 0, (IiconTexture texture) => {
						//0x17EC864
						texture.Set(m_selectDivaSceneImages[index]);
						SceneIconTextureCache.ChangeKiraMaterial(m_selectDivaSceneImages[index], texture as IconTexture, false);
					});
					m_sceneIconDecraitons[i].SetActive(false);

				}
				for(int i = 0; i < m_compatibleAnimeLayout.Length; i++)
				{
					m_compatibleAnimeLayout[i].StartChildrenAnimGoStop("st_non");
				}
				m_compatibleFlags = 0;
			}
			else
			{
				MenuScene.Instance.DivaIconCache.Load(selectedDiva.AHHJLDLAPAN_DivaId, selectedDiva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, selectedDiva.EKFONBFDAAP_ColorId, (IiconTexture texture) => {
					//0x17EC448
					texture.Set(m_selectDivaIconImage);
				});
				m_selectDivaCenterIconImage.enabled = m_isSelectedCenterDiva;
				for(int i = 0; i < 3; i++)
				{
					int index = i;
					m_skillIconLayout[i].StartChildrenAnimGoStop("01");
					GCIJNCFDNON scene = null;
					if(i == 0)
					{
						if(selectedDiva.FGFIBOBAPIA_SceneId > 0)
						{
							scene = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[selectedDiva.FGFIBOBAPIA_SceneId - 1];
						}
					}
					else
					{
						if (selectedDiva.DJICAKGOGFO_SubSceneIds[i - 1] > 0)
						{
							scene = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[selectedDiva.DJICAKGOGFO_SubSceneIds[i - 1] - 1];
						}
					}
					bool isKira = scene != null ? scene.MBMFJILMOBP() : false;
					GameManager.Instance.SceneIconCache.Load(scene != null ? scene.BCCHOBPJJKE_SceneId : 0, scene != null ? scene.CGIELKDLHGE_GetEvolveId() : 0, (IiconTexture texture) => {
						//0x17EC68C
						texture.Set(m_selectDivaSceneImages[index]);
						SceneIconTextureCache.ChangeKiraMaterial(m_selectDivaSceneImages[index], texture as IconTexture, isKira);
					});
					m_sceneIconDecraitons[i].SetActive(scene != null && scene.BCCHOBPJJKE_SceneId > 0);
					if(i == 0 && m_isSelectedCenterDiva)
					{
						if(scene != null && scene.HGONFBDIBPM_ActiveSkillId > 0)
						{
							if(!SetDeckSkillIconControl.CheckMatchActiveSkill(scene))
							{
								m_skillIconLayout[0].StartChildrenAnimGoStop("02");
							}
							m_compatibleFlags |= (sbyte)((0x1000000 << i) >> 0x18);
							SetSkillTypeIcon(SceneIconScrollContent.SkillIconType.Active, i * 2);
						}
						else
						{
							m_compatibleFlags &= (sbyte)~((0x1000000 << i) >> 0x18);
							m_compatibleAnimeLayout[i].StartChildrenAnimGoStop("st_non");
						}
					}
					else
					{
						if(scene != null && scene.DCLLIDMKNGO(selectedDiva.AHHJLDLAPAN_DivaId) && scene.FILPDDHMKEJ(false, 0, 0) > 0)
						{
							if(!SetDeckSkillIconControl.CheckMatchLiveSkill(scene, selectedDiva.AHHJLDLAPAN_DivaId, musicData != null ? musicData.DLAEJOBELBH_MusicId : 0))
							{
								m_skillIconLayout[i].StartChildrenAnimGoStop("02");
							}
							m_compatibleFlags |= (sbyte)((0x1000000 << i) >> 0x18);
							SetSkillTypeIcon(SceneIconScrollContent.SkillIconType.Live, i * 2);
						}
						else
						{
							m_compatibleFlags &= (sbyte)~((0x1000000 << i) >> 0x18);
							m_compatibleAnimeLayout[i].StartChildrenAnimGoStop("st_non");
						}
					}
				}
			}
			if(m_removeButton != null)
			{
				m_removeButton.ClearOnClickCallback();
				m_removeButton.AddOnClickCallback(OnRemoveButton);
				if(selectedDiva == null || GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId == selectedDiva.AHHJLDLAPAN_DivaId)
				{
					m_removeButton.Dark = true;
				}
				else
				{
					m_removeButton.Dark = false;
				}
			}
			m_scrollList.SetItemCount(sortDivaIndexList.Count);
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}

		//// RVA: 0x17E9E6C Offset: 0x17E9E6C VA: 0x17E9E6C
		private void UpdateScrollContent(int index, SwapScrollListContent content)
		{
			DivaSelectListIcon data = content as DivaSelectListIcon;
			FFHPBEPOMAK f = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC[m_sortDivaList[index]];
			data.SetDivaIcon(f.AHHJLDLAPAN_DivaId, f.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, f.EKFONBFDAAP_ColorId, IsCenter(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH, f.AHHJLDLAPAN_DivaId), IsUnitMember(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH, f.AHHJLDLAPAN_DivaId));
			for(int i = 0; i < 3; i++)
			{
				if (i == 0)
				{
					bool isKira = false;
					bool isCompatible = false;
					bool isActivate = true;
					int sceneId = f.FGFIBOBAPIA_SceneId;
					int rank = 0;
					if (sceneId >= 1)
					{
						GCIJNCFDNON scene = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[sceneId - 1];
						sceneId = scene.BCCHOBPJJKE_SceneId;
						rank = scene.CGIELKDLHGE_GetEvolveId();
						isKira = scene.MBMFJILMOBP();
						if (!m_isSelectedCenterDiva)
						{
							isCompatible = false;
							if (scene.DCLLIDMKNGO(f.AHHJLDLAPAN_DivaId))
							{
								isCompatible = false;
								if (scene.FILPDDHMKEJ(false, 0, 0) > 0)
								{
									isActivate = SetDeckSkillIconControl.CheckMatchLiveSkill(scene, f.AHHJLDLAPAN_DivaId, m_musicData != null ? m_musicData.DLAEJOBELBH_MusicId : 0);
									isCompatible = true;
								}
							}
						}
						else
						{
							isCompatible = scene.HGONFBDIBPM_ActiveSkillId > 0;
							isActivate = SetDeckSkillIconControl.CheckMatchActiveSkill(scene);
						}
					}
					data.SetMainSceneIcon(sceneId, rank, isCompatible, isKira, m_isSelectedCenterDiva ? SceneIconScrollContent.SkillIconType.Active : SceneIconScrollContent.SkillIconType.Live, isActivate);
				}
				else
				{
					int sceneId = f.DJICAKGOGFO_SubSceneIds[i - 1];
					bool isActivate = true;
					bool isKira = false;
					bool isCompatible = false;
					int rank = 0;
					if (sceneId > 0)
					{
						GCIJNCFDNON scene = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[sceneId - 1];
						sceneId = scene.BCCHOBPJJKE_SceneId;
						rank = scene.CGIELKDLHGE_GetEvolveId();
						isActivate = false;
						if(scene.DCLLIDMKNGO(f.AHHJLDLAPAN_DivaId))
						{
							isActivate = false;
							if (scene.FILPDDHMKEJ(false, 0, 0) > 0)
							{
								isActivate = true;
							}
						}
						isCompatible = false;
						isKira = scene.MBMFJILMOBP();
						if (isActivate)
						{
							isActivate = SetDeckSkillIconControl.CheckMatchLiveSkill(scene, f.AHHJLDLAPAN_DivaId, m_musicData != null ? m_musicData.DLAEJOBELBH_MusicId : 0);
							isCompatible = true;
						}
						else
						{
							isActivate = true;
						}
					}
					data.SetSubSceneIcon(i - 1, sceneId, rank, isCompatible, isKira, isActivate);
				}
			}
			data.UpdateDocoration(f, GameManager.Instance.ViewPlayerData, m_displayType);
			data.OnPushEvent.RemoveAllListeners();
			data.OnPushEvent.AddListener(() =>
			{
				//0x17ECA34
				OnSelectDiva(index);
			});
			data.OnStayEvent.RemoveAllListeners();
			data.OnStayEvent.AddListener(() =>
			{
				//0x17ECA64
				OnShowDivaStatus(index);
			});
		}

		//// RVA: 0x17EBA50 Offset: 0x17EBA50 VA: 0x17EBA50
		public void UpdateDecoration(FFHPBEPOMAK selectDiva, List<int> sortIndexList, DisplayType type)
		{
			m_displayType = type;
			m_scrollList.VisibleRegionUpdate();
			if(selectDiva != null)
			{
				m_divaIconDecoration.Change(selectDiva, GameManager.Instance.ViewPlayerData, type);
				for(int i = 0; i < m_sceneIconDecraitons.Length; i++)
				{
					if(i == 0)
					{
						if(selectDiva.FGFIBOBAPIA_SceneId > 0)
						{
							GCIJNCFDNON scene = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[selectDiva.FGFIBOBAPIA_SceneId - 1];
							if(scene != null)
							{
								m_sceneIconDecraitons[i].Change(scene, type);
							}
						}
					}
					else
					{
						if(selectDiva.DJICAKGOGFO_SubSceneIds[i - 1] > 0)
						{
							GCIJNCFDNON scene = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[selectDiva.DJICAKGOGFO_SubSceneIds[i - 1] - 1];
							if(scene != null)
							{
								m_sceneIconDecraitons[i].Change(scene, type);
							}
						}
					}
				}
			}
		}

		//// RVA: 0x17EAADC Offset: 0x17EAADC VA: 0x17EAADC
		private bool IsUnitMember(JLKEOGLJNOD unitData, int divaId)
		{
			for (int i = 0; i < unitData.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				if (unitData.BCJEAJPLGMB_MainDivas[i] != null)
				{
					if (unitData.BCJEAJPLGMB_MainDivas[i].AHHJLDLAPAN_DivaId == divaId)
						return true;
				}
			}
			for(int i = 0; i < unitData.CMOPCCAJAAO_AddDivas.Count; i++)
			{
				if (unitData.CMOPCCAJAAO_AddDivas[i] != null)
				{
					if (unitData.CMOPCCAJAAO_AddDivas[i].AHHJLDLAPAN_DivaId == divaId)
						return true;
				}
			}
			return false;
		}

		//// RVA: 0x17EA958 Offset: 0x17EA958 VA: 0x17EA958
		private bool IsCenter(JLKEOGLJNOD unitData, int divaId)
		{
			for(int i = 0; i < unitData.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				if(unitData.BCJEAJPLGMB_MainDivas[i] != null)
				{
					return i == 0 && unitData.BCJEAJPLGMB_MainDivas[i].AHHJLDLAPAN_DivaId == divaId;
				}
			}
			return false;
		}

		//// RVA: 0x17EBD34 Offset: 0x17EBD34 VA: 0x17EBD34
		private void OnRemoveButton()
		{
			TodoLogger.LogNotImplemented("OnRemoveButton");
		}

		//// RVA: 0x17EBD60 Offset: 0x17EBD60 VA: 0x17EBD60
		private void OnSelectDiva(int listIndex)
		{
			m_onSelectDivaEvent.Invoke(listIndex);
		}

		//// RVA: 0x17EBDE0 Offset: 0x17EBDE0 VA: 0x17EBDE0
		private void OnShowDivaStatus(int listIndex)
		{
			m_onShowDivaStatusEvent.Invoke(listIndex);
		}

		//// RVA: 0x17EBE60 Offset: 0x17EBE60 VA: 0x17EBE60
		private void OnShowSelectedDivaStatus()
		{
			m_onShowDivaStatusEvent.Invoke(-1);
		}

		//// RVA: 0x17EBEDC Offset: 0x17EBEDC VA: 0x17EBEDC
		//private void OnShowSelectedDivaSelectScene(int slot) { }

		//// RVA: 0x17EBF5C Offset: 0x17EBF5C VA: 0x17EBF5C
		public void Wait()
		{
			m_animationLayout.StartChildrenAnimGoStop("st_wait", "st_wait");
		}

		//// RVA: 0x17EBFDC Offset: 0x17EBFDC VA: 0x17EBFDC
		public void Show()
		{
			m_animationLayout.StartChildrenAnimGoStop("st_wait", "st_in");
		}

		//// RVA: 0x17EC068 Offset: 0x17EC068 VA: 0x17EC068
		public void Hide()
		{
			m_animationLayout.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x17EC0F4 Offset: 0x17EC0F4 VA: 0x17EC0F4
		public bool IsPlaying()
		{
			return m_animationLayout.IsPlaying();
		}

		//// RVA: 0x17E8CEC Offset: 0x17E8CEC VA: 0x17E8CEC
		protected void UpdateCompatibleAnime(float dt)
		{
			if (m_compatibleAnimeLayout != null)
			{
				int val = m_comAnimeParam.UpdateFrame(dt);
				for(int i = 0; i < m_compatibleAnimeLayout.Length; i++)
				{
					if((m_compatibleFlags & (1 << i)) != 0)
					{
						m_compatibleAnimeLayout[i].StartChildrenAnimGoStop(val, val);
					}
				}
			}
		}

		//// RVA: 0x17E9C50 Offset: 0x17E9C50 VA: 0x17E9C50
		private void SetSkillTypeIcon(SceneIconScrollContent.SkillIconType type, int index)
		{
			m_skillIconImages[index].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(type == SceneIconScrollContent.SkillIconType.Active ? "sel_card_icon_skill_01" : "sel_card_icon_skill_02"));
			m_skillIconImages[index + 1].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(type == SceneIconScrollContent.SkillIconType.Active ? "sel_card_icon_skill_01" : "sel_card_icon_skill_02"));
		}

		//// RVA: 0x17EC120 Offset: 0x17EC120 VA: 0x17EC120
		public StayButton GetNavigationDivaListButton()
		{
			TodoLogger.Log(0, "GetNavigationDivaListButton");
			return null;
		}
	}
}
