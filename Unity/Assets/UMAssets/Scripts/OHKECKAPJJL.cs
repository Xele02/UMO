
public class OHKECKAPJJL
{
    public enum GPNHNIGPGCL
    {
        HJNNKCMLGFL_0_None = 0,
        PDCBCIGDPHL_1_Gacha1 = 1,
        DLNKBNOECAG_2_Mission1 = 2,
        NOBPFBOJLJD_3_Campaign = 3,
        LKPNOOKDFHH_4_StoneSale = 4,
        PEEBEIHMLIO_5_NyanCuzi = 5,
        GLLGHGMHCKF_6_Event1 = 6,
        CKPLJKICBKB_7_Event2 = 7,
        ODPGFIPCFEF_8_DailyAdv = 8,
        ILBPPODCPPP_9_Gacha2 = 9,
        NNJBAJMNBCM_10_Offer = 10,
        JPDDBAEMJLJ = 11,
        LAJAJEMJBFC_12_Gacha3 = 12,
        MLDKHMADOAD_13_Mission2 = 13,
        OCHMPNOEELL_14_Mission3 = 14,
        NKCLBKDFOCM_15_Mission4 = 15,
        IFHIJGBBGNH = 16,
        ELKFFLPDNAD = 17,
        DIDJLIPNCKO_18_Bingo = 18,
        IOPLLOIHMJC = 19,
    }

    public enum ONKLMFNGCHJ
    {
        HJNNKCMLGFL_0_None = 0,
        NHICGIPPMBD_1_NotStarted = 1,
        LAOEGNLOJHC_2_Start = 2,
        EMAMLLFAOJI_3_Counting = 3,
        FKHAJADPBJK_4_Epilogue = 4,
        OLCLJKOKJCD_5_End = 5,
        FBFBGLONIME_6_AfterGacha = 6,
        IOPLLOIHMJC_7 = 7,
    }

    public enum OHKBMOEIPEP
    {
        HJNNKCMLGFL_0_None = 0,
        IPPOEPJEDPP_1 = 1,
        OFBEAEHFHOG_2 = 2,
        FELOJMIJMDD_3 = 3,
        GPDBJKNHHGM_4 = 4,
        IOPLLOIHMJC = 5,
    }

    public enum NBADGBJMBMM
    {
        HIDGJCIFFNJ_0 = 0,
        IIBKMHIDNPM_1 = 1,
    }

    public enum FLIGIBMFEOA
    {
        DOEHLCLBCNN_1_Gacha = 1,
        NKDOEBONGNI_2_EventMission = 2,
        NOBPFBOJLJD_3_Campaign = 3,
        FKAEGJHEHAO = 0,
        OCCGDMDBCHK_4_EventGacha = 4,
        CCDOBDNDPIL_5_Event = 5,
        ODPGFIPCFEF_7_DailyAdv = 7,
        ILBPPODCPPP_8_Gacha2 = 8,
        NNJBAJMNBCM_9_Offer = 9,
        JPDDBAEMJLJ = 10,
        DIDJLIPNCKO_11_Bingo = 11,
    }

	private int FBGGEFFJJHB_xor; // 0x8
	private long BBEGLBMOBOF_xorl; // 0x10
	private const sbyte HKKJGAJPNIL_True = 88;
	private const sbyte FKHFJOKHNAK_False = 58;
	private int EHOIENNDEDH_IdCrypted; // 0x18
	private int CFKADAPCGMI_Crypted; // 0x1C
	private int JOPENLCBJHH_Crypted; // 0x20
	private int AMAEPCDKEGF_Crypted; // 0x24
	private int AFPJHODHJAB_Crypted; // 0x28
	private int LNFKNALODJB_Crypted; // 0x2C
	private int GHJIEPHJJEK_Crypted; // 0x30
	private NNJFKLBPBNK_SecureString NLCIPNCPOII = new NNJFKLBPBNK_SecureString(); // 0x34
	private int CKNBCJIIMAM_Crypted; // 0x38
	private sbyte ANBAEAGJNEE_Crypted; // 0x3C
	private long PCLNFCNIECH_OpenAtCrypted; // 0x40
	private long HHPIJHADAOB_CloseAtCrypted; // 0x48
	private sbyte MFHADBAGMCE_is_new_Crypted; // 0x50
	private int HPNLHEAENJB_Crypted; // 0x54
	private int KIAAIBDCMCC_Crypted; // 0x58
	private int AIMMOBGOLML_Crypted; // 0x5C
	private int BAILLKDINBE_Crypted; // 0x60
	private sbyte KGPJMCOKANB_Crypted; // 0x64

	public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1DE19C0 DEMEPMAEJOO_get_id 0x1DE19D0 HIGKAIDMOKN_set_id
	public int MGLJCOMOGLO_BtnId { get { return CFKADAPCGMI_Crypted ^ FBGGEFFJJHB_xor; } set { CFKADAPCGMI_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1DE19E0 AEIJNJKLGOI_get_BtnId 0x1DE19F0 LEOGMFOMAJK_set_BtnId
	public int GNOFNIOLPPC_ImgId { get { return JOPENLCBJHH_Crypted ^ FBGGEFFJJHB_xor; } set { JOPENLCBJHH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1DE1A00 GFDJOOOJFOA_get_ImgId 0x1DE1A10 BINBNBMIJLA_set_ImgId
	public int BOJCOPAALNC_EventId { get { return AMAEPCDKEGF_Crypted ^ FBGGEFFJJHB_xor; } set { AMAEPCDKEGF_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1DE1A20 PHFOCDMIEIO_get_EventId 0x1DE1A30 MBPAGIFEGHH_set_EventId
	public GPNHNIGPGCL PNDEAHGLJIC_BtnType { get { return (GPNHNIGPGCL)(AFPJHODHJAB_Crypted ^ FBGGEFFJJHB_xor); } set { AFPJHODHJAB_Crypted = (int)value ^ FBGGEFFJJHB_xor; } } //0x1DE1A40 FCMJGJNLHJC_get_BtnType 0x1DE1A50 PMDHFNCONCH_set_BtnType
	public ONKLMFNGCHJ OAAKAAFFFLE { get { return (ONKLMFNGCHJ)(LNFKNALODJB_Crypted ^ FBGGEFFJJHB_xor); } set { LNFKNALODJB_Crypted = (int)value ^ FBGGEFFJJHB_xor; } } //0x1DE1A60 EEHLNEDINEB_bgs 0x1DE1A70 CBOMGBPMEKN_bgs
	public int GGHDEDJFFOM { get { return GHJIEPHJJEK_Crypted ^ FBGGEFFJJHB_xor; } set { GHJIEPHJJEK_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1DE1A80 JJJMMJMGNEF_bgs 0x1DE1A90 DEMJPCDIJEH_bgs
	public string KLFCPBPGKJK { get { return NLCIPNCPOII.DNJEJEANJGL_Value; } set { NLCIPNCPOII.DNJEJEANJGL_Value = value; } } //0x1DE1AA0 BBAHHOKNEED_bgs 0x1DE1ACC LBNBKPMDMBK_bgs
	public int LPDLBACJKIB_TransId { get { return CKNBCJIIMAM_Crypted ^ FBGGEFFJJHB_xor; } set { CKNBCJIIMAM_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1DE1B00 KJEJNNIKGJA_get_TransId 0x1DE1B10 FPPDFHIGMCE_set_TransId
	public bool FICHDKOOOOB_Enabled { get { return ANBAEAGJNEE_Crypted == HKKJGAJPNIL_True; } set { ANBAEAGJNEE_Crypted = value ? HKKJGAJPNIL_True : FKHFJOKHNAK_False; } } //0x1DE1B20 MIMBAGECCNP_bgs 0x1DE1B34 NGGOBNINJOD_bgs
	public long PDBPFJJCADD_open_at { get { return PCLNFCNIECH_OpenAtCrypted ^ BBEGLBMOBOF_xorl; } set { PCLNFCNIECH_OpenAtCrypted = value ^ BBEGLBMOBOF_xorl; } } //0x1DE1B64 FOACOMBHPAC_get_open_at 0x1DE1B78 NBACOBCOJCA_set_open_at
	public long FDBNFFNFOND_close_at { get { return HHPIJHADAOB_CloseAtCrypted ^ BBEGLBMOBOF_xorl; } set { HHPIJHADAOB_CloseAtCrypted = value ^ BBEGLBMOBOF_xorl; } } //0x1DE1B98 BPJOGHJCLDJ_get_close_at 0x1DE1BAC NLJKMCHOCBK_set_close_at
	public bool LHMOAJAIJCO_is_new { get { return MFHADBAGMCE_is_new_Crypted == HKKJGAJPNIL_True; } set { MFHADBAGMCE_is_new_Crypted = value ? HKKJGAJPNIL_True : FKHFJOKHNAK_False; } } //0x1DE1BCC ECKLIIBFNGI_bgs 0x1DE1BE0 BGNCBCKNKNK_bgs
	public int BDEOMEBFDFF_gacha_id { get { return HPNLHEAENJB_Crypted ^ FBGGEFFJJHB_xor; } set { HPNLHEAENJB_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1DE1C10 OEIBDDGJBMK_get_gacha_id 0x1DE1C20 LELOPHJEIIM_set_gacha_id
	public int LCCDKCPBJAK_BannerId { get { return KIAAIBDCMCC_Crypted ^ FBGGEFFJJHB_xor; } set { KIAAIBDCMCC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1DE1C30 EJCGPCCMFOC_get_BannerId 0x1DE1C40 PIDILOOINOG_set_BannerId
	public OHKBMOEIPEP IJIDIJBPGNB { get { return (OHKBMOEIPEP)(AIMMOBGOLML_Crypted ^ FBGGEFFJJHB_xor); } set { AIMMOBGOLML_Crypted = (int)value ^ FBGGEFFJJHB_xor; } } //0x1DE1C50 OMIAAFEEGBJ_bgs 0x1DE1C60 PEBNFGKBHIE_bgs
	public NBADGBJMBMM MMJHAMFEHCH { get { return (NBADGBJMBMM)(BAILLKDINBE_Crypted ^ FBGGEFFJJHB_xor); } set { BAILLKDINBE_Crypted = (int)value ^ FBGGEFFJJHB_xor; } } //0x1DE1C70 IILBCPNOFLG_bgs 0x1DE1C80 DIMLNOKMHHO_bgs
	public bool CDPAEHCPPAM { get { return KGPJMCOKANB_Crypted == HKKJGAJPNIL_True; } set { KGPJMCOKANB_Crypted = value ? HKKJGAJPNIL_True : FKHFJOKHNAK_False; } } //0x1DE1C90 OEBCFFCMEKH_bgs 0x1DE1CA4 OCMPHCGEIML_bgs

	// RVA: 0x1DE1CD4 Offset: 0x1DE1CD4 VA: 0x1DE1CD4
	public OHKECKAPJJL()
    {
        FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
        BBEGLBMOBOF_xorl = FBGGEFFJJHB_xor;
        OBKGEDCKHHE_Init(0);
    }

	// // RVA: 0x1DE1DA0 Offset: 0x1DE1DA0 VA: 0x1DE1DA0
	public void OBKGEDCKHHE_Init(int _PPFNGGCBJKC_id)
    {
        BOJCOPAALNC_EventId = 0;
        GGHDEDJFFOM = 0;
        MGLJCOMOGLO_BtnId = _PPFNGGCBJKC_id;
        GNOFNIOLPPC_ImgId = 1;
        PNDEAHGLJIC_BtnType = (GPNHNIGPGCL)_PPFNGGCBJKC_id;
        KLFCPBPGKJK = "";
        LPDLBACJKIB_TransId = 0;
        FICHDKOOOOB_Enabled = false;
        PDBPFJJCADD_open_at = 0;
        FDBNFFNFOND_close_at = 0;
        BDEOMEBFDFF_gacha_id = 0;
        LCCDKCPBJAK_BannerId = 0;
        IJIDIJBPGNB = OHKBMOEIPEP.HJNNKCMLGFL_0_None;
        MMJHAMFEHCH = NBADGBJMBMM.HIDGJCIFFNJ_0;
        CDPAEHCPPAM = false;
        LHMOAJAIJCO_is_new = false;
    }
}
