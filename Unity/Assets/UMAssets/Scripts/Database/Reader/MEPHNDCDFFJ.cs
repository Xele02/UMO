using FlatBuffers;
using System.Collections.Generic;

public class ILCNBIAEIFB
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint PLALNIIBLOF_en { get; set; } // 0xC DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public uint BDJMFDKLHPM_s_id { get; set; } // 0x10 EOBCNECIOMH GFMBGPMJPLJ_get_s_id ENAMMCHJBDE_set_s_id
	public uint OCAMDLMPBGA_dv { get; set; } // 0x14 JKDMAFHPKDJ DHOGDENEIOI_get_dv DBDFNFLGDFN_set_dv
	public uint CEKKIGJHMDH { get; set; } // 0x18 HCNFHGLLDEG HLNCBLBDANO_get_ JFAGGENCMCI_set_
	public uint AKEFCAFBFKJ_clv { get; set; } // 0x1C HMEFJMIBONM ILAGFIGNAIJ_get_clv ACOFICGMCFO_set_clv
	public uint EPBBNFDFLLD_or { get; set; } // 0x20 NPFHGPKKHIM BLGGFAKCGDK_get_or FMMOBHNGGCF_set_or
	public uint ILJEIMNCKME_cf_id { get; set; } // 0x24 NDGNFIAKHKN JNKBIGPEPNJ_get_cf_id LAAEELACMFF_set_cf_id
	public uint NPHJIIHDEDD_cdf { get; set; } // 0x28 NHKIHHLADHO ECKDCEECIBE_get_cdf BPMKGNFEHPC_set_cdf
	public uint LPADGFJPFDN { get; set; } // 0x2C LJGFJDABFGL IGKDGLPNIIP_get_ KFBOGIKKEGM_set_
	public uint EHDDADDKMFI_f_id { get; set; } // 0x30 MCAKELLLNIO IFFJALDBDDI_get_f_id LMLHCMMIEJH_set_f_id
	public uint NHBLDIPBHNF_pg { get; set; } // 0x34 HEJBEEJPNPG HOMBHFADDNG_get_pg FIEMLIDBMID_set_pg
	public uint EOOCLKKJHLK { get; set; } // 0x38 MDFJCBNPFMF CDGGBBFFOND_get_ CEAKAJILBOG_set_
	public int IJEKNCDIIAE_mver { get; set; } // 0x3C FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
}
public class MEPHNDCDFFJ
{
	public ILCNBIAEIFB[] PEJOABFFHHA { get; set; } // 0x8 BIKBPGHAIAB GLNDKIEHINH_get_ ICACJPGBGFI_set_
	public static MEPHNDCDFFJ HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x1311EFC
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		PLONLLOGMEJ res_readData_ = PLONLLOGMEJ.GetRootAsPLONLLOGMEJ(buffer);
		MEPHNDCDFFJ res_data_ = new MEPHNDCDFFJ();

		List<ILCNBIAEIFB> PEJOABFFHHA_list_ = new List<ILCNBIAEIFB>();
		for(int PEJOABFFHHA_idx_ = 0; PEJOABFFHHA_idx_ < res_readData_.JEEPKOLPINELength; PEJOABFFHHA_idx_++)
		{
			GEGKPJCPNJE PEJOABFFHHA_readData_ = res_readData_.GetJEEPKOLPINE(PEJOABFFHHA_idx_);
			ILCNBIAEIFB PEJOABFFHHA_data_ = new ILCNBIAEIFB();

			PEJOABFFHHA_data_.PPFNGGCBJKC_id = PEJOABFFHHA_readData_.BBPHAPFBFHK/*_id*/;
			PEJOABFFHHA_data_.PLALNIIBLOF_en = PEJOABFFHHA_readData_.CFLMCGOJJJD/*_en*/;
			PEJOABFFHHA_data_.BDJMFDKLHPM_s_id = PEJOABFFHHA_readData_.MJOCIHPPKNO/*_s_id*/;
			PEJOABFFHHA_data_.OCAMDLMPBGA_dv = PEJOABFFHHA_readData_.DDMBKEJNPJK/*_dv*/;
			PEJOABFFHHA_data_.CEKKIGJHMDH = PEJOABFFHHA_readData_.ACNNNALNEFM;
			PEJOABFFHHA_data_.AKEFCAFBFKJ_clv = PEJOABFFHHA_readData_.LOOGFGKLHGK/*_clv*/;
			PEJOABFFHHA_data_.EPBBNFDFLLD_or = PEJOABFFHHA_readData_.HAMMBHGLKML/*_or*/;
			PEJOABFFHHA_data_.ILJEIMNCKME_cf_id = PEJOABFFHHA_readData_.KALCKCHDIDB/*_cf_id*/;
			PEJOABFFHHA_data_.NPHJIIHDEDD_cdf = PEJOABFFHHA_readData_.KANIHFOMCKI/*_cdf*/;
			PEJOABFFHHA_data_.LPADGFJPFDN = PEJOABFFHHA_readData_.GBGHHKPDHOH;
			PEJOABFFHHA_data_.EHDDADDKMFI_f_id = PEJOABFFHHA_readData_.NAJHJIHCOON/*_f_id*/;
			PEJOABFFHHA_data_.NHBLDIPBHNF_pg = PEJOABFFHHA_readData_.LNCMMHCDOJE/*_pg*/;
			PEJOABFFHHA_data_.EOOCLKKJHLK = PEJOABFFHHA_readData_.FOMMMCHNLPL;
			PEJOABFFHHA_data_.IJEKNCDIIAE_mver = PEJOABFFHHA_readData_.OFMGALJGDAO/*_mver*/;
			PEJOABFFHHA_list_.Add(PEJOABFFHHA_data_);
		}
		res_data_.PEJOABFFHHA = PEJOABFFHHA_list_.ToArray();

		return res_data_;
	}
}
