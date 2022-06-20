using System.Text.RegularExpressions;
using System;

public class GCGNICILKLD
{
	public static Regex NOCCMAKNLLD = new Regex("!s[0-9a-fA-F]+z!"); // 0x0
	public static Regex HKHANOINECD = new Regex("!s(?<p>[0-9a-fA-F]+)z!"); // 0x4
	public JDEFIJBCJLC PGDPCHNHMKI; // 0x8 // dst
	public JDEFIJBCJLC ELLCDOJOGKL; // 0xC // src
	public JDEFIJBCJLC NKLIKAENLNC; // 0x10 // md5
	public long CFKONDFCBEB; // 0x18
	public uint FGGCKOJFJGK; // 0x20
	public int LBALIFCJKON; // 0x24
	private uint JCKCPNHIKGP; // 0x28
	private long BBEGLBMOBOF; // 0x30
	public int FDDDLPAJIEJ; // 0x38
	public static uint LAFJPOLCKLP = 0x14577faf; // 0x8
	public static long PMMJABPFGOA = 0x74841251; // 0x10

	public string OIEAICNAMNB { get { // name
        if(PGDPCHNHMKI != null)
            return PGDPCHNHMKI.DNJEJEANJGL;
        return null;
    } } // 0x16AAC60 DOKAICDKCCN
	public string MFBMBPJAADA { get {
        if(ELLCDOJOGKL != null)
            return ELLCDOJOGKL.DNJEJEANJGL;
        return null;
    } } //0x16AAC78 NJDFIHBJDOG
	public string POEGMFKLFJG { get { // md5
        if(NKLIKAENLNC != null)
            return NKLIKAENLNC.DNJEJEANJGL;
        return null;
    } } //0x16AAC90 NCFJKJMKANL
	public long CALJIGKCAAH { get { // last update
        return BBEGLBMOBOF ^ CFKONDFCBEB;
    } set {
        CFKONDFCBEB = BBEGLBMOBOF ^ value;
    } } //0x16AACA8 MMINNMHAJGO 0x16AACBC CBMKIPILIND
	// public uint HHPEMFKDHLK { get; }  0x16AACDC NCFONAKINMA

	// RVA: 0x16AACEC Offset: 0x16AACEC VA: 0x16AACEC
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK, int OIPCCBHIKIA)
    {
        BBEGLBMOBOF = PMMJABPFGOA;
        JCKCPNHIKGP = LAFJPOLCKLP;
        LAFJPOLCKLP = LAFJPOLCKLP * 0xe;
        PMMJABPFGOA = PMMJABPFGOA * 0x1c;
        if(LAFJPOLCKLP == 0)
            LAFJPOLCKLP = 0x14577faf;
        if(PMMJABPFGOA == 0)
            PMMJABPFGOA = 0x74841251;
        
        string file = (string)IDLHJIOMJBK[AFEHLCGHAEE.MIMGPBHAJCO/*file*/];
        ELLCDOJOGKL = new JDEFIJBCJLC();
        ELLCDOJOGKL.DNJEJEANJGL = file;

        PGDPCHNHMKI = new JDEFIJBCJLC();
        PGDPCHNHMKI.DNJEJEANJGL = NOCCMAKNLLD.Replace(file, "");

        FGGCKOJFJGK = JCKCPNHIKGP;
        string txt = null;
        if(ELLCDOJOGKL != null)
            txt = ELLCDOJOGKL.DNJEJEANJGL;
        
        Match m = HKHANOINECD.Match(txt);
        if(m.Success)
        {
            string strhash = m.Groups["p"].Value;
            uint hash;
            if(UInt32.TryParse(strhash, out hash))
            {
                FGGCKOJFJGK = hash ^ JCKCPNHIKGP;
            }
        }

        NKLIKAENLNC = new JDEFIJBCJLC();
        NKLIKAENLNC.DNJEJEANJGL = (string)IDLHJIOMJBK[AFEHLCGHAEE.POEGMFKLFJG/*hash_value*/];

        LBALIFCJKON = OIPCCBHIKIA;
        CFKONDFCBEB = (int)IDLHJIOMJBK[AFEHLCGHAEE.CALJIGKCAAH/*last_updated_at*/] ^ BBEGLBMOBOF;
    }
}
