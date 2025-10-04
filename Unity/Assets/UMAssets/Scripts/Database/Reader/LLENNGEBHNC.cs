using FlatBuffers;
using System.Collections.Generic;

public class IBOBDDNBCKJ
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint DMEDKJPOLCH_cat { get; set; } // 0xC JAEJJPMKMFI IPKCKAAEEOE_get_cat JOGLLINFLJN_set_cat
	public uint JBGEEPFKIGG_val { get; set; } // 0x10 AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
	public uint DOOGFEGEKLG_max { get; set; } // 0x14 IKKMNBJGBJK AECMFIOFFJN_get_max NGOJJDOCIDG_set_max
	public uint PLALNIIBLOF_en { get; set; } // 0x18 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int IJEKNCDIIAE_mver { get; set; } // 0x1C FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public uint FBFLDFMFFOH_rar { get; set; } // 0x20 LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
	public uint FPOMEEJFBIG_odr { get; set; } // 0x24 PJKJIFMIFDJ OEEBAHNAPEC_get_odr BEHAPLPPLNE_set_odr
}
public class LLENNGEBHNC
{
	public IBOBDDNBCKJ[] AHGBBPMKAJK { get; set; } // 0x8 NGAOCNIGIFD BPBKKIAJABI_get_ GLFIMOKMIJI_set_
	public static LLENNGEBHNC HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x180CF34
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		EAHMHMEDAOG res_readData_ = EAHMHMEDAOG.GetRootAsEAHMHMEDAOG(buffer);
		LLENNGEBHNC res_data_ = new LLENNGEBHNC();

		List<IBOBDDNBCKJ> AHGBBPMKAJK_list_ = new List<IBOBDDNBCKJ>();
		for(int AHGBBPMKAJK_idx_ = 0; AHGBBPMKAJK_idx_ < res_readData_.GNEIHOGKEDGLength; AHGBBPMKAJK_idx_++)
		{
			JPCMJGNLFFA AHGBBPMKAJK_readData_ = res_readData_.GetGNEIHOGKEDG(AHGBBPMKAJK_idx_);
			IBOBDDNBCKJ AHGBBPMKAJK_data_ = new IBOBDDNBCKJ();

			AHGBBPMKAJK_data_.PPFNGGCBJKC_id = AHGBBPMKAJK_readData_.BBPHAPFBFHK/*_id*/;
			AHGBBPMKAJK_data_.DMEDKJPOLCH_cat = AHGBBPMKAJK_readData_.ADCLAGBHDBC/*_cat*/;
			AHGBBPMKAJK_data_.JBGEEPFKIGG_val = AHGBBPMKAJK_readData_.KJFEBMBHKOC/*_val*/;
			AHGBBPMKAJK_data_.DOOGFEGEKLG_max = AHGBBPMKAJK_readData_.GEJGMBBCFEE/*_max*/;
			AHGBBPMKAJK_data_.PLALNIIBLOF_en = AHGBBPMKAJK_readData_.CFLMCGOJJJD/*_en*/;
			AHGBBPMKAJK_data_.IJEKNCDIIAE_mver = AHGBBPMKAJK_readData_.OFMGALJGDAO/*_mver*/;
			AHGBBPMKAJK_data_.FBFLDFMFFOH_rar = AHGBBPMKAJK_readData_.ODBPKGJPLMD/*_rar*/;
			AHGBBPMKAJK_data_.FPOMEEJFBIG_odr = AHGBBPMKAJK_readData_.AEAKMMJLLDK/*_odr*/;
			AHGBBPMKAJK_list_.Add(AHGBBPMKAJK_data_);
		}
		res_data_.AHGBBPMKAJK = AHGBBPMKAJK_list_.ToArray();

		return res_data_;
	}
}
