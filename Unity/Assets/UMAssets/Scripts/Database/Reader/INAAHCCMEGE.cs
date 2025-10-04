using FlatBuffers;
using System.Collections.Generic;

public class CACJOBCOKLG
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
	public uint PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int IJEKNCDIIAE_mver { get; set; } // 0x14 FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public uint FBFLDFMFFOH_rar { get; set; } // 0x18 LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
}
public class INAAHCCMEGE
{
	public CACJOBCOKLG[] BMMFEIFJOHD { get; set; } // 0x8 IMFGCAGPFOA IMHNBNPDJMC_get_ GILJCMDFGLH_set_
	public static INAAHCCMEGE HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xA00BA4
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		MHNDFPBJOGK res_readData_ = MHNDFPBJOGK.GetRootAsMHNDFPBJOGK(buffer);
		INAAHCCMEGE res_data_ = new INAAHCCMEGE();

		List<CACJOBCOKLG> BMMFEIFJOHD_list_ = new List<CACJOBCOKLG>();
		for(int BMMFEIFJOHD_idx_ = 0; BMMFEIFJOHD_idx_ < res_readData_.NPHHBNJPNILLength; BMMFEIFJOHD_idx_++)
		{
			KCMKJOCLIMD BMMFEIFJOHD_readData_ = res_readData_.GetNPHHBNJPNIL(BMMFEIFJOHD_idx_);
			CACJOBCOKLG BMMFEIFJOHD_data_ = new CACJOBCOKLG();

			BMMFEIFJOHD_data_.PPFNGGCBJKC_id = BMMFEIFJOHD_readData_.BBPHAPFBFHK/*_id*/;
			BMMFEIFJOHD_data_.JBGEEPFKIGG_val = BMMFEIFJOHD_readData_.KJFEBMBHKOC/*_val*/;
			BMMFEIFJOHD_data_.PLALNIIBLOF_en = BMMFEIFJOHD_readData_.CFLMCGOJJJD/*_en*/;
			BMMFEIFJOHD_data_.IJEKNCDIIAE_mver = BMMFEIFJOHD_readData_.OFMGALJGDAO/*_mver*/;
			BMMFEIFJOHD_data_.FBFLDFMFFOH_rar = BMMFEIFJOHD_readData_.ODBPKGJPLMD/*_rar*/;
			BMMFEIFJOHD_list_.Add(BMMFEIFJOHD_data_);
		}
		res_data_.BMMFEIFJOHD = BMMFEIFJOHD_list_.ToArray();

		return res_data_;
	}
}
