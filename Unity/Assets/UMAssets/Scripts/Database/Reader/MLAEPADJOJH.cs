using FlatBuffers;
using System.Collections.Generic;

public class CDHIKHMHMPC
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int IJEKNCDIIAE_mver { get; set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public int PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int PDBPFJJCADD_open_at { get; set; } // 0x14 PMJMBGBCIGO FOACOMBHPAC_get_open_at NBACOBCOJCA_set_open_at
	public int FDBNFFNFOND_close_at { get; set; } // 0x18 INOJHLHGKMI BPJOGHJCLDJ_get_close_at NLJKMCHOCBK_set_close_at
	public int FJOLNJLLJEJ_rank { get; set; } // 0x1C BLIGJGPCOKP EAKAGHDPEMI_get_rank GHECCGBGCBI_set_rank
	public int KNHOMNONOEB_AssetId { get; set; } // 0x20 EJNCFCPHDML NECFMEFKKPH_get_AssetId MHNEFLJACHA_set_AssetId
}
public class MLAEPADJOJH
{
	public CDHIKHMHMPC[] MJBONPHHNKG { get; set; } // 0x8 PDFMJOBHFJE LNGLAMGMLHL_get_ KLCILDKIJCF_set_
	public static MLAEPADJOJH HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x195CBB8
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		OGOJIHOJMHD res_readData_ = OGOJIHOJMHD.GetRootAsOGOJIHOJMHD(buffer);
		MLAEPADJOJH res_data_ = new MLAEPADJOJH();

		List<CDHIKHMHMPC> MJBONPHHNKG_list_ = new List<CDHIKHMHMPC>();
		for(int MJBONPHHNKG_idx_ = 0; MJBONPHHNKG_idx_ < res_readData_.EIKBNOECLEALength; MJBONPHHNKG_idx_++)
		{
			FJNOJOMGGKJ MJBONPHHNKG_readData_ = res_readData_.GetEIKBNOECLEA(MJBONPHHNKG_idx_);
			CDHIKHMHMPC MJBONPHHNKG_data_ = new CDHIKHMHMPC();

			MJBONPHHNKG_data_.PPFNGGCBJKC_id = MJBONPHHNKG_readData_.BBPHAPFBFHK/*_id*/;
			MJBONPHHNKG_data_.IJEKNCDIIAE_mver = MJBONPHHNKG_readData_.OFMGALJGDAO/*_mver*/;
			MJBONPHHNKG_data_.PLALNIIBLOF_en = MJBONPHHNKG_readData_.CFLMCGOJJJD/*_en*/;
			MJBONPHHNKG_data_.PDBPFJJCADD_open_at = MJBONPHHNKG_readData_.NJLJEKDBPCH/*_open_at*/;
			MJBONPHHNKG_data_.FDBNFFNFOND_close_at = MJBONPHHNKG_readData_.MAOAGDBDBIB/*_close_at*/;
			MJBONPHHNKG_data_.FJOLNJLLJEJ_rank = MJBONPHHNKG_readData_.BDGDHOAJDFM/*_rank*/;
			MJBONPHHNKG_data_.KNHOMNONOEB_AssetId = MJBONPHHNKG_readData_.NCADHENBLDB/*_AssetId*/;
			MJBONPHHNKG_list_.Add(MJBONPHHNKG_data_);
		}
		res_data_.MJBONPHHNKG = MJBONPHHNKG_list_.ToArray();

		return res_data_;
	}
}
