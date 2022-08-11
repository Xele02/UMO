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
			public string VocalName { get; } // 0x2C
			public int MusicTime { get; } // 0x30
			public MusicSelectConsts.MusicTimeType TimeType { get; } = MusicSelectConsts.MusicTimeType.Max; // 0x34
			public MusicSelectConsts.EventType EventType { get; } = MusicSelectConsts.EventType.Max; // 0x38
			public MusicSelectConsts.MusicType MusicType { get; } = MusicSelectConsts.MusicType.Max; // 0x3C
			public MusicSelectConsts.PlayBoostType PlayBoostType { get; } = MusicSelectConsts.PlayBoostType.Max; // 0x40

			//	// RVA: 0xCA2E0C Offset: 0xCA2E0C VA: 0xCA2E0C
			public MusicListData(VerticalMusicDataList.MusicListData.InitParam initParam)
			{
				TodoLogger.Log(0, "MusicListData()");
				MusicName = initParam.musicName;
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

		private List<VerticalMusicDataList.MusicListData> m_viewList = new List<VerticalMusicDataList.MusicListData>(); // 0x8
		private List<VerticalMusicDataList.MusicListData> m_view6LineList = new List<VerticalMusicDataList.MusicListData>(); // 0xC
		private List<VerticalMusicDataList.MusicListData> m_viewSimulationList = new List<VerticalMusicDataList.MusicListData>(); // 0x10
		private List<VerticalMusicDataList.MusicListData> m_viewSimulation6LineList = new List<VerticalMusicDataList.MusicListData>(); // 0x14

		//// RVA: 0xCA0F60 Offset: 0xCA0F60 VA: 0xCA0F60
		public static List<VerticalMusicDataList.MusicListData> CreateMusicListData(List<IBJAKJJICBC> viewMusicDataList, IKDICBBFBMI_EventBase eventController, bool line6Mode, int musicTypeThreshold, int lastStoryFreeMusicId)
		{
			string musicTimeFormat = MessageManager.Instance.GetBank("menu").GetMessageByLabel("vertical_music_select_music_time");
			List<VerticalMusicDataList.MusicListData> res = new List<VerticalMusicDataList.MusicListData>();
			FPGEMAIAMBF b = new FPGEMAIAMBF();
			for(int i = 0; i < viewMusicDataList.Count; i++)
			{
				List<MusicRewardStat> rewardList = new List<MusicRewardStat>();
				IBJAKJJICBC musicData = viewMusicDataList[i];
				int val = 0;
				for(int j = 0; j < musicData.MGJKEJHEBPO_DiffInfos.Count; j++)
				{
					MusicRewardStat reward = new MusicRewardStat();
					b.JMHCEMHPPCM(musicData.GHBPLHBNMBK_FreeMusicId, j, line6Mode, musicData.MNNHHJBBICA_EventType);
					reward.Init(b);
					rewardList.Add(reward);
					if(val < musicData.MGJKEJHEBPO_DiffInfos[i].HHMLMKAEJBJ_Score.MCMIPODICAN_length)
					{
						val = musicData.MGJKEJHEBPO_DiffInfos[i].HHMLMKAEJBJ_Score.MCMIPODICAN_length;
					}
				}
				if(musicData.AJGCPCMLGKO)
				{
					int val2 = 5;
					if(((int)musicData.AFCMIOIGAJN.HIDHLFCBIDE_EventCategory - 1) < 14)
					{
						int[] d = { 0, 5, 0, 5, 2, 0, 5, 5, 5, 0, 0, 5, 5, 0 };
						val2 = d[((int)musicData.AFCMIOIGAJN.HIDHLFCBIDE_EventCategory - 1)];
					}
					int val3 = 1;
					if(lastStoryFreeMusicId == 0)
					{
						val3 = 0;
					}
					else
					{
						val3 = musicData.GHBPLHBNMBK_FreeMusicId == lastStoryFreeMusicId;
					}
					MusicListData.InitParam initparam;
					initparam.viewMusic = ; // 0x0
					initparam.rewardStat = rewardList; // 0x4
					initparam.aprilFoolEndTime = ; // 0x8
					initparam.isOpen = ; // 0x10
					initparam.isNew = ; // 0x11
					initparam.isUnlockable = ; // 0x12
					initparam.isSimulation = ; // 0x13
					initparam.isHighLevel = ; // 0x14
					initparam.timeType = ; // 0x18
					initparam.musicType = ; // 0x1C
					initparam.eventType = ; // 0x20
					initparam.boostType = ; // 0x24
					initparam.eventPeriod = ; // 0x28
					initparam.musicTimeStr = ; // 0x2C
					initparam.musicName = ; // 0x30
					initparam.vocalName = ; // 0x34
					initparam.musicTime = ; // 0x38
					MusicListData data = new MusicListData(initparam);
					res.Add(data);
					/*
					CONCAT460(piVar8, 
					CONCAT456(in_stack_fffffee0,
					ZEXT5256(
						CONCAT448(local_50, 
						CONCAT444(local_ac,				null
						CONCAT440(local_a8,				null
						CONCAT436(local_b4,				null
						CONCAT432(local_98,				GetEventPeriodString
						CONCAT428(local_94,				1
						CONCAT424(local_8c,				val2
						CONCAT420(iVar25,				0
						CONCAT416(local_b0,				2
						CONCAT412(local_b8,				0
						CONCAT48(in_stack_fffffeb0,
							(uint)bVar2 << 0x18 |		musicData.EHNGOGBJMGL
							(uint)bVar1 << 8 |			musicData.LDGOHPAPBMM
							local_88 |					1
							uVar13 << 0x10;				val3
						CONCAT44(local_74,				 0
							seconds)					0
							*/
				}
				else if(musicData.BNIAJAKIAJC)
				{
					TodoLogger.Log(0, "CreateMusicListData event 2");
				}
				else
				{
					KEODKEGFDLD freeMusicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[musicData.GHBPLHBNMBK_FreeMusicId - 1];
					EONOEHOKBEB_Music musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.INJDLHAEPEK_GetMusicInfo(musicData.GHBPLHBNMBK_FreeMusicId, freeMusicInfo.DLAEJOBELBH_Id);
					string musicName = Database.Instance.musicText.Get(musicInfo.KNMGEEFGDNI_Nam).musicName;
					string vocalName = Database.Instance.musicText.Get(musicInfo.KNMGEEFGDNI_Nam).vocalName;
					int local74 = 0;
					int seconds = 0;
					int days, hours, minutes;
					MusicSelectSceneBase.ExtractRemainTime(val / 1000.0f, out days, out hours, out minutes, out seconds);
					string remainingTimeStr = string.Format(musicTimeFormat, minutes, seconds);
					bool localb0 = val < musicTypeThreshold;
					int eventData = musicData.MNNHHJBBICA_EventType;
					if(eventData < 12)
					{
						//L582
					}
					/*
					CONCAT460(piVar8, 
					CONCAT456(in_stack_fffffee0,
					ZEXT5256(
						CONCAT448(local_50, 
						CONCAT444(local_ac,				vocalName
						CONCAT440(local_a8,				musicName
						CONCAT436(local_b4,				remainingTimeStr
						CONCAT432(local_98,				
						CONCAT428(local_94,				
						CONCAT424(local_8c,				
						CONCAT420(iVar25,				
						CONCAT416(local_b0,				
						CONCAT412(local_b8,				
						CONCAT48(in_stack_fffffeb0,
							(uint)bVar2 << 0x18 |		
							(uint)bVar1 << 8 |			
							local_88 |					
							uVar13 << 0x10;			
						CONCAT44(local_74,				 
							seconds)					
							*/
				}

				TodoLogger.Log(0, "CreateMusicListData !!!");
				/*MusicListData.InitParam initparam;
				int id = viewMusicDataList[i].GHBPLHBNMBK_FreeMusicId;
				KEODKEGFDLD musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[id - 1];
				EONOEHOKBEB_Music a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.INJDLHAEPEK_GetMusicInfo(id, musicInfo.DLAEJOBELBH_Id);
				initparam.musicName = Database.Instance.musicText.Get(a.KNMGEEFGDNI_Nam).musicName;
				initparam.viewMusic = viewMusicDataList[i]; // to check
				initparam.isHighLevel = false;
				initparam.aprilFoolEndTime = 0; // TODO
				initparam.isOpen = true; // TODO
				initparam.isSimulation = true; // TODO
				initparam.isUnlockable = false; // TODO
				initparam.musicTimeStr = ""; // TODO
				initparam.timeType = MusicSelectConsts.MusicTimeType.Short; // TODO
				initparam.isNew = false;
				initparam.musicType = MusicSelectConsts.MusicType.None;
				initparam.rewardStat = new List<MusicRewardStat>();
				initparam.eventType = MusicSelectConsts.EventType.Max;
				initparam.boostType = MusicSelectConsts.PlayBoostType.Max;
				initparam.vocalName = "Vocal";
				initparam.eventPeriod = "";
				MusicListData data = new MusicListData(initparam);
				res.Add(data);*/
			}
			return res;
		}

		//// RVA: 0xCA24B0 Offset: 0xCA24B0 VA: 0xCA24B0
		//private static List<IKDICBBFBMI> GetEventControllerList(OHCAABOMEOF.KGOGMKMBCPP type, long currentTime, KGCNCBOKCBA.GNENJEHKMHD term = 9) { }

		//// RVA: 0xCA2728 Offset: 0xCA2728 VA: 0xCA2728
		//public static string GetEventPeriodString(long openTime, long closeTime) { }

		//// RVA: 0xCA2ED4 Offset: 0xCA2ED4 VA: 0xCA2ED4
		public int GetCount(bool line6Mode, bool simulation)
		{
			List<VerticalMusicDataList.MusicListData> data;
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
		public VerticalMusicDataList.MusicListData Get(int index, bool line6Mode, bool simulation)
		{
			List<VerticalMusicDataList.MusicListData> data;
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
		public List<VerticalMusicDataList.MusicListData> GetList(bool line6Mode, bool simulation)
		{
			List<VerticalMusicDataList.MusicListData> data;
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
		//public void UpdateDownloadState(int musicId) { }

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
			return FindIndex((VerticalMusicDataList.MusicListData _) =>
			{
				//0xCA3C4C
				return _.ViewMusic.GHBPLHBNMBK_FreeMusicId == freeMusicId && _.ViewMusic.MNNHHJBBICA_EventType == (int)gameEventType;
			}, line6Mode, simulation);
		}

		//// RVA: 0xCA3424 Offset: 0xCA3424 VA: 0xCA3424
		public int FindIndex(Predicate<VerticalMusicDataList.MusicListData> match, bool line6Mode, bool simulation)
		{
			List<VerticalMusicDataList.MusicListData> list = null;
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
		//public VerticalMusicDataList.MusicListData Find(int freeMusicId, bool line6Mode, bool simulation) { }

		//// RVA: 0xCA3778 Offset: 0xCA3778 VA: 0xCA3778
		//public VerticalMusicDataList.MusicListData Find(int freeMusicId, OHCAABOMEOF.KGOGMKMBCPP gameEventType, bool line6Mode, bool simulation) { }

		//// RVA: 0xCA36D0 Offset: 0xCA36D0 VA: 0xCA36D0
		//public VerticalMusicDataList.MusicListData Find(Predicate<VerticalMusicDataList.MusicListData> match, bool line6Mode, bool simulation) { }

		//// RVA: 0xCA3888 Offset: 0xCA3888 VA: 0xCA3888
		public void AddList(List<VerticalMusicDataList.MusicListData> addList, bool line6Mode, bool simulation)
		{
			List<VerticalMusicDataList.MusicListData> inList;
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
