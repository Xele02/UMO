using FlatBuffers;
using System.Collections.Generic;

public class HMJNEBPFCKE
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint GJDNBENICPF_vcid { get; set; } // 0xC HPJECMJNMPM AFNFOLBCEAH_get_vcid NAFMLADMAGK_set_vcid
	public int IJEKNCDIIAE_mver { get; set; } // 0x10 FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public uint PLALNIIBLOF_en { get; set; } // 0x14 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public uint DOOGFEGEKLG_max { get; set; } // 0x18 IKKMNBJGBJK AECMFIOFFJN_get_max NGOJJDOCIDG_set_max
}
public class ONPNHODCGFB
{
	public HMJNEBPFCKE[] IGBEFKKKMKJ { get; set; } // 0x8 PNALEOLKEKE GJFMOFKINKE_get_ BOCOJJJHAIK_set_
	public static ONPNHODCGFB HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xCAFF8C
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		NMOEOEOBDAD res_readData_ = NMOEOEOBDAD.GetRootAsNMOEOEOBDAD(buffer);
		ONPNHODCGFB res_data_ = new ONPNHODCGFB();

		List<HMJNEBPFCKE> IGBEFKKKMKJ_list_ = new List<HMJNEBPFCKE>();
		for(int IGBEFKKKMKJ_idx_ = 0; IGBEFKKKMKJ_idx_ < res_readData_.LLDMPBONLLMLength; IGBEFKKKMKJ_idx_++)
		{
			DHEAKBKIDEA IGBEFKKKMKJ_readData_ = res_readData_.GetLLDMPBONLLM(IGBEFKKKMKJ_idx_);
			HMJNEBPFCKE IGBEFKKKMKJ_data_ = new HMJNEBPFCKE();

			IGBEFKKKMKJ_data_.PPFNGGCBJKC_id = IGBEFKKKMKJ_readData_.BBPHAPFBFHK/*_id*/;
			IGBEFKKKMKJ_data_.GJDNBENICPF_vcid = IGBEFKKKMKJ_readData_.HHBHJBIAAAD/*_vcid*/;
			IGBEFKKKMKJ_data_.IJEKNCDIIAE_mver = IGBEFKKKMKJ_readData_.OFMGALJGDAO/*_mver*/;
			IGBEFKKKMKJ_data_.PLALNIIBLOF_en = IGBEFKKKMKJ_readData_.CFLMCGOJJJD/*_en*/;
			IGBEFKKKMKJ_data_.DOOGFEGEKLG_max = IGBEFKKKMKJ_readData_.GEJGMBBCFEE/*_max*/;
			IGBEFKKKMKJ_list_.Add(IGBEFKKKMKJ_data_);
		}
		res_data_.IGBEFKKKMKJ = IGBEFKKKMKJ_list_.ToArray();

		return res_data_;
	}
}
