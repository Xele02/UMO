using FlatBuffers;
using System.Collections.Generic;

public class COGPJCIDIKA
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint FBFLDFMFFOH_rar { get; set; } // 0xC LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
	public uint JBGEEPFKIGG_val { get; set; } // 0x10 AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
	public uint GBJFNGCDKPM_typ { get; set; } // 0x14 GHLFADHILNN CEJJMKODOGK_get_typ HOHCEBMMACI_set_typ
}
public class OOFJBDCPKBJ
{
	public COGPJCIDIKA[] LMNJDPMHNLB { get; set; } // 0x8 KKMMFCHFCME OIJNIAFGIJA_get_ NEMCLJHANIO_set_
	public static OOFJBDCPKBJ HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xCB02B0
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		DOLNHKKDNCC res_readData_ = DOLNHKKDNCC.GetRootAsDOLNHKKDNCC(buffer);
		OOFJBDCPKBJ res_data_ = new OOFJBDCPKBJ();

		List<COGPJCIDIKA> LMNJDPMHNLB_list_ = new List<COGPJCIDIKA>();
		for(int LMNJDPMHNLB_idx_ = 0; LMNJDPMHNLB_idx_ < res_readData_.FPOHCPNHGMNLength; LMNJDPMHNLB_idx_++)
		{
			KKJKDONIHBM LMNJDPMHNLB_readData_ = res_readData_.GetFPOHCPNHGMN(LMNJDPMHNLB_idx_);
			COGPJCIDIKA LMNJDPMHNLB_data_ = new COGPJCIDIKA();

			LMNJDPMHNLB_data_.PPFNGGCBJKC_id = LMNJDPMHNLB_readData_.BBPHAPFBFHK/*_id*/;
			LMNJDPMHNLB_data_.FBFLDFMFFOH_rar = LMNJDPMHNLB_readData_.ODBPKGJPLMD/*_rar*/;
			LMNJDPMHNLB_data_.JBGEEPFKIGG_val = LMNJDPMHNLB_readData_.KJFEBMBHKOC/*_val*/;
			LMNJDPMHNLB_data_.GBJFNGCDKPM_typ = LMNJDPMHNLB_readData_.LPJPOOHJKAE/*_typ*/;
			LMNJDPMHNLB_list_.Add(LMNJDPMHNLB_data_);
		}
		res_data_.LMNJDPMHNLB = LMNJDPMHNLB_list_.ToArray();

		return res_data_;
	}
}
