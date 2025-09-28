using System.Text.RegularExpressions;
using System;
using System.Globalization;

[System.Obsolete("Use GCGNICILKLD_AssetFileInfo", true)]
public class GCGNICILKLD { }
public class GCGNICILKLD_AssetFileInfo
{
	public static Regex NOCCMAKNLLD = new Regex("!s[0-9a-fA-F]+z!"); // 0x0
	public static Regex HKHANOINECD = new Regex("!s(?<p>[0-9a-fA-F]+)z!"); // 0x4
	public JDEFIJBCJLC_EncryptedString PGDPCHNHMKI_LocalFileName; // 0x8 // dst
	public JDEFIJBCJLC_EncryptedString ELLCDOJOGKL_FileName; // 0xC // src
	public JDEFIJBCJLC_EncryptedString NKLIKAENLNC_Hash; // 0x10 // md5
	public long CFKONDFCBEB_LastUpdated; // 0x18
	public uint FGGCKOJFJGK_FileHash; // 0x20
	public int LBALIFCJKON_Idx; // 0x24
	private uint JCKCPNHIKGP_Key1; // 0x28
	private long BBEGLBMOBOF_xorl; // 0x30
	public int FDDDLPAJIEJ_IsMediaFile; // 0x38
	public static uint LAFJPOLCKLP_Key1 = 0x14577faf; // 0x8
	public static long PMMJABPFGOA_Key2 = 0x74841251; // 0x10

	public string OIEAICNAMNB_LocalFileName { get { // name
        if(PGDPCHNHMKI_LocalFileName != null)
            return PGDPCHNHMKI_LocalFileName.DNJEJEANJGL_Value;
        return null;
    } } // 0x16AAC60 DOKAICDKCCN
	public string MFBMBPJAADA_FileName { get {
        if(ELLCDOJOGKL_FileName != null)
            return ELLCDOJOGKL_FileName.DNJEJEANJGL_Value;
        return null;
    } } //0x16AAC78 NJDFIHBJDOG
	public string POEGMFKLFJG_hash_value { get { // md5
        if(NKLIKAENLNC_Hash != null)
            return NKLIKAENLNC_Hash.DNJEJEANJGL_Value;
        return null;
    } } //0x16AAC90 NCFJKJMKANL
	public long CALJIGKCAAH_last_updated_at { get { // last update
        return BBEGLBMOBOF_xorl ^ CFKONDFCBEB_LastUpdated;
    } set {
        CFKONDFCBEB_LastUpdated = BBEGLBMOBOF_xorl ^ value;
    } } //0x16AACA8 MMINNMHAJGO 0x16AACBC CBMKIPILIND
	public uint HHPEMFKDHLK_Hash { get { return JCKCPNHIKGP_Key1 ^ FGGCKOJFJGK_FileHash; } } // 0x16AACDC NCFONAKINMA

	// RVA: 0x16AACEC Offset: 0x16AACEC VA: 0x16AACEC
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, int _OIPCCBHIKIA_index)
    {
        BBEGLBMOBOF_xorl = PMMJABPFGOA_Key2;
        JCKCPNHIKGP_Key1 = LAFJPOLCKLP_Key1;
        LAFJPOLCKLP_Key1 = LAFJPOLCKLP_Key1 * 0xe;
        PMMJABPFGOA_Key2 = PMMJABPFGOA_Key2 * 0x1c;
        if(LAFJPOLCKLP_Key1 == 0)
            LAFJPOLCKLP_Key1 = 0x14577faf;
        if(PMMJABPFGOA_Key2 == 0)
            PMMJABPFGOA_Key2 = 0x74841251;
        
        string file = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.MIMGPBHAJCO_file/*file*/];
        ELLCDOJOGKL_FileName = new JDEFIJBCJLC_EncryptedString();
        ELLCDOJOGKL_FileName.DNJEJEANJGL_Value = file;

        PGDPCHNHMKI_LocalFileName = new JDEFIJBCJLC_EncryptedString();
        PGDPCHNHMKI_LocalFileName.DNJEJEANJGL_Value = NOCCMAKNLLD.Replace(file, "");

        FGGCKOJFJGK_FileHash = JCKCPNHIKGP_Key1;
        string txt = null;
        if(ELLCDOJOGKL_FileName != null)
            txt = ELLCDOJOGKL_FileName.DNJEJEANJGL_Value;
        
        Match m = HKHANOINECD.Match(txt);
        if(m.Success)
        {
            string strhash = m.Groups["p"].Value;
            uint hash;
            if(UInt32.TryParse(strhash, NumberStyles.HexNumber, null, out hash))
            {
                FGGCKOJFJGK_FileHash = hash ^ JCKCPNHIKGP_Key1;
            }
        }

        NKLIKAENLNC_Hash = new JDEFIJBCJLC_EncryptedString();
        NKLIKAENLNC_Hash.DNJEJEANJGL_Value = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.POEGMFKLFJG_hash_value/*hash_value*/];

        LBALIFCJKON_Idx = _OIPCCBHIKIA_index;
        CFKONDFCBEB_LastUpdated = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.CALJIGKCAAH_last_updated_at/*last_updated_at*/] ^ BBEGLBMOBOF_xorl;
    }
}
