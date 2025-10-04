using FlatBuffers;
using System.Collections.Generic;

public class CBKLHFDMLFO
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint HEOLEHDFLJO_ico { get; set; } // 0xC EALEFNJMEPK OICOCHBFNAK_get_ico HGLFJJHECGH_set_ico
	public uint[] IFILLPEKJFK_ngi { get; set; } // 0x10 MHLFAGLLMGH LMFKMBOBFOG_get_ngi ENHLLDAKGJJ_set_ngi
	public uint GBJFNGCDKPM_typ { get; set; } // 0x14 GHLFADHILNN CEJJMKODOGK_get_typ HOHCEBMMACI_set_typ
	public uint ACGLMKEBMDL_uc { get; set; } // 0x18 EPENFLDKGJE ALOLFIJOOHG_get_uc JDPCOMJIMHG_set_uc
	public uint KMIDKGMIIBK_w { get; set; } // 0x1C EMKLEANANFF IJHDGOLKKDM_get_w KDBIHPAHGHA_set_w
	public uint[] BONFLFAPFDG { get; set; } // 0x20 HAFEFLMECIM ADMBEAAIBDL_get_ HLIHMAKBLMN_set_
}
public class AOGBEJNPKFB
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int[] CFMBELIAJIB_pl { get; set; } // 0xC MMJNKEGILKA AMOJHDKGHBP_get_pl CIHDINOPNEM_set_pl
	public int[] NJGNGFNKHAH_rd { get; set; } // 0x10 LEONGAPBFML LILBBEIJFHD_get_rd KIFDICGFJIE_set_rd
}
public class MNFBFBKBJLB
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int[] CFMBELIAJIB_pl { get; set; } // 0xC MMJNKEGILKA AMOJHDKGHBP_get_pl CIHDINOPNEM_set_pl
	public int[] NJGNGFNKHAH_rd { get; set; } // 0x10 LEONGAPBFML LILBBEIJFHD_get_rd KIFDICGFJIE_set_rd
}
public class BDEOFCEPFMN
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint PLALNIIBLOF_en { get; set; } // 0xC DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int IJEKNCDIIAE_mver { get; set; } // 0x10 FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public int ALMNMBDELDB_mlt { get; set; } // 0x14 PBNNMHBCMJH PMGKNCJIDIJ_get_mlt JCNDENOLLFK_set_mlt
	public int JBGEEPFKIGG_val { get; set; } // 0x18 AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
	public int[] JFJFMFNMPPF { get; set; } // 0x1C OIGALJDLLCA IKEJPGFHMOG_get_ CCEGLLNCOGM_set_
}
public class GGNFFEBIPON
{
	public CBKLHFDMLFO[] CNGFINPPJKG { get; set; } // 0x8 NKLPKADLGEJ AMHJPMPAGGI_get_ CICLCACKBBJ_set_
	public AOGBEJNPKFB[] EBMHHKNDDEN { get; set; } // 0xC EMKLLGFDNMG PDJCBBHHBIH_get_ HMPBEHHFEIH_set_
	public MNFBFBKBJLB[] EABCJPHDKDC { get; set; } // 0x10 MCLMFFDJOLF NGAEPBJIAPF_get_ GLIAKALDNJL_set_
	public BDEOFCEPFMN[] DBIEABIPELG { get; set; } // 0x14 BBNOMBNEHMC CFDIHDPGNJL_get_ FMLHAPHMCLB_set_
	public static GGNFFEBIPON HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xAA3590
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		ANBBEHKIHLJ res_readData_ = ANBBEHKIHLJ.GetRootAsANBBEHKIHLJ(buffer);
		GGNFFEBIPON res_data_ = new GGNFFEBIPON();

		List<CBKLHFDMLFO> CNGFINPPJKG_list_ = new List<CBKLHFDMLFO>();
		for(int CNGFINPPJKG_idx_ = 0; CNGFINPPJKG_idx_ < res_readData_.OAHBCGIOJFALength; CNGFINPPJKG_idx_++)
		{
			EDGCKDLNLNN CNGFINPPJKG_readData_ = res_readData_.GetOAHBCGIOJFA(CNGFINPPJKG_idx_);
			CBKLHFDMLFO CNGFINPPJKG_data_ = new CBKLHFDMLFO();

			CNGFINPPJKG_data_.PPFNGGCBJKC_id = CNGFINPPJKG_readData_.BBPHAPFBFHK/*_id*/;
			CNGFINPPJKG_data_.HEOLEHDFLJO_ico = CNGFINPPJKG_readData_.EOHDEKFEONI/*_ico*/;
			List<uint> IFILLPEKJFK_list_ = new List<uint>();
			for(int IFILLPEKJFK_idx_ = 0; IFILLPEKJFK_idx_ < CNGFINPPJKG_readData_.PLPNKMFFPLELength; IFILLPEKJFK_idx_++)
			{
				IFILLPEKJFK_list_.Add(CNGFINPPJKG_readData_.GetPLPNKMFFPLE(IFILLPEKJFK_idx_));
			}
			CNGFINPPJKG_data_.IFILLPEKJFK_ngi = IFILLPEKJFK_list_.ToArray();

			CNGFINPPJKG_data_.GBJFNGCDKPM_typ = CNGFINPPJKG_readData_.LPJPOOHJKAE/*_typ*/;
			CNGFINPPJKG_data_.ACGLMKEBMDL_uc = CNGFINPPJKG_readData_.PAEGHLMNPNO/*_uc*/;
			CNGFINPPJKG_data_.KMIDKGMIIBK_w = CNGFINPPJKG_readData_.OPOLOJINLPI/*_w*/;
			List<uint> BONFLFAPFDG_list_ = new List<uint>();
			for(int BONFLFAPFDG_idx_ = 0; BONFLFAPFDG_idx_ < CNGFINPPJKG_readData_.NMKAIHMOFNALength; BONFLFAPFDG_idx_++)
			{
				BONFLFAPFDG_list_.Add(CNGFINPPJKG_readData_.GetNMKAIHMOFNA(BONFLFAPFDG_idx_));
			}
			CNGFINPPJKG_data_.BONFLFAPFDG = BONFLFAPFDG_list_.ToArray();

			CNGFINPPJKG_list_.Add(CNGFINPPJKG_data_);
		}
		res_data_.CNGFINPPJKG = CNGFINPPJKG_list_.ToArray();

		List<AOGBEJNPKFB> EBMHHKNDDEN_list_ = new List<AOGBEJNPKFB>();
		for(int EBMHHKNDDEN_idx_ = 0; EBMHHKNDDEN_idx_ < res_readData_.KOMCNJPMIHCLength; EBMHHKNDDEN_idx_++)
		{
			LLGJODEDLOA EBMHHKNDDEN_readData_ = res_readData_.GetKOMCNJPMIHC(EBMHHKNDDEN_idx_);
			AOGBEJNPKFB EBMHHKNDDEN_data_ = new AOGBEJNPKFB();

			EBMHHKNDDEN_data_.PPFNGGCBJKC_id = EBMHHKNDDEN_readData_.BBPHAPFBFHK/*_id*/;
			List<int> CFMBELIAJIB_list_ = new List<int>();
			for(int CFMBELIAJIB_idx_ = 0; CFMBELIAJIB_idx_ < EBMHHKNDDEN_readData_.GAGNCJEKOLLLength; CFMBELIAJIB_idx_++)
			{
				CFMBELIAJIB_list_.Add(EBMHHKNDDEN_readData_.GetGAGNCJEKOLL(CFMBELIAJIB_idx_));
			}
			EBMHHKNDDEN_data_.CFMBELIAJIB_pl = CFMBELIAJIB_list_.ToArray();

			List<int> NJGNGFNKHAH_list_ = new List<int>();
			for(int NJGNGFNKHAH_idx_ = 0; NJGNGFNKHAH_idx_ < EBMHHKNDDEN_readData_.GPCCCOAHKAELength; NJGNGFNKHAH_idx_++)
			{
				NJGNGFNKHAH_list_.Add(EBMHHKNDDEN_readData_.GetGPCCCOAHKAE(NJGNGFNKHAH_idx_));
			}
			EBMHHKNDDEN_data_.NJGNGFNKHAH_rd = NJGNGFNKHAH_list_.ToArray();

			EBMHHKNDDEN_list_.Add(EBMHHKNDDEN_data_);
		}
		res_data_.EBMHHKNDDEN = EBMHHKNDDEN_list_.ToArray();

		List<MNFBFBKBJLB> EABCJPHDKDC_list_ = new List<MNFBFBKBJLB>();
		for(int EABCJPHDKDC_idx_ = 0; EABCJPHDKDC_idx_ < res_readData_.LCPGFAHAGPLLength; EABCJPHDKDC_idx_++)
		{
			DJABNGNLIHM EABCJPHDKDC_readData_ = res_readData_.GetLCPGFAHAGPL(EABCJPHDKDC_idx_);
			MNFBFBKBJLB EABCJPHDKDC_data_ = new MNFBFBKBJLB();

			EABCJPHDKDC_data_.PPFNGGCBJKC_id = EABCJPHDKDC_readData_.BBPHAPFBFHK/*_id*/;
			List<int> CFMBELIAJIB_list_ = new List<int>();
			for(int CFMBELIAJIB_idx_ = 0; CFMBELIAJIB_idx_ < EABCJPHDKDC_readData_.GAGNCJEKOLLLength; CFMBELIAJIB_idx_++)
			{
				CFMBELIAJIB_list_.Add(EABCJPHDKDC_readData_.GetGAGNCJEKOLL(CFMBELIAJIB_idx_));
			}
			EABCJPHDKDC_data_.CFMBELIAJIB_pl = CFMBELIAJIB_list_.ToArray();

			List<int> NJGNGFNKHAH_list_ = new List<int>();
			for(int NJGNGFNKHAH_idx_ = 0; NJGNGFNKHAH_idx_ < EABCJPHDKDC_readData_.GPCCCOAHKAELength; NJGNGFNKHAH_idx_++)
			{
				NJGNGFNKHAH_list_.Add(EABCJPHDKDC_readData_.GetGPCCCOAHKAE(NJGNGFNKHAH_idx_));
			}
			EABCJPHDKDC_data_.NJGNGFNKHAH_rd = NJGNGFNKHAH_list_.ToArray();

			EABCJPHDKDC_list_.Add(EABCJPHDKDC_data_);
		}
		res_data_.EABCJPHDKDC = EABCJPHDKDC_list_.ToArray();

		List<BDEOFCEPFMN> DBIEABIPELG_list_ = new List<BDEOFCEPFMN>();
		for(int DBIEABIPELG_idx_ = 0; DBIEABIPELG_idx_ < res_readData_.HIHGBEKDKOLLength; DBIEABIPELG_idx_++)
		{
			OHCNALAONKF DBIEABIPELG_readData_ = res_readData_.GetHIHGBEKDKOL(DBIEABIPELG_idx_);
			BDEOFCEPFMN DBIEABIPELG_data_ = new BDEOFCEPFMN();

			DBIEABIPELG_data_.PPFNGGCBJKC_id = DBIEABIPELG_readData_.BBPHAPFBFHK/*_id*/;
			DBIEABIPELG_data_.PLALNIIBLOF_en = DBIEABIPELG_readData_.CFLMCGOJJJD/*_en*/;
			DBIEABIPELG_data_.IJEKNCDIIAE_mver = DBIEABIPELG_readData_.OFMGALJGDAO/*_mver*/;
			DBIEABIPELG_data_.ALMNMBDELDB_mlt = DBIEABIPELG_readData_.OFELCGCIOFJ/*_mlt*/;
			DBIEABIPELG_data_.JBGEEPFKIGG_val = DBIEABIPELG_readData_.KJFEBMBHKOC/*_val*/;
			List<int> JFJFMFNMPPF_list_ = new List<int>();
			for(int JFJFMFNMPPF_idx_ = 0; JFJFMFNMPPF_idx_ < DBIEABIPELG_readData_.DAIPOIOKCAALength; JFJFMFNMPPF_idx_++)
			{
				JFJFMFNMPPF_list_.Add(DBIEABIPELG_readData_.GetDAIPOIOKCAA(JFJFMFNMPPF_idx_));
			}
			DBIEABIPELG_data_.JFJFMFNMPPF = JFJFMFNMPPF_list_.ToArray();

			DBIEABIPELG_list_.Add(DBIEABIPELG_data_);
		}
		res_data_.DBIEABIPELG = DBIEABIPELG_list_.ToArray();

		return res_data_;
	}
}
