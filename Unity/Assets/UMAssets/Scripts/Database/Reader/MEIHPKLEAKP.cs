using FlatBuffers;
using System.Collections.Generic;

public class CFNMIJDKIJH
{
	public int[] BCGKLONODHO { get; set; } // 0x8 EJKADCKMMCN KAINPELLHFF_get_ EJPIFOFOINA_set_
	public int[] KPBJHHHMOJE_Time { get; set; } // 0xC DDMBHIBNJIF NNBONJFLKFM_get_Time FIOMMOICJLL_set_Time
	public int[] JBGEEPFKIGG_val { get; set; } // 0x10 AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class OLDDMCHLPEB
{
	public int[] JPMAHJJMMIA { get; set; } // 0x8 IEIHIPLOPPP EEIHPMNJMKG_get_ MGAEEIHCOAL_set_
	public int[] HMFFHLPNMPH_count { get; set; } // 0xC NKBFANLDLIL NJOGDDPICKG_get_count NBBGMMBICNA_set_count
}
public class MEIHPKLEAKP
{
	public CFNMIJDKIJH[] DJOIJIADLCC { get; set; } // 0x8 JCPMCEPGJKD DAHJLCAKBDK_get_ CFOALBJFGGN_set_
	public OLDDMCHLPEB[] NLPDKFCOPNB { get; set; } // 0xC FIPBANFOKPG MMPHCGFMOJD_get_ OCMBDBGBGMB_set_
	public static MEIHPKLEAKP HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x1311638
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		NCJELDIPMGO res_readData_ = NCJELDIPMGO.GetRootAsNCJELDIPMGO(buffer);
		MEIHPKLEAKP res_data_ = new MEIHPKLEAKP();

		List<CFNMIJDKIJH> DJOIJIADLCC_list_ = new List<CFNMIJDKIJH>();
		for(int DJOIJIADLCC_idx_ = 0; DJOIJIADLCC_idx_ < res_readData_.DLBEPCGINEOLength; DJOIJIADLCC_idx_++)
		{
			ENFPBAMFLPL DJOIJIADLCC_readData_ = res_readData_.GetDLBEPCGINEO(DJOIJIADLCC_idx_);
			CFNMIJDKIJH DJOIJIADLCC_data_ = new CFNMIJDKIJH();

			List<int> BCGKLONODHO_list_ = new List<int>();
			for(int BCGKLONODHO_idx_ = 0; BCGKLONODHO_idx_ < DJOIJIADLCC_readData_.BJOOKJIOGHFLength; BCGKLONODHO_idx_++)
			{
				BCGKLONODHO_list_.Add(DJOIJIADLCC_readData_.GetBJOOKJIOGHF(BCGKLONODHO_idx_));
			}
			DJOIJIADLCC_data_.BCGKLONODHO = BCGKLONODHO_list_.ToArray();

			List<int> KPBJHHHMOJE_list_ = new List<int>();
			for(int KPBJHHHMOJE_idx_ = 0; KPBJHHHMOJE_idx_ < DJOIJIADLCC_readData_.AKKGNHMOBPPLength; KPBJHHHMOJE_idx_++)
			{
				KPBJHHHMOJE_list_.Add(DJOIJIADLCC_readData_.GetAKKGNHMOBPP(KPBJHHHMOJE_idx_));
			}
			DJOIJIADLCC_data_.KPBJHHHMOJE_Time = KPBJHHHMOJE_list_.ToArray();

			List<int> JBGEEPFKIGG_list_ = new List<int>();
			for(int JBGEEPFKIGG_idx_ = 0; JBGEEPFKIGG_idx_ < DJOIJIADLCC_readData_.CGKGLCKCAMCLength; JBGEEPFKIGG_idx_++)
			{
				JBGEEPFKIGG_list_.Add(DJOIJIADLCC_readData_.GetCGKGLCKCAMC(JBGEEPFKIGG_idx_));
			}
			DJOIJIADLCC_data_.JBGEEPFKIGG_val = JBGEEPFKIGG_list_.ToArray();

			DJOIJIADLCC_list_.Add(DJOIJIADLCC_data_);
		}
		res_data_.DJOIJIADLCC = DJOIJIADLCC_list_.ToArray();

		List<OLDDMCHLPEB> NLPDKFCOPNB_list_ = new List<OLDDMCHLPEB>();
		for(int NLPDKFCOPNB_idx_ = 0; NLPDKFCOPNB_idx_ < res_readData_.IOCIMBDOMFILength; NLPDKFCOPNB_idx_++)
		{
			HGLIPFFGBBC NLPDKFCOPNB_readData_ = res_readData_.GetIOCIMBDOMFI(NLPDKFCOPNB_idx_);
			OLDDMCHLPEB NLPDKFCOPNB_data_ = new OLDDMCHLPEB();

			List<int> JPMAHJJMMIA_list_ = new List<int>();
			for(int JPMAHJJMMIA_idx_ = 0; JPMAHJJMMIA_idx_ < NLPDKFCOPNB_readData_.CKBNFBPHJEALength; JPMAHJJMMIA_idx_++)
			{
				JPMAHJJMMIA_list_.Add(NLPDKFCOPNB_readData_.GetCKBNFBPHJEA(JPMAHJJMMIA_idx_));
			}
			NLPDKFCOPNB_data_.JPMAHJJMMIA = JPMAHJJMMIA_list_.ToArray();

			List<int> HMFFHLPNMPH_list_ = new List<int>();
			for(int HMFFHLPNMPH_idx_ = 0; HMFFHLPNMPH_idx_ < NLPDKFCOPNB_readData_.IKNICGHGHNMLength; HMFFHLPNMPH_idx_++)
			{
				HMFFHLPNMPH_list_.Add(NLPDKFCOPNB_readData_.GetIKNICGHGHNM(HMFFHLPNMPH_idx_));
			}
			NLPDKFCOPNB_data_.HMFFHLPNMPH_count = HMFFHLPNMPH_list_.ToArray();

			NLPDKFCOPNB_list_.Add(NLPDKFCOPNB_data_);
		}
		res_data_.NLPDKFCOPNB = NLPDKFCOPNB_list_.ToArray();

		return res_data_;
	}
}
