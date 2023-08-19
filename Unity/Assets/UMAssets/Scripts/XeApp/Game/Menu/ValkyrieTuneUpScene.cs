using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class ValkyrieTuneUpScene : TransitionRoot
	{
		private static readonly SeriesAttr.Type[] s_SeriesButtonIndex = new SeriesAttr.Type[4]
			{
				SeriesAttr.Type.First, SeriesAttr.Type.Seven, SeriesAttr.Type.Frontia, SeriesAttr.Type.Delta
			}; // 0x0
		private static readonly float DISP_NOTICE_TIME = 1; // 0x4
		private static readonly int BGM_ID = 1028; // 0x8
		private DFKGGBMFFGB_PlayerInfo m_PlayerData; // 0x48
		private JLKEOGLJNOD_TeamInfo m_UnitData; // 0x4C
		private List<PNGOLKLFFLH> m_ValkyrieList; // 0x50
		private List<PNGOLKLFFLH>[] m_SeriesValkyrieList = new List<PNGOLKLFFLH>[5]; // 0x54
		private List<PIGBBNDPPJC> m_EpisodeList; // 0x58
		private Action m_Updater; // 0x5C
		private bool m_IsInitialized; // 0x60
		private bool m_IsReset = true; // 0x61
		private bool m_IsPlayEpAnim; // 0x62
		private bool m_IsDispEpPop; // 0x63
		private bool m_IsDispViewBtn; // 0x64
		private bool m_is_ValkrieTouch; // 0x65
		private bool m_IsDeculture; // 0x66
		private int m_DisableViewButtonCount; // 0x68
		private ValkyriePopupSetting m_PopupSetting; // 0x6C
		private ValkyrieSkillCheckPopupSetting m_SkillCheckPopupSetting; // 0x70
		private ValkyrieSkillUpRewardPopupSetting m_skillupRewardPopupSetting; // 0x74
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
		private LayoutTuneUpBgCircle m_circle; // 0x98
		private LayoutEpisodePopup m_episodePop; // 0x9C
		private LayoutDecultureAnimation m_deculture; // 0xA0
		private OfferHaveItemCheck m_haveItemCheck; // 0xA4
		private LayoutSkillUpAnimation m_abilityUpAnim; // 0xA8
		public int SelectSeries = 1; // 0xAC
		public int Select; // 0xB0

		// RVA: 0xBD0164 Offset: 0xBD0164 VA: 0xBD0164 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_Updater = UpdateInit;
			for(int i = 0; i < m_SeriesValkyrieList.Length; i++)
			{
				m_SeriesValkyrieList[i] = new List<PNGOLKLFFLH>();
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_PopupSetting = new ValkyriePopupSetting();
			m_PopupSetting.WindowSize = SizeType.Large;
			m_PopupSetting.TitleText = bk.GetMessageByLabel("pop_valyrietuneup_title");
			m_PopupSetting.SetParent(transform);
			m_SkillCheckPopupSetting = new ValkyrieSkillCheckPopupSetting();
			m_SkillCheckPopupSetting.WindowSize = SizeType.Small;
			m_SkillCheckPopupSetting.TitleText = bk.GetMessageByLabel("pop_valyrietuneupcheck_title");
			m_SkillCheckPopupSetting.SetParent(transform);
			m_skillupRewardPopupSetting = new ValkyrieSkillUpRewardPopupSetting();
			m_skillupRewardPopupSetting.WindowSize = SizeType.Small;
			m_skillupRewardPopupSetting.TitleText = "";
			m_skillupRewardPopupSetting.IsCaption = false;
			m_skillupRewardPopupSetting.SetParent(transform);
			this.StartCoroutineWatched(Co_LoadEffect());
			this.StartCoroutineWatched(Co_LayoutAssetLoad());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x73460C Offset: 0x73460C VA: 0x73460C
		//// RVA: 0xBD05A0 Offset: 0xBD05A0 VA: 0xBD05A0
		private IEnumerator Co_LoadEffect()
		{
			string bundleName; // 0x14
			string assetName; // 0x18
			AssetBundleLoadAllAssetOperationBase operation; // 0x1C

			//0xBD9D48
			bundleName = "ef/cmn.xab";
			assetName = "model_loading";
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName);
			yield return operation;
			m_EffectPrefab = operation.GetAsset<GameObject>(assetName);
			AssetBundleManager.UnloadAssetBundle(bundleName);
			m_IsLoadEffect = true;
		}

		// RVA: 0xBD06D8 Offset: 0xBD06D8 VA: 0xBD06D8 Slot: 20
		protected override bool OnBgmStart()
		{
			SoundManager.Instance.bgmPlayer.ContinuousPlay(BGM_ID, 1);
			return true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x734684 Offset: 0x734684 VA: 0x734684
		//// RVA: 0xBD062C Offset: 0xBD062C VA: 0xBD062C
		private IEnumerator Co_LayoutAssetLoad()
		{
			string bundleName; // 0x14
			Font systemFont; // 0x18

			//0xBD81C8
			m_IsLoadLayout = false;
			bundleName = "ly/045.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co.R(Co_LoadAssetsAbilityUpAnim(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsLayoutValkyrieSelect(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsLayoutSeriesButton(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsLayoutCircle(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsPopUp(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsHaveItem(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsDecolureAnimation(bundleName, systemFont));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			while (m_layoutValSelect == null)
				yield return null;
			while (m_SeriesTab == null)
				yield return null;
			while (m_circle == null)
				yield return null;
			while (m_episodePop == null)
				yield return null;
			while (m_deculture == null)
				yield return null;
			while (m_abilityUpAnim == null)
				yield return null;
			m_IsLoadLayout = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7346FC Offset: 0x7346FC VA: 0x7346FC
		//// RVA: 0xBD07D8 Offset: 0xBD07D8 VA: 0xBD07D8
		private IEnumerator Co_LoadAssetsLayoutValkyrieSelect(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xBD9780
			if(m_layoutValSelect == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_valkyrie01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0xBD6624
					instance.transform.SetParent(transform, false);
					m_layoutValSelect = instance.GetComponent<LayoutValkyrieSelect>();
					m_layoutValSelect.SetAtkArrowEnable(false);
					m_layoutValSelect.SetHitArrowEnable(false);
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName);
				operation = null;
			}
			else
			{
				m_layoutValSelect.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x734774 Offset: 0x734774 VA: 0x734774
		//// RVA: 0xBD08B8 Offset: 0xBD08B8 VA: 0xBD08B8
		private IEnumerator Co_LoadAssetsLayoutSeriesButton(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xBD946C
			if(m_SeriesTab == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_val_btn_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0xBD673C
					instance.transform.SetParent(transform, false);
					m_SeriesTab = instance.GetComponent<LayoutSeriesTab>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_SeriesTab.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7347EC Offset: 0x7347EC VA: 0x7347EC
		//// RVA: 0xBD0998 Offset: 0xBD0998 VA: 0xBD0998
		private IEnumerator Co_LoadAssetsLayoutCircle(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xBD91B8
			if(m_circle == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_val_circle_abi_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0xBD680C
					m_circle = instance.GetComponent<LayoutTuneUpBgCircle>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x734864 Offset: 0x734864 VA: 0x734864
		//// RVA: 0xBD0A78 Offset: 0xBD0A78 VA: 0xBD0A78
		private IEnumerator Co_LoadAssetsPopUp(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xBD9A94
			if(m_episodePop == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_val_terms_window_all_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0xBD6888
					instance.transform.SetParent(transform, false);
					m_episodePop = instance.GetComponent<LayoutEpisodePopup>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7348DC Offset: 0x7348DC VA: 0x7348DC
		//// RVA: 0xBD0B58 Offset: 0xBD0B58 VA: 0xBD0B58
		private IEnumerator Co_LoadAssetsDecolureAnimation(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xBD8B90
			if(m_deculture == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "sw_sel_val_abi_deculture_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0xBD6958
					instance.transform.SetParent(transform, false);
					m_deculture = instance.GetComponent<LayoutDecultureAnimation>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_deculture.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x734954 Offset: 0x734954 VA: 0x734954
		//// RVA: 0xBD0C38 Offset: 0xBD0C38 VA: 0xBD0C38
		private IEnumerator Co_LoadAssetsHaveItem(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xBD8EA4
			if(m_haveItemCheck == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_vfo_item_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0xBD6A28
					instance.transform.SetParent(transform, false);
					m_haveItemCheck = instance.GetComponent<OfferHaveItemCheck>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7349CC Offset: 0x7349CC VA: 0x7349CC
		//// RVA: 0xBD0D18 Offset: 0xBD0D18 VA: 0xBD0D18
		private IEnumerator Co_LoadAssetsAbilityUpAnim(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xBD887C
			if(m_abilityUpAnim == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "sw_sel_val_abi_lvup_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0xBD6AF8
					instance.transform.SetParent(transform, false);
					m_abilityUpAnim = instance.GetComponent<LayoutSkillUpAnimation>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName);
				operation = null;
			}
			else
			{
				m_abilityUpAnim.transform.SetParent(transform, false);
			}
		}

		//// RVA: 0xBD0DF8 Offset: 0xBD0DF8 VA: 0xBD0DF8
		//private void ShowViewButton() { }

		//// RVA: 0xBD0E0C Offset: 0xBD0E0C VA: 0xBD0E0C
		//private void HideViewButton() { }

		//// RVA: 0xBD0E20 Offset: 0xBD0E20 VA: 0xBD0E20
		//public void ShowLoadingEffect() { }

		//// RVA: 0xBD0F88 Offset: 0xBD0F88 VA: 0xBD0F88
		//public void HideLoadingEffect() { }

		//[IteratorStateMachineAttribute] // RVA: 0x734A44 Offset: 0x734A44 VA: 0x734A44
		//// RVA: 0xBD1130 Offset: 0xBD1130 VA: 0xBD1130
		private IEnumerator Co_PlayNoticeAnim()
		{
			//0xBDA5C4
			m_layoutValSelect.NoticeAnimEnter();
			m_IsDispNotice = true;
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0xBD6BC8
				return m_layoutValSelect.NoticeAnimIsPlaying();
			});
			while (!m_IsSceneActivate)
				yield return null;
			if(m_IsDispNotice)
			{
				float wait_time = DISP_NOTICE_TIME;
				yield return new WaitWhile(() =>
				{
					//0xBD6D5C
					wait_time -= Time.deltaTime;
					return wait_time >= 0;
				});
				m_layoutValSelect.NoticeAnimLeave();
				m_IsDispNotice = false;
			}
		}

		// RVA: 0xBD11DC Offset: 0xBD11DC VA: 0xBD11DC
		public void Update()
		{
			if (m_Updater != null)
				m_Updater();
		}

		//// RVA: 0xBD1208 Offset: 0xBD1208 VA: 0xBD1208
		//private int ConvertSeriesAttrIndex(SeriesAttr.Type type) { }

		//// RVA: 0xBD1350 Offset: 0xBD1350 VA: 0xBD1350
		private void ResetValkyrieData()
		{
			m_ValkyrieList = PNGOLKLFFLH.NEOMKKIEMJJ(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, false);
			if(m_UnitData.JOKFNBLEILN_Valkyrie == null)
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
			int selId = GameManager.Instance.localSave.EPJOACOONAC_GetSave().IOAFPGDJCDH_ValkyrieTuneUp.IHAHBHEDIAK_SelectVfId;
			PNGOLKLFFLH valk = m_ValkyrieList.Find((PNGOLKLFFLH _) =>
			{
				//0xBD6DA0
				return _.GPPEFLKGGGJ_ValkyrieId == selId;
			});
			if(valk != null)
			{
				SelectSeries = valk.AIHCEGFANAM_Serie - 1;
				Select = m_SeriesValkyrieList[SelectSeries].FindIndex((PNGOLKLFFLH _) =>
				{
					//0xBD6DD8
					return _.GPPEFLKGGGJ_ValkyrieId == selId;
				});
			}
		}

		//// RVA: 0xBD18B8 Offset: 0xBD18B8 VA: 0xBD18B8
		private void ResetSeriesButtonState()
		{
			for(int i = 0; i < 5; i++)
			{
				m_SeriesTab.ButtonDisable(i, m_SeriesValkyrieList[i].Count == 0);
			}
		}

		//// RVA: 0xBD19A8 Offset: 0xBD19A8 VA: 0xBD19A8
		private void UpdateInit()
		{
			if(m_IsLoadEffect && m_IsLoadLayout)
			{
				if(m_EffectInstance == null)
				{
					m_EffectInstance = Instantiate(m_EffectPrefab, new Vector3(0, 1, 0), m_EffectPrefab.transform.rotation);
				}
				m_EffectInstance.gameObject.SetActive(false);
				m_PlayerData = GameManager.Instance.ViewPlayerData;
				m_UnitData = m_PlayerData.NPFCMHCCDDH;
				m_SeriesTab.SetSeriesIcon();
				m_SeriesTab.SetSeriesButtonCallBack((SeriesAttr.Type type) =>
				{
					//0xBD6BF4
					if(InputManager.Instance.GetInScreenTouchCount() < 2)
					{
						if(!MenuScene.Instance.DirtyChangeScene && IsLoadedValkyrie())
						{
							if(!m_SwaipTouch.IsMoveFlickDistance() && !m_viewSceneFlag)
							{
								SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
								m_SeriesTab.ChangeSelectSeries((int)type, ref SelectSeries, ref Select);
								m_SeriesTab.ApplySelectSeriesButton((int)type - 1);
								ApplySelectValkyrie();
								m_Updater = UpdateChangeAnim_Start;
							}
						}
					}
				});
				m_episodePop.SetEpisodeButtonCallback(OnClickEpisodeButton);
				m_layoutValSelect.SetTransformTouchAreaCallback(OnClickTransformation);
				m_layoutValSelect.SetButtonCallBack(() =>
				{
					//0xBD6BF8
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
				}, () =>
				{
					//0xBD6BFC
					if(!m_SwaipTouch.IsMoveFlickDistance() && !m_viewSceneFlag)
					{
						if (InputManager.Instance.GetInScreenTouchCount() < 2)
						{
							if (!MenuScene.Instance.DirtyChangeScene)
							{
								if (IsLoadedValkyrie())
								{
									ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.RIGHT);
									SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
								}
							}
						}
					}
				}, () =>
				{
					//0xBD6C00
					OnClickSelectButton(false);
				}, null);
				m_SwaipTouch = GetComponentInChildren<SwaipTouch>(true);
				m_deculture.Leave();
				m_layoutValSelect.SelectButtonChangeUV(m_transitionName);
				IsReady = true;
				m_Updater = UpdateIdle;
			}
		}

		//// RVA: 0xBD1E94 Offset: 0xBD1E94 VA: 0xBD1E94
		private void ApplyAbility()
		{
			m_layoutValSelect.HasAbility = m_SeriesValkyrieList[SelectSeries][Select].CNLIAMIIJID_AbilityLevel > 0;
			ALEKLHIANJN a = new ALEKLHIANJN(m_SeriesValkyrieList[SelectSeries][Select].GPPEFLKGGGJ_ValkyrieId, m_SeriesValkyrieList[SelectSeries][Select].CNLIAMIIJID_AbilityLevel);
			m_layoutValSelect.SetAbility(a.OPFGFINHFCE_SkillName, a.CHHADJECKNL_GetLevel(), a.DMBDNIEEMCB_GetDesc());
		}

		//// RVA: 0xBD2104 Offset: 0xBD2104 VA: 0xBD2104
		private void ApplySelectValkyrie()
		{
			PNGOLKLFFLH valk = m_SeriesValkyrieList[SelectSeries][Select];
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().IOAFPGDJCDH_ValkyrieTuneUp.IHAHBHEDIAK_SelectVfId = valk.GPPEFLKGGGJ_ValkyrieId;
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			m_layoutValSelect.SetName(valk.IJBLEJOKEFH_ValkyrieName, valk.OPBPKNHIPPE_Pilot.OPFGFINHFCE_Name, valk.KINFGHHNFCF_Atk.ToString(), valk.NONBCCLGBAO_Hit.ToString());
			ApplyAbility();
			if(IsAbilityMax())
			{
				this.StartCoroutineWatched(Deculture());
			}
			else
			{
				if(m_IsDeculture)
				{
					m_deculture.Leave();
					m_IsDeculture = false;
				}
				m_layoutValSelect.SetSelectBtnDisable(false);
				m_layoutValSelect.SetSelectBtnCoverLayoutDisable(true);
			}
			m_layoutValSelect.SetPilotTexture(valk.OPBPKNHIPPE_Pilot.PFGJJLGLPAC_PilotId);
			m_layoutValSelect.SetIconState(m_UnitData.JOKFNBLEILN_Valkyrie.GPPEFLKGGGJ_ValkyrieId == valk.GPPEFLKGGGJ_ValkyrieId ? "01" : "02");
			m_SwaipTouch.enabled = m_layoutValSelect.SubValkyrieEnable(m_SeriesValkyrieList[SelectSeries].Count);
			if(!valk.FJODMPGPDDD_Unlocked)
			{
				if(m_viewValkyrieModeObj != null)
				{
					if (m_viewValkyrieModeObj.GetComponent<ViewScreenValkyrie>() != null)
						m_viewValkyrieModeObj.GetComponent<ViewScreenValkyrie>().Hide();
				}
				m_layoutValSelect.SetSelectBtnDisable(true);
				m_layoutValSelect.SetSelectBtnCoverLayoutDisable(true);
				if (m_IsDispViewBtn)
					m_IsDispViewBtn = false;
				m_IsPlayEpAnim = true;
			}
			else
			{
				if(m_viewValkyrieModeObj != null)
				{
					ViewScreenValkyrie v = m_viewValkyrieModeObj.GetComponent<ViewScreenValkyrie>();
					if (v != null)
					{
						v.Show();
						if(v.GetValkyrieId() == valk.GPPEFLKGGGJ_ValkyrieId)
						{
							if(!m_viewSceneFlag)
							{
								v.ChangeFormType(valk.GCCNMFHELCB_Form, false);
							}
							else
							{
								valk.GCCNMFHELCB_Form = v.GetFormType();
								v.ChangeValkyrie(valk.GPPEFLKGGGJ_ValkyrieId, valk.GCCNMFHELCB_Form);
							}
						}
						else
						{
							v.ChangeValkyrie(valk.GPPEFLKGGGJ_ValkyrieId, valk.GCCNMFHELCB_Form);
						}
						if (!v.IsChangeValkyrie() && !m_IsDispViewBtn)
							m_IsDispViewBtn = true;
						m_IsPlayEpAnim = false;
					}
				}
				m_IsPlayEpAnim = false;
			}
		}

		//// RVA: 0xBD2D38 Offset: 0xBD2D38 VA: 0xBD2D38
		private bool IsPlayingAll()
		{
			return !m_SeriesTab.IsPlaying() && !m_layoutValSelect.IsPlaying() && !m_circle.IsPlaying();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x734ABC Offset: 0x734ABC VA: 0x734ABC
		//// RVA: 0xBD2DC4 Offset: 0xBD2DC4 VA: 0xBD2DC4
		private IEnumerator Co_Initialize()
		{
			//0xBD7A88
			m_IsInitialized = false;
			if (m_IsReset)
				ResetValkyrieData();
			int loading_count = 0;
			for (int i = 0; i < m_ValkyrieList.Count; i++)
			{
				loading_count++;
				MenuScene.Instance.ValkyrieIconCache.LoadPortraitIcon(m_ValkyrieList[i].GPPEFLKGGGJ_ValkyrieId, 0, (IiconTexture texture) =>
				{
					//0xBD6E18
					loading_count--;
				});
				loading_count++;
				GameManager.Instance.PilotTextureCache.Load(m_ValkyrieList[i].OPBPKNHIPPE_Pilot.PFGJJLGLPAC_PilotId, (IiconTexture texture) =>
				{
					//0xBD6E28
					loading_count--;
				});
			}
			yield return new WaitWhile(() =>
			{
				//0xBD6E38
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

		// RVA: 0xBD2E70 Offset: 0xBD2E70 VA: 0xBD2E70 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			MenuScene.Instance.BgControl.SetPriority(BgPriority.TopMost);
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.PNNHEOOJBFI_TutorialGeneralFlags.EDEDFDDIOKO_SetTrue(2);
			m_IsSceneActivate = false;
			this.StartCoroutineWatched(Co_Initialize());
		}

		// RVA: 0xBD3020 Offset: 0xBD3020 VA: 0xBD3020 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return base.IsEndPreSetCanvas() && m_IsInitialized;
		}

		// RVA: 0xBD3044 Offset: 0xBD3044 VA: 0xBD3044 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_circle.transform.SetParent(MenuScene.Instance.m_bgRootObject.transform, false);
			m_circle.Enter();
			m_SeriesTab.Enter();
			m_layoutValSelect.Enter();
			m_haveItemCheck.Enter();
			if (m_viewSceneFlag && !m_IsDispViewBtn)
				m_IsDispViewBtn = true;
			this.StartCoroutineWatched(Co_PlayNoticeAnim());
			if(m_viewValkyrieModeObj == null)
			{
				m_viewValkyrieModeObj = ViewScreenValkyrie.Create(m_SeriesValkyrieList[SelectSeries][Select].GPPEFLKGGGJ_ValkyrieId, m_SeriesValkyrieList[SelectSeries][Select].GCCNMFHELCB_Form, () =>
				{
					//0xBD6C08
					if(m_EffectInstance != null)
					{
						m_EffectInstance.SetActive(true);
						m_layoutValSelect.SetActiveTransform(m_EffectInstance.activeSelf, false);
						if (m_IsDispViewBtn)
							m_IsDispViewBtn = false;
						MenuScene.Instance.InputDisable();
					}
				}, () =>
				{
					//0xBD6C0C
					if(m_EffectInstance != null)
					{
						m_EffectInstance.SetActive(false);
						m_layoutValSelect.SetActiveTransform(m_EffectInstance.activeSelf, true);
						if (!m_IsDispViewBtn)
							m_IsDispViewBtn = true;
						MenuScene.Instance.InputEnable();
						m_SwaipTouch.ResetValue();
						m_SwaipTouch.ResetInputState();
					}
				}, true);
			}
			m_is_ValkrieTouch = true;
			m_viewSceneFlag = false;
		}

		// RVA: 0xBD33DC Offset: 0xBD33DC VA: 0xBD33DC Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return IsPlayingAll();
		}

		// RVA: 0xBD33E0 Offset: 0xBD33E0 VA: 0xBD33E0 Slot: 23
		protected override void OnActivateScene()
		{
			this.StartCoroutineWatched(Co_OnActivateScene());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x734B34 Offset: 0x734B34 VA: 0x734B34
		//// RVA: 0xBD3404 Offset: 0xBD3404 VA: 0xBD3404
		private IEnumerator Co_OnActivateScene()
		{
			GameManager.PushBackButtonHandler backButtonDummy;

			//0xBD9F88
			if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsValkyrieUpgradeHelp))
			{
				TodoLogger.LogError(0, "Tuto");
				yield return null;
			}
			//LAB_00bda480
			m_IsSceneActivate = true;
			SetActiveSwaipTouch(true);
		}

		// RVA: 0xBD34B0 Offset: 0xBD34B0 VA: 0xBD34B0 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_circle.Leave();
			m_layoutValSelect.Leave();
			m_SeriesTab.Leave();
			m_haveItemCheck.Leave();
			if (m_IsDispViewBtn)
				m_IsDispViewBtn = false;
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
			if (!m_viewSceneFlag)
				ViewScreenValkyrie.Destroy(m_viewValkyrieModeObj);
			else
				m_IsReset = false;
		}

		// RVA: 0xBD3670 Offset: 0xBD3670 VA: 0xBD3670 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return IsPlayingAll();
		}

		// RVA: 0xBD3674 Offset: 0xBD3674 VA: 0xBD3674 Slot: 21
		protected override void OnOpenScene()
		{
			m_circle.loop();
		}

		// RVA: 0xBD36A0 Offset: 0xBD36A0 VA: 0xBD36A0 Slot: 14
		protected override void OnDestoryScene()
		{
			m_circle.transform.SetParent(transform, false);
			if (m_viewSceneFlag)
				return;
			MenuScene.Instance.BgControl.SetPriority(BgPriority.Bottom);
		}

		// RVA: 0xBD37C8 Offset: 0xBD37C8 VA: 0xBD37C8 Slot: 15
		protected override void OnDeleteCache()
		{
			m_circle.transform.SetParent(transform, false);
			Destroy(m_EffectInstance);
		}

		//// RVA: 0xBD38A8 Offset: 0xBD38A8 VA: 0xBD38A8
		private void ChangeSelectValkyrie(LayoutValkyrieSelect.Direction dir)
		{
			if (m_SeriesValkyrieList[SelectSeries].Count < 2)
				return;
			m_SeriesValkyrieList[SelectSeries][Select].OELFCIKFMLL(0);
			if(dir == LayoutValkyrieSelect.Direction.RIGHT)
			{
				Select++;
				if(Select >= m_SeriesValkyrieList[SelectSeries].Count)
					Select -= m_SeriesValkyrieList[SelectSeries].Count;
			}
			else if(dir == LayoutValkyrieSelect.Direction.LEFT)
			{
				Select--;
				if (Select < 0)
					Select += m_SeriesValkyrieList[SelectSeries].Count;
			}
			ApplySelectValkyrie();
			m_Updater = UpdateChangeAnim_Start;
		}

		//// RVA: 0xBD3AC0 Offset: 0xBD3AC0 VA: 0xBD3AC0
		private void UpdateIdle()
		{
			if(m_SwaipTouch != null)
			{
				if (m_SwaipTouch.IsStop())
					return;
				if (m_SwaipTouch.IsSwaip(SwaipTouch.Direction.RIGHT))
					ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.LEFT);
				if (m_SwaipTouch.IsSwaip(SwaipTouch.Direction.LEFT))
					ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.RIGHT);
				if (m_SwaipTouch.IsFlickNoSwaip(SwaipTouch.Direction.RIGHT))
					ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.LEFT);
				if (m_SwaipTouch.IsFlickNoSwaip(SwaipTouch.Direction.LEFT))
					ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.RIGHT);
			}
		}

		//// RVA: 0xBD3C60 Offset: 0xBD3C60 VA: 0xBD3C60
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

		//// RVA: 0xBD3E04 Offset: 0xBD3E04 VA: 0xBD3E04
		private void UpdateChangeAnim_Wait()
		{
			if(!m_layoutValSelect.ValkyrieImageIsPlaying())
			{
				if(!m_episodePop.IsPlaying())
				{
					m_layoutValSelect.ApplySelectValkyrieImage(m_SeriesValkyrieList[SelectSeries], Select);
					PIGBBNDPPJC e = GetEpisodeData(m_SeriesValkyrieList[SelectSeries][Select].KELFCMEOPPM_EpisodeId);
					string epName = e != null ? e.OPFGFINHFCE_Name : "";
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					m_episodePop.SetEpisodeText(bk.GetMessageByLabel("costume_select_text_01"), string.Format(bk.GetMessageByLabel("costume_select_text_02"), epName));
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
		}

		//// RVA: 0xBD42E8 Offset: 0xBD42E8 VA: 0xBD42E8
		private void UpdateChangeAnim_End()
		{
			if(!m_layoutValSelect.ValkyrieImageIsPlaying())
			{
				if(!m_episodePop.IsPlaying())
				{
					MenuScene.Instance.InputEnable();
					m_SwaipTouch.ResetValue();
					m_SwaipTouch.ResetInputState();
					m_layoutValSelect.SetActiveTransform(m_EffectInstance.activeSelf, true);
					m_Updater = UpdateIdle;
				}
			}
		}

		//// RVA: 0xBD44A0 Offset: 0xBD44A0 VA: 0xBD44A0
		//private void OnClickArrowButtonL() { }

		//// RVA: 0xBD476C Offset: 0xBD476C VA: 0xBD476C
		//private void OnClickArrowButtonR() { }

		//// RVA: 0xBD490C Offset: 0xBD490C VA: 0xBD490C
		private void OnClickSelectButton(bool isNotPlaySe = false)
		{
			if(!IsProcessing())
			{
				if(!isNotPlaySe)
				{
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				}
				m_PopupSetting.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				m_PopupSetting.before_data = new ALEKLHIANJN(m_SeriesValkyrieList[SelectSeries][Select].GPPEFLKGGGJ_ValkyrieId, m_SeriesValkyrieList[SelectSeries][Select].CNLIAMIIJID_AbilityLevel);
				m_PopupSetting.after_data = new ALEKLHIANJN(m_SeriesValkyrieList[SelectSeries][Select].GPPEFLKGGGJ_ValkyrieId, m_SeriesValkyrieList[SelectSeries][Select].CNLIAMIIJID_AbilityLevel);
				PopupWindowManager.Show(m_PopupSetting, OnClickPopupButton, null, null, null);
			}
		}

		//// RVA: 0xBD4E3C Offset: 0xBD4E3C VA: 0xBD4E3C
		private bool IsProcessing()
		{
			return m_SwaipTouch.IsMoveFlickDistance() || m_viewSceneFlag || InputManager.Instance.GetInScreenTouchCount() > 1 || MenuScene.Instance.DirtyChangeScene || !IsLoadedValkyrie();
		}

		//// RVA: 0xBD4F8C Offset: 0xBD4F8C VA: 0xBD4F8C
		private void OnClickPopupButton(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			if(label == PopupButton.ButtonLabel.Cancel)
			{
				m_is_ValkrieTouch = true;
				SetActiveSwaipTouch(true);
			}
			else if(label == PopupButton.ButtonLabel.Ok)
			{
				m_is_ValkrieTouch = false;
				SetActiveSwaipTouch(false);
				this.StartCoroutineWatched(Co_DecideValkyrie());
			}
		}

		//// RVA: 0xBD5160 Offset: 0xBD5160 VA: 0xBD5160
		private void OnClickCheckPopupButton(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			if(label == PopupButton.ButtonLabel.Ok)
			{
				GKFMJAHKEMA_ValSkill.CCPFGNNIBDD a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.MNHBHNIHJJH(m_SeriesValkyrieList[SelectSeries][Select].ENMAEBJGEKL);
				if (a.NHFDCMNPFDK < 1)
				{
					if (IsAbilityMax())
					{
						this.StartCoroutineWatched(Deculture());
					}
					else
						OnClickSelectButton(true);
				}
				else
				{
					m_skillupRewardPopupSetting.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					m_skillupRewardPopupSetting.itemId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.NIIADANCEKL(a.NHFDCMNPFDK).MLIJKJFMOHN(m_SeriesValkyrieList[SelectSeries][Select].CNLIAMIIJID_AbilityLevel - 1);
					m_skillupRewardPopupSetting.cnt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.NIIADANCEKL(a.NHFDCMNPFDK).IMALGGGJDJO(m_SeriesValkyrieList[SelectSeries][Select].CNLIAMIIJID_AbilityLevel - 1);
					PopupWindowManager.Show(m_skillupRewardPopupSetting, OnClickSkillUpRewardPopupButton, null, null, null);
				}
			}
		}

		//// RVA: 0xBD55C0 Offset: 0xBD55C0 VA: 0xBD55C0
		private void OnClickSkillUpRewardPopupButton(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			if(label == PopupButton.ButtonLabel.Ok)
			{
				if(IsAbilityMax())
				{
					this.StartCoroutineWatched(Deculture());
				}
				else
				{
					OnClickSelectButton(true);
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x734BAC Offset: 0x734BAC VA: 0x734BAC
		//// RVA: 0xBD50D4 Offset: 0xBD50D4 VA: 0xBD50D4
		private IEnumerator Co_DecideValkyrie()
		{
			//0xBD6E78
			MenuScene.Instance.InputDisable();
			m_layoutValSelect.Leave();
			m_SeriesTab.Leave();
			m_haveItemCheck.Leave();
			MenuScene.Instance.HeaderLeave();
			MenuScene.Instance.HeaderMenu.MenuStack.LeaveBackButton(false);
			bool isDone = false;
			if(m_PopupSetting.after_data.KBFDFIBDOKC(() =>
			{
				//0xBD6E68
				isDone = true;
			}) != 1)
			{ 
				yield break;
			}
			while (!isDone)
				yield return null;
			while(m_layoutValSelect.IsPlaying())
				yield return null;
			yield return new WaitForSeconds(1);
			m_abilityUpAnim.EnterEffect();
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_KIRA_000);
			m_circle.AnimationSpeedUp();
			while (m_abilityUpAnim.IsPlaying())
				yield return null;
			m_abilityUpAnim.EnterWord();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
			while (m_abilityUpAnim.IsPlaying())
				yield return null;
			m_circle.DefaoultSpeed();
			m_layoutValSelect.Enter();
			m_SeriesTab.Enter();
			m_haveItemCheck.Enter();
			MenuScene.Instance.HeaderEnter();
			MenuScene.Instance.HeaderMenu.MenuStack.EnterBackButton(false);
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JJFFBDLIOCF_Valkyrie != null)
			{
				m_SeriesValkyrieList[SelectSeries][Select].CNLIAMIIJID_AbilityLevel = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JJFFBDLIOCF_Valkyrie.OEMMJCLJMGB_GetLevel(m_SeriesValkyrieList[SelectSeries][Select].GPPEFLKGGGJ_ValkyrieId);
			}
			ApplyAbility();
			m_viewSceneFlag = false;
			while (m_layoutValSelect.IsPlaying())
				yield return null;
			MenuScene.Instance.InputEnable();
			m_SkillCheckPopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_SkillCheckPopupSetting.data = new ALEKLHIANJN(m_SeriesValkyrieList[SelectSeries][Select].GPPEFLKGGGJ_ValkyrieId, m_SeriesValkyrieList[SelectSeries][Select].CNLIAMIIJID_AbilityLevel);
			PopupWindowManager.Show(m_SkillCheckPopupSetting, OnClickCheckPopupButton, null, null, null);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x734C24 Offset: 0x734C24 VA: 0x734C24
		//// RVA: 0xBD2CAC Offset: 0xBD2CAC VA: 0xBD2CAC
		private IEnumerator Deculture()
		{
			//0xBDA92C
			m_IsDeculture = true;
			m_layoutValSelect.SetSelectBtnDisable(true);
			m_layoutValSelect.SetSelectBtnCoverLayoutDisable(false);
			m_deculture.Enter();
			m_is_ValkrieTouch = true;
			SetActiveSwaipTouch(true);
			while (m_deculture.IsPlaying())
				yield return null;
			m_deculture.loop();
		}

		//// RVA: 0xBD2B88 Offset: 0xBD2B88 VA: 0xBD2B88
		private bool IsAbilityMax()
		{
			return m_SeriesValkyrieList[SelectSeries][Select].AKDKFIPNAOL_AbilityLevelMax <= m_SeriesValkyrieList[SelectSeries][Select].CNLIAMIIJID_AbilityLevel;
		}

		//// RVA: 0xBD5650 Offset: 0xBD5650 VA: 0xBD5650
		//private void OnClickViewButton() { }

		//// RVA: 0xBD5884 Offset: 0xBD5884 VA: 0xBD5884
		//private void OnClickSeriesButton(SeriesAttr.Type type) { }

		//// RVA: 0xBD5AC4 Offset: 0xBD5AC4 VA: 0xBD5AC4
		private void OnClickEpisodeButton()
		{
			if(InputManager.Instance.GetInScreenTouchCount() < 2)
			{
				if(!MenuScene.Instance.DirtyChangeScene)
				{
					PIGBBNDPPJC ep = GetEpisodeData(m_SeriesValkyrieList[SelectSeries][Select].KELFCMEOPPM_EpisodeId);
					string epName = ep != null ? ep.OPFGFINHFCE_Name : "";
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					if(ep == null || !m_SeriesValkyrieList[SelectSeries][Select].CPGDEPMPMFK)
					{
						MessageBank bk = MessageManager.Instance.GetBank("menu");
						PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("costume_select_text_03"), SizeType.Small, string.Format("costume_select_text_04", epName), new ButtonInfo[1]
							{
								new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
							}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
							{
								//0xBD6D50
								return;
							}, null, null, null);
					}
					else
					{
						EpisodeDetailArgs arg = new EpisodeDetailArgs();
						arg.data = ep;
						MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_EPISODESELECT_EPISODEDETAIL, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
				}
			}
		}

		//// RVA: 0xBD41D0 Offset: 0xBD41D0 VA: 0xBD41D0
		private PIGBBNDPPJC GetEpisodeData(int id)
		{
			for(int i = 0; i < m_EpisodeList.Count; i++)
			{
				if (m_EpisodeList[i].KELFCMEOPPM_EpId == id)
					return m_EpisodeList[i];
			}
			return null;
		}

		//// RVA: 0xBD6078 Offset: 0xBD6078 VA: 0xBD6078
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
										PNGOLKLFFLH valk = m_SeriesValkyrieList[SelectSeries][Select];
										int f = valk.GCCNMFHELCB_Form >= 2 ? valk.GCCNMFHELCB_Form - 2 : valk.GCCNMFHELCB_Form + 1;
										valk.OELFCIKFMLL(f);
										v.ChangeFormType(f, true);
										SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_VALKYRIE_000);
										m_layoutValSelect.SetActiveTransform(m_EffectInstance.activeSelf, false);
										m_SwaipTouch.Stop(true);
										this.StartCoroutineWatched(v.Co_WaitEnableTransformation(() =>
										{
											//0xBD6C10
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

		//// RVA: 0xBD4FF0 Offset: 0xBD4FF0 VA: 0xBD4FF0
		private void SetActiveSwaipTouch(bool is_active)
		{
			if (m_SeriesValkyrieList[SelectSeries].Count < 2)
				is_active = false;
			m_SwaipTouch.enabled = is_active;
		}

		//// RVA: 0xBD4640 Offset: 0xBD4640 VA: 0xBD4640
		private bool IsLoadedValkyrie()
		{
			if(m_viewValkyrieModeObj != null)
			{
				if(m_viewValkyrieModeObj.GetComponent<ViewScreenValkyrie>() != null)
				{
					return m_viewValkyrieModeObj.GetComponent<ViewScreenValkyrie>().IsLoaded();
				}
			}
			return false;
		}
	}
}
