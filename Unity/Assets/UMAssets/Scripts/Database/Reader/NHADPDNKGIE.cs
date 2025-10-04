using FlatBuffers;
using System.Collections.Generic;

public class JNHHIHOCMHN
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint HANMDEBPBHG_pic { get; set; } // 0xC IMDBPCNAOOE EFGGIMOPNMG_get_pic PNGGKPFDKMA_set_pic
	public uint HDEBAGHEIKD_plt { get; set; } // 0x10 LEOIDFOJDEB ILEIGMALLGJ_get_plt EEAKPBHBMOL_set_plt
	public uint DFOIEJOKDKJ_avo { get; set; } // 0x14 NELIGKOCNOK FKLAHJBFJCO_get_avo APCNKLOJCNJ_set_avo
	public uint AKOJJJLPCKA_c_s { get; set; } // 0x18 HAHLJMLFIKD NIKDJFBDBOO_get_c_s IDCBHPEIAFE_set_c_s
	public uint LNKKMBCDPHH_l_s { get; set; } // 0x1C GPEMGLLCJIF PAPMCJONAGI_get_l_s MODJBBMBLCD_set_l_s
}
public class NHADPDNKGIE
{
	public JNHHIHOCMHN[] EAHFNHMNPIB { get; set; } // 0x8 MEMBLECFIJD FCMCIMGKNLP_get_ CGGPLGMEJHC_set_
	public static NHADPDNKGIE HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x1890084
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		PCIEJLEICFK res_readData_ = PCIEJLEICFK.GetRootAsPCIEJLEICFK(buffer);
		NHADPDNKGIE res_data_ = new NHADPDNKGIE();

		List<JNHHIHOCMHN> EAHFNHMNPIB_list_ = new List<JNHHIHOCMHN>();
		for(int EAHFNHMNPIB_idx_ = 0; EAHFNHMNPIB_idx_ < res_readData_.AHBLKAMALAMLength; EAHFNHMNPIB_idx_++)
		{
			PJOFNFPMOLG EAHFNHMNPIB_readData_ = res_readData_.GetAHBLKAMALAM(EAHFNHMNPIB_idx_);
			JNHHIHOCMHN EAHFNHMNPIB_data_ = new JNHHIHOCMHN();

			EAHFNHMNPIB_data_.PPFNGGCBJKC_id = EAHFNHMNPIB_readData_.BBPHAPFBFHK/*_id*/;
			EAHFNHMNPIB_data_.HANMDEBPBHG_pic = EAHFNHMNPIB_readData_.BLJLFEDLAME/*_pic*/;
			EAHFNHMNPIB_data_.HDEBAGHEIKD_plt = EAHFNHMNPIB_readData_.DALJDMJEJGE/*_plt*/;
			EAHFNHMNPIB_data_.DFOIEJOKDKJ_avo = EAHFNHMNPIB_readData_.IDJCFCJMBCF/*_avo*/;
			EAHFNHMNPIB_data_.AKOJJJLPCKA_c_s = EAHFNHMNPIB_readData_.NAGPKLGDNDA/*_c_s*/;
			EAHFNHMNPIB_data_.LNKKMBCDPHH_l_s = EAHFNHMNPIB_readData_.BNDEBMLCMNB/*_l_s*/;
			EAHFNHMNPIB_list_.Add(EAHFNHMNPIB_data_);
		}
		res_data_.EAHFNHMNPIB = EAHFNHMNPIB_list_.ToArray();

		return res_data_;
	}
}
