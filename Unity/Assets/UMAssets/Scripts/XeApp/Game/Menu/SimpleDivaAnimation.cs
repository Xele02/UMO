using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using static XeApp.Game.Common.DivaResource;

namespace XeApp.Game.Menu
{
	public class SimpleDivaAnimation : MonoBehaviour
	{
		private const int SimpleMotionMax = 5;
		private const int SimpleLoopMotionMax = 2;
		private SimpleDivaObject m_divaObject; // 0xC
		public DivaResource m_divaResource; // 0x10
		private StringBuilder m_bundleName = new StringBuilder(64); // 0x14
		private StringBuilder m_assetName = new StringBuilder(64); // 0x18
		private List<MotionOverrideClipKeyResource> m_overrideClipList = new List<MotionOverrideClipKeyResource>(); // 0x1C
		private List<float> m_DivaHeightAdjustList = new List<float>(); // 0x20
		private SimpleVoicePlayer m_voicePlayer; // 0x24
		private Coroutine m_coCommonLoopTalk; // 0x28
		private const string idleStateName = "simple_idle";
		private const string entryStateName = "simple_entry";
		private const string commonStateName = "simple_anime_{0:D2}";
		private const string commonLoopStateName = "simple_anime_loop_{0:D2}";
		private const string simpleLipSyncStateName = "simple_cmn_talk";
		private static readonly int EntryHash = Animator.StringToHash("body.sub_simple.simple_entry"); // 0x0
		private static readonly int IdleHash = Animator.StringToHash("body.sub_simple.simple_idle"); // 0x4
		private static readonly int IdleMouthHash = Animator.StringToHash("mouth.sub_simple.simple_idle"); // 0x8
		private List<int> SimpleAnimeHash = new List<int>(); // 0x30
		private List<int> SimpleLoopAnimeHash = new List<int>(); // 0x34
		private List<string> m_motionNameList; // 0x38
		private List<string> m_loopMotionNameList; // 0x3C

		public bool m_IsLoading { get; private set; } // 0x2C

		// RVA: 0xC49594 Offset: 0xC49594 VA: 0xC49594
		private void Awake()
		{
			m_divaObject = GetComponentInChildren<SimpleDivaObject>();
			m_voicePlayer = GetComponent<SimpleVoicePlayer>();
			StringBuilder str = new StringBuilder();
			for(int i = 0; i < 5; i++)
			{
				str.SetFormat("body.sub_simple.simple_anime{0:D2}", i + 1);
				SimpleAnimeHash.Add(Animator.StringToHash(str.ToString()));
			}
			str = new StringBuilder();
			for (int i = 0; i < 2; i++)
			{
				str.SetFormat("body.sub_simple.simple_anime{0:D2}", i + 1);
				SimpleLoopAnimeHash.Add(Animator.StringToHash(str.ToString()));
			}
		}

		//// RVA: 0xC497C8 Offset: 0xC497C8 VA: 0xC497C8
		public void LoadGoDivaResource(int divaId, int costumeModelId, int colorId, GoDivaResultAnimSetting animSetting)
		{
			m_IsLoading = true;
			this.StartCoroutineWatched(Co_LoadGoDivaResource(divaId, costumeModelId, colorId, animSetting));
		}

		//// RVA: 0xC49900 Offset: 0xC49900 VA: 0xC49900
		public GoDivaResultAnimSetting CreateGoDivaAnimSetting(int divaId, bool isBonusPop)
		{
			GoDivaResultAnimSetting res = new GoDivaResultAnimSetting();
			res.delayTimeList = new List<float>();
			List<string> ls = new List<string>();
			switch(divaId)
			{
				case 1:
					if(isBonusPop)
					{
						res.delayTimeList.Add(1);
						ls.Add("diva_001_appeal_start");
						ls.Add("diva_001_appeal_loop");
					}
					else
					{
						res.delayTimeList.Add(0);
						ls.Add("type_002_menu_talk01_start");
						ls.Add("type_002_menu_talk01");
						ls.Add("type_002_menu_talk01_end");
					}
					break;
				case 2:
					res.delayTimeList.Add(0);
					if(isBonusPop)
					{
						ls.Add("diva_002_menu_reaction04");
					}
					else
					{
						ls.Add("type_001_menu_talk01_start");
						ls.Add("type_001_menu_talk01");
						ls.Add("type_001_menu_talk01_end");
					}
					break;
				case 3:
					res.delayTimeList.Add(0);
					if(isBonusPop)
					{
						ls.Add("diva_003_join_start");
						ls.Add("diva_003_join_end_loop");
					}
					else
					{
						ls.Add("type_001_menu_talk01_start");
						ls.Add("type_001_menu_talk01");
						ls.Add("type_001_menu_talk01_end");
					}
					break;
				case 4:
					if(isBonusPop)
					{
						res.delayTimeList.Add(0.5f);
						ls.Add("diva_004_menu_simple_talk01");
					}
					else
					{
						res.delayTimeList.Add(0);
						ls.Add("type_002_menu_talk01_start");
						ls.Add("type_002_menu_talk01");
						ls.Add("type_002_menu_talk01_end");
					}
					break;
				case 5:
					res.delayTimeList.Add(0);
					if(isBonusPop)
					{
						ls.Add("type_004_menu_talk02_start");
						ls.Add("type_004_menu_talk02");
						ls.Add("type_004_menu_talk02_end");
					}
					else
					{
						ls.Add("type_004_menu_talk01_start");
						ls.Add("type_004_menu_talk01");
						ls.Add("type_004_menu_talk01_end");
					}
					break;
				case 6:
					res.delayTimeList.Add(0);
					if(isBonusPop)
					{
						ls.Add("diva_006_menu_timezone01");
					}
					else
					{
						ls.Add("type_003_menu_talk02_start");
						ls.Add("type_003_menu_talk02");
						ls.Add("type_003_menu_talk02_end");
					}
					break;
				case 7:
					res.delayTimeList.Add(0);
					if(isBonusPop)
					{
						ls.Add("type_001_menu_present01");
					}
					else
					{
						ls.Add("type_001_menu_talk01_start");
						ls.Add("type_001_menu_talk01");
						ls.Add("type_001_menu_talk01_end");
					}
					break;
				case 8:
					res.delayTimeList.Add(0);
					if(isBonusPop)
					{
						ls.Add("diva_008_menu_reaction01");
					}
					else
					{
						ls.Add("type_003_menu_talk02_start");
						ls.Add("type_003_menu_talk02");
						ls.Add("type_003_menu_talk02_end");
					}
					break;
				case 9:
					res.delayTimeList.Add(0);
					if(isBonusPop)
					{
						ls.Add("diva_009_menu_reaction01");
					}
					else
					{
						ls.Add("type_005_menu_talk01_start");
						ls.Add("type_005_menu_talk01");
						ls.Add("type_005_menu_talk01_end");
					}
					break;
				case 10:
					if(isBonusPop)
					{
						res.delayTimeList.Add(1);
						ls.Add("diva_010_join_start");
						ls.Add("diva_010_join_end_loop");
					}
					else
					{
						res.delayTimeList.Add(0);
						ls.Add("type_003_menu_talk02_start");
						ls.Add("type_003_menu_talk02");
						ls.Add("type_003_menu_talk02_end");
					}
					break;
			}
			res.animNameList = new List<string>(ls);
			StringBuilder str = new StringBuilder();
			str.SetFormat("cs_diva_event_{0:D3}", divaId);
			res.queSheetName = str.ToString();
			return res;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C55F8 Offset: 0x6C55F8 VA: 0x6C55F8
		//// RVA: 0xC49808 Offset: 0xC49808 VA: 0xC49808
		private IEnumerator Co_LoadGoDivaResource(int divaId, int costumeModelId, int colorId, GoDivaResultAnimSetting animSetting)
		{
			AssetBundleLoadAllAssetOperationBase operationDiva; // 0x28
			List<string> motionNameList; // 0x2C

			//0xC4C5F4
			if(divaId == 0)
			{
				Debug.LogError(JpStringLiterals.StringLiteral_20457);
				yield break;
			}
			if(costumeModelId == 0)
			{
				Debug.LogError(JpStringLiterals.StringLiteral_20458);
				yield break;
			}
			if(m_divaResource != null)
			{
				Release();
				yield return null;
				yield return Resources.UnloadUnusedAssets();
			}
			if(animSetting.queSheetName != "")
			{
				bool isEndedChangeCueSheet = false;
				m_voicePlayer.RequestChangeCueSheet(animSetting.queSheetName, () =>
				{
					//0xC4C3E8
					isEndedChangeCueSheet = true;
				});
				while(!isEndedChangeCueSheet)
					yield return null;
			}
			m_divaResource.LoadBasicResource(divaId, costumeModelId, colorId);
			m_divaResource.LoadMenuResource(divaId, costumeModelId, MenuFacialType.Home, ResultScoreRank.Type.Illegal);
			while(!m_divaResource.isMenuAllLoaded)
				yield return null;
			m_divaObject.Initialize(m_divaResource, divaId, false);
			m_divaObject.gameObject.SetActive(false);
			m_bundleName.SetFormat("dv/ca/{0:D3}.xab", divaId);
			operationDiva = AssetBundleManager.LoadAllAssetAsync(m_bundleName.ToString());
			yield return operationDiva;
			m_overrideClipList.Add(MotionOverrideClipKeyResource.Set("diva_{0:D3}_menu_entry_{1}", "diva_cmn_simple_entry", divaId, operationDiva, m_assetName));
			m_overrideClipList.Add(MotionOverrideClipKeyResource.Set("diva_{0:D3}_menu_idle_{1}", "diva_cmn_simple_idle", divaId, operationDiva, m_assetName));
			m_overrideClipList.Add(MotionOverrideClipKeyResource.Set("diva_{0:D3}_menu_idle_{1}", "diva_cmn_menu_idle", divaId, operationDiva, m_assetName));
			AssetBundleManager.UnloadAssetBundle(m_bundleName.ToString(), false);
			motionNameList = animSetting.animNameList;
			if(motionNameList[0].StartsWith("type"))
			{
				m_bundleName.SetFormat("dv/ty/{0:D3}.xab", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(divaId).FPMGHDKACOF_PersonalityId);
				operationDiva = AssetBundleManager.LoadAllAssetAsync(m_bundleName.ToString());
				yield return operationDiva;
			}
			for(int i = 0; i < motionNameList.Count; i++)
			{
				motionNameList[i] = motionNameList[i] + "_{1}";
			}
			if(motionNameList.Count == 1)
			{
				m_overrideClipList.Add(MotionOverrideClipKeyResource.Set(motionNameList[0], "diva_cmn_simple_anime01", divaId, operationDiva, m_assetName));
			}
			else if(motionNameList.Count == 2)
			{
				m_overrideClipList.Add(MotionOverrideClipKeyResource.Set(motionNameList[0], "diva_cmn_simple_loop_start", divaId, operationDiva, m_assetName));
				m_overrideClipList.Add(MotionOverrideClipKeyResource.Set(motionNameList[1], "diva_cmn_simple_loop_loop", divaId, operationDiva, m_assetName));
			}
			else if(motionNameList.Count == 3)
			{
				m_overrideClipList.Add(MotionOverrideClipKeyResource.Set(motionNameList[0], "diva_cmn_menu_talk01_start", divaId, operationDiva, m_assetName));
				m_overrideClipList.Add(MotionOverrideClipKeyResource.Set(motionNameList[1], "diva_cmn_menu_talk01", divaId, operationDiva, m_assetName));
				m_overrideClipList.Add(MotionOverrideClipKeyResource.Set(motionNameList[2], "diva_cmn_menu_talk01_end", divaId, operationDiva, m_assetName));
			}
			m_divaObject.OverrideAnimations(m_overrideClipList);
			AssetBundleManager.UnloadAssetBundle(m_bundleName.ToString(), false);
			m_IsLoading = false;
		}

		//// RVA: 0xC4A7B0 Offset: 0xC4A7B0 VA: 0xC4A7B0
		public void LoadResource(int divaId, int costumeModelId, int colorId, List<string> motionNameList, List<string> loopMotionNameList, string voiceQueSheetName)
		{
			m_IsLoading = true;
			this.StartCoroutineWatched(Co_LoadResource(divaId, costumeModelId, colorId, motionNameList, loopMotionNameList, voiceQueSheetName));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C5670 Offset: 0x6C5670 VA: 0x6C5670
		//// RVA: 0xC4A7F4 Offset: 0xC4A7F4 VA: 0xC4A7F4
		private IEnumerator Co_LoadResource(int divaId, int costumeModelId, int colorId, List<string> motionNameList, List<string> loopMotionNameList, string voiceQueSheetName)
		{
			AssetBundleLoadAllAssetOperationBase operationDiva;

			//0xC4D7E4
			if (divaId == 0)
			{
				Debug.LogError(JpStringLiterals.StringLiteral_20457);
			}
			else if (costumeModelId == 0)
			{
				Debug.LogError(JpStringLiterals.StringLiteral_20458);
			}
			else if (motionNameList == null || motionNameList.Count < 6)
			{
				if (loopMotionNameList == null || loopMotionNameList.Count < 3)
				{
					m_motionNameList = motionNameList;
					m_loopMotionNameList = loopMotionNameList;
					if (m_divaResource != null)
					{
						Release();
						yield return null;
						yield return Resources.UnloadUnusedAssets();
					}
					if(voiceQueSheetName != "")
					{
						bool isEndedChangeCueSheet = false;
						m_voicePlayer.RequestChangeCueSheet(voiceQueSheetName, () =>
						{
							//0xC4C3FC
							isEndedChangeCueSheet = true;
						});
						while (!isEndedChangeCueSheet)
							yield return null;
					}
					m_divaResource.LoadBasicResource(divaId, costumeModelId, colorId);
					m_divaResource.LoadMenuResource(divaId, costumeModelId, DivaResource.MenuFacialType.Home, ResultScoreRank.Type.Illegal);
					while (!m_divaResource.isMenuAllLoaded)
						yield return null;
					m_bundleName.SetFormat("dv/ca/{0:D3}.xab", divaId);
					operationDiva = AssetBundleManager.LoadAllAssetAsync(m_bundleName.ToString());
					yield return operationDiva;
					m_divaObject.Initialize(m_divaResource, divaId, false);
					m_divaObject.gameObject.SetActive(false);
					m_overrideClipList.Add(MotionOverrideClipKeyResource.Set("diva_{0:D3}_menu_entry_{1}", "diva_cmn_simple_entry", divaId, operationDiva, m_assetName));
					m_overrideClipList.Add(MotionOverrideClipKeyResource.Set("diva_{0:D3}_menu_idle_{1}", "diva_cmn_simple_idle", divaId, operationDiva, m_assetName));
					StringBuilder str = new StringBuilder();
					if(motionNameList != null)
					{
						for(int i = 0; i < motionNameList.Count; i++)
						{
							str.SetFormat("diva_cmn_simple_anime{0:D2}", i + 1);
							m_overrideClipList.Add(MotionOverrideClipKeyResource.Set(motionNameList[i], str.ToString(), divaId, operationDiva, m_assetName));
						}
					}
					if(loopMotionNameList != null)
					{
						for (int i = 0; i < loopMotionNameList.Count; i++)
						{
							str.SetFormat("diva_cmn_simple_loop_anime{0:D2}", i + 1);
							m_overrideClipList.Add(MotionOverrideClipKeyResource.Set(loopMotionNameList[i], str.ToString(), divaId, operationDiva, m_assetName));
						}
					}
					m_divaObject.OverrideAnimations(m_overrideClipList);
					AssetBundleManager.UnloadAssetBundle(m_bundleName.ToString(), false);
					yield return null;
					m_IsLoading = false;
				}
				else
				{
					Debug.LogError(JpStringLiterals.StringLiteral_20470 + loopMotionNameList.Count + " ]");
				}
			}
			else
			{
				Debug.LogError(JpStringLiterals.StringLiteral_20469 + motionNameList.Count + " ]");
			}
		}

		//// RVA: 0xC4A940 Offset: 0xC4A940 VA: 0xC4A940
		public void StopMotion()
		{
			m_divaObject.Stop();
		}

		//// RVA: 0xC4A96C Offset: 0xC4A96C VA: 0xC4A96C
		public void StartEntryMotion()
		{
			m_divaObject.Play("simple_entry");
		}

		//// RVA: 0xC4A9E8 Offset: 0xC4A9E8 VA: 0xC4A9E8
		public void StartIdleMotion()
		{
			m_divaObject.Play("simple_idle");
		}

		//// RVA: 0xC4AA64 Offset: 0xC4AA64 VA: 0xC4AA64
		//public void StartSimpleMotion(string motionName) { }

		//// RVA: 0xC4ABFC Offset: 0xC4ABFC VA: 0xC4ABFC
		public void StartSimpleMotion(int motionNo)
		{
			if(m_motionNameList != null && m_motionNameList.Count <= motionNo)
			{
				Debug.LogError(string.Concat(new object[] {
					JpStringLiterals.StringLiteral_20448,
					motionNo,
					"/",
					m_motionNameList.Count,
					" ]"
				}));
			}
			m_divaObject.Anim_SetTrigger("menu_toSimple");
			m_divaObject.Anim_SetInteger("menu_simpleId", motionNo + 1);
		}

		//// RVA: 0xC4AFA8 Offset: 0xC4AFA8 VA: 0xC4AFA8
		//public void StartSimpleLoopMotion(string motionName) { }

		//// RVA: 0xC4B140 Offset: 0xC4B140 VA: 0xC4B140
		public void StartSimpleLoopMotion(int motionNo)
		{
			if(m_loopMotionNameList != null && m_loopMotionNameList.Count <= motionNo)
			{
				Debug.LogError(new object[5]
				{
					"StringLiteral_20450", motionNo, "/", m_loopMotionNameList.Count, " ]"
				});
			}
			m_divaObject.Anim_SetTrigger("menu_toSimpleLoop");
			m_divaObject.Anim_SetInteger("menu_simpleId", motionNo + 1);
		}

		//// RVA: 0xC4B4EC Offset: 0xC4B4EC VA: 0xC4B4EC
		public void CrossFadeIdel(string stateName)
		{
			m_divaObject.CrossFadeIdle(stateName);
		}

		//// RVA: 0xC4B520 Offset: 0xC4B520 VA: 0xC4B520
		public bool IsPlayingEntry()
		{
			return m_divaObject.GetBodyHash() == EntryHash;
		}

		//// RVA: 0xC4B5E4 Offset: 0xC4B5E4 VA: 0xC4B5E4
		public bool IsPlayingIdle()
		{
			return m_divaObject.GetBodyHash() == IdleHash;
		}

		//// RVA: 0xC4B6A8 Offset: 0xC4B6A8 VA: 0xC4B6A8
		public bool IsPlayingIdleMouth()
		{
			return m_divaObject.GetMouthHash() == IdleMouthHash;
		}

		//// RVA: 0xC4B76C Offset: 0xC4B76C VA: 0xC4B76C
		public bool IsPlayingSelectMotion(int animNum)
		{
			return m_divaObject.GetBodyHash() == Animator.StringToHash(string.Format("body.sub_simple.simple_anime{0:D2}", animNum + 1));
		}

		//// RVA: 0xC4B83C Offset: 0xC4B83C VA: 0xC4B83C
		//public bool IsPlayingSelectLoopMotion(int loopAnimNum) { }

		//// RVA: 0xC4B90C Offset: 0xC4B90C VA: 0xC4B90C
		//public bool IsPlayingSimpleAnim(string motionName) { }

		//// RVA: 0xC4B92C Offset: 0xC4B92C VA: 0xC4B92C
		//public bool IsPlayingSimpleAnim(int motionNo) { }

		//// RVA: 0xC4BA20 Offset: 0xC4BA20 VA: 0xC4BA20
		public bool IsPlayingVoice()
		{
			return m_voicePlayer.isPlaying;
		}

		//// RVA: 0xC4BA4C Offset: 0xC4BA4C VA: 0xC4BA4C
		public void SetVisible(bool isVisible)
		{
			m_divaObject.SetEnableRenderer(isVisible);
		}

		//// RVA: 0xC4BA80 Offset: 0xC4BA80 VA: 0xC4BA80
		public void Release()
		{
			if(m_coCommonLoopTalk != null)
			{
				this.StopCoroutineWatched(m_coCommonLoopTalk);
				m_coCommonLoopTalk = null;
			}
			for(int i = 0; i < m_overrideClipList.Count; i++)
			{
				m_overrideClipList[i].Release();
			}
			m_overrideClipList.Clear();
			if(m_divaObject != null)
			{
				m_divaObject.ReleaseMediator();
				m_divaObject.Release();
				m_divaObject.enabled = false;
			}
			if (m_divaResource != null)
				m_divaResource.ReleaseAll();
		}

		//// RVA: 0xC4AA84 Offset: 0xC4AA84 VA: 0xC4AA84
		//private int GetSimpleAnimationId(string motionName) { }

		//// RVA: 0xC4AFC8 Offset: 0xC4AFC8 VA: 0xC4AFC8
		//private int GetLoopSimpleAnimationId(string motionName) { }

		//// RVA: 0xC4BCF0 Offset: 0xC4BCF0 VA: 0xC4BCF0
		public int PlayVoiceRandom(SimpleDivaVoiceSetting setting, int exclusionId = -1)
		{
			int a = m_voicePlayer.PlayVoiceRandom(setting.m_voiceSetting, exclusionId);
			this.StartCoroutineWatched(Co_SimpleLipSync(setting));
			return a;
		}

		//// RVA: 0xC4BE10 Offset: 0xC4BE10 VA: 0xC4BE10
		public void PlayVoice(SimpleDivaVoiceSetting setting, int id)
		{
			m_voicePlayer.PlayVoice(setting.m_voiceSetting, id);
			this.StartCoroutineWatched(Co_SimpleLipSync(setting));
		}

		//// RVA: 0xC4BE80 Offset: 0xC4BE80 VA: 0xC4BE80
		public void PlayVoiceOnly(SimpleDivaVoiceSetting setting)
		{
			m_voicePlayer.PlayVoiceRandom(setting.m_voiceSetting, -1);
		}

		//// RVA: 0xC4BECC Offset: 0xC4BECC VA: 0xC4BECC
		//public void StartLipSync(SimpleDivaVoiceSetting setting) { }

		//// RVA: 0xC4BEF0 Offset: 0xC4BEF0 VA: 0xC4BEF0
		public void StopVoice()
		{
			m_voicePlayer.StopVoice();
			StopSimpleLipSync();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C56E8 Offset: 0x6C56E8 VA: 0x6C56E8
		//// RVA: 0xC4BD68 Offset: 0xC4BD68 VA: 0xC4BD68
		private IEnumerator Co_SimpleLipSync(SimpleDivaVoiceSetting setting)
		{
			//0xC4E534
			yield return new WaitUntil(() =>
			{
				//0xC4C350
				return m_voicePlayer.isPlaying;
			});
			if (setting.m_isSimpleLipSync)
				StartSimpleLipSync();
		}

		//// RVA: 0xC4BFC8 Offset: 0xC4BFC8 VA: 0xC4BFC8
		private void StartSimpleLipSync()
		{
			m_divaObject.PlayFacialAnime("simple_cmn_talk");
			m_divaObject.Anim_SetBool("menu_breakTalkLoop", false);
			m_coCommonLoopTalk = this.StartCoroutineWatched(Co_CommonLoopTalk());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C5760 Offset: 0x6C5760 VA: 0x6C5760
		//// RVA: 0xC4C094 Offset: 0xC4C094 VA: 0xC4C094
		private IEnumerator Co_CommonLoopTalk()
		{
			//0xC4C434
			yield return new WaitUntil(() =>
			{
				//0xC4C37C
#if UNITY_EDITOR
				return m_voicePlayer.source.status == CriWare.CriAtomSource.Status.Stop;
#else
				return m_voicePlayer.source.status == CriWare.CriAtomSource.Status.PlayEnd;
#endif
			});
			StopSimpleLipSync();
			m_coCommonLoopTalk = null;
		}

		//// RVA: 0xC4BF28 Offset: 0xC4BF28 VA: 0xC4BF28
		private void StopSimpleLipSync()
		{
			m_divaObject.Anim_SetBool("menu_breakTalkLoop", true);
		}
	}
}
