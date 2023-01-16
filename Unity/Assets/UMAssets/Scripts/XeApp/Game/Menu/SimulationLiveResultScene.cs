using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections;
using System.Text;
using XeSys;
using mcrs;
using XeApp.Core;

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
			FFHPBEPOMAK_DivaInfo divaInfo = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC[MenuScene.Instance.divaManager.DivaId - 1];
			m_serifWindow.SetTitle(divaInfo.OPFGFINHFCE_DivaName);
			StringBuilder str = new StringBuilder();
			str.Clear();
			str.AppendFormat("diva{0:D3}", divaInfo.AHHJLDLAPAN_DivaId);
			m_serifWindow.SetText(MessageManager.Instance.GetBank(str.ToString()).GetMessageByLabel("simulation_result_01"));
			m_serifWindow.Enter();
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
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				MusicSelectArgs args = new MusicSelectArgs();
				args.isSimulation = true;
				args.isLine6Mode = Database.Instance.gameSetup.musicInfo.IsLine6Mode;
				MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				PGIGNJDPCAH.HIHIEBACIHJ(PGIGNJDPCAH.FELLIEJEPIJ.NADCOIBMMJM/*2*/);
				SoundManager.Instance.bgmPlayer.Stop();
				Database.Instance.gameResult.Reset();
			});
			base.OnPreSetCanvas();
		}

		// RVA: 0xC50810 Offset: 0xC50810 VA: 0xC50810 Slot: 15
		protected override void OnDeleteCache()
		{
			GameManager.Instance.SetFPS(30);
			if(divaControl != null)
			{
				MenuScene.Instance.divaManager.EndControl(divaControl);
			}
			if (MenuScene.Instance.divaManager.Compare(GameManager.Instance.GetHomeDiva().AHHJLDLAPAN_DivaId, GameManager.Instance.GetHomeDiva().EOJIGHEFIAA_GetHomeDivaPrismCostumeId(), GameManager.Instance.GetHomeDiva().LHGJHJLGPBE_GetHomeDivaColorId()))
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
		private IEnumerator CO_LoadResultInfo()
		{
			string bundleName;
			Font font;
			AssetBundleLoadLayoutOperationBase op;

			//0x12C9A2C
			bundleName = "ly/108.xab";
			font = GameManager.Instance.GetSystemFont();
			op = AssetBundleManager.LoadLayoutAsync(bundleName, "S_LiveResult");
			yield return op;
			yield return op.InitializeLayoutCoroutine(font, (GameObject instance) => {
				//0xC50EBC
				instance.transform.SetParent(transform, false);
				m_resultInfo = instance.GetComponent<SimulationLiveResultInfo>();
			});
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x726F14 Offset: 0x726F14 VA: 0x726F14
		//// RVA: 0xC50B64 Offset: 0xC50B64 VA: 0xC50B64
		private IEnumerator CO_LoadSerifWindow()
		{
			string bundleName;
			Font font;
			AssetBundleLoadLayoutOperationBase op;

			//0x12C9D0C
			bundleName = "ly/032.xab";
			font = GameManager.Instance.GetSystemFont();
			op = AssetBundleManager.LoadLayoutAsync(bundleName, "root_cmn_balloon_layout_root");
			yield return op;
			yield return op.InitializeLayoutCoroutine(font, (GameObject instance) => {
				//0xC50F8C
				instance.transform.SetParent(transform, false);
				m_serifWindow = instance.GetComponent<DivaSerifWindow>();
			});
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x726F8C Offset: 0x726F8C VA: 0x726F8C
		//// RVA: 0xC50BEC Offset: 0xC50BEC VA: 0xC50BEC
		private IEnumerator Co_LoadCommonLayout()
		{
			string bundleName;
			AssetBundleLoadLayoutOperationBase lytAssetOp;

			//0x12CA59C
			bundleName = "ly/022.xab";
			lytAssetOp = AssetBundleManager.LoadLayoutAsync(bundleName, "UI_ResultCommon");
			yield return lytAssetOp;
			yield return lytAssetOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) => {
				//0xC5105C
				instance.transform.SetParent(transform, false);
				m_resultCmn = instance.GetComponent<ResultCommonLayoutController>();
			});
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
		}

		//// RVA: 0xC4FB88 Offset: 0xC4FB88 VA: 0xC4FB88
		private MusicTextDatabase.TextInfo GetMusicTextInfo(int musicId)
		{
			return Database.Instance.musicText.Get(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(musicId).KNMGEEFGDNI_Nam);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x727004 Offset: 0x727004 VA: 0x727004
		//// RVA: 0xC4FEB4 Offset: 0xC4FEB4 VA: 0xC4FEB4
		//private IEnumerator OnBuyMusicCoroutine(int musicId, MusicTextDatabase.TextInfo musicInfo) { }

		//[IteratorStateMachineAttribute] // RVA: 0x72707C Offset: 0x72707C VA: 0x72707C
		//// RVA: 0xC500A8 Offset: 0xC500A8 VA: 0xC500A8
		//private IEnumerator OnBuyAnimCoroutine(int musicId, MusicTextDatabase.TextInfo musicInfo) { }
	}
}
