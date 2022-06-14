using System;
using UnityEngine;
using System.Text;
using System.Collections.Generic;

public delegate bool OMIFMMJPMDJ(int INDDJNMPONH, float LNAHJANMJNM);
public delegate void OBHIGCFPKJN(string DOGDHKIEBJA, IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP);

public class KDLPEDBKMID
{
    public class EMEKAOMPFNC
    {
        public string CJEKGLGBIHF; // 0x8
        public string BLHCFFOHBNF; // 0xC
        public string NOCCPNGFFPF; // 0x10
        public int LGADCGFMLLD; // 0x14
    }

    public enum PHKOILLPHGG
    {
        LACMMENCAIF = 0,
        HGACHBEOOHD = 1,
        ODFDIFNIFPC = 2,
    }

	private StringBuilder JBBHNIACMFJ = new StringBuilder(256); // 0x8
	private List<KDLPEDBKMID.EMEKAOMPFNC> JFEKDMEMKHE = new List<KDLPEDBKMID.EMEKAOMPFNC>(30); // 0xC
	public DJBHIFLHJLK FGGJNGCAFGK; // 0x18
	private Action LCIGLIDJILJ; // 0x1C
	private bool KOIGPANFBKP; // 0x20
	private bool LFPOPKJMGKA; // 0x21
	public float HANBBBBLLGP; // 0x24
	private bool PICLIFPDEOF; // 0x28
	private JEHIAIPJNJF PMDNNKAPIKJ; // 0x2C
	private float FGCMHIPPDFL; // 0x34
	private float LPHLENALMBE = 1.0f; // 0x38
	private WaitForEndOfFrame CGHFIPJFFKD = new WaitForEndOfFrame(); // 0x3C
	private static readonly string[] NFKOAFFBHOL = new string[13] {"snd/bgm/cs_bgm_tutorial.acb", 
																	"snd/bgm/cs_bgm_tutorial.awb",
																	"ct/dv/me/01/01_01.xab",
																	"ct/dv/me/01/02_01.xab",
																	"ct/dv/me/01/03_01.xab",
																	"ct/dv/me/01/04_01.xab",
																	"ct/dv/me/01/05_01.xab",
																	"ct/dv/me/01/06_01.xab",
																	"ct/dv/me/01/07_01.xab",
																	"ct/dv/me/01/10_01.xab",
																	"ly/083.xab",
																	"handmade/shader.xab",
																	"handmade/cmnparam.xab"}; // 0x4
	private static readonly string[] FJFFOIHEDID = new string[6] {"mc/{0}/bt001.xab",
																	"mc/{0}/ft.xab",
																	"mc/{0}/sc.xab",
																	"sc/{0:D4}.dat",
																	"snd/bgm/cs_w_{0:D4}.acb",
																	"snd/bgm/cs_w_{0:D4}.awb"}; // 0x8
	private static readonly string[] KJAAFBDBDOM = new string[6] {"mc/{0}/bt001.xab",
																	"mc/{0}/ft.xab",
																	"mc/{0}/sc.xab",
																	"sc/{0:D4}.dat",
																	"snd/bgm/cs_w_{0:D4}.acb",
																	"snd/bgm/cs_w_{0:D4}_d.awb"}; // 0xC
	private static readonly string MFDEFIILPGM = "st/{0:D4}.xab"; // 0x10
	private static readonly string JOLFLDNELHO = "mov/gm/dv/game_dv_{0:D4}_mv_{1}q{2:D1}.usm"; // 0x14
	private static readonly string NMFLPJMFPFN = "mc/{0}/bt002.xab"; // 0x18
	private static readonly string EMLADNPGDOG = "mov/gm/dv/game_dv_{0:D4}_mv_{1}q{2:D1}.usm"; // 0x1C
	private static readonly string[] ABNBIJGFNBA = new string[6] {"mc/{0}/dr/cc/{1:D3}.xab",
																	"mc/{0}/dr/dc/{1:D3}.xab",
																	"mc/{0}/dr/dv/{1:D3}.xab",
																	"mc/{0}/dr/li/{1:D3}.xab",
																	"mc/{0}/dr/st/{1:D3}.xab",
																	"mc/{0}/dr/sc/{1:D3}.xab"}; // 0x20
	private static readonly string[] MOMNOGAGKHP = new string[2] {"snd/vo/diva/cs_diva_{0:D3}.acb", "snd/vo/diva/cs_diva_{0:D3}.awb"}; // 0x24
	private static readonly string[] BPKOEOEOBLD = new string[3] {"dv/cs/{0:D3}_{1:D3}.xab", "dv/bs/{0:D3}_{1:D3}.xab", "ct/dv/ps/{0:D2}_{1:D2}.xab"}; // 0x28
	private static readonly string[] EALKAGJANPD = new string[3] {"ct/dv/me/01/{0:D2}_{1:D2}.xab", "ct/dv/me/02/{0:D2}_{1:D2}.xab", "ct/dv/me/03/{0:D2}_{1:D2}.xab"}; // 0x2C
	private static readonly string[] ILINMFJBKAL = new string[3] {"vl/{0:D4}.xab", "ct/vl/01/{0:D2}_01.xab", "ct/vl/02/{0:D2}_01.xab"}; // 0x30
	private static readonly string[] KPBAICAFLPC = new string[3] {"snd/vo/pilot/cs_pilot_{0:D3}.acb", "snd/vo/pilot/cs_pilot_{0:D3}.awb", "ct/pl/{0:D3}.xab"}; // 0x34

	public static KDLPEDBKMID HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	public OMIFMMJPMDJ OEPPEGHGNNO { get; set; } // 0x10 KPEKONPJHCL LKCDOGAFPNM NPJJMDFAIII
	public OBHIGCFPKJN MAIHLKPEHJN { get; set; } // 0x14 EAIFOAGPGGH KCLBNOKEPIG OCIMGEFKKLM
	// public bool LNHFLJBGGJB { get; } // KOIPHFOBLOD 0xE7D688
	public KDLPEDBKMID.PHKOILLPHGG CNDDKMJAIBG { get; set; } // 0x30 HMCLOEGDNBA HIGNHAEJKAH DFJLAMPMCMP

	// // RVA: 0xE7D730 Offset: 0xE7D730 VA: 0xE7D730
	// public void OIKLOJMPBGA(int COGJONKKALB) { }

	// // RVA: 0xE7D768 Offset: 0xE7D768 VA: 0xE7D768
	// public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE) { }

	// // RVA: 0xE7D90C Offset: 0xE7D90C VA: 0xE7D90C
	// public void FFBCKMFKFME() { }

	// // RVA: 0xE7D990 Offset: 0xE7D990 VA: 0xE7D990
	public void OFLDICKPNFD(bool CJPFICKPJPP, DJBHIFLHJLK FGGJNGCAFGK)
    {
        UnityEngine.Debug.LogError("TODO");
    }

	// // RVA: 0xE7DA9C Offset: 0xE7DA9C VA: 0xE7DA9C
	// public void BAGMHFKPFIF() { }

	// // RVA: 0xE7DAC8 Offset: 0xE7DAC8 VA: 0xE7DAC8
	// private void LFKLIOKFGLP() { }

	// // RVA: 0xE7DD48 Offset: 0xE7DD48 VA: 0xE7DD48
	// private void OCGLHHHMILH() { }

	// // RVA: 0xE7DDDC Offset: 0xE7DDDC VA: 0xE7DDDC
	// public static bool ENEFCDLNAEF(string KEIGHMAKAAC) { }

	// // RVA: 0xE7E040 Offset: 0xE7E040 VA: 0xE7E040
	// public bool BDOFDNICMLC(string KEIGHMAKAAC) { }

	// // RVA: 0xE7E294 Offset: 0xE7E294 VA: 0xE7E294
	// private string KPIAEBMBBPE(string KEIGHMAKAAC) { }

	// // RVA: 0xE7E4A8 Offset: 0xE7E4A8 VA: 0xE7E4A8
	// private string FAKFFDIFAAH(string CJEKGLGBIHF) { }

	// // RVA: 0xE7E870 Offset: 0xE7E870 VA: 0xE7E870
	// private string FLBHKPMIJHP(string CJEKGLGBIHF) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6BB384 Offset: 0x6BB384 VA: 0x6BB384
	// // RVA: 0xE7DCBC Offset: 0xE7DCBC VA: 0xE7DCBC
	// private IEnumerator EOFJPNPFGDM_Install() { }

	// // RVA: 0xE7ECF4 Offset: 0xE7ECF4 VA: 0xE7ECF4
	// private GCGNICILKLD DHBFAKEGDOG(string CJEKGLGBIHF) { }

	// // RVA: 0xE7EEF8 Offset: 0xE7EEF8 VA: 0xE7EEF8
	// public bool EGIFDIFALKK(string KEIGHMAKAAC) { }

	// // RVA: 0xE7EF18 Offset: 0xE7EF18 VA: 0xE7EF18
	// private void EEHMGCMAOAB(string DOGDHKIEBJA, IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP) { }

	// // RVA: 0xE7EF44 Offset: 0xE7EF44 VA: 0xE7EF44
	// public bool HFMOAJDHDHJ(int GHBPLHBNMBK) { }

	// // RVA: 0xE7F26C Offset: 0xE7F26C VA: 0xE7F26C
	// private static string[] JAAOIKIALFJ(int ECOIBKOIPFP) { }

	// // RVA: 0xE7F44C Offset: 0xE7F44C VA: 0xE7F44C
	// public bool OKJCGCOGDIA(int ECOIBKOIPFP, int DNHLEPCFPFC, int MOBOJNCPCGD, int HADONLEBKLD) { }

	// // RVA: 0xE7F898 Offset: 0xE7F898 VA: 0xE7F898
	// public void LIDGJKCOGFA(int ECOIBKOIPFP, int DNHLEPCFPFC, int MOBOJNCPCGD, List<string> NNDGIAEFMOG, int HADONLEBKLD) { }

	// // RVA: 0xE7FD38 Offset: 0xE7FD38 VA: 0xE7FD38
	// public bool KEILLGAJEPF(int ECOIBKOIPFP, int IMPALJEMHJJ, int DNHLEPCFPFC, List<int> KJAIAJIIOMA, List<int> DJPOMCAOKKD, List<int> KBGIODFCIGN, List<int> LMIFMHACFID, List<int> DDFCBCNPGHD, List<int> MEJEDAJBJKN, int MCFPOJBDIHP, List<int> HPDJEIFEADB, int HADONLEBKLD) { }

	// // RVA: 0xE806E8 Offset: 0xE806E8 VA: 0xE806E8
	// public void IDCJNAFJLAA(int ECOIBKOIPFP, int IMPALJEMHJJ, int DNHLEPCFPFC, List<int> KJAIAJIIOMA, List<int> DJPOMCAOKKD, List<int> KBGIODFCIGN, List<int> LMIFMHACFID, List<int> DDFCBCNPGHD, List<int> MEJEDAJBJKN, int MCFPOJBDIHP, List<int> HPDJEIFEADB, List<string> NNDGIAEFMOG, int HADONLEBKLD) { }

	// // RVA: 0xE81148 Offset: 0xE81148 VA: 0xE81148
	// public bool NMFCNFFFMAC(int AHHJLDLAPAN, int EGNLGHDHDDH, bool MMNIIDPMDNP) { }

	// // RVA: 0xE8164C Offset: 0xE8164C VA: 0xE8164C
	// public void EINPFPOEPHP(int AHHJLDLAPAN, int EGNLGHDHDDH, bool MMNIIDPMDNP, List<string> NNDGIAEFMOG) { }

	// // RVA: 0xE81BB0 Offset: 0xE81BB0 VA: 0xE81BB0
	// public bool FKIJBFJBIOC(int JBGIHPHNDKH, bool MMNIIDPMDNP) { }

	// // RVA: 0xE81D54 Offset: 0xE81D54 VA: 0xE81D54
	// public void GJPDNBOCINF(int JBGIHPHNDKH, bool MMNIIDPMDNP, List<string> NNDGIAEFMOG) { }

	// // RVA: 0xE81EF8 Offset: 0xE81EF8 VA: 0xE81EF8
	// public bool CKANBNPEIJD(int LLOBHDMHJIG, int PFGJJLGLPAC) { }

	// // RVA: 0xE82324 Offset: 0xE82324 VA: 0xE82324
	// public void MKJABJDHKNO(int LLOBHDMHJIG, int PFGJJLGLPAC, List<string> NNDGIAEFMOG) { }

	// // RVA: 0xE82798 Offset: 0xE82798 VA: 0xE82798
	// public bool OANDCKGGJIP(int JCNLIANKPAA) { }

	// // RVA: 0xE82944 Offset: 0xE82944 VA: 0xE82944
	// public void HEBLFJFCCLF(int JCNLIANKPAA, List<string> NNDGIAEFMOG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BB3FC Offset: 0x6BB3FC VA: 0x6BB3FC
	// // RVA: 0xE841D8 Offset: 0xE841D8 VA: 0xE841D8
	// private bool <OnAwake>b__33_0() { }
}
