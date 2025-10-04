using FlatBuffers;
using System.Collections.Generic;

public class PLCJIGFCOIK
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public string OPFGFINHFCE_name { get; set; } // 0xC LGIIAPHCLPN DKJOHDGOIJE_get_name MJAMIGECMMF_set_name
	public int CPGFOBNKKBF_CurrencyId { get; set; } // 0x10 CIAEKFDKLJB AMNKHCIJHJD_get_CurrencyId INJMDACNFOL_set_CurrencyId
	public string PFAOBLDNMGF { get; set; } // 0x14 DFHKMMADKJK EGIONHIJBIJ_get_ OBIJPLJHIIM_set_
	public string PDHGIGPAEBG { get; set; } // 0x18 HCBCLJEGFKJ JEDAGPENDIG_get_ HPDKOCKJHPK_set_
	public int BFINGCJHOHI_cnt { get; set; } // 0x1C PIAHJAJPLKA LFMCLIDAPHB_get_cnt EDAEPDGGFJJ_set_cnt
	public int GBJFNGCDKPM_typ { get; set; } // 0x20 GHLFADHILNN CEJJMKODOGK_get_typ HOHCEBMMACI_set_typ
	public int PDBPFJJCADD_open_at { get; set; } // 0x24 PMJMBGBCIGO FOACOMBHPAC_get_open_at NBACOBCOJCA_set_open_at
	public int EGBOHDFBAPB_closed_at { get; set; } // 0x28 DDNBDNJHAIB MGOEKKJNOLF_get_closed_at NHPFDCAFAFF_set_closed_at
	public int HPGNBPIBAOM_IsBeginner { get; set; } // 0x2C BMEHEHGDBEL CNGGNJIILPC_get_IsBeginner KINBLEJIELP_set_IsBeginner
	public int AFHPLBPHEGA { get; set; } // 0x30 MEPFNKKKPHP INHKANPGKOO_get_ MJDENHCKCOE_set_
	public int HEOLEHDFLJO_ico { get; set; } // 0x34 EALEFNJMEPK OICOCHBFNAK_get_ico HGLFJJHECGH_set_ico
	public string KLMPFGOCBHC_description { get; set; } // 0x38 MODIAAEGMCJ BGJNIABLBDB_get_description HFBJLALGKOM_set_description
	public int DLCGAMHADEN_Label { get; set; } // 0x3C ANDDAFHKOPK BNGHEBJEOPL_get_Label PBMMAJFCPJL_set_Label
	public int[] KGOFMDMDFCJ_BonusId { get; set; } // 0x40 DODJFJLJPIE NPEIPAKLPPG_get_BonusId CCMIKCFIDEM_set_BonusId
	public int[] NNIIINKFDBG_BonusCount { get; set; } // 0x44 BGNHEGBJBFI JJCMDBOMGGE_get_BonusCount BEJCKOIHNPK_set_BonusCount
	public int IHCLFMKAJND { get; set; } // 0x48 HHENDIIFCBD MJKPAAFNENM_get_ LNMLLJLJFKN_set_
	public int EILKGEADKGH_Order { get; set; } // 0x4C PBIPJHCABED NPDDACIHBKD_get_Order BJJMCKHBPNH_set_Order
}
public class EGHGEIALECF
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int PLALNIIBLOF_en { get; set; } // 0xC DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public string FEMMDNIELFC_Desc { get; set; } // 0x10 GDKPKLJELJK JDHDMBHNKJD_get_Desc FNAJEJLLJOE_set_Desc
	public int PDBPFJJCADD_open_at { get; set; } // 0x14 PMJMBGBCIGO FOACOMBHPAC_get_open_at NBACOBCOJCA_set_open_at
	public int EGBOHDFBAPB_closed_at { get; set; } // 0x18 DDNBDNJHAIB MGOEKKJNOLF_get_closed_at NHPFDCAFAFF_set_closed_at
	public int KAPMOPMDHJE_label { get; set; } // 0x1C EJDCHACDMPH MONBNPKLFGC_get_label KGFFKEDNIID_set_label
}
public class MDFCHKPOMAJ
{
	public PLCJIGFCOIK[] GKBBBINCAGN { get; set; } // 0x8 FPAGOGOKEJK LNIEKMGPGDO_get_ FPJMNEDPCHG_set_
	public EGHGEIALECF[] CMFJFBJHKPE { get; set; } // 0xC NBFPEPPMNGF KMCBNOABKEC_get_ JLJEGLHIHHK_set_
	public static MDFCHKPOMAJ HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x130F5FC
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		LBAGNFKGHIB res_readData_ = LBAGNFKGHIB.GetRootAsLBAGNFKGHIB(buffer);
		MDFCHKPOMAJ res_data_ = new MDFCHKPOMAJ();

		List<PLCJIGFCOIK> GKBBBINCAGN_list_ = new List<PLCJIGFCOIK>();
		for(int GKBBBINCAGN_idx_ = 0; GKBBBINCAGN_idx_ < res_readData_.CNOBKOPJGPLLength; GKBBBINCAGN_idx_++)
		{
			AAHHDFJLDIO GKBBBINCAGN_readData_ = res_readData_.GetCNOBKOPJGPL(GKBBBINCAGN_idx_);
			PLCJIGFCOIK GKBBBINCAGN_data_ = new PLCJIGFCOIK();

			GKBBBINCAGN_data_.PPFNGGCBJKC_id = GKBBBINCAGN_readData_.BBPHAPFBFHK/*_id*/;
			GKBBBINCAGN_data_.OPFGFINHFCE_name = GKBBBINCAGN_readData_.IIDCFMHCPLJ/*_name*/;
			GKBBBINCAGN_data_.CPGFOBNKKBF_CurrencyId = GKBBBINCAGN_readData_.DKMLEDJJFOI/*_CurrencyId*/;
			GKBBBINCAGN_data_.PFAOBLDNMGF = GKBBBINCAGN_readData_.GHHPIICJHDB;
			GKBBBINCAGN_data_.PDHGIGPAEBG = GKBBBINCAGN_readData_.IJKHPPCHPGK;
			GKBBBINCAGN_data_.BFINGCJHOHI_cnt = GKBBBINCAGN_readData_.CLEEFGNMCEL/*_cnt*/;
			GKBBBINCAGN_data_.GBJFNGCDKPM_typ = GKBBBINCAGN_readData_.LPJPOOHJKAE/*_typ*/;
			GKBBBINCAGN_data_.PDBPFJJCADD_open_at = GKBBBINCAGN_readData_.NJLJEKDBPCH/*_open_at*/;
			GKBBBINCAGN_data_.EGBOHDFBAPB_closed_at = GKBBBINCAGN_readData_.IPHMJNCEPIJ/*_closed_at*/;
			GKBBBINCAGN_data_.HPGNBPIBAOM_IsBeginner = GKBBBINCAGN_readData_.JBAHJKKJPEG/*_IsBeginner*/;
			GKBBBINCAGN_data_.AFHPLBPHEGA = GKBBBINCAGN_readData_.OIMEOBNAAHH;
			GKBBBINCAGN_data_.HEOLEHDFLJO_ico = GKBBBINCAGN_readData_.EOHDEKFEONI/*_ico*/;
			GKBBBINCAGN_data_.KLMPFGOCBHC_description = GKBBBINCAGN_readData_.LCMOIMEFAHI/*_description*/;
			GKBBBINCAGN_data_.DLCGAMHADEN_Label = GKBBBINCAGN_readData_.PELKLPGCMFN/*_Label*/;
			List<int> KGOFMDMDFCJ_list_ = new List<int>();
			for(int KGOFMDMDFCJ_idx_ = 0; KGOFMDMDFCJ_idx_ < GKBBBINCAGN_readData_.IDKJOALBKAALength; KGOFMDMDFCJ_idx_++)
			{
				KGOFMDMDFCJ_list_.Add(GKBBBINCAGN_readData_.GetIDKJOALBKAA(KGOFMDMDFCJ_idx_));
			}
			GKBBBINCAGN_data_.KGOFMDMDFCJ_BonusId = KGOFMDMDFCJ_list_.ToArray();

			List<int> NNIIINKFDBG_list_ = new List<int>();
			for(int NNIIINKFDBG_idx_ = 0; NNIIINKFDBG_idx_ < GKBBBINCAGN_readData_.AFDJJJOJBMOLength; NNIIINKFDBG_idx_++)
			{
				NNIIINKFDBG_list_.Add(GKBBBINCAGN_readData_.GetAFDJJJOJBMO(NNIIINKFDBG_idx_));
			}
			GKBBBINCAGN_data_.NNIIINKFDBG_BonusCount = NNIIINKFDBG_list_.ToArray();

			GKBBBINCAGN_data_.IHCLFMKAJND = GKBBBINCAGN_readData_.MCPMLMHKKOP;
			GKBBBINCAGN_data_.EILKGEADKGH_Order = GKBBBINCAGN_readData_.BPMBFFDNMDD/*_Order*/;
			GKBBBINCAGN_list_.Add(GKBBBINCAGN_data_);
		}
		res_data_.GKBBBINCAGN = GKBBBINCAGN_list_.ToArray();

		List<EGHGEIALECF> CMFJFBJHKPE_list_ = new List<EGHGEIALECF>();
		for(int CMFJFBJHKPE_idx_ = 0; CMFJFBJHKPE_idx_ < res_readData_.MDOIDBIGFJILength; CMFJFBJHKPE_idx_++)
		{
			LFDPEDHPEKC CMFJFBJHKPE_readData_ = res_readData_.GetMDOIDBIGFJI(CMFJFBJHKPE_idx_);
			EGHGEIALECF CMFJFBJHKPE_data_ = new EGHGEIALECF();

			CMFJFBJHKPE_data_.PPFNGGCBJKC_id = CMFJFBJHKPE_readData_.BBPHAPFBFHK/*_id*/;
			CMFJFBJHKPE_data_.PLALNIIBLOF_en = CMFJFBJHKPE_readData_.CFLMCGOJJJD/*_en*/;
			CMFJFBJHKPE_data_.FEMMDNIELFC_Desc = CMFJFBJHKPE_readData_.NNKLANONDOM/*_Desc*/;
			CMFJFBJHKPE_data_.PDBPFJJCADD_open_at = CMFJFBJHKPE_readData_.NJLJEKDBPCH/*_open_at*/;
			CMFJFBJHKPE_data_.EGBOHDFBAPB_closed_at = CMFJFBJHKPE_readData_.IPHMJNCEPIJ/*_closed_at*/;
			CMFJFBJHKPE_data_.KAPMOPMDHJE_label = CMFJFBJHKPE_readData_.BNFLNMGOJCM/*_label*/;
			CMFJFBJHKPE_list_.Add(CMFJFBJHKPE_data_);
		}
		res_data_.CMFJFBJHKPE = CMFJFBJHKPE_list_.ToArray();

		return res_data_;
	}
}
