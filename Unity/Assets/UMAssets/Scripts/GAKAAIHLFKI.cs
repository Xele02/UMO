
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

public class IMKNEDJDNGC
{
	public long BEBJKJKBOGH_Date; // 0x8
	public int FMDCAFCHBJH_Offset; // 0x10
	public int AIPLIEMLHGC; // 0x14
	public int AJIDLAGFPGM; // 0x18
	public int OIPCCBHIKIA_Index; // 0x1C
	public int HDBOIICCEIA; // 0x20
	public short IDELKEKDIFD_CharaId; // 0x24
	public sbyte OKMMDJCAHNK_WinShapeId; // 0x26
	public sbyte HMKFHLLAKCI_WindowSizeId; // 0x27
	public string OPFGFINHFCE_Name; // 0x28
	public string LJGOOOMOMMA_Desc; // 0x2C
	public bool GAIEHFCHAOK; // 0x30
	public bool EDCBHGECEBE; // 0x31

	//// RVA: 0x9FB16C Offset: 0x9FB16C VA: 0x9FB16C
	public void FCFDHFAJKPB()
	{
		if (EDCBHGECEBE)
			return;
		DDEMMEPBOIA_Sns.EFIFBJGKPJF saveSns = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG[AIPLIEMLHGC - 1];
		SNSRoomTextData.Header header = Database.Instance.roomText.textData.FindHeader(AJIDLAGFPGM);
		if (header.count <= saveSns.LDJIMGPHFPA_Cnt)
			return;
		saveSns.LDJIMGPHFPA_Cnt = (short)header.count;
	}
}

public class GAKAAIHLFKI
{
	public int MALFHCHNEFN; // 0x8
	public string OPFGFINHFCE; // 0xC
	public long LKGLMCFEDBF; // 0x10
	public int HIDHLFCBIDE; // 0x18
	public long JBOECJOONLP; // 0x20
	public int IHCEJBAEEDO; // 0x28
	public int IJEKNCDIIAE; // 0x2C
	public long ILDLJMCIKAK; // 0x30
	public int AIPLIEMLHGC; // 0x38
	public List<IMKNEDJDNGC> CNEOPOINCBA = new List<IMKNEDJDNGC>(); // 0x3C

	//// RVA: 0x13FF9BC Offset: 0x13FF9BC VA: 0x13FF9BC
	public int FOBEBCPEILE(long JHNMKKNEENE, bool BAOMADKMHKP = false, bool DGLDFDLGGBB = false)
	{
		for(int i = 0; i < CNEOPOINCBA.Count; i++)
		{
			if (JHNMKKNEENE < CNEOPOINCBA[i].BEBJKJKBOGH_Date)
				return i;
			if(CNEOPOINCBA[i].GAIEHFCHAOK)
			{
				int a = i;
				if(BAOMADKMHKP)
				{
					if (LKGLMCFEDBF == 0)
						LKGLMCFEDBF = Utility.GetCurrentUnixTime();
					long now = Utility.GetCurrentUnixTime();
					if (now - LKGLMCFEDBF >= CNEOPOINCBA[i].FMDCAFCHBJH_Offset)
					{
						CNEOPOINCBA[i].GAIEHFCHAOK = false;
						CNEOPOINCBA[i].FCFDHFAJKPB();
						a = i + 1;
						LKGLMCFEDBF = now;
					}
				}
				if (!DGLDFDLGGBB)
					return a;
				CNEOPOINCBA[i].GAIEHFCHAOK = false;
				CNEOPOINCBA[i].FCFDHFAJKPB();
				LKGLMCFEDBF = JHNMKKNEENE;
				return a + 1;
			}
		}
		return CNEOPOINCBA.Count;
	}

	//// RVA: 0x13FFD7C Offset: 0x13FFD7C VA: 0x13FFD7C
	public int MCGDHHHFBMO(long JHNMKKNEENE, bool BAOMADKMHKP = false)
	{
		int res = 0;
		for(int i = 0; i < CNEOPOINCBA.Count; i++)
		{
			if (JHNMKKNEENE < CNEOPOINCBA[i].BEBJKJKBOGH_Date)
				return res;
			if (CNEOPOINCBA[i].OIPCCBHIKIA_Index + 1 <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG[CNEOPOINCBA[i].AIPLIEMLHGC - 1].LDJIMGPHFPA_Cnt)
				res++;
		}
		return res;
	}

	//// RVA: 0x140001C Offset: 0x140001C VA: 0x140001C
	public int BDNLOOAGKKE(long JHNMKKNEENE, bool BAOMADKMHKP = false, bool MIENHPPDMNG = false)
	{
		int res = 0;
		for(int i = 0; i < CNEOPOINCBA.Count; i++)
		{
			if(!MIENHPPDMNG || !CNEOPOINCBA[i].EDCBHGECEBE)
			{
				if (JHNMKKNEENE < CNEOPOINCBA[i].BEBJKJKBOGH_Date)
					return res;
				if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG[CNEOPOINCBA[i].AIPLIEMLHGC - 1].LDJIMGPHFPA_Cnt < CNEOPOINCBA[i].OIPCCBHIKIA_Index + 1)
					res++;
			}
		}
		return res;
	}

	//// RVA: 0x1400320 Offset: 0x1400320 VA: 0x1400320
	//public void NLBFHOGFHLA(long JHNMKKNEENE) { }

	//// RVA: 0x140060C Offset: 0x140060C VA: 0x140060C
	public bool PLKKMHBFDCJ(long JHNMKKNEENE)
	{
		for(int i = CNEOPOINCBA.Count - 1; i >= 0; i--)
		{
			if(!CNEOPOINCBA[i].EDCBHGECEBE)
			{
				if (JHNMKKNEENE < CNEOPOINCBA[i].BEBJKJKBOGH_Date)
					return false;
				if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG[CNEOPOINCBA[i].AIPLIEMLHGC - 1].LDJIMGPHFPA_Cnt < CNEOPOINCBA[i].OIPCCBHIKIA_Index + 1)
					return true;
			}
		}
		return false;
	}
}
