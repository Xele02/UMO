using FlatBuffers;
using System.Collections.Generic;

public class OMNECLCMFOL
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint FBFLDFMFFOH_rar { get; set; } // 0xC LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
	public uint GBJFNGCDKPM_typ { get; set; } // 0x10 GHLFADHILNN CEJJMKODOGK_get_typ HOHCEBMMACI_set_typ
	public int IJEKNCDIIAE_mver { get; set; } // 0x14 FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public int PLALNIIBLOF_en { get; set; } // 0x18 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
}
public class MDOBMPOHGJO
{
	public OMNECLCMFOL[] KKOAFINEAAG { get; set; } // 0x8 KGMBNMDHFCM FMKFOBKGGPB_get_ HBCGJPCEMKF_set_
	public static MDOBMPOHGJO HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x1310640
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		GAPIOFFIFKN res_readData_ = GAPIOFFIFKN.GetRootAsGAPIOFFIFKN(buffer);
		MDOBMPOHGJO res_data_ = new MDOBMPOHGJO();

		List<OMNECLCMFOL> KKOAFINEAAG_list_ = new List<OMNECLCMFOL>();
		for(int KKOAFINEAAG_idx_ = 0; KKOAFINEAAG_idx_ < res_readData_.KHFMFOFIFGGLength; KKOAFINEAAG_idx_++)
		{
			EIICDPMENEH KKOAFINEAAG_readData_ = res_readData_.GetKHFMFOFIFGG(KKOAFINEAAG_idx_);
			OMNECLCMFOL KKOAFINEAAG_data_ = new OMNECLCMFOL();

			KKOAFINEAAG_data_.PPFNGGCBJKC_id = KKOAFINEAAG_readData_.BBPHAPFBFHK/*_id*/;
			KKOAFINEAAG_data_.FBFLDFMFFOH_rar = KKOAFINEAAG_readData_.ODBPKGJPLMD/*_rar*/;
			KKOAFINEAAG_data_.GBJFNGCDKPM_typ = KKOAFINEAAG_readData_.LPJPOOHJKAE/*_typ*/;
			KKOAFINEAAG_data_.IJEKNCDIIAE_mver = KKOAFINEAAG_readData_.OFMGALJGDAO/*_mver*/;
			KKOAFINEAAG_data_.PLALNIIBLOF_en = KKOAFINEAAG_readData_.CFLMCGOJJJD/*_en*/;
			KKOAFINEAAG_list_.Add(KKOAFINEAAG_data_);
		}
		res_data_.KKOAFINEAAG = KKOAFINEAAG_list_.ToArray();

		return res_data_;
	}
}
