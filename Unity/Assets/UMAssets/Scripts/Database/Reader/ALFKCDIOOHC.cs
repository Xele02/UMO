using FlatBuffers;
using System.Collections.Generic;

public class NPMGLCODOBA
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint FBFLDFMFFOH_rar { get; set; } // 0xC LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
	public uint JBGEEPFKIGG_val { get; set; } // 0x10 AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
}
public class ALFKCDIOOHC
{
	public NPMGLCODOBA[] HKOCCOIGLIK { get; set; } // 0x8 CNLKFIOLIDE KLPIFHCGJLC_get_ KLMMJCOMKHN_set_
	public static ALFKCDIOOHC HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xCD9C28
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		JHNNMJEDOLG res_readData_ = JHNNMJEDOLG.GetRootAsJHNNMJEDOLG(buffer);
		ALFKCDIOOHC res_data_ = new ALFKCDIOOHC();

		List<NPMGLCODOBA> HKOCCOIGLIK_list_ = new List<NPMGLCODOBA>();
		for(int HKOCCOIGLIK_idx_ = 0; HKOCCOIGLIK_idx_ < res_readData_.AHKGHCGBMDALength; HKOCCOIGLIK_idx_++)
		{
			DEGPNJFEGOC HKOCCOIGLIK_readData_ = res_readData_.GetAHKGHCGBMDA(HKOCCOIGLIK_idx_);
			NPMGLCODOBA HKOCCOIGLIK_data_ = new NPMGLCODOBA();

			HKOCCOIGLIK_data_.PPFNGGCBJKC_id = HKOCCOIGLIK_readData_.BBPHAPFBFHK/*_id*/;
			HKOCCOIGLIK_data_.FBFLDFMFFOH_rar = HKOCCOIGLIK_readData_.ODBPKGJPLMD/*_rar*/;
			HKOCCOIGLIK_data_.JBGEEPFKIGG_val = HKOCCOIGLIK_readData_.KJFEBMBHKOC/*_val*/;
			HKOCCOIGLIK_list_.Add(HKOCCOIGLIK_data_);
		}
		res_data_.HKOCCOIGLIK = HKOCCOIGLIK_list_.ToArray();

		return res_data_;
	}
}
