
using System.Collections.Generic;

[System.Obsolete("Use FBIOJHECAHB_EventStory", true)]
public class FBIOJHECAHB { }
[UMOClass(ReaderClass = "BLOHGJIKLAK")]
public class FBIOJHECAHB_EventStory : DIHHCBACKGG_DbSection
{
	[UMOClass(ReaderClass = "BCCFAPDAFOE")]
	public class GIEHECAKIFC_StoryInfo
	{
		[UMOMember(ReaderMember = "PPFNGGCBJKC")]
		public int PPFNGGCBJKC_Id; // 0x8
		[UMOMember(ReaderMember = "IJEKNCDIIAE|PLALNIIBLOF", Desc = "Availabe in game if value = 2")]
		public int PPEGAKEIEGM_Enabled; // 0xC
		[UMOMember(ReaderMember = "BCKCEEMNKCH")]
		public int OAFJONPIFGM_EventId; // 0x10
		[UMOMember(ReaderMember = "BDJMFDKLHPM")]
		public byte MGBDCFIKBPM_Serie; // 0x14
		[UMOMember(ReaderMember = "PDBPFJJCADD", ReaderDisplay = "Date", Display = "Date")]
		public long PDBPFJJCADD_PeriodStart; // 0x18
		[UMOMember(ReaderMember = "FDBNFFNFOND", ReaderDisplay = "Date", Display = "Date")]
		public long FDBNFFNFOND_PeriodEnd; // 0x20
	}

	[UMOClass(ReaderClass = "MCCFOKHKJIC")]
	public class ENDMMNNOAIL_StoryPartInfo
	{
		[UMOMember(ReaderMember = "PPFNGGCBJKC")]
		public int PPFNGGCBJKC_Id; // 0x8
		[UMOMember(ReaderMember = "PLALNIIBLOF", Desc = "Availabe in game if value = 2")]
		public int PPEGAKEIEGM_Enabled; // 0xC
		[UMOMember(ReaderMember = "BCKCEEMNKCH")]
		public int OAFJONPIFGM_EventId; // 0x10
		[UMOMember(ReaderMember = "PIDAAPMCAML")]
		public NMIGMCJHAIE JDJNNJEJDAJ_Type; // 0x14
		[UMOMember(ReaderMember = "OIAAFFHGBBD")]
		public int LOHMKCPKBON_AdvId; // 0x18
		[UMOMember(ReaderMember = "ODNOJKHHEOP")]
		public int CHOFDPDFPDC; // 0x1C
		[UMOMember(ReaderMember = "DFMOIKJOCGH")]
		public int PFGAKEDKOPD_UnlockSpCost; // 0x20
	}

	public class CHCCGPMJFEL
	{
		public int PPFNGGCBJKC; // 0x8
		public int PPEGAKEIEGM; // 0xC
		public int BCCHOBPJJKE; // 0x10
		public int BPNKGDGBBFG; // 0x14
	}

	public enum NMIGMCJHAIE
	{
		JFEDIMKFDNH_Prologue = 1,
		GBECNPANBEA_2_Sns = 2,
		OEDCONLFLHD_Epilogue = 3,
		DCDEBCIMEMM_Opening = 4,
		MOPAEGFEGCB_5_EpisodeStory = 5,
	}

	public enum CHMHPDHPDCD
	{
		FCPAKJFNKPG = 0,
		MOKIALDCAGP = 1,
		JJCGGAFJLGM = 2,
		FDBFJFDIKPE = 3,
		GCLFEJGEIPL = 4,
		MKNOPGIJNID = 5,
	}

	[UMOMember(ReaderMember = "MLJNCEIFECL")]
	public List<GIEHECAKIFC_StoryInfo> ILEJEJKNOBN_StoryList = new List<GIEHECAKIFC_StoryInfo>(); // 0x20
	[UMOMember(ReaderMember = "FGAOKKECNIH")]
	public List<ENDMMNNOAIL_StoryPartInfo> JPIGOBGOMON_StoryPartsList = new List<ENDMMNNOAIL_StoryPartInfo>(); // 0x24

	// RVA: 0xFC6448 Offset: 0xFC6448 VA: 0xFC6448
	public FBIOJHECAHB_EventStory()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 43;
	}

	// RVA: 0xFC6570 Offset: 0xFC6570 VA: 0xFC6570 Slot: 8
	protected override void KMBPACJNEOF()
	{
		ILEJEJKNOBN_StoryList.Clear();
		JPIGOBGOMON_StoryPartsList.Clear();
	}

	// RVA: 0xFC6614 Offset: 0xFC6614 VA: 0xFC6614 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		BLOHGJIKLAK parser = BLOHGJIKLAK.HEGEKFMJNCC(DBBGALAPFGC);
		ILEJEJKNOBN_StoryList.Clear();
		JPIGOBGOMON_StoryPartsList.Clear();
		{
			BCCFAPDAFOE[] array = parser.MLJNCEIFECL;
			for(int i = 0; i < array.Length; i++)
			{
				GIEHECAKIFC_StoryInfo data = new GIEHECAKIFC_StoryInfo();
				data.PPFNGGCBJKC_Id = array[i].PPFNGGCBJKC;
				data.PPEGAKEIEGM_Enabled = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
				data.OAFJONPIFGM_EventId = array[i].BCKCEEMNKCH;
				data.MGBDCFIKBPM_Serie = (byte)array[i].BDJMFDKLHPM;
				data.PDBPFJJCADD_PeriodStart = array[i].PDBPFJJCADD;
				data.FDBNFFNFOND_PeriodEnd = array[i].FDBNFFNFOND;
				ILEJEJKNOBN_StoryList.Add(data);
			}
		}
		{
			MCCFOKHKJIC[] array = parser.FGAOKKECNIH;
			for(int i = 0; i < array.Length; i++)
			{
				ENDMMNNOAIL_StoryPartInfo data = new ENDMMNNOAIL_StoryPartInfo();
				data.PPFNGGCBJKC_Id = array[i].PPFNGGCBJKC;
				data.PPEGAKEIEGM_Enabled = array[i].PLALNIIBLOF;
				data.OAFJONPIFGM_EventId = array[i].BCKCEEMNKCH;
				data.JDJNNJEJDAJ_Type = (NMIGMCJHAIE)array[i].PIDAAPMCAML;
				data.LOHMKCPKBON_AdvId = array[i].OIAAFFHGBBD;
				data.CHOFDPDFPDC = array[i].ODNOJKHHEOP;
				data.PFGAKEDKOPD_UnlockSpCost = array[i].DFMOIKJOCGH;
				JPIGOBGOMON_StoryPartsList.Add(data);
			}
		}
		return true;
	}

	// RVA: 0xFC6B30 Offset: 0xFC6B30 VA: 0xFC6B30 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return true;
	}

	// RVA: 0xFC6B38 Offset: 0xFC6B38 VA: 0xFC6B38 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "FBIOJHECAHB_EventStory.CAOGDCBPBAN");
		return 0;
	}

	//// RVA: 0xFC7070 Offset: 0xFC7070 VA: 0xFC7070
	public ENDMMNNOAIL_StoryPartInfo GIBIMCOLLNN(int AIPLIEMLHGC)
	{
		ENDMMNNOAIL_StoryPartInfo e = JPIGOBGOMON_StoryPartsList.Find((ENDMMNNOAIL_StoryPartInfo GHPLINIACBB) =>
		{
			//0xFC7200
			if(GHPLINIACBB.PPEGAKEIEGM_Enabled == 2 && GHPLINIACBB.JDJNNJEJDAJ_Type == NMIGMCJHAIE.GBECNPANBEA_2_Sns)
				return GHPLINIACBB.LOHMKCPKBON_AdvId == AIPLIEMLHGC;
			return false;
		});
		if(e != null)
		{
			if(ILEJEJKNOBN_StoryList.Find((GIEHECAKIFC_StoryInfo GHPLINIACBB) =>
			{
				//0xFC7254
				if(GHPLINIACBB.PPEGAKEIEGM_Enabled != 2)
					return false;
				return GHPLINIACBB.OAFJONPIFGM_EventId == e.OAFJONPIFGM_EventId;
			}) != null)
			{
				return e;
			}
		}
		return null;
	}
}
