
using System.Collections.Generic;

[System.Obsolete("Use IHFIAFDLAAK_DecoStamp", true)]
public class IHFIAFDLAAK { }
public class IHFIAFDLAAK_DecoStamp : DIHHCBACKGG_DbSection
{
	public class MFHKPMPJGHC
	{
		private int FBGGEFFJJHB_xor; // 0x8
		private long BBEGLBMOBOF_xorl; // 0x10
		private int EHOIENNDEDH_IdCrypted; // 0x18
		private int GNGNIKNNCNH_MVerCrypted; // 0x1C
		private int HNJHPNPFAAN_EnabledCrypted; // 0x20
		private int NOFECLGOLAI_TypeCrypted; // 0x24
		private int KGKIDDDKOGL_cidCrypted; // 0x28
		private int ALGLCFOIHCN; // 0x2C
		private int EAJCFBCHIFB_RarityCrypted; // 0x30
		private int CFONNKENNJH; // 0x34
		private int CCACGHNJNOF; // 0x38

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FA504 DEMEPMAEJOO 0x11F9CF0 HIGKAIDMOKN
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FA514 KJIMMIBDCIL 0x11F9D00 DMEGNOKIKCD
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FA524 JPCJNLHHIPE 0x11F9D10 JJFJNEJLBDG
		// Type
		public int GBJFNGCDKPM_typ { get { return NOFECLGOLAI_TypeCrypted ^ FBGGEFFJJHB_xor; } set { NOFECLGOLAI_TypeCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FA534 CEJJMKODOGK 0x11F9D20 HOHCEBMMACI
		// CharaId
		public int JBFLEDKDFCO_cid { get { return KGKIDDDKOGL_cidCrypted ^ FBGGEFFJJHB_xor; } set { KGKIDDDKOGL_cidCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FA544 LIJMKJLDHGP 0x11F9D30 NFNCLFPPADP
		public int ALAEHBKAEPB { get { return ALGLCFOIHCN ^ FBGGEFFJJHB_xor; } set { ALGLCFOIHCN = value ^ FBGGEFFJJHB_xor; } } //0x11FA554 NHILKCBAGHE 0x11F9D40 ONHBPCBCFAE
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FA564 OEEHBGECGKL 0x11F9D50 GHLMHLJJBIG
		public int NGILPOOLBCF_OffsetX { get { return CFONNKENNJH ^ FBGGEFFJJHB_xor; } set { CFONNKENNJH = value ^ FBGGEFFJJHB_xor; } } //0x11FA574 EDGHLAHGBFN 0x11F9D60 LFCKFNLGFCN
		public int JINEKNIBOFI_OffsetY { get { return CCACGHNJNOF ^ FBGGEFFJJHB_xor; } set { CCACGHNJNOF = value ^ FBGGEFFJJHB_xor; } } //0x11FA584 LKDHAPEGCPH 0x11F9D70 PBPDONPMGNF

		// RVA: 0x11F9C3C Offset: 0x11F9C3C VA: 0x11F9C3C
		public MFHKPMPJGHC()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
			BBEGLBMOBOF_xorl = ~FBGGEFFJJHB_xor;
			PPFNGGCBJKC_id = 0;
			IJEKNCDIIAE_mver = 0;
			PLALNIIBLOF_en = 0;
			GBJFNGCDKPM_typ = 0;
			JBFLEDKDFCO_cid = 0;
			ALAEHBKAEPB = 0;
			EKLIPGELKCL_Rarity = 0;
			NGILPOOLBCF_OffsetX = 0;
			JINEKNIBOFI_OffsetY = 0;
		}

		// RVA: 0x11FA0C8 Offset: 0x11FA0C8 VA: 0x11FA0C8
		//public uint CAOGDCBPBAN() { }
	}

	public class MCBOAJEIFNP
	{
		private int FBGGEFFJJHB_xor; // 0x8
		private long BBEGLBMOBOF_xorl; // 0x10
		private int EHOIENNDEDH_IdCrypted; // 0x18
		private int GNGNIKNNCNH_MVerCrypted; // 0x1C
		private int HNJHPNPFAAN_EnabledCrypted; // 0x20
		private int NOFECLGOLAI_TypeCrypted; // 0x24
		private int CNHNJMCOKGN; // 0x28
		private int IPAKEGGICML_SerieCrypted; // 0x2C
		private int KGKIDDDKOGL_cidCrypted; // 0x30
		private int HNNLOMMFHEN_catCrypted; // 0x34
		private int EAJCFBCHIFB_RarityCrypted; // 0x38
		private int MMDBOPCEKCJ; // 0x3C
		private int HJCJMAONOMH; // 0x40
		private int HAIFEBPOPEF; // 0x44

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FA444 DEMEPMAEJOO 0x11F9E38 HIGKAIDMOKN
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FA454 KJIMMIBDCIL 0x11F9E48 DMEGNOKIKCD
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FA464 JPCJNLHHIPE 0x11F9E58 JJFJNEJLBDG
		// FrameId
		public int GBJFNGCDKPM_typ { get { return NOFECLGOLAI_TypeCrypted ^ FBGGEFFJJHB_xor; } set { NOFECLGOLAI_TypeCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FA474 CEJJMKODOGK 0x11F9E68 HOHCEBMMACI
		public int LDLGLHBGOKE_FontSize { get { return CNHNJMCOKGN ^ FBGGEFFJJHB_xor; } set { CNHNJMCOKGN = value ^ FBGGEFFJJHB_xor; } } //0x11FA484 EONNCAKAEFE 0x11F9E78 BJAADDLLCHE
		public int CPKMLLNADLJ_Serie { get { return IPAKEGGICML_SerieCrypted ^ FBGGEFFJJHB_xor; } set { IPAKEGGICML_SerieCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FA494 BJPJMGHCDNO 0x11F9E88 BPKIOJBKNBP
		public int JBFLEDKDFCO_cid { get { return KGKIDDDKOGL_cidCrypted ^ FBGGEFFJJHB_xor; } set { KGKIDDDKOGL_cidCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FA4A4 LIJMKJLDHGP 0x11F9E98 NFNCLFPPADP
		public int DMEDKJPOLCH_cat { get { return HNNLOMMFHEN_catCrypted ^ FBGGEFFJJHB_xor; } set { HNNLOMMFHEN_catCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FA4B4 IPKCKAAEEOE 0x11F9EB8 JOGLLINFLJN
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FA4C4 OEEHBGECGKL 0x11F9EA8 GHLMHLJJBIG
		public int MLMCEBBDJOE { get { return MMDBOPCEKCJ ^ FBGGEFFJJHB_xor; } set { MMDBOPCEKCJ = value ^ FBGGEFFJJHB_xor; } } //0x11FA4D4 IGMHCODOFKG 0x11F9EC8 IIIGDLGGEGK
		public int ODNILEDOAIP { get { return HJCJMAONOMH ^ FBGGEFFJJHB_xor; } set { HJCJMAONOMH = value ^ FBGGEFFJJHB_xor; } } //0x11FA4E4 GNKPMBBAJHI 0x11F9ED8 PPMACIMALAC
		public int NPPGKNGIFGK_price { get { return HAIFEBPOPEF ^ FBGGEFFJJHB_xor; } set { HAIFEBPOPEF = value ^ FBGGEFFJJHB_xor; } } //0x11FA4F4 FLMDBAFHDNJ 0x11F9EE8 DIHIEJPOCOJ

		// RVA: 0x11F9D80 Offset: 0x11F9D80 VA: 0x11F9D80
		public MCBOAJEIFNP()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
			BBEGLBMOBOF_xorl = ~FBGGEFFJJHB_xor;
			PPFNGGCBJKC_id = 0;
			IJEKNCDIIAE_mver = 0;
			PLALNIIBLOF_en = 0;
			GBJFNGCDKPM_typ = 0;
			LDLGLHBGOKE_FontSize = 0;
			CPKMLLNADLJ_Serie = 0;
			JBFLEDKDFCO_cid = 0;
			DMEDKJPOLCH_cat = 0;
			EKLIPGELKCL_Rarity = 0;
			MLMCEBBDJOE = 0;
			ODNILEDOAIP = 0;
			NPPGKNGIFGK_price = 0;
		}

		// RVA: 0x11FA120 Offset: 0x11FA120 VA: 0x11FA120
		//public uint CAOGDCBPBAN() { }
	}

	public const int GBMMJDIKMGG = 3;
	public const int JGDONEBKCHM = 300;
	public const int DAMKFCBLMPN = 400;
	public List<MFHKPMPJGHC> FHBIIONKIDI_Stamps = new List<MFHKPMPJGHC>(); // 0x20
	public List<MCBOAJEIFNP> DMKMNGELNAE_Serif = new List<MCBOAJEIFNP>(); // 0x24

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x28 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x2C KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	// RVA: 0x11F9004 Offset: 0x11F9004 VA: 0x11F9004
	public IHFIAFDLAAK_DecoStamp()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		LMHMIIKCGPE = 13;
	}

	// RVA: 0x11F9194 Offset: 0x11F9194 VA: 0x11F9194 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		FHBIIONKIDI_Stamps.Clear();
		DMKMNGELNAE_Serif.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
		OHJFBLFELNK_m_intParam.Clear();
	}

	// RVA: 0x11F9290 Offset: 0x11F9290 VA: 0x11F9290 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		JONOKOHFAJO parser = JONOKOHFAJO.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		KHINMAHJMJD(parser);
		MNGDFBHLDBM(parser);
		{
			LNPGKJNNIFN[] array = parser.BHGDNGHDDAC;
			for(int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
				OHJFBLFELNK_m_intParam.Add(array[i].LJNAKDMILMC_key, data);
			}
		}
		{
			PJHPLPHEBJH[] array = parser.MHGMDJNOLMI;
			for(int i = 0; i < array.Length; i++)
			{
				NNJFKLBPBNK_SecureString data = new NNJFKLBPBNK_SecureString();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
				FJOEBCMGDMI_m_stringParam.Add(array[i].LJNAKDMILMC_key, data);
			}
		}
		return true;
	}

	//// RVA: 0x11F9570 Offset: 0x11F9570 VA: 0x11F9570
	private bool KHINMAHJMJD(JONOKOHFAJO AJLPJINDCBI)
	{
		GDKBIMGFAEE[] array = AJLPJINDCBI.AKMICHNIBCI;
		for(int i = 0; i < array.Length; i++)
		{
			MFHKPMPJGHC data = new MFHKPMPJGHC();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
			data.PLALNIIBLOF_en = (int)array[i].PLALNIIBLOF_en;
			data.GBJFNGCDKPM_typ = (int)array[i].GBJFNGCDKPM_typ;
			data.JBFLEDKDFCO_cid = (int)array[i].JBFLEDKDFCO_cid;
			data.ALAEHBKAEPB = (int)array[i].ALAEHBKAEPB;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
			data.NGILPOOLBCF_OffsetX = array[i].NGILPOOLBCF_OffsetX;
			data.JINEKNIBOFI_OffsetY = array[i].JINEKNIBOFI_OffsetY;
			FHBIIONKIDI_Stamps.Add(data);
		}
		return true;
	}

	//// RVA: 0x11F9890 Offset: 0x11F9890 VA: 0x11F9890
	private bool MNGDFBHLDBM(JONOKOHFAJO AJLPJINDCBI)
	{
		JABLGCMDAIK[] array = AJLPJINDCBI.CKALDHBDFBN;
		for(int i = 0; i < array.Length; i++)
		{
			MCBOAJEIFNP data = new MCBOAJEIFNP();
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
			data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
			data.PLALNIIBLOF_en = (int)array[i].PLALNIIBLOF_en;
			data.GBJFNGCDKPM_typ = array[i].GBJFNGCDKPM_typ;
			data.LDLGLHBGOKE_FontSize = (int)array[i].LDLGLHBGOKE_FontSize;
			data.CPKMLLNADLJ_Serie = (int)array[i].CPKMLLNADLJ_Serie;
			data.JBFLEDKDFCO_cid = (int)array[i].JBFLEDKDFCO_cid;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
			data.DMEDKJPOLCH_cat = (int)array[i].DMEDKJPOLCH_cat;
			data.MLMCEBBDJOE = array[i].MLMCEBBDJOE;
			data.ODNILEDOAIP = array[i].ODNILEDOAIP;
			data.NPPGKNGIFGK_price = array[i].NPPGKNGIFGK_price;
			DMKMNGELNAE_Serif.Add(data);
		}
		return true;
	}

	// RVA: 0x11F9EF8 Offset: 0x11F9EF8 VA: 0x11F9EF8 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// RVA: 0x11F9F00 Offset: 0x11F9F00 VA: 0x11F9F00 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "IHFIAFDLAAK_DecoStamp.CAOGDCBPBAN");
		return 0;
	}

	//// RVA: 0x11FA18C Offset: 0x11FA18C VA: 0x11FA18C
	public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval)
	{
		if (!FJOEBCMGDMI_m_stringParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return FJOEBCMGDMI_m_stringParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	//// RVA: 0x11FA270 Offset: 0x11FA270 VA: 0x11FA270
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if (!OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	//// RVA: 0x11FA354 Offset: 0x11FA354 VA: 0x11FA354
	//public bool GMKNPOJDIPP(string _LJNAKDMILMC_key, out int _NANNGLGOFKH_value) { }
}
