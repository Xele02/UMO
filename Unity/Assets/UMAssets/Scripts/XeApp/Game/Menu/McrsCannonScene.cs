using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class McrsCannonScene : TransitionRoot
	{
		[SerializeField]
		private MacrossCannon m_mcrsCannonPrefab; // 0x48
		private MacrossCannon m_mcrsCannonObj; // 0x4C
		[SerializeField]
		private McrsCannonShakeObject m_mcrsCannonShakePrefab; // 0x50
		private McrsCannonShakeObject m_mcrsCannonShakeObj; // 0x54
		private bool m_isInitialize; // 0x58
		private SeriesAttr.Type series; // 0x5C
		private int m_pattern; // 0x60
		private int m_quality; // 0x64
		private bool m_isAssetLoad; // 0x68
		private bool m_isPlayingMovie; // 0x69
		private RaidResultCannonDamageLayout m_cannonDamangeLayout; // 0x6C

		// RVA: 0xEBB004 Offset: 0xEBB004 VA: 0xEBB004
		private void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_LayoutAssetLoad());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x713874 Offset: 0x713874 VA: 0x713874
		// // RVA: 0xEBB034 Offset: 0xEBB034 VA: 0xEBB034
		private IEnumerator Co_LayoutAssetLoad()
		{
			string bundleName; // 0x14
			FontInfo systemFont; // 0x18

			//0xEBC970
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName = "ly/204.xab";
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co.R(Co_LoadAssetsLayoutCannonDamageLayout(bundleName, systemFont));
			while(m_cannonDamangeLayout == null)
				yield return null;
			m_isAssetLoad = true;
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7138EC Offset: 0x7138EC VA: 0x7138EC
		// // RVA: 0xEBB0E0 Offset: 0xEBB0E0 VA: 0xEBB0E0
		private IEnumerator Co_LoadAssetsLayoutCannonDamageLayout(string bundleName, FontInfo font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xEBCC1C
			if(m_cannonDamangeLayout != null)
				yield break;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_g_r_r_damage_cc_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xEBBEF0
				m_cannonDamangeLayout = instance.GetComponent<RaidResultCannonDamageLayout>();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
		}

		// RVA: 0xEBB1C0 Offset: 0xEBB1C0 VA: 0xEBB1C0
		private void Start()
		{
			return;
		}

		// RVA: 0xEBB1C4 Offset: 0xEBB1C4 VA: 0xEBB1C4
		private void Update()
		{
			if(m_isPlayingMovie)
			{
				if(InputManager.Instance.GetInScreenTouchCount() < 1)
					return;
				m_mcrsCannonObj.End();
				m_isPlayingMovie = false;
			}
		}

		// RVA: 0xEBB29C Offset: 0xEBB29C VA: 0xEBB29C Slot: 16
		protected override void OnPreSetCanvas()
		{
			m_cannonDamangeLayout.Hide();
			m_mcrsCannonObj = Instantiate(m_mcrsCannonPrefab);
			m_mcrsCannonObj.transform.SetAsLastSibling();
			SoundManager.Instance.bgmPlayer.Stop();
			this.StartCoroutineWatched(Co_Initialize());
		}

		// RVA: 0xEBB480 Offset: 0xEBB480 VA: 0xEBB480 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			if(m_isAssetLoad)
			{
				return m_isInitialize;
			}
			return false;
		}

		// RVA: 0xEBB4A0 Offset: 0xEBB4A0 VA: 0xEBB4A0 Slot: 21
		protected override void OnOpenScene()
		{
			return;
		}

		// RVA: 0xEBB4A4 Offset: 0xEBB4A4 VA: 0xEBB4A4 Slot: 18
		protected override void OnPostSetCanvas()
		{
			m_cannonDamangeLayout.transform.SetParent(transform.parent, false);
			m_cannonDamangeLayout.transform.SetAsLastSibling();
		}

		// RVA: 0xEBB56C Offset: 0xEBB56C VA: 0xEBB56C Slot: 7
		protected override void OnDisable()
		{
			m_isInitialize = false;
			if(m_mcrsCannonObj != null)
			{
				Destroy(m_mcrsCannonObj.gameObject);
			}
			base.OnDisable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x713964 Offset: 0x713964 VA: 0x713964
		// // RVA: 0xEBB3F4 Offset: 0xEBB3F4 VA: 0xEBB3F4
		private IEnumerator Co_Initialize()
		{
			//0xEBC604
			while(!m_isAssetLoad)
				yield return null;
			MovieSetting();
			yield return this.StartCoroutineWatched(BgChange());
			yield return Co.R(m_mcrsCannonObj.Initialize(series, m_pattern, m_quality, () =>
			{
				//0xEBBF6C
				m_isPlayingMovie = false;
			}, 0.1f));
			m_isInitialize = true;
			m_mcrsCannonObj.Play();
			m_isPlayingMovie = true;
			while(m_isPlayingMovie)
				yield return null;
			GameManager.Instance.StartCoroutineWatched(Co_DamageAnime());
		}

		// // RVA: 0xEBB690 Offset: 0xEBB690 VA: 0xEBB690
		private void MovieSetting()
		{
			PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			series = ev.NNDFMCHDJOH_GetBossSerie(ev.KACFOENGHIK().INDDJNMPONH_Type);
			m_pattern = 0;
			m_quality = 2;
			m_cannonDamangeLayout.Setup(ev.KACFOENGHIK().FJOLNJLLJEJ_Rank, ev.AGEJGHGEGFF_GetBossName(ev.KACFOENGHIK().INDDJNMPONH_Type), ev.MBNLPELOLBJ().HALIDDHLNEG_MCannonDamage);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7139DC Offset: 0x7139DC VA: 0x7139DC
		// // RVA: 0xEBB894 Offset: 0xEBB894 VA: 0xEBB894
		private IEnumerator BgChange()
		{
			//0xEBBFE0
			PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			yield return Co.R(MenuScene.Instance.BgControl.ChangeBgCoroutine(BgType.Raid, ev.KACFOENGHIK().HPPDFBKEJCG_BgId, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
		}

		// // RVA: 0xEBB928 Offset: 0xEBB928 VA: 0xEBB928
		public void StartShake()
		{
			if(m_mcrsCannonShakePrefab != null)
			{
				m_mcrsCannonShakeObj = Instantiate(m_mcrsCannonShakePrefab);
				m_mcrsCannonShakeObj.Play(Camera.main);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x713A54 Offset: 0x713A54 VA: 0x713A54
		// // RVA: 0xEBBB28 Offset: 0xEBBB28 VA: 0xEBBB28
		private IEnumerator Co_DamageAnime()
		{
			//0xEBC274
			StartShake();
			PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			if(ev != null)
			{
				ChangeTrialMusic(ev.EDNMFMBLCGF_GetWavId());
			}
			m_cannonDamangeLayout.Show();
			yield return Co.R(m_cannonDamangeLayout.StartAnime());
			MenuScene.Instance.Call(TransitionList.Type.RAID_REWARD, null, true);
			yield return Co.R(m_cannonDamangeLayout.EndAnime());
			Destroy(m_cannonDamangeLayout.gameObject);
		}

		// // RVA: 0xEBBBD4 Offset: 0xEBBBD4 VA: 0xEBBBD4
		// private void EndMovie() { }

		// // RVA: 0xEBBCCC Offset: 0xEBBCCC VA: 0xEBBCCC
		private void ChangeTrialMusic(int wavId)
		{
			int bgmId = BgmPlayer.MENU_TRIAL_ID_BASE + wavId;
			if(SoundManager.Instance.bgmPlayer.isPlaying)
			{
				if(SoundManager.Instance.bgmPlayer.currentBgmId == bgmId)
					return;
				SoundManager.Instance.bgmPlayer.FadeOut(0.3f, () =>
				{
					//0xEBBF78
					SoundManager.Instance.bgmPlayer.Play(bgmId, 1);
				});
			}
			else
			{
				SoundManager.Instance.bgmPlayer.Play(bgmId, 1);
			}
		}

		// RVA: 0xEBBEA0 Offset: 0xEBBEA0 VA: 0xEBBEA0
		private void OnApplicationPause(bool pauseStatus)
		{
			if(!m_isPlayingMovie)
				return;
			if(pauseStatus)
				m_mcrsCannonObj.Pause();
			else
				m_mcrsCannonObj.Resume();
		}
	}
}
