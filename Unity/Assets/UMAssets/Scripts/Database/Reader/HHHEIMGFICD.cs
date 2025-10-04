using FlatBuffers;
using System.Collections.Generic;

public class GGDEOLDOFMH
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int AGNHPHEJKMK_tgt { get; set; } // 0xC BCKMGEBHABF MNJIGLFFJAH_get_tgt MEHEHNALGIH_set_tgt
	public int EILKGEADKGH_Order { get; set; } // 0x10 PBIPJHCABED NPDDACIHBKD_get_Order BJJMCKHBPNH_set_Order
	public int GBJFNGCDKPM_typ { get; set; } // 0x14 GHLFADHILNN CEJJMKODOGK_get_typ HOHCEBMMACI_set_typ
	public int PLALNIIBLOF_en { get; set; } // 0x18 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public string ADCMNODJBGJ_title { get; set; } // 0x1C PDOIKFFAKNG AJDDKABOOLK_get_title GHAHAGNIELN_set_title
	public string[] BNMCMNPPPCI_ChoiceText { get; set; } // 0x20 OJDCFHIBPBH OJPIPIHODMK_get_ChoiceText MHKOFEGPBMG_set_ChoiceText
	public int EMNLOGDDOBC { get; set; } // 0x24 LKKBIIFHIJH LLPCDDPBCIF_get_ IANFOOFFAHD_set_
	public int IICECOLFEEL { get; set; } // 0x28 GDCLPLLNMAP NPILABMMKMB_get_ AFPJONFBLEO_set_
	public int IJEKNCDIIAE_mver { get; set; } // 0x2C FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public int NNDBJGDFEEM_Min { get; set; } // 0x30 CNDGBLDLDCC EHNOFMPHLFC_get_Min GCANPOPEKEE_set_Min
	public int DOOGFEGEKLG_max { get; set; } // 0x34 IKKMNBJGBJK AECMFIOFFJN_get_max NGOJJDOCIDG_set_max
	public int LLNDMKBBNIJ_ver { get; set; } // 0x38 BGOALFDCFBL OHMCGADLNCA_get_ver KJNHDFEGEGE_set_ver
}
public class HHHEIMGFICD
{
	public GGDEOLDOFMH[] EEMGLFBGGKN { get; set; } // 0x8 HECMJMBFELK JBBCGDLBBAA_get_ FANKGMKNGGK_set_
	public static HHHEIMGFICD HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x1759CA8
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		EBDJIPDILLC res_readData_ = EBDJIPDILLC.GetRootAsEBDJIPDILLC(buffer);
		HHHEIMGFICD res_data_ = new HHHEIMGFICD();

		List<GGDEOLDOFMH> EEMGLFBGGKN_list_ = new List<GGDEOLDOFMH>();
		for(int EEMGLFBGGKN_idx_ = 0; EEMGLFBGGKN_idx_ < res_readData_.BIDEEFOGFCGLength; EEMGLFBGGKN_idx_++)
		{
			EJMDBHGILEI EEMGLFBGGKN_readData_ = res_readData_.GetBIDEEFOGFCG(EEMGLFBGGKN_idx_);
			GGDEOLDOFMH EEMGLFBGGKN_data_ = new GGDEOLDOFMH();

			EEMGLFBGGKN_data_.PPFNGGCBJKC_id = EEMGLFBGGKN_readData_.BBPHAPFBFHK/*_id*/;
			EEMGLFBGGKN_data_.AGNHPHEJKMK_tgt = EEMGLFBGGKN_readData_.HLPHBGLMBIO/*_tgt*/;
			EEMGLFBGGKN_data_.EILKGEADKGH_Order = EEMGLFBGGKN_readData_.BPMBFFDNMDD/*_Order*/;
			EEMGLFBGGKN_data_.GBJFNGCDKPM_typ = EEMGLFBGGKN_readData_.LPJPOOHJKAE/*_typ*/;
			EEMGLFBGGKN_data_.PLALNIIBLOF_en = EEMGLFBGGKN_readData_.CFLMCGOJJJD/*_en*/;
			EEMGLFBGGKN_data_.ADCMNODJBGJ_title = EEMGLFBGGKN_readData_.AFJJKGBHFJP/*_title*/;
			List<string> BNMCMNPPPCI_list_ = new List<string>();
			for(int BNMCMNPPPCI_idx_ = 0; BNMCMNPPPCI_idx_ < EEMGLFBGGKN_readData_.NKCBBELDHOILength; BNMCMNPPPCI_idx_++)
			{
				BNMCMNPPPCI_list_.Add(EEMGLFBGGKN_readData_.GetNKCBBELDHOI(BNMCMNPPPCI_idx_));
			}
			EEMGLFBGGKN_data_.BNMCMNPPPCI_ChoiceText = BNMCMNPPPCI_list_.ToArray();

			EEMGLFBGGKN_data_.EMNLOGDDOBC = EEMGLFBGGKN_readData_.PPGJPNONPDB;
			EEMGLFBGGKN_data_.IICECOLFEEL = EEMGLFBGGKN_readData_.COBFEKPMGIB;
			EEMGLFBGGKN_data_.IJEKNCDIIAE_mver = EEMGLFBGGKN_readData_.OFMGALJGDAO/*_mver*/;
			EEMGLFBGGKN_data_.NNDBJGDFEEM_Min = EEMGLFBGGKN_readData_.CCIHMCAPHCB/*_Min*/;
			EEMGLFBGGKN_data_.DOOGFEGEKLG_max = EEMGLFBGGKN_readData_.GEJGMBBCFEE/*_max*/;
			EEMGLFBGGKN_data_.LLNDMKBBNIJ_ver = EEMGLFBGGKN_readData_.CNNEAFFOPAO/*_ver*/;
			EEMGLFBGGKN_list_.Add(EEMGLFBGGKN_data_);
		}
		res_data_.EEMGLFBGGKN = EEMGLFBGGKN_list_.ToArray();

		return res_data_;
	}
}
