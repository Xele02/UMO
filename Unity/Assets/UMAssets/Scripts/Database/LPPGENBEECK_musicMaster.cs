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


public class KEODKEGFDLD //!!!
{
	// [CompilerGeneratedAttribute] // RVA: 0x6681E4 Offset: 0x6681E4 VA: 0x6681E4
	// private short <JHHAKBMGFEN>k__BackingField; // 0x8
	// [CompilerGeneratedAttribute] // RVA: 0x6681F4 Offset: 0x6681F4 VA: 0x6681F4
	// private short <CKJALIDGGOH>k__BackingField; // 0xA
	// [CompilerGeneratedAttribute] // RVA: 0x668204 Offset: 0x668204 VA: 0x668204
	// private sbyte <OGKJCKOPEPM>k__BackingField; // 0xC
	// [CompilerGeneratedAttribute] // RVA: 0x668214 Offset: 0x668214 VA: 0x668214
	// private sbyte <NEKLJCCBECB>k__BackingField; // 0xD
	// [CompilerGeneratedAttribute] // RVA: 0x668224 Offset: 0x668224 VA: 0x668224
	// private sbyte <NGMLLJPEBPB>k__BackingField; // 0xE
	// [CompilerGeneratedAttribute] // RVA: 0x668234 Offset: 0x668234 VA: 0x668234
	// private int <FAHNCMHNFCG>k__BackingField; // 0x10
	// [CompilerGeneratedAttribute] // RVA: 0x668244 Offset: 0x668244 VA: 0x668244
	// private int <MBOEJOMMKCK>k__BackingField; // 0x14
	// [CompilerGeneratedAttribute] // RVA: 0x668254 Offset: 0x668254 VA: 0x668254
	// private short <CFNDJLELGFP>k__BackingField; // 0x18
	// [CompilerGeneratedAttribute] // RVA: 0x668264 Offset: 0x668264 VA: 0x668264
	// private short <BKNCCIILLPJ>k__BackingField; // 0x1A
	// [CompilerGeneratedAttribute] // RVA: 0x668274 Offset: 0x668274 VA: 0x668274
	// private short <APIBHBGLOCI>k__BackingField; // 0x1C
	// [CompilerGeneratedAttribute] // RVA: 0x668284 Offset: 0x668284 VA: 0x668284
	// private short <ACECKLDHLHN>k__BackingField; // 0x1E
	// [CompilerGeneratedAttribute] // RVA: 0x668294 Offset: 0x668294 VA: 0x668294
	// private short <HGCANNFGBJK>k__BackingField; // 0x20
	// [CompilerGeneratedAttribute] // RVA: 0x6682A4 Offset: 0x6682A4 VA: 0x6682A4
	// private short <PINOBFJAMKP>k__BackingField; // 0x22
	// [CompilerGeneratedAttribute] // RVA: 0x6682B4 Offset: 0x6682B4 VA: 0x6682B4
	// private short <IEFOAKGGOGB>k__BackingField; // 0x24
	// [CompilerGeneratedAttribute] // RVA: 0x6682C4 Offset: 0x6682C4 VA: 0x6682C4
	// private short <NONHMBMDBKM>k__BackingField; // 0x26
	// [CompilerGeneratedAttribute] // RVA: 0x6682D4 Offset: 0x6682D4 VA: 0x6682D4
	// private short <HHBCGAKHPMG>k__BackingField; // 0x28
	// [CompilerGeneratedAttribute] // RVA: 0x6682E4 Offset: 0x6682E4 VA: 0x6682E4
	// private short <ODCMCKBNJEL>k__BackingField; // 0x2A
	// [CompilerGeneratedAttribute] // RVA: 0x6682F4 Offset: 0x6682F4 VA: 0x6682F4
	// private short <DDDFCKCLGPD>k__BackingField; // 0x2C
	// [CompilerGeneratedAttribute] // RVA: 0x668304 Offset: 0x668304 VA: 0x668304
	// private short <MJPMALLKMJJ>k__BackingField; // 0x2E
	// [CompilerGeneratedAttribute] // RVA: 0x668314 Offset: 0x668314 VA: 0x668314
	// private short <CLFFNMKCEOE>k__BackingField; // 0x30
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
	// [CompilerGeneratedAttribute] // RVA: 0x668324 Offset: 0x668324 VA: 0x668324
	// private int <PHGFINLGEPL>k__BackingField; // 0x74
	// [CompilerGeneratedAttribute] // RVA: 0x668334 Offset: 0x668334 VA: 0x668334
	// private bool <NADBEMIAIJA>k__BackingField; // 0x78
	// [CompilerGeneratedAttribute] // RVA: 0x668344 Offset: 0x668344 VA: 0x668344
	// private bool <KNDGBCJKPMC>k__BackingField; // 0x79

	public short GHBPLHBNMBK { get; set; }
	// public short DLAEJOBELBH { get; set; }
	// public sbyte DEPGBBJMFED { get; set; }
	// public sbyte PPEGAKEIEGM { get; set; }
	// public sbyte ELOGNMFPAHJ { get; set; }
	// public int IJEKNCDIIAE { get; set; }
	// public int EKANGPODCEP { get; set; }
	// public short KEFGPJBKAOD { get; set; }
	// public short EEFLOOBOAGF { get; set; }
	// private short KCNHKNKNGNH { get; set; }
	// private short CNEMDPMKCPA { get; set; }
	// public short MGLDIOILOFF { get; set; }
	// private short LGNMFFMDIJP { get; set; }
	// private short AOKEOELIAMH { get; set; }
	// public short JCDKMICANJO { get; set; }
	// private short EFNKJFCJGBB { get; set; }
	// private short PNILIOGELFK { get; set; }
	// public short CCLIOBOGFHC { get; set; }
	// public short EAEDODGPLEC { get; set; }
	// public short LOKLNBLBBFD { get; set; }
	// public int BLDDNEJDFON { get; set; }
	// public bool BHJNFBDNFEJ { get; set; }
	// public bool GBNOALJPOBM { get; set; }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1150 Offset: 0x6C1150 VA: 0x6C1150
	// // RVA: 0x19F2CF8 Offset: 0x19F2CF8 VA: 0x19F2CF8
	// public short HKFCFPFPMBN() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1160 Offset: 0x6C1160 VA: 0x6C1160
	// // RVA: 0x19F2D00 Offset: 0x19F2D00 VA: 0x19F2D00
	// public void IFMPBFAAKNN(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1170 Offset: 0x6C1170 VA: 0x6C1170
	// // RVA: 0x19F2D08 Offset: 0x19F2D08 VA: 0x19F2D08
	// public short MPGNHBOBFBD() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1180 Offset: 0x6C1180 VA: 0x6C1180
	// // RVA: 0x19F2D10 Offset: 0x19F2D10 VA: 0x19F2D10
	// public void EPEMOAEGPLI(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1190 Offset: 0x6C1190 VA: 0x6C1190
	// // RVA: 0x19F2D18 Offset: 0x19F2D18 VA: 0x19F2D18
	// public sbyte FNMFOBJIIIC() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C11A0 Offset: 0x6C11A0 VA: 0x6C11A0
	// // RVA: 0x19F2D20 Offset: 0x19F2D20 VA: 0x19F2D20
	// public void OBEDPJLBBEG(sbyte NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C11B0 Offset: 0x6C11B0 VA: 0x6C11B0
	// // RVA: 0x19F2D28 Offset: 0x19F2D28 VA: 0x19F2D28
	// public sbyte KPOEEPIMMJP() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C11C0 Offset: 0x6C11C0 VA: 0x6C11C0
	// // RVA: 0x19F2D30 Offset: 0x19F2D30 VA: 0x19F2D30
	// public void NCIEAFEDPBH(sbyte NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C11D0 Offset: 0x6C11D0 VA: 0x6C11D0
	// // RVA: 0x19F2D38 Offset: 0x19F2D38 VA: 0x19F2D38
	// public sbyte PIICIAMECHP() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C11E0 Offset: 0x6C11E0 VA: 0x6C11E0
	// // RVA: 0x19F2D40 Offset: 0x19F2D40 VA: 0x19F2D40
	// public void MHEBLIAMCAC(sbyte NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C11F0 Offset: 0x6C11F0 VA: 0x6C11F0
	// // RVA: 0x19F2D48 Offset: 0x19F2D48 VA: 0x19F2D48
	// public int KJIMMIBDCIL() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1200 Offset: 0x6C1200 VA: 0x6C1200
	// // RVA: 0x19F2D50 Offset: 0x19F2D50 VA: 0x19F2D50
	// public void DMEGNOKIKCD(int NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1210 Offset: 0x6C1210 VA: 0x6C1210
	// // RVA: 0x19F2D58 Offset: 0x19F2D58 VA: 0x19F2D58
	// public int EBLAFEMDFGD() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1220 Offset: 0x6C1220 VA: 0x6C1220
	// // RVA: 0x19F2D60 Offset: 0x19F2D60 VA: 0x19F2D60
	// public void AHEFELNFBDM(int NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1230 Offset: 0x6C1230 VA: 0x6C1230
	// // RVA: 0x19F2D68 Offset: 0x19F2D68 VA: 0x19F2D68
	// public short MKJJKNIMMBC() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1240 Offset: 0x6C1240 VA: 0x6C1240
	// // RVA: 0x19F2D70 Offset: 0x19F2D70 VA: 0x19F2D70
	// public void NACMHHKKBCJ(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1250 Offset: 0x6C1250 VA: 0x6C1250
	// // RVA: 0x19F2D78 Offset: 0x19F2D78 VA: 0x19F2D78
	// public short NLDELFLNODF() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1260 Offset: 0x6C1260 VA: 0x6C1260
	// // RVA: 0x19F2D80 Offset: 0x19F2D80 VA: 0x19F2D80
	// public void PEHLMNDKOEE(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1270 Offset: 0x6C1270 VA: 0x6C1270
	// // RVA: 0x19F2D88 Offset: 0x19F2D88 VA: 0x19F2D88
	// private short BPPHFJDPDJO() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1280 Offset: 0x6C1280 VA: 0x6C1280
	// // RVA: 0x19F2D90 Offset: 0x19F2D90 VA: 0x19F2D90
	// private void FGPEKMCHDKK(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1290 Offset: 0x6C1290 VA: 0x6C1290
	// // RVA: 0x19F2D98 Offset: 0x19F2D98 VA: 0x19F2D98
	// private short OBCBGGMIHIG() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C12A0 Offset: 0x6C12A0 VA: 0x6C12A0
	// // RVA: 0x19F2DA0 Offset: 0x19F2DA0 VA: 0x19F2DA0
	// private void AELNGOGMECL(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C12B0 Offset: 0x6C12B0 VA: 0x6C12B0
	// // RVA: 0x19F2DA8 Offset: 0x19F2DA8 VA: 0x19F2DA8
	// public short JCCNFABDFGA() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C12C0 Offset: 0x6C12C0 VA: 0x6C12C0
	// // RVA: 0x19F2DB0 Offset: 0x19F2DB0 VA: 0x19F2DB0
	// public void LPONDIIPEDN(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C12D0 Offset: 0x6C12D0 VA: 0x6C12D0
	// // RVA: 0x19F2DB8 Offset: 0x19F2DB8 VA: 0x19F2DB8
	// private short GOELDFINKPG() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C12E0 Offset: 0x6C12E0 VA: 0x6C12E0
	// // RVA: 0x19F2DC0 Offset: 0x19F2DC0 VA: 0x19F2DC0
	// private void DOPEOGFPFPN(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C12F0 Offset: 0x6C12F0 VA: 0x6C12F0
	// // RVA: 0x19F2DC8 Offset: 0x19F2DC8 VA: 0x19F2DC8
	// private short DJMKMADIFCN() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1300 Offset: 0x6C1300 VA: 0x6C1300
	// // RVA: 0x19F2DD0 Offset: 0x19F2DD0 VA: 0x19F2DD0
	// private void DBCDHPEOKKD(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1310 Offset: 0x6C1310 VA: 0x6C1310
	// // RVA: 0x19F2DD8 Offset: 0x19F2DD8 VA: 0x19F2DD8
	// public short ODFMHJFFILL() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1320 Offset: 0x6C1320 VA: 0x6C1320
	// // RVA: 0x19F2DE0 Offset: 0x19F2DE0 VA: 0x19F2DE0
	// public void DCDFFHHMHEL(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1330 Offset: 0x6C1330 VA: 0x6C1330
	// // RVA: 0x19F2DE8 Offset: 0x19F2DE8 VA: 0x19F2DE8
	// private short EMEFKAIBMFJ() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1340 Offset: 0x6C1340 VA: 0x6C1340
	// // RVA: 0x19F2DF0 Offset: 0x19F2DF0 VA: 0x19F2DF0
	// private void LDCPINNLDDN(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1350 Offset: 0x6C1350 VA: 0x6C1350
	// // RVA: 0x19F2DF8 Offset: 0x19F2DF8 VA: 0x19F2DF8
	// private short FJHBDENFDAJ() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1360 Offset: 0x6C1360 VA: 0x6C1360
	// // RVA: 0x19F2E00 Offset: 0x19F2E00 VA: 0x19F2E00
	// private void DELONBFLKPM(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1370 Offset: 0x6C1370 VA: 0x6C1370
	// // RVA: 0x19F2E08 Offset: 0x19F2E08 VA: 0x19F2E08
	// public short JMGOABJPFJO() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1380 Offset: 0x6C1380 VA: 0x6C1380
	// // RVA: 0x19F2E10 Offset: 0x19F2E10 VA: 0x19F2E10
	// public void LJMBPNDJCOO(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1390 Offset: 0x6C1390 VA: 0x6C1390
	// // RVA: 0x19F2E18 Offset: 0x19F2E18 VA: 0x19F2E18
	// public short EOGPNADNBFO() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C13A0 Offset: 0x6C13A0 VA: 0x6C13A0
	// // RVA: 0x19F2E20 Offset: 0x19F2E20 VA: 0x19F2E20
	// public void OGLPGIKKFLK(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C13B0 Offset: 0x6C13B0 VA: 0x6C13B0
	// // RVA: 0x19F2E28 Offset: 0x19F2E28 VA: 0x19F2E28
	// public short IHPAHIEIHMH() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C13C0 Offset: 0x6C13C0 VA: 0x6C13C0
	// // RVA: 0x19F2E30 Offset: 0x19F2E30 VA: 0x19F2E30
	// public void LNCFBKJDBEK(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C13D0 Offset: 0x6C13D0 VA: 0x6C13D0
	// // RVA: 0x19F2E38 Offset: 0x19F2E38 VA: 0x19F2E38
	// public int JLDOLKKPJMP() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C13E0 Offset: 0x6C13E0 VA: 0x6C13E0
	// // RVA: 0x19F2E40 Offset: 0x19F2E40 VA: 0x19F2E40
	// public void ADMEDIKMAPD(int NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C13F0 Offset: 0x6C13F0 VA: 0x6C13F0
	// // RVA: 0x19F2E48 Offset: 0x19F2E48 VA: 0x19F2E48
	// public bool JCELPEBCMAG() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1400 Offset: 0x6C1400 VA: 0x6C1400
	// // RVA: 0x19F2E50 Offset: 0x19F2E50 VA: 0x19F2E50
	// public void GCCCGMBALMC(bool NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1410 Offset: 0x6C1410 VA: 0x6C1410
	// // RVA: 0x19F2E58 Offset: 0x19F2E58 VA: 0x19F2E58
	// public bool PALLMADFFMA() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1420 Offset: 0x6C1420 VA: 0x6C1420
	// // RVA: 0x19F2E60 Offset: 0x19F2E60 VA: 0x19F2E60
	// public void BEDKPPHDHAA(bool NANNGLGOFKH) { }

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
	// [CompilerGeneratedAttribute] // RVA: 0x668354 Offset: 0x668354 VA: 0x668354
	// private short <GBNPEKLEHPH>k__BackingField; // 0x8
	// [CompilerGeneratedAttribute] // RVA: 0x668364 Offset: 0x668364 VA: 0x668364
	// private int <CKJALIDGGOH>k__BackingField; // 0xC
	// [CompilerGeneratedAttribute] // RVA: 0x668374 Offset: 0x668374 VA: 0x668374
	// private int <OGKJCKOPEPM>k__BackingField; // 0x10
	// [CompilerGeneratedAttribute] // RVA: 0x668384 Offset: 0x668384 VA: 0x668384
	// private int <OHACHFCDBOF>k__BackingField; // 0x14
	// [CompilerGeneratedAttribute] // RVA: 0x668394 Offset: 0x668394 VA: 0x668394
	// private int <CFNDJLELGFP>k__BackingField; // 0x18
	// [CompilerGeneratedAttribute] // RVA: 0x6683A4 Offset: 0x6683A4 VA: 0x6683A4
	// private int <APIBHBGLOCI>k__BackingField; // 0x1C
	// [CompilerGeneratedAttribute] // RVA: 0x6683B4 Offset: 0x6683B4 VA: 0x6683B4
	// private int <HGCANNFGBJK>k__BackingField; // 0x20
	// public short[] OCOGIADDNDN = new short[3]; // 0x24
	// public short[] LHICAKGHIGF = new short[3]; // 0x28
	// public int[] HLKHOFPAOMK = new int[3]; // 0x2C
	// public int[] HLLJIICKNIP = new int[3]; // 0x30
	// public int[] FENOHOEIJOE = new int[3]; // 0x34
	// public int[] LJPKLMJPLAC = new int[3]; // 0x38
	// public int[] MALHPBKPIDE = new int[3]; // 0x3C
	// public List<ADDHLABEFKH> COGKJBAFBKN = new List<ADDHLABEFKH>(); // 0x40
	// public byte PPEGAKEIEGM; // 0x44

	// public short KLCIIHKFPPO { get; set; }
	// public int DLAEJOBELBH { get; set; }
	// public int DEPGBBJMFED { get; set; }
	// public int MHPAFEEPBNJ { get; set; }
	// public int KEFGPJBKAOD { get; set; }
	// public int KCNHKNKNGNH { get; set; }
	// public int MGLDIOILOFF { get; set; }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1430 Offset: 0x6C1430 VA: 0x6C1430
	// // RVA: 0x198D528 Offset: 0x198D528 VA: 0x198D528
	// public short CPDGCNILCII() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1440 Offset: 0x6C1440 VA: 0x6C1440
	// // RVA: 0x198D530 Offset: 0x198D530 VA: 0x198D530
	// public void IILKMGEKOBG(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1450 Offset: 0x6C1450 VA: 0x6C1450
	// // RVA: 0x198D538 Offset: 0x198D538 VA: 0x198D538
	// public int MPGNHBOBFBD() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1460 Offset: 0x6C1460 VA: 0x6C1460
	// // RVA: 0x198D540 Offset: 0x198D540 VA: 0x198D540
	// public void EPEMOAEGPLI(int NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1470 Offset: 0x6C1470 VA: 0x6C1470
	// // RVA: 0x198D548 Offset: 0x198D548 VA: 0x198D548
	// public int FNMFOBJIIIC() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1480 Offset: 0x6C1480 VA: 0x6C1480
	// // RVA: 0x198D550 Offset: 0x198D550 VA: 0x198D550
	// public void OBEDPJLBBEG(int NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1490 Offset: 0x6C1490 VA: 0x6C1490
	// // RVA: 0x198D558 Offset: 0x198D558 VA: 0x198D558
	// public int NODKIDEKNGJ() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C14A0 Offset: 0x6C14A0 VA: 0x6C14A0
	// // RVA: 0x198D560 Offset: 0x198D560 VA: 0x198D560
	// public void CHFBEINBPKA(int NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C14B0 Offset: 0x6C14B0 VA: 0x6C14B0
	// // RVA: 0x198D568 Offset: 0x198D568 VA: 0x198D568
	// public int MKJJKNIMMBC() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C14C0 Offset: 0x6C14C0 VA: 0x6C14C0
	// // RVA: 0x198D570 Offset: 0x198D570 VA: 0x198D570
	// public void NACMHHKKBCJ(int NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C14D0 Offset: 0x6C14D0 VA: 0x6C14D0
	// // RVA: 0x198D578 Offset: 0x198D578 VA: 0x198D578
	// public int BPPHFJDPDJO() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C14E0 Offset: 0x6C14E0 VA: 0x6C14E0
	// // RVA: 0x198D580 Offset: 0x198D580 VA: 0x198D580
	// public void FGPEKMCHDKK(int NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C14F0 Offset: 0x6C14F0 VA: 0x6C14F0
	// // RVA: 0x198D588 Offset: 0x198D588 VA: 0x198D588
	// public int JCCNFABDFGA() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1500 Offset: 0x6C1500 VA: 0x6C1500
	// // RVA: 0x198D590 Offset: 0x198D590 VA: 0x198D590
	// public void LPONDIIPEDN(int NANNGLGOFKH) { }

	// // RVA: 0x198D598 Offset: 0x198D598 VA: 0x198D598
	// public uint CAOGDCBPBAN() { }
}


public class HMJHLLPBCLD : IComparable<HMJHLLPBCLD>
{
	// [CompilerGeneratedAttribute] // RVA: 0x6683C4 Offset: 0x6683C4 VA: 0x6683C4
	// private int <KNJIHALCKLN>k__BackingField; // 0x8
	// [CompilerGeneratedAttribute] // RVA: 0x6683D4 Offset: 0x6683D4 VA: 0x6683D4
	// private short <HHBMOFEAFKC>k__BackingField; // 0xC
	// [CompilerGeneratedAttribute] // RVA: 0x6683E4 Offset: 0x6683E4 VA: 0x6683E4
	// private short <BDIBNPFLIED>k__BackingField; // 0xE
	// [CompilerGeneratedAttribute] // RVA: 0x6683F4 Offset: 0x6683F4 VA: 0x6683F4
	// private short <CDLBEODBHLK>k__BackingField; // 0x10

	// public int LJNAKDMILMC { get; set; }
	// public int ANAJIAENLNB { get; }
	// public int AHHJLDLAPAN { get; }
	// public int DLAEJOBELBH { get; }
	// public short LHBDCGFOKCA { get; set; }
	// public short CEFHDLLAPDH { get; set; }
	// public short CIIIELDHDEP { get; set; }
	// public short LDCJDIAOKGD { get; set; }
	// public short KDGIHMCBLND { get; set; }

	// // RVA: 0x15F68F8 Offset: 0x15F68F8 VA: 0x15F68F8
	// public static int ABDFBABHIHJ(int DLAEJOBELBH, int AHHJLDLAPAN, int BAKLKJLPLOJ) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1510 Offset: 0x6C1510 VA: 0x6C1510
	// // RVA: 0x15F6910 Offset: 0x15F6910 VA: 0x15F6910
	// public int LIIHHICIBKM() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1520 Offset: 0x6C1520 VA: 0x6C1520
	// // RVA: 0x15F6918 Offset: 0x15F6918 VA: 0x15F6918
	// public void OACJGKPBHIK(int NANNGLGOFKH) { }

	// // RVA: 0x15F6920 Offset: 0x15F6920 VA: 0x15F6920
	// public int MMOMNMBKHJF() { }

	// // RVA: 0x15F6944 Offset: 0x15F6944 VA: 0x15F6944
	// public int IPKDLMIDMHH() { }

	// // RVA: 0x15F6974 Offset: 0x15F6974 VA: 0x15F6974
	// public int MPGNHBOBFBD() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1530 Offset: 0x6C1530 VA: 0x6C1530
	// // RVA: 0x15F6990 Offset: 0x15F6990 VA: 0x15F6990
	// public short OLHHGEIKLDM() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1540 Offset: 0x6C1540 VA: 0x6C1540
	// // RVA: 0x15F6998 Offset: 0x15F6998 VA: 0x15F6998
	// public void DOOHFPHPMPF(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1550 Offset: 0x6C1550 VA: 0x6C1550
	// // RVA: 0x15F69A0 Offset: 0x15F69A0 VA: 0x15F69A0
	// public short BKFIIGCINNL() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1560 Offset: 0x6C1560 VA: 0x6C1560
	// // RVA: 0x15F69A8 Offset: 0x15F69A8 VA: 0x15F69A8
	// public void BNJMJMNLMEA(short NANNGLGOFKH) { }

	// // RVA: 0x15F69B0 Offset: 0x15F69B0 VA: 0x15F69B0
	// public short NAMNBEJFNFN() { }

	// // RVA: 0x15F69D0 Offset: 0x15F69D0 VA: 0x15F69D0
	// public void BGOEGAOOHIE(short NANNGLGOFKH) { }

	// // RVA: 0x15F69E0 Offset: 0x15F69E0 VA: 0x15F69E0
	// public short DBJGHGEJOAH() { }

	// // RVA: 0x15F69E8 Offset: 0x15F69E8 VA: 0x15F69E8
	// public void HEDOJDJALID(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1570 Offset: 0x6C1570 VA: 0x6C1570
	// // RVA: 0x15F69C8 Offset: 0x15F69C8 VA: 0x15F69C8
	// public short GLDGPMFEKGM() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1580 Offset: 0x6C1580 VA: 0x6C1580
	// // RVA: 0x15F69D8 Offset: 0x15F69D8 VA: 0x15F69D8
	// public void BJIBDJAOFJJ(short NANNGLGOFKH) { }

	// // RVA: 0x15F69F0 Offset: 0x15F69F0 VA: 0x15F69F0
	// public void .ctor(int LJNAKDMILMC) { }

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
	// [CompilerGeneratedAttribute] // RVA: 0x668404 Offset: 0x668404 VA: 0x668404
	// private int <JHHAKBMGFEN>k__BackingField; // 0x8
	// [CompilerGeneratedAttribute] // RVA: 0x668414 Offset: 0x668414 VA: 0x668414
	// private int <PLIPNHDDIFP>k__BackingField; // 0xC

	// public int GHBPLHBNMBK { get; set; }
	// public int ADBHJCDINFL { get; set; }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1590 Offset: 0x6C1590 VA: 0x6C1590
	// // RVA: 0x1BA5420 Offset: 0x1BA5420 VA: 0x1BA5420
	// public int HKFCFPFPMBN() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C15A0 Offset: 0x6C15A0 VA: 0x6C15A0
	// // RVA: 0x1BA5428 Offset: 0x1BA5428 VA: 0x1BA5428
	// public void IFMPBFAAKNN(int NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C15B0 Offset: 0x6C15B0 VA: 0x6C15B0
	// // RVA: 0x1BA5430 Offset: 0x1BA5430 VA: 0x1BA5430
	// public int NKIPIGNMFGK() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C15C0 Offset: 0x6C15C0 VA: 0x6C15C0
	// // RVA: 0x1BA5438 Offset: 0x1BA5438 VA: 0x1BA5438
	// public void NNPOJPDCEHE(int NANNGLGOFKH) { }

	// // RVA: 0x1BA5440 Offset: 0x1BA5440 VA: 0x1BA5440
	// public uint CAOGDCBPBAN() { }
}

public class NONFIGBOJLN
{
	public int PDGEMDFHFIB; // 0x8
	public List<int> MNKDEFJFKGN; // 0xC
}

public class AJIKMKFGNCJ //!!!
{
	// [CompilerGeneratedAttribute] // RVA: 0x668424 Offset: 0x668424 VA: 0x668424
	// private short <JIHJGFNPPIL>k__BackingField; // 0x8
	// [CompilerGeneratedAttribute] // RVA: 0x668434 Offset: 0x668434 VA: 0x668434
	// private byte <JDIGGEBNOPK>k__BackingField; // 0xA
	// [CompilerGeneratedAttribute] // RVA: 0x668444 Offset: 0x668444 VA: 0x668444
	// private byte <AMALMGIALDF>k__BackingField; // 0xB
	// [CompilerGeneratedAttribute] // RVA: 0x668454 Offset: 0x668454 VA: 0x668454
	// private int <AHPLCJAKAOP>k__BackingField; // 0xC

	// public short JOMGCCBFKEF { get; set; }
	// public byte INDDJNMPONH { get; set; }
	// public byte AHHJLDLAPAN { get; set; }
	// public int JBGEEPFKIGG { get; set; }

	// [CompilerGeneratedAttribute] // RVA: 0x6C15D0 Offset: 0x6C15D0 VA: 0x6C15D0
	// // RVA: 0xCD251C Offset: 0xCD251C VA: 0xCD251C
	// public short GGFGMDFOFLG() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C15E0 Offset: 0x6C15E0 VA: 0x6C15E0
	// // RVA: 0xCD2524 Offset: 0xCD2524 VA: 0xCD2524
	// public void JCJBHJOOIDP(short NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C15F0 Offset: 0x6C15F0 VA: 0x6C15F0
	// // RVA: 0xCD252C Offset: 0xCD252C VA: 0xCD252C
	// public byte GHAILOLPHPF() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1600 Offset: 0x6C1600 VA: 0x6C1600
	// // RVA: 0xCD2534 Offset: 0xCD2534 VA: 0xCD2534
	// public void BACGOKIGMBC(byte NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1610 Offset: 0x6C1610 VA: 0x6C1610
	// // RVA: 0xCD253C Offset: 0xCD253C VA: 0xCD253C
	// public byte IPKDLMIDMHH() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1620 Offset: 0x6C1620 VA: 0x6C1620
	// // RVA: 0xCD2544 Offset: 0xCD2544 VA: 0xCD2544
	// public void IENNENMKEFO(byte NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1630 Offset: 0x6C1630 VA: 0x6C1630
	// // RVA: 0xCD254C Offset: 0xCD254C VA: 0xCD254C
	// public int OLOCMINKGON() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C1640 Offset: 0x6C1640 VA: 0x6C1640
	// // RVA: 0xCD2554 Offset: 0xCD2554 VA: 0xCD2554
	// public void ABAFHIBFKCE(int NANNGLGOFKH) { }
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