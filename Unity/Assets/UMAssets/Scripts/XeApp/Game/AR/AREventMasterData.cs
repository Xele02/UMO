using System.Collections.Generic;

namespace XeApp.Game.AR
{
	public class AREventMasterData : ARMasterData
	{
		public class Campaign
		{
			public string eventId = ""; // 0x8
			public long startTime; // 0x10
			public long endTime; // 0x18
			public int bannerId; // 0x20
			public int imageCount; // 0x24
		}

		public class EventTime
		{
			public long startTime; // 0x8
			public long endTime; // 0x10
			public int enable; // 0x18
		}

		public class Data
		{
			public int no; // 0x8
			public int enable; // 0xC
			public string eventId = ""; // 0x10
			public string eventName = ""; // 0x14
			public string[] snsTemplateTable = new string[2]; // 0x18
			public AREventMasterData.Campaign campaign = new AREventMasterData.Campaign(); // 0x1C

			// RVA: 0xBB8728 Offset: 0xBB8728 VA: 0xBB8728
			// public bool CanShowHelp() { }
		}

		public class Chenge_bg
		{
			public long startTime; // 0x8
			public long endTime; // 0x10
			public int enable; // 0x18
			public int bgId; // 0x1C
		}

		private static AREventMasterData sm_instance; // 0x0
		private List<AREventMasterData.Data> m_eventList = new List<AREventMasterData.Data>(); // 0x18
		private List<AREventMasterData.Chenge_bg> m_chengeBg = new List<AREventMasterData.Chenge_bg>(); // 0x1C
		private List<AREventMasterData.EventTime> m_eventTime = new List<AREventMasterData.EventTime>(); // 0x20
		private long m_arStartTime; // 0x28
		private long m_arEndTime; // 0x30

		public static AREventMasterData Instance { get {
			//0xBB6C40
			if(sm_instance == null)
			{
				sm_instance = new AREventMasterData();
				sm_instance.name = "ar_event";
			}
			return sm_instance;
		} } 
		public Dictionary<string, NNJFKLBPBNK> m_stringParam { get; private set; } // 0x38
		public Dictionary<string, CEBFFLDKAEC> m_intParam { get; private set; } // 0x3C

		// // RVA: 0xBB6F34 Offset: 0xBB6F34 VA: 0xBB6F34
		// public static void Release() { }

		// // RVA: 0xBB6FC4 Offset: 0xBB6FC4 VA: 0xBB6FC4 Slot: 4
		protected override void Initialize(byte[] bytes)
		{
			IINMAJAFDIF fileData = IINMAJAFDIF.HEGEKFMJNCC(bytes);
			m_eventList.Clear();
			for(int i = 0; i < fileData.GHGFEFIAIFC.Length; i++)
			{
				Data data = new Data();
				data.no = fileData.GHGFEFIAIFC[i].IKPIDCFOFEA;
				data.enable = fileData.GHGFEFIAIFC[i].PLALNIIBLOF;
				data.eventId = fileData.GHGFEFIAIFC[i].DNJLJMKKDNA.ToLower();
				data.eventName = fileData.GHGFEFIAIFC[i].OFJIBKAOMKO;
				data.snsTemplateTable[0] = fileData.GHGFEFIAIFC[i].AMLNJJHJEHE;
				data.snsTemplateTable[1] = fileData.GHGFEFIAIFC[i].DJJAKCKDGMA;
				data.campaign.eventId = fileData.GHGFEFIAIFC[i].DNJLJMKKDNA.ToLower();
				data.campaign.startTime = fileData.GHGFEFIAIFC[i].KIGNIOGKEGD;
				data.campaign.endTime = fileData.GHGFEFIAIFC[i].AKCAHAKHIPI;
				data.campaign.bannerId = fileData.GHGFEFIAIFC[i].LCCDKCPBJAK;
				data.campaign.imageCount = fileData.GHGFEFIAIFC[i].LLAGMIDPGFP;
				m_eventList.Add(data);
			}
			m_chengeBg.Clear();
			for(int i = 0; i < fileData.DEJCELHJKHN.Length; i++)
			{
				Chenge_bg data = new Chenge_bg();
				data.bgId = fileData.DEJCELHJKHN[i].OENPCNBFPDA;
				data.enable = fileData.DEJCELHJKHN[i].PLALNIIBLOF;
				data.startTime = fileData.DEJCELHJKHN[i].KBPENAAJPHN;
				data.endTime = fileData.DEJCELHJKHN[i].AKKDBALDNAN;
				m_chengeBg.Add(data);
			}
			m_intParam = new Dictionary<string, CEBFFLDKAEC>();
			for(int i = 0; i < fileData.BHGDNGHDDAC.Length; i++)
			{
				CEBFFLDKAEC data = new CEBFFLDKAEC();
				data.DNJEJEANJGL = fileData.BHGDNGHDDAC[i].JBGEEPFKIGG;
				m_intParam.Add(fileData.BHGDNGHDDAC[i].LJNAKDMILMC, data);
			}
			m_stringParam = new Dictionary<string, NNJFKLBPBNK>();
			for(int i = 0; i < fileData.MHGMDJNOLMI.Length; i++)
			{
				NNJFKLBPBNK data = new NNJFKLBPBNK();
				data.DNJEJEANJGL = fileData.MHGMDJNOLMI[i].JBGEEPFKIGG;
				m_stringParam.Add(fileData.MHGMDJNOLMI[i].LJNAKDMILMC, data);

			}
			m_eventTime.Clear();
			for(int i = 0; i < fileData.GCKNBNMLCEF.Length; i++)
			{
				EventTime data = new EventTime();
				data.startTime = fileData.GCKNBNMLCEF[i].JLIPMPMDEHI;
				data.endTime = fileData.GCKNBNMLCEF[i].LOPHEKJBJKD;
				data.enable = fileData.GCKNBNMLCEF[i].PLALNIIBLOF;
				m_eventTime.Add(data);
			}
		}

		// // RVA: 0xBB7C6C Offset: 0xBB7C6C VA: 0xBB7C6C
		// public string GetStringParam(string key, string noval) { }

		// // RVA: 0xBB7D50 Offset: 0xBB7D50 VA: 0xBB7D50
		// public int GetIntParam(string key, int noval) { }

		// // RVA: 0xBB7E34 Offset: 0xBB7E34 VA: 0xBB7E34
		// public bool IsEnableARMode() { }

		// // RVA: 0xBB80BC Offset: 0xBB80BC VA: 0xBB80BC
		// public List<AREventMasterData.Data> GetEventList(bool isAll = False) { }

		// // RVA: 0xBB820C Offset: 0xBB820C VA: 0xBB820C
		// public List<AREventMasterData.Campaign> GetEnableCampaigns() { }

		// // RVA: 0xBB8448 Offset: 0xBB8448 VA: 0xBB8448
		public AREventMasterData.Chenge_bg FindChangeBG()
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI();
			for(int i = 0; i < m_chengeBg.Count; i++)
			{
				if(m_chengeBg[i].enable == 2)
				{
					if(m_chengeBg[i].startTime <= time && m_chengeBg[i].endTime >= time)
						return m_chengeBg[i];
				}
			}
			UnityEngine.Debug.LogWarning("No BG found return the last one");
			// HACK for game post close
			return m_chengeBg[m_chengeBg.Count-1];
		}

		// // RVA: 0xBB7E4C Offset: 0xBB7E4C VA: 0xBB7E4C
		// public AREventMasterData.EventTime FindEventTime() { }

	}
}
