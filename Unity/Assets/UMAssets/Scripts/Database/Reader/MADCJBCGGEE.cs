using FlatBuffers;
using System.Collections.Generic;

public class FLNGBOANAGE
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint FBFLDFMFFOH_rar { get; set; } // 0xC LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
	public uint JBGEEPFKIGG_val { get; set; } // 0x10 AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
	public int FDBOPFEOENF_diva { get; set; } // 0x14 DNDMMJJOAOE MJPHCAIKKJG_get_diva GHECGDMEBFF_set_diva
	public int GBJFNGCDKPM_typ { get; set; } // 0x18 GHLFADHILNN CEJJMKODOGK_get_typ HOHCEBMMACI_set_typ
}
public class MADCJBCGGEE
{
	public FLNGBOANAGE[] GKNGIIHMBOD { get; set; } // 0x8 EMEIPPBCELJ PPDIJNPGCHB_get_ AHEPMHLJGHO_set_
	public static MADCJBCGGEE HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xA13E40
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		OOKJGIANFNP res_readData_ = OOKJGIANFNP.GetRootAsOOKJGIANFNP(buffer);
		MADCJBCGGEE res_data_ = new MADCJBCGGEE();

		List<FLNGBOANAGE> GKNGIIHMBOD_list_ = new List<FLNGBOANAGE>();
		for(int GKNGIIHMBOD_idx_ = 0; GKNGIIHMBOD_idx_ < res_readData_.LJOPIBIJHNALength; GKNGIIHMBOD_idx_++)
		{
			LLGKOAFFEJF GKNGIIHMBOD_readData_ = res_readData_.GetLJOPIBIJHNA(GKNGIIHMBOD_idx_);
			FLNGBOANAGE GKNGIIHMBOD_data_ = new FLNGBOANAGE();

			GKNGIIHMBOD_data_.PPFNGGCBJKC_id = GKNGIIHMBOD_readData_.BBPHAPFBFHK/*_id*/;
			GKNGIIHMBOD_data_.FBFLDFMFFOH_rar = GKNGIIHMBOD_readData_.ODBPKGJPLMD/*_rar*/;
			GKNGIIHMBOD_data_.JBGEEPFKIGG_val = GKNGIIHMBOD_readData_.KJFEBMBHKOC/*_val*/;
			GKNGIIHMBOD_data_.FDBOPFEOENF_diva = GKNGIIHMBOD_readData_.PIFAMBCEMKL/*_diva*/;
			GKNGIIHMBOD_data_.GBJFNGCDKPM_typ = GKNGIIHMBOD_readData_.LPJPOOHJKAE/*_typ*/;
			GKNGIIHMBOD_list_.Add(GKNGIIHMBOD_data_);
		}
		res_data_.GKNGIIHMBOD = GKNGIIHMBOD_list_.ToArray();

		return res_data_;
	}
}
