
using System.Collections.Generic;

[System.Obsolete("Use JKICPBIIHNE_Bingo", true)]
public class JKICPBIIHNE { }
public class JKICPBIIHNE_Bingo : DIHHCBACKGG_DbSection
{
	public class HNOGDJFJGPM
	{
		private int EHOIENNDEDH_IdCrypted; // 0x8
		private int GNGNIKNNCNH_MVerCrypted; // 0xC
		private int HNJHPNPFAAN_EnabledCrypted; // 0x10
		private int JAOGGLOLPPN; // 0x14
		private long PCLNFCNIECH_OpenAtCrypted; // 0x18
		private long HHPIJHADAOB_CloseAtCrypted; // 0x20
		private int LDPOJKCJOBP; // 0x28
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO_KeyPrefix = new NNJFKLBPBNK_SecureString(); // 0x2C
		public List<EHLBDNHLCIN> DPGMFEGFCJN = new List<EHLBDNHLCIN>(); // 0x30

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1465520 DEMEPMAEJOO 0x146558C HIGKAIDMOKN
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0x14655FC KJIMMIBDCIL 0x1465668 DMEGNOKIKCD
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x14656D8 JPCJNLHHIPE 0x1465744 JJFJNEJLBDG
		public int OGKBHHLMMID { get { return JAOGGLOLPPN ^ FBGGEFFJJHB_xor; } set { JAOGGLOLPPN = value ^ FBGGEFFJJHB_xor; } } //0x14657B4 CBAAJCGPEJC 0x1465820 NHMOKHOBEHB
		public long PDBPFJJCADD_open_at { get { return PCLNFCNIECH_OpenAtCrypted ^ BBEGLBMOBOF_xorl; } set { PCLNFCNIECH_OpenAtCrypted = value ^ BBEGLBMOBOF_xorl; } } //0x1465890 FOACOMBHPAC 0x1465900 NBACOBCOJCA
		public long FDBNFFNFOND_close_at { get { return HHPIJHADAOB_CloseAtCrypted ^ BBEGLBMOBOF_xorl; } set { HHPIJHADAOB_CloseAtCrypted = value ^ BBEGLBMOBOF_xorl; } } //0x1465978 BPJOGHJCLDJ 0x14659E8 NLJKMCHOCBK
		public string OCDMGOGMHGE_KeyPrefix { get { return EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value; } set { EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value = value; } } //0x1465A60 HBAAAKFHDBB 0x1465A8C NHJLJOIPOFK
		public int MNOKEJIPOBJ { get { return LDPOJKCJOBP ^ FBGGEFFJJHB_xor; } set { LDPOJKCJOBP = value ^ FBGGEFFJJHB_xor; } } //0x1465AC0 ACNHGHKOCLM 0x1465B2C GJLIJNICBKM

		// RVA: 0x1465B9C Offset: 0x1465B9C VA: 0x1465B9C
		public HNOGDJFJGPM()
		{
			LHPDDGIJKNB_Reset();
		}

		// RVA: 0x1465C54 Offset: 0x1465C54 VA: 0x1465C54
		public void LHPDDGIJKNB_Reset()
		{
			PPFNGGCBJKC_id = 0;
			IJEKNCDIIAE_mver = 0;
			PLALNIIBLOF_en = 0;
			OGKBHHLMMID = 0;
			PDBPFJJCADD_open_at = 0;
			FDBNFFNFOND_close_at = 0;
			MNOKEJIPOBJ = 0;
			DPGMFEGFCJN.Clear();
		}

		// RVA: 0x1465F54 Offset: 0x1465F54 VA: 0x1465F54
		//public uint CAOGDCBPBAN() { }
	}

	public class EHLBDNHLCIN
	{
		private int EHOIENNDEDH_IdCrypted; // 0x8
		public List<CCOCDFGGDBB> CFHKEJHDGBG = new List<CCOCDFGGDBB>(); // 0xC
		public List<MKOCCBABHAH> PFEGHILDOGF = new List<MKOCCBABHAH>(); // 0x10
		public List<IEGCPLCLOHF> MFMGDFACBON = new List<IEGCPLCLOHF>(); // 0x14

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1363068 DEMEPMAEJOO 0x1361F9C HIGKAIDMOKN
		public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x18 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
		public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x1C KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

		// RVA: 0x1361E38 Offset: 0x1361E38 VA: 0x1361E38
		public EHLBDNHLCIN()
		{
			FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
			OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
			LHPDDGIJKNB_Reset();
		}

		// RVA: 0x13630E4 Offset: 0x13630E4 VA: 0x13630E4
		public void LHPDDGIJKNB_Reset()
		{
			PPFNGGCBJKC_id = 0;
			OHJFBLFELNK_m_intParam.Clear();
			FJOEBCMGDMI_m_stringParam.Clear();
			CFHKEJHDGBG.Clear();
			PFEGHILDOGF.Clear();
			MFMGDFACBON.Clear();
		}

		//// RVA: 0x1363264 Offset: 0x1363264 VA: 0x1363264
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x1363470 Offset: 0x1363470 VA: 0x1363470
		//public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval) { }

		//// RVA: 0x1363554 Offset: 0x1363554 VA: 0x1363554
		//public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval) { }
	}

	public class CCOCDFGGDBB
	{
		private int EHOIENNDEDH_IdCrypted; // 0x8
		private int HNJHPNPFAAN_EnabledCrypted; // 0xC
		private int AFHMDMMHBMC_Crypted; // 0x10
		private List<int> KGANBBFKCDD_Crypted = new List<int>(); // 0x14
		private List<int> AHGCGHAAHOO_ItemIdCrypted = new List<int>(); // 0x18
		private List<int> CMBLIDNDLOO_Crypted = new List<int>(); // 0x1C
		private List<int> AIGOPKGALKA_Crypted = new List<int>(); // 0x20

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x13626D8 DEMEPMAEJOO 0x13620E8 HIGKAIDMOKN
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1362744 JPCJNLHHIPE 0x1362158 JJFJNEJLBDG
		public int BGKHDJOGEAL { get { return AFHMDMMHBMC_Crypted ^ FBGGEFFJJHB_xor; } set { AFHMDMMHBMC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x13627B0 BAEEGALHJCD 0x13621C8 MIIBCLFCGBJ

		//// RVA: 0x136281C Offset: 0x136281C VA: 0x136281C
		public int BLLCPCGGHJM(int _IOPHIHFOOEP_idx)
		{
			if (_IOPHIHFOOEP_idx > -1 && _IOPHIHFOOEP_idx < KGANBBFKCDD_Crypted.Count)
			{
				return FBGGEFFJJHB_xor ^ KGANBBFKCDD_Crypted[_IOPHIHFOOEP_idx];
			}
			return 0;
		}

		//// RVA: 0x1362238 Offset: 0x1362238 VA: 0x1362238
		public bool APPMICHOCFN(int _IOPHIHFOOEP_idx, int _JBGEEPFKIGG_val)
		{
			if (_IOPHIHFOOEP_idx > -1 && _IOPHIHFOOEP_idx < KGANBBFKCDD_Crypted.Count)
			{
				KGANBBFKCDD_Crypted[_IOPHIHFOOEP_idx] = FBGGEFFJJHB_xor ^ _JBGEEPFKIGG_val;
				return true;
			}
			return false;
		}

		//// RVA: 0x13628FC Offset: 0x13628FC VA: 0x13628FC
		public int FKNBLDPIPMC_GetItemCode(int _IOPHIHFOOEP_idx)
		{
			if (_IOPHIHFOOEP_idx > -1 && _IOPHIHFOOEP_idx < AHGCGHAAHOO_ItemIdCrypted.Count)
			{
				return FBGGEFFJJHB_xor ^ AHGCGHAAHOO_ItemIdCrypted[_IOPHIHFOOEP_idx];
			}
			return 0;
		}

		//// RVA: 0x1362320 Offset: 0x1362320 VA: 0x1362320
		public bool OEFHMMJFEKC_SetItemId(int _IOPHIHFOOEP_idx, int _JBGEEPFKIGG_val)
		{
			if (_IOPHIHFOOEP_idx > -1 && _IOPHIHFOOEP_idx < AHGCGHAAHOO_ItemIdCrypted.Count)
			{
				AHGCGHAAHOO_ItemIdCrypted[_IOPHIHFOOEP_idx] = FBGGEFFJJHB_xor ^ _JBGEEPFKIGG_val;
				return true;
			}
			return false;
		}

		//// RVA: 0x13629DC Offset: 0x13629DC VA: 0x13629DC
		public int KAINPNMMAEK_GetItemCount(int _IOPHIHFOOEP_idx)
		{
			if (_IOPHIHFOOEP_idx > -1 && _IOPHIHFOOEP_idx < CMBLIDNDLOO_Crypted.Count)
			{
				return FBGGEFFJJHB_xor ^ CMBLIDNDLOO_Crypted[_IOPHIHFOOEP_idx];
			}
			return 0;
		}

		//// RVA: 0x1362408 Offset: 0x1362408 VA: 0x1362408
		public bool PPJAGFPBFHJ_SetItemCount(int _IOPHIHFOOEP_idx, int _JBGEEPFKIGG_val)
		{
			if (_IOPHIHFOOEP_idx > -1 && _IOPHIHFOOEP_idx < CMBLIDNDLOO_Crypted.Count)
			{
				CMBLIDNDLOO_Crypted[_IOPHIHFOOEP_idx] = FBGGEFFJJHB_xor ^ _JBGEEPFKIGG_val;
				return true;
			}
			return false;
		}

		//// RVA: 0x1362ABC Offset: 0x1362ABC VA: 0x1362ABC
		//public int BINCAIKOHGF(int _IOPHIHFOOEP_idx) { }

		//// RVA: 0x13624F0 Offset: 0x13624F0 VA: 0x13624F0
		public bool DKAFBIJCDIF(int _IOPHIHFOOEP_idx, int _JBGEEPFKIGG_val)
		{
			if (_IOPHIHFOOEP_idx > -1 && _IOPHIHFOOEP_idx < AIGOPKGALKA_Crypted.Count)
			{
				AIGOPKGALKA_Crypted[_IOPHIHFOOEP_idx] = FBGGEFFJJHB_xor ^ _JBGEEPFKIGG_val;
				return true;
			}
			return false;
		}

		// RVA: 0x136200C Offset: 0x136200C VA: 0x136200C
		public CCOCDFGGDBB()
		{
			LHPDDGIJKNB_Reset();
		}

		// RVA: 0x1362B9C Offset: 0x1362B9C VA: 0x1362B9C
		public void LHPDDGIJKNB_Reset()
		{
			PPFNGGCBJKC_id = 0;
			PLALNIIBLOF_en = 0;
			BGKHDJOGEAL = 0;
			KGANBBFKCDD_Crypted.Clear();
			AHGCGHAAHOO_ItemIdCrypted.Clear();
			CMBLIDNDLOO_Crypted.Clear();
			AIGOPKGALKA_Crypted.Clear();
			for(int i = 0; i < 8; i++)
			{
				KGANBBFKCDD_Crypted.Add(0);
				AHGCGHAAHOO_ItemIdCrypted.Add(0);
				CMBLIDNDLOO_Crypted.Add(0);
				AIGOPKGALKA_Crypted.Add(0);
			}
		}

		// RVA: 0x1362E74 Offset: 0x1362E74 VA: 0x1362E74
		//public uint CAOGDCBPBAN() { }
	}

	public class MKOCCBABHAH
	{
		private int EHOIENNDEDH_IdCrypted; // 0x8
		private int HNJHPNPFAAN_EnabledCrypted; // 0xC
		private int IPAKEGGICML_SerieCrypted; // 0x10
		private int LLEMDLLGIAH_divaCrypted; // 0x14
		private List<int> AHGCGHAAHOO_ItemIdCrypted = new List<int>(); // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1467D30 DEMEPMAEJOO 0x1467D9C HIGKAIDMOKN
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1467E0C JPCJNLHHIPE 0x1467E78 JJFJNEJLBDG
		public int CPKMLLNADLJ_Serie { get { return IPAKEGGICML_SerieCrypted ^ FBGGEFFJJHB_xor; } set { IPAKEGGICML_SerieCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1467EE8 BJPJMGHCDNO 0x1467F54 BPKIOJBKNBP
		public int FDBOPFEOENF_diva { get { return LLEMDLLGIAH_divaCrypted ^ FBGGEFFJJHB_xor; } set { LLEMDLLGIAH_divaCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1467FC4 MJPHCAIKKJG 0x1468030 GHECGDMEBFF

		//// RVA: 0x14680A0 Offset: 0x14680A0 VA: 0x14680A0
		public int FKNBLDPIPMC_GetItemCode(int _IOPHIHFOOEP_idx)
		{
			if (_IOPHIHFOOEP_idx > -1 && _IOPHIHFOOEP_idx < AHGCGHAAHOO_ItemIdCrypted.Count)
			{
				return AHGCGHAAHOO_ItemIdCrypted[_IOPHIHFOOEP_idx] ^ FBGGEFFJJHB_xor;
			}
			return 0;
		}

		//// RVA: 0x1468180 Offset: 0x1468180 VA: 0x1468180
		public bool OEFHMMJFEKC_SetItemId(int _IOPHIHFOOEP_idx, int _JBGEEPFKIGG_val)
		{
			if (_IOPHIHFOOEP_idx > -1 && _IOPHIHFOOEP_idx < AHGCGHAAHOO_ItemIdCrypted.Count)
			{
				AHGCGHAAHOO_ItemIdCrypted[_IOPHIHFOOEP_idx] = FBGGEFFJJHB_xor ^ _JBGEEPFKIGG_val;
				return true;
			}
			return false;
		}

		// RVA: 0x1468268 Offset: 0x1468268 VA: 0x1468268
		public MKOCCBABHAH()
		{
			LHPDDGIJKNB_Reset();
		}

		// RVA: 0x14682FC Offset: 0x14682FC VA: 0x14682FC
		public void LHPDDGIJKNB_Reset()
		{
			PPFNGGCBJKC_id = 0;
			PLALNIIBLOF_en = 0;
			CPKMLLNADLJ_Serie = 0;
			FDBOPFEOENF_diva = 0;
			AHGCGHAAHOO_ItemIdCrypted.Clear();
			for(int i = 0; i < 8; i++)
			{
				AHGCGHAAHOO_ItemIdCrypted.Add(0);
			}
		}

		//// RVA: 0x1468510 Offset: 0x1468510 VA: 0x1468510
		//public uint CAOGDCBPBAN() { }
	}

	public class IEGCPLCLOHF
	{
		private int EHOIENNDEDH_IdCrypted; // 0x8
		private int OHPLLHANLHO_CidCrypted; // 0xC
		private int HNJHPNPFAAN_EnabledCrypted; // 0x10
		private int MEJIFDMJHLM_Crypted; // 0x14
		private int IPAKEGGICML_SerieCrypted; // 0x18
		private int LLEMDLLGIAH_divaCrypted; // 0x1C
		private int EHLGHDIACCG_MusicDifficultyCrypted; // 0x20
		private int DHICHPNOIMJ_Crypted; // 0x24
		private int KNJCNHEBPED_Crypted; // 0x28
		private int FILBJBFDMMN_Crypted; // 0x2C
		private int KGKIDDDKOGL_cidCrypted; // 0x30
		private int HPMEEPLGJDL_Crypted; // 0x34
		private int AHGCGHAAHOO_ItemIdCrypted; // 0x38
		private int CMBLIDNDLOO_Crypted; // 0x3C
		private int AIGOPKGALKA_Crypted; // 0x40
		private NNJFKLBPBNK_SecureString FHBDAJIDLNN = new NNJFKLBPBNK_SecureString(); // 0x44
		private NNJFKLBPBNK_SecureString IDCENBCAPBP = new NNJFKLBPBNK_SecureString(); // 0x48

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x14662DC DEMEPMAEJOO 0x1466348 HIGKAIDMOKN
		public int PBEEPMLJGJC_Cid { get { return OHPLLHANLHO_CidCrypted ^ FBGGEFFJJHB_xor; } set { OHPLLHANLHO_CidCrypted = value ^ FBGGEFFJJHB_xor; } } //0x14663B8 JGJMCAHJFFE 0x1466424 FJPAJAAPBEN
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1466494 JPCJNLHHIPE 0x1466500 JJFJNEJLBDG
		public int NDFOAINJPIN_pos { get { return MEJIFDMJHLM_Crypted ^ FBGGEFFJJHB_xor; } set { MEJIFDMJHLM_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1466570 CLKKCPLEKBC 0x14665DC CLJOOFCICMO
		public int CPKMLLNADLJ_Serie { get { return IPAKEGGICML_SerieCrypted ^ FBGGEFFJJHB_xor; } set { IPAKEGGICML_SerieCrypted = value ^ FBGGEFFJJHB_xor; } } //0x146664C BJPJMGHCDNO 0x14666B8 BPKIOJBKNBP
		public int FDBOPFEOENF_diva { get { return LLEMDLLGIAH_divaCrypted ^ FBGGEFFJJHB_xor; } set { LLEMDLLGIAH_divaCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1466728 MJPHCAIKKJG 0x1466794 GHECGDMEBFF
		public int GOKJLBDJOLA_df { get { return EHLGHDIACCG_MusicDifficultyCrypted ^ FBGGEFFJJHB_xor; } set { EHLGHDIACCG_MusicDifficultyCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1466804 CCEEILBGBOM 0x1466870 MKNIFMGHJHC
		// Score Rank
		public int GPNPBHLLHDI_srnk { get { return DHICHPNOIMJ_Crypted ^ FBGGEFFJJHB_xor; } set { DHICHPNOIMJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x14668E0 HKNLEPBHECG 0x146694C NDOLKOBKNNE
		// Combo rank
		public int IMEPEOAFIIB_cbrnk { get { return KNJCNHEBPED_Crypted ^ FBGGEFFJJHB_xor; } set { KNJCNHEBPED_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x14669BC GBBFFLPKKFA 0x1466A28 PFPAJELFONN
		public int MAPNDFCJFLJ_ConditionType { get { return FILBJBFDMMN_Crypted ^ FBGGEFFJJHB_xor; } set { FILBJBFDMMN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1466A98 IPFCNEIHNLJ 0x1466B04 CLNEANLIOFN
		// ConditionValue
		public int JBFLEDKDFCO_cid { get { return KGKIDDDKOGL_cidCrypted ^ FBGGEFFJJHB_xor; } set { KGKIDDDKOGL_cidCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1466B74 LIJMKJLDHGP 0x1466BE0 NFNCLFPPADP
		public int PMDLBHLNIDP_Target { get { return HPMEEPLGJDL_Crypted ^ FBGGEFFJJHB_xor; } set { HPMEEPLGJDL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1466C50 HNDKMDOPGNC 0x1466CBC NLFFKMHAAKB
		public int GLCLFMGPMAN_ItemId { get { return AHGCGHAAHOO_ItemIdCrypted ^ FBGGEFFJJHB_xor; } set { AHGCGHAAHOO_ItemIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1466D2C LNJAENEGDEL 0x1466D98 JHIDBGCHOKL
		public int LJKMKCOAICL_ItemCount { get { return CMBLIDNDLOO_Crypted ^ FBGGEFFJJHB_xor; } set { CMBLIDNDLOO_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1466E08 KJPMAPBJBKE 0x1466E74 PPBMLEFDPOF
		public int JJHPDDPKBHF { get { return AIGOPKGALKA_Crypted ^ FBGGEFFJJHB_xor; } set { AIGOPKGALKA_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1466EE4 HFILAJCCGJG 0x1466F50 ACCDONHEHCG
		public string FEMMDNIELFC_Desc { get { return FHBDAJIDLNN.DNJEJEANJGL_Value; } set { FHBDAJIDLNN.DNJEJEANJGL_Value = value; } } //0x1466FC0 JDHDMBHNKJD 0x1466FEC FNAJEJLLJOE
		public string JEPGJJJBFLN_ConditionText { get { return IDCENBCAPBP.DNJEJEANJGL_Value; } set { IDCENBCAPBP.DNJEJEANJGL_Value = value; } } //0x1467020 AKHEBLBJGBP 0x146704C EEJDMJMLKMG

		// RVA: 0x1467080 Offset: 0x1467080 VA: 0x1467080
		public IEGCPLCLOHF()
		{
			PPFNGGCBJKC_id = 0;
			PBEEPMLJGJC_Cid = 0;
			PLALNIIBLOF_en = 0;
			NDFOAINJPIN_pos = 0;
			CPKMLLNADLJ_Serie = 0;
			FDBOPFEOENF_diva = 0;
			GOKJLBDJOLA_df = 0;
			GPNPBHLLHDI_srnk = 0;
			IMEPEOAFIIB_cbrnk = 0;
			MAPNDFCJFLJ_ConditionType = 0;
			JBFLEDKDFCO_cid = 0;
			PMDLBHLNIDP_Target = 0;
			GLCLFMGPMAN_ItemId = 0;
			LJKMKCOAICL_ItemCount = 0;
			JJHPDDPKBHF = 0;
			FEMMDNIELFC_Desc = "";
			JEPGJJJBFLN_ConditionText = "";
		}

		// RVA: 0x1467660 Offset: 0x1467660 VA: 0x1467660
		//public uint CAOGDCBPBAN() { }
	}

	public static int FBGGEFFJJHB_xor; // 0x0
	public static long BBEGLBMOBOF_xorl; // 0x8
	public List<HNOGDJFJGPM> JJAICEAEGKF = new List<HNOGDJFJGPM>(); // 0x20
	
	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x24 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x28 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x13602EC Offset: 0x13602EC VA: 0x13602EC
	//public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval) { }

	//// RVA: 0x13603D0 Offset: 0x13603D0 VA: 0x13603D0
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if (!OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	// RVA: 0x13604B4 Offset: 0x13604B4 VA: 0x13604B4
	public JKICPBIIHNE_Bingo()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
		BBEGLBMOBOF_xorl = ~FBGGEFFJJHB_xor;
		LMHMIIKCGPE = 6;
	}

	// RVA: 0x1360670 Offset: 0x1360670 VA: 0x1360670 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		JJAICEAEGKF.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
		OHJFBLFELNK_m_intParam.Clear();
	}

	// RVA: 0x1360740 Offset: 0x1360740 VA: 0x1360740 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		LGDFIOHBHIK parser = LGDFIOHBHIK.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		NIPNMNKLOBK(parser);
		{
			PFCELKENNNE[] array = parser.BHGDNGHDDAC;
			for(int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
				OHJFBLFELNK_m_intParam.Add(array[i].LJNAKDMILMC_key, data);
			}
		}
		{
			ODDAHAKDLMP[] array = parser.MHGMDJNOLMI;
			for(int i = 0; i < array.Length; i++)
			{
				NNJFKLBPBNK_SecureString data = new NNJFKLBPBNK_SecureString();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
				FJOEBCMGDMI_m_stringParam.Add(array[i].LJNAKDMILMC_key, data);
			}
		}

		return true;
	}

	// RVA: 0x1360A14 Offset: 0x1360A14 VA: 0x1360A14
	private bool NIPNMNKLOBK(LGDFIOHBHIK AJLPJINDCBI)
	{
		{
			LFDHMBMBANF[] array = AJLPJINDCBI.AJHKFCBHLKF;
			for (int i = 0; i < array.Length; i++)
			{
				HNOGDJFJGPM data = new HNOGDJFJGPM();
				data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
				data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
				data.PLALNIIBLOF_en = (int)array[i].PLALNIIBLOF_en;
				data.OGKBHHLMMID = array[i].OGKBHHLMMID;
				data.PDBPFJJCADD_open_at = array[i].PDBPFJJCADD_open_at;
				data.FDBNFFNFOND_close_at = array[i].FDBNFFNFOND_close_at;
				data.FDBNFFNFOND_close_at = 0; // UMO : always unlocked
				data.OCDMGOGMHGE_KeyPrefix = array[i].OCDMGOGMHGE_KeyPrefix;
				data.MNOKEJIPOBJ = array[i].MNOKEJIPOBJ;
				IJCMDDNKELE(i, ref data, AJLPJINDCBI);
				JJAICEAEGKF.Add(data);
			}
		}
		return true;
	}

	//// RVA: 0x1360D98 Offset: 0x1360D98 VA: 0x1360D98
	private bool IJCMDDNKELE(int _OIPCCBHIKIA_index, ref HNOGDJFJGPM BFPPAPMNEHA, LGDFIOHBHIK AJLPJINDCBI)
	{
		EHLBDNHLCIN data = new EHLBDNHLCIN();
		NFJHOMPBCPA[] array = AJLPJINDCBI.LMEMCJJJGKO;
		data.PPFNGGCBJKC_id = array[_OIPCCBHIKIA_index].PPFNGGCBJKC_id;
		{
			AIIMCMMBIFN[] array2 = array[_OIPCCBHIKIA_index].CACDKPLABDE;
			for(int i = 0; i < array2.Length; i++)
			{
				CCOCDFGGDBB data2 = new CCOCDFGGDBB();
				data2.PPFNGGCBJKC_id = array2[i].PPFNGGCBJKC_id;
				data2.PLALNIIBLOF_en = (int)array2[i].PLALNIIBLOF_en;
				data2.BGKHDJOGEAL = array2[i].FGKGELOJBJK_ul;
				{
					int[] array3 = array2[i].AEDMJLGNDHN_IsSp;
					int[] array4 = array2[i].GLCLFMGPMAN_ItemId;
					int[] array5 = array2[i].LJKMKCOAICL_ItemCount;
					int[] array6 = array2[i].JJHPDDPKBHF;
					for (int j = 0; j < array3.Length && j < 8; j++)
					{
						data2.APPMICHOCFN(j, array3[j]);
						data2.OEFHMMJFEKC_SetItemId(j, array4[j]);
						data2.PPJAGFPBFHJ_SetItemCount(j, array5[j]);
						data2.DKAFBIJCDIF(j, array6[j]);
					}
				}
				data.CFHKEJHDGBG.Add(data2);
			}
		}
		{
			IHILMALOBMA[] array2 = array[_OIPCCBHIKIA_index].APHNKNGKKFC;
			for (int i = 0; i < array2.Length; i++)
			{
				MKOCCBABHAH data2 = new MKOCCBABHAH();
				data2.PPFNGGCBJKC_id = array2[i].PPFNGGCBJKC_id;
				data2.PLALNIIBLOF_en = (int)array2[i].PLALNIIBLOF_en;
				data2.CPKMLLNADLJ_Serie = array2[i].CPKMLLNADLJ_Serie;
				data2.FDBOPFEOENF_diva = array2[i].FDBOPFEOENF_diva;
				int[] array3 = array2[i].GLCLFMGPMAN_ItemId;
				for(int j = 0; j < array3.Length && j < 8; j++)
				{
					data2.OEFHMMJFEKC_SetItemId(j, array3[j]);
				}
				data.PFEGHILDOGF.Add(data2);
			}
		}
		{
			FCJFGEJHJGK[] array2 = array[_OIPCCBHIKIA_index].ABGNJMDKCEL;
			for (int i = 0; i < array2.Length; i++)
			{
				IEGCPLCLOHF data2 = new IEGCPLCLOHF();
				data2.PPFNGGCBJKC_id = array2[i].PPFNGGCBJKC_id;
				data2.PBEEPMLJGJC_Cid = array2[i].PBEEPMLJGJC_Cid;
				data2.PLALNIIBLOF_en = (int)array2[i].PLALNIIBLOF_en;
				data2.NDFOAINJPIN_pos = array2[i].NDFOAINJPIN_pos;
				data2.CPKMLLNADLJ_Serie = array2[i].CPKMLLNADLJ_Serie;
				data2.FDBOPFEOENF_diva = array2[i].FDBOPFEOENF_diva;
				data2.GOKJLBDJOLA_df = array2[i].GOKJLBDJOLA_df;
				data2.GPNPBHLLHDI_srnk = array2[i].GPNPBHLLHDI_srnk;
				data2.IMEPEOAFIIB_cbrnk = array2[i].IMEPEOAFIIB_cbrnk;
				data2.MAPNDFCJFLJ_ConditionType = array2[i].MAPNDFCJFLJ_ConditionType;
				data2.JBFLEDKDFCO_cid = array2[i].JBFLEDKDFCO_cid;
				data2.PMDLBHLNIDP_Target = array2[i].PMDLBHLNIDP_Target;
				data2.GLCLFMGPMAN_ItemId = array2[i].GLCLFMGPMAN_ItemId;
				data2.LJKMKCOAICL_ItemCount = array2[i].LJKMKCOAICL_ItemCount;
				data2.JJHPDDPKBHF = array2[i].JJHPDDPKBHF;
				data2.FEMMDNIELFC_Desc = DatabaseTextConverter.TranslateBingo(BFPPAPMNEHA.PPFNGGCBJKC_id, data.PPFNGGCBJKC_id, data2.PPFNGGCBJKC_id, array2[i].FEMMDNIELFC_Desc, 0);
				data2.JEPGJJJBFLN_ConditionText = DatabaseTextConverter.TranslateBingo(BFPPAPMNEHA.PPFNGGCBJKC_id, data.PPFNGGCBJKC_id, data2.PPFNGGCBJKC_id, array2[i].JEPGJJJBFLN_ConditionText, 1);
				data.MFMGDFACBON.Add(data2);
			}
		}
		{
			GJJGDBPNBGP[] array2 = array[_OIPCCBHIKIA_index].AKIFKNAJBFG;
			for (int i = 0; i < array2.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data2 = new CEBFFLDKAEC_SecureInt();
				data2.DNJEJEANJGL_Value = array2[i].JBGEEPFKIGG_val;
				data.OHJFBLFELNK_m_intParam.Add(array2[i].LJNAKDMILMC_key, data2);
			}
		}
		{
			IDPIHOHBGBH[] array2 = array[_OIPCCBHIKIA_index].EKBIDLMHCBF;
			for (int i = 0; i < array2.Length; i++)
			{
				NNJFKLBPBNK_SecureString data2 = new NNJFKLBPBNK_SecureString();
				data2.DNJEJEANJGL_Value = array2[i].JBGEEPFKIGG_val;
				data.FJOEBCMGDMI_m_stringParam.Add(array2[i].LJNAKDMILMC_key, data2);
			}
		}
		BFPPAPMNEHA.DPGMFEGFCJN.Add(data);
		return true;
	}

	// RVA: 0x13625E8 Offset: 0x13625E8 VA: 0x13625E8 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// RVA: 0x13625F0 Offset: 0x13625F0 VA: 0x13625F0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "JKICPBIIHNE_Bingo.CAOGDCBPBAN");
		return 0;
	}
}
