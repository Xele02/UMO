using FlatBuffers;
using System.Collections.Generic;

public class MKMPJMOODKL
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
	public uint PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int IJEKNCDIIAE_mver { get; set; } // 0x14 FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public uint FBFLDFMFFOH_rar { get; set; } // 0x18 LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
}
public class LGCNKCBKJBA
{
	public MKMPJMOODKL[] AAAKAPGGNGL { get; set; } // 0x8 HKFGLJEMJLN FBHLKPJCEIK_get_ BLHFBBOCHHL_set_
	public static LGCNKCBKJBA HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xD7076C
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		JPNGMOOGNIA res_readData_ = JPNGMOOGNIA.GetRootAsJPNGMOOGNIA(buffer);
		LGCNKCBKJBA res_data_ = new LGCNKCBKJBA();

		List<MKMPJMOODKL> AAAKAPGGNGL_list_ = new List<MKMPJMOODKL>();
		for(int AAAKAPGGNGL_idx_ = 0; AAAKAPGGNGL_idx_ < res_readData_.GHBONFLCMKCLength; AAAKAPGGNGL_idx_++)
		{
			JBAKGMLAGMJ AAAKAPGGNGL_readData_ = res_readData_.GetGHBONFLCMKC(AAAKAPGGNGL_idx_);
			MKMPJMOODKL AAAKAPGGNGL_data_ = new MKMPJMOODKL();

			AAAKAPGGNGL_data_.PPFNGGCBJKC_id = AAAKAPGGNGL_readData_.BBPHAPFBFHK/*_id*/;
			AAAKAPGGNGL_data_.JBGEEPFKIGG_val = AAAKAPGGNGL_readData_.KJFEBMBHKOC/*_val*/;
			AAAKAPGGNGL_data_.PLALNIIBLOF_en = AAAKAPGGNGL_readData_.CFLMCGOJJJD/*_en*/;
			AAAKAPGGNGL_data_.IJEKNCDIIAE_mver = AAAKAPGGNGL_readData_.OFMGALJGDAO/*_mver*/;
			AAAKAPGGNGL_data_.FBFLDFMFFOH_rar = AAAKAPGGNGL_readData_.ODBPKGJPLMD/*_rar*/;
			AAAKAPGGNGL_list_.Add(AAAKAPGGNGL_data_);
		}
		res_data_.AAAKAPGGNGL = AAAKAPGGNGL_list_.ToArray();

		return res_data_;
	}
}
