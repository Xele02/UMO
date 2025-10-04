using FlatBuffers;
using System.Collections.Generic;

public class FBCAIGGLGMK
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint PLALNIIBLOF_en { get; set; } // 0xC DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public uint FNEIADJMHHO_st { get; set; } // 0x10 PJFAGECNJCF FAPDANAMOKF_get_st JIHDPPHAAOJ_set_st
	public uint KOMKKBDABJP_end { get; set; } // 0x14 JPPMFGFLNGH MOMCBDJIGKO_get_end NECMHGINPDE_set_end
	public string[] EHDDADDKMFI_f_id { get; set; } // 0x18 MCAKELLLNIO IFFJALDBDDI_get_f_id LMLHCMMIEJH_set_f_id
	public string GENIJOLKBNH { get; set; } // 0x1C IDAFBNJFLAE BJIGPDFOCBK_get_ CIJOJAMNIEC_set_
	public int BFINGCJHOHI_cnt { get; set; } // 0x20 PIAHJAJPLKA LFMCLIDAPHB_get_cnt EDAEPDGGFJJ_set_cnt
	public int OEOIHIIIMCK_add { get; set; } // 0x24 CJPIOPLFGFA BLMLNFDOJHF_get_add IJLDMBPEGAK_set_add
}
public class PMHJIJGDJMO
{
	public FBCAIGGLGMK[] MDFFJJKBDFC { get; set; } // 0x8 MLEEAALCDDB CGKHDMIDHGN_get_ MDIFADGJNNH_set_
	public static PMHJIJGDJMO HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xFEFAF0
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		CFFBOCDCDCJ res_readData_ = CFFBOCDCDCJ.GetRootAsCFFBOCDCDCJ(buffer);
		PMHJIJGDJMO res_data_ = new PMHJIJGDJMO();

		List<FBCAIGGLGMK> MDFFJJKBDFC_list_ = new List<FBCAIGGLGMK>();
		for(int MDFFJJKBDFC_idx_ = 0; MDFFJJKBDFC_idx_ < res_readData_.CGHMONDBJAILength; MDFFJJKBDFC_idx_++)
		{
			ACFFNDFGCHL MDFFJJKBDFC_readData_ = res_readData_.GetCGHMONDBJAI(MDFFJJKBDFC_idx_);
			FBCAIGGLGMK MDFFJJKBDFC_data_ = new FBCAIGGLGMK();

			MDFFJJKBDFC_data_.PPFNGGCBJKC_id = MDFFJJKBDFC_readData_.BBPHAPFBFHK/*_id*/;
			MDFFJJKBDFC_data_.PLALNIIBLOF_en = MDFFJJKBDFC_readData_.CFLMCGOJJJD/*_en*/;
			MDFFJJKBDFC_data_.FNEIADJMHHO_st = MDFFJJKBDFC_readData_.GLIIHLOLPEF/*_st*/;
			MDFFJJKBDFC_data_.KOMKKBDABJP_end = MDFFJJKBDFC_readData_.BNDAHALMIPE/*_end*/;
			List<string> EHDDADDKMFI_list_ = new List<string>();
			for(int EHDDADDKMFI_idx_ = 0; EHDDADDKMFI_idx_ < MDFFJJKBDFC_readData_.BKLDFCFKFOMLength; EHDDADDKMFI_idx_++)
			{
				EHDDADDKMFI_list_.Add(MDFFJJKBDFC_readData_.GetBKLDFCFKFOM(EHDDADDKMFI_idx_));
			}
			MDFFJJKBDFC_data_.EHDDADDKMFI_f_id = EHDDADDKMFI_list_.ToArray();

			MDFFJJKBDFC_data_.GENIJOLKBNH = MDFFJJKBDFC_readData_.IOKCFIHFBHG;
			MDFFJJKBDFC_data_.BFINGCJHOHI_cnt = MDFFJJKBDFC_readData_.CLEEFGNMCEL/*_cnt*/;
			MDFFJJKBDFC_data_.OEOIHIIIMCK_add = MDFFJJKBDFC_readData_.GKMDCGBFHPM/*_add*/;
			MDFFJJKBDFC_list_.Add(MDFFJJKBDFC_data_);
		}
		res_data_.MDFFJJKBDFC = MDFFJJKBDFC_list_.ToArray();

		return res_data_;
	}
}
