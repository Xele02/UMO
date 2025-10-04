using FlatBuffers;
using System.Collections.Generic;

public class LPBEJIIKIDI
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint FBFLDFMFFOH_rar { get; set; } // 0xC LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
	public uint JBGEEPFKIGG_val { get; set; } // 0x10 AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class MMEGEEMJBDH
{
	public LPBEJIIKIDI[] KLFCPLCMION { get; set; } // 0x8 AMOMNOEFIFI CEKEKEAHJDP_get_ KGDBNIPDMBO_set_
	public static MMEGEEMJBDH HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x19646A8
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		CFOEKHAFGOJ res_readData_ = CFOEKHAFGOJ.GetRootAsCFOEKHAFGOJ(buffer);
		MMEGEEMJBDH res_data_ = new MMEGEEMJBDH();

		List<LPBEJIIKIDI> KLFCPLCMION_list_ = new List<LPBEJIIKIDI>();
		for(int KLFCPLCMION_idx_ = 0; KLFCPLCMION_idx_ < res_readData_.FHPGFDAILOGLength; KLFCPLCMION_idx_++)
		{
			NLLKKCGLDPD KLFCPLCMION_readData_ = res_readData_.GetFHPGFDAILOG(KLFCPLCMION_idx_);
			LPBEJIIKIDI KLFCPLCMION_data_ = new LPBEJIIKIDI();

			KLFCPLCMION_data_.PPFNGGCBJKC_id = KLFCPLCMION_readData_.BBPHAPFBFHK/*_id*/;
			KLFCPLCMION_data_.FBFLDFMFFOH_rar = KLFCPLCMION_readData_.ODBPKGJPLMD/*_rar*/;
			KLFCPLCMION_data_.JBGEEPFKIGG_val = KLFCPLCMION_readData_.KJFEBMBHKOC/*_val*/;
			KLFCPLCMION_list_.Add(KLFCPLCMION_data_);
		}
		res_data_.KLFCPLCMION = KLFCPLCMION_list_.ToArray();

		return res_data_;
	}
}
