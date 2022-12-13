using CriWare;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
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
		//private CostumeInfoPopupSetting m_costume_window = new CostumeInfoPopupSetting(); // 0xA4
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
			StartCoroutine(Co_LoadResources());
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
		//private void UpdateIdle() { }

		//// RVA: 0x16DEFAC Offset: 0x16DEFAC VA: 0x16DEFAC
		//private bool CanLoading() { }

		//// RVA: 0x16DEC74 Offset: 0x16DEC74 VA: 0x16DEC74
		//private void UpdateModel() { }

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
			StartCoroutine(Co_LoadDivaResource(m_diva_id));
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
			if (m_view_on.IsPlaying())
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
				StopCoroutine(divaWaitCoroutine);
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
			yield return Co_LoadLayout();
			yield return Co_LoadEffect();
			yield return Co_LoadPopupWindow();
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
		//private IEnumerator Co_LoadLayout() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CCEE4 Offset: 0x6CCEE4 VA: 0x6CCEE4
		//// RVA: 0x16E0444 Offset: 0x16E0444 VA: 0x16E0444
		//private IEnumerator Co_LoadEffect() { }

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
				Method$XeApp.Game.Menu.CostumeSelectScene.<>c__DisplayClass51_0.<Co_LoadDivaResource>b__0()
			});
			voicePlayIndex = 0;
			divaResource.Initialize(divaId);
			yield return divaResource.Co_LoadBasicResource();
			yield return divaResource.Co_LoadMotion();
			while (isWaitLoadCueSheet)
				yield return null;
			CriAtomCueSheet cueSheet = voicePlayer.source.cueSheet.GetCueSheet();
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
		//private IEnumerator Co_LoadPopupWindow() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CD04C Offset: 0x6CD04C VA: 0x6CD04C
		//// RVA: 0x16E05BC Offset: 0x16E05BC VA: 0x16E05BC
		//private IEnumerator Co_CostumeSaveAndSceneReturn() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CD0C4 Offset: 0x6CD0C4 VA: 0x6CD0C4
		//// RVA: 0x16E0650 Offset: 0x16E0650 VA: 0x16E0650
		//private IEnumerator Co_PopupGetInfo(int a_index) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CD13C Offset: 0x6CD13C VA: 0x6CD13C
		//// RVA: 0x16E0718 Offset: 0x16E0718 VA: 0x16E0718
		//private IEnumerator Co_PopupCostumeBuildLock() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CD1B4 Offset: 0x6CD1B4 VA: 0x6CD1B4
		//// RVA: 0x16DEFDC Offset: 0x16DEFDC VA: 0x16DEFDC
		//private IEnumerator CoroutineDivaModel(bool isTrying, bool local = True) { }

		//// RVA: 0x16E07CC Offset: 0x16E07CC VA: 0x16E07CC
		//private void OnClickViewOn() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CD22C Offset: 0x6CD22C VA: 0x6CD22C
		//// RVA: 0x16E0840 Offset: 0x16E0840 VA: 0x16E0840
		//private IEnumerator Co_GotoViewMode() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CD2A4 Offset: 0x6CD2A4 VA: 0x6CD2A4
		//// RVA: 0x16E08EC Offset: 0x16E08EC VA: 0x16E08EC
		//private IEnumerator Co_WaitDiva() { }

		//// RVA: 0x16E0998 Offset: 0x16E0998 VA: 0x16E0998
		//private void SetNextCostume(int modelId, int colorId) { }

		//// RVA: 0x16E09A4 Offset: 0x16E09A4 VA: 0x16E09A4
		//private void CB_Try(int a_index) { }

		//// RVA: 0x16E0AC4 Offset: 0x16E0AC4 VA: 0x16E0AC4
		//private void CB_GetInfo(int a_index) { }

		//// RVA: 0x16E0B40 Offset: 0x16E0B40 VA: 0x16E0B40
		//private void CB_CostumeChange() { }

		//// RVA: 0x16E1138 Offset: 0x16E1138 VA: 0x16E1138
		//private void ChangeCostume(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		//// RVA: 0x16E17A4 Offset: 0x16E17A4 VA: 0x16E17A4
		//private void ChangeTabContens(IPopupContent content, PopupTabButton.ButtonLabel label) { }

		//// RVA: 0x16E189C Offset: 0x16E189C VA: 0x16E189C
		//private void CB_CostumeBuild() { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x6CD32C Offset: 0x6CD32C VA: 0x6CD32C
		//// RVA: 0x16E1B1C Offset: 0x16E1B1C VA: 0x16E1B1C
		//private void <Co_LoadLayout>b__49_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6CD33C Offset: 0x6CD33C VA: 0x6CD33C
		//// RVA: 0x16E1BEC Offset: 0x16E1BEC VA: 0x16E1BEC
		//private void <Co_LoadLayout>b__49_1(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6CD34C Offset: 0x6CD34C VA: 0x6CD34C
		//// RVA: 0x16E1CC0 Offset: 0x16E1CC0 VA: 0x16E1CC0
		//private void <Co_LoadLayout>b__49_2() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6CD35C Offset: 0x6CD35C VA: 0x6CD35C
		//// RVA: 0x16E1CC4 Offset: 0x16E1CC4 VA: 0x16E1CC4
		//private void <Co_LoadPopupWindow>b__52_0(GameObject instance) { }
	}
}
