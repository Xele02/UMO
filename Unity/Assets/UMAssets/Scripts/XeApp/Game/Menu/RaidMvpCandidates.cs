using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidMvpCandidatesArgs : TransitionArgs
	{
		public PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ bossInfo; // 0x8

		// RVA: 0x1BD460C Offset: 0x1BD460C VA: 0x1BD460C
		public RaidMvpCandidatesArgs(PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ _bossInfo)
		{
			bossInfo = _bossInfo;
		}
	}

	public class RaidMvpCandidates : TransitionRoot
	{
		private RaidMvpLayout m_mvpLayout; // 0x48
		private List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ.CALIFIMGGMD> m_rankingList; // 0x4C
		private bool m_isInitialized; // 0x50
		private PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ m_boss_info; // 0x54

		// RVA: 0x1BD23F0 Offset: 0x1BD23F0 VA: 0x1BD23F0
		private void Start()
		{
			m_isInitialized = false;
			m_rankingList = new List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ.CALIFIMGGMD>();
			this.StartCoroutineWatched(Co_LoadLayout());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x715014 Offset: 0x715014 VA: 0x715014
		// // RVA: 0x1BD251C Offset: 0x1BD251C VA: 0x1BD251C
		private IEnumerator Co_Initialize()
		{
			PKNOKJNLPOE_EventRaid raidController;

			//0x1BD3294
			m_isInitialized = false;
			RaidMvpCandidatesArgs arg = Args as RaidMvpCandidatesArgs;
			if(arg != null)
				m_boss_info = arg.bossInfo;
			raidController = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			if(m_boss_info == null)
			{
				m_boss_info = raidController.KACFOENGHIK();
			}
			bool isDone = false;
			raidController.PDPFNKCIJOP(m_boss_info, () =>
			{
				//0x1BD31D0
				isDone = true;
			}, () =>
			{
				//0x1BD31DC
				isDone = true;
				MenuScene.Instance.GotoTitle();
			});
			while(!isDone)
				yield return null;
			isDone = false;
			GameManager.Instance.RaidBossTextureCache.LoadForBossIcon(m_boss_info.HPPDFBKEJCG_BgId, (IiconTexture icon) =>
			{
				//0x1BD3284
				isDone = true;
			});
			while(!isDone)
				yield return null;
			m_mvpLayout.SetBossName(raidController.AGEJGHGEGFF_GetBossName(m_boss_info.INDDJNMPONH_Type));
			m_mvpLayout.SetBossRank(m_boss_info.FJOLNJLLJEJ_Rank);
			m_mvpLayout.SetBossImage(m_boss_info.HPPDFBKEJCG_BgId);
			m_mvpLayout.SetPlayerDamage(m_boss_info.AEGFDINOACE_PlayerDamage);
			m_mvpLayout.PushProfileButtonListner += OnClickProfileButton;
			m_rankingList.Clear();
			for(int i = 0; i < m_boss_info.IBGEJLJIAFD; i++)
			{
				m_rankingList.Add(m_boss_info.PMPMADPEGDE(i));
			}
			m_mvpLayout.UpdateContent(m_rankingList);
			m_isInitialized = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71508C Offset: 0x71508C VA: 0x71508C
		// // RVA: 0x1BD2490 Offset: 0x1BD2490 VA: 0x1BD2490
		private IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x14
			FontInfo systemFont; // 0x18
			int bundleLoadCount; // 0x1C
			AssetBundleLoadLayoutOperationBase lytOp; // 0x20

			//0x1BD4190
			bundleName = new StringBuilder();
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/039.xab");
			bundleLoadCount = 0;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_list_raid_mvp_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1BD30F8
				instance.transform.SetParent(transform, false);
				m_mvpLayout = instance.GetComponent<RaidMvpLayout>();
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			yield return this.StartCoroutineWatched(m_mvpLayout.LoadScrollObjectCoroutine());
			IsReady = true;
		}

		// // RVA: 0x1BD25E8 Offset: 0x1BD25E8 VA: 0x1BD25E8
		private void OnClickProfileButton(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			EAJCBFGKKFA_FriendInfo f = new EAJCBFGKKFA_FriendInfo();
			f.KHEKNNFCAOI(m_rankingList[index]);
			ProfilDateArgs arg = new ProfilDateArgs();
			arg.data = f;
			arg.infoType = ProfilMenuLayout.InfoType.SCENE;
			arg.isFavorite = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GAAOPEGIPKA_FavoritePlayer.FFKIDMKHIOE(f.MLPEHNBNOGD_Id);
			arg.btnType = NKGJPJPHLIF.HHCJCDFCLOB.CAFHLEFMMGD_GetPlayerId() == f.MLPEHNBNOGD_Id ? ProfilMenuLayout.ButtonType.None : ProfilMenuLayout.ButtonType.Raid_Result;
			MenuScene.Instance.Call(TransitionList.Type.PROFIL, arg, true);
		}

		// RVA: 0x1BD28CC Offset: 0x1BD28CC VA: 0x1BD28CC Slot: 16
		protected override void OnPreSetCanvas()
		{
			m_isInitialized = false;
			m_mvpLayout.Hide();
			m_mvpLayout.InitializeDecoration();
			this.StartCoroutineWatched(Co_Initialize());
		}

		// RVA: 0x1BD2B3C Offset: 0x1BD2B3C VA: 0x1BD2B3C Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_isInitialized;
		}

		// RVA: 0x1BD2B44 Offset: 0x1BD2B44 VA: 0x1BD2B44 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return true;
		}

		// RVA: 0x1BD2B4C Offset: 0x1BD2B4C VA: 0x1BD2B4C Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_mvpLayout.Enter();
		}

		// RVA: 0x1BD2C14 Offset: 0x1BD2C14 VA: 0x1BD2C14 Slot: 23
		protected override void OnActivateScene()
		{
			return;
		}

		// RVA: 0x1BD2C18 Offset: 0x1BD2C18 VA: 0x1BD2C18 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_mvpLayout.IsPlaying();
		}

		// RVA: 0x1BD2C70 Offset: 0x1BD2C70 VA: 0x1BD2C70 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_mvpLayout.Leave();
		}

		// RVA: 0x1BD2D38 Offset: 0x1BD2D38 VA: 0x1BD2D38 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_mvpLayout.IsPlaying();
		}

		// RVA: 0x1BD2D64 Offset: 0x1BD2D64 VA: 0x1BD2D64 Slot: 14
		protected override void OnDestoryScene()
		{
			m_mvpLayout.Release();
			m_mvpLayout.PushProfileButtonListner -= OnClickProfileButton;
		}
	}
}
