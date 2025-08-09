using System;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class MusicDataList
	{
		private List<IBJAKJJICBC> m_viewList; // 0x8
		private List<IBJAKJJICBC> m_view6LineList; // 0xC
		private List<IBJAKJJICBC> m_viewSimulationList; // 0x10
		private List<IBJAKJJICBC> m_view6LineSimulationList; // 0x14

		// // RVA: 0x10494DC Offset: 0x10494DC VA: 0x10494DC
		public int GetCount(bool line6Mode, bool simulation/* = False*/)
		{
			List<IBJAKJJICBC> l;
			if(simulation)
			{
				if(!line6Mode)
					l = m_viewSimulationList;
				else
					l = m_view6LineSimulationList;
			}
			else
			{
				if(!line6Mode)
					l = m_viewList;
				else
					l = m_view6LineList;
			}
			if(l != null)
			{
				return l.Count;
			}
			return 0;
		}

		// // RVA: 0x10495A8 Offset: 0x10495A8 VA: 0x10495A8
		public IBJAKJJICBC Get(int index, bool line6Mode, bool simulation/* = False*/)
		{
			List<IBJAKJJICBC> l;
			if(simulation)
			{
				if(!line6Mode)
					l = m_viewSimulationList;
				else
					l = m_view6LineSimulationList;
			}
			else
			{
				if(!line6Mode)
					l = m_viewList;
				else
					l = m_view6LineList;
			}
			if(l != null)
			{
				return l[index];
			}
			return null;
		}

		// // RVA: 0x104957C Offset: 0x104957C VA: 0x104957C
		public List<IBJAKJJICBC> GetList(bool line6Mode, bool simulation/* = False*/)
		{
			if(simulation)
			{
				if(!line6Mode)
					return m_viewSimulationList;
				else
					return m_view6LineSimulationList;
			}
			else
			{
				if(!line6Mode)
					return m_viewList;
				else
					return m_view6LineList;
			}
		}

		// // RVA: 0x1049650 Offset: 0x1049650 VA: 0x1049650
		public bool ContainsNew(bool simulation/* = False*/)
		{
			for(int i = 0; i < GetCount(false, simulation); i++)
			{
                IBJAKJJICBC m = Get(i, false, simulation);
                if (!m.AJGCPCMLGKO_IsEvent && !m.BNIAJAKIAJC_IsEventMinigame && !m.POEGGBGOKGI_IsInfoLiveEntrance && m.CADENLBDAEB_IsNew)
					return true;
			}
			return false;
		}

		// // RVA: 0x1049750 Offset: 0x1049750 VA: 0x1049750
		public int FindIndex(int freeMusicId, bool line6Mode/* = False*/, bool simulation/* = False*/)
		{
			return FindIndex((IBJAKJJICBC _) =>
			{
				//0x104A274
				return freeMusicId == _.GHBPLHBNMBK_FreeMusicId;
			}, line6Mode, simulation);
		}

		// // RVA: 0x10498EC Offset: 0x10498EC VA: 0x10498EC
		public int FindIndex(int freeMusicId, OHCAABOMEOF.KGOGMKMBCPP_EventType gameEventType, bool line6Mode = false, bool simulation = false)
		{
			return FindIndex((IBJAKJJICBC _) => {
				//0x104A274
				return freeMusicId == _.GHBPLHBNMBK_FreeMusicId;
			}, line6Mode, simulation);
		}

		// // RVA: 0x1049844 Offset: 0x1049844 VA: 0x1049844
		public int FindIndex(Predicate<IBJAKJJICBC> match, bool line6Mode = false, bool simulation = false)
		{
			List<IBJAKJJICBC> list;
			if(simulation)
			{
				if(!line6Mode)
				{
					list = m_viewSimulationList;
				}
				else
				{
					list = m_view6LineSimulationList;
				}
			}
			else if(!line6Mode)
			{
				list = m_viewList;
			}
			else
			{
				list = m_view6LineList;
			}
			if(list != null)
				return list.FindIndex(match);
			return 0;
		}

		// // RVA: 0x1038590 Offset: 0x1038590 VA: 0x1038590
		public IBJAKJJICBC Find(int freeMusicId, bool line6Mode/* = False*/, bool simulation/* = False*/)
		{
			return Find((IBJAKJJICBC _) =>
			{
				//0x104A1C0
				return _.GHBPLHBNMBK_FreeMusicId == freeMusicId;
			}, line6Mode, simulation);
		}

		// // RVA: 0x1049AAC Offset: 0x1049AAC VA: 0x1049AAC
		// public IBJAKJJICBC Find(int freeMusicId, OHCAABOMEOF.KGOGMKMBCPP gameEventType, bool line6Mode = False, bool simulation = False) { }

		// // RVA: 0x1049A04 Offset: 0x1049A04 VA: 0x1049A04
		public IBJAKJJICBC Find(Predicate<IBJAKJJICBC> match, bool line6Mode/* = False*/, bool simulation/* = False*/)
		{
			if(simulation)
			{
				if(!line6Mode)
				{
					if(m_viewSimulationList != null)
						return m_viewSimulationList.Find(match);
				}
				else
				{
					if(m_view6LineSimulationList != null)
						return m_view6LineSimulationList.Find(match);
				}
			}
			else
			{
				if(!line6Mode)
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

		// // RVA: 0x1049BBC Offset: 0x1049BBC VA: 0x1049BBC
		public void UpdateDownloadState(int musicId)
		{
			for(int i = 0; i < GetCount(false, false); i++)
			{
				if(Get(i, false, false).DLAEJOBELBH_MusicId == musicId)
				{
					Get(i, false, false).OBGKIMDIAJF_CheckIsDlded();
				}
			}
			for(int i = 0; i < GetCount(true, false); i++)
			{
				if(Get(i, true, false).DLAEJOBELBH_MusicId == musicId)
				{
					Get(i, true, false).OBGKIMDIAJF_CheckIsDlded();
				}
			}
			for(int i = 0; i < GetCount(false, true); i++)
			{
				if(Get(i, false, true).DLAEJOBELBH_MusicId == musicId)
				{
					Get(i, false, true).OBGKIMDIAJF_CheckIsDlded();
				}
			}
			for(int i = 0; i < GetCount(true, true); i++)
			{
				if(Get(i, true, true).DLAEJOBELBH_MusicId == musicId)
				{
					Get(i, true, true).OBGKIMDIAJF_CheckIsDlded();
				}
			}
		}

		// // RVA: 0x1049E54 Offset: 0x1049E54 VA: 0x1049E54
		// private bool IsPlayed(IBJAKJJICBC data) { }

		// // RVA: 0x1049FF0 Offset: 0x1049FF0 VA: 0x1049FF0
		public MusicDataList(List<IBJAKJJICBC> viewList)
		{
			m_viewList = viewList;
			m_view6LineList = new List<IBJAKJJICBC>();
			m_viewSimulationList = new List<IBJAKJJICBC>();
			m_view6LineSimulationList = new List<IBJAKJJICBC>();
		}

		// // RVA: 0x1040144 Offset: 0x1040144 VA: 0x1040144
		public MusicDataList(List<IBJAKJJICBC> viewList, List<IBJAKJJICBC> view6LineList)
		{
			m_viewList = viewList;
			m_view6LineList = view6LineList;
			m_viewSimulationList = new List<IBJAKJJICBC>();
			m_view6LineSimulationList = new List<IBJAKJJICBC>();
		}

		// // RVA: 0x104A0B4 Offset: 0x104A0B4 VA: 0x104A0B4
		public MusicDataList(List<IBJAKJJICBC> viewList, List<IBJAKJJICBC> view6LineList, List<IBJAKJJICBC> viewSimulationList, List<IBJAKJJICBC> view6LineSimulationList)
		{
			m_viewList = viewList;
			m_view6LineList = view6LineList;
			m_viewSimulationList = viewSimulationList;
			m_view6LineSimulationList = view6LineSimulationList;
		}

		// // RVA: 0x104A0EC Offset: 0x104A0EC VA: 0x104A0EC
		public MusicDataList()
		{
			m_viewList = new List<IBJAKJJICBC>();
			m_view6LineList = new List<IBJAKJJICBC>();
			m_viewSimulationList = new List<IBJAKJJICBC>();
			m_view6LineSimulationList = new List<IBJAKJJICBC>();
		}
	}
}
