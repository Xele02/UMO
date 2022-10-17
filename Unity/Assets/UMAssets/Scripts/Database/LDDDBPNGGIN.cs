using System.Collections.Generic;
using XeSys;

public class LDDDBPNGGIN { }
public class LDDDBPNGGIN_Game : DIHHCBACKGG_DbSection
{
	private const int NADNGLNALCK = 30;
	private const int NHCGFMDPPPA = 5;
	private const int NAJMGFDOCMH = 25;
	public static int EDGOFPJDPPI = -1; // 0x0
	private int FBGGEFFJJHB = 0x1aa9f1; // 0x20
	public int LECAOCJCEKF_FCoeff0; // 0xAC
	public int IHIONKFAAED_FCoeff1; // 0xB0
	public int HHPJIALEPEE_FCoeff2; // 0xB4
	public int BCCKJLPNJJM_FCoeff3; // 0xB8
	public int CIFKMCKFMOA_FCoeff4; // 0xBC
	public int FLPKPBECPOD_BCoeff0; // 0xC4
	public int NELJPDJEKNM_BCoeff1; // 0xC8
	public int MPAMBMKFCKK_BCoeff2; // 0xCC
	public int IJDBNKCLGIC_BCoeff3; // 0xD0
	public int GLMKBFEHPLA_BCoeff4; // 0xD4
	public int LPDACKNMGNK_BCoeff5; // 0xD8
	private List<int> EDCJLGMBGCH_BCb; // 0xDC
	private List<int> DFEAPKGAGMN_BHit; // 0xE0
	private Dictionary<int, byte[]> GEDEIGJKMGI; // 0xFC
	public List<int> HLKHOFPAOMK_VIn; // 0x108
	public List<int> HLLJIICKNIP_VAw; // 0x10C
	public List<int> FENOHOEIJOE_VMax; // 0x110
	public List<int> LJPKLMJPLAC_DIn; // 0x114
	public List<int> MALHPBKPIDE_SdIn; // 0x118
	public List<int> GEFODCKCCBK; // 0x11C
	public List<int> ELLLGOHHICG; // 0x120
	public List<int> IHMOHBMPMLO; // 0x124
	public List<int> GJDCMCFCIKD; // 0x128
	public List<int> IIDJCNEOLAL; // 0x12C
	public List<int> JJBJKENKAJP_ClrRarCoef; // 0x130
	private List<KLJCBKMHKNK> HPEFFMGGIBC_Spn; // 0x134
	private int PNEMPHGJLKG_LuckCoef0; // 0x138
	private int NPEECLODIKB_LuckCoef1; // 0x13C
	public List<sbyte> JHPPLIGJFPI; // 0x140
	private List<int> DOAAGIMJOMM; // 0x144
	private List<int> KMJNLIMMCED; // 0x148

	public List<JANMKFAKHIC_ComboBonus> KGHLOJNCFDO_ComboBonus { get; private set; } // 0x24 KGEFOIBPACG KHDCLBNDLPL IKNIJILKKCC
	public List<int> PDNEMDIEGFB_JudgeCoef { get; private set; } // 0x28 JLOJENKKFFK MNANHEAKBBM BAKOHDPHEDO
	private List<int> JKPKJKFJDGL_Progress { get; set; } // 0x2C OJIPOCNKJBD KDPCOHLOEPI EOHDGCNIFDD
	private List<int> OBLDNPMODOM_SSta { get; set; } // 0x30 NPILHIHHEAI BBNCEDBIOPA BNDHBJKKLDJ
	private List<int> COKBDFIMOPM_FSta { get; set; } // 0x34 LGJFNFMPHFC CFGNDJEJLBG MENCEALDKFL
	private List<int> OHNJBOFLCOL_DMis { get; set; } // 0x38 JDBEGBDCANJ PCAHFKBLGBJ JFAEDDLHHHL
	private List<int> HHCDCEOJCIH_DBad { get; set; } // 0x3C DONDJBIKOCG EKPHGCGNCGI LLJMJOEFGLP
	private List<int> IMIMFIKCFMK_Heal { get; set; } // 0x40 DJAGACPHFMG JJLBDIGMIFG DJPJFOHDGPL
	private List<int> PIBHLAMOJNH { get; set; } // 0x44 NOBIPOAKIBM JFMJEIEAFMA MPKGHIGNGDK
	private List<int> CAIAODFECPC { get; set; } // 0x48 NDDBGDLPCDF LJINEDABLGC LEOCPDDOCKJ
	private List<int> KGJDEFCEEAB { get; set; } // 0x4C PEDJMMGILOO JDDGFDDHIOE NPJPJJNFPIF
	private List<int> PLMFEFIIBFL { get; set; } // 0x50 JFPBFCMFLFN NCNPOOEDFKJ LBMIPPEIKIM
	private List<int> BGKMMAGPAMJ { get; set; } // 0x54 NHPCFCHGJHA KBBMCHCEDDL DGBENIFCADE
	public List<int> EKONPEGLAND_PrsSt { get; private set; } // 0x58 HIKHMNLINHK GHKKLEMEFNC KLOMFFIIOIJ
	public List<int> ILIEHCECHOA_PrsEd { get; private set; } // 0x5C DDHOFNKHJAC NJMOEBAMNBD BFIDKDHLDNF
	public List<int> NPNCNFKCIAE_RelSt { get; private set; } // 0x60 PBCPNONMGMK IJOIFPCKPCC PMBDANMIMGM
	public List<int> HODKHINFHGH_RelEd { get; private set; } // 0x64 PIGNMLCJAON AMJLFHNFLCL CGABGDKCKNC
	public List<int> BFDLLHNGICE_TapSt { get; private set; } // 0x68 KEGKFMIDNNC BCBGKEHFEGM GBJBHMEPCKB
	public List<int> ICNFEDCCODF_TapEd { get; private set; } // 0x6C LHKGBMJBDIG FPIBEOILGPI CNBHKJCCLMG
	public List<int> AOFKIBFPAOD_SFlkSt { get; private set; } // 0x70 KKAJIHKPLAJ NKDPBBMOEDI HCENODFLLKA
	public List<int> FDLBHEMAOLC_SFlkEd { get; private set; } // 0x74 LNIMHIEONAP FEIIGKHOPPO AGLCDKODAAM
	public List<int> MNGGGOOCJBM_SFlkSt { get; private set; } // 0x78 KCIDHEBAFNO HJIODPHOAEM PPKGCGHCGJE
	public List<int> BLEDLGDGBHI_SFlkEd { get; private set; } // 0x7C OIFDPNACLBO DPLGCCCGMEA DLPDCMOMMGF
	public List<int> PLGLPDGAADE_LFlkSt { get; private set; } // 0x80 ONEDEHPKJBF BJCAPIBFMMM AKHPFPLDNJB
	public List<int> IFHAPIJOCOJ_LFlkEd { get; private set; } // 0x84 BELIANLLCIA DFLGBDDJJEF FJIGECMBDDO
	public List<int> DDLNCIOPBBB_SlRelSt { get; private set; } // 0x88 AFMBPDOGPJB NMIIDEACMOG GNPCOIKJPIG
	public List<int> DDGNKEJKJCK_SlRelEd { get; private set; } // 0x8C ANDKJHBACIH BEPFOFDMCFJ FGACFCONAAN
	public List<int> KDGGKFOAGAE_SlFlkSt { get; private set; } // 0x90 DOPBAMLOCIO JEBHDMKBJFE EDAIDBMOENF
	public List<int> FBKOFEHDENI_SlFlkEd { get; private set; } // 0x94 LBGBPNNFMBN DKBFIEMFMOL PCNMCFKJAKK
	public List<int> KBOIDPDGCLA_PasSt { get; private set; } // 0x98 IIBNBENEJLN CACNGONAKFC ACBFJKBJOFF
	public List<int> GGAMKBLHGGI_PasEd { get; private set; } // 0x9C MMJCJMDBMAN NKHPAMBMGHH LNEJKJBKJAD
	private List<int> FIDHHBBINNB_Uc { get; set; } // 0xA0 DAGAJKBDICH KKMEKEPJKIN NLHFPGKEDAE
	private List<int> MPADAMHJBKK { get; set; } // 0xA4 FAALLDIADNK OHAIBAGEBPI LELJPMEAKCL
	public List<int> CPNJJKDKNOO_FPt { get; private set; } // 0xA8 DDFBBNIDJCC OHAGJJCHEHB HHICCPAOIDC
	public List<int> EONACOOGKCA_BPt { get; private set; } // 0xC0 NKENGKNNLBO PJPCHAFPLOL DHPBCABKIMB
	public List<sbyte> LLDJIAKLOGC_RarMltMax { get; private set; } // 0xE4 AAPBDKJMMMC CPONLDIPHBC OAFDONJGICP
	public List<sbyte> FKLCEJNHKMN_RarLvMax { get; private set; } // 0xE8 HOGHPJNPMMJ BGNDKMECEJE LKJEJJOLLGA
	public List<byte[]> ODEBNEPEDLN { get; private set; } // 0xEC BKECHPMBPEI GANOHDNGGFD JANPPDBPFKO
	public List<sbyte> ALPMOLDJJKL_RarFeedMltMax { get; private set; } // 0xF0 BDCNICMDOFN BPPEMPKMOBO ODKFFGPEKHH
	public List<sbyte> PNDCOGFIGJO_RarFeedLvMax { get; private set; } // 0xF4 EDJPHDKKKMN JGCAHAKFFMC ILHOJHCDDCI
	public List<byte[]> HFHMMOMMFON { get; private set; } // 0xF8 LIKKAOPIJPL HCEPMKIIAFM BELEAEECDBA
	public List<int> KDIJDAKMODE { get; private set; } // 0x100 LIIEMFJHMJG LKFIODIJCHM PKJMLBKLIGE
	public List<int> AJBKGOPDGFI { get; private set; } // 0x104 AFKBJPJLHIN DMAGCOAEFFH AFDEABEKAFG
	// public int JJIBDCAIBIO { get; set; } // CODJHFNCMMC 0xDA1000 IPLMEIKMCJB 0xDA1010
	// public int AMNBEMCJCHF { get; set; } // KEFFGJGHPIF 0xDA1020 HDOCBIIBDPG 0xDA1030
	public Dictionary<string, int> OHJFBLFELNK { get; private set; } // 0x14C KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	// // RVA: 0xDA0338 Offset: 0xDA0338 VA: 0xDA0338
	public int ADBELGIDIEN(int ANAJIAENLNB_MusicLevel, bool GIKLNODJKFK_IsLine6)
	{
		if(!GIKLNODJKFK_IsLine6)
		{
			return JKPKJKFJDGL_Progress[ANAJIAENLNB_MusicLevel - 1];
		}
		else
		{
			return PIBHLAMOJNH[ANAJIAENLNB_MusicLevel - 1];
		}
	}

	// // RVA: 0xDA03C8 Offset: 0xDA03C8 VA: 0xDA03C8
	// public int MMLNFAJOPCB(int ANAJIAENLNB) { }

	// // RVA: 0xDA0448 Offset: 0xDA0448 VA: 0xDA0448
	public int HHEEPBJNAKA_GetEnergy(int ANAJIAENLNB, bool GIKLNODJKFK)
	{
		if (!GIKLNODJKFK)
			return COKBDFIMOPM_FSta[ANAJIAENLNB - 1];
		else
			return CAIAODFECPC[ANAJIAENLNB - 1];
	}

	// // RVA: 0xDA04D8 Offset: 0xDA04D8 VA: 0xDA04D8
	public int AOGJFPLIOGB(int ANAJIAENLNB, bool GIKLNODJKFK)
	{
		if (!GIKLNODJKFK)
		{
			return OHNJBOFLCOL_DMis[ANAJIAENLNB - 1];
		}
		else
		{
			return KGJDEFCEEAB[ANAJIAENLNB - 1];
		}
	}

	// // RVA: 0xDA0568 Offset: 0xDA0568 VA: 0xDA0568
	public int GOLHPPFLJNF(int ANAJIAENLNB, bool GIKLNODJKFK)
	{
		if(!GIKLNODJKFK)
		{
			return HHCDCEOJCIH_DBad[ANAJIAENLNB - 1];
		}
		else
		{
			return PLMFEFIIBFL[ANAJIAENLNB - 1];
		}
	}

	// // RVA: 0xDA05F8 Offset: 0xDA05F8 VA: 0xDA05F8
	public int AFDONIMNHEJ(int ANAJIAENLNB, bool GIKLNODJKFK)
	{
		if (!GIKLNODJKFK)
		{
			return IMIMFIKCFMK_Heal[ANAJIAENLNB - 1];
		}
		else
		{
			return BGKMMAGPAMJ[ANAJIAENLNB - 1];
		}
	}

	// // RVA: 0xDA0688 Offset: 0xDA0688 VA: 0xDA0688
	// public int GFODAIJMBAH(int ANAJIAENLNB, bool GIKLNODJKFK) { }

	// // RVA: 0xDA0798 Offset: 0xDA0798 VA: 0xDA0798
	// public byte[] CEKGFNKJDCF(KOGHKIODHPA JEMMMJEJLNL, int JPIPENJGGDD, int AOPBAOJIOGO, int ILABPFOMEAG, int JKGFBFPIMGA, bool MCCIFLKCNKO) { }

	// // RVA: 0xDA0984 Offset: 0xDA0984 VA: 0xDA0984
	public byte[] KLIGCACGHHN(KOGHKIODHPA_Board JEMMMJEJLNL_BoardDb, int AOPBAOJIOGO_Sb, int ILABPFOMEAG_Va, int JKGFBFPIMGA_Rar, bool MCCIFLKCNKO_Feed)
	{
		int id = GENHLFPKOEE(JKGFBFPIMGA_Rar, MCCIFLKCNKO_Feed);
		int id2 = JEMMMJEJLNL_BoardDb.NENHCPMDAGM(id, AOPBAOJIOGO_Sb, ILABPFOMEAG_Va);
		int key = id * 1000 + id2;
		if (GEDEIGJKMGI.ContainsKey(key))
		{
			return GEDEIGJKMGI[key];
		}
		else
		{
			byte[] res = new byte[50];
			for(int i = 0; i < id2; i++)
			{
				res[i >> 3] |= (byte)(1 << (i & 7));
			}
			GEDEIGJKMGI.Add(key, res);
			return res;
		}
	}

	// // RVA: 0xDA0B80 Offset: 0xDA0B80 VA: 0xDA0B80
	public int FHHPNFAECCJ(int CKFNNECHOGG)
	{
		return DEOPEBMHCLB(EDCJLGMBGCH_BCb, CKFNNECHOGG);
	}

	// // RVA: 0xDA0C1C Offset: 0xDA0C1C VA: 0xDA0C1C
	public int IKIGFABDFMB(int OBBGMJPIHIL)
	{
		return DEOPEBMHCLB(DFEAPKGAGMN_BHit, OBBGMJPIHIL);
	}

	// // RVA: 0xDA0C28 Offset: 0xDA0C28 VA: 0xDA0C28
	public int FHFLCJHEEPK(int OBBGMJPIHIL)
	{
		return GIIDKJMJLPP(DFEAPKGAGMN_BHit, OBBGMJPIHIL);
	}

	// // RVA: 0xDA0C34 Offset: 0xDA0C34 VA: 0xDA0C34
	private int GIIDKJMJLPP(List<int> NNDGIAEFMOG, int NANNGLGOFKH)
	{
		int res = 0;
		if(NNDGIAEFMOG.Count > 1)
		{
			/*int var4 = 0;
			int index = 0;
			int var1 = 0;
			int var6 = -1;
			int var7 = 0;
			int var5 = 0;
			do
			{
				var5 = var1;
				res = NNDGIAEFMOG[index];
				if (res > NANNGLGOFKH)
					return var7;
				var4 = var6 + 2;
				index += 2;
				var1 = var5 + 1;
				var6++;
				var7 = var5;
			} while (var4 < NNDGIAEFMOG.Count / 2);*/
			for(res = 0; res < NNDGIAEFMOG.Count / 2; res++)
			{
				if(NNDGIAEFMOG[res] >= NANNGLGOFKH)
					return res;
			}
			res--;
		}
		return res;
	}

	// // RVA: 0xDA0B8C Offset: 0xDA0B8C VA: 0xDA0B8C
	private int DEOPEBMHCLB(List<int> NNDGIAEFMOG, int NANNGLGOFKH)
	{
		return NNDGIAEFMOG[GIIDKJMJLPP(NNDGIAEFMOG, NANNGLGOFKH) << 1 | 1];
	}

	// // RVA: 0xDA0D38 Offset: 0xDA0D38 VA: 0xDA0D38
	// public KLJCBKMHKNK BBFNPHGDCOF(int PPFNGGCBJKC_Id) { }

	// // RVA: 0xDA08F4 Offset: 0xDA08F4 VA: 0xDA08F4
	public int GENHLFPKOEE(int FBFLDFMFFOH_Rar, bool MCCIFLKCNKO_Feed)
	{
		if (MCCIFLKCNKO_Feed)
			return ALPMOLDJJKL_RarFeedMltMax[FBFLDFMFFOH_Rar - 1];
		else
			return LLDJIAKLOGC_RarMltMax[FBFLDFMFFOH_Rar - 1];
	}

	// // RVA: 0xDA0E5C Offset: 0xDA0E5C VA: 0xDA0E5C
	public int LAGGGIEIPEG(int JKGFBFPIMGA, bool OBKCAELADKD, bool MCCIFLKCNKO)
	{
		if(MCCIFLKCNKO)
		{
			return PNDCOGFIGJO_RarFeedLvMax[JKGFBFPIMGA * 2 - 2 | (OBKCAELADKD ? 1 : 0)];
		}
		else
		{
			return FKLCEJNHKMN_RarLvMax[JKGFBFPIMGA + (OBKCAELADKD ? 1 : 0) - 1];
		}
	}

	// // RVA: 0xDA0F2C Offset: 0xDA0F2C VA: 0xDA0F2C
	// public int GAJPHGOJAAB(int NIGMJFOLJBE, bool MCCIFLKCNKO) { }

	// // RVA: 0xDA0F40 Offset: 0xDA0F40 VA: 0xDA0F40
	public byte[] DNMKPAKOJFA(int JKGFBFPIMGA, bool OBKCAELADKD, bool MCCIFLKCNKO)
	{
		if (MCCIFLKCNKO)
		{
			return HFHMMOMMFON[JKGFBFPIMGA * 2 - 2 | (OBKCAELADKD ? 1 : 0)];
		}
		else
		{
			return ODEBNEPEDLN[JKGFBFPIMGA + (OBKCAELADKD ? 1 : 0) - 1];
		}
	}

	// // RVA: 0xDA1040 Offset: 0xDA1040 VA: 0xDA1040
	// public int NBIAKELCBLC(int MJBODMOLOBC, int HLOHIMEAPLH) { }

	// // RVA: 0xDA1120 Offset: 0xDA1120 VA: 0xDA1120
	// public static int NBIAKELCBLC(int MJBODMOLOBC, int HLOHIMEAPLH, int BAFFAONJPCE, int BDMLMGBLGPC) { }

	// // RVA: 0xDA1180 Offset: 0xDA1180 VA: 0xDA1180
	// public int GFIPALLLPMF(int PMKBJMHIFCM, int EILKGEADKGH) { }

	// // RVA: 0xDA12BC Offset: 0xDA12BC VA: 0xDA12BC
	public int GAHIBKLEDBF(int AKNELONELJK_Difficulty, bool GIKLNODJKFK_IsLine6)
	{
		if(!GIKLNODJKFK_IsLine6)
		{
			return DOAAGIMJOMM[AKNELONELJK_Difficulty];
		}
		else
		{
			return KMJNLIMMCED[AKNELONELJK_Difficulty];
		}
	}

	// // RVA: 0xDA135C Offset: 0xDA135C VA: 0xDA135C
	public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH)
	{
		if (!OHJFBLFELNK.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		return OHJFBLFELNK[LJNAKDMILMC];
	}

	// // RVA: 0xDA1420 Offset: 0xDA1420 VA: 0xDA1420
	public LDDDBPNGGIN_Game()
    {
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		KGHLOJNCFDO_ComboBonus = new List<JANMKFAKHIC_ComboBonus>(30);
		PDNEMDIEGFB_JudgeCoef = new List<int>(5);
		HPEFFMGGIBC_Spn = new List<KLJCBKMHKNK>();
		JKPKJKFJDGL_Progress = new List<int>(25);
		PIBHLAMOJNH = new List<int>(25);
		EKONPEGLAND_PrsSt = new List<int>();
		ILIEHCECHOA_PrsEd = new List<int>();
		NPNCNFKCIAE_RelSt = new List<int>();
		HODKHINFHGH_RelEd = new List<int>();
		BFDLLHNGICE_TapSt = new List<int>();
		ICNFEDCCODF_TapEd = new List<int>();
		AOFKIBFPAOD_SFlkSt = new List<int>();
		FDLBHEMAOLC_SFlkEd = new List<int>();
		MNGGGOOCJBM_SFlkSt = new List<int>();
		BLEDLGDGBHI_SFlkEd = new List<int>();
		PLGLPDGAADE_LFlkSt = new List<int>();
		IFHAPIJOCOJ_LFlkEd = new List<int>();
		DDLNCIOPBBB_SlRelSt = new List<int>();
		DDGNKEJKJCK_SlRelEd = new List<int>();
		KDGGKFOAGAE_SlFlkSt = new List<int>();
		FBKOFEHDENI_SlFlkEd = new List<int>();
		KBOIDPDGCLA_PasSt = new List<int>();
		GGAMKBLHGGI_PasEd = new List<int>();
		OBLDNPMODOM_SSta = new List<int>(25);
		COKBDFIMOPM_FSta = new List<int>(25);
		OHNJBOFLCOL_DMis = new List<int>(25);
		HHCDCEOJCIH_DBad = new List<int>(25);
		IMIMFIKCFMK_Heal = new List<int>(25);
		FIDHHBBINNB_Uc = new List<int>(25);
		CAIAODFECPC = new List<int>(25);
		KGJDEFCEEAB = new List<int>(25);
		PLMFEFIIBFL = new List<int>(25);
		BGKMMAGPAMJ = new List<int>(25);
		MPADAMHJBKK = new List<int>(25);
		HLKHOFPAOMK_VIn = new List<int>(25);
		HLLJIICKNIP_VAw = new List<int>(25);
		FENOHOEIJOE_VMax = new List<int>(25);
		LJPKLMJPLAC_DIn = new List<int>(25);
		MALHPBKPIDE_SdIn = new List<int>(25);
		GEFODCKCCBK = new List<int>(25);
		ELLLGOHHICG = new List<int>(25);
		IHMOHBMPMLO = new List<int>(25);
		GJDCMCFCIKD = new List<int>(25);
		IIDJCNEOLAL = new List<int>(25);
		CPNJJKDKNOO_FPt = new List<int>(5);
		EONACOOGKCA_BPt = new List<int>(5);
		EDCJLGMBGCH_BCb = new List<int>(12);
		DFEAPKGAGMN_BHit = new List<int>(12);
		LLDJIAKLOGC_RarMltMax = new List<sbyte>(6);
		FKLCEJNHKMN_RarLvMax = new List<sbyte>(6);
		ODEBNEPEDLN = new List<byte[]>();
		ALPMOLDJJKL_RarFeedMltMax = new List<sbyte>(12);
		PNDCOGFIGJO_RarFeedLvMax = new List<sbyte>(12);
		HFHMMOMMFON = new List<byte[]>(12);
		JJBJKENKAJP_ClrRarCoef = new List<int>(5);
		PNEMPHGJLKG_LuckCoef0 = FBGGEFFJJHB;
		NPEECLODIKB_LuckCoef1 = FBGGEFFJJHB;
		JHPPLIGJFPI = new List<sbyte>(8);
		KDIJDAKMODE = new List<int>(5);
		AJBKGOPDGFI = new List<int>(5);
		GEDEIGJKMGI = new Dictionary<int, byte[]>();
		DOAAGIMJOMM = new List<int>(5);
		KMJNLIMMCED = new List<int>(5);
		OHJFBLFELNK = new Dictionary<string, int>();
		LMHMIIKCGPE = 49;
    }

	// // RVA: 0xDA1C50 Offset: 0xDA1C50 VA: 0xDA1C50 Slot: 8
	protected override void KMBPACJNEOF()
    {
		FBGGEFFJJHB = (int)(Utility.GetCurrentUnixTime() ^ 0x48f8c5);
		KGHLOJNCFDO_ComboBonus.Clear();
		PDNEMDIEGFB_JudgeCoef.Clear();
		HPEFFMGGIBC_Spn.Clear();
		EKONPEGLAND_PrsSt.Clear();
		ILIEHCECHOA_PrsEd.Clear();
		NPNCNFKCIAE_RelSt.Clear();
		HODKHINFHGH_RelEd.Clear();
		BFDLLHNGICE_TapSt.Clear();
		ICNFEDCCODF_TapEd.Clear();
		AOFKIBFPAOD_SFlkSt.Clear();
		FDLBHEMAOLC_SFlkEd.Clear();
		MNGGGOOCJBM_SFlkSt.Clear();
		BLEDLGDGBHI_SFlkEd.Clear();
		PLGLPDGAADE_LFlkSt.Clear();
		IFHAPIJOCOJ_LFlkEd.Clear();
		DDLNCIOPBBB_SlRelSt.Clear();
		DDGNKEJKJCK_SlRelEd.Clear();
		KDGGKFOAGAE_SlFlkSt.Clear();
		FBKOFEHDENI_SlFlkEd.Clear();
		KBOIDPDGCLA_PasSt.Clear();
		GGAMKBLHGGI_PasEd.Clear();
		OBLDNPMODOM_SSta.Clear();
		COKBDFIMOPM_FSta.Clear();
		OHNJBOFLCOL_DMis.Clear();
		HHCDCEOJCIH_DBad.Clear();
		IMIMFIKCFMK_Heal.Clear();
		FIDHHBBINNB_Uc.Clear();
		CAIAODFECPC.Clear();
		KGJDEFCEEAB.Clear();
		PLMFEFIIBFL.Clear();
		BGKMMAGPAMJ.Clear();
		MPADAMHJBKK.Clear();
		HLKHOFPAOMK_VIn.Clear();
		HLLJIICKNIP_VAw.Clear();
		FENOHOEIJOE_VMax.Clear();
		LJPKLMJPLAC_DIn.Clear();
		MALHPBKPIDE_SdIn.Clear();
		GEFODCKCCBK.Clear();
		ELLLGOHHICG.Clear();
		IHMOHBMPMLO.Clear();
		GJDCMCFCIKD.Clear();
		IIDJCNEOLAL.Clear();
		CPNJJKDKNOO_FPt.Clear();
		EONACOOGKCA_BPt.Clear();
		EDCJLGMBGCH_BCb.Clear();
		DFEAPKGAGMN_BHit.Clear();
		LECAOCJCEKF_FCoeff0 = 0x2710;
		IHIONKFAAED_FCoeff1 = 0x32;
		HHPJIALEPEE_FCoeff2 = 0xc8;
		BCCKJLPNJJM_FCoeff3 = 0xc8;
		LLDJIAKLOGC_RarMltMax.Clear();
		CIFKMCKFMOA_FCoeff4 = 1000;
		FKLCEJNHKMN_RarLvMax.Clear();
		ODEBNEPEDLN.Clear();
		JJBJKENKAJP_ClrRarCoef.Clear();
		ALPMOLDJJKL_RarFeedMltMax.Clear();
		PNDCOGFIGJO_RarFeedLvMax.Clear();
		HFHMMOMMFON.Clear();
		JHPPLIGJFPI.Clear();
		KDIJDAKMODE.Clear();
		PNEMPHGJLKG_LuckCoef0 = FBGGEFFJJHB;
		NPEECLODIKB_LuckCoef1 = FBGGEFFJJHB ^ 10;
		AJBKGOPDGFI.Clear();
		GEDEIGJKMGI.Clear();
		DOAAGIMJOMM.Clear();
		KMJNLIMMCED.Clear();
		OHJFBLFELNK.Clear();
    }

	// // RVA: 0xDA2768 Offset: 0xDA2768 VA: 0xDA2768 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
    {
		IPDBLJMFKHL reader = IPDBLJMFKHL.HEGEKFMJNCC(DBBGALAPFGC);
		{
			uint[] array = reader.BEHEPILDEGG;
			KGHLOJNCFDO_ComboBonus.Clear();
			for (int i = 0; i < array.Length / 2; i++)
			{
				JANMKFAKHIC_ComboBonus data = new JANMKFAKHIC_ComboBonus();
				data.ADKDHKMPMHP = (int)array[i * 2];
				data.DHIPGHBJLIL = (int)array[i * 2 + 1];
				KGHLOJNCFDO_ComboBonus.Add(data);
			}
		}
		{
			PDNEMDIEGFB_JudgeCoef.Clear();
			uint[] array = reader.DHMKKDEKJID;
			for(int i = 0; i < array.Length; i++)
			{
				PDNEMDIEGFB_JudgeCoef.Add((int)array[i]);
			}
		}
		JKPKJKFJDGL_Progress.Clear();
		PIBHLAMOJNH.Clear();
		{
			uint[] array1 = reader.GPCCCPHPDNL;
			uint[] array2 = reader.BOFDLPNBGOJ;
			for(int i = 0;i < array1.Length; i++)
			{
				JKPKJKFJDGL_Progress.Add((int)array1[i]);
				PIBHLAMOJNH.Add((int)array2[i]);
			}
		}
		{
			BOAKDBGHGPM src = reader.ELPCGDPJBGB;
			{
				int[] array = src.EBIFBMEKEIL;
				for(int i = 0; i< array.Length; i++)
				{
					BFDLLHNGICE_TapSt.Add(array[i]);
				}
			}
			{
				int[] array = src.OCLBNLOCOPC;
				for (int i = 0; i < array.Length; i++)
				{
					ICNFEDCCODF_TapEd.Add(array[i]);
				}
			}
			{
				int[] array = src.BGKIIFCGOLI;
				for (int i = 0; i < array.Length; i++)
				{
					NPNCNFKCIAE_RelSt.Add(array[i]);
				}
			}
			{
				int[] array = src.AFFLGPAJMHC;
				for (int i = 0; i < array.Length; i++)
				{
					HODKHINFHGH_RelEd.Add(array[i]);
				}
			}
			{
				int[] array = src.NMALAMICDGP;
				for (int i = 0; i < array.Length; i++)
				{
					EKONPEGLAND_PrsSt.Add(array[i]);
				}
			}
			{
				int[] array = src.KNJJPDDBKBA;
				for (int i = 0; i < array.Length; i++)
				{
					ILIEHCECHOA_PrsEd.Add(array[i]);
				}
			}
			{
				int[] array = src.CDNKGPHFIHI;
				for (int i = 0; i < array.Length; i++)
				{
					AOFKIBFPAOD_SFlkSt.Add(array[i]);
				}
			}
			{
				int[] array = src.HILOBIHECNN;
				for (int i = 0; i < array.Length; i++)
				{
					FDLBHEMAOLC_SFlkEd.Add(array[i]);
				}
			}
			{
				int[] array = src.CDNKGPHFIHI;
				for (int i = 0; i < array.Length; i++)
				{
					MNGGGOOCJBM_SFlkSt.Add(array[i]);
				}
			}
			{
				int[] array = src.HILOBIHECNN;
				for (int i = 0; i < array.Length; i++)
				{
					BLEDLGDGBHI_SFlkEd.Add(array[i]);
				}
			}
			{
				int[] array = src.DMFAMLPFNPO;
				for (int i = 0; i < array.Length; i++)
				{
					PLGLPDGAADE_LFlkSt.Add(array[i]);
				}
			}
			{
				int[] array = src.JPJMMIAFCEO;
				for (int i = 0; i < array.Length; i++)
				{
					IFHAPIJOCOJ_LFlkEd.Add(array[i]);
				}
			}
			{
				int[] array = src.NLNNFIEAAPC;
				for (int i = 0; i < array.Length; i++)
				{
					DDLNCIOPBBB_SlRelSt.Add(array[i]);
				}
			}
			{
				int[] array = src.KHBEKNAIGEH;
				for (int i = 0; i < array.Length; i++)
				{
					DDGNKEJKJCK_SlRelEd.Add(array[i]);
				}
			}
			{
				int[] array = src.PHFNPONOGMK;
				for (int i = 0; i < array.Length; i++)
				{
					KDGGKFOAGAE_SlFlkSt.Add(array[i]);
				}
			}
			{
				int[] array = src.JECMJBFGMCA;
				for (int i = 0; i < array.Length; i++)
				{
					FBKOFEHDENI_SlFlkEd.Add(array[i]);
				}
			}
			{
				int[] array = src.AJKDHAADIIP;
				for (int i = 0; i < array.Length; i++)
				{
					KBOIDPDGCLA_PasSt.Add(array[i]);
				}
			}
			{
				int[] array = src.NBMPDOGPOPN;
				for (int i = 0; i < array.Length; i++)
				{
					GGAMKBLHGGI_PasEd.Add(array[i]);
				}
			}
		}
		{
			uint[] array = reader.KNDKMLHAONN;
			for(int i = 0; i < array.Length; i++)
			{
				OBLDNPMODOM_SSta.Add((int)array[i]);
			}
		}
		{
			uint[] array1 = reader.AEJPNAKLKED;
			uint[] array2 = reader.BPGOIALMEBD;
			for (int i = 0; i < array1.Length; i++)
			{
				COKBDFIMOPM_FSta.Add((int)array1[i]);
				CAIAODFECPC.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.NBBLIKLDGKL;
			uint[] array2 = reader.APGFIDEIALK;
			for (int i = 0; i < array1.Length; i++)
			{
				OHNJBOFLCOL_DMis.Add((int)array1[i]);
				KGJDEFCEEAB.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.FEKLEAOHIFG;
			uint[] array2 = reader.DPKOBEEOBFN;
			for (int i = 0; i < array1.Length; i++)
			{
				HHCDCEOJCIH_DBad.Add((int)array1[i]);
				PLMFEFIIBFL.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.APJBBOHHFNE;
			uint[] array2 = reader.CPGHODANBMF;
			for (int i = 0; i < array1.Length; i++)
			{
				IMIMFIKCFMK_Heal.Add((int)array1[i]);
				BGKMMAGPAMJ.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.ACGLMKEBMDL;
			uint[] array2 = reader.KDLGMEBCBAC;
			for (int i = 0; i < array1.Length; i++)
			{
				FIDHHBBINNB_Uc.Add((int)array1[i]);
				MPADAMHJBKK.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.JGEIIONMJMI;
			uint[] array2 = reader.DOAFFAGEHOM;
			for (int i = 0; i < array1.Length; i++)
			{
				HLKHOFPAOMK_VIn.Add((int)array1[i]);
				GEFODCKCCBK.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.CMENIBCJJNF;
			uint[] array2 = reader.BIHJCIGKMBA;
			for (int i = 0; i < array1.Length; i++)
			{
				HLLJIICKNIP_VAw.Add((int)array1[i]);
				ELLLGOHHICG.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.KMFHHOANPFH;
			uint[] array2 = reader.OOBOCLOFPBF;
			for (int i = 0; i < array1.Length; i++)
			{
				FENOHOEIJOE_VMax.Add((int)array1[i]);
				IHMOHBMPMLO.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.EHODALENBEL;
			uint[] array2 = reader.DKAIOCGKJLO;
			for (int i = 0; i < array1.Length; i++)
			{
				LJPKLMJPLAC_DIn.Add((int)array1[i]);
				GJDCMCFCIKD.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.ALJIHHGHCOG;
			uint[] array2 = reader.OIDAMEGDNOF;
			for (int i = 0; i < array1.Length; i++)
			{
				MALHPBKPIDE_SdIn.Add((int)array1[i]);
				IIDJCNEOLAL.Add((int)array2[i]);
			}
		}
		{
			uint[] array = reader.DHJMHKKGIGE;
			for(int i = 0; i < array.Length; i++)
			{
				JJBJKENKAJP_ClrRarCoef.Add((int)array[i]);
			}
		}
		{
			uint[] array = reader.EGAEODOCBEL;
			for (int i = 0; i < array.Length; i++)
			{
				LLDJIAKLOGC_RarMltMax.Add((sbyte)array[i]);
			}
		}
		{
			uint[] array = reader.EDKOLGMBOAB;
			for (int i = 0; i < array.Length; i++)
			{
				ALPMOLDJJKL_RarFeedMltMax.Add((sbyte)array[i]);
			}
		}
		{
			uint[] array = reader.IFCIFFKIGAM;
			for (int i = 0; i < array.Length; i++)
			{
				PNDCOGFIGJO_RarFeedLvMax.Add((sbyte)array[i]);
				byte[] b = new byte[1];
				b[0] = 0;
				for(int j = 0; j < array[i]; j++)
				{
					b[j >> 3] |= (byte)(1 << (j & 7));
				}
				HFHMMOMMFON.Add(b);
			}
		}
		{
			uint[] array = reader.KGDFDGPBEBO;
			for (int i = 0; i < array.Length; i++)
			{
				FKLCEJNHKMN_RarLvMax.Add((sbyte)array[i]);
				byte[] b = new byte[15];
				for(int j = 0; j < 15; j++)
					b[j] = 0;
				for (int j = 0; j < array[i]; j++)
				{
					b[j >> 3] |= (byte)(1 << (j & 7));
				}
				ODEBNEPEDLN.Add(b);
			}
		}
		{
			uint[] array = reader.NNCLBDOAAJE;
			for (int i = 0; i < array.Length; i++)
			{
				JHPPLIGJFPI.Add((sbyte)array[i]);
			}
		}
		{
			int[] array = reader.CDGLFHLKOKF;
			for (int i = 0; i < array.Length; i++)
			{
				KDIJDAKMODE.Add(array[i]);
			}
		}
		{
			int[] array = reader.HJCDMCCIMPI;
			for (int i = 0; i < array.Length; i++)
			{
				AJBKGOPDGFI.Add(array[i]);
			}
		}
		{
			int[] array = reader.IMBPPBDMDKB;
			for (int i = 0; i < array.Length; i++)
			{
				if (i < array.Length / 2)
				{
					DOAAGIMJOMM.Add(array[i]);
				}
				else
				{
					KMJNLIMMCED.Add(array[i]);
				}
			}
		}
		IMOBCGKLJJG(reader);
		GGMGOGCBHDE(reader);

		{
			int[] array = reader.BLPPPLONCGI;
			PNEMPHGJLKG_LuckCoef0 = FBGGEFFJJHB ^ array[0];
			NPEECLODIKB_LuckCoef1 = FBGGEFFJJHB ^ (array[1] == 0 ? 1 : array[1]);
		}
		{
			JMELOFNPNBJ[] array = reader.BHGDNGHDDAC;
			for(int i = 0; i < array.Length; i++)
			{
				OHJFBLFELNK[array[i].LJNAKDMILMC] = array[i].JBGEEPFKIGG;
			}
		}
		return true;
    }

	// // RVA: 0xDA5A70 Offset: 0xDA5A70 VA: 0xDA5A70 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(100, "Json Load");
		return true;
	}

	// // RVA: 0xDA4E98 Offset: 0xDA4E98 VA: 0xDA4E98
	private bool IMOBCGKLJJG(IPDBLJMFKHL GKNHGLCNBIJ)
	{
		INFBDFJLCPJ data = GKNHGLCNBIJ.GIAGNPBBPAD;
		{
			int[] array = data.OOKGKIONGJF;
			for(int i = 0;i < array.Length; i++)
			{
				CPNJJKDKNOO_FPt.Add(array[i]);
			}
		}
		List<int> l = new List<int>();
		{
			uint[] array = data.PGLELFPNOPI;
			for (int i = 0; i < array.Length; i++)
			{
				l.Add((int)array[i]);
			}
			LECAOCJCEKF_FCoeff0 = l[0];
			IHIONKFAAED_FCoeff1 = l[1];
			HHPJIALEPEE_FCoeff2 = l[2];
			BCCKJLPNJJM_FCoeff3 = l[3];
			CIFKMCKFMOA_FCoeff4 = l[4];
		}
		{
			uint[] array = data.LHICAPGLBOF;
			for (int i = 0; i < array.Length; i++)
			{
				EONACOOGKCA_BPt.Add((int)array[i]);
			}
		}
		l.Clear();
		{
			uint[] array = data.LCFIHFMFICM;
			for (int i = 0; i < array.Length; i++)
			{
				l.Add((int)array[i]);
			}
			FLPKPBECPOD_BCoeff0 = l[0];
			NELJPDJEKNM_BCoeff1 = l[1];
			MPAMBMKFCKK_BCoeff2 = l[2];
			IJDBNKCLGIC_BCoeff3 = l[3];
			GLMKBFEHPLA_BCoeff4 = l[4];
			LPDACKNMGNK_BCoeff5 = l[5];
		}
		EDCJLGMBGCH_BCb.Clear();
		{
			uint[] array = data.PPAOHBBEPKK;
			for (int i = 0; i < array.Length; i++)
			{
				EDCJLGMBGCH_BCb.Add((int)array[i]);
			}
		}
		DFEAPKGAGMN_BHit.Clear();
		{
			int[] array = data.BABAGPKAONA;
			for (int i = 0; i < array.Length; i++)
			{
				DFEAPKGAGMN_BHit.Add(array[i]);
			}
		}
		return true;
	}

	// // RVA: 0xDA6DDC Offset: 0xDA6DDC VA: 0xDA6DDC
	// private bool IMOBCGKLJJG(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE, ref bool NGJDHLGMHMH) { }

	// // RVA: 0xDA5614 Offset: 0xDA5614 VA: 0xDA5614
	private bool GGMGOGCBHDE(IPDBLJMFKHL GKNHGLCNBIJ)
	{
		KHDOHBDIJOC[] array_data = GKNHGLCNBIJ.BEKOPEJPACJ;
		for(int i = 0; i < array_data.Length; i++)
		{
			KLJCBKMHKNK data = new KLJCBKMHKNK();
			data.PPFNGGCBJKC_Id = (int)array_data[i].PPFNGGCBJKC;
			for(int j = 0; j < array_data[i].EAOPGELMIHB.Length; j++)
			{
				EGLJKICMCPG data2 = new EGLJKICMCPG();
				data2.PHGLKBPLFDH_RMax = (short)array_data[i].EAOPGELMIHB[j].FBHMAIEDEGJ;
				data2.GKPPCFMBANO_NMax = (short)array_data[i].EAOPGELMIHB[j].JPHMLLIBLGG;
				data2.MPPANPOOIIB_NMin = (short)array_data[i].EAOPGELMIHB[j].ABNMKJGNKFO;
				data2.DAPGDCPDCNA_Pri = (short)array_data[i].EAOPGELMIHB[j].KPECMLFDLOI;
				data2.MDDMKHJNCBO_RMin = new short[array_data[i].EAOPGELMIHB[j].LEJHEGIMCCL.Length];
				for(int k = 0; k < array_data[i].EAOPGELMIHB[j].LEJHEGIMCCL.Length; k++)
				{
					data2.MDDMKHJNCBO_RMin[k] = (short)array_data[i].EAOPGELMIHB[j].LEJHEGIMCCL[k];
				}
				data.CDENCMNHNGA.Add(data2);
			}
			HPEFFMGGIBC_Spn.Add(data);
		}
		return true;
	}

	// // RVA: 0xDA7398 Offset: 0xDA7398 VA: 0xDA7398
	// private bool GGMGOGCBHDE(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE, ref bool NGJDHLGMHMH) { }

	// // RVA: 0xDA7A7C Offset: 0xDA7A7C VA: 0xDA7A7C
	// private uint DIGCEJDMJBN(List<int> NNDGIAEFMOG) { }

	// // RVA: 0xDA7B3C Offset: 0xDA7B3C VA: 0xDA7B3C
	// private uint DIGCEJDMJBN(List<sbyte> NNDGIAEFMOG) { }

	// // RVA: 0xDA7BFC Offset: 0xDA7BFC VA: 0xDA7BFC Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(100, "CAOGDCBPBAN");
		return 0;
	}
}

public class JANMKFAKHIC_ComboBonus
{
	public int ADKDHKMPMHP; // 0x8
	public int DHIPGHBJLIL; // 0xC
}


public class EGLJKICMCPG
{
	public short PHGLKBPLFDH_RMax; // 0x8
	public short GKPPCFMBANO_NMax; // 0xA
	public short MPPANPOOIIB_NMin; // 0xC
	public short DAPGDCPDCNA_Pri; // 0xE
	public short[] MDDMKHJNCBO_RMin; // 0x10

	// RVA: 0x1C4FDBC Offset: 0x1C4FDBC VA: 0x1C4FDBC
	// public short JNNKKPNGPAA(SpecialNoteAttribute.Type FJFCNGNGIBN) { }
}

public class KLJCBKMHKNK
{
	public List<EGLJKICMCPG> CDENCMNHNGA = new List<EGLJKICMCPG>(); // 0x8
	public int PPFNGGCBJKC_Id; // 0xC

	// RVA: 0x111C678 Offset: 0x111C678 VA: 0x111C678
	// public EGLJKICMCPG GCINIJEMHFK(KLJCBKMHKNK.HHMPIIILOLD CNDDKMJAIBG) { }
}
