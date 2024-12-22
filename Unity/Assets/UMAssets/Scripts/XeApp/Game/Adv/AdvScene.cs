using System.Collections;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeApp.Game.Tutorial;

namespace XeApp.Game.Adv
{
	public class AdvScene : MainSceneBase
	{
		private AdvManager m_manager; // 0x28

		// RVA: 0xE569DC Offset: 0xE569DC VA: 0xE569DC Slot: 9
		protected override void DoAwake()
		{
			enableFade = false;
			m_manager = GetComponentInChildren<AdvManager>(true);
			m_manager.NetErrorHandler += GotoTitle;
		}

		// RVA: 0xE56AB4 Offset: 0xE56AB4 VA: 0xE56AB4
		public void OnDestroy()
		{
			m_manager.NetErrorHandler -= GotoTitle;
		}

		// RVA: 0xE56B5C Offset: 0xE56B5C VA: 0xE56B5C Slot: 12
		protected override bool DoUpdateEnter()
		{
			GameManager.Instance.NowLoading.Hide();
			this.StartCoroutineWatched(ProcAdv());
			return base.DoUpdateEnter();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7439DC Offset: 0x7439DC VA: 0x7439DC
		//// RVA: 0xE56C40 Offset: 0xE56C40 VA: 0xE56C40
		private IEnumerator ProcAdv()
		{
			AdvResultData advResult;

			//0xE577E4
			int advId = Database.Instance.advSetup.AdvID;
			Database.Instance.advSetup.Clear();
			yield return Co.R(m_manager.DoAdv(advId, false));
			advResult = Database.Instance.advResult;
			if (string.IsNullOrEmpty(advResult.ReturnSceneName))
				yield break;
			if(advResult.IsCallRhythmGame())
			{
				JGEOBNENMAH.EDHCNKBMLGI a = SetupGame(advResult.FreeMusicId);
				bool isSuccess = false;
				JGEOBNENMAH.HHCJCDFCLOB.OLDDILMKJND(a, () =>
				{
					//0xE577D4
					isSuccess = true;
				}, () =>
				{
					//0xE577BC
					return;
				}, () =>
				{
					//0xE577C0
					return;
				}, () =>
				{
					//0xE577C4
					return;
				}, () =>
				{
					//0xE577C8
					return;
				}, null);
				while(!isSuccess)
					yield return null;
				yield return Co.R(MenuScene.RhythmGamePreLoad(null));
			}
			else if(advResult.IsCallAdv())
			{
				Database.Instance.advSetup.Setup(advResult.AdvId);
			}
			//LAB_00e57e20
			NextScene(advResult.ReturnSceneName);
			advResult.Clear();
		}

		//// RVA: 0xE56CEC Offset: 0xE56CEC VA: 0xE56CEC
		private void GotoTitle()
		{
			PopupWindowManager.Close(null, null);
			SoundManager.Instance.bgmPlayer.Stop();
			NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.MBOIDKCMCDL = false;
			GameManager.Instance.ClearPushBackButtonHandler();
			NextScene("Title");
		}

		//// RVA: 0xE56EAC Offset: 0xE56EAC VA: 0xE56EAC
		private JGEOBNENMAH.EDHCNKBMLGI SetupGame(int musicId)
		{
			StatusData st = new StatusData();
			StatusData st2 = new StatusData();
			int isTuto = 1;
			if(musicId < 0)
			{
				Database.Instance.gameSetup.musicInfo.SetupInfoByTutorial(TutorialGameMode.Type.TutorialTwo);
				BasicTutorialManager.Log(OAGBCBBHMPF.OGBCFNIKAFI.NBFHAMJNMMG_25/*25*/);
			}
			else
			{
				isTuto = 0;
				Database.Instance.gameSetup.musicInfo.SetupInfoByFreeMusic(musicId, Difficulty.Type.Easy, false, new GameSetupData.MusicInfo.InitFreeMusicParam() { isDisableBattleEventIntermediateResult = false, returnTransitionUniqueId = 0 }, 0, 0, 0, false, false, "", 0, 0, -1, 0, 0, 1, 0);
			}
			AEGLGBOGDHH a_ = new AEGLGBOGDHH();
			a_.OBKGEDCKHHE();
			IBJAKJJICBC ib_ = new IBJAKJJICBC();
			ib_.KHEKNNFCAOI(Database.Instance.gameSetup.musicInfo.freeMusicId, false, 0, 0, 0, false, false, false);
			CMMKCEPBIHI.DIDENKKDJKI(ref a_, GameManager.Instance.ViewPlayerData.NPFCMHCCDDH, GameManager.Instance.ViewPlayerData, ib_, null, ib_.MGJKEJHEBPO_DiffInfos[0].HPBPDHPIBGN_EnemyData);
			a_.GEEDEOHGMOM(ref st);
			st2.Clear();
			st2.Copy(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.CMCKNKKCNDK_GoDivaStatus);
			st2.Add(st);
			Database.Instance.gameSetup.teamInfo.SetupInfo(st2, GameManager.Instance.ViewPlayerData, 0, ib_, null, null, null, false);
			JGEOBNENMAH.EDHCNKBMLGI j_ = new JGEOBNENMAH.EDHCNKBMLGI();
			j_.GHBPLHBNMBK_FreeMusicId = Database.Instance.gameSetup.musicInfo.freeMusicId;
			j_.KLCIIHKFPPO_StoryMusicId = Database.Instance.gameSetup.musicInfo.storyMusicId;
			j_.AKNELONELJK_Difficulty = (int)Database.Instance.gameSetup.musicInfo.difficultyType;
			j_.OALJNDABDHK = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH;
			j_.NHPGGBCKLHC_FriendData = null;
			j_.MNNHHJBBICA_GameEventType = 0;
			j_.MFJKNCACBDG_OpenEventType = 0;
			j_.OEILJHENAHN_PlayEventType = 0;
			j_.JPJMALBLKDI_Tutorial = isTuto;
			j_.KAIPAEILJHO_TicketCount = 0;
			j_.PMCGHPOGLGM_IsSkip = false;
			int luck = 0;
			for(int i = 0; i < GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				luck += DivaIconDecoration.GetEquipmentLuck(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[i], GameManager.Instance.ViewPlayerData);
			}
			StatusData st3 = new StatusData();
			st3.Clear();
			a_.DIJOPLHIMBO(j_.ENMGODCHGAC_Log, GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.JLJGCBOHJID_Status, st3, luck, 0);
			return j_;
		}
	}
}
