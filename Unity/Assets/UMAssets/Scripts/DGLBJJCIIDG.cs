
public class DGLBJJCIIDG
{
	private const int FBGGEFFJJHB_xor = 625060239; // 0x2541a98f
	public int DGNFIGBNKCK_Crypted = FBGGEFFJJHB_xor; // 0x8
	public int EPGOIGPKPPJ_FreeMusicIdCrypted = FBGGEFFJJHB_xor; // 0xC
	public int GBGHABAJPGJ_JacketIdCrypted = FBGGEFFJJHB_xor; // 0x10
	public long IBCNABKLHHH_Crypted = FBGGEFFJJHB_xor; // 0x18
	public long MABPKDKBJAG_Crypted = FBGGEFFJJHB_xor; // 0x20
	public int LJMNBDMIJNK_Crypted = FBGGEFFJJHB_xor; // 0x28
	public int HAKIFBIKHFF_Crypted = FBGGEFFJJHB_xor; // 0x2C

	public int NPHNPEAGFFM_Id { get { return DGNFIGBNKCK_Crypted ^ FBGGEFFJJHB_xor; } set { DGNFIGBNKCK_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1985F34 EDIKGLOOMGO 0x1985F48 FCBNHLIMONF
	public int GHBPLHBNMBK_FreeMusicId { get { return EPGOIGPKPPJ_FreeMusicIdCrypted ^ FBGGEFFJJHB_xor; } set { EPGOIGPKPPJ_FreeMusicIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1985F5C HKFCFPFPMBN 0x1985F70 IFMPBFAAKNN
	public int JNCPEGJGHOG_JackedId { get { return GBGHABAJPGJ_JacketIdCrypted ^ FBGGEFFJJHB_xor; } set { GBGHABAJPGJ_JacketIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1985F84 HHEADMHBBPB 0x1985F98 GOFFKDDNACG
	public long KJBGCLPMLCG_OpenAt { get { return IBCNABKLHHH_Crypted ^ FBGGEFFJJHB_xor; } set { IBCNABKLHHH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1985FAC IDLJOCDJJOC 0x1985FC0 ODIEKGPKOAC
	public long GJFPFFBAKGK_CloseAt { get { return MABPKDKBJAG_Crypted ^ FBGGEFFJJHB_xor; } set { MABPKDKBJAG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1985FDC KPBMCJKFEGN 0x1985FF0 IEFCDGKGICA
	public int EKHAFFFELCO_CSkill { get { return LJMNBDMIJNK_Crypted ^ FBGGEFFJJHB_xor; } set { LJMNBDMIJNK_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x198600C NLJFEDEABCC 0x1986020 IFABHNFDEII
	public int EDHAJJHIKHE_LSkill { get { return HAKIFBIKHFF_Crypted ^ FBGGEFFJJHB_xor; } set { HAKIFBIKHFF_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1986034 EIEHOAIEGJE 0x1986048 ILEEIPGLDEO

	// RVA: 0x198605C Offset: 0x198605C VA: 0x198605C
	public void KHEKNNFCAOI(int PPFNGGCBJKC, int _GOIKCKHMBDL_FreeMusicId, int PDBPFJJCADD, int _FDBNFFNFOND_CloseAt, int _CPBFAMJEODF_CSkill, int MGHPJNNDCIG)
    {
        NPHNPEAGFFM_Id = PPFNGGCBJKC;
        GHBPLHBNMBK_FreeMusicId = _GOIKCKHMBDL_FreeMusicId;
        JNCPEGJGHOG_JackedId = 0;
        if(_GOIKCKHMBDL_FreeMusicId > 0)
        {
            IBJAKJJICBC data = new IBJAKJJICBC();
            data.KHEKNNFCAOI(GHBPLHBNMBK_FreeMusicId, false, 0, 0, 0, false, false, false);
            JNCPEGJGHOG_JackedId = data.JNCPEGJGHOG_JacketId;
        }
        KJBGCLPMLCG_OpenAt = PDBPFJJCADD;
        GJFPFFBAKGK_CloseAt = _FDBNFFNFOND_CloseAt;
        EKHAFFFELCO_CSkill = _CPBFAMJEODF_CSkill;
        EDHAJJHIKHE_LSkill = MGHPJNNDCIG;
    }
}

public class EMGOCNMMPHC : DGLBJJCIIDG
{
	private const int FBGGEFFJJHB_xor = 625060239; // 0x2541a98f
	private const sbyte JFOFMKBJBBE_False = 19; // 0x13
	private const sbyte CNECJGKECHK_True = 87; // 0x57
	public int NBOLDNMPJFG_Crypted = FBGGEFFJJHB_xor; // 0x30
	public int BBJHIKDJEJL_Crypted = FBGGEFFJJHB_xor; // 0x34
	public int JNLBGAKBBMH_Crypted = FBGGEFFJJHB_xor; // 0x38
	public int CPHLLEKLFFG_Crypted = FBGGEFFJJHB_xor; // 0x3C
	public int FOKECLCJLJL_Crypted = FBGGEFFJJHB_xor; // 0x40
	public int NBJNFGJFANG_Crypted = FBGGEFFJJHB_xor; // 0x44
	public int HJBFNENMJPG_Crypted = FBGGEFFJJHB_xor; // 0x48
	public sbyte EJPAGBKMOOG_Crypted = JFOFMKBJBBE_False; // 0x4C
	public sbyte BLHCJOONONA_Crypted = JFOFMKBJBBE_False; // 0x4D
	public sbyte KCLBICAILCC_Crypted = JFOFMKBJBBE_False; // 0x4E

	public int KNIFCANOHOC_Sc { get { return NBOLDNMPJFG_Crypted ^ FBGGEFFJJHB_xor; } set { NBOLDNMPJFG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1309A50 EOJEPLIPOMJ 0x1309A64 AEEMBPAEAAI
	public int BGJDHCEOIDB_ClassRank { get { return BBJHIKDJEJL_Crypted ^ FBGGEFFJJHB_xor; } set { BBJHIKDJEJL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1309A78 OCKGMLNANOK 0x1309A8C NINDNKAPBLB
	public int IOOBNLAHLEJ_WinBonus { get { return JNLBGAKBBMH_Crypted ^ FBGGEFFJJHB_xor; } set { JNLBGAKBBMH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1309AA0 PILACCFMMMP 0x1309AB4 LDNPPCPAFEO
	public int FOFJCOHAFCG_Ec { get { return CPHLLEKLFFG_Crypted ^ FBGGEFFJJHB_xor; } set { CPHLLEKLFFG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1309AC8 MLACLHMAMKE 0x1309ADC JIJCJGDAJOL
	public int CLEFJPKPOGB_Ep { get { return FOKECLCJLJL_Crypted ^ FBGGEFFJJHB_xor; } set { FOKECLCJLJL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1309AF0 PLBDHPIJHFI 0x1309B04 OENPAHPKEGE
	public int KDNCMJBDCLE_ExBattleScore { get { return NBJNFGJFANG_Crypted ^ FBGGEFFJJHB_xor; } set { NBJNFGJFANG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1309B18 LAIOBMGCNAF 0x1309B2C AJJOLHOJABN
	public int LDIODNEADGG_Hs { get { return HJBFNENMJPG_Crypted ^ FBGGEFFJJHB_xor; } set { HJBFNENMJPG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1309B40 EHCHFFLBLJA 0x1309B54 CHNBHKLHEDA
	public bool FFHMPNGJCLK_NewRecord { get { return EJPAGBKMOOG_Crypted == CNECJGKECHK_True; } set { EJPAGBKMOOG_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1309B68 CMHNAFLEENF 0x1309B7C OEPHKBJBDPO
	public bool OHBNMGEKPNF_HasC { get { return BLHCJOONONA_Crypted == CNECJGKECHK_True; } set { BLHCJOONONA_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1309BAC ANJPCMBAAPP 0x1309BC0 FCDNBMDMOPL
	public bool DPCFADCFMOA_Win { get { return KCLBICAILCC_Crypted == CNECJGKECHK_True; } set { KCLBICAILCC_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1309BF0 FKKNODLLFOI 0x1309C04 BGGKJMIPHEE

	// RVA: 0x1309C38 Offset: 0x1309C38 VA: 0x1309C38
	public EMGOCNMMPHC()
    {
        KHEKNNFCAOI(0, 0);
    }

	// RVA: 0x1309CA8 Offset: 0x1309CA8 VA: 0x1309CA8
	public void KHEKNNFCAOI(int PPFNGGCBJKC, int _GOIKCKHMBDL_FreeMusicId)
    {
        base.KHEKNNFCAOI(PPFNGGCBJKC, _GOIKCKHMBDL_FreeMusicId, 0, 0, 0, 0);
        KNIFCANOHOC_Sc = 0;
        BGJDHCEOIDB_ClassRank = 0;
        IOOBNLAHLEJ_WinBonus = 0;
        FOFJCOHAFCG_Ec = 0;
        CLEFJPKPOGB_Ep = 0;
        KDNCMJBDCLE_ExBattleScore = 0;
        LDIODNEADGG_Hs = 0;
        FFHMPNGJCLK_NewRecord = false;
        OHBNMGEKPNF_HasC = false;
        DPCFADCFMOA_Win = false;
    }
}
