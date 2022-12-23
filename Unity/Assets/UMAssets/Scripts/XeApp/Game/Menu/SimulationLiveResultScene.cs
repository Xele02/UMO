using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class SimulationLiveResultScene : TransitionRoot
	{
		[SerializeField]
		private Button m_okButton; // 0x48
		private SimulationLiveResultInfo m_resultInfo; // 0x4C
		private ResultCommonLayoutController m_resultCmn; // 0x50
		private DivaSerifWindow m_serifWindow; // 0x54
		private ResultDivaControl divaControl = new ResultDivaControl(); // 0x58

		// RVA: 0xC4F5A0 Offset: 0xC4F5A0 VA: 0xC4F5A0
		private void Awake()
		{
			MenuScene.Instance.divaManager.BeginControl(divaControl);
			StartCoroutine(CO_ResourceLoad());
		}

		// RVA: 0xC4F708 Offset: 0xC4F708 VA: 0xC4F708 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			base.OnStartEnterAnimation();
			GameManager.Instance.SetFPS(60);
			EONOEHOKBEB_Music musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[Database.Instance.selectedMusic.GetSelectedMusicData().DLAEJOBELBH_MusicId - 1];
			m_resultInfo.Setup(System.Convert.ToInt32(Database.Instance.musicText.Get(musicInfo.KNMGEEFGDNI_Nam).bannerId), GetMusicTextInfo(Database.Instance.selectedMusic.GetSelectedMusicData().DLAEJOBELBH_MusicId));
			m_resultInfo.Enter();
			m_resultCmn.ChangeViewForSimulationResult();
			MenuScene.Instance.divaManager.SetActive(true, true);
			m_resultInfo.OnClickMusicButton = OnClickMusicButton;
			m_resultInfo.OnClickAnimeStoreButton = OnClickAnimeStoreButton;
			divaControl.OnResultStart();
			StartCoroutine(CO_WaitDiva());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x726DAC Offset: 0x726DAC VA: 0x726DAC
		//// RVA: 0xC4FCDC Offset: 0xC4FCDC VA: 0xC4FCDC
		private IEnumerator CO_WaitDiva()
		{
			//0x12CA308
			yield return new WaitWhile(() =>
			{
				//0xC50CF0
				return !m_resultInfo.IsPlaying();
			});
			yield return new WaitForSeconds(1.5f);
			if(Database.Instance.gameSetup.ForceSLiveResultSerifWindow() < 1)
			{
				EnterSerifWindow();
			}
			divaControl.RequestSimulationResultAnimStart();
		}

		//// RVA: 0xC4FD64 Offset: 0xC4FD64 VA: 0xC4FD64
		private void OnClickMusicButton()
		{
			TodoLogger.LogNotImplemented("SimulationLiveResultScene.OnClickMusicButton");
		}

		//// RVA: 0xC4FF58 Offset: 0xC4FF58 VA: 0xC4FF58
		private void OnClickAnimeStoreButton()
		{
			TodoLogger.LogNotImplemented("SimulationLiveResultScene.OnClickAnimeStoreButton");
		}

		//// RVA: 0xC5014C Offset: 0xC5014C VA: 0xC5014C
		private void EnterSerifWindow()
		{
			!!!
		}

		// RVA: 0xC50454 Offset: 0xC50454 VA: 0xC50454 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && !m_resultInfo.IsPlaying();
		}

		// RVA: 0xC50524 Offset: 0xC50524 VA: 0xC50524 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			m_resultInfo.Leave();
		}

		// RVA: 0xC50558 Offset: 0xC50558 VA: 0xC50558 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_resultInfo.IsPlaying();
		}

		// RVA: 0xC50584 Offset: 0xC50584 VA: 0xC50584 Slot: 16
		protected override void OnPreSetCanvas()
		{
			m_resultCmn.transform.Find("Okay").GetComponent<LayoutResultOkayButton>().SetupCallback(() =>
			{
				//0x12C971C
				return;
			}, () =>
			{
				//0x12C9720
				SoundManager.Instance.sePlayerBoot.Play(cs_se_boot.SE_BTN_001);
				MusicSelectArgs args = new MusicSelectArgs();
				args.isSimulation = true;
				args.isLine6Mode = Database.Instance.gameSetup.musicInfo.IsLine6Mode;
				MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				PGIGNJDPCAH.HIHIEBACIHJ(2);
				SoundManager.Instance.bgmPlayer.Stop();
				Database.Instance.gameResult.Reset();
			});
			base.OnPreSetCanvas();
		}

		// RVA: 0xC50810 Offset: 0xC50810 VA: 0xC50810 Slot: 15
		protected override void OnDeleteCache()
		{
			GameManager.Instance.SetFPS(30);
			if(divaControl != GameManager.Instance.GetHomeDiva())
			{
				MenuScene.Instance.divaManager.EndControl(divaControl);
			}
			if (MenuScene.Instance.divaManager.Compare(GameManager.Instance.GetHomeDiva().AHHJLDLAPAN, GameManager.Instance.GetHomeDiva().EOJIGHEFIAA, GameManager.Instance.GetHomeDiva().LHGJHJLGPBE))
				return;
			MenuScene.Instance.divaManager.Release(true);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x726E24 Offset: 0x726E24 VA: 0x726E24
		//// RVA: 0xC4F680 Offset: 0xC4F680 VA: 0xC4F680
		private IEnumerator CO_ResourceLoad()
		{
			//0x12C9FEC
			yield return StartCoroutine(CO_LoadResultInfo());
			yield return StartCoroutine(Co_LoadCommonLayout());
			yield return StartCoroutine(CO_LoadSerifWindow());
			yield return new WaitWhile(() =>
			{
				//0xC50D1C
				if(m_resultInfo != null)
				{
					if(m_resultInfo.IsLoaded())
					{
						if(m_resultCmn != null)
						{
							if(m_resultCmn.IsReady())
							{
								if(m_serifWindow != null)
								{
									return !m_serifWindow.IsLoaded();
								}
							}
						}
					}
				}
				return true;
			});
			IsReady = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x726E9C Offset: 0x726E9C VA: 0x726E9C
		//// RVA: 0xC50ADC Offset: 0xC50ADC VA: 0xC50ADC
		//private IEnumerator CO_LoadResultInfo() { }

		//[IteratorStateMachineAttribute] // RVA: 0x726F14 Offset: 0x726F14 VA: 0x726F14
		//// RVA: 0xC50B64 Offset: 0xC50B64 VA: 0xC50B64
		//private IEnumerator CO_LoadSerifWindow() { }

		//[IteratorStateMachineAttribute] // RVA: 0x726F8C Offset: 0x726F8C VA: 0x726F8C
		//// RVA: 0xC50BEC Offset: 0xC50BEC VA: 0xC50BEC
		//private IEnumerator Co_LoadCommonLayout() { }

		//// RVA: 0xC4FB88 Offset: 0xC4FB88 VA: 0xC4FB88
		//private MusicTextDatabase.TextInfo GetMusicTextInfo(int musicId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x727004 Offset: 0x727004 VA: 0x727004
		//// RVA: 0xC4FEB4 Offset: 0xC4FEB4 VA: 0xC4FEB4
		//private IEnumerator OnBuyMusicCoroutine(int musicId, MusicTextDatabase.TextInfo musicInfo) { }

		//[IteratorStateMachineAttribute] // RVA: 0x72707C Offset: 0x72707C VA: 0x72707C
		//// RVA: 0xC500A8 Offset: 0xC500A8 VA: 0xC500A8
		//private IEnumerator OnBuyAnimCoroutine(int musicId, MusicTextDatabase.TextInfo musicInfo) { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x727114 Offset: 0x727114 VA: 0x727114
		//// RVA: 0xC50EBC Offset: 0xC50EBC VA: 0xC50EBC
		//private void <CO_LoadResultInfo>b__17_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x727124 Offset: 0x727124 VA: 0x727124
		//// RVA: 0xC50F8C Offset: 0xC50F8C VA: 0xC50F8C
		//private void <CO_LoadSerifWindow>b__18_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x727134 Offset: 0x727134 VA: 0x727134
		//// RVA: 0xC5105C Offset: 0xC5105C VA: 0xC5105C
		//private void <Co_LoadCommonLayout>b__19_0(GameObject instance) { }
	}
}
