
public class DGLBJJCIIDG
{
	private const int FBGGEFFJJHB_xor = 625060239; // 0x2541a98f
	public int DGNFIGBNKCK_Crypted = FBGGEFFJJHB_xor; // 0x8
	public int EPGOIGPKPPJ_FreeMusicIdCrypted = FBGGEFFJJHB_xor; // 0xC
	public int GBGHABAJPGJ_JacketIdCrypted = FBGGEFFJJHB_xor; // 0x10
	public long IBCNABKLHHH_StartCrypted = FBGGEFFJJHB_xor; // 0x18
	public long MABPKDKBJAG_CloseAtCrypted = FBGGEFFJJHB_xor; // 0x20
	public int LJMNBDMIJNK_Crypted = FBGGEFFJJHB_xor; // 0x28
	public int HAKIFBIKHFF_Crypted = FBGGEFFJJHB_xor; // 0x2C

	public int NPHNPEAGFFM_Id { get { return DGNFIGBNKCK_Crypted ^ FBGGEFFJJHB_xor; } set { DGNFIGBNKCK_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1985F34 EDIKGLOOMGO_bgs 0x1985F48 FCBNHLIMONF_bgs
	public int GHBPLHBNMBK_FreeMusicId { get { return EPGOIGPKPPJ_FreeMusicIdCrypted ^ FBGGEFFJJHB_xor; } set { EPGOIGPKPPJ_FreeMusicIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1985F5C HKFCFPFPMBN_bgs 0x1985F70 IFMPBFAAKNN_bgs
	public int JNCPEGJGHOG_JacketId { get { return GBGHABAJPGJ_JacketIdCrypted ^ FBGGEFFJJHB_xor; } set { GBGHABAJPGJ_JacketIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1985F84 HHEADMHBBPB_bgs 0x1985F98 GOFFKDDNACG_bgs
	public long KJBGCLPMLCG_OpenedAt { get { return IBCNABKLHHH_StartCrypted ^ FBGGEFFJJHB_xor; } set { IBCNABKLHHH_StartCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1985FAC IDLJOCDJJOC_bgs 0x1985FC0 ODIEKGPKOAC_bgs
	public long GJFPFFBAKGK_CloseAt { get { return MABPKDKBJAG_CloseAtCrypted ^ FBGGEFFJJHB_xor; } set { MABPKDKBJAG_CloseAtCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1985FDC KPBMCJKFEGN_bgs 0x1985FF0 IEFCDGKGICA_bgs
	public int EKHAFFFELCO_CSkill { get { return LJMNBDMIJNK_Crypted ^ FBGGEFFJJHB_xor; } set { LJMNBDMIJNK_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x198600C NLJFEDEABCC_bgs 0x1986020 IFABHNFDEII_bgs
	public int EDHAJJHIKHE_LSkill { get { return HAKIFBIKHFF_Crypted ^ FBGGEFFJJHB_xor; } set { HAKIFBIKHFF_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1986034 EIEHOAIEGJE_bgs 0x1986048 ILEEIPGLDEO_bgs

	// RVA: 0x198605C Offset: 0x198605C VA: 0x198605C
	public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, int _GOIKCKHMBDL_FreeMusicId, int _PDBPFJJCADD_open_at, int _FDBNFFNFOND_close_at, int _CPBFAMJEODF_c_skill, int _MGHPJNNDCIG_l_skill)
    {
        NPHNPEAGFFM_Id = _PPFNGGCBJKC_id;
        GHBPLHBNMBK_FreeMusicId = _GOIKCKHMBDL_FreeMusicId;
        JNCPEGJGHOG_JacketId = 0;
        if(_GOIKCKHMBDL_FreeMusicId > 0)
        {
            IBJAKJJICBC data = new IBJAKJJICBC();
            data.KHEKNNFCAOI_Init(GHBPLHBNMBK_FreeMusicId, false, 0, 0, 0, false, false, false);
            JNCPEGJGHOG_JacketId = data.JNCPEGJGHOG_JacketId;
        }
        KJBGCLPMLCG_OpenedAt = _PDBPFJJCADD_open_at;
        GJFPFFBAKGK_CloseAt = _FDBNFFNFOND_close_at;
        EKHAFFFELCO_CSkill = _CPBFAMJEODF_c_skill;
        EDHAJJHIKHE_LSkill = _MGHPJNNDCIG_l_skill;
    }
}

public class EMGOCNMMPHC : DGLBJJCIIDG
{
	private const int FBGGEFFJJHB_xor = 625060239; // 0x2541a98f
	private const sbyte JFOFMKBJBBE_False = 19; // 0x13
	private const sbyte CNECJGKECHK_True = 87; // 0x57
	public int NBOLDNMPJFG_scoreCrypted = FBGGEFFJJHB_xor; // 0x30
	public int BBJHIKDJEJL_Crypted = FBGGEFFJJHB_xor; // 0x34
	public int JNLBGAKBBMH_Crypted = FBGGEFFJJHB_xor; // 0x38
	public int CPHLLEKLFFG_Crypted = FBGGEFFJJHB_xor; // 0x3C
	public int FOKECLCJLJL_Crypted = FBGGEFFJJHB_xor; // 0x40
	public int NBJNFGJFANG_Crypted = FBGGEFFJJHB_xor; // 0x44
	public int HJBFNENMJPG_Crypted = FBGGEFFJJHB_xor; // 0x48
	public sbyte EJPAGBKMOOG_Crypted = JFOFMKBJBBE_False; // 0x4C
	public sbyte BLHCJOONONA_Crypted = JFOFMKBJBBE_False; // 0x4D
	public sbyte KCLBICAILCC_Crypted = JFOFMKBJBBE_False; // 0x4E

	public int KNIFCANOHOC_score { get { return NBOLDNMPJFG_scoreCrypted ^ FBGGEFFJJHB_xor; } set { NBOLDNMPJFG_scoreCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1309A50 EOJEPLIPOMJ_get_score 0x1309A64 AEEMBPAEAAI_set_score
	public int BGJDHCEOIDB_BattleClass { get { return BBJHIKDJEJL_Crypted ^ FBGGEFFJJHB_xor; } set { BBJHIKDJEJL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1309A78 OCKGMLNANOK_bgs 0x1309A8C NINDNKAPBLB_bgs
	public int IOOBNLAHLEJ_WinPoint { get { return JNLBGAKBBMH_Crypted ^ FBGGEFFJJHB_xor; } set { JNLBGAKBBMH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1309AA0 PILACCFMMMP_bgs 0x1309AB4 LDNPPCPAFEO_bgs
	public int FOFJCOHAFCG_EpisodeCnt { get { return CPHLLEKLFFG_Crypted ^ FBGGEFFJJHB_xor; } set { CPHLLEKLFFG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1309AC8 MLACLHMAMKE_bgs 0x1309ADC JIJCJGDAJOL_bgs
	public int CLEFJPKPOGB_EpBonusCnt { get { return FOKECLCJLJL_Crypted ^ FBGGEFFJJHB_xor; } set { FOKECLCJLJL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1309AF0 PLBDHPIJHFI_bgs 0x1309B04 OENPAHPKEGE_bgs
	public int KDNCMJBDCLE_ExBattleScore { get { return NBJNFGJFANG_Crypted ^ FBGGEFFJJHB_xor; } set { NBJNFGJFANG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1309B18 LAIOBMGCNAF_bgs 0x1309B2C AJJOLHOJABN_bgs
	public int LDIODNEADGG_Hs { get { return HJBFNENMJPG_Crypted ^ FBGGEFFJJHB_xor; } set { HJBFNENMJPG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1309B40 EHCHFFLBLJA_bgs 0x1309B54 CHNBHKLHEDA_bgs
	public bool FFHMPNGJCLK_NewRecord { get { return EJPAGBKMOOG_Crypted == CNECJGKECHK_True; } set { EJPAGBKMOOG_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1309B68 CMHNAFLEENF_bgs 0x1309B7C OEPHKBJBDPO_bgs
	public bool OHBNMGEKPNF_HasC { get { return BLHCJOONONA_Crypted == CNECJGKECHK_True; } set { BLHCJOONONA_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1309BAC ANJPCMBAAPP_bgs 0x1309BC0 FCDNBMDMOPL_bgs
	public bool DPCFADCFMOA_Win { get { return KCLBICAILCC_Crypted == CNECJGKECHK_True; } set { KCLBICAILCC_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1309BF0 FKKNODLLFOI_bgs 0x1309C04 BGGKJMIPHEE_bgs

	// RVA: 0x1309C38 Offset: 0x1309C38 VA: 0x1309C38
	public EMGOCNMMPHC()
    {
        KHEKNNFCAOI_Init(0, 0);
    }

	// RVA: 0x1309CA8 Offset: 0x1309CA8 VA: 0x1309CA8
	public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, int _GOIKCKHMBDL_FreeMusicId)
    {
        base.KHEKNNFCAOI_Init(_PPFNGGCBJKC_id, _GOIKCKHMBDL_FreeMusicId, 0, 0, 0, 0);
        KNIFCANOHOC_score = 0;
        BGJDHCEOIDB_BattleClass = 0;
        IOOBNLAHLEJ_WinPoint = 0;
        FOFJCOHAFCG_EpisodeCnt = 0;
        CLEFJPKPOGB_EpBonusCnt = 0;
        KDNCMJBDCLE_ExBattleScore = 0;
        LDIODNEADGG_Hs = 0;
        FFHMPNGJCLK_NewRecord = false;
        OHBNMGEKPNF_HasC = false;
        DPCFADCFMOA_Win = false;
    }
}
