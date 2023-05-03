
using System.Collections.Generic;

[System.Obsolete("Use BCGFHLIEKLJ_DecoItem", true)]
public class BCGFHLIEKLJ { }
public class BCGFHLIEKLJ_DecoItem : KLFDBFMNLBL_ServerSaveBlock
{
	public class AKAHOEBACGJ
	{
		public int ENOBDCFHELD; // 0x8
		public int FCEJCHGLFGN; // 0xC
		public long JHOLGGAKMOH; // 0x10
		public long BCGMFGMCPCP; // 0x18
		private const sbyte JFOFMKBJBBE_False = 0x13;
		private const sbyte CNECJGKECHK_True = 0x57;
		private int EHOIENNDEDH; // 0x20
		public int INCHFKJOIEK; // 0x24
		private int IFEHKNJONPL; // 0x28
		public int ONFJFGFNGGD; // 0x2C
		private sbyte ACKPOCNHOOP; // 0x30
		public sbyte KCEAEOMJNFO; // 0x31

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ ENOBDCFHELD; } set { EHOIENNDEDH = value ^ ENOBDCFHELD; INCHFKJOIEK = value ^ FCEJCHGLFGN; } } //0xF30D20 DEMEPMAEJOO 0xF323A0 HIGKAIDMOKN
		public int BFINGCJHOHI_Cnt { get { return IFEHKNJONPL ^ ENOBDCFHELD; } set { IFEHKNJONPL = value ^ ENOBDCFHELD; ONFJFGFNGGD = value ^ FCEJCHGLFGN; } } //0xF30D30 LFMCLIDAPHB 0xF323B4 EDAEPDGGFJJ
		public bool CADENLBDAEB_IsNew { get { return ACKPOCNHOOP == CNECJGKECHK_True; } set { ACKPOCNHOOP = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; KCEAEOMJNFO = value ? JFOFMKBJBBE_False : CNECJGKECHK_True; } } //0xF30D40 KJGFPPLHLAB 0xF323C8 ILJHLPMDHPO

		// RVA: 0xF2EE60 Offset: 0xF2EE60 VA: 0xF2EE60
		public AKAHOEBACGJ()
		{
			ENOBDCFHELD = LPDNKHAIOLH.CEIBAFOCNCA();
			FCEJCHGLFGN = LPDNKHAIOLH.CEIBAFOCNCA();
			JHOLGGAKMOH = ~ENOBDCFHELD;
			BCGMFGMCPCP = ~FCEJCHGLFGN;
		}

		//// RVA: 0xF2EF18 Offset: 0xF2EF18 VA: 0xF2EF18
		public void LHPDDGIJKNB(int PPFNGGCBJKC = 0)
		{
			this.PPFNGGCBJKC_Id = PPFNGGCBJKC;
			BFINGCJHOHI_Cnt = 0;
			CADENLBDAEB_IsNew = false;
		}

		//// RVA: 0xF32AA4 Offset: 0xF32AA4 VA: 0xF32AA4
		public AKAHOEBACGJ ODDIHGPONFL(AKAHOEBACGJ GPBJHKLFCEP)
		{
			PPFNGGCBJKC_Id = GPBJHKLFCEP.PPFNGGCBJKC_Id;
			BFINGCJHOHI_Cnt = GPBJHKLFCEP.BFINGCJHOHI_Cnt;
			CADENLBDAEB_IsNew = GPBJHKLFCEP.CADENLBDAEB_IsNew;
			return this;
		}

		//// RVA: 0xF33270 Offset: 0xF33270 VA: 0xF33270
		public bool AGBOGBEOFME(AKAHOEBACGJ OIKJFMGEICL)
		{
			if(PPFNGGCBJKC_Id != OIKJFMGEICL.PPFNGGCBJKC_Id ||
				BFINGCJHOHI_Cnt != OIKJFMGEICL.BFINGCJHOHI_Cnt ||
				CADENLBDAEB_IsNew != OIKJFMGEICL.CADENLBDAEB_IsNew)
				return false;
			return true;
		}

		//// RVA: 0xF30CF4 Offset: 0xF30CF4 VA: 0xF30CF4
		//public bool DFIGPDCBAPB() { }

		//// RVA: 0xF341A8 Offset: 0xF341A8 VA: 0xF341A8
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, BCGFHLIEKLJ.AKAHOEBACGJ OHMCIEMIKCE, bool EFOEPDLNLJG) { }

		//// RVA: 0xF34D3C Offset: 0xF34D3C VA: 0xF34D3C
		//public FENCAJJBLBH PFAKPFKJJKA() { }

		//// RVA: 0xF351F0 Offset: 0xF351F0 VA: 0xF351F0
		//public bool PPJAGFPBFHJ(int HMFFHLPNMPH) { }
	}

	public class GNGFGEIAGJL : AKAHOEBACGJ
	{
		public int ICKOHEDLEFP; // 0x34
		public int DNNBPDILAKL; // 0x38
		public int MBCPMFPKNBA; // 0x3C
		public int DKOGOBKOGBM; // 0x40
		public long MCPHOEIDJAD; // 0x48
		public long LPKAMAJLKPP; // 0x50
		public long AEHDMHDCOAH; // 0x58
		public long GKBHBHNPMED; // 0x60

		public int JBGEEPFKIGG_Val { get { return ICKOHEDLEFP ^ ENOBDCFHELD; } set { ICKOHEDLEFP = value ^ ENOBDCFHELD; DNNBPDILAKL = value ^ FCEJCHGLFGN; } } //0xF30DD4 OLOCMINKGON 0xF32420 ABAFHIBFKCE
		public int ANAJIAENLNB_Level { get { return MBCPMFPKNBA ^ ENOBDCFHELD; } set { MBCPMFPKNBA = value ^ ENOBDCFHELD; DKOGOBKOGBM = value ^ FCEJCHGLFGN; } } //0xF30DE4 MMOMNMBKHJF 0xF32438 FEHNFGPFINK
		public long FOONCJDLLIK_CTm { get { return MCPHOEIDJAD ^ JHOLGGAKMOH; } set { MCPHOEIDJAD = value ^ JHOLGGAKMOH; LPKAMAJLKPP = value ^ BCGMFGMCPCP; } } //0xF30DF4 BONPKDDFHNB 0xF32450 OEAGMCNGNLL
		public long EMHCHMHMFHJ_CTmOfs { get { return AEHDMHDCOAH ^ JHOLGGAKMOH; } set { AEHDMHDCOAH = value ^ JHOLGGAKMOH; GKBHBHNPMED = value ^ BCGMFGMCPCP; } } //0xF30E08 HEOOBGPDPND 0xF32474 KFMNIKFMHOD

		// RVA: 0xF2EF38 Offset: 0xF2EF38 VA: 0xF2EF38
		public GNGFGEIAGJL()
		{
			LHPDDGIJKNB(0);
		}

		//// RVA: 0xF2EF58 Offset: 0xF2EF58 VA: 0xF2EF58
		public new void LHPDDGIJKNB(int PPFNGGCBJKC = 0)
		{
			base.LHPDDGIJKNB(PPFNGGCBJKC);
			FOONCJDLLIK_CTm = 0;
			EMHCHMHMFHJ_CTmOfs = 0;
			JBGEEPFKIGG_Val = 0;
			ANAJIAENLNB_Level = 1;
		}

		//// RVA: 0xF32B3C Offset: 0xF32B3C VA: 0xF32B3C
		public GNGFGEIAGJL ODDIHGPONFL(GNGFGEIAGJL GPBJHKLFCEP)
		{
			base.ODDIHGPONFL(GPBJHKLFCEP);
			JBGEEPFKIGG_Val = GPBJHKLFCEP.JBGEEPFKIGG_Val;
			ANAJIAENLNB_Level = GPBJHKLFCEP.ANAJIAENLNB_Level;
			FOONCJDLLIK_CTm = GPBJHKLFCEP.FOONCJDLLIK_CTm;
			EMHCHMHMFHJ_CTmOfs = GPBJHKLFCEP.EMHCHMHMFHJ_CTmOfs;
			return this;
			
		}

		//// RVA: 0xF33338 Offset: 0xF33338 VA: 0xF33338
		//public bool AGBOGBEOFME(BCGFHLIEKLJ.GNGFGEIAGJL OIKJFMGEICL) { }

		//// RVA: 0xF30D54 Offset: 0xF30D54 VA: 0xF30D54
		//public bool DFIGPDCBAPB() { }

		//// RVA: 0xF34460 Offset: 0xF34460 VA: 0xF34460
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, BCGFHLIEKLJ.GNGFGEIAGJL OHMCIEMIKCE, bool EFOEPDLNLJG) { }

		//// RVA: 0xF34E6C Offset: 0xF34E6C VA: 0xF34E6C
		//public FENCAJJBLBH PFAKPFKJJKA() { }
	}

	private const int ECFEMKGFDCE = 3;
	private const string POFDDFCGEGP = "_";
	public const int ANOIFBFMJBP = 1;
	public const int FOFNKPBEFGH = 5;
	public const int IOBMKHGKDPH = 1;
	public const int BFOCEIGBFDO = 1;
	public const int FHMFBDFDNKE = 50;
	private const int AFOABJNOHAI = 200;
	private const int OPFHEMEPCLF = 6000;
	private const int KDMILKGINIJ = 100;
	private const int PEMGHACIFFE = 50;
	private const int LEGINFJMMIE = 100;
	private const int DPGCGCHGGDL = 300;
	public int ENOBDCFHELD; // 0x24
	public int FCEJCHGLFGN; // 0x28
	public long JHOLGGAKMOH; // 0x30
	public long BCGMFGMCPCP; // 0x38
	private long MEEMHKPLHJD; // 0x58
	private long IEGEBHKPKMG; // 0x60

	public List<AKAHOEBACGJ> DJHBDDGEKGO_Bgs { get; private set; } // 0x40 OFEGCFCDMHI HBAMJHDDJFM KNHIHMEMJFG
	public List<AKAHOEBACGJ> KPMFLNOELIN_Objs { get; private set; } // 0x44 CADKDIOOABF OFBFDEOELGP PFONKPMNHIC
	public List<AKAHOEBACGJ> PEBDEIKBCCM_Chars { get; private set; } // 0x48 LEIABNBAPDF IIKABCDNMHE NGPIHFEHDCH
	public List<GNGFGEIAGJL> NBKAMFFIOOG_Sp { get; private set; } // 0x4C ILBDLKBMCLL HDJOCNANCEI JMEAGFDOOGE
	public List<AKAHOEBACGJ> PFNNIMBMKDL_Posters { get; private set; } // 0x50 FIIKAHPNLIE IGJGKPNGDIH JNGABBLANIN
	public List<AKAHOEBACGJ> NOAEDPJGBJK_Sets { get; private set; } // 0x54 PGLOGOHILGI CIDOGCLBPDM ILJKEMBMMBG
	public long MKLJLHBHBJA_AcumAt { get { return MEEMHKPLHJD ^ JHOLGGAKMOH; } set { MEEMHKPLHJD = value ^ JHOLGGAKMOH; IEGEBHKPKMG = value ^ BCGMFGMCPCP; } } // BFGAIJEPHKF 0xF2F008 ENMIOFHLLMG 0xF2EFE4
	public override bool DMICHEJIAJL { get { return true; } } // 0xF35028 NFKFOODCJJB

	// // RVA: 0xF2A574 Offset: 0xF2A574 VA: 0xF2A574
	public BCGFHLIEKLJ_DecoItem()
	{
		ENOBDCFHELD = LPDNKHAIOLH.CEIBAFOCNCA();
		FCEJCHGLFGN = LPDNKHAIOLH.CEIBAFOCNCA();
		JHOLGGAKMOH = ~ENOBDCFHELD;
		BCGMFGMCPCP = ~FCEJCHGLFGN;
		DJHBDDGEKGO_Bgs = new List<AKAHOEBACGJ>();
		KPMFLNOELIN_Objs = new List<AKAHOEBACGJ>();
		PEBDEIKBCCM_Chars = new List<AKAHOEBACGJ>();
		NBKAMFFIOOG_Sp = new List<GNGFGEIAGJL>();
		PFNNIMBMKDL_Posters = new List<AKAHOEBACGJ>();
		NOAEDPJGBJK_Sets = new List<AKAHOEBACGJ>();
	}

	// // RVA: 0xF2E988 Offset: 0xF2E988 VA: 0xF2E988 Slot: 4
	public override void KMBPACJNEOF()
	{
		DJHBDDGEKGO_Bgs.Clear();
		KPMFLNOELIN_Objs.Clear();
		PEBDEIKBCCM_Chars.Clear();
		NBKAMFFIOOG_Sp.Clear();
		PFNNIMBMKDL_Posters.Clear();
		for(int i = 0; i < 200; i++)
		{
			AKAHOEBACGJ data = new AKAHOEBACGJ();
			data.LHPDDGIJKNB(i + 1);
			DJHBDDGEKGO_Bgs.Add(data);
		}
		for(int i = 0; i < 6000; i++)
		{
			AKAHOEBACGJ data = new AKAHOEBACGJ();
			data.LHPDDGIJKNB(i + 1);
			KPMFLNOELIN_Objs.Add(data);
		}
		for (int i = 0; i < 100; i++)
		{
			AKAHOEBACGJ data = new AKAHOEBACGJ();
			data.LHPDDGIJKNB(i + 1);
			PEBDEIKBCCM_Chars.Add(data);
		}
		for (int i = 0; i < 50; i++)
		{
			GNGFGEIAGJL data = new GNGFGEIAGJL();
			data.LHPDDGIJKNB(i + 1);
			NBKAMFFIOOG_Sp.Add(data);
		}
		for (int i = 0; i < 100; i++)
		{
			AKAHOEBACGJ data = new AKAHOEBACGJ();
			data.LHPDDGIJKNB(i + 1);
			PFNNIMBMKDL_Posters.Add(data);
		}
		for (int i = 0; i < 300; i++)
		{
			AKAHOEBACGJ data = new AKAHOEBACGJ();
			data.LHPDDGIJKNB(i + 1);
			NOAEDPJGBJK_Sets.Add(data);
		}
		MKLJLHBHBJA_AcumAt = 0;
	}

	// // RVA: 0xF2F01C Offset: 0xF2F01C VA: 0xF2F01C Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2["_"] = "";
			for(int i = 0; i < DJHBDDGEKGO_Bgs.Count; i++)
			{
				if(DJHBDDGEKGO_Bgs[i].BFINGCJHOHI_Cnt != 0 || DJHBDDGEKGO_Bgs[i].CADENLBDAEB_IsNew)
				{
					EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
					data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = DJHBDDGEKGO_Bgs[i].PPFNGGCBJKC_Id;
					data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = DJHBDDGEKGO_Bgs[i].BFINGCJHOHI_Cnt;
					data3[AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new] = DJHBDDGEKGO_Bgs[i].CADENLBDAEB_IsNew ? 1 : 0;
					data2["_" + (i + 1)] = data3;
				}
			}
			data[AFEHLCGHAEE_Strings.JMPEGAACBKA_di_bg] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2["_"] = "";
			for (int i = 0; i < KPMFLNOELIN_Objs.Count; i++)
			{
				if (KPMFLNOELIN_Objs[i].BFINGCJHOHI_Cnt != 0 || KPMFLNOELIN_Objs[i].CADENLBDAEB_IsNew)
				{
					EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
					data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = KPMFLNOELIN_Objs[i].PPFNGGCBJKC_Id;
					data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = KPMFLNOELIN_Objs[i].BFINGCJHOHI_Cnt;
					data3[AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new] = KPMFLNOELIN_Objs[i].CADENLBDAEB_IsNew ? 1 : 0;
					data2["_" + (i + 1)] = data3;
				}
			}
			data[AFEHLCGHAEE_Strings.BEJFAOEGBLE_di_obj] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2["_"] = "";
			for (int i = 0; i < PEBDEIKBCCM_Chars.Count; i++)
			{
				if (PEBDEIKBCCM_Chars[i].BFINGCJHOHI_Cnt != 0 || PEBDEIKBCCM_Chars[i].CADENLBDAEB_IsNew)
				{
					EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
					data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = PEBDEIKBCCM_Chars[i].PPFNGGCBJKC_Id;
					data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = PEBDEIKBCCM_Chars[i].BFINGCJHOHI_Cnt;
					data3[AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new] = PEBDEIKBCCM_Chars[i].CADENLBDAEB_IsNew ? 1 : 0;
					data2["_" + (i + 1)] = data3;
				}
			}
			data[AFEHLCGHAEE_Strings.GJMJHEPMLOA_di_chr] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2["_"] = "";
			for (int i = 0; i < NBKAMFFIOOG_Sp.Count; i++)
			{
				if (NBKAMFFIOOG_Sp[i].BFINGCJHOHI_Cnt != 0 || NBKAMFFIOOG_Sp[i].CADENLBDAEB_IsNew ||
					NBKAMFFIOOG_Sp[i].FOONCJDLLIK_CTm != 0 || NBKAMFFIOOG_Sp[i].JBGEEPFKIGG_Val != 0 ||
					NBKAMFFIOOG_Sp[i].ANAJIAENLNB_Level != 1)
				{
					EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
					data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = NBKAMFFIOOG_Sp[i].PPFNGGCBJKC_Id;
					data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = NBKAMFFIOOG_Sp[i].BFINGCJHOHI_Cnt;
					data3[AFEHLCGHAEE_Strings.JBGEEPFKIGG_val] = NBKAMFFIOOG_Sp[i].JBGEEPFKIGG_Val;
					data3[AFEHLCGHAEE_Strings.ANAJIAENLNB_lv] = NBKAMFFIOOG_Sp[i].ANAJIAENLNB_Level;
					data3[AFEHLCGHAEE_Strings.MKHBDJBODON_c_tm] = NBKAMFFIOOG_Sp[i].FOONCJDLLIK_CTm;
					data3[AFEHLCGHAEE_Strings.POBGGHEKLIB_c_tm_ofs] = NBKAMFFIOOG_Sp[i].EMHCHMHMFHJ_CTmOfs;
					data3[AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new] = NBKAMFFIOOG_Sp[i].CADENLBDAEB_IsNew ? 1 : 0;
					data2["_" + (i + 1)] = data3;
				}
			}
			data[AFEHLCGHAEE_Strings.BLJOJBEKFAH_di_sp] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2["_"] = "";
			for (int i = 0; i < PFNNIMBMKDL_Posters.Count; i++)
			{
				if (PFNNIMBMKDL_Posters[i].BFINGCJHOHI_Cnt != 0 || PFNNIMBMKDL_Posters[i].CADENLBDAEB_IsNew)
				{
					EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
					data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = PFNNIMBMKDL_Posters[i].PPFNGGCBJKC_Id;
					data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = PFNNIMBMKDL_Posters[i].BFINGCJHOHI_Cnt;
					data3[AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new] = PFNNIMBMKDL_Posters[i].CADENLBDAEB_IsNew ? 1 : 0;
					data2["_" + (i + 1)] = data3;
				}
			}
			data[AFEHLCGHAEE_Strings.CIJOGNLMIKM_di_pst] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2["_"] = "";
			for (int i = 0; i < NOAEDPJGBJK_Sets.Count; i++)
			{
				if (NOAEDPJGBJK_Sets[i].BFINGCJHOHI_Cnt != 0 || NOAEDPJGBJK_Sets[i].CADENLBDAEB_IsNew)
				{
					EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
					data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = NOAEDPJGBJK_Sets[i].PPFNGGCBJKC_Id;
					data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = NOAEDPJGBJK_Sets[i].BFINGCJHOHI_Cnt;
					data3[AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new] = NOAEDPJGBJK_Sets[i].CADENLBDAEB_IsNew ? 1 : 0;
					data2["_" + (i + 1)] = data3;
				}
			}
			data["di_set"] = data2;
		}
		data[AFEHLCGHAEE_Strings.DLLLHFLGBAP_acum_at] = MKLJLHBHBJA_AcumAt;
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			data2[JIKKNHIAEKG_BlockName] = data;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 3;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0xF30E1C Offset: 0xF30E1C VA: 0xF30E1C Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 3);
		if (!blockMissing)
		{
			if (block == null)
			{
				isInvalid = true;
			}
			else
			{
				if(block.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.JMPEGAACBKA_di_bg))
				{
					EDOHBJAPLPF_JsonData b = block[AFEHLCGHAEE_Strings.JMPEGAACBKA_di_bg];
					for(int i = 0; i < 200; i++)
					{
						string str = POFDDFCGEGP + (i + 1).ToString();
						if (b.BBAJPINMOEP_Contains(str))
						{
							EDOHBJAPLPF_JsonData b2 = b[str];
							AKAHOEBACGJ data = DJHBDDGEKGO_Bgs[i];
							data.PPFNGGCBJKC_Id = i + 1;
							data.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
							if (data.BFINGCJHOHI_Cnt < 0)
								data.BFINGCJHOHI_Cnt = 1;
							data.CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new, 0, ref isInvalid) == 1;
						}
					}
				}
				else
					isInvalid = true;
				if (block.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BEJFAOEGBLE_di_obj))
				{
					List<NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem> items = null;
					int cnt = 5;
					if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
					{
						NDBFKHKMMCE_DecoItem decoDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem;
						items = decoDb.GHOLIPLDMPJ_ItemsObj;
						cnt = decoDb.LPJLEHAJADA("obj_have_max", 5);
					}
					EDOHBJAPLPF_JsonData b = block[AFEHLCGHAEE_Strings.BEJFAOEGBLE_di_obj];
					for (int i = 0; i < 6000; i++)
					{
						string str = POFDDFCGEGP + (i + 1).ToString();
						if (b.BBAJPINMOEP_Contains(str))
						{
							EDOHBJAPLPF_JsonData b2 = b[str];
							AKAHOEBACGJ data = KPMFLNOELIN_Objs[i];
							data.PPFNGGCBJKC_Id = i + 1;
							int c = cnt;
							if (i < items.Count)
								c = items[i].KEJMJPHFFOJ;
							data.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
							if (c < data.BFINGCJHOHI_Cnt)
								data.BFINGCJHOHI_Cnt = c;
							data.CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new, 0, ref isInvalid) == 1;
						}
					}
				}
				else
					isInvalid = true;
				if (block.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.GJMJHEPMLOA_di_chr))
				{
					EDOHBJAPLPF_JsonData b = block[AFEHLCGHAEE_Strings.GJMJHEPMLOA_di_chr];
					for (int i = 0; i < 100; i++)
					{
						string str = POFDDFCGEGP + (i + 1).ToString();
						if (b.BBAJPINMOEP_Contains(str))
						{
							EDOHBJAPLPF_JsonData b2 = b[str];
							AKAHOEBACGJ data = PEBDEIKBCCM_Chars[i];
							data.PPFNGGCBJKC_Id = i + 1;
							data.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
							if (data.BFINGCJHOHI_Cnt < 0)
								data.BFINGCJHOHI_Cnt = 1;
							data.CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new, 0, ref isInvalid) == 1;
						}
					}
				}
				else
					isInvalid = true;
				if (block.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BLJOJBEKFAH_di_sp))
				{
					EDOHBJAPLPF_JsonData b = block[AFEHLCGHAEE_Strings.BLJOJBEKFAH_di_sp];
					for (int i = 0; i < 100; i++)
					{
						string str = POFDDFCGEGP + (i + 1).ToString();
						if (b.BBAJPINMOEP_Contains(str))
						{
							EDOHBJAPLPF_JsonData b2 = b[str];
							GNGFGEIAGJL data = NBKAMFFIOOG_Sp[i];
							data.PPFNGGCBJKC_Id = i + 1;
							data.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
							if (data.BFINGCJHOHI_Cnt < 0)
								data.BFINGCJHOHI_Cnt = 1;
							data.JBGEEPFKIGG_Val = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.JBGEEPFKIGG_val, 0, ref isInvalid);
							data.ANAJIAENLNB_Level = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.ANAJIAENLNB_lv, 1, ref isInvalid);
							data.FOONCJDLLIK_CTm = DKMPHAPBDLH_ReadLong(b2, AFEHLCGHAEE_Strings.MKHBDJBODON_c_tm, 0, ref isInvalid);
							data.EMHCHMHMFHJ_CTmOfs = DKMPHAPBDLH_ReadLong(b2, AFEHLCGHAEE_Strings.POBGGHEKLIB_c_tm_ofs, 0, ref isInvalid);
							data.CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new, 0, ref isInvalid) == 1;
						}
					}
				}
				else
					isInvalid = true;
				if (block.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.CIJOGNLMIKM_di_pst))
				{ 
					List<NDBFKHKMMCE_DecoItem.IEOEMNPLANK_PosterItem> items = null;
					int cnt = 50;
					if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
					{
						NDBFKHKMMCE_DecoItem decoDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem;
						items = decoDb.COLIEKINOPB_ItemsPoster;
						cnt = decoDb.LPJLEHAJADA("poster_have_max", 50);
					}
					EDOHBJAPLPF_JsonData b = block[AFEHLCGHAEE_Strings.CIJOGNLMIKM_di_pst];
					for (int i = 0; i < 100; i++)
					{
						string str = POFDDFCGEGP + (i + 1).ToString();
						if (b.BBAJPINMOEP_Contains(str))
						{
							EDOHBJAPLPF_JsonData b2 = b[str];
							AKAHOEBACGJ data = PFNNIMBMKDL_Posters[i];
							data.PPFNGGCBJKC_Id = i + 1;
							int c = cnt;
							if (items.Count < i) // ??
								c = items[i].KEJMJPHFFOJ;
							data.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
							if (c < data.BFINGCJHOHI_Cnt)
								data.BFINGCJHOHI_Cnt = c;
							data.CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new, 0, ref isInvalid) == 1;
						}
					}
				}
				else
					isInvalid = true;
				if (block.BBAJPINMOEP_Contains("di_set"))
				{
					EDOHBJAPLPF_JsonData b = block["di_set"];
					for (int i = 0; i < 300; i++)
					{
						string str = POFDDFCGEGP + (i + 1).ToString();
						if (b.BBAJPINMOEP_Contains(str))
						{
							EDOHBJAPLPF_JsonData b2 = b[str];
							AKAHOEBACGJ data = NOAEDPJGBJK_Sets[i];
							data.PPFNGGCBJKC_Id = i + 1;
							data.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
							if (data.BFINGCJHOHI_Cnt < 0)
								data.BFINGCJHOHI_Cnt = 1;
							data.CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new, 0, ref isInvalid) == 1;
						}
					}
				}
				else
					isInvalid = true;
				MKLJLHBHBJA_AcumAt = DKMPHAPBDLH_ReadLong(block, AFEHLCGHAEE_Strings.DLLLHFLGBAP_acum_at, 0, ref isInvalid);
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0xF32498 Offset: 0xF32498 VA: 0xF32498 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		BCGFHLIEKLJ_DecoItem d = GPBJHKLFCEP as BCGFHLIEKLJ_DecoItem;
		for(int i = 0; i < DJHBDDGEKGO_Bgs.Count; i++)
		{
			DJHBDDGEKGO_Bgs[i].ODDIHGPONFL(d.DJHBDDGEKGO_Bgs[i]);
		}
		for (int i = 0; i < KPMFLNOELIN_Objs.Count; i++)
		{
			KPMFLNOELIN_Objs[i].ODDIHGPONFL(d.KPMFLNOELIN_Objs[i]);
		}
		for(int i = 0; i < PEBDEIKBCCM_Chars.Count; i++)
		{
			PEBDEIKBCCM_Chars[i].ODDIHGPONFL(d.PEBDEIKBCCM_Chars[i]);
		}
		for(int i = 0; i < NBKAMFFIOOG_Sp.Count; i++)
		{
			NBKAMFFIOOG_Sp[i].ODDIHGPONFL(d.NBKAMFFIOOG_Sp[i]);
		}
		for(int i = 0; i < PFNNIMBMKDL_Posters.Count; i++)
		{
			PFNNIMBMKDL_Posters[i].ODDIHGPONFL(d.PFNNIMBMKDL_Posters[i]);
		}
		for(int i = 0; i < NOAEDPJGBJK_Sets.Count; i++)
		{
			NOAEDPJGBJK_Sets[i].ODDIHGPONFL(d.NOAEDPJGBJK_Sets[i]);
		}
		MKLJLHBHBJA_AcumAt = d.MKLJLHBHBJA_AcumAt;
	}

	// // RVA: 0xF32C3C Offset: 0xF32C3C VA: 0xF32C3C Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		BCGFHLIEKLJ_DecoItem other = GPBJHKLFCEP as BCGFHLIEKLJ_DecoItem;
		for(int i = 0; i < DJHBDDGEKGO_Bgs.Count; i++)
		{
			if(!DJHBDDGEKGO_Bgs[i].AGBOGBEOFME(other.DJHBDDGEKGO_Bgs[i]))
				return false;
		}
		for(int i = 0; i < KPMFLNOELIN_Objs.Count; i++)
		{
			if(!KPMFLNOELIN_Objs[i].AGBOGBEOFME(other.KPMFLNOELIN_Objs[i]))
				return false;
		}
		for(int i = 0; i < PEBDEIKBCCM_Chars.Count; i++)
		{
			if(!PEBDEIKBCCM_Chars[i].AGBOGBEOFME(other.PEBDEIKBCCM_Chars[i]))
				return false;
		}
		for(int i = 0; i < NBKAMFFIOOG_Sp.Count; i++)
		{
			if(!NBKAMFFIOOG_Sp[i].AGBOGBEOFME(other.NBKAMFFIOOG_Sp[i]))
				return false;
		}
		for(int i = 0; i < PFNNIMBMKDL_Posters.Count; i++)
		{
			if(!PFNNIMBMKDL_Posters[i].AGBOGBEOFME(other.PFNNIMBMKDL_Posters[i]))
				return false;
		}
		for(int i = 0; i < NOAEDPJGBJK_Sets.Count; i++)
		{
			if(!NOAEDPJGBJK_Sets[i].AGBOGBEOFME(other.NOAEDPJGBJK_Sets[i]))
				return false;
		}
		if(MKLJLHBHBJA_AcumAt != other.MKLJLHBHBJA_AcumAt)
			return false;
		return true;
	}

	// // RVA: 0xF33518 Offset: 0xF33518 VA: 0xF33518 Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "AGHKODFKOJI");
	}

	// // RVA: 0xF34888 Offset: 0xF34888 VA: 0xF34888 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}

	// // RVA: 0xF35030 Offset: 0xF35030 VA: 0xF35030
	public int KFFGHBCCCIJ(NDBFKHKMMCE_DecoItem EPAHOAKPAJJ, int NDKJCDGHPLD, int LNBOIHIGAGL)
	{
		int res = 0;
		foreach(var k in NBKAMFFIOOG_Sp)
		{
			if(k.BFINGCJHOHI_Cnt > 0)
			{
				int a = EPAHOAKPAJJ.CHMNDNFMAGA(k.PPFNGGCBJKC_Id);
				if (LNBOIHIGAGL < a && NDKJCDGHPLD >= a && res < a)
					res = a;
			}
		}
		return res;
	}
}
