using mcrs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class BingoRewardSelectScene : TransitionRoot
	{
		private int xor = GNGMCIAIKMA.FBGGEFFJJHB; // 0x48
		private long xorl = GNGMCIAIKMA.BBEGLBMOBOF; // 0x50
		private const int BGM_ID = 1029;
		private int bingoId; // 0x58
		private LayoutBingoRewardSelect m_layout; // 0x5C
		private bool IsAssetLoaded; // 0x60
		private JJPEIELNEJB m_view; // 0x64
		private List<JJPEIELNEJB.LKDLJCCJJNK> m_rewardList; // 0x68
		private bool IsInitialize; // 0x6C
		private int list_no_; // 0x70
		private const float s_ScrollSec = 0.2f;
		private bool IsStartTransition; // 0x74

		public int list_no { get { return xor ^ list_no_; } set { list_no_ = xor ^ value; } } //0x10A1DC4 0x10A1DD4

		// RVA: 0x10A1DE4 Offset: 0x10A1DE4 VA: 0x10A1DE4
		private void Start()
		{
			IsReady = true;
			list_no = 1;
		}

		// RVA: 0x10A1E0C Offset: 0x10A1E0C VA: 0x10A1E0C
		private void Update()
		{
			return;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CA68C Offset: 0x6CA68C VA: 0x6CA68C
		//// RVA: 0x10A1E10 Offset: 0x10A1E10 VA: 0x10A1E10
		private IEnumerator Co_initialize(int id)
		{
			//0x10A3D9C
			IsInitialize = false;
			IsStartTransition = false;
			m_view = new JJPEIELNEJB(id);
			m_rewardList = m_view.NHPHOKNJNAH.FKDIMODKKJD();
			list_no = m_view.NHPHOKNJNAH.FOAPHMMBKDM;
			m_layout.onScrollRepeated = OnScrollRepeated;
			m_layout.onScrollUpdated = OnScrollUpdated;
			m_layout.onScrollEnded = OnScrollEnded;
			m_layout.onScrollStarted = OnScrollStarted;
			m_layout.onSelectionChanged = OnSelectionChanged;
			m_layout.onClickFlowButton = OnClickFlowButton;
			m_layout.LayoutSetting(list_no, m_rewardList.Count, GNGMCIAIKMA.HHCJCDFCLOB.EHFLAKIFPOO(id), () =>
			{
				//0x10A2E48
				if (!IsStartTransition)
				{
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					m_layout.ScrollDisable();
					int idx = 0;
					if(list_no > 0)
					{
						if (list_no <= m_rewardList.Count)
							idx = list_no - 1;
					}
					JJPEIELNEJB.LKDLJCCJJNK reward = m_rewardList[idx];
					PopupBingoRewardSelectSetting s = new PopupBingoRewardSelectSetting();
					s.TitleText = bk.GetMessageByLabel("bingo_reward_select_conf_title");
					s.sceneId = reward.BCCHOBPJJKE_SceneId;
					s.rare = reward.BOCDGDKMMIP_Rarity;
					s.select_msg = bk.GetMessageByLabel("bingo_reward_select_conf_text");
					s.WindowSize = SizeType.Middle;
					s.IsCaption = true;
					s.Buttons = new ButtonInfo[2]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					PopupWindowManager.Show(s, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0x10A360C
						if(label == PopupButton.ButtonLabel.Cancel)
						{
							m_layout.ScrollEnable();
						}
						else if(label == PopupButton.ButtonLabel.Ok)
						{
							if(GNGMCIAIKMA.HHCJCDFCLOB != null)
							{
								NFMHCLHEMHB_Bingo.CCGKCGJKADC bingo = GNGMCIAIKMA.HHCJCDFCLOB.MENDFPNPAAO_GetSaveBingo(bingoId);
								bingo.AHCFGOGCJKI_St.EIHOBHDKCDB_RId = reward.PPFNGGCBJKC;
								bingo.AHCFGOGCJKI_St.AHHJLDLAPAN_Dv = reward.AHHJLDLAPAN_DivaId;
								bingo.AHCFGOGCJKI_St.DAJGPBLEEOB_Mdl = reward.DAJGPBLEEOB_CostumeId;
								MenuScene.SaveRequest();
								IsStartTransition = true;
							}
							MenuScene.Instance.Mount(TransitionUniqueId.QUEST_BINGOMISSITON, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
						}
					}, null, null, null);
				}
			});
			m_layout.initializeScroll();
			m_layout.ScrollDisable();
			yield return Co.R(DivaIconDownload());
			yield return Co.R(SceneCardDownload());
			IsInitialize = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CA704 Offset: 0x6CA704 VA: 0x6CA704
		//// RVA: 0x10A1ED8 Offset: 0x10A1ED8 VA: 0x10A1ED8
		private IEnumerator DivaIconDownload()
		{
			KDLPEDBKMID install;
			bool InstallCheck;

			//0x10A43DC
			install = KDLPEDBKMID.HHCJCDFCLOB;
			InstallCheck = false;
			for (int i = 0; i < m_rewardList.Count; i++)
			{
				InstallCheck |= install.BDOFDNICMLC_StartInstallIfNeeded(DivaIconTextureCache.GetDivaStandingCostumeIconPath(m_rewardList[i].AHHJLDLAPAN_DivaId, m_rewardList[i].DAJGPBLEEOB_CostumeId));
			}
			install.OFLDICKPNFD(true, () =>
			{
				//0x10A3398
				MenuScene.Instance.GotoTitle();
			});
			yield return null;
			if (!InstallCheck)
				yield break;
			while (install.LNHFLJBGGJB_IsRunning)
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CA77C Offset: 0x6CA77C VA: 0x6CA77C
		//// RVA: 0x10A1F84 Offset: 0x10A1F84 VA: 0x10A1F84
		private IEnumerator SceneCardDownload()
		{
			KDLPEDBKMID install;
			bool InstallCheck;

			//0x10A482C
			install = KDLPEDBKMID.HHCJCDFCLOB;
			InstallCheck = false;
			SceneIconTextureCache t = new SceneIconTextureCache();
			for (int i = 0; i < m_rewardList.Count; i++)
			{
				t.TryInstall(m_rewardList[i].BCCHOBPJJKE_SceneId, 1);
				t.TryInstall(m_rewardList[i].BCCHOBPJJKE_SceneId, 2);
				InstallCheck = true;
			}
			install.OFLDICKPNFD(true, () =>
			{
				//0x10A3434
				MenuScene.Instance.GotoTitle();
			});
			yield return null;
			if (!InstallCheck)
				yield break;
			while (install.LNHFLJBGGJB_IsRunning)
				yield return null;
		}

		// RVA: 0x10A2030 Offset: 0x10A2030 VA: 0x10A2030 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			if (GNGMCIAIKMA.HHCJCDFCLOB != null)
				bingoId = GNGMCIAIKMA.HHCJCDFCLOB.MGAHOPFMKHB_GetBingoId();
			this.StartCoroutineWatched(AssetLoad());
		}

		// RVA: 0x10A2108 Offset: 0x10A2108 VA: 0x10A2108 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return IsAssetLoaded;
		}

		// RVA: 0x10A2110 Offset: 0x10A2110 VA: 0x10A2110 Slot: 18
		protected override void OnPostSetCanvas()
		{
			base.OnPostSetCanvas();
			this.StartCoroutineWatched(Co_initialize(bingoId));
		}

		// RVA: 0x10A2144 Offset: 0x10A2144 VA: 0x10A2144 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return IsInitialize;
		}

		// RVA: 0x10A214C Offset: 0x10A214C VA: 0x10A214C Slot: 14
		protected override void OnDestoryScene()
		{
			base.OnDestoryScene();
		}

		// RVA: 0x10A2154 Offset: 0x10A2154 VA: 0x10A2154 Slot: 21
		protected override void OnOpenScene()
		{
			base.OnOpenScene();
			m_layout.Enter();
			if(IsBingoMissionHelp())
			{
				this.StartCoroutineWatched(StartHelp());
			}
			else
			{
				m_layout.ScrollEnable();
			}
		}

		// RVA: 0x10A2344 Offset: 0x10A2344 VA: 0x10A2344 Slot: 22
		protected override bool IsEndOpenScene()
		{
			return base.IsEndOpenScene();
		}

		// RVA: 0x10A234C Offset: 0x10A234C VA: 0x10A234C Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_layout.Leave();
			base.OnStartExitAnimation();
		}

		// RVA: 0x10A2388 Offset: 0x10A2388 VA: 0x10A2388 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_layout.RootLayoutIsPlaying();
		}

		// RVA: 0x10A23B8 Offset: 0x10A23B8 VA: 0x10A23B8 Slot: 20
		protected override bool OnBgmStart()
		{
			SoundManager.Instance.bgmPlayer.ContinuousPlay(1029, 1);
			return true;
		}

		//// RVA: 0x10A21D4 Offset: 0x10A21D4 VA: 0x10A21D4
		private bool IsBingoMissionHelp()
		{
			return !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsBingoReward);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CA7F4 Offset: 0x6CA7F4 VA: 0x6CA7F4
		//// RVA: 0x10A22B8 Offset: 0x10A22B8 VA: 0x10A22B8
		private IEnumerator StartHelp()
		{
			GameManager.PushBackButtonHandler backButtonDummy;

			//0x10A4C68
			backButtonDummy = () =>
			{
				//0x10A34D0
				return;
			};
			MenuScene.Instance.InputDisable();
			while (m_layout.RootLayoutIsPlaying())
				yield return null;
			bool isWait = true;
			yield return Co.R(TutorialManager.ShowTutorial(GNGMCIAIKMA.HHCJCDFCLOB.FIAHJAMFNPD_GetTutorialId(), null));
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsBingoReward, true);
			MenuScene.Save(() =>
			{
				//0x10A3898
				isWait = false;
			}, null);
			while (isWait)
				yield return null;
			GameManager.Instance.RemovePushBackButtonHandler(backButtonDummy);
			MenuScene.Instance.InputEnable();
			m_layout.ScrollEnable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CA86C Offset: 0x6CA86C VA: 0x6CA86C
		//// RVA: 0x10A207C Offset: 0x10A207C VA: 0x10A207C
		private IEnumerator AssetLoad()
		{
			string bundleName; // 0x18
			Font systemFont; // 0x1C
			AssetBundleLoadLayoutOperationBase operation; // 0x20

			//0x10A39B4
			if(m_layout == null)
			{
				IsAssetLoaded = false;
				bool isInitAsset = false;
				bundleName = "ly/151.xab";
				systemFont = GameManager.Instance.GetSystemFont();
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "UI_Bingo_RewardSelect");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x10A38AC
					instance.transform.SetParent(transform, false);
					m_layout = instance.GetComponent<LayoutBingoRewardSelect>();
					isInitAsset = true;
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				while (!isInitAsset)
					yield return null;
				IsAssetLoaded = true;
			}
		}

		//// RVA: 0x10A2458 Offset: 0x10A2458 VA: 0x10A2458
		private void OnSelectionChanged(int offset)
		{
			list_no = RepeatIndex(list_no + offset);
			if(offset != 0)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_004);
			}
			if (m_rewardList[list_no - 1].FIKLKJBHCOH_Acquired)
				m_layout.SetSelectButtonDisable();
			else
				m_layout.SetSelectButtonEnable();
		}

		//// RVA: 0x10A2640 Offset: 0x10A2640 VA: 0x10A2640
		private void OnScrollRepeated(int repeatDelta, int beginIndex, int endIndex)
		{
			if(beginIndex <= endIndex)
			{
				for(int i = 0; i + beginIndex <= endIndex; i++)
				{
					int a = RepeatIndex(beginIndex + i + list_no);
					BingoRewardContents c = m_layout.ChangeReward(i, m_rewardList[a - 1].AHHJLDLAPAN_DivaId);
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					c.TextSetting(m_rewardList[a - 1].BGIMCADKCKJ_EpisodeName, string.Format(bk.GetMessageByLabel("bingo_reward_select_scene_detail_text"), m_rewardList[a - 1].BGIMCADKCKJ_EpisodeName));
					c.ChengeLayout(m_rewardList[a - 1].AHHJLDLAPAN_DivaId);
					c.SetSceneIcon(m_rewardList[a - 1].BCCHOBPJJKE_SceneId, m_rewardList[a - 1].BOCDGDKMMIP_Rarity);
					c.SetDivaIcon(m_rewardList[a - 1].AHHJLDLAPAN_DivaId, m_rewardList[a - 1].DAJGPBLEEOB_CostumeId);
					c.SetAcquiredIconEnable(m_rewardList[a - 1].FIKLKJBHCOH_Acquired);
					c.SetexplanationText(m_rewardList[a - 1].GNKKNILFNDP_ExplanationText);
				}
			}
		}

		//// RVA: 0x10A29F0 Offset: 0x10A29F0 VA: 0x10A29F0
		private void OnScrollStarted(bool isAuto)
		{
			TextUpdate();
		}

		//// RVA: 0x10A2AA4 Offset: 0x10A2AA4 VA: 0x10A2AA4
		private void OnScrollUpdated(bool isAuto)
		{
			TextUpdate();
		}

		//// RVA: 0x10A2AA8 Offset: 0x10A2AA8 VA: 0x10A2AA8
		private void OnScrollEnded(bool isAuto)
		{
			TextUpdate();
		}

		//// RVA: 0x10A29F4 Offset: 0x10A29F4 VA: 0x10A29F4
		private void TextUpdate()
		{
			m_layout.SetSelectCountText(list_no, m_rewardList.Count);
		}

		//// RVA: 0x10A25B0 Offset: 0x10A25B0 VA: 0x10A25B0
		protected int RepeatIndex(int index)
		{
			return Math.Repeat(index, 1, m_rewardList.Count);
		}

		//// RVA: 0x10A2AAC Offset: 0x10A2AAC VA: 0x10A2AAC
		protected void OnClickFlowButton(int offset)
		{
			if(offset < 0)
			{
				MenuScene.Instance.InputDisable();
				m_layout.RequestLeftFlow(-offset, 0.2f, () =>
				{
					//0x10A34D4
					MenuScene.Instance.InputEnable();
				});
			}
			else if(offset != 0)
			{
				MenuScene.Instance.InputDisable();
				m_layout.RequestRightFlow(offset, 0.2f, () =>
				{
					//0x10A3570
					MenuScene.Instance.InputEnable();
				});
			}
		}
	}
}
