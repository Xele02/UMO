using FlatBuffers;
using System.Collections.Generic;

public class EIIBKGHEGFI
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint FBFLDFMFFOH_rar { get; set; } // 0xC LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
	public uint JBGEEPFKIGG_val { get; set; } // 0x10 AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
	public uint GBJFNGCDKPM_typ { get; set; } // 0x14 GHLFADHILNN CEJJMKODOGK_get_typ HOHCEBMMACI_set_typ
}
public class BELBAJBINBO
{
	public EIIBKGHEGFI[] GMDKFCMGHIK { get; set; } // 0x8 POMGFCIPGKL EMAGPNNLPGJ_get_ FJEPAPLAIDL_set_
	public static BELBAJBINBO HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xC75CF8
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		AIAGNLHOHPF res_readData_ = AIAGNLHOHPF.GetRootAsAIAGNLHOHPF(buffer);
		BELBAJBINBO res_data_ = new BELBAJBINBO();

		List<EIIBKGHEGFI> GMDKFCMGHIK_list_ = new List<EIIBKGHEGFI>();
		for(int GMDKFCMGHIK_idx_ = 0; GMDKFCMGHIK_idx_ < res_readData_.KDNNKLCMJCELength; GMDKFCMGHIK_idx_++)
		{
			MKPHLDNDLDL GMDKFCMGHIK_readData_ = res_readData_.GetKDNNKLCMJCE(GMDKFCMGHIK_idx_);
			EIIBKGHEGFI GMDKFCMGHIK_data_ = new EIIBKGHEGFI();

			GMDKFCMGHIK_data_.PPFNGGCBJKC_id = GMDKFCMGHIK_readData_.BBPHAPFBFHK/*_id*/;
			GMDKFCMGHIK_data_.FBFLDFMFFOH_rar = GMDKFCMGHIK_readData_.ODBPKGJPLMD/*_rar*/;
			GMDKFCMGHIK_data_.JBGEEPFKIGG_val = GMDKFCMGHIK_readData_.KJFEBMBHKOC/*_val*/;
			GMDKFCMGHIK_data_.GBJFNGCDKPM_typ = GMDKFCMGHIK_readData_.LPJPOOHJKAE/*_typ*/;
			GMDKFCMGHIK_list_.Add(GMDKFCMGHIK_data_);
		}
		res_data_.GMDKFCMGHIK = GMDKFCMGHIK_list_.ToArray();

		return res_data_;
	}
}
