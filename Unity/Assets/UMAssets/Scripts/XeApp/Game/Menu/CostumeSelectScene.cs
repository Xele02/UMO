using CriWare;
using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class CostumeSelectScene : TransitionRoot
	{
		private Action mUpdater; // 0x48
		private CostumeSelectViewOn m_view_on; // 0x4C
		private int m_diva_id; // 0x50
		private int m_diva_index; // 0x54
		private CostumeSelectDivaResrouce divaResource; // 0x58
		private VoicePlayerBase voicePlayer; // 0x5C
		private CriAtomExPlayback voicePlayBack; // 0x60
		private int voiceQueCount; // 0x64
		private int voicePlayIndex; // 0x68
		private bool m_model_loaded; // 0x6C
		private GameObject m_viewObj; // 0x70
		private GameObject m_EffectPrefab; // 0x74
		private GameObject m_EffectInstance; // 0x78
		private bool m_is_view_mode; // 0x7C
		private bool isLoadedUnionResource; // 0x7D
		private Coroutine costumeChangeCoroutine; // 0x80
		private CostumeSelectListWin m_cos_list_win; // 0x84
		private List<PIGBBNDPPJC> m_episode_list; // 0x88
		private int m_costume_model_id = -1; // 0x8C
		private int m_costume_id = -1; // 0x90
		private int m_costume_color = -1; // 0x94
		private int m_next_costume_model_id = -1; // 0x98
		private int m_next_costume_color = -1; // 0x9C
		private bool m_pushedTrying; // 0xA0
		private bool m_resourceLoadRequest = true; // 0xA1
		private CostumeInfoPopupSetting m_costume_window = new CostumeInfoPopupSetting(); // 0xA4
		private StringBuilder m_builder = new StringBuilder(); // 0xA8
		private Coroutine divaWaitCoroutine; // 0xAC
		private WaitForSeconds divaWaitSecods = new WaitForSeconds(0.1f); // 0xB0
		private GameObject m_touch_disable_obj; // 0xB4
		private bool m_is_godiva; // 0xB8

		//// RVA: 0x16DE8C8 Offset: 0x16DE8C8 VA: 0x16DE8C8
		private bool IsParentCostumeUpgrade()
		{
			return ParentTransition == TransitionList.Type.COSTUME_UPGRADE || ParentTransition == TransitionList.Type.COSTUME_UPGRADE_ITEM_SELECT;
		}

		//// RVA: 0x16DE908 Offset: 0x16DE908 VA: 0x16DE908
		//private bool IsHiddenButtonCostumeButton() { }

		// RVA: 0x16DE90C Offset: 0x16DE90C VA: 0x16DE90C Slot: 4
		protected override void Awake()
		{
			base.Awake();
			voicePlayer = gameObject.AddComponent<VoicePlayerBase>();
			divaResource = gameObject.AddComponent<CostumeSelectDivaResrouce>();
			divaResource.setupFlags = DivaResource.SetupFlags.Manual;
		}

		// RVA: 0x16DE9F8 Offset: 0x16DE9F8 VA: 0x16DE9F8 Slot: 5
		protected override void Start()
		{
			this.StartCoroutineWatched(Co_LoadResources());
		}

		// RVA: 0x16DEAA8 Offset: 0x16DEAA8 VA: 0x16DEAA8
		private void Update()
		{
			if(mUpdater != null)
			{
				mUpdater();
			}
		}

		//// RVA: 0x16DEABC Offset: 0x16DEABC VA: 0x16DEABC
		private void UpdateIdle()
		{
			UpdateModel();
			if(m_EffectInstance != null)
			{
				if(m_model_loaded)
				{
					m_EffectInstance.SetActive(false);
				}
				else
				{
					m_EffectInstance.SetActive(true);
				}
			}
			if(m_viewObj == null)
			{
				if(!m_model_loaded)
				{
					if (!m_view_on.IsEntered())
						return;
					m_view_on.Leave();
					return;
				}
				if(!m_view_on.IsEntered())
				{
					m_view_on.Enter();
				}
			}
		}

		//// RVA: 0x16DEFAC Offset: 0x16DEFAC VA: 0x16DEFAC
		//private bool CanLoading() { }

		//// RVA: 0x16DEC74 Offset: 0x16DEC74 VA: 0x16DEC74
		private void UpdateModel()
		{
			if (!m_model_loaded)
				return;
			if(m_costume_model_id == m_next_costume_model_id && m_costume_color == m_next_costume_color)
				return;
			m_costume_model_id = m_next_costume_model_id;
			m_costume_color = m_next_costume_color;
			MenuScene.Instance.divaManager.SetActive(false);
			m_model_loaded = false;
			this.StartCoroutineWatched(CoroutineDivaModel(m_pushedTrying, false));
		}

		// RVA: 0x16DF084 Offset: 0x16DF084 VA: 0x16DF084 Slot: 16
		protected override void OnPreSetCanvas()
		{
			if(m_touch_disable_obj != null)
			{
				m_touch_disable_obj.SetActive(false);
			}
			MenuScene.Instance.BgControl.SetPriority(BgPriority.TopMost);
			base.OnPreSetCanvas();
			bool first_transition = false;
			if(Args is CostumeChangeDivaArgs)
			{
				first_transition = true;
				m_diva_id = (Args as CostumeChangeDivaArgs).DivaId;
				m_diva_index = m_diva_id - 1;
				m_is_godiva = (Args as CostumeChangeDivaArgs).is_godiva;
			}
			m_pushedTrying = false;
			m_cos_list_win.HiddenButtonCostumeUpgrade(IsParentCostumeUpgrade());
			if(!m_is_view_mode)
			{
				m_cos_list_win.CreateNewMark();
				m_cos_list_win.CreateItem(m_diva_id, first_transition, m_transitionName, false, m_is_godiva);
				for(int i = 0; i < m_cos_list_win.m_list_item.Count; i++)
				{
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(ItemTextureCache.MakeItemIconTexturePath(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume, m_cos_list_win.m_list_item[i].m_cos_id), m_cos_list_win.m_list_item[i].m_cos_color));
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(CostumeTextureCache.MakeCostumeTexturePath(m_diva_id, m_cos_list_win.m_list_item[i].m_view_diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, m_cos_list_win.m_list_item[i].m_cos_color));
				}
				m_episode_list = PIGBBNDPPJC.FKDIMODKKJD_GetAvaiableEpisodes(true);
				m_costume_model_id = -1;
				m_costume_color = -1;
				if(first_transition)
				{
					if(m_transitionName == TransitionList.Type.COSTUME_SELECT)
					{
						m_next_costume_model_id = m_cos_list_win.GetSelectItem().m_view_diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId;
						m_next_costume_color = m_cos_list_win.GetSelectItem().m_cos_color;
					}
				}
			}
			this.StartCoroutineWatched(Co_LoadDivaResource(m_diva_id));
		}

		// RVA: 0x16DF764 Offset: 0x16DF764 VA: 0x16DF764 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			if(!KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && isLoadedUnionResource)
			{
				m_EffectInstance = Instantiate(m_EffectPrefab, new Vector3(-5, 1, 0), m_EffectPrefab.transform.rotation);
				if(m_is_view_mode)
				{
					m_EffectInstance.SetActive(false);
				}
				m_cos_list_win.Enter();
				ViewScreenCostume.Leave(m_viewObj, () =>
				{
					//0x16E1B10
					m_viewObj = null;
				});
				m_is_view_mode = false;
				return true;
			}
			return false;
		}

		// RVA: 0x16DF9B4 Offset: 0x16DF9B4 VA: 0x16DF9B4 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			base.OnStartEnterAnimation();
			mUpdater = UpdateIdle;
		}

		// RVA: 0x16DFA48 Offset: 0x16DFA48 VA: 0x16DFA48 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return base.IsEndEnterAnimation();
		}

		// RVA: 0x16DFA50 Offset: 0x16DFA50 VA: 0x16DFA50 Slot: 22
		protected override bool IsEndOpenScene()
		{
			return !GameManager.Instance.CostumeIconCache.IsLoading() && !MenuScene.Instance.divaManager.IsLoading;
		}

		// RVA: 0x16DFB8C Offset: 0x16DFB8C VA: 0x16DFB8C Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			if(MenuScene.Instance.GetNextScene().name != TransitionList.Type.COSTUME_VIEW_MODE)
			{
				m_view_on.Leave();
				GameManager.Instance.SetFPS(30);
			}
			mUpdater = null;
		}

		// RVA: 0x16DFCD4 Offset: 0x16DFCD4 VA: 0x16DFCD4 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			if (!m_view_on.IsPlaying())
			{
				if (!m_model_loaded)
					return false;
				if (MenuScene.Instance.GetNextScene().name == TransitionList.Type.COSTUME_VIEW_MODE)
					m_is_view_mode = true;
				else
				{
					if (!m_model_loaded)
						return false;
					MenuScene.Instance.divaManager.Release(true);
				}
				Destroy(m_EffectInstance);
				return true;
			}
			return false;
		}

		// RVA: 0x16DFF3C Offset: 0x16DFF3C VA: 0x16DFF3C Slot: 14
		protected override void OnDestoryScene()
		{
			if (m_is_view_mode)
				return;
			GameManager.Instance.ResetViewPlayerData();
			m_cos_list_win.DestroyNewMark();
			MenuScene.Instance.BgControl.SetPriority(BgPriority.Bottom);
			if(voicePlayer != null)
			{
				voicePlayer.RemoveCueSheet();
			}
			MenuScene.Instance.divaManager.Release(true);
			divaResource.Release();
			voicePlayer.RemoveCueSheet();
			m_resourceLoadRequest = true;
			if(divaWaitCoroutine != null)
			{
				this.StopCoroutineWatched(divaWaitCoroutine);
				divaWaitCoroutine = null;
			}
			MenuScene.Instance.divaManager.SetAnimParamInteger("menu_simpleLoopStart_State", 0);
			GameManager.Instance.SetFPS(30);
		}

		// RVA: 0x16E02A8 Offset: 0x16E02A8 VA: 0x16E02A8 Slot: 15
		protected override void OnDeleteCache()
		{
			if(m_viewObj != null)
			{
				Destroy(m_viewObj);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CCDF4 Offset: 0x6CCDF4 VA: 0x6CCDF4
		//// RVA: 0x16DEA1C Offset: 0x16DEA1C VA: 0x16DEA1C
		private IEnumerator Co_LoadResources()
		{
			//0x16E3B38
			yield return Co.R(Co_LoadLayout());
			yield return Co.R(Co_LoadEffect());
			yield return Co.R(Co_LoadPopupWindow());
			if(m_touch_disable_obj == null)
			{
				m_touch_disable_obj = new GameObject("Panel");
				m_touch_disable_obj.transform.SetParent(gameObject.transform);
				m_touch_disable_obj.transform.SetAsLastSibling();
				Image im = m_touch_disable_obj.AddComponent<Image>();
				im.rectTransform.anchorMin = new Vector2(0, 0);
				im.rectTransform.anchorMax = new Vector2(1, 1);
				im.color = new Color(0, 0, 0, 0);
			}
			m_touch_disable_obj.SetActive(false);
			IsReady = true;
			m_model_loaded = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CCE6C Offset: 0x6CCE6C VA: 0x6CCE6C
		//// RVA: 0x16E0398 Offset: 0x16E0398 VA: 0x16E0398
		private IEnumerator Co_LoadLayout()
		{
			Font font; // 0x14
			string bundleName; // 0x18
			int bundleLoadCount; // 0x1C
			AssetBundleLoadLayoutOperationBase lytOp; // 0x20

			//0x16E30C0
			font = GameManager.Instance.GetSystemFont();
			bundleName = "ly/044.xab";
			bundleLoadCount = 0;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_cos_win_layout_root");
			yield return Co.R(lytOp);

			yield return Co.R(lytOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x16E1B1C
				instance.transform.SetParent(transform, false);
				m_cos_list_win = instance.GetComponent<CostumeSelectListWin>();
			}));
			bundleLoadCount++;
			yield return Co.R(m_cos_list_win.Co_LoadListContent());

			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName, "ViewModeViewOn");
			yield return Co.R(lytOp);

			yield return Co.R(lytOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x16E1BEC
				m_view_on = instance.GetComponent<CostumeSelectViewOn>();
				instance.transform.SetParent(transform, false);
			}));

			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName);
			}
			while (!m_cos_list_win.IsLoaded())
				yield return null;
			while (!m_view_on.IsLoaded())
				yield return null;
			m_view_on.GetButton().AddOnClickCallback(() =>
			{
				//0x16E1CC0
				OnClickViewOn();
			});
			m_cos_list_win.m_cb_try += CB_Try;
			m_cos_list_win.m_cb_getinfo += CB_GetInfo;
			m_cos_list_win.m_cb_cos_build += CB_CostumeBuild;
			m_cos_list_win.m_cb_cos_change += CB_CostumeChange;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CCEE4 Offset: 0x6CCEE4 VA: 0x6CCEE4
		//// RVA: 0x16E0444 Offset: 0x16E0444 VA: 0x16E0444
		private IEnumerator Co_LoadEffect()
		{
			string bundleName; // 0x14
			string assetName; // 0x18
			AssetBundleLoadAllAssetOperationBase operation; // 0x1C

			//0x16E2E88
			bundleName = "ef/cmn.xab";
			assetName = "model_loading";
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName);
			yield return Co.R(operation);

			m_EffectPrefab = operation.GetAsset<GameObject>(assetName);
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CCF5C Offset: 0x6CCF5C VA: 0x6CCF5C
		//// RVA: 0x16DF6BC Offset: 0x16DF6BC VA: 0x16DF6BC
		private IEnumerator Co_LoadDivaResource(int divaId)
		{
			//0x16E2994
			isLoadedUnionResource = false;
			if(divaResource.LoadedDivaId == divaId && !m_resourceLoadRequest)
			{
				isLoadedUnionResource = true;
				yield break;
			}
			divaResource.ReleaseAll();
			bool isWaitLoadCueSheet = true;
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("cs_coschange_{0:D3}", divaId);
			voicePlayer.RequestChangeCueSheet(str.ToString(), () =>
			{
				//0x16E1E10
				isWaitLoadCueSheet = false;
			});
			voicePlayIndex = 0;
			divaResource.Initialize(divaId);
			yield return Co.R(divaResource.Co_LoadBasicResource());
			yield return Co.R(divaResource.Co_LoadMotion());
			while (isWaitLoadCueSheet)
				yield return null;
			CriAtomCueSheet cueSheet = CriAtom.GetCueSheet(voicePlayer.source.cueSheet);
			if (cueSheet != null)
			{
				if(cueSheet.acb.GetCueInfoList() != null)
				{
					voiceQueCount = cueSheet.acb.GetCueInfoList().Length;
				}
			}
			m_resourceLoadRequest = false;
			isLoadedUnionResource = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CCFD4 Offset: 0x6CCFD4 VA: 0x6CCFD4
		//// RVA: 0x16E0510 Offset: 0x16E0510 VA: 0x16E0510
		private IEnumerator Co_LoadPopupWindow()
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x16E37AC
			operation = AssetBundleManager.LoadLayoutAsync(m_costume_window.BundleName, m_costume_window.AssetName);
			yield return Co.R(operation);

			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x16E1CC4
				m_costume_window.SetContent(instance);
				m_costume_window.costumeInfoWindow = instance.GetComponent<CostumeInfoWindow>();
			}));

			m_costume_window.SetParent(transform);
			AssetBundleManager.UnloadAssetBundle(m_costume_window.BundleName, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CD04C Offset: 0x6CD04C VA: 0x6CD04C
		//// RVA: 0x16E05BC Offset: 0x16E05BC VA: 0x16E05BC
		private IEnumerator Co_CostumeSaveAndSceneReturn()
		{
			//0x1641CB8
			bool isWait = true;
			MenuScene.Instance.InputDisable();
			MenuScene.Save(() =>
			{
				//0x16E1E24
				isWait = false;
			}, null);
			while (isWait)
				yield return null;
			MenuScene.Instance.Return(true);
			yield return null;
			MenuScene.Instance.InputEnable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CD0C4 Offset: 0x6CD0C4 VA: 0x6CD0C4
		//// RVA: 0x16E0650 Offset: 0x16E0650 VA: 0x16E0650
		//private IEnumerator Co_PopupGetInfo(int a_index) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CD13C Offset: 0x6CD13C VA: 0x6CD13C
		//// RVA: 0x16E0718 Offset: 0x16E0718 VA: 0x16E0718
		private IEnumerator Co_PopupCostumeBuildLock()
		{
			//0x16E3FCC
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			StringBuilder str = new StringBuilder();
			str.SetFormat(bk.GetMessageByLabel("costume_upgrade_lock_text"), MOEALEGLGCH.IGDOBKHKNJM_GetCostumeUpgradeOfferNum());
			TextPopupSetting s = new TextPopupSetting();
			s.IsCaption = false;
			s.Text = str.ToString();
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			bool t_end_popup = false;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x16E1E04
				return;
			}, null, null, null, true, true, false, null, () =>
			{
				//0x16E1E70
				t_end_popup = true;
			});
			while (!t_end_popup)
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CD1B4 Offset: 0x6CD1B4 VA: 0x6CD1B4
		//// RVA: 0x16DEFDC Offset: 0x16DEFDC VA: 0x16DEFDC
		private IEnumerator CoroutineDivaModel(bool isTrying, bool local = true)
		{
			int hash;

			//0x16E5738
			if(divaWaitCoroutine != null)
			{
				this.StopCoroutineWatched(divaWaitCoroutine);
				divaWaitCoroutine = null;
			}
			yield return null;
			MenuScene.Instance.divaManager.SetAnimParamInteger("menu_simpleLoopStart_State", 0);
			if(isTrying)
			{
				GameManager.Instance.SetFPS(60);
			}
			MenuScene.Instance.InputDisable();
			yield return Resources.UnloadUnusedAssets();
			bool isWait = true;
			divaResource.ReleaseCostume();
			this.StartCoroutineWatched(divaResource.Co_LoadCostume(m_costume_model_id, () =>
			{
				//0x16E1E84
				isWait = false;
			}));
			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			MenuScene.Instance.InputEnable();
			while (isWait)
				yield return null;
			MenuScene.Instance.divaManager.Load(divaResource, m_diva_id, m_costume_model_id, m_costume_color, false);
			MenuScene.Instance.divaManager.OverrideAnimations(divaResource.overrideClipList);
			if(divaResource.materialList.Count > 0)
			{
				MenuScene.Instance.divaManager.ChangeCostumeTexture(divaResource.materialList[m_costume_color], m_costume_color);
			}
			while (MenuScene.Instance.divaManager.IsLoading)
				yield return null;
			MenuScene.Instance.divaManager.OnIdle("simple_idle");
			if(isTrying)
			{
				MenuScene.Instance.divaManager.SetAnimParamInteger("menu_simpleLoopStart_State", 1);
				yield return null;
				hash = Animator.StringToHash("simple_loop_start");
				while (!MenuScene.Instance.divaManager.IsCurrentBodyState(hash))
					yield return null;
				voicePlayBack = voicePlayer.source.Play(voicePlayIndex);
				voicePlayIndex++;
				if (voiceQueCount <= voicePlayIndex)
					voicePlayIndex = 0;
				divaWaitCoroutine = this.StartCoroutineWatched(Co_WaitDiva());
			}
			yield return new WaitForSeconds(0.1f);
			MenuScene.Instance.divaManager.SetEnableRenderer(true);
			yield return null;
			m_model_loaded = true;
		}

		//// RVA: 0x16E07CC Offset: 0x16E07CC VA: 0x16E07CC
		private void OnClickViewOn()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_GotoViewMode());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CD22C Offset: 0x6CD22C VA: 0x6CD22C
		//// RVA: 0x16E0840 Offset: 0x16E0840 VA: 0x16E0840
		private IEnumerator Co_GotoViewMode()
		{
			int t_hash_simple_idle; // 0x14
			int t_hash_simple_end; // 0x18
			bool isMotion; // 0x1C

			//0x16E219C
			if (m_touch_disable_obj != null)
				m_touch_disable_obj.SetActive(true);
			t_hash_simple_idle = Animator.StringToHash("simple_idle");
			t_hash_simple_end = Animator.StringToHash("simple_loop_end");
			MenuScene.Instance.InputDisable();
			isMotion = false;
			if(divaWaitCoroutine != null)
			{
				this.StopCoroutineWatched(divaWaitCoroutine);
				divaWaitCoroutine = null;
				isMotion = true;
			}
			yield return null;
			MenuScene.Instance.divaManager.SetAnimParamInteger("menu_simpleLoopStart_State", 0);
			if (isMotion)
			{
				if (!MenuScene.Instance.divaManager.IsCurrentBodyState(t_hash_simple_idle) &&
					!MenuScene.Instance.divaManager.IsCurrentBodyState(t_hash_simple_end))
				{
					MenuScene.Instance.divaManager.SetBodyCrossFade("simple_loop_end", 0.07f);
					MenuScene.Instance.divaManager.PlayFacialBlendAnimator("simple_idle", 0);
					MenuScene.Instance.divaManager.PlayFacialBlendAnimator("simple_idle", 1);
				}
			}
			yield return null;
			yield return this.StartCoroutineWatched(MenuScene.Instance.divaManager.Co_WaitTransition());
			while (!MenuScene.Instance.divaManager.IsCurrentBodyState(t_hash_simple_idle))
			{
				yield return null;
			}
			m_view_on.Leave();
			m_cos_list_win.Leave();
			m_viewObj = ViewScreenCostume.Create();
			ViewScreenCostume.Enter(m_viewObj, null);
			MenuScene.Instance.InputEnable();
			DivaViewModeArgs arg = new DivaViewModeArgs();
			arg.viewObj = m_viewObj;
			MenuScene.Instance.Call(TransitionList.Type.COSTUME_VIEW_MODE, arg, true);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CD2A4 Offset: 0x6CD2A4 VA: 0x6CD2A4
		//// RVA: 0x16E08EC Offset: 0x16E08EC VA: 0x16E08EC
		private IEnumerator Co_WaitDiva()
		{
			//0x16E5338
			while (voicePlayBack.GetStatus() != CriAtomExPlayback.Status.Removed)
				yield return null;
			MenuScene.Instance.divaManager.SetAnimParamInteger("menu_simpleLoopStart_State", 2);
			int hash = Animator.StringToHash("simple_idle");
			while (!MenuScene.Instance.divaManager.IsCurrentBodyState(hash))
				yield return null;
			MenuScene.Instance.divaManager.SetAnimParamInteger("menu_simpleLoopStart_State", 0);
			divaWaitCoroutine = null;
			yield return new WaitForSeconds(0.1f);
			GameManager.Instance.SetFPS(30);
		}

		//// RVA: 0x16E0998 Offset: 0x16E0998 VA: 0x16E0998
		//private void SetNextCostume(int modelId, int colorId) { }

		//// RVA: 0x16E09A4 Offset: 0x16E09A4 VA: 0x16E09A4
		private void CB_Try(int a_index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			CostumeSelectListWin.ItemInfo item = m_cos_list_win.GetItem(a_index);
			if(item.m_is_new)
			{
				item.m_is_new = false;
				item.m_view_diva.LEHDLBJJBNC();
			}
			m_pushedTrying = true;
			m_next_costume_model_id = item.m_view_diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId;
			m_next_costume_color = item.m_cos_color;
		}

		//// RVA: 0x16E0AC4 Offset: 0x16E0AC4 VA: 0x16E0AC4
		private void CB_GetInfo(int a_index)
		{
			TodoLogger.LogNotImplemented("CB_GetInfo");
		}

		//// RVA: 0x16E0B40 Offset: 0x16E0B40 VA: 0x16E0B40
		private void CB_CostumeChange()
		{
			CostumeSelectListWin.ItemInfo item = m_cos_list_win.GetSelectItem();
			if(item.m_is_have)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				m_costume_id = item.m_cos_id;
				m_costume_model_id = item.m_cos_model_id;
				m_costume_color = item.m_cos_color;
				FFHPBEPOMAK_DivaInfo divaInfo;
				if (!m_is_godiva)
				{
					divaInfo = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC[m_diva_index];
				}
				else
				{
					divaInfo = null;
					TodoLogger.Log(0, "CB_CostumeChange divaGo");
				}
				if(m_transitionName == TransitionList.Type.COSTUME_SELECT)
				{
					m_costume_window.TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_title_02");
					m_costume_window.WindowSize = SizeType.Large;
					m_costume_window.Buttons = new ButtonInfo[2] {
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					m_costume_window.SetParent(transform);
					m_costume_window.beforeData = divaInfo;
					m_costume_window.afterData = item.m_view_diva;
					m_costume_window.afterData.JEIGPGNJJCP_SetCostumeColor(item.m_cos_color);
					PopupWindowManager.Show(m_costume_window, ChangeCostume, ChangeTabContens, null, null);
				}
			}
		}

		//// RVA: 0x16E1138 Offset: 0x16E1138 VA: 0x16E1138
		private void ChangeCostume(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			if (type != PopupButton.ButtonType.Positive)
				return;
			CostumeSelectListWin.ItemInfo item = m_cos_list_win.GetSelectItem();
			if (!item.m_is_have)
				return;
			item.m_view_diva.LEHDLBJJBNC();
			JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = true;
			JDDGPJDKHNE.HHCJCDFCLOB.NFNLGGHMEAM();
			FFHPBEPOMAK_DivaInfo currentDiva = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC[m_diva_index];
			int divaId = currentDiva.AHHJLDLAPAN_DivaId;
			int oldCostumeId = 0;
			int oldColorId = 0;
			int oldHomeCostumeId = 0;
			int oldHomeColorId = 0;
			int newCostumeId = 0;
			int newColorId = 0;
			int newHomeCostumeId = 0;
			int newHomeColorId = 0;
			if (m_transitionName == TransitionList.Type.COSTUME_SELECT)
			{
				oldCostumeId = currentDiva.JPIDIENBGKH_CostumeId;
				oldColorId = currentDiva.EKFONBFDAAP_ColorId;
				oldHomeCostumeId = currentDiva.KIIMFCFMMDN_HomeCostumeId;
				oldHomeColorId = currentDiva.JFFLFIMIMOI_HomeColorId;
				GameManager.Instance.ViewPlayerData.HOOJOFACOEK_SetCostume(divaId, m_costume_id, m_costume_color);
				bool homeSync = false;
				if(m_costume_window.costumeInfoWindow.IsHomeCostumeReflect)
				{
					GameManager.Instance.ViewPlayerData.OPDBFHFKKJN_SetHomeCostume(divaId, m_costume_id, m_costume_color);
					homeSync = true;
				}
				newCostumeId = currentDiva.JPIDIENBGKH_CostumeId;
				newColorId = currentDiva.EKFONBFDAAP_ColorId;
				newHomeCostumeId = currentDiva.KIIMFCFMMDN_HomeCostumeId;
				newHomeColorId = currentDiva.JFFLFIMIMOI_HomeColorId;
				if(homeSync)
				{
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId = divaId;
				}
			}
			bool b = false;
			if(oldCostumeId != newCostumeId || oldColorId != newColorId)
			{
				ILCCJNDFFOB.HHCJCDFCLOB.DBIDGHMFLIC(divaId, oldCostumeId, newCostumeId, oldColorId, newColorId);
				b = true;
			}
			if(oldHomeCostumeId != newHomeCostumeId || oldHomeColorId != newHomeColorId)
			{
				ILCCJNDFFOB.HHCJCDFCLOB.CJCJNKOPIKB(divaId, oldHomeCostumeId, newHomeCostumeId, oldHomeColorId, newHomeColorId);
				b = true;
			}
			if (b)
			{
				if (GNGMCIAIKMA.HHCJCDFCLOB != null)
				{
					GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.HOOJOFACOEK/*7*/, divaId, 1, null);
					GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_IsBingoValid(null, -1);
				}
			}

			//LAB_016e1740
			m_cos_list_win.Exit();
			this.StartCoroutineWatched(Co_CostumeSaveAndSceneReturn());
		}

		//// RVA: 0x16E17A4 Offset: 0x16E17A4 VA: 0x16E17A4
		private void ChangeTabContens(IPopupContent content, PopupTabButton.ButtonLabel label)
		{
			(content as PopupTabContents).ChangeContents((int)label);
		}

		//// RVA: 0x16E189C Offset: 0x16E189C VA: 0x16E189C
		private void CB_CostumeBuild()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(MOEALEGLGCH.CDOCOLOKCJK())
			{
				CostumeUpgradeArgs arg = new CostumeUpgradeArgs();
				arg.divaId = m_diva_id;
				arg.costumemModelId = m_next_costume_model_id;
				MenuScene.Instance.Call(TransitionList.Type.COSTUME_UPGRADE, arg, true);
			}
			else
			{
				this.StartCoroutineWatched(Co_PopupCostumeBuildLock());
			}
		}
	}
}
