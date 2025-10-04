using FlatBuffers;
using System.Collections.Generic;

public class DNNGNDOKKGA
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint FBFLDFMFFOH_rar { get; set; } // 0xC LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
	public uint JBGEEPFKIGG_val { get; set; } // 0x10 AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
	public uint FPOMEEJFBIG_odr { get; set; } // 0x14 PJKJIFMIFDJ OEEBAHNAPEC_get_odr BEHAPLPPLNE_set_odr
	public uint DOOGFEGEKLG_max { get; set; } // 0x18 IKKMNBJGBJK AECMFIOFFJN_get_max NGOJJDOCIDG_set_max
}
public class CHIHOOMFLNA
{
	public DNNGNDOKKGA[] KADBDHBKNMK { get; set; } // 0x8 OBKGMIFKBHP CGOCHNOHPGO_get_ PDJNADPCPCE_set_
	public static CHIHOOMFLNA HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x12C78B0
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		AGKBCKADDKJ res_readData_ = AGKBCKADDKJ.GetRootAsAGKBCKADDKJ(buffer);
		CHIHOOMFLNA res_data_ = new CHIHOOMFLNA();

		List<DNNGNDOKKGA> KADBDHBKNMK_list_ = new List<DNNGNDOKKGA>();
		for(int KADBDHBKNMK_idx_ = 0; KADBDHBKNMK_idx_ < res_readData_.AGCMBBANHPNLength; KADBDHBKNMK_idx_++)
		{
			FKEPLHAEEBK KADBDHBKNMK_readData_ = res_readData_.GetAGCMBBANHPN(KADBDHBKNMK_idx_);
			DNNGNDOKKGA KADBDHBKNMK_data_ = new DNNGNDOKKGA();

			KADBDHBKNMK_data_.PPFNGGCBJKC_id = KADBDHBKNMK_readData_.BBPHAPFBFHK/*_id*/;
			KADBDHBKNMK_data_.FBFLDFMFFOH_rar = KADBDHBKNMK_readData_.ODBPKGJPLMD/*_rar*/;
			KADBDHBKNMK_data_.JBGEEPFKIGG_val = KADBDHBKNMK_readData_.KJFEBMBHKOC/*_val*/;
			KADBDHBKNMK_data_.FPOMEEJFBIG_odr = KADBDHBKNMK_readData_.AEAKMMJLLDK/*_odr*/;
			KADBDHBKNMK_data_.DOOGFEGEKLG_max = KADBDHBKNMK_readData_.GEJGMBBCFEE/*_max*/;
			KADBDHBKNMK_list_.Add(KADBDHBKNMK_data_);
		}
		res_data_.KADBDHBKNMK = KADBDHBKNMK_list_.ToArray();

		return res_data_;
	}
}
