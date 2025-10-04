using FlatBuffers;
using System.Collections.Generic;

public class BCCFAPDAFOE
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int IJEKNCDIIAE_mver { get; set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public int PLALNIIBLOF_en { get; set; } // 0x10 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int BCKCEEMNKCH { get; set; } // 0x14 HNOKIOCJCGC KMKCBONBHCN_get_ MMKFAENKJPK_set_
	public int BDJMFDKLHPM_s_id { get; set; } // 0x18 EOBCNECIOMH GFMBGPMJPLJ_get_s_id ENAMMCHJBDE_set_s_id
	public int PDBPFJJCADD_open_at { get; set; } // 0x1C PMJMBGBCIGO FOACOMBHPAC_get_open_at NBACOBCOJCA_set_open_at
	public int FDBNFFNFOND_close_at { get; set; } // 0x20 INOJHLHGKMI BPJOGHJCLDJ_get_close_at NLJKMCHOCBK_set_close_at
}
public class MCCFOKHKJIC
{
	public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public int PLALNIIBLOF_en { get; set; } // 0xC DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public int BCKCEEMNKCH { get; set; } // 0x10 HNOKIOCJCGC KMKCBONBHCN_get_ MMKFAENKJPK_set_
	public int PIDAAPMCAML { get; set; } // 0x14 FBMFEMGAJPD BHFHPNBGGBA_get_ ILHFKGPINNI_set_
	public int OIAAFFHGBBD_AdvId { get; set; } // 0x18 JOJKCBIKOIO ENLDJCEIHCK_get_AdvId GOMCJDMDDBG_set_AdvId
	public int ODNOJKHHEOP_c_id { get; set; } // 0x1C HHGINHPEICA NINNDNIDNGJ_get_c_id DEKDOBENELE_set_c_id
	public int DFMOIKJOCGH { get; set; } // 0x20 MFFLHOELPCE NFBPOLHEJIA_get_ DPCFHPDOKDN_set_
}
public class BLOHGJIKLAK
{
	public BCCFAPDAFOE[] MLJNCEIFECL { get; set; } // 0x8 HCKJIAKFGCH GOEBFAEFFMB_get_ CHCLIHFFFPK_set_
	public MCCFOKHKJIC[] FGAOKKECNIH { get; set; } // 0xC CALGMBGPKOL JBLDLHMDFCI_get_ EKEBNPNMBAE_set_
	public static BLOHGJIKLAK HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x19C2300
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		HKILNANKLLB res_readData_ = HKILNANKLLB.GetRootAsHKILNANKLLB(buffer);
		BLOHGJIKLAK res_data_ = new BLOHGJIKLAK();

		List<BCCFAPDAFOE> MLJNCEIFECL_list_ = new List<BCCFAPDAFOE>();
		for(int MLJNCEIFECL_idx_ = 0; MLJNCEIFECL_idx_ < res_readData_.JCEDIBCEFOJLength; MLJNCEIFECL_idx_++)
		{
			JJEDGMMFLNA MLJNCEIFECL_readData_ = res_readData_.GetJCEDIBCEFOJ(MLJNCEIFECL_idx_);
			BCCFAPDAFOE MLJNCEIFECL_data_ = new BCCFAPDAFOE();

			MLJNCEIFECL_data_.PPFNGGCBJKC_id = MLJNCEIFECL_readData_.BBPHAPFBFHK/*_id*/;
			MLJNCEIFECL_data_.IJEKNCDIIAE_mver = MLJNCEIFECL_readData_.OFMGALJGDAO/*_mver*/;
			MLJNCEIFECL_data_.PLALNIIBLOF_en = MLJNCEIFECL_readData_.CFLMCGOJJJD/*_en*/;
			MLJNCEIFECL_data_.BCKCEEMNKCH = MLJNCEIFECL_readData_.GKNBEHEMMFH;
			MLJNCEIFECL_data_.BDJMFDKLHPM_s_id = MLJNCEIFECL_readData_.MJOCIHPPKNO/*_s_id*/;
			MLJNCEIFECL_data_.PDBPFJJCADD_open_at = MLJNCEIFECL_readData_.NJLJEKDBPCH/*_open_at*/;
			MLJNCEIFECL_data_.FDBNFFNFOND_close_at = MLJNCEIFECL_readData_.MAOAGDBDBIB/*_close_at*/;
			MLJNCEIFECL_list_.Add(MLJNCEIFECL_data_);
		}
		res_data_.MLJNCEIFECL = MLJNCEIFECL_list_.ToArray();

		List<MCCFOKHKJIC> FGAOKKECNIH_list_ = new List<MCCFOKHKJIC>();
		for(int FGAOKKECNIH_idx_ = 0; FGAOKKECNIH_idx_ < res_readData_.GFOJACKHEDCLength; FGAOKKECNIH_idx_++)
		{
			CBMILEEGEPN FGAOKKECNIH_readData_ = res_readData_.GetGFOJACKHEDC(FGAOKKECNIH_idx_);
			MCCFOKHKJIC FGAOKKECNIH_data_ = new MCCFOKHKJIC();

			FGAOKKECNIH_data_.PPFNGGCBJKC_id = FGAOKKECNIH_readData_.BBPHAPFBFHK/*_id*/;
			FGAOKKECNIH_data_.PLALNIIBLOF_en = FGAOKKECNIH_readData_.CFLMCGOJJJD/*_en*/;
			FGAOKKECNIH_data_.BCKCEEMNKCH = FGAOKKECNIH_readData_.GKNBEHEMMFH;
			FGAOKKECNIH_data_.PIDAAPMCAML = FGAOKKECNIH_readData_.DNMMADEPEKH;
			FGAOKKECNIH_data_.OIAAFFHGBBD_AdvId = FGAOKKECNIH_readData_.CEPBOFBJBKB/*_AdvId*/;
			FGAOKKECNIH_data_.ODNOJKHHEOP_c_id = FGAOKKECNIH_readData_.IHPEJOJEPFM/*_c_id*/;
			FGAOKKECNIH_data_.DFMOIKJOCGH = FGAOKKECNIH_readData_.BBDGLCFCBFL;
			FGAOKKECNIH_list_.Add(FGAOKKECNIH_data_);
		}
		res_data_.FGAOKKECNIH = FGAOKKECNIH_list_.ToArray();

		return res_data_;
	}
}
