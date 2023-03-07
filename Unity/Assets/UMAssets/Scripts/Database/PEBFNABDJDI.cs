using System.Collections.Generic;
using XeSys;
using System;
using System.Text;

[System.Obsolete("Use PEBFNABDJDI_System", true)]
public class PEBFNABDJDI { }
public class PEBFNABDJDI_System : DIHHCBACKGG_DbSection
{
    public class JFIGGEAFMCN
    {
        public long BIMOIPDPLJO; // 0x8
        public int OLMFFMANMNE; // 0x10

        public long KJLPILMAIKH_Date { get { return BIMOIPDPLJO ^ 0xbd07d870; } set { BIMOIPDPLJO = value ^ 0xbd07d870; } } //GLFFDLFFELA 0x16C0E08 PEMIOJOMOHL 0x16C0DD8
        public int CEMEIPNMAAD_Version { get { return OLMFFMANMNE ^ 0x96aafb; } set { OLMFFMANMNE = value ^ 0x96aafb; } } //MPHJDGEDFOC 0x16C0E1C FNCCGEAMNAC 0x16C0DF4

        // // RVA: 0x16C0DA0 Offset: 0x16C0DA0 VA: 0x16C0DA0
        public JFIGGEAFMCN() 
        { 
            BIMOIPDPLJO = 0xbd07d870;
            OLMFFMANMNE = 0x96aafb;
        }
    }

	public static bool EEDNHJDKIAC; // 0x0
	private List<NNJFKLBPBNK_SecureString> IFBBNEGGCIH; // 0x40
	private List<CEBFFLDKAEC_SecureInt> JNJAOACIGOC; // 0x44
	public Dictionary<int, long> IOIDJALFFJA_GachaSortPriority = new Dictionary<int, long>(); // 0x48
	public sbyte[] NLNNEOLDOGE_PushTimeSlotIndex; // 0x4C
	public sbyte[] POEHINEHAEG_UneiPushTimeSlotPermit; // 0x50
	public int JDFBNIBIPPK_PushTimeSlotNum; // 0x54
	public bool GNEGCHEGECN_RaidPushEnable; // 0x58
    public List<int> PDELLJAOANM_GachaTicketCurrencyIds = new List<int>(); // 0x5C
	public int CAAMBBJBODI_StoryBgMax = 12; // 0x60
	private List<string> NCJKIFNCLAF_FixedBiasGpuName; // 0x64
	public int FPGDAPAILAK_ExtremeUnlock; // 0x68
	public List<JFIGGEAFMCN> BMAHEAMPCED_BeginnerGachaInfo = new List<JFIGGEAFMCN>(); // 0x6C
	public int KMDDIEJBNPO_CombackPushDisable; // 0x70

	public CHBDMJBEENG NGHKJOEDLIP { get; set; } // CLJNODMDGFA  0x20 // OPMNKEBHEBI // FLAGNHPCHCF
	public List<OGNALGCHKED> JDBLDOPHHNL_Enc { get; set; } // IJDNKAPDDFF 0x24 // FCBDHDGIMHO // OOLGKMGAHOP
	public List<EJABAIAPFLK> BHDJIIHLMDM_Query { get; set; } // BFKDBLJIGLO 0x28 // JIAMJJLMMLF // HBDIDBHLJCO
	public Dictionary<string, string> JLJEEMEOPLE { get; set; } // CJGBLCGHHEI 0x2C // DCHGJLCADKP // ICHNENECFGN
	public Dictionary<string, BIJMLAPNMAB_SceneSwitch> LMBIOEDHNHB_SceneSwitch { get; set; } // OOCFKPKLBJH 0x30 // BGCEPJDLFFA // JPLHJCLOPKE
	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI { get; set; } // IHKPIFIBECO 0x34 // GAMGELHIHHI // DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK { get; set; } // KLDCHOIPJGB 0x38 // AEMNOGNEBOJ // DGKDBOAMNBB
	public Dictionary<string, int> KBAPDOLLLAN_AcbSettings { get; set; } // BKGIMGCBBOC 0x3C // OOEBAHFJPAB // MCMHANFFFNF

	// // RVA: 0xCC4458 Offset: 0xCC4458 VA: 0xCC4458
	public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH)
	{
		if (!FJOEBCMGDMI.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		return FJOEBCMGDMI[LJNAKDMILMC].DNJEJEANJGL_Value;
	}

	// // RVA: 0xCC453C Offset: 0xCC453C VA: 0xCC453C
	public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH)
	{
		if(!OHJFBLFELNK.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		
		return OHJFBLFELNK[LJNAKDMILMC].DNJEJEANJGL_Value;
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
				if(DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion > val1 || (i + 1) >= strs.Length/2)
					return val2;
			}
		}
		return 0;
	}

	// // RVA: 0xCC4804 Offset: 0xCC4804 VA: 0xCC4804
	public bool EJPFDDOOKJI(string MDBKPOCDJDP)
	{
		return NCJKIFNCLAF_FixedBiasGpuName.Contains(MDBKPOCDJDP);
	}

	// // RVA: 0xCC4880 Offset: 0xCC4880 VA: 0xCC4880
	// public int NCEMAEDMJLO(long EOLFJGMAJAB) { }

	// // RVA: 0xCC49B8 Offset: 0xCC49B8 VA: 0xCC49B8
	// public bool JLAJNCMIIOK(int JIKLEHGJKBH, string OPFGFINHFCE) { }

	// // RVA: 0xCC4B20 Offset: 0xCC4B20 VA: 0xCC4B20
	public int GAGDEIMGBBG(int JIKLEHGJKBH)
	{
		string[] strs = EFEGBHACJAL("default_3dmode_android", "1,1,0").Split(new char[] { ',' });
		return int.Parse(strs[JIKLEHGJKBH]);
	}

	// // RVA: 0xCC4C4C Offset: 0xCC4C4C VA: 0xCC4C4C
	public int DDGHBNLOBAJ_GetCueEncryptedKey(string OPFGFINHFCE)
	{
		if (!KBAPDOLLLAN_AcbSettings.ContainsKey(OPFGFINHFCE))
			return 0;
		return KBAPDOLLLAN_AcbSettings[OPFGFINHFCE];
	}

	// // RVA: 0xCC4D0C Offset: 0xCC4D0C VA: 0xCC4D0C
	public PEBFNABDJDI_System()
    {
		JIKKNHIAEKG_BlockName = "";
        LNIMEIMBCMF = false;
        NGHKJOEDLIP = new CHBDMJBEENG();
        JDBLDOPHHNL_Enc = new List<OGNALGCHKED>();
        BHDJIIHLMDM_Query = new List<EJABAIAPFLK>();
        JLJEEMEOPLE = new Dictionary<string, string>();
        LMHMIIKCGPE = 79;
        LMBIOEDHNHB_SceneSwitch = new Dictionary<string, BIJMLAPNMAB_SceneSwitch>();
        OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
        KBAPDOLLLAN_AcbSettings = new Dictionary<string, int>();
        JNJAOACIGOC = new List<CEBFFLDKAEC_SecureInt>();
        FJOEBCMGDMI = new Dictionary<string, NNJFKLBPBNK_SecureString>();
        IFBBNEGGCIH = new List<NNJFKLBPBNK_SecureString>();
        NLNNEOLDOGE_PushTimeSlotIndex = new sbyte[24];
        POEHINEHAEG_UneiPushTimeSlotPermit = new sbyte[24];
    }

	// // RVA: 0xCC50C8 Offset: 0xCC50C8 VA: 0xCC50C8 Slot: 8
	protected override void KMBPACJNEOF()
	{
		JDBLDOPHHNL_Enc.Clear();
		NGHKJOEDLIP.FPBEBCIPEPI_GachaHour.Clear();
		NGHKJOEDLIP.FPBEBCIPEPI_GachaHour.Add(0);
		OHJFBLFELNK.Clear();
		JNJAOACIGOC.Clear();
		KBAPDOLLLAN_AcbSettings.Clear();
		FJOEBCMGDMI.Clear();
		IFBBNEGGCIH.Clear();
		CAAMBBJBODI_StoryBgMax = 12;
		BMAHEAMPCED_BeginnerGachaInfo.Clear();
		FPGDAPAILAK_ExtremeUnlock = 0;
		IOIDJALFFJA_GachaSortPriority.Clear();
	}

	// // RVA: 0xCC5308 Offset: 0xCC5308 VA: 0xCC5308 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		IAIDGBJGDBH reader = IAIDGBJGDBH.HEGEKFMJNCC(DBBGALAPFGC);
		NGHKJOEDLIP.PFNBMPCIIJJ_HealSec = (int)reader.EOACHAJJLHB.PFNBMPCIIJJ;
		NGHKJOEDLIP.KBNGOBEAHIC_KeyPath = reader.EOACHAJJLHB.KBNGOBEAHIC;
		NGHKJOEDLIP.JOIEHMBKJHI_RetryWaitMs = reader.EOACHAJJLHB.JOIEHMBKJHI;
		NGHKJOEDLIP.KHGJIGNHAGD = reader.EOACHAJJLHB.KHGJIGNHAGD;
		NGHKJOEDLIP.EEBOIPHMMBP = 5;
		NGHKJOEDLIP.IMNJNFICJPM = 5;
		NGHKJOEDLIP.PIAMMJNADJH_PlayerMaxLevel = reader.EOACHAJJLHB.PIJNJBJMFHL;
		NGHKJOEDLIP.KMNPFOPBDMA_RenameDay = (int)reader.EOACHAJJLHB.KMNPFOPBDMA;
		NGHKJOEDLIP.FPBEBCIPEPI_GachaHour.Clear();
		for(int i = 0; i < reader.EOACHAJJLHB.JEDMLKOECHN.Length; i++)
		{
			NGHKJOEDLIP.FPBEBCIPEPI_GachaHour.Add((sbyte)reader.EOACHAJJLHB.JEDMLKOECHN[i]);
		}
		{
			CAEJOAOPJCJ[] array = reader.POEOOJPBOJC;
			for(int i = 0; i < array.Length; i++)
			{
				OGNALGCHKED data = new OGNALGCHKED();
				data.MKANHLNEEGL_Filter = array[i].MKANHLNEEGL;
				data.LJNAKDMILMC_Key = (int)array[i].LJNAKDMILMC;
				JDBLDOPHHNL_Enc.Add(data);
			}
		}
		{
			KHCOEKAINPK[] array = reader.KPDMCJELMCI;
			for (int i = 0; i < array.Length; i++)
			{
				EJABAIAPFLK data = new EJABAIAPFLK();
				data.HAMJMEHKOKL_Id = (int)array[i].PPFNGGCBJKC;
				data.LJNAKDMILMC_Key = array[i].LJNAKDMILMC;
				data.DLGMPHGKDKD_Ofs = (EJABAIAPFLK.GHEPCFJHEEA)array[i].IKNALLJDAFH;
				data.NHPCKCOPKAM_From = array[i].NHPCKCOPKAM;
				data.PJFKNNNDMIA_To = array[i].PJFKNNNDMIA;
				data.DBMKMAPNCCK_OnlyFriends = array[i].PLGFGIAHDHJ != 0;
				data.JJOPBMCLBCB_ExcludeBan = array[i].DLAIGBEOGNN != 0;
				data.ADPPAIPFHML_Num = (int)array[i].ADPPAIPFHML;
				data.MLPLGFLKKLI_Ipp = (int)array[i].MLPLGFLKKLI;
				BHDJIIHLMDM_Query.Add(data);
			}
		}
		for (int i = 0; i < reader.NELGGEGAJPH.Length; i++)
		{
			JLJEEMEOPLE.Add(reader.NELGGEGAJPH[i].PPFNGGCBJKC, reader.NELGGEGAJPH[i].HJLDBEJOMIO);
		}
		for (int i = 0; i < reader.GJOBPIOOEHD.Length; i++)
		{
			BIJMLAPNMAB_SceneSwitch data = new BIJMLAPNMAB_SceneSwitch();
			data.OIPCKOBNHJL_PrefabName = reader.GJOBPIOOEHD[i].BDCNFMMAEJJ;
			data.AEMLILCNODL_MasterVersion = (int)reader.GJOBPIOOEHD[i].CJOKJFGDHLD;
			LMBIOEDHNHB_SceneSwitch.Add(reader.GJOBPIOOEHD[i].GJCCGIFLKPD, data);
		}
		{
			FNLNOMGDCIJ[] array = reader.BHGDNGHDDAC;
			for (int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				OHJFBLFELNK.Add(array[i].LJNAKDMILMC, data);
				JNJAOACIGOC.Add(data);
			}
		}
		for (int i = 0; i < reader.MHGMDJNOLMI.Length; i++)
		{
			NNJFKLBPBNK_SecureString data = new NNJFKLBPBNK_SecureString();
			data.DNJEJEANJGL_Value = reader.MHGMDJNOLMI[i].JBGEEPFKIGG;
			FJOEBCMGDMI[reader.MHGMDJNOLMI[i].LJNAKDMILMC] = data;
			IFBBNEGGCIH.Add(data);
		}
		CAAMBBJBODI_StoryBgMax = HEDDDBDAMGO("story_bg_maximum", "1,12");

		NCJKIFNCLAF_FixedBiasGpuName = new List<string>();
		string str = EFEGBHACJAL("fixedbias_gpu_name", "");
		if(!string.IsNullOrEmpty(str))
		{
			char[] sep = new char[1] { ',' };
			NCJKIFNCLAF_FixedBiasGpuName.AddRange(str.Split(sep));
		}

		FPGDAPAILAK_ExtremeUnlock = HEDDDBDAMGO("extreme_unlock", "1,2");
		str = EFEGBHACJAL("beginner_gacha_info", "");
		if(!string.IsNullOrEmpty(str))
		{
			char[] sep = new char[1] { ',' };
			string[] strs = str.Split(sep);
			for(int i = 0; i < strs.Length; i++)
			{
				sep = new char[1] { '=' };
				JFIGGEAFMCN data = new JFIGGEAFMCN();
				string[] strs2 = strs[i].Split(sep);
				DateTime date;
				if (DateTime.TryParse(strs2[1], out date))
				{
					data.KJLPILMAIKH_Date = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
					int val;
					if(Int32.TryParse(strs[0], out val))
					{
						data.CEMEIPNMAAD_Version = val;
						BMAHEAMPCED_BeginnerGachaInfo.Add(data);
					}
				}
			}
		}
		if ((LPJLEHAJADA("acb_setting", 3) & 1) != 0)
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
					KBAPDOLLLAN_AcbSettings.Add("cs_w_"+val1.ToString("D4"), val2);
				}
			}
		}
		KMDDIEJBNPO_CombackPushDisable = LPJLEHAJADA("comback_push_disable", 0);
		DMLGPFLLMOB(IOIDJALFFJA_GachaSortPriority, EFEGBHACJAL("gacha_sort_prioirty", ""));
		{
			str = EFEGBHACJAL("push_time_slot_index", "0,0,0,0,1,1,1,1,2,2,2,2,3,3,3,3,4,4,4,4,5,5,5,5");
			char[] sep = new char[1] { ',' };
			string[] strs = str.Split(sep);
			for(int i = 0; i < strs.Length; i++)
			{
				if(i < NLNNEOLDOGE_PushTimeSlotIndex.Length)
				{
					NLNNEOLDOGE_PushTimeSlotIndex[i] = (sbyte)Int32.Parse(strs[i]);
				}
			}
		}
		{
			str = EFEGBHACJAL("unei_push_time_slot_permit", "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1");
			char[] sep = new char[1] { ',' };
			string[] strs = str.Split(sep);
			for (int i = 0; i < strs.Length; i++)
			{
				if (i < POEHINEHAEG_UneiPushTimeSlotPermit.Length)
				{
					POEHINEHAEG_UneiPushTimeSlotPermit[i] = (sbyte)Int32.Parse(strs[i]);
				}
			}
		}
		JDFBNIBIPPK_PushTimeSlotNum = LPJLEHAJADA("push_time_slot_num", 6);
		GNEGCHEGECN_RaidPushEnable = LPJLEHAJADA("raid_push_enable", 1) != 0;
		{
			str = EFEGBHACJAL("gacha_ticket_currency_ids", string.Empty);
			char[] sep = new char[1] { ',' };
			string[] strs = str.Split(sep);
			PDELLJAOANM_GachaTicketCurrencyIds.Clear();
			for (int i = 0; i < strs.Length; i++)
			{
				int val = 0;
				if (Int32.TryParse(strs[i], out val))
				{
					PDELLJAOANM_GachaTicketCurrencyIds.Add(val);
				}
			}
		}

		return true;
    }

	// // RVA: 0xCC6E38 Offset: 0xCC6E38 VA: 0xCC6E38 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(100, "TODO");
		return true;
	}

	// // RVA: 0xCC6B8C Offset: 0xCC6B8C VA: 0xCC6B8C
	private void DMLGPFLLMOB(Dictionary<int, long> AKMJDDOFJOL, string FJOEBCMGDMI)
	{
		char[] sep = new char[1] { ',' };
		string[] strs = FJOEBCMGDMI.Split(sep);
		for(int i = 0; i < strs.Length; i++)
		{
			char[] sep2 = new char[1] { ':' };
			string[] strs2 = strs[i].Split(sep2);
			if(strs2.Length > 1)
			{
				int val = 0;
				if(Int32.TryParse(strs2[0], out val))
				{
					AKMJDDOFJOL.Add(val, Convert.ToInt64(strs2[1], 16));
				}
			}
		}
	}

	// // RVA: 0xCC7E98 Offset: 0xCC7E98 VA: 0xCC7E98
	// public int AHJDJACMFMN(long EOLFJGMAJAB) { }

	// // RVA: 0xCC7F98 Offset: 0xCC7F98 VA: 0xCC7F98 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "PEBFNABDJDI_System.CAOGDCBPBAN");
		return 0;
	}

	// // RVA: 0xCC8338 Offset: 0xCC8338 VA: 0xCC8338
	// public bool BLEDNLHJDEF() { }

	// // RVA: 0xCC8404 Offset: 0xCC8404 VA: 0xCC8404
	// public bool BEFGHIJNEBL() { }

	// // RVA: 0xCC84D0 Offset: 0xCC84D0 VA: 0xCC84D0
	// public bool MDECFOOCLHG() { }

	// // RVA: 0xCC859C Offset: 0xCC859C VA: 0xCC859C
	public bool OANJBOPLCKP_IsUnit5Enabled()
	{
		int val = LPJLEHAJADA("unit5_enable_master_version", 0);
		return val > 0 && val <= DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion;
	}

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
	public List<sbyte> FPBEBCIPEPI_GachaHour = new List<sbyte>(10); // 0x2C

	public int PFNBMPCIIJJ_HealSec { get { return DCBANOMELHM ^ OBPBCNNFNFO; } set { DCBANOMELHM = value ^ OBPBCNNFNFO; } } //FHKONOMKGBN 0x12BE018 BLIGJALGJIK 0x12BE028
	public int KBNGOBEAHIC_KeyPath { get { return OBPBCNNFNFO ^ NMJDFCEJOCP; } set { NMJDFCEJOCP = OBPBCNNFNFO ^ value; } } //JKEJHFKAKDN 0x12BE038 OKFDFHNIILF 0x12BE048
	public int JOIEHMBKJHI_RetryWaitMs { get { return OBPBCNNFNFO ^ IGNPLAKONFE; } set { IGNPLAKONFE = OBPBCNNFNFO ^ value; } } //LKFCFNJDCOD 0x12BE058 EAKKAOCBAMF 0x12BE068
	public int KHGJIGNHAGD { get { return OBPBCNNFNFO ^ JOGHEIDHELL; } set { JOGHEIDHELL = OBPBCNNFNFO ^ value; } } //NLNDHIKBGOA 0x12BE078 OACFGDPBLCP 0x12BE088
	public int EEBOIPHMMBP { get { return ALMFPODMADF ^ OBPBCNNFNFO; } set { ALMFPODMADF = value ^ OBPBCNNFNFO; } } //PCJCHDJPDHN 0x12BE098 BCLCFCILPFP 0x12BE0A8
	public int IMNJNFICJPM { get { return HNDNGHNDNMD ^ OBPBCNNFNFO; } set { HNDNGHNDNMD = value ^ OBPBCNNFNFO; } } //GCLLEGIMPCF 0x12BE0B8 FKPEMBDPOME 0x12BE0C8
	public int PIAMMJNADJH_PlayerMaxLevel { get { return JIICFAEIGLO ^ OBPBCNNFNFO; } set { JIICFAEIGLO = value ^ OBPBCNNFNFO; } } //AOHLFEDHOHH 0x12BE0D8 IPHJMAENLHE 0x12BE0E8
	public int KMNPFOPBDMA_RenameDay { get { return ELCCKELHDIJ ^ OBPBCNNFNFO; } set { ELCCKELHDIJ = value ^ OBPBCNNFNFO; } } //BKMILJONJDL 0x12BE0F8 PLJFDIKPMMH 0x12BE108

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

	public string MKANHLNEEGL_Filter { get {
			if (KGFBCJBOJPK == null)
				return null;
			byte[] b = new byte[KGFBCJBOJPK.Length];
			for (int i = 0; i < KGFBCJBOJPK.Length; i++)
				b[i] = KGFBCJBOJPK[i];
			PCAGOJJPIIP(b);
			return Encoding.UTF8.GetString(b);
		} set {
			if (value == null)
				KGFBCJBOJPK = null;
			KGFBCJBOJPK = Encoding.UTF8.GetBytes(value);
			PCAGOJJPIIP(KGFBCJBOJPK);
		} } //0x1DDF648 KMICICLALGM 0x1DDF800 BEMBDHHJDAH
	public int LJNAKDMILMC_Key { get { return AGOIMGHMGOH ^ OBPBCNNFNFO; } set { AGOIMGHMGOH = value ^ OBPBCNNFNFO; } } //0x1DDF868 LIIHHICIBKM 0x1DDF878 OACJGKPBHIK

	// RVA: 0x1DDF5AC Offset: 0x1DDF5AC VA: 0x1DDF5AC
	public OGNALGCHKED()
	{
		OBPBCNNFNFO = (int)(Utility.GetCurrentUnixTime() ^ 0x70f5a731);
	}

	// // RVA: 0x1DDF798 Offset: 0x1DDF798 VA: 0x1DDF798
	private void PCAGOJJPIIP(byte[] BNKHBCBJBKI)
	{
		for(int i = 0; i < BNKHBCBJBKI.Length; i++)
		{
			BNKHBCBJBKI[i] = (byte)(BNKHBCBJBKI[i] ^ (OBPBCNNFNFO >> 3));
		}
	}
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

	public int HAMJMEHKOKL_Id; // 0x8
	public string LJNAKDMILMC_Key; // 0xC
	public EJABAIAPFLK.GHEPCFJHEEA DLGMPHGKDKD_Ofs; // 0x10
	public Nullable<int> NHPCKCOPKAM_From; // 0x14
	public Nullable<int> PJFKNNNDMIA_To; // 0x1C
	public bool DBMKMAPNCCK_OnlyFriends; // 0x24
	public bool JJOPBMCLBCB_ExcludeBan; // 0x25
	public int MLPLGFLKKLI_Ipp; // 0x28
	public int ADPPAIPFHML_Num; // 0x2C

	// // RVA: 0x12EBC80 Offset: 0x12EBC80 VA: 0x12EBC80
	// public uint CAOGDCBPBAN() { }

	// // RVA: 0x12EBCB8 Offset: 0x12EBCB8 VA: 0x12EBCB8
	public EMOLDNAEDMG MGCBIOALLFE(BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
		int? from = null;
		int? to = null;
		switch(DLGMPHGKDKD_Ofs)
		{
			case GHEPCFJHEEA.MCIACFOAHID:
				to = PJFKNNNDMIA_To;
				from = NHPCKCOPKAM_From;
				break;
			case GHEPCFJHEEA.MECKFENAEPJ:
				from = NHPCKCOPKAM_From;
				to = PJFKNNNDMIA_To + 1;
				break;
			case GHEPCFJHEEA.NDGMFGMHCJM:
				from = NHPCKCOPKAM_From + AHEFHIMGIBI.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
				if (from < 2)
					from = 1;
				to = PJFKNNNDMIA_To + AHEFHIMGIBI.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
				break;
			case GHEPCFJHEEA.HJNNKCMLGFL:
				from = NHPCKCOPKAM_From;
				to = PJFKNNNDMIA_To;
				break;
		}
		EMOLDNAEDMG res = new EMOLDNAEDMG();
		res.IDLHJIOMJBK_SakashoCriteria = SakashoPlayerCriteria.NewCriteriaFromTo(LJNAKDMILMC_Key, from, to);
		res.IDLHJIOMJBK_SakashoCriteria.ExcludeAccountBan = JJOPBMCLBCB_ExcludeBan;
		res.IDLHJIOMJBK_SakashoCriteria.OnlyFriends = DBMKMAPNCCK_OnlyFriends;
		res.MLPLGFLKKLI_Ipp = MLPLGFLKKLI_Ipp;
		res.ADPPAIPFHML_Num = ADPPAIPFHML_Num;
		return res;
	}
}

[System.Obsolete("Use BIJMLAPNMAB_SceneSwitch", true)]
public class BIJMLAPNMAB { }
public class BIJMLAPNMAB_SceneSwitch
{
	public string OIPCKOBNHJL_PrefabName; // 0x8
	public int AEMLILCNODL_MasterVersion; // 0xC

	// // RVA: 0xC85350 Offset: 0xC85350 VA: 0xC85350
	// public uint CAOGDCBPBAN() { }
}
