using System.Collections.Generic;
using System;

public class LPPGENBEECK {}
public class LPPGENBEECK_musicMaster : DIHHCBACKGG
{
	private List<HMJHLLPBCLD> OHLOHGGCCMD; // 0x30
	private List<JPCKBFBCJKD> MGBKDJLEICI; // 0x34
	private List<HDNKOFNBCEO> MGDLFOAKGGF; // 0x38
	public List<NONFIGBOJLN> NEIBEDCGDEM; // 0x3C
	public List<AIPEHINPIHC> HBJDIFMCGAL; // 0x40
	public List<AOJCMPIBFHD> DBBLKLCCHFC; // 0x44

	public List<EONOEHOKBEB_Music> EPMMNEFADAP_Musics { get; private set; }// 0x20 // EONBIDEIFIA   HPBDACIJFEM DCLKBPALLLD
	public List<KEODKEGFDLD> GEAANLPDJBP { get; private set; } // 0x24 BJHOBLKDBKK ONBBLMFKDMA IIGCCMELFCO
	public List<DJNPIGEFPMF> CLHIABAKKJM { get; private set; } // 0x28 LECLIAKPOBM  PNNMFKPPDBI CHBJKIFMECH
	public List<KLBKPANJCPL_Score> CMPPNEFNGMK_Scores { get; private set; } // 0x2C // OLPOIIEPELN MPLAPBEGBOA PFDIMNJEMFF

	// // RVA: 0x10CF794 Offset: 0x10CF794 VA: 0x10CF794
	public EONOEHOKBEB_Music IAJLOELFHKC(int DLAEJOBELBH)
	{
		UnityEngine.Debug.LogError("TODO");
		return null;
	}

	// // RVA: 0x10CF824 Offset: 0x10CF824 VA: 0x10CF824
	// public KEODKEGFDLD NOBCLJIAMLC(int GHBPLHBNMBK) { }

	// // RVA: 0x10CF8B4 Offset: 0x10CF8B4 VA: 0x10CF8B4
	// public DJNPIGEFPMF FLMLJIKBIMJ(int KLCIIHKFPPO) { }

	// // RVA: 0x10CF944 Offset: 0x10CF944 VA: 0x10CF944
	// public HMJHLLPBCLD KCBOGEBCMMJ(int LJNAKDMILMC) { }

	// // RVA: 0x10CFA30 Offset: 0x10CFA30 VA: 0x10CFA30
	// public JPCKBFBCJKD LLJOPJMIGPD(int GHBPLHBNMBK) { }

	// // RVA: 0x10CFB28 Offset: 0x10CFB28 VA: 0x10CFB28
	// public bool IAAMKEJKPPL(JPCKBFBCJKD KBOLNIBLIND, int ADFIHAPELAN) { }

	// // RVA: 0x10CFB94 Offset: 0x10CFB94 VA: 0x10CFB94
	// public HDNKOFNBCEO NEJKJJPIGKD(KEODKEGFDLD AOKGAGHGAEC, int AKNELONELJK, bool GIKLNODJKFK) { }

	// // RVA: 0x10CFC50 Offset: 0x10CFC50 VA: 0x10CFC50
	// public KLBKPANJCPL ALJFMLEJEHH(int KKPAHLMJKIH, int BKJGCEOEPFB, int NOAKHKMLPFK, bool GIKLNODJKFK = False, bool IOOOMNMAGAH = True) { }

	// // RVA: 0x10CFE98 Offset: 0x10CFE98 VA: 0x10CFE98
	// public int CHBLIEKBOLL(int KKPAHLMJKIH, int BKJGCEOEPFB, int NOAKHKMLPFK, bool GIKLNODJKFK = False) { }

	// // RVA: 0x10CFED0 Offset: 0x10CFED0 VA: 0x10CFED0
	// public bool BHJKMPBACAC(int GHBPLHBNMBK) { }

	// // RVA: 0x10CFFA0 Offset: 0x10CFFA0 VA: 0x10CFFA0
	// public EONOEHOKBEB INJDLHAEPEK(int GHBPLHBNMBK, int DLAEJOBELBH) { }

	// // RVA: 0x10CFFC0 Offset: 0x10CFFC0 VA: 0x10CFFC0
	// public int CIKALPJDGMF(int GHBPLHBNMBK, int DLAEJOBELBH) { }

	// // RVA: 0x10D00E8 Offset: 0x10D00E8 VA: 0x10D00E8
	// public AOJCMPIBFHD OOKAOFJBCFD(int DLAEJOBELBH, int OFGIOBGAJPA) { }

	// // RVA: 0x10D0270 Offset: 0x10D0270 VA: 0x10D0270
	// public int DCMGLKDJAKL(int JHNCAFBGOKA, int HKOHGJAIJMA, List<int> JFCDMNPDIGP) { }

	// // RVA: 0x10D050C Offset: 0x10D050C VA: 0x10D050C
	public LPPGENBEECK_musicMaster()
	{
		JIKKNHIAEKG = "";
		LNIMEIMBCMF = false;
		EPMMNEFADAP_Musics = new List<EONOEHOKBEB_Music>(300);
		GEAANLPDJBP = new List<KEODKEGFDLD>(2000);
		CLHIABAKKJM = new List<DJNPIGEFPMF>(200);
		CMPPNEFNGMK_Scores = new List<KLBKPANJCPL_Score>(1000);
		OHLOHGGCCMD = new List<HMJHLLPBCLD>(2400);
		MGBKDJLEICI = new List<JPCKBFBCJKD>(2000);
		MGDLFOAKGGF = new List<HDNKOFNBCEO>();
		NEIBEDCGDEM = new List<NONFIGBOJLN>();
		HBJDIFMCGAL = new List<AIPEHINPIHC>();
		DBBLKLCCHFC = new List<AOJCMPIBFHD>();
		LMHMIIKCGPE = 62;
	}

	// // RVA: 0x10D07EC Offset: 0x10D07EC VA: 0x10D07EC Slot: 8
	protected override void KMBPACJNEOF()
	{
		EPMMNEFADAP_Musics.Clear();
		GEAANLPDJBP.Clear();
		CLHIABAKKJM.Clear();
		CMPPNEFNGMK_Scores.Clear();
		OHLOHGGCCMD.Clear();
		MGBKDJLEICI.Clear();
		MGDLFOAKGGF.Clear();
		NEIBEDCGDEM.Clear();
		HBJDIFMCGAL.Clear();
		DBBLKLCCHFC.Clear();
		for(int i = 1; i < 301; i++)
		{
			EONOEHOKBEB_Music data = new EONOEHOKBEB_Music();
			data.DLAEJOBELBH = (short)i;
			EPMMNEFADAP_Musics.Add(data);
		}
		for(int i = 1; i < 2001; i++)
		{
			KEODKEGFDLD data = new KEODKEGFDLD();
			data.GHBPLHBNMBK = (short)i;
			GEAANLPDJBP.Add(data);
		}
	}

	// // RVA: 0x10D0B00 Offset: 0x10D0B00 VA: 0x10D0B00 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		BMHPFEELLNP reader = BMHPFEELLNP.HEGEKFMJNCC(DBBGALAPFGC);
		JJOLLBDMIJP_LoadScore(reader);
		NOGICBBHLNK_LoadFreeReward(reader);
		KANEJCIALLM_LoadStoryTh(reader);
		if(AOPNONMKCLC_LoadMusic(reader) && ANKANPOHJNM(reader))
		{
			AHNNMALAMFF(reader);
			CNCEJAKLNBL(reader);
			FKLPBNIFBNF(reader);
			DNCNGDFMMPI(reader);
			ALLLNNDHGLA(reader);
			return true;
		}
		return false;
	}

	// // RVA: 0x10D52EC Offset: 0x10D52EC VA: 0x10D52EC Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		UnityEngine.Debug.LogError("TODO");
		return false;
	}

	// // RVA: 0x10D0BB4 Offset: 0x10D0BB4 VA: 0x10D0BB4
	private bool JJOLLBDMIJP_LoadScore(BMHPFEELLNP FCLGPOPLDFL)
	{
		/*FMAFIIPNNEO[] array = FCLGPOPLDFL.DGEPOLGDKHA;
		for(int i = 0; i < array.Length; i++)
		{
			KLBKPANJCPL_Score data = new KLBKPANJCPL_Score();
			data.GKNBCINLIJJ_Scid = (int)array[i].GKHGCPODNEG;
			data.ANAJIAENLNB_F_pt = (int)array[i].ANAJIAENLNB;
			data.NLKEBAOBJCM_Cb = (int)array[i].OLKHBHLOKJI;
			data.KNIFCANOHOC_Ss = (int)array[i].EJOECKJNGPD;
			data.CKDPPJAHAIP_Dn = (int)array[i].HDBEJBBPPBK;
			data.NPKMKMBEOAG_Dnc = (int)array[i].HOPIMOECAFA;
			data.NPGCIDONKOP_Sp = (int)array[i].PIPCIMIALOO;
			data.MCMIPODICAN = (int)array[i].MOIECBABHNP;
			data.KIEHDJFCCNM = (int)array[i].AMGHCNHIFFG;
			data.GEIDIHCKDNO = (int)array[i].KKBPKNBLJCK;
			data.JJBOEMOJPEC = (int)array[i].GDHLEEJPNIJ;
			data.OABPNBLPHHP = (int)array[i].AOLENLGEJED;
			data.GIABDDFGHOK = (int)array[i].EPEBHGHKMBE;
			CMPPNEFNGMK_Scores.Add(data);
		}*/
		UnityEngine.Debug.LogError("TODO Database Load");
		return true;
	}

	// // RVA: 0x10D5584 Offset: 0x10D5584 VA: 0x10D5584
	// private bool JJOLLBDMIJP(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D1584 Offset: 0x10D1584 VA: 0x10D1584
	private bool AOPNONMKCLC_LoadMusic(BMHPFEELLNP FCLGPOPLDFL)
	{
		/*JPALGGIPGGN[] array = FCLGPOPLDFL.MDFFJJKBDFC;
		for(int i = 0; i < array.Length; i++)
		{
			EONOEHOKBEB_Music data = new EONOEHOKBEB_Music();
			
			EPMMNEFADAP_Musics.Add(data);
		}*/
		UnityEngine.Debug.LogError("TODO Database Load");
		return true;
	}

	// // RVA: 0x10D6180 Offset: 0x10D6180 VA: 0x10D6180
	// private bool AOPNONMKCLC(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D104C Offset: 0x10D104C VA: 0x10D104C
	private bool NOGICBBHLNK_LoadFreeReward(BMHPFEELLNP FCLGPOPLDFL)
	{
		UnityEngine.Debug.LogError("TODO Database Load");
		return true;
	}

	// // RVA: 0x10D5ACC Offset: 0x10D5ACC VA: 0x10D5ACC
	// private bool NOGICBBHLNK(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D12E8 Offset: 0x10D12E8 VA: 0x10D12E8
	private bool KANEJCIALLM_LoadStoryTh(BMHPFEELLNP FCLGPOPLDFL)
	{
		UnityEngine.Debug.LogError("TODO Database Load");
		return true;
	}

	// // RVA: 0x10D5E30 Offset: 0x10D5E30 VA: 0x10D5E30
	// private bool KANEJCIALLM(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D730C Offset: 0x10D730C VA: 0x10D730C
	// private ADDHLABEFKH FEEODHDKLFH(int EJOECKJNGPD, int OLKHBHLOKJI, int OIPCCBHIKIA, HDNKOFNBCEO IBOGLMCNFBK) { }

	// // RVA: 0x10D7728 Offset: 0x10D7728 VA: 0x10D7728
	// private ADDHLABEFKH FEEODHDKLFH(int EJOECKJNGPD, int OLKHBHLOKJI, int OIPCCBHIKIA, NONFIGBOJLN IBOGLMCNFBK) { }

	// // RVA: 0x10D1FCC Offset: 0x10D1FCC VA: 0x10D1FCC
	private bool ANKANPOHJNM(BMHPFEELLNP FCLGPOPLDFL)
	{
		UnityEngine.Debug.LogError("TODO Database Load");
		return true;
	}

	// // RVA: 0x10D6D94 Offset: 0x10D6D94 VA: 0x10D6D94
	// private bool ANKANPOHJNM(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D3D78 Offset: 0x10D3D78 VA: 0x10D3D78
	private bool AHNNMALAMFF(BMHPFEELLNP FCLGPOPLDFL)
	{
		UnityEngine.Debug.LogError("TODO Database Load");
		return true;
	}

	// // RVA: 0x10D6D9C Offset: 0x10D6D9C VA: 0x10D6D9C
	// private bool AHNNMALAMFF(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D46D8 Offset: 0x10D46D8 VA: 0x10D46D8
	private bool CNCEJAKLNBL(BMHPFEELLNP FCLGPOPLDFL)
	{
		UnityEngine.Debug.LogError("TODO Database Load");
		return true;
	}

	// // RVA: 0x10D6DA4 Offset: 0x10D6DA4 VA: 0x10D6DA4
	// private bool CNCEJAKLNBL(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D4950 Offset: 0x10D4950 VA: 0x10D4950
	private bool FKLPBNIFBNF(BMHPFEELLNP FCLGPOPLDFL)
	{
		UnityEngine.Debug.LogError("TODO Database Load");
		return true;
	}

	// // RVA: 0x10D70B0 Offset: 0x10D70B0 VA: 0x10D70B0
	// private bool FKLPBNIFBNF(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D4B28 Offset: 0x10D4B28 VA: 0x10D4B28
	private bool DNCNGDFMMPI(BMHPFEELLNP FCLGPOPLDFL)
	{
		UnityEngine.Debug.LogError("TODO Database Load");
		return true;
	}

	// // RVA: 0x10D4FA0 Offset: 0x10D4FA0 VA: 0x10D4FA0
	private bool ALLLNNDHGLA(BMHPFEELLNP FCLGPOPLDFL)
	{
		UnityEngine.Debug.LogError("TODO Database Load");
		return true;
	}

	// // RVA: 0x10D7BD4 Offset: 0x10D7BD4 VA: 0x10D7BD4 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		UnityEngine.Debug.LogError("TODO CAOGDCBPBAN");
		return 0;
	}
}


public class KLBKPANJCPL{}
public class KLBKPANJCPL_Score
{
	public int OIPCCBHIKIA; // 0x8

	public int GKNBCINLIJJ_Scid { get; set; } // 0xC  // PIEBLLLAAEF ECBOBCJLLOD LFMJPMIHHBF
	public int ANAJIAENLNB_F_pt { get; set; } // 0x10 // IKMILCFHBGA MMOMNMBKHJF FEHNFGPFINK
	public int NLKEBAOBJCM_Cb { get; set; }   // 0x14 // ABLBDMPGEHA AECNKGBNKHH ECHLKFHOJFP
	public int KNIFCANOHOC_Ss { get; set; }   // 0x18 // DKDLLFCBBCE EOJEPLIPOMJ AEEMBPAEAAI
	public int CKDPPJAHAIP_Dn { get; set; }   // 0x1C // MBBGDHGPJDM DBMNFCDGGEC JEFJBPPGBOK
	public int NPKMKMBEOAG_Dnc { get; set; }  // 0x20 // AKAEHHAHFDM GHJDKBCAGLL IIEJNMBABCK
	public int NPGCIDONKOP_Sp { get; set; }   // 0x24 // AHONHAIELEA GKHINHNGCKE LLPNJHACHEB
	public int MCMIPODICAN { get; set; }      // 0x28 // IFGANBEKEAE DAGDLFMEAKG FNGANMMAACC
	public int KIEHDJFCCNM { get; set; }      // 0x2C // EGKCBOHGFBA LNPKNMONEFI CEPCIKJKLLF
	public int GEIDIHCKDNO { get; set; }      // 0x30 // DDIGBBJDNLF JAOFBBKGCHP IBIPFCNGHFF
	public int JJBOEMOJPEC { get; set; }      // 0x34 // BAGPHOPPPPC FGMMNEIIHKM MFKGPCOLFLA
	public int OABPNBLPHHP { get; set; }      // 0x38 // GJJGLNLOGHN BMCLOFLOPLO IABNMIBLHAA
	public int GIABDDFGHOK { get; set; }      // 0x3C // COGAGDDAEFD EHAGPCANMCN FMJMCAEJMPG

	// RVA: 0x1A0B9C0 Offset: 0x1A0B9C0 VA: 0x1A0B9C0
	//public uint CAOGDCBPBAN() { }
}

public class EONOEHOKBEB{}
public class EONOEHOKBEB_Music
{
	public short DLAEJOBELBH { get; set; } // CKJALIDGGOH // 0x8 MPGNHBOBFBD EPEMOAEGPLI
	public short JNCPEGJGHOG { get; set; } // LABOODIMOII // 0xA HHEADMHBBPB GOFFKDDNACG
	public short NNHOBFBCIIJ { get; set; } // GKMKHKHFBEI // 0xC AOBMNDMGGIO NIMNBBDNJMC
	public short KNMGEEFGDNI { get; set; } // JELJHGCOAFJ // 0xE HKEFEIOCKLP OCOGGADKEHD
	public short NODKIFGGMGP { get; set; } // PNBJIFJHCBL // 0x10 APAOBAGKCPC LKDECIOADPO
	public sbyte FKDCCLPGKDK { get; set; } // KLMKEFEMHOC // 0x12 FBADKBMGIBP NCNMMABFHGN
	public sbyte AIHCEGFANAM { get; set; } // FJOGAAMLJMA // 0x13 ANEJPLENMAL HEHDOGFEIOL
	public sbyte EMIKBGHIOMN { get; set; } // CCEIEDMCHLA // 0x14 BJGJCKFOBCA OAKIKBEEACC
	public short KKPAHLMJKIH { get; set; } // EOPNGHAFEMB // 0x16 ENODDPDBIPA HOAKFLEAEOH
	public short BKJGCEOEPFB { get; set; } // PJKCKOJHKEM // 0x18 FNEBPBJBIIP OIDGLNHNGJB
	public short GHICLBNHNGJ { get; set; } // IHIHAAJLBHK // 0x1A OLKANNICFLL MHEEIDDKIJH
	public short AABILPMIOFN { get; set; } // HJBLBCKELMF // 0x1C GACMKBLPOIB LKFFBLEIPIP
	public short DMKCGNMOCCH { get; set; } // LKKNIADKGAE // 0x1E PEBOPIIJCOM NOGOFLKEEMP
	public short EECJONKNHNK { get; set; } // GEOMFEFKOLF // 0x20 KJKNOCBOHFC DONMAGEIEJF
	public short MNEFKDDCEHE { get; set; } // EDBCILCIAEL // 0x22 MCDMIOFGCDF KIECJGPAHGO
	public short NJAOOMHCIHL { get; set; } // GHHLJOCPEAE // 0x24 OJBDKKDLFDD CMMJPNDAJDG
	public short PECMGDOMLAF { get; set; } // ADLPNCIONGK // 0x26 MDIFJJACKBC JKMNGNMPONF
	public short ACPKFNNONMH { get; set; } // LEDNEEKHDPM // 0x28 IOOMEBAFGFK DPMAFCKJJPM

	// RVA: 0xFBDFFC Offset: 0xFBDFFC VA: 0xFBDFFC
	//public uint CAOGDCBPBAN() { }
}


public class KEODKEGFDLD
{
	// public short[] OCOGIADDNDN = new short[5]; // 0x34
	// public short[] LHICAKGHIGF = new short[5]; // 0x38
	// public int[] HLKHOFPAOMK = new int[5]; // 0x3C
	// public int[] HLLJIICKNIP = new int[5]; // 0x40
	// public int[] FENOHOEIJOE = new int[5]; // 0x44
	// public int[] LJPKLMJPLAC = new int[5]; // 0x48
	// public int[] MALHPBKPIDE = new int[5]; // 0x4C
	// public short[] DPJDHKIIJIJ = new short[5]; // 0x50
	// public short[] PJNFOCDANCE = new short[5]; // 0x54
	// public int[] MAGILDGLOKD = new int[5]; // 0x58
	// public int[] JEANDFEBLIG = new int[5]; // 0x5C
	// public int[] KFIDHFOGDPJ = new int[5]; // 0x60
	// public int[] ILCJOOPIILK = new int[5]; // 0x64
	// public int[] BGILEHEJHHA = new int[5]; // 0x68
	// private List<ADDHLABEFKH> COGKJBAFBKN = new List<ADDHLABEFKH>(); // 0x6C
	// private List<ADDHLABEFKH> IPFHDCEFLDE = new List<ADDHLABEFKH>(); // 0x70

	public short GHBPLHBNMBK { get; set; } // 0x8 JHHAKBMGFEN HKFCFPFPMBN IFMPBFAAKNN
	// public short DLAEJOBELBH { get; set; } // 0xA CKJALIDGGOH MPGNHBOBFBD EPEMOAEGPLI
	// public sbyte DEPGBBJMFED { get; set; } // 0xC OGKJCKOPEPM FNMFOBJIIIC OBEDPJLBBEG
	// public sbyte PPEGAKEIEGM { get; set; } // 0xD NEKLJCCBECB KPOEEPIMMJP NCIEAFEDPBH
	// public sbyte ELOGNMFPAHJ { get; set; } // 0xE NGMLLJPEBPB PIICIAMECHP MHEBLIAMCAC
	// public int IJEKNCDIIAE { get; set; } // 0x10 FAHNCMHNFCG KJIMMIBDCIL DMEGNOKIKCD
	// public int EKANGPODCEP { get; set; } // 0x14 MBOEJOMMKCK EBLAFEMDFGD AHEFELNFBDM
	// public short KEFGPJBKAOD { get; set; } // 0x18 CFNDJLELGFP MKJJKNIMMBC NACMHHKKBCJ
	// public short EEFLOOBOAGF { get; set; } // 0x1A BKNCCIILLPJ NLDELFLNODF PEHLMNDKOEE
	// private short KCNHKNKNGNH { get; set; } // 0x1C APIBHBGLOCI BPPHFJDPDJO FGPEKMCHDKK
	// private short CNEMDPMKCPA { get; set; } // 0x1E ACECKLDHLHN OBCBGGMIHIG AELNGOGMECL
	// public short MGLDIOILOFF { get; set; } // 0x20 HGCANNFGBJK JCCNFABDFGA LPONDIIPEDN
	// private short LGNMFFMDIJP { get; set; } // 0x22 PINOBFJAMKP GOELDFINKPG DOPEOGFPFPN
	// private short AOKEOELIAMH { get; set; } // 0x24 IEFOAKGGOGB DJMKMADIFCN DBCDHPEOKKD
	// public short JCDKMICANJO { get; set; } // 0x26 NONHMBMDBKM ODFMHJFFILL DCDFFHHMHEL
	// private short EFNKJFCJGBB { get; set; } // 0x28 HHBCGAKHPMG EMEFKAIBMFJ LDCPINNLDDN
	// private short PNILIOGELFK { get; set; } // 0x2A ODCMCKBNJEL FJHBDENFDAJ DELONBFLKPM
	// public short CCLIOBOGFHC { get; set; } // 0x2C DDDFCKCLGPD JMGOABJPFJO LJMBPNDJCOO
	// public short EAEDODGPLEC { get; set; } // 0x2E MJPMALLKMJJ EOGPNADNBFO OGLPGIKKFLK
	// public short LOKLNBLBBFD { get; set; } // 0x30 CLFFNMKCEOE IHPAHIEIHMH LNCFBKJDBEK
	// public int BLDDNEJDFON { get; set; } // 0x74 PHGFINLGEPL JLDOLKKPJMP ADMEDIKMAPD
	// public bool BHJNFBDNFEJ { get; set; } // 0x78 NADBEMIAIJA JCELPEBCMAG GCCCGMBALMC
	// public bool GBNOALJPOBM { get; set; } // 0x79 KNDGBCJKPMC PALLMADFFMA BEDKPPHDHAA

	// // RVA: 0x19F2E68 Offset: 0x19F2E68 VA: 0x19F2E68
	// public void LOHABKAHNKD(short IGCLOFPOABH, short ACMOFHKGJLG) { }

	// // RVA: 0x19F2E74 Offset: 0x19F2E74 VA: 0x19F2E74
	// public void FEOLNFKIIJJ(short IGCLOFPOABH, short ACMOFHKGJLG) { }

	// // RVA: 0x19F2E80 Offset: 0x19F2E80 VA: 0x19F2E80
	// public void FNFKCHMPLAD(short IGCLOFPOABH, short ACMOFHKGJLG) { }

	// // RVA: 0x19F2E8C Offset: 0x19F2E8C VA: 0x19F2E8C
	// public short KDIKCKEEPDA(bool GIKLNODJKFK) { }

	// // RVA: 0x19F2EA0 Offset: 0x19F2EA0 VA: 0x19F2EA0
	// public short ONLFLGPMAAN(bool GIKLNODJKFK) { }

	// // RVA: 0x19F2EB4 Offset: 0x19F2EB4 VA: 0x19F2EB4
	// public short NCCFJCDMBFO(bool GIKLNODJKFK) { }

	// // RVA: 0x19F2EC8 Offset: 0x19F2EC8 VA: 0x19F2EC8
	// public uint CAOGDCBPBAN() { }

	// // RVA: 0x19F31FC Offset: 0x19F31FC VA: 0x19F31FC
	// public void NHKABAGJCDM(ADDHLABEFKH ANAJIAENLNB) { }

	// // RVA: 0x19F327C Offset: 0x19F327C VA: 0x19F327C
	// public void IFABJEBEKPB(ADDHLABEFKH ANAJIAENLNB) { }

	// // RVA: 0x19F32FC Offset: 0x19F32FC VA: 0x19F32FC
	// public ADDHLABEFKH EMJCHPDJHEI(bool GIKLNODJKFK, int AKNELONELJK) { }

}

public class DJNPIGEFPMF
{
	// public short[] OCOGIADDNDN = new short[3]; // 0x24
	// public short[] LHICAKGHIGF = new short[3]; // 0x28
	// public int[] HLKHOFPAOMK = new int[3]; // 0x2C
	// public int[] HLLJIICKNIP = new int[3]; // 0x30
	// public int[] FENOHOEIJOE = new int[3]; // 0x34
	// public int[] LJPKLMJPLAC = new int[3]; // 0x38
	// public int[] MALHPBKPIDE = new int[3]; // 0x3C
	// public List<ADDHLABEFKH> COGKJBAFBKN = new List<ADDHLABEFKH>(); // 0x40
	// public byte PPEGAKEIEGM; // 0x44

	// public short KLCIIHKFPPO { get; set; }  // 0x8 GBNPEKLEHPH CPDGCNILCII IILKMGEKOBG
	// public int DLAEJOBELBH { get; set; }  // 0xC CKJALIDGGOH MPGNHBOBFBD EPEMOAEGPLI
	// public int DEPGBBJMFED { get; set; } // 0x10 OGKJCKOPEPM FNMFOBJIIIC OBEDPJLBBEG
	// public int MHPAFEEPBNJ { get; set; } // 0x14 OHACHFCDBOF NODKIDEKNGJ CHFBEINBPKA
	// public int KEFGPJBKAOD { get; set; } // 0x18 CFNDJLELGFP MKJJKNIMMBC NACMHHKKBCJ
	// public int KCNHKNKNGNH { get; set; } // 0x1C APIBHBGLOCI BPPHFJDPDJO FGPEKMCHDKK
	// public int MGLDIOILOFF { get; set; } // 0x20 HGCANNFGBJK JCCNFABDFGA LPONDIIPEDN

	// // RVA: 0x198D598 Offset: 0x198D598 VA: 0x198D598
	// public uint CAOGDCBPBAN() { }
}


public class HMJHLLPBCLD : IComparable<HMJHLLPBCLD>
{
	// public int LJNAKDMILMC { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM OACJGKPBHIK
	// public int ANAJIAENLNB { get; } 0x15F6920 MMOMNMBKHJF
	// public int AHHJLDLAPAN { get; } 0x15F6944 IPKDLMIDMHH
	// public int DLAEJOBELBH { get; } 0x15F6974 MPGNHBOBFBD
	// public short LHBDCGFOKCA { get; set; } // 0xC HHBMOFEAFKC OLHHGEIKLDM DOOHFPHPMPF
	// public short CEFHDLLAPDH { get; set; } // 0xE BDIBNPFLIED BKFIIGCINNL BNJMJMNLMEA
	// public short CIIIELDHDEP { get; set; } 0x15F69B0 NAMNBEJFNFN 0x15F69D0 BGOEGAOOHIE
	// public short LDCJDIAOKGD { get; set; } 0x15F69E0 DBJGHGEJOAH 0x15F69E8 HEDOJDJALID
	// public short KDGIHMCBLND { get; set; } // 0x10 CDLBEODBHLK GLDGPMFEKGM BJIBDJAOFJJ

	// // RVA: 0x15F68F8 Offset: 0x15F68F8 VA: 0x15F68F8
	// public static int ABDFBABHIHJ(int DLAEJOBELBH, int AHHJLDLAPAN, int BAKLKJLPLOJ) { }

	// // RVA: 0x15F69F0 Offset: 0x15F69F0 VA: 0x15F69F0
	public HMJHLLPBCLD(int LJNAKDMILMC)
	{
		this.LJNAKDMILMC = LJNAKDMILMC;
	}

	// // RVA: 0x15F6A10 Offset: 0x15F6A10 VA: 0x15F6A10 Slot: 4
	public int CompareTo(HMJHLLPBCLD EAIPIMCBNJN)
	{
		UnityEngine.Debug.LogError("TODO");
		return 0;
	}

	// // RVA: 0x15F6A54 Offset: 0x15F6A54 VA: 0x15F6A54
	// public uint CAOGDCBPBAN() { }
}

public class JPCKBFBCJKD
{
	// public int GHBPLHBNMBK { get; set; } // 0x8 JHHAKBMGFEN HKFCFPFPMBN IFMPBFAAKNN
	// public int ADBHJCDINFL { get; set; }  // 0xC PLIPNHDDIFP NKIPIGNMFGK NNPOJPDCEHE

	// // RVA: 0x1BA5440 Offset: 0x1BA5440 VA: 0x1BA5440
	// public uint CAOGDCBPBAN() { }
}

public class NONFIGBOJLN
{
	public int PDGEMDFHFIB; // 0x8
	public List<int> MNKDEFJFKGN; // 0xC
}

public class AJIKMKFGNCJ
{
	// public short JOMGCCBFKEF { get; set; } // 0x8 JIHJGFNPPIL GGFGMDFOFLG JCJBHJOOIDP
	// public byte INDDJNMPONH { get; set; } // 0xA JDIGGEBNOPK GHAILOLPHPF BACGOKIGMBC
	// public byte AHHJLDLAPAN { get; set; } // 0xB AMALMGIALDF IPKDLMIDMHH IENNENMKEFO
	// public int JBGEEPFKIGG { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON ABAFHIBFKCE
}

public class AIPEHINPIHC
{
	public int NMNDNFFJHPJ; // 0x8
	public int GPPEFLKGGGJ; // 0xC
	public int[] AHHJLDLAPAN = new int[3]; // 0x10
	public int[] JPIDIENBGKH = new int[3]; // 0x14
	public int IOPCBBNHJIP; // 0x18
	public int OOFEIPCLEKJ; // 0x1C
	public int EDDLJBLJJOE; // 0x20
	public int JIIOKINLOGM; // 0x24
	public int MDKNFOIMCJB; // 0x28
	public int OENPCNBFPDA; // 0x2C
	public int EGMIILFFHMI; // 0x30
	public int HFMFGFHPBNB; // 0x34
	public int ENAAKPKFBGN; // 0x38
	public int IHLDBMMOCHF; // 0x3C
}

public class AOJCMPIBFHD
{
	public int IJEKNCDIIAE; // 0x8
	public int PLALNIIBLOF; // 0xC
	public int DLAEJOBELBH; // 0x10
	public int[] AHHJLDLAPAN = new int[5]; // 0x14
	public int OFGIOBGAJPA; // 0x18
	public int OEJOOMPKAOO; // 0x1C
}

public class HDNKOFNBCEO
{
	public const int JIEBOLHLFOC = 0;
	public const int GJPKDHHKPPE = 4;
	public const int AKADJOKMIEN = 8;
	public const int HGFDJJPJNNG = 12;
	public int EIHOBHDKCDB; // 0x8
	public List<int> LLEILBEMEEJ; // 0xC

	// // RVA: 0x1742A5C Offset: 0x1742A5C VA: 0x1742A5C
	// public int FKNBLDPIPMC(int OIPCCBHIKIA) { }

	// // RVA: 0x1742ADC Offset: 0x1742ADC VA: 0x1742ADC
	// public int KAINPNMMAEK(int OIPCCBHIKIA) { }

	// // RVA: 0x1742B60 Offset: 0x1742B60 VA: 0x1742B60
	// public int GPBKAAMLIBF(int OIPCCBHIKIA) { }

	// // RVA: 0x1742BE4 Offset: 0x1742BE4 VA: 0x1742BE4
	// public int MEBHFJPMCIF(int HMFFHLPNMPH) { }

	// // RVA: 0x1742C2C Offset: 0x1742C2C VA: 0x1742C2C
	// public uint CAOGDCBPBAN() { }
}