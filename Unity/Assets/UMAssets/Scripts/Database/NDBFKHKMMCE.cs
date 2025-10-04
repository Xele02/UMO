using System.Collections.Generic;
using System.Linq;

[System.Obsolete("Use NDBFKHKMMCE_DecoItem", true)]
public class NDBFKHKMMCE { }
public class NDBFKHKMMCE_DecoItem : DIHHCBACKGG_DbSection
{
	public class ANMODBDBNPK
	{
		public enum DBAMIACJODJ
		{
			HJNNKCMLGFL_0_None = 0,
			PMJFENNOEJD_Bg = 1,
			JKMLKAMHJIF_Obj = 2,
			MIIELMELDBO_Char = 3,
			BKLKNLDCJIO_4_Stamp = 4,
			AAAOOKJAMGE_Sp = 5,
			CAMKIILHPDE_6 = 6,
		}

		public enum BIKFCCKCHHC
		{
			HJNNKCMLGFL_0_None = 0,
			FIHMIDDLAKH_1_CanonFillSp = 1,
			IOEGFJMNDBM_2 = 2,
			JJNIMNEJPOF_3 = 3,
			AEKNIFPOLOK = 4,
			PKAOEMNODGC = 5,
			BEEKDIOOCPB = 6,
			BPHFFAAAEEJ = 7,
			GCAFEMIIJJH = 8,
			HMMABLHNLHN = 9,
			BEHOGNFEDPN = 10,
			JPPOGMHJKKJ_11_VisitItemSp = 11,
			FKEDBMECLJG_12 = 12,
		}
	}

	public class EHLEEEBJLAM_BgItem
	{
		private int FBGGEFFJJHB_xor; // 0x8
		private long BBEGLBMOBOF_xorl; // 0x10
		private int EHOIENNDEDH_IdCrypted; // 0x18
		private int GNGNIKNNCNH_MVerCrypted; // 0x1C
		private int HNJHPNPFAAN_EnabledCrypted; // 0x20
		private int BGALCJHAFPF; // 0x24
		private int IPAKEGGICML_SerieCrypted; // 0x28
		private int EAJCFBCHIFB_RarityCrypted; // 0x2C
		private int MMDBOPCEKCJ; // 0x30
		private int HJCJMAONOMH; // 0x34
		private int HAIFEBPOPEF; // 0x38
		private int JFLBJEOOAMH_SetIdCrypted; // 0x3C

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE28F0 DEMEPMAEJOO_get_id 0x1AE1178 HIGKAIDMOKN_set_id
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2900 KJIMMIBDCIL_get_mver 0x1AE1188 DMEGNOKIKCD_set_mver
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1ADE084 JPCJNLHHIPE_get_en 0x1AE1198 JJFJNEJLBDG_set_en
		public int FJFCNGNGIBN_Attribute { get { return BGALCJHAFPF ^ FBGGEFFJJHB_xor; } set { BGALCJHAFPF = value ^ FBGGEFFJJHB_xor; } } //0x1AE2910 OCNDKILHCJK_get_Attribute 0x1AE11A8 NMEEPJEFADN_set_Attribute
		public int CPKMLLNADLJ_Serie { get { return IPAKEGGICML_SerieCrypted ^ FBGGEFFJJHB_xor; } set { IPAKEGGICML_SerieCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2920 BJPJMGHCDNO_get_Serie 0x1AE11B8 BPKIOJBKNBP_set_Serie
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2930 OEEHBGECGKL_get_Rarity 0x1AE11C8 GHLMHLJJBIG_set_Rarity
		public int MLMCEBBDJOE { get { return MMDBOPCEKCJ ^ FBGGEFFJJHB_xor; } set { MMDBOPCEKCJ = value ^ FBGGEFFJJHB_xor; } } //0x1AE2940 IGMHCODOFKG_get_ 0x1AE11F8 IIIGDLGGEGK_set_
		public int ODNILEDOAIP { get { return HJCJMAONOMH ^ FBGGEFFJJHB_xor; } set { HJCJMAONOMH = value ^ FBGGEFFJJHB_xor; } } //0x1AE2950 GNKPMBBAJHI_get_ 0x1AE11E8 PPMACIMALAC_set_
		public int NPPGKNGIFGK_price { get { return HAIFEBPOPEF ^ FBGGEFFJJHB_xor; } set { HAIFEBPOPEF = value ^ FBGGEFFJJHB_xor; } } //0x1AE2960 FLMDBAFHDNJ_get_price 0x1AE11D8 DIHIEJPOCOJ_set_price
		public int EBIMFANOGBK_SetId { get { return JFLBJEOOAMH_SetIdCrypted ^ FBGGEFFJJHB_xor; } set { JFLBJEOOAMH_SetIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2970 CLJNHJFLOPF_bgs 0x1ADEDEC PBOCBEONGKG_bgs

		// RVA: 0x1AE10C0 Offset: 0x1AE10C0 VA: 0x1AE10C0
		public EHLEEEBJLAM_BgItem()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
			NPPGKNGIFGK_price = 0;
			EBIMFANOGBK_SetId = 0;
			BBEGLBMOBOF_xorl = -FBGGEFFJJHB_xor;
			PPFNGGCBJKC_id = 0;
			IJEKNCDIIAE_mver = 0;
			PLALNIIBLOF_en = 0;
			FJFCNGNGIBN_Attribute = 0;
			CPKMLLNADLJ_Serie = 0;
			EKLIPGELKCL_Rarity = 0;
			MLMCEBBDJOE = 0;
			ODNILEDOAIP = 0;
		}

		// RVA: 0x1AE1FC8 Offset: 0x1AE1FC8 VA: 0x1AE1FC8
		// public uint CAOGDCBPBAN() { }
	}

	public class NIBEBIGPKLA_ObjItem
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public long BBEGLBMOBOF_xorl; // 0x10
		private int EHOIENNDEDH_IdCrypted; // 0x18
		private int GNGNIKNNCNH_MVerCrypted; // 0x1C
		private int HNJHPNPFAAN_EnabledCrypted; // 0x20
		private int NOFECLGOLAI_TypeCrypted; // 0x24
		private int BGALCJHAFPF; // 0x28
		private int IPAKEGGICML_SerieCrypted; // 0x2C
		private int EAJCFBCHIFB_RarityCrypted; // 0x30
		private int IGBOGLAJCAO; // 0x34
		private int ILEIBLFHMEI; // 0x38
		private int CFONNKENNJH; // 0x3C
		private int CCACGHNJNOF; // 0x40
		private int FMCEHHAICJE; // 0x44
		private int HJKNAPMLBFG; // 0x48
		private int HHPFFPINGAA_OrderCrypted; // 0x4C
		private int MMDBOPCEKCJ; // 0x50
		private int HJCJMAONOMH; // 0x54
		private int HAIFEBPOPEF; // 0x58
		private int GJFLAHAGDKG; // 0x5C
		private int JFLBJEOOAMH_SetIdCrypted; // 0x60

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2AD0 DEMEPMAEJOO_get_id 0x1AE12D4 HIGKAIDMOKN_set_id
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2838 KJIMMIBDCIL_get_mver 0x1AE12E4 DMEGNOKIKCD_set_mver
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1ADE648 JPCJNLHHIPE_get_en 0x1AE12F4 JJFJNEJLBDG_set_en
		// Type
		public int GBJFNGCDKPM_typ { get { return NOFECLGOLAI_TypeCrypted ^ FBGGEFFJJHB_xor; } set { NOFECLGOLAI_TypeCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2828 CEJJMKODOGK_get_typ 0x1AE1304 HOHCEBMMACI_set_typ
		public int FJFCNGNGIBN_Attribute { get { return BGALCJHAFPF ^ FBGGEFFJJHB_xor; } set { BGALCJHAFPF = value ^ FBGGEFFJJHB_xor; } } //0x1AE2AE0 OCNDKILHCJK_get_Attribute 0x1AE1314 NMEEPJEFADN_set_Attribute
		public int CPKMLLNADLJ_Serie { get { return IPAKEGGICML_SerieCrypted ^ FBGGEFFJJHB_xor; } set { IPAKEGGICML_SerieCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2AF0 BJPJMGHCDNO_get_Serie 0x1AE1324 BPKIOJBKNBP_set_Serie
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2B00 OEEHBGECGKL_get_Rarity 0x1AE1334 GHLMHLJJBIG_set_Rarity
		public int FAKNMCIIAEM_IsAutoFlip { get { return IGBOGLAJCAO ^ FBGGEFFJJHB_xor; } set { IGBOGLAJCAO = value ^ FBGGEFFJJHB_xor; } } //0x1AE2B10 CGDPJCABPDB_get_IsAutoFlip 0x1AE1344 JJFPNFCDNIC_set_IsAutoFlip
		public int KPECMLFDLOI_pri { get { return ILEIBLFHMEI ^ FBGGEFFJJHB_xor; } set { ILEIBLFHMEI = value ^ FBGGEFFJJHB_xor; } } //0x1AE2B20 ILFJIGDCGBK_get_pri 0x1AE1354 DOGEFDDMBDM_set_pri
		public int NGILPOOLBCF_OffsetX { get { return CFONNKENNJH ^ FBGGEFFJJHB_xor; } set { CFONNKENNJH = value ^ FBGGEFFJJHB_xor; } }	//0x1AE2B30 EDGHLAHGBFN_get_OffsetX 0x1AE1364 LFCKFNLGFCN_set_OffsetX
		public int JINEKNIBOFI_OffsetY { get { return CCACGHNJNOF ^ FBGGEFFJJHB_xor; } set { CCACGHNJNOF = value ^ FBGGEFFJJHB_xor; } } //0x1AE2B40 LKDHAPEGCPH_get_OffsetY 0x1AE1374 PBPDONPMGNF_set_OffsetY
		public int BHDHPCDLICO_Thickness { get { return FMCEHHAICJE ^ FBGGEFFJJHB_xor; } set { FMCEHHAICJE = value ^ FBGGEFFJJHB_xor; } } //0x1AE2B50 AHKMMIGMMHJ_bgs 0x1AE1384 CHFCMEBBCOG_bgs
		public int CMMNFCJNIOO_IsOnShelf { get { return HJKNAPMLBFG ^ FBGGEFFJJHB_xor; } set { HJKNAPMLBFG = value ^ FBGGEFFJJHB_xor; } } //0x1AE2B60 IPBHOIGBNEO_get_IsOnShelf 0x1AE1394 EACBGCGAKLO_set_IsOnShelf
		public int EILKGEADKGH_Order { get { return HHPFFPINGAA_OrderCrypted ^ FBGGEFFJJHB_xor; } set { HHPFFPINGAA_OrderCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2B70 NPDDACIHBKD_get_Order 0x1AE13A4 BJJMCKHBPNH_set_Order
		public int MLMCEBBDJOE { get { return MMDBOPCEKCJ ^ FBGGEFFJJHB_xor; } set { MMDBOPCEKCJ = value ^ FBGGEFFJJHB_xor; } } //0x1AE2B80 IGMHCODOFKG_get_ 0x1AE13B4 IIIGDLGGEGK_set_
		public int ODNILEDOAIP { get { return HJCJMAONOMH ^ FBGGEFFJJHB_xor; } set { HJCJMAONOMH = value ^ FBGGEFFJJHB_xor; } } //0x1AE2B90 GNKPMBBAJHI_get_ 0x1AE13C4 PPMACIMALAC_set_
		public int NPPGKNGIFGK_price { get { return HAIFEBPOPEF ^ FBGGEFFJJHB_xor; } set { HAIFEBPOPEF = value ^ FBGGEFFJJHB_xor; } } //0x1AE2BA0 FLMDBAFHDNJ_get_price 0x1AE13D4 DIHIEJPOCOJ_set_price
		public int KEJMJPHFFOJ_Max { get { return GJFLAHAGDKG ^ FBGGEFFJJHB_xor; } set { GJFLAHAGDKG = value ^ FBGGEFFJJHB_xor; } } //0x1AE2BB0 FMNMLNIALNE_get_Max 0x1AE13E4 GBEPCBPOGDB_set_Max
		public int EBIMFANOGBK_SetId { get { return JFLBJEOOAMH_SetIdCrypted ^ FBGGEFFJJHB_xor; } set { JFLBJEOOAMH_SetIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2BC0 CLJNHJFLOPF_bgs 0x1ADEDFC PBOCBEONGKG_bgs

		// RVA: 0x1AE1208 Offset: 0x1AE1208 VA: 0x1AE1208
		public NIBEBIGPKLA_ObjItem()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
			ODNILEDOAIP = 0;
			EILKGEADKGH_Order = 0;
			EBIMFANOGBK_SetId = 0;
			BBEGLBMOBOF_xorl = -FBGGEFFJJHB_xor;
			PPFNGGCBJKC_id = 0;
			IJEKNCDIIAE_mver = 0;
			PLALNIIBLOF_en = 0;
			GBJFNGCDKPM_typ = 0;
			FJFCNGNGIBN_Attribute = 0;
			CPKMLLNADLJ_Serie = 0;
			EKLIPGELKCL_Rarity = 0;
			FAKNMCIIAEM_IsAutoFlip = 0;
			KPECMLFDLOI_pri = 0;
			NGILPOOLBCF_OffsetX = 0;
			JINEKNIBOFI_OffsetY = 0;
			BHDHPCDLICO_Thickness = 0;
			CMMNFCJNIOO_IsOnShelf = 0;
			MLMCEBBDJOE = 0;
			NPPGKNGIFGK_price = 0;
			KEJMJPHFFOJ_Max = 0;
		}

		// RVA: 0x1AE2028 Offset: 0x1AE2028 VA: 0x1AE2028
		// public uint CAOGDCBPBAN() { }
	}

	public class FIDBAFHNGCF : NIBEBIGPKLA_ObjItem
	{
		private int HNNLOMMFHEN_catCrypted; // 0x64
		private int PIMKKONMBOG_ItemIdCrypted; // 0x68
		private int CGDIOPJFHHD; // 0x6C

		public int DMEDKJPOLCH_cat { get { return HNNLOMMFHEN_catCrypted ^ FBGGEFFJJHB_xor; } set { HNNLOMMFHEN_catCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2980 IPKCKAAEEOE_get_cat 0x1AE1438 JOGLLINFLJN_set_cat
		public int KIJAPOFAGPN_ItemId { get { return PIMKKONMBOG_ItemIdCrypted ^ FBGGEFFJJHB_xor; } set { PIMKKONMBOG_ItemIdCrypted = value ^ FBGGEFFJJHB_xor; } }  //0x1AE2990 GCKKKIDNACI_bgs 0x1AE1418 OGBLMPODGBG_bgs
		public int ADECCOKCCDH { get { return CGDIOPJFHHD ^ FBGGEFFJJHB_xor; } set { CGDIOPJFHHD = value ^ FBGGEFFJJHB_xor; } } //0x1AE29A0 GCFCECGJAJF_bgs 0x1AE1428 GJBMKGFMOFF_bgs

		// RVA: 0x1AE13F4 Offset: 0x1AE13F4 VA: 0x1AE13F4
		public FIDBAFHNGCF()
		{
			DMEDKJPOLCH_cat = 0;
			KIJAPOFAGPN_ItemId = 0;
			ADECCOKCCDH = 0;
		}

		// RVA: 0x1AE20F8 Offset: 0x1AE20F8 VA: 0x1AE20F8
		// public uint CAOGDCBPBAN() { }
	}

	public class PELPLGBMOII
	{
		private int FBGGEFFJJHB_xor; // 0x8
		private long BBEGLBMOBOF_xorl; // 0x10
		public CEBFFLDKAEC_SecureInt[] IPGHEIAFCHE = new CEBFFLDKAEC_SecureInt[10]; // 0x18
		public CEBFFLDKAEC_SecureInt[] MILFOEODPDK = new CEBFFLDKAEC_SecureInt[10]; // 0x1C
		private int EHOIENNDEDH_IdCrypted; // 0x20
		private int IBNLAGGBLDH; // 0x24

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2C44 DEMEPMAEJOO_get_id 0x1AE16E8 HIGKAIDMOKN_set_id
		public int AGHJAAMABPI { get { return IBNLAGGBLDH ^ FBGGEFFJJHB_xor; } set { IBNLAGGBLDH = value ^ FBGGEFFJJHB_xor; } } //0x1AE2C54 IICGAHBLHFJ_bgs 0x1AE16F8 OJOFJPLDCNB_bgs

		// RVA: 0x1AE1448 Offset: 0x1AE1448 VA: 0x1AE1448
		public PELPLGBMOII()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
			PPFNGGCBJKC_id = 0;
			AGHJAAMABPI = 0;
			BBEGLBMOBOF_xorl = -FBGGEFFJJHB_xor;
			for(int i = 0; i < 10; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				IPGHEIAFCHE[i] = data;
				data.DNJEJEANJGL_Value = 0;

				data = new CEBFFLDKAEC_SecureInt();
				MILFOEODPDK[i] = data;
				data.DNJEJEANJGL_Value = 0;
			}
		}

		// RVA: 0x1AE2130 Offset: 0x1AE2130 VA: 0x1AE2130
		// public uint CAOGDCBPBAN() { }
	}

	public class IEOEMNPLANK_PosterItem
	{
		private int FBGGEFFJJHB_xor; // 0x8
		private long BBEGLBMOBOF_xorl; // 0x10
		private int EHOIENNDEDH_IdCrypted; // 0x18
		private int GNGNIKNNCNH_MVerCrypted; // 0x1C
		private int HNJHPNPFAAN_EnabledCrypted; // 0x20
		private int IPAKEGGICML_SerieCrypted; // 0x24
		private int EAJCFBCHIFB_RarityCrypted; // 0x28
		private int MMDBOPCEKCJ; // 0x2C
		private int HJCJMAONOMH; // 0x30
		private int HAIFEBPOPEF; // 0x34
		private int GJFLAHAGDKG; // 0x38
		private int JFLBJEOOAMH_SetIdCrypted; // 0x3C

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2A40 DEMEPMAEJOO_get_id 0x1AE17C0 HIGKAIDMOKN_set_id
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2A50 KJIMMIBDCIL_get_mver 0x1AE17D0 DMEGNOKIKCD_set_mver
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1ADE658 JPCJNLHHIPE_get_en 0x1AE17E0 JJFJNEJLBDG_set_en
		public int CPKMLLNADLJ_Serie { get { return IPAKEGGICML_SerieCrypted ^ FBGGEFFJJHB_xor; } set { IPAKEGGICML_SerieCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2A60 BJPJMGHCDNO_get_Serie 0x1AE17F0 BPKIOJBKNBP_set_Serie
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2A70 OEEHBGECGKL_get_Rarity 0x1AE1800 GHLMHLJJBIG_set_Rarity
		public int MLMCEBBDJOE { get { return MMDBOPCEKCJ ^ FBGGEFFJJHB_xor; } set { MMDBOPCEKCJ = value ^ FBGGEFFJJHB_xor; } } //0x1AE2A80 IGMHCODOFKG_get_ 0x1AE1810 IIIGDLGGEGK_set_
		public int ODNILEDOAIP { get { return HJCJMAONOMH ^ FBGGEFFJJHB_xor; } set { HJCJMAONOMH = value ^ FBGGEFFJJHB_xor; } } //0x1AE2A90 GNKPMBBAJHI_get_ 0x1AE1820 PPMACIMALAC_set_
		public int NPPGKNGIFGK_price { get { return HAIFEBPOPEF ^ FBGGEFFJJHB_xor; } set { HAIFEBPOPEF = value ^ FBGGEFFJJHB_xor; } } //0x1AE2AA0 FLMDBAFHDNJ_get_price 0x1AE1830 DIHIEJPOCOJ_set_price
		public int KEJMJPHFFOJ_Max { get { return GJFLAHAGDKG ^ FBGGEFFJJHB_xor; } set { GJFLAHAGDKG = value ^ FBGGEFFJJHB_xor; } } //0x1AE2AB0 FMNMLNIALNE_get_Max 0x1AE1840 GBEPCBPOGDB_set_Max
		public int EBIMFANOGBK_SetId { get { return JFLBJEOOAMH_SetIdCrypted ^ FBGGEFFJJHB_xor; } set { JFLBJEOOAMH_SetIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2AC0 CLJNHJFLOPF_bgs 0x1ADEE1C PBOCBEONGKG_bgs

			// RVA: 0x1AE1708 Offset: 0x1AE1708 VA: 0x1AE1708
		public IEOEMNPLANK_PosterItem()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
			KEJMJPHFFOJ_Max = 0;
			EBIMFANOGBK_SetId = 0;
			BBEGLBMOBOF_xorl = -FBGGEFFJJHB_xor;
			PPFNGGCBJKC_id = 0;
			PLALNIIBLOF_en = 0;
			EKLIPGELKCL_Rarity = 0;
			ODNILEDOAIP = 0;
		}

		// RVA: 0x1AE2218 Offset: 0x1AE2218 VA: 0x1AE2218
		// public uint CAOGDCBPBAN() { }
	}

	public class CCHHGIJMLBN_CharaItem
	{
		private int FBGGEFFJJHB_xor; // 0x8
		private long BBEGLBMOBOF_xorl; // 0x10
		public CEBFFLDKAEC_SecureInt[] KPIBEAHCGOB = new CEBFFLDKAEC_SecureInt[5]; // 0x18
		private int EHOIENNDEDH_IdCrypted; // 0x1C
		private int GNGNIKNNCNH_MVerCrypted; // 0x20
		private int HNJHPNPFAAN_EnabledCrypted; // 0x24
		private int KGKIDDDKOGL_cidCrypted; // 0x28
		private int NOFECLGOLAI_TypeCrypted; // 0x2C
		private int IPAKEGGICML_SerieCrypted; // 0x30
		private int EAJCFBCHIFB_RarityCrypted; // 0x34
		private int MMDBOPCEKCJ; // 0x38
		private int HJCJMAONOMH; // 0x3C
		private int HAIFEBPOPEF; // 0x40
		private int JFLBJEOOAMH_SetIdCrypted; // 0x44

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2850 DEMEPMAEJOO_get_id 0x1AE1A14 HIGKAIDMOKN_set_id
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2860 KJIMMIBDCIL_get_mver 0x1AE1A24 DMEGNOKIKCD_set_mver
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1ADE638 JPCJNLHHIPE_get_en 0x1AE1A34 JJFJNEJLBDG_set_en
		public int JBFLEDKDFCO_cid { get { return KGKIDDDKOGL_cidCrypted ^ FBGGEFFJJHB_xor; } set { KGKIDDDKOGL_cidCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2870 LIJMKJLDHGP_get_cid 0x1AE1A44_bgs NFNCLFPPADP_set_cid
		//Type
		public int GBJFNGCDKPM_typ { get { return NOFECLGOLAI_TypeCrypted ^ FBGGEFFJJHB_xor; } set { NOFECLGOLAI_TypeCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2880 CEJJMKODOGK_get_typ 0x1AE1A54 HOHCEBMMACI_set_typ
		public int CPKMLLNADLJ_Serie { get { return IPAKEGGICML_SerieCrypted ^ FBGGEFFJJHB_xor; } set { IPAKEGGICML_SerieCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2890 BJPJMGHCDNO_get_Serie 0x1AE1A64 BPKIOJBKNBP_set_Serie
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE28A0 OEEHBGECGKL_get_Rarity 0x1AE1A74 GHLMHLJJBIG_set_Rarity
		public int MLMCEBBDJOE { get { return MMDBOPCEKCJ ^ FBGGEFFJJHB_xor; } set { MMDBOPCEKCJ = value ^ FBGGEFFJJHB_xor; } } //0x1AE28B0 IGMHCODOFKG_get_ 0x1AE1A84 IIIGDLGGEGK_set_
		public int ODNILEDOAIP { get { return HJCJMAONOMH ^ FBGGEFFJJHB_xor; } set { HJCJMAONOMH = value ^ FBGGEFFJJHB_xor; } } //0x1AE28C0 GNKPMBBAJHI_get_ 0x1AE1A94 PPMACIMALAC_set_
		public int NPPGKNGIFGK_price { get { return HAIFEBPOPEF ^ FBGGEFFJJHB_xor; } set { HAIFEBPOPEF = value ^ FBGGEFFJJHB_xor; } } //0x1AE28D0 FLMDBAFHDNJ_get_price 0x1AE1AA4 DIHIEJPOCOJ_set_price
		public int EBIMFANOGBK_SetId { get { return JFLBJEOOAMH_SetIdCrypted ^ FBGGEFFJJHB_xor; } set { JFLBJEOOAMH_SetIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE28E0 CLJNHJFLOPF_bgs 0x1ADEE0C PBOCBEONGKG_bgs

		// RVA: 0x1AE1850 Offset: 0x1AE1850 VA: 0x1AE1850
		public CCHHGIJMLBN_CharaItem()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
			ODNILEDOAIP = 0;
			NPPGKNGIFGK_price = 0;
			EBIMFANOGBK_SetId = 0;
			BBEGLBMOBOF_xorl = -FBGGEFFJJHB_xor;
			PPFNGGCBJKC_id = 0;
			PLALNIIBLOF_en = 0;
			GBJFNGCDKPM_typ = 0;
			EKLIPGELKCL_Rarity = 0;
			for(int i = 0; i < 5; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				KPIBEAHCGOB[i] = data;
				data.DNJEJEANJGL_Value = 0;
			}
		}

		// RVA: 0x1AE2278 Offset: 0x1AE2278 VA: 0x1AE2278
		// public uint CAOGDCBPBAN() { }
	}

	public class NNCIBDMDEFE
	{
		private int FBGGEFFJJHB_xor; // 0x8
		private long BBEGLBMOBOF_xorl; // 0x10
		private int EHOIENNDEDH_IdCrypted; // 0x18
		private int EMKPFNEJOAB; // 0x1C
		private long PCLNFCNIECH_OpenAtCrypted; // 0x20
		private long HHPIJHADAOB_CloseAtCrypted; // 0x28
		private int OIFAFKDMEEJ_EnabledCrypted; // 0x30

		public int MDLEEKBBEKD { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE2BD0 ODPALPLOPNN_bgs 0x1AE1B68 FJJOKFJJHME_bgs
		public int EFNKCPBALOP_EffectId { get { return EMKPFNEJOAB ^ FBGGEFFJJHB_xor; } set { EMKPFNEJOAB = value ^ FBGGEFFJJHB_xor; } } //0x1AE2BE0 HAIPHNPDPIP_bgs 0x1AE1B88 DBJFAEOKOEK_bgs
		public long NMELNJNFMJF_Start { get { return PCLNFCNIECH_OpenAtCrypted ^ BBEGLBMOBOF_xorl; } set { PCLNFCNIECH_OpenAtCrypted = value ^ BBEGLBMOBOF_xorl; } } //0x1AE2BF0 KPCNKFFKELH_bgs 0x1AE1B98 BEMLPMCBHEA_bgs
		public long IAJAOIEOPDP_End { get { return HHPIJHADAOB_CloseAtCrypted ^ BBEGLBMOBOF_xorl; } set { HHPIJHADAOB_CloseAtCrypted = value ^ BBEGLBMOBOF_xorl; } } //0x1AE2C04 GEFNJEHLBAL_bgs 0x1AE1BB8 IGAAEBAFAHB_bgs
		public int PPEGAKEIEGM_Enabled { get { return OIFAFKDMEEJ_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { OIFAFKDMEEJ_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AE1BD8 KPOEEPIMMJP_bgs 0x1AE1B78 NCIEAFEDPBH_bgs

		// RVA: 0x1AE1AB4 Offset: 0x1AE1AB4 VA: 0x1AE1AB4
		public NNCIBDMDEFE()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
			EMKPFNEJOAB = FBGGEFFJJHB_xor;
			BBEGLBMOBOF_xorl = -FBGGEFFJJHB_xor;
			PCLNFCNIECH_OpenAtCrypted = FBGGEFFJJHB_xor;
			HHPIJHADAOB_CloseAtCrypted = FBGGEFFJJHB_xor;
		}

		// RVA: 0x1AE2C18 Offset: 0x1AE2C18 VA: 0x1AE2C18
		// public uint CAOGDCBPBAN() { }
	}

	public struct FKIMJLOFONM
	{
		private int FBGGEFFJJHB_xor; // 0x0
		private int OHMGPDPKGLF_ValueCrypted; // 0x4

		public int NANNGLGOFKH_value { get { return OHMGPDPKGLF_ValueCrypted ^ FBGGEFFJJHB_xor; } set { OHMGPDPKGLF_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0x7FEBC4 EDFAHCMGHKM_get_value 0x7FEBD4 BKPDFNKGNHA_set_value

		// RVA: 0x7FEBE4 Offset: 0x7FEBE4 VA: 0x7FEBE4
		public FKIMJLOFONM(int _NANNGLGOFKH_value, int _FBGGEFFJJHB_xor)
		{
			this.FBGGEFFJJHB_xor = _FBGGEFFJJHB_xor;
			OHMGPDPKGLF_ValueCrypted = 0;
			this.NANNGLGOFKH_value = _NANNGLGOFKH_value;
		}

		//// RVA: 0x1AE29E0 Offset: 0x1AE29E0 VA: 0x1AE29E0
		public static int JNEJKMKNIJJ(FKIMJLOFONM OHDPMGMGJBI)
		{
			return OHDPMGMGJBI.NANNGLGOFKH_value;
		}

		//// RVA: 0x1AE29E8 Offset: 0x1AE29E8 VA: 0x1AE29E8
		//public static string HBPCIELOBKD(NDBFKHKMMCE_DecoItem.FKIMJLOFONM OHDPMGMGJBI) { }

		// RVA: 0x7FEBF4 Offset: 0x7FEBF4 VA: 0x7FEBF4 Slot: 3
		public override string ToString()
		{
			return NANNGLGOFKH_value.ToString();
		}
	}


	// public const int NLDKJMCFECI = 200;
	// public const int LNNEEPBINDO = 6000;
	// public const int IKMLLLANDNO = 100;
	// public const int HEGFNNDPKJI = 50;
	// public const int NOMAGGDHCCC = 100;
	// public const int JGDONEBKCHM = 5;
	// public const int OKKOJBACFHH = 10;
	public List<EHLEEEBJLAM_BgItem> GJLHEJPHEDA_ItemsBg = new List<EHLEEEBJLAM_BgItem>(); // 0x20
	public List<NIBEBIGPKLA_ObjItem> GHOLIPLDMPJ_ItemsObj = new List<NIBEBIGPKLA_ObjItem>(); // 0x24
	public List<FIDBAFHNGCF> GMONECJCJFK_Sp = new List<FIDBAFHNGCF>(); // 0x28
	public List<PELPLGBMOII> ONODAPNHMPB = new List<PELPLGBMOII>(); // 0x2C
	public List<IEOEMNPLANK_PosterItem> COLIEKINOPB_ItemsPoster = new List<IEOEMNPLANK_PosterItem>(); // 0x30
	public List<CCHHGIJMLBN_CharaItem> KHCACDIKJLG_Characters = new List<CCHHGIJMLBN_CharaItem>(); // 0x34
	public List<NNCIBDMDEFE> JDMCHNFAOFO = new List<NNCIBDMDEFE>(); // 0x38

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x3C IHKPIFIBECO GAMGELHIHHI_get_m_stringParam DDDEJIJGGBJ_set_m_stringParam
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x40 KLDCHOIPJGB AEMNOGNEBOJ_get_m_intParam DGKDBOAMNBB_set_m_intParam

	// // RVA: 0x1ADDEF8 Offset: 0x1ADDEF8 VA: 0x1ADDEF8
	public bool KOPLBMLHKCD_IsValidBgItem(int _GLCLFMGPMAN_ItemId)
	{
		if(_GLCLFMGPMAN_ItemId == 0)
			return true;
		else if(_GLCLFMGPMAN_ItemId < 0)
			return false;
		else
		{
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_GLCLFMGPMAN_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg)
			{
				int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(_GLCLFMGPMAN_ItemId);
				if(id != 0)
				{
					if(id <= GJLHEJPHEDA_ItemsBg.Count)
					{
						return GJLHEJPHEDA_ItemsBg[id - 1].PLALNIIBLOF_en == 2;
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x1ADE094 Offset: 0x1ADE094 VA: 0x1ADE094
	public bool FMGPOKFKPIJ_IsValidItem(OKGLGHCBCJP_Database _NDFIEMPPMLF_master, int _GLCLFMGPMAN_ItemId)
	{
        EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_GLCLFMGPMAN_ItemId);
        int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(_GLCLFMGPMAN_ItemId);
		if(id < 1)
			return false;
		switch(cat)
		{
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
				if(id <= GHOLIPLDMPJ_ItemsObj.Count)
				{
					return GHOLIPLDMPJ_ItemsObj[id - 1].PLALNIIBLOF_en == 2;
				}
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
				if(id <= KHCACDIKJLG_Characters.Count)
				{
					return KHCACDIKJLG_Characters[id - 1].PLALNIIBLOF_en == 2;
				}
				break;
			default:
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
				if(id <= GMONECJCJFK_Sp.Count)
				{
					return GMONECJCJFK_Sp[id - 1].PLALNIIBLOF_en == 2;
				}
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
				if(id <= COLIEKINOPB_ItemsPoster.Count)
				{
					return COLIEKINOPB_ItemsPoster[id - 1].PLALNIIBLOF_en == 2;
				}
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
				if(id <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table.Count)
				{
					return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[id - 1].PPEGAKEIEGM_Enabled == 2;
				}
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
				if(id <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_table.Count)
				{
					return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_table[id - 1].PPEGAKEIEGM_Enabled == 2;
				}
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
				if(id <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_table.Count)
				{
					return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_table[id - 1].PPEGAKEIEGM_Enabled == 2;
				}
				break;
		}
		return false;
	}

	// // RVA: 0x1ADE668 Offset: 0x1ADE668 VA: 0x1ADE668
	public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval)
	{
		if (!FJOEBCMGDMI_m_stringParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return FJOEBCMGDMI_m_stringParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	// // RVA: 0x1ADE74C Offset: 0x1ADE74C VA: 0x1ADE74C
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if (!OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	// // RVA: 0x1ADE830 Offset: 0x1ADE830 VA: 0x1ADE830
	public bool GMKNPOJDIPP(string _LJNAKDMILMC_key, out int _NANNGLGOFKH_value)
	{
		_NANNGLGOFKH_value = 0;
		if(OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
		{
			_NANNGLGOFKH_value = OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
			return true;
		}
		return false;
	}

	// // RVA: 0x1ADE920 Offset: 0x1ADE920 VA: 0x1ADE920
	public void MFIAFCCJHOF(BBLECJKKKLA_DecoSetItem _MJALLIOHKEJ_DecoSetItem)
	{
        for(int i = 0; i < _MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA_table.Count; i++)
		{
			BBLECJKKKLA_DecoSetItem.GJBPBKNHLHC_DecoSetItemInfo set = _MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA_table[i];
			if (set.PLALNIIBLOF_en == 2)
			{
				for(int j = 0; j < set.JJBNDDDGEAN_GetNumItems(); j++)
				{
					int code = set.FKNBLDPIPMC_GetItemCode(j);
					EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(code);
					int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(code);
					if(id > 0)
					{
						switch(cat)
						{
							case EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
								if(GJLHEJPHEDA_ItemsBg.Count >= id)
								{
									EHLEEEBJLAM_BgItem bgItem = GJLHEJPHEDA_ItemsBg[id - 1];
									bgItem.EBIMFANOGBK_SetId = set.PPFNGGCBJKC_id;
								}
								break;
							case EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
								if(GHOLIPLDMPJ_ItemsObj.Count >= id)
								{
									NIBEBIGPKLA_ObjItem objItem = GHOLIPLDMPJ_ItemsObj[id - 1];
									objItem.EBIMFANOGBK_SetId = set.PPFNGGCBJKC_id;
								}
								break;
							case EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
								if (KHCACDIKJLG_Characters.Count >= id)
								{
									CCHHGIJMLBN_CharaItem charaItem = KHCACDIKJLG_Characters[id - 1];
									charaItem.EBIMFANOGBK_SetId = set.PPFNGGCBJKC_id;
								}
								break;
							case EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
								if (COLIEKINOPB_ItemsPoster.Count >= id)
								{
									IEOEMNPLANK_PosterItem posterItem = COLIEKINOPB_ItemsPoster[id - 1];
									posterItem.EBIMFANOGBK_SetId = set.PPFNGGCBJKC_id;
								}
								break;
						}
					}
				}
			}
		}
	}

	// // RVA: 0x1ADEE2C Offset: 0x1ADEE2C VA: 0x1ADEE2C
	public NDBFKHKMMCE_DecoItem()
    {
		JIKKNHIAEKG_BlockName = "";
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 13;
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
    }

	// // RVA: 0x1ADF0C0 Offset: 0x1ADF0C0 VA: 0x1ADF0C0 Slot: 8
	protected override void KMBPACJNEOF_Reset()
    {
		GJLHEJPHEDA_ItemsBg.Clear();
		GHOLIPLDMPJ_ItemsObj.Clear();
		GMONECJCJFK_Sp.Clear();
		ONODAPNHMPB.Clear();
		COLIEKINOPB_ItemsPoster.Clear();
		KHCACDIKJLG_Characters.Clear();
		JDMCHNFAOFO.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
    }

	// // RVA: 0x1ADF298 Offset: 0x1ADF298 VA: 0x1ADF298 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
    {
		NLFIKMMPOAL parser = NLFIKMMPOAL.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		MPPKBPADFBE(parser);
		DGJJPDCFKKM(parser);
		FEEHPPNFAHP(parser);
		GPJFKMCOAAL(parser);
		GPNIEKBBIII(parser);
		OGIAJJLNKNE(parser);
		BFLDLDCDFIC(parser);
		{
			HAJOGKOEFID[] array = parser.BHGDNGHDDAC;
			for(int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
				OHJFBLFELNK_m_intParam.Add(array[i].LJNAKDMILMC_key, data);
			}
		}
		{
			AGLIIECMMKO[] array = parser.MHGMDJNOLMI;
			for (int i = 0; i < array.Length; i++)
			{
				NNJFKLBPBNK_SecureString data = new NNJFKLBPBNK_SecureString();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
				FJOEBCMGDMI_m_stringParam.Add(array[i].LJNAKDMILMC_key, data);
			}
		}
		return true;
    }

	// // RVA: 0x1ADF5B4 Offset: 0x1ADF5B4 VA: 0x1ADF5B4
	private bool MPPKBPADFBE(NLFIKMMPOAL AJLPJINDCBI)
	{
		OANCBKFMLFB[] array = AJLPJINDCBI.DPMFAJPEFOL;
		for(int i = 0; i < array.Length; i++)
		{
			EHLEEEBJLAM_BgItem data = new EHLEEEBJLAM_BgItem();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
			data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, (int)array[i].PLALNIIBLOF_en, 0);
			data.FJFCNGNGIBN_Attribute = (int)array[i].FJFCNGNGIBN_Attribute;
			data.CPKMLLNADLJ_Serie = (int)array[i].CPKMLLNADLJ_Serie;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
			data.NPPGKNGIFGK_price = array[i].NPPGKNGIFGK_price;
			data.ODNILEDOAIP = array[i].ODNILEDOAIP;
			data.MLMCEBBDJOE = array[i].MLMCEBBDJOE;
			GJLHEJPHEDA_ItemsBg.Add(data);
		}
		return true;
	}

	// // RVA: 0x1ADF91C Offset: 0x1ADF91C VA: 0x1ADF91C
	private bool DGJJPDCFKKM(NLFIKMMPOAL AJLPJINDCBI)
	{
		IJLIGDANLAG[] array = AJLPJINDCBI.NGJHCGBNCNL;
		for(int i = 0; i < array.Length; i++)
		{
			NIBEBIGPKLA_ObjItem data = new NIBEBIGPKLA_ObjItem();
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
			data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
			data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, (int)array[i].PLALNIIBLOF_en, 0);
			data.GBJFNGCDKPM_typ = array[i].GBJFNGCDKPM_typ;
			data.FJFCNGNGIBN_Attribute = array[i].FJFCNGNGIBN_Attribute;
			data.CPKMLLNADLJ_Serie = (int)array[i].CPKMLLNADLJ_Serie;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
			data.FAKNMCIIAEM_IsAutoFlip = (int)array[i].FAKNMCIIAEM_IsAutoFlip;
			data.KPECMLFDLOI_pri = (int)array[i].KPECMLFDLOI_pri;
			data.NGILPOOLBCF_OffsetX = array[i].NGILPOOLBCF_OffsetX;
			data.JINEKNIBOFI_OffsetY = array[i].JINEKNIBOFI_OffsetY;
			data.BHDHPCDLICO_Thickness = array[i].IHLFAPCIBJB;
			data.CMMNFCJNIOO_IsOnShelf = (int)array[i].CMMNFCJNIOO_IsOnShelf;
			data.EILKGEADKGH_Order = array[i].FPOMEEJFBIG_odr;
			data.MLMCEBBDJOE = array[i].MLMCEBBDJOE;
			data.ODNILEDOAIP = array[i].ODNILEDOAIP;
			data.NPPGKNGIFGK_price = array[i].NPPGKNGIFGK_price;
			data.KEJMJPHFFOJ_Max = array[i].KEJMJPHFFOJ_Max;
			GHOLIPLDMPJ_ItemsObj.Add(data);
		}
		return true;
	}

	// // RVA: 0x1ADFE3C Offset: 0x1ADFE3C VA: 0x1ADFE3C
	private bool FEEHPPNFAHP(NLFIKMMPOAL AJLPJINDCBI)
	{
		JLFONMFLBHF[] array = AJLPJINDCBI.NNCJEMHAIMC;
		for(int i = 0; i < array.Length; i++)
		{
			FIDBAFHNGCF data = new FIDBAFHNGCF();
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
			data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
			data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, (int)array[i].PLALNIIBLOF_en, 0);
			data.GBJFNGCDKPM_typ = array[i].GBJFNGCDKPM_typ;
			data.FJFCNGNGIBN_Attribute = array[i].FJFCNGNGIBN_Attribute;
			data.CPKMLLNADLJ_Serie = (int)array[i].CPKMLLNADLJ_Serie;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
			data.FAKNMCIIAEM_IsAutoFlip = (int)array[i].FAKNMCIIAEM_IsAutoFlip;
			data.KPECMLFDLOI_pri = (int)array[i].KPECMLFDLOI_pri;
			data.NGILPOOLBCF_OffsetX = array[i].NGILPOOLBCF_OffsetX;
			data.JINEKNIBOFI_OffsetY = array[i].JINEKNIBOFI_OffsetY;
			data.BHDHPCDLICO_Thickness = array[i].IHLFAPCIBJB;
			data.CMMNFCJNIOO_IsOnShelf = (int)array[i].CMMNFCJNIOO_IsOnShelf;
			data.EILKGEADKGH_Order = 0;
			data.KIJAPOFAGPN_ItemId = (int)array[i].GLCLFMGPMAN_ItemId;
			data.ADECCOKCCDH = array[i].JJPDPNJFBHN_TableId;
			data.DMEDKJPOLCH_cat = (int)array[i].DMEDKJPOLCH_cat;
			GMONECJCJFK_Sp.Add(data);
		}
		return true;
	}

	// // RVA: 0x1AE0308 Offset: 0x1AE0308 VA: 0x1AE0308
	private bool GPJFKMCOAAL(NLFIKMMPOAL AJLPJINDCBI)
	{
		JBFPJEDOMLM[] array = AJLPJINDCBI.JMFICAHELIK;
		for(int i = 0; i < array.Length; i++)
		{
			PELPLGBMOII data = new PELPLGBMOII();
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
			data.AGHJAAMABPI = array[i].IGKCGELCEBD;
			for(int j = 0; j < data.IPGHEIAFCHE.Length; j++)
			{
				data.IPGHEIAFCHE[j].DNJEJEANJGL_Value = array[i].KONAMNAICNJ[j];
				data.MILFOEODPDK[j].DNJEJEANJGL_Value = array[i].JAHIGOPCJBG[j];
			}
			ONODAPNHMPB.Add(data);
		}
		return true;
	}

	// // RVA: 0x1AE0638 Offset: 0x1AE0638 VA: 0x1AE0638
	private bool GPNIEKBBIII(NLFIKMMPOAL AJLPJINDCBI)
	{
		GJLHLFLOCGJ[] array = AJLPJINDCBI.HLKGADDBKDB;
		for(int i = 0; i < array.Length; i++)
		{
			IEOEMNPLANK_PosterItem data = new IEOEMNPLANK_PosterItem();
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
			data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
			data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, (int)array[i].PLALNIIBLOF_en, 0);
			data.CPKMLLNADLJ_Serie = (int)array[i].CPKMLLNADLJ_Serie;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
			data.MLMCEBBDJOE = array[i].MLMCEBBDJOE;
			data.ODNILEDOAIP = array[i].ODNILEDOAIP;
			data.NPPGKNGIFGK_price = array[i].NPPGKNGIFGK_price;
			data.KEJMJPHFFOJ_Max = array[i].KEJMJPHFFOJ_Max;
			COLIEKINOPB_ItemsPoster.Add(data);
		}
		return true;
	}

	// // RVA: 0x1AE09A0 Offset: 0x1AE09A0 VA: 0x1AE09A0
	private bool OGIAJJLNKNE(NLFIKMMPOAL AJLPJINDCBI)
	{
		IPFNMBJGFFB[] array = AJLPJINDCBI.CEPBAOMAHNH;
		for(int i = 0; i < array.Length; i++)
		{
			CCHHGIJMLBN_CharaItem data = new CCHHGIJMLBN_CharaItem();
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
			data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
			data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, (int)array[i].PLALNIIBLOF_en, 0);
			data.JBFLEDKDFCO_cid = array[i].JBFLEDKDFCO_cid;
			data.GBJFNGCDKPM_typ = array[i].GBJFNGCDKPM_typ;
			data.CPKMLLNADLJ_Serie = (int)array[i].CPKMLLNADLJ_Serie;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
			data.MLMCEBBDJOE = array[i].MLMCEBBDJOE;
			data.ODNILEDOAIP = array[i].ODNILEDOAIP;
			data.NPPGKNGIFGK_price = array[i].NPPGKNGIFGK_price;
			for(int j = 0; j < data.KPIBEAHCGOB.Length; j++)
			{
				data.KPIBEAHCGOB[j].DNJEJEANJGL_Value = array[i].GNKMHCKFADN_stamp[j];
			}
			KHCACDIKJLG_Characters.Add(data);
		}
		return true;
	}

	// // RVA: 0x1AE0E00 Offset: 0x1AE0E00 VA: 0x1AE0E00
	private bool BFLDLDCDFIC(NLFIKMMPOAL AJLPJINDCBI)
	{
		JCNADBBMELP[] array = AJLPJINDCBI.OOEMJCHLAKD;
		for(int i = 0; i < array.Length; i++)
		{
			NNCIBDMDEFE data = new NNCIBDMDEFE();
			data.MDLEEKBBEKD = array[i].PPFNGGCBJKC_id;
			data.PPEGAKEIEGM_Enabled = array[i].PLALNIIBLOF_en;
			data.EFNKCPBALOP_EffectId = array[i].FLLNHNJFIFL;
			data.NMELNJNFMJF_Start = array[i].PDBPFJJCADD_open_at;
			data.IAJAOIEOPDP_End = array[i].FDBNFFNFOND_close_at;
			data.PPEGAKEIEGM_Enabled = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, data.PPEGAKEIEGM_Enabled, 0);
			JDMCHNFAOFO.Add(data);
		}
		return true;
	}

	// // RVA: 0x1AE1BE8 Offset: 0x1AE1BE8 VA: 0x1AE1BE8 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// // RVA: 0x1AE1BF0 Offset: 0x1AE1BF0 VA: 0x1AE1BF0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "NDBFKHKMMCE_DecoItem.CAOGDCBPBAN");
		return 0;
	}

	// // RVA: 0x1AE2358 Offset: 0x1AE2358 VA: 0x1AE2358
	public int KDFMGDNOMHE(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, int NCLLKNJBEKI)
	{
		if(NCLLKNJBEKI > 0)
		{
			if(NCLLKNJBEKI <= KHCACDIKJLG_Characters.Count)
			{
				if(KHCACDIKJLG_Characters[NCLLKNJBEKI - 1].PLALNIIBLOF_en == 2)
				{
					JKNGJFOBADP j = new JKNGJFOBADP();
					int a = 0;
					for(int i = 0; i < KHCACDIKJLG_Characters[NCLLKNJBEKI - 1].KPIBEAHCGOB.Length; i++)
					{
						if(KHCACDIKJLG_Characters[NCLLKNJBEKI - 1].KPIBEAHCGOB[i].DNJEJEANJGL_Value > 0)
						{
							IHFIAFDLAAK_DecoStamp.MFHKPMPJGHC dbStamp = _LKMHPJKIFDN_md.GAPONCJOKAC_DecoStamp.FHBIIONKIDI_Stamps[KHCACDIKJLG_Characters[NCLLKNJBEKI - 1].KPIBEAHCGOB[i].DNJEJEANJGL_Value - 1];
							if(dbStamp.PLALNIIBLOF_en == 2)
							{
								//EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara, dbStamp.PPFNGGCBJKC_id);
								int num = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, EKLNMHFCAOI.FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara, dbStamp.PPFNGGCBJKC_id, null);
								if(num == 0)
								{
									EKLNMHFCAOI.DPHGFMEPOCA_SetNumItems(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, EKLNMHFCAOI.FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara, dbStamp.PPFNGGCBJKC_id, 1, null);
									j.NGEPPDAOIBN(EKLNMHFCAOI.FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara, dbStamp.PPFNGGCBJKC_id, 1, 1, dbStamp.EKLIPGELKCL_Rarity);
									a++;
								}
							}
						}
					}
					return a;
				}
			}
		}
		return 0;
	}

	// // RVA: 0x1AE2738 Offset: 0x1AE2738 VA: 0x1AE2738
	public int CHMNDNFMAGA(int _BIEGNEGKLDE_SpItemId)
	{
		if (_BIEGNEGKLDE_SpItemId > 0 && _BIEGNEGKLDE_SpItemId <= GMONECJCJFK_Sp.Count)
		{
			if (GMONECJCJFK_Sp[_BIEGNEGKLDE_SpItemId - 1].GBJFNGCDKPM_typ == 12)
				return GMONECJCJFK_Sp[_BIEGNEGKLDE_SpItemId - 1].IJEKNCDIIAE_mver;
		}
		return -1;
	}
}
