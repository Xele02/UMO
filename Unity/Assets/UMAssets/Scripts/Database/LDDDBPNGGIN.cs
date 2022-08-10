using System.Collections.Generic;
using XeSys;

public class LDDDBPNGGIN { }
public class LDDDBPNGGIN_Game : DIHHCBACKGG
{
	private const int NADNGLNALCK = 30;
	private const int NHCGFMDPPPA = 5;
	private const int NAJMGFDOCMH = 25;
	public static int EDGOFPJDPPI = -1; // 0x0
	private int FBGGEFFJJHB = 0x1aa9f1; // 0x20
	public int LECAOCJCEKF; // 0xAC
	public int IHIONKFAAED; // 0xB0
	public int HHPJIALEPEE; // 0xB4
	public int BCCKJLPNJJM; // 0xB8
	public int CIFKMCKFMOA; // 0xBC
	public int FLPKPBECPOD; // 0xC4
	public int NELJPDJEKNM; // 0xC8
	public int MPAMBMKFCKK; // 0xCC
	public int IJDBNKCLGIC; // 0xD0
	public int GLMKBFEHPLA; // 0xD4
	public int LPDACKNMGNK; // 0xD8
	private List<int> EDCJLGMBGCH; // 0xDC
	private List<int> DFEAPKGAGMN; // 0xE0
	private Dictionary<int, byte[]> GEDEIGJKMGI; // 0xFC
	public List<int> HLKHOFPAOMK; // 0x108
	public List<int> HLLJIICKNIP; // 0x10C
	public List<int> FENOHOEIJOE; // 0x110
	public List<int> LJPKLMJPLAC; // 0x114
	public List<int> MALHPBKPIDE; // 0x118
	public List<int> GEFODCKCCBK; // 0x11C
	public List<int> ELLLGOHHICG; // 0x120
	public List<int> IHMOHBMPMLO; // 0x124
	public List<int> GJDCMCFCIKD; // 0x128
	public List<int> IIDJCNEOLAL; // 0x12C
	public List<int> JJBJKENKAJP; // 0x130
	private List<KLJCBKMHKNK> HPEFFMGGIBC; // 0x134
	private int PNEMPHGJLKG; // 0x138
	private int NPEECLODIKB; // 0x13C
	public List<sbyte> JHPPLIGJFPI; // 0x140
	private List<int> DOAAGIMJOMM; // 0x144
	private List<int> KMJNLIMMCED; // 0x148

	public List<JANMKFAKHIC_ComboBonus> KGHLOJNCFDO_ComboBonus { get; private set; } // 0x24 KGEFOIBPACG KHDCLBNDLPL IKNIJILKKCC
	public List<int> PDNEMDIEGFB { get; private set; } // 0x28 JLOJENKKFFK MNANHEAKBBM BAKOHDPHEDO
	private List<int> JKPKJKFJDGL { get; set; } // 0x2C OJIPOCNKJBD KDPCOHLOEPI EOHDGCNIFDD
	private List<int> OBLDNPMODOM { get; set; } // 0x30 NPILHIHHEAI BBNCEDBIOPA BNDHBJKKLDJ
	private List<int> COKBDFIMOPM { get; set; } // 0x34 LGJFNFMPHFC CFGNDJEJLBG MENCEALDKFL
	private List<int> OHNJBOFLCOL { get; set; } // 0x38 JDBEGBDCANJ PCAHFKBLGBJ JFAEDDLHHHL
	private List<int> HHCDCEOJCIH { get; set; } // 0x3C DONDJBIKOCG EKPHGCGNCGI LLJMJOEFGLP
	private List<int> IMIMFIKCFMK { get; set; } // 0x40 DJAGACPHFMG JJLBDIGMIFG DJPJFOHDGPL
	private List<int> PIBHLAMOJNH { get; set; } // 0x44 NOBIPOAKIBM JFMJEIEAFMA MPKGHIGNGDK
	private List<int> CAIAODFECPC { get; set; } // 0x48 NDDBGDLPCDF LJINEDABLGC LEOCPDDOCKJ
	private List<int> KGJDEFCEEAB { get; set; } // 0x4C PEDJMMGILOO JDDGFDDHIOE NPJPJJNFPIF
	private List<int> PLMFEFIIBFL { get; set; } // 0x50 JFPBFCMFLFN NCNPOOEDFKJ LBMIPPEIKIM
	private List<int> BGKMMAGPAMJ { get; set; } // 0x54 NHPCFCHGJHA KBBMCHCEDDL DGBENIFCADE
	public List<int> EKONPEGLAND { get; private set; } // 0x58 HIKHMNLINHK GHKKLEMEFNC KLOMFFIIOIJ
	public List<int> ILIEHCECHOA { get; private set; } // 0x5C DDHOFNKHJAC NJMOEBAMNBD BFIDKDHLDNF
	public List<int> NPNCNFKCIAE { get; private set; } // 0x60 PBCPNONMGMK IJOIFPCKPCC PMBDANMIMGM
	public List<int> HODKHINFHGH { get; private set; } // 0x64 PIGNMLCJAON AMJLFHNFLCL CGABGDKCKNC
	public List<int> BFDLLHNGICE { get; private set; } // 0x68 KEGKFMIDNNC BCBGKEHFEGM GBJBHMEPCKB
	public List<int> ICNFEDCCODF { get; private set; } // 0x6C LHKGBMJBDIG FPIBEOILGPI CNBHKJCCLMG
	public List<int> AOFKIBFPAOD { get; private set; } // 0x70 KKAJIHKPLAJ NKDPBBMOEDI HCENODFLLKA
	public List<int> FDLBHEMAOLC { get; private set; } // 0x74 LNIMHIEONAP FEIIGKHOPPO AGLCDKODAAM
	public List<int> MNGGGOOCJBM { get; private set; } // 0x78 KCIDHEBAFNO HJIODPHOAEM PPKGCGHCGJE
	public List<int> BLEDLGDGBHI { get; private set; } // 0x7C OIFDPNACLBO DPLGCCCGMEA DLPDCMOMMGF
	public List<int> PLGLPDGAADE { get; private set; } // 0x80 ONEDEHPKJBF BJCAPIBFMMM AKHPFPLDNJB
	public List<int> IFHAPIJOCOJ { get; private set; } // 0x84 BELIANLLCIA DFLGBDDJJEF FJIGECMBDDO
	public List<int> DDLNCIOPBBB { get; private set; } // 0x88 AFMBPDOGPJB NMIIDEACMOG GNPCOIKJPIG
	public List<int> DDGNKEJKJCK { get; private set; } // 0x8C ANDKJHBACIH BEPFOFDMCFJ FGACFCONAAN
	public List<int> KDGGKFOAGAE { get; private set; } // 0x90 DOPBAMLOCIO JEBHDMKBJFE EDAIDBMOENF
	public List<int> FBKOFEHDENI { get; private set; } // 0x94 LBGBPNNFMBN DKBFIEMFMOL PCNMCFKJAKK
	public List<int> KBOIDPDGCLA { get; private set; } // 0x98 IIBNBENEJLN CACNGONAKFC ACBFJKBJOFF
	public List<int> GGAMKBLHGGI { get; private set; } // 0x9C MMJCJMDBMAN NKHPAMBMGHH LNEJKJBKJAD
	private List<int> FIDHHBBINNB { get; set; } // 0xA0 DAGAJKBDICH KKMEKEPJKIN NLHFPGKEDAE
	private List<int> MPADAMHJBKK { get; set; } // 0xA4 FAALLDIADNK OHAIBAGEBPI LELJPMEAKCL
	public List<int> CPNJJKDKNOO { get; private set; } // 0xA8 DDFBBNIDJCC OHAGJJCHEHB HHICCPAOIDC
	public List<int> EONACOOGKCA { get; private set; } // 0xC0 NKENGKNNLBO PJPCHAFPLOL DHPBCABKIMB
	public List<sbyte> LLDJIAKLOGC { get; private set; } // 0xE4 AAPBDKJMMMC CPONLDIPHBC OAFDONJGICP
	public List<sbyte> FKLCEJNHKMN { get; private set; } // 0xE8 HOGHPJNPMMJ BGNDKMECEJE LKJEJJOLLGA
	public List<byte[]> ODEBNEPEDLN { get; private set; } // 0xEC BKECHPMBPEI GANOHDNGGFD JANPPDBPFKO
	public List<sbyte> ALPMOLDJJKL { get; private set; } // 0xF0 BDCNICMDOFN BPPEMPKMOBO ODKFFGPEKHH
	public List<sbyte> PNDCOGFIGJO { get; private set; } // 0xF4 EDJPHDKKKMN JGCAHAKFFMC ILHOJHCDDCI
	public List<byte[]> HFHMMOMMFON { get; private set; } // 0xF8 LIKKAOPIJPL HCEPMKIIAFM BELEAEECDBA
	public List<int> KDIJDAKMODE { get; private set; } // 0x100 LIIEMFJHMJG LKFIODIJCHM PKJMLBKLIGE
	public List<int> AJBKGOPDGFI { get; private set; } // 0x104 AFKBJPJLHIN DMAGCOAEFFH AFDEABEKAFG
	// public int JJIBDCAIBIO { get; set; } // CODJHFNCMMC 0xDA1000 IPLMEIKMCJB 0xDA1010
	// public int AMNBEMCJCHF { get; set; } // KEFFGJGHPIF 0xDA1020 HDOCBIIBDPG 0xDA1030
	public Dictionary<string, int> OHJFBLFELNK { get; private set; } // 0x14C KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	// // RVA: 0xDA0338 Offset: 0xDA0338 VA: 0xDA0338
	// public int ADBELGIDIEN(int ANAJIAENLNB, bool GIKLNODJKFK) { }

	// // RVA: 0xDA03C8 Offset: 0xDA03C8 VA: 0xDA03C8
	// public int MMLNFAJOPCB(int ANAJIAENLNB) { }

	// // RVA: 0xDA0448 Offset: 0xDA0448 VA: 0xDA0448
	public int HHEEPBJNAKA_GetEnergy(int ANAJIAENLNB, bool GIKLNODJKFK)
	{
		if (!GIKLNODJKFK)
			return COKBDFIMOPM[ANAJIAENLNB - 1];
		else
			return CAIAODFECPC[ANAJIAENLNB - 1];
	}

	// // RVA: 0xDA04D8 Offset: 0xDA04D8 VA: 0xDA04D8
	// public int AOGJFPLIOGB(int ANAJIAENLNB, bool GIKLNODJKFK) { }

	// // RVA: 0xDA0568 Offset: 0xDA0568 VA: 0xDA0568
	// public int GOLHPPFLJNF(int ANAJIAENLNB, bool GIKLNODJKFK) { }

	// // RVA: 0xDA05F8 Offset: 0xDA05F8 VA: 0xDA05F8
	// public int AFDONIMNHEJ(int ANAJIAENLNB, bool GIKLNODJKFK) { }

	// // RVA: 0xDA0688 Offset: 0xDA0688 VA: 0xDA0688
	// public int GFODAIJMBAH(int ANAJIAENLNB, bool GIKLNODJKFK) { }

	// // RVA: 0xDA0798 Offset: 0xDA0798 VA: 0xDA0798
	// public byte[] CEKGFNKJDCF(KOGHKIODHPA JEMMMJEJLNL, int JPIPENJGGDD, int AOPBAOJIOGO, int ILABPFOMEAG, int JKGFBFPIMGA, bool MCCIFLKCNKO) { }

	// // RVA: 0xDA0984 Offset: 0xDA0984 VA: 0xDA0984
	// public byte[] KLIGCACGHHN(KOGHKIODHPA JEMMMJEJLNL, int AOPBAOJIOGO, int ILABPFOMEAG, int JKGFBFPIMGA, bool MCCIFLKCNKO) { }

	// // RVA: 0xDA0B80 Offset: 0xDA0B80 VA: 0xDA0B80
	// public int FHHPNFAECCJ(int CKFNNECHOGG) { }

	// // RVA: 0xDA0C1C Offset: 0xDA0C1C VA: 0xDA0C1C
	// public int IKIGFABDFMB(int OBBGMJPIHIL) { }

	// // RVA: 0xDA0C28 Offset: 0xDA0C28 VA: 0xDA0C28
	// public int FHFLCJHEEPK(int OBBGMJPIHIL) { }

	// // RVA: 0xDA0C34 Offset: 0xDA0C34 VA: 0xDA0C34
	// private int GIIDKJMJLPP(List<int> NNDGIAEFMOG, int NANNGLGOFKH) { }

	// // RVA: 0xDA0B8C Offset: 0xDA0B8C VA: 0xDA0B8C
	// private int DEOPEBMHCLB(List<int> NNDGIAEFMOG, int NANNGLGOFKH) { }

	// // RVA: 0xDA0D38 Offset: 0xDA0D38 VA: 0xDA0D38
	// public KLJCBKMHKNK BBFNPHGDCOF(int PPFNGGCBJKC_Id) { }

	// // RVA: 0xDA08F4 Offset: 0xDA08F4 VA: 0xDA08F4
	// public int GENHLFPKOEE(int FBFLDFMFFOH, bool MCCIFLKCNKO) { }

	// // RVA: 0xDA0E5C Offset: 0xDA0E5C VA: 0xDA0E5C
	// public int LAGGGIEIPEG(int JKGFBFPIMGA, bool OBKCAELADKD, bool MCCIFLKCNKO) { }

	// // RVA: 0xDA0F2C Offset: 0xDA0F2C VA: 0xDA0F2C
	// public int GAJPHGOJAAB(int NIGMJFOLJBE, bool MCCIFLKCNKO) { }

	// // RVA: 0xDA0F40 Offset: 0xDA0F40 VA: 0xDA0F40
	// public byte[] DNMKPAKOJFA(int JKGFBFPIMGA, bool OBKCAELADKD, bool MCCIFLKCNKO) { }

	// // RVA: 0xDA1040 Offset: 0xDA1040 VA: 0xDA1040
	// public int NBIAKELCBLC(int MJBODMOLOBC, int HLOHIMEAPLH) { }

	// // RVA: 0xDA1120 Offset: 0xDA1120 VA: 0xDA1120
	// public static int NBIAKELCBLC(int MJBODMOLOBC, int HLOHIMEAPLH, int BAFFAONJPCE, int BDMLMGBLGPC) { }

	// // RVA: 0xDA1180 Offset: 0xDA1180 VA: 0xDA1180
	// public int GFIPALLLPMF(int PMKBJMHIFCM, int EILKGEADKGH) { }

	// // RVA: 0xDA12BC Offset: 0xDA12BC VA: 0xDA12BC
	// public int GAHIBKLEDBF(int AKNELONELJK, bool GIKLNODJKFK) { }

	// // RVA: 0xDA135C Offset: 0xDA135C VA: 0xDA135C
	// public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH) { }

	// // RVA: 0xDA1420 Offset: 0xDA1420 VA: 0xDA1420
	public LDDDBPNGGIN_Game()
    {
		JIKKNHIAEKG = "";
		LNIMEIMBCMF = false;
		KGHLOJNCFDO_ComboBonus = new List<JANMKFAKHIC_ComboBonus>(30);
		PDNEMDIEGFB = new List<int>(5);
		HPEFFMGGIBC = new List<KLJCBKMHKNK>();
		JKPKJKFJDGL = new List<int>(25);
		PIBHLAMOJNH = new List<int>(25);
		EKONPEGLAND = new List<int>();
		ILIEHCECHOA = new List<int>();
		NPNCNFKCIAE = new List<int>();
		HODKHINFHGH = new List<int>();
		BFDLLHNGICE = new List<int>();
		ICNFEDCCODF = new List<int>();
		AOFKIBFPAOD = new List<int>();
		FDLBHEMAOLC = new List<int>();
		MNGGGOOCJBM = new List<int>();
		BLEDLGDGBHI = new List<int>();
		PLGLPDGAADE = new List<int>();
		IFHAPIJOCOJ = new List<int>();
		DDLNCIOPBBB = new List<int>();
		DDGNKEJKJCK = new List<int>();
		KDGGKFOAGAE = new List<int>();
		FBKOFEHDENI = new List<int>();
		KBOIDPDGCLA = new List<int>();
		GGAMKBLHGGI = new List<int>();
		OBLDNPMODOM = new List<int>(25);
		COKBDFIMOPM = new List<int>(25);
		OHNJBOFLCOL = new List<int>(25);
		HHCDCEOJCIH = new List<int>(25);
		IMIMFIKCFMK = new List<int>(25);
		FIDHHBBINNB = new List<int>(25);
		CAIAODFECPC = new List<int>(25);
		KGJDEFCEEAB = new List<int>(25);
		PLMFEFIIBFL = new List<int>(25);
		BGKMMAGPAMJ = new List<int>(25);
		MPADAMHJBKK = new List<int>(25);
		HLKHOFPAOMK = new List<int>(25);
		HLLJIICKNIP = new List<int>(25);
		FENOHOEIJOE = new List<int>(25);
		LJPKLMJPLAC = new List<int>(25);
		MALHPBKPIDE = new List<int>(25);
		GEFODCKCCBK = new List<int>(25);
		ELLLGOHHICG = new List<int>(25);
		IHMOHBMPMLO = new List<int>(25);
		GJDCMCFCIKD = new List<int>(25);
		IIDJCNEOLAL = new List<int>(25);
		CPNJJKDKNOO = new List<int>(5);
		EONACOOGKCA = new List<int>(5);
		EDCJLGMBGCH = new List<int>(12);
		DFEAPKGAGMN = new List<int>(12);
		LLDJIAKLOGC = new List<sbyte>(6);
		FKLCEJNHKMN = new List<sbyte>(6);
		ODEBNEPEDLN = new List<byte[]>();
		ALPMOLDJJKL = new List<sbyte>(12);
		PNDCOGFIGJO = new List<sbyte>(12);
		HFHMMOMMFON = new List<byte[]>(12);
		JJBJKENKAJP = new List<int>(5);
		PNEMPHGJLKG = FBGGEFFJJHB;
		NPEECLODIKB = FBGGEFFJJHB;
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
		PDNEMDIEGFB.Clear();
		HPEFFMGGIBC.Clear();
		EKONPEGLAND.Clear();
		ILIEHCECHOA.Clear();
		NPNCNFKCIAE.Clear();
		HODKHINFHGH.Clear();
		BFDLLHNGICE.Clear();
		ICNFEDCCODF.Clear();
		AOFKIBFPAOD.Clear();
		FDLBHEMAOLC.Clear();
		MNGGGOOCJBM.Clear();
		BLEDLGDGBHI.Clear();
		PLGLPDGAADE.Clear();
		IFHAPIJOCOJ.Clear();
		DDLNCIOPBBB.Clear();
		DDGNKEJKJCK.Clear();
		KDGGKFOAGAE.Clear();
		FBKOFEHDENI.Clear();
		KBOIDPDGCLA.Clear();
		GGAMKBLHGGI.Clear();
		OBLDNPMODOM.Clear();
		COKBDFIMOPM.Clear();
		OHNJBOFLCOL.Clear();
		HHCDCEOJCIH.Clear();
		IMIMFIKCFMK.Clear();
		FIDHHBBINNB.Clear();
		CAIAODFECPC.Clear();
		KGJDEFCEEAB.Clear();
		PLMFEFIIBFL.Clear();
		BGKMMAGPAMJ.Clear();
		MPADAMHJBKK.Clear();
		HLKHOFPAOMK.Clear();
		HLLJIICKNIP.Clear();
		FENOHOEIJOE.Clear();
		LJPKLMJPLAC.Clear();
		MALHPBKPIDE.Clear();
		GEFODCKCCBK.Clear();
		ELLLGOHHICG.Clear();
		IHMOHBMPMLO.Clear();
		GJDCMCFCIKD.Clear();
		IIDJCNEOLAL.Clear();
		CPNJJKDKNOO.Clear();
		EONACOOGKCA.Clear();
		EDCJLGMBGCH.Clear();
		DFEAPKGAGMN.Clear();
		LECAOCJCEKF = 0x2710;
		IHIONKFAAED = 0x32;
		HHPJIALEPEE = 0xc8;
		BCCKJLPNJJM = 0xc8;
		LLDJIAKLOGC.Clear();
		CIFKMCKFMOA = 1000;
		FKLCEJNHKMN.Clear();
		ODEBNEPEDLN.Clear();
		JJBJKENKAJP.Clear();
		ALPMOLDJJKL.Clear();
		PNDCOGFIGJO.Clear();
		HFHMMOMMFON.Clear();
		JHPPLIGJFPI.Clear();
		KDIJDAKMODE.Clear();
		PNEMPHGJLKG = FBGGEFFJJHB;
		NPEECLODIKB = FBGGEFFJJHB ^ 10;
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
			PDNEMDIEGFB.Clear();
			uint[] array = reader.DHMKKDEKJID;
			for(int i = 0; i < array.Length; i++)
			{
				PDNEMDIEGFB.Add((int)array[i]);
			}
		}
		JKPKJKFJDGL.Clear();
		PIBHLAMOJNH.Clear();
		{
			uint[] array1 = reader.GPCCCPHPDNL;
			uint[] array2 = reader.BOFDLPNBGOJ;
			for(int i = 0;i < array1.Length; i++)
			{
				JKPKJKFJDGL.Add((int)array1[i]);
				PIBHLAMOJNH.Add((int)array2[i]);
			}
		}
		{
			BOAKDBGHGPM src = reader.ELPCGDPJBGB;
			{
				int[] array = src.EBIFBMEKEIL;
				for(int i = 0; i< array.Length; i++)
				{
					BFDLLHNGICE.Add(array[i]);
				}
			}
			{
				int[] array = src.OCLBNLOCOPC;
				for (int i = 0; i < array.Length; i++)
				{
					ICNFEDCCODF.Add(array[i]);
				}
			}
			{
				int[] array = src.BGKIIFCGOLI;
				for (int i = 0; i < array.Length; i++)
				{
					NPNCNFKCIAE.Add(array[i]);
				}
			}
			{
				int[] array = src.AFFLGPAJMHC;
				for (int i = 0; i < array.Length; i++)
				{
					HODKHINFHGH.Add(array[i]);
				}
			}
			{
				int[] array = src.NMALAMICDGP;
				for (int i = 0; i < array.Length; i++)
				{
					EKONPEGLAND.Add(array[i]);
				}
			}
			{
				int[] array = src.KNJJPDDBKBA;
				for (int i = 0; i < array.Length; i++)
				{
					ILIEHCECHOA.Add(array[i]);
				}
			}
			{
				int[] array = src.CDNKGPHFIHI;
				for (int i = 0; i < array.Length; i++)
				{
					AOFKIBFPAOD.Add(array[i]);
				}
			}
			{
				int[] array = src.HILOBIHECNN;
				for (int i = 0; i < array.Length; i++)
				{
					FDLBHEMAOLC.Add(array[i]);
				}
			}
			{
				int[] array = src.CDNKGPHFIHI;
				for (int i = 0; i < array.Length; i++)
				{
					MNGGGOOCJBM.Add(array[i]);
				}
			}
			{
				int[] array = src.HILOBIHECNN;
				for (int i = 0; i < array.Length; i++)
				{
					BLEDLGDGBHI.Add(array[i]);
				}
			}
			{
				int[] array = src.DMFAMLPFNPO;
				for (int i = 0; i < array.Length; i++)
				{
					PLGLPDGAADE.Add(array[i]);
				}
			}
			{
				int[] array = src.JPJMMIAFCEO;
				for (int i = 0; i < array.Length; i++)
				{
					IFHAPIJOCOJ.Add(array[i]);
				}
			}
			{
				int[] array = src.NLNNFIEAAPC;
				for (int i = 0; i < array.Length; i++)
				{
					DDLNCIOPBBB.Add(array[i]);
				}
			}
			{
				int[] array = src.KHBEKNAIGEH;
				for (int i = 0; i < array.Length; i++)
				{
					DDGNKEJKJCK.Add(array[i]);
				}
			}
			{
				int[] array = src.PHFNPONOGMK;
				for (int i = 0; i < array.Length; i++)
				{
					KDGGKFOAGAE.Add(array[i]);
				}
			}
			{
				int[] array = src.JECMJBFGMCA;
				for (int i = 0; i < array.Length; i++)
				{
					FBKOFEHDENI.Add(array[i]);
				}
			}
			{
				int[] array = src.AJKDHAADIIP;
				for (int i = 0; i < array.Length; i++)
				{
					KBOIDPDGCLA.Add(array[i]);
				}
			}
			{
				int[] array = src.NBMPDOGPOPN;
				for (int i = 0; i < array.Length; i++)
				{
					GGAMKBLHGGI.Add(array[i]);
				}
			}
		}
		{
			uint[] array = reader.KNDKMLHAONN;
			for(int i = 0; i < array.Length; i++)
			{
				OBLDNPMODOM.Add((int)array[i]);
			}
		}
		{
			uint[] array1 = reader.AEJPNAKLKED;
			uint[] array2 = reader.BPGOIALMEBD;
			for (int i = 0; i < array1.Length; i++)
			{
				COKBDFIMOPM.Add((int)array1[i]);
				CAIAODFECPC.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.NBBLIKLDGKL;
			uint[] array2 = reader.APGFIDEIALK;
			for (int i = 0; i < array1.Length; i++)
			{
				OHNJBOFLCOL.Add((int)array1[i]);
				KGJDEFCEEAB.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.FEKLEAOHIFG;
			uint[] array2 = reader.DPKOBEEOBFN;
			for (int i = 0; i < array1.Length; i++)
			{
				HHCDCEOJCIH.Add((int)array1[i]);
				PLMFEFIIBFL.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.APJBBOHHFNE;
			uint[] array2 = reader.CPGHODANBMF;
			for (int i = 0; i < array1.Length; i++)
			{
				IMIMFIKCFMK.Add((int)array1[i]);
				BGKMMAGPAMJ.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.ACGLMKEBMDL;
			uint[] array2 = reader.KDLGMEBCBAC;
			for (int i = 0; i < array1.Length; i++)
			{
				FIDHHBBINNB.Add((int)array1[i]);
				MPADAMHJBKK.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.JGEIIONMJMI;
			uint[] array2 = reader.DOAFFAGEHOM;
			for (int i = 0; i < array1.Length; i++)
			{
				HLKHOFPAOMK.Add((int)array1[i]);
				GEFODCKCCBK.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.CMENIBCJJNF;
			uint[] array2 = reader.BIHJCIGKMBA;
			for (int i = 0; i < array1.Length; i++)
			{
				HLLJIICKNIP.Add((int)array1[i]);
				ELLLGOHHICG.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.KMFHHOANPFH;
			uint[] array2 = reader.OOBOCLOFPBF;
			for (int i = 0; i < array1.Length; i++)
			{
				FENOHOEIJOE.Add((int)array1[i]);
				IHMOHBMPMLO.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.EHODALENBEL;
			uint[] array2 = reader.DKAIOCGKJLO;
			for (int i = 0; i < array1.Length; i++)
			{
				LJPKLMJPLAC.Add((int)array1[i]);
				GJDCMCFCIKD.Add((int)array2[i]);
			}
		}
		{
			uint[] array1 = reader.ALJIHHGHCOG;
			uint[] array2 = reader.OIDAMEGDNOF;
			for (int i = 0; i < array1.Length; i++)
			{
				MALHPBKPIDE.Add((int)array1[i]);
				IIDJCNEOLAL.Add((int)array2[i]);
			}
		}
		{
			uint[] array = reader.DHJMHKKGIGE;
			for(int i = 0; i < array.Length; i++)
			{
				JJBJKENKAJP.Add((int)array[i]);
			}
		}
		{
			uint[] array = reader.EGAEODOCBEL;
			for (int i = 0; i < array.Length; i++)
			{
				LLDJIAKLOGC.Add((sbyte)array[i]);
			}
		}
		{
			uint[] array = reader.EDKOLGMBOAB;
			for (int i = 0; i < array.Length; i++)
			{
				ALPMOLDJJKL.Add((sbyte)array[i]);
			}
		}
		{
			uint[] array = reader.IFCIFFKIGAM;
			for (int i = 0; i < array.Length; i++)
			{
				PNDCOGFIGJO.Add((sbyte)array[i]);
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
				FKLCEJNHKMN.Add((sbyte)array[i]);
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
			PNEMPHGJLKG = FBGGEFFJJHB ^ array[0];
			NPEECLODIKB = FBGGEFFJJHB ^ (array[1] == 0 ? 1 : array[1]);
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
		TodoLogger.Log(0, "TODO");
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
				CPNJJKDKNOO.Add(array[i]);
			}
		}
		List<int> l = new List<int>();
		{
			uint[] array = data.PGLELFPNOPI;
			for (int i = 0; i < array.Length; i++)
			{
				l.Add((int)array[i]);
			}
			LECAOCJCEKF = l[0];
			IHIONKFAAED = l[1];
			HHPJIALEPEE = l[2];
			BCCKJLPNJJM = l[3];
			CIFKMCKFMOA = l[4];
		}
		{
			uint[] array = data.LHICAPGLBOF;
			for (int i = 0; i < array.Length; i++)
			{
				EONACOOGKCA.Add((int)array[i]);
			}
		}
		l.Clear();
		{
			uint[] array = data.LCFIHFMFICM;
			for (int i = 0; i < array.Length; i++)
			{
				l.Add((int)array[i]);
			}
			FLPKPBECPOD = l[0];
			NELJPDJEKNM = l[1];
			MPAMBMKFCKK = l[2];
			IJDBNKCLGIC = l[3];
			GLMKBFEHPLA = l[4];
			LPDACKNMGNK = l[5];
		}
		EDCJLGMBGCH.Clear();
		{
			uint[] array = data.PPAOHBBEPKK;
			for (int i = 0; i < array.Length; i++)
			{
				EDCJLGMBGCH.Add((int)array[i]);
			}
		}
		DFEAPKGAGMN.Clear();
		{
			int[] array = data.BABAGPKAONA;
			for (int i = 0; i < array.Length; i++)
			{
				DFEAPKGAGMN.Add(array[i]);
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
				data2.PHGLKBPLFDH = (short)array_data[i].EAOPGELMIHB[j].FBHMAIEDEGJ;
				data2.GKPPCFMBANO = (short)array_data[i].EAOPGELMIHB[j].JPHMLLIBLGG;
				data2.MPPANPOOIIB = (short)array_data[i].EAOPGELMIHB[j].ABNMKJGNKFO;
				data2.DAPGDCPDCNA = (short)array_data[i].EAOPGELMIHB[j].KPECMLFDLOI;
				data2.MDDMKHJNCBO = new short[array_data[i].EAOPGELMIHB[j].LEJHEGIMCCL.Length];
				for(int k = 0; k < array_data[i].EAOPGELMIHB[j].LEJHEGIMCCL.Length; k++)
				{
					data2.MDDMKHJNCBO[k] = (short)array_data[i].EAOPGELMIHB[j].LEJHEGIMCCL[k];
				}
				data.CDENCMNHNGA.Add(data2);
			}
			HPEFFMGGIBC.Add(data);
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
		TodoLogger.Log(0, "CAOGDCBPBAN");
		return 0;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6C0A30 Offset: 0x6C0A30 VA: 0x6C0A30
	// // RVA: 0xDA8004 Offset: 0xDA8004 VA: 0xDA8004
	// private void <Deserialize>b__245_0(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0A40 Offset: 0x6C0A40 VA: 0x6C0A40
	// // RVA: 0xDA8084 Offset: 0xDA8084 VA: 0xDA8084
	// private void <Deserialize>b__245_1(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0A50 Offset: 0x6C0A50 VA: 0x6C0A50
	// // RVA: 0xDA8104 Offset: 0xDA8104 VA: 0xDA8104
	// private void <Deserialize>b__245_2(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0A60 Offset: 0x6C0A60 VA: 0x6C0A60
	// // RVA: 0xDA8184 Offset: 0xDA8184 VA: 0xDA8184
	// private void <Deserialize>b__245_3(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0A70 Offset: 0x6C0A70 VA: 0x6C0A70
	// // RVA: 0xDA8204 Offset: 0xDA8204 VA: 0xDA8204
	// private void <Deserialize>b__245_4(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0A80 Offset: 0x6C0A80 VA: 0x6C0A80
	// // RVA: 0xDA8284 Offset: 0xDA8284 VA: 0xDA8284
	// private void <Deserialize>b__245_5(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0A90 Offset: 0x6C0A90 VA: 0x6C0A90
	// // RVA: 0xDA8304 Offset: 0xDA8304 VA: 0xDA8304
	// private void <Deserialize>b__245_6(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0AA0 Offset: 0x6C0AA0 VA: 0x6C0AA0
	// // RVA: 0xDA8384 Offset: 0xDA8384 VA: 0xDA8384
	// private void <Deserialize>b__245_7(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0AB0 Offset: 0x6C0AB0 VA: 0x6C0AB0
	// // RVA: 0xDA8404 Offset: 0xDA8404 VA: 0xDA8404
	// private void <Deserialize>b__245_8(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0AC0 Offset: 0x6C0AC0 VA: 0x6C0AC0
	// // RVA: 0xDA8484 Offset: 0xDA8484 VA: 0xDA8484
	// private void <Deserialize>b__245_9(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0AD0 Offset: 0x6C0AD0 VA: 0x6C0AD0
	// // RVA: 0xDA8504 Offset: 0xDA8504 VA: 0xDA8504
	// private void <Deserialize>b__245_10(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0AE0 Offset: 0x6C0AE0 VA: 0x6C0AE0
	// // RVA: 0xDA8584 Offset: 0xDA8584 VA: 0xDA8584
	// private void <Deserialize>b__245_11(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0AF0 Offset: 0x6C0AF0 VA: 0x6C0AF0
	// // RVA: 0xDA8604 Offset: 0xDA8604 VA: 0xDA8604
	// private void <Deserialize>b__245_12(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0B00 Offset: 0x6C0B00 VA: 0x6C0B00
	// // RVA: 0xDA8684 Offset: 0xDA8684 VA: 0xDA8684
	// private void <Deserialize>b__245_13(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0B10 Offset: 0x6C0B10 VA: 0x6C0B10
	// // RVA: 0xDA8704 Offset: 0xDA8704 VA: 0xDA8704
	// private void <Deserialize>b__245_14(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0B20 Offset: 0x6C0B20 VA: 0x6C0B20
	// // RVA: 0xDA8784 Offset: 0xDA8784 VA: 0xDA8784
	// private void <Deserialize>b__245_15(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0B30 Offset: 0x6C0B30 VA: 0x6C0B30
	// // RVA: 0xDA8804 Offset: 0xDA8804 VA: 0xDA8804
	// private void <Deserialize>b__245_16(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0B40 Offset: 0x6C0B40 VA: 0x6C0B40
	// // RVA: 0xDA8884 Offset: 0xDA8884 VA: 0xDA8884
	// private void <Deserialize>b__245_17(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0B50 Offset: 0x6C0B50 VA: 0x6C0B50
	// // RVA: 0xDA8904 Offset: 0xDA8904 VA: 0xDA8904
	// private void <Deserialize>b__245_18(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0B60 Offset: 0x6C0B60 VA: 0x6C0B60
	// // RVA: 0xDA8984 Offset: 0xDA8984 VA: 0xDA8984
	// private void <Deserialize>b__245_19(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0B70 Offset: 0x6C0B70 VA: 0x6C0B70
	// // RVA: 0xDA8A04 Offset: 0xDA8A04 VA: 0xDA8A04
	// private void <Deserialize>b__245_20(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0B80 Offset: 0x6C0B80 VA: 0x6C0B80
	// // RVA: 0xDA8A84 Offset: 0xDA8A84 VA: 0xDA8A84
	// private void <Deserialize>b__245_21(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0B90 Offset: 0x6C0B90 VA: 0x6C0B90
	// // RVA: 0xDA8B04 Offset: 0xDA8B04 VA: 0xDA8B04
	// private void <Deserialize>b__245_22(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0BA0 Offset: 0x6C0BA0 VA: 0x6C0BA0
	// // RVA: 0xDA8B84 Offset: 0xDA8B84 VA: 0xDA8B84
	// private void <Deserialize>b__245_23(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0BB0 Offset: 0x6C0BB0 VA: 0x6C0BB0
	// // RVA: 0xDA8C04 Offset: 0xDA8C04 VA: 0xDA8C04
	// private void <Deserialize>b__245_24(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0BC0 Offset: 0x6C0BC0 VA: 0x6C0BC0
	// // RVA: 0xDA8C84 Offset: 0xDA8C84 VA: 0xDA8C84
	// private void <Deserialize>b__245_25(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0BD0 Offset: 0x6C0BD0 VA: 0x6C0BD0
	// // RVA: 0xDA8D04 Offset: 0xDA8D04 VA: 0xDA8D04
	// private void <Deserialize>b__245_26(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0BE0 Offset: 0x6C0BE0 VA: 0x6C0BE0
	// // RVA: 0xDA8D84 Offset: 0xDA8D84 VA: 0xDA8D84
	// private void <Deserialize>b__245_27(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0BF0 Offset: 0x6C0BF0 VA: 0x6C0BF0
	// // RVA: 0xDA8E04 Offset: 0xDA8E04 VA: 0xDA8E04
	// private void <Deserialize>b__245_28(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0C00 Offset: 0x6C0C00 VA: 0x6C0C00
	// // RVA: 0xDA8E84 Offset: 0xDA8E84 VA: 0xDA8E84
	// private void <Deserialize>b__245_29(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0C10 Offset: 0x6C0C10 VA: 0x6C0C10
	// // RVA: 0xDA8F04 Offset: 0xDA8F04 VA: 0xDA8F04
	// private void <Deserialize>b__245_30(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0C20 Offset: 0x6C0C20 VA: 0x6C0C20
	// // RVA: 0xDA8F84 Offset: 0xDA8F84 VA: 0xDA8F84
	// private void <Deserialize>b__245_31(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0C30 Offset: 0x6C0C30 VA: 0x6C0C30
	// // RVA: 0xDA9004 Offset: 0xDA9004 VA: 0xDA9004
	// private void <Deserialize>b__245_32(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0C40 Offset: 0x6C0C40 VA: 0x6C0C40
	// // RVA: 0xDA9084 Offset: 0xDA9084 VA: 0xDA9084
	// private void <Deserialize>b__245_33(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0C50 Offset: 0x6C0C50 VA: 0x6C0C50
	// // RVA: 0xDA9104 Offset: 0xDA9104 VA: 0xDA9104
	// private void <Deserialize>b__245_34(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6C0C60 Offset: 0x6C0C60 VA: 0x6C0C60
	// // RVA: 0xDA9184 Offset: 0xDA9184 VA: 0xDA9184
	// private void <Deserialize>b__245_35(int OIPCCBHIKIA, int JBGEEPFKIGG) { }
}

public class JANMKFAKHIC_ComboBonus
{
	public int ADKDHKMPMHP; // 0x8
	public int DHIPGHBJLIL; // 0xC
}


public class EGLJKICMCPG
{
	public short PHGLKBPLFDH; // 0x8
	public short GKPPCFMBANO; // 0xA
	public short MPPANPOOIIB; // 0xC
	public short DAPGDCPDCNA; // 0xE
	public short[] MDDMKHJNCBO; // 0x10

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
