using FlatBuffers;
using System.Collections.Generic;

public class HNJNEMJIBKI
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint HANMDEBPBHG_pic { get; set; } // 0xC IMDBPCNAOOE EFGGIMOPNMG_get_pic PNGGKPFDKMA_set_pic
	public uint PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public uint FPOMEEJFBIG_odr { get; set; } // 0x14 PJKJIFMIFDJ OEEBAHNAPEC_get_odr BEHAPLPPLNE_set_odr
	public uint FBFLDFMFFOH_rar { get; set; } // 0x18 LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
}
public class IMLKIIBJABA
{
	public HNJNEMJIBKI[] BDDHMELPABN { get; set; } // 0x8 JJCJJPALGGI OCFACIBPFKK_get_ MNPFODINBCO_set_
	public static IMLKIIBJABA HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x9FB3A4
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		MLCJDNPCFHI res_readData_ = MLCJDNPCFHI.GetRootAsMLCJDNPCFHI(buffer);
		IMLKIIBJABA res_data_ = new IMLKIIBJABA();

		List<HNJNEMJIBKI> BDDHMELPABN_list_ = new List<HNJNEMJIBKI>();
		for(int BDDHMELPABN_idx_ = 0; BDDHMELPABN_idx_ < res_readData_.NHJGDCCCDBJLength; BDDHMELPABN_idx_++)
		{
			LHFKAKHPGBF BDDHMELPABN_readData_ = res_readData_.GetNHJGDCCCDBJ(BDDHMELPABN_idx_);
			HNJNEMJIBKI BDDHMELPABN_data_ = new HNJNEMJIBKI();

			BDDHMELPABN_data_.PPFNGGCBJKC_id = BDDHMELPABN_readData_.BBPHAPFBFHK/*_id*/;
			BDDHMELPABN_data_.HANMDEBPBHG_pic = BDDHMELPABN_readData_.BLJLFEDLAME/*_pic*/;
			BDDHMELPABN_data_.PLALNIIBLOF_en = BDDHMELPABN_readData_.CFLMCGOJJJD/*_en*/;
			BDDHMELPABN_data_.FPOMEEJFBIG_odr = BDDHMELPABN_readData_.AEAKMMJLLDK/*_odr*/;
			BDDHMELPABN_data_.FBFLDFMFFOH_rar = BDDHMELPABN_readData_.ODBPKGJPLMD/*_rar*/;
			BDDHMELPABN_list_.Add(BDDHMELPABN_data_);
		}
		res_data_.BDDHMELPABN = BDDHMELPABN_list_.ToArray();

		return res_data_;
	}
}
