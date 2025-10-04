using FlatBuffers;
using System.Collections.Generic;

public class MMBIHLNLPHB
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int IJEKNCDIIAE_mver { get; set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public int PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int PDBPFJJCADD_open_at { get; set; } // 0x14 PMJMBGBCIGO FOACOMBHPAC_get_open_at NBACOBCOJCA_set_open_at
	public int FDBNFFNFOND_close_at { get; set; } // 0x18 INOJHLHGKMI BPJOGHJCLDJ_get_close_at NLJKMCHOCBK_set_close_at
	public int KNHOMNONOEB_AssetId { get; set; } // 0x1C EJNCFCPHDML NECFMEFKKPH_get_AssetId MHNEFLJACHA_set_AssetId
}
public class BENBFNLECGA
{
	public MMBIHLNLPHB[] KFKOALPLEGG { get; set; } // 0x8 FCMLCPIOBEN OEPJFJBDFIG_get_ BBGIPEJCKNE_set_
	public static BENBFNLECGA HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xC75FDC
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		CJMBCLHMFBF res_readData_ = CJMBCLHMFBF.GetRootAsCJMBCLHMFBF(buffer);
		BENBFNLECGA res_data_ = new BENBFNLECGA();

		List<MMBIHLNLPHB> KFKOALPLEGG_list_ = new List<MMBIHLNLPHB>();
		for(int KFKOALPLEGG_idx_ = 0; KFKOALPLEGG_idx_ < res_readData_.BBPMPGIIHOLLength; KFKOALPLEGG_idx_++)
		{
			GFNMEMLEAFB KFKOALPLEGG_readData_ = res_readData_.GetBBPMPGIIHOL(KFKOALPLEGG_idx_);
			MMBIHLNLPHB KFKOALPLEGG_data_ = new MMBIHLNLPHB();

			KFKOALPLEGG_data_.PPFNGGCBJKC_id = KFKOALPLEGG_readData_.BBPHAPFBFHK/*_id*/;
			KFKOALPLEGG_data_.IJEKNCDIIAE_mver = KFKOALPLEGG_readData_.OFMGALJGDAO/*_mver*/;
			KFKOALPLEGG_data_.PLALNIIBLOF_en = KFKOALPLEGG_readData_.CFLMCGOJJJD/*_en*/;
			KFKOALPLEGG_data_.PDBPFJJCADD_open_at = KFKOALPLEGG_readData_.NJLJEKDBPCH/*_open_at*/;
			KFKOALPLEGG_data_.FDBNFFNFOND_close_at = KFKOALPLEGG_readData_.MAOAGDBDBIB/*_close_at*/;
			KFKOALPLEGG_data_.KNHOMNONOEB_AssetId = KFKOALPLEGG_readData_.NCADHENBLDB/*_AssetId*/;
			KFKOALPLEGG_list_.Add(KFKOALPLEGG_data_);
		}
		res_data_.KFKOALPLEGG = KFKOALPLEGG_list_.ToArray();

		return res_data_;
	}
}
