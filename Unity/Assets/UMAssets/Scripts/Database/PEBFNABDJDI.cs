using System.Collections.Generic;
using XeSys;
using System;

public class PEBFNABDJDI { }
public class PEBFNABDJDI_System : DIHHCBACKGG
{
    public class JFIGGEAFMCN
    {
        public long BIMOIPDPLJO; // 0x8
        public int OLMFFMANMNE; // 0x10

        // public long KJLPILMAIKH { get; set; } GLFFDLFFELA 0x16C0E08 PEMIOJOMOHL 0x16C0DD8
        // public int CEMEIPNMAAD_Version { get; set; } MPHJDGEDFOC 0x16C0E1C FNCCGEAMNAC 0x16C0DF4

        // // RVA: 0x16C0DA0 Offset: 0x16C0DA0 VA: 0x16C0DA0
        public JFIGGEAFMCN() 
        { 
            BIMOIPDPLJO = 0xbd07d870;
            OLMFFMANMNE = 0x96aafb;
        }
    }

	public static bool EEDNHJDKIAC; // 0x0
	private List<NNJFKLBPBNK> IFBBNEGGCIH; // 0x40
	private List<CEBFFLDKAEC> JNJAOACIGOC; // 0x44
	public Dictionary<int, long> IOIDJALFFJA = new Dictionary<int, long>(); // 0x48
	public sbyte[] NLNNEOLDOGE; // 0x4C
	public sbyte[] POEHINEHAEG; // 0x50
	public int JDFBNIBIPPK; // 0x54
	public bool GNEGCHEGECN; // 0x58
    public List<int> PDELLJAOANM = new List<int>(); // 0x5C
	public int CAAMBBJBODI = 12; // 0x60
	private List<string> NCJKIFNCLAF; // 0x64
	public int FPGDAPAILAK; // 0x68
	public List<JFIGGEAFMCN> BMAHEAMPCED = new List<JFIGGEAFMCN>(); // 0x6C
	public int KMDDIEJBNPO; // 0x70

	public CHBDMJBEENG NGHKJOEDLIP { get; set; } // CLJNODMDGFA  0x20 // OPMNKEBHEBI // FLAGNHPCHCF
	public List<OGNALGCHKED> JDBLDOPHHNL { get; set; } // IJDNKAPDDFF 0x24 // FCBDHDGIMHO // OOLGKMGAHOP
	public List<EJABAIAPFLK> BHDJIIHLMDM { get; set; } // BFKDBLJIGLO 0x28 // JIAMJJLMMLF // HBDIDBHLJCO
	public Dictionary<string, string> JLJEEMEOPLE { get; set; } // CJGBLCGHHEI 0x2C // DCHGJLCADKP // ICHNENECFGN
	public Dictionary<string, BIJMLAPNMAB_SceneSwitch> LMBIOEDHNHB_SceneSwitch { get; set; } // OOCFKPKLBJH 0x30 // BGCEPJDLFFA // JPLHJCLOPKE
	public Dictionary<string, NNJFKLBPBNK> FJOEBCMGDMI { get; set; } // IHKPIFIBECO 0x34 // GAMGELHIHHI // DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC> OHJFBLFELNK { get; set; } // KLDCHOIPJGB 0x38 // AEMNOGNEBOJ // DGKDBOAMNBB
	public Dictionary<string, int> KBAPDOLLLAN { get; set; } // BKGIMGCBBOC 0x3C // OOEBAHFJPAB // MCMHANFFFNF

	// // RVA: 0xCC4458 Offset: 0xCC4458 VA: 0xCC4458
	public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH)
	{
		if (!FJOEBCMGDMI.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		return FJOEBCMGDMI[LJNAKDMILMC].DNJEJEANJGL;
	}

	// // RVA: 0xCC453C Offset: 0xCC453C VA: 0xCC453C
	public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH)
	{
		if(!OHJFBLFELNK.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		
		return OHJFBLFELNK[LJNAKDMILMC].DNJEJEANJGL;
	}

	// // RVA: 0xCC4620 Offset: 0xCC4620 VA: 0xCC4620
	public int HEDDDBDAMGO(string LJNAKDMILMC, string KKMJBMKHGNH)
	{
		string str = EFEGBHACJAL(LJNAKDMILMC, KKMJBMKHGNH);
		char[] sep = new char[1]{','};
		string[] strs = str.Split(sep);
		if(strs.Length > 1)
		{
			for(int i = 0; i < strs.Length / 2; i++)
			{
				int val1 = Int32.Parse(strs[i * 2]);
				int val2 = Int32.Parse(strs[i * 2 + 1]);
				if(DIHHCBACKGG.IEFOPDOOLOK > val1 || (i + 1) >= strs.Length/2)
					return val2;
			}
		}
		return 0;
	}

	// // RVA: 0xCC4804 Offset: 0xCC4804 VA: 0xCC4804
	public bool EJPFDDOOKJI(string MDBKPOCDJDP)
	{
		return NCJKIFNCLAF.Contains(MDBKPOCDJDP);
	}

	// // RVA: 0xCC4880 Offset: 0xCC4880 VA: 0xCC4880
	// public int NCEMAEDMJLO(long EOLFJGMAJAB) { }

	// // RVA: 0xCC49B8 Offset: 0xCC49B8 VA: 0xCC49B8
	// public bool JLAJNCMIIOK(int JIKLEHGJKBH, string OPFGFINHFCE) { }

	// // RVA: 0xCC4B20 Offset: 0xCC4B20 VA: 0xCC4B20
	// public int GAGDEIMGBBG(int JIKLEHGJKBH) { }

	// // RVA: 0xCC4C4C Offset: 0xCC4C4C VA: 0xCC4C4C
	public int DDGHBNLOBAJ_GetCueEncryptedKey(string OPFGFINHFCE)
	{
		if (!KBAPDOLLLAN.ContainsKey(OPFGFINHFCE))
			return 0;
		return KBAPDOLLLAN[OPFGFINHFCE];
	}

	// // RVA: 0xCC4D0C Offset: 0xCC4D0C VA: 0xCC4D0C
	public PEBFNABDJDI_System()
    {
		JIKKNHIAEKG = "";
        LNIMEIMBCMF = false;
        NGHKJOEDLIP = new CHBDMJBEENG();
        JDBLDOPHHNL = new List<OGNALGCHKED>();
        BHDJIIHLMDM = new List<EJABAIAPFLK>();
        JLJEEMEOPLE = new Dictionary<string, string>();
        LMHMIIKCGPE = 79;
        LMBIOEDHNHB_SceneSwitch = new Dictionary<string, BIJMLAPNMAB_SceneSwitch>();
        OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC>();
        KBAPDOLLLAN = new Dictionary<string, int>();
        JNJAOACIGOC = new List<CEBFFLDKAEC>();
        FJOEBCMGDMI = new Dictionary<string, NNJFKLBPBNK>();
        IFBBNEGGCIH = new List<NNJFKLBPBNK>();
        NLNNEOLDOGE = new sbyte[24];
        POEHINEHAEG = new sbyte[24];
    }

	// // RVA: 0xCC50C8 Offset: 0xCC50C8 VA: 0xCC50C8 Slot: 8
	protected override void KMBPACJNEOF()
	{
		JDBLDOPHHNL.Clear();
		NGHKJOEDLIP.FPBEBCIPEPI.Clear();
		NGHKJOEDLIP.FPBEBCIPEPI.Add(0);
		OHJFBLFELNK.Clear();
		JNJAOACIGOC.Clear();
		KBAPDOLLLAN.Clear();
		FJOEBCMGDMI.Clear();
		IFBBNEGGCIH.Clear();
		CAAMBBJBODI = 12;
		BMAHEAMPCED.Clear();
		FPGDAPAILAK = 0;
		IOIDJALFFJA.Clear();
	}

	// // RVA: 0xCC5308 Offset: 0xCC5308 VA: 0xCC5308 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
    {
        TodoLogger.Log(0, "Database Load");

		IAIDGBJGDBH reader = IAIDGBJGDBH.HEGEKFMJNCC(DBBGALAPFGC);

		for(int i = 0; i < reader.NELGGEGAJPH.Length; i++)
		{
			JLJEEMEOPLE.Add(reader.NELGGEGAJPH[i].PPFNGGCBJKC, reader.NELGGEGAJPH[i].HJLDBEJOMIO);
		}
		for(int i = 0; i < reader.GJOBPIOOEHD.Length; i++)
		{
			BIJMLAPNMAB_SceneSwitch data = new BIJMLAPNMAB_SceneSwitch();
			data.OIPCKOBNHJL_PrefabName = reader.GJOBPIOOEHD[i].BDCNFMMAEJJ;
			data.AEMLILCNODL_MasterVersion = (int)reader.GJOBPIOOEHD[i].CJOKJFGDHLD;
			LMBIOEDHNHB_SceneSwitch.Add(reader.GJOBPIOOEHD[i].GJCCGIFLKPD, data);
		}
		for(int i = 0; i < reader.MHGMDJNOLMI.Length; i++) // L495
		{
			NNJFKLBPBNK data = new NNJFKLBPBNK();
			data.DNJEJEANJGL = reader.MHGMDJNOLMI[i].JBGEEPFKIGG;
			FJOEBCMGDMI[reader.MHGMDJNOLMI[i].LJNAKDMILMC] = data;
			IFBBNEGGCIH.Add(data);
		}

		//L549
		NCJKIFNCLAF = new List<string>();
		string str = EFEGBHACJAL("fixedbias_gpu_name", "");
		if(!string.IsNullOrEmpty(str))
		{
			char[] sep = new char[1] { ',' };
			NCJKIFNCLAF.AddRange(str.Split(sep));
		}

		if ((LPJLEHAJADA("acb_setting", 3) & 1) != 0) // L 702
		{
			string val = EFEGBHACJAL("login_bonus_setting", "");
			if(!string.IsNullOrEmpty(val))
			{
				char[] sep = new char[1] { ',' };
				string[] ids = val.Split(sep);
				for(int i = 0; i < ids.Length / 2; i++)
				{
					int val1 = Int32.Parse(ids[i * 2]);
					int val2 = Int32.Parse(ids[i * 2 + 1]);
					KBAPDOLLLAN.Add("cs_w_"+val1.ToString("D4"), val2);
				}
			}
		}

		//L581
		FPGDAPAILAK = HEDDDBDAMGO("extreme_unlock", "1,2");

		return true;
    }

	// // RVA: 0xCC6E38 Offset: 0xCC6E38 VA: 0xCC6E38 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(0, "TODO");
		return true;
	}

	// // RVA: 0xCC6B8C Offset: 0xCC6B8C VA: 0xCC6B8C
	// private void DMLGPFLLMOB(Dictionary<int, long> AKMJDDOFJOL, string FJOEBCMGDMI) { }

	// // RVA: 0xCC7E98 Offset: 0xCC7E98 VA: 0xCC7E98
	// public int AHJDJACMFMN(long EOLFJGMAJAB) { }

	// // RVA: 0xCC7F98 Offset: 0xCC7F98 VA: 0xCC7F98 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(0, "CAOGDCBPBAN");
		return 0;
	}

	// // RVA: 0xCC8338 Offset: 0xCC8338 VA: 0xCC8338
	// public bool BLEDNLHJDEF() { }

	// // RVA: 0xCC8404 Offset: 0xCC8404 VA: 0xCC8404
	// public bool BEFGHIJNEBL() { }

	// // RVA: 0xCC84D0 Offset: 0xCC84D0 VA: 0xCC84D0
	// public bool MDECFOOCLHG() { }

	// // RVA: 0xCC859C Offset: 0xCC859C VA: 0xCC859C
	// public bool OANJBOPLCKP() { }

	// // RVA: 0xCC8668 Offset: 0xCC8668 VA: 0xCC8668
	// public bool CDOOMPPEINP() { }

	// // RVA: 0xCC8734 Offset: 0xCC8734 VA: 0xCC8734
	// public bool NJGEDPHNIKC() { }
}
 
public class CHBDMJBEENG
{
	private int OBPBCNNFNFO; // 0x8
	private int DCBANOMELHM; // 0xC
	private int NMJDFCEJOCP; // 0x10
	private int IGNPLAKONFE; // 0x14
	private int JOGHEIDHELL; // 0x18
	private int ALMFPODMADF; // 0x1C
	private int HNDNGHNDNMD; // 0x20
	private int JIICFAEIGLO; // 0x24
	private int ELCCKELHDIJ; // 0x28
	public List<sbyte> FPBEBCIPEPI = new List<sbyte>(10); // 0x2C

	// public int PFNBMPCIIJJ { get; set; } FHKONOMKGBN 0x12BE018 BLIGJALGJIK 0x12BE028
	public int KBNGOBEAHIC { get { return OBPBCNNFNFO ^ NMJDFCEJOCP; } set { NMJDFCEJOCP = OBPBCNNFNFO ^ value; } } //JKEJHFKAKDN 0x12BE038 OKFDFHNIILF 0x12BE048
	public int JOIEHMBKJHI { get { return OBPBCNNFNFO ^ IGNPLAKONFE; } set { IGNPLAKONFE = OBPBCNNFNFO ^ value; } } //LKFCFNJDCOD 0x12BE058 EAKKAOCBAMF 0x12BE068
	public int KHGJIGNHAGD { get { return OBPBCNNFNFO ^ JOGHEIDHELL; } set { JOGHEIDHELL = OBPBCNNFNFO ^ value; } } //NLNDHIKBGOA 0x12BE078 OACFGDPBLCP 0x12BE088
	// public int EEBOIPHMMBP { get; set; } PCJCHDJPDHN 0x12BE098 BCLCFCILPFP 0x12BE0A8
	// public int IMNJNFICJPM { get; set; } GCLLEGIMPCF 0x12BE0B8 FKPEMBDPOME 0x12BE0C8
	// public int PIAMMJNADJH { get; set; } AOHLFEDHOHH 0x12BE0D8 IPHJMAENLHE 0x12BE0E8
	// public int KMNPFOPBDMA { get; set; } BKMILJONJDL 0x12BE0F8 PLJFDIKPMMH 0x12BE108

	// RVA: 0x12BE118 Offset: 0x12BE118 VA: 0x12BE118
	public CHBDMJBEENG()
	{
		OBPBCNNFNFO = (int)Utility.GetCurrentUnixTime() ^ 0x70f5a731;
	}

	// RVA: 0x12BE1EC Offset: 0x12BE1EC VA: 0x12BE1EC
	// public uint CAOGDCBPBAN() { }
}

public class OGNALGCHKED
{
	private int OBPBCNNFNFO; // 0x8
	private int AGOIMGHMGOH; // 0xC
	public string BMBEAHIAGBH; // 0x10
	public byte[] KGFBCJBOJPK; // 0x14

	// public string MKANHLNEEGL { get; set; }
	// public int LJNAKDMILMC { get; set; }

	// RVA: 0x1DDF5AC Offset: 0x1DDF5AC VA: 0x1DDF5AC
	public OGNALGCHKED()
	{
		OBPBCNNFNFO = (int)(Utility.GetCurrentUnixTime() ^ 0x70f5a731);
	}

	// // RVA: 0x1DDF648 Offset: 0x1DDF648 VA: 0x1DDF648
	// public string KMICICLALGM() { }

	// // RVA: 0x1DDF800 Offset: 0x1DDF800 VA: 0x1DDF800
	// public void BEMBDHHJDAH(string NANNGLGOFKH) { }

	// // RVA: 0x1DDF868 Offset: 0x1DDF868 VA: 0x1DDF868
	// public int LIIHHICIBKM() { }

	// // RVA: 0x1DDF878 Offset: 0x1DDF878 VA: 0x1DDF878
	// public void OACJGKPBHIK(int NANNGLGOFKH) { }

	// // RVA: 0x1DDF798 Offset: 0x1DDF798 VA: 0x1DDF798
	// private void PCAGOJJPIIP(byte[] BNKHBCBJBKI) { }
}

public class EJABAIAPFLK
{
	public enum GHEPCFJHEEA
	{
		HJNNKCMLGFL = -1,
		MCIACFOAHID = 0,
		MECKFENAEPJ = 1,
		NDGMFGMHCJM = 2,
	}

	public int HAMJMEHKOKL; // 0x8
	public string LJNAKDMILMC; // 0xC
	public EJABAIAPFLK.GHEPCFJHEEA DLGMPHGKDKD; // 0x10
	public Nullable<int> NHPCKCOPKAM; // 0x14
	public Nullable<int> PJFKNNNDMIA; // 0x1C
	public bool DBMKMAPNCCK; // 0x24
	public bool JJOPBMCLBCB; // 0x25
	public int MLPLGFLKKLI; // 0x28
	public int ADPPAIPFHML; // 0x2C

	// // RVA: 0x12EBC80 Offset: 0x12EBC80 VA: 0x12EBC80
	// public uint CAOGDCBPBAN() { }

	// // RVA: 0x12EBCB8 Offset: 0x12EBCB8 VA: 0x12EBCB8
	// public EMOLDNAEDMG MGCBIOALLFE(BBHNACPENDM AHEFHIMGIBI) { }
}

public class BIJMLAPNMAB { }
public class BIJMLAPNMAB_SceneSwitch
{
	public string OIPCKOBNHJL_PrefabName; // 0x8
	public int AEMLILCNODL_MasterVersion; // 0xC

	// // RVA: 0xC85350 Offset: 0xC85350 VA: 0xC85350
	// public uint CAOGDCBPBAN() { }
}
