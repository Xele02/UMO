using FlatBuffers;
using System.Collections.Generic;

public class LPMLJGGJGGK
{
	public string OPFGFINHFCE_name { get; set; } // 0x8 LGIIAPHCLPN DKJOHDGOIJE_get_name MJAMIGECMMF_set_name
	public int IOIMHJAOKOO_Hash { get; set; } // 0xC GMLEDKKPBFJ HJMJGBCJBIN_get_Hash OLGHLLNJPKD_set_Hash
}
public class BNBONBECPKB
{
	public LPMLJGGJGGK[] GMLFFMJMPCC { get; set; } // 0x8 MKAFOOHLHAC FHEIILDDCIM_get_ CBMHJMIJLHH_set_
	public static BNBONBECPKB HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x19CA924
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		ODNNPHLAMGH res_readData_ = ODNNPHLAMGH.GetRootAsODNNPHLAMGH(buffer);
		BNBONBECPKB res_data_ = new BNBONBECPKB();

		List<LPMLJGGJGGK> GMLFFMJMPCC_list_ = new List<LPMLJGGJGGK>();
		for(int GMLFFMJMPCC_idx_ = 0; GMLFFMJMPCC_idx_ < res_readData_.AMGOKLNCCPHLength; GMLFFMJMPCC_idx_++)
		{
			FIMKNOFPMLA GMLFFMJMPCC_readData_ = res_readData_.GetAMGOKLNCCPH(GMLFFMJMPCC_idx_);
			LPMLJGGJGGK GMLFFMJMPCC_data_ = new LPMLJGGJGGK();

			GMLFFMJMPCC_data_.OPFGFINHFCE_name = GMLFFMJMPCC_readData_.IIDCFMHCPLJ/*_name*/;
			GMLFFMJMPCC_data_.IOIMHJAOKOO_Hash = GMLFFMJMPCC_readData_.PAPMBEBHHIG/*_Hash*/;
			GMLFFMJMPCC_list_.Add(GMLFFMJMPCC_data_);
		}
		res_data_.GMLFFMJMPCC = GMLFFMJMPCC_list_.ToArray();

		return res_data_;
	}
}
