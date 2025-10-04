using FlatBuffers;
using System.Collections.Generic;

public class GMHAHLAIOKB
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint DMEDKJPOLCH_cat { get; set; } // 0xC JAEJJPMKMFI IPKCKAAEEOE_get_cat JOGLLINFLJN_set_cat
	public uint JBGEEPFKIGG_val { get; set; } // 0x10 AHPLCJAKAOP OLOCMINKGON_get_val ABAFHIBFKCE_set_val
	public uint DOOGFEGEKLG_max { get; set; } // 0x14 IKKMNBJGBJK AECMFIOFFJN_get_max NGOJJDOCIDG_set_max
	public uint PLALNIIBLOF_en { get; set; } // 0x18 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int IJEKNCDIIAE_mver { get; set; } // 0x1C FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public uint FBFLDFMFFOH_rar { get; set; } // 0x20 LMKEDCAPLEE HNLMNIOMOLI_get_rar CHHJKABBIBL_set_rar
	public uint FPOMEEJFBIG_odr { get; set; } // 0x24 PJKJIFMIFDJ OEEBAHNAPEC_get_odr BEHAPLPPLNE_set_odr
	public uint EMIJNAFJFJO_expir { get; set; } // 0x28 GBHMMAHHJGG GBGPKONOFGD_get_expir KCFHLAFJJPJ_set_expir
	public uint KHCBANFDKBO_Duration { get; set; } // 0x2C HIGLBJDKMKJ MKDAJEEHBJC_get_Duration ELDLDDCADHA_set_Duration
}
public class KNJFLGCKEIF
{
	public GMHAHLAIOKB[] FNKIIFGDCDM { get; set; } // 0x8 LODMOGMIKOP HDMLBDMIIMD_get_ HCAANAAHKNJ_set_
	public static KNJFLGCKEIF HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x1122BC8
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		BHNBHGFFDII res_readData_ = BHNBHGFFDII.GetRootAsBHNBHGFFDII(buffer);
		KNJFLGCKEIF res_data_ = new KNJFLGCKEIF();

		List<GMHAHLAIOKB> FNKIIFGDCDM_list_ = new List<GMHAHLAIOKB>();
		for(int FNKIIFGDCDM_idx_ = 0; FNKIIFGDCDM_idx_ < res_readData_.CGPJCLDIGDDLength; FNKIIFGDCDM_idx_++)
		{
			FLFCIMHEKJE FNKIIFGDCDM_readData_ = res_readData_.GetCGPJCLDIGDD(FNKIIFGDCDM_idx_);
			GMHAHLAIOKB FNKIIFGDCDM_data_ = new GMHAHLAIOKB();

			FNKIIFGDCDM_data_.PPFNGGCBJKC_id = FNKIIFGDCDM_readData_.BBPHAPFBFHK/*_id*/;
			FNKIIFGDCDM_data_.DMEDKJPOLCH_cat = FNKIIFGDCDM_readData_.ADCLAGBHDBC/*_cat*/;
			FNKIIFGDCDM_data_.JBGEEPFKIGG_val = FNKIIFGDCDM_readData_.KJFEBMBHKOC/*_val*/;
			FNKIIFGDCDM_data_.DOOGFEGEKLG_max = FNKIIFGDCDM_readData_.GEJGMBBCFEE/*_max*/;
			FNKIIFGDCDM_data_.PLALNIIBLOF_en = FNKIIFGDCDM_readData_.CFLMCGOJJJD/*_en*/;
			FNKIIFGDCDM_data_.IJEKNCDIIAE_mver = FNKIIFGDCDM_readData_.OFMGALJGDAO/*_mver*/;
			FNKIIFGDCDM_data_.FBFLDFMFFOH_rar = FNKIIFGDCDM_readData_.ODBPKGJPLMD/*_rar*/;
			FNKIIFGDCDM_data_.FPOMEEJFBIG_odr = FNKIIFGDCDM_readData_.AEAKMMJLLDK/*_odr*/;
			FNKIIFGDCDM_data_.EMIJNAFJFJO_expir = FNKIIFGDCDM_readData_.HHGNAFHNHEK/*_expir*/;
			FNKIIFGDCDM_data_.KHCBANFDKBO_Duration = FNKIIFGDCDM_readData_.LFLGAOPCDLC/*_Duration*/;
			FNKIIFGDCDM_list_.Add(FNKIIFGDCDM_data_);
		}
		res_data_.FNKIIFGDCDM = FNKIIFGDCDM_list_.ToArray();

		return res_data_;
	}
}
