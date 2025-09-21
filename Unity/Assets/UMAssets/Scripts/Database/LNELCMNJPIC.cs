
using System.Collections.Generic;
using UnityEngine.Localization.SmartFormat.Utilities;
using XeSys;

[System.Obsolete("Use LNELCMNJPIC_EventGoDiva", true)]
public class LNELCMNJPIC { }
public class LNELCMNJPIC_EventGoDiva : DIHHCBACKGG_DbSection
{
	public class HBIFAOGFEEO
	{
		public int OBGBAOLONDD_UniqueId; // 0x8
		public string OPFGFINHFCE_name; // 0xC
		public string HEDAGCNPHGD_RankingName; // 0x10
		public string OCGFKMHNEOF_name_for_api; // 0x14
		public string FEMMDNIELFC_Desc; // 0x18
		public long BONDDBOFBND_RankingStart; // 0x20
		public long EHHFFKAFOMC; // 0x28
		public long HPNOGLIFJOP_RankingEnd; // 0x30
		public long LNFKGHNHJKE_RankingEnd2; // 0x38
		public long JGMDAOACOJF_RewardStart; // 0x40
		public long IDDBFFBPNGI_RewardEnd; // 0x48
		public long KNLGKBBIBOH_RewardEnd2; // 0x50
		public long JBFDHOIKAIK_InventoryEndDate; // 0x58
		public int KHIKEGLBGAF_RankingRewardScene; // 0x60
		public int DPJCFLKFEPN; // 0x64
		public int MJBKGOJBPAD_item_type; // 0x68
		public sbyte POGEFBMBPCB_MonthOdd; // 0x6C
		public sbyte AHKNMANFILO_DayGroup; // 0x6D
		public sbyte MOEKELIIDEO_SaveIdx; // 0x6E
		public string OMCAOJJGOGG_Lb; // 0x70
		public int EKJFNHHKBPL; // 0x74
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO_KeyPrefix = new NNJFKLBPBNK_SecureString(); // 0x78
		private NNJFKLBPBNK_SecureString NJKIMJAFCPC = new NNJFKLBPBNK_SecureString(); // 0x7C
		public sbyte MPKNCMEAMLO; // 0x80
		public sbyte AHKPNPNOAMO_ExtreamOpen; // 0x81
		public sbyte HKKNEAGCIEB_RankingSupport; // 0x82
		public List<string> MPCAGEPEJJJ_Key = new List<string>(); // 0x84
		public List<int> JHPCPNJJHLI_RankingThreshold = new List<int>(); // 0x88
		public int HIOOGLEJBKM_StartAdventureId; // 0x8C
		public int FJCADCDNPMP_EndAdventureId; // 0x90
		public int[] EJBGHLOOLBC_HelpIds; // 0x94
		public List<int> EEOGPJJCKHH_Drops = new List<int>(); // 0x98

		public string OCDMGOGMHGE_AchievementIdPrefix { get { return EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value; } set { EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value = value; } } //0x10C1C68 HBAAAKFHDBB 0x10C009C NHJLJOIPOFK
		public string PJBILOFOCIC { get { return NJKIMJAFCPC.DNJEJEANJGL_Value; } set { NJKIMJAFCPC.DNJEJEANJGL_Value = value; } } //0x10C1C94 NOEFEAIFHCL 0x10C00D0 GJIJFGNONEL

		//// RVA: 0x10C1CC0 Offset: 0x10C1CC0 VA: 0x10C1CC0
		//public void OMBPLLMLOHL(string _LJNAKDMILMC_key) { }

		//// RVA: 0x10C1D40 Offset: 0x10C1D40 VA: 0x10C1D40
		//public string HBCCJELFNLI(int _AHHJLDLAPAN_DivaId) { }

		//// RVA: 0x10BDBC8 Offset: 0x10BDBC8 VA: 0x10BDBC8
		public void LHPDDGIJKNB_Reset()
		{
			OBGBAOLONDD_UniqueId = 0;
			JGMDAOACOJF_RewardStart = 0;
			IDDBFFBPNGI_RewardEnd = 0;
			JBFDHOIKAIK_InventoryEndDate = 0;
			KHIKEGLBGAF_RankingRewardScene = 0;
			DPJCFLKFEPN = 0;
			MJBKGOJBPAD_item_type = 0;
			BONDDBOFBND_RankingStart = 0;
			EHHFFKAFOMC = 0;
			HPNOGLIFJOP_RankingEnd = 0;
			POGEFBMBPCB_MonthOdd = 0;
			MOEKELIIDEO_SaveIdx = 0;
			MJBKGOJBPAD_item_type = 1;
			EKJFNHHKBPL = 0;
			OPFGFINHFCE_name = null;
			HEDAGCNPHGD_RankingName = null;
			OCGFKMHNEOF_name_for_api = null;
			FEMMDNIELFC_Desc = null;
			OCDMGOGMHGE_AchievementIdPrefix = "";
			PJBILOFOCIC = "";
			HKKNEAGCIEB_RankingSupport = 0;
			MPKNCMEAMLO = 0;
			MPCAGEPEJJJ_Key.Clear();
			JHPCPNJJHLI_RankingThreshold.Clear();
			OMCAOJJGOGG_Lb = "";
			HIOOGLEJBKM_StartAdventureId = 0;
			FJCADCDNPMP_EndAdventureId = 0;
			EJBGHLOOLBC_HelpIds = null;
			EEOGPJJCKHH_Drops.Clear();
		}

		//// RVA: 0x10C15D4 Offset: 0x10C15D4 VA: 0x10C15D4
		//public uint CAOGDCBPBAN() { }
	}

	public class POLLFBLLAHL
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int ICKOHEDLEFP_ValueCrypted; // 0x10
		private int PCLNFCNIECH_OpenAtCrypted; // 0x14
		private int HHPIJHADAOB_CloseAtCrypted; // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C2330 DEMEPMAEJOO 0x10C2340 HIGKAIDMOKN
		public int JBGEEPFKIGG_Value { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C2350 OLOCMINKGON 0x10C2360 ABAFHIBFKCE
		public int PDBPFJJCADD_open_at { get { return PCLNFCNIECH_OpenAtCrypted ^ FBGGEFFJJHB_xor; } set { PCLNFCNIECH_OpenAtCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C2370 FOACOMBHPAC 0x10C2380 NBACOBCOJCA
		public int FDBNFFNFOND_CloseAt { get { return HHPIJHADAOB_CloseAtCrypted ^ FBGGEFFJJHB_xor; } set { HHPIJHADAOB_CloseAtCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C2390 BPJOGHJCLDJ 0x10C23A0 NLJKMCHOCBK

		//// RVA: 0x10C178C Offset: 0x10C178C VA: 0x10C178C
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x10C0340 Offset: 0x10C0340 VA: 0x10C0340
		public void KHEKNNFCAOI_Init(int JBGJDEELLOP, int KNEFBLHBDBG, FOKPKJFHNLO JMHECKKKMLK)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			PPFNGGCBJKC_id = 0;
			JBGEEPFKIGG_Value = 0;
			PDBPFJJCADD_open_at = 0;
			FDBNFFNFOND_CloseAt = 0;
			PPFNGGCBJKC_id = (int)JMHECKKKMLK.DGBJMMJALMH[JBGJDEELLOP - 1].PPFNGGCBJKC;
			JBGEEPFKIGG_Value = (int)JMHECKKKMLK.DGBJMMJALMH[JBGJDEELLOP - 1].JBGEEPFKIGG;
			PDBPFJJCADD_open_at = JMHECKKKMLK.DGBJMMJALMH[JBGJDEELLOP - 1].PDBPFJJCADD;
			FDBNFFNFOND_CloseAt = JMHECKKKMLK.DGBJMMJALMH[JBGJDEELLOP - 1].FDBNFFNFOND;
		}

		//// RVA: 0x10C23B0 Offset: 0x10C23B0 VA: 0x10C23B0
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }
	}

	public class DPKGKNJBFBJ
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int OAMCHDAAINE_Crypted; // 0x10
		private int NKBIFNAGIMH_Crypted; // 0x14
		private int LBPNMNOCJMH_Crypted; // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1AF8 DEMEPMAEJOO 0x10C1B08 HIGKAIDMOKN
		public int LJELGFAFGAB_so { get { return OAMCHDAAINE_Crypted ^ FBGGEFFJJHB_xor; } set { OAMCHDAAINE_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1B18 APHFJDOOLCK 0x10C1B28 KBEAJHMCGPM
		public int KNEDJFLCCLN_vo { get { return NKBIFNAGIMH_Crypted ^ FBGGEFFJJHB_xor; } set { NKBIFNAGIMH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1B38 DKJNGOIGJGH 0x10C1B48 EOMMBJGKKJI
		public int MBAMIOJNGBD_ch { get { return LBPNMNOCJMH_Crypted ^ FBGGEFFJJHB_xor; } set { LBPNMNOCJMH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1B58 NJBKAFBFJML 0x10C1B68 IGAFGHBHMIF

		//// RVA: 0x10C17B8 Offset: 0x10C17B8 VA: 0x10C17B8
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x10C048C Offset: 0x10C048C VA: 0x10C048C
		public void KHEKNNFCAOI_Init(int JBGJDEELLOP, int KNEFBLHBDBG, FOKPKJFHNLO JMHECKKKMLK)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			PPFNGGCBJKC_id = 0;
			LJELGFAFGAB_so = 0;
			KNEDJFLCCLN_vo = 0;
			MBAMIOJNGBD_ch = 0;
			PPFNGGCBJKC_id = (int)JMHECKKKMLK.MPPGCHJPPKM[JBGJDEELLOP - 1].PPFNGGCBJKC;
			LJELGFAFGAB_so = (int)JMHECKKKMLK.MPPGCHJPPKM[JBGJDEELLOP - 1].LJELGFAFGAB;
			KNEDJFLCCLN_vo = (int)JMHECKKKMLK.MPPGCHJPPKM[JBGJDEELLOP - 1].KNEDJFLCCLN;
			MBAMIOJNGBD_ch = (int)JMHECKKKMLK.MPPGCHJPPKM[JBGJDEELLOP - 1].MBAMIOJNGBD;
		}

		//// RVA: 0x10C1B78 Offset: 0x10C1B78 VA: 0x10C1B78
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }
	}

	public class BKBNHEEEHIB
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public int LKIFDCEKDCK_exp; // 0xC
		public int DKHIHHMOIKM_Bonus; // 0x10

		//// RVA: 0x10C17E4 Offset: 0x10C17E4 VA: 0x10C17E4
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x10C05D8 Offset: 0x10C05D8 VA: 0x10C05D8
		public void KHEKNNFCAOI_Init(int JBGJDEELLOP, int KNEFBLHBDBG, FOKPKJFHNLO JMHECKKKMLK)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			LKIFDCEKDCK_exp = 0;
			DKHIHHMOIKM_Bonus = 0;
			LKIFDCEKDCK_exp = (int)JMHECKKKMLK.EENKKKDBABF[JBGJDEELLOP - 1].LKIFDCEKDCK;
			DKHIHHMOIKM_Bonus = (int)JMHECKKKMLK.EENKKKDBABF[JBGJDEELLOP - 1].DKHIHHMOIKM;
		}

		//// RVA: 0x10C1AC8 Offset: 0x10C1AC8 VA: 0x10C1AC8
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }
	}

	public class BGDLJMBDNOL
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int BEPBNPOOBEO_Crypted; // 0x10
		private int OCAHLJMJNBH_Crypted; // 0x14
		private int ICKOHEDLEFP_ValueCrypted; // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1998 DEMEPMAEJOO 0x10C19A8 HIGKAIDMOKN
		private int ECLAOLBGCDD_tbl { get { return BEPBNPOOBEO_Crypted ^ FBGGEFFJJHB_xor; } set { BEPBNPOOBEO_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x10C19B8 DPILCBJHCPP 0x10C19C8 BHCFGBAPKBF
		public int OMCOIBDHOCF { get { return OCAHLJMJNBH_Crypted ^ FBGGEFFJJHB_xor; } set { OCAHLJMJNBH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x10C19D8 CFNIHNGBFCB 0x10C19E8 OLFHCIKJJIF
		private int JBGEEPFKIGG_Value { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C19F8 OLOCMINKGON 0x10C1A08 ABAFHIBFKCE
		public int LJELGFAFGAB_so { get { return ECLAOLBGCDD_tbl != 0 && ECLAOLBGCDD_tbl != 1 ? ECLAOLBGCDD_tbl : JBGEEPFKIGG_Value; } } //0x10C1A18 APHFJDOOLCK
		public int KNEDJFLCCLN_vo { get { return ECLAOLBGCDD_tbl != 0 && ECLAOLBGCDD_tbl != 2 ? ECLAOLBGCDD_tbl : JBGEEPFKIGG_Value; } } //0x10C1A5C DKJNGOIGJGH
		public int MBAMIOJNGBD_ch { get { return ECLAOLBGCDD_tbl != 0 && ECLAOLBGCDD_tbl != 3 ? ECLAOLBGCDD_tbl : JBGEEPFKIGG_Value; } } //0x10C1A88 NJBKAFBFJML
		public bool EJFAEKPGKNJ_daily { get { return ECLAOLBGCDD_tbl == 0; } } //0x10C1A44 GDEHEBKFALC

		//// RVA: 0x10C17F4 Offset: 0x10C17F4 VA: 0x10C17F4
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x10C06A8 Offset: 0x10C06A8 VA: 0x10C06A8
		public void KHEKNNFCAOI_Init(int JBGJDEELLOP, int KNEFBLHBDBG, FOKPKJFHNLO JMHECKKKMLK)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			PPFNGGCBJKC_id = 0;
			ECLAOLBGCDD_tbl = 0;
			OMCOIBDHOCF = 0;
			JBGEEPFKIGG_Value = 0;
			PPFNGGCBJKC_id = (int)JMHECKKKMLK.DHDJOPFCOPP[JBGJDEELLOP - 1].PPFNGGCBJKC;
			ECLAOLBGCDD_tbl = (int)JMHECKKKMLK.DHDJOPFCOPP[JBGJDEELLOP - 1].ECLAOLBGCDD;
			OMCOIBDHOCF = (int)JMHECKKKMLK.DHDJOPFCOPP[JBGJDEELLOP - 1].OMCOIBDHOCF;
			JBGEEPFKIGG_Value = (int)JMHECKKKMLK.DHDJOPFCOPP[JBGJDEELLOP - 1].JBGEEPFKIGG;
		}

		//// RVA: 0x10C1AB4 Offset: 0x10C1AB4 VA: 0x10C1AB4
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }
	}

	public class EOJAGLGHMCL
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int HNJHPNPFAAN_EnabledCrypted; // 0x10
		private int ICKOHEDLEFP_ValueCrypted; // 0x14
		private int KLAPHOKNEDG_Crypted; // 0x18
		private int AHNNLEGMCCN_Crypted; // 0x1C
		private int JMFCALBAINN_Crypted; // 0x20

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1B8C DEMEPMAEJOO 0x10C1B9C HIGKAIDMOKN
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1BAC JPCJNLHHIPE 0x10C1BBC JJFJNEJLBDG
		// BonusRate
		public int JBGEEPFKIGG_Value { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1BCC OLOCMINKGON 0x10C1BDC ABAFHIBFKCE
		public int BEBJKJKBOGH_Date { get { return KLAPHOKNEDG_Crypted ^ FBGGEFFJJHB_xor; } set { KLAPHOKNEDG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1BEC DIAPHCJBPFD 0x10C1BFC IHAIKPNEEJE
		public int FNEIADJMHHO_st { get { return AHNNLEGMCCN_Crypted ^ FBGGEFFJJHB_xor; } set { AHNNLEGMCCN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1C0C FAPDANAMOKF 0x10C1C1C JIHDPPHAAOJ
		public int EICJBAEDMNM_DaySecondsEnd { get { return JMFCALBAINN_Crypted ^ FBGGEFFJJHB_xor; } set { JMFCALBAINN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1C2C KINEOEMJLIF 0x10C1C3C MFGDGANNOMO

		//// RVA: 0x10C1820 Offset: 0x10C1820 VA: 0x10C1820
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x10C07F4 Offset: 0x10C07F4 VA: 0x10C07F4
		public void KHEKNNFCAOI_Init(int JBGJDEELLOP, int KNEFBLHBDBG, FOKPKJFHNLO JMHECKKKMLK)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			PPFNGGCBJKC_id = 0;
			PLALNIIBLOF_en = 0;
			JBGEEPFKIGG_Value = 0;
			BEBJKJKBOGH_Date = 0;
			FNEIADJMHHO_st = 0;
			EICJBAEDMNM_DaySecondsEnd = 0;
			PPFNGGCBJKC_id = (int)JMHECKKKMLK.GICHIKNDMHE[JBGJDEELLOP - 1].PPFNGGCBJKC;
			PLALNIIBLOF_en = (int)JMHECKKKMLK.GICHIKNDMHE[JBGJDEELLOP - 1].PLALNIIBLOF;
			JBGEEPFKIGG_Value = (int)JMHECKKKMLK.GICHIKNDMHE[JBGJDEELLOP - 1].JBGEEPFKIGG;
			BEBJKJKBOGH_Date = JMHECKKKMLK.GICHIKNDMHE[JBGJDEELLOP - 1].BEBJKJKBOGH;
			FNEIADJMHHO_st = JMHECKKKMLK.GICHIKNDMHE[JBGJDEELLOP - 1].FNEIADJMHHO;
			EICJBAEDMNM_DaySecondsEnd = JMHECKKKMLK.GICHIKNDMHE[JBGJDEELLOP - 1].EICJBAEDMNM;
		}

		//// RVA: 0x10C1C4C Offset: 0x10C1C4C VA: 0x10C1C4C
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }
	}

	public class LDAGBDINHMC
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int FMDDJNKEBBB_Crypted; // 0x10
		private int MDKGAAMBJDJ_Crypted; // 0x14
		private int GGEBNMPPEID_Crypted; // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C2288 DEMEPMAEJOO 0x10C2298 HIGKAIDMOKN
		public int CNKFPJCGNFE_SceneId { get { return FMDDJNKEBBB_Crypted ^ FBGGEFFJJHB_xor; } set { FMDDJNKEBBB_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x10C22A8 GJBOGOFHGNP 0x10C22B8 GJDGIDCMJMH
		public int GNFBMCGMCFO_BonusBefore { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB_xor; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x10C22C8 NCIMMDJLPLJ 0x10C22D8 HNAJAFBHOLM
		public int BFFGFAMJAIG_BonusAfter { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB_xor; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x10C22E8 PKMNOMELPMN 0x10C22F8 IABBJBAHKCE

		//// RVA: 0x10C196C Offset: 0x10C196C VA: 0x10C196C
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x10C09AC Offset: 0x10C09AC VA: 0x10C09AC
		public void KHEKNNFCAOI_Init(int JBGJDEELLOP, int KNEFBLHBDBG, FOKPKJFHNLO JMHECKKKMLK)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			PPFNGGCBJKC_id = 0;
			CNKFPJCGNFE_SceneId = 0;
			GNFBMCGMCFO_BonusBefore = 0;
			BFFGFAMJAIG_BonusAfter = 0;
			PPFNGGCBJKC_id = JMHECKKKMLK.OLACFKILCFD[JBGJDEELLOP - 1].PPFNGGCBJKC;
			CNKFPJCGNFE_SceneId = JMHECKKKMLK.OLACFKILCFD[JBGJDEELLOP - 1].CNKFPJCGNFE;
			GNFBMCGMCFO_BonusBefore = JMHECKKKMLK.OLACFKILCFD[JBGJDEELLOP - 1].GNFBMCGMCFO;
			BFFGFAMJAIG_BonusAfter = JMHECKKKMLK.OLACFKILCFD[JBGJDEELLOP - 1].BFFGFAMJAIG;
		}

		//// RVA: 0x10C2308 Offset: 0x10C2308 VA: 0x10C2308
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }
	}

	public class IONELJACGCL
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int MDKGAAMBJDJ_Crypted; // 0x10
		private int GGEBNMPPEID_Crypted; // 0x14

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C2150 DEMEPMAEJOO 0x10C2160 HIGKAIDMOKN
		public int GNFBMCGMCFO_BonusBefore { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB_xor; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x10C2170 NCIMMDJLPLJ 0x10C2180 HNAJAFBHOLM
		public int BFFGFAMJAIG_BonusAfter { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB_xor; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x10C2190 PKMNOMELPMN 0x10C21A0 IABBJBAHKCE

		//// RVA: 0x10C1948 Offset: 0x10C1948 VA: 0x10C1948
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x10C0AF8 Offset: 0x10C0AF8 VA: 0x10C0AF8
		public void KHEKNNFCAOI_Init(int _OIPCCBHIKIA_index, int KNEFBLHBDBG, FOKPKJFHNLO JMHECKKKMLK)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			PPFNGGCBJKC_id = 0;
			GNFBMCGMCFO_BonusBefore = 0;
			BFFGFAMJAIG_BonusAfter = 0;
			PPFNGGCBJKC_id = JMHECKKKMLK.MIOCOKLMLBD[_OIPCCBHIKIA_index - 1].PPFNGGCBJKC;
			GNFBMCGMCFO_BonusBefore = JMHECKKKMLK.MIOCOKLMLBD[_OIPCCBHIKIA_index - 1].GNFBMCGMCFO;
			BFFGFAMJAIG_BonusAfter = JMHECKKKMLK.MIOCOKLMLBD[_OIPCCBHIKIA_index - 1].BFFGFAMJAIG;
		}

		//// RVA: 0x10C21B0 Offset: 0x10C21B0 VA: 0x10C21B0
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }
	}

	public class JNHHOCNJIKD
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int HHEEHHHLKHC_Crypted; // 0xC
		private int LGAIHLFAPDC_Crypted; // 0x10
		public List<int> KDNMBOBEGJM_GachaIds = new List<int>(); // 0x14

		public int KHPHAAMGMJP { get { return HHEEHHHLKHC_Crypted ^ FBGGEFFJJHB_xor; } set { HHEEHHHLKHC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x10C21C0 ABFDDKBBPCH 0x10C21D0 MHDOIIEMDEH
		public int OFIAENKCJME { get { return LGAIHLFAPDC_Crypted ^ FBGGEFFJJHB_xor; } set { LGAIHLFAPDC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x10C21E0 KADLAKFANGA 0x10C21F0 AIDAPNCEPOB

		//// RVA: 0x10C1870 Offset: 0x10C1870 VA: 0x10C1870
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x10C0C88 Offset: 0x10C0C88 VA: 0x10C0C88
		public void KHEKNNFCAOI_Init(int _OIPCCBHIKIA_index, int KNEFBLHBDBG, FOKPKJFHNLO JMHECKKKMLK)
		{
			LHPDDGIJKNB_Reset(KNEFBLHBDBG);
			KHPHAAMGMJP = JMHECKKKMLK.IEJLJIHIDJC[_OIPCCBHIKIA_index - 1].KHPHAAMGMJP;
			OFIAENKCJME = JMHECKKKMLK.IEJLJIHIDJC[_OIPCCBHIKIA_index - 1].OFIAENKCJME;
			for(int i = 0; i < JMHECKKKMLK.IEJLJIHIDJC[_OIPCCBHIKIA_index - 1].JMLCLHHLJHM.Length; i++)
			{
				KDNMBOBEGJM_GachaIds.Add(JMHECKKKMLK.IEJLJIHIDJC[_OIPCCBHIKIA_index - 1].JMLCLHHLJHM[i]);
			}
		}

		//// RVA: 0x10C2200 Offset: 0x10C2200 VA: 0x10C2200
		public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			KHPHAAMGMJP = 0;
			OFIAENKCJME = 0;
			KDNMBOBEGJM_GachaIds.Clear();
		}
	}

	public class OPNEOOPNELG
	{
		public int GLCLFMGPMAN_ItemId; // 0x8
		public int HMFFHLPNMPH_Count; // 0xC
		public int NMKEOMCMIPP_RewardId; // 0x10
		public int HJAFPEBIBOP_Limit; // 0x14
		public bool JOPPFEHKNFO_Pickup; // 0x18

		public bool PJPDOCNJNGJ_TimeLimited { get { return HJAFPEBIBOP_Limit > 0; } } //0x10C231C MBEBLALDBHJ

		//// RVA: 0x10C1ADC Offset: 0x10C1ADC VA: 0x10C1ADC
		//public uint CAOGDCBPBAN() { }
	}

	public class DKPKNBNMOGI
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int DNBFMLBNAEE_Point; // 0xC
		public List<OPNEOOPNELG> AHJNPEAMCCH_Rewards = new List<OPNEOOPNELG>(); // 0x10
		public bool JOPPFEHKNFO_Pickup; // 0x14
		
		//// RVA: 0x10C1694 Offset: 0x10C1694 VA: 0x10C1694
		//public uint CAOGDCBPBAN() { }
	}

	public class HGLNJDGOPMM
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public int EHOIENNDEDH_IdCrypted; // 0xC
		public int HNJHPNPFAAN_EnabledCrypted; // 0x10
		public int CNMODNFFBLP_FMusicIdCrypted; // 0x14
		public long PCLNFCNIECH_OpenAtCrypted; // 0x18
		public long HHPIJHADAOB_CloseAtCrypted; // 0x20

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1DC0 DEMEPMAEJOO 0x10C1DCC HIGKAIDMOKN
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1DDC JPCJNLHHIPE 0x10C1DEC JJFJNEJLBDG
		public int MPLGPBNJDJB_FreeMusicId { get { return CNMODNFFBLP_FMusicIdCrypted ^ FBGGEFFJJHB_xor; } set { CNMODNFFBLP_FMusicIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1DFC KADAEAOKJNE 0x10C1E0C MBKFNLHPNPP
		public long PDBPFJJCADD_open_at { get { return PCLNFCNIECH_OpenAtCrypted ^ FBGGEFFJJHB_xor; } set { PCLNFCNIECH_OpenAtCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1E1C FOACOMBHPAC 0x10C1E34 NBACOBCOJCA
		public long FDBNFFNFOND_CloseAt { get { return HHPIJHADAOB_CloseAtCrypted ^ FBGGEFFJJHB_xor; } set { HHPIJHADAOB_CloseAtCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10C1E48 BPJOGHJCLDJ 0x10C1E60 NLJKMCHOCBK

		//// RVA: 0x10C1E74 Offset: 0x10C1E74 VA: 0x10C1E74
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id, int KNEFBLHBDBG) { }

		//// RVA: 0x10C1EA4 Offset: 0x10C1EA4 VA: 0x10C1EA4
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, int KNEFBLHBDBG, EDOHBJAPLPF _IDLHJIOMJBK_Data) { }

		//// RVA: 0x10C01A0 Offset: 0x10C01A0 VA: 0x10C01A0
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, int KNEFBLHBDBG, FOKPKJFHNLO JMHECKKKMLK)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			PPFNGGCBJKC_id = 0;
			PLALNIIBLOF_en = 0;
			MPLGPBNJDJB_FreeMusicId = 0;
			PDBPFJJCADD_open_at = 0;
			FDBNFFNFOND_CloseAt = 0;
            AFEHHCKJJGB data = JMHECKKKMLK.GHIHAGAOPNC[_PPFNGGCBJKC_id - 1];
			PPFNGGCBJKC_id = (int)data.PPFNGGCBJKC;
			PLALNIIBLOF_en = (int)data.PLALNIIBLOF;
			MPLGPBNJDJB_FreeMusicId = (int)data.MPLGPBNJDJB;
			PDBPFJJCADD_open_at = data.PDBPFJJCADD;
			FDBNFFNFOND_CloseAt = data.FDBNFFNFOND;
        }

		//// RVA: 0x10C2104 Offset: 0x10C2104 VA: 0x10C2104
		//public uint CAOGDCBPBAN() { }
	}

	public class OOGLJJLAMBD
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int KFCIJBLDHOK_v1; // 0xC
		public int JLEIHOEGMOP_v2; // 0x10
	}

	public HBIFAOGFEEO NGHKJOEDLIP_Settings = new HBIFAOGFEEO(); // 0x20
	public List<DKPKNBNMOGI> FCIPEDFHFEM_TotalRewards = new List<DKPKNBNMOGI>(); // 0x24
	public List<HGLNJDGOPMM> IJJHFGOIDOK_EventMusic = new List<HGLNJDGOPMM>(); // 0x28
	public List<AKIIJBEJOEP> NNMPGOAGEOL_quests = new List<AKIIJBEJOEP>(); // 0x2C
	public List<POLLFBLLAHL> EAPOKGEIFKA = new List<POLLFBLLAHL>(); // 0x30
	public List<DPKGKNJBFBJ> AEHKHFCKHJH = new List<DPKGKNJBFBJ>(); // 0x34
	public List<BKBNHEEEHIB> CDMAJPFOLKK = new List<BKBNHEEEHIB>(); // 0x38
	public List<BGDLJMBDNOL> DLEFGPMFCMA = new List<BGDLJMBDNOL>(); // 0x3C
	public List<EOJAGLGHMCL> BGHBALGJNFF = new List<EOJAGLGHMCL>(); // 0x40
	public List<LDAGBDINHMC> GEGAEDDGNMA_Bonuses = new List<LDAGBDINHMC>(); // 0x44//EpBonusByScene
	public List<IONELJACGCL> OGMHMAGDNAM = new List<IONELJACGCL>(); // 0x48
	public List<JNHHOCNJIKD> LHAKGDAGEMM_EpBonusInfo = new List<JNHHOCNJIKD>(); // 0x4C
	private List<NNJFKLBPBNK_SecureString> IFBBNEGGCIH; // 0x58
	private List<CEBFFLDKAEC_SecureInt> JNJAOACIGOC; // 0x5C
	public List<OOGLJJLAMBD> ADPFKHEMNBL = new List<OOGLJJLAMBD>(); // 0x60
	public List<OOGLJJLAMBD> GKCBPNPEJJF = new List<OOGLJJLAMBD>(); // 0x64
	public List<AIGOEAPJGEB> MBHDIJJEOFL = new List<AIGOEAPJGEB>(); // 0x68
	public List<IJNOIMLNBGN> LLCLJBEJOPM_BannerInfo = new List<IJNOIMLNBGN>(); // 0x6C

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_String { get; private set; } // 0x50 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_IntArray { get; private set; } // 0x54 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x10BD0CC Offset: 0x10BD0CC VA: 0x10BD0CC
	public string EFEGBHACJAL(string _LJNAKDMILMC_key, string KKMJBMKHGNH)
	{
		if(FJOEBCMGDMI_String.ContainsKey(_LJNAKDMILMC_key))
		{
			return FJOEBCMGDMI_String[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		}
		return KKMJBMKHGNH;
	}

	//// RVA: 0x10BD1B0 Offset: 0x10BD1B0 VA: 0x10BD1B0
	public int LPJLEHAJADA(string _LJNAKDMILMC_key, int KKMJBMKHGNH)
	{
		if(OHJFBLFELNK_IntArray.ContainsKey(_LJNAKDMILMC_key))
		{
			return OHJFBLFELNK_IntArray[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		}
		return KKMJBMKHGNH;
	}

	// RVA: 0x10BD294 Offset: 0x10BD294 VA: 0x10BD294
	public LNELCMNJPIC_EventGoDiva()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK_IntArray = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		JNJAOACIGOC = new List<CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI_String = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		IFBBNEGGCIH = new List<NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 32;
	}

	// RVA: 0x10BD848 Offset: 0x10BD848 VA: 0x10BD848 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		NGHKJOEDLIP_Settings.LHPDDGIJKNB_Reset();
		FCIPEDFHFEM_TotalRewards.Clear();
		NNMPGOAGEOL_quests.Clear();
		OHJFBLFELNK_IntArray.Clear();
		JNJAOACIGOC.Clear();
		FJOEBCMGDMI_String.Clear();
		IFBBNEGGCIH.Clear();
		EAPOKGEIFKA.Clear();
		AEHKHFCKHJH.Clear();
		CDMAJPFOLKK.Clear();
		DLEFGPMFCMA.Clear();
		BGHBALGJNFF.Clear();
		ADPFKHEMNBL.Clear();
		GKCBPNPEJJF.Clear();
		MBHDIJJEOFL.Clear();
		LLCLJBEJOPM_BannerInfo.Clear();
		GEGAEDDGNMA_Bonuses.Clear();
		OGMHMAGDNAM.Clear();
		LHAKGDAGEMM_EpBonusInfo.Clear();
	}

	// RVA: 0x10BDD3C Offset: 0x10BDD3C VA: 0x10BDD3C Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_Data)
	{
		FOKPKJFHNLO data = FOKPKJFHNLO.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		DGKKMKLCEDF(data);
		GPEKKMGGBPF(data);
		GJEHPJJBCDE(data);
		CFOFJPLEDEA(data);
		CJMJMDAEFMD(data);
		HNIKNPHOBOD(data);
		KCFJACFPGPI(data);
		MEJCLAPLIOE(data);
		HLIEMPBNOMK(data);
		ABICOINNGEK(data);
		EGLHCMDNFOE(data);
		JBNBGGDDEGG(data);
		for(int i = 0; i < data.BHGDNGHDDAC.Length; i++)
		{
			CEBFFLDKAEC_SecureInt d = new CEBFFLDKAEC_SecureInt();
			d.DNJEJEANJGL_Value = data.BHGDNGHDDAC[i].JBGEEPFKIGG;
			OHJFBLFELNK_IntArray.Add(data.BHGDNGHDDAC[i].LJNAKDMILMC, d);
			JNJAOACIGOC.Add(d);
		}
		for(int i = 0; i < data.MHGMDJNOLMI.Length; i++)
		{
			NNJFKLBPBNK_SecureString d = new NNJFKLBPBNK_SecureString();
			d.DNJEJEANJGL_Value = data.MHGMDJNOLMI[i].JBGEEPFKIGG;
			FJOEBCMGDMI_String.Add(data.MHGMDJNOLMI[i].LJNAKDMILMC, d);
			IFBBNEGGCIH.Add(d);
		}
		for(int i = 0; i < data.KIEKMCKCMGD.Length; i++)
		{
			OOGLJJLAMBD d = new OOGLJJLAMBD();
			d.PPFNGGCBJKC_id = data.KIEKMCKCMGD[i].PPFNGGCBJKC;
			d.KFCIJBLDHOK_v1 = data.KIEKMCKCMGD[i].KFCIJBLDHOK;
			d.JLEIHOEGMOP_v2 = data.KIEKMCKCMGD[i].JLEIHOEGMOP;
			if(i < data.KIEKMCKCMGD.Length / 2)
			{
				ADPFKHEMNBL.Add(d);
			}
			else
			{
				GKCBPNPEJJF.Add(d);
			}
		}
		AIGOEAPJGEB.KHEKNNFCAOI_Init(MBHDIJJEOFL, data);
		IJNOIMLNBGN.KHEKNNFCAOI_Init(JIKKNHIAEKG_BlockName, LLCLJBEJOPM_BannerInfo, data);

		UnityEngine.Debug.LogError(NGHKJOEDLIP_Settings.OPFGFINHFCE_name+" "+NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId);

		// Update dates
		UMOEventList.EventData CurrenEvent = UMOEventList.GetCurrentEvent();
		if (CurrenEvent != null && CurrenEvent.EnableBlock(JIKKNHIAEKG_BlockName))
		{
			System.DateTime date = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
			System.DateTime date2 = Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart);
			date = date.AddDays(-1);
			long offset = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, date2.Hour, date2.Minute, date2.Second) - NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			if (NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart != 0) NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart += offset;
			if (NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd != 0) NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd += offset;
			if (NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 != 0) NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 += offset;
			if (NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart != 0) NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart += offset;
			if (NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd != 0) NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd += offset;
			if (NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 != 0) NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 += offset;
			if (NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate != 0) NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate += offset;

			for(int i = 0; i < EAPOKGEIFKA.Count; i++)
			{
				if (EAPOKGEIFKA[i].PDBPFJJCADD_open_at != 0) EAPOKGEIFKA[i].PDBPFJJCADD_open_at = (int)NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (EAPOKGEIFKA[i].FDBNFFNFOND_CloseAt != 0) EAPOKGEIFKA[i].FDBNFFNFOND_CloseAt = (int)NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			}
			for(int i = 0; i < BGHBALGJNFF.Count; i++)
			{
				if (BGHBALGJNFF[i].BEBJKJKBOGH_Date != 0) BGHBALGJNFF[i].BEBJKJKBOGH_Date += (int)offset;
			}
			for(int i = 0; i < IJJHFGOIDOK_EventMusic.Count; i++)
			{
				if (IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at != 0) IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt != 0) IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			}
			for(int i = 0; i < NNMPGOAGEOL_quests.Count; i++)
			{
				if (NNMPGOAGEOL_quests[i].KJBGCLPMLCG_OpenedAt != 0) NNMPGOAGEOL_quests[i].KJBGCLPMLCG_OpenedAt = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (NNMPGOAGEOL_quests[i].GJFPFFBAKGK_CloseAt != 0) NNMPGOAGEOL_quests[i].GJFPFFBAKGK_CloseAt = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			}
			for(int i = 0; i < LLCLJBEJOPM_BannerInfo.Count; i++)
			{
				if (LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_open_at != 0) LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_CloseAt != 0) LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_CloseAt = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			}
		}
		return true;
	}

	// RVA: 0x10C0094 Offset: 0x10C0094 VA: 0x10C0094 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "LNELCMNJPIC_EventGoDiva.IIEMACPEEBJ");
		return true;
	}

	//// RVA: 0x10BE2C4 Offset: 0x10BE2C4 VA: 0x10BE2C4
	private bool DGKKMKLCEDF(FOKPKJFHNLO JMHECKKKMLK)
	{
		NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId = (int)JMHECKKKMLK.HMBHNLCFDIH.OBGBAOLONDD;
		NGHKJOEDLIP_Settings.OPFGFINHFCE_name = JMHECKKKMLK.HMBHNLCFDIH.OPFGFINHFCE;
		NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName = JMHECKKKMLK.HMBHNLCFDIH.HEDAGCNPHGD;
		NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api = JMHECKKKMLK.HMBHNLCFDIH.OCGFKMHNEOF;
		NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart = JMHECKKKMLK.HMBHNLCFDIH.BONDDBOFBND;
		NGHKJOEDLIP_Settings.EHHFFKAFOMC = JMHECKKKMLK.HMBHNLCFDIH.EHHFFKAFOMC;
		NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd = JMHECKKKMLK.HMBHNLCFDIH.HPNOGLIFJOP;
		NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 = JMHECKKKMLK.HMBHNLCFDIH.LNFKGHNHJKE;
		NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart = JMHECKKKMLK.HMBHNLCFDIH.JGMDAOACOJF;
		NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd = JMHECKKKMLK.HMBHNLCFDIH.IDDBFFBPNGI;
		NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 = JMHECKKKMLK.HMBHNLCFDIH.KNLGKBBIBOH;
		NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate = JMHECKKKMLK.HMBHNLCFDIH.JBFDHOIKAIK;
		NGHKJOEDLIP_Settings.KHIKEGLBGAF_RankingRewardScene = (int)JMHECKKKMLK.HMBHNLCFDIH.KHIKEGLBGAF;
		NGHKJOEDLIP_Settings.DPJCFLKFEPN = (int)JMHECKKKMLK.HMBHNLCFDIH.DPJCFLKFEPN;
		NGHKJOEDLIP_Settings.POGEFBMBPCB_MonthOdd = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.JMJDLDEIFKE;
		NGHKJOEDLIP_Settings.AHKNMANFILO_DayGroup = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.AHKNMANFILO;
		NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.MOEKELIIDEO;
		NGHKJOEDLIP_Settings.OCDMGOGMHGE_AchievementIdPrefix = JMHECKKKMLK.HMBHNLCFDIH.OCDMGOGMHGE;
		NGHKJOEDLIP_Settings.PJBILOFOCIC = JMHECKKKMLK.HMBHNLCFDIH.PJBILOFOCIC;
		NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type = JMHECKKKMLK.HMBHNLCFDIH.MJBKGOJBPAD;
		NGHKJOEDLIP_Settings.MPKNCMEAMLO = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.MPKNCMEAMLO;
		NGHKJOEDLIP_Settings.AHKPNPNOAMO_ExtreamOpen = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.AHKPNPNOAMO;
		NGHKJOEDLIP_Settings.FEMMDNIELFC_Desc = JMHECKKKMLK.HMBHNLCFDIH.FEMMDNIELFC;
		NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.HKKNEAGCIEB;
		NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId = JMHECKKKMLK.HMBHNLCFDIH.HIOOGLEJBKM;
		NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId = JMHECKKKMLK.HMBHNLCFDIH.FJCADCDNPMP;
		NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds = JMHECKKKMLK.HMBHNLCFDIH.EJBGHLOOLBC;
		NGHKJOEDLIP_Settings.EKJFNHHKBPL = JMHECKKKMLK.HMBHNLCFDIH.EKJFNHHKBPL;
		NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb = JMHECKKKMLK.HMBHNLCFDIH.OMCAOJJGOGG;
		NGHKJOEDLIP_Settings.MPCAGEPEJJJ_Key.Clear();
		for(int i = 0; i < JMHECKKKMLK.HMBHNLCFDIH.MPCAGEPEJJJ.Length; i++)
		{
			NGHKJOEDLIP_Settings.MPCAGEPEJJJ_Key.Add(JMHECKKKMLK.HMBHNLCFDIH.MPCAGEPEJJJ[i]);
		}
		for(int i = 0; i < JMHECKKKMLK.HMBHNLCFDIH.JHPCPNJJHLI.Length; i++)
		{
			if(JMHECKKKMLK.HMBHNLCFDIH.JHPCPNJJHLI[i] < 1001)
			{
				NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold.Add(JMHECKKKMLK.HMBHNLCFDIH.JHPCPNJJHLI[i]);
			}
		}
		NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops.Clear();
		for(int i = 0; i < JMHECKKKMLK.HMBHNLCFDIH.EEOGPJJCKHH.Length; i++)
		{
			NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops.Add((int)JMHECKKKMLK.HMBHNLCFDIH.EEOGPJJCKHH[i]);
		}
		return true;
	}

	//// RVA: 0x10BED60 Offset: 0x10BED60 VA: 0x10BED60
	private bool GPEKKMGGBPF(FOKPKJFHNLO JMHECKKKMLK)
	{
		for(int i = 0; i < JMHECKKKMLK.MCHFABAKPMH.Length; i++)
		{
			DKPKNBNMOGI d = new DKPKNBNMOGI();
			d.PPFNGGCBJKC_id = (int)JMHECKKKMLK.MCHFABAKPMH[i].PPFNGGCBJKC;
			d.DNBFMLBNAEE_Point = (int)JMHECKKKMLK.MCHFABAKPMH[i].FOILNHKHHDF;
			d.JOPPFEHKNFO_Pickup = JMHECKKKMLK.MCHFABAKPMH[i].JOPPFEHKNFO != 0;
			for(int j = 0; j < JMHECKKKMLK.MCHFABAKPMH[i].AIHOJKFNEEN.Length; j++)
			{
				OPNEOOPNELG d2 = new OPNEOOPNELG();
				d2.GLCLFMGPMAN_ItemId = JMHECKKKMLK.MCHFABAKPMH[i].AIHOJKFNEEN[j];
				d2.HMFFHLPNMPH_Count = (int)JMHECKKKMLK.MCHFABAKPMH[i].BFINGCJHOHI[j];
				d2.NMKEOMCMIPP_RewardId = (int)JMHECKKKMLK.MCHFABAKPMH[i].JJHPDDPKBHF[j];
				d2.HJAFPEBIBOP_Limit = (int)JMHECKKKMLK.MCHFABAKPMH[i].HJAFPEBIBOP[j];
				d.AHJNPEAMCCH_Rewards.Add(d2);
			}
			FCIPEDFHFEM_TotalRewards.Add(d);
		}
		return true;
	}

	//// RVA: 0x10BF1CC Offset: 0x10BF1CC VA: 0x10BF1CC
	private bool GJEHPJJBCDE(FOKPKJFHNLO JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime();
		for(int i = 0; i < JMHECKKKMLK.GHIHAGAOPNC.Length; i++)
		{
			HGLNJDGOPMM d = new HGLNJDGOPMM();
			d.KHEKNNFCAOI_Init(i + 1, xor * 11 + 1, JMHECKKKMLK);
			IJJHFGOIDOK_EventMusic.Add(d);
		}
		return true;
	}

	//// RVA: 0x10BF340 Offset: 0x10BF340 VA: 0x10BF340
	private bool CFOFJPLEDEA(FOKPKJFHNLO JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.MDDOGIAFDEI.Length; i++)
		{
			AKIIJBEJOEP d = new AKIIJBEJOEP();
			d.KHEKNNFCAOI_Init(JIKKNHIAEKG_BlockName, i + 1, xor, JMHECKKKMLK);
			NNMPGOAGEOL_quests.Add(d);
			xor += 0xd;
		}
		return true;
	}

	//// RVA: 0x10BF4D8 Offset: 0x10BF4D8 VA: 0x10BF4D8
	private bool CJMJMDAEFMD(FOKPKJFHNLO JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime();
		for(int i = 0; i < JMHECKKKMLK.DGBJMMJALMH.Length; i++)
		{
			POLLFBLLAHL d = new POLLFBLLAHL();
			d.KHEKNNFCAOI_Init(i + 1, xor * 11 + 1, JMHECKKKMLK);
			EAPOKGEIFKA.Add(d);
		}
		return true;
	}

	//// RVA: 0x10BF64C Offset: 0x10BF64C VA: 0x10BF64C
	private bool HNIKNPHOBOD(FOKPKJFHNLO JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime();
		for(int i = 0; i < JMHECKKKMLK.MPPGCHJPPKM.Length; i++)
		{
			DPKGKNJBFBJ d = new DPKGKNJBFBJ();
			d.KHEKNNFCAOI_Init(i + 1, xor * 11 + 1, JMHECKKKMLK);
			AEHKHFCKHJH.Add(d);
		}
		return true;
	}

	//// RVA: 0x10BF7C0 Offset: 0x10BF7C0 VA: 0x10BF7C0
	private bool KCFJACFPGPI(FOKPKJFHNLO JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime();
		for(int i = 0; i < JMHECKKKMLK.EENKKKDBABF.Length; i++)
		{
			BKBNHEEEHIB d = new BKBNHEEEHIB();
			d.KHEKNNFCAOI_Init(i + 1, xor * 11 + 1, JMHECKKKMLK);
			CDMAJPFOLKK.Add(d);
		}
		return true;
	}

	//// RVA: 0x10BF934 Offset: 0x10BF934 VA: 0x10BF934
	private bool MEJCLAPLIOE(FOKPKJFHNLO JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime();
		for(int i = 0; i < JMHECKKKMLK.DHDJOPFCOPP.Length; i++)
		{
			BGDLJMBDNOL d = new BGDLJMBDNOL();
			d.KHEKNNFCAOI_Init(i + 1, xor * 11 + 1, JMHECKKKMLK);
			DLEFGPMFCMA.Add(d);
		}
		return true;
	}

	//// RVA: 0x10BFAA8 Offset: 0x10BFAA8 VA: 0x10BFAA8
	private bool HLIEMPBNOMK(FOKPKJFHNLO JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime();
		for(int i = 0; i < JMHECKKKMLK.GICHIKNDMHE.Length; i++)
		{
			EOJAGLGHMCL d = new EOJAGLGHMCL();
			d.KHEKNNFCAOI_Init(i + 1, xor * 11 + 1, JMHECKKKMLK);
			BGHBALGJNFF.Add(d);
		}
		return true;
	}

	//// RVA: 0x10BFF10 Offset: 0x10BFF10 VA: 0x10BFF10
	private bool JBNBGGDDEGG(FOKPKJFHNLO JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.OLACFKILCFD.Length; i++)
		{
			LDAGBDINHMC d = new LDAGBDINHMC();
			d.KHEKNNFCAOI_Init(i + 1, xor, JMHECKKKMLK);
			GEGAEDDGNMA_Bonuses.Add(d);
			xor = xor * 3 + 0xd;
		}
		return true;
	}

	//// RVA: 0x10BFC1C Offset: 0x10BFC1C VA: 0x10BFC1C
	private bool ABICOINNGEK(FOKPKJFHNLO JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.MIOCOKLMLBD.Length; i++)
		{
			IONELJACGCL d = new IONELJACGCL();
			d.KHEKNNFCAOI_Init(i + 1, xor, JMHECKKKMLK);
			OGMHMAGDNAM.Add(d);
			xor = xor * 3 + 0xd;
		}
		return true;
	}

	//// RVA: 0x10BFD98 Offset: 0x10BFD98 VA: 0x10BFD98
	private bool EGLHCMDNFOE(FOKPKJFHNLO JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.IEJLJIHIDJC.Length; i++)
		{
			JNHHOCNJIKD d = new JNHHOCNJIKD();
			d.KHEKNNFCAOI_Init(i + 1, xor, JMHECKKKMLK);
			LHAKGDAGEMM_EpBonusInfo.Add(d);
			xor = xor * 3 + 0xd;
		}
		return true;
	}

	// RVA: 0x10C0E5C Offset: 0x10C0E5C VA: 0x10C0E5C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "LNELCMNJPIC_EventGoDiva.CAOGDCBPBAN");
		return 0;
	}
}
