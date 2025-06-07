using System;
using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class McrsCannonViewer : MonoBehaviour
	{
		[SerializeField]
		private MacrossCannon m_mcrsCannonPrefab; // 0xC
		private MacrossCannon m_mcrsCannonObj; // 0x10
		[SerializeField]
		private McrsCannonShakeObject m_mcrsCannonShakePrefab; // 0x14
		private McrsCannonShakeObject m_mcrsCannonShakeObj; // 0x18
		[SerializeField]
		private ButtonBase m_hitCheck; // 0x1C
		private Action OnClickCallback; // 0x20
		private int m_wavId; // 0x24
		private SeriesAttr.Type m_series; // 0x28
		private int m_pattern; // 0x2C
		private int m_quality; // 0x30
		private int m_bossType; // 0x34
		private int m_bossRank; // 0x38
		private string m_bossName; // 0x3C
		private int m_bossDamage; // 0x40
		private RaidResultCannonDamageLayout m_cannonDamangeLayout; // 0x44
		private RaidResultBossFilterLayout m_bossFilterLayout; // 0x48
		private static McrsCannonViewer m_instance; // 0x0
		private Coroutine m_coroutine; // 0x4C
		private float s_preEndTime = 0.16f; // 0x50
		private bool m_isPlayingMovie; // 0x54

		public static RaidResultBossFilterLayout BossFilterLayout { get { return m_instance.m_bossFilterLayout; } } //0xEBDDDC

		// RVA: 0xEBDE50 Offset: 0xEBDE50 VA: 0xEBDE50
		public static void Initiarize(Transform parent, int wavId, SeriesAttr.Type series, int bossType, int bossRank, string bossName, int bossDamage, Action endCallback)
		{
			GameManager.Instance.StartCoroutineWatched(Co_Initiarize(parent, wavId, series, bossType, bossRank, bossName, bossDamage, endCallback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x713C7C Offset: 0x713C7C VA: 0x713C7C
		// // RVA: 0xEBDF40 Offset: 0xEBDF40 VA: 0xEBDF40
		private static IEnumerator Co_Initiarize(Transform parent, int wavId, SeriesAttr.Type series, int bossType, int bossRank, string bossName, int bossDamage, Action endCallback)
		{
			//0xEBFA0C
			yield return Co.R(Co_LoadAssetInstance(parent));
			m_instance.m_wavId = wavId;
			m_instance.m_series = series;
			m_instance.m_bossType = bossType;
			m_instance.m_bossRank = bossRank;
			m_instance.m_bossName = bossName;
			m_instance.m_bossDamage = bossDamage;
			m_instance.m_hitCheck.AddOnClickCallback(() =>
			{
				//0xEBF358
				if(m_instance.OnClickCallback != null)
					m_instance.OnClickCallback();
			});
			yield return Co.R(m_instance.Co_LoadAssetLayout());
			yield return Co.R(m_instance.Co_InitializeMovie());
			m_instance.LoadBGM();
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			if(endCallback != null)
				endCallback();
		}

		// // RVA: 0xEBE0A4 Offset: 0xEBE0A4 VA: 0xEBE0A4
		public static void DeleteCache()
		{
			if(m_instance != null)
			{
				if(m_instance.m_mcrsCannonObj != null)
				{
					Destroy(m_instance.m_mcrsCannonObj.gameObject);
					m_instance.m_mcrsCannonObj = null;
				}
			}
			Destroy(m_instance.gameObject);
			m_instance = null;
			MenuScene.Instance.BgControl.DestroyCacheBg();
		}

		// // RVA: 0xEBE36C Offset: 0xEBE36C VA: 0xEBE36C
		public static void Play(Action movieEndCallback, Action damageEndCallback, Action onClickCallback)
		{
			if(m_instance != null)
			{
				m_instance.m_coroutine = m_instance.StartCoroutineWatched(m_instance.Co_Play(movieEndCallback, damageEndCallback));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x713CF4 Offset: 0x713CF4 VA: 0x713CF4
		// // RVA: 0xEBE4D4 Offset: 0xEBE4D4 VA: 0xEBE4D4
		private IEnumerator Co_Play(Action movieEndCallback, Action damageEndCallback)
		{
			//0xEC0BE0
			yield return Co.R(Co_StartMovie());
			if(movieEndCallback != null)
				movieEndCallback();
			yield return Co.R(Co_DamageAnime());
			if(damageEndCallback != null)
				damageEndCallback();
			m_coroutine = null;
		}

		// // RVA: 0xEBE5B4 Offset: 0xEBE5B4 VA: 0xEBE5B4
		public static void Skip()
		{
			if(m_instance != null)
			{
				m_instance.m_isPlayingMovie = false;
				m_instance.StartCoroutineWatched(m_instance.Co_Skip());
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x713D6C Offset: 0x713D6C VA: 0x713D6C
		// // RVA: 0xEBE6E4 Offset: 0xEBE6E4 VA: 0xEBE6E4
		private IEnumerator Co_Skip()
		{
			//0xEC0D60
			yield return new WaitForSeconds(s_preEndTime);
			if(m_instance.m_mcrsCannonObj != null)
			{
				m_instance.m_mcrsCannonObj.End();
			}
		}

		// // RVA: 0xEBE790 Offset: 0xEBE790 VA: 0xEBE790
		public static bool IsPlaying()
		{
			if(m_instance != null)
				return m_instance.m_coroutine != null;
			return false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x713DE4 Offset: 0x713DE4 VA: 0x713DE4
		// // RVA: 0xEBE870 Offset: 0xEBE870 VA: 0xEBE870
		private static IEnumerator Co_LoadAssetInstance(Transform parent)
		{
			string bundleName; // 0x14
			AssetBundleLoadAssetOperation operation; // 0x18

			//0xEBFEEC
			bundleName = "ly/200.xab";
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			operation = AssetBundleManager.LoadAssetAsync(bundleName, "McrsCannonViewer", typeof(GameObject));
			yield return operation;
			GameObject g = Instantiate(operation.GetAsset<GameObject>());
			m_instance = g.GetComponent<McrsCannonViewer>();
			m_instance.transform.SetParent(parent, false);
			m_instance.transform.SetAsFirstSibling();
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x713E5C Offset: 0x713E5C VA: 0x713E5C
		// // RVA: 0xEBE91C Offset: 0xEBE91C VA: 0xEBE91C
		private IEnumerator Co_LoadAssetLayout()
		{
			string bundleName; // 0x14
			FontInfo systemFont; // 0x18

			//0xEC02DC
			bundleName = "ly/204.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co.R(Co_LoadAssetLayoutCannonDamageLayout(bundleName, systemFont));
			while(m_cannonDamangeLayout == null)
				yield return null;
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co.R(Co_LoadAssetLayoutBossFilterLayout(bundleName, systemFont));
			while(m_bossFilterLayout == null)
				yield return null;
			
		}

		// [IteratorStateMachineAttribute] // RVA: 0x713ED4 Offset: 0x713ED4 VA: 0x713ED4
		// // RVA: 0xEBE9C8 Offset: 0xEBE9C8 VA: 0xEBE9C8
		private IEnumerator Co_LoadAssetLayoutCannonDamageLayout(string bundleName, FontInfo font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xEC092C
			if(m_cannonDamangeLayout != null)
				yield break;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_g_r_r_damage_cc_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xEBF1D8
				m_cannonDamangeLayout = instance.GetComponent<RaidResultCannonDamageLayout>();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x713F4C Offset: 0x713F4C VA: 0x713F4C
		// // RVA: 0xEBEAA8 Offset: 0xEBEAA8 VA: 0xEBEAA8
		private IEnumerator Co_LoadAssetLayoutBossFilterLayout(string bundleName, FontInfo font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xEC0678
			if(m_bossFilterLayout != null)
				yield break;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_g_r_d_filter_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xEBF254
				m_bossFilterLayout = instance.GetComponent<RaidResultBossFilterLayout>();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x713FC4 Offset: 0x713FC4 VA: 0x713FC4
		// // RVA: 0xEBEB88 Offset: 0xEBEB88 VA: 0xEBEB88
		private IEnumerator Co_InitializeMovie()
		{
			//0xEBF6A8
			m_mcrsCannonObj = Instantiate(m_mcrsCannonPrefab);
			m_mcrsCannonObj.transform.SetAsLastSibling();
			m_pattern = 0;
			m_quality = 2;
			m_cannonDamangeLayout.Hide();
			m_cannonDamangeLayout.Setup(m_bossRank, m_bossName, m_bossDamage);
			yield return Co.R(m_mcrsCannonObj.Initialize(m_series, m_pattern, m_quality, () =>
			{
				//0xEBF2D0
				m_isPlayingMovie = false;
			}, s_preEndTime));
			yield return Co.R(MenuScene.Instance.BgControl.CacheBg(BgType.Raid, m_bossType));
		}

		// // RVA: 0xEBEC34 Offset: 0xEBEC34 VA: 0xEBEC34
		private void LoadBGM()
		{
			StringBuilder str = new StringBuilder(64);
			str.SetFormat("cs_w_{0:D4}", m_wavId);
			if(!SoundResource.IsInstalledCueSheet(str.ToString()))
				SoundResource.InstallCueSheet(str.ToString());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71403C Offset: 0x71403C VA: 0x71403C
		// // RVA: 0xEBEDA4 Offset: 0xEBEDA4 VA: 0xEBEDA4
		private IEnumerator Co_StartMovie()
		{
			//0xEC0F78
			SoundManager.Instance.bgmPlayer.Stop();
			m_bossFilterLayout.SetFilter(RaidResultBossFilterLayout.FilterType.None);
			m_mcrsCannonObj.Play();
			m_isPlayingMovie = true;
			while(m_isPlayingMovie)
				yield return null;
			yield return Co.R(MenuScene.Instance.BgControl.ChangeBgCoroutine(BgType.Raid, m_bossType, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			m_cannonDamangeLayout.transform.SetParent(transform, false);
			m_cannonDamangeLayout.transform.SetAsLastSibling();
			m_bossFilterLayout.transform.SetParent(transform, false);
			m_bossFilterLayout.transform.SetAsFirstSibling();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7140B4 Offset: 0x7140B4 VA: 0x7140B4
		// // RVA: 0xEBEE50 Offset: 0xEBEE50 VA: 0xEBEE50
		public IEnumerator Co_StartShake()
		{
			//0xEC1364
			yield return new WaitForSeconds(s_preEndTime);
			if(m_mcrsCannonShakePrefab != null)
			{
				m_mcrsCannonShakeObj = Instantiate(m_mcrsCannonShakePrefab);
				m_mcrsCannonShakeObj.Play(Camera.main);
			}
			
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71412C Offset: 0x71412C VA: 0x71412C
		// // RVA: 0xEBEEFC Offset: 0xEBEEFC VA: 0xEBEEFC
		private IEnumerator Co_DamageAnime()
		{
			//0xEBF484
			this.StartCoroutineWatched(Co_StartShake());
			ChangeTrialMusic(m_wavId);
			m_bossFilterLayout.SetFilter(RaidResultBossFilterLayout.FilterType.Red);
			m_cannonDamangeLayout.Show();
			yield return Co.R(m_cannonDamangeLayout.StartAnime());
			yield return Co.R(m_cannonDamangeLayout.EndAnime());
		}

		// // RVA: 0xEBEFA8 Offset: 0xEBEFA8 VA: 0xEBEFA8
		private void ChangeTrialMusic(int wavId)
		{
			int bgmId = BgmPlayer.MENU_TRIAL_ID_BASE + wavId;
			if(SoundManager.Instance.bgmPlayer.isPlaying)
			{
				if(SoundManager.Instance.bgmPlayer.currentBgmId == m_wavId)
					return;
				SoundManager.Instance.bgmPlayer.FadeOut(0.3f, () =>
				{
					//0xEBF41C
					SoundManager.Instance.bgmPlayer.Play(bgmId, 1);
				});
			}
			else
			{
				SoundManager.Instance.bgmPlayer.Play(bgmId, 1);
			}
		}

		// RVA: 0xEBF17C Offset: 0xEBF17C VA: 0xEBF17C
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
