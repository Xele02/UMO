using FlatBuffers;
using System.Collections.Generic;

public class MPEFMPPMBGM
{
	public uint GLCLFMGPMAN_ItemId { get; set; } // 0x8 KCELNMGLKHH LNJAENEGDEL_get_ItemId JHIDBGCHOKL_set_ItemId
	public int FPLEBCKDCBE_pos_x { get; set; } // 0xC BJHAJOOCEPM GMAGDACFGJF_get_pos_x BNOJHOABBFC_set_pos_x
	public int MDLMHEDHPHA_pos_y { get; set; } // 0x10 NIBANBEBJBP HBELOEOGKNM_get_pos_y APHNMFBNLBJ_set_pos_y
	public uint NEGMFBPNJGK_rvs { get; set; } // 0x14 EKOPFGHKAEB AGBGLCMJIIL_get_rvs PDPBJNLLAID_set_rvs
	public uint DAPGDCPDCNA_Prio { get; set; } // 0x18 AIEPLCMPKAN GFAHOLGECII_get_Prio KJKCIHEDEBB_set_Prio
	public uint BEJGNPAAKNB_word { get; set; } // 0x1C MNDBPPIDDEG PPHPHCADCLJ_get_word BPMLEPPPCKP_set_word
	public uint OPAHFDJPFJO_placing { get; set; } // 0x20 EIPKOACLOPK AFIMAHKLGJH_get_placing OELIAPKHFKE_set_placing
}
public class FFHDKFPLLEN
{
	public MPEFMPPMBGM[] HMPJFEFCGHI { get; set; } // 0x8 JDFLNCKOEIJ JIJDJPPJJKH_get_ PECPJANFJCM_set_
	public static FFHDKFPLLEN HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x14DC914
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		OJJJPOGDHKM res_readData_ = OJJJPOGDHKM.GetRootAsOJJJPOGDHKM(buffer);
		FFHDKFPLLEN res_data_ = new FFHDKFPLLEN();

		List<MPEFMPPMBGM> HMPJFEFCGHI_list_ = new List<MPEFMPPMBGM>();
		for(int HMPJFEFCGHI_idx_ = 0; HMPJFEFCGHI_idx_ < res_readData_.BKJJHPCJDMJLength; HMPJFEFCGHI_idx_++)
		{
			CJBNLNDKLKA HMPJFEFCGHI_readData_ = res_readData_.GetBKJJHPCJDMJ(HMPJFEFCGHI_idx_);
			MPEFMPPMBGM HMPJFEFCGHI_data_ = new MPEFMPPMBGM();

			HMPJFEFCGHI_data_.GLCLFMGPMAN_ItemId = HMPJFEFCGHI_readData_.MBBJMJAAODG/*_ItemId*/;
			HMPJFEFCGHI_data_.FPLEBCKDCBE_pos_x = HMPJFEFCGHI_readData_.CFCGMIMJKLE/*_pos_x*/;
			HMPJFEFCGHI_data_.MDLMHEDHPHA_pos_y = HMPJFEFCGHI_readData_.OFGPIPFIPKB/*_pos_y*/;
			HMPJFEFCGHI_data_.NEGMFBPNJGK_rvs = HMPJFEFCGHI_readData_.LHABMCKNLFG/*_rvs*/;
			HMPJFEFCGHI_data_.DAPGDCPDCNA_Prio = HMPJFEFCGHI_readData_.AIIPAPCLGGO/*_Prio*/;
			HMPJFEFCGHI_data_.BEJGNPAAKNB_word = HMPJFEFCGHI_readData_.ACHLKLEIOJJ/*_word*/;
			HMPJFEFCGHI_data_.OPAHFDJPFJO_placing = HMPJFEFCGHI_readData_.GGIDBEGABBO/*_placing*/;
			HMPJFEFCGHI_list_.Add(HMPJFEFCGHI_data_);
		}
		res_data_.HMPJFEFCGHI = HMPJFEFCGHI_list_.ToArray();

		return res_data_;
	}
}
