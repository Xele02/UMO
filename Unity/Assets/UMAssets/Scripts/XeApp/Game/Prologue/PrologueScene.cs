using mcrs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.DownLoad;
using XeApp.Game.Tutorial;
using XeSys.Gfx;

namespace XeApp.Game.Prologue
{
	public class PrologueScene : MainSceneBase
	{
		private bool m_isLoding; // 0x28
		private bool m_isSkip; // 0x29
		private PrologueControl m_control; // 0x2C
		private ActionButton m_skipButton; // 0x30
		private LayoutUGUIRuntime m_skipButtonAnime; // 0x34
		private LayoutUGUIRuntime m_loadingAnime; // 0x38
		private AbsoluteLayout m_loadingProgressBarLayout; // 0x3C
		private const string ShaderBundleName = "handmade/shader.xab";
		private LayoutDownLoad m_Layout; // 0x40
		private List<int> m_kickDivaId = new List<int>() { 8, 9 }; // 0x44
		private Canvas m_prologueCanvas; // 0x48
		private bool m_isDownLoaded; // 0x4C
		private bool m_isExecution; // 0x4D
		public const string HighModeGameUiPath = "gm/if/hi.xab";
		public const string LowModeGameUiPath = "gm/if/lo.xab";
		private List<string> m_downLoadList = new List<string>(); // 0x50

		//// RVA: 0xCA6A58 Offset: 0xCA6A58 VA: 0xCA6A58
		//private bool IsNotDownloadEnded() { }

		//// RVA: 0xCA6A7C Offset: 0xCA6A7C VA: 0xCA6A7C
		private bool IsPrologueEnded()
		{
			return GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.OLDAGCNLJOI_Progress > 0;
		}

		// RVA: 0xCA6B70 Offset: 0xCA6B70 VA: 0xCA6B70 Slot: 9
		protected override void DoAwake()
		{
			base.DoAwake();
			enableFade = false;
			m_isLoding = true;
			m_prologueCanvas = GetComponent<Canvas>();
			this.StartCoroutineWatched(InitializeTutorialCoroutine());
		}

		// RVA: 0xCA6C9C Offset: 0xCA6C9C VA: 0xCA6C9C Slot: 10
		protected override void DoStart()
		{
			base.DoStart();
		}

		// RVA: 0xCA6CA4 Offset: 0xCA6CA4 VA: 0xCA6CA4 Slot: 12
		protected override bool DoUpdateEnter()
		{
			return !m_isLoding;
		}

		// RVA: 0xCA6CB8 Offset: 0xCA6CB8 VA: 0xCA6CB8
		public void OnDestroy()
		{
			AssetBundleManager.UnloadAssetBundle("handmade/shader.xab", true);
			KEHOJEJMGLJ.HHCJCDFCLOB.OEPPEGHGNNO = null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B0BA8 Offset: 0x6B0BA8 VA: 0x6B0BA8
		//// RVA: 0xCA6C14 Offset: 0xCA6C14 VA: 0xCA6C14
		private IEnumerator InitializeTutorialCoroutine()
		{
			//0xF59DC4
			bool isNetInstallManagerInitialized = false;
			KEHOJEJMGLJ.HHCJCDFCLOB.PAHGEEOFEPM_Install(KEHOJEJMGLJ.ACGGHEIMPHC.DEKNOKPEIHO_2, () =>
			{
				//0xCA8D7C
				isNetInstallManagerInitialized = true;
			}, () =>
			{
				//0xCA8D88
				isNetInstallManagerInitialized = true;
			}, 0, 0);
			while(!isNetInstallManagerInitialized)
				yield return null;
			BasicTutorialManager.Initialize();
			GameManager.Instance.IsTutorial = true;
			/*if (KDLPEDBKMID.HHCJCDFCLOB.HFMOAJDHDHJ(38))
			{
				while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
					yield return null;
			}*/
			bool needDld = false;
			yield return Co.R(KDLPEDBKMID.HHCJCDFCLOB.HFMOAJDHDHJ_Coroutine(38, (bool r) => { needDld = r; }));
			if(needDld)
			{
				while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
					yield return null;
			}
			BasicTutorialManager.SetupFirstTutorialLog();
			yield return Co.R(LoadPrologueResourceCoroutine());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B0C20 Offset: 0x6B0C20 VA: 0x6B0C20
		//// RVA: 0xCA6DA0 Offset: 0xCA6DA0 VA: 0xCA6DA0
		private IEnumerator LoadPrologueResourceCoroutine()
		{
			ShaderAssetBundleLoadOperation unionBundleOperation;

			//0xF5A218
			unionBundleOperation = AssetBundleManager.LoadShaderAssetBundle("handmade/shader.xab");
			yield return unionBundleOperation;
			yield return unionBundleOperation.PreLoadShader(new string[1] { "UiShaderVariants" });
			BasicTutorialManager.Initialize();
			if (!IsPrologueEnded())
				yield return Co.R(Co_LoadPrologue());
			m_isLoding = false;
			this.StartCoroutineWatched(ExecuteCoroutine());
		}

		//// RVA: 0xCA6E28 Offset: 0xCA6E28 VA: 0xCA6E28
		private void PushSkipButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			m_isSkip = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B0C98 Offset: 0x6B0C98 VA: 0x6B0C98
		//// RVA: 0xCA6E8C Offset: 0xCA6E8C VA: 0xCA6E8C
		private IEnumerator ExecuteCoroutine()
		{
			bool isExecPrologue; // 0x18
			ILDKBCLAFPB.MPHNGGECENI_Option option; // 0x1C
			WaitWhile layoutWait; // 0x20

			//0xCA9B60
			if(m_skipButton != null)
			{
				m_skipButton.Disable = true;
				m_skipButtonAnime.Layout.StartAllAnimGoStop("st_wait");
			}
			if (m_loadingAnime != null)
				m_loadingAnime.Layout.StartAllAnimGoStop("st_wait");
			m_isDownLoaded = false;
			m_isExecution = false;
			KEHOJEJMGLJ.HHCJCDFCLOB.OEPPEGHGNNO = InstallGuiEvent;
			option = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options;
			yield return Co.R(GameManager.Instance.ListupRhythmGameResourceFileList(1, 1, 1, 0, 38, 0, 0, m_downLoadList, 1));
			if (option.DDHCLNFPNGK_RenderQuality == 0)
				m_downLoadList.Add("gm/if/hi.xab");
			else
				m_downLoadList.Add("gm/if/lo.xab");
			int fixed_scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("fixed_scene", 3);
			m_downLoadList.AddRange(ListupSceneAssetPath(fixed_scene));
			KEHOJEJMGLJ.HHCJCDFCLOB.PAHGEEOFEPM_Install(KEHOJEJMGLJ.ACGGHEIMPHC.ANFKBNLLJFN_0, () =>
			{
				//0xCA8D9C
				if(m_skipButton != null)
				{
					m_skipButton.Disable = false;
					m_skipButtonAnime.Layout.StartAllAnimGoStop("go_in", "st_in");
				}
				if (m_loadingAnime != null)
					m_loadingAnime.Layout.StartAllAnimGoStop("go_out", "st_out");
				m_isDownLoaded = true;
			}, () =>
			{
				//0xCA8FDC
				NextScene("Title");
			}, 1, 0);
			option = null;
			while(!m_isDownLoaded)
			{
				if (m_isExecution)
				{
					break;
				}
				else
					yield return null;
			}
			if (m_isExecution)
			{
				LoadResource();
				//LAB_00caa308
				while (!DownLoadUIManager.Instance.IsLoadedLayout)
					yield return null;
				m_Layout = DownLoadUIManager.Instance.Layout;
				m_Layout.SetupDivaSelect();
				if(m_loadingAnime != null)
				{
					m_loadingAnime.Layout.StartAllAnimGoStop("go_in", "st_in");
					m_loadingAnime.Layout.Root.StartAllAnimDecoLoop();
					m_loadingProgressBarLayout = m_loadingAnime.Layout.FindViewByExId("sw_cmn_tuto02_dl_inout_anim_swfrm_dl") as AbsoluteLayout;
				}
				m_Layout.SwaipTouch.enabled = false;
			}
			//LAB_00caa5f0;
			isExecPrologue = false;
			bool isWait = false;
			if(!IsPrologueEnded())
			{
				isExecPrologue = true;
				SoundManager.Instance.bgmPlayer.FadeOut(0.6f, () =>
				{
					//0xCA9058
					isWait = false;
				});
				//LAB_00caa848;
				while (isWait)
					yield return null;
				yield return Co.R(Co_PlayPrologue());
			}
			//LAB_00caa620;
			if(!m_isDownLoaded && m_isExecution)
			{
				m_prologueCanvas.worldCamera.gameObject.SetActive(false);
				GameManager.Instance.fullscreenFader.Fade(1, 0);
				if(isExecPrologue)
				{
					SoundManager.Instance.bgmPlayer.ContinuousPlay(BgmConstant.Name.Prologue2, 1);
					SoundManager.Instance.bgmPlayer.ChangeVolume(0.4f, 0.6f, null);
				}
				yield return GameManager.Instance.WaitFadeYielder;
				layoutWait = new WaitWhile(() =>
				{
					//0xCA9064
					return m_Layout.IsPlaying();
				});
				m_Layout.EnterDownLoad();
				m_Layout.EnterVoiceButton();
				m_Layout.SwaipTouch.enabled = true;
				yield return null;
				yield return layoutWait;
				m_Layout.SetEnabledOperation(true, false);
				while (!m_isDownLoaded)
					yield return null;
				//LAB_00caa178
				while (m_Layout.IsPlaying())
					yield return null;
				GameManager.Instance.fullscreenFader.Fade(1, Color.black);
				SoundManager.Instance.bgmPlayer.ChangeVolume(1, 1, null);
				yield return GameManager.Instance.WaitFadeYielder;
			}
			//LAB_00caa62c
			GameManager.Instance.InitializeUnionData();
			while (!GameManager.Instance.IsUnionDataInitialized)
				yield return null;
			isWait = true;
			BasicTutorialManager.Instance.PreLoadResource(() =>
			{
				//0xCA90A4
				isWait = false;
			}, true);
			while (isWait)
				yield return null;
			SceneEnd();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B0D10 Offset: 0x6B0D10 VA: 0x6B0D10
		//// RVA: 0xCA6F38 Offset: 0xCA6F38 VA: 0xCA6F38
		private IEnumerator Co_LoadPrologue()
		{
			int loadCount; // 0x14
			string bundlePath; // 0x18
			AssetBundleLoadLayoutOperationBase lyOpt; // 0x1C

			//0xCA90B4
			loadCount = 0;
			bundlePath = "ly/083.xab";
			lyOpt = AssetBundleManager.LoadLayoutAsync(bundlePath, "root_cmn_tuto02_layout_root");
			yield return lyOpt;
			yield return Co.R(lyOpt.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xCA89CC
				instance.transform.SetParent(transform.GetChild(0), false);
				m_control = instance.GetComponent<PrologueControl>();
			}));
			loadCount++;
			lyOpt = AssetBundleManager.LoadLayoutAsync(bundlePath, "root_cmn_tuto02_skip_layout_root");
			yield return lyOpt;
			yield return Co.R(lyOpt.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xCA8AC0
				instance.transform.SetParent(transform.GetChild(0), false);
				instance.transform.SetAsLastSibling();
				m_skipButton = instance.GetComponentInChildren<ActionButton>(true);
				m_skipButtonAnime = instance.GetComponentInChildren<LayoutUGUIRuntime>(true);
			}));
			loadCount++;
			lyOpt = AssetBundleManager.LoadLayoutAsync(bundlePath, "root_cmn_tuto02_dl_layout_root");
			yield return lyOpt;
			yield return Co.R(lyOpt.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xCA8C40
				instance.transform.SetParent(transform.GetChild(0), false);
				instance.transform.SetAsLastSibling();
				m_loadingAnime = instance.GetComponentInChildren<LayoutUGUIRuntime>(true);
			}));
			loadCount++;
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundlePath, false);
			}
			while (!m_control.IsInitialized)
				yield return null;
			m_skipButton.AddOnClickCallback(PushSkipButton);
			m_control.BgmChangeEventHandler += BgmChange;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B0D88 Offset: 0x6B0D88 VA: 0x6B0D88
		//// RVA: 0xCA6FE4 Offset: 0xCA6FE4 VA: 0xCA6FE4
		private IEnumerator Co_PlayPrologue()
		{
			//0xCA9764
			BasicTutorialManager.Log(OAGBCBBHMPF.OGBCFNIKAFI.BABBMOJCMDM_1);
			SoundManager.Instance.bgmPlayer.Play(BgmConstant.Name.Prologue1);
			GameManager.Instance.fullscreenFader.Fade(1, 0);
			m_control.Play();
			while (m_control.IsPlaying() && !m_isSkip)
				yield return null;
			GameManager.Instance.fullscreenFader.Fade(1, Color.black);
			yield return GameManager.Instance.WaitFadeYielder;
			m_control.gameObject.SetActive(false);
		}

		//// RVA: 0xCA7090 Offset: 0xCA7090 VA: 0xCA7090
		private void SceneEnd()
		{
			int progress = GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.OLDAGCNLJOI_Progress;
			if(progress > 0)
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.AHEFHIMGIBI_PlayerData.INBCGKAFHDO(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
			}
			switch(progress)
			{
				case 1:
				case 2:
					NextScene("RhythmAdjust");
					break;
				case 3:
				case 4:
				case 5:
				case 6:
					NextScene("Menu");
					break;
				case 7:
					Database.Instance.gameSetup.musicInfo.SetupInfoByTutorial(TutorialGameMode.Type.TutorialTwo);
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.AHEFHIMGIBI_PlayerData.MFNPKIACGLM(JGEOBNENMAH.HHCJCDFCLOB, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, Database.Instance.gameSetup, Database.Instance.gameResult);
					Database.Instance.advSetup.Setup(4);
					NextScene("Menu");
					break;
				case 8:
					Database.Instance.advSetup.Setup(4);
					NextScene("Adv");
					break;
				case 9:
					Database.Instance.advSetup.Setup(5);
					NextScene("Adv");
					break;
				case 10:
					NextScene("DivaSelect");
					break;
				default:
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(1).CPGFPEDMDEH_Have = 1;
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().LHPDDGIJKNB_Reset();
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_MainDivas[0].DIPKCALNIII_Id = 1;
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_MainDivas[0].BEEAIAAJOHD_CId = 1;
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_MainDivas[0].AFNIOJHODAG_ColId = 0;
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.AHEFHIMGIBI_PlayerData.MNGKOHKKAHI(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
					Database.Instance.advSetup.Setup(1);
					Database.Instance.advResult.Setup("RhythmAdjust");
					NextScene("Adv");
					break;
			}
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NELPFCBCJAO();
			GameManager.Instance.CreateViewPlayerData();
		}

		//// RVA: 0xCA77B4 Offset: 0xCA77B4 VA: 0xCA77B4
		private void BgmChange()
		{
			SoundManager.Instance.bgmPlayer.ContinuousPlay(BgmConstant.Name.Prologue2, 1);
		}

		//// RVA: 0xCA7890 Offset: 0xCA7890 VA: 0xCA7890
		private void LoadResource()
		{
			List<int> l = new List<int>();
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas.Count; i++)
				{
					BJPLLEBHAGO_DivaInfo dInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[i];
					if(dInfo.PPEGAKEIEGM_Enabled == 2)
					{
						l.Add(dInfo.AHHJLDLAPAN_DivaId);
					}
				}
				if(GameManager.Instance.IsTutorial)
				{
					for(int i = 0; i < m_kickDivaId.Count; i++)
					{
						l.Remove(m_kickDivaId[i]);
					}
				}
			}
			DownLoadUIManager.Instance.LoadResouce(l);
		}

		//// RVA: 0xCA7BF4 Offset: 0xCA7BF4 VA: 0xCA7BF4
		private bool InstallGuiEvent(int type, float per)
		{
			switch(type)
			{
				case 1:
					m_isExecution = true;
					break;
				case 2:
					m_isDownLoaded = true;
					SetDownLoadProgressPer(null, 100);
					m_Layout.FinishDownLoad();
					break;
				case 3:
					m_Layout.SetProgressPer(per);
					SetDownLoadProgressPer(null, per);
					break;
				case 4:
					return m_Layout != null;
			}
			return false;
		}

		//// RVA: 0xCA7D34 Offset: 0xCA7D34 VA: 0xCA7D34
		private void SetDownLoadProgressPer(AbsoluteLayout layout, float per)
		{
			if (m_loadingProgressBarLayout == null)
				return;
			int a = Mathf.FloorToInt(per);
			m_loadingProgressBarLayout.StartChildrenAnimGoStop(a, a);
		}

		//// RVA: 0xCA7DF4 Offset: 0xCA7DF4 VA: 0xCA7DF4
		private List<string> ListupSceneAssetPath(int sceneId)
		{
			List<string> res = new List<string>();
			MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[sceneId - 1];
			res.Add(string.Format("ct/sc/me/01/{0:D6}_01.xab", sceneId));
			res.Add(string.Format("ct/sc/me/01/{0:D6}_02.xab", sceneId));
			res.Add(string.Format("ct/sc/me/02/{0:D6}_01.xab", sceneId));
			if(scene.PBEPKDEEBBK_AS > 0)
			{
				CDNKOFIELMK skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[scene.PBEPKDEEBBK_AS - 1];
				for(int i = 0; i < skill.EGLDFPILJLG_BuffEffectType.Length; i++)
				{
					if(skill.EGLDFPILJLG_BuffEffectType[i] != 0)
					{
						res.Add(string.Format("ct/gm/as/{0:D3}.xab", skill.EGLDFPILJLG_BuffEffectType[i]));
					}
				}
			}
			if (scene.ECKJJCGPOPN_AS2 > 0)
			{
				CDNKOFIELMK skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[scene.ECKJJCGPOPN_AS2 - 1];
				for (int i = 0; i < skill.EGLDFPILJLG_BuffEffectType.Length; i++)
				{
					if (skill.EGLDFPILJLG_BuffEffectType[i] != 0)
					{
						res.Add(string.Format("ct/gm/as/{0:D3}.xab", skill.EGLDFPILJLG_BuffEffectType[i]));
					}
				}
			}
			GCIJNCFDNON_SceneInfo sceneInfo = new GCIJNCFDNON_SceneInfo();
			sceneInfo.KHEKNNFCAOI(sceneId, null, null, 0, 0, 0, false, 0, 0);
			if(scene.KPIIIEGGPIB_LS > 0)
			{
				PPGHMBNIAEC skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[sceneInfo.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0) - 1];
				for (int i = 0; i < skill.EGLDFPILJLG_SkillBuffEffect.Length; i++)
				{
					if (skill.EGLDFPILJLG_SkillBuffEffect[i] != 0)
					{
						res.Add(string.Format("ct/gm/as/{0:D3}.xab", skill.EGLDFPILJLG_SkillBuffEffect[i]));
					}
				}
			}
			if (scene.PJKJFIOKBGJ_LS2 > 0)
			{
				PPGHMBNIAEC skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[sceneInfo.FILPDDHMKEJ_GetLiveSkillId(true, 0, 0) - 1];
				for (int i = 0; i < skill.EGLDFPILJLG_SkillBuffEffect.Length; i++)
				{
					if (skill.EGLDFPILJLG_SkillBuffEffect[i] != 0)
					{
						res.Add(string.Format("ct/gm/as/{0:D3}.xab", skill.EGLDFPILJLG_SkillBuffEffect[i]));
					}
				}
			}
			return res;
		}
	}
}
