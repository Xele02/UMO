using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using mcrs;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class ValkyrieSelectScene : TransitionRoot
	{
		private static readonly SeriesAttr.Type[] s_SeriesButtonIndex = new SeriesAttr.Type[5] {
			SeriesAttr.Type.First,
			SeriesAttr.Type.Seven,
			SeriesAttr.Type.Frontia,
			SeriesAttr.Type.Delta,
			SeriesAttr.Type.Plus
		}; // 0x0
		private static readonly float DISP_NOTICE_TIME = 1; // 0x4
		private AbsoluteLayout m_ViewBtnAnim; // 0x48
		private DFKGGBMFFGB m_PlayerData; // 0x4C
		private JLKEOGLJNOD m_UnitData; // 0x50
		private List<PNGOLKLFFLH> m_ValkyrieList; // 0x54
		private List<PNGOLKLFFLH>[] m_SeriesValkyrieList = new List<PNGOLKLFFLH>[5]; // 0x58
		private List<PIGBBNDPPJC> m_EpisodeList; // 0x5C
		private Action m_Updater; // 0x60
		private bool m_IsInitialized; // 0x64
		private bool m_IsReset = true; // 0x65
		private bool m_IsPlayEpAnim; // 0x66
		private bool m_IsDispEpPop; // 0x67
		private bool m_IsDispViewBtn; // 0x68
		private bool m_is_ValkrieTouch; // 0x69
		private int m_DisableViewButtonCount; // 0x6C
		private ActionButton m_ViewButton; // 0x70
		private ReplaceValkyriePopupSetting m_PopupSetting; // 0x74
		private GameObject m_viewValkyrieModeObj; // 0x78
		private bool m_viewSceneFlag; // 0x7C
		private SwaipTouch m_SwaipTouch; // 0x80
		private GameObject m_EffectPrefab; // 0x84
		private GameObject m_EffectInstance; // 0x88
		private bool m_IsLoadEffect; // 0x8C
		private bool m_IsLoadLayout; // 0x8D
		private bool m_IsDispNotice; // 0x8E
		private bool m_IsSceneActivate; // 0x8F
		private LayoutSeriesTab m_SeriesTab; // 0x90
		private LayoutValkyrieSelect m_layoutValSelect; // 0x94
		private LayoutBackGroundCircle m_circle; // 0x98
		private LayoutEpisodePopup m_episodePop; // 0x9C
		public int SelectSeries = 1; // 0xA0
		public int Select; // 0xA4
		private bool m_isGoDiva; // 0xA8

		// RVA: 0x1659744 Offset: 0x1659744 VA: 0x1659744 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_Updater = UpdateInit;
			for(int i = 0; i < m_SeriesValkyrieList.Length; i++)
			{
				m_SeriesValkyrieList[i] = new List<PNGOLKLFFLH>();
			}
			m_PopupSetting = new ReplaceValkyriePopupSetting();
			m_PopupSetting.WindowSize = SizeType.Large;
			m_PopupSetting.TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_valkyrie_select_title");
			m_PopupSetting.SetParent(transform);
			StartCoroutine(Co_LoadEffect());
			StartCoroutine(Co_LayoutAssetLoad());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x733A3C Offset: 0x733A3C VA: 0x733A3C
		// // RVA: 0x16599D4 Offset: 0x16599D4 VA: 0x16599D4
		private IEnumerator Co_LoadEffect()
		{
			string bundleName; // 0x14
			string assetName; // 0x18
			AssetBundleLoadAllAssetOperationBase operation; // 0x1C

			//0x1661CEC
			bundleName = "ef/cmn.xab";
			assetName = "model_loading";
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName);
			yield return operation;

			m_EffectPrefab = operation.GetAsset<GameObject>(assetName);
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			m_IsLoadEffect = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x733AB4 Offset: 0x733AB4 VA: 0x733AB4
		// // RVA: 0x1659A60 Offset: 0x1659A60 VA: 0x1659A60
		private IEnumerator Co_LayoutAssetLoad()
		{
			string bundleName; // 0x14
			Font systemFont; // 0x18

			//0x166095C
			m_IsLoadLayout = false;
			bundleName = "ly/045.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co_LoadAssetsLayoutValkyrieSelect(bundleName, systemFont);
			yield return Co_LoadAssetsLayoutSeriesButton(bundleName, systemFont);
			yield return Co_LoadAssetsLayoutCircle(bundleName, systemFont);
			yield return Co_LoadAssetsViewButton(bundleName, systemFont);
			yield return Co_LoadAssetsPopUp(bundleName, systemFont);
			AssetBundleManager.UnloadAssetBundle(bundleName, false);

			while(m_layoutValSelect == null)
				yield return null;
			while(m_SeriesTab == null)
				yield return null;
			while(m_circle == null)
				yield return null;
			while(m_ViewBtnAnim == null)
				yield return null;
			while(m_episodePop == null)
				yield return null;
			
			m_IsLoadLayout = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x733B2C Offset: 0x733B2C VA: 0x733B2C
		// // RVA: 0x1659B2C Offset: 0x1659B2C VA: 0x1659B2C
		private IEnumerator Co_LoadAssetsLayoutValkyrieSelect(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation; // 0x1C

			//0x16614B0
			if(m_layoutValSelect == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_valkyrie01_layout_root");
				yield return operation;
				yield return operation.InitializeLayoutCoroutine(font, (GameObject instance) => {
					//0x165F544
					instance.transform.SetParent(transform, false);
					m_layoutValSelect = instance.GetComponent<LayoutValkyrieSelect>();
				});

				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_layoutValSelect.transform.SetParent(transform, false);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x733BA4 Offset: 0x733BA4 VA: 0x733BA4
		// // RVA: 0x1659C0C Offset: 0x1659C0C VA: 0x1659C0C
		private IEnumerator Co_LoadAssetsLayoutSeriesButton(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x166119C
			if(m_SeriesTab == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_val_btn_layout_root");
				yield return operation;
				yield return operation.InitializeLayoutCoroutine(font, (GameObject instance) => {
					//0x165F614
					instance.transform.SetParent(transform, false);
					m_SeriesTab = instance.GetComponent<LayoutSeriesTab>();
				});
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_SeriesTab.transform.SetParent(transform, false);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x733C1C Offset: 0x733C1C VA: 0x733C1C
		// // RVA: 0x1659CEC Offset: 0x1659CEC VA: 0x1659CEC
		private IEnumerator Co_LoadAssetsLayoutCircle(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x1660EE8
			if(m_circle == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_val_circle_layout_root");
				yield return operation;
				yield return operation.InitializeLayoutCoroutine(font, (GameObject instance) => {
					//0x165F6E4
					m_circle = instance.GetComponent<LayoutBackGroundCircle>();
				});
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x733C94 Offset: 0x733C94 VA: 0x733C94
		// // RVA: 0x1659DCC Offset: 0x1659DCC VA: 0x1659DCC
		private IEnumerator Co_LoadAssetsViewButton(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x1661A78
			if(m_ViewBtnAnim == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_val_btn_view_layout_root");
				yield return operation;
				yield return operation.InitializeLayoutCoroutine(font, (GameObject instance) => {
					//0x165F760
					instance.transform.SetParent(transform, false);
					LayoutUGUIRuntime runtime = instance.GetComponent<LayoutUGUIRuntime>();
					m_ViewBtnAnim = runtime.Layout.FindViewByExId("root_sel_val_btn_view_sw_sel_val_btn_02") as AbsoluteLayout;
					ActionButton[] btns = instance.GetComponentsInChildren<ActionButton>(true);
					m_ViewButton = btns.Where((ActionButton _) => {
						//0x165FCB4
						return _.name == "sw_sel_val_view_btn_anim (AbsoluteLayout)";
					}).First();
					m_ViewButton.AddOnClickCallback(OnClickViewButton);
				});
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x733D0C Offset: 0x733D0C VA: 0x733D0C
		// // RVA: 0x1659EAC Offset: 0x1659EAC VA: 0x1659EAC
		private IEnumerator Co_LoadAssetsPopUp(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x16617C4
			if(m_episodePop == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_val_terms_window_all_layout_root");
				yield return operation;
				yield return operation.InitializeLayoutCoroutine(font, (GameObject instance) => {
					//0x165FA64
					instance.transform.SetParent(transform, false);
					m_episodePop = instance.GetComponent<LayoutEpisodePopup>();
				});
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
		}

		// // RVA: 0x1659F8C Offset: 0x1659F8C VA: 0x1659F8C
		private void ShowViewButton()
		{
			if(m_IsDispViewBtn)
				return;
			m_ViewBtnAnim.StartChildrenAnimGoStop("go_in", "st_in");
			m_IsDispViewBtn = true;
		}

		// // RVA: 0x165A02C Offset: 0x165A02C VA: 0x165A02C
		private void HideViewButton()
		{
			if(!m_IsDispViewBtn)
				return;
			m_ViewBtnAnim.StartChildrenAnimGoStop("go_out", "st_out");
			m_IsDispViewBtn = false;
		}

		// // RVA: 0x165A0CC Offset: 0x165A0CC VA: 0x165A0CC
		// public void ShowLoadingEffect() { }

		// // RVA: 0x165A22C Offset: 0x165A22C VA: 0x165A22C
		// public void HideLoadingEffect() { }

		// [IteratorStateMachineAttribute] // RVA: 0x733D84 Offset: 0x733D84 VA: 0x733D84
		// // RVA: 0x165A3CC Offset: 0x165A3CC VA: 0x165A3CC
		private IEnumerator Co_PlayNoticeAnim()
		{
			//0x1661F2C
			m_layoutValSelect.NoticeAnimEnter();
			m_IsDispNotice = true;
			yield return null;
			yield return new WaitWhile(() => {
				//0x165FB34
				return m_layoutValSelect.NoticeAnimIsPlaying();
			});
			while(!m_IsSceneActivate)
				yield return null;
			if(!m_IsDispNotice)
				yield break;
			float wait_time = DISP_NOTICE_TIME;
			yield return new WaitWhile(() => {
				//0x165FD44
				wait_time -= Time.deltaTime;
				return wait_time >= 0;
			});
			m_layoutValSelect.NoticeAnimLeave();
			m_IsDispNotice = false;
		}

		// RVA: 0x165A478 Offset: 0x165A478 VA: 0x165A478
		public void Update()
		{
			m_Updater();
		}

		// // RVA: 0x165A4A4 Offset: 0x165A4A4 VA: 0x165A4A4
		// private int ConvertSeriesAttrIndex(SeriesAttr.Type type) { }

		// // RVA: 0x165A5EC Offset: 0x165A5EC VA: 0x165A5EC
		private void ResetValkyrieData()
		{
			m_ValkyrieList = PNGOLKLFFLH.FKDIMODKKJD();
			PNGOLKLFFLH valk = m_UnitData.JOKFNBLEILN_Valkyrie;
			if(valk == null)
			{
				if(m_ValkyrieList.Count > 0)
				{
					m_UnitData.LDPCJAKOKHB(m_ValkyrieList[0].GPPEFLKGGGJ_ValkyrieId, -1);
				}
			}
			for(int i = 0; i < m_SeriesValkyrieList.Length; i++)
			{
				m_SeriesValkyrieList[i].Clear();
			}
			for(int i = 0; i < m_ValkyrieList.Count; i++)
			{
				m_SeriesValkyrieList[m_ValkyrieList[i].AIHCEGFANAM_Serie - 1].Add(m_ValkyrieList[i]);
			}
			int id = m_UnitData.JOKFNBLEILN_Valkyrie.GPPEFLKGGGJ_ValkyrieId;
			SelectSeries = m_ValkyrieList.Find((PNGOLKLFFLH _) =>
			{
				//0x165FD88
				return _.GPPEFLKGGGJ_ValkyrieId == id;
			}).AIHCEGFANAM_Serie - 1;
			Select = m_SeriesValkyrieList[SelectSeries].FindIndex((PNGOLKLFFLH _) =>
			{
				//0x165FDC0
				return _.GPPEFLKGGGJ_ValkyrieId == id;
			});
		}

		// // RVA: 0x165AA98 Offset: 0x165AA98 VA: 0x165AA98
		private void ResetSeriesButtonState()
		{
			for(int i = 0; i < 5; i++)
			{
				m_SeriesTab.ButtonDisable(i, m_SeriesValkyrieList[i].Count == 0);
			}
		}

		// // RVA: 0x165AB88 Offset: 0x165AB88 VA: 0x165AB88
		private void UpdateInit()
		{
			if(m_IsLoadEffect && m_IsLoadLayout)
			{
				if(m_EffectInstance == null)
				{
					m_EffectInstance = Instantiate(m_EffectPrefab, new Vector3(0, 0.1f, 0), transform.rotation);
				}
				m_EffectInstance.SetActive(false);
				m_SeriesTab.SetSeriesIcon();
				m_SeriesTab.SetSeriesButtonCallBack((SeriesAttr.Type type) => {
					//0x165FB60
					OnClickSeriesButton(type);
				});
				m_episodePop.SetEpisodeButtonCallback(OnClickEpisodeButton);
				m_layoutValSelect.SetTransformTouchAreaCallback(OnClickTransformation);
				m_layoutValSelect.SetButtonCallBack(() => {
					//0x165FB64
					OnClickArrowButtonL();
				}, () => {
					//0x165FB68
					OnClickArrowButtonR();
				}, () => {
					//0x165FB6C
					OnClickSelectButton();
				}, null);
				m_layoutValSelect.SetSelectBtnCoverLayoutDisable(true);
				m_SwaipTouch = GetComponentInChildren<SwaipTouch>();
				m_layoutValSelect.SelectButtonChangeUV(m_transitionName);
				IsReady = true;
				m_Updater = UpdateIdle;
			}
		}

		// // RVA: 0x165B004 Offset: 0x165B004 VA: 0x165B004
		private void ApplyAbility()
		{
			PNGOLKLFFLH valk = m_SeriesValkyrieList[SelectSeries][Select];
			ALEKLHIANJN data = new ALEKLHIANJN(valk.GPPEFLKGGGJ_ValkyrieId, valk.CNLIAMIIJID_AbilityLevel);
			m_layoutValSelect.HasAbility = valk.CNLIAMIIJID_AbilityLevel > 0;
			m_layoutValSelect.SetAbility(data.OPFGFINHFCE_SkillName, data.CHHADJECKNL_GetLevel(), data.DMBDNIEEMCB_GetDesc(false));
		}

		// // RVA: 0x165B274 Offset: 0x165B274 VA: 0x165B274
		private EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition GetAbilityCondition()
		{
			if(ParentTransition == TransitionList.Type.TEAM_SELECT)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null &&
					Database.Instance.gameSetup.musicInfo != null)
				{
					int serie = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(Database.Instance.gameSetup.musicInfo.musicId).AIHCEGFANAM_SerieId;
					if (serie >= 1 && serie <= 4)
						return 0;
					return (EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition)serie;
				}
			}
			return EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition.HJNNKCMLGFL/*0*/;
		}

		// // RVA: 0x165B3F8 Offset: 0x165B3F8 VA: 0x165B3F8
		private void ApplySelectValkyrie()
		{
			PNGOLKLFFLH valk = m_SeriesValkyrieList[SelectSeries][Select];
			NHDJHOPLMDE data = new NHDJHOPLMDE(valk.GPPEFLKGGGJ_ValkyrieId, 0);
			m_layoutValSelect.SetAtkArrowEnable(false);
			m_layoutValSelect.SetHitArrowEnable(false);
			string atkText = valk.KINFGHHNFCF_Atk.ToString();
			string hitText = valk.NONBCCLGBAO_Hit.ToString();
			if (data.LAKLFHGMCLI(EPIFHEDDJAE.NGEDJNHECKN.MGJDKBFHDML/*1*/, GetAbilityCondition()))
			{
				if(data.KINFGHHNFCF_Atk > 0)
				{
					atkText = "<color=#008200>" + (data.KINFGHHNFCF_Atk + valk.KINFGHHNFCF_Atk) + "</color>";
					m_layoutValSelect.SetAtkArrowEnable(true);
				}
				if(data.NONBCCLGBAO_Hit > 0)
				{
					hitText = "<color=#008200>" + (data.NONBCCLGBAO_Hit + valk.NONBCCLGBAO_Hit) + "</color>";
					m_layoutValSelect.SetHitArrowEnable(true);
				}
			}
			m_layoutValSelect.SetName(valk.IJBLEJOKEFH_ValkyrieName, valk.OPBPKNHIPPE_Pilot.OPFGFINHFCE_Name, atkText, hitText);
			ApplyAbility();
			m_layoutValSelect.SetPilotTexture(valk.OPBPKNHIPPE_Pilot.PFGJJLGLPAC_PilotId);
			m_layoutValSelect.SetIconState(valk.GPPEFLKGGGJ_ValkyrieId == m_UnitData.JOKFNBLEILN_Valkyrie.GPPEFLKGGGJ_ValkyrieId ? "01" : "02");
			m_SwaipTouch.enabled = m_layoutValSelect.SubValkyrieEnable(m_SeriesValkyrieList[SelectSeries].Count);
			if (!valk.FJODMPGPDDD_Unlocked)
			{
				if (m_viewValkyrieModeObj != null)
				{
					ViewScreenValkyrie v = m_viewValkyrieModeObj.GetComponent<ViewScreenValkyrie>();
					if (v != null)
						v.Hide();
				}
				m_layoutValSelect.SetSelectBtnDisable(true);
				HideViewButton();
				m_IsPlayEpAnim = true;
			}
			else
			{

				if (m_viewValkyrieModeObj != null)
				{
					ViewScreenValkyrie v = m_viewValkyrieModeObj.GetComponent<ViewScreenValkyrie>();
					if (v != null)
					{
						v.Show();
						if(v.GetValkyrieId() == valk.GPPEFLKGGGJ_ValkyrieId)
						{
							if(!m_viewSceneFlag)
								v.ChangeFormType(valk.GCCNMFHELCB_Form, false);
							else
							{
								valk.GCCNMFHELCB_Form = v.GetFormType();
								v.ChangeValkyrie(valk.GCCNMFHELCB_Form, valk.GCCNMFHELCB_Form);
							}
						}
						else
						{
							v.ChangeValkyrie(valk.GPPEFLKGGGJ_ValkyrieId, valk.GCCNMFHELCB_Form);
						}
						if (!v.IsChangeValkyrie())
							ShowViewButton();
					}
				}
				m_layoutValSelect.SetSelectBtnDisable(false);
				m_IsPlayEpAnim = false;
			}
		}
	
		// // RVA: 0x165BF3C Offset: 0x165BF3C VA: 0x165BF3C
		private void ReplaceValkyrie()
		{
			m_UnitData.LDPCJAKOKHB(m_SeriesValkyrieList[SelectSeries][Select].GPPEFLKGGGJ_ValkyrieId, m_SeriesValkyrieList[SelectSeries][Select].GCCNMFHELCB_Form);
		}

		// // RVA: 0x165C07C Offset: 0x165C07C VA: 0x165C07C
		// private bool IsPlayingAll() { }

		// [IteratorStateMachineAttribute] // RVA: 0x733DFC Offset: 0x733DFC VA: 0x733DFC
		// // RVA: 0x165C130 Offset: 0x165C130 VA: 0x165C130
		private IEnumerator Co_Initialize()
		{
			//0x1660220
			m_IsInitialized = false;
			if(m_IsReset)
				ResetValkyrieData();
			int loading_count = 0;
			for(int i = 0; i < m_ValkyrieList.Count; i++)
			{
				loading_count++;
				MenuScene.Instance.ValkyrieIconCache.Load(ValkyrieIconTextureCache.MakePortraitIconBundleName(m_ValkyrieList[i].GPPEFLKGGGJ_ValkyrieId, 0), (IiconTexture texture) => {
					//0x165FE00
					loading_count--;
				});
				loading_count++;
				GameManager.Instance.PilotTextureCache.Load(m_ValkyrieList[i].OPBPKNHIPPE_Pilot.PFGJJLGLPAC_PilotId, (IiconTexture texture) => {
					//0x165FE10
					loading_count--;
				});
			}
			yield return new WaitWhile(() => {
			//0x165FE20
				return loading_count > 0;
			});

			m_EpisodeList = PIGBBNDPPJC.FKDIMODKKJD_GetAvaiableEpisodes(true);
			ResetSeriesButtonState();
			m_SeriesTab.ChangeSelectSeries(SelectSeries + 1, ref SelectSeries, ref Select);
			m_SeriesTab.ApplySelectSeriesButton(SelectSeries);
			m_layoutValSelect.ValkyrieImageDefault();
			m_layoutValSelect.SetDetachBtnHidden(true);
			ApplySelectValkyrie();
			m_layoutValSelect.ApplySelectValkyrieImage(m_SeriesValkyrieList[SelectSeries], Select);
			m_layoutValSelect.SetDefaultText(MessageManager.Instance.GetBank("menu").GetMessageByLabel("valkyrie_tuneup_skill_not"));
			m_IsInitialized = true;
			m_IsReset = true;
			SetActiveSwaipTouch(false);
		}

		// RVA: 0x165C1DC Offset: 0x165C1DC VA: 0x165C1DC Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			m_isGoDiva = (Args as ValkyrieDataArgs).isGoDiva;
			m_UnitData = GameManager.Instance.ViewPlayerData.DPLBHAIKPGL(m_isGoDiva);
			MenuScene.Instance.BgControl.SetPriority(BgPriority.TopMost);
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.PNNHEOOJBFI_TutorialGeneralFlags.EDEDFDDIOKO(2);
			m_IsSceneActivate = false;
			StartCoroutine(Co_Initialize());
		}

		// RVA: 0x165C43C Offset: 0x165C43C VA: 0x165C43C Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			if(base.IsEndPreSetCanvas())
				return m_IsInitialized;
			return false;
		}

		// RVA: 0x165C460 Offset: 0x165C460 VA: 0x165C460 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_circle.transform.SetParent(MenuScene.Instance.m_bgRootObject.transform, false);
			m_circle.Enter();
			m_SeriesTab.Enter();
			m_layoutValSelect.Enter();
			if(m_viewSceneFlag)
			{
				ShowViewButton();
			}
			StartCoroutine(Co_PlayNoticeAnim());
			if(m_viewValkyrieModeObj == null)
			{
				m_viewValkyrieModeObj = ViewScreenValkyrie.Create(m_SeriesValkyrieList[SelectSeries][Select].GPPEFLKGGGJ_ValkyrieId, m_SeriesValkyrieList[SelectSeries][Select].GCCNMFHELCB_Form, () => {
					//0x165FB70
					if(m_EffectInstance != null)
					{
						m_EffectInstance.SetActive(true);
						m_layoutValSelect.SetActiveTransform(m_EffectInstance.activeSelf, false);
						HideViewButton();
						MenuScene.Instance.InputDisable();
					}
				}, () => {
					//0x165FB74
					if(m_EffectInstance != null)
					{
						m_EffectInstance.SetActive(false);
						m_layoutValSelect.SetActiveTransform(m_EffectInstance.activeSelf,true);
						ShowViewButton();
						MenuScene.Instance.InputEnable();
						m_SwaipTouch.ResetValue();
						m_SwaipTouch.ResetInputState();
					}
				}, true);
			}
			m_is_ValkrieTouch = true;
			m_viewSceneFlag = false;
		}

		// RVA: 0x165C7CC Offset: 0x165C7CC VA: 0x165C7CC Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_SeriesTab.IsPlaying() && !m_layoutValSelect.IsPlaying() && !m_circle.IsPlaying() && !m_ViewBtnAnim.IsPlayingChildren();
		}

		// RVA: 0x165C7D0 Offset: 0x165C7D0 VA: 0x165C7D0 Slot: 23
		protected override void OnActivateScene()
		{
			m_IsSceneActivate = true;
			SetActiveSwaipTouch(true);
		}

		// RVA: 0x165C8C4 Offset: 0x165C8C4 VA: 0x165C8C4 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_circle.Leave();
			m_layoutValSelect.Leave();
			m_SeriesTab.Leave();
			HideViewButton();
			if(m_IsDispNotice)
			{
				m_layoutValSelect.NoticeAnimLeave();
				m_IsDispNotice = false;
			}
			if(m_IsDispEpPop)
			{
				m_episodePop.Leave();
				m_IsDispEpPop = false;
			}
			m_IsPlayEpAnim = false;
			m_EffectInstance.SetActive(false);
			if(!m_viewSceneFlag)
			{
				ViewScreenValkyrie.Destroy(m_viewValkyrieModeObj);
				return;
			}
			m_IsReset = false;
		}

		// RVA: 0x165CA5C Offset: 0x165CA5C VA: 0x165CA5C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_SeriesTab.IsPlaying() && !m_layoutValSelect.IsPlaying() && !m_circle.IsPlaying() && !m_ViewBtnAnim.IsPlayingChildren();
		}

		// RVA: 0x165CA60 Offset: 0x165CA60 VA: 0x165CA60 Slot: 21
		protected override void OnOpenScene()
		{
			m_circle.loop();
		}

		// RVA: 0x165CA8C Offset: 0x165CA8C VA: 0x165CA8C Slot: 14
		protected override void OnDestoryScene()
		{
			m_circle.transform.SetParent(transform, false);
			if(!m_viewSceneFlag)
			{
				MenuScene.Instance.BgControl.SetPriority(BgPriority.Bottom);
			}
		}

		// RVA: 0x165CBB4 Offset: 0x165CBB4 VA: 0x165CBB4 Slot: 15
		protected override void OnDeleteCache()
		{
			m_circle.transform.SetParent(transform, false);
			Destroy(m_EffectInstance);
		}

		// RVA: 0x165CC94 Offset: 0x165CC94 VA: 0x165CC94
		private void ChangeSelectValkyrie(LayoutValkyrieSelect.Direction dir)
		{
			if(m_SeriesValkyrieList[SelectSeries].Count < 2)
				return;
			m_SeriesValkyrieList[SelectSeries][Select].OELFCIKFMLL(0);
			if(dir == LayoutValkyrieSelect.Direction.RIGHT)
			{
				Select++;
				if(Select >= m_SeriesValkyrieList[SelectSeries].Count)
				{
					Select = Select - m_SeriesValkyrieList[SelectSeries].Count;
				}
			}
			else if(dir == LayoutValkyrieSelect.Direction.LEFT)
			{
				Select--;
				if(Select < 0)
				{
					Select += m_SeriesValkyrieList[SelectSeries].Count;
				}
			}
			ApplySelectValkyrie();
			m_Updater = UpdateChangeAnim_Start;
		}

		// // RVA: 0x165CEAC Offset: 0x165CEAC VA: 0x165CEAC
		private void UpdateIdle()
		{
			if(m_SwaipTouch != null)
			{
				if(m_SwaipTouch.IsStop())
					return;
				if(m_SwaipTouch.IsSwaip(SwaipTouch.Direction.RIGHT))
				{
					ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.LEFT);
				}
				if(m_SwaipTouch.IsSwaip(SwaipTouch.Direction.LEFT))
				{
					ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.RIGHT);
				}
				if(m_SwaipTouch.IsFlickNoSwaip(SwaipTouch.Direction.RIGHT))
				{
					ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.LEFT);
				}
				if(m_SwaipTouch.IsFlickNoSwaip(SwaipTouch.Direction.LEFT))
				{
					ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.RIGHT);
				}
			}
		}

		// // RVA: 0x165D04C Offset: 0x165D04C VA: 0x165D04C
		private void UpdateChangeAnim_Start()
		{
			MenuScene.Instance.InputDisable();
			m_layoutValSelect.SetActiveTransform(m_EffectInstance.activeSelf, false);
			m_layoutValSelect.FadeOutValkyrieImage(LayoutValkyrieSelect.Direction.LEFT);
			m_layoutValSelect.FadeOutValkyrieImage(LayoutValkyrieSelect.Direction.RIGHT);
			if(m_IsDispEpPop)
			{
				m_episodePop.Leave();
				m_IsDispEpPop = false;
			}
			m_Updater = UpdateChangeAnim_Wait;
		}

		// // RVA: 0x165D1F0 Offset: 0x165D1F0 VA: 0x165D1F0
		private void UpdateChangeAnim_Wait()
		{
			if(!m_layoutValSelect.ValkyrieImageIsPlaying())
			{
				if(m_episodePop.IsPlaying())
					return;
				m_layoutValSelect.ApplySelectValkyrieImage(m_SeriesValkyrieList[SelectSeries], Select);
                PIGBBNDPPJC epData = GetEpisodeData(m_SeriesValkyrieList[SelectSeries][Select].KELFCMEOPPM_EpisodeId);
                m_episodePop.SetEpisodeText(MessageManager.Instance.GetBank("menu").GetMessageByLabel("costume_select_text_01"), string.Format(MessageManager.Instance.GetBank("menu").GetMessageByLabel("costume_select_text_02"), epData != null ? epData.OPFGFINHFCE : ""));
				m_layoutValSelect.FadeInValkyrieImage(LayoutValkyrieSelect.Direction.LEFT);
				m_layoutValSelect.FadeInValkyrieImage(LayoutValkyrieSelect.Direction.RIGHT);
				m_episodePop.SetEpisodeValkyrieImage(m_SeriesValkyrieList[SelectSeries][Select].GPPEFLKGGGJ_ValkyrieId, 0);
				if(m_IsPlayEpAnim)
				{
					m_episodePop.Enter();
					m_IsDispEpPop = true;
				}
				m_Updater = UpdateChangeAnim_End;
			}
		}

		// // RVA: 0x165D6D4 Offset: 0x165D6D4 VA: 0x165D6D4
		private void UpdateChangeAnim_End()
		{
			if(!m_layoutValSelect.ValkyrieImageIsPlaying())
			{
				if(m_episodePop.IsPlaying())
					return;
				MenuScene.Instance.InputEnable();
				m_SwaipTouch.ResetValue();
				m_SwaipTouch.ResetInputState();
				m_layoutValSelect.SetActiveTransform(m_EffectInstance.activeSelf, true);
				m_Updater = UpdateIdle;
			}
		}

		// // RVA: 0x165D88C Offset: 0x165D88C VA: 0x165D88C
		private void OnClickArrowButtonL()
		{
			if(!m_SwaipTouch.IsMoveFlickDistance() && !m_viewSceneFlag)
			{
				if(InputManager.Instance.GetInScreenTouchCount() < 2)
				{
					if(!MenuScene.Instance.DirtyChangeScene)
					{
						if(IsLoadedValkyrie())
						{
							ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.LEFT);
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						}
					}
				}
			}
		}

		// // RVA: 0x165DB58 Offset: 0x165DB58 VA: 0x165DB58
		private void OnClickArrowButtonR()
		{
			if(!m_SwaipTouch.IsMoveFlickDistance() && !m_viewSceneFlag)
			{
				if(InputManager.Instance.GetInScreenTouchCount() < 2)
				{
					if(!MenuScene.Instance.DirtyChangeScene)
					{
						if(IsLoadedValkyrie())
						{
							ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.RIGHT);
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						}
					}
				}
			}
		}

		// // RVA: 0x165DCF8 Offset: 0x165DCF8 VA: 0x165DCF8
		private void OnClickSelectButton()
		{
			if(!m_SwaipTouch.IsMoveFlickDistance() && !m_viewSceneFlag)
			{
				if(InputManager.Instance.GetInScreenTouchCount() < 2)
				{
					if(!MenuScene.Instance.DirtyChangeScene && IsLoadedValkyrie())
					{
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						m_PopupSetting.Buttons = new ButtonInfo[2] {
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
						};
						m_PopupSetting.before_data = m_UnitData.JOKFNBLEILN_Valkyrie;
						m_PopupSetting.after_data = m_SeriesValkyrieList[SelectSeries][Select];
						NHDJHOPLMDE n = new NHDJHOPLMDE(m_PopupSetting.before_data.GPPEFLKGGGJ_ValkyrieId, 0);
						m_PopupSetting.before_data_ab = n.LAKLFHGMCLI(EPIFHEDDJAE.NGEDJNHECKN.MGJDKBFHDML, GetAbilityCondition()) ? n : null;
						n = new NHDJHOPLMDE(m_PopupSetting.after_data.GPPEFLKGGGJ_ValkyrieId, 0);
						m_PopupSetting.after_data_ab = n.LAKLFHGMCLI(EPIFHEDDJAE.NGEDJNHECKN.MGJDKBFHDML, GetAbilityCondition()) ? n : null;
						SoundManager.Instance.voPilot.RequestChangeCueSheet(m_PopupSetting.after_data.OPBPKNHIPPE_Pilot.PFGJJLGLPAC_PilotId, () => {
							//0x165FD34
							return;
						});
						PopupWindowManager.Show(m_PopupSetting, OnClickPopupButton, null, null, null);
					}
				}
			}
		}

		// // RVA: 0x165E470 Offset: 0x165E470 VA: 0x165E470
		private void OnClickPopupButton(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			if(label != PopupButton.ButtonLabel.Ok)
				return;
			m_is_ValkrieTouch = false;
			StartCoroutine(Co_DecideValkyrie());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x733E74 Offset: 0x733E74 VA: 0x733E74
		// // RVA: 0x165E4A8 Offset: 0x165E4A8 VA: 0x165E4A8
		private IEnumerator Co_DecideValkyrie()
		{
			//0x165FE38
			MenuScene.Instance.InputDisable();
			SoundManager.Instance.voPilot.Play(PilotVoicePlayer.VoiceCategory.Select, 0);
			JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = true;
			JDDGPJDKHNE.HHCJCDFCLOB.NFNLGGHMEAM();
			int oldValk = m_UnitData.JOKFNBLEILN_Valkyrie.GPPEFLKGGGJ_ValkyrieId;
			ReplaceValkyrie();
			int newValk = m_UnitData.JOKFNBLEILN_Valkyrie.GPPEFLKGGGJ_ValkyrieId;
			if(oldValk != newValk)
			{
				ILCCJNDFFOB.HHCJCDFCLOB.EEPIDKPPLJI(oldValk, newValk);
			}
			MenuScene.SaveRequest();
			m_viewSceneFlag = false;
			yield return new WaitForSeconds(0.5f);
			MenuScene.Instance.Return(true);
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x165E554 Offset: 0x165E554 VA: 0x165E554
		private void OnClickViewButton()
		{
			TodoLogger.LogNotImplemented("OnClickViewButton");
		}

		// // RVA: 0x165E788 Offset: 0x165E788 VA: 0x165E788
		private void OnClickSeriesButton(SeriesAttr.Type type)
		{
			if(InputManager.Instance.GetInScreenTouchCount() < 2)
			{
				if(!MenuScene.Instance.DirtyChangeScene)
				{
					if(IsLoadedValkyrie())
					{
						if(!m_SwaipTouch.IsMoveFlickDistance() && !m_viewSceneFlag)
						{
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
							m_SeriesTab.ChangeSelectSeries((int)type, ref SelectSeries, ref Select);
							ApplySelectValkyrie();
							m_SeriesTab.ApplySelectSeriesButton((int)type - 1);
							m_Updater = UpdateChangeAnim_Start;
						}
					}
				}
			}
		}

		// // RVA: 0x165E9C8 Offset: 0x165E9C8 VA: 0x165E9C8
		private void OnClickEpisodeButton()
		{
			TodoLogger.LogNotImplemented("OnClickEpisodeButton");
		}

		// // RVA: 0x165D5BC Offset: 0x165D5BC VA: 0x165D5BC
		private PIGBBNDPPJC GetEpisodeData(int id)
		{
			for(int i = 0; i < m_EpisodeList.Count; i++)
			{
				if(m_EpisodeList[i].KELFCMEOPPM_Id == id)
				{
					return m_EpisodeList[i];
				}
			}
			return null;
		}

		// // RVA: 0x165EFA4 Offset: 0x165EFA4 VA: 0x165EFA4
		private void OnClickTransformation()
		{
			if(m_viewValkyrieModeObj != null)
			{
				ViewScreenValkyrie v = m_viewValkyrieModeObj.GetComponent<ViewScreenValkyrie>();
				if(v != null)
				{
					if(v.IsShow() && m_is_ValkrieTouch)
					{
						if(!m_SwaipTouch.IsSwaiping())
						{
							if(!m_SwaipTouch.IsMoveFlickDistance() && !m_viewSceneFlag)
							{
								if(InputManager.Instance.GetInScreenTouchCount() < 2)
								{
									if(!MenuScene.Instance.DirtyChangeScene)
									{
										int nextForm = m_SeriesValkyrieList[SelectSeries][Select].GCCNMFHELCB_Form;
										nextForm++;
										if(nextForm > 2)
											nextForm -= 3;
										m_SeriesValkyrieList[SelectSeries][Select].OELFCIKFMLL(nextForm);
										v.ChangeFormType(nextForm, true);
										SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_VALKYRIE_000);
										m_layoutValSelect.SetActiveTransform(m_EffectInstance.activeSelf, false);
										m_SwaipTouch.Stop(true);
										StartCoroutine(v.Co_WaitEnableTransformation(() => {
											//0x165FB78
											m_SwaipTouch.ResetValue();
											m_SwaipTouch.ResetInputState();
											m_layoutValSelect.SetActiveTransform(m_EffectInstance.activeSelf, true);
											m_SwaipTouch.Stop(false);
										}));
									}
								}
							}
						}
					}
				}
			}
		}

		// // RVA: 0x165C7E0 Offset: 0x165C7E0 VA: 0x165C7E0
		private void SetActiveSwaipTouch(bool is_active)
		{
			m_SwaipTouch.enabled = m_SeriesValkyrieList[SelectSeries].Count < 2 ? false : is_active;
		}

		// // RVA: 0x165DA2C Offset: 0x165DA2C VA: 0x165DA2C
		private bool IsLoadedValkyrie()
		{
			if(m_viewValkyrieModeObj != null)
			{
				ViewScreenValkyrie v = m_viewValkyrieModeObj.GetComponent<ViewScreenValkyrie>();
				if(v != null)
				{
					return v.IsLoaded();
				}
			}
			return false;
		}
	}
}
