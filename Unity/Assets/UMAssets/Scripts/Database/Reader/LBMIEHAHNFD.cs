using FlatBuffers;
using System.Collections.Generic;

public class BPIFDOECJPH
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int JPFMJHLCMJL_sa { get; set; } // 0xC PIJIPMOBEIJ LLFFAPHPGFJ_get_sa PMGNHNIKHLE_set_sa
	public int MJMPANIBFED_pid { get; set; } // 0x10 GGAJJGLDIII LPHIIIAOHBE_get_pid POHHJDNBLOD_set_pid
}
public class LBMIEHAHNFD
{
	public BPIFDOECJPH[] NNCNIHFAPBO { get; set; } // 0x8 MOOJCMAAIPD CFNFEFAGEFM_get_ DMPLBFJCPDE_set_
	public static LBMIEHAHNFD HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xD99910
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		IBBBNNBOBLD res_readData_ = IBBBNNBOBLD.GetRootAsIBBBNNBOBLD(buffer);
		LBMIEHAHNFD res_data_ = new LBMIEHAHNFD();

		List<BPIFDOECJPH> NNCNIHFAPBO_list_ = new List<BPIFDOECJPH>();
		for(int NNCNIHFAPBO_idx_ = 0; NNCNIHFAPBO_idx_ < res_readData_.EIACEFFDPEFLength; NNCNIHFAPBO_idx_++)
		{
			HFKBJAIMIBG NNCNIHFAPBO_readData_ = res_readData_.GetEIACEFFDPEF(NNCNIHFAPBO_idx_);
			BPIFDOECJPH NNCNIHFAPBO_data_ = new BPIFDOECJPH();

			NNCNIHFAPBO_data_.PPFNGGCBJKC_id = NNCNIHFAPBO_readData_.BBPHAPFBFHK/*_id*/;
			NNCNIHFAPBO_data_.JPFMJHLCMJL_sa = NNCNIHFAPBO_readData_.GJEJFAJHBME/*_sa*/;
			NNCNIHFAPBO_data_.MJMPANIBFED_pid = NNCNIHFAPBO_readData_.COPFAKAHEMN/*_pid*/;
			NNCNIHFAPBO_list_.Add(NNCNIHFAPBO_data_);
		}
		res_data_.NNCNIHFAPBO = NNCNIHFAPBO_list_.ToArray();

		return res_data_;
	}
}
