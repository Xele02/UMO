using FlatBuffers;
using System.Collections.Generic;

public class LLFEFBAPGCH
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int IJEKNCDIIAE_mver { get; set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public int PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int CEHGGKDLAFA { get; set; } // 0x14 JJBLENPJLEK NMDGBGFNNCJ_get_ MFJINKDMHHP_set_
}
public class NJBPFPMDKHN
{
	public LLFEFBAPGCH[] CEEPNGEADMG { get; set; } // 0x8 CHAJIGCPNGK PFHOLDEPGAB_get_ KFFKCCNMEED_set_
	public static NJBPFPMDKHN HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x18AB410
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		EADNHFHCKIA res_readData_ = EADNHFHCKIA.GetRootAsEADNHFHCKIA(buffer);
		NJBPFPMDKHN res_data_ = new NJBPFPMDKHN();

		List<LLFEFBAPGCH> CEEPNGEADMG_list_ = new List<LLFEFBAPGCH>();
		for(int CEEPNGEADMG_idx_ = 0; CEEPNGEADMG_idx_ < res_readData_.EJNIGLEDAFJLength; CEEPNGEADMG_idx_++)
		{
			NGBNIMPLJEE CEEPNGEADMG_readData_ = res_readData_.GetEJNIGLEDAFJ(CEEPNGEADMG_idx_);
			LLFEFBAPGCH CEEPNGEADMG_data_ = new LLFEFBAPGCH();

			CEEPNGEADMG_data_.PPFNGGCBJKC_id = CEEPNGEADMG_readData_.BBPHAPFBFHK/*_id*/;
			CEEPNGEADMG_data_.IJEKNCDIIAE_mver = CEEPNGEADMG_readData_.OFMGALJGDAO/*_mver*/;
			CEEPNGEADMG_data_.PLALNIIBLOF_en = CEEPNGEADMG_readData_.CFLMCGOJJJD/*_en*/;
			CEEPNGEADMG_data_.CEHGGKDLAFA = CEEPNGEADMG_readData_.JCIIGMCDKAH;
			CEEPNGEADMG_list_.Add(CEEPNGEADMG_data_);
		}
		res_data_.CEEPNGEADMG = CEEPNGEADMG_list_.ToArray();

		return res_data_;
	}
}
