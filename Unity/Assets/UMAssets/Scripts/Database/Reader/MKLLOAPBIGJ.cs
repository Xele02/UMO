using FlatBuffers;
using System.Collections.Generic;

public class FHAPNNHNNCN
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int IJEKNCDIIAE_mver { get; set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public int PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int HJAFPEBIBOP_Limit { get; set; } // 0x14 AELPJDJAIEA GNDLHNBPMHN_get_Limit HPFNBOKBEDD_set_Limit
	public int JBGEEPFKIGG_val { get; set; } // 0x18 AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
	public int DOOGFEGEKLG_max { get; set; } // 0x1C IKKMNBJGBJK AECMFIOFFJN_get_max NGOJJDOCIDG_set_max
	public int FPOMEEJFBIG_odr { get; set; } // 0x20 PJKJIFMIFDJ OEEBAHNAPEC_get_odr BEHAPLPPLNE_set_odr
	public uint FBFLDFMFFOH_rar { get; set; } // 0x24 LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
}
public class MKLLOAPBIGJ
{
	public FHAPNNHNNCN[] JNMKOOKNLIN { get; set; } // 0x8 OBFBJCIGOCE HKJHABAAOCC_get_ IEJEDMFIHLO_set_
	public static MKLLOAPBIGJ HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x195A638
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		AMMFBOPDMFI res_readData_ = AMMFBOPDMFI.GetRootAsAMMFBOPDMFI(buffer);
		MKLLOAPBIGJ res_data_ = new MKLLOAPBIGJ();

		List<FHAPNNHNNCN> JNMKOOKNLIN_list_ = new List<FHAPNNHNNCN>();
		for(int JNMKOOKNLIN_idx_ = 0; JNMKOOKNLIN_idx_ < res_readData_.JIHMDOCLAPKLength; JNMKOOKNLIN_idx_++)
		{
			EFOIDPJOBDM JNMKOOKNLIN_readData_ = res_readData_.GetJIHMDOCLAPK(JNMKOOKNLIN_idx_);
			FHAPNNHNNCN JNMKOOKNLIN_data_ = new FHAPNNHNNCN();

			JNMKOOKNLIN_data_.PPFNGGCBJKC_id = JNMKOOKNLIN_readData_.BBPHAPFBFHK/*_id*/;
			JNMKOOKNLIN_data_.IJEKNCDIIAE_mver = JNMKOOKNLIN_readData_.OFMGALJGDAO/*_mver*/;
			JNMKOOKNLIN_data_.PLALNIIBLOF_en = JNMKOOKNLIN_readData_.CFLMCGOJJJD/*_en*/;
			JNMKOOKNLIN_data_.HJAFPEBIBOP_Limit = JNMKOOKNLIN_readData_.HBHEHJDPEBI/*_Limit*/;
			JNMKOOKNLIN_data_.JBGEEPFKIGG_val = JNMKOOKNLIN_readData_.KJFEBMBHKOC/*_val*/;
			JNMKOOKNLIN_data_.DOOGFEGEKLG_max = JNMKOOKNLIN_readData_.GEJGMBBCFEE/*_max*/;
			JNMKOOKNLIN_data_.FPOMEEJFBIG_odr = JNMKOOKNLIN_readData_.AEAKMMJLLDK/*_odr*/;
			JNMKOOKNLIN_data_.FBFLDFMFFOH_rar = JNMKOOKNLIN_readData_.ODBPKGJPLMD/*_rar*/;
			JNMKOOKNLIN_list_.Add(JNMKOOKNLIN_data_);
		}
		res_data_.JNMKOOKNLIN = JNMKOOKNLIN_list_.ToArray();

		return res_data_;
	}
}
