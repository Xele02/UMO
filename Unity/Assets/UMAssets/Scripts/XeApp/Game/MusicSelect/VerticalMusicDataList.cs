using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.MusicSelect
{
	public class VerticalMusicDataList
	{

		public class MusicListData
		{
			public struct InitParam
			{
				public IBJAKJJICBC viewMusic; // 0x0
				// public List<MusicRewardStat> rewardStat; // 0x4
				// public long aprilFoolEndTime; // 0x8
				// public bool isOpen; // 0x10
				// public bool isNew; // 0x11
				// public bool isUnlockable; // 0x12
				// public bool isSimulation; // 0x13
				// public bool isHighLevel; // 0x14
				// public MusicSelectConsts.MusicTimeType timeType; // 0x18
				// public MusicSelectConsts.MusicType musicType; // 0x1C
				// public MusicSelectConsts.EventType eventType; // 0x20
				// public MusicSelectConsts.PlayBoostType boostType; // 0x24
				// public string eventPeriod; // 0x28
				// public string musicTimeStr; // 0x2C
				public string musicName; // 0x30
				// public string vocalName; // 0x34
				// public int musicTime; // 0x38
			}
			//	private List<MusicRewardStat> m_rewardStat = new List<MusicRewardStat>(); // 0xC

			public IBJAKJJICBC ViewMusic { get; } = new IBJAKJJICBC(); // 0x8
			//	public List<MusicRewardStat> RewardStat { get; } 0xCA3E58
			//	public long AprilFoolEndTime { get; } // 0x10
			//	public bool IsOpen { get; } = false; // 0x18
			//	public bool IsUnlockable { get; } = false; // 0x19
			//	public bool IsNew { get; } = false; //0x1A
			//	public bool IsSimulation { get; } = false; // 0x1B
			//	public bool IsHighLevel { get; } = false; // 0x1C
			//	public string EventPeriod { get; } // 0x20
			//	public string MusicTimeStr { get; } // 0x24
				public string MusicName { get; } // 0x28
			//	public string VocalName { get; } // 0x2C
			//	public int MusicTime { get; } // 0x30
			//	public MusicSelectConsts.MusicTimeType TimeType { get; } = 2; // 0x34
			//	public MusicSelectConsts.EventType EventType { get; } = 5; // 0x38
			//	public MusicSelectConsts.MusicType MusicType { get; } = 3; // 0x3C
			//	public MusicSelectConsts.PlayBoostType PlayBoostType { get; } = 1; // 0x40

			//	// RVA: 0xCA2E0C Offset: 0xCA2E0C VA: 0xCA2E0C
			public MusicListData(VerticalMusicDataList.MusicListData.InitParam initParam)
			{
				UnityEngine.Debug.LogError("TODO MusicListData()");
				MusicName = initParam.musicName;
				ViewMusic = initParam.viewMusic;
			}
		}

		private List<VerticalMusicDataList.MusicListData> m_viewList = new List<VerticalMusicDataList.MusicListData>(); // 0x8
		private List<VerticalMusicDataList.MusicListData> m_view6LineList = new List<VerticalMusicDataList.MusicListData>(); // 0xC
		private List<VerticalMusicDataList.MusicListData> m_viewSimulationList = new List<VerticalMusicDataList.MusicListData>(); // 0x10
		private List<VerticalMusicDataList.MusicListData> m_viewSimulation6LineList = new List<VerticalMusicDataList.MusicListData>(); // 0x14

		//// RVA: 0xCA0F60 Offset: 0xCA0F60 VA: 0xCA0F60
		public static List<VerticalMusicDataList.MusicListData> CreateMusicListData(List<IBJAKJJICBC> viewMusicDataList, IKDICBBFBMI eventController, bool line6Mode, int musicTypeThreshold, int lastStoryFreeMusicId)
		{
			UnityEngine.Debug.LogError("TODO CreateMusicListData !!!");

			List<VerticalMusicDataList.MusicListData> res =  new List<VerticalMusicDataList.MusicListData>();
			for(int i = 0; i < viewMusicDataList.Count; i++)
			{
				MusicListData.InitParam initparam;
				int id = viewMusicDataList[i].GHBPLHBNMBK;
				KEODKEGFDLD musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[id - 1];
				EONOEHOKBEB_Music a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.INJDLHAEPEK_GetMusicInfo(id, musicInfo.DLAEJOBELBH_Id);
				initparam.musicName = Database.Instance.musicText.Get(a.KNMGEEFGDNI_Nam).musicName;
				initparam.viewMusic = viewMusicDataList[i]; // to check
				//initparam.musicName = "Music "+id;
				VerticalMusicDataList.MusicListData data = new VerticalMusicDataList.MusicListData(initparam);
				res.Add(data);
			}
			return res;
		}

		//// RVA: 0xCA24B0 Offset: 0xCA24B0 VA: 0xCA24B0
		//private static List<IKDICBBFBMI> GetEventControllerList(OHCAABOMEOF.KGOGMKMBCPP type, long currentTime, KGCNCBOKCBA.GNENJEHKMHD term = 9) { }

		//// RVA: 0xCA2728 Offset: 0xCA2728 VA: 0xCA2728
		//public static string GetEventPeriodString(long openTime, long closeTime) { }

		//// RVA: 0xCA2ED4 Offset: 0xCA2ED4 VA: 0xCA2ED4
		//public int GetCount(bool line6Mode, bool simulation) { }

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
		//public int FindIndex(int freeMusicId, bool line6Mode, bool simulation) { }

		//// RVA: 0xCA34CC Offset: 0xCA34CC VA: 0xCA34CC
		//public int FindIndex(int freeMusicId, OHCAABOMEOF.KGOGMKMBCPP gameEventType, bool line6Mode, bool simulation) { }

		//// RVA: 0xCA3424 Offset: 0xCA3424 VA: 0xCA3424
		//public int FindIndex(Predicate<VerticalMusicDataList.MusicListData> match, bool line6Mode, bool simulation) { }

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
