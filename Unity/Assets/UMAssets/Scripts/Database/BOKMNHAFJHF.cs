

using System.Collections.Generic;
using UnityEngine;
using XeSys;

[System.Obsolete("Use BOKMNHAFJHF_Sns", true)]
public class BOKMNHAFJHF { }
public class BOKMNHAFJHF_Sns : DIHHCBACKGG_DbSection
{
	public class KEIGMAOCJHK
	{
		public long DPIBHFNDJII; // 0x8
		public long EKPBOLNFGJB; // 0x10
		public int AIPLIEMLHGC; // 0x18
		public int MALFHCHNEFN; // 0x1C
		public int AJIDLAGFPGM; // 0x20
		public sbyte JKNGNIMLDDJ; // 0x24
		public sbyte PPEGAKEIEGM_Enabled; // 0x25
		public ushort IJEKNCDIIAE; // 0x26

		//// RVA: 0x19CEFD4 Offset: 0x19CEFD4 VA: 0x19CEFD4
		//public uint CAOGDCBPBAN() { }
	}

	public class LEBAGJNJJNG_Room
	{
		public short MALFHCHNEFN_Room; // 0x8
		public string OPFGFINHFCE_Name; // 0xC
		public int EAHPLCJMPHD; // 0x10
		public int EEECOMPDNEJ; // 0x14
		public int EKANGPODCEP; // 0x18
		public int PPEGAKEIEGM_Enabled; // 0x1C
		public int PKOKDPHHLCG; // 0x20

		//// RVA: 0x19CF0C0 Offset: 0x19CF0C0 VA: 0x19CF0C0
		//public uint CAOGDCBPBAN() { }
	}

	public class JFMDDEBLCAA
	{
		public int IDELKEKDIFD; // 0x8
		public int EAHPLCJMPHD; // 0xC
		public int HEHKNMCDBJJ_ColorId; // 0x10
		public int CPKMLLNADLJ_Serie; // 0x14
		public string OPFGFINHFCE_Name; // 0x18
		public string HAPAFECPFEK; // 0x1C
		public sbyte PPEGAKEIEGM_Enabled; // 0x20

		//// RVA: 0x19CF01C Offset: 0x19CF01C VA: 0x19CF01C
		//public uint CAOGDCBPBAN() { }
	}

	public class EIJGEDBGBBI
	{
		public int PPFNGGCBJKC; // 0x8
		public Color DOKKMMFKLJI_Color; // 0xC

		//// RVA: 0x19CF038 Offset: 0x19CF038 VA: 0x19CF038
		//public uint CAOGDCBPBAN() { }
	}

	public List<KEIGMAOCJHK> CDENCMNHNGA { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB
	public List<LEBAGJNJJNG_Room> NPKPBDIDBBG_Room { get; private set; } // 0x24 APIEOMBDJJM OJBJIECLMKI KHEKLHLKDIJ
	public List<JFMDDEBLCAA> KHCACDIKJLG_Characters { get; private set; } // 0x28 BMCJBCFBOJG ICPBCJDBBAI HHKFEJDAHNA
	public List<EIJGEDBGBBI> LOCEHOMKJEI { get; private set; } // 0x2C GJFNINODHJK LLFHHFNLOPC CGEAKFHLBNF

	//// RVA: 0x19CD998 Offset: 0x19CD998 VA: 0x19CD998
	//public BOKMNHAFJHF.KEIGMAOCJHK GCINIJEMHFK(int PPFNGGCBJKC) { }

	// RVA: 0x19CDA60 Offset: 0x19CDA60 VA: 0x19CDA60
	public BOKMNHAFJHF_Sns()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		CDENCMNHNGA = new List<KEIGMAOCJHK>();
		NPKPBDIDBBG_Room = new List<LEBAGJNJJNG_Room>();
		KHCACDIKJLG_Characters = new List<JFMDDEBLCAA>();
		LOCEHOMKJEI = new List<EIJGEDBGBBI>();
		LMHMIIKCGPE = 76;
	}

	// RVA: 0x19CDBF4 Offset: 0x19CDBF4 VA: 0x19CDBF4 Slot: 8
	protected override void KMBPACJNEOF()
	{
		int val = (int)Utility.GetCurrentUnixTime();
		CDENCMNHNGA.Clear();
		for(int i = 0; i < 2000; i++)
		{
			KEIGMAOCJHK data = new KEIGMAOCJHK();
			data.AIPLIEMLHGC = i + 1;
			CDENCMNHNGA.Add(data);
		}
		KHCACDIKJLG_Characters.Clear();
		for(int i = 0; i < 100; i++)
		{
			JFMDDEBLCAA data = new JFMDDEBLCAA();
			data.OPFGFINHFCE_Name = "";
			data.HAPAFECPFEK = "";
			data.IDELKEKDIFD = i + 1;
			data.EAHPLCJMPHD = 1;
			data.HEHKNMCDBJJ_ColorId = 1;
			data.CPKMLLNADLJ_Serie = 0;
			KHCACDIKJLG_Characters.Add(data);
		}
	}

	// RVA: 0x19CDE7C Offset: 0x19CDE7C VA: 0x19CDE7C Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		MILDDOGCGLE parser = MILDDOGCGLE.HEGEKFMJNCC(DBBGALAPFGC);
		if(NMJBKFBFPFG(parser))
		{
			FGOHGNBIAAP_LoadRoom(parser);
			if(LHFCGAJLMDL(parser))
			{
				NOBOFLFGLMJ(parser);
				return true;
			}
		}
		return false;
	}

	// RVA: 0x19CEA10 Offset: 0x19CEA10 VA: 0x19CEA10 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	//// RVA: 0x19CDEE8 Offset: 0x19CDEE8 VA: 0x19CDEE8
	private bool NMJBKFBFPFG(MILDDOGCGLE LKDONLFHMEO)
	{
		COJBCBGIGHJ[] array = LKDONLFHMEO.IPCJPOGBHGP;
		if(array.Length <= CDENCMNHNGA.Count)
		{
			for(int i = 0; i < array.Length; i++)
			{
				KEIGMAOCJHK data = CDENCMNHNGA[i];
				data.AIPLIEMLHGC = (int)array[i].PPFNGGCBJKC;
				data.DPIBHFNDJII = array[i].KFCIJBLDHOK;
				data.EKPBOLNFGJB = array[i].JLEIHOEGMOP;
				data.MALFHCHNEFN = (int)array[i].OKECOPNBAGP;
				data.JKNGNIMLDDJ = (sbyte)array[i].ODMJFHDIGLP;
				data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, (int)array[i].PLALNIIBLOF, 0);
				data.AJIDLAGFPGM = (int)array[i].EPKOHDLIKAN;
				data.IJEKNCDIIAE = (ushort)array[i].IJEKNCDIIAE;
			}
			return true;
		}
		return false;
	}

	//// RVA: 0x19CEA18 Offset: 0x19CEA18 VA: 0x19CEA18
	//private bool NMJBKFBFPFG(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	//// RVA: 0x19CE1EC Offset: 0x19CE1EC VA: 0x19CE1EC
	private bool FGOHGNBIAAP_LoadRoom(MILDDOGCGLE LKDONLFHMEO)
	{
		NPKPBDIDBBG_Room.Clear();
		APLNHNOKJFK[] array = LKDONLFHMEO.BHFAMKAPFNJ;
		for(int i = 0; i < array.Length; i++)
		{
			LEBAGJNJJNG_Room data = new LEBAGJNJJNG_Room();
			data.MALFHCHNEFN_Room = (short)array[i].OKECOPNBAGP;
			data.EKANGPODCEP = array[i].JMMEGKGCIIL;
			data.OPFGFINHFCE_Name = array[i].OPFGFINHFCE;
			data.PPEGAKEIEGM_Enabled = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.EEECOMPDNEJ = array[i].GBJFNGCDKPM;
			data.PKOKDPHHLCG = (int)array[i].PFJJFCPPNIN;
			NPKPBDIDBBG_Room.Add(data);
		}
		return true;
	}

	//// RVA: 0x19CEA20 Offset: 0x19CEA20 VA: 0x19CEA20
	//private bool FGOHGNBIAAP(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	//// RVA: 0x19CE4AC Offset: 0x19CE4AC VA: 0x19CE4AC
	private bool LHFCGAJLMDL(MILDDOGCGLE LKDONLFHMEO)
	{
		EIDBDFGNCFB[] array = LKDONLFHMEO.CEPBAOMAHNH;
		if (array.Length <= KHCACDIKJLG_Characters.Count)
		{
			for (int i = 0; i < array.Length; i++)
			{
				JFMDDEBLCAA data = KHCACDIKJLG_Characters[i];
				data.OPFGFINHFCE_Name = array[i].OPFGFINHFCE;
				data.HAPAFECPFEK = array[i].ONOPACPKFPK;
				data.EAHPLCJMPHD = (int)array[i].HANMDEBPBHG;
				data.HEHKNMCDBJJ_ColorId = array[i].DJJNOCDIIAE;
				data.CPKMLLNADLJ_Serie = array[i].CPKMLLNADLJ;
				data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(1, (int)array[i].PLALNIIBLOF, 0);
			}
			return true;
		}
		return false;
	}

	//// RVA: 0x19CECD0 Offset: 0x19CECD0 VA: 0x19CECD0
	//private bool LHFCGAJLMDL(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	//// RVA: 0x19CE75C Offset: 0x19CE75C VA: 0x19CE75C
	private bool NOBOFLFGLMJ(MILDDOGCGLE LKDONLFHMEO)
	{
		CBGIPNJOPAH[] array = LKDONLFHMEO.ABIKKECOBIJ;
		for(int i = 0; i < array.Length; i++)
		{
			EIJGEDBGBBI data = new EIJGEDBGBBI();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.DOKKMMFKLJI_Color = new Color((array[i].DOKKMMFKLJI & 0xff) / 255.0f,
				((array[i].DOKKMMFKLJI >> 8) & 0xff) / 255.0f,
				((array[i].DOKKMMFKLJI >> 16) & 0xff) / 255.0f);
			LOCEHOMKJEI.Add(data);
		}
		return true;
	}

	//// RVA: 0x19CECD8 Offset: 0x19CECD8 VA: 0x19CECD8
	//private bool NOBOFLFGLMJ(EDOHBJAPLPF FMFBOLMIIKP, int KAPMOPMDHJE) { }

	// RVA: 0x19CECF0 Offset: 0x19CECF0 VA: 0x19CECF0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "BOKMNHAFJHF_Sns.CAOGDCBPBAN");
		return 0;
	}
}
