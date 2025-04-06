using System;
using System.Collections.Generic;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

namespace XeApp.Game.MusicSelect
{
	public class VerticalMusicDataList
	{

		public class MusicListData
		{
			public struct InitParam
			{
				public IBJAKJJICBC viewMusic; // 0x0
				public List<MusicRewardStat> rewardStat; // 0x4
				public long aprilFoolEndTime; // 0x8
				public bool isOpen; // 0x10
				public bool isNew; // 0x11
				public bool isUnlockable; // 0x12
				public bool isSimulation; // 0x13
				public bool isHighLevel; // 0x14
				public MusicSelectConsts.MusicTimeType timeType; // 0x18
				public MusicSelectConsts.MusicType musicType; // 0x1C
				public MusicSelectConsts.EventType eventType; // 0x20
				public MusicSelectConsts.PlayBoostType boostType; // 0x24
				public string eventPeriod; // 0x28
				public string musicTimeStr; // 0x2C
				public string musicName; // 0x30
				public string vocalName; // 0x34
				public int musicTime; // 0x38
				public string musicName_2;
				public string musicName_3;
			}
			private List<MusicRewardStat> m_rewardStat = new List<MusicRewardStat>(); // 0xC

			public IBJAKJJICBC ViewMusic { get; } = new IBJAKJJICBC(); // 0x8
			public List<MusicRewardStat> RewardStat { get { return m_rewardStat; } } //0xCA3E58
			public long AprilFoolEndTime { get; } // 0x10
			public bool IsOpen { get; } = false; // 0x18
			public bool IsUnlockable { get; } = false; // 0x19
			public bool IsNew { get; } = false; //0x1A
			public bool IsSimulation { get; } = false; // 0x1B
			public bool IsHighLevel { get; } = false; // 0x1C
			public string EventPeriod { get; } // 0x20
			public string MusicTimeStr { get; } // 0x24
			public string MusicName { get; } // 0x28
			public string MusicName2 { get; }
			public string MusicName3 { get; }
			public string VocalName { get; } // 0x2C
			public int MusicTime { get; } // 0x30
			public MusicSelectConsts.MusicTimeType TimeType { get; } = MusicSelectConsts.MusicTimeType.Max; // 0x34
			public MusicSelectConsts.EventType EventType { get; } = MusicSelectConsts.EventType.Max; // 0x38
			public MusicSelectConsts.MusicType MusicType { get; } = MusicSelectConsts.MusicType.Max; // 0x3C
			public MusicSelectConsts.PlayBoostType PlayBoostType { get; } = MusicSelectConsts.PlayBoostType.Max; // 0x40

			//	// RVA: 0xCA2E0C Offset: 0xCA2E0C VA: 0xCA2E0C
			public MusicListData(InitParam initParam)
			{
				MusicName = initParam.musicName;
				MusicName2 = initParam.musicName_2;
				MusicName3 = initParam.musicName_3;
				ViewMusic = initParam.viewMusic;
				IsHighLevel = initParam.isHighLevel;
				IsSimulation = initParam.isSimulation;
				IsOpen = initParam.isOpen;
				IsUnlockable = initParam.isUnlockable;
				MusicTimeStr = initParam.musicTimeStr;
				AprilFoolEndTime = initParam.aprilFoolEndTime;
				TimeType = initParam.timeType;
				m_rewardStat = initParam.rewardStat;
				EventType = initParam.eventType;
				MusicType = initParam.musicType;
				PlayBoostType = initParam.boostType;
				IsNew = initParam.isNew;
				EventPeriod = initParam.eventPeriod;
				VocalName = initParam.vocalName;
				MusicTime = initParam.musicTime;
			}
		}

		private List<MusicListData> m_viewList = new List<MusicListData>(); // 0x8
		private List<MusicListData> m_view6LineList = new List<MusicListData>(); // 0xC
		private List<MusicListData> m_viewSimulationList = new List<MusicListData>(); // 0x10
		private List<MusicListData> m_viewSimulation6LineList = new List<MusicListData>(); // 0x14

		//// RVA: 0xCA0F60 Offset: 0xCA0F60 VA: 0xCA0F60
		public static List<MusicListData> CreateMusicListData(List<IBJAKJJICBC> viewMusicDataList, IKDICBBFBMI_EventBase eventController, bool line6Mode, int musicTypeThreshold, int lastStoryFreeMusicId)
		{
			string musicTimeFormat = MessageManager.Instance.GetBank("menu").GetMessageByLabel("vertical_music_select_music_time");
			List<MusicListData> res = new List<MusicListData>();
			FPGEMAIAMBF_RewardData b = new FPGEMAIAMBF_RewardData();
			for(int i = 0; i < viewMusicDataList.Count; i++)
			{
				List<MusicRewardStat> rewardList = new List<MusicRewardStat>();
				IBJAKJJICBC musicData = viewMusicDataList[i];
				int musicTime = 0;
				for(int j = 0; j < musicData.MGJKEJHEBPO_DiffInfos.Count; j++)
				{
					MusicRewardStat reward = new MusicRewardStat();
					b.JMHCEMHPPCM(musicData.GHBPLHBNMBK_FreeMusicId, j, line6Mode, musicData.MNNHHJBBICA_GameEventType);
					reward.Init(b);
					rewardList.Add(reward);
					if(musicTime < musicData.MGJKEJHEBPO_DiffInfos[j].HHMLMKAEJBJ_Score.MCMIPODICAN_length)
					{
						musicTime = musicData.MGJKEJHEBPO_DiffInfos[j].HHMLMKAEJBJ_Score.MCMIPODICAN_length;
					}
				}
				if(musicData.AJGCPCMLGKO_IsEvent)
				{
					MusicSelectConsts.EventType eventType = MusicSelectConsts.EventType.Max;
					if(((int)musicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory - 1) < 14)
					{
						MusicSelectConsts.EventType[] d = 
						{
							MusicSelectConsts.EventType.Special,
							MusicSelectConsts.EventType.Max,
							MusicSelectConsts.EventType.Special,
							MusicSelectConsts.EventType.Max,
							MusicSelectConsts.EventType.Weekly,
							MusicSelectConsts.EventType.Special,
							MusicSelectConsts.EventType.Max,
							MusicSelectConsts.EventType.Max,
							MusicSelectConsts.EventType.Max,
							MusicSelectConsts.EventType.Special,
							MusicSelectConsts.EventType.Special,
							MusicSelectConsts.EventType.Max,
							MusicSelectConsts.EventType.Max,
							MusicSelectConsts.EventType.Special
						};
						eventType = d[((int)musicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory - 1)];
					}
					bool isUnlockable = true;
					if(lastStoryFreeMusicId == 0)
					{
						isUnlockable = false;
					}
					else
					{
						isUnlockable = musicData.GHBPLHBNMBK_FreeMusicId == lastStoryFreeMusicId;
					}
					MusicListData.InitParam initparam;
					initparam.viewMusic = musicData; // 0x0									public IBJAKJJICBC viewMusic; // 0x0
					initparam.rewardStat = rewardList; // 0x4						public List<MusicRewardStat> rewardStat; // 0x4
					initparam.aprilFoolEndTime = 0; // 0x8							public long aprilFoolEndTime; // 0x8
					initparam.isOpen = true; // 0x10									public bool isOpen; // 0x10
					initparam.isNew = musicData.LDGOHPAPBMM_IsNew; // 0x11										public bool isNew; // 0x11
					initparam.isUnlockable = isUnlockable; // 0x12								public bool isUnlockable; // 0x12
					initparam.isSimulation = musicData.EHNGOGBJMGL; // 0x13								public bool isSimulation; // 0x13
					initparam.isHighLevel = false; // 0x14								public bool isHighLevel; // 0x14
					initparam.timeType = MusicSelectConsts.MusicTimeType.Max; // 0x18									public MusicSelectConsts.MusicTimeType timeType; // 0x18
					initparam.musicType = MusicSelectConsts.MusicType.None; // 0x1C									public MusicSelectConsts.MusicType musicType; // 0x1C
					initparam.eventType = eventType; // 0x20									public MusicSelectConsts.EventType eventType; // 0x20
					initparam.boostType = MusicSelectConsts.PlayBoostType.Max; // 0x24									public MusicSelectConsts.PlayBoostType boostType; // 0x24
					initparam.eventPeriod = GetEventPeriodString(musicData.AFCMIOIGAJN_EventInfo.KINJOEIAHFK_OpenTime, musicData.AFCMIOIGAJN_EventInfo.PCCFAKEOBIC_CloseTime); // 0x28								public string eventPeriod; // 0x28
					initparam.musicTimeStr = null; // 0x2C								public string musicTimeStr; // 0x2C
					initparam.musicName = null; // 0x30									public string musicName; // 0x30
					initparam.musicName_2 = null;
					initparam.musicName_3 = null;
					initparam.vocalName = null; // 0x34									public string vocalName; // 0x34
					initparam.musicTime = musicTime; // 0x38									public int musicTime; // 0x38
					MusicListData data = new MusicListData(initparam);
					res.Add(data);
				}
				else if(musicData.BNIAJAKIAJC_IsEventMinigame)
				{
					bool isUnlockable = true;
					if (lastStoryFreeMusicId == 0)
					{
						isUnlockable = false;
					}
					else
					{
						isUnlockable = musicData.GHBPLHBNMBK_FreeMusicId == lastStoryFreeMusicId;
					}
					MusicListData.InitParam initparam;
					initparam.viewMusic = musicData; // 0x0									public IBJAKJJICBC viewMusic; // 0x0
					initparam.rewardStat = rewardList; // 0x4						public List<MusicRewardStat> rewardStat; // 0x4
					initparam.aprilFoolEndTime = 0; // 0x8							public long aprilFoolEndTime; // 0x8
					initparam.isOpen = true; // 0x10									public bool isOpen; // 0x10
					initparam.isNew = musicData.LDGOHPAPBMM_IsNew; // 0x11										public bool isNew; // 0x11
					initparam.isUnlockable = isUnlockable; // 0x12								public bool isUnlockable; // 0x12
					initparam.isSimulation = musicData.EHNGOGBJMGL; // 0x13								public bool isSimulation; // 0x13
					initparam.isHighLevel = false; // 0x14								public bool isHighLevel; // 0x14
					initparam.timeType = MusicSelectConsts.MusicTimeType.Max; // 0x18									public MusicSelectConsts.MusicTimeType timeType; // 0x18
					initparam.musicType = MusicSelectConsts.MusicType.None; // 0x1C									public MusicSelectConsts.MusicType musicType; // 0x1C
					initparam.eventType = MusicSelectConsts.EventType.Special; // 0x20									public MusicSelectConsts.EventType eventType; // 0x20
					initparam.boostType = MusicSelectConsts.PlayBoostType.Max; // 0x24									public MusicSelectConsts.PlayBoostType boostType; // 0x24
					initparam.eventPeriod = GetEventPeriodString(musicData.NOKBLCDMLPP_MinigameEventInfo.KINJOEIAHFK_OpenTime, musicData.NOKBLCDMLPP_MinigameEventInfo.PCCFAKEOBIC_CloseTime); // 0x28								public string eventPeriod; // 0x28
					initparam.musicTimeStr = null; // 0x2C								public string musicTimeStr; // 0x2C
					initparam.musicName = null; // 0x30									public string musicName; // 0x30
					initparam.musicName_2 = null;
					initparam.musicName_3 = null;
					initparam.vocalName = null; // 0x34									public string vocalName; // 0x34
					initparam.musicTime = musicTime; // 0x38									public int musicTime; // 0x38
					MusicListData data = new MusicListData(initparam);
					res.Add(data);
				}
				else
				{
					KEODKEGFDLD_FreeMusicInfo freeMusicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[musicData.GHBPLHBNMBK_FreeMusicId - 1];
					EONOEHOKBEB_Music musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.INJDLHAEPEK_GetMusicInfo(musicData.GHBPLHBNMBK_FreeMusicId, freeMusicInfo.DLAEJOBELBH_MusicId);
					string musicName = Database.Instance.musicText.Get(musicInfo.KNMGEEFGDNI_Nam).musicName;
					string vocalName = Database.Instance.musicText.Get(musicInfo.KNMGEEFGDNI_Nam).vocalName;
					string musicName_2 = Database.Instance.musicText.Get(musicInfo.KNMGEEFGDNI_Nam).musicName_2;
					string musicName_3 = Database.Instance.musicText.Get(musicInfo.KNMGEEFGDNI_Nam).musicName_3;
					int seconds = 0;
					int days, hours, minutes;
					MusicSelectSceneBase.ExtractRemainTime(musicTime / 1000, out days, out hours, out minutes, out seconds);
					string remainingTimeStr = string.Format(musicTimeFormat, minutes, seconds);
					MusicSelectConsts.MusicTimeType timeType = musicTime < musicTypeThreshold ? MusicSelectConsts.MusicTimeType.Short : MusicSelectConsts.MusicTimeType.Long;
					int eventData = musicData.MNNHHJBBICA_GameEventType;
					MusicSelectConsts.EventType eventType ;
					if (eventData < 12)
					{
						if (((1 << eventData & 0xff) & 0xc4a) == 0) // 110001001010
						{
							if (((1 << eventData & 0xff) & 0x394) == 0) // 001110010100
							{
								if (eventData != 5)
								{
									eventType = MusicSelectConsts.EventType.Max;
									if (eventData == 14)
										eventType = MusicSelectConsts.EventType.Special;
								}
								else
								{
									eventType = MusicSelectConsts.EventType.Weekly;
								}
							}
							else
								eventType = MusicSelectConsts.EventType.Max;
						}
						else eventType = MusicSelectConsts.EventType.Special;
					}
					else
					{
						eventType = MusicSelectConsts.EventType.Max;
						if (eventData == 14)
							eventType = MusicSelectConsts.EventType.Special;
					}
					if (musicData.LEBDMNIGOJB_IsScoreEvent)
						eventType = MusicSelectConsts.EventType.ScoreRanking;
					MusicSelectConsts.PlayBoostType boostType = MusicSelectConsts.PlayBoostType.Max;
					if(musicData.LHONOILACFL_IsWeeklyEvent)
					{
						eventType = MusicSelectConsts.EventType.Weekly;
						boostType = !musicData.GDLNCHCPMCK_HasBoost ? MusicSelectConsts.PlayBoostType.Max : MusicSelectConsts.PlayBoostType.Boost;
					}
					string eventPeriodString = null;
					if (eventController == null || !musicData.EHNGOGBJMGL)
					{
						;
					}
					else
					{
						eventPeriodString = GetEventPeriodString(eventController.GLIMIGNNGGB_Start, eventController.DPJCPDKALGI_End1);
						if (musicData.AHAEGEHKONB_GetOtherTimeLeft() == 0)
						{
							continue;
						}
					}
					//LAB_00ca1d50
					if (musicData.KCKBOIDCPCK_CdSelectEvenType > 0)
					{
						eventData = musicData.KCKBOIDCPCK_CdSelectEvenType - 1; // ?not sure still event data
						if (eventData < 6 && ((0x2f >> (eventData & 0xff)) & 1) != 0)
						{
							MusicSelectConsts.EventType[] _ = 
							{
								MusicSelectConsts.EventType.Weekly,
								MusicSelectConsts.EventType.Special,
								MusicSelectConsts.EventType.Special,
								MusicSelectConsts.EventType.Birthday,
								MusicSelectConsts.EventType.Weekly,
								MusicSelectConsts.EventType.Special
							};
							eventType = _[eventData];
						}
					}
					long aprilFoolEndTime = 0;
					bool isHighLevel;
					if (!musicData.FGKMJHKLGLD)
					{
						isHighLevel = false;
					}
					else
					{
						isHighLevel = false;
						List<IKDICBBFBMI_EventBase> list = GetEventControllerList(OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), KGCNCBOKCBA.GNENJEHKMHD_EventStatus.KPMNPGKKFJG);
						for (int j = 0; j < list.Count; j++)
						{
							AMLGMLNGMFB_EventAprilFool eventApril = list[j] as AMLGMLNGMFB_EventAprilFool;
							if (musicData.EKANGPODCEP_EventId == eventApril.PGIIDPEGGPI_EventId)
							{
								KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP dd = eventApril.KOBMFPACBMB().Find((KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP x) =>
								{
									//0xCA3DB4
									return x.MPLGPBNJDJB_FreeMusicId == musicData.GHBPLHBNMBK_FreeMusicId;
								});
								aprilFoolEndTime = eventApril.DPJCPDKALGI_End1;
								if (dd.FDBNFFNFOND_CloseAt != 0)
								{
									aprilFoolEndTime = dd.FDBNFFNFOND_CloseAt;
								}
								if (eventApril.HLPEBPOPCPI_GetChangeMusicSelectUI() != 0 && dd.PPFNGGCBJKC_Id == eventApril.HLPEBPOPCPI_GetChangeMusicSelectUI())
								{
									isHighLevel = true;
								}
							}
						}
					}
					bool isOpen = true;
					if (musicData.DEPGBBJMFED_CategoryId != 5)
					{
						isOpen = IBJAKJJICBC.LBHPMGDNPHK_IsMusicOpen(musicData.GHBPLHBNMBK_FreeMusicId, musicData.DEPGBBJMFED_CategoryId);
						if (musicData.HAMPEDFMIAD_HasOnlyMultiDivaMode())
						{
							isOpen &= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("multi_dance_player_level", 3) <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
						}
					}
					MusicSelectConsts.MusicType musicType = (MusicSelectConsts.MusicType)(musicData.EEFLOOBOAGF % 10);
					if (musicType > MusicSelectConsts.MusicType.Another)
						musicType = MusicSelectConsts.MusicType.None;
					bool isUnlockable;
					if (lastStoryFreeMusicId == 0)
					{
						isUnlockable = false;
					}
					else
					{
						isUnlockable = musicData.GHBPLHBNMBK_FreeMusicId == lastStoryFreeMusicId;
					}
					MusicListData.InitParam initparam;
					initparam.viewMusic = musicData; // 0x0									public IBJAKJJICBC viewMusic; // 0x0
					initparam.rewardStat = rewardList; // 0x4						public List<MusicRewardStat> rewardStat; // 0x4
					initparam.aprilFoolEndTime = aprilFoolEndTime; // 0x8							public long aprilFoolEndTime; // 0x8
					initparam.isOpen = isOpen/* || RuntimeSettings.CurrentSettings.ForceSongUnlock*/; // 0x10	public bool isOpen; // 0x10		var13
					initparam.isNew = musicData.LDGOHPAPBMM_IsNew; // 0x11										public bool isNew; // 0x11	local88
					initparam.isUnlockable = isUnlockable; // 0x12								public bool isUnlockable; // 0x12
					initparam.isSimulation = musicData.EHNGOGBJMGL; // 0x13								public bool isSimulation; // 0x13		musicData.EHNGOGBJMGL - uVar13 - musicData.LDGOHPAPBMM - local_88
					initparam.isHighLevel = isHighLevel; // 0x14								public bool isHighLevel; // 0x14
					initparam.timeType = timeType; // 0x18									public MusicSelectConsts.MusicTimeType timeType; // 0x18
					initparam.musicType = musicType; // 0x1C									public MusicSelectConsts.MusicType musicType; // 0x1C
					initparam.eventType = eventType; // 0x20									public MusicSelectConsts.EventType eventType; // 0x20
					initparam.boostType = boostType; // 0x24									public MusicSelectConsts.PlayBoostType boostType; // 0x24
					initparam.eventPeriod = eventPeriodString; // 0x28								public string eventPeriod; // 0x28
					initparam.musicTimeStr = remainingTimeStr; // 0x2C								public string musicTimeStr; // 0x2C
					initparam.musicName = musicName; // 0x30									public string musicName; // 0x30
					initparam.vocalName = vocalName; // 0x34									public string vocalName; // 0x34
					initparam.musicTime = musicTime; // 0x38									public int musicTime; // 0x38
					initparam.musicName_2 = musicName_2;
					initparam.musicName_3 = musicName_3;
					MusicListData data = new MusicListData(initparam);
					res.Add(data);
				}
			}
			return res;
		}

		//// RVA: 0xCA24B0 Offset: 0xCA24B0 VA: 0xCA24B0
		private static List<IKDICBBFBMI_EventBase> GetEventControllerList(OHCAABOMEOF.KGOGMKMBCPP_EventType type, long currentTime, KGCNCBOKCBA.GNENJEHKMHD_EventStatus term = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived)
		{
			List<IKDICBBFBMI_EventBase> res = new List<IKDICBBFBMI_EventBase>();
			List<IKDICBBFBMI_EventBase> list = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.FindAll((IKDICBBFBMI_EventBase _) =>
			{
				//0xCA3E0C
				return _.HIDHLFCBIDE_EventType == type;
			});
			for(int i = 0; i < list.Count; i++)
			{
				list[i].HCDGELDHFHB_UpdateStatus(currentTime);
				if(list[i].NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1 && list[i].NGOFCFJHOMI_Status <= term)
				{
					res.Add(list[i]);
				}
			}
			return res;
		}

		//// RVA: 0xCA2728 Offset: 0xCA2728 VA: 0xCA2728
		public static string GetEventPeriodString(long openTime, long closeTime)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(closeTime != 0)
			{
				if (closeTime % 100 == 0)
					closeTime -= 1;
			}
			DateTime d1 = Utility.GetLocalDateTime(openTime);
			DateTime d2 = Utility.GetLocalDateTime(closeTime);
			return string.Format(bk.GetMessageByLabel("vertical_music_select_event_period"), new object[10]
			{
				d1.Year, d1.Month, d1.Day, d1.Hour, d1.Minute,
				d2.Year, d2.Month, d2.Day, d2.Hour, d2.Minute
			});
		}

		//// RVA: 0xCA2ED4 Offset: 0xCA2ED4 VA: 0xCA2ED4
		public int GetCount(bool line6Mode, bool simulation)
		{
			List<MusicListData> data;
			if(simulation)
			{
				if(line6Mode)
				{
					data = m_viewSimulationList;
				}
				else
				{
					data = m_viewSimulation6LineList;
				}
			}
			else if(line6Mode)
			{
				data = m_viewList;
			}
			else
			{
				data = m_view6LineList;
			}
			return data.Count;
		}

		//// RVA: 0xCA2FA4 Offset: 0xCA2FA4 VA: 0xCA2FA4
		public MusicListData Get(int index, bool line6Mode, bool simulation)
		{
			List<MusicListData> data;
			if(simulation)
			{
				if(line6Mode)
				{
					data = m_viewSimulationList;
				}
				else
				{
					data = m_viewSimulation6LineList;
				}
			}
			else if(line6Mode)
			{
				data = m_viewList;
			}
			else
			{
				data = m_view6LineList;
			}
			if(index >= data.Count)
				return null;
			return data[index];
		}

		//// RVA: 0xCA2F78 Offset: 0xCA2F78 VA: 0xCA2F78
		public List<MusicListData> GetList(bool line6Mode, bool simulation)
		{
			List<MusicListData> data;
			if(simulation)
			{
				if(line6Mode)
				{
					data = m_viewSimulationList;
				}
				else
				{
					data = m_viewSimulation6LineList;
				}
			}
			else if(line6Mode)
			{
				data = m_viewList;
			}
			else
			{
				data = m_view6LineList;
			}
			return data;
		}

		//// RVA: 0xCA3088 Offset: 0xCA3088 VA: 0xCA3088
		public void UpdateDownloadState(int musicId)
		{
			for(int i = 0; i < GetCount(false, false); i++)
			{
				var music = Get(i, false, false).ViewMusic;
				if (music.DLAEJOBELBH_MusicId == musicId)
				{
					music.OBGKIMDIAJF_CheckIsDlded();
				}
			}
			for (int i = 0; i < GetCount(true, false); i++)
			{
				var music = Get(i, true, false).ViewMusic;
				if (music.DLAEJOBELBH_MusicId == musicId)
				{
					music.OBGKIMDIAJF_CheckIsDlded();
				}
			}
			for (int i = 0; i < GetCount(false, true); i++) // Fixed from original game where it was a second time true,false
			{
				var music = Get(i, false, true).ViewMusic;
				if (music.DLAEJOBELBH_MusicId == musicId)
				{
					music.OBGKIMDIAJF_CheckIsDlded();
				}
			}
			for (int i = 0; i < GetCount(true, true); i++)
			{
				var music = Get(i, true, true).ViewMusic;
				if (music.DLAEJOBELBH_MusicId == musicId)
				{
					music.OBGKIMDIAJF_CheckIsDlded();
				}
			}
		}

		//// RVA: 0xCA3330 Offset: 0xCA3330 VA: 0xCA3330
		public int FindIndex(int freeMusicId, bool line6Mode, bool simulation)
		{
			return FindIndex((MusicListData _) =>
			{
				//0xCA3BF4
				return _.ViewMusic.GHBPLHBNMBK_FreeMusicId == freeMusicId;
			}, line6Mode, simulation);
		}

		//// RVA: 0xCA34CC Offset: 0xCA34CC VA: 0xCA34CC
		public int FindIndex(int freeMusicId, OHCAABOMEOF.KGOGMKMBCPP_EventType gameEventType, bool line6Mode, bool simulation)
		{
			return FindIndex((MusicListData _) =>
			{
				//0xCA3C4C
				return _.ViewMusic.GHBPLHBNMBK_FreeMusicId == freeMusicId && _.ViewMusic.MNNHHJBBICA_GameEventType == (int)gameEventType;
			}, line6Mode, simulation);
		}

		//// RVA: 0xCA3424 Offset: 0xCA3424 VA: 0xCA3424
		public int FindIndex(Predicate<MusicListData> match, bool line6Mode, bool simulation)
		{
			List<MusicListData> list = null;
			if (simulation)
			{
				if(line6Mode)
				{
					list = m_viewSimulationList;
				}
				else
				{
					list = m_viewSimulation6LineList;
				}
			}
			else
			{
				if(line6Mode)
				{
					list = m_viewList;
				}
				else
				{
					list = m_view6LineList;
				}
			}
			if (list != null)
				return list.FindIndex(match);
			return 0;
		}

		//// RVA: 0xCA35DC Offset: 0xCA35DC VA: 0xCA35DC
		public MusicListData Find(int freeMusicId, bool line6Mode, bool simulation)
		{
			return Find((MusicListData _) =>
			{
				//0xCA3CD4
				return _.ViewMusic.GHBPLHBNMBK_FreeMusicId == freeMusicId;
			}, line6Mode, simulation);
		}

		//// RVA: 0xCA3778 Offset: 0xCA3778 VA: 0xCA3778
		//public VerticalMusicDataList.MusicListData Find(int freeMusicId, OHCAABOMEOF.KGOGMKMBCPP gameEventType, bool line6Mode, bool simulation) { }

		//// RVA: 0xCA36D0 Offset: 0xCA36D0 VA: 0xCA36D0
		public MusicListData Find(Predicate<MusicListData> match, bool line6Mode, bool simulation)
		{
			if(simulation)
			{
				if(line6Mode)
				{
					if(m_viewSimulationList != null)
						return m_viewSimulationList.Find(match);
				}
				else
				{
					if(m_viewSimulation6LineList != null)
						return m_viewSimulation6LineList.Find(match);
				}
			}
			else
			{
				if(line6Mode)
				{
					if(m_viewList != null)
						return m_viewList.Find(match);
				}
				else
				{
					if(m_view6LineList != null)
						return m_view6LineList.Find(match);
				}
			}
			return null;
		}

		//// RVA: 0xCA3888 Offset: 0xCA3888 VA: 0xCA3888
		public void AddList(List<MusicListData> addList, bool line6Mode, bool simulation)
		{
			List<MusicListData> inList;
			if(simulation)
			{
				if(line6Mode)
				{
					inList = m_viewSimulationList;
				}
				else
				{
					inList = m_viewSimulation6LineList;
				}
			}
			else if(line6Mode)
				inList = m_viewList;
			else
				inList = m_view6LineList;
			foreach(MusicListData data in addList)
			{
				inList.Add(data);
			}
		}

		//// RVA: 0xCA3A24 Offset: 0xCA3A24 VA: 0xCA3A24
		public void Clear()
		{
			m_viewList.Clear();
			m_view6LineList.Clear();
			m_viewSimulationList.Clear();
			m_viewSimulation6LineList.Clear();
		}
	}
}
