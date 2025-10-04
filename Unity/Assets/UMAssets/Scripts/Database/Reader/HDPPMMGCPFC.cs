using FlatBuffers;
using System.Collections.Generic;

public class JMHHPHHACHH
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
	public uint PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int IJEKNCDIIAE_mver { get; set; } // 0x14 FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public uint FBFLDFMFFOH_rar { get; set; } // 0x18 LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
	public int EIGNPDFHIJA { get; set; } // 0x1C JIMIIFIJDON COAODPNEELA_get_ OHOPAKFBOGL_set_
}
public class HDPPMMGCPFC
{
	public JMHHPHHACHH[] ECFMCPJIDJN { get; set; } // 0x8 CBOICJHEFAO IDEIHKDOEGB_get_ HHIPMDCOPPA_set_
	public static HDPPMMGCPFC HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x1743664
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		FJGGBKGOPEG res_readData_ = FJGGBKGOPEG.GetRootAsFJGGBKGOPEG(buffer);
		HDPPMMGCPFC res_data_ = new HDPPMMGCPFC();

		List<JMHHPHHACHH> ECFMCPJIDJN_list_ = new List<JMHHPHHACHH>();
		for(int ECFMCPJIDJN_idx_ = 0; ECFMCPJIDJN_idx_ < res_readData_.HCAJMDDNOANLength; ECFMCPJIDJN_idx_++)
		{
			LDJGKHHLNKN ECFMCPJIDJN_readData_ = res_readData_.GetHCAJMDDNOAN(ECFMCPJIDJN_idx_);
			JMHHPHHACHH ECFMCPJIDJN_data_ = new JMHHPHHACHH();

			ECFMCPJIDJN_data_.PPFNGGCBJKC_id = ECFMCPJIDJN_readData_.BBPHAPFBFHK/*_id*/;
			ECFMCPJIDJN_data_.JBGEEPFKIGG_val = ECFMCPJIDJN_readData_.KJFEBMBHKOC/*_val*/;
			ECFMCPJIDJN_data_.PLALNIIBLOF_en = ECFMCPJIDJN_readData_.CFLMCGOJJJD/*_en*/;
			ECFMCPJIDJN_data_.IJEKNCDIIAE_mver = ECFMCPJIDJN_readData_.OFMGALJGDAO/*_mver*/;
			ECFMCPJIDJN_data_.FBFLDFMFFOH_rar = ECFMCPJIDJN_readData_.ODBPKGJPLMD/*_rar*/;
			ECFMCPJIDJN_data_.EIGNPDFHIJA = ECFMCPJIDJN_readData_.GPBMFGDNLHL;
			ECFMCPJIDJN_list_.Add(ECFMCPJIDJN_data_);
		}
		res_data_.ECFMCPJIDJN = ECFMCPJIDJN_list_.ToArray();

		return res_data_;
	}
}
