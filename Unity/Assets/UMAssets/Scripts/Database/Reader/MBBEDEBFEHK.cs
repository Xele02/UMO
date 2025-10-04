using FlatBuffers;
using System.Collections.Generic;

public class LCFLMIGPBLJ
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int IJEKNCDIIAE_mver { get; set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public int PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int PDBPFJJCADD_open_at { get; set; } // 0x14 PMJMBGBCIGO FOACOMBHPAC_get_open_at NBACOBCOJCA_set_open_at
	public int FDBNFFNFOND_close_at { get; set; } // 0x18 INOJHLHGKMI BPJOGHJCLDJ_get_close_at NLJKMCHOCBK_set_close_at
	public int[] BMFACNFNCKC { get; set; } // 0x1C CJHLOJHAPDH LEMPPNHNINM_get_ DHOGBDDHLIA_set_
	public int[] MFKKADJIHHK { get; set; } // 0x20 HOEKGABMBND PILANLMGNKE_get_ HAJEGBDJMHK_set_
}
public class MBBEDEBFEHK
{
	public LCFLMIGPBLJ[] KNCEIKIFAGD { get; set; } // 0x8 IDJNHHNOOCG FNKCCJEKBLM_get_ ILOCLDBPPCI_set_
	public static MBBEDEBFEHK HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xA2D1D0
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		JKIJAPMNHFJ res_readData_ = JKIJAPMNHFJ.GetRootAsJKIJAPMNHFJ(buffer);
		MBBEDEBFEHK res_data_ = new MBBEDEBFEHK();

		List<LCFLMIGPBLJ> KNCEIKIFAGD_list_ = new List<LCFLMIGPBLJ>();
		for(int KNCEIKIFAGD_idx_ = 0; KNCEIKIFAGD_idx_ < res_readData_.ECIELLPPMPPLength; KNCEIKIFAGD_idx_++)
		{
			FDEDPMKCNLB KNCEIKIFAGD_readData_ = res_readData_.GetECIELLPPMPP(KNCEIKIFAGD_idx_);
			LCFLMIGPBLJ KNCEIKIFAGD_data_ = new LCFLMIGPBLJ();

			KNCEIKIFAGD_data_.PPFNGGCBJKC_id = KNCEIKIFAGD_readData_.BBPHAPFBFHK/*_id*/;
			KNCEIKIFAGD_data_.IJEKNCDIIAE_mver = KNCEIKIFAGD_readData_.OFMGALJGDAO/*_mver*/;
			KNCEIKIFAGD_data_.PLALNIIBLOF_en = KNCEIKIFAGD_readData_.CFLMCGOJJJD/*_en*/;
			KNCEIKIFAGD_data_.PDBPFJJCADD_open_at = KNCEIKIFAGD_readData_.NJLJEKDBPCH/*_open_at*/;
			KNCEIKIFAGD_data_.FDBNFFNFOND_close_at = KNCEIKIFAGD_readData_.MAOAGDBDBIB/*_close_at*/;
			List<int> BMFACNFNCKC_list_ = new List<int>();
			for(int BMFACNFNCKC_idx_ = 0; BMFACNFNCKC_idx_ < KNCEIKIFAGD_readData_.EOLOEKNHBGKLength; BMFACNFNCKC_idx_++)
			{
				BMFACNFNCKC_list_.Add(KNCEIKIFAGD_readData_.GetEOLOEKNHBGK(BMFACNFNCKC_idx_));
			}
			KNCEIKIFAGD_data_.BMFACNFNCKC = BMFACNFNCKC_list_.ToArray();

			List<int> MFKKADJIHHK_list_ = new List<int>();
			for(int MFKKADJIHHK_idx_ = 0; MFKKADJIHHK_idx_ < KNCEIKIFAGD_readData_.DHFIMBLLAMOLength; MFKKADJIHHK_idx_++)
			{
				MFKKADJIHHK_list_.Add(KNCEIKIFAGD_readData_.GetDHFIMBLLAMO(MFKKADJIHHK_idx_));
			}
			KNCEIKIFAGD_data_.MFKKADJIHHK = MFKKADJIHHK_list_.ToArray();

			KNCEIKIFAGD_list_.Add(KNCEIKIFAGD_data_);
		}
		res_data_.KNCEIKIFAGD = KNCEIKIFAGD_list_.ToArray();

		return res_data_;
	}
}
