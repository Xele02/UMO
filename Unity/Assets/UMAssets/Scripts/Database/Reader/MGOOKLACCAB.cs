using FlatBuffers;
using System.Collections.Generic;

public class JOBPCOAEJEI
{
	public uint[] BFINGCJHOHI_cnt { get; set; } // 0x8 PIAHJAJPLKA LFMCLIDAPHB_get_cnt EDAEPDGGFJJ_set_cnt
	public uint[] DOOGFEGEKLG_max { get; set; } // 0xC IKKMNBJGBJK AECMFIOFFJN_get_max NGOJJDOCIDG_set_max
	public uint INJIPPBFMIG_r_id { get; set; } // 0x10 ONFGDIOJLPA HKIKFJPCKBG_get_r_id GECBGBGMDGL_set_r_id
	public uint[] EHKJFNAABMC_rat { get; set; } // 0x14 FAOHBEIIENC LGFHJLOCEDP_get_rat BBBACEEAPNI_set_rat
}
public class PPAILKPGOHE
{
	public uint BDJMFDKLHPM_s_id { get; set; } // 0x8 EOBCNECIOMH GFMBGPMJPLJ_get_s_id ENAMMCHJBDE_set_s_id
	public uint[] AIHOJKFNEEN_itm { get; set; } // 0xC GGBFCEFNCFM BGFIPHMMOGA_get_itm DHAIHODDOGM_set_itm
}
public class ENDMPLADFDI
{
	public uint[] DOOGFEGEKLG_max { get; set; } // 0x8 IKKMNBJGBJK AECMFIOFFJN_get_max NGOJJDOCIDG_set_max
	public uint INJIPPBFMIG_r_id { get; set; } // 0xC ONFGDIOJLPA HKIKFJPCKBG_get_r_id GECBGBGMDGL_set_r_id
	public uint[] EHKJFNAABMC_rat { get; set; } // 0x10 FAOHBEIIENC LGFHJLOCEDP_get_rat BBBACEEAPNI_set_rat
}
public class HPCDKBLCICB
{
	public uint BDJMFDKLHPM_s_id { get; set; } // 0x8 EOBCNECIOMH GFMBGPMJPLJ_get_s_id ENAMMCHJBDE_set_s_id
	public uint[] AIHOJKFNEEN_itm { get; set; } // 0xC GGBFCEFNCFM BGFIPHMMOGA_get_itm DHAIHODDOGM_set_itm
}
public class MGOOKLACCAB
{
	public JOBPCOAEJEI[] EPNKMPDCNJM { get; set; } // 0x8 HOOIHIAFKLA HBEOCOFLMGO_get_ IOKIIBHHGKD_set_
	public PPAILKPGOHE[] NLLEGNEHGFO { get; set; } // 0xC GOAHCDNBHKF GOMKACNICGP_get_ MDPLHCOGHAN_set_
	public ENDMPLADFDI[] GFFKLDFECOD { get; set; } // 0x10 HMOMNFFPFBL KKNAFNEBEEE_get_ PACMJDPNPEI_set_
	public HPCDKBLCICB[] FCKIKCOMCGA { get; set; } // 0x14 OJIMMBIIPMO EKEFMCAGBHB_get_ BKBGAFALILA_set_
	public int[] CHPPGDIEJPK { get; set; } // 0x18 IPIBKJNKEIN BCPNAFHCKGB_get_ KBGBFHKJNGK_set_
	public int[] DPBLNJLNMOF { get; set; } // 0x1C NJNELLBJICI IKNJLPINJND_get_ LCPPPIOPBBC_set_
	public int[] JLDHMJLGGDO { get; set; } // 0x20 PDFNKGEEJHH ICNLGGHPMPJ_get_ OGBJGLGJPFK_set_
	public int[] FHPCBBOAHLJ { get; set; } // 0x24 CAHGMIIBNNN IMDLJDGCGBA_get_ ACMBBMIJGDH_set_
	public int[] IFJHGKNBGIC { get; set; } // 0x28 BNDOBAICOEO FICEBEIEDGN_get_ NPDIAIEFFLM_set_
	public static MGOOKLACCAB HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x1319088
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		BECPINGJFLI res_readData_ = BECPINGJFLI.GetRootAsBECPINGJFLI(buffer);
		MGOOKLACCAB res_data_ = new MGOOKLACCAB();

		List<JOBPCOAEJEI> EPNKMPDCNJM_list_ = new List<JOBPCOAEJEI>();
		for(int EPNKMPDCNJM_idx_ = 0; EPNKMPDCNJM_idx_ < res_readData_.FMCNJAKFCIDLength; EPNKMPDCNJM_idx_++)
		{
			OALBFMECCIL EPNKMPDCNJM_readData_ = res_readData_.GetFMCNJAKFCID(EPNKMPDCNJM_idx_);
			JOBPCOAEJEI EPNKMPDCNJM_data_ = new JOBPCOAEJEI();

			List<uint> BFINGCJHOHI_list_ = new List<uint>();
			for(int BFINGCJHOHI_idx_ = 0; BFINGCJHOHI_idx_ < EPNKMPDCNJM_readData_.BNCIPLKECMCLength; BFINGCJHOHI_idx_++)
			{
				BFINGCJHOHI_list_.Add(EPNKMPDCNJM_readData_.GetBNCIPLKECMC(BFINGCJHOHI_idx_));
			}
			EPNKMPDCNJM_data_.BFINGCJHOHI_cnt = BFINGCJHOHI_list_.ToArray();

			List<uint> DOOGFEGEKLG_list_ = new List<uint>();
			for(int DOOGFEGEKLG_idx_ = 0; DOOGFEGEKLG_idx_ < EPNKMPDCNJM_readData_.NMEEJNHKPCNLength; DOOGFEGEKLG_idx_++)
			{
				DOOGFEGEKLG_list_.Add(EPNKMPDCNJM_readData_.GetNMEEJNHKPCN(DOOGFEGEKLG_idx_));
			}
			EPNKMPDCNJM_data_.DOOGFEGEKLG_max = DOOGFEGEKLG_list_.ToArray();

			EPNKMPDCNJM_data_.INJIPPBFMIG_r_id = EPNKMPDCNJM_readData_.CNOKDINCFAO/*_r_id*/;
			List<uint> EHKJFNAABMC_list_ = new List<uint>();
			for(int EHKJFNAABMC_idx_ = 0; EHKJFNAABMC_idx_ < EPNKMPDCNJM_readData_.NGGAJCBPGFILength; EHKJFNAABMC_idx_++)
			{
				EHKJFNAABMC_list_.Add(EPNKMPDCNJM_readData_.GetNGGAJCBPGFI(EHKJFNAABMC_idx_));
			}
			EPNKMPDCNJM_data_.EHKJFNAABMC_rat = EHKJFNAABMC_list_.ToArray();

			EPNKMPDCNJM_list_.Add(EPNKMPDCNJM_data_);
		}
		res_data_.EPNKMPDCNJM = EPNKMPDCNJM_list_.ToArray();

		List<PPAILKPGOHE> NLLEGNEHGFO_list_ = new List<PPAILKPGOHE>();
		for(int NLLEGNEHGFO_idx_ = 0; NLLEGNEHGFO_idx_ < res_readData_.COJCIOPMDIELength; NLLEGNEHGFO_idx_++)
		{
			IFOEEDHKMMF NLLEGNEHGFO_readData_ = res_readData_.GetCOJCIOPMDIE(NLLEGNEHGFO_idx_);
			PPAILKPGOHE NLLEGNEHGFO_data_ = new PPAILKPGOHE();

			NLLEGNEHGFO_data_.BDJMFDKLHPM_s_id = NLLEGNEHGFO_readData_.MJOCIHPPKNO/*_s_id*/;
			List<uint> AIHOJKFNEEN_list_ = new List<uint>();
			for(int AIHOJKFNEEN_idx_ = 0; AIHOJKFNEEN_idx_ < NLLEGNEHGFO_readData_.LEFPIGNDJNCLength; AIHOJKFNEEN_idx_++)
			{
				AIHOJKFNEEN_list_.Add(NLLEGNEHGFO_readData_.GetLEFPIGNDJNC(AIHOJKFNEEN_idx_));
			}
			NLLEGNEHGFO_data_.AIHOJKFNEEN_itm = AIHOJKFNEEN_list_.ToArray();

			NLLEGNEHGFO_list_.Add(NLLEGNEHGFO_data_);
		}
		res_data_.NLLEGNEHGFO = NLLEGNEHGFO_list_.ToArray();

		List<ENDMPLADFDI> GFFKLDFECOD_list_ = new List<ENDMPLADFDI>();
		for(int GFFKLDFECOD_idx_ = 0; GFFKLDFECOD_idx_ < res_readData_.BICLHKLAJLPLength; GFFKLDFECOD_idx_++)
		{
			KAKPINDJHMG GFFKLDFECOD_readData_ = res_readData_.GetBICLHKLAJLP(GFFKLDFECOD_idx_);
			ENDMPLADFDI GFFKLDFECOD_data_ = new ENDMPLADFDI();

			List<uint> DOOGFEGEKLG_list_ = new List<uint>();
			for(int DOOGFEGEKLG_idx_ = 0; DOOGFEGEKLG_idx_ < GFFKLDFECOD_readData_.NMEEJNHKPCNLength; DOOGFEGEKLG_idx_++)
			{
				DOOGFEGEKLG_list_.Add(GFFKLDFECOD_readData_.GetNMEEJNHKPCN(DOOGFEGEKLG_idx_));
			}
			GFFKLDFECOD_data_.DOOGFEGEKLG_max = DOOGFEGEKLG_list_.ToArray();

			GFFKLDFECOD_data_.INJIPPBFMIG_r_id = GFFKLDFECOD_readData_.CNOKDINCFAO/*_r_id*/;
			List<uint> EHKJFNAABMC_list_ = new List<uint>();
			for(int EHKJFNAABMC_idx_ = 0; EHKJFNAABMC_idx_ < GFFKLDFECOD_readData_.NGGAJCBPGFILength; EHKJFNAABMC_idx_++)
			{
				EHKJFNAABMC_list_.Add(GFFKLDFECOD_readData_.GetNGGAJCBPGFI(EHKJFNAABMC_idx_));
			}
			GFFKLDFECOD_data_.EHKJFNAABMC_rat = EHKJFNAABMC_list_.ToArray();

			GFFKLDFECOD_list_.Add(GFFKLDFECOD_data_);
		}
		res_data_.GFFKLDFECOD = GFFKLDFECOD_list_.ToArray();

		List<HPCDKBLCICB> FCKIKCOMCGA_list_ = new List<HPCDKBLCICB>();
		for(int FCKIKCOMCGA_idx_ = 0; FCKIKCOMCGA_idx_ < res_readData_.NCBNELGABFHLength; FCKIKCOMCGA_idx_++)
		{
			EHCHNFGDMIN FCKIKCOMCGA_readData_ = res_readData_.GetNCBNELGABFH(FCKIKCOMCGA_idx_);
			HPCDKBLCICB FCKIKCOMCGA_data_ = new HPCDKBLCICB();

			FCKIKCOMCGA_data_.BDJMFDKLHPM_s_id = FCKIKCOMCGA_readData_.MJOCIHPPKNO/*_s_id*/;
			List<uint> AIHOJKFNEEN_list_ = new List<uint>();
			for(int AIHOJKFNEEN_idx_ = 0; AIHOJKFNEEN_idx_ < FCKIKCOMCGA_readData_.LEFPIGNDJNCLength; AIHOJKFNEEN_idx_++)
			{
				AIHOJKFNEEN_list_.Add(FCKIKCOMCGA_readData_.GetLEFPIGNDJNC(AIHOJKFNEEN_idx_));
			}
			FCKIKCOMCGA_data_.AIHOJKFNEEN_itm = AIHOJKFNEEN_list_.ToArray();

			FCKIKCOMCGA_list_.Add(FCKIKCOMCGA_data_);
		}
		res_data_.FCKIKCOMCGA = FCKIKCOMCGA_list_.ToArray();

		List<int> CHPPGDIEJPK_list_ = new List<int>();
		for(int CHPPGDIEJPK_idx_ = 0; CHPPGDIEJPK_idx_ < res_readData_.NGKPDABJNMKLength; CHPPGDIEJPK_idx_++)
		{
			CHPPGDIEJPK_list_.Add(res_readData_.GetNGKPDABJNMK(CHPPGDIEJPK_idx_));
		}
		res_data_.CHPPGDIEJPK = CHPPGDIEJPK_list_.ToArray();

		List<int> DPBLNJLNMOF_list_ = new List<int>();
		for(int DPBLNJLNMOF_idx_ = 0; DPBLNJLNMOF_idx_ < res_readData_.AOKADHKMIFMLength; DPBLNJLNMOF_idx_++)
		{
			DPBLNJLNMOF_list_.Add(res_readData_.GetAOKADHKMIFM(DPBLNJLNMOF_idx_));
		}
		res_data_.DPBLNJLNMOF = DPBLNJLNMOF_list_.ToArray();

		List<int> JLDHMJLGGDO_list_ = new List<int>();
		for(int JLDHMJLGGDO_idx_ = 0; JLDHMJLGGDO_idx_ < res_readData_.AKMNCOGDAIMLength; JLDHMJLGGDO_idx_++)
		{
			JLDHMJLGGDO_list_.Add(res_readData_.GetAKMNCOGDAIM(JLDHMJLGGDO_idx_));
		}
		res_data_.JLDHMJLGGDO = JLDHMJLGGDO_list_.ToArray();

		List<int> FHPCBBOAHLJ_list_ = new List<int>();
		for(int FHPCBBOAHLJ_idx_ = 0; FHPCBBOAHLJ_idx_ < res_readData_.LAHBHILKOHDLength; FHPCBBOAHLJ_idx_++)
		{
			FHPCBBOAHLJ_list_.Add(res_readData_.GetLAHBHILKOHD(FHPCBBOAHLJ_idx_));
		}
		res_data_.FHPCBBOAHLJ = FHPCBBOAHLJ_list_.ToArray();

		List<int> IFJHGKNBGIC_list_ = new List<int>();
		for(int IFJHGKNBGIC_idx_ = 0; IFJHGKNBGIC_idx_ < res_readData_.NIGBGMIANCELength; IFJHGKNBGIC_idx_++)
		{
			IFJHGKNBGIC_list_.Add(res_readData_.GetNIGBGMIANCE(IFJHGKNBGIC_idx_));
		}
		res_data_.IFJHGKNBGIC = IFJHGKNBGIC_list_.ToArray();

		return res_data_;
	}
}
