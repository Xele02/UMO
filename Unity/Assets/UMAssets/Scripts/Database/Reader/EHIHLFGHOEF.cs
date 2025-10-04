using FlatBuffers;
using System.Collections.Generic;

public class COBIMANANGK
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint FBFLDFMFFOH_rar { get; set; } // 0xC LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
	public uint JBGEEPFKIGG_val { get; set; } // 0x10 AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class EHIHLFGHOEF
{
	public COBIMANANGK[] AJJAKJEMCID { get; set; } // 0x8 MIHGHOPDLGP KHOGMDCLGBK_get_ OOLKGHLPFBB_set_
	public static EHIHLFGHOEF HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x12EA1E4
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		CBOPKMNJJIA res_readData_ = CBOPKMNJJIA.GetRootAsCBOPKMNJJIA(buffer);
		EHIHLFGHOEF res_data_ = new EHIHLFGHOEF();

		List<COBIMANANGK> AJJAKJEMCID_list_ = new List<COBIMANANGK>();
		for(int AJJAKJEMCID_idx_ = 0; AJJAKJEMCID_idx_ < res_readData_.HBPDIEOICJPLength; AJJAKJEMCID_idx_++)
		{
			CECBEDHLMBM AJJAKJEMCID_readData_ = res_readData_.GetHBPDIEOICJP(AJJAKJEMCID_idx_);
			COBIMANANGK AJJAKJEMCID_data_ = new COBIMANANGK();

			AJJAKJEMCID_data_.PPFNGGCBJKC_id = AJJAKJEMCID_readData_.BBPHAPFBFHK/*_id*/;
			AJJAKJEMCID_data_.FBFLDFMFFOH_rar = AJJAKJEMCID_readData_.ODBPKGJPLMD/*_rar*/;
			AJJAKJEMCID_data_.JBGEEPFKIGG_val = AJJAKJEMCID_readData_.KJFEBMBHKOC/*_val*/;
			AJJAKJEMCID_list_.Add(AJJAKJEMCID_data_);
		}
		res_data_.AJJAKJEMCID = AJJAKJEMCID_list_.ToArray();

		return res_data_;
	}
}
