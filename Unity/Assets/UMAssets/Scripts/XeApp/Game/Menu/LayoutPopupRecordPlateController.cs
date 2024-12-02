using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using mcrs;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupRecordPlateController : IDisposable
	{
		private const int LIST_ITEM_NUM = 3;
		private const int LIST_INFO_ITEM_NUM = 7;
		private PopupRecordPlateOverlapSetting m_overlapSetting; // 0x18
		private LayoutOverlapPlateLvup m_overlapLvup; // 0x1C
		private PopupOverlapListSetting m_overlapListSetting; // 0x20
		private RecordPlateUtility.eSceneType m_sceneType; // 0x24
		private SceneCardTextureCache m_sceneCard; // 0x28
		private SceneFrameTextureCache m_sceneFrame; // 0x2C
		private PopupAddEpisodeContentSetting m_newEpisodeSetting; // 0x30
		private PopupGachaSkillUpSetting m_gachaSkillUpSetting; // 0x34
		private KiraProductController m_kiraProduct; // 0x38
		private PopupAddEpisodeScrollSetting m_newEpisodeScrollSetting; // 0x3C
		private string[] m_bundleNames = new string[3] { "ly/073.xab", "ly/074.xab", "ly/057.xab" }; // 0x40
		private Dictionary<string, int> m_bundleCounter = new Dictionary<string, int>(8); // 0x44

		public GameObject Parent { get; set; } // 0x8
		public GameObject CanvasParent { get; set; } // 0xC
		public MonoBehaviour mb { get; set; } // 0x10
		public bool IsShowRarityUp { get; private set; } // 0x14
		public bool IsShowKiraUp { get; private set; } // 0x15
		public bool IsLoadBundle { get; private set; } // 0x48

		// RVA: 0x177A218 Offset: 0x177A218 VA: 0x177A218
		public void Update()
		{
			if (m_sceneCard != null)
				m_sceneCard.Update();
			if (m_sceneFrame != null)
				m_sceneFrame.Update();
		}

		//// RVA: 0x177A254 Offset: 0x177A254 VA: 0x177A254
		public void Setup(RecordPlateUtility.eSceneType sceneType)
		{
			m_sceneType = sceneType;
			m_overlapListSetting = new PopupOverlapListSetting();
			m_overlapSetting = new PopupRecordPlateOverlapSetting();
			m_newEpisodeSetting = new PopupAddEpisodeContentSetting();
			m_kiraProduct = new KiraProductController();
			m_gachaSkillUpSetting = new PopupGachaSkillUpSetting();
			m_newEpisodeScrollSetting = new PopupAddEpisodeScrollSetting();
			SetupSceneCard();
		}

		//// RVA: 0x177A420 Offset: 0x177A420 VA: 0x177A420
		private void PopupShowNewGet(GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo info, Action callback)
		{
			m_overlapSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_overlapSetting.RareUpInfo = info;
			PopupWindowManager.Show(m_overlapSetting, (PopupWindowControl control, PopupButton.ButtonType buttonType, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0x177D0F8
				if (callback != null)
					callback();
			}, null, null, null, info.IPMJIODJGBC != GONMPHKGKHI_RewardView.CECMLGBLHHG.GBIDBHKEPGL/*1*/, true, false);
		}

		//// RVA: 0x177A664 Offset: 0x177A664 VA: 0x177A664
		private void PopupShowEpisode(int episodeId, LayoutPopupAddEpisode.Type type, Action callback)
		{
			m_newEpisodeSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_newEpisodeSetting.EpisodeId = episodeId;
			m_newEpisodeSetting.Type = type;
            PopupWindowControl cont = null;
			cont = PopupWindowManager.Show(m_newEpisodeSetting, (PopupWindowControl control, PopupButton.ButtonType buttonType, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0x177D10C
				if (callback != null)
					callback();
			}, null, () =>
			{
				//0x177D120
				GameManager.Instance.StartCoroutineWatched(Co_ShowTutorial_39(cont));
			}, null);
        }

		//// RVA: 0x177A910 Offset: 0x177A910 VA: 0x177A910
		private void PopupShowAddScrollEpisode(List<int> episodeIds, LayoutPopupAddEpisode.Type type, Action callback)
		{
			m_newEpisodeScrollSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_newEpisodeScrollSetting.EpisodeIds = episodeIds;
			m_newEpisodeScrollSetting.Type = type;
            PopupWindowControl cont = null;
			cont = PopupWindowManager.Show(m_newEpisodeScrollSetting, (PopupWindowControl control, PopupButton.ButtonType buttonType, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0x177D1EC
				if (callback != null)
					callback();
			}, null, () =>
			{
				//0x177D200
				GameManager.Instance.StartCoroutineWatched(Co_ShowTutorial_39(cont));
			}, null);
        }

		//// RVA: 0x177ABBC Offset: 0x177ABBC VA: 0x177ABBC
		private void PopupShowList(List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> list, Action callback)
		{
			if(list.Count < 1)
			{
				if(callback != null)
					callback();
			}
			else
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				GONMPHKGKHI_RewardView.CECMLGBLHHG type = GONMPHKGKHI_RewardView.CECMLGBLHHG.INJNLJHGGKB_4;
				if(list[0] is GONMPHKGKHI_RewardView.GCHFDJMNCAF)
					type = GONMPHKGKHI_RewardView.CECMLGBLHHG.JCGKGFLCKCP_8;
				m_overlapListSetting.TitleText = bk.GetMessageByLabel("popup_record_plate_008");
				m_overlapListSetting.WindowSize = list.Count == 1 ? SizeType.Small : SizeType.Large;
				m_overlapListSetting.Type = type;
				m_overlapListSetting.List = list;
				m_overlapListSetting.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				PopupWindowManager.Show(m_overlapListSetting, (PopupWindowControl control, PopupButton.ButtonType buttonType, PopupButton.ButtonLabel buttonLabel) =>
				{
					//0x177D2CC
					if(callback != null)
						callback();
				}, null, null, ShowTutorial_21, true, true, false, null, null, (PopupWindowControl.SeType seType) =>
				{
					//0x177CFE4
					if(seType == PopupWindowControl.SeType.WindowOpen && !RecordPlateUtility.IsResultConfirm)
					{
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
						return true;
					}
					return false;
				});
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70BD2C Offset: 0x70BD2C VA: 0x70BD2C
		//// RVA: 0x177B0D0 Offset: 0x177B0D0 VA: 0x177B0D0
		public IEnumerator ListPhase(List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> highList, List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> infoList, Action callback)
		{
			//0x177EA90
			GameManager.Instance.NowLoading.Show();
			if(infoList.Count > 0)
			{
				List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> reward = infoList.FindAll((GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo _) =>
				{
					//0x177D0C8
					return _.IPMJIODJGBC == GONMPHKGKHI_RewardView.CECMLGBLHHG.AGLFBCCGHJM_2;
				});
				if(reward.Count > 0)
				{
					yield return Co.R(LoadLayoutNewEpisodeSetup(GONMPHKGKHI_RewardView.CECMLGBLHHG.AGLFBCCGHJM_2, null));
				}
			}
			GameManager.Instance.NowLoading.Hide();
			bool isWait = true;
			PopupShowList(infoList, () =>
			{
				//0x177D2E8
				isWait = false;
			});
			while(isWait)
				yield return null;
			if(callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70BDA4 Offset: 0x70BDA4 VA: 0x70BDA4
		//// RVA: 0x177B1B0 Offset: 0x177B1B0 VA: 0x177B1B0
		public IEnumerator RarityUpPhase(List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> highList, Action callback)
		{
			int i;

			//0x1781078
			if(highList.Count < 1)
				yield break;
			IsShowRarityUp = true;
			GameManager.Instance.NowLoading.Show();
			bool isLoading = false;
			mb.StartCoroutineWatched(LoadLayoutPlate(() =>
			{
				//0x177D2FC
				isLoading = true;
			}));
			while(!isLoading)
				yield return null;
			isLoading = false;
			mb.StartCoroutineWatched(InitializeSceneCard(() =>
			{
				//0x177D308
				isLoading = true;
			}));
			while(!isLoading)
				yield return null;
			isLoading = false;
			mb.StartCoroutineWatched(LoadLayoutPlateLvup(() =>
			{
				//0x177D314
				isLoading = true;
			}));
			while(!isLoading)
				yield return null;
			GameManager.Instance.NowLoading.Hide();
			m_overlapLvup.transform.SetParent(CanvasParent.transform, false);
			m_overlapLvup.transform.SetAsLastSibling();
			for(i = 0; i < highList.Count; i++)
			{
				if(MenuScene.Instance != null)
					MenuScene.Instance.RaycastDisable();
				m_overlapLvup.SetStatus(highList[i], m_sceneCard, m_sceneFrame);
				while(IsLoadingSceneCard())
					yield return null;
				bool isWait = true;
				m_overlapLvup.In();
				m_overlapLvup.CallbackAnimEnd = () =>
				{
					//0x177D328
					isWait = false;
				};
				while(isWait)
					yield return null;
				if(MenuScene.Instance != null)
					MenuScene.Instance.RaycastEnable();
				TerminatedSceneCard(highList);
			}
			m_overlapLvup.transform.SetParent(Parent.transform, false);
			if(callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70BE1C Offset: 0x70BE1C VA: 0x70BE1C
		//// RVA: 0x177B290 Offset: 0x177B290 VA: 0x177B290
		public IEnumerator SkillEvolutionPhase(List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> highList, Action callback)
		{
			GCIJNCFDNON_SceneInfo view1; // 0x1C
			GCIJNCFDNON_SceneInfo view2; // 0x20
			int i; // 0x24

			//0x1781B00
			if(highList.Count < 1)
				yield break;
			view1 = new GCIJNCFDNON_SceneInfo();
			view2 = new GCIJNCFDNON_SceneInfo();
			m_gachaSkillUpSetting.IsCaption = false;
			m_gachaSkillUpSetting.WindowSize = SizeType.Middle;
			m_gachaSkillUpSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			for(i = 0; i < highList.Count; i++)
			{
				view1.KHEKNNFCAOI(highList[i].BCCHOBPJJKE_SceneId, null, null, 0, 0, 0, false, 0, 0);
				view2.KHEKNNFCAOI(highList[i].BCCHOBPJJKE_SceneId, null, null, 1, 0, 0, false, 0, 0);
				if(MenuScene.Instance != null)
					MenuScene.Instance.RaycastDisable();
				m_gachaSkillUpSetting.SceneId = highList[i].BCCHOBPJJKE_SceneId;
				yield return Co.R(PopupActiveSkillUP(view1, view2));
				yield return Co.R(PopupCenterSkillUP(view1, view2));
				yield return Co.R(PopupLiveSkillUP(view1, view2));
				if(MenuScene.Instance != null)
					MenuScene.Instance.RaycastEnable();
			}
			if(callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70BE94 Offset: 0x70BE94 VA: 0x70BE94
		//// RVA: 0x177B370 Offset: 0x177B370 VA: 0x177B370
		private IEnumerator PopupActiveSkillUP(GCIJNCFDNON_SceneInfo view1, GCIJNCFDNON_SceneInfo view2)
		{
			//0x17807C8
			if(view1.HGONFBDIBPM_ActiveSkillId == view2.HGONFBDIBPM_ActiveSkillId)
				yield break;
			bool isWait = true;
			m_gachaSkillUpSetting.SkillType = GCIJNCFDNON_SceneInfo.DLAMEBMGKDO.DJECFFENCND;
			PopupWindowManager.Show(m_gachaSkillUpSetting, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x177D33C
				isWait = false;
			}, null, null, null);
			while(isWait)
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70BF0C Offset: 0x70BF0C VA: 0x70BF0C
		//// RVA: 0x177B450 Offset: 0x177B450 VA: 0x177B450
		private IEnumerator PopupCenterSkillUP(GCIJNCFDNON_SceneInfo view1, GCIJNCFDNON_SceneInfo view2)
		{
			//0x1780A8C
			if(view1.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0) == view2.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0))
				yield break;
			bool isWait = true;
			m_gachaSkillUpSetting.SkillType = GCIJNCFDNON_SceneInfo.DLAMEBMGKDO.DFAPCDGNNPN;
			PopupWindowManager.Show(m_gachaSkillUpSetting, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x177D350
				isWait = false;
			}, null, null, null);
			while(isWait)
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70BF84 Offset: 0x70BF84 VA: 0x70BF84
		//// RVA: 0x177B530 Offset: 0x177B530 VA: 0x177B530
		private IEnumerator PopupLiveSkillUP(GCIJNCFDNON_SceneInfo view1, GCIJNCFDNON_SceneInfo view2)
		{
			//0x1780D80
			if(view1.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0) == view2.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0))
				yield break;
			bool isWait = true;
			m_gachaSkillUpSetting.SkillType = GCIJNCFDNON_SceneInfo.DLAMEBMGKDO.OONCLCEAICE;
			PopupWindowManager.Show(m_gachaSkillUpSetting, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x177D364
				isWait = false;
			}, null, null, null);
			while(isWait)
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70BFFC Offset: 0x70BFFC VA: 0x70BFFC
		//// RVA: 0x177B610 Offset: 0x177B610 VA: 0x177B610
		public IEnumerator KiraUpPhase(int sceneId, int baseRare, Action callback)
		{
			int _divaId; // 0x24
			bool _isPlayDivaVoice; // 0x28

			//0x177E0EC
			if(sceneId < 1)
				yield break;
			IsShowKiraUp = true;
			_divaId = 1;
			FFHPBEPOMAK_DivaInfo data = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0];
			if(data != null)
				_divaId = data.AHHJLDLAPAN_DivaId;
			int homeDiva = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId;
			if(homeDiva > 0)
				_divaId = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[homeDiva - 1].AHHJLDLAPAN_DivaId;
			GameManager.Instance.NowLoading.Show();
			bool isLoading = false;
			mb.StartCoroutineWatched(LoadLayoutPlate(() =>
			{
				//0x177D378
				isLoading = true;
			}));
			while(!isLoading)
				yield return null;
			isLoading = false;
			mb.StartCoroutineWatched(InitializeSceneCard(() =>
			{
				//0x177D384
				isLoading = true;
			}));
			while(!isLoading)
				yield return null;
			isLoading = false;
			yield return Co.R(m_kiraProduct.Co_LoadLayout(CanvasParent.transform));
			while(!m_kiraProduct.IsLayoutLoaded)
				yield return null;
			yield return Co.R(m_kiraProduct.SettingDivaVoice(_divaId));
			GameManager.Instance.NowLoading.Hide();
			m_kiraProduct.AllLayoutSetAsLastSibling();
			_isPlayDivaVoice = false;
			m_kiraProduct.SettingAnimLayout(_divaId, m_sceneCard, m_sceneFrame, sceneId, baseRare);
			while(!m_kiraProduct.IsEndSetting())
				yield return null;
			if(!_isPlayDivaVoice)
			{
				_isPlayDivaVoice = true;
				yield return Co.R(m_kiraProduct.StartDivaVoice());
			}
			//LAB_0177e78c
			yield return Co.R(m_kiraProduct.StartKiraAnimation());
			m_kiraProduct.AllLayoutHide();
			m_sceneCard.Terminated();
			m_sceneFrame.Terminated();
			yield return Co.R(m_kiraProduct.ResetDivaVoice(_divaId));
			m_kiraProduct.AllLayoutChangeParent(Parent.transform, false);
			if(callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C074 Offset: 0x70C074 VA: 0x70C074
		//// RVA: 0x177B708 Offset: 0x177B708 VA: 0x177B708
		public IEnumerator NewGetPhase(List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> infoList, Action callback)
		{
			int i;

			//0x1780374
			bool isLoading = false;
			mb.StartCoroutineWatched(LoadLayoutPlate(() =>
			{
				//0x177D398
				isLoading = true;
			}));
			while(!isLoading)
				yield return null;
			for(i = 0; i < infoList.Count; i++)
			{
				yield return Co.R(LoadLayoutNewEpisodeSetup(infoList[i].IPMJIODJGBC, null));
				bool isWait = true;
				PopupShowNewGet(infoList[i], () =>
				{
					//0x177D3AC
					isWait = false;
				});
				while (isWait)
					yield return null;
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C0EC Offset: 0x70C0EC VA: 0x70C0EC
		//// RVA: 0x177B7E8 Offset: 0x177B7E8 VA: 0x177B7E8
		public IEnumerator EpisodePhase(GONMPHKGKHI_RewardView.CECMLGBLHHG type, List<int> episodeList, Action callback)
		{
			LayoutPopupAddEpisode.Type layoutType; // 0x28
			int i; // 0x2C

			//0x177D690
			if(episodeList.Count > 0)
			{
				yield return Co.R(LoadLayoutNewEpisodeSetup(GONMPHKGKHI_RewardView.CECMLGBLHHG.AGLFBCCGHJM_2, null));
			}
			if(episodeList.Count > 0)
			{
				yield return Co.R(LoadLayoutNewEpisodeListSetup(GONMPHKGKHI_RewardView.CECMLGBLHHG.AGLFBCCGHJM_2, null));
			}
			layoutType = type == GONMPHKGKHI_RewardView.CECMLGBLHHG.BKHAAGAAIHJ_7 ? LayoutPopupAddEpisode.Type.AvailableEpisode : LayoutPopupAddEpisode.Type.AddEpisode;
			if(type == GONMPHKGKHI_RewardView.CECMLGBLHHG.AGLFBCCGHJM_2)
			{
				if(episodeList.Count > 1)
				{
					layoutType = LayoutPopupAddEpisode.Type.AddEpisodeListContent;
					bool isWait = true;
					episodeList.Sort();
					PopupShowAddScrollEpisode(episodeList, layoutType, () =>
					{
						//0x177D3C0
						isWait = false;
					});
					while(isWait)
						yield return null;
					if(callback != null)
						callback();
					yield break;
				}
			}
			for(i = 0; i < episodeList.Count; i++)
			{
				bool isWait = true;
				PopupShowEpisode(episodeList[i], layoutType, () =>
				{
					//0x177D3D4
					isWait = false;
				});
				while(isWait)
					yield return null;
				
			}
			if(callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C164 Offset: 0x70C164 VA: 0x70C164
		//// RVA: 0x177B8E0 Offset: 0x177B8E0 VA: 0x177B8E0
		public IEnumerator GetPosterPhase(List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> posterList, Action callback)
		{
			//0x177DBD0
			bool isWait = true;
			PopupShowList(posterList, () =>
			{
				//0x177D3E8
				isWait = false;
			});
			while(isWait)
				yield return null;
			if(callback != null)
				callback();
		}

		// RVA: 0x177B9C0 Offset: 0x177B9C0 VA: 0x177B9C0 Slot: 4
		public void Dispose()
		{
			foreach(var k in m_bundleCounter)
			{
				for(int i = 0; i < k.Value; i++)
				{
					AssetBundleManager.UnloadAssetBundle(k.Key, false);
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C1DC Offset: 0x70C1DC VA: 0x70C1DC
		//// RVA: 0x177BC20 Offset: 0x177BC20 VA: 0x177BC20
		private IEnumerator LoadLayoutNewEpisodeSetup(GONMPHKGKHI_RewardView.CECMLGBLHHG type, Action callback)
		{
			//0x177FB04
			if(type == GONMPHKGKHI_RewardView.CECMLGBLHHG.AGLFBCCGHJM_2/*2*/)
			{
				bool isLoading = false;
				GameManager.Instance.NowLoading.Show();
				isLoading = false;
				mb.StartCoroutineWatched(LoadLayoutNewEpisode(() =>
				{
					//0x177D3FC
					isLoading = true;
				}));
				while (!isLoading)
					yield return null;
				GameManager.Instance.NowLoading.Hide();
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C254 Offset: 0x70C254 VA: 0x70C254
		//// RVA: 0x177BD00 Offset: 0x177BD00 VA: 0x177BD00
		private IEnumerator LoadLayoutNewEpisodeListSetup(GONMPHKGKHI_RewardView.CECMLGBLHHG type, Action callback)
		{
			//0x177F7B0
			if(type == GONMPHKGKHI_RewardView.CECMLGBLHHG.AGLFBCCGHJM_2)
			{
				bool isLoading = false;
				GameManager.Instance.NowLoading.Show();
				mb.StartCoroutineWatched(LoadLayoutNewEpisodeList(() =>
				{
					//0x177D410
					isLoading = true;
				}));
				while(!isLoading)
					yield return null;
				GameManager.Instance.NowLoading.Hide();
			}
			//LAB_0177fa14
			if(callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C2CC Offset: 0x70C2CC VA: 0x70C2CC
		//// RVA: 0x177BDE0 Offset: 0x177BDE0 VA: 0x177BDE0
		private IEnumerator LoadLayoutPlate(Action callback)
		{
			//0x177FE58
			if(m_overlapSetting.Content == null)
			{
				m_overlapSetting.m_parent = Parent.transform;
				m_overlapSetting.IsCaption = false;
				m_overlapSetting.WindowSize = SizeType.Small;
				yield return Co.R(LoadLayout(m_overlapSetting.BundleName, m_overlapSetting.AssetName, (GameObject instance) =>
				{
					//0x177CB64
					if (Parent != null)
						instance.transform.SetParent(Parent.transform, false);
					PopupRecordPlateOverlapContent content = instance.GetComponent<PopupRecordPlateOverlapContent>();
					if(content != null)
					{
						m_overlapSetting.SetContent(content.gameObject);
					}
				}));
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C344 Offset: 0x70C344 VA: 0x70C344
		//// RVA: 0x177BEA8 Offset: 0x177BEA8 VA: 0x177BEA8
		private IEnumerator LoadLayoutPlateLvup(Action callback)
		{
			//0x1780160
			if(m_overlapLvup == null)
			{
				yield return Co.R(LoadLayout("ly/073.xab", "root_gacha_overlap_plate_lvup_layout_root", (GameObject instance) =>
				{
					//0x177CD18
					if(Parent != null)
					{
						instance.transform.SetParent(Parent.transform, false);
					}
					m_overlapLvup = instance.GetComponent<LayoutOverlapPlateLvup>();
				}));
			}
			if(callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C3BC Offset: 0x70C3BC VA: 0x70C3BC
		//// RVA: 0x177BF70 Offset: 0x177BF70 VA: 0x177BF70
		private IEnumerator LoadLayoutNewEpisode(Action callback)
		{
			//0x177F208
			if(m_newEpisodeSetting.Content == null)
			{
				m_newEpisodeSetting.m_parent = Parent.transform;
				m_newEpisodeSetting.IsCaption = false;
				m_newEpisodeSetting.WindowSize = SizeType.Middle;
				yield return Co.R(LoadLayout(m_newEpisodeSetting.BundleName, m_newEpisodeSetting.AssetName, (GameObject instance) =>
				{
					//0x177CE44
					if(Parent != null)
					{
						instance.transform.SetParent(Parent.transform, false);
						m_newEpisodeSetting.SetContent(instance);
					}
				}));
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C434 Offset: 0x70C434 VA: 0x70C434
		//// RVA: 0x177C038 Offset: 0x177C038 VA: 0x177C038
		private IEnumerator LoadLayoutNewEpisodeList(Action callback)
		{
			//0x177F510
			if(m_newEpisodeScrollSetting.Content == null)
			{
				m_newEpisodeScrollSetting.m_parent = Parent.transform;
				m_newEpisodeScrollSetting.IsCaption = false;
				m_newEpisodeScrollSetting.WindowSize = SizeType.Middle;
				yield return Co.R(m_newEpisodeScrollSetting.LoadAssetBundlePrefab(Parent.transform));
			}
			if(callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C4AC Offset: 0x70C4AC VA: 0x70C4AC
		//// RVA: 0x177C100 Offset: 0x177C100 VA: 0x177C100
		private IEnumerator InitializeSceneCard(Action callback)
		{
			//0x177DDDC
			if(m_sceneCard != null)
			{
				yield return Co.R(m_sceneCard.Initialize(false));
			}
			if(callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C524 Offset: 0x70C524 VA: 0x70C524
		//// RVA: 0x177C1C8 Offset: 0x177C1C8 VA: 0x177C1C8
		//private IEnumerator IsReadyLayoutRuntime(List<LayoutUGUIScriptBase> scriptBase) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70C59C Offset: 0x70C59C VA: 0x70C59C
		//// RVA: 0x177C274 Offset: 0x177C274 VA: 0x177C274
		private IEnumerator LoadLayout(string bundleName, string assetName, Action<GameObject> callback)
		{
			XeSys.FontInfo font; // 0x24
			AssetBundleLoadLayoutOperationBase operation; // 0x28

			//0x177EF48
			font = GameManager.Instance.GetSystemFont();
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, assetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x177D424
				callback(instance);
			}));
			AddBundleCounter(bundleName);
		}

		//// RVA: 0x177C37C Offset: 0x177C37C VA: 0x177C37C
		private void AddBundleCounter(string bundleName)
		{
			if(m_bundleCounter.ContainsKey(bundleName))
			{
				m_bundleCounter[bundleName]++;
			}
			else
			{
				m_bundleCounter.Add(bundleName, 1);
			}
		}

		//// RVA: 0x177C490 Offset: 0x177C490 VA: 0x177C490
		public void LoadAssetBundle()
		{
			IsLoadBundle = false;
			GameManager.Instance.StartCoroutineWatched(UnionBundle());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C634 Offset: 0x70C634 VA: 0x70C634
		//// RVA: 0x177C548 Offset: 0x177C548 VA: 0x177C548
		private IEnumerator UnionBundle()
		{
			int i;

			//0x1782228
			for(i = 0; i < m_bundleNames.Length; i++)
			{
				UnionAssetBundleLoadOperation operation = AssetBundleManager.LoadUnionAssetBundle(m_bundleNames[i]);
				AddBundleCounter(m_bundleNames[i]);
				yield return Co.R(operation);
			}
			IsLoadBundle = true;
		}

		//// RVA: 0x177B9C4 Offset: 0x177B9C4 VA: 0x177B9C4
		//public void UnloadAssetBundle() { }

		//// RVA: 0x177A388 Offset: 0x177A388 VA: 0x177A388
		private void SetupSceneCard()
		{
			m_sceneCard = new SceneCardTextureCache();
			m_sceneFrame = new SceneFrameTextureCache();
		}

		//// RVA: 0x177A21C Offset: 0x177A21C VA: 0x177A21C
		//private void SceneCardUpdete() { }

		//// RVA: 0x177C5F4 Offset: 0x177C5F4 VA: 0x177C5F4
		private bool IsLoadingSceneCard()
		{
			return m_sceneCard.IsLoading() || m_sceneFrame.IsLoading();
		}

		//// RVA: 0x177C650 Offset: 0x177C650 VA: 0x177C650
		private void TerminatedSceneCard(List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> highList)
		{
			if(m_sceneType == RecordPlateUtility.eSceneType.Gacha)
			{
				if(highList.Count < 2)
					return;
			}
			m_sceneCard.Terminated();
			m_sceneFrame.Terminated();
		}

		//// RVA: 0x177C72C Offset: 0x177C72C VA: 0x177C72C
		private void ShowTutorial_21()
		{
			GameManager.Instance.StartCoroutineWatched(TutorialManager.TryShowTutorialCoroutine(CheckTutorialFunc_21));
		}

		//// RVA: 0x177C850 Offset: 0x177C850 VA: 0x177C850
		private bool CheckTutorialFunc_21(TutorialConditionId conditionId)
		{
			if(conditionId != TutorialConditionId.Condition21)
				return false;
			if(m_sceneType == RecordPlateUtility.eSceneType.RarityUp)
				return false;
			return IsShowRarityUp;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70C6AC Offset: 0x70C6AC VA: 0x70C6AC
		//// RVA: 0x177C888 Offset: 0x177C888 VA: 0x177C888
		private IEnumerator Co_ShowTutorial_39(PopupWindowControl control)
		{
			//0x177D4A8
			control.InputDisable();
			yield return TutorialManager.TryShowTutorialCoroutine(CheckTutorialFunc_39);
			control.InputEnable();
		}

		//// RVA: 0x177C950 Offset: 0x177C950 VA: 0x177C950
		private bool CheckTutorialFunc_39(TutorialConditionId conditionId)
		{
			return conditionId == TutorialConditionId.Condition39;
		}
	}
}
