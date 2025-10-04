using FlatBuffers;
using System.Collections.Generic;

public class CMEPJFBDNPP
{
	public int BFINGCJHOHI_cnt { get; set; } // 0x8 PIAHJAJPLKA LFMCLIDAPHB_get_cnt EDAEPDGGFJJ_set_cnt
	public int LKIFDCEKDCK_exp { get; set; } // 0xC IAHMAGLCEBN GOKMANFHFPC_get_exp ICJKOKGFNLI_set_exp
}
public class EJLDLIODAID
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint AGNHPHEJKMK_tgt { get; set; } // 0xC BCKMGEBHABF MNJIGLFFJAH_get_tgt MEHEHNALGIH_set_tgt
	public uint DHIPGHBJLIL_coef { get; set; } // 0x10 KPOCJEKICDF PEIEKKODNKE_get_coef MHBDIGBDPNK_set_coef
}
public class PCFOIOGMHHL
{
	public uint[] FEOKKEPAIBB_diff { get; set; } // 0x8 GIGNEBBDCBK ICBAELIDDMP_get_diff NPOGDBMAGGF_set_diff
	public uint[] FDBOPFEOENF_diva { get; set; } // 0xC DNDMMJJOAOE MJPHCAIKKJG_get_diva GHECGDMEBFF_set_diva
	public CMEPJFBDNPP[] MDFFJJKBDFC { get; set; } // 0x10 MLEEAALCDDB CGKHDMIDHGN_get_ MDIFADGJNNH_set_
	public uint[] BPLOEAHOPFI_stamina { get; set; } // 0x14 KKOIOMJKJJK IFLOIFCLBFJ_get_stamina NGMKCJOPEGH_set_stamina
	public uint[] FJAJPKBEPPG { get; set; } // 0x18 FGOLJFGOHOE GMFOGMLLLED_get_ KNLDHCEKOPJ_set_
	public uint[] KJEJPGIHAEK { get; set; } // 0x1C CDKEFACJIMH FPAKLDBFNOG_get_ AKDIBNOENKB_set_
	public EJLDLIODAID[] OGGLMPCHEDD { get; set; } // 0x20 CLPPBIOJDBL CCEPJDHBMHB_get_ ODJNKOBMJKJ_set_
	public uint[] JPFFIBCDCNJ_friend { get; set; } // 0x24 CMMMMFKLOEI PFHOLHLIENA_get_friend LMMBLLEOLEI_set_friend
	public static PCFOIOGMHHL HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xCBF638
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		NLMKDBJHCCM res_readData_ = NLMKDBJHCCM.GetRootAsNLMKDBJHCCM(buffer);
		PCFOIOGMHHL res_data_ = new PCFOIOGMHHL();

		List<uint> FEOKKEPAIBB_list_ = new List<uint>();
		for(int FEOKKEPAIBB_idx_ = 0; FEOKKEPAIBB_idx_ < res_readData_.EOKPHAFLHBGLength; FEOKKEPAIBB_idx_++)
		{
			FEOKKEPAIBB_list_.Add(res_readData_.GetEOKPHAFLHBG(FEOKKEPAIBB_idx_));
		}
		res_data_.FEOKKEPAIBB_diff = FEOKKEPAIBB_list_.ToArray();

		List<uint> FDBOPFEOENF_list_ = new List<uint>();
		for(int FDBOPFEOENF_idx_ = 0; FDBOPFEOENF_idx_ < res_readData_.FOGBEEHMDJMLength; FDBOPFEOENF_idx_++)
		{
			FDBOPFEOENF_list_.Add(res_readData_.GetFOGBEEHMDJM(FDBOPFEOENF_idx_));
		}
		res_data_.FDBOPFEOENF_diva = FDBOPFEOENF_list_.ToArray();

		List<CMEPJFBDNPP> MDFFJJKBDFC_list_ = new List<CMEPJFBDNPP>();
		for(int MDFFJJKBDFC_idx_ = 0; MDFFJJKBDFC_idx_ < res_readData_.CGHMONDBJAILength; MDFFJJKBDFC_idx_++)
		{
			PLJHMEIABJO MDFFJJKBDFC_readData_ = res_readData_.GetCGHMONDBJAI(MDFFJJKBDFC_idx_);
			CMEPJFBDNPP MDFFJJKBDFC_data_ = new CMEPJFBDNPP();

			MDFFJJKBDFC_data_.BFINGCJHOHI_cnt = MDFFJJKBDFC_readData_.CLEEFGNMCEL/*_cnt*/;
			MDFFJJKBDFC_data_.LKIFDCEKDCK_exp = MDFFJJKBDFC_readData_.JKDAMKCJMLD/*_exp*/;
			MDFFJJKBDFC_list_.Add(MDFFJJKBDFC_data_);
		}
		res_data_.MDFFJJKBDFC = MDFFJJKBDFC_list_.ToArray();

		List<uint> BPLOEAHOPFI_list_ = new List<uint>();
		for(int BPLOEAHOPFI_idx_ = 0; BPLOEAHOPFI_idx_ < res_readData_.JPNFHMDOLDILength; BPLOEAHOPFI_idx_++)
		{
			BPLOEAHOPFI_list_.Add(res_readData_.GetJPNFHMDOLDI(BPLOEAHOPFI_idx_));
		}
		res_data_.BPLOEAHOPFI_stamina = BPLOEAHOPFI_list_.ToArray();

		List<uint> FJAJPKBEPPG_list_ = new List<uint>();
		for(int FJAJPKBEPPG_idx_ = 0; FJAJPKBEPPG_idx_ < res_readData_.DDIHJIBBICGLength; FJAJPKBEPPG_idx_++)
		{
			FJAJPKBEPPG_list_.Add(res_readData_.GetDDIHJIBBICG(FJAJPKBEPPG_idx_));
		}
		res_data_.FJAJPKBEPPG = FJAJPKBEPPG_list_.ToArray();

		List<uint> KJEJPGIHAEK_list_ = new List<uint>();
		for(int KJEJPGIHAEK_idx_ = 0; KJEJPGIHAEK_idx_ < res_readData_.JBGHINGOKLJLength; KJEJPGIHAEK_idx_++)
		{
			KJEJPGIHAEK_list_.Add(res_readData_.GetJBGHINGOKLJ(KJEJPGIHAEK_idx_));
		}
		res_data_.KJEJPGIHAEK = KJEJPGIHAEK_list_.ToArray();

		List<EJLDLIODAID> OGGLMPCHEDD_list_ = new List<EJLDLIODAID>();
		for(int OGGLMPCHEDD_idx_ = 0; OGGLMPCHEDD_idx_ < res_readData_.IBLGLCALOMGLength; OGGLMPCHEDD_idx_++)
		{
			CJBKPOKAIDA OGGLMPCHEDD_readData_ = res_readData_.GetIBLGLCALOMG(OGGLMPCHEDD_idx_);
			EJLDLIODAID OGGLMPCHEDD_data_ = new EJLDLIODAID();

			OGGLMPCHEDD_data_.PPFNGGCBJKC_id = OGGLMPCHEDD_readData_.BBPHAPFBFHK/*_id*/;
			OGGLMPCHEDD_data_.AGNHPHEJKMK_tgt = OGGLMPCHEDD_readData_.HLPHBGLMBIO/*_tgt*/;
			OGGLMPCHEDD_data_.DHIPGHBJLIL_coef = OGGLMPCHEDD_readData_.KBPBECKBGMH/*_coef*/;
			OGGLMPCHEDD_list_.Add(OGGLMPCHEDD_data_);
		}
		res_data_.OGGLMPCHEDD = OGGLMPCHEDD_list_.ToArray();

		List<uint> JPFFIBCDCNJ_list_ = new List<uint>();
		for(int JPFFIBCDCNJ_idx_ = 0; JPFFIBCDCNJ_idx_ < res_readData_.GNOLKLKMNFPLength; JPFFIBCDCNJ_idx_++)
		{
			JPFFIBCDCNJ_list_.Add(res_readData_.GetGNOLKLKMNFP(JPFFIBCDCNJ_idx_));
		}
		res_data_.JPFFIBCDCNJ_friend = JPFFIBCDCNJ_list_.ToArray();

		return res_data_;
	}
}
