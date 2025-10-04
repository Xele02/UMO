using FlatBuffers;
using System.Collections.Generic;

public class LNFHEEBKPNL
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int IJEKNCDIIAE_mver { get; set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public uint PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public uint FEFDGBPFKBJ_gid { get; set; } // 0x14 NBBEDGJCLDE BFIENFNOPIH_get_gid INLGKGJPBCP_set_gid
	public uint KOMKKBDABJP_end { get; set; } // 0x18 JPPMFGFLNGH MOMCBDJIGKO_get_end NECMHGINPDE_set_end
	public uint FOILNHKHHDF_pt { get; set; } // 0x1C LNNCNOIGMGM FOFBHPJDHFO_get_pt LHPMDDKPJDP_set_pt
	public uint[] CIOKHGPEEKE_sid { get; set; } // 0x20 BDJNNGOOPCO KICCFHPEGJC_get_sid NNKLOCFCMOL_set_sid
}
public class DNAMOAGODKD
{
	public string LJNAKDMILMC_key { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM_get_key OACJGKPBHIK_set_key
	public int JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class MOGPEEGGGEC
{
	public string LJNAKDMILMC_key { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM_get_key OACJGKPBHIK_set_key
	public string JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class DNKLFEPGGNC
{
	public LNFHEEBKPNL[] JFFLBNACFOH { get; set; } // 0x8 CGJILPEONDC IPLFONNHHCA_get_ JFHKHKPPHFN_set_
	public DNAMOAGODKD[] BHGDNGHDDAC { get; set; } // 0xC JHDNDHBDFFI CEHHJMMMCID_get_ EDOEOHENKDG_set_
	public MOGPEEGGGEC[] MHGMDJNOLMI { get; set; } // 0x10 JBFEKPIDNIC NFFJJGMEEOB_get_ BGEFBFOAMPK_set_
	public static DNKLFEPGGNC HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x1231FD8
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		ACCMHHCLELG res_readData_ = ACCMHHCLELG.GetRootAsACCMHHCLELG(buffer);
		DNKLFEPGGNC res_data_ = new DNKLFEPGGNC();

		List<LNFHEEBKPNL> JFFLBNACFOH_list_ = new List<LNFHEEBKPNL>();
		for(int JFFLBNACFOH_idx_ = 0; JFFLBNACFOH_idx_ < res_readData_.ODLAFHPCDECLength; JFFLBNACFOH_idx_++)
		{
			JLIDEAHFDEA JFFLBNACFOH_readData_ = res_readData_.GetODLAFHPCDEC(JFFLBNACFOH_idx_);
			LNFHEEBKPNL JFFLBNACFOH_data_ = new LNFHEEBKPNL();

			JFFLBNACFOH_data_.PPFNGGCBJKC_id = JFFLBNACFOH_readData_.BBPHAPFBFHK/*_id*/;
			JFFLBNACFOH_data_.IJEKNCDIIAE_mver = JFFLBNACFOH_readData_.OFMGALJGDAO/*_mver*/;
			JFFLBNACFOH_data_.PLALNIIBLOF_en = JFFLBNACFOH_readData_.CFLMCGOJJJD/*_en*/;
			JFFLBNACFOH_data_.FEFDGBPFKBJ_gid = JFFLBNACFOH_readData_.PBMIJLINDCG/*_gid*/;
			JFFLBNACFOH_data_.KOMKKBDABJP_end = JFFLBNACFOH_readData_.BNDAHALMIPE/*_end*/;
			JFFLBNACFOH_data_.FOILNHKHHDF_pt = JFFLBNACFOH_readData_.HJNPKHJJDBB/*_pt*/;
			List<uint> CIOKHGPEEKE_list_ = new List<uint>();
			for(int CIOKHGPEEKE_idx_ = 0; CIOKHGPEEKE_idx_ < JFFLBNACFOH_readData_.PJLIIABPNFJLength; CIOKHGPEEKE_idx_++)
			{
				CIOKHGPEEKE_list_.Add(JFFLBNACFOH_readData_.GetPJLIIABPNFJ(CIOKHGPEEKE_idx_));
			}
			JFFLBNACFOH_data_.CIOKHGPEEKE_sid = CIOKHGPEEKE_list_.ToArray();

			JFFLBNACFOH_list_.Add(JFFLBNACFOH_data_);
		}
		res_data_.JFFLBNACFOH = JFFLBNACFOH_list_.ToArray();

		List<DNAMOAGODKD> BHGDNGHDDAC_list_ = new List<DNAMOAGODKD>();
		for(int BHGDNGHDDAC_idx_ = 0; BHGDNGHDDAC_idx_ < res_readData_.NJJINHMIOHNLength; BHGDNGHDDAC_idx_++)
		{
			CKMEIOAPABF BHGDNGHDDAC_readData_ = res_readData_.GetNJJINHMIOHN(BHGDNGHDDAC_idx_);
			DNAMOAGODKD BHGDNGHDDAC_data_ = new DNAMOAGODKD();

			BHGDNGHDDAC_data_.LJNAKDMILMC_key = BHGDNGHDDAC_readData_.AGOIMGHMGOH/*_key*/;
			BHGDNGHDDAC_data_.JBGEEPFKIGG_val = BHGDNGHDDAC_readData_.KJFEBMBHKOC/*_val*/;
			BHGDNGHDDAC_list_.Add(BHGDNGHDDAC_data_);
		}
		res_data_.BHGDNGHDDAC = BHGDNGHDDAC_list_.ToArray();

		List<MOGPEEGGGEC> MHGMDJNOLMI_list_ = new List<MOGPEEGGGEC>();
		for(int MHGMDJNOLMI_idx_ = 0; MHGMDJNOLMI_idx_ < res_readData_.NPFBHGKLIOMLength; MHGMDJNOLMI_idx_++)
		{
			BEHBIEJAFJL MHGMDJNOLMI_readData_ = res_readData_.GetNPFBHGKLIOM(MHGMDJNOLMI_idx_);
			MOGPEEGGGEC MHGMDJNOLMI_data_ = new MOGPEEGGGEC();

			MHGMDJNOLMI_data_.LJNAKDMILMC_key = MHGMDJNOLMI_readData_.AGOIMGHMGOH/*_key*/;
			MHGMDJNOLMI_data_.JBGEEPFKIGG_val = MHGMDJNOLMI_readData_.KJFEBMBHKOC/*_val*/;
			MHGMDJNOLMI_list_.Add(MHGMDJNOLMI_data_);
		}
		res_data_.MHGMDJNOLMI = MHGMDJNOLMI_list_.ToArray();

		return res_data_;
	}
}
